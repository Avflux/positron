using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

[DesignerGenerated]
public class frmGerenciadorContatos : Form
{
	private IContainer gD59pBIhZB;

	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog gFL9TrXWT3;

	[AccessedThroughProperty("GroupBoxModelos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox iDL9JC0XkY;

	[AccessedThroughProperty("DGModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView uyi9hZ5WXC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxContatos")]
	private GroupBox s5c9o9Ynsf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGContato")]
	private DataGridView nMB9GccV4b;

	[CompilerGenerated]
	[AccessedThroughProperty("TBModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox auv9HqQP5g;

	[AccessedThroughProperty("BTEditaModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button UhQ9kSqDsm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTAdicionaModelo")]
	private Button n2V9djWQ11;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTApagaModelo")]
	[CompilerGenerated]
	private Button A8H9ffYTMQ;

	[AccessedThroughProperty("TBT1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox Prp9DXTJhV;

	[AccessedThroughProperty("BTEditaContato")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button tyu9vPfbKH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAdicionaContato")]
	[CompilerGenerated]
	private Button raH962B0qe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTApagaContaro")]
	private Button FG09tAQI3o;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbTipo")]
	private Label wX49jnhxMK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBComportamento")]
	private ComboBox Aul9L7T0Vg;

	[CompilerGenerated]
	[AccessedThroughProperty("CBTipo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox gI99wuE5UW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBT3")]
	private TextBox hRL9x9LpTF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBT2")]
	[CompilerGenerated]
	private TextBox ShU9bhmXeY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbTerminais")]
	[CompilerGenerated]
	private Label cZW9MPGuxb;

	[AccessedThroughProperty("TBTerminais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox K7s9OPAW9f;

	[AccessedThroughProperty("BTNovo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button fVE9ImEaDL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox Nmw97HhUto;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGContatosInseridos")]
	private DataGridView mT19qB4rNV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip g5s9a22kDF;

	[AccessedThroughProperty("BTExportaEX")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button K9498aTx7G;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTImportaEX")]
	private Button mhp9NanEfL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbLayout")]
	private Label KOQ9FiK4Ew;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTopografico")]
	private Label EnC9Qu6Z1x;

	[AccessedThroughProperty("btSelecionaBlocoTopo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button ELc9PZHGfF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecionaBlocoLayout")]
	private Button SCX9cU83XM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBlocoTopografico")]
	private TextBox XfJ9KvodTu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBlocoLayout")]
	private TextBox a9n9eu1rOh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTerminaisModelo")]
	private Label HN592RdMJN;

	[AccessedThroughProperty("lbNomeModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label W7W93jP3OS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbOrientacao")]
	private Label dJM9nDBiqO;

	[AccessedThroughProperty("tbOrientacao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox IBu91C3is7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox tBw9l0pBTJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbOrientacaoTerminais")]
	[CompilerGenerated]
	private TextBox HUN95H9hTW;

	[AccessedThroughProperty("lbOrientacaoTerm")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label Noe90cf8DF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagaModelosSemUso")]
	private Button bh69RjyDSt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisaLM2")]
	private Button TUK9mOtQnL;

	[AccessedThroughProperty("btPesquisaLM1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button zDd9XHpXMt;

	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox KO19U6nXaX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox Umf9yCSKMT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCodigo1")]
	private TextBox t2B9gorbvR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbModelo1")]
	[CompilerGenerated]
	private TextBox KJy9AmtOwx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricaoResum2")]
	private TextBox AxN9sJ13YT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricaoResum1")]
	private TextBox Bwo9BvfDjX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCodigo2")]
	private TextBox GyJ9V3sqXO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFabricante2")]
	[CompilerGenerated]
	private TextBox cRL9uFHX1D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFabricante1")]
	[CompilerGenerated]
	private TextBox MGJ9EIObPQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbModelo2")]
	private TextBox kov9ZbAxJx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbFabricante")]
	private Label LnS9iDh5Ki;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbModelo")]
	private Label s9F9Sv2pV6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDesc")]
	private Label CRS94Vc9BC;

	[CompilerGenerated]
	[AccessedThroughProperty("lbCodigo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label Yqe9CiUZiI;

	private DeclaracoesClonar.structureMaterial[] EiB9Y3sMeJ;

	private int Ucp9rHhj2R;

	private int RnE99oMK3k;

	private Declaracoes2.MModelosDeContatos[] jgX9zK19sF;

	private Declaracoes2.StructureContatosAuxiliares[] UWuzWyqRcA;

	private bool SbHzp2bYTy;

	private List<int> nXczTc5nTE;

	internal virtual GroupBox GroupBoxModelos
	{
		[CompilerGenerated]
		get
		{
			return iDL9JC0XkY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iDL9JC0XkY = value;
		}
	}

	internal virtual DataGridView DGModelo
	{
		[CompilerGenerated]
		get
		{
			return uyi9hZ5WXC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = kKYrl9Im2L;
			KeyEventHandler value3 = WVoriS9NYV;
			KeyEventHandler value4 = Kd1rSNMRTP;
			DataGridView dataGridView = uyi9hZ5WXC;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
			}
			uyi9hZ5WXC = value;
			dataGridView = uyi9hZ5WXC;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
			}
		}
	}

	internal virtual GroupBox GroupBoxContatos
	{
		[CompilerGenerated]
		get
		{
			return s5c9o9Ynsf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s5c9o9Ynsf = value;
		}
	}

	internal virtual DataGridView DGContato
	{
		[CompilerGenerated]
		get
		{
			return nMB9GccV4b;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = hcbrBxSiMW;
			DataGridView dataGridView = nMB9GccV4b;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			nMB9GccV4b = value;
			dataGridView = nMB9GccV4b;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual TextBox TBModelo
	{
		[CompilerGenerated]
		get
		{
			return auv9HqQP5g;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = JNYrup9DyJ;
			TextBox textBox = auv9HqQP5g;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			auv9HqQP5g = value;
			textBox = auv9HqQP5g;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button BTEditaModelo
	{
		[CompilerGenerated]
		get
		{
			return UhQ9kSqDsm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ifWrRgr7pu;
			Button button = UhQ9kSqDsm;
			if (button != null)
			{
				button.Click -= value2;
			}
			UhQ9kSqDsm = value;
			button = UhQ9kSqDsm;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAdicionaModelo
	{
		[CompilerGenerated]
		get
		{
			return n2V9djWQ11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QO6r046UrS;
			Button button = n2V9djWQ11;
			if (button != null)
			{
				button.Click -= value2;
			}
			n2V9djWQ11 = value;
			button = n2V9djWQ11;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTApagaModelo
	{
		[CompilerGenerated]
		get
		{
			return A8H9ffYTMQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yMZrX9wFN9;
			Button button = A8H9ffYTMQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			A8H9ffYTMQ = value;
			button = A8H9ffYTMQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBT1
	{
		[CompilerGenerated]
		get
		{
			return Prp9DXTJhV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Prp9DXTJhV = value;
		}
	}

	internal virtual Button BTEditaContato
	{
		[CompilerGenerated]
		get
		{
			return tyu9vPfbKH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NHArAosvEZ;
			Button button = tyu9vPfbKH;
			if (button != null)
			{
				button.Click -= value2;
			}
			tyu9vPfbKH = value;
			button = tyu9vPfbKH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAdicionaContato
	{
		[CompilerGenerated]
		get
		{
			return raH962B0qe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dZHrg3PtFK;
			Button button = raH962B0qe;
			if (button != null)
			{
				button.Click -= value2;
			}
			raH962B0qe = value;
			button = raH962B0qe;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTApagaContaro
	{
		[CompilerGenerated]
		get
		{
			return FG09tAQI3o;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OpfrsXSTAb;
			Button button = FG09tAQI3o;
			if (button != null)
			{
				button.Click -= value2;
			}
			FG09tAQI3o = value;
			button = FG09tAQI3o;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LbTipo
	{
		[CompilerGenerated]
		get
		{
			return wX49jnhxMK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wX49jnhxMK = value;
		}
	}

	internal virtual ComboBox CBComportamento
	{
		[CompilerGenerated]
		get
		{
			return Aul9L7T0Vg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Aul9L7T0Vg = value;
		}
	}

	internal virtual ComboBox CBTipo
	{
		[CompilerGenerated]
		get
		{
			return gI99wuE5UW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ax9r1pEbBP;
			ComboBox comboBox = gI99wuE5UW;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			gI99wuE5UW = value;
			comboBox = gI99wuE5UW;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox TBT3
	{
		[CompilerGenerated]
		get
		{
			return hRL9x9LpTF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hRL9x9LpTF = value;
		}
	}

	internal virtual TextBox TBT2
	{
		[CompilerGenerated]
		get
		{
			return ShU9bhmXeY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ShU9bhmXeY = value;
		}
	}

	internal virtual Label LbTerminais
	{
		[CompilerGenerated]
		get
		{
			return cZW9MPGuxb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cZW9MPGuxb = value;
		}
	}

	internal virtual TextBox TBTerminais
	{
		[CompilerGenerated]
		get
		{
			return K7s9OPAW9f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			K7s9OPAW9f = value;
		}
	}

	internal virtual Button BTNovo
	{
		[CompilerGenerated]
		get
		{
			return fVE9ImEaDL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HG3ryHFjrQ;
			Button button = fVE9ImEaDL;
			if (button != null)
			{
				button.Click -= value2;
			}
			fVE9ImEaDL = value;
			button = fVE9ImEaDL;
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
			return Nmw97HhUto;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Nmw97HhUto = value;
		}
	}

	internal virtual DataGridView DGContatosInseridos
	{
		[CompilerGenerated]
		get
		{
			return mT19qB4rNV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = Dr4rVq9Jcr;
			DataGridView dataGridView = mT19qB4rNV;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			mT19qB4rNV = value;
			dataGridView = mT19qB4rNV;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button BTExportaEX
	{
		[CompilerGenerated]
		get
		{
			return K9498aTx7G;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GIXrZvr64R;
			Button button = K9498aTx7G;
			if (button != null)
			{
				button.Click -= value2;
			}
			K9498aTx7G = value;
			button = K9498aTx7G;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTImportaEX
	{
		[CompilerGenerated]
		get
		{
			return mhp9NanEfL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bnsrErB0VP;
			Button button = mhp9NanEfL;
			if (button != null)
			{
				button.Click -= value2;
			}
			mhp9NanEfL = value;
			button = mhp9NanEfL;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbLayout
	{
		[CompilerGenerated]
		get
		{
			return KOQ9FiK4Ew;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KOQ9FiK4Ew = value;
		}
	}

	internal virtual Label lbTopografico
	{
		[CompilerGenerated]
		get
		{
			return EnC9Qu6Z1x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EnC9Qu6Z1x = value;
		}
	}

	internal virtual Button btSelecionaBlocoTopo
	{
		[CompilerGenerated]
		get
		{
			return ELc9PZHGfF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Glrr4ujHAr;
			Button button = ELc9PZHGfF;
			if (button != null)
			{
				button.Click -= value2;
			}
			ELc9PZHGfF = value;
			button = ELc9PZHGfF;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSelecionaBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return SCX9cU83XM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fA9rCsMRYb;
			Button button = SCX9cU83XM;
			if (button != null)
			{
				button.Click -= value2;
			}
			SCX9cU83XM = value;
			button = SCX9cU83XM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbBlocoTopografico
	{
		[CompilerGenerated]
		get
		{
			return XfJ9KvodTu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XfJ9KvodTu = value;
		}
	}

	internal virtual TextBox tbBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return a9n9eu1rOh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a9n9eu1rOh = value;
		}
	}

	internal virtual Label lbTerminaisModelo
	{
		[CompilerGenerated]
		get
		{
			return HN592RdMJN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HN592RdMJN = value;
		}
	}

	internal virtual Label lbNomeModelo
	{
		[CompilerGenerated]
		get
		{
			return W7W93jP3OS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			W7W93jP3OS = value;
		}
	}

	internal virtual Label lbOrientacao
	{
		[CompilerGenerated]
		get
		{
			return dJM9nDBiqO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dJM9nDBiqO = value;
		}
	}

	internal virtual TextBox tbOrientacao
	{
		[CompilerGenerated]
		get
		{
			return IBu91C3is7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = MTxrYSMwCT;
			TextBox textBox = IBu91C3is7;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			IBu91C3is7 = value;
			textBox = IBu91C3is7;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return tBw9l0pBTJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tBw9l0pBTJ = value;
		}
	}

	internal virtual TextBox tbOrientacaoTerminais
	{
		[CompilerGenerated]
		get
		{
			return HUN95H9hTW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = dOarrK99kW;
			TextBox textBox = HUN95H9hTW;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			HUN95H9hTW = value;
			textBox = HUN95H9hTW;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbOrientacaoTerm
	{
		[CompilerGenerated]
		get
		{
			return Noe90cf8DF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Noe90cf8DF = value;
		}
	}

	internal virtual Button btApagaModelosSemUso
	{
		[CompilerGenerated]
		get
		{
			return bh69RjyDSt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oBBrUDMvuE;
			Button button = bh69RjyDSt;
			if (button != null)
			{
				button.Click -= value2;
			}
			bh69RjyDSt = value;
			button = bh69RjyDSt;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPesquisaLM2
	{
		[CompilerGenerated]
		get
		{
			return TUK9mOtQnL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = f3Xrzfe9Id;
			Button button = TUK9mOtQnL;
			if (button != null)
			{
				button.Click -= value2;
			}
			TUK9mOtQnL = value;
			button = TUK9mOtQnL;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPesquisaLM1
	{
		[CompilerGenerated]
		get
		{
			return zDd9XHpXMt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = O8Ur9KXNlQ;
			Button button = zDd9XHpXMt;
			if (button != null)
			{
				button.Click -= value2;
			}
			zDd9XHpXMt = value;
			button = zDd9XHpXMt;
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
			return KO19U6nXaX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KO19U6nXaX = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return Umf9yCSKMT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Umf9yCSKMT = value;
		}
	}

	internal virtual TextBox tbCodigo1
	{
		[CompilerGenerated]
		get
		{
			return t2B9gorbvR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			t2B9gorbvR = value;
		}
	}

	internal virtual TextBox tbModelo1
	{
		[CompilerGenerated]
		get
		{
			return KJy9AmtOwx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KJy9AmtOwx = value;
		}
	}

	internal virtual TextBox tbDescricaoResum2
	{
		[CompilerGenerated]
		get
		{
			return AxN9sJ13YT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AxN9sJ13YT = value;
		}
	}

	internal virtual TextBox tbDescricaoResum1
	{
		[CompilerGenerated]
		get
		{
			return Bwo9BvfDjX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Bwo9BvfDjX = value;
		}
	}

	internal virtual TextBox tbCodigo2
	{
		[CompilerGenerated]
		get
		{
			return GyJ9V3sqXO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GyJ9V3sqXO = value;
		}
	}

	internal virtual TextBox tbFabricante2
	{
		[CompilerGenerated]
		get
		{
			return cRL9uFHX1D;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cRL9uFHX1D = value;
		}
	}

	internal virtual TextBox tbFabricante1
	{
		[CompilerGenerated]
		get
		{
			return MGJ9EIObPQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MGJ9EIObPQ = value;
		}
	}

	internal virtual TextBox tbModelo2
	{
		[CompilerGenerated]
		get
		{
			return kov9ZbAxJx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kov9ZbAxJx = value;
		}
	}

	internal virtual Label lbFabricante
	{
		[CompilerGenerated]
		get
		{
			return LnS9iDh5Ki;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LnS9iDh5Ki = value;
		}
	}

	internal virtual Label lbModelo
	{
		[CompilerGenerated]
		get
		{
			return s9F9Sv2pV6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s9F9Sv2pV6 = value;
		}
	}

	internal virtual Label lbDesc
	{
		[CompilerGenerated]
		get
		{
			return CRS94Vc9BC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CRS94Vc9BC = value;
		}
	}

	internal virtual Label lbCodigo
	{
		[CompilerGenerated]
		get
		{
			return Yqe9CiUZiI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Yqe9CiUZiI = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && gD59pBIhZB != null)
			{
				gD59pBIhZB.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void bPyrnLxyur()
	{
		gD59pBIhZB = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		GroupBoxModelos = new GroupBox();
		DGModelo = new DataGridView();
		GroupBox2 = new GroupBox();
		btApagaModelosSemUso = new Button();
		lbTerminaisModelo = new Label();
		lbOrientacao = new Label();
		tbOrientacao = new TextBox();
		TBModelo = new TextBox();
		TBTerminais = new TextBox();
		BTEditaModelo = new Button();
		BTApagaModelo = new Button();
		BTAdicionaModelo = new Button();
		lbNomeModelo = new Label();
		btPesquisaLM2 = new Button();
		btPesquisaLM1 = new Button();
		BTImportaEX = new Button();
		BTExportaEX = new Button();
		tbBlocoLayout = new TextBox();
		btSelecionaBlocoLayout = new Button();
		tbBlocoTopografico = new TextBox();
		btSelecionaBlocoTopo = new Button();
		lbLayout = new Label();
		lbTopografico = new Label();
		GroupBoxContatos = new GroupBox();
		tbOrientacaoTerminais = new TextBox();
		lbOrientacaoTerm = new Label();
		LbTipo = new Label();
		CBComportamento = new ComboBox();
		CBTipo = new ComboBox();
		TBT3 = new TextBox();
		BTNovo = new Button();
		TBT2 = new TextBox();
		LbTerminais = new Label();
		TBT1 = new TextBox();
		BTEditaContato = new Button();
		BTAdicionaContato = new Button();
		BTApagaContaro = new Button();
		DGContato = new DataGridView();
		GroupBox1 = new GroupBox();
		DGContatosInseridos = new DataGridView();
		FDqpBiUmZij(new ToolTip(gD59pBIhZB));
		GroupBox3 = new GroupBox();
		GroupBox4 = new GroupBox();
		lbFabricante = new Label();
		lbModelo = new Label();
		lbDesc = new Label();
		lbCodigo = new Label();
		tbFabricante2 = new TextBox();
		tbFabricante1 = new TextBox();
		tbModelo2 = new TextBox();
		tbModelo1 = new TextBox();
		tbDescricaoResum2 = new TextBox();
		tbDescricaoResum1 = new TextBox();
		tbCodigo2 = new TextBox();
		tbCodigo1 = new TextBox();
		GroupBoxModelos.SuspendLayout();
		((ISupportInitialize)DGModelo).BeginInit();
		GroupBox2.SuspendLayout();
		GroupBoxContatos.SuspendLayout();
		((ISupportInitialize)DGContato).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)DGContatosInseridos).BeginInit();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		SuspendLayout();
		GroupBoxModelos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBoxModelos.Controls.Add(DGModelo);
		GroupBoxModelos.Location = new Point(6, 6);
		GroupBoxModelos.Name = "GroupBoxModelos";
		GroupBoxModelos.Size = new Size(554, 192);
		GroupBoxModelos.TabIndex = 132;
		GroupBoxModelos.TabStop = false;
		GroupBoxModelos.Text = "GroupBoxModelos";
		DGModelo.AllowUserToAddRows = false;
		DGModelo.AllowUserToDeleteRows = false;
		DGModelo.AllowUserToOrderColumns = true;
		DGModelo.AllowUserToResizeRows = false;
		DGModelo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGModelo.BackgroundColor = SystemColors.ButtonHighlight;
		DGModelo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGModelo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGModelo.Location = new Point(5, 15);
		DGModelo.MultiSelect = false;
		DGModelo.Name = "DGModelo";
		DGModelo.ReadOnly = true;
		DGModelo.RowHeadersVisible = false;
		DGModelo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGModelo.Size = new Size(543, 171);
		DGModelo.TabIndex = 117;
		DGModelo.TabStop = false;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(btApagaModelosSemUso);
		GroupBox2.Controls.Add(lbTerminaisModelo);
		GroupBox2.Controls.Add(lbOrientacao);
		GroupBox2.Controls.Add(tbOrientacao);
		GroupBox2.Controls.Add(TBModelo);
		GroupBox2.Controls.Add(TBTerminais);
		GroupBox2.Controls.Add(BTEditaModelo);
		GroupBox2.Controls.Add(BTApagaModelo);
		GroupBox2.Controls.Add(BTAdicionaModelo);
		GroupBox2.Controls.Add(lbNomeModelo);
		GroupBox2.Location = new Point(8, 198);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(468, 70);
		GroupBox2.TabIndex = 167;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		btApagaModelosSemUso.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagaModelosSemUso.FlatStyle = FlatStyle.Flat;
		btApagaModelosSemUso.ForeColor = SystemColors.Control;
		btApagaModelosSemUso.Image = Resources.Apagador_32;
		btApagaModelosSemUso.Location = new Point(423, 18);
		btApagaModelosSemUso.Name = "btApagaModelosSemUso";
		btApagaModelosSemUso.Size = new Size(40, 40);
		btApagaModelosSemUso.TabIndex = 167;
		btApagaModelosSemUso.Tag = "";
		btApagaModelosSemUso.UseVisualStyleBackColor = true;
		lbTerminaisModelo.AutoSize = true;
		lbTerminaisModelo.Location = new Point(101, 18);
		lbTerminaisModelo.Name = "lbTerminaisModelo";
		lbTerminaisModelo.Size = new Size(60, 13);
		lbTerminaisModelo.TabIndex = 164;
		lbTerminaisModelo.Text = "lbTerminais";
		lbOrientacao.AutoSize = true;
		lbOrientacao.Location = new Point(194, 18);
		lbOrientacao.Name = "lbOrientacao";
		lbOrientacao.Size = new Size(67, 13);
		lbOrientacao.TabIndex = 166;
		lbOrientacao.Text = "lbOrientacao";
		tbOrientacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbOrientacao.Location = new Point(194, 35);
		tbOrientacao.Name = "tbOrientacao";
		tbOrientacao.Size = new Size(87, 20);
		tbOrientacao.TabIndex = 3;
		TBModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBModelo.Location = new Point(5, 35);
		TBModelo.Name = "TBModelo";
		TBModelo.Size = new Size(90, 20);
		TBModelo.TabIndex = 1;
		TBTerminais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTerminais.Location = new Point(101, 35);
		TBTerminais.Name = "TBTerminais";
		TBTerminais.Size = new Size(87, 20);
		TBTerminais.TabIndex = 2;
		BTEditaModelo.FlatStyle = FlatStyle.Flat;
		BTEditaModelo.ForeColor = SystemColors.Control;
		BTEditaModelo.Image = Resources.Editar;
		BTEditaModelo.Location = new Point(331, 18);
		BTEditaModelo.Name = "BTEditaModelo";
		BTEditaModelo.Size = new Size(40, 40);
		BTEditaModelo.TabIndex = 5;
		BTEditaModelo.UseVisualStyleBackColor = true;
		BTApagaModelo.FlatStyle = FlatStyle.Flat;
		BTApagaModelo.ForeColor = SystemColors.Control;
		BTApagaModelo.Image = Resources.Delete_32;
		BTApagaModelo.Location = new Point(377, 18);
		BTApagaModelo.Name = "BTApagaModelo";
		BTApagaModelo.Size = new Size(40, 40);
		BTApagaModelo.TabIndex = 6;
		BTApagaModelo.Tag = "";
		BTApagaModelo.UseVisualStyleBackColor = true;
		BTAdicionaModelo.FlatStyle = FlatStyle.Flat;
		BTAdicionaModelo.ForeColor = SystemColors.Control;
		BTAdicionaModelo.Image = Resources.Adiciona_32;
		BTAdicionaModelo.Location = new Point(285, 18);
		BTAdicionaModelo.Name = "BTAdicionaModelo";
		BTAdicionaModelo.Size = new Size(40, 40);
		BTAdicionaModelo.TabIndex = 4;
		BTAdicionaModelo.UseVisualStyleBackColor = true;
		lbNomeModelo.AutoSize = true;
		lbNomeModelo.Location = new Point(5, 19);
		lbNomeModelo.Name = "lbNomeModelo";
		lbNomeModelo.Size = new Size(43, 13);
		lbNomeModelo.TabIndex = 163;
		lbNomeModelo.Text = "lbNome";
		btPesquisaLM2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM2.FlatStyle = FlatStyle.Flat;
		btPesquisaLM2.ForeColor = SystemColors.Control;
		btPesquisaLM2.Image = Resources.Pesquisar_16;
		btPesquisaLM2.Location = new Point(524, 59);
		btPesquisaLM2.Name = "btPesquisaLM2";
		btPesquisaLM2.Size = new Size(22, 22);
		btPesquisaLM2.TabIndex = 195;
		btPesquisaLM2.UseVisualStyleBackColor = true;
		btPesquisaLM1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM1.FlatStyle = FlatStyle.Flat;
		btPesquisaLM1.ForeColor = SystemColors.Control;
		btPesquisaLM1.Image = Resources.Pesquisar_16;
		btPesquisaLM1.Location = new Point(524, 36);
		btPesquisaLM1.Name = "btPesquisaLM1";
		btPesquisaLM1.Size = new Size(22, 24);
		btPesquisaLM1.TabIndex = 194;
		btPesquisaLM1.UseVisualStyleBackColor = true;
		BTImportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTImportaEX.FlatStyle = FlatStyle.Flat;
		BTImportaEX.ForeColor = SystemColors.Control;
		BTImportaEX.Image = Resources.ImportaExcel_20;
		BTImportaEX.Location = new Point(532, 214);
		BTImportaEX.Name = "BTImportaEX";
		BTImportaEX.Size = new Size(22, 42);
		BTImportaEX.TabIndex = 14;
		BTImportaEX.UseVisualStyleBackColor = true;
		BTExportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTExportaEX.FlatStyle = FlatStyle.Flat;
		BTExportaEX.ForeColor = SystemColors.Control;
		BTExportaEX.Image = Resources.ExportaExcel_20;
		BTExportaEX.Location = new Point(504, 214);
		BTExportaEX.Name = "BTExportaEX";
		BTExportaEX.Size = new Size(22, 42);
		BTExportaEX.TabIndex = 13;
		BTExportaEX.UseVisualStyleBackColor = true;
		tbBlocoLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoLayout.Location = new Point(284, 39);
		tbBlocoLayout.Name = "tbBlocoLayout";
		tbBlocoLayout.Size = new Size(234, 20);
		tbBlocoLayout.TabIndex = 11;
		btSelecionaBlocoLayout.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoLayout.ForeColor = SystemColors.Control;
		btSelecionaBlocoLayout.Image = Resources.Pesquisar_16;
		btSelecionaBlocoLayout.Location = new Point(524, 37);
		btSelecionaBlocoLayout.Name = "btSelecionaBlocoLayout";
		btSelecionaBlocoLayout.Size = new Size(22, 22);
		btSelecionaBlocoLayout.TabIndex = 12;
		btSelecionaBlocoLayout.UseVisualStyleBackColor = true;
		tbBlocoTopografico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoTopografico.Location = new Point(13, 39);
		tbBlocoTopografico.Name = "tbBlocoTopografico";
		tbBlocoTopografico.Size = new Size(220, 20);
		tbBlocoTopografico.TabIndex = 9;
		btSelecionaBlocoTopo.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoTopo.ForeColor = SystemColors.Control;
		btSelecionaBlocoTopo.Image = Resources.Pesquisar_16;
		btSelecionaBlocoTopo.Location = new Point(239, 37);
		btSelecionaBlocoTopo.Name = "btSelecionaBlocoTopo";
		btSelecionaBlocoTopo.Size = new Size(22, 22);
		btSelecionaBlocoTopo.TabIndex = 10;
		btSelecionaBlocoTopo.UseVisualStyleBackColor = true;
		lbLayout.Location = new Point(281, 20);
		lbLayout.Name = "lbLayout";
		lbLayout.Size = new Size(112, 16);
		lbLayout.TabIndex = 158;
		lbLayout.Text = "lbLAYOUT";
		lbTopografico.Location = new Point(13, 20);
		lbTopografico.Name = "lbTopografico";
		lbTopografico.Size = new Size(112, 16);
		lbTopografico.TabIndex = 156;
		lbTopografico.Text = "lbTOPOGRAFICO";
		GroupBoxContatos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBoxContatos.Controls.Add(tbOrientacaoTerminais);
		GroupBoxContatos.Controls.Add(lbOrientacaoTerm);
		GroupBoxContatos.Controls.Add(LbTipo);
		GroupBoxContatos.Controls.Add(CBComportamento);
		GroupBoxContatos.Controls.Add(CBTipo);
		GroupBoxContatos.Controls.Add(TBT3);
		GroupBoxContatos.Controls.Add(BTNovo);
		GroupBoxContatos.Controls.Add(TBT2);
		GroupBoxContatos.Controls.Add(LbTerminais);
		GroupBoxContatos.Controls.Add(TBT1);
		GroupBoxContatos.Controls.Add(BTEditaContato);
		GroupBoxContatos.Controls.Add(BTAdicionaContato);
		GroupBoxContatos.Controls.Add(BTApagaContaro);
		GroupBoxContatos.Controls.Add(DGContato);
		GroupBoxContatos.Location = new Point(566, 6);
		GroupBoxContatos.Name = "GroupBoxContatos";
		GroupBoxContatos.Size = new Size(466, 300);
		GroupBoxContatos.TabIndex = 134;
		GroupBoxContatos.TabStop = false;
		GroupBoxContatos.Text = "GroupBoxContatos";
		tbOrientacaoTerminais.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbOrientacaoTerminais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbOrientacaoTerminais.Location = new Point(124, 272);
		tbOrientacaoTerminais.Name = "tbOrientacaoTerminais";
		tbOrientacaoTerminais.Size = new Size(81, 20);
		tbOrientacaoTerminais.TabIndex = 18;
		lbOrientacaoTerm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbOrientacaoTerm.BorderStyle = BorderStyle.Fixed3D;
		lbOrientacaoTerm.Location = new Point(124, 252);
		lbOrientacaoTerm.Name = "lbOrientacaoTerm";
		lbOrientacaoTerm.Size = new Size(81, 17);
		lbOrientacaoTerm.TabIndex = 147;
		lbOrientacaoTerm.Text = "ORIENTAÇÃO";
		lbOrientacaoTerm.TextAlign = ContentAlignment.MiddleCenter;
		LbTipo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbTipo.BorderStyle = BorderStyle.Fixed3D;
		LbTipo.Location = new Point(211, 252);
		LbTipo.Name = "LbTipo";
		LbTipo.Size = new Size(83, 17);
		LbTipo.TabIndex = 146;
		LbTipo.Text = "lbTIPO";
		LbTipo.TextAlign = ContentAlignment.MiddleCenter;
		CBComportamento.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CBComportamento.FormattingEnabled = true;
		CBComportamento.Location = new Point(254, 272);
		CBComportamento.Name = "CBComportamento";
		CBComportamento.Size = new Size(40, 21);
		CBComportamento.TabIndex = 20;
		CBTipo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CBTipo.FormattingEnabled = true;
		CBTipo.Location = new Point(211, 272);
		CBTipo.Name = "CBTipo";
		CBTipo.Size = new Size(40, 21);
		CBTipo.TabIndex = 19;
		TBT3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBT3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBT3.Location = new Point(85, 272);
		TBT3.Name = "TBT3";
		TBT3.Size = new Size(35, 20);
		TBT3.TabIndex = 17;
		BTNovo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTNovo.FlatStyle = FlatStyle.Flat;
		BTNovo.ForeColor = SystemColors.Control;
		BTNovo.Image = Resources.Proximo_32;
		BTNovo.Location = new Point(296, 252);
		BTNovo.Name = "BTNovo";
		BTNovo.Size = new Size(40, 40);
		BTNovo.TabIndex = 21;
		BTNovo.UseVisualStyleBackColor = true;
		TBT2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBT2.Location = new Point(45, 272);
		TBT2.Name = "TBT2";
		TBT2.Size = new Size(35, 20);
		TBT2.TabIndex = 16;
		LbTerminais.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbTerminais.BorderStyle = BorderStyle.Fixed3D;
		LbTerminais.Location = new Point(5, 252);
		LbTerminais.Name = "LbTerminais";
		LbTerminais.Size = new Size(115, 17);
		LbTerminais.TabIndex = 139;
		LbTerminais.Text = "lbTERMINAIS";
		LbTerminais.TextAlign = ContentAlignment.MiddleCenter;
		TBT1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBT1.Location = new Point(5, 272);
		TBT1.Name = "TBT1";
		TBT1.Size = new Size(35, 20);
		TBT1.TabIndex = 15;
		BTEditaContato.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTEditaContato.FlatStyle = FlatStyle.Flat;
		BTEditaContato.ForeColor = SystemColors.Control;
		BTEditaContato.Image = Resources.Editar;
		BTEditaContato.Location = new Point(376, 252);
		BTEditaContato.Name = "BTEditaContato";
		BTEditaContato.Size = new Size(40, 40);
		BTEditaContato.TabIndex = 23;
		BTEditaContato.UseVisualStyleBackColor = true;
		BTAdicionaContato.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTAdicionaContato.FlatStyle = FlatStyle.Flat;
		BTAdicionaContato.ForeColor = SystemColors.Control;
		BTAdicionaContato.Image = Resources.Adiciona_32;
		BTAdicionaContato.Location = new Point(336, 252);
		BTAdicionaContato.Name = "BTAdicionaContato";
		BTAdicionaContato.Size = new Size(40, 40);
		BTAdicionaContato.TabIndex = 22;
		BTAdicionaContato.UseVisualStyleBackColor = true;
		BTApagaContaro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTApagaContaro.FlatStyle = FlatStyle.Flat;
		BTApagaContaro.ForeColor = SystemColors.Control;
		BTApagaContaro.Image = Resources.Delete_32;
		BTApagaContaro.Location = new Point(416, 252);
		BTApagaContaro.Name = "BTApagaContaro";
		BTApagaContaro.Size = new Size(40, 40);
		BTApagaContaro.TabIndex = 24;
		BTApagaContaro.Tag = "";
		BTApagaContaro.UseVisualStyleBackColor = true;
		DGContato.AllowUserToAddRows = false;
		DGContato.AllowUserToDeleteRows = false;
		DGContato.AllowUserToOrderColumns = true;
		DGContato.AllowUserToResizeRows = false;
		DGContato.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGContato.BackgroundColor = SystemColors.ButtonHighlight;
		DGContato.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGContato.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGContato.Location = new Point(6, 13);
		DGContato.MultiSelect = false;
		DGContato.Name = "DGContato";
		DGContato.ReadOnly = true;
		DGContato.RowHeadersVisible = false;
		DGContato.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGContato.Size = new Size(454, 236);
		DGContato.TabIndex = 117;
		DGContato.TabStop = false;
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox1.Controls.Add(DGContatosInseridos);
		GroupBox1.Location = new Point(566, 305);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(466, 135);
		GroupBox1.TabIndex = 141;
		GroupBox1.TabStop = false;
		DGContatosInseridos.AllowUserToAddRows = false;
		DGContatosInseridos.AllowUserToDeleteRows = false;
		DGContatosInseridos.AllowUserToOrderColumns = true;
		DGContatosInseridos.AllowUserToResizeRows = false;
		DGContatosInseridos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGContatosInseridos.BackgroundColor = SystemColors.ButtonHighlight;
		DGContatosInseridos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGContatosInseridos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGContatosInseridos.Location = new Point(6, 11);
		DGContatosInseridos.MultiSelect = false;
		DGContatosInseridos.Name = "DGContatosInseridos";
		DGContatosInseridos.ReadOnly = true;
		DGContatosInseridos.RowHeadersVisible = false;
		DGContatosInseridos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGContatosInseridos.Size = new Size(454, 118);
		DGContatosInseridos.TabIndex = 118;
		DGContatosInseridos.TabStop = false;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(lbTopografico);
		GroupBox3.Controls.Add(lbLayout);
		GroupBox3.Controls.Add(btSelecionaBlocoTopo);
		GroupBox3.Controls.Add(tbBlocoLayout);
		GroupBox3.Controls.Add(tbBlocoTopografico);
		GroupBox3.Controls.Add(btSelecionaBlocoLayout);
		GroupBox3.Location = new Point(8, 274);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(552, 71);
		GroupBox3.TabIndex = 119;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "GroupBox3";
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(lbFabricante);
		GroupBox4.Controls.Add(lbModelo);
		GroupBox4.Controls.Add(lbDesc);
		GroupBox4.Controls.Add(lbCodigo);
		GroupBox4.Controls.Add(tbFabricante2);
		GroupBox4.Controls.Add(tbFabricante1);
		GroupBox4.Controls.Add(tbModelo2);
		GroupBox4.Controls.Add(tbModelo1);
		GroupBox4.Controls.Add(tbDescricaoResum2);
		GroupBox4.Controls.Add(tbDescricaoResum1);
		GroupBox4.Controls.Add(tbCodigo2);
		GroupBox4.Controls.Add(tbCodigo1);
		GroupBox4.Controls.Add(btPesquisaLM2);
		GroupBox4.Controls.Add(btPesquisaLM1);
		GroupBox4.Location = new Point(8, 351);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(552, 89);
		GroupBox4.TabIndex = 168;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "GroupBox4";
		lbFabricante.Location = new Point(407, 17);
		lbFabricante.Name = "lbFabricante";
		lbFabricante.Size = new Size(111, 16);
		lbFabricante.TabIndex = 207;
		lbFabricante.Text = "Fabricante";
		lbModelo.Location = new Point(290, 16);
		lbModelo.Name = "lbModelo";
		lbModelo.Size = new Size(111, 16);
		lbModelo.TabIndex = 206;
		lbModelo.Text = "Modelo";
		lbDesc.Location = new Point(87, 16);
		lbDesc.Name = "lbDesc";
		lbDesc.Size = new Size(197, 16);
		lbDesc.TabIndex = 205;
		lbDesc.Text = "Descrição Resumida";
		lbCodigo.Location = new Point(6, 16);
		lbCodigo.Name = "lbCodigo";
		lbCodigo.Size = new Size(75, 16);
		lbCodigo.TabIndex = 204;
		lbCodigo.Text = "Codigo";
		tbFabricante2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante2.Location = new Point(407, 61);
		tbFabricante2.Name = "tbFabricante2";
		tbFabricante2.ReadOnly = true;
		tbFabricante2.Size = new Size(111, 20);
		tbFabricante2.TabIndex = 203;
		tbFabricante1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante1.Location = new Point(407, 36);
		tbFabricante1.Name = "tbFabricante1";
		tbFabricante1.ReadOnly = true;
		tbFabricante1.Size = new Size(111, 20);
		tbFabricante1.TabIndex = 202;
		tbModelo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo2.Location = new Point(290, 61);
		tbModelo2.Name = "tbModelo2";
		tbModelo2.ReadOnly = true;
		tbModelo2.Size = new Size(111, 20);
		tbModelo2.TabIndex = 201;
		tbModelo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo1.Location = new Point(290, 36);
		tbModelo1.Name = "tbModelo1";
		tbModelo1.ReadOnly = true;
		tbModelo1.Size = new Size(111, 20);
		tbModelo1.TabIndex = 200;
		tbDescricaoResum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum2.Location = new Point(87, 61);
		tbDescricaoResum2.Name = "tbDescricaoResum2";
		tbDescricaoResum2.ReadOnly = true;
		tbDescricaoResum2.Size = new Size(197, 20);
		tbDescricaoResum2.TabIndex = 199;
		tbDescricaoResum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum1.Location = new Point(87, 36);
		tbDescricaoResum1.Name = "tbDescricaoResum1";
		tbDescricaoResum1.ReadOnly = true;
		tbDescricaoResum1.Size = new Size(197, 20);
		tbDescricaoResum1.TabIndex = 198;
		tbCodigo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo2.Location = new Point(8, 61);
		tbCodigo2.Name = "tbCodigo2";
		tbCodigo2.ReadOnly = true;
		tbCodigo2.Size = new Size(73, 20);
		tbCodigo2.TabIndex = 197;
		tbCodigo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo1.Location = new Point(8, 36);
		tbCodigo1.Name = "tbCodigo1";
		tbCodigo1.ReadOnly = true;
		tbCodigo1.Size = new Size(73, 20);
		tbCodigo1.TabIndex = 196;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1044, 445);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox4);
		Controls.Add(BTImportaEX);
		Controls.Add(GroupBox2);
		Controls.Add(BTExportaEX);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBoxContatos);
		Controls.Add(GroupBoxModelos);
		MaximizeBox = false;
		MaximumSize = new Size(1500, 2000);
		MinimumSize = new Size(1060, 440);
		Name = "frmGerenciadorContatos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Gerenciador de Contatos";
		GroupBoxModelos.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGModelo).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBoxContatos.ResumeLayout(performLayout: false);
		GroupBoxContatos.PerformLayout();
		((ISupportInitialize)DGContato).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGContatosInseridos).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return gFL9TrXWT3;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		gFL9TrXWT3 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return g5s9a22kDF;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		g5s9a22kDF = WithEventsValue;
	}

	public frmGerenciadorContatos()
	{
		Resize += wTR9Wc20Uk;
		Ucp9rHhj2R = -1;
		RnE99oMK3k = -1;
		SbHzp2bYTy = false;
		nXczTc5nTE = new List<int>();
		if (Geral.ExisteForm("frmGerenciadorContatos") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			bPyrnLxyur();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 651]);
			GroupBoxModelos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 652]);
			lbNomeModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]);
			LbTerminais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 655]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
			GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 192]);
			GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]);
			lbCodigo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1245]);
			lbDesc.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
			lbModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
			lbFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]);
			lbTerminaisModelo.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 659], " ;"));
			lbOrientacao.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1846], " ;"));
			GroupBoxContatos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 653]);
			LbTerminais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 659]);
			lbOrientacaoTerm.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1846], " ;"));
			LbTipo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 660]);
			lbTopografico.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 657]);
			lbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 658]);
			w8dpBZ0kvSD().SetToolTip(BTAdicionaModelo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 661]));
			w8dpBZ0kvSD().SetToolTip(BTEditaModelo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 662]));
			w8dpBZ0kvSD().SetToolTip(BTApagaModelo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 663]));
			w8dpBZ0kvSD().SetToolTip(BTNovo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 664]));
			w8dpBZ0kvSD().SetToolTip(BTAdicionaContato, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 665]));
			w8dpBZ0kvSD().SetToolTip(BTEditaContato, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 666]));
			w8dpBZ0kvSD().SetToolTip(BTApagaContaro, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 667]));
			w8dpBZ0kvSD().SetToolTip(TBT1, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 668]));
			w8dpBZ0kvSD().SetToolTip(TBT2, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 669]));
			w8dpBZ0kvSD().SetToolTip(TBT3, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 670]));
			w8dpBZ0kvSD().SetToolTip(CBTipo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 671]));
			w8dpBZ0kvSD().SetToolTip(CBComportamento, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 672]));
			w8dpBZ0kvSD().SetToolTip(DGContatosInseridos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 673]));
			w8dpBZ0kvSD().SetToolTip(BTImportaEX, Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 916], TBModelo.Text)));
			w8dpBZ0kvSD().SetToolTip(BTExportaEX, Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 917], TBModelo.Text)));
			w8dpBZ0kvSD().SetToolTip(btApagaModelosSemUso, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1843]));
			w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoTopo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
			w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoLayout, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
			w8dpBZ0kvSD().SetToolTip(btPesquisaLM1, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1211]));
			w8dpBZ0kvSD().SetToolTip(btPesquisaLM2, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1211]));
			Correcao.CorrigeModelosDeContatos();
			DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref jgX9zK19sF);
			DataGridView dg = DGModelo;
			clsDispositivo.carregaModelosNoDG(ref dg, jgX9zK19sF);
			DGModelo = dg;
			cDadosLM cDadosLM2 = new cDadosLM();
			EiB9Y3sMeJ = cDadosLM2.CarregaDadosLMMatriz();
			cDadosLM2.fechaConexao();
			CBTipo.Items.Clear();
			CBTipo.Items.Add("NA");
			CBTipo.Items.Add("NF");
			CBTipo.Items.Add("RV");
			CBTipo.Text = "NA";
			CBComportamento.Items.Clear();
			CBComportamento.Items.Add("ST");
			CBComportamento.Items.Add("TE");
			CBComportamento.Items.Add("TD");
			CBComportamento.Items.Add("BI");
			CBComportamento.Items.Add("AM");
			CBComportamento.Text = "ST";
			tbBlocoTopografico.Enabled = false;
			tbBlocoLayout.Enabled = false;
			if (DGModelo.Rows.Count > 0)
			{
				DGModelo.Rows[0].Selected = true;
			}
			clsDispositivo.EncontraModelosUsados(ref nXczTc5nTE);
			mostraModelo();
			mostraContatos();
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			SbHzp2bYTy = true;
			if (DGContato.Rows.Count > 0)
			{
				DGContato.Rows[0].Selected = false;
			}
			dg = DGModelo;
			clsDispositivo.AtualizaColunasDGModelos(ref dg);
			DGModelo = dg;
			dg = DGContato;
			clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliaresMODELO(ref dg);
			DGContato = dg;
			clsDispositivoAuxiliares.VerificaTamanhoContatosAuxiliares();
			marcaUdoDosModelos(nXczTc5nTE);
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	private void ax9r1pEbBP(object P_0, EventArgs P_1)
	{
		TBT2.Enabled = true;
		TBT2.BackColor = Color.White;
		TBT2.ForeColor = Color.Black;
		TBT3.Enabled = true;
		TBT3.BackColor = Color.White;
		TBT3.ForeColor = Color.Black;
		if (Operators.CompareString(CBTipo.Text, "NA", TextCompare: true) == 0)
		{
			TBT3.Text = "";
			TBT3.Enabled = false;
			TBT3.BackColor = Color.Silver;
		}
		if (Operators.CompareString(CBTipo.Text, "NF", TextCompare: true) == 0)
		{
			TBT3.Text = "";
			TBT3.Enabled = false;
			TBT3.BackColor = Color.Silver;
		}
		checked
		{
			if ((Operators.CompareString(CBTipo.Text, "RV", TextCompare: true) == 0) & (Operators.CompareString(TBT3.Text, "", TextCompare: true) == 0))
			{
				if (!(Versioned.IsNumeric(TBT1.Text) & Versioned.IsNumeric(TBT2.Text)))
				{
					TBT3.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
				}
				else if (Operators.CompareString(TBT1.Text, TBT2.Text, TextCompare: true) >= 0)
				{
					TBT3.Text = Conversions.ToString(Conversions.ToInteger(TBT1.Text) + (Conversions.ToInteger(TBT1.Text) - Conversions.ToInteger(TBT2.Text)));
				}
				else
				{
					TBT3.Text = Conversions.ToString(Conversions.ToInteger(TBT2.Text) + (Conversions.ToInteger(TBT2.Text) - Conversions.ToInteger(TBT1.Text)));
				}
			}
		}
	}

	private void kKYrl9Im2L(object P_0, DataGridViewCellEventArgs P_1)
	{
		TBModelo.BackColor = Color.White;
		TBModelo.ForeColor = Color.Black;
		mostraModelo();
		foreach (DataGridViewRow item in (IEnumerable)DGContato.Rows)
		{
			item.Selected = false;
		}
	}

	public void mostraModelo()
	{
		checked
		{
			int num = DGModelo.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGModelo.Rows[i].Selected)
				{
					Ucp9rHhj2R = Conversions.ToInteger(DGModelo.Rows[i].Cells[0].Value);
					TBModelo.Text = Conversions.ToString(DGModelo.Rows[i].Cells[1].Value);
					i3dr5Qwhxi(Conversions.ToInteger(DGModelo.Rows[i].Cells[2].Value), 1);
					i3dr5Qwhxi(Conversions.ToInteger(DGModelo.Rows[i].Cells[3].Value), 2);
					tbBlocoTopografico.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
					{
						tbBlocoTopografico.BackColor = Color.White;
					}
					tbBlocoTopografico.Text = DGModelo.Rows[i].Cells[5].Value.ToString().ToUpper().Trim();
					tbBlocoLayout.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
					{
						tbBlocoLayout.BackColor = Color.White;
					}
					tbBlocoLayout.Text = DGModelo.Rows[i].Cells[6].Value.ToString().ToUpper().Trim();
					TBTerminais.Text = Conversions.ToString(DGModelo.Rows[i].Cells[9].Value);
					tbOrientacao.Text = Conversions.ToString(DGModelo.Rows[i].Cells[10].Value);
					int iIndiceSelecionado = Conversions.ToInteger(DGModelo.Rows[i].Cells[0].Value);
					UWuzWyqRcA = new Declaracoes2.StructureContatosAuxiliares[1];
					DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref UWuzWyqRcA);
					DataGridView DGContatos = DGContato;
					clsDispositivoAuxiliares.carregaContatosNoDG(ref DGContatos, UWuzWyqRcA);
					DGContato = DGContatos;
					TBT1.Text = "";
					TBT2.Text = "";
					TBT3.Text = "";
					tbOrientacaoTerminais.Text = "";
					CBTipo.Text = "NA";
					CBComportamento.Text = "ST";
					mostraContatos();
				}
			}
			if (DGContato.RowCount == 0)
			{
				DataGridView DGContatos = DGContatosInseridos;
				clsDispositivoAuxiliares.carregaDispPrincipalDoModeloInserido(ref DGContatos, Ucp9rHhj2R);
				DGContatosInseridos = DGContatos;
			}
			w8dpBZ0kvSD().SetToolTip(BTImportaEX, Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 916], TBModelo.Text)));
			w8dpBZ0kvSD().SetToolTip(BTExportaEX, Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 917], TBModelo.Text)));
		}
	}

	private void i3dr5Qwhxi(int P_0, int P_1)
	{
		if (P_1 == 1)
		{
			tbCodigo1.Text = Conversions.ToString(0);
			tbDescricaoResum1.Text = "";
			tbModelo1.Text = "";
			tbFabricante1.Text = "";
		}
		else if (P_1 == 2)
		{
			tbCodigo2.Text = Conversions.ToString(0);
			tbDescricaoResum2.Text = "";
			tbModelo2.Text = "";
			tbFabricante2.Text = "";
		}
		int num = Information.UBound(EiB9Y3sMeJ);
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (EiB9Y3sMeJ[num2].CodigoInterno == P_0)
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return;
		}
		switch (P_1)
		{
		case 1:
			tbCodigo1.Text = Conversions.ToString(P_0);
			tbDescricaoResum1.Text = EiB9Y3sMeJ[num2].DescricaoResumida;
			tbModelo1.Text = EiB9Y3sMeJ[num2].Modelo;
			tbFabricante1.Text = EiB9Y3sMeJ[num2].Fabricante;
			break;
		case 2:
			tbCodigo2.Text = Conversions.ToString(P_0);
			tbDescricaoResum2.Text = EiB9Y3sMeJ[num2].DescricaoResumida;
			tbModelo2.Text = EiB9Y3sMeJ[num2].Modelo;
			tbFabricante2.Text = EiB9Y3sMeJ[num2].Fabricante;
			break;
		}
	}

	public void marcaUdoDosModelos(List<int> lModelosUsados)
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.LightGreen;
		int num = -1;
		checked
		{
			int num2 = DGModelo.Rows.Count - 1;
			for (int i = num2; i >= 0; i += -1)
			{
				if (DGModelo.Rows[i].Selected)
				{
					num = Conversions.ToInteger(DGModelo.Rows[i].Cells[0].Value);
				}
			}
			int num3 = DGModelo.Rows.Count - 1;
			for (int j = num3; j >= 0; j += -1)
			{
				if (!lModelosUsados.Contains(Conversions.ToInteger(DGModelo.Rows[j].Cells[0].Value)))
				{
					DGModelo.Rows[j].Cells[0].Style = dataGridViewCellStyle2;
				}
				else
				{
					DGModelo.Rows[j].Cells[0].Style = dataGridViewCellStyle;
				}
			}
			int num4 = DGModelo.Rows.Count - 1;
			int num5 = num4;
			while (true)
			{
				if (num5 >= 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.CompareObjectEqual(num, DGModelo.Rows[num5].Cells[0].Value, TextCompare: true), true, TextCompare: true))
					{
						break;
					}
					num5 += -1;
					continue;
				}
				return;
			}
			DGModelo.Rows[num5].Selected = true;
		}
	}

	private void QO6r046UrS(object P_0, EventArgs P_1)
	{
		ModelosBotoesVisiveis(bOpcao: false);
		int iLM = 0;
		int iLM2 = 0;
		if (Operators.CompareString(tbCodigo1.Text.Trim(), "", TextCompare: true) != 0)
		{
			iLM = Conversions.ToInteger(tbCodigo1.Text);
		}
		if (Operators.CompareString(tbCodigo2.Text.Trim(), "", TextCompare: true) != 0)
		{
			iLM2 = Conversions.ToInteger(tbCodigo2.Text);
		}
		TBModelo.Text = TBModelo.Text.ToString().Trim();
		checked
		{
			int num = Information.UBound(jgX9zK19sF) - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					TBModelo.BackColor = Color.White;
					TBModelo.ForeColor = Color.Black;
					if (!Operators.ConditionalCompareObjectEqual(DGModelo.Rows[num2].Cells[1].Value, TBModelo.Text.ToString(), TextCompare: true))
					{
						num2++;
						continue;
					}
					TBModelo.BackColor = Color.Red;
					TBModelo.ForeColor = Color.White;
					break;
				}
				int num3 = 0;
				int num4 = DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref jgX9zK19sF);
				num3 = Information.UBound(jgX9zK19sF) + 1;
				ref Declaracoes2.MModelosDeContatos[] reference = ref jgX9zK19sF;
				reference = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(reference, new Declaracoes2.MModelosDeContatos[num3 + 1]);
				if (DGModelo.RowCount != 0)
				{
					int num5 = DGModelo.Rows.Count - 1;
					for (int i = 0; i <= num5; i++)
					{
						if (Conversions.ToInteger(DGModelo.Rows[i].Cells[0].Value.ToString()) >= num4)
						{
							num4 = Conversions.ToInteger(DGModelo.Rows[i].Cells[0].Value.ToString()) + 1;
						}
					}
				}
				clsDispositivo.ApagaUmModelo(num4);
				if (num4 == 0)
				{
					num4 = 1;
				}
				jgX9zK19sF[num3].iIndiceModelo = num4;
				jgX9zK19sF[num3].sNomeModelo = TBModelo.Text.ToString();
				jgX9zK19sF[num3].iLM1 = iLM;
				jgX9zK19sF[num3].iLM2 = iLM2;
				jgX9zK19sF[num3].sBlocoTopografico = tbBlocoTopografico.Text.ToString();
				jgX9zK19sF[num3].sBlocoLayout = tbBlocoLayout.Text.ToString();
				jgX9zK19sF[num3].sTerminaisDoDispositivo = TBTerminais.Text;
				jgX9zK19sF[num3].sOrientacao = tbOrientacao.Text;
				DicionarioContatos.GravaOsModelosDeDispositivosDeDicionario(ref jgX9zK19sF);
				DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref jgX9zK19sF);
				DataGridView dg = DGModelo;
				clsDispositivo.carregaModelosNoDG(ref dg, jgX9zK19sF);
				DGModelo = dg;
				if (DGModelo.Rows.Count > 0)
				{
					DGModelo.Rows[DGModelo.Rows.Count - 1].Selected = true;
				}
				if (DGModelo.Rows.Count > 0)
				{
					int num6 = DGModelo.Rows.Count - 1;
					DGModelo.Rows[num6].Selected = true;
					DGModelo.FirstDisplayedScrollingRowIndex = num6;
				}
				mostraModelo();
				dg = DGContatosInseridos;
				clsDispositivoAuxiliares.carregaContatosAuxiliaresDoModeloInserido(ref dg, Ucp9rHhj2R, RnE99oMK3k);
				DGContatosInseridos = dg;
				break;
			}
			ModelosBotoesVisiveis(bOpcao: true);
			marcaUdoDosModelos(nXczTc5nTE);
		}
	}

	private void ifWrRgr7pu(object P_0, EventArgs P_1)
	{
		b4urmaYtwg();
		marcaUdoDosModelos(nXczTc5nTE);
	}

	private void b4urmaYtwg()
	{
		ModelosBotoesVisiveis(bOpcao: false);
		checked
		{
			if (DGModelo.Rows.Count != 0)
			{
				int num = -1;
				string text = "";
				string sTerm = "";
				bool flag = false;
				List<string> lHandlesOcultos = new List<string>();
				TBModelo.Text = TBModelo.Text.ToString().Trim();
				int num2 = DGModelo.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (DGModelo.Rows[i].Selected && Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(DGModelo.Rows[i].Cells[1].Value, TBModelo.Text, TextCompare: true), Operators.CompareString(DGModelo.Rows[i].Cells[2].Value.ToString(), tbCodigo1.Text.ToString(), TextCompare: true) != 0), Operators.CompareString(DGModelo.Rows[i].Cells[3].Value.ToString(), tbCodigo2.Text.ToString(), TextCompare: true) != 0), Operators.CompareObjectNotEqual(DGModelo.Rows[i].Cells[5].Value, tbBlocoTopografico.Text, TextCompare: true)), Operators.CompareObjectNotEqual(DGModelo.Rows[i].Cells[6].Value, tbBlocoLayout.Text, TextCompare: true)), Operators.CompareObjectNotEqual(DGModelo.Rows[i].Cells[9].Value, TBTerminais.Text, TextCompare: true)), Operators.CompareObjectNotEqual(DGModelo.Rows[i].Cells[10].Value, tbOrientacao.Text, TextCompare: true))))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					int num3 = DGModelo.Rows.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						if (DGModelo.Rows[j].Selected)
						{
							DGModelo.Rows[j].Cells[1].Value = TBModelo.Text;
							DGModelo.Rows[j].Cells[2].Value = tbCodigo1.Text.ToString();
							DGModelo.Rows[j].Cells[3].Value = tbCodigo2.Text.ToString();
							DGModelo.Rows[j].Cells[5].Value = tbBlocoTopografico.Text;
							DGModelo.Rows[j].Cells[6].Value = tbBlocoLayout.Text;
							DGModelo.Rows[j].Cells[7].Value = "";
							DGModelo.Rows[j].Cells[9].Value = TBTerminais.Text;
							DGModelo.Rows[j].Cells[10].Value = tbOrientacao.Text;
							num = Conversions.ToInteger(DGModelo.Rows[j].Cells[0].Value);
							text = TBModelo.Text;
							sTerm = TBTerminais.Text;
							break;
						}
					}
					clsDispositivo.ModeloBobina(ref lHandlesOcultos);
					jgX9zK19sF = new Declaracoes2.MModelosDeContatos[1];
					int num4 = DGModelo.Rows.Count - 1;
					for (int k = 0; k <= num4; k++)
					{
						int num5 = Information.UBound(jgX9zK19sF) + 1;
						ref Declaracoes2.MModelosDeContatos[] reference = ref jgX9zK19sF;
						reference = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(reference, new Declaracoes2.MModelosDeContatos[num5 + 1]);
						jgX9zK19sF[num5].iIndiceModelo = Conversions.ToInteger(DGModelo.Rows[k].Cells[0].Value);
						jgX9zK19sF[num5].sNomeModelo = Conversions.ToString(DGModelo.Rows[k].Cells[1].Value);
						if (Operators.CompareString(DGModelo.Rows[k].Cells[2].Value.ToString(), "0", TextCompare: true) != 0)
						{
							jgX9zK19sF[num5].iLM1 = Conversions.ToInteger(DGModelo.Rows[k].Cells[2].Value);
						}
						if (Operators.CompareString(DGModelo.Rows[k].Cells[3].Value.ToString(), "0", TextCompare: true) != 0)
						{
							jgX9zK19sF[num5].iLM2 = Conversions.ToInteger(DGModelo.Rows[k].Cells[3].Value);
						}
						jgX9zK19sF[num5].sBlocoTopografico = Conversions.ToString(DGModelo.Rows[k].Cells[5].Value);
						jgX9zK19sF[num5].sBlocoLayout = Conversions.ToString(DGModelo.Rows[k].Cells[6].Value);
						jgX9zK19sF[num5].sTerminaisDoDispositivo = Conversions.ToString(DGModelo.Rows[k].Cells[9].Value);
						jgX9zK19sF[num5].sOrientacao = Conversions.ToString(DGModelo.Rows[k].Cells[10].Value);
					}
					DicionarioContatos.GravaOsModelosDeDispositivosDeDicionario(ref jgX9zK19sF);
					DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref jgX9zK19sF);
					DataGridView dg = DGModelo;
					clsDispositivo.carregaModelosNoDG(ref dg, jgX9zK19sF);
					DGModelo = dg;
					clsDispositivo.AtualizaOsDispositivosPrincipais(num, text, sTerm, tbBlocoTopografico.Text, tbBlocoLayout.Text, Conversions.ToInteger(tbCodigo1.Text), Conversions.ToInteger(tbCodigo2.Text));
					clsDispositivo.AtualizaOsModelosDosPrincipais(num, text);
					int num6 = DGModelo.Rows.Count - 1;
					for (int l = 0; l <= num6; l++)
					{
						if (Conversions.ToInteger(DGModelo.Rows[l].Cells[0].Value) == num)
						{
							DGModelo.Rows[l].Selected = true;
							DGModelo.CurrentCell = DGModelo.Rows[l].Cells[0];
							break;
						}
					}
					clsUtilitarios.EditaDipAuxPainelModeloFabricante();
					clsDispositivo.OcultaModeloBobinaEditada(ref lHandlesOcultos);
				}
			}
			ModelosBotoesVisiveis(bOpcao: true);
		}
	}

	private void yMZrX9wFN9(object P_0, EventArgs P_1)
	{
		checked
		{
			if (DGModelo.Rows.Count != 0)
			{
				ModelosBotoesVisiveis(bOpcao: false);
				int iMaxIndice = 0;
				MsgBoxResult msgBoxResult = MsgBoxResult.No;
				int num = -1;
				int num2 = 0;
				int num3 = DGModelo.Rows.Count - 1;
				for (int i = num3; i >= 0; i += -1)
				{
					if (DGModelo.Rows[i].Selected)
					{
						num = i;
						num2 = Conversions.ToInteger(DGModelo.Rows[i].Cells[0].Value);
						break;
					}
				}
				msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 674], DGModelo.Rows[num].Cells[1].Value), " ?"), MsgBoxStyle.YesNo, "Elétron");
				if (msgBoxResult != MsgBoxResult.No)
				{
					DGContato.Rows.Clear();
					TBModelo.BackColor = Color.White;
					TBModelo.ForeColor = Color.Black;
					if (num != -1)
					{
						DGModelo.Rows.RemoveAt(num);
						clsDispositivo.ApagaUmModelo(num2);
					}
					UWuzWyqRcA = new Declaracoes2.StructureContatosAuxiliares[1];
					DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(num2, ref iMaxIndice, UWuzWyqRcA);
					jgX9zK19sF = new Declaracoes2.MModelosDeContatos[1];
					int num4 = DGModelo.Rows.Count - 1;
					for (int j = 0; j <= num4; j++)
					{
						int num5 = Information.UBound(jgX9zK19sF) + 1;
						ref Declaracoes2.MModelosDeContatos[] reference = ref jgX9zK19sF;
						reference = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(reference, new Declaracoes2.MModelosDeContatos[num5 + 1]);
						jgX9zK19sF[num5].iIndiceModelo = Conversions.ToInteger(DGModelo.Rows[j].Cells[0].Value);
						jgX9zK19sF[num5].sNomeModelo = Conversions.ToString(DGModelo.Rows[j].Cells[1].Value);
						jgX9zK19sF[num5].iLM1 = Conversions.ToInteger(DGModelo.Rows[j].Cells[2].Value);
						jgX9zK19sF[num5].iLM2 = Conversions.ToInteger(DGModelo.Rows[j].Cells[3].Value);
						jgX9zK19sF[num5].sBlocoTopografico = Conversions.ToString(DGModelo.Rows[j].Cells[5].Value);
						jgX9zK19sF[num5].sBlocoLayout = Conversions.ToString(DGModelo.Rows[j].Cells[6].Value);
						jgX9zK19sF[num5].sTerminaisDoDispositivo = Conversions.ToString(DGModelo.Rows[j].Cells[9].Value);
						jgX9zK19sF[num5].sOrientacao = Conversions.ToString(DGModelo.Rows[j].Cells[10].Value);
					}
					DicionarioContatos.GravaOsModelosDeDispositivosDeDicionario(ref jgX9zK19sF);
					DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref jgX9zK19sF);
					DataGridView dg = DGModelo;
					clsDispositivo.carregaModelosNoDG(ref dg, jgX9zK19sF);
					DGModelo = dg;
					if (DGModelo.Rows.Count > 0)
					{
						int num6 = DGModelo.Rows.Count - 1;
						DGModelo.Rows[num6].Selected = true;
						DGModelo.FirstDisplayedScrollingRowIndex = num6;
					}
					mostraModelo();
					dg = DGContatosInseridos;
					clsDispositivoAuxiliares.carregaContatosAuxiliaresDoModeloInserido(ref dg, Ucp9rHhj2R, RnE99oMK3k);
					DGContatosInseridos = dg;
				}
			}
			int num7 = DGModelo.Rows.Count - 1;
			for (int k = 0; k <= num7; k++)
			{
				DGModelo.Rows[k].Selected = false;
			}
			ModelosBotoesVisiveis(bOpcao: true);
			marcaUdoDosModelos(nXczTc5nTE);
		}
	}

	private void oBBrUDMvuE(object P_0, EventArgs P_1)
	{
		ModelosBotoesVisiveis(bOpcao: false);
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1842]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		checked
		{
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1283]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
				if (msgBoxResult != MsgBoxResult.No)
				{
					List<int> list = new List<int>();
					int num = DGModelo.Rows.Count - 1;
					for (int i = num; i >= 0; i += -1)
					{
						if (DGModelo.Rows[i].Cells[0].Style.BackColor == Color.LightGreen)
						{
							list.Add(Conversions.ToInteger(DGModelo.Rows[i].Cells[0].Value));
						}
					}
					DGContato.Rows.Clear();
					DGContato.Columns.Clear();
					int iMaxIndice = 0;
					foreach (int item in list)
					{
						UWuzWyqRcA = new Declaracoes2.StructureContatosAuxiliares[1];
						DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(item, ref iMaxIndice, UWuzWyqRcA);
						int num2 = DGModelo.Rows.Count - 1;
						for (int j = num2; j >= 0; j += -1)
						{
							if (Operators.ConditionalCompareObjectEqual(DGModelo.Rows[j].Cells[0].Value, item, TextCompare: true))
							{
								DGModelo.Rows.RemoveAt(j);
								break;
							}
						}
					}
					jgX9zK19sF = new Declaracoes2.MModelosDeContatos[1];
					int num3 = DGModelo.Rows.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						int num4 = Information.UBound(jgX9zK19sF) + 1;
						ref Declaracoes2.MModelosDeContatos[] reference = ref jgX9zK19sF;
						reference = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(reference, new Declaracoes2.MModelosDeContatos[num4 + 1]);
						jgX9zK19sF[num4].iIndiceModelo = Conversions.ToInteger(DGModelo.Rows[k].Cells[0].Value);
						jgX9zK19sF[num4].sNomeModelo = Conversions.ToString(DGModelo.Rows[k].Cells[1].Value);
						jgX9zK19sF[num4].iLM1 = Conversions.ToInteger(DGModelo.Rows[k].Cells[2].Value);
						jgX9zK19sF[num4].iLM2 = Conversions.ToInteger(DGModelo.Rows[k].Cells[3].Value);
						jgX9zK19sF[num4].sBlocoTopografico = Conversions.ToString(DGModelo.Rows[k].Cells[5].Value);
						jgX9zK19sF[num4].sBlocoLayout = Conversions.ToString(DGModelo.Rows[k].Cells[6].Value);
						jgX9zK19sF[num4].sTerminaisDoDispositivo = Conversions.ToString(DGModelo.Rows[k].Cells[9].Value);
						jgX9zK19sF[num4].sOrientacao = Conversions.ToString(DGModelo.Rows[k].Cells[10].Value);
					}
					DicionarioContatos.GravaOsModelosDeDispositivosDeDicionario(ref jgX9zK19sF);
					DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref jgX9zK19sF);
					DataGridView dg = DGModelo;
					clsDispositivo.carregaModelosNoDG(ref dg, jgX9zK19sF);
					DGModelo = dg;
					if (DGModelo.Rows.Count > 0)
					{
						int num5 = DGModelo.Rows.Count - 1;
						DGModelo.Rows[num5].Selected = true;
						DGModelo.FirstDisplayedScrollingRowIndex = num5;
					}
					mostraModelo();
					dg = DGContatosInseridos;
					clsDispositivoAuxiliares.carregaContatosAuxiliaresDoModeloInserido(ref dg, Ucp9rHhj2R, RnE99oMK3k);
					DGContatosInseridos = dg;
				}
			}
			int num6 = DGModelo.Rows.Count - 1;
			for (int l = 0; l <= num6; l++)
			{
				DGModelo.Rows[l].Selected = false;
			}
			ModelosBotoesVisiveis(bOpcao: true);
			marcaUdoDosModelos(nXczTc5nTE);
		}
	}

	public void mostraContatos()
	{
		checked
		{
			int num = DGContato.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!DGContato.Rows[i].Selected)
				{
				}
			}
			int num2 = DGContato.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (DGContato.Rows[j].Selected)
				{
					RnE99oMK3k = Conversions.ToInteger(DGContato.Rows[j].Cells[0].Value);
					TBT1.Text = Conversions.ToString(DGContato.Rows[j].Cells[1].Value);
					TBT2.Text = Conversions.ToString(DGContato.Rows[j].Cells[2].Value);
					TBT3.Text = Conversions.ToString(DGContato.Rows[j].Cells[3].Value);
					CBTipo.Text = Conversions.ToString(DGContato.Rows[j].Cells[5].Value);
					CBComportamento.Text = Conversions.ToString(DGContato.Rows[j].Cells[6].Value);
					break;
				}
			}
			DGContatosInseridos.Rows.Clear();
			DGContatosInseridos.Columns.Clear();
		}
	}

	private void HG3ryHFjrQ(object P_0, EventArgs P_1)
	{
		CalculaProximoContato();
		checked
		{
			int num = DGContato.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGContato.Rows[i].Selected)
				{
					DGContato.Rows[i].Selected = false;
					DGContatosInseridos.Rows.Clear();
					DGContatosInseridos.Columns.Clear();
				}
			}
		}
	}

	public void CalculaProximoContato()
	{
		checked
		{
			int num = DGContato.Rows.Count - 1;
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			if (DGContato.Rows.Count <= 1)
			{
				num = 0;
			}
			else
			{
				text = Conversions.ToString(DGContato.Rows[num].Cells[1].Value);
				if (num > 0)
				{
					text2 = Conversions.ToString(DGContato.Rows[num - 1].Cells[1].Value);
				}
				text3 = Conversions.ToString(DGContato.Rows[num].Cells[2].Value);
				if (num > 0)
				{
					text4 = Conversions.ToString(DGContato.Rows[num - 1].Cells[2].Value);
				}
				text5 = Conversions.ToString(DGContato.Rows[num].Cells[3].Value);
				if (num > 0)
				{
					text6 = Conversions.ToString(DGContato.Rows[num - 1].Cells[3].Value);
				}
				if (Operators.ConditionalCompareObjectEqual(DGContato.Rows[num].Cells[5].Value, DGContato.Rows[num - 1].Cells[5].Value, TextCompare: true))
				{
					tbOrientacaoTerminais.Text = Conversions.ToString(DGContato.Rows[num].Cells[4].Value);
					CBTipo.Text = Conversions.ToString(DGContato.Rows[num].Cells[5].Value);
					CBComportamento.Text = Conversions.ToString(DGContato.Rows[num].Cells[6].Value);
				}
			}
			if (num <= 0)
			{
				TBT1.Text = "";
				TBT2.Text = "";
				TBT3.Text = "";
				tbOrientacaoTerminais.Text = "";
			}
			else
			{
				if (!(Versioned.IsNumeric(text) & Versioned.IsNumeric(text2)))
				{
					TBT1.Text = "";
				}
				else
				{
					TBT1.Text = Conversions.ToString(Conversions.ToInteger(text) + (Conversions.ToInteger(text) - Conversions.ToInteger(text2)));
				}
				if (!(Versioned.IsNumeric(text3) & Versioned.IsNumeric(text4)))
				{
					TBT2.Text = "";
				}
				else
				{
					TBT2.Text = Conversions.ToString(Conversions.ToInteger(text3) + (Conversions.ToInteger(text3) - Conversions.ToInteger(text4)));
				}
				if (!(Versioned.IsNumeric(text5) & Versioned.IsNumeric(text6)))
				{
					TBT3.Text = "";
				}
				else
				{
					TBT3.Text = Conversions.ToString(Conversions.ToInteger(text5) + (Conversions.ToInteger(text5) - Conversions.ToInteger(text6)));
				}
			}
			if (!TBT1.Enabled)
			{
				TBT1.Text = "";
			}
			if (!TBT2.Enabled)
			{
				TBT2.Text = "";
			}
			if (!TBT3.Enabled)
			{
				TBT3.Text = "";
			}
			if (TBT1.Enabled && Operators.CompareString(TBT1.Text, "", TextCompare: true) == 0)
			{
				TBT1.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			}
			if (TBT2.Enabled && Operators.CompareString(TBT2.Text, "", TextCompare: true) == 0)
			{
				TBT2.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			}
			if (TBT3.Enabled && Operators.CompareString(TBT3.Text, "", TextCompare: true) == 0)
			{
				TBT3.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			}
		}
	}

	private void dZHrg3PtFK(object P_0, EventArgs P_1)
	{
		if (clsDispositivoAuxiliares.CorrigirModelo(Ucp9rHhj2R))
		{
			clsDispositivoAuxiliares.CorrigeAlturaDosModelos(Ucp9rHhj2R);
		}
		ContatosBotoesVisiveis(bOpcao: false);
		if (DeclaracoesGeral.Conf.Norma != 1)
		{
		}
		int num = 1;
		int iMaxIndice = 1;
		checked
		{
			int num2 = DGContato.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				iMaxIndice = Conversions.ToInteger(Operators.AddObject(DGContato.Rows[i].Cells[0].Value, 1));
				num = iMaxIndice;
			}
			Declaracoes2.StructureFuncoesDispositivo[] mFuncoes = null;
			clsDispositivoAuxiliares.GuardaAsFuncoesDosModelos(ref mFuncoes);
			DataGridView DGContatos;
			if (DGContato.Rows.Count == 0)
			{
				DGContato.Columns.Add("IndiceModelo", "#");
				DGContato.Columns.Add("T1", "T1");
				DGContato.Columns.Add("T2", "T2");
				DGContato.Columns.Add("T3", "T3");
				DGContato.Columns.Add("Orientaçao", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]));
				DGContato.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 995]));
				DGContato.Columns.Add("Comportamento", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 996]));
				DGContato.Columns.Add("Reserva1", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1049], "1")));
				DGContato.Columns.Add("Reserva2", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1049], "2")));
				DGContato.Columns.Add("Handle", "Handle");
				DGContatos = DGContato;
				clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliaresMODELO(ref DGContatos);
				DGContato = DGContatos;
			}
			if (Operators.CompareString(TBT1.Text, "", TextCompare: true) == 0)
			{
				TBT1.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			}
			if (Operators.CompareString(TBT2.Text, "", TextCompare: true) == 0)
			{
				TBT2.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			}
			if ((Operators.CompareString(CBTipo.Text, "RV", TextCompare: true) == 0) & (Operators.CompareString(TBT3.Text, "", TextCompare: true) == 0))
			{
				TBT3.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			}
			DGContato.Rows.Add(num, TBT1.Text, TBT2.Text, TBT3.Text, tbOrientacaoTerminais.Text, CBTipo.Text, CBComportamento.Text, "", "");
			clsDispositivo.carregaMatrizContatos(DGContato, ref UWuzWyqRcA);
			DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(Ucp9rHhj2R, ref iMaxIndice, UWuzWyqRcA);
			clsDispositivo.ApagaOsContatoAuxiliarDoModelo(Ucp9rHhj2R);
			clsDispositivo.ReInsereContatosModelo(UWuzWyqRcA, Ucp9rHhj2R);
			if (DGContato.Rows.Count > 0)
			{
				int num3 = DGContato.Rows.Count - 1;
				DGContato.Rows[num3].Selected = true;
				DGContato.FirstDisplayedScrollingRowIndex = num3;
			}
			DGContatos = DGContato;
			clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliaresMODELO(ref DGContatos);
			DGContato = DGContatos;
			CalculaProximoContato();
			Correcao.CorrigeContatosAux(Ucp9rHhj2R);
			ContatosBotoesVisiveis(bOpcao: true);
			DGContatos = DGContato;
			clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliaresMODELO(ref DGContatos);
			DGContato = DGContatos;
			clsDispositivoAuxiliares.EscreveAsFuncoesDosModelos(ref mFuncoes);
		}
	}

	private void NHArAosvEZ(object P_0, EventArgs P_1)
	{
		checked
		{
			if (DGContato.Rows.Count != 0)
			{
				Declaracoes2.StructureFuncoesDispositivo[] mFuncoes = null;
				clsDispositivoAuxiliares.GuardaAsFuncoesDosModelos(ref mFuncoes);
				if (clsDispositivoAuxiliares.CorrigirModelo(Ucp9rHhj2R))
				{
					clsDispositivoAuxiliares.CorrigeAlturaDosModelos(Ucp9rHhj2R);
				}
				ContatosBotoesVisiveis(bOpcao: false);
				if (Operators.CompareString(TBT1.Text.Trim(), "", TextCompare: true) == 0)
				{
					TBT1.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
				}
				if (Operators.CompareString(TBT2.Text.Trim(), "", TextCompare: true) == 0)
				{
					TBT2.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
				}
				if (Operators.CompareString(TBT3.Text.Trim(), "", TextCompare: true) == 0)
				{
					TBT3.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
				}
				if (Operators.CompareString(CBTipo.Text, "RV", TextCompare: true) != 0)
				{
					TBT3.Text = "";
				}
				bool flag = true;
				int iMaxIndice = 0;
				int iIndexSel = 0;
				string tipoDoContato = Conversions.ToString(0);
				string left = CBTipo.Text;
				if (Operators.CompareString(left, "NA", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "NF", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "RV", TextCompare: true) == 0)
						{
							tipoDoContato = Conversions.ToString(3);
						}
					}
					else
					{
						tipoDoContato = Conversions.ToString(2);
					}
				}
				else
				{
					tipoDoContato = Conversions.ToString(1);
				}
				int num = DGContato.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!DGContato.Rows[i].Selected)
					{
						continue;
					}
					if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(DGContato.Rows[i].Cells[5].Value, CBTipo.Text, TextCompare: true), Operators.CompareObjectEqual(DGContato.Rows[i].Cells[6].Value, CBComportamento.Text, TextCompare: true))) && DGContatosInseridos.Rows.Count != 0 && !Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DGContato.Rows[i].Cells[5].Value, "RV", TextCompare: true), Operators.CompareString(CBTipo.Text, "RV", TextCompare: true) == 0)))
					{
						bool flag2 = true;
						int num2 = DGContatosInseridos.Rows.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							string left2 = Strings.Mid(Conversions.ToString(DGContatosInseridos.Rows[j].Cells[2].Value), 5, 2);
							if (Operators.CompareString(left2, CBTipo.Text, TextCompare: true) != 0)
							{
								flag2 = false;
								flag = false;
								break;
							}
						}
						if (!flag2)
						{
							flag = false;
							break;
						}
					}
					DGContato.FirstDisplayedScrollingRowIndex = i;
					iIndexSel = i;
					break;
				}
				int num3 = DGContato.Rows.Count - 1;
				int num4 = num3;
				while (true)
				{
					if (num4 >= 0)
					{
						if (DGContato.Rows[num4].Selected)
						{
							break;
						}
						num4 += -1;
						continue;
					}
					return;
				}
				if (!flag)
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 914]), MsgBoxStyle.Information);
				}
				else
				{
					bool flag3 = false;
					if (Operators.ConditionalCompareObjectNotEqual(DGContato.SelectedRows[0].Cells[1].Value, TBT1.Text, TextCompare: true))
					{
						DGContato.SelectedRows[0].Cells[1].Value = TBT1.Text;
						flag3 = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGContato.SelectedRows[0].Cells[2].Value, TBT2.Text, TextCompare: true))
					{
						DGContato.SelectedRows[0].Cells[2].Value = TBT2.Text;
						flag3 = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGContato.SelectedRows[0].Cells[3].Value, TBT3.Text, TextCompare: true))
					{
						DGContato.SelectedRows[0].Cells[3].Value = TBT3.Text;
						flag3 = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGContato.SelectedRows[0].Cells[4].Value, tbOrientacaoTerminais.Text, TextCompare: true))
					{
						DGContato.SelectedRows[0].Cells[4].Value = tbOrientacaoTerminais.Text;
						flag3 = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGContato.SelectedRows[0].Cells[5].Value, CBTipo.Text, TextCompare: true))
					{
						flag3 = true;
					}
					if (!flag3)
					{
						goto IL_03da;
					}
					DGContato.SelectedRows[0].Cells[5].Value = CBTipo.Text;
					clsDispositivo.carregaMatrizContatos(DGContato, ref UWuzWyqRcA);
					AtualizaContatosModelo(Ucp9rHhj2R, iMaxIndice, iIndexSel, tipoDoContato, UWuzWyqRcA);
				}
				clsDispositivoAuxiliares.EscreveAsFuncoesDosModelos(ref mFuncoes);
			}
			goto IL_03da;
		}
		IL_03da:
		ContatosBotoesVisiveis(bOpcao: true);
	}

	public void AtualizaContatosModelo(int indexModelo, int iMaxIndice, int iIndexSel, string TipoDoContato, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS)
	{
		DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(indexModelo, ref iMaxIndice, mCONTATOS);
		checked
		{
			int index = iIndexSel + 1;
			clsDispositivo.EditaContatos(mCONTATOS, indexModelo, index);
			DataGridView DGContatosInseridos = this.DGContatosInseridos;
			clsDispositivoAuxiliares.carregaContatosAuxiliaresDoModeloInserido(ref DGContatosInseridos, indexModelo, RnE99oMK3k);
			this.DGContatosInseridos = DGContatosInseridos;
			if (this.DGContatosInseridos.Rows.Count > 0)
			{
				int num = this.DGContatosInseridos.Rows.Count - 1;
				for (int i = num; i >= 0; i += -1)
				{
					string sHandle = this.DGContatosInseridos.Rows[i].Cells[3].Value.ToString();
					clsDispositivoAuxiliares.AtualizaOsTerminaisAuxiliares(sHandle, CBTipo.Text, TBT1.Text, TBT2.Text, TBT3.Text, Conversions.ToInteger(TipoDoContato));
				}
			}
			clsDispositivo.ApagaOsContatoAuxiliarDoModelo(indexModelo);
			clsDispositivo.ReInsereContatosModelo(mCONTATOS, indexModelo);
			Correcao.CorrigeBlocosContatosAux();
			clsDispositivoAuxiliares.SincronizaContatos(indexModelo);
			DGContatosInseridos = DGContato;
			clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliaresMODELO(ref DGContatosInseridos);
			DGContato = DGContatosInseridos;
		}
	}

	private void OpfrsXSTAb(object P_0, EventArgs P_1)
	{
		if (clsDispositivoAuxiliares.CorrigirModelo(Ucp9rHhj2R))
		{
			clsDispositivoAuxiliares.CorrigeAlturaDosModelos(Ucp9rHhj2R);
		}
		Declaracoes2.StructureFuncoesDispositivo[] mFuncoes = null;
		checked
		{
			if (DGContato.Rows.Count != 0)
			{
				clsDispositivoAuxiliares.GuardaAsFuncoesDosModelos(ref mFuncoes);
				ContatosBotoesVisiveis(bOpcao: false);
				bool flag = false;
				int num = -1;
				int iMaxIndice = 0;
				int num2 = DGContato.Rows.Count - 1;
				for (int i = num2; i >= 0; i += -1)
				{
					if (DGContato.Rows[i].Selected)
					{
						RnE99oMK3k = Conversions.ToInteger(DGContato.Rows[i].Cells[0].Value);
						num = i;
						if (i != DGContato.Rows.Count - 1)
						{
							flag = true;
						}
						break;
					}
				}
				if (num != -1)
				{
					DGContato.Rows.RemoveAt(num);
				}
				clsDispositivo.carregaMatrizContatos(DGContato, ref UWuzWyqRcA);
				int num3 = DGContato.Rows.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					iMaxIndice = Conversions.ToInteger(DGContato.Rows[j].Cells[0].Value);
				}
				DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(Ucp9rHhj2R, ref iMaxIndice, UWuzWyqRcA);
				clsDispositivo.ApagaOsContatoAuxiliarDoModelo(Ucp9rHhj2R);
				clsDispositivo.ApagaOsContatoAuxiliarDoDispositivo(Ucp9rHhj2R, RnE99oMK3k);
				clsDispositivo.ReInsereContatosModelo(UWuzWyqRcA, Ucp9rHhj2R);
				DataGridView DGContatos = DGContato;
				clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliaresMODELO(ref DGContatos);
				DGContato = DGContatos;
				if (DGContato.Rows.Count > 0)
				{
					int num4 = DGContato.Rows.Count - 1;
					DGContato.Rows[num4].Selected = true;
					DGContato.FirstDisplayedScrollingRowIndex = num4;
				}
				DGContatos = DGContatosInseridos;
				clsDispositivoAuxiliares.carregaContatosAuxiliaresDoModeloInserido(ref DGContatos, Ucp9rHhj2R, RnE99oMK3k);
				DGContatosInseridos = DGContatos;
				clsDispositivoAuxiliares.SincronizaContatos(Ucp9rHhj2R);
				if (flag)
				{
					Correcao.CorrigeModelosDeContatos(Ucp9rHhj2R);
					int num5 = DGContato.Rows.Count - 1;
					for (int k = 0; k <= num5; k++)
					{
						DGContato.Rows[k].Cells[0].Value = k + 1;
					}
				}
			}
			int num6 = DGContato.Rows.Count - 1;
			for (int l = 0; l <= num6; l++)
			{
				DGContato.Rows[l].Selected = false;
			}
			mostraModelo();
			clsDispositivoAuxiliares.EscreveAsFuncoesDosModelos(ref mFuncoes);
			Correcao.CorrigeContatosAux(Ucp9rHhj2R);
			ContatosBotoesVisiveis(bOpcao: true);
		}
	}

	private void hcbrBxSiMW(object P_0, DataGridViewCellEventArgs P_1)
	{
		this.DGContatosInseridos.Rows.Clear();
		this.DGContatosInseridos.Columns.Clear();
		RnE99oMK3k = Conversions.ToInteger(DGContato.SelectedRows[0].Cells[0].Value);
		DataGridView DGContatosInseridos = this.DGContatosInseridos;
		clsDispositivoAuxiliares.carregaContatosAuxiliaresDoModeloInserido(ref DGContatosInseridos, Ucp9rHhj2R, RnE99oMK3k);
		this.DGContatosInseridos = DGContatosInseridos;
		checked
		{
			int num = DGContato.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (DGContato.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			RnE99oMK3k = Conversions.ToInteger(DGContato.Rows[num2].Cells[0].Value);
			TBT1.Text = Conversions.ToString(DGContato.Rows[num2].Cells[1].Value);
			TBT2.Text = Conversions.ToString(DGContato.Rows[num2].Cells[2].Value);
			TBT3.Text = Conversions.ToString(DGContato.Rows[num2].Cells[3].Value);
			tbOrientacaoTerminais.Text = Conversions.ToString(DGContato.Rows[num2].Cells[4].Value);
			CBTipo.Text = Conversions.ToString(DGContato.Rows[num2].Cells[5].Value);
			CBComportamento.Text = Conversions.ToString(DGContato.Rows[num2].Cells[6].Value);
		}
	}

	private void Dr4rVq9Jcr(object P_0, DataGridViewCellEventArgs P_1)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		if (DGContatosInseridos.Rows.Count == 0)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					int num = DGContatosInseridos.Rows.Count - 1;
					for (int i = num; i >= 0; i += -1)
					{
						if (!DGContatosInseridos.Rows[i].Selected)
						{
							continue;
						}
						string text = DGContatosInseridos.Rows[i].Cells[3].Value.ToString();
						if (Operators.CompareString(text, "", TextCompare: true) == 0)
						{
							break;
						}
						ObjectId val3 = clsBlocos.RetornaID_Bloco(text);
						if (val3.IsValid)
						{
							BlockReference val4 = (BlockReference)val2.GetObject(val3, (OpenMode)0);
							try
							{
								uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
								string pag = ((Entity)val4).Layer.ToString();
								uscPagina.ativaPaginaAtalho(ref pag);
								Caderno.ZEntity(((DBObject)val4).ObjectId, 10);
							}
							finally
							{
								((IDisposable)val4)?.Dispose();
							}
						}
						break;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
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

	private void JNYrup9DyJ(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = TBModelo;
		clsTextos.NomeValido(ref tbNome);
		TBModelo = tbNome;
		TBModelo.BackColor = Color.White;
		TBModelo.ForeColor = Color.Black;
	}

	private void bnsrErB0VP(object P_0, EventArgs P_1)
	{
		Declaracoes2.StructureFuncoesDispositivo[] mFuncoes = null;
		clsDispositivoAuxiliares.GuardaAsFuncoesDosModelos(ref mFuncoes);
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		bool flag = false;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false);
		if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.ToUpper()
			.Trim(), DeclaracoesGeral.mMensagem[1, 1846].ToString().ToUpper().Trim(), TextCompare: true) == 0)
		{
			flag = true;
		}
		string text = "";
		text = (flag ? clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)"J2", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))) : clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)"I2", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))));
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		MsgBoxResult msgBoxResult = MsgBoxResult.No;
		string text2 = "";
		text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1703], TBModelo.Text), ", "), DeclaracoesGeral.mMensagem[1, 1704]), text), "?"));
		msgBoxResult = Interaction.MsgBox(text2, MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		checked
		{
			int num = DGModelo.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(DGModelo.Rows[i].Cells[1].Value, text, TextCompare: true) && !DGModelo.Rows[i].Selected)
				{
					text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1705], text.ToString()), "."), "\r\n"), DeclaracoesGeral.mMensagem[1, 1706]), DGModelo.Rows[i].Cells[0].Value.ToString()));
					Interaction.MsgBox(text2, MsgBoxStyle.SystemModal, "Elétron");
					if (!flag)
					{
						((_Worksheet)oSheet).get_Range((object)"I2", RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
					}
					else
					{
						((_Worksheet)oSheet).get_Range((object)"J2", RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
					}
					return;
				}
			}
			int iIndiceSelecionado = -1;
			int iMaxIndice = 0;
			int num2 = DGModelo.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (DGModelo.Rows[j].Selected)
				{
					iIndiceSelecionado = Conversions.ToInteger(DGModelo.Rows[j].Cells[0].Value);
					DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref UWuzWyqRcA);
				}
			}
			clsDispositivoAuxiliares.StructureFuncaoAuxiliares[] mFuncoes2 = new clsDispositivoAuxiliares.StructureFuncaoAuxiliares[1];
			clsDispositivoAuxiliares.BuscaContatosUsadosDoModelo(ref mFuncoes2, iIndiceSelecionado);
			if (iIndiceSelecionado != -1)
			{
				clsDispositivoAuxiliares.BuscaUsoDosContatosAuxiliares(ref UWuzWyqRcA, iIndiceSelecionado);
				Declaracoes2.StructureContatosAuxiliares[] mContatos_IMPORTAR = new Declaracoes2.StructureContatosAuxiliares[1];
				ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false);
				if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
				{
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				}
				bool bComplemento = false;
				string sMOdelo = "";
				string sTerminais = "";
				string sLm = "";
				string sLm2 = "";
				string sTopo = "";
				string sLay = "";
				string sOrientacao = "";
				List<int> lIndex = new List<int>();
				int num3 = DGContato.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					lIndex.Add(Conversions.ToInteger(DGContato.Rows[k].Cells[0].Value));
				}
				bool flag2 = false;
				if (flag ? excContatos.ImportaContatosNovo(ref oSheet, ref mContatos_IMPORTAR, ref bComplemento, ref UWuzWyqRcA, ref sMOdelo, ref sTerminais, ref sLm, ref sLm2, ref sTopo, ref sLay, ref sOrientacao) : excContatos.ImportaContatosAntigo(ref oSheet, ref mContatos_IMPORTAR, ref bComplemento, ref UWuzWyqRcA, ref sMOdelo, ref sTerminais, ref sLm, ref sLm2, ref sTopo, ref sLay))
				{
					if (!(flag ? excContatos.ComparaContatosNovo(ref oSheet, ref mContatos_IMPORTAR) : excContatos.ComparaContatosAntigo(ref oSheet, ref mContatos_IMPORTAR)))
					{
						Interaction.MsgBox(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 918], TBModelo.Text), MsgBoxStyle.SystemModal, "Elétron");
						goto IL_05fe;
					}
					if (DeclaracoesGeral.Conf.Norma != 1)
					{
					}
					DataGridView DGContatos = DGContato;
					clsDispositivoAuxiliares.carregaContatosNoDG(ref DGContatos, mContatos_IMPORTAR);
					DGContato = DGContatos;
					DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(Ucp9rHhj2R, ref iMaxIndice, mContatos_IMPORTAR);
					if (bComplemento)
					{
						if (Operators.CompareString(sMOdelo.Trim(), "", TextCompare: true) != 0)
						{
							TBModelo.Text = sMOdelo;
						}
						if (Operators.CompareString(sTerminais.Trim(), "", TextCompare: true) != 0)
						{
							TBTerminais.Text = sTerminais;
						}
						i3dr5Qwhxi(Conversions.ToInteger(sLm), 1);
						i3dr5Qwhxi(Conversions.ToInteger(sLm2), 2);
						if (Operators.CompareString(sTopo, tbBlocoTopografico.Text, TextCompare: true) != 0)
						{
							tbBlocoTopografico.Text = sTopo;
						}
						if (Operators.CompareString(sLay, tbBlocoLayout.Text, TextCompare: true) != 0)
						{
							tbBlocoLayout.Text = sLay;
						}
						tbOrientacao.Text = sOrientacao;
						b4urmaYtwg();
					}
					int num4 = Information.UBound(mContatos_IMPORTAR);
					for (int l = 1; l <= num4; l++)
					{
						if (l == Information.UBound(mContatos_IMPORTAR))
						{
							AtualizaContatosModelo(Ucp9rHhj2R, iMaxIndice, mContatos_IMPORTAR[l].iIndice, Conversions.ToString(mContatos_IMPORTAR[l].iTipo), mContatos_IMPORTAR);
						}
					}
					clsDispositivoAuxiliares.SincronizaContatos(Ucp9rHhj2R);
					DGContatos = DGContato;
					clsDispositivoAuxiliares.AtualizaTipoDoContatoDepoisDeImportarDoExcel(ref DGContatos, Ucp9rHhj2R);
					DGContato = DGContatos;
				}
				else
				{
					Interaction.MsgBox(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 918], TBModelo.Text), MsgBoxStyle.SystemModal, "Elétron");
				}
				int num5 = DGContato.Rows.Count - 1;
				for (int m = 0; m <= num5; m++)
				{
					if (lIndex.Contains(Conversions.ToInteger(DGContato.Rows[m].Cells[0].Value)))
					{
						lIndex.Remove(Conversions.ToInteger(DGContato.Rows[m].Cells[0].Value));
					}
				}
				if (lIndex.Count > 0)
				{
					clsDispositivoAuxiliares.ApagaContatoOrfao(ref lIndex, iIndiceSelecionado);
				}
				clsDispositivoAuxiliares.AtualizaFuncaoDoContatoAux(ref mFuncoes2, iIndiceSelecionado);
				clsDispositivoAuxiliares.EscreveAsFuncoesDosModelos(ref mFuncoes);
			}
			goto IL_05fe;
		}
		IL_05fe:
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		marcaUdoDosModelos(nXczTc5nTE);
	}

	private void GIXrZvr64R(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		clsDispositivo.carregaMatrizContatos(DGContato, ref UWuzWyqRcA);
		ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, TBModelo.Text);
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
		{
			ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		}
		else
		{
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
		excContatos.ExportaContatos(ref oSheet, ref UWuzWyqRcA, TBModelo.Text, TBTerminais.Text, tbCodigo1.Text, tbCodigo2.Text, tbBlocoTopografico.Text, tbBlocoLayout.Text, Conversions.ToString(DGModelo.SelectedRows[0].Cells[10].Value));
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		new List<string>();
	}

	private void WVoriS9NYV(object P_0, KeyEventArgs P_1)
	{
		TBModelo.BackColor = Color.White;
		TBModelo.ForeColor = Color.Black;
		mostraModelo();
	}

	private void Kd1rSNMRTP(object P_0, KeyEventArgs P_1)
	{
		TBModelo.BackColor = Color.White;
		TBModelo.ForeColor = Color.Black;
		mostraModelo();
	}

	private void Glrr4ujHAr(object P_0, EventArgs P_1)
	{
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico)))
		{
			tbBlocoTopografico.Enabled = false;
			tbBlocoTopografico.BackColor = Color.Silver;
			return;
		}
		tbBlocoTopografico.BackColor = Color.White;
		DeclaracoesGeral.gsCaminhoBloco = DeclaracoesGeral.Conf.dirSimbologiaTopografico;
		frmVisualizarBloco frmVisualizarBloco2 = new frmVisualizarBloco();
		Application.ShowModalDialog((Form)frmVisualizarBloco2);
		frmVisualizarBloco2.Dispose();
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoTopografico.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	private void fA9rCsMRYb(object P_0, EventArgs P_1)
	{
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout)))
		{
			tbBlocoLayout.Enabled = false;
			tbBlocoLayout.BackColor = Color.Silver;
			return;
		}
		tbBlocoLayout.BackColor = Color.White;
		DeclaracoesGeral.gsCaminhoBloco = DeclaracoesGeral.Conf.dirSimbologiaLayout;
		frmVisualizarBloco frmVisualizarBloco2 = new frmVisualizarBloco();
		Application.ShowModalDialog((Form)frmVisualizarBloco2);
		frmVisualizarBloco2.Dispose();
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoLayout.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	public void ModelosBotoesVisiveis(bool bOpcao)
	{
		BTAdicionaModelo.Enabled = bOpcao;
		BTEditaModelo.Enabled = bOpcao;
		BTApagaModelo.Enabled = bOpcao;
	}

	public void ContatosBotoesVisiveis(bool bOpcao)
	{
		BTAdicionaContato.Enabled = bOpcao;
		BTEditaContato.Enabled = bOpcao;
		BTApagaContaro.Enabled = bOpcao;
	}

	public string BuscaNumeroDoMaterial(string sNum)
	{
		string text = "";
		if (Operators.CompareString(sNum.Trim(), "", TextCompare: true) != 0)
		{
			sNum = sNum.ToString().Trim();
			int num = Strings.Len(sNum);
			for (int i = 1; i <= num && Versioned.IsNumeric(Strings.Mid(sNum, i, 1)); i = checked(i + 1))
			{
				text += Strings.Mid(sNum, i, 1);
			}
		}
		return text;
	}

	private void MTxrYSMwCT(object P_0, KeyEventArgs P_1)
	{
		string sTerm = TBTerminais.Text + ";";
		TextBox textBox;
		string sOrientacao = (textBox = tbOrientacao).Text;
		VerificaEntradaTerminais(sTerm, ref sOrientacao);
		textBox.Text = sOrientacao;
		tbOrientacao.SelectionStart = tbOrientacao.Text.Length;
	}

	private void dOarrK99kW(object P_0, KeyEventArgs P_1)
	{
		string sTerm = TBT1.Text + ";" + TBT2.Text + ";" + TBT3.Text + ";";
		TextBox textBox;
		string sOrientacao = (textBox = tbOrientacaoTerminais).Text;
		VerificaEntradaTerminais(sTerm, ref sOrientacao);
		textBox.Text = sOrientacao;
		tbOrientacaoTerminais.SelectionStart = tbOrientacaoTerminais.Text.Length;
	}

	public void VerificaEntradaTerminais(string sTerm, ref string sOrientacao)
	{
		if (Operators.CompareString(sOrientacao, "", TextCompare: true) == 0)
		{
			return;
		}
		int num = 0;
		sTerm = sTerm.Replace(";;", ";");
		string[] array = sTerm.Split(';');
		int num2 = Information.UBound(array);
		checked
		{
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.CompareString(array[i].ToString().Trim(), "", TextCompare: true) != 0)
				{
					num++;
				}
			}
			sOrientacao = sOrientacao.ToUpper();
			string text = sOrientacao.Trim();
			text = text.Replace("NN", "N");
			text = text.Replace("SS", "S");
			text = text.Replace("NS", "N");
			text = text.Replace("SN", "S");
			string text2 = "";
			int num3 = 0;
			int num4 = Strings.Len(text);
			for (int j = 1; j <= num4; j++)
			{
				string text3 = Strings.Mid(text, j, 1);
				if ((Operators.CompareString(text3, "N", TextCompare: true) == 0) | (Operators.CompareString(text3, "S", TextCompare: true) == 0) | (Operators.CompareString(text3, ";", TextCompare: true) == 0))
				{
					if ((Operators.CompareString(text3, "N", TextCompare: true) == 0) | (Operators.CompareString(text3, "S", TextCompare: true) == 0))
					{
						num3++;
					}
					if (num3 <= num)
					{
						text2 += text3;
					}
				}
			}
			text2 = text2.Replace(";;", ";");
			if (Operators.CompareString(text2, ";", TextCompare: true) == 0)
			{
				text2 = "";
			}
			sOrientacao = text2;
		}
	}

	private void O8Ur9KXNlQ(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo1.Text));
		tbCodigo1.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum1.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo1.Text = frmPesquisaMateriais2.modelo;
		tbFabricante1.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}

	private void f3Xrzfe9Id(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo2.Text));
		tbCodigo2.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum2.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo2.Text = frmPesquisaMateriais2.modelo;
		tbFabricante2.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}

	private void wTR9Wc20Uk(object P_0, EventArgs P_1)
	{
		if (SbHzp2bYTy)
		{
			DataGridView dg = DGModelo;
			clsDispositivo.AtualizaColunasDGModelos(ref dg);
			DGModelo = dg;
			dg = DGContato;
			clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliaresMODELO(ref dg);
			DGContato = dg;
			dg = DGContatosInseridos;
			clsDispositivo.AtualizaColunasDGContatosInseridos(ref dg);
			DGContatosInseridos = dg;
		}
	}
}
