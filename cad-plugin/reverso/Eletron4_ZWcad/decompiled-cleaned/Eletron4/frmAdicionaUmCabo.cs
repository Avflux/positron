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
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmAdicionaUmCabo : Form
{
	private IContainer ASUTrlOCEw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog LJAT9IHD6r;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip Y7jTzrpZmb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("gbTrio")]
	private GroupBox VAsJW0Pecl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbT1Var")]
	private TextBox Io8JpMjL5B;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbT3Var")]
	[CompilerGenerated]
	private TextBox R1aJTwQLor;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbT2Var")]
	private TextBox Vl4JJkaFpR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("gbPar")]
	private GroupBox iyNJhfw3bb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbP1Var")]
	[CompilerGenerated]
	private TextBox xNBJoCBhp9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbP2Var")]
	private TextBox F1vJGjfRU5;

	[AccessedThroughProperty("gbBL")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox GRrJHNO4uC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbBLVar")]
	private TextBox AKcJkQo769;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionaCabo")]
	[CompilerGenerated]
	private Button qlaJdGIYs0;

	[CompilerGenerated]
	[AccessedThroughProperty("PNCabos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Panel gd6Jfy9b5g;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbOrigem")]
	[CompilerGenerated]
	private ComboBox uGJJDNeZGm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbDestino")]
	private ComboBox dWIJvpepBN;

	[AccessedThroughProperty("tbCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox sW4J6TjLnk;

	[AccessedThroughProperty("LbCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label s3YJtwKO9k;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbOrigem")]
	[CompilerGenerated]
	private Label zlEJjNt7e0;

	[CompilerGenerated]
	[AccessedThroughProperty("tbVeia")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox FUVJLjso5T;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbVeia")]
	private Label tPGJwEaNPB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbSecao")]
	private TextBox NsOJxwLGsS;

	[AccessedThroughProperty("lbSecao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label mxhJbosrwH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCabosED")]
	private TextBox L5mJMyv9Ok;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbBlinED")]
	private ComboBox CwOJOkCmX8;

	[AccessedThroughProperty("tbFuncao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox dwjJIOMMCj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("cbAterrarED")]
	private ComboBox yRXJ7gUbTW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbComprimento")]
	private TextBox Ja6Jqalifx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbTrajeto")]
	private TextBox Tc5JaPaAuD;

	[AccessedThroughProperty("_6lbCabosED")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label kufJ8KQmSq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_5lbBlinED")]
	[CompilerGenerated]
	private Label cPKJNnjOXc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_9lbComprimento")]
	private Label Wj0JFiiiHl;

	[AccessedThroughProperty("_10lbTrajeto")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label DRdJQ9BZSh;

	[CompilerGenerated]
	[AccessedThroughProperty("_8lbFuncao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label KyrJPwcCW1;

	[AccessedThroughProperty("_7lbAterrarED")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label xS1Jc68Cgt;

	private bool bWAJK1tODk;

	private ClsCabos.StructureCabo[] s9HJewcMLL;

	public List<string> lTodosCabos;

	private List<int> qlqJ2ndMTx;

	private bool oLHJ3GsXqC;

	internal virtual GroupBox gbTrio
	{
		[CompilerGenerated]
		get
		{
			return VAsJW0Pecl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VAsJW0Pecl = value;
		}
	}

	internal virtual TextBox tbT1Var
	{
		[CompilerGenerated]
		get
		{
			return Io8JpMjL5B;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Io8JpMjL5B = value;
		}
	}

	internal virtual TextBox tbT3Var
	{
		[CompilerGenerated]
		get
		{
			return R1aJTwQLor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			R1aJTwQLor = value;
		}
	}

	internal virtual TextBox tbT2Var
	{
		[CompilerGenerated]
		get
		{
			return Vl4JJkaFpR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Vl4JJkaFpR = value;
		}
	}

	internal virtual GroupBox gbPar
	{
		[CompilerGenerated]
		get
		{
			return iyNJhfw3bb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iyNJhfw3bb = value;
		}
	}

	internal virtual TextBox tbP1Var
	{
		[CompilerGenerated]
		get
		{
			return xNBJoCBhp9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xNBJoCBhp9 = value;
		}
	}

	internal virtual TextBox tbP2Var
	{
		[CompilerGenerated]
		get
		{
			return F1vJGjfRU5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			F1vJGjfRU5 = value;
		}
	}

	internal virtual GroupBox gbBL
	{
		[CompilerGenerated]
		get
		{
			return GRrJHNO4uC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GRrJHNO4uC = value;
		}
	}

	internal virtual TextBox tbBLVar
	{
		[CompilerGenerated]
		get
		{
			return AKcJkQo769;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AKcJkQo769 = value;
		}
	}

	internal virtual Button btAdicionaCabo
	{
		[CompilerGenerated]
		get
		{
			return qlaJdGIYs0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = d4LTX8chNb;
			Button button = qlaJdGIYs0;
			if (button != null)
			{
				button.Click -= value2;
			}
			qlaJdGIYs0 = value;
			button = qlaJdGIYs0;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Panel PNCabos
	{
		[CompilerGenerated]
		get
		{
			return gd6Jfy9b5g;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gd6Jfy9b5g = value;
		}
	}

	internal virtual ComboBox cbOrigem
	{
		[CompilerGenerated]
		get
		{
			return uGJJDNeZGm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = cHvTUXcDlu;
			EventHandler value3 = SVETyRTQpC;
			EventHandler value4 = F0qTgTQD2S;
			ComboBox comboBox = uGJJDNeZGm;
			if (comboBox != null)
			{
				comboBox.MouseUp -= value2;
				comboBox.SelectedIndexChanged -= value3;
				comboBox.SelectedValueChanged -= value4;
			}
			uGJJDNeZGm = value;
			comboBox = uGJJDNeZGm;
			if (comboBox != null)
			{
				comboBox.MouseUp += value2;
				comboBox.SelectedIndexChanged += value3;
				comboBox.SelectedValueChanged += value4;
			}
		}
	}

	internal virtual ComboBox cbDestino
	{
		[CompilerGenerated]
		get
		{
			return dWIJvpepBN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = iUJTAP6k8H;
			EventHandler value3 = EpxTsr3AYt;
			ComboBox comboBox = dWIJvpepBN;
			if (comboBox != null)
			{
				comboBox.MouseUp -= value2;
				comboBox.SelectedValueChanged -= value3;
			}
			dWIJvpepBN = value;
			comboBox = dWIJvpepBN;
			if (comboBox != null)
			{
				comboBox.MouseUp += value2;
				comboBox.SelectedValueChanged += value3;
			}
		}
	}

	internal virtual TextBox tbCabo
	{
		[CompilerGenerated]
		get
		{
			return sW4J6TjLnk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = dQYTmqxHvq;
			EventHandler value3 = PO9TBoBLoS;
			TextBox textBox = sW4J6TjLnk;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.TextChanged -= value3;
			}
			sW4J6TjLnk = value;
			textBox = sW4J6TjLnk;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.TextChanged += value3;
			}
		}
	}

	internal virtual Label LbCabo
	{
		[CompilerGenerated]
		get
		{
			return s3YJtwKO9k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s3YJtwKO9k = value;
		}
	}

	internal virtual Label lbOrigem
	{
		[CompilerGenerated]
		get
		{
			return zlEJjNt7e0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zlEJjNt7e0 = value;
		}
	}

	internal virtual TextBox tbVeia
	{
		[CompilerGenerated]
		get
		{
			return FUVJLjso5T;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = cGdTVnt0iC;
			EventHandler value3 = YNmTuVE6Ed;
			TextBox textBox = FUVJLjso5T;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.TextChanged -= value3;
			}
			FUVJLjso5T = value;
			textBox = FUVJLjso5T;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.TextChanged += value3;
			}
		}
	}

	internal virtual Label lbVeia
	{
		[CompilerGenerated]
		get
		{
			return tPGJwEaNPB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tPGJwEaNPB = value;
		}
	}

	internal virtual TextBox tbSecao
	{
		[CompilerGenerated]
		get
		{
			return NsOJxwLGsS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XdUTEXKmUi;
			TextBox textBox = NsOJxwLGsS;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			NsOJxwLGsS = value;
			textBox = NsOJxwLGsS;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	internal virtual Label lbSecao
	{
		[CompilerGenerated]
		get
		{
			return mxhJbosrwH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mxhJbosrwH = value;
		}
	}

	internal virtual TextBox tbCabosED
	{
		[CompilerGenerated]
		get
		{
			return L5mJMyv9Ok;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = J0aTSf5oFi;
			TextBox textBox = L5mJMyv9Ok;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			L5mJMyv9Ok = value;
			textBox = L5mJMyv9Ok;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	internal virtual ComboBox cbBlinED
	{
		[CompilerGenerated]
		get
		{
			return CwOJOkCmX8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OkITZPnthP;
			EventHandler value3 = aTeTiwegHT;
			ComboBox comboBox = CwOJOkCmX8;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
				comboBox.SelectedValueChanged -= value3;
			}
			CwOJOkCmX8 = value;
			comboBox = CwOJOkCmX8;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
				comboBox.SelectedValueChanged += value3;
			}
		}
	}

	internal virtual TextBox tbFuncao
	{
		[CompilerGenerated]
		get
		{
			return dwjJIOMMCj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dwjJIOMMCj = value;
		}
	}

	internal virtual ComboBox cbAterrarED
	{
		[CompilerGenerated]
		get
		{
			return yRXJ7gUbTW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = L0qT4JT3J3;
			EventHandler value3 = t6DTCVHT60;
			ComboBox comboBox = yRXJ7gUbTW;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged -= value2;
				comboBox.SelectedIndexChanged -= value3;
			}
			yRXJ7gUbTW = value;
			comboBox = yRXJ7gUbTW;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged += value2;
				comboBox.SelectedIndexChanged += value3;
			}
		}
	}

	internal virtual TextBox tbComprimento
	{
		[CompilerGenerated]
		get
		{
			return Ja6Jqalifx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = UMdTYL86h5;
			TextBox textBox = Ja6Jqalifx;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			Ja6Jqalifx = value;
			textBox = Ja6Jqalifx;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbTrajeto
	{
		[CompilerGenerated]
		get
		{
			return Tc5JaPaAuD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Tc5JaPaAuD = value;
		}
	}

	internal virtual Label _6lbCabosED
	{
		[CompilerGenerated]
		get
		{
			return kufJ8KQmSq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kufJ8KQmSq = value;
		}
	}

	internal virtual Label _5lbBlinED
	{
		[CompilerGenerated]
		get
		{
			return cPKJNnjOXc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cPKJNnjOXc = value;
		}
	}

	internal virtual Label _9lbComprimento
	{
		[CompilerGenerated]
		get
		{
			return Wj0JFiiiHl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Wj0JFiiiHl = value;
		}
	}

	internal virtual Label _10lbTrajeto
	{
		[CompilerGenerated]
		get
		{
			return DRdJQ9BZSh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DRdJQ9BZSh = value;
		}
	}

	internal virtual Label _8lbFuncao
	{
		[CompilerGenerated]
		get
		{
			return KyrJPwcCW1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KyrJPwcCW1 = value;
		}
	}

	internal virtual Label _7lbAterrarED
	{
		[CompilerGenerated]
		get
		{
			return xS1Jc68Cgt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xS1Jc68Cgt = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && ASUTrlOCEw != null)
			{
				ASUTrlOCEw.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void YNgT0vgQsg()
	{
		ASUTrlOCEw = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(ASUTrlOCEw));
		gbTrio = new GroupBox();
		tbT1Var = new TextBox();
		tbT3Var = new TextBox();
		tbT2Var = new TextBox();
		gbPar = new GroupBox();
		tbP1Var = new TextBox();
		tbP2Var = new TextBox();
		gbBL = new GroupBox();
		tbBLVar = new TextBox();
		btAdicionaCabo = new Button();
		_8lbFuncao = new Label();
		_7lbAterrarED = new Label();
		_6lbCabosED = new Label();
		_5lbBlinED = new Label();
		_9lbComprimento = new Label();
		_10lbTrajeto = new Label();
		cbBlinED = new ComboBox();
		tbCabosED = new TextBox();
		tbTrajeto = new TextBox();
		tbFuncao = new TextBox();
		tbComprimento = new TextBox();
		cbAterrarED = new ComboBox();
		PNCabos = new Panel();
		cbOrigem = new ComboBox();
		cbDestino = new ComboBox();
		tbCabo = new TextBox();
		LbCabo = new Label();
		lbOrigem = new Label();
		tbVeia = new TextBox();
		lbVeia = new Label();
		tbSecao = new TextBox();
		lbSecao = new Label();
		gbTrio.SuspendLayout();
		gbPar.SuspendLayout();
		gbBL.SuspendLayout();
		PNCabos.SuspendLayout();
		SuspendLayout();
		gbTrio.Controls.Add(tbT1Var);
		gbTrio.Controls.Add(tbT3Var);
		gbTrio.Controls.Add(tbT2Var);
		gbTrio.Location = new Point(523, 62);
		gbTrio.Name = "gbTrio";
		gbTrio.Size = new Size(67, 105);
		gbTrio.TabIndex = 12;
		gbTrio.TabStop = false;
		gbTrio.Text = "BL";
		tbT1Var.Location = new Point(10, 19);
		tbT1Var.Name = "tbT1Var";
		tbT1Var.Size = new Size(50, 20);
		tbT1Var.TabIndex = 0;
		tbT3Var.Location = new Point(10, 71);
		tbT3Var.Name = "tbT3Var";
		tbT3Var.Size = new Size(50, 20);
		tbT3Var.TabIndex = 2;
		tbT2Var.Location = new Point(10, 45);
		tbT2Var.Name = "tbT2Var";
		tbT2Var.Size = new Size(50, 20);
		tbT2Var.TabIndex = 1;
		gbPar.Controls.Add(tbP1Var);
		gbPar.Controls.Add(tbP2Var);
		gbPar.Location = new Point(522, 62);
		gbPar.Name = "gbPar";
		gbPar.Size = new Size(67, 78);
		gbPar.TabIndex = 11;
		gbPar.TabStop = false;
		gbPar.Text = "BL";
		tbP1Var.Location = new Point(10, 19);
		tbP1Var.Name = "tbP1Var";
		tbP1Var.Size = new Size(50, 20);
		tbP1Var.TabIndex = 1;
		tbP2Var.Location = new Point(10, 45);
		tbP2Var.Name = "tbP2Var";
		tbP2Var.Size = new Size(50, 20);
		tbP2Var.TabIndex = 4;
		gbBL.Controls.Add(tbBLVar);
		gbBL.Location = new Point(522, 13);
		gbBL.Name = "gbBL";
		gbBL.Size = new Size(67, 49);
		gbBL.TabIndex = 11;
		gbBL.TabStop = false;
		gbBL.Text = "BL";
		tbBLVar.Location = new Point(10, 19);
		tbBLVar.Name = "tbBLVar";
		tbBLVar.Size = new Size(50, 20);
		tbBLVar.TabIndex = 0;
		btAdicionaCabo.Enabled = false;
		btAdicionaCabo.FlatStyle = FlatStyle.Flat;
		btAdicionaCabo.ForeColor = SystemColors.Control;
		btAdicionaCabo.Image = Resources.Adiciona_32;
		btAdicionaCabo.Location = new Point(475, 118);
		btAdicionaCabo.Name = "btAdicionaCabo";
		btAdicionaCabo.Size = new Size(40, 40);
		btAdicionaCabo.TabIndex = 184;
		btAdicionaCabo.UseVisualStyleBackColor = true;
		_8lbFuncao.BorderStyle = BorderStyle.Fixed3D;
		_8lbFuncao.Location = new Point(190, 62);
		_8lbFuncao.Name = "_8lbFuncao";
		_8lbFuncao.Size = new Size(315, 20);
		_8lbFuncao.TabIndex = 201;
		_8lbFuncao.Text = "Função";
		_8lbFuncao.TextAlign = ContentAlignment.MiddleCenter;
		_7lbAterrarED.BorderStyle = BorderStyle.Fixed3D;
		_7lbAterrarED.Location = new Point(126, 62);
		_7lbAterrarED.Name = "_7lbAterrarED";
		_7lbAterrarED.Size = new Size(58, 20);
		_7lbAterrarED.TabIndex = 200;
		_7lbAterrarED.Text = "Aterrar";
		_7lbAterrarED.TextAlign = ContentAlignment.MiddleCenter;
		_6lbCabosED.BorderStyle = BorderStyle.Fixed3D;
		_6lbCabosED.Location = new Point(80, 62);
		_6lbCabosED.Name = "_6lbCabosED";
		_6lbCabosED.Size = new Size(40, 20);
		_6lbCabosED.TabIndex = 196;
		_6lbCabosED.Text = "Cabos";
		_6lbCabosED.TextAlign = ContentAlignment.MiddleCenter;
		_5lbBlinED.BorderStyle = BorderStyle.Fixed3D;
		_5lbBlinED.Location = new Point(14, 62);
		_5lbBlinED.Name = "_5lbBlinED";
		_5lbBlinED.Size = new Size(60, 20);
		_5lbBlinED.TabIndex = 197;
		_5lbBlinED.Text = "Blindagem";
		_5lbBlinED.TextAlign = ContentAlignment.MiddleCenter;
		_9lbComprimento.BorderStyle = BorderStyle.Fixed3D;
		_9lbComprimento.Location = new Point(14, 113);
		_9lbComprimento.Name = "_9lbComprimento";
		_9lbComprimento.Size = new Size(82, 20);
		_9lbComprimento.TabIndex = 198;
		_9lbComprimento.Text = "Comprimento";
		_9lbComprimento.TextAlign = ContentAlignment.MiddleCenter;
		_10lbTrajeto.BorderStyle = BorderStyle.Fixed3D;
		_10lbTrajeto.Location = new Point(102, 113);
		_10lbTrajeto.Name = "_10lbTrajeto";
		_10lbTrajeto.Size = new Size(364, 20);
		_10lbTrajeto.TabIndex = 199;
		_10lbTrajeto.Text = "Trajeto";
		_10lbTrajeto.TextAlign = ContentAlignment.MiddleCenter;
		cbBlinED.FormattingEnabled = true;
		cbBlinED.Location = new Point(14, 84);
		cbBlinED.Name = "cbBlinED";
		cbBlinED.Size = new Size(60, 21);
		cbBlinED.TabIndex = 5;
		tbCabosED.Location = new Point(82, 85);
		tbCabosED.Name = "tbCabosED";
		tbCabosED.Size = new Size(40, 20);
		tbCabosED.TabIndex = 6;
		tbTrajeto.Location = new Point(102, 137);
		tbTrajeto.Name = "tbTrajeto";
		tbTrajeto.Size = new Size(364, 20);
		tbTrajeto.TabIndex = 10;
		tbFuncao.Location = new Point(190, 85);
		tbFuncao.Name = "tbFuncao";
		tbFuncao.Size = new Size(315, 20);
		tbFuncao.TabIndex = 8;
		tbComprimento.Location = new Point(14, 137);
		tbComprimento.Name = "tbComprimento";
		tbComprimento.Size = new Size(82, 20);
		tbComprimento.TabIndex = 9;
		cbAterrarED.FormattingEnabled = true;
		cbAterrarED.Location = new Point(126, 84);
		cbAterrarED.Name = "cbAterrarED";
		cbAterrarED.Size = new Size(58, 21);
		cbAterrarED.TabIndex = 7;
		PNCabos.Controls.Add(_8lbFuncao);
		PNCabos.Controls.Add(btAdicionaCabo);
		PNCabos.Controls.Add(cbOrigem);
		PNCabos.Controls.Add(gbTrio);
		PNCabos.Controls.Add(_7lbAterrarED);
		PNCabos.Controls.Add(gbPar);
		PNCabos.Controls.Add(cbDestino);
		PNCabos.Controls.Add(gbBL);
		PNCabos.Controls.Add(_6lbCabosED);
		PNCabos.Controls.Add(tbCabo);
		PNCabos.Controls.Add(_5lbBlinED);
		PNCabos.Controls.Add(_9lbComprimento);
		PNCabos.Controls.Add(LbCabo);
		PNCabos.Controls.Add(_10lbTrajeto);
		PNCabos.Controls.Add(lbOrigem);
		PNCabos.Controls.Add(cbBlinED);
		PNCabos.Controls.Add(tbVeia);
		PNCabos.Controls.Add(tbCabosED);
		PNCabos.Controls.Add(lbVeia);
		PNCabos.Controls.Add(tbTrajeto);
		PNCabos.Controls.Add(tbSecao);
		PNCabos.Controls.Add(tbFuncao);
		PNCabos.Controls.Add(lbSecao);
		PNCabos.Controls.Add(tbComprimento);
		PNCabos.Controls.Add(cbAterrarED);
		PNCabos.Location = new Point(7, 12);
		PNCabos.Name = "PNCabos";
		PNCabos.Size = new Size(600, 174);
		PNCabos.TabIndex = 197;
		cbOrigem.FormattingEnabled = true;
		cbOrigem.Location = new Point(14, 36);
		cbOrigem.Name = "cbOrigem";
		cbOrigem.Size = new Size(130, 21);
		cbOrigem.TabIndex = 0;
		cbDestino.FormattingEnabled = true;
		cbDestino.Location = new Point(150, 36);
		cbDestino.Name = "cbDestino";
		cbDestino.Size = new Size(130, 21);
		cbDestino.TabIndex = 1;
		tbCabo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCabo.Location = new Point(286, 36);
		tbCabo.Name = "tbCabo";
		tbCabo.Size = new Size(100, 20);
		tbCabo.TabIndex = 2;
		LbCabo.BorderStyle = BorderStyle.Fixed3D;
		LbCabo.Location = new Point(286, 13);
		LbCabo.Name = "LbCabo";
		LbCabo.Size = new Size(100, 20);
		LbCabo.TabIndex = 168;
		LbCabo.Text = "lbCabo";
		LbCabo.TextAlign = ContentAlignment.MiddleCenter;
		lbOrigem.BorderStyle = BorderStyle.Fixed3D;
		lbOrigem.Location = new Point(14, 13);
		lbOrigem.Name = "lbOrigem";
		lbOrigem.Size = new Size(266, 20);
		lbOrigem.TabIndex = 169;
		lbOrigem.Text = "lbOrigem";
		lbOrigem.TextAlign = ContentAlignment.MiddleCenter;
		tbVeia.CharacterCasing = CharacterCasing.Upper;
		tbVeia.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbVeia.Location = new Point(392, 36);
		tbVeia.Name = "tbVeia";
		tbVeia.Size = new Size(44, 20);
		tbVeia.TabIndex = 3;
		lbVeia.BorderStyle = BorderStyle.Fixed3D;
		lbVeia.Location = new Point(392, 13);
		lbVeia.Name = "lbVeia";
		lbVeia.Size = new Size(44, 20);
		lbVeia.TabIndex = 172;
		lbVeia.Text = "lbVeia";
		lbVeia.TextAlign = ContentAlignment.MiddleCenter;
		tbSecao.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSecao.Location = new Point(442, 36);
		tbSecao.Name = "tbSecao";
		tbSecao.Size = new Size(63, 20);
		tbSecao.TabIndex = 4;
		lbSecao.BorderStyle = BorderStyle.Fixed3D;
		lbSecao.Location = new Point(442, 13);
		lbSecao.Name = "lbSecao";
		lbSecao.Size = new Size(63, 20);
		lbSecao.TabIndex = 174;
		lbSecao.Text = "lbSeção";
		lbSecao.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(614, 196);
		Controls.Add(PNCabos);
		ImeMode = ImeMode.On;
		MaximizeBox = false;
		MaximumSize = new Size(630, 235);
		MinimizeBox = false;
		MinimumSize = new Size(630, 235);
		Name = "frmAdicionaUmCabo";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Adicionar Cabos";
		gbTrio.ResumeLayout(performLayout: false);
		gbTrio.PerformLayout();
		gbPar.ResumeLayout(performLayout: false);
		gbPar.PerformLayout();
		gbBL.ResumeLayout(performLayout: false);
		gbBL.PerformLayout();
		PNCabos.ResumeLayout(performLayout: false);
		PNCabos.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return LJAT9IHD6r;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		LJAT9IHD6r = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return Y7jTzrpZmb;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		Y7jTzrpZmb = WithEventsValue;
	}

	public frmAdicionaUmCabo(bool bFecha = false, string sPN1 = "", string sPN2 = "")
	{
		bWAJK1tODk = false;
		qlqJ2ndMTx = new List<int>();
		oLHJ3GsXqC = false;
		if (Geral.ExisteForm("frmAdicionaUmCabo"))
		{
			return;
		}
		YNgT0vgQsg();
		Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 566]);
		gbBL.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1232]);
		gbPar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1233]);
		gbTrio.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1234]);
		tbBLVar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1232]);
		tbP1Var.Text = "P1";
		tbP2Var.Text = "P2";
		tbT1Var.Text = "T1";
		tbT2Var.Text = "T2";
		tbT3Var.Text = "T3";
		LbCabo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]);
		lbVeia.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]);
		lbSecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1240]);
		lbOrigem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1342]);
		_5lbBlinED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 565]);
		_6lbCabosED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
		_7lbAterrarED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1243]);
		_8lbFuncao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]);
		_9lbComprimento.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]);
		_10lbTrajeto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1413]);
		cDadosAccess.carregaDadosDWG();
		cbOrigem.Items.Clear();
		cbDestino.Items.Clear();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.LeTodosOsPaineisDosCabos(ref qlqJ2ndMTx);
		cDadosAccessInterligacao3.FechaConexao();
		cDadosAccess.carregaPainelDicionario();
		foreach (int key in DeclaracoesGeral.dicPainel.Keys)
		{
			int item = key;
			if (!qlqJ2ndMTx.Contains(item))
			{
				qlqJ2ndMTx.Add(item);
			}
		}
		checked
		{
			int num = qlqJ2ndMTx.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				cbOrigem.Items.Add(Dicionario.BuscaNomeDoPainel(qlqJ2ndMTx[i]));
				cbDestino.Items.Add(Dicionario.BuscaNomeDoPainel(qlqJ2ndMTx[i]));
			}
			cbBlinED.Items.Clear();
			cbBlinED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 19]));
			cbBlinED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 20]));
			cbAterrarED.Items.Clear();
			cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 20]));
			cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 429]));
			cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 432]));
			cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1639]));
			cmYTRty6q3();
			oLHJ3GsXqC = bFecha;
			cbOrigem.Text = sPN1;
			cbDestino.Text = sPN2;
			gbBL.Enabled = false;
			gbPar.Enabled = false;
			gbTrio.Enabled = false;
			gbTrio.Visible = true;
			gbPar.Visible = false;
			gbTrio.Location = new Point(gbPar.Location.X, gbPar.Location.Y);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			Application.ShowModalDialog(Application.MainWindow.Handle, (Form)this, false);
			bWAJK1tODk = true;
		}
	}

	private void cmYTRty6q3()
	{
		s9HJewcMLL = new ClsCabos.StructureCabo[1];
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.LeTodosOsCabos(ref s9HJewcMLL, ref lTodosCabos);
		cDadosAccessInterligacao3.FechaConexao();
	}

	private void dQYTmqxHvq(object P_0, KeyEventArgs P_1)
	{
		try
		{
			if (btAdicionaCabo.Visible)
			{
				tbCabo.BackColor = Color.White;
				tbCabo.ForeColor = Color.Black;
				if (lTodosCabos.Contains(tbCabo.Text))
				{
					tbCabo.BackColor = Color.Red;
					tbCabo.ForeColor = Color.White;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void d4LTX8chNb(object P_0, EventArgs P_1)
	{
		verificaSeCaboEstaCorreto();
		if (btAdicionaCabo.Enabled)
		{
			ClsCabos.NomeVeias nv = new ClsCabos.NomeVeias
			{
				blVar = tbBLVar.Text,
				P1Var = tbP1Var.Text,
				P2Var = tbP2Var.Text,
				T1Var = tbT1Var.Text,
				T2Var = tbT2Var.Text,
				T3Var = tbT3Var.Text
			};
			ClsCabos.StructureCabo mCabos = default;
			List<string> lmListaCabos = new List<string>();
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			cDadosAccessInterligacao3.LeNomeDeCabos(ref lmListaCabos);
			adicionaCaboUnico(ref mCabos, nv, ref cDadosAccessInterligacao3);
			cDadosAccessInterligacao3.FechaConexao();
			if (!oLHJ3GsXqC)
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				cmYTRty6q3();
			}
			else
			{
				Close();
			}
		}
	}

	public bool adicionaCaboUnico(ref ClsCabos.StructureCabo mCabos, ClsCabos.NomeVeias nv, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		bool flag = false;
		mCabos.iLinha = 1;
		mCabos.iPn1 = Dicionario.BuscaIndiceDoPainel(cbOrigem.Text);
		mCabos.iPn2 = Dicionario.BuscaIndiceDoPainel(cbDestino.Text);
		mCabos.sTag = tbCabo.Text;
		mCabos.sVeias = tbVeia.Text;
		mCabos.sSecao = tbSecao.Text;
		if (Conversions.ToInteger(tbCabosED.Text) != 1)
		{
			mCabos.sFormacao = "1x" + tbSecao.Text;
		}
		else
		{
			mCabos.sFormacao = tbVeia.Text + "x" + tbSecao.Text;
		}
		int num = 0;
		string left = cbBlinED.Text;
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
		mCabos.bBlindagem = num != 0;
		mCabos.iCabos = Conversions.ToInteger(tbCabosED.Text);
		int iAterrar = 0;
		string left2 = cbAterrarED.Text.Trim();
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
		mCabos.sFuncao = clsTextos.TiraNothing(tbFuncao.Text);
		if (!Versioned.IsNumeric(tbComprimento.Text))
		{
			mCabos.dComprimento = 0.0;
		}
		else
		{
			mCabos.dComprimento = Conversions.ToDouble(tbComprimento.Text);
		}
		mCabos.sTrajeto = clsTextos.TiraNothing(tbTrajeto.Text);
		mCabos.sGrupo = "";
		mCabos.sInstrucao = "";
		ClsCabos.StructureCabo cabo = mCabos;
		flag = ClsCabos.LancaUmCabo(cabo, nv, ref cDadosAccessInterligacao);
		limpaCamposDaPesquisa();
		return flag;
	}

	public void limpaCamposDaPesquisa()
	{
		tbCabo.BackColor = Color.White;
		tbVeia.BackColor = Color.White;
		tbSecao.BackColor = Color.White;
		cbBlinED.BackColor = Color.White;
		tbCabosED.BackColor = Color.White;
		cbAterrarED.BackColor = Color.White;
		tbFuncao.BackColor = Color.White;
		tbComprimento.BackColor = Color.White;
		tbTrajeto.BackColor = Color.White;
		tbCabo.ForeColor = Color.Black;
		tbVeia.ForeColor = Color.Black;
		tbSecao.ForeColor = Color.Black;
		cbBlinED.ForeColor = Color.Black;
		tbCabosED.ForeColor = Color.Black;
		cbAterrarED.ForeColor = Color.Black;
		tbFuncao.ForeColor = Color.Black;
		tbComprimento.ForeColor = Color.Black;
		tbTrajeto.ForeColor = Color.Black;
	}

	public bool VerificaVeia()
	{
		bool result = true;
		gbPar.Enabled = false;
		gbTrio.Enabled = false;
		try
		{
			if (!((cbOrigem.BackColor == Color.Red) | (cbDestino.BackColor == Color.Red)))
			{
				tbVeia.BackColor = Color.White;
				tbVeia.ForeColor = Color.Black;
				tbVeia.Text = tbVeia.Text.Trim();
				if (!((Operators.CompareString(tbVeia.Text.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(tbVeia.Text.Trim(), "0", TextCompare: true) == 0)))
				{
					if (!Versioned.IsNumeric(tbVeia.Text))
					{
						string text = Strings.Mid(tbVeia.Text, Strings.Len(tbVeia.Text));
						if (!((Operators.CompareString(text.ToUpper(), "P", TextCompare: true) == 0) | (Operators.CompareString(text.ToUpper(), "T", TextCompare: true) == 0)))
						{
							result = false;
							tbVeia.BackColor = Color.Red;
							tbVeia.ForeColor = Color.White;
						}
						else
						{
							if (Operators.CompareString(text.ToUpper(), "P", TextCompare: true) == 0)
							{
								gbPar.Visible = true;
								gbPar.Enabled = true;
								gbTrio.Visible = false;
							}
							if (Operators.CompareString(text.ToUpper(), "T", TextCompare: true) == 0)
							{
								gbTrio.Visible = true;
								gbTrio.Enabled = true;
								gbPar.Visible = false;
							}
							result = true;
						}
					}
					else
					{
						int num = Conversions.ToInteger(tbVeia.Text);
						if (num <= 0)
						{
							result = false;
							tbVeia.BackColor = Color.Red;
							tbVeia.ForeColor = Color.White;
						}
						else
						{
							result = true;
							if (Operators.CompareString(tbCabosED.Text, "1", TextCompare: true) != 0)
							{
								tbCabosED.Text = "1";
							}
						}
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void cHvTUXcDlu(object P_0, MouseEventArgs P_1)
	{
		cbDestino.Items.Clear();
		cbDestino.Text = "";
		checked
		{
			int num = qlqJ2ndMTx.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = Dicionario.BuscaNomeDoPainel(qlqJ2ndMTx[i]);
				if (Operators.CompareString(cbOrigem.Text, text, TextCompare: true) != 0)
				{
					cbDestino.Items.Add(text);
				}
			}
			verificaSeCaboEstaCorreto();
		}
	}

	private void SVETyRTQpC(object P_0, EventArgs P_1)
	{
		cbAterrarED.BackColor = Color.White;
		cbAterrarED.ForeColor = Color.Black;
		cbDestino.Items.Clear();
		cbDestino.Text = "";
		checked
		{
			int num = qlqJ2ndMTx.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = Dicionario.BuscaNomeDoPainel(qlqJ2ndMTx[i]);
				if (Operators.CompareString(cbOrigem.Text, text, TextCompare: true) != 0)
				{
					cbDestino.Items.Add(text);
				}
			}
		}
	}

	private void F0qTgTQD2S(object P_0, EventArgs P_1)
	{
		cbOrigem.BackColor = Color.White;
		cbOrigem.ForeColor = Color.Black;
		if (((Operators.CompareString(cbOrigem.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(cbDestino.Text.Trim(), "", TextCompare: true) != 0)) && Operators.CompareString(cbOrigem.Text.Trim(), cbDestino.Text.Trim(), TextCompare: true) == 0)
		{
			cbOrigem.BackColor = Color.Red;
			cbOrigem.ForeColor = Color.White;
		}
		verificaSeCaboEstaCorreto();
	}

	private void iUJTAP6k8H(object P_0, MouseEventArgs P_1)
	{
		verificaSeCaboEstaCorreto();
	}

	private void EpxTsr3AYt(object P_0, EventArgs P_1)
	{
		cbDestino.BackColor = Color.White;
		cbDestino.ForeColor = Color.Black;
		if (((Operators.CompareString(cbOrigem.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(cbDestino.Text.Trim(), "", TextCompare: true) != 0)) && Operators.CompareString(cbOrigem.Text.Trim(), cbDestino.Text.Trim(), TextCompare: true) == 0)
		{
			cbDestino.BackColor = Color.Red;
			cbDestino.ForeColor = Color.White;
		}
		verificaSeCaboEstaCorreto();
	}

	private void PO9TBoBLoS(object P_0, EventArgs P_1)
	{
		verificaSeCaboEstaCorreto();
	}

	private void cGdTVnt0iC(object P_0, KeyEventArgs P_1)
	{
		VerificaVeia();
	}

	private void YNmTuVE6Ed(object P_0, EventArgs P_1)
	{
		verificaSeCaboEstaCorreto();
	}

	private void XdUTEXKmUi(object P_0, EventArgs P_1)
	{
		verificaSeCaboEstaCorreto();
	}

	private void OkITZPnthP(object P_0, EventArgs P_1)
	{
		if (!Operators.ConditionalCompareObjectEqual(cbBlinED.Text.Trim(), DeclaracoesGeral.mMensagem[1, 19], TextCompare: true))
		{
			gbBL.Enabled = false;
		}
		else
		{
			gbBL.Enabled = true;
		}
		verificaSeCaboEstaCorreto();
	}

	private void aTeTiwegHT(object P_0, EventArgs P_1)
	{
		cbBlinED.BackColor = Color.White;
		cbBlinED.ForeColor = Color.Black;
		if (Operators.CompareString(cbBlinED.Text, "", TextCompare: true) == 0)
		{
			cbBlinED.BackColor = Color.Red;
			cbBlinED.ForeColor = Color.White;
		}
		verificaSeCaboEstaCorreto();
	}

	private void J0aTSf5oFi(object P_0, EventArgs P_1)
	{
		verificaSeCaboEstaCorreto();
	}

	private void L0qT4JT3J3(object P_0, EventArgs P_1)
	{
		cbAterrarED.BackColor = Color.White;
		cbAterrarED.ForeColor = Color.Black;
		if (Operators.CompareString(cbAterrarED.Text, "", TextCompare: true) == 0)
		{
			cbAterrarED.BackColor = Color.Red;
			cbAterrarED.ForeColor = Color.White;
		}
		verificaSeCaboEstaCorreto();
	}

	private void t6DTCVHT60(object P_0, EventArgs P_1)
	{
		if (!Operators.ConditionalCompareObjectEqual(cbBlinED.Text.Trim(), DeclaracoesGeral.mMensagem[1, 19], TextCompare: true))
		{
			gbBL.Enabled = false;
		}
		else
		{
			gbBL.Enabled = true;
		}
		verificaSeCaboEstaCorreto();
	}

	private void UMdTYL86h5(object P_0, KeyEventArgs P_1)
	{
		tbComprimento.BackColor = Color.White;
		tbComprimento.ForeColor = Color.Black;
		tbComprimento.Text = tbComprimento.Text.Trim();
		if (Operators.CompareString(tbComprimento.Text.Trim(), "", TextCompare: true) == 0)
		{
			tbComprimento.Text = "0";
		}
		if (!Versioned.IsNumeric(tbComprimento.Text))
		{
			tbComprimento.BackColor = Color.Red;
			tbComprimento.ForeColor = Color.White;
		}
		else
		{
			double num = Conversions.ToDouble(tbComprimento.Text);
			if (num >= 0.0 && Operators.CompareString(tbComprimento.Text.ToString(), "0.0", TextCompare: true) == 0)
			{
				tbComprimento.Text = "0";
			}
		}
		verificaSeCaboEstaCorreto();
	}

	public void verificaSeCaboEstaCorreto()
	{
		limpaCamposDaPesquisa();
		bool flag = true;
		if (cbOrigem.BackColor == Color.Red)
		{
			flag = false;
		}
		if (cbDestino.BackColor == Color.Red)
		{
			flag = false;
		}
		if (Dicionario.BuscaIndiceDoPainel(cbOrigem.Text) == 0)
		{
			if (Operators.CompareString(cbOrigem.Text, "", TextCompare: true) != 0)
			{
				cbOrigem.BackColor = Color.Red;
				cbOrigem.ForeColor = Color.White;
			}
			flag = false;
		}
		if (Dicionario.BuscaIndiceDoPainel(cbDestino.Text) == 0)
		{
			if (Operators.CompareString(cbDestino.Text, "", TextCompare: true) != 0)
			{
				cbDestino.BackColor = Color.Red;
				cbDestino.ForeColor = Color.White;
			}
			flag = false;
		}
		if (lTodosCabos.Contains(tbCabo.Text) | (Operators.CompareString(tbCabo.Text.Trim(), "", TextCompare: true) == 0))
		{
			if (Operators.CompareString(tbCabo.Text, "", TextCompare: true) != 0)
			{
				tbCabo.BackColor = Color.Red;
				tbCabo.ForeColor = Color.White;
			}
			flag = false;
		}
		if (!VerificaVeia())
		{
			flag = false;
		}
		if (Operators.CompareString(tbSecao.Text.Trim(), "", TextCompare: true) == 0)
		{
			flag = false;
		}
		if (Operators.CompareString(cbBlinED.Text.Trim(), "", TextCompare: true) == 0)
		{
			flag = false;
		}
		if (Operators.CompareString(tbCabosED.Text.Trim(), "", TextCompare: true) == 0)
		{
			flag = false;
		}
		if (Operators.CompareString(cbAterrarED.Text.Trim(), "", TextCompare: true) == 0)
		{
			flag = false;
		}
		if (!flag)
		{
			btAdicionaCabo.Enabled = false;
		}
		else
		{
			btAdicionaCabo.Enabled = true;
		}
	}

	~frmAdicionaUmCabo()
	{
		base.Finalize();
	}
}
