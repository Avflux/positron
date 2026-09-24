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
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Aranha : Form
{
	private IContainer N09pjKjI6p2;

	[AccessedThroughProperty("dgRevisao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView sVapjeLAHGc;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView d9bpj2SnWJ0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionarRegua")]
	private Button zPrpj36WJXj;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip k4wpjnvAIcA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	private GroupBox dOLpj1kcx7E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCadastro")]
	[CompilerGenerated]
	private RadioButton pumpjlg6mxv;

	[CompilerGenerated]
	[AccessedThroughProperty("rbCrescente")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton QSFpj5lOKy9;

	[AccessedThroughProperty("dgRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView usdpj0dYvYm;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox GvepjRHbIri;

	[CompilerGenerated]
	[AccessedThroughProperty("rb2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton GyBpjmjyuJq;

	[AccessedThroughProperty("rb1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton g2WpjXZMf0v;

	[AccessedThroughProperty("btApagaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button tXypjU50Ow5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btJumper")]
	private Button AbKpjy5jjet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarJumper")]
	private Button FyZpjgF6IUq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btApagarCabos")]
	private Button wtjpjAINpEo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	private GroupBox BiWpjsmetJt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox BpupjB2v4aM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	[CompilerGenerated]
	private GroupBox g7IpjVUsIDS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCabos")]
	private Button uuvpjuWnTGt;

	[AccessedThroughProperty("GroupBox6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox pn5pjEHmdEx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarVeias")]
	private Button efPpjZ0dlGg;

	[AccessedThroughProperty("btVeias")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button C4vpjiCI4ZO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSincroniza")]
	[CompilerGenerated]
	private Button CncpjSrRn23;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb4")]
	[CompilerGenerated]
	private RadioButton SILpj48GmD1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb3")]
	private RadioButton x7DpjCCPEJW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar id1pjYOgB2Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbPesquisa")]
	private TextBox KLOpjrqemgd;

	[CompilerGenerated]
	[AccessedThroughProperty("btSeleciona")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button gedpj9l3thV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbC")]
	private RadioButton lrapjzFj5ig;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btMirrorJumperDown")]
	private Button lvkpLWf5URe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEsquerda")]
	private Button k5DpLpVEMs7;

	[AccessedThroughProperty("dgEsquerda")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView qWtpLT0BiNX;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label vmNpLJRyF5m;

	[CompilerGenerated]
	[AccessedThroughProperty("cbAterrarBlindagem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox wukpLhSwDjT;

	[AccessedThroughProperty("btVerificar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button TQhpLoCWXcB;

	[AccessedThroughProperty("btApagarCruzamentos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button VfZpLGJGK6J;

	private DeclaracoesFiacao.structurePnRev[] c8spLHg6Whn;

	private DeclaracoesFiacao.structureRevisoes[] cH8pLksF77v;

	private DeclaracoesInterligacao.structureRI[] yGkpLdW3M1k;

	private DeclaracoesInterligacao.structureBornesInseridos[] Om8pLfrqK6x;

	private string siXpLDNFae4;

	private int mRLpLvE9hF2;

	private bool OA3pL6LTNkR;

	private bool of9pLt1MMAu;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return sVapjeLAHGc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pDOpjkMhx4h;
			DataGridView dataGridView = sVapjeLAHGc;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			sVapjeLAHGc = value;
			dataGridView = sVapjeLAHGc;
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
			return d9bpj2SnWJ0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = q0Tpjvsd0EG;
			DataGridView dataGridView = d9bpj2SnWJ0;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			d9bpj2SnWJ0 = value;
			dataGridView = d9bpj2SnWJ0;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btAdicionarRegua
	{
		[CompilerGenerated]
		get
		{
			return zPrpj36WJXj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ziNpjxRkDHZ;
			Button button = zPrpj36WJXj;
			if (button != null)
			{
				button.Click -= value2;
			}
			zPrpj36WJXj = value;
			button = zPrpj36WJXj;
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
			return dOLpj1kcx7E;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dOLpj1kcx7E = value;
		}
	}

	internal virtual RadioButton rbCadastro
	{
		[CompilerGenerated]
		get
		{
			return pumpjlg6mxv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CqLpjD62i1T;
			RadioButton radioButton = pumpjlg6mxv;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			pumpjlg6mxv = value;
			radioButton = pumpjlg6mxv;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbCrescente
	{
		[CompilerGenerated]
		get
		{
			return QSFpj5lOKy9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QSFpj5lOKy9 = value;
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return usdpj0dYvYm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			usdpj0dYvYm = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return GvepjRHbIri;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GvepjRHbIri = value;
		}
	}

	internal virtual RadioButton rb2
	{
		[CompilerGenerated]
		get
		{
			return GyBpjmjyuJq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GyBpjmjyuJq = value;
		}
	}

	internal virtual RadioButton rb1
	{
		[CompilerGenerated]
		get
		{
			return g2WpjXZMf0v;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			g2WpjXZMf0v = value;
		}
	}

	internal virtual Button btApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return tXypjU50Ow5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wwwpjbfatQs;
			Button button = tXypjU50Ow5;
			if (button != null)
			{
				button.Click -= value2;
			}
			tXypjU50Ow5 = value;
			button = tXypjU50Ow5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btJumper
	{
		[CompilerGenerated]
		get
		{
			return AbKpjy5jjet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ewTpjO5LfJX;
			Button button = AbKpjy5jjet;
			if (button != null)
			{
				button.Click -= value2;
			}
			AbKpjy5jjet = value;
			button = AbKpjy5jjet;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarJumper
	{
		[CompilerGenerated]
		get
		{
			return FyZpjgF6IUq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SP6pjIhZ9gO;
			Button button = FyZpjgF6IUq;
			if (button != null)
			{
				button.Click -= value2;
			}
			FyZpjgF6IUq = value;
			button = FyZpjgF6IUq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarCabos
	{
		[CompilerGenerated]
		get
		{
			return wtjpjAINpEo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HuZpj8KG5lp;
			Button button = wtjpjAINpEo;
			if (button != null)
			{
				button.Click -= value2;
			}
			wtjpjAINpEo = value;
			button = wtjpjAINpEo;
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
			return BiWpjsmetJt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BiWpjsmetJt = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return BpupjB2v4aM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BpupjB2v4aM = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return g7IpjVUsIDS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			g7IpjVUsIDS = value;
		}
	}

	internal virtual Button btCabos
	{
		[CompilerGenerated]
		get
		{
			return uuvpjuWnTGt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QLjpjaKI3B9;
			Button button = uuvpjuWnTGt;
			if (button != null)
			{
				button.Click -= value2;
			}
			uuvpjuWnTGt = value;
			button = uuvpjuWnTGt;
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
			return pn5pjEHmdEx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pn5pjEHmdEx = value;
		}
	}

	internal virtual Button btApagarVeias
	{
		[CompilerGenerated]
		get
		{
			return efPpjZ0dlGg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = K2kpjFmnJDh;
			Button button = efPpjZ0dlGg;
			if (button != null)
			{
				button.Click -= value2;
			}
			efPpjZ0dlGg = value;
			button = efPpjZ0dlGg;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btVeias
	{
		[CompilerGenerated]
		get
		{
			return C4vpjiCI4ZO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = koHpjNgBTbw;
			Button button = C4vpjiCI4ZO;
			if (button != null)
			{
				button.Click -= value2;
			}
			C4vpjiCI4ZO = value;
			button = C4vpjiCI4ZO;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSincroniza
	{
		[CompilerGenerated]
		get
		{
			return CncpjSrRn23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mV3pjPkQNRh;
			Button button = CncpjSrRn23;
			if (button != null)
			{
				button.Click -= value2;
			}
			CncpjSrRn23 = value;
			button = CncpjSrRn23;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rb4
	{
		[CompilerGenerated]
		get
		{
			return SILpj48GmD1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SILpj48GmD1 = value;
		}
	}

	internal virtual RadioButton rb3
	{
		[CompilerGenerated]
		get
		{
			return x7DpjCCPEJW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			x7DpjCCPEJW = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return id1pjYOgB2Z;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			id1pjYOgB2Z = value;
		}
	}

	internal virtual TextBox tbPesquisa
	{
		[CompilerGenerated]
		get
		{
			return KLOpjrqemgd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = v3opjdpNsT9;
			TextBox textBox = KLOpjrqemgd;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			KLOpjrqemgd = value;
			textBox = KLOpjrqemgd;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return gedpj9l3thV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = O5BpjMjJAQK;
			Button button = gedpj9l3thV;
			if (button != null)
			{
				button.Click -= value2;
			}
			gedpj9l3thV = value;
			button = gedpj9l3thV;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbC
	{
		[CompilerGenerated]
		get
		{
			return lrapjzFj5ig;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oW1pjQojWot;
			RadioButton radioButton = lrapjzFj5ig;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			lrapjzFj5ig = value;
			radioButton = lrapjzFj5ig;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btMirrorJumperDown
	{
		[CompilerGenerated]
		get
		{
			return lvkpLWf5URe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kqSpj7j53FS;
			Button button = lvkpLWf5URe;
			if (button != null)
			{
				button.Click -= value2;
			}
			lvkpLWf5URe = value;
			button = lvkpLWf5URe;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEsquerda
	{
		[CompilerGenerated]
		get
		{
			return k5DpLpVEMs7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kRVpjqffg0A;
			Button button = k5DpLpVEMs7;
			if (button != null)
			{
				button.Click -= value2;
			}
			k5DpLpVEMs7 = value;
			button = k5DpLpVEMs7;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgEsquerda
	{
		[CompilerGenerated]
		get
		{
			return qWtpLT0BiNX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qWtpLT0BiNX = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return vmNpLJRyF5m;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vmNpLJRyF5m = value;
		}
	}

	internal virtual CheckBox cbAterrarBlindagem
	{
		[CompilerGenerated]
		get
		{
			return wukpLhSwDjT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wukpLhSwDjT = value;
		}
	}

	internal virtual Button btVerificar
	{
		[CompilerGenerated]
		get
		{
			return TQhpLoCWXcB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NwepjjDTVHy;
			Button button = TQhpLoCWXcB;
			if (button != null)
			{
				button.Click -= value2;
			}
			TQhpLoCWXcB = value;
			button = TQhpLoCWXcB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarCruzamentos
	{
		[CompilerGenerated]
		get
		{
			return VfZpLGJGK6J;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NAIpjc5Zwa4;
			Button button = VfZpLGJGK6J;
			if (button != null)
			{
				button.Click -= value2;
			}
			VfZpLGJGK6J = value;
			button = VfZpLGJGK6J;
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
			if (disposing && N09pjKjI6p2 != null)
			{
				N09pjKjI6p2.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void q4UpjoaaCUM()
	{
		N09pjKjI6p2 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		btAdicionarRegua = new Button();
		FDqpBiUmZij(new ToolTip(N09pjKjI6p2));
		GroupBox2 = new GroupBox();
		rbCadastro = new RadioButton();
		rbCrescente = new RadioButton();
		dgRegua = new DataGridView();
		GroupBox1 = new GroupBox();
		rbC = new RadioButton();
		rb4 = new RadioButton();
		rb3 = new RadioButton();
		rb2 = new RadioButton();
		rb1 = new RadioButton();
		btApagaRegua = new Button();
		btJumper = new Button();
		btApagarJumper = new Button();
		btApagarCabos = new Button();
		GroupBox3 = new GroupBox();
		btVerificar = new Button();
		GroupBox4 = new GroupBox();
		btMirrorJumperDown = new Button();
		GroupBox5 = new GroupBox();
		btEsquerda = new Button();
		btCabos = new Button();
		GroupBox6 = new GroupBox();
		btVeias = new Button();
		btApagarVeias = new Button();
		btSincroniza = new Button();
		ProgressBar1 = new ProgressBar();
		tbPesquisa = new TextBox();
		btSeleciona = new Button();
		dgEsquerda = new DataGridView();
		Label1 = new Label();
		cbAterrarBlindagem = new CheckBox();
		btApagarCruzamentos = new Button();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgRegua).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox6.SuspendLayout();
		((ISupportInitialize)dgEsquerda).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
		dgRevisao.Size = new Size(395, 133);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(13, 177);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(137, 250);
		dgEquip.TabIndex = 8;
		btAdicionarRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAdicionarRegua.FlatStyle = FlatStyle.Flat;
		btAdicionarRegua.ForeColor = SystemColors.Control;
		btAdicionarRegua.Image = Resources.BorneAranha_32;
		btAdicionarRegua.Location = new Point(47, 20);
		btAdicionarRegua.Name = "btAdicionarRegua";
		btAdicionarRegua.Size = new Size(40, 42);
		btAdicionarRegua.TabIndex = 15;
		btAdicionarRegua.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rbCadastro);
		GroupBox2.Controls.Add(rbCrescente);
		GroupBox2.Location = new Point(155, 355);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(169, 43);
		GroupBox2.TabIndex = 47;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordem Bornes Máscara";
		rbCadastro.AutoSize = true;
		rbCadastro.Location = new Point(94, 19);
		rbCadastro.Name = "rbCadastro";
		rbCadastro.Size = new Size(76, 17);
		rbCadastro.TabIndex = 1;
		rbCadastro.TabStop = true;
		rbCadastro.Text = "rbCadastro";
		rbCadastro.UseVisualStyleBackColor = true;
		rbCrescente.AutoSize = true;
		rbCrescente.Location = new Point(6, 19);
		rbCrescente.Name = "rbCrescente";
		rbCrescente.Size = new Size(82, 17);
		rbCrescente.TabIndex = 0;
		rbCrescente.TabStop = true;
		rbCrescente.Text = "rbCrescente";
		rbCrescente.UseVisualStyleBackColor = true;
		dgRegua.AllowUserToAddRows = false;
		dgRegua.AllowUserToDeleteRows = false;
		dgRegua.AllowUserToOrderColumns = true;
		dgRegua.AllowUserToResizeRows = false;
		dgRegua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgRegua.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgRegua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgRegua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRegua.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRegua.Location = new Point(155, 151);
		dgRegua.MultiSelect = false;
		dgRegua.Name = "dgRegua";
		dgRegua.ReadOnly = true;
		dgRegua.RowHeadersVisible = false;
		dgRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRegua.Size = new Size(252, 181);
		dgRegua.TabIndex = 48;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbC);
		GroupBox1.Controls.Add(rb4);
		GroupBox1.Controls.Add(rb3);
		GroupBox1.Controls.Add(rb2);
		GroupBox1.Controls.Add(rb1);
		GroupBox1.Location = new Point(157, 404);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(250, 49);
		GroupBox1.TabIndex = 49;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Posição";
		rbC.AutoSize = true;
		rbC.Location = new Point(102, 19);
		rbC.Name = "rbC";
		rbC.Size = new Size(41, 17);
		rbC.TabIndex = 54;
		rbC.TabStop = true;
		rbC.Text = "rbC";
		rbC.UseVisualStyleBackColor = true;
		rb4.AutoSize = true;
		rb4.Location = new Point(195, 19);
		rb4.Name = "rb4";
		rb4.Size = new Size(40, 17);
		rb4.TabIndex = 53;
		rb4.TabStop = true;
		rb4.Text = "rb4";
		rb4.UseVisualStyleBackColor = true;
		rb3.AutoSize = true;
		rb3.Location = new Point(149, 19);
		rb3.Name = "rb3";
		rb3.Size = new Size(40, 17);
		rb3.TabIndex = 52;
		rb3.TabStop = true;
		rb3.Text = "rb3";
		rb3.UseVisualStyleBackColor = true;
		rb2.AutoSize = true;
		rb2.Location = new Point(55, 19);
		rb2.Name = "rb2";
		rb2.Size = new Size(40, 17);
		rb2.TabIndex = 51;
		rb2.TabStop = true;
		rb2.Text = "rb2";
		rb2.UseVisualStyleBackColor = true;
		rb1.AutoSize = true;
		rb1.Location = new Point(10, 19);
		rb1.Name = "rb1";
		rb1.Size = new Size(40, 17);
		rb1.TabIndex = 50;
		rb1.TabStop = true;
		rb1.Text = "rb1";
		rb1.UseVisualStyleBackColor = true;
		btApagaRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagaRegua.FlatStyle = FlatStyle.Flat;
		btApagaRegua.ForeColor = SystemColors.Control;
		btApagaRegua.Image = Resources.Delete_32;
		btApagaRegua.Location = new Point(85, 20);
		btApagaRegua.Name = "btApagaRegua";
		btApagaRegua.Size = new Size(40, 42);
		btApagaRegua.TabIndex = 50;
		btApagaRegua.UseVisualStyleBackColor = true;
		btJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btJumper.FlatStyle = FlatStyle.Flat;
		btJumper.ForeColor = SystemColors.Control;
		btJumper.Image = Resources.JumperAranha_32;
		btJumper.Location = new Point(7, 19);
		btJumper.Name = "btJumper";
		btJumper.Size = new Size(26, 42);
		btJumper.TabIndex = 51;
		btJumper.UseVisualStyleBackColor = true;
		btApagarJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarJumper.FlatStyle = FlatStyle.Flat;
		btApagarJumper.ForeColor = SystemColors.Control;
		btApagarJumper.Image = Resources.Delete_32;
		btApagarJumper.Location = new Point(37, 20);
		btApagarJumper.Name = "btApagarJumper";
		btApagarJumper.Size = new Size(40, 42);
		btApagarJumper.TabIndex = 52;
		btApagarJumper.UseVisualStyleBackColor = true;
		btApagarCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCabos.FlatStyle = FlatStyle.Flat;
		btApagarCabos.ForeColor = SystemColors.Control;
		btApagarCabos.Image = Resources.Delete_32;
		btApagarCabos.Location = new Point(85, 18);
		btApagarCabos.Name = "btApagarCabos";
		btApagarCabos.Size = new Size(40, 42);
		btApagarCabos.TabIndex = 54;
		btApagarCabos.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(btVerificar);
		GroupBox3.Controls.Add(btAdicionarRegua);
		GroupBox3.Controls.Add(btApagaRegua);
		GroupBox3.Location = new Point(155, 459);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(130, 70);
		GroupBox3.TabIndex = 56;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Réguas de Bornes";
		btVerificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVerificar.FlatStyle = FlatStyle.Flat;
		btVerificar.ForeColor = SystemColors.Control;
		btVerificar.Image = Resources.Check;
		btVerificar.Location = new Point(6, 20);
		btVerificar.Name = "btVerificar";
		btVerificar.Size = new Size(36, 42);
		btVerificar.TabIndex = 70;
		btVerificar.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(btMirrorJumperDown);
		GroupBox4.Controls.Add(btApagarJumper);
		GroupBox4.Controls.Add(btJumper);
		GroupBox4.Location = new Point(291, 459);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(116, 70);
		GroupBox4.TabIndex = 57;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Jumpers";
		btMirrorJumperDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btMirrorJumperDown.FlatStyle = FlatStyle.Flat;
		btMirrorJumperDown.ForeColor = SystemColors.Control;
		btMirrorJumperDown.Image = Resources.JumperRebatido2_32;
		btMirrorJumperDown.Location = new Point(81, 20);
		btMirrorJumperDown.Name = "btMirrorJumperDown";
		btMirrorJumperDown.Size = new Size(32, 42);
		btMirrorJumperDown.TabIndex = 67;
		btMirrorJumperDown.UseVisualStyleBackColor = true;
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(btEsquerda);
		GroupBox5.Controls.Add(btCabos);
		GroupBox5.Controls.Add(btApagarCabos);
		GroupBox5.Location = new Point(155, 534);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(130, 70);
		GroupBox5.TabIndex = 58;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Cabos";
		btEsquerda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btEsquerda.FlatStyle = FlatStyle.Flat;
		btEsquerda.ForeColor = SystemColors.Control;
		btEsquerda.Image = Resources.DI_Left;
		btEsquerda.Location = new Point(4, 18);
		btEsquerda.Name = "btEsquerda";
		btEsquerda.Size = new Size(40, 42);
		btEsquerda.TabIndex = 55;
		btEsquerda.UseVisualStyleBackColor = true;
		btCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCabos.FlatStyle = FlatStyle.Flat;
		btCabos.ForeColor = SystemColors.Control;
		btCabos.Image = Resources.CaboAranha_32;
		btCabos.Location = new Point(48, 18);
		btCabos.Name = "btCabos";
		btCabos.Size = new Size(40, 42);
		btCabos.TabIndex = 51;
		btCabos.UseVisualStyleBackColor = true;
		GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox6.Controls.Add(btVeias);
		GroupBox6.Controls.Add(btApagarVeias);
		GroupBox6.Location = new Point(291, 535);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(116, 70);
		GroupBox6.TabIndex = 59;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Veias";
		btVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVeias.FlatStyle = FlatStyle.Flat;
		btVeias.ForeColor = SystemColors.Control;
		btVeias.Image = Resources.Veias;
		btVeias.Location = new Point(13, 19);
		btVeias.Name = "btVeias";
		btVeias.Size = new Size(40, 42);
		btVeias.TabIndex = 55;
		btVeias.UseVisualStyleBackColor = true;
		btApagarVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarVeias.FlatStyle = FlatStyle.Flat;
		btApagarVeias.ForeColor = SystemColors.Control;
		btApagarVeias.Image = Resources.Delete_32;
		btApagarVeias.Location = new Point(62, 19);
		btApagarVeias.Name = "btApagarVeias";
		btApagarVeias.Size = new Size(40, 42);
		btApagarVeias.TabIndex = 52;
		btApagarVeias.UseVisualStyleBackColor = true;
		btSincroniza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSincroniza.FlatStyle = FlatStyle.Flat;
		btSincroniza.ForeColor = SystemColors.Control;
		btSincroniza.Image = Resources.Sincroniza_32;
		btSincroniza.Location = new Point(329, 358);
		btSincroniza.Name = "btSincroniza";
		btSincroniza.Size = new Size(36, 42);
		btSincroniza.TabIndex = 51;
		btSincroniza.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(155, 338);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(252, 11);
		ProgressBar1.TabIndex = 61;
		tbPesquisa.Location = new Point(12, 151);
		tbPesquisa.Name = "tbPesquisa";
		tbPesquisa.Size = new Size(109, 20);
		tbPesquisa.TabIndex = 62;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_16;
		btSeleciona.Location = new Point(123, 151);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(24, 20);
		btSeleciona.TabIndex = 66;
		btSeleciona.UseVisualStyleBackColor = true;
		dgEsquerda.AllowUserToAddRows = false;
		dgEsquerda.AllowUserToOrderColumns = true;
		dgEsquerda.AllowUserToResizeRows = false;
		dgEsquerda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		dgEsquerda.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgEsquerda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgEsquerda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEsquerda.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEsquerda.Location = new Point(12, 451);
		dgEsquerda.MultiSelect = false;
		dgEsquerda.Name = "dgEsquerda";
		dgEsquerda.ReadOnly = true;
		dgEsquerda.RowHeadersVisible = false;
		dgEsquerda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEsquerda.Size = new Size(137, 135);
		dgEsquerda.TabIndex = 67;
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label1.AutoSize = true;
		Label1.Location = new Point(12, 434);
		Label1.Name = "Label1";
		Label1.Size = new Size(85, 13);
		Label1.TabIndex = 68;
		Label1.Text = "Equip. Esquerda";
		cbAterrarBlindagem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAterrarBlindagem.AutoSize = true;
		cbAterrarBlindagem.Location = new Point(12, 592);
		cbAterrarBlindagem.Name = "cbAterrarBlindagem";
		cbAterrarBlindagem.Size = new Size(139, 17);
		cbAterrarBlindagem.TabIndex = 69;
		cbAterrarBlindagem.Text = "Aterrar Blindagem Colet.";
		cbAterrarBlindagem.UseVisualStyleBackColor = true;
		btApagarCruzamentos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCruzamentos.FlatStyle = FlatStyle.Flat;
		btApagarCruzamentos.ForeColor = SystemColors.Control;
		btApagarCruzamentos.Image = Resources.Delete_32;
		btApagarCruzamentos.Location = new Point(371, 357);
		btApagarCruzamentos.Name = "btApagarCruzamentos";
		btApagarCruzamentos.Size = new Size(36, 42);
		btApagarCruzamentos.TabIndex = 70;
		btApagarCruzamentos.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(414, 611);
		Controls.Add(btApagarCruzamentos);
		Controls.Add(cbAterrarBlindagem);
		Controls.Add(GroupBox2);
		Controls.Add(Label1);
		Controls.Add(dgEsquerda);
		Controls.Add(btSeleciona);
		Controls.Add(tbPesquisa);
		Controls.Add(ProgressBar1);
		Controls.Add(btSincroniza);
		Controls.Add(GroupBox6);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(dgRegua);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(430, 1200);
		MinimumSize = new Size(430, 650);
		Name = "frmRelatorio_Aranha";
		ShowInTaskbar = false;
		Text = "Diagrama de Interligação Eletronorte";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dgRegua).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox6.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgEsquerda).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return k4wpjnvAIcA;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		k4wpjnvAIcA = WithEventsValue;
	}

	public frmRelatorio_Aranha()
	{
		c8spLHg6Whn = new DeclaracoesFiacao.structurePnRev[1];
		cH8pLksF77v = new DeclaracoesFiacao.structureRevisoes[1];
		siXpLDNFae4 = "";
		mRLpLvE9hF2 = 0;
		OA3pL6LTNkR = false;
		of9pLt1MMAu = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Aranha"))
			{
				q4UpjoaaCUM();
				L6LpjGRBP72(_0020: false);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1437]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1439]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1419]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1444]);
				GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
				GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1445]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1548]);
				rbCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1420]);
				rbCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1421]);
				rb1.Text = "1";
				rb2.Text = "2";
				rb3.Text = "3";
				rb4.Text = "4";
				rbC.Text = "C";
				w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1900]));
				w8dpBZ0kvSD().SetToolTip(btApagarCruzamentos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1901]));
				w8dpBZ0kvSD().SetToolTip(btVerificar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1902]));
				w8dpBZ0kvSD().SetToolTip(btEsquerda, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1903]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				yGkpLdW3M1k = new DeclaracoesInterligacao.structureRI[1];
				yGkpLdW3M1k[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				Om8pLfrqK6x = new DeclaracoesInterligacao.structureBornesInseridos[1];
				formataDGRevisao();
				formataDGEquip();
				rbCrescente.Checked = true;
				rb1.Checked = true;
				cbAterrarBlindagem.Checked = true;
				plcpjHadFgB();
				L6LpjGRBP72(_0020: true);
				btEsquerda.Enabled = false;
				btMirrorJumperDown.Enabled = false;
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

	private void L6LpjGRBP72(bool P_0)
	{
		GroupBox1.Enabled = P_0;
		GroupBox2.Enabled = P_0;
		GroupBox3.Enabled = P_0;
		GroupBox4.Enabled = P_0;
		GroupBox5.Enabled = P_0;
		GroupBox6.Enabled = P_0;
		btSincroniza.Enabled = P_0;
		btSeleciona.Enabled = P_0;
	}

	private void plcpjHadFgB()
	{
		cH8pLksF77v = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref cH8pLksF77v);
			OA3pL6LTNkR = true;
			dgRevisao.Rows.Clear();
			OA3pL6LTNkR = false;
			int num = Information.UBound(cH8pLksF77v);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(cH8pLksF77v[i].revisao, cH8pLksF77v[i].criador, cH8pLksF77v[i].data);
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

	private void pDOpjkMhx4h(object P_0, EventArgs P_1)
	{
		of9pLt1MMAu = true;
		dgEquip.Rows.Clear();
		of9pLt1MMAu = false;
		if (!OA3pL6LTNkR)
		{
			ocapjfYNmWQ(_0020: false);
		}
	}

	private void v3opjdpNsT9(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(tbPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !OA3pL6LTNkR)
		{
			ocapjfYNmWQ(_0020: true);
		}
	}

	private void ocapjfYNmWQ(bool P_0)
	{
		if (!P_0)
		{
			tbPesquisa.Text = "";
		}
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			siXpLDNFae4 = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			of9pLt1MMAu = true;
			dgEquip.Rows.Clear();
			of9pLt1MMAu = false;
			int num = Information.UBound(c8spLHg6Whn);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(c8spLHg6Whn[i].revisao, siXpLDNFae4, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(c8spLHg6Whn[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(c8spLHg6Whn[i].painel, text);
					}
					else if (text.ToUpper().Contains(tbPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(c8spLHg6Whn[i].painel, text);
					}
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

	public void CarregaPnRev()
	{
		c8spLHg6Whn = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(cH8pLksF77v) > 0)
			{
				int num = Information.UBound(cH8pLksF77v);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(cH8pLksF77v[i].revisao, ref c8spLHg6Whn);
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
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	private void CqLpjD62i1T(object P_0, EventArgs P_1)
	{
		sMtpj63gAvY();
	}

	private void q0Tpjvsd0EG(object P_0, EventArgs P_1)
	{
		sMtpj63gAvY();
		formataDGEsquerda();
	}

	private void sMtpj63gAvY()
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				L6LpjGRBP72(_0020: false);
				mRLpLvE9hF2 = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				formataDGRegua();
				yGkpLdW3M1k = new DeclaracoesInterligacao.structureRI[1];
				yGkpLdW3M1k[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cDadosAccessInterligacao3.CarregaReguas(siXpLDNFae4, mRLpLvE9hF2, ref yGkpLdW3M1k);
				cDadosAccessInterligacao3.CarregaReguasPortas(siXpLDNFae4, mRLpLvE9hF2, ref yGkpLdW3M1k);
				cDadosAccessInterligacao3.CarregaBornesReguas(siXpLDNFae4, mRLpLvE9hF2, ref yGkpLdW3M1k, rbCadastro.Checked);
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = checked(qrRpjt9ejBk() * 2);
				ProgressBar1.Value = 0;
				ProgressBar1.Step = 1;
				string revisao = siXpLDNFae4;
				int painel = mRLpLvE9hF2;
				ref DeclaracoesInterligacao.structureRI[] mReguas = ref yGkpLdW3M1k;
				ProgressBar ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaCabosNosBornesRI(revisao, painel, ref mReguas, ref ProgressBar, -1);
				ProgressBar1 = ProgressBar;
				string revisao2 = siXpLDNFae4;
				int painel2 = mRLpLvE9hF2;
				ref DeclaracoesInterligacao.structureRI[] mReguas2 = ref yGkpLdW3M1k;
				ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaJumpersNosBornesRI(revisao2, painel2, ref mReguas2, ref ProgressBar);
				ProgressBar1 = ProgressBar;
				seMpjwixCTm();
				pcApjLX9N6D();
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
			ProgressBar1.Value = 0;
			L6LpjGRBP72(_0020: true);
		}
	}

	private int qrRpjt9ejBk()
	{
		int num = 0;
		int num2 = Information.UBound(yGkpLdW3M1k);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!Information.IsNothing(yGkpLdW3M1k[i].Bornes))
				{
					num += yGkpLdW3M1k[i].Bornes.Length - 1;
				}
			}
			return num;
		}
	}

	private void NwepjjDTVHy(object P_0, EventArgs P_1)
	{
		pcApjLX9N6D();
	}

	private void pcApjLX9N6D()
	{
		Om8pLfrqK6x = new DeclaracoesInterligacao.structureBornesInseridos[1];
		ClsAranha.ContaBornesReguas(mRLpLvE9hF2, ref Om8pLfrqK6x);
		checked
		{
			int num = dgRegua.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string right = Conversions.ToString(dgRegua.Rows[i].Cells[1].Value);
				string right2 = Conversions.ToString(dgRegua.Rows[i].Cells[2].Value);
				int num2 = Conversions.ToInteger(dgRegua.Rows[i].Cells[3].Value);
				bool flag = false;
				int num3 = Information.UBound(Om8pLfrqK6x);
				for (int j = 1; j <= num3; j++)
				{
					if (!((Operators.CompareString(Om8pLfrqK6x[j].Tag, right, TextCompare: true) == 0) & (Operators.CompareString(Om8pLfrqK6x[j].NRegua, right2, TextCompare: true) == 0)))
					{
						continue;
					}
					if (num2 != Om8pLfrqK6x[j].Qtde)
					{
						if ((num2 > Om8pLfrqK6x[j].Qtde) & (Om8pLfrqK6x[j].Qtde > 0))
						{
							flag = true;
							dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightYellow;
						}
					}
					else
					{
						flag = true;
						dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightCoral;
					}
				}
				if (!flag)
				{
					dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
				}
			}
		}
	}

	private void seMpjwixCTm()
	{
		if (Information.UBound(yGkpLdW3M1k) == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		try
		{
			int num = Information.UBound(yGkpLdW3M1k);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Information.IsNothing(yGkpLdW3M1k[i].Bornes))
				{
					if (!list.Contains(yGkpLdW3M1k[i].DWG))
					{
						list.Add(yGkpLdW3M1k[i].DWG);
					}
					continue;
				}
				int num2 = Information.UBound(yGkpLdW3M1k[i].Bornes);
				dgRegua.Rows.Add(yGkpLdW3M1k[i].Tipo, yGkpLdW3M1k[i].Tag, yGkpLdW3M1k[i].NRegua, num2);
			}
			string text = "";
			if (list.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicDWG)
			{
				if (list.Contains(item.Key))
				{
					text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? item.Value : ("," + item.Value));
				}
			}
			if (list.Count != 1)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1981], "\r\n"), " "), text), MsgBoxStyle.Information);
			}
			else
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1980], "\r\n"), " "), text), MsgBoxStyle.Information);
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

	private void ziNpjxRkDHZ(object P_0, EventArgs P_1)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0794: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				List<string> lPaginasColunas = new List<string>();
				ClsAranha.BuscaPaginasColuna(ref lPaginasColunas);
				DeclaracoesInterligacao.structureRI structureRI = default;
				if (dgEquip.SelectedRows.Count == 0 || dgRegua.SelectedRows.Count == 0)
				{
					return;
				}
				DeclaracoesGeral.Reguas RH = default;
				if (XDataGeral.LeXDataReguaH(ref RH))
				{
					Point3d ptCol = new Point3d(RH.Pti.X + (RH.LarguraBase - RH.Pti.X) / 4.0, 262.0, 0.0);
					Point3d ptCol2 = new Point3d(RH.Pti.X + (RH.LarguraBase - RH.Pti.X) * 3.0 / 4.0, 262.0, 0.0);
					string text = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
					string text2 = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
					int num = Information.UBound(yGkpLdW3M1k);
					for (int i = 1; i <= num; i++)
					{
						if ((Operators.CompareString(yGkpLdW3M1k[i].Tag, text, TextCompare: true) == 0) & (Operators.CompareString(yGkpLdW3M1k[i].NRegua, text2, TextCompare: true) == 0))
						{
							structureRI = yGkpLdW3M1k[i];
							break;
						}
					}
					if (Information.UBound(structureRI.Bornes) == 0)
					{
						return;
					}
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					double num5 = 0.0;
					double num6 = 0.0;
					bool bInsereNomeRegua = false;
					double num7 = 0.0;
					if (structureRI.Bornes[1].TipoBorne != 0)
					{
						num5 = 90.0;
						num6 = 74.5;
						num7 = 7.5;
					}
					else
					{
						num5 = 90.0;
						num6 = 80.0;
						num7 = 5.0;
					}
					Point3d val = new Point3d(ptCol.X - num5, 236.0, 0.0);
					Point3d val2 = new Point3d(ptCol.X + num6, 236.0, 0.0);
					Point3d val3 = new Point3d(ptCol2.X - num5, 236.0, 0.0);
					Point3d val4 = new Point3d(ptCol2.X + num6, 236.0, 0.0);
					Point3d val5 = new Point3d((ptCol.X + ptCol2.X) / 2.0 - num7, 236.0, 0.0);
					Point3d ptIns = default;
					if (!rb1.Checked)
					{
						if (!rb2.Checked)
						{
							if (!rb3.Checked)
							{
								if (!rb4.Checked)
								{
									if (rbC.Checked)
									{
										ptIns = val5;
										num4 = 5;
									}
								}
								else
								{
									ptIns = val4;
									num4 = 4;
								}
							}
							else
							{
								ptIns = val3;
								num4 = 3;
							}
						}
						else
						{
							ptIns = val2;
							num4 = 2;
						}
					}
					else
					{
						ptIns = val;
						num4 = 1;
					}
					List<string> lBornes = new List<string>();
					Point3d pt = default;
					if (ClsAranha.ReguaExiste(mRLpLvE9hF2, text, text2))
					{
						DeclaracoesInterligacao.PosborneAranha ubn = default;
						if (!ClsAranha.BuscaUltimoBorne(mRLpLvE9hF2, text, text2, ref ubn, ref lBornes))
						{
							return;
						}
						Pagina.AtivaPagina(ubn.Pagina);
						num4 = ubn.Posicao;
						ptIns = ubn.PtIns;
						num2 = (int)Math.Round((236.0 - ubn.PtIns.Y) / 5.0);
						if (structureRI.Bornes[1].TipoBorne != 0)
						{
							num2 += 2;
							num3 = 10;
						}
						else
						{
							num2++;
							num3 = 5;
						}
					}
					else if (ClsAranha.OutraReguaExiste(DeclaracoesGeral.ativo.Pagina, ref pt, num4))
					{
						ptIns = new Point3d(pt.X, pt.Y - 20.0, 0.0);
						num2 = (int)Math.Round((236.0 - ptIns.Y) / 5.0);
						if (num2 >= 40)
						{
							return;
						}
						bInsereNomeRegua = true;
					}
					int num8 = Information.UBound(structureRI.Bornes);
					int num9 = 1;
					while (true)
					{
						if (num9 <= num8)
						{
							if (!lBornes.Contains(structureRI.Bornes[num9].Borne))
							{
								if (num2 != 0)
								{
									if (!((num2 > 0) & (num2 < 40)))
									{
										if (!((num2 >= 40) & (num4 <= 4)))
										{
											if ((num2 >= 40) & (num4 == 5))
											{
												num2 = 0;
												num4 = 5;
												string text3 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
												if (Operators.CompareString(text3, "", TextCompare: true) != 0)
												{
													Pagina.AtivaPagina(text3);
												}
												else if (!Pagina.criarUmaNovaPagina())
												{
													goto IL_0737;
												}
												ClsAranha.InsereColunasSePrecisar(ref lPaginasColunas, ptCol, ptCol2);
												ptIns = val5;
											}
										}
										else
										{
											num2 = 0;
											num4++;
											if (num4 == 5)
											{
												num4 = 1;
												string text4 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
												if (Operators.CompareString(text4, "", TextCompare: true) != 0)
												{
													Pagina.AtivaPagina(text4);
												}
												else if (!Pagina.criarUmaNovaPagina())
												{
													goto IL_0737;
												}
												ClsAranha.InsereColunasSePrecisar(ref lPaginasColunas, ptCol, ptCol2);
											}
											switch (num4)
											{
											case 4:
												ptIns = val4;
												break;
											case 1:
												ptIns = val;
												break;
											case 2:
												ptIns = val2;
												break;
											case 3:
												ptIns = val3;
												break;
											}
										}
									}
									else
									{
										ptIns = new Point3d(ptIns.X, ptIns.Y - (double)num3, 0.0);
									}
								}
								else
								{
									ClsAranha.InsereColunasSePrecisar(ref lPaginasColunas, ptCol, ptCol2);
								}
								DeclaracoesInterligacao.borneAranha bn = new DeclaracoesInterligacao.borneAranha
								{
									Revisao = siXpLDNFae4,
									Painel = mRLpLvE9hF2,
									Tag = text,
									NRegua = text2,
									Borne = structureRI.Bornes[num9].Borne,
									TipoBorne = structureRI.Bornes[num9].TipoBorne,
									Ordem = structureRI.Bornes[num9].Ordem,
									Posicao = num4
								};
								string text5 = "";
								text5 = ((bn.TipoBorne == 0) ? "BorneSimples.DWG" : "BorneDuplo.DWG");
								if (!File.Exists(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + text5))
								{
									break;
								}
								if (num2 == 0)
								{
									bInsereNomeRegua = true;
								}
								ClsAranha.InserirBorneAranha(text5, bn, ptIns, bInsereNomeRegua);
								bInsereNomeRegua = false;
								if (bn.TipoBorne != 0)
								{
									if (bn.TipoBorne == 1)
									{
										num2 += 2;
										num3 = 10;
									}
								}
								else
								{
									num2++;
									num3 = 5;
								}
							}
							num9++;
							continue;
						}
						goto IL_0737;
						IL_0737:
						DeclaracoesGeral._uscPagina.CarregaPG();
						return;
					}
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
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
				pcApjLX9N6D();
				Application.UpdateScreen();
			}
		}
	}

	private void wwwpjbfatQs(object P_0, EventArgs P_1)
	{
		string tag = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
		string nRegua = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
		ClsAranha.ApagaRegua(siXpLDNFae4, mRLpLvE9hF2, tag, nRegua);
		pcApjLX9N6D();
		Application.UpdateScreen();
	}

	private void O5BpjMjJAQK(object P_0, EventArgs P_1)
	{
		string rev = "";
		int painel = 0;
		checked
		{
			if (ClsAranha.SelecionaBorne(ref rev, ref painel))
			{
				int num = dgRevisao.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!Operators.ConditionalCompareObjectEqual(dgRevisao[0, i].Value, rev, TextCompare: true))
					{
						continue;
					}
					dgRevisao.Rows[i].Selected = true;
					dgRevisao.FirstDisplayedScrollingRowIndex = i;
					int num2 = dgEquip.RowCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectEqual(dgEquip[0, j].Value, painel, TextCompare: true))
						{
							dgEquip.Rows[j].Selected = true;
							dgEquip.FirstDisplayedScrollingRowIndex = j;
							break;
						}
					}
					break;
				}
			}
			Application.UpdateScreen();
		}
	}

	private void ewTpjO5LfJX(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.jumper[] mJumpers = new DeclaracoesInterligacao.jumper[1];
		if (!ClsAranha.CarregaBornesJ(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ))
		{
			return;
		}
		ClsAranha.BuscaJumpers(ref mBornesJ, ref mJumpers, ref yGkpLdW3M1k);
		ClsAranha.ApagaJumper(siXpLDNFae4, mRLpLvE9hF2);
		if (Information.UBound(mJumpers) <= 0)
		{
			return;
		}
		int num = Information.UBound(mJumpers);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!mJumpers[i].bMesmaPaginaColuna)
			{
				if (!mJumpers[i].bMesmaPaginaColuna)
				{
					ClsAranha.DesenhaJumper2(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ, ref mJumpers, i);
				}
			}
			else
			{
				ClsAranha.DesenhaJumper1(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ, ref mJumpers, i);
			}
		}
		Application.UpdateScreen();
	}

	private void SP6pjIhZ9gO(object P_0, EventArgs P_1)
	{
		ClsAranha.ApagaJumper(siXpLDNFae4, mRLpLvE9hF2);
		Application.UpdateScreen();
	}

	private void kqSpj7j53FS(object P_0, EventArgs P_1)
	{
		ClsAranha.EspelhaJumperLeft();
		Application.UpdateScreen();
	}

	private void kRVpjqffg0A(object P_0, EventArgs P_1)
	{
		formataDGEsquerda();
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		List<string> lPaineis = new List<string>();
		if (!ClsAranha.CarregaBornesJ(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ))
		{
			return;
		}
		ClsAranha.CarregaEquipamentos5(ref yGkpLdW3M1k, ref mBornesJ, ref lPaineis);
		lPaineis.Sort();
		if (lPaineis.Count <= 0)
		{
			return;
		}
		foreach (string item in lPaineis)
		{
			dgEsquerda.Rows.Add(item);
		}
	}

	private void QLjpjaKI3B9(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		List<string> list = new List<string>();
		if (!ClsAranha.CarregaBornesJ(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ))
		{
			return;
		}
		checked
		{
			if (dgEsquerda.Rows.Count > 0)
			{
				int num = dgEsquerda.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					list.Add(Conversions.ToString(dgEsquerda.Rows[i].Cells[0].Value));
				}
			}
			ClsAranha.CarregaCabosInseridos(siXpLDNFae4, mRLpLvE9hF2, ref lCabosInseridos);
			ClsAranha.CarregaCabos(siXpLDNFae4, ref yGkpLdW3M1k, ref mBornesJ, ref mCabos, list);
			ClsAranha.InsereCabos(siXpLDNFae4, mRLpLvE9hF2, ref mCabos, lCabosInseridos, cbAterrarBlindagem.Checked);
			Application.UpdateScreen();
		}
	}

	private void HuZpj8KG5lp(object P_0, EventArgs P_1)
	{
		ClsAranha.ApagaCabos(siXpLDNFae4, mRLpLvE9hF2);
		ClsAranha.ApagaVeias(siXpLDNFae4, mRLpLvE9hF2);
		Application.UpdateScreen();
	}

	private void koHpjNgBTbw(object P_0, EventArgs P_1)
	{
		btVeias.Enabled = false;
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias = new DeclaracoesInterligacao.cruzamentoCaboAranha[1];
		if (ClsAranha.CarregaBornesJ(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ))
		{
			ClsAranha.AtualizaBornesJ(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ);
			ClsAranha.CarregaCabosInseridosViaVeias(siXpLDNFae4, mRLpLvE9hF2, ref lCabosInseridos);
			ClsAranha.CarregaCabosDWG(siXpLDNFae4, mRLpLvE9hF2, ref mCabos);
			ClsAranha.RelacionaCabosBornes(mRLpLvE9hF2, ref yGkpLdW3M1k, ref mBornesJ, ref mCabos);
			ClsAranha.VerificaErro(mCabos);
			ClsAranha.InsereVeias(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos);
			ClsAranha.InsereVeias2(siXpLDNFae4, mRLpLvE9hF2, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos);
			Application.UpdateScreen();
		}
		btVeias.Enabled = true;
	}

	private void K2kpjFmnJDh(object P_0, EventArgs P_1)
	{
		ClsAranha.ApagaVeias(siXpLDNFae4, mRLpLvE9hF2);
		Application.UpdateScreen();
	}

	private void oW1pjQojWot(object P_0, EventArgs P_1)
	{
		if (!rbC.Checked)
		{
			btEsquerda.Enabled = false;
			btMirrorJumperDown.Enabled = false;
		}
		else
		{
			btEsquerda.Enabled = true;
			btMirrorJumperDown.Enabled = true;
		}
	}

	private void mV3pjPkQNRh(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.caboSync[] mCabosSync = new DeclaracoesInterligacao.caboSync[1];
		DeclaracoesInterligacao.caboSync[] mTodosCabosSync = new DeclaracoesInterligacao.caboSync[1];
		cDadosAccess.carregaDadosDWG();
		ClsAranha.CarregaTodosCabosDWG(siXpLDNFae4, ref mCabosSync);
		List<int> lPn = new List<int>();
		int num = Information.UBound(mCabosSync);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!lPn.Contains(mCabosSync[i].Painel))
			{
				lPn.Add(mCabosSync[i].Painel);
			}
		}
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		cDadosAccessInterligacao3.ApagaCabosRevPn(siXpLDNFae4, ref lPn);
		cDadosAccessInterligacao3.exportaCabos(siXpLDNFae4, ref mCabosSync);
		cDadosAccessInterligacao3.leCabos(siXpLDNFae4, ref mTodosCabosSync);
		ClsAranha.LimpaCruzamentoCabos();
		ClsAranha.SincronizaCabos(siXpLDNFae4, mTodosCabosSync);
		cDadosAccessInterligacao3.fechaConexao();
		Application.UpdateScreen();
	}

	private void NAIpjc5Zwa4(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1899]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
			cDadosAtualizaBanco2.ApagaAranha4();
			cDadosAtualizaBanco2.fechaConexao();
		}
	}

	public void formataDGRevisao()
	{
		checked
		{
			try
			{
				dgRevisao.Rows.Clear();
				dgRevisao.Columns.Clear();
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 753]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 754]));
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num / 3f);
				dgRevisao.Columns[1].Width = (int)Math.Round(num / 3f);
				dgRevisao.Columns[2].Width = (int)Math.Round(num / 3f);
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
				of9pLt1MMAu = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				float num = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num);
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
				of9pLt1MMAu = false;
			}
		}
	}

	public void formataDGRegua()
	{
		checked
		{
			try
			{
				dgRegua.Rows.Clear();
				dgRegua.Columns.Clear();
				dgRegua.Columns.Add("", "Tipo");
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 110]));
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]));
				dgRegua.Columns.Add("", "#");
				float num = dgRegua.Width - 22;
				dgRegua.Columns[0].Width = 0;
				dgRegua.Columns[0].Visible = false;
				dgRegua.Columns[1].Width = (int)Math.Round(num * 2f / 4f);
				dgRegua.Columns[2].Width = (int)Math.Round((double)num * 1.2 / 4.0);
				dgRegua.Columns[3].Width = (int)Math.Round((double)num * 0.8 / 4.0);
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

	public void formataDGEsquerda()
	{
		checked
		{
			try
			{
				dgEsquerda.Rows.Clear();
				dgEsquerda.Columns.Clear();
				dgEsquerda.Columns.Add("", "Nome");
				float num = dgEsquerda.Width - 22;
				dgEsquerda.Columns[0].Width = (int)Math.Round(num);
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
}
