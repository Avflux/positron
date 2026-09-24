using System;
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
using Microsoft.Win32;
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_IndicedePaginas : Form
{
	private IContainer OQSpOXiu5Yc;

	[CompilerGenerated]
	[AccessedThroughProperty("tbFonteBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox wQ1pOUhquCN;

	[AccessedThroughProperty("LabelCorTexto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label JEupOy0AmiV;

	[AccessedThroughProperty("btCorTextoBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button DJfpOgoMhTR;

	[AccessedThroughProperty("LabelCorLinha")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label Xw1pOAqJohg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelTamanhoFonte")]
	private Label NLypOs5T9Ax;

	[AccessedThroughProperty("btCorBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button Dp3pOBUlqxn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelQuantColunas")]
	private Label rMFpOVJFj45;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelStiloLinha")]
	private Label a17pOuiUkmJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBFonte")]
	private ComboBox MmxpOEasePK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	private Button txFpOZjHEeV;

	[AccessedThroughProperty("btApagar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button da1pOiiY7um;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBColunas")]
	private ComboBox aGipOSLdJZt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBTitulo4")]
	private CheckBox ctCpO4CwijU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBTitulo3")]
	private CheckBox WATpOC9b562;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBTitulo2")]
	private CheckBox e0FpOYvwS2M;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBTitulo1")]
	private CheckBox vKjpOrqu1Vt;

	[CompilerGenerated]
	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog tU9pO9Zwnl8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	private Label jP5pOzRYJxi;

	[CompilerGenerated]
	[AccessedThroughProperty("TBDisteEntreColunas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox ROGpIWAjb3Y;

	[AccessedThroughProperty("BTCancelar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button iKEpIpXwNAE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	[CompilerGenerated]
	private TextBox phHpIT774RI;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label PQ3pIJuq0om;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaDoBloco")]
	private TextBox NOLpIhrBRHh;

	[AccessedThroughProperty("LBAlturaDoBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label oT0pIoirCaQ;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox ia3pIGWfj5y;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt1")]
	private Button sC3pIHdQIX7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBNome")]
	private TextBox OrOpIk9aFkv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt2")]
	private Button H9TpIdaxugD;

	[AccessedThroughProperty("btSet")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button O3YpIf11Nhu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt3")]
	private Button XQxpIDd9rJC;

	[AccessedThroughProperty("bt5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button adupIvtJxfR;

	[AccessedThroughProperty("bt4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button DgFpI6mlPUU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBRev")]
	private CheckBox FLkpItCeWLC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBAlternativo")]
	private CheckBox VM1pIj4duJT;

	[CompilerGenerated]
	[AccessedThroughProperty("CBPagina")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox EFrpILq1B9V;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox LdUpIwXGPjL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBUnidade")]
	private CheckBox HJvpIxgIkVv;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox BjwpIbX8cao;

	[AccessedThroughProperty("TBPaginaReserva")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox xIVpIMIvsC3;

	[AccessedThroughProperty("LBPaginaReserva")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label p5cpIOX8GNi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBPaginaReserva")]
	private CheckBox c42pIId65nY;

	private bool LF6pI7gVPgU;

	private DeclaracoesGeral.ConfRelatorioIndice avbpIqZyC1C;

	private string nZXpIaVKlh4;

	private ColorDialog YxEpI8B0I1y;

	private bool kD2pINY5WFX;

	private bool WgDpIF4EiNO;

	internal virtual TextBox tbFonteBloco
	{
		[CompilerGenerated]
		get
		{
			return wQ1pOUhquCN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = t2FpOMq727T;
			TextBox textBox = wQ1pOUhquCN;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			wQ1pOUhquCN = value;
			textBox = wQ1pOUhquCN;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label LabelCorTexto
	{
		[CompilerGenerated]
		get
		{
			return JEupOy0AmiV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JEupOy0AmiV = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return DJfpOgoMhTR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xYApOx4ZFDf;
			Button button = DJfpOgoMhTR;
			if (button != null)
			{
				button.Click -= value2;
			}
			DJfpOgoMhTR = value;
			button = DJfpOgoMhTR;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelCorLinha
	{
		[CompilerGenerated]
		get
		{
			return Xw1pOAqJohg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Xw1pOAqJohg = value;
		}
	}

	internal virtual Label LabelTamanhoFonte
	{
		[CompilerGenerated]
		get
		{
			return NLypOs5T9Ax;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NLypOs5T9Ax = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return Dp3pOBUlqxn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DcQpOwUIcfP;
			Button button = Dp3pOBUlqxn;
			if (button != null)
			{
				button.Click -= value2;
			}
			Dp3pOBUlqxn = value;
			button = Dp3pOBUlqxn;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelQuantColunas
	{
		[CompilerGenerated]
		get
		{
			return rMFpOVJFj45;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rMFpOVJFj45 = value;
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return a17pOuiUkmJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a17pOuiUkmJ = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return MmxpOEasePK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MmxpOEasePK = value;
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return txFpOZjHEeV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dBGpOInG38v;
			Button button = txFpOZjHEeV;
			if (button != null)
			{
				button.Click -= value2;
			}
			txFpOZjHEeV = value;
			button = txFpOZjHEeV;
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
			return da1pOiiY7um;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = I4mpO7CmXOj;
			Button button = da1pOiiY7um;
			if (button != null)
			{
				button.Click -= value2;
			}
			da1pOiiY7um = value;
			button = da1pOiiY7um;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox CBColunas
	{
		[CompilerGenerated]
		get
		{
			return aGipOSLdJZt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aGipOSLdJZt = value;
		}
	}

	internal virtual CheckBox CBTitulo4
	{
		[CompilerGenerated]
		get
		{
			return ctCpO4CwijU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pHspORhXpPA;
			CheckBox checkBox = ctCpO4CwijU;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			ctCpO4CwijU = value;
			checkBox = ctCpO4CwijU;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CBTitulo3
	{
		[CompilerGenerated]
		get
		{
			return WATpOC9b562;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = n78pO0p4AT3;
			CheckBox checkBox = WATpOC9b562;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			WATpOC9b562 = value;
			checkBox = WATpOC9b562;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CBTitulo2
	{
		[CompilerGenerated]
		get
		{
			return e0FpOYvwS2M;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TUSpO5FdxLi;
			CheckBox checkBox = e0FpOYvwS2M;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			e0FpOYvwS2M = value;
			checkBox = e0FpOYvwS2M;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CBTitulo1
	{
		[CompilerGenerated]
		get
		{
			return vKjpOrqu1Vt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fg4pOl6PvhU;
			CheckBox checkBox = vKjpOrqu1Vt;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			vKjpOrqu1Vt = value;
			checkBox = vKjpOrqu1Vt;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return jP5pOzRYJxi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jP5pOzRYJxi = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return ROGpIWAjb3Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = on6pOONv8L0;
			TextBox textBox = ROGpIWAjb3Y;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			ROGpIWAjb3Y = value;
			textBox = ROGpIWAjb3Y;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button BTCancelar
	{
		[CompilerGenerated]
		get
		{
			return iKEpIpXwNAE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WpZpOqUjMkW;
			Button button = iKEpIpXwNAE;
			if (button != null)
			{
				button.Click -= value2;
			}
			iKEpIpXwNAE = value;
			button = iKEpIpXwNAE;
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
			return phHpIT774RI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			phHpIT774RI = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return PQ3pIJuq0om;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PQ3pIJuq0om = value;
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return NOLpIhrBRHh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = LpcpOa9Y1qR;
			TextBox textBox = NOLpIhrBRHh;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			NOLpIhrBRHh = value;
			textBox = NOLpIhrBRHh;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label LBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return oT0pIoirCaQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oT0pIoirCaQ = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return ia3pIGWfj5y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ia3pIGWfj5y = value;
		}
	}

	internal virtual Button bt1
	{
		[CompilerGenerated]
		get
		{
			return sC3pIHdQIX7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bxCpONiv9TB;
			Button button = sC3pIHdQIX7;
			if (button != null)
			{
				button.Click -= value2;
			}
			sC3pIHdQIX7 = value;
			button = sC3pIHdQIX7;
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
			return OrOpIk9aFkv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OrOpIk9aFkv = value;
		}
	}

	internal virtual Button bt2
	{
		[CompilerGenerated]
		get
		{
			return H9TpIdaxugD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JVApOFMCgGG;
			Button button = H9TpIdaxugD;
			if (button != null)
			{
				button.Click -= value2;
			}
			H9TpIdaxugD = value;
			button = H9TpIdaxugD;
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
			return O3YpIf11Nhu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MEfpO8vJ4GC;
			Button button = O3YpIf11Nhu;
			if (button != null)
			{
				button.Click -= value2;
			}
			O3YpIf11Nhu = value;
			button = O3YpIf11Nhu;
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
			return XQxpIDd9rJC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = c35pOQBI4tk;
			Button button = XQxpIDd9rJC;
			if (button != null)
			{
				button.Click -= value2;
			}
			XQxpIDd9rJC = value;
			button = XQxpIDd9rJC;
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
			return adupIvtJxfR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HZ1pOcbqgOY;
			Button button = adupIvtJxfR;
			if (button != null)
			{
				button.Click -= value2;
			}
			adupIvtJxfR = value;
			button = adupIvtJxfR;
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
			return DgFpI6mlPUU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tJSpOPFQoJA;
			Button button = DgFpI6mlPUU;
			if (button != null)
			{
				button.Click -= value2;
			}
			DgFpI6mlPUU = value;
			button = DgFpI6mlPUU;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CBRev
	{
		[CompilerGenerated]
		get
		{
			return FLkpItCeWLC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FLkpItCeWLC = value;
		}
	}

	internal virtual CheckBox CBAlternativo
	{
		[CompilerGenerated]
		get
		{
			return VM1pIj4duJT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PynpO1j6ZLJ;
			CheckBox checkBox = VM1pIj4duJT;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			VM1pIj4duJT = value;
			checkBox = VM1pIj4duJT;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CBPagina
	{
		[CompilerGenerated]
		get
		{
			return EFrpILq1B9V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MTKpOnwFjn3;
			CheckBox checkBox = EFrpILq1B9V;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			EFrpILq1B9V = value;
			checkBox = EFrpILq1B9V;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return LdUpIwXGPjL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LdUpIwXGPjL = value;
		}
	}

	internal virtual CheckBox CBUnidade
	{
		[CompilerGenerated]
		get
		{
			return HJvpIxgIkVv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HJvpIxgIkVv = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return BjwpIbX8cao;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BjwpIbX8cao = value;
		}
	}

	internal virtual TextBox TBPaginaReserva
	{
		[CompilerGenerated]
		get
		{
			return xIVpIMIvsC3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xIVpIMIvsC3 = value;
		}
	}

	internal virtual Label LBPaginaReserva
	{
		[CompilerGenerated]
		get
		{
			return p5cpIOX8GNi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			p5cpIOX8GNi = value;
		}
	}

	internal virtual CheckBox CBPaginaReserva
	{
		[CompilerGenerated]
		get
		{
			return c42pIId65nY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NkspOmKUi3e;
			CheckBox checkBox = c42pIId65nY;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			c42pIId65nY = value;
			checkBox = c42pIId65nY;
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
			if (disposing && OQSpOXiu5Yc != null)
			{
				OQSpOXiu5Yc.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AjKpOLdkTZH()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_IndicedePaginas));
		btApagar = new Button();
		btExporta = new Button();
		CBColunas = new ComboBox();
		CBFonte = new ComboBox();
		LabelStiloLinha = new Label();
		LabelQuantColunas = new Label();
		LabelCorTexto = new Label();
		btCorTextoBloco = new Button();
		LabelCorLinha = new Label();
		tbFonteBloco = new TextBox();
		LabelTamanhoFonte = new Label();
		btCorBloco = new Button();
		CBTitulo1 = new CheckBox();
		CBTitulo2 = new CheckBox();
		CBTitulo3 = new CheckBox();
		CBTitulo4 = new CheckBox();
		aHypBEW66iS(new FolderBrowserDialog());
		LBDistanciaEntreColunas = new Label();
		TBDisteEntreColunas = new TextBox();
		BTCancelar = new Button();
		TBAlturaInicialRelatorio = new TextBox();
		LabelDistanciaDaRegua = new Label();
		TBAlturaDoBloco = new TextBox();
		LBAlturaDoBloco = new Label();
		GroupBox2 = new GroupBox();
		bt1 = new Button();
		TBNome = new TextBox();
		bt2 = new Button();
		btSet = new Button();
		bt3 = new Button();
		bt5 = new Button();
		bt4 = new Button();
		CBRev = new CheckBox();
		CBAlternativo = new CheckBox();
		CBPagina = new CheckBox();
		GroupBox1 = new GroupBox();
		TBPaginaReserva = new TextBox();
		LBPaginaReserva = new Label();
		CBUnidade = new CheckBox();
		GroupBox3 = new GroupBox();
		CBPaginaReserva = new CheckBox();
		GroupBox2.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		SuspendLayout();
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(321, 241);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 41;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(274, 241);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 39;
		btExporta.UseVisualStyleBackColor = true;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(176, 83);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(47, 21);
		CBColunas.TabIndex = 52;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(92, 176);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(130, 21);
		CBFonte.TabIndex = 0;
		LabelStiloLinha.Location = new Point(7, 176);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(79, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		LabelQuantColunas.Location = new Point(7, 83);
		LabelQuantColunas.Name = "LabelQuantColunas";
		LabelQuantColunas.Size = new Size(175, 25);
		LabelQuantColunas.TabIndex = 45;
		LabelQuantColunas.Text = "Quantidede de Colunas";
		LabelQuantColunas.TextAlign = ContentAlignment.MiddleLeft;
		LabelCorTexto.Location = new Point(115, 17);
		LabelCorTexto.Name = "LabelCorTexto";
		LabelCorTexto.Size = new Size(72, 25);
		LabelCorTexto.TabIndex = 38;
		LabelCorTexto.Text = "Cor do Texto";
		LabelCorTexto.TextAlign = ContentAlignment.MiddleLeft;
		btCorTextoBloco.BackColor = SystemColors.ActiveCaption;
		btCorTextoBloco.Location = new Point(187, 17);
		btCorTextoBloco.Name = "btCorTextoBloco";
		btCorTextoBloco.Size = new Size(35, 25);
		btCorTextoBloco.TabIndex = 1;
		btCorTextoBloco.UseVisualStyleBackColor = false;
		LabelCorLinha.Location = new Point(6, 17);
		LabelCorLinha.Name = "LabelCorLinha";
		LabelCorLinha.Size = new Size(69, 25);
		LabelCorLinha.TabIndex = 37;
		LabelCorLinha.Text = "Cor da Linha";
		LabelCorLinha.TextAlign = ContentAlignment.MiddleLeft;
		tbFonteBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteBloco.Location = new Point(176, 50);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(47, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LabelTamanhoFonte.Location = new Point(6, 50);
		LabelTamanhoFonte.Name = "LabelTamanhoFonte";
		LabelTamanhoFonte.Size = new Size(175, 25);
		LabelTamanhoFonte.TabIndex = 36;
		LabelTamanhoFonte.Text = "Tamanho do Fonte";
		LabelTamanhoFonte.TextAlign = ContentAlignment.MiddleLeft;
		btCorBloco.BackColor = SystemColors.ActiveCaption;
		btCorBloco.Location = new Point(74, 17);
		btCorBloco.Name = "btCorBloco";
		btCorBloco.Size = new Size(35, 25);
		btCorBloco.TabIndex = 0;
		btCorBloco.UseVisualStyleBackColor = false;
		CBTitulo1.AutoSize = true;
		CBTitulo1.Location = new Point(105, 21);
		CBTitulo1.Name = "CBTitulo1";
		CBTitulo1.Size = new Size(63, 17);
		CBTitulo1.TabIndex = 57;
		CBTitulo1.Text = "Título 1";
		CBTitulo1.UseVisualStyleBackColor = true;
		CBTitulo2.AutoSize = true;
		CBTitulo2.Location = new Point(105, 44);
		CBTitulo2.Name = "CBTitulo2";
		CBTitulo2.Size = new Size(63, 17);
		CBTitulo2.TabIndex = 58;
		CBTitulo2.Text = "Título 2";
		CBTitulo2.UseVisualStyleBackColor = true;
		CBTitulo3.AutoSize = true;
		CBTitulo3.Location = new Point(105, 67);
		CBTitulo3.Name = "CBTitulo3";
		CBTitulo3.Size = new Size(63, 17);
		CBTitulo3.TabIndex = 59;
		CBTitulo3.Text = "Título 3";
		CBTitulo3.UseVisualStyleBackColor = true;
		CBTitulo4.AutoSize = true;
		CBTitulo4.Location = new Point(105, 90);
		CBTitulo4.Name = "CBTitulo4";
		CBTitulo4.Size = new Size(63, 17);
		CBTitulo4.TabIndex = 60;
		CBTitulo4.Text = "Título 4";
		CBTitulo4.UseVisualStyleBackColor = true;
		LBDistanciaEntreColunas.Location = new Point(7, 116);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(175, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(176, 116);
		TBDisteEntreColunas.Name = "TBDisteEntreColunas";
		TBDisteEntreColunas.Size = new Size(47, 20);
		TBDisteEntreColunas.TabIndex = 64;
		TBDisteEntreColunas.TextAlign = HorizontalAlignment.Center;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(368, 241);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 66;
		BTCancelar.UseVisualStyleBackColor = true;
		TBAlturaInicialRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaInicialRelatorio.Location = new Point(175, 209);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelDistanciaDaRegua.Location = new Point(7, 209);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(176, 145);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(47, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(6, 145);
		LBAlturaDoBloco.Name = "LBAlturaDoBloco";
		LBAlturaDoBloco.Size = new Size(162, 25);
		LBAlturaDoBloco.TabIndex = 70;
		LBAlturaDoBloco.Text = "Altura do Bloco";
		LBAlturaDoBloco.TextAlign = ContentAlignment.MiddleLeft;
		GroupBox2.Controls.Add(bt1);
		GroupBox2.Controls.Add(TBNome);
		GroupBox2.Controls.Add(bt2);
		GroupBox2.Controls.Add(btSet);
		GroupBox2.Controls.Add(bt3);
		GroupBox2.Controls.Add(bt5);
		GroupBox2.Controls.Add(bt4);
		GroupBox2.Location = new Point(258, 163);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(174, 76);
		GroupBox2.TabIndex = 92;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
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
		CBRev.AutoSize = true;
		CBRev.Location = new Point(12, 88);
		CBRev.Name = "CBRev";
		CBRev.Size = new Size(65, 17);
		CBRev.TabIndex = 93;
		CBRev.Text = "Revisão";
		CBRev.UseVisualStyleBackColor = true;
		CBAlternativo.AutoSize = true;
		CBAlternativo.Location = new Point(12, 42);
		CBAlternativo.Name = "CBAlternativo";
		CBAlternativo.Size = new Size(76, 17);
		CBAlternativo.TabIndex = 94;
		CBAlternativo.Text = "Alternativo";
		CBAlternativo.UseVisualStyleBackColor = true;
		CBPagina.AutoSize = true;
		CBPagina.Location = new Point(12, 21);
		CBPagina.Name = "CBPagina";
		CBPagina.Size = new Size(59, 17);
		CBPagina.TabIndex = 95;
		CBPagina.Text = "Página";
		CBPagina.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(TBPaginaReserva);
		GroupBox1.Controls.Add(LBPaginaReserva);
		GroupBox1.Controls.Add(LabelCorLinha);
		GroupBox1.Controls.Add(LabelCorTexto);
		GroupBox1.Controls.Add(LabelStiloLinha);
		GroupBox1.Controls.Add(TBAlturaDoBloco);
		GroupBox1.Controls.Add(btCorBloco);
		GroupBox1.Controls.Add(TBAlturaInicialRelatorio);
		GroupBox1.Controls.Add(tbFonteBloco);
		GroupBox1.Controls.Add(LabelDistanciaDaRegua);
		GroupBox1.Controls.Add(btCorTextoBloco);
		GroupBox1.Controls.Add(TBDisteEntreColunas);
		GroupBox1.Controls.Add(CBColunas);
		GroupBox1.Controls.Add(CBFonte);
		GroupBox1.Controls.Add(LabelTamanhoFonte);
		GroupBox1.Controls.Add(LabelQuantColunas);
		GroupBox1.Controls.Add(LBDistanciaEntreColunas);
		GroupBox1.Controls.Add(LBAlturaDoBloco);
		GroupBox1.Location = new Point(10, 10);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(237, 276);
		GroupBox1.TabIndex = 96;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		TBPaginaReserva.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBPaginaReserva.Location = new Point(115, 243);
		TBPaginaReserva.Name = "TBPaginaReserva";
		TBPaginaReserva.Size = new Size(107, 20);
		TBPaginaReserva.TabIndex = 71;
		TBPaginaReserva.TextAlign = HorizontalAlignment.Center;
		LBPaginaReserva.Location = new Point(7, 243);
		LBPaginaReserva.Name = "LBPaginaReserva";
		LBPaginaReserva.Size = new Size(102, 25);
		LBPaginaReserva.TabIndex = 72;
		LBPaginaReserva.Text = "Páginas Reservas";
		LBPaginaReserva.TextAlign = ContentAlignment.MiddleLeft;
		CBUnidade.AutoSize = true;
		CBUnidade.Location = new Point(12, 65);
		CBUnidade.Name = "CBUnidade";
		CBUnidade.Size = new Size(66, 17);
		CBUnidade.TabIndex = 97;
		CBUnidade.Text = "Unidade";
		CBUnidade.UseVisualStyleBackColor = true;
		GroupBox3.Controls.Add(CBPaginaReserva);
		GroupBox3.Controls.Add(CBPagina);
		GroupBox3.Controls.Add(CBUnidade);
		GroupBox3.Controls.Add(CBTitulo1);
		GroupBox3.Controls.Add(CBTitulo2);
		GroupBox3.Controls.Add(CBTitulo3);
		GroupBox3.Controls.Add(CBAlternativo);
		GroupBox3.Controls.Add(CBTitulo4);
		GroupBox3.Controls.Add(CBRev);
		GroupBox3.Location = new Point(258, 12);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(174, 137);
		GroupBox3.TabIndex = 98;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "GroupBox3";
		CBPaginaReserva.AutoSize = true;
		CBPaginaReserva.Location = new Point(12, 111);
		CBPaginaReserva.Name = "CBPaginaReserva";
		CBPaginaReserva.Size = new Size(59, 17);
		CBPaginaReserva.TabIndex = 95;
		CBPaginaReserva.Text = "Página";
		CBPaginaReserva.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(438, 296);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox2);
		Controls.Add(BTCancelar);
		Controls.Add(btExporta);
		Controls.Add(btApagar);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmRelatorio_IndicedePaginas";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Indice de Páginas";
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return tU9pO9Zwnl8;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		tU9pO9Zwnl8 = WithEventsValue;
	}

	public frmRelatorio_IndicedePaginas()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		nZXpIaVKlh4 = "INDICE";
		YxEpI8B0I1y = new ColorDialog();
		kD2pINY5WFX = false;
		WgDpIF4EiNO = false;
		if (Geral.ExisteForm("frmRelatorio_IndicedePaginas"))
		{
			return;
		}
		AjKpOLdkTZH();
		DeclaracoesGeral.Reguas RH = default;
		if (XDataGeral.LeXDataReguaH(ref RH))
		{
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 338]);
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 111]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 382]);
			GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 354]);
			LabelTamanhoFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 339]);
			LabelCorLinha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 340]);
			LabelCorTexto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 341]);
			LabelQuantColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 342]);
			LabelStiloLinha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 343]);
			LBAlturaDoBloco.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 344]);
			LBDistanciaEntreColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 345]);
			LabelDistanciaDaRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 350]);
			DeclaracoesGeral.Titulos tit = default;
			Pagina.buscaTitulosExistentes(ref tit);
			CBPagina.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]);
			CBAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]);
			CBUnidade.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 11]);
			CBRev.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 62]);
			CBTitulo1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 346]);
			CBTitulo2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 347]);
			CBTitulo3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 348]);
			CBTitulo4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 349]);
			CBPaginaReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1689]);
			LBPaginaReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1689]);
			TBPaginaReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 375]);
			CBPagina.Checked = true;
			CBAlternativo.Checked = false;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4", writable: true);
			if (registryKey != null)
			{
				kD2pINY5WFX = Conversions.ToBoolean(registryKey.GetValue("Altern", "0"));
				CBAlternativo.Enabled = true;
				CBPagina.Enabled = true;
			}
			else
			{
				registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4");
				registryKey.SetValue("Altern", "0");
				kD2pINY5WFX = false;
				CBAlternativo.Enabled = false;
				CBPagina.Enabled = false;
			}
			registryKey.Close();
			CBRev.Checked = true;
			CBTitulo1.Enabled = true;
			CBTitulo2.Enabled = true;
			CBTitulo3.Enabled = true;
			CBTitulo4.Enabled = true;
			if (!tit.bTitulo1)
			{
				CBTitulo1.Enabled = false;
			}
			if (!tit.bTitulo2)
			{
				CBTitulo2.Enabled = false;
			}
			if (!tit.bTitulo3)
			{
				CBTitulo3.Enabled = false;
			}
			if (!tit.bTitulo4)
			{
				CBTitulo4.Enabled = false;
			}
			tbFonteBloco.Text = "2";
			CBColunas.Items.Clear();
			CBColunas.Items.Add("1");
			CBColunas.Items.Add("2");
			CBColunas.Items.Add("3");
			CBColunas.Items.Add("4");
			CBColunas.Items.Add("5");
			CBColunas.Text = "2";
			string[] array = new string[1];
			TBAlturaInicialRelatorio.Text = "25";
			array = (string[])Relatorios_Paginas.CapturaOsTextStyle();
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
			TBPaginaReserva.Enabled = false;
			TBDisteEntreColunas.Text = Conversions.ToString(6);
			TBAlturaDoBloco.Text = Conversions.ToString(7);
			CBTitulo1.Checked = true;
			Color val = Color.FromColorIndex((ColorMethod)194, (short)7);
			btCorBloco.BackColor = val.ColorValue;
			val = Color.FromColorIndex((ColorMethod)194, (short)7);
			btCorTextoBloco.BackColor = val.ColorValue;
			avbpIqZyC1C.CorLinha = 7;
			avbpIqZyC1C.CorTexto = 7;
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			iRspOKPPcI6();
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
		}
	}

	private void DcQpOwUIcfP(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = YxEpI8B0I1y.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			avbpIqZyC1C.CorLinha = YxEpI8B0I1y.Color.ColorIndex;
			btCorBloco.BackColor = YxEpI8B0I1y.Color.ColorValue;
		}
	}

	private void xYApOx4ZFDf(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = YxEpI8B0I1y.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			avbpIqZyC1C.CorTexto = YxEpI8B0I1y.Color.ColorIndex;
			btCorTextoBloco.BackColor = YxEpI8B0I1y.Color.ColorValue;
		}
	}

	private short WLWpObbOfVt()
	{
		DialogResult dialogResult = YxEpI8B0I1y.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return YxEpI8B0I1y.Color.ColorIndex;
	}

	private void t2FpOMq727T(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void on6pOONv8L0(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void dBGpOInG38v(object P_0, EventArgs P_1)
	{
		avbpIqZyC1C.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
		avbpIqZyC1C.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		avbpIqZyC1C.AlturaInicial = verificadecimal(TBAlturaInicialRelatorio.Text);
		avbpIqZyC1C.sFonte = CBFonte.Text;
		avbpIqZyC1C.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
		avbpIqZyC1C.Tit1 = CBTitulo1.Checked;
		avbpIqZyC1C.Tit2 = CBTitulo2.Checked;
		avbpIqZyC1C.Tit3 = CBTitulo3.Checked;
		avbpIqZyC1C.Tit4 = CBTitulo4.Checked;
		avbpIqZyC1C.Tit4 = CBTitulo4.Checked;
		avbpIqZyC1C.bRev = CBRev.Checked;
		avbpIqZyC1C.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
		DeclaracoesGeral.bPararRelatorio = false;
		Relatorios_Paginas.InsereIndiceDePaginas(avbpIqZyC1C, CBPagina.Checked, CBAlternativo.Checked, CBUnidade.Checked, CBPaginaReserva.Checked, TBPaginaReserva.Text);
	}

	public double verificadecimal(string sNumero)
	{
		double num = Conversions.ToDouble(sNumero);
		try
		{
			string str = Conversions.ToString(0.5);
			str = Strings.Mid(str, 2, 1);
			sNumero = sNumero.Replace(".", str);
			sNumero = sNumero.Replace(",", str);
			num = (Versioned.IsNumeric(sNumero) ? Conversions.ToDouble(sNumero) : 25.0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			num = Conversions.ToDouble(sNumero);
			ProjectData.ClearProjectError();
		}
		return num;
	}

	private void I4mpO7CmXOj(object P_0, EventArgs P_1)
	{
		Relatorios_Paginas.ApagaRelatorioDeIndices();
	}

	private void WpZpOqUjMkW(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		Application.DoEvents();
	}

	private void LpcpOa9Y1qR(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void MEfpO8vJ4GC(object P_0, EventArgs P_1)
	{
		if (LF6pI7gVPgU)
		{
			LF6pI7gVPgU = false;
			iRspOKPPcI6();
			return;
		}
		LF6pI7gVPgU = true;
		bt1.Enabled = true;
		bt2.Enabled = true;
		bt3.Enabled = true;
		bt4.Enabled = true;
		bt5.Enabled = true;
	}

	private void bxCpONiv9TB(object P_0, EventArgs P_1)
	{
		if (LF6pI7gVPgU)
		{
			YPEpO3RHXDO(1);
			LF6pI7gVPgU = false;
		}
		else
		{
			TBNome.Text = "";
			m2xpOebkxF8(1);
		}
	}

	private void JVApOFMCgGG(object P_0, EventArgs P_1)
	{
		if (LF6pI7gVPgU)
		{
			YPEpO3RHXDO(2);
			LF6pI7gVPgU = false;
		}
		else
		{
			TBNome.Text = "";
			m2xpOebkxF8(2);
		}
	}

	private void c35pOQBI4tk(object P_0, EventArgs P_1)
	{
		if (LF6pI7gVPgU)
		{
			YPEpO3RHXDO(3);
			LF6pI7gVPgU = false;
		}
		else
		{
			TBNome.Text = "";
			m2xpOebkxF8(3);
		}
	}

	private void tJSpOPFQoJA(object P_0, EventArgs P_1)
	{
		if (LF6pI7gVPgU)
		{
			YPEpO3RHXDO(4);
			LF6pI7gVPgU = false;
		}
		else
		{
			TBNome.Text = "";
			m2xpOebkxF8(4);
		}
	}

	private void HZ1pOcbqgOY(object P_0, EventArgs P_1)
	{
		if (LF6pI7gVPgU)
		{
			YPEpO3RHXDO(5);
			LF6pI7gVPgU = false;
		}
		else
		{
			TBNome.Text = "";
			m2xpOebkxF8(5);
		}
	}

	private void iRspOKPPcI6()
	{
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
					DataTable dataTable = cDadosAccessComum2.LeConfiguracaoRelatorio("E", nZXpIaVKlh4);
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

	private void m2xpOebkxF8(int P_0)
	{
		WgDpIF4EiNO = true;
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string sComando = "";
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.LeConfiguracao(ref sComando, P_0, "E", nZXpIaVKlh4);
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
		int num = 1;
		object obj = array;
		qV5pO2j75ZY(ref obj, sComando);
		array = (object[])obj;
		TBNome.Text = Conversions.ToString(array[1]);
		num = 2;
		CBTitulo1.Checked = Conversions.ToBoolean(array[2]);
		num = 3;
		CBTitulo2.Checked = Conversions.ToBoolean(array[3]);
		num = 4;
		CBTitulo3.Checked = Conversions.ToBoolean(array[4]);
		num = 5;
		CBTitulo4.Checked = Conversions.ToBoolean(array[5]);
		num = 6;
		CBRev.Checked = Conversions.ToBoolean(array[6]);
		num = 7;
		Color val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[7]));
		btCorBloco.BackColor = val.ColorValue;
		num = 8;
		avbpIqZyC1C.CorLinha = val.ColorIndex;
		val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[8]));
		btCorTextoBloco.BackColor = val.ColorValue;
		num = 9;
		avbpIqZyC1C.CorTexto = val.ColorIndex;
		tbFonteBloco.Text = Conversions.ToString(array[9]);
		num = 10;
		CBColunas.Text = Conversions.ToString(array[10]);
		num = 11;
		TBDisteEntreColunas.Text = Conversions.ToString(array[11]);
		num = 12;
		TBAlturaDoBloco.Text = Conversions.ToString(array[12]);
		num = 13;
		CBFonte.Text = Conversions.ToString(array[13]);
		num = 14;
		TBAlturaInicialRelatorio.Text = Conversions.ToString(array[14]);
		num = 15;
		checked
		{
			if (Information.UBound(array) >= 15)
			{
				CBPagina.Checked = Conversions.ToBoolean(array[num]);
				num++;
			}
			if (!CBAlternativo.Visible)
			{
				num++;
			}
			else if (Information.UBound(array) >= num)
			{
				CBAlternativo.Checked = Conversions.ToBoolean(array[num]);
				num++;
			}
			if (CBUnidade.Visible && Information.UBound(array) >= num)
			{
				CBUnidade.Checked = Conversions.ToBoolean(array[num]);
				num++;
			}
			try
			{
				CBPaginaReserva.Checked = false;
				TBPaginaReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 375]);
				CBPaginaReserva.Checked = Conversions.ToBoolean(array[num]);
				num++;
				if (CBPaginaReserva.Checked)
				{
					TBPaginaReserva.Text = Conversions.ToString(array[num]);
					num++;
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			WgDpIF4EiNO = false;
		}
	}

	private void qV5pO2j75ZY(ref object P_0, string P_1)
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

	private void YPEpO3RHXDO(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = "";
		text = TBNome.Text;
		text = text + ";" + Conversions.ToString(CBTitulo1.Checked);
		text = text + ";" + Conversions.ToString(CBTitulo2.Checked);
		text = text + ";" + Conversions.ToString(CBTitulo3.Checked);
		text = text + ";" + Conversions.ToString(CBTitulo4.Checked);
		text = text + ";" + Conversions.ToString(CBRev.Checked);
		text = text + ";" + Conversions.ToString((int)avbpIqZyC1C.CorLinha);
		text = text + ";" + Conversions.ToString((int)avbpIqZyC1C.CorTexto);
		text = text + ";" + tbFonteBloco.Text;
		text = text + ";" + CBColunas.Text;
		text = text + ";" + TBDisteEntreColunas.Text;
		text = text + ";" + TBAlturaDoBloco.Text;
		text = text + ";" + CBFonte.Text;
		text = text + ";" + TBAlturaInicialRelatorio.Text;
		text = text + ";" + Conversions.ToString(CBPagina.Checked);
		text = text + ";" + Conversions.ToString(CBAlternativo.Checked);
		text = text + ";" + Conversions.ToString(CBUnidade.Checked);
		text = text + ";" + Conversions.ToString(CBPaginaReserva.Checked);
		text = text + ";" + TBPaginaReserva.Text;
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.GravaConfiguracao(text, P_0, "E", nZXpIaVKlh4);
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
		iRspOKPPcI6();
	}

	private void MTKpOnwFjn3(object P_0, EventArgs P_1)
	{
		if (CBPagina.Checked)
		{
			if (CBAlternativo.Checked)
			{
				CBAlternativo.Checked = false;
			}
		}
		else
		{
			CBAlternativo.Checked = true;
		}
	}

	private void PynpO1j6ZLJ(object P_0, EventArgs P_1)
	{
		if (CBAlternativo.Checked)
		{
			if (CBPagina.Checked)
			{
				CBPagina.Checked = false;
			}
		}
		else
		{
			CBPagina.Checked = true;
		}
	}

	private void fg4pOl6PvhU(object P_0, EventArgs P_1)
	{
		if (!WgDpIF4EiNO && (!CBTitulo1.Checked & !CBTitulo2.Checked & !CBTitulo3.Checked & !CBTitulo4.Checked))
		{
			CBTitulo1.Checked = true;
		}
	}

	private void TUSpO5FdxLi(object P_0, EventArgs P_1)
	{
		if (!WgDpIF4EiNO && (!CBTitulo1.Checked & !CBTitulo2.Checked & !CBTitulo3.Checked & !CBTitulo4.Checked))
		{
			CBTitulo1.Checked = true;
		}
	}

	private void n78pO0p4AT3(object P_0, EventArgs P_1)
	{
		if (!WgDpIF4EiNO && (!CBTitulo1.Checked & !CBTitulo2.Checked & !CBTitulo3.Checked & !CBTitulo4.Checked))
		{
			CBTitulo1.Checked = true;
		}
	}

	private void pHspORhXpPA(object P_0, EventArgs P_1)
	{
		if (!WgDpIF4EiNO && (!CBTitulo1.Checked & !CBTitulo2.Checked & !CBTitulo3.Checked & !CBTitulo4.Checked))
		{
			CBTitulo1.Checked = true;
		}
	}

	private void NkspOmKUi3e(object P_0, EventArgs P_1)
	{
		TBPaginaReserva.Enabled = false;
		if (CBPaginaReserva.Checked)
		{
			TBPaginaReserva.Enabled = true;
		}
	}
}
