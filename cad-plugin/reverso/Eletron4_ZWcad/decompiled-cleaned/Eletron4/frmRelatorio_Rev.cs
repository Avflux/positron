using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Rev : Form
{
	private IContainer WHQ8bGuE47;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog SqV8MtGrMv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip Evs8OPYhbq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	private Button hCN8I116YH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbRev")]
	private ComboBox zuE878VkC1;

	[AccessedThroughProperty("tbPaginas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox YdB8qUFGmK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbRev")]
	private Label jv88acgag6;

	[CompilerGenerated]
	[AccessedThroughProperty("lbPaginas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label U1D88VLuPM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDescicao")]
	private Label IwC8NLA8ZB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescicao")]
	private TextBox CTw8FvpviU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	[CompilerGenerated]
	private Button oSD8Q4DaRT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox hhI8PuwOug;

	[AccessedThroughProperty("bt1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button kfS8cnJQxn;

	[AccessedThroughProperty("TBNome")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox bVq8KAqpN4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt2")]
	private Button HRE8eonjlF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSet")]
	private Button YuV82l6ljL;

	[AccessedThroughProperty("bt3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button iIJ831DIN9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt5")]
	private Button qhO8nwAhbE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt4")]
	private Button lcq81nmKGE;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox p3u8l5yN5d;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelLinhas")]
	private Label eM2857ZxKo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorBloco")]
	private Button Vcu80QxdKE;

	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox fgw8RvnT9r;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelCorTexto")]
	private Label W688mcDDR5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	private Label IrU8XWUEGr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btCorTextoBloco")]
	private Button kqN8Uelnfk;

	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox aJg8yUE3N5;

	[AccessedThroughProperty("TBAlturaDoBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox fG88gDLjGJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LBAlturaDoBloco")]
	private Label r8Y8A7IcPA;

	[CompilerGenerated]
	[AccessedThroughProperty("TBDisteEntreColunas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox XG08s7PSaq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LabelTamanhoFonte")]
	private Label VjZ8Bv5DrQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBFonte")]
	private ComboBox HSm8VeDMKu;

	[AccessedThroughProperty("LabelQuantColunas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label aNp8ujLTOt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBColunas")]
	[CompilerGenerated]
	private ComboBox CAq8ENxDhY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LabelStiloLinha")]
	private Label B398ZYaQ45;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFonteBloco")]
	private TextBox DH58i5pUkV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	[CompilerGenerated]
	private Label BBX8SwKPBW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TextBox1")]
	private TextBox apO84elpxy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TextBox2")]
	private TextBox y8t8CMU2MW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TextBox3")]
	private TextBox TLZ8YBsqCr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt1D")]
	[CompilerGenerated]
	private Button YS48rYSKJ0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt1A")]
	[CompilerGenerated]
	private Button w8E89GmmHH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt2A")]
	private Button XXE8zxGQ90;

	[AccessedThroughProperty("bt2D")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button au3NWHFqYc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt3A")]
	private Button qGNNp8q4dE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt3D")]
	private Button NOrNT4XVoB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbRev2")]
	private Label IpONJGk1xi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbPaginas2")]
	private Label C1mNh5pK6w;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDescicao2")]
	private Label PtMNokK2kc;

	[CompilerGenerated]
	[AccessedThroughProperty("CKAgrupaPaginas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox RVsNGKmooV;

	private Relatorios_Rev.ConfigReV lT3NH17Fic;

	private bool TygNkq7Hov;

	private string eoENdmtB33;

	private ColorDialog U1FNfB9E0s;

	private int dMcND2t28K;

	private int FhoNveT4M5;

	private double avrN6VJu8X;

	private double LZSNtwDZR0;

	private double IA8NjWEViG;

	private int breNLB1qkH;

	private int gi3NwfJWI7;

	private int KHBNxVwRLv;

	private int G4sNbtPqY7;

	private int sgvNM4oC4C;

	private int V98NOZW9vN;

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return hCN8I116YH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gixarGjF87;
			Button button = hCN8I116YH;
			if (button != null)
			{
				button.Click -= value2;
			}
			hCN8I116YH = value;
			button = hCN8I116YH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox cbRev
	{
		[CompilerGenerated]
		get
		{
			return zuE878VkC1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xt2a9Cv8b5;
			ComboBox comboBox = zuE878VkC1;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			zuE878VkC1 = value;
			comboBox = zuE878VkC1;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox tbPaginas
	{
		[CompilerGenerated]
		get
		{
			return YdB8qUFGmK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YdB8qUFGmK = value;
		}
	}

	internal virtual Label lbRev
	{
		[CompilerGenerated]
		get
		{
			return jv88acgag6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jv88acgag6 = value;
		}
	}

	internal virtual Label lbPaginas
	{
		[CompilerGenerated]
		get
		{
			return U1D88VLuPM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			U1D88VLuPM = value;
		}
	}

	internal virtual Label lbDescicao
	{
		[CompilerGenerated]
		get
		{
			return IwC8NLA8ZB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IwC8NLA8ZB = value;
		}
	}

	internal virtual TextBox tbDescicao
	{
		[CompilerGenerated]
		get
		{
			return CTw8FvpviU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CTw8FvpviU = value;
		}
	}

	internal virtual Button btApagar
	{
		[CompilerGenerated]
		get
		{
			return oSD8Q4DaRT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iLuazhslYA;
			Button button = oSD8Q4DaRT;
			if (button != null)
			{
				button.Click -= value2;
			}
			oSD8Q4DaRT = value;
			button = oSD8Q4DaRT;
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
			return hhI8PuwOug;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hhI8PuwOug = value;
		}
	}

	internal virtual Button bt1
	{
		[CompilerGenerated]
		get
		{
			return kfS8cnJQxn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = H1e8pTqmdB;
			Button button = kfS8cnJQxn;
			if (button != null)
			{
				button.Click -= value2;
			}
			kfS8cnJQxn = value;
			button = kfS8cnJQxn;
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
			return bVq8KAqpN4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bVq8KAqpN4 = value;
		}
	}

	internal virtual Button bt2
	{
		[CompilerGenerated]
		get
		{
			return HRE8eonjlF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nEd8T0ivxr;
			Button button = HRE8eonjlF;
			if (button != null)
			{
				button.Click -= value2;
			}
			HRE8eonjlF = value;
			button = HRE8eonjlF;
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
			return YuV82l6ljL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = k5J8WBuQSb;
			Button button = YuV82l6ljL;
			if (button != null)
			{
				button.Click -= value2;
			}
			YuV82l6ljL = value;
			button = YuV82l6ljL;
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
			return iIJ831DIN9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Kdw8JJLmBt;
			Button button = iIJ831DIN9;
			if (button != null)
			{
				button.Click -= value2;
			}
			iIJ831DIN9 = value;
			button = iIJ831DIN9;
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
			return qhO8nwAhbE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Dm28oNFV8u;
			Button button = qhO8nwAhbE;
			if (button != null)
			{
				button.Click -= value2;
			}
			qhO8nwAhbE = value;
			button = qhO8nwAhbE;
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
			return lcq81nmKGE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JgI8h3PTpU;
			Button button = lcq81nmKGE;
			if (button != null)
			{
				button.Click -= value2;
			}
			lcq81nmKGE = value;
			button = lcq81nmKGE;
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
			return p3u8l5yN5d;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			p3u8l5yN5d = value;
		}
	}

	internal virtual Label LabelLinhas
	{
		[CompilerGenerated]
		get
		{
			return eM2857ZxKo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eM2857ZxKo = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return Vcu80QxdKE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bGnaiwqP1M;
			Button button = Vcu80QxdKE;
			if (button != null)
			{
				button.Click -= value2;
			}
			Vcu80QxdKE = value;
			button = Vcu80QxdKE;
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
			return fgw8RvnT9r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fgw8RvnT9r = value;
		}
	}

	internal virtual Label LabelCorTexto
	{
		[CompilerGenerated]
		get
		{
			return W688mcDDR5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			W688mcDDR5 = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return IrU8XWUEGr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IrU8XWUEGr = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return kqN8Uelnfk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ndRaSLBBok;
			Button button = kqN8Uelnfk;
			if (button != null)
			{
				button.Click -= value2;
			}
			kqN8Uelnfk = value;
			button = kqN8Uelnfk;
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
			return aJg8yUE3N5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aJg8yUE3N5 = value;
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return fG88gDLjGJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fG88gDLjGJ = value;
		}
	}

	internal virtual Label LBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return r8Y8A7IcPA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			r8Y8A7IcPA = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return XG08s7PSaq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = g9t8DOsBe3;
			TextBox textBox = XG08s7PSaq;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			XG08s7PSaq = value;
			textBox = XG08s7PSaq;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LabelTamanhoFonte
	{
		[CompilerGenerated]
		get
		{
			return VjZ8Bv5DrQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VjZ8Bv5DrQ = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return HSm8VeDMKu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HSm8VeDMKu = value;
		}
	}

	internal virtual Label LabelQuantColunas
	{
		[CompilerGenerated]
		get
		{
			return aNp8ujLTOt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aNp8ujLTOt = value;
		}
	}

	internal virtual ComboBox CBColunas
	{
		[CompilerGenerated]
		get
		{
			return CAq8ENxDhY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = plb8fwsgUv;
			ComboBox comboBox = CAq8ENxDhY;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			CAq8ENxDhY = value;
			comboBox = CAq8ENxDhY;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return B398ZYaQ45;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			B398ZYaQ45 = value;
		}
	}

	internal virtual TextBox tbFonteBloco
	{
		[CompilerGenerated]
		get
		{
			return DH58i5pUkV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DH58i5pUkV = value;
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return BBX8SwKPBW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BBX8SwKPBW = value;
		}
	}

	internal virtual TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return apO84elpxy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			apO84elpxy = value;
		}
	}

	internal virtual TextBox TextBox2
	{
		[CompilerGenerated]
		get
		{
			return y8t8CMU2MW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			y8t8CMU2MW = value;
		}
	}

	internal virtual TextBox TextBox3
	{
		[CompilerGenerated]
		get
		{
			return TLZ8YBsqCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TLZ8YBsqCr = value;
		}
	}

	internal virtual Button bt1D
	{
		[CompilerGenerated]
		get
		{
			return YS48rYSKJ0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wBw8v2aGrS;
			Button button = YS48rYSKJ0;
			if (button != null)
			{
				button.Click -= value2;
			}
			YS48rYSKJ0 = value;
			button = YS48rYSKJ0;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt1A
	{
		[CompilerGenerated]
		get
		{
			return w8E89GmmHH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aaQ86kNI8K;
			Button button = w8E89GmmHH;
			if (button != null)
			{
				button.Click -= value2;
			}
			w8E89GmmHH = value;
			button = w8E89GmmHH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt2A
	{
		[CompilerGenerated]
		get
		{
			return XXE8zxGQ90;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eY88jLMbcy;
			Button button = XXE8zxGQ90;
			if (button != null)
			{
				button.Click -= value2;
			}
			XXE8zxGQ90 = value;
			button = XXE8zxGQ90;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt2D
	{
		[CompilerGenerated]
		get
		{
			return au3NWHFqYc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = b1k8tvHDGR;
			Button button = au3NWHFqYc;
			if (button != null)
			{
				button.Click -= value2;
			}
			au3NWHFqYc = value;
			button = au3NWHFqYc;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt3A
	{
		[CompilerGenerated]
		get
		{
			return qGNNp8q4dE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RIh8w4Ke9G;
			Button button = qGNNp8q4dE;
			if (button != null)
			{
				button.Click -= value2;
			}
			qGNNp8q4dE = value;
			button = qGNNp8q4dE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt3D
	{
		[CompilerGenerated]
		get
		{
			return NOrNT4XVoB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YWT8LBg5h0;
			Button button = NOrNT4XVoB;
			if (button != null)
			{
				button.Click -= value2;
			}
			NOrNT4XVoB = value;
			button = NOrNT4XVoB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbRev2
	{
		[CompilerGenerated]
		get
		{
			return IpONJGk1xi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IpONJGk1xi = value;
		}
	}

	internal virtual Label lbPaginas2
	{
		[CompilerGenerated]
		get
		{
			return C1mNh5pK6w;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			C1mNh5pK6w = value;
		}
	}

	internal virtual Label lbDescicao2
	{
		[CompilerGenerated]
		get
		{
			return PtMNokK2kc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PtMNokK2kc = value;
		}
	}

	internal virtual CheckBox CKAgrupaPaginas
	{
		[CompilerGenerated]
		get
		{
			return RVsNGKmooV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yZV8xo4kLJ;
			CheckBox checkBox = RVsNGKmooV;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			RVsNGKmooV = value;
			checkBox = RVsNGKmooV;
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
			if (disposing && WHQ8bGuE47 != null)
			{
				WHQ8bGuE47.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PXNaEluZDt()
	{
		WHQ8bGuE47 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Rev));
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(WHQ8bGuE47));
		btExporta = new Button();
		cbRev = new ComboBox();
		tbPaginas = new TextBox();
		lbRev = new Label();
		lbPaginas = new Label();
		lbDescicao = new Label();
		tbDescicao = new TextBox();
		btApagar = new Button();
		GroupBox3 = new GroupBox();
		bt1 = new Button();
		TBNome = new TextBox();
		bt2 = new Button();
		btSet = new Button();
		bt3 = new Button();
		bt5 = new Button();
		bt4 = new Button();
		GroupBox1 = new GroupBox();
		bt3A = new Button();
		lbRev2 = new Label();
		lbPaginas2 = new Label();
		bt3D = new Button();
		lbDescicao2 = new Label();
		bt2A = new Button();
		TextBox3 = new TextBox();
		bt1D = new Button();
		TextBox1 = new TextBox();
		bt2D = new Button();
		bt1A = new Button();
		TextBox2 = new TextBox();
		LabelLinhas = new Label();
		btCorBloco = new Button();
		TBAlturaInicialRelatorio = new TextBox();
		LabelCorTexto = new Label();
		LabelDistanciaDaRegua = new Label();
		btCorTextoBloco = new Button();
		GroupBox2 = new GroupBox();
		TBAlturaDoBloco = new TextBox();
		LBAlturaDoBloco = new Label();
		TBDisteEntreColunas = new TextBox();
		LabelTamanhoFonte = new Label();
		CBFonte = new ComboBox();
		LabelQuantColunas = new Label();
		CBColunas = new ComboBox();
		LabelStiloLinha = new Label();
		tbFonteBloco = new TextBox();
		LBDistanciaEntreColunas = new Label();
		CKAgrupaPaginas = new CheckBox();
		GroupBox3.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(359, 206);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 118;
		btExporta.UseVisualStyleBackColor = true;
		cbRev.FormattingEnabled = true;
		cbRev.Location = new Point(8, 278);
		cbRev.Name = "cbRev";
		cbRev.Size = new Size(73, 21);
		cbRev.TabIndex = 173;
		tbPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		tbPaginas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPaginas.Location = new Point(87, 279);
		tbPaginas.Multiline = true;
		tbPaginas.Name = "tbPaginas";
		tbPaginas.Size = new Size(349, 20);
		tbPaginas.TabIndex = 174;
		lbRev.AutoSize = true;
		lbRev.Location = new Point(8, 258);
		lbRev.Name = "lbRev";
		lbRev.Size = new Size(54, 13);
		lbRev.TabIndex = 175;
		lbRev.Text = "lbRevisão";
		lbPaginas.AutoSize = true;
		lbPaginas.Location = new Point(87, 259);
		lbPaginas.Name = "lbPaginas";
		lbPaginas.Size = new Size(53, 13);
		lbPaginas.TabIndex = 176;
		lbPaginas.Text = "lbPáginas";
		lbDescicao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbDescicao.AutoSize = true;
		lbDescicao.Location = new Point(8, 303);
		lbDescicao.Name = "lbDescicao";
		lbDescicao.Size = new Size(63, 13);
		lbDescicao.TabIndex = 178;
		lbDescicao.Text = "lbDescrição";
		tbDescicao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbDescicao.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescicao.Location = new Point(8, 323);
		tbDescicao.Name = "tbDescicao";
		tbDescicao.Size = new Size(428, 20);
		tbDescicao.TabIndex = 177;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(282, 206);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 179;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		GroupBox3.Controls.Add(bt1);
		GroupBox3.Controls.Add(TBNome);
		GroupBox3.Controls.Add(bt2);
		GroupBox3.Controls.Add(btSet);
		GroupBox3.Controls.Add(bt3);
		GroupBox3.Controls.Add(bt5);
		GroupBox3.Controls.Add(bt4);
		GroupBox3.Location = new Point(258, 114);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(174, 76);
		GroupBox3.TabIndex = 182;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "GroupBox3";
		bt1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt1.Location = new Point(9, 46);
		bt1.Name = "bt1";
		bt1.Size = new Size(25, 20);
		bt1.TabIndex = 84;
		bt1.Text = "1";
		bt1.UseVisualStyleBackColor = true;
		TBNome.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBNome.Location = new Point(9, 20);
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(104, 20);
		TBNome.TabIndex = 90;
		TBNome.TextAlign = HorizontalAlignment.Center;
		bt2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt2.Location = new Point(40, 46);
		bt2.Name = "bt2";
		bt2.Size = new Size(25, 20);
		bt2.TabIndex = 85;
		bt2.Text = "2";
		bt2.UseVisualStyleBackColor = true;
		btSet.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btSet.Location = new Point(119, 19);
		btSet.Name = "btSet";
		btSet.Size = new Size(40, 20);
		btSet.TabIndex = 89;
		btSet.Text = "SET";
		btSet.UseVisualStyleBackColor = true;
		bt3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt3.Location = new Point(71, 46);
		bt3.Name = "bt3";
		bt3.Size = new Size(25, 20);
		bt3.TabIndex = 86;
		bt3.Text = "3";
		bt3.UseVisualStyleBackColor = true;
		bt5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt5.Location = new Point(134, 46);
		bt5.Name = "bt5";
		bt5.Size = new Size(25, 20);
		bt5.TabIndex = 88;
		bt5.Text = "5";
		bt5.UseVisualStyleBackColor = true;
		bt4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt4.Location = new Point(103, 46);
		bt4.Name = "bt4";
		bt4.Size = new Size(25, 20);
		bt4.TabIndex = 87;
		bt4.Text = "4";
		bt4.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(bt3A);
		GroupBox1.Controls.Add(lbRev2);
		GroupBox1.Controls.Add(lbPaginas2);
		GroupBox1.Controls.Add(bt3D);
		GroupBox1.Controls.Add(lbDescicao2);
		GroupBox1.Controls.Add(bt2A);
		GroupBox1.Controls.Add(TextBox3);
		GroupBox1.Controls.Add(bt1D);
		GroupBox1.Controls.Add(TextBox1);
		GroupBox1.Controls.Add(bt2D);
		GroupBox1.Controls.Add(bt1A);
		GroupBox1.Controls.Add(TextBox2);
		GroupBox1.Location = new Point(257, 7);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(175, 101);
		GroupBox1.TabIndex = 181;
		GroupBox1.TabStop = false;
		bt3A.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt3A.Image = Resources.Soma;
		bt3A.Location = new Point(140, 70);
		bt3A.Name = "bt3A";
		bt3A.Size = new Size(20, 20);
		bt3A.TabIndex = 197;
		bt3A.UseVisualStyleBackColor = true;
		lbRev2.AutoSize = true;
		lbRev2.Location = new Point(6, 48);
		lbRev2.Name = "lbRev2";
		lbRev2.Size = new Size(54, 13);
		lbRev2.TabIndex = 175;
		lbRev2.Text = "lbRevisão";
		lbPaginas2.AutoSize = true;
		lbPaginas2.Location = new Point(7, 21);
		lbPaginas2.Name = "lbPaginas2";
		lbPaginas2.Size = new Size(53, 13);
		lbPaginas2.TabIndex = 176;
		lbPaginas2.Text = "lbPáginas";
		bt3D.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt3D.Image = Resources.Subtrai;
		bt3D.Location = new Point(86, 70);
		bt3D.Name = "bt3D";
		bt3D.Size = new Size(20, 20);
		bt3D.TabIndex = 195;
		bt3D.UseVisualStyleBackColor = true;
		lbDescicao2.AutoSize = true;
		lbDescicao2.Location = new Point(6, 74);
		lbDescicao2.Name = "lbDescicao2";
		lbDescicao2.Size = new Size(63, 13);
		lbDescicao2.TabIndex = 178;
		lbDescicao2.Text = "lbDescrição";
		bt2A.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt2A.Image = Resources.Soma;
		bt2A.Location = new Point(140, 44);
		bt2A.Name = "bt2A";
		bt2A.Size = new Size(20, 20);
		bt2A.TabIndex = 194;
		bt2A.UseVisualStyleBackColor = true;
		TextBox3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TextBox3.Location = new Point(106, 70);
		TextBox3.Name = "TextBox3";
		TextBox3.ReadOnly = true;
		TextBox3.Size = new Size(32, 20);
		TextBox3.TabIndex = 188;
		TextBox3.TextAlign = HorizontalAlignment.Center;
		bt1D.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt1D.Image = Resources.Subtrai;
		bt1D.Location = new Point(86, 18);
		bt1D.Name = "bt1D";
		bt1D.Size = new Size(20, 20);
		bt1D.TabIndex = 189;
		bt1D.UseVisualStyleBackColor = true;
		TextBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TextBox1.Location = new Point(106, 18);
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = true;
		TextBox1.Size = new Size(32, 20);
		TextBox1.TabIndex = 184;
		TextBox1.TextAlign = HorizontalAlignment.Center;
		bt2D.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt2D.Image = Resources.Subtrai;
		bt2D.Location = new Point(86, 44);
		bt2D.Name = "bt2D";
		bt2D.Size = new Size(20, 20);
		bt2D.TabIndex = 192;
		bt2D.UseVisualStyleBackColor = true;
		bt1A.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt1A.Image = Resources.Soma;
		bt1A.Location = new Point(140, 18);
		bt1A.Name = "bt1A";
		bt1A.Size = new Size(20, 20);
		bt1A.TabIndex = 191;
		bt1A.UseVisualStyleBackColor = true;
		TextBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TextBox2.Location = new Point(106, 44);
		TextBox2.Name = "TextBox2";
		TextBox2.ReadOnly = true;
		TextBox2.Size = new Size(32, 20);
		TextBox2.TabIndex = 186;
		TextBox2.TextAlign = HorizontalAlignment.Center;
		LabelLinhas.ImageAlign = ContentAlignment.TopLeft;
		LabelLinhas.Location = new Point(8, 151);
		LabelLinhas.Name = "LabelLinhas";
		LabelLinhas.Size = new Size(143, 25);
		LabelLinhas.TabIndex = 95;
		LabelLinhas.Text = "Linhas";
		LabelLinhas.TextAlign = ContentAlignment.MiddleLeft;
		btCorBloco.BackColor = SystemColors.ActiveCaption;
		btCorBloco.Location = new Point(177, 149);
		btCorBloco.Name = "btCorBloco";
		btCorBloco.Size = new Size(47, 25);
		btCorBloco.TabIndex = 0;
		btCorBloco.UseVisualStyleBackColor = false;
		TBAlturaInicialRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaInicialRelatorio.Location = new Point(177, 211);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelCorTexto.ImageAlign = ContentAlignment.TopLeft;
		LabelCorTexto.Location = new Point(7, 180);
		LabelCorTexto.Name = "LabelCorTexto";
		LabelCorTexto.Size = new Size(143, 25);
		LabelCorTexto.TabIndex = 38;
		LabelCorTexto.Text = "Textos";
		LabelCorTexto.TextAlign = ContentAlignment.MiddleLeft;
		LabelDistanciaDaRegua.Location = new Point(8, 211);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		btCorTextoBloco.BackColor = SystemColors.ActiveCaption;
		btCorTextoBloco.Location = new Point(177, 180);
		btCorTextoBloco.Name = "btCorTextoBloco";
		btCorTextoBloco.Size = new Size(47, 25);
		btCorTextoBloco.TabIndex = 1;
		btCorTextoBloco.UseVisualStyleBackColor = false;
		GroupBox2.Controls.Add(TBAlturaInicialRelatorio);
		GroupBox2.Controls.Add(LabelDistanciaDaRegua);
		GroupBox2.Controls.Add(LabelLinhas);
		GroupBox2.Controls.Add(LabelCorTexto);
		GroupBox2.Controls.Add(TBAlturaDoBloco);
		GroupBox2.Controls.Add(btCorBloco);
		GroupBox2.Controls.Add(btCorTextoBloco);
		GroupBox2.Controls.Add(LBAlturaDoBloco);
		GroupBox2.Controls.Add(TBDisteEntreColunas);
		GroupBox2.Controls.Add(LabelTamanhoFonte);
		GroupBox2.Controls.Add(CBFonte);
		GroupBox2.Controls.Add(LabelQuantColunas);
		GroupBox2.Controls.Add(CBColunas);
		GroupBox2.Controls.Add(LabelStiloLinha);
		GroupBox2.Controls.Add(tbFonteBloco);
		GroupBox2.Controls.Add(LBDistanciaEntreColunas);
		GroupBox2.Location = new Point(14, 7);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(238, 248);
		GroupBox2.TabIndex = 180;
		GroupBox2.TabStop = false;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(177, 95);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(47, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(7, 94);
		LBAlturaDoBloco.Name = "LBAlturaDoBloco";
		LBAlturaDoBloco.Size = new Size(162, 25);
		LBAlturaDoBloco.TabIndex = 70;
		LBAlturaDoBloco.Text = "Altura do Bloco";
		LBAlturaDoBloco.TextAlign = ContentAlignment.MiddleLeft;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(177, 69);
		TBDisteEntreColunas.Name = "TBDisteEntreColunas";
		TBDisteEntreColunas.Size = new Size(47, 20);
		TBDisteEntreColunas.TabIndex = 64;
		TBDisteEntreColunas.TextAlign = HorizontalAlignment.Center;
		LabelTamanhoFonte.Location = new Point(7, 16);
		LabelTamanhoFonte.Name = "LabelTamanhoFonte";
		LabelTamanhoFonte.Size = new Size(162, 25);
		LabelTamanhoFonte.TabIndex = 36;
		LabelTamanhoFonte.Text = "Tamanho do Fonte";
		LabelTamanhoFonte.TextAlign = ContentAlignment.MiddleLeft;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(119, 122);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(105, 21);
		CBFonte.TabIndex = 0;
		LabelQuantColunas.Location = new Point(8, 42);
		LabelQuantColunas.Name = "LabelQuantColunas";
		LabelQuantColunas.Size = new Size(130, 25);
		LabelQuantColunas.TabIndex = 45;
		LabelQuantColunas.Text = "Quantidede de Colunas";
		LabelQuantColunas.TextAlign = ContentAlignment.MiddleLeft;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(177, 42);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(47, 21);
		CBColunas.TabIndex = 52;
		LabelStiloLinha.Location = new Point(9, 121);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(104, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		tbFonteBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteBloco.Location = new Point(177, 16);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(47, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LBDistanciaEntreColunas.Location = new Point(8, 68);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(161, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		CKAgrupaPaginas.AutoSize = true;
		CKAgrupaPaginas.Location = new Point(160, 259);
		CKAgrupaPaginas.Name = "CKAgrupaPaginas";
		CKAgrupaPaginas.Size = new Size(118, 17);
		CKAgrupaPaginas.TabIndex = 183;
		CKAgrupaPaginas.Text = "_CKAgrupaPaginas";
		CKAgrupaPaginas.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(444, 356);
		Controls.Add(CKAgrupaPaginas);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox2);
		Controls.Add(btApagar);
		Controls.Add(lbDescicao);
		Controls.Add(tbDescicao);
		Controls.Add(lbPaginas);
		Controls.Add(lbRev);
		Controls.Add(cbRev);
		Controls.Add(tbPaginas);
		Controls.Add(btExporta);
		ImeMode = ImeMode.On;
		MaximumSize = new Size(460, 450);
		MinimumSize = new Size(460, 395);
		Name = "frmRelatorio_Rev";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Estatistica";
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return SqV8MtGrMv;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		SqV8MtGrMv = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return Evs8OPYhbq;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		Evs8OPYhbq = WithEventsValue;
	}

	public frmRelatorio_Rev()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		eoENdmtB33 = "RELREV";
		U1FNfB9E0s = new ColorDialog();
		dMcND2t28K = 6;
		FhoNveT4M5 = 4;
		avrN6VJu8X = 0.0;
		IA8NjWEViG = 10.0;
		breNLB1qkH = 15;
		gi3NwfJWI7 = 10;
		KHBNxVwRLv = 75;
		G4sNbtPqY7 = breNLB1qkH;
		sgvNM4oC4C = gi3NwfJWI7;
		V98NOZW9vN = KHBNxVwRLv;
		if (Geral.ExisteForm("frmRelatorio_Rev"))
		{
			return;
		}
		PXNaEluZDt();
		DeclaracoesGeral.Reguas RH = default;
		checked
		{
			if (XDataGeral.LeXDataReguaH(ref RH))
			{
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1673]);
				lbPaginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 287]);
				lbRev.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]);
				lbDescicao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 390]);
				lbPaginas2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 287]);
				lbRev2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]);
				lbDescicao2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 390]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 382]);
				LabelTamanhoFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 339]);
				LabelLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 340]);
				LabelCorTexto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 341]);
				LabelQuantColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 342]);
				LabelStiloLinha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 343]);
				LBAlturaDoBloco.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 344]);
				LBDistanciaEntreColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 345]);
				LabelDistanciaDaRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 350]);
				CKAgrupaPaginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1891]);
				Q5VaZ4so52();
				FhoNveT4M5 = (int)Math.Round((LZSNtwDZR0 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta) / 90.0);
				avrN6VJu8X = RH.Pti.Y - RH.AltBase;
				double num = avrN6VJu8X - IA8NjWEViG - Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
				num /= 35.0;
				dMcND2t28K = (int)Conversion.Int(num);
				GSNaCpk1gV();
				HEd8GMewC6();
				GroupBox2.Enabled = true;
				Application.ShowModelessDialog((Form)this);
				Relatorios_Rev.encontraTamanhosDasColunas(ref lT3NH17Fic);
				breNLB1qkH = lT3NH17Fic.i1;
				gi3NwfJWI7 = lT3NH17Fic.i2;
				KHBNxVwRLv = lT3NH17Fic.i3;
				MostraValor();
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
			}
		}
	}

	private void Q5VaZ4so52()
	{
		tbFonteBloco.Text = "2";
		CBColunas.Items.Clear();
		CBColunas.Items.Add("1");
		CBColunas.Items.Add("2");
		CBColunas.Items.Add("3");
		CBColunas.Text = "2";
		string[] array = new string[1];
		TBAlturaInicialRelatorio.Text = "25";
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
		TBDisteEntreColunas.Text = Conversions.ToString(6);
		TBAlturaDoBloco.Text = Conversions.ToString(7);
		Color val = Color.FromColorIndex((ColorMethod)194, (short)7);
		btCorBloco.BackColor = val.ColorValue;
		val = Color.FromColorIndex((ColorMethod)194, (short)7);
		btCorTextoBloco.BackColor = val.ColorValue;
		lT3NH17Fic.CorLinha = 7;
		lT3NH17Fic.CorTexto = 7;
	}

	private void bGnaiwqP1M(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = U1FNfB9E0s.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			lT3NH17Fic.CorLinha = U1FNfB9E0s.Color.ColorIndex;
			btCorBloco.BackColor = U1FNfB9E0s.Color.ColorValue;
		}
	}

	private void ndRaSLBBok(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = U1FNfB9E0s.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			lT3NH17Fic.CorTexto = U1FNfB9E0s.Color.ColorIndex;
			btCorTextoBloco.BackColor = U1FNfB9E0s.Color.ColorValue;
		}
	}

	private short iL5a4PKnaD()
	{
		DialogResult dialogResult = U1FNfB9E0s.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return U1FNfB9E0s.Color.ColorIndex;
	}

	private void GSNaCpk1gV()
	{
		List<string> list = new List<string>();
		try
		{
			Revisao.capturaRevisoesSimplificadas();
			cbRev.Items.Clear();
			int num = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.ConditionalCompareObjectNotEqual(DeclaracoesGeral.mRevSimplificada[1, i], "", TextCompare: true) && !list.Contains(Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, i])))
				{
					list.Add(Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, i]));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
		list.Sort();
		foreach (string item in list)
		{
			if (Operators.CompareString(item.Trim(), "", TextCompare: true) != 0)
			{
				cbRev.Items.Add(item);
				if (Operators.CompareString(cbRev.Text, "", TextCompare: true) == 0)
				{
					cbRev.Text = item;
				}
			}
		}
		if (Operators.CompareString(cbRev.Text, "", TextCompare: true) != 0)
		{
			eEKaYdrkpC();
		}
	}

	private void eEKaYdrkpC()
	{
		tbPaginas.Text = Relatorios_Rev.EncontraPaginasUsadasEmUmaRevisao(cbRev.Text, CKAgrupaPaginas.Checked);
		tbDescicao.Text = Relatorios_Rev.capturaDescricaoRevCompleta(cbRev.Text);
	}

	private void gixarGjF87(object P_0, EventArgs P_1)
	{
		lT3NH17Fic.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
		lT3NH17Fic.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		lT3NH17Fic.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
		lT3NH17Fic.sFonte = CBFonte.Text;
		lT3NH17Fic.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
		lT3NH17Fic.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
		lT3NH17Fic.i1 = breNLB1qkH;
		lT3NH17Fic.i2 = gi3NwfJWI7;
		lT3NH17Fic.i3 = KHBNxVwRLv;
		Relatorios_Rev.CriaRelatorioREvisaoDWG(lT3NH17Fic, cbRev.Text, tbPaginas.Text, tbDescicao.Text);
	}

	private void xt2a9Cv8b5(object P_0, EventArgs P_1)
	{
		eEKaYdrkpC();
	}

	private void iLuazhslYA(object P_0, EventArgs P_1)
	{
		Relatorios_Rev.ApagaRelatorioRevisaoCompleta(cbRev.Text);
	}

	private void k5J8WBuQSb(object P_0, EventArgs P_1)
	{
		if (TygNkq7Hov)
		{
			TygNkq7Hov = false;
			HEd8GMewC6();
			return;
		}
		TygNkq7Hov = true;
		bt1.Enabled = true;
		bt2.Enabled = true;
		bt3.Enabled = true;
		bt4.Enabled = true;
		bt5.Enabled = true;
	}

	private void H1e8pTqmdB(object P_0, EventArgs P_1)
	{
		if (TygNkq7Hov)
		{
			Irh8dseaSl(1);
			TygNkq7Hov = false;
			bt1.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			r9g8HVwMU0(1);
		}
	}

	private void nEd8T0ivxr(object P_0, EventArgs P_1)
	{
		if (TygNkq7Hov)
		{
			Irh8dseaSl(2);
			TygNkq7Hov = false;
			bt2.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			r9g8HVwMU0(2);
		}
	}

	private void Kdw8JJLmBt(object P_0, EventArgs P_1)
	{
		if (TygNkq7Hov)
		{
			Irh8dseaSl(3);
			TygNkq7Hov = false;
			bt3.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			r9g8HVwMU0(3);
		}
	}

	private void JgI8h3PTpU(object P_0, EventArgs P_1)
	{
		if (TygNkq7Hov)
		{
			Irh8dseaSl(4);
			TygNkq7Hov = false;
			bt4.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			r9g8HVwMU0(4);
		}
	}

	private void Dm28oNFV8u(object P_0, EventArgs P_1)
	{
		if (TygNkq7Hov)
		{
			Irh8dseaSl(5);
			TygNkq7Hov = false;
			bt5.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			r9g8HVwMU0(5);
		}
	}

	private void HEd8GMewC6()
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
				GroupBox1.Enabled = true;
				cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
				try
				{
					DataTable dataTable = cDadosAccessComum2.LeConfiguracaoRelatorio("F", eoENdmtB33);
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
			GroupBox1.Enabled = false;
		}
	}

	private void r9g8HVwMU0(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string sComando = "";
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.LeConfiguracao(ref sComando, P_0, "F", eoENdmtB33);
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
		sComando += ";15;10;75;";
		object obj = array;
		Eq28kVr0y4(ref obj, sComando);
		array = (object[])obj;
		TBNome.Text = Conversions.ToString(array[1]);
		Color val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[2]));
		btCorBloco.BackColor = val.ColorValue;
		lT3NH17Fic.CorLinha = val.ColorIndex;
		val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[3]));
		btCorTextoBloco.BackColor = val.ColorValue;
		lT3NH17Fic.CorTexto = val.ColorIndex;
		tbFonteBloco.Text = Conversions.ToString(array[4]);
		CBColunas.Text = Conversions.ToString(array[5]);
		TBDisteEntreColunas.Text = Conversions.ToString(array[6]);
		TBAlturaDoBloco.Text = Conversions.ToString(array[7]);
		CBFonte.Text = Conversions.ToString(array[8]);
		TBAlturaInicialRelatorio.Text = Conversions.ToString(array[9]);
		breNLB1qkH = Conversions.ToInteger(array[10]);
		gi3NwfJWI7 = Conversions.ToInteger(array[11]);
		KHBNxVwRLv = Conversions.ToInteger(array[12]);
		MostraValor();
	}

	private void Eq28kVr0y4(ref object P_0, string P_1)
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

	private void Irh8dseaSl(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = "";
		text = TBNome.Text;
		text = text + ";" + Conversions.ToString((int)lT3NH17Fic.CorLinha);
		text = text + ";" + Conversions.ToString((int)lT3NH17Fic.CorTexto);
		text = text + ";" + tbFonteBloco.Text;
		text = text + ";" + CBColunas.Text;
		text = text + ";" + TBDisteEntreColunas.Text;
		text = text + ";" + TBAlturaDoBloco.Text;
		text = text + ";" + CBFonte.Text;
		text = text + ";" + TBAlturaInicialRelatorio.Text;
		text = text + ";" + Conversions.ToString(breNLB1qkH);
		text = text + ";" + Conversions.ToString(gi3NwfJWI7);
		text = text + ";" + Conversions.ToString(KHBNxVwRLv);
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.GravaConfiguracao(text, P_0, "F", eoENdmtB33);
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
		HEd8GMewC6();
	}

	private void plb8fwsgUv(object P_0, EventArgs P_1)
	{
		MostraValor();
	}

	private void g9t8DOsBe3(object P_0, KeyEventArgs P_1)
	{
		MostraValor();
	}

	private void wBw8v2aGrS(object P_0, EventArgs P_1)
	{
		Guarda();
		checked
		{
			breNLB1qkH--;
			KHBNxVwRLv++;
			if (breNLB1qkH < 0)
			{
				recupera();
			}
			MostraValor();
		}
	}

	private void aaQ86kNI8K(object P_0, EventArgs P_1)
	{
		Guarda();
		checked
		{
			breNLB1qkH++;
			KHBNxVwRLv--;
			if (KHBNxVwRLv < 0)
			{
				recupera();
			}
			MostraValor();
		}
	}

	private void b1k8tvHDGR(object P_0, EventArgs P_1)
	{
		Guarda();
		checked
		{
			gi3NwfJWI7--;
			KHBNxVwRLv++;
			if (gi3NwfJWI7 < 0)
			{
				recupera();
			}
			MostraValor();
		}
	}

	private void eY88jLMbcy(object P_0, EventArgs P_1)
	{
		Guarda();
		checked
		{
			gi3NwfJWI7++;
			KHBNxVwRLv--;
			if (KHBNxVwRLv < 0)
			{
				recupera();
			}
			MostraValor();
		}
	}

	private void YWT8LBg5h0(object P_0, EventArgs P_1)
	{
		Guarda();
		checked
		{
			KHBNxVwRLv--;
			gi3NwfJWI7++;
			if (KHBNxVwRLv < 0)
			{
				recupera();
			}
			MostraValor();
		}
	}

	private void RIh8w4Ke9G(object P_0, EventArgs P_1)
	{
		Guarda();
		checked
		{
			KHBNxVwRLv++;
			gi3NwfJWI7--;
			if (gi3NwfJWI7 < 0)
			{
				recupera();
			}
			MostraValor();
		}
	}

	public void Guarda()
	{
		G4sNbtPqY7 = breNLB1qkH;
		sgvNM4oC4C = gi3NwfJWI7;
		V98NOZW9vN = KHBNxVwRLv;
	}

	public void recupera()
	{
		breNLB1qkH = G4sNbtPqY7;
		gi3NwfJWI7 = sgvNM4oC4C;
		KHBNxVwRLv = V98NOZW9vN;
	}

	public void MostraValor()
	{
		if ((Operators.CompareString(CBColunas.Text, "", TextCompare: true) != 0) & (Operators.CompareString(TBDisteEntreColunas.Text, "", TextCompare: true) != 0))
		{
			TextBox1.Text = Conversions.ToString(breNLB1qkH) + "%";
			TextBox2.Text = Conversions.ToString(gi3NwfJWI7) + "%";
			TextBox3.Text = Conversions.ToString(KHBNxVwRLv) + "%";
		}
	}

	private void yZV8xo4kLJ(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(cbRev.Text, "", TextCompare: true) != 0)
		{
			eEKaYdrkpC();
		}
	}
}
