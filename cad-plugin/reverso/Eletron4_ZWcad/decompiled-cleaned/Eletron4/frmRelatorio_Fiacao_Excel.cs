using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Fiacao_Excel : Form
{
	public struct ConfRelelatorioExcel
	{
		public string Desc1;

		public string NumDesenho;

		public string sRev;

		public double LinhasPorPagina;

		public bool bPagina;

		public string Prefixo;

		public string Sufixo;

		public string sCaminhoDesenho;
	}

	private IContainer HHnOXYigPn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelPainel")]
	private Label gTKOUISD26;

	[AccessedThroughProperty("btEletrosulA")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button iypOyJF1r9;

	[AccessedThroughProperty("Label9")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label KrqOgwV3gY;

	[AccessedThroughProperty("tbLinhasPorPaginaNorte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox bOVOA2JcTH;

	[CompilerGenerated]
	[AccessedThroughProperty("btExportaExcelEletronorte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button WqJOsORwYL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEletronorteE")]
	[CompilerGenerated]
	private Button HKjOBr7llN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btParar")]
	[CompilerGenerated]
	private Button jMkOVqIhFF;

	[AccessedThroughProperty("btFurnasAntigoC")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button T1QOumqU8t;

	[CompilerGenerated]
	[AccessedThroughProperty("btExportaExcelFurnas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button aNlOEWwry9;

	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label uWZOZ63yiQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbLinhasPorPaginaFurnas")]
	private TextBox ccZOiV32wf;

	[AccessedThroughProperty("rbDispositivos")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label UvuOSF1aGL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDisp")]
	private TextBox OKPO4PRVkD;

	[AccessedThroughProperty("tbSeparador")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox QHxOCDsmgI;

	[CompilerGenerated]
	[AccessedThroughProperty("rbTerminal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label eaTOYEuCBG;

	[AccessedThroughProperty("ckOrigemDestino")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton k5GOrlOThd;

	[CompilerGenerated]
	[AccessedThroughProperty("ckDestino")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton SExO9HS4yO;

	[AccessedThroughProperty("ckOrigem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton WQYOzKU6Bb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox_E")]
	[CompilerGenerated]
	private GroupBox olTIWTEo5E;

	[AccessedThroughProperty("GroupBox_A_B_D")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox SghIpSUcaX;

	[AccessedThroughProperty("btModeloExcel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button h9dIT8RYSw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDesc1")]
	[CompilerGenerated]
	private Label UTpIJCJbrb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbLinhas")]
	[CompilerGenerated]
	private Label PxSIhMFSld;

	[AccessedThroughProperty("tbNumDesenho")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox zbwIoCU6Z2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btSelecionaImagem")]
	private Button n0HIGAwbXE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbNumDesenho")]
	private Label PhDIHHZN40;

	[AccessedThroughProperty("tbCaminho")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox a3hIkNpa0u;

	[AccessedThroughProperty("tbLinhasPorPaginaSul")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox SpLIdEZoBV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbImagem")]
	[CompilerGenerated]
	private Label EhaIfkjc7V;

	[AccessedThroughProperty("tbDesc1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox r56IDhaxWI;

	[AccessedThroughProperty("tbRev")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox si3Ivc4WWN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCELELETROSUL")]
	private Button uAlI6Y3mEb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbRev")]
	private Label Gv1ItwMnx1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbPaginas")]
	private Label LXtIj4SSIr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPaginaInicio")]
	private TextBox NPAILnGxNn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox_C")]
	private GroupBox VVBIw6B5gs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btFurnasNovoB")]
	[CompilerGenerated]
	private Button uE4IxWn8NA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbAnilha")]
	private Label e00IbyC61v;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbSeparador")]
	[CompilerGenerated]
	private Label DSwIMYo4Rj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCEMIG_D")]
	private Button N88IOMiKfc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCorBitola")]
	private RadioButton CcyIIivsDx;

	[CompilerGenerated]
	[AccessedThroughProperty("rbBitola")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton zXcI7Lv3hb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private GroupBox BYTIqBZ5EV;

	private bool gkvIaBNOWw;

	private ConfRelelatorioExcel AVJI8uP4uN;

	private DeclaracoesFiacao.structureRelFiacao[] HyNIN6qecd;

	private string MaxIFIUw3a;

	private int HjUIQYQ7FY;

	private string nMoIPpcTVs;

	private ColorDialog yolIc2W8o1;

	private string Nq9IKMuSHW;

	private string nwHIeaUAu6;

	private int r5MI2xYsoo;

	private string DyQI33GeCK;

	private string DsjInjsO6S;

	private Declaracoes2.StructureIndiceRelatEletroSul[] dSGI1og8EM;

	internal virtual Label LabelPainel
	{
		[CompilerGenerated]
		get
		{
			return gTKOUISD26;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gTKOUISD26 = value;
		}
	}

	internal virtual Button btEletrosulA
	{
		[CompilerGenerated]
		get
		{
			return iypOyJF1r9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Y0bOKfDBx3;
			Button button = iypOyJF1r9;
			if (button != null)
			{
				button.Click -= value2;
			}
			iypOyJF1r9 = value;
			button = iypOyJF1r9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label9
	{
		[CompilerGenerated]
		get
		{
			return KrqOgwV3gY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KrqOgwV3gY = value;
		}
	}

	internal virtual TextBox tbLinhasPorPaginaNorte
	{
		[CompilerGenerated]
		get
		{
			return bOVOA2JcTH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = zUVOPY4tBF;
			TextBox textBox = bOVOA2JcTH;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			bOVOA2JcTH = value;
			textBox = bOVOA2JcTH;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button btExportaExcelEletronorte
	{
		[CompilerGenerated]
		get
		{
			return WqJOsORwYL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XgPO5V7gqx;
			Button button = WqJOsORwYL;
			if (button != null)
			{
				button.Click -= value2;
			}
			WqJOsORwYL = value;
			button = WqJOsORwYL;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEletronorteE
	{
		[CompilerGenerated]
		get
		{
			return HKjOBr7llN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = w4sOcItVuB;
			Button button = HKjOBr7llN;
			if (button != null)
			{
				button.Click -= value2;
			}
			HKjOBr7llN = value;
			button = HKjOBr7llN;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btParar
	{
		[CompilerGenerated]
		get
		{
			return jMkOVqIhFF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = W00O1eKQJf;
			Button button = jMkOVqIhFF;
			if (button != null)
			{
				button.Click -= value2;
			}
			jMkOVqIhFF = value;
			button = jMkOVqIhFF;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btFurnasAntigoC
	{
		[CompilerGenerated]
		get
		{
			return T1QOumqU8t;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bIPO2WlqPG;
			Button button = T1QOumqU8t;
			if (button != null)
			{
				button.Click -= value2;
			}
			T1QOumqU8t = value;
			button = T1QOumqU8t;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportaExcelFurnas
	{
		[CompilerGenerated]
		get
		{
			return aNlOEWwry9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eaFO0g1Qvn;
			Button button = aNlOEWwry9;
			if (button != null)
			{
				button.Click -= value2;
			}
			aNlOEWwry9 = value;
			button = aNlOEWwry9;
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
			return uWZOZ63yiQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uWZOZ63yiQ = value;
		}
	}

	internal virtual TextBox tbLinhasPorPaginaFurnas
	{
		[CompilerGenerated]
		get
		{
			return ccZOiV32wf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ccZOiV32wf = value;
		}
	}

	internal virtual Label rbDispositivos
	{
		[CompilerGenerated]
		get
		{
			return UvuOSF1aGL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UvuOSF1aGL = value;
		}
	}

	internal virtual TextBox tbDisp
	{
		[CompilerGenerated]
		get
		{
			return OKPO4PRVkD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OKPO4PRVkD = value;
		}
	}

	internal virtual TextBox tbSeparador
	{
		[CompilerGenerated]
		get
		{
			return QHxOCDsmgI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QHxOCDsmgI = value;
		}
	}

	internal virtual Label rbTerminal
	{
		[CompilerGenerated]
		get
		{
			return eaTOYEuCBG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eaTOYEuCBG = value;
		}
	}

	internal virtual RadioButton ckOrigemDestino
	{
		[CompilerGenerated]
		get
		{
			return k5GOrlOThd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FM9ORhX6As;
			RadioButton radioButton = k5GOrlOThd;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			k5GOrlOThd = value;
			radioButton = k5GOrlOThd;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton ckDestino
	{
		[CompilerGenerated]
		get
		{
			return SExO9HS4yO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FM9ORhX6As;
			RadioButton radioButton = SExO9HS4yO;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			SExO9HS4yO = value;
			radioButton = SExO9HS4yO;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton ckOrigem
	{
		[CompilerGenerated]
		get
		{
			return WQYOzKU6Bb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FM9ORhX6As;
			RadioButton radioButton = WQYOzKU6Bb;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			WQYOzKU6Bb = value;
			radioButton = WQYOzKU6Bb;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox_E
	{
		[CompilerGenerated]
		get
		{
			return olTIWTEo5E;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			olTIWTEo5E = value;
		}
	}

	internal virtual GroupBox GroupBox_A_B_D
	{
		[CompilerGenerated]
		get
		{
			return SghIpSUcaX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SghIpSUcaX = value;
		}
	}

	internal virtual Button btModeloExcel
	{
		[CompilerGenerated]
		get
		{
			return h9dIT8RYSw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rBIOn6hM9s;
			Button button = h9dIT8RYSw;
			if (button != null)
			{
				button.Click -= value2;
			}
			h9dIT8RYSw = value;
			button = h9dIT8RYSw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbDesc1
	{
		[CompilerGenerated]
		get
		{
			return UTpIJCJbrb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UTpIJCJbrb = value;
		}
	}

	internal virtual Label lbLinhas
	{
		[CompilerGenerated]
		get
		{
			return PxSIhMFSld;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PxSIhMFSld = value;
		}
	}

	internal virtual TextBox tbNumDesenho
	{
		[CompilerGenerated]
		get
		{
			return zbwIoCU6Z2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zbwIoCU6Z2 = value;
		}
	}

	internal virtual Button btSelecionaImagem
	{
		[CompilerGenerated]
		get
		{
			return n0HIGAwbXE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = q48O3MhG1s;
			Button button = n0HIGAwbXE;
			if (button != null)
			{
				button.Click -= value2;
			}
			n0HIGAwbXE = value;
			button = n0HIGAwbXE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbNumDesenho
	{
		[CompilerGenerated]
		get
		{
			return PhDIHHZN40;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PhDIHHZN40 = value;
		}
	}

	internal virtual TextBox tbCaminho
	{
		[CompilerGenerated]
		get
		{
			return a3hIkNpa0u;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a3hIkNpa0u = value;
		}
	}

	internal virtual TextBox tbLinhasPorPaginaSul
	{
		[CompilerGenerated]
		get
		{
			return SpLIdEZoBV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = XBdOQ3jL5o;
			TextBox textBox = SpLIdEZoBV;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			SpLIdEZoBV = value;
			textBox = SpLIdEZoBV;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label lbImagem
	{
		[CompilerGenerated]
		get
		{
			return EhaIfkjc7V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EhaIfkjc7V = value;
		}
	}

	internal virtual TextBox tbDesc1
	{
		[CompilerGenerated]
		get
		{
			return r56IDhaxWI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			r56IDhaxWI = value;
		}
	}

	internal virtual TextBox tbRev
	{
		[CompilerGenerated]
		get
		{
			return si3Ivc4WWN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			si3Ivc4WWN = value;
		}
	}

	internal virtual Button btExportaEXCELELETROSUL
	{
		[CompilerGenerated]
		get
		{
			return uAlI6Y3mEb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yXCOlnVBVF;
			Button button = uAlI6Y3mEb;
			if (button != null)
			{
				button.Click -= value2;
			}
			uAlI6Y3mEb = value;
			button = uAlI6Y3mEb;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbRev
	{
		[CompilerGenerated]
		get
		{
			return Gv1ItwMnx1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Gv1ItwMnx1 = value;
		}
	}

	internal virtual Label lbPaginas
	{
		[CompilerGenerated]
		get
		{
			return LXtIj4SSIr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LXtIj4SSIr = value;
		}
	}

	internal virtual TextBox tbPaginaInicio
	{
		[CompilerGenerated]
		get
		{
			return NPAILnGxNn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NPAILnGxNn = value;
		}
	}

	internal virtual GroupBox GroupBox_C
	{
		[CompilerGenerated]
		get
		{
			return VVBIw6B5gs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VVBIw6B5gs = value;
		}
	}

	internal virtual Button btFurnasNovoB
	{
		[CompilerGenerated]
		get
		{
			return uE4IxWn8NA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = r9XOejD7Zh;
			Button button = uE4IxWn8NA;
			if (button != null)
			{
				button.Click -= value2;
			}
			uE4IxWn8NA = value;
			button = uE4IxWn8NA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbAnilha
	{
		[CompilerGenerated]
		get
		{
			return e00IbyC61v;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			e00IbyC61v = value;
		}
	}

	internal virtual Label lbSeparador
	{
		[CompilerGenerated]
		get
		{
			return DSwIMYo4Rj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DSwIMYo4Rj = value;
		}
	}

	internal virtual Button btCEMIG_D
	{
		[CompilerGenerated]
		get
		{
			return N88IOMiKfc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Vf5OmCXoMm;
			Button button = N88IOMiKfc;
			if (button != null)
			{
				button.Click -= value2;
			}
			N88IOMiKfc = value;
			button = N88IOMiKfc;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbCorBitola
	{
		[CompilerGenerated]
		get
		{
			return CcyIIivsDx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CcyIIivsDx = value;
		}
	}

	internal virtual RadioButton rbBitola
	{
		[CompilerGenerated]
		get
		{
			return zXcI7Lv3hb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zXcI7Lv3hb = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return BYTIqBZ5EV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BYTIqBZ5EV = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && HHnOXYigPn != null)
			{
				HHnOXYigPn.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void mUBONcOCa6()
	{
		btParar = new Button();
		btEletrosulA = new Button();
		LabelPainel = new Label();
		btExportaExcelEletronorte = new Button();
		Label9 = new Label();
		tbLinhasPorPaginaNorte = new TextBox();
		btEletronorteE = new Button();
		btFurnasAntigoC = new Button();
		btExportaExcelFurnas = new Button();
		Label1 = new Label();
		tbLinhasPorPaginaFurnas = new TextBox();
		ckOrigemDestino = new RadioButton();
		ckDestino = new RadioButton();
		ckOrigem = new RadioButton();
		rbDispositivos = new Label();
		tbSeparador = new TextBox();
		tbDisp = new TextBox();
		rbTerminal = new Label();
		GroupBox_E = new GroupBox();
		GroupBox_A_B_D = new GroupBox();
		GroupBox1 = new GroupBox();
		rbCorBitola = new RadioButton();
		rbBitola = new RadioButton();
		btModeloExcel = new Button();
		lbDesc1 = new Label();
		lbLinhas = new Label();
		tbNumDesenho = new TextBox();
		btSelecionaImagem = new Button();
		lbNumDesenho = new Label();
		tbCaminho = new TextBox();
		tbLinhasPorPaginaSul = new TextBox();
		lbImagem = new Label();
		tbDesc1 = new TextBox();
		tbRev = new TextBox();
		btExportaEXCELELETROSUL = new Button();
		lbRev = new Label();
		lbPaginas = new Label();
		tbPaginaInicio = new TextBox();
		GroupBox_C = new GroupBox();
		lbSeparador = new Label();
		lbAnilha = new Label();
		btFurnasNovoB = new Button();
		btCEMIG_D = new Button();
		GroupBox_E.SuspendLayout();
		GroupBox_A_B_D.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox_C.SuspendLayout();
		SuspendLayout();
		btParar.FlatStyle = FlatStyle.Flat;
		btParar.ForeColor = SystemColors.Control;
		btParar.Image = Resources.Stop_32;
		btParar.Location = new Point(131, 632);
		btParar.Name = "btParar";
		btParar.Size = new Size(40, 42);
		btParar.TabIndex = 105;
		btParar.UseVisualStyleBackColor = true;
		btEletrosulA.AutoSize = true;
		btEletrosulA.FlatStyle = FlatStyle.Flat;
		btEletrosulA.Image = Resources.EletroSul;
		btEletrosulA.Location = new Point(15, 30);
		btEletrosulA.Name = "btEletrosulA";
		btEletrosulA.Size = new Size(110, 50);
		btEletrosulA.TabIndex = 99;
		btEletrosulA.UseVisualStyleBackColor = true;
		LabelPainel.AutoSize = true;
		LabelPainel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		LabelPainel.Location = new Point(16, 13);
		LabelPainel.Name = "LabelPainel";
		LabelPainel.Size = new Size(73, 13);
		LabelPainel.TabIndex = 96;
		LabelPainel.Text = "LabelPainel";
		LabelPainel.TextAlign = ContentAlignment.MiddleLeft;
		btExportaExcelEletronorte.FlatStyle = FlatStyle.Flat;
		btExportaExcelEletronorte.ForeColor = SystemColors.Control;
		btExportaExcelEletronorte.Image = Resources.ExportaExcel_20;
		btExportaExcelEletronorte.Location = new Point(300, 130);
		btExportaExcelEletronorte.Name = "btExportaExcelEletronorte";
		btExportaExcelEletronorte.Size = new Size(40, 43);
		btExportaExcelEletronorte.TabIndex = 103;
		btExportaExcelEletronorte.UseVisualStyleBackColor = true;
		Label9.Location = new Point(61, 147);
		Label9.Name = "Label9";
		Label9.Size = new Size(100, 25);
		Label9.TabIndex = 102;
		Label9.Text = "lbLinhas por Página";
		Label9.TextAlign = ContentAlignment.MiddleLeft;
		tbLinhasPorPaginaNorte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLinhasPorPaginaNorte.Location = new Point(167, 148);
		tbLinhasPorPaginaNorte.Name = "tbLinhasPorPaginaNorte";
		tbLinhasPorPaginaNorte.Size = new Size(68, 20);
		tbLinhasPorPaginaNorte.TabIndex = 69;
		tbLinhasPorPaginaNorte.TextAlign = HorizontalAlignment.Center;
		btEletronorteE.FlatStyle = FlatStyle.Flat;
		btEletronorteE.Image = Resources.eletron;
		btEletronorteE.Location = new Point(131, 86);
		btEletronorteE.Name = "btEletronorteE";
		btEletronorteE.Size = new Size(110, 50);
		btEletronorteE.TabIndex = 104;
		btEletronorteE.TextAlign = ContentAlignment.MiddleRight;
		btEletronorteE.UseVisualStyleBackColor = true;
		btFurnasAntigoC.FlatStyle = FlatStyle.Flat;
		btFurnasAntigoC.Image = Resources.EletrobrasFurnas;
		btFurnasAntigoC.Location = new Point(244, 30);
		btFurnasAntigoC.Name = "btFurnasAntigoC";
		btFurnasAntigoC.Size = new Size(110, 50);
		btFurnasAntigoC.TabIndex = 105;
		btFurnasAntigoC.TextAlign = ContentAlignment.MiddleRight;
		btFurnasAntigoC.UseVisualStyleBackColor = true;
		btExportaExcelFurnas.FlatStyle = FlatStyle.Flat;
		btExportaExcelFurnas.ForeColor = SystemColors.Control;
		btExportaExcelFurnas.Image = Resources.ExportaExcel_20;
		btExportaExcelFurnas.Location = new Point(300, 130);
		btExportaExcelFurnas.Name = "btExportaExcelFurnas";
		btExportaExcelFurnas.Size = new Size(40, 43);
		btExportaExcelFurnas.TabIndex = 103;
		btExportaExcelFurnas.UseVisualStyleBackColor = true;
		Label1.Location = new Point(60, 147);
		Label1.Name = "Label1";
		Label1.Size = new Size(100, 20);
		Label1.TabIndex = 102;
		Label1.Text = "lbLinhas por Página";
		Label1.TextAlign = ContentAlignment.MiddleLeft;
		tbLinhasPorPaginaFurnas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLinhasPorPaginaFurnas.Location = new Point(166, 148);
		tbLinhasPorPaginaFurnas.Name = "tbLinhasPorPaginaFurnas";
		tbLinhasPorPaginaFurnas.Size = new Size(91, 20);
		tbLinhasPorPaginaFurnas.TabIndex = 69;
		tbLinhasPorPaginaFurnas.TextAlign = HorizontalAlignment.Center;
		ckOrigemDestino.AutoSize = true;
		ckOrigemDestino.Location = new Point(235, 36);
		ckOrigemDestino.Name = "ckOrigemDestino";
		ckOrigemDestino.Size = new Size(106, 17);
		ckOrigemDestino.TabIndex = 115;
		ckOrigemDestino.TabStop = true;
		ckOrigemDestino.Text = "ckOrigemDestino";
		ckOrigemDestino.UseVisualStyleBackColor = true;
		ckDestino.AutoSize = true;
		ckDestino.Location = new Point(124, 36);
		ckDestino.Name = "ckDestino";
		ckDestino.Size = new Size(73, 17);
		ckDestino.TabIndex = 114;
		ckDestino.TabStop = true;
		ckDestino.Text = "ckDestino";
		ckDestino.UseVisualStyleBackColor = true;
		ckOrigem.AutoSize = true;
		ckOrigem.Location = new Point(29, 36);
		ckOrigem.Name = "ckOrigem";
		ckOrigem.Size = new Size(70, 17);
		ckOrigem.TabIndex = 113;
		ckOrigem.TabStop = true;
		ckOrigem.Text = "ckOrigem";
		ckOrigem.UseVisualStyleBackColor = true;
		rbDispositivos.AutoSize = true;
		rbDispositivos.Location = new Point(24, 95);
		rbDispositivos.Name = "rbDispositivos";
		rbDispositivos.Size = new Size(66, 13);
		rbDispositivos.TabIndex = 105;
		rbDispositivos.Text = "lbDispositivo";
		tbSeparador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbSeparador.Location = new Point(225, 92);
		tbSeparador.Name = "tbSeparador";
		tbSeparador.Size = new Size(28, 22);
		tbSeparador.TabIndex = 107;
		tbSeparador.Text = ":";
		tbSeparador.TextAlign = HorizontalAlignment.Center;
		tbDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbDisp.Location = new Point(94, 90);
		tbDisp.Name = "tbDisp";
		tbDisp.Size = new Size(28, 22);
		tbDisp.TabIndex = 106;
		tbDisp.Text = "/";
		tbDisp.TextAlign = HorizontalAlignment.Center;
		rbTerminal.AutoSize = true;
		rbTerminal.Location = new Point(155, 95);
		rbTerminal.Name = "rbTerminal";
		rbTerminal.Size = new Size(55, 13);
		rbTerminal.TabIndex = 108;
		rbTerminal.Text = "lbTerminal";
		GroupBox_E.Controls.Add(btExportaExcelEletronorte);
		GroupBox_E.Controls.Add(tbLinhasPorPaginaNorte);
		GroupBox_E.Controls.Add(Label9);
		GroupBox_E.Location = new Point(9, 143);
		GroupBox_E.Name = "GroupBox_E";
		GroupBox_E.Size = new Size(355, 190);
		GroupBox_E.TabIndex = 111;
		GroupBox_E.TabStop = false;
		GroupBox_E.Text = "GB0E";
		GroupBox_A_B_D.Controls.Add(GroupBox1);
		GroupBox_A_B_D.Controls.Add(btModeloExcel);
		GroupBox_A_B_D.Controls.Add(lbDesc1);
		GroupBox_A_B_D.Controls.Add(lbLinhas);
		GroupBox_A_B_D.Controls.Add(tbNumDesenho);
		GroupBox_A_B_D.Controls.Add(btSelecionaImagem);
		GroupBox_A_B_D.Controls.Add(lbNumDesenho);
		GroupBox_A_B_D.Controls.Add(tbCaminho);
		GroupBox_A_B_D.Controls.Add(tbLinhasPorPaginaSul);
		GroupBox_A_B_D.Controls.Add(lbImagem);
		GroupBox_A_B_D.Controls.Add(tbDesc1);
		GroupBox_A_B_D.Controls.Add(tbRev);
		GroupBox_A_B_D.Controls.Add(btExportaEXCELELETROSUL);
		GroupBox_A_B_D.Controls.Add(lbRev);
		GroupBox_A_B_D.Controls.Add(lbPaginas);
		GroupBox_A_B_D.Controls.Add(tbPaginaInicio);
		GroupBox_A_B_D.Location = new Point(9, 143);
		GroupBox_A_B_D.Name = "GroupBox_A_B_D";
		GroupBox_A_B_D.Size = new Size(355, 190);
		GroupBox_A_B_D.TabIndex = 112;
		GroupBox_A_B_D.TabStop = false;
		GroupBox_A_B_D.Text = "GB0_A_B_D";
		GroupBox1.Controls.Add(rbCorBitola);
		GroupBox1.Controls.Add(rbBitola);
		GroupBox1.Location = new Point(237, 14);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(107, 56);
		GroupBox1.TabIndex = 117;
		GroupBox1.TabStop = false;
		rbCorBitola.AutoSize = true;
		rbCorBitola.Location = new Point(6, 30);
		rbCorBitola.Name = "rbCorBitola";
		rbCorBitola.Size = new Size(88, 17);
		rbCorBitola.TabIndex = 117;
		rbCorBitola.TabStop = true;
		rbCorBitola.Text = "rbCor e Bitola";
		rbCorBitola.UseVisualStyleBackColor = true;
		rbBitola.AutoSize = true;
		rbBitola.Location = new Point(6, 8);
		rbBitola.Name = "rbBitola";
		rbBitola.Size = new Size(60, 17);
		rbBitola.TabIndex = 116;
		rbBitola.TabStop = true;
		rbBitola.Text = "rbBitola";
		rbBitola.UseVisualStyleBackColor = true;
		btModeloExcel.FlatStyle = FlatStyle.Flat;
		btModeloExcel.ForeColor = SystemColors.Control;
		btModeloExcel.Image = Resources.ModeloExcel_32;
		btModeloExcel.Location = new Point(261, 137);
		btModeloExcel.Name = "btModeloExcel";
		btModeloExcel.Size = new Size(40, 42);
		btModeloExcel.TabIndex = 115;
		btModeloExcel.UseVisualStyleBackColor = true;
		lbDesc1.Location = new Point(11, 19);
		lbDesc1.Name = "lbDesc1";
		lbDesc1.Size = new Size(64, 25);
		lbDesc1.TabIndex = 70;
		lbDesc1.Text = "lbDesc1";
		lbDesc1.TextAlign = ContentAlignment.MiddleLeft;
		lbLinhas.Location = new Point(124, 70);
		lbLinhas.Name = "lbLinhas";
		lbLinhas.Size = new Size(107, 17);
		lbLinhas.TabIndex = 102;
		lbLinhas.Text = "lbLinhas por Página";
		lbLinhas.TextAlign = ContentAlignment.MiddleCenter;
		tbNumDesenho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNumDesenho.Location = new Point(75, 47);
		tbNumDesenho.Name = "tbNumDesenho";
		tbNumDesenho.Size = new Size(157, 20);
		tbNumDesenho.TabIndex = 98;
		tbNumDesenho.TextAlign = HorizontalAlignment.Center;
		btSelecionaImagem.FlatStyle = FlatStyle.Flat;
		btSelecionaImagem.ForeColor = SystemColors.Control;
		btSelecionaImagem.Image = Resources.Pesquisar_16;
		btSelecionaImagem.Location = new Point(226, 145);
		btSelecionaImagem.Name = "btSelecionaImagem";
		btSelecionaImagem.Size = new Size(23, 23);
		btSelecionaImagem.TabIndex = 114;
		btSelecionaImagem.UseVisualStyleBackColor = true;
		lbNumDesenho.Location = new Point(11, 47);
		lbNumDesenho.Name = "lbNumDesenho";
		lbNumDesenho.Size = new Size(64, 25);
		lbNumDesenho.TabIndex = 99;
		lbNumDesenho.Text = "lbDesenho";
		lbNumDesenho.TextAlign = ContentAlignment.MiddleLeft;
		tbCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCaminho.Location = new Point(14, 131);
		tbCaminho.Multiline = true;
		tbCaminho.Name = "tbCaminho";
		tbCaminho.Size = new Size(205, 51);
		tbCaminho.TabIndex = 111;
		tbLinhasPorPaginaSul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLinhasPorPaginaSul.Location = new Point(124, 90);
		tbLinhasPorPaginaSul.Name = "tbLinhasPorPaginaSul";
		tbLinhasPorPaginaSul.Size = new Size(107, 20);
		tbLinhasPorPaginaSul.TabIndex = 69;
		tbLinhasPorPaginaSul.TextAlign = HorizontalAlignment.Center;
		lbImagem.Location = new Point(14, 113);
		lbImagem.Name = "lbImagem";
		lbImagem.Size = new Size(231, 15);
		lbImagem.TabIndex = 112;
		lbImagem.Text = "Imagem";
		lbImagem.TextAlign = ContentAlignment.MiddleLeft;
		tbDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDesc1.Location = new Point(75, 19);
		tbDesc1.Name = "tbDesc1";
		tbDesc1.Size = new Size(157, 20);
		tbDesc1.TabIndex = 101;
		tbDesc1.TextAlign = HorizontalAlignment.Center;
		tbRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbRev.Location = new Point(8, 90);
		tbRev.Name = "tbRev";
		tbRev.Size = new Size(110, 20);
		tbRev.TabIndex = 109;
		tbRev.TextAlign = HorizontalAlignment.Center;
		btExportaEXCELELETROSUL.FlatStyle = FlatStyle.Flat;
		btExportaEXCELELETROSUL.ForeColor = SystemColors.Control;
		btExportaEXCELELETROSUL.Image = Resources.ExportaExcel_20;
		btExportaEXCELELETROSUL.Location = new Point(307, 135);
		btExportaEXCELELETROSUL.Name = "btExportaEXCELELETROSUL";
		btExportaEXCELELETROSUL.Size = new Size(40, 45);
		btExportaEXCELELETROSUL.TabIndex = 100;
		btExportaEXCELELETROSUL.UseVisualStyleBackColor = true;
		lbRev.Location = new Point(11, 72);
		lbRev.Name = "lbRev";
		lbRev.Size = new Size(107, 15);
		lbRev.TabIndex = 110;
		lbRev.Text = "lbsRev";
		lbRev.TextAlign = ContentAlignment.MiddleCenter;
		lbPaginas.Location = new Point(237, 72);
		lbPaginas.Name = "lbPaginas";
		lbPaginas.Size = new Size(107, 15);
		lbPaginas.TabIndex = 106;
		lbPaginas.Text = "lbPáginas";
		lbPaginas.TextAlign = ContentAlignment.MiddleCenter;
		tbPaginaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPaginaInicio.Location = new Point(237, 90);
		tbPaginaInicio.Name = "tbPaginaInicio";
		tbPaginaInicio.Size = new Size(107, 20);
		tbPaginaInicio.TabIndex = 105;
		tbPaginaInicio.TextAlign = HorizontalAlignment.Center;
		GroupBox_C.Controls.Add(lbSeparador);
		GroupBox_C.Controls.Add(rbDispositivos);
		GroupBox_C.Controls.Add(tbSeparador);
		GroupBox_C.Controls.Add(lbAnilha);
		GroupBox_C.Controls.Add(tbDisp);
		GroupBox_C.Controls.Add(ckOrigemDestino);
		GroupBox_C.Controls.Add(rbTerminal);
		GroupBox_C.Controls.Add(ckOrigem);
		GroupBox_C.Controls.Add(btExportaExcelFurnas);
		GroupBox_C.Controls.Add(ckDestino);
		GroupBox_C.Controls.Add(tbLinhasPorPaginaFurnas);
		GroupBox_C.Controls.Add(Label1);
		GroupBox_C.Location = new Point(9, 143);
		GroupBox_C.Name = "GroupBox_C";
		GroupBox_C.Size = new Size(355, 190);
		GroupBox_C.TabIndex = 113;
		GroupBox_C.TabStop = false;
		GroupBox_C.Text = "GB0C";
		lbSeparador.AutoSize = true;
		lbSeparador.Location = new Point(24, 72);
		lbSeparador.Name = "lbSeparador";
		lbSeparador.Size = new Size(64, 13);
		lbSeparador.TabIndex = 117;
		lbSeparador.Text = "lbSeparador";
		lbAnilha.AutoSize = true;
		lbAnilha.Location = new Point(24, 19);
		lbAnilha.Name = "lbAnilha";
		lbAnilha.Size = new Size(44, 13);
		lbAnilha.TabIndex = 116;
		lbAnilha.Text = "lbAnilha";
		btFurnasNovoB.FlatStyle = FlatStyle.Flat;
		btFurnasNovoB.Image = Resources.EletrobrasFurnasNovo;
		btFurnasNovoB.Location = new Point(131, 30);
		btFurnasNovoB.Name = "btFurnasNovoB";
		btFurnasNovoB.Size = new Size(110, 50);
		btFurnasNovoB.TabIndex = 115;
		btFurnasNovoB.TextAlign = ContentAlignment.MiddleRight;
		btFurnasNovoB.UseVisualStyleBackColor = true;
		btCEMIG_D.FlatStyle = FlatStyle.Flat;
		btCEMIG_D.Image = Resources.CEMIG_D;
		btCEMIG_D.Location = new Point(15, 86);
		btCEMIG_D.Name = "btCEMIG_D";
		btCEMIG_D.Size = new Size(110, 50);
		btCEMIG_D.TabIndex = 116;
		btCEMIG_D.TextAlign = ContentAlignment.MiddleRight;
		btCEMIG_D.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(374, 341);
		Controls.Add(btCEMIG_D);
		Controls.Add(btFurnasNovoB);
		Controls.Add(btFurnasAntigoC);
		Controls.Add(btEletronorteE);
		Controls.Add(LabelPainel);
		Controls.Add(btEletrosulA);
		Controls.Add(GroupBox_A_B_D);
		Controls.Add(btParar);
		Controls.Add(GroupBox_C);
		Controls.Add(GroupBox_E);
		Cursor = Cursors.Default;
		MaximizeBox = false;
		MaximumSize = new Size(390, 380);
		MinimizeBox = false;
		MinimumSize = new Size(390, 380);
		Name = "frmRelatorio_Fiacao_Excel";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Relatório de Fiação EXCEL";
		GroupBox_E.ResumeLayout(performLayout: false);
		GroupBox_E.PerformLayout();
		GroupBox_A_B_D.ResumeLayout(performLayout: false);
		GroupBox_A_B_D.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox_C.ResumeLayout(performLayout: false);
		GroupBox_C.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmRelatorio_Fiacao_Excel(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sTipoRel, int iPnSel, string sRev)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		MaxIFIUw3a = "";
		HjUIQYQ7FY = 0;
		nMoIPpcTVs = "";
		yolIc2W8o1 = new ColorDialog();
		Nq9IKMuSHW = "E";
		nwHIeaUAu6 = "";
		r5MI2xYsoo = 1;
		DyQI33GeCK = "";
		DsjInjsO6S = "";
		dSGI1og8EM = null;
		nMoIPpcTVs = Dicionario.BuscaNomeDoPainel(iPnSel);
		HyNIN6qecd = mFiacao;
		int num = Information.UBound(HyNIN6qecd);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(HyNIN6qecd[i].Tag, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Tag = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Circuito, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Circuito = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Jumper, "", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Jumper = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Terminal, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Terminal = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp1, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp1 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term1, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term1 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp2, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp2 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term2, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term2 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp3, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp3 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term3, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term3 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp4, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp4 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term4, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term4 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Cor12, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Cor12 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Secao12, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Secao12 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Pagina12, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Pagina12 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Cor34, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Cor34 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Secao34, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Secao34 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Pagina34, null, TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Pagina34 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Tag, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Tag = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Jumper, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Jumper = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Terminal, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Terminal = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp1, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp1 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term1, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term1 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp2, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp2 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term2, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term2 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp3, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp3 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term3, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term3 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Disp4, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Disp4 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Term4, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Term4 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Cor12, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Cor12 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Secao12, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Secao12 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Pagina12, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Pagina12 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Cor34, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Cor34 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Secao34, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Secao34 = "";
			}
			if (Operators.CompareString(HyNIN6qecd[i].Pagina34, "##B##", TextCompare: true) == 0)
			{
				HyNIN6qecd[i].Pagina34 = "";
			}
		}
		mUBONcOCa6();
		GroupBox_C.Location = new Point(GroupBox_A_B_D.Location.X, GroupBox_A_B_D.Location.Y);
		GroupBox_E.Location = new Point(GroupBox_A_B_D.Location.X, GroupBox_A_B_D.Location.Y);
		rbBitola.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]);
		rbCorBitola.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 834]);
		rbBitola.Visible = false;
		rbCorBitola.Visible = false;
		GroupBox1.Visible = false;
		MaxIFIUw3a = sTipoRel;
		HjUIQYQ7FY = iPnSel;
		DyQI33GeCK = sRev;
		string maxIFIUw3a = MaxIFIUw3a;
		if (Operators.CompareString(maxIFIUw3a, "DISP", TextCompare: true) != 0)
		{
			if (Operators.CompareString(maxIFIUw3a, "REGUAS", TextCompare: true) == 0)
			{
				Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Elétron"));
				LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 788], " : "), Dicionario.BuscaNomeDoPainel(iPnSel)));
			}
		}
		else
		{
			Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Elétron"));
			LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 518], " : "), Dicionario.BuscaNomeDoPainel(iPnSel)));
		}
		DeclaracoesGeral.Reguas RH = default;
		if (XDataGeral.LeXDataReguaH(ref RH))
		{
			GroupBox_E.Text = "";
			GroupBox_A_B_D.Text = "";
			GroupBox_C.Text = "";
			lbAnilha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1591]);
			lbSeparador.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1216]);
			lbDesc1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 805]);
			lbNumDesenho.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1158]);
			lbRev.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]);
			lbLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1151]);
			Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1151]);
			Label9.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1151]);
			lbPaginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]);
			tbLinhasPorPaginaNorte.Text = "60";
			lbImagem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1159]);
			rbDispositivos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]);
			rbTerminal.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 771]);
			tbCaminho.Text = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "EletrosulRelatorio.png";
			tbCaminho.BackColor = Color.White;
			if (Operators.CompareString(tbCaminho.Text, "", TextCompare: true) != 0 && !File.Exists(tbCaminho.Text))
			{
				tbCaminho.BackColor = Color.LightCoral;
			}
			ckOrigem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1510]);
			ckDestino.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1511]);
			ckOrigemDestino.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1510], "/"), DeclaracoesGeral.mMensagem[1, 1511]));
			ckOrigem.Checked = true;
			GroupBox_A_B_D.Visible = false;
			GroupBox_C.Visible = false;
			GroupBox_E.Visible = true;
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			tbRev.Text = DyQI33GeCK;
			btEletronorteE.Focus();
			_ = (string[])Relatorios_GeralDWG.CapturaOsTextStyle();
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
		}
	}

	private short DpMOF7joUL()
	{
		DialogResult dialogResult = yolIc2W8o1.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return yolIc2W8o1.Color.ColorIndex;
	}

	private void XBdOQ3jL5o(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void zUVOPY4tBF(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void w4sOcItVuB(object P_0, EventArgs P_1)
	{
		GroupBox_E.Visible = true;
		GroupBox_A_B_D.Visible = false;
		GroupBox_C.Visible = false;
		tbDesc1.Text = "";
		tbNumDesenho.Text = "";
		tbRev.Text = "";
		tbLinhasPorPaginaNorte.Text = "60";
		tbPaginaInicio.Text = "";
		string maxIFIUw3a = MaxIFIUw3a;
		if (Operators.CompareString(maxIFIUw3a, "DISP", TextCompare: true) != 0)
		{
			if (Operators.CompareString(maxIFIUw3a, "REGUAS", TextCompare: true) == 0)
			{
				Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Elétron"));
			}
		}
		else
		{
			Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Elétron"));
			FiacaoExcel.iLinhaInicialRelatorio = 1;
		}
	}

	private void Y0bOKfDBx3(object P_0, EventArgs P_1)
	{
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		Nq9IKMuSHW = "E";
		tbDesc1.Size = new Size(157, 20);
		tbNumDesenho.Size = new Size(157, 20);
		rbBitola.Visible = true;
		rbBitola.Checked = true;
		rbCorBitola.Visible = true;
		GroupBox1.Visible = true;
		GroupBox_A_B_D.Visible = true;
		GroupBox_C.Visible = false;
		GroupBox_E.Visible = false;
		lbImagem.Visible = true;
		tbCaminho.Visible = true;
		btSelecionaImagem.Visible = true;
		tbLinhasPorPaginaSul.Enabled = true;
		lbLinhas.Enabled = true;
		tbCaminho.Text = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "EletrosulRelatorio.png";
		if (!Caderno.ExisteFormato())
		{
			tbDesc1.Text = "";
		}
		else
		{
			TextBox textBox = tbDesc1;
			string sHandle = ((object)DeclaracoesGeral.blockFormatoID.Handle/*cast due to constrained. prefix*/).ToString();
			textBox.Text = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "SUBESTACAO");
		}
		tbDesc1.Text = nMoIPpcTVs;
		tbNumDesenho.Text = DeclaracoesGeral.Conf.Local;
		tbRev.Text = DyQI33GeCK;
		tbLinhasPorPaginaSul.Text = "60";
		ref string sPaginaInicio = ref nwHIeaUAu6;
		ref int iColuna = ref r5MI2xYsoo;
		int ProximaLinhaIndice = 2;
		RelatoriosFiacaoBornesExcelEletrosul.EncontraDadosFiacao(ref sPaginaInicio, ref iColuna, ref ProximaLinhaIndice);
		RelatoriosFiacaoBornesExcelEletrosul.EncontraProximaPagina(ref nwHIeaUAu6);
		int ProximaLinhaIndice2 = 3;
		RelatoriosFiacaoBornesExcelEletrosul.EncontraLinhaDoIndice(ref ProximaLinhaIndice2);
		tbPaginaInicio.Text = nwHIeaUAu6;
		string maxIFIUw3a = MaxIFIUw3a;
		if (Operators.CompareString(maxIFIUw3a, "DISP", TextCompare: true) != 0)
		{
			if (Operators.CompareString(maxIFIUw3a, "REGUAS", TextCompare: true) == 0)
			{
				DeclaracoesFiacao.ilinhaCEMIGD = ProximaLinhaIndice2;
				Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Eletrosul"));
			}
		}
		else
		{
			Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Eletrosul"));
			DeclaracoesFiacao.ilinhaCEMIGD = ProximaLinhaIndice2;
			FiacaoExcel.iLinhaInicialRelatorio = 1;
		}
	}

	private void r9XOejD7Zh(object P_0, EventArgs P_1)
	{
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		Nq9IKMuSHW = "F";
		tbDesc1.Size = new Size(269, 20);
		tbNumDesenho.Size = new Size(269, 20);
		rbBitola.Visible = false;
		rbCorBitola.Visible = false;
		GroupBox1.Visible = false;
		GroupBox_A_B_D.Visible = true;
		GroupBox_C.Visible = false;
		GroupBox_E.Visible = false;
		lbImagem.Visible = true;
		tbCaminho.Visible = true;
		btSelecionaImagem.Visible = true;
		tbLinhasPorPaginaSul.Enabled = true;
		lbLinhas.Enabled = true;
		tbCaminho.Text = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Furnas.png";
		tbCaminho.BackColor = Color.White;
		if (Operators.CompareString(tbCaminho.Text, "", TextCompare: true) != 0 && !File.Exists(tbCaminho.Text))
		{
			tbCaminho.BackColor = Color.LightCoral;
		}
		if (!Caderno.ExisteFormato())
		{
			tbDesc1.Text = "";
		}
		else
		{
			TextBox textBox = tbDesc1;
			string sHandle = ((object)DeclaracoesGeral.blockFormatoID.Handle/*cast due to constrained. prefix*/).ToString();
			textBox.Text = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "SUBESTACAO");
		}
		tbDesc1.Text = "";
		tbNumDesenho.Text = DeclaracoesGeral.Conf.Local;
		tbRev.Text = DyQI33GeCK;
		tbLinhasPorPaginaSul.Text = "60";
		ref string sPaginaInicio = ref nwHIeaUAu6;
		ref int iColuna = ref r5MI2xYsoo;
		int ProximaLinhaIndice = 2;
		RelatoriosFiacaoBornesExcelEletrosul.EncontraDadosFiacao(ref sPaginaInicio, ref iColuna, ref ProximaLinhaIndice);
		tbPaginaInicio.Text = nwHIeaUAu6;
		string maxIFIUw3a = MaxIFIUw3a;
		if (Operators.CompareString(maxIFIUw3a, "DISP", TextCompare: true) != 0)
		{
			if (Operators.CompareString(maxIFIUw3a, "REGUAS", TextCompare: true) == 0)
			{
				Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Furnas"));
			}
		}
		else
		{
			Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Furnas"));
			FiacaoExcel.iLinhaInicialRelatorio = 1;
		}
	}

	private void bIPO2WlqPG(object P_0, EventArgs P_1)
	{
		GroupBox_E.Visible = false;
		GroupBox_A_B_D.Visible = false;
		GroupBox_C.Visible = true;
		tbDesc1.Text = nMoIPpcTVs;
		tbNumDesenho.Text = "";
		tbRev.Text = "";
		tbLinhasPorPaginaFurnas.Text = "60";
		tbPaginaInicio.Text = "";
		string maxIFIUw3a = MaxIFIUw3a;
		if (Operators.CompareString(maxIFIUw3a, "DISP", TextCompare: true) != 0)
		{
			if (Operators.CompareString(maxIFIUw3a, "REGUAS", TextCompare: true) == 0)
			{
				Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Furnas"));
			}
		}
		else
		{
			Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - Furnas"));
			FiacaoExcel.iLinhaInicialRelatorio = 1;
		}
	}

	private void q48O3MhG1s(object P_0, EventArgs P_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptOpenFileOptions val = new PromptOpenFileOptions(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1160]));
		((PromptFileOptions)val).InitialDirectory = "C:\\";
		((PromptFileOptions)val).Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*";
		PromptFileNameResult fileNameForOpen = editor.GetFileNameForOpen(val);
		PromptStatus status = ((PromptResult)fileNameForOpen).Status;
		if ((int)status != -5002 && (int)status == 5100)
		{
			tbCaminho.Text = ((PromptResult)fileNameForOpen).StringResult;
			tbCaminho.BackColor = Color.White;
			if (Operators.CompareString(tbCaminho.Text, "", TextCompare: true) != 0 && !File.Exists(tbCaminho.Text))
			{
				tbCaminho.BackColor = Color.LightCoral;
			}
		}
	}

	private void rBIOn6hM9s(object P_0, EventArgs P_1)
	{
		string text = "";
		if (Operators.CompareString(Nq9IKMuSHW, "E", TextCompare: true) != 0)
		{
			if (Operators.CompareString(Nq9IKMuSHW, "F", TextCompare: true) != 0)
			{
				if (Operators.CompareString(Nq9IKMuSHW, "D", TextCompare: true) == 0)
				{
					text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Eletron4\\Modelos\\Modelo Fiação Furnas CEMIG-D.xls";
				}
			}
			else
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Eletron4\\Modelos\\Modelo Fiação Furnas.xls";
			}
		}
		else
		{
			text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Eletron4\\Modelos\\Modelo Fiação.xls";
		}
		if (!File.Exists(text))
		{
			Interaction.MsgBox("Modelo Não encontrado: \r\n" + text);
			return;
		}
		FiacaoExcel.iLinhaInicialRelatorio = 1;
		FiacaoExcel.mIndiceExcel = new FiacaoExcel.StructureIndiceRelatorio[1];
		ExcFuncoesExcel.FechaExcelOculto();
		ExcFuncoesExcel.AbreExcelExterno(text);
		Relatorios_FiacaoEXCEL_Furnas.EncontraDadosFiacao(ref nwHIeaUAu6, ref DeclaracoesFiacao.ilinhaCEMIGD, ref r5MI2xYsoo);
		tbPaginaInicio.Text = nwHIeaUAu6;
		if (Operators.CompareString(Nq9IKMuSHW, "E", TextCompare: true) == 0)
		{
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Workbook oBook = null;
			Worksheet oSheet = null;
			if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
			{
				Relatorios_FiacaoEXCEL_Sul.BuscaIndiceJaExistente(ref oExcelNew, ref dSGI1og8EM);
			}
		}
	}

	private void W00O1eKQJf(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		System.Windows.Forms.Application.DoEvents();
		btExportaEXCELELETROSUL.Enabled = true;
	}

	private void yXCOlnVBVF(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = false;
		btExportaEXCELELETROSUL.Enabled = false;
		nMoIPpcTVs = Dicionario.BuscaNomeDoPainel(HjUIQYQ7FY).ToUpper();
		AVJI8uP4uN.Desc1 = tbDesc1.Text;
		AVJI8uP4uN.NumDesenho = tbNumDesenho.Text;
		AVJI8uP4uN.sRev = tbRev.Text;
		AVJI8uP4uN.LinhasPorPagina = Conversions.ToInteger(tbLinhasPorPaginaSul.Text);
		AVJI8uP4uN.Prefixo = tbPaginaInicio.Text;
		AVJI8uP4uN.sCaminhoDesenho = tbCaminho.Text;
		checked
		{
			if (Operators.CompareString(Nq9IKMuSHW, "E", TextCompare: true) != 0)
			{
				if (Operators.CompareString(Nq9IKMuSHW, "F", TextCompare: true) != 0)
				{
					if (Operators.CompareString(Nq9IKMuSHW, "D", TextCompare: true) == 0)
					{
						Relatorios_FiacaoEXCEL_CEMIG.EncontraDadosFiacao(ref nwHIeaUAu6, ref DeclaracoesFiacao.ilinhaCEMIGD, ref r5MI2xYsoo);
						tbPaginaInicio.Text = nwHIeaUAu6;
						FiacaoExcel.iLinhaInicialRelatorio = DeclaracoesFiacao.ilinhaCEMIGD;
						DeclaracoesFiacao.structureRelFiacao[] hyNIN6qecd = HyNIN6qecd;
						string maxIFIUw3a = MaxIFIUw3a;
						ref string sPainel = ref nMoIPpcTVs;
						ConfRelelatorioExcel aVJI8uP4uN = AVJI8uP4uN;
						TextBox textBox;
						string sPaginaInicio = (textBox = tbPaginaInicio).Text;
						Relatorios_FiacaoEXCEL_CEMIG.CriaMatrizFiacaoDispositivos_Excel_CEMIG(hyNIN6qecd, maxIFIUw3a, ref sPainel, aVJI8uP4uN, ref sPaginaInicio);
						textBox.Text = sPaginaInicio;
						int num = 0;
						ExcFuncoesExcel.PosicoesExcel[] mPosicoes = new ExcFuncoesExcel.PosicoesExcel[1];
						ExcFuncoesExcel.ValoresExcel[] arySrc = new ExcFuncoesExcel.ValoresExcel[1];
						num = 1;
						arySrc = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc, new ExcFuncoesExcel.ValoresExcel[2]);
						arySrc[1].SNomeCampo = "#DESC1#";
						arySrc[1].SValor = tbDesc1.Text;
						num = 2;
						arySrc = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc, new ExcFuncoesExcel.ValoresExcel[3]);
						arySrc[2].SNomeCampo = "#EQUIPAMENTO#";
						if (!nMoIPpcTVs.Contains("PAINEL"))
						{
							arySrc[num].SValor = "PAINEL " + nMoIPpcTVs;
						}
						else
						{
							arySrc[num].SValor = nMoIPpcTVs;
						}
						num++;
						arySrc = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc, new ExcFuncoesExcel.ValoresExcel[num + 1]);
						arySrc[num].SNomeCampo = "#REV#";
						arySrc[num].SValor = tbRev.Text;
						num++;
						arySrc = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc, new ExcFuncoesExcel.ValoresExcel[num + 1]);
						arySrc[num].SNomeCampo = "#DESENHO#";
						arySrc[num].SValor = tbNumDesenho.Text;
						List<string> lCampos = new List<string> { "#FL#", "#EQUIPAMENTO#", "#DESC1#", "#DESC2#", "#DESC3#", "#DESENHO#", "#REV#" };
						ExcFuncoesExcel.BuscaTodosValorDoModelo("C:\\Program Files\\Eletron4\\Modelos\\Modelo Fiação Furnas CEMIG-D.xls", lCampos, ref mPosicoes);
						ExcFuncoesExcel.PreencheTodosValorDoModelo(mPosicoes, arySrc);
						Relatorios_FiacaoEXCEL_CEMIG.preencheIndiceInterligacaoExcel(tbRev.Text);
						int num2 = Information.UBound(mPosicoes);
						for (int i = 1; i <= num2; i++)
						{
							if (Operators.CompareString(mPosicoes[i].SSheet, "CAPA", TextCompare: true) == 0 && Operators.CompareString(mPosicoes[i].SNomeCampo, "#FL#", TextCompare: true) == 0)
							{
								ExcFuncoesExcel.PreencheUmValorNOExcel("CAPA", mPosicoes[i].SPosicao, "'1/" + FiacaoExcel.mIndiceExcel[Information.UBound(FiacaoExcel.mIndiceExcel)].sFolha);
							}
						}
					}
				}
				else
				{
					Relatorios_FiacaoEXCEL_Furnas.EncontraDadosFiacao(ref nwHIeaUAu6, ref DeclaracoesFiacao.ilinhaCEMIGD, ref r5MI2xYsoo);
					tbPaginaInicio.Text = nwHIeaUAu6;
					DeclaracoesFiacao.structureRelFiacao[] hyNIN6qecd2 = HyNIN6qecd;
					string maxIFIUw3a2 = MaxIFIUw3a;
					ref string sPainel2 = ref nMoIPpcTVs;
					ConfRelelatorioExcel aVJI8uP4uN2 = AVJI8uP4uN;
					TextBox textBox;
					string sPaginaInicio = (textBox = tbPaginaInicio).Text;
					Relatorios_FiacaoEXCEL_Furnas.CriaMatrizFiacaoDispositivos_Excel_Furnas(hyNIN6qecd2, maxIFIUw3a2, ref sPainel2, aVJI8uP4uN2, ref sPaginaInicio);
					textBox.Text = sPaginaInicio;
					int num3 = 0;
					ExcFuncoesExcel.PosicoesExcel[] mPosicoes2 = new ExcFuncoesExcel.PosicoesExcel[1];
					ExcFuncoesExcel.ValoresExcel[] arySrc2 = new ExcFuncoesExcel.ValoresExcel[1];
					num3 = 1;
					arySrc2 = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc2, new ExcFuncoesExcel.ValoresExcel[2]);
					arySrc2[1].SNomeCampo = "#DESC1#";
					arySrc2[1].SValor = tbDesc1.Text;
					num3 = 2;
					arySrc2 = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc2, new ExcFuncoesExcel.ValoresExcel[3]);
					arySrc2[2].SNomeCampo = "#EQUIPAMENTO#";
					if (!nMoIPpcTVs.Contains("PAINEL"))
					{
						arySrc2[num3].SValor = "PAINEL " + nMoIPpcTVs;
					}
					else
					{
						arySrc2[num3].SValor = nMoIPpcTVs;
					}
					num3++;
					arySrc2 = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc2, new ExcFuncoesExcel.ValoresExcel[num3 + 1]);
					arySrc2[num3].SNomeCampo = "#REV#";
					arySrc2[num3].SValor = tbRev.Text;
					num3++;
					arySrc2 = (ExcFuncoesExcel.ValoresExcel[])Utils.CopyArray(arySrc2, new ExcFuncoesExcel.ValoresExcel[num3 + 1]);
					arySrc2[num3].SNomeCampo = "#DESENHO#";
					arySrc2[num3].SValor = tbNumDesenho.Text;
					List<string> lCampos2 = new List<string> { "#FL#", "#EQUIPAMENTO#", "#DESC1#", "#DESC2#", "#DESC3#", "#DESENHO#", "#REV#" };
					ExcFuncoesExcel.BuscaTodosValorDoModelo("C:\\Program Files\\Eletron4\\Modelos\\Modelo Fiação Furnas.xls", lCampos2, ref mPosicoes2);
					ExcFuncoesExcel.PreencheTodosValorDoModelo(mPosicoes2, arySrc2);
					Relatorios_FiacaoEXCEL_Furnas.preencheIndiceInterligacaoExcel(tbRev.Text);
					Relatorios_FiacaoEXCEL_Furnas.preencheRelatorioRevCapaExcel(tbRev.Text);
					int num4 = Information.UBound(mPosicoes2);
					for (int j = 1; j <= num4; j++)
					{
						if (Operators.CompareString(mPosicoes2[j].SSheet, "CAPA", TextCompare: true) == 0 && Operators.CompareString(mPosicoes2[j].SNomeCampo, "#FL#", TextCompare: true) == 0)
						{
							ExcFuncoesExcel.PreencheUmValorNOExcel("CAPA", mPosicoes2[j].SPosicao, "'1/" + FiacaoExcel.mIndiceExcel[Information.UBound(FiacaoExcel.mIndiceExcel)].sFolha);
						}
					}
				}
			}
			else
			{
				tbPaginaInicio.Text = nwHIeaUAu6;
				if (Information.IsNothing(dSGI1og8EM))
				{
					Microsoft.Office.Interop.Excel.Application oExcelNew = null;
					Workbook oBook = null;
					Worksheet oSheet = null;
					if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
					{
						RelatoriosFiacaoBornesExcelEletrosul.LeDadosDoIndiceDoIndiceEletrosul(ref dSGI1og8EM);
					}
				}
				if (Operators.CompareString(MaxIFIUw3a, "DISP", TextCompare: true) == 0)
				{
					DeclaracoesFiacao.structureRelFiacao[] hyNIN6qecd3 = HyNIN6qecd;
					string maxIFIUw3a3 = MaxIFIUw3a;
					ref string sPainel3 = ref nMoIPpcTVs;
					ConfRelelatorioExcel aVJI8uP4uN3 = AVJI8uP4uN;
					TextBox textBox;
					string sPaginaInicio = (textBox = tbPaginaInicio).Text;
					RelatoriosFiacaoDispositivosExcelEletrosul.CriaMatrizFiacaoDispositivos_Excel_Sul(hyNIN6qecd3, maxIFIUw3a3, ref sPainel3, aVJI8uP4uN3, ref sPaginaInicio, ref dSGI1og8EM, rbCorBitola.Checked);
					textBox.Text = sPaginaInicio;
				}
				if (Operators.CompareString(MaxIFIUw3a, "REGUAS", TextCompare: true) == 0)
				{
					DeclaracoesFiacao.structureRelFiacao[] hyNIN6qecd4 = HyNIN6qecd;
					string maxIFIUw3a4 = MaxIFIUw3a;
					ref string sPainel4 = ref nMoIPpcTVs;
					ConfRelelatorioExcel aVJI8uP4uN4 = AVJI8uP4uN;
					TextBox textBox;
					string sPaginaInicio = (textBox = tbPaginaInicio).Text;
					RelatoriosFiacaoBornesExcelEletrosul.CriaMatrizFiacaoBornes_Excel_Sul(hyNIN6qecd4, maxIFIUw3a4, ref sPainel4, aVJI8uP4uN4, ref sPaginaInicio, ref dSGI1og8EM, rbCorBitola.Checked);
					textBox.Text = sPaginaInicio;
				}
				if (!DeclaracoesGeral.bPararRelatorio)
				{
					Relatorios_ExcelComum_EletroSul.preencheIndiceComumExcel(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1667]), nMoIPpcTVs, tbDesc1.Text, "", "", tbRev.Text, "Num. Des. " + AVJI8uP4uN.NumDesenho, "2");
					Relatorios_ExcelComum_EletroSul.preencheIndiceInterligacaoExcel(ref dSGI1og8EM, nMoIPpcTVs, tbRev.Text, AVJI8uP4uN.NumDesenho, Conversions.ToString(Value: true), ref r5MI2xYsoo);
				}
				if (!DeclaracoesGeral.bPararRelatorio)
				{
					Relatorios_ExcelComum_EletroSul.preencheIndiceComumExcel("CAPA", nMoIPpcTVs, tbDesc1.Text, "", "", tbRev.Text, tbNumDesenho.Text, "'1/" + dSGI1og8EM[Information.UBound(dSGI1og8EM)].sFolha);
				}
				if (Operators.CompareString(DsjInjsO6S, "", TextCompare: true) == 0)
				{
					DsjInjsO6S = ExcFuncoesExcel.BuscaValorNaPlanilhaExcel("C:\\Program Files\\Eletron4\\Modelos\\Modelo Fiação.xls", "CAPA", "#FL#", 60, 64);
				}
				ExcFuncoesExcel.PreencheUmValorNOExcel("CAPA", DsjInjsO6S, "'1/" + dSGI1og8EM[Information.UBound(dSGI1og8EM)].sFolha);
			}
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
			btExportaEXCELELETROSUL.Enabled = true;
		}
	}

	private void XgPO5V7gqx(object P_0, EventArgs P_1)
	{
		btExportaExcelEletronorte.Enabled = false;
		if (Operators.CompareString(MaxIFIUw3a, "DISP", TextCompare: true) == 0)
		{
			Relatorios_FiacaoExcelEletronorte.CriaMatrizFiacao_Excel(HyNIN6qecd, MaxIFIUw3a, nMoIPpcTVs, Conversions.ToInteger(tbLinhasPorPaginaNorte.Text));
		}
		if (Operators.CompareString(MaxIFIUw3a, "REGUAS", TextCompare: true) == 0)
		{
			Relatorios_FiacaoExcelEletronorte.CriaMatrizFiacaoBorne_Excel(HyNIN6qecd, MaxIFIUw3a, nMoIPpcTVs, Conversions.ToInteger(tbLinhasPorPaginaNorte.Text));
		}
		btExportaExcelEletronorte.Enabled = true;
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
	}

	private void eaFO0g1Qvn(object P_0, EventArgs P_1)
	{
		btExportaExcelEletronorte.Enabled = false;
		int iTipoAnilha = 1;
		if (ckOrigem.Checked)
		{
			iTipoAnilha = 1;
		}
		if (ckDestino.Checked)
		{
			iTipoAnilha = 2;
		}
		if (ckOrigemDestino.Checked)
		{
			iTipoAnilha = 3;
		}
		if ((Operators.CompareString(MaxIFIUw3a, "DISP", TextCompare: true) == 0) | (Operators.CompareString(MaxIFIUw3a, "REGUAS", TextCompare: true) == 0))
		{
			Relatorios_FiacaoExcelEletronorte.CriaMatrizFiacaoFurnas_Excel(HyNIN6qecd, MaxIFIUw3a, nMoIPpcTVs, Conversions.ToInteger(tbLinhasPorPaginaFurnas.Text), iTipoAnilha, tbDisp.Text, tbSeparador.Text);
		}
		btExportaExcelEletronorte.Enabled = true;
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
	}

	private void FM9ORhX6As(object P_0, EventArgs P_1)
	{
		rbDispositivos.Enabled = false;
		tbDisp.Enabled = false;
		if (ckOrigemDestino.Checked)
		{
			rbDispositivos.Enabled = true;
			tbDisp.Enabled = true;
		}
	}

	private void Vf5OmCXoMm(object P_0, EventArgs P_1)
	{
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		Nq9IKMuSHW = "D";
		tbDesc1.Size = new Size(269, 20);
		tbNumDesenho.Size = new Size(269, 20);
		rbBitola.Visible = false;
		rbCorBitola.Visible = false;
		GroupBox1.Visible = false;
		GroupBox_E.Visible = false;
		GroupBox_A_B_D.Visible = true;
		GroupBox_C.Visible = false;
		tbCaminho.Text = "";
		lbImagem.Visible = false;
		tbCaminho.Visible = false;
		btSelecionaImagem.Visible = false;
		tbLinhasPorPaginaSul.Enabled = false;
		lbLinhas.Enabled = false;
		if (!Caderno.ExisteFormato())
		{
			tbDesc1.Text = "";
		}
		else
		{
			TextBox textBox = tbDesc1;
			string sHandle = ((object)DeclaracoesGeral.blockFormatoID.Handle/*cast due to constrained. prefix*/).ToString();
			textBox.Text = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "SUBESTACAO");
		}
		tbDesc1.Text = "";
		tbNumDesenho.Text = DeclaracoesGeral.Conf.Local;
		tbRev.Text = DyQI33GeCK;
		tbLinhasPorPaginaSul.Text = "60";
		ref string sPaginaInicio = ref nwHIeaUAu6;
		ref int iColuna = ref r5MI2xYsoo;
		int ProximaLinhaIndice = 2;
		RelatoriosFiacaoBornesExcelEletrosul.EncontraDadosFiacao(ref sPaginaInicio, ref iColuna, ref ProximaLinhaIndice);
		tbPaginaInicio.Text = nwHIeaUAu6;
		string maxIFIUw3a = MaxIFIUw3a;
		if (Operators.CompareString(maxIFIUw3a, "DISP", TextCompare: true) != 0)
		{
			if (Operators.CompareString(maxIFIUw3a, "REGUAS", TextCompare: true) == 0)
			{
				Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - CEMIG"));
			}
		}
		else
		{
			Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1251], " - CEMIG"));
			FiacaoExcel.iLinhaInicialRelatorio = 1;
		}
	}
}
