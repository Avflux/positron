using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.EditorInput;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class uscPaginas : UserControl
{
	public enum ProgressBarColor
	{
		Green = 1,
		Red,
		Yellow
	}

	private IContainer Bu3plo5vquB;

	[CompilerGenerated]
	[AccessedThroughProperty("dg")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView vn9plGvwlBI;

	[AccessedThroughProperty("cmStrip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ContextMenuStrip p4FplHYVvBk;

	[AccessedThroughProperty("EditarUnidadeToolStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripMenuItem jvdplken8Ij;

	[AccessedThroughProperty("EditarAlternativoToolStripMenuItem")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem idhpld9aFGV;

	[AccessedThroughProperty("ToolStripSeparator1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripSeparator EE1plfiZYWO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ExcluirPáginasToolStripMenuItem")]
	private ToolStripMenuItem CqfplDJtw5E;

	[CompilerGenerated]
	[AccessedThroughProperty("RenomearPáginasToolStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem ytKplvZHaSn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("AlternativoToolStripMenuItem")]
	private ToolStripMenuItem M8qpl6LhdJS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MultiseleçãoToolStripMenuItem")]
	private ToolStripMenuItem cWKpltrPZOw;

	[AccessedThroughProperty("ToolStripSeparator2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripSeparator uaopljZgLCB;

	[AccessedThroughProperty("CriarPaginaToolStripMenuItem")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem WX4plLl0OrW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("InserirToolStripMenuItem")]
	private ToolStripMenuItem O8aplwPuo2H;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripSeparator3")]
	private ToolStripSeparator ArZplxlvWjk;

	[AccessedThroughProperty("FolhaToolStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripComboBox w1fplb3Uaeu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("EditarTitulosToolStripMenuItem")]
	private ToolStripMenuItem FDlplM3F7qH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("EditarRevisoesToollStripMenuItem")]
	private ToolStripMenuItem acsplOlTEf2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RevSimplificadaToolStripMenuItem")]
	private ToolStripMenuItem QVGplIVOW4s;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("RevCompletaToolStripMenuItem")]
	private ToolStripMenuItem pZgpl7hgwSx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPagina")]
	private TextBox JU2plq8nx4F;

	[AccessedThroughProperty("btPagina")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button P9FplaYsJ97;

	[AccessedThroughProperty("lb1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label IBWpl84T8C8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lb2")]
	private Label m2mplN9JuFd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lb4")]
	private Label M5MplFhYKNk;

	[CompilerGenerated]
	[AccessedThroughProperty("lb3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label mZVplQ2L1on;

	[AccessedThroughProperty("btSalva")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button KIqplPF59s6;

	[AccessedThroughProperty("ToolStripMenuItem1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripMenuItem OXEplcI2XaH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem2")]
	private ToolStripMenuItem uLZplK5nm9o;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem3")]
	private ToolStripMenuItem DK8pleIWds8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripMenuItem4")]
	[CompilerGenerated]
	private ToolStripMenuItem CeSpl2h1P0V;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripMenuItem5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem OKdpl3mixai;

	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PictureBox djKplnM1l3x;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar rvGpl1ZtoCb;

	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PictureBox dxepllKZMer;

	public int Quantidade;

	public bool Passo;

	private bool zmrpl5cr22t;

	private bool UEipl0tKnkP;

	private bool fKqplRiGop5;

	private bool u8wplmSvBqh;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return vn9plGvwlBI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ykRp10riNnL;
			DataGridViewCellEventHandler value3 = j9Sp1mKZkcD;
			KeyEventHandler value4 = wZ0p1XlFJ5o;
			DataGridViewCellEventHandler value5 = Jnvplhw32hA;
			DataGridView dataGridView = vn9plGvwlBI;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
				dataGridView.CellEndEdit -= value3;
				dataGridView.KeyDown -= value4;
				dataGridView.CellContentClick -= value5;
			}
			vn9plGvwlBI = value;
			dataGridView = vn9plGvwlBI;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
				dataGridView.CellEndEdit += value3;
				dataGridView.KeyDown += value4;
				dataGridView.CellContentClick += value5;
			}
		}
	}

	internal virtual ContextMenuStrip cmStrip1
	{
		[CompilerGenerated]
		get
		{
			return p4FplHYVvBk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			p4FplHYVvBk = value;
		}
	}

	internal virtual ToolStripMenuItem EditarUnidadeToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return jvdplken8Ij;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bt6p1Bww9xD;
			ToolStripMenuItem toolStripMenuItem = jvdplken8Ij;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			jvdplken8Ij = value;
			toolStripMenuItem = jvdplken8Ij;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem EditarAlternativoToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return idhpld9aFGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = T5Qp1VoBCME;
			ToolStripMenuItem toolStripMenuItem = idhpld9aFGV;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			idhpld9aFGV = value;
			toolStripMenuItem = idhpld9aFGV;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		[CompilerGenerated]
		get
		{
			return EE1plfiZYWO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EE1plfiZYWO = value;
		}
	}

	internal virtual ToolStripMenuItem ExcluirPáginasToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return CqfplDJtw5E;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DhWp1iIyTvQ;
			ToolStripMenuItem toolStripMenuItem = CqfplDJtw5E;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			CqfplDJtw5E = value;
			toolStripMenuItem = CqfplDJtw5E;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem RenomearPáginasToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return ytKplvZHaSn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = C8Op1CM1YgS;
			ToolStripMenuItem toolStripMenuItem = ytKplvZHaSn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			ytKplvZHaSn = value;
			toolStripMenuItem = ytKplvZHaSn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AlternativoToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return M8qpl6LhdJS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uK5p1AIarkk;
			ToolStripMenuItem toolStripMenuItem = M8qpl6LhdJS;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			M8qpl6LhdJS = value;
			toolStripMenuItem = M8qpl6LhdJS;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem MultiseleçãoToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return cWKpltrPZOw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Swkp1y1gUG1;
			EventHandler value3 = BVdp1gNNvUG;
			ToolStripMenuItem toolStripMenuItem = cWKpltrPZOw;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.CheckedChanged -= value2;
				toolStripMenuItem.Click -= value3;
			}
			cWKpltrPZOw = value;
			toolStripMenuItem = cWKpltrPZOw;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.CheckedChanged += value2;
				toolStripMenuItem.Click += value3;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		[CompilerGenerated]
		get
		{
			return uaopljZgLCB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uaopljZgLCB = value;
		}
	}

	internal virtual ToolStripMenuItem CriarPaginaToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return WX4plLl0OrW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hgNp1ss9oWw;
			ToolStripMenuItem toolStripMenuItem = WX4plLl0OrW;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			WX4plLl0OrW = value;
			toolStripMenuItem = WX4plLl0OrW;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem InserirToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return O8aplwPuo2H;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			O8aplwPuo2H = value;
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator3
	{
		[CompilerGenerated]
		get
		{
			return ArZplxlvWjk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ArZplxlvWjk = value;
		}
	}

	internal virtual ToolStripComboBox FolhaToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return w1fplb3Uaeu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Es6p1Y15jTb;
			ToolStripComboBox toolStripComboBox = w1fplb3Uaeu;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.TextChanged -= value2;
			}
			w1fplb3Uaeu = value;
			toolStripComboBox = w1fplb3Uaeu;
			if (toolStripComboBox != null)
			{
				toolStripComboBox.TextChanged += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem EditarTitulosToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return FDlplM3F7qH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = z3Kp1uHJC5G;
			ToolStripMenuItem toolStripMenuItem = FDlplM3F7qH;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			FDlplM3F7qH = value;
			toolStripMenuItem = FDlplM3F7qH;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem EditarRevisoesToollStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return acsplOlTEf2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			acsplOlTEf2 = value;
		}
	}

	internal virtual ToolStripMenuItem RevSimplificadaToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return QVGplIVOW4s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Blcp1EA4dWJ;
			ToolStripMenuItem toolStripMenuItem = QVGplIVOW4s;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			QVGplIVOW4s = value;
			toolStripMenuItem = QVGplIVOW4s;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem RevCompletaToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return pZgpl7hgwSx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fplp1ZiHjHx;
			ToolStripMenuItem toolStripMenuItem = pZgpl7hgwSx;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			pZgpl7hgwSx = value;
			toolStripMenuItem = pZgpl7hgwSx;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual TextBox tbPagina
	{
		[CompilerGenerated]
		get
		{
			return JU2plq8nx4F;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JU2plq8nx4F = value;
		}
	}

	internal virtual Button btPagina
	{
		[CompilerGenerated]
		get
		{
			return P9FplaYsJ97;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tPRp15VpStR;
			Button button = P9FplaYsJ97;
			if (button != null)
			{
				button.Click -= value2;
			}
			P9FplaYsJ97 = value;
			button = P9FplaYsJ97;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lb1
	{
		[CompilerGenerated]
		get
		{
			return IBWpl84T8C8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RXnp13sEwHd;
			Label label = IBWpl84T8C8;
			if (label != null)
			{
				label.Click -= value2;
			}
			IBWpl84T8C8 = value;
			label = IBWpl84T8C8;
			if (label != null)
			{
				label.Click += value2;
			}
		}
	}

	internal virtual Label lb2
	{
		[CompilerGenerated]
		get
		{
			return m2mplN9JuFd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = e7qp1nZuNdI;
			Label label = m2mplN9JuFd;
			if (label != null)
			{
				label.Click -= value2;
			}
			m2mplN9JuFd = value;
			label = m2mplN9JuFd;
			if (label != null)
			{
				label.Click += value2;
			}
		}
	}

	internal virtual Label lb4
	{
		[CompilerGenerated]
		get
		{
			return M5MplFhYKNk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xPyp1ljbIB8;
			Label label = M5MplFhYKNk;
			if (label != null)
			{
				label.Click -= value2;
			}
			M5MplFhYKNk = value;
			label = M5MplFhYKNk;
			if (label != null)
			{
				label.Click += value2;
			}
		}
	}

	internal virtual Label lb3
	{
		[CompilerGenerated]
		get
		{
			return mZVplQ2L1on;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jXHp11IcvOu;
			Label label = mZVplQ2L1on;
			if (label != null)
			{
				label.Click -= value2;
			}
			mZVplQ2L1on = value;
			label = mZVplQ2L1on;
			if (label != null)
			{
				label.Click += value2;
			}
		}
	}

	internal virtual Button btSalva
	{
		[CompilerGenerated]
		get
		{
			return KIqplPF59s6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EDJp12YldpK;
			Button button = KIqplPF59s6;
			if (button != null)
			{
				button.Click -= value2;
			}
			KIqplPF59s6 = value;
			button = KIqplPF59s6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem1
	{
		[CompilerGenerated]
		get
		{
			return OXEplcI2XaH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ALbp1rlkV2U;
			ToolStripMenuItem toolStripMenuItem = OXEplcI2XaH;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			OXEplcI2XaH = value;
			toolStripMenuItem = OXEplcI2XaH;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem2
	{
		[CompilerGenerated]
		get
		{
			return uLZplK5nm9o;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yvkp19tK4tH;
			ToolStripMenuItem toolStripMenuItem = uLZplK5nm9o;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			uLZplK5nm9o = value;
			toolStripMenuItem = uLZplK5nm9o;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem3
	{
		[CompilerGenerated]
		get
		{
			return DK8pleIWds8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ldUp1zs1gc7;
			ToolStripMenuItem toolStripMenuItem = DK8pleIWds8;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			DK8pleIWds8 = value;
			toolStripMenuItem = DK8pleIWds8;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem4
	{
		[CompilerGenerated]
		get
		{
			return CeSpl2h1P0V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DTMplWw4hxb;
			ToolStripMenuItem toolStripMenuItem = CeSpl2h1P0V;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			CeSpl2h1P0V = value;
			toolStripMenuItem = CeSpl2h1P0V;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem5
	{
		[CompilerGenerated]
		get
		{
			return OKdpl3mixai;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oIPplp5NlDs;
			ToolStripMenuItem toolStripMenuItem = OKdpl3mixai;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			OKdpl3mixai = value;
			toolStripMenuItem = OKdpl3mixai;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return djKplnM1l3x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			djKplnM1l3x = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return rvGpl1ZtoCb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rvGpl1ZtoCb = value;
		}
	}

	internal virtual PictureBox PictureBox2
	{
		[CompilerGenerated]
		get
		{
			return dxepllKZMer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dxepllKZMer = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && Bu3plo5vquB != null)
			{
				Bu3plo5vquB.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void P7Vp1P0bp1h()
	{
		Bu3plo5vquB = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dg = new DataGridView();
		cmStrip1 = new ContextMenuStrip(Bu3plo5vquB);
		MultiseleçãoToolStripMenuItem = new ToolStripMenuItem();
		AlternativoToolStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator2 = new ToolStripSeparator();
		CriarPaginaToolStripMenuItem = new ToolStripMenuItem();
		InserirToolStripMenuItem = new ToolStripMenuItem();
		ToolStripMenuItem1 = new ToolStripMenuItem();
		ToolStripMenuItem2 = new ToolStripMenuItem();
		ToolStripMenuItem3 = new ToolStripMenuItem();
		ToolStripMenuItem4 = new ToolStripMenuItem();
		ToolStripMenuItem5 = new ToolStripMenuItem();
		ExcluirPáginasToolStripMenuItem = new ToolStripMenuItem();
		RenomearPáginasToolStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator1 = new ToolStripSeparator();
		EditarUnidadeToolStripMenuItem = new ToolStripMenuItem();
		EditarAlternativoToolStripMenuItem = new ToolStripMenuItem();
		EditarTitulosToolStripMenuItem = new ToolStripMenuItem();
		EditarRevisoesToollStripMenuItem = new ToolStripMenuItem();
		RevSimplificadaToolStripMenuItem = new ToolStripMenuItem();
		RevCompletaToolStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator3 = new ToolStripSeparator();
		FolhaToolStripMenuItem = new ToolStripComboBox();
		tbPagina = new TextBox();
		btPagina = new Button();
		lb1 = new Label();
		lb2 = new Label();
		lb4 = new Label();
		lb3 = new Label();
		btSalva = new Button();
		PictureBox1 = new PictureBox();
		ProgressBar1 = new ProgressBar();
		PictureBox2 = new PictureBox();
		((ISupportInitialize)dg).BeginInit();
		cmStrip1.SuspendLayout();
		((ISupportInitialize)PictureBox1).BeginInit();
		((ISupportInitialize)PictureBox2).BeginInit();
		SuspendLayout();
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = SystemColors.Control;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.ContextMenuStrip = cmStrip1;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dg.DefaultCellStyle = dataGridViewCellStyle2;
		dg.Location = new Point(9, 51);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.ForeColor = SystemColors.ActiveCaptionText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlLightLight;
		dg.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dg.ScrollBars = ScrollBars.Vertical;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(152, 369);
		dg.TabIndex = 0;
		cmStrip1.BackColor = SystemColors.Control;
		cmStrip1.Items.AddRange(new ToolStripItem[14]
		{
			MultiseleçãoToolStripMenuItem, AlternativoToolStripMenuItem, ToolStripSeparator2, CriarPaginaToolStripMenuItem, InserirToolStripMenuItem, ExcluirPáginasToolStripMenuItem, RenomearPáginasToolStripMenuItem, ToolStripSeparator1, EditarUnidadeToolStripMenuItem, EditarAlternativoToolStripMenuItem,
			EditarTitulosToolStripMenuItem, EditarRevisoesToollStripMenuItem, ToolStripSeparator3, FolhaToolStripMenuItem
		});
		cmStrip1.Name = "cmStrip1";
		cmStrip1.Size = new Size(186, 271);
		MultiseleçãoToolStripMenuItem.Checked = true;
		MultiseleçãoToolStripMenuItem.CheckState = CheckState.Checked;
		MultiseleçãoToolStripMenuItem.Name = "MultiseleçãoToolStripMenuItem";
		MultiseleçãoToolStripMenuItem.Size = new Size(185, 22);
		MultiseleçãoToolStripMenuItem.Text = "Multiseleção";
		AlternativoToolStripMenuItem.Checked = true;
		AlternativoToolStripMenuItem.CheckState = CheckState.Checked;
		AlternativoToolStripMenuItem.Name = "AlternativoToolStripMenuItem";
		AlternativoToolStripMenuItem.Size = new Size(185, 22);
		AlternativoToolStripMenuItem.Text = "Alternativo";
		ToolStripSeparator2.Name = "ToolStripSeparator2";
		ToolStripSeparator2.Size = new Size(182, 6);
		CriarPaginaToolStripMenuItem.Image = Resources.Pagina;
		CriarPaginaToolStripMenuItem.Name = "CriarPaginaToolStripMenuItem";
		CriarPaginaToolStripMenuItem.Size = new Size(185, 22);
		CriarPaginaToolStripMenuItem.Text = "Nova Página";
		InserirToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5] { ToolStripMenuItem1, ToolStripMenuItem2, ToolStripMenuItem3, ToolStripMenuItem4, ToolStripMenuItem5 });
		InserirToolStripMenuItem.Image = Resources.Colunas2;
		InserirToolStripMenuItem.Name = "InserirToolStripMenuItem";
		InserirToolStripMenuItem.Size = new Size(185, 22);
		InserirToolStripMenuItem.Text = "Inserir";
		ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		ToolStripMenuItem1.Size = new Size(193, 22);
		ToolStripMenuItem1.Text = "ToolStripMenuItem1";
		ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		ToolStripMenuItem2.Size = new Size(193, 22);
		ToolStripMenuItem2.Text = "ToolStripMenuItem2";
		ToolStripMenuItem3.Name = "ToolStripMenuItem3";
		ToolStripMenuItem3.Size = new Size(193, 22);
		ToolStripMenuItem3.Text = "ToolStripMenuItem3";
		ToolStripMenuItem4.Name = "ToolStripMenuItem4";
		ToolStripMenuItem4.Size = new Size(193, 22);
		ToolStripMenuItem4.Text = "ToolStripMenuItem4";
		ToolStripMenuItem5.Name = "ToolStripMenuItem5";
		ToolStripMenuItem5.Size = new Size(193, 22);
		ToolStripMenuItem5.Text = "ToolStripMenuItem5";
		ExcluirPáginasToolStripMenuItem.Image = Resources.Apagar;
		ExcluirPáginasToolStripMenuItem.Name = "ExcluirPáginasToolStripMenuItem";
		ExcluirPáginasToolStripMenuItem.Size = new Size(185, 22);
		ExcluirPáginasToolStripMenuItem.Text = "Excluir Páginas";
		RenomearPáginasToolStripMenuItem.Image = Resources.Renomear;
		RenomearPáginasToolStripMenuItem.Name = "RenomearPáginasToolStripMenuItem";
		RenomearPáginasToolStripMenuItem.Size = new Size(185, 22);
		RenomearPáginasToolStripMenuItem.Text = "Renomear Páginas";
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(182, 6);
		EditarUnidadeToolStripMenuItem.Image = Resources.Editar_16;
		EditarUnidadeToolStripMenuItem.Name = "EditarUnidadeToolStripMenuItem";
		EditarUnidadeToolStripMenuItem.Size = new Size(185, 22);
		EditarUnidadeToolStripMenuItem.Text = "Editar Unidade";
		EditarAlternativoToolStripMenuItem.Image = Resources.Editar_16;
		EditarAlternativoToolStripMenuItem.Name = "EditarAlternativoToolStripMenuItem";
		EditarAlternativoToolStripMenuItem.Size = new Size(185, 22);
		EditarAlternativoToolStripMenuItem.Text = "Editar Alternativo";
		EditarTitulosToolStripMenuItem.Image = Resources.Editar_16;
		EditarTitulosToolStripMenuItem.Name = "EditarTitulosToolStripMenuItem";
		EditarTitulosToolStripMenuItem.Size = new Size(185, 22);
		EditarTitulosToolStripMenuItem.Text = "Editar Tíitulos";
		EditarRevisoesToollStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2] { RevSimplificadaToolStripMenuItem, RevCompletaToolStripMenuItem });
		EditarRevisoesToollStripMenuItem.Image = Resources.Editar_16;
		EditarRevisoesToollStripMenuItem.Name = "EditarRevisoesToollStripMenuItem";
		EditarRevisoesToollStripMenuItem.Size = new Size(185, 22);
		EditarRevisoesToollStripMenuItem.Text = "Editar Revisoes";
		RevSimplificadaToolStripMenuItem.Name = "RevSimplificadaToolStripMenuItem";
		RevSimplificadaToolStripMenuItem.Size = new Size(146, 22);
		RevSimplificadaToolStripMenuItem.Text = "Simplificada";
		RevCompletaToolStripMenuItem.Name = "RevCompletaToolStripMenuItem";
		RevCompletaToolStripMenuItem.Size = new Size(146, 22);
		RevCompletaToolStripMenuItem.Text = "Completa";
		ToolStripSeparator3.Name = "ToolStripSeparator3";
		ToolStripSeparator3.Size = new Size(182, 6);
		FolhaToolStripMenuItem.AccessibleName = "";
		FolhaToolStripMenuItem.Name = "FolhaToolStripMenuItem";
		FolhaToolStripMenuItem.Size = new Size(90, 25);
		FolhaToolStripMenuItem.Tag = "";
		tbPagina.CharacterCasing = CharacterCasing.Upper;
		tbPagina.Location = new Point(9, 25);
		tbPagina.MaxLength = 7;
		tbPagina.Name = "tbPagina";
		tbPagina.Size = new Size(45, 20);
		tbPagina.TabIndex = 1;
		btPagina.FlatStyle = FlatStyle.Flat;
		btPagina.ForeColor = SystemColors.Control;
		btPagina.Image = Resources.Enter_16;
		btPagina.Location = new Point(55, 24);
		btPagina.Name = "btPagina";
		btPagina.Size = new Size(25, 20);
		btPagina.TabIndex = 2;
		btPagina.UseVisualStyleBackColor = true;
		lb1.BorderStyle = BorderStyle.FixedSingle;
		lb1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lb1.Location = new Point(80, 7);
		lb1.Name = "lb1";
		lb1.Size = new Size(46, 15);
		lb1.TabIndex = 4;
		lb1.Text = "55555A";
		lb1.TextAlign = ContentAlignment.MiddleCenter;
		lb2.BorderStyle = BorderStyle.FixedSingle;
		lb2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lb2.Location = new Point(128, 7);
		lb2.Name = "lb2";
		lb2.Size = new Size(46, 15);
		lb2.TabIndex = 5;
		lb2.Text = "55555A";
		lb2.TextAlign = ContentAlignment.MiddleCenter;
		lb4.BorderStyle = BorderStyle.FixedSingle;
		lb4.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lb4.Location = new Point(128, 27);
		lb4.Name = "lb4";
		lb4.Size = new Size(46, 15);
		lb4.TabIndex = 7;
		lb4.Text = "55555A";
		lb4.TextAlign = ContentAlignment.MiddleCenter;
		lb3.BorderStyle = BorderStyle.FixedSingle;
		lb3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lb3.Location = new Point(80, 27);
		lb3.Name = "lb3";
		lb3.Size = new Size(46, 15);
		lb3.TabIndex = 6;
		lb3.Text = "55555A";
		lb3.TextAlign = ContentAlignment.MiddleCenter;
		btSalva.FlatStyle = FlatStyle.Flat;
		btSalva.ForeColor = SystemColors.Control;
		btSalva.Image = Resources.Record_16;
		btSalva.Location = new Point(55, 3);
		btSalva.Name = "btSalva";
		btSalva.Size = new Size(25, 20);
		btSalva.TabIndex = 0;
		btSalva.UseVisualStyleBackColor = true;
		PictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		PictureBox1.Image = Resources.eletron_grande21;
		PictureBox1.Location = new Point(9, 439);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(162, 28);
		PictureBox1.TabIndex = 8;
		PictureBox1.TabStop = false;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.ForeColor = Color.Transparent;
		ProgressBar1.Location = new Point(9, 426);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(152, 7);
		ProgressBar1.TabIndex = 24;
		PictureBox2.BackColor = Color.Transparent;
		PictureBox2.Image = Resources.DB_DISCONNECTED;
		PictureBox2.Location = new Point(16, 7);
		PictureBox2.Name = "PictureBox2";
		PictureBox2.Size = new Size(31, 17);
		PictureBox2.TabIndex = 26;
		PictureBox2.TabStop = false;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		Controls.Add(PictureBox2);
		Controls.Add(ProgressBar1);
		Controls.Add(PictureBox1);
		Controls.Add(btSalva);
		Controls.Add(lb4);
		Controls.Add(lb3);
		Controls.Add(lb2);
		Controls.Add(lb1);
		Controls.Add(tbPagina);
		Controls.Add(dg);
		Controls.Add(btPagina);
		Name = "uscPaginas";
		Size = new Size(171, 472);
		((ISupportInitialize)dg).EndInit();
		cmStrip1.ResumeLayout(performLayout: false);
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)PictureBox2).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

	private static void aGSp1cgg3tL(ProgressBar P_0, ProgressBarColor P_1)
	{
		SendMessage(P_0.Handle, 1040, (int)P_1, 0);
	}

	public void pbIniciar()
	{
		ProgressBar1.Minimum = 0;
		if (Quantidade < 0)
		{
			Quantidade = 0;
		}
		ProgressBar1.Maximum = Quantidade;
		ProgressBar1.Step = 1;
		aGSp1cgg3tL(ProgressBar1, ProgressBarColor.Red);
	}

	public void pbPasso(int iPasso = 1)
	{
		ProgressBar1.Increment(iPasso);
	}

	public void pbFim()
	{
		ProgressBar1.Value = 0;
		ProgressBar1.Minimum = 0;
		ProgressBar1.Maximum = 0;
	}

	public uscPaginas()
	{
		Resize += dSYplTtjY5W;
		UEipl0tKnkP = false;
		fKqplRiGop5 = false;
		u8wplmSvBqh = false;
		P7Vp1P0bp1h();
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4", writable: true);
		if (registryKey != null)
		{
			UEipl0tKnkP = Conversions.ToBoolean(registryKey.GetValue("Altern", "0"));
		}
		else
		{
			registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4");
			registryKey.SetValue("Altern", "0");
			UEipl0tKnkP = false;
		}
		registryKey.Close();
		MultiseleçãoToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 14]);
		AlternativoToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]);
		CriarPaginaToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 29]);
		InserirToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 35]);
		ToolStripMenuItem1.Text = "ELET1_";
		ToolStripMenuItem2.Text = "ELET2_";
		ToolStripMenuItem3.Text = "ELET3_";
		ToolStripMenuItem4.Text = "ELET4_";
		ToolStripMenuItem5.Text = "ELET5_";
		ExcluirPáginasToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 21]);
		RenomearPáginasToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 22]);
		EditarUnidadeToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 12]);
		EditarAlternativoToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 13]);
		EditarTitulosToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 44]);
		EditarRevisoesToollStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 58]);
		RevSimplificadaToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 59]);
		RevCompletaToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 60]);
		FolhaToolStripMenuItem.Items.Add("12");
		FolhaToolStripMenuItem.Items.Add("012");
		FolhaToolStripMenuItem.Items.Add("0012");
		FolhaToolStripMenuItem.Items.Add("00012");
		FolhaToolStripMenuItem.Items.Add("000012");
		FolhaToolStripMenuItem.Items.Add("0000012");
		FolhaToolStripMenuItem.BackColor = Color.LightGray;
		FolhaToolStripMenuItem.FlatStyle = FlatStyle.Standard;
		MultiseleçãoToolStripMenuItem.Checked = false;
		AlternativoToolStripMenuItem.Checked = UEipl0tKnkP;
		if (!AlternativoToolStripMenuItem.Checked)
		{
			EditarAlternativoToolStripMenuItem.Visible = false;
		}
		else
		{
			EditarAlternativoToolStripMenuItem.Visible = true;
		}
	}

	public void CarregaPG()
	{
		lb1.Text = DeclaracoesGeral.atalhosPag.atalho1;
		lb2.Text = DeclaracoesGeral.atalhosPag.atalho2;
		lb3.Text = DeclaracoesGeral.atalhosPag.atalho3;
		lb4.Text = DeclaracoesGeral.atalhosPag.atalho4;
		Y9op1KgeRgW();
		VSWp1ebyWra();
		fKqplRiGop5 = true;
		switch (DeclaracoesGeral.Conf.LarguraFixaPaginas)
		{
		case 7:
			FolhaToolStripMenuItem.Text = "0000012";
			break;
		case 0:
			FolhaToolStripMenuItem.Text = "12";
			break;
		case 3:
			FolhaToolStripMenuItem.Text = "012";
			break;
		case 4:
			FolhaToolStripMenuItem.Text = "0012";
			break;
		case 5:
			FolhaToolStripMenuItem.Text = "00012";
			break;
		case 6:
			FolhaToolStripMenuItem.Text = "000012";
			break;
		}
		fKqplRiGop5 = false;
		if (!(!DeclaracoesGeral.Conf.SCapa & !DeclaracoesGeral.Conf.SCorpo))
		{
			RevSimplificadaToolStripMenuItem.Enabled = true;
		}
		else
		{
			RevSimplificadaToolStripMenuItem.Enabled = false;
		}
		if (!(!DeclaracoesGeral.Conf.CCapa & !DeclaracoesGeral.Conf.CCorpo))
		{
			RevCompletaToolStripMenuItem.Enabled = true;
		}
		else
		{
			RevCompletaToolStripMenuItem.Enabled = false;
		}
		DeclaracoesGeral.LayersExtra bLayers = default;
		Pagina.verificaLayerExtraNoFormato(ref bLayers);
		ToolStripMenuItem1.Visible = bLayers.bELET1;
		ToolStripMenuItem2.Visible = bLayers.bELET2;
		ToolStripMenuItem3.Visible = bLayers.bELET3;
		ToolStripMenuItem4.Visible = bLayers.bELET4;
		ToolStripMenuItem5.Visible = bLayers.bELET5;
		ToolStripMenuItem1.Text = bLayers.sELET1;
		ToolStripMenuItem2.Text = bLayers.sELET2;
		ToolStripMenuItem3.Text = bLayers.sELET3;
		ToolStripMenuItem4.Text = bLayers.sELET4;
		ToolStripMenuItem5.Text = bLayers.sELET5;
		if (!(!bLayers.bELET1 & !bLayers.bELET2 & !bLayers.bELET3 & !bLayers.bELET4 & !bLayers.bELET5))
		{
			InserirToolStripMenuItem.Visible = true;
		}
		else
		{
			InserirToolStripMenuItem.Visible = false;
		}
	}

	private void Y9op1KgeRgW()
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 11]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]));
		dg.Columns.Add("", "Pg");
		dg.Columns.Add("", "PgDecimal");
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			float num2 = dg.Width - 20;
			if (!UEipl0tKnkP)
			{
				dg.Columns[0].Width = (int)Math.Round(num2 * 2f / 5f);
				dg.Columns[1].Width = (int)Math.Round(num2 * 3f / 5f);
				dg.Columns[2].Width = 0;
				dg.Columns[2].Visible = false;
				dg.Columns[3].Width = 0;
				dg.Columns[3].Visible = false;
				dg.Columns[4].Width = 0;
				dg.Columns[4].Visible = false;
			}
			else
			{
				dg.Columns[0].Width = (int)Math.Round(num2 / 3f);
				dg.Columns[1].Width = (int)Math.Round(num2 / 3f);
				dg.Columns[2].Width = (int)Math.Round(num2 / 3f);
				dg.Columns[3].Width = 0;
				dg.Columns[3].Visible = false;
				dg.Columns[4].Width = 0;
				dg.Columns[4].Visible = false;
			}
			if ((Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "D", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "A", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "V", TextCompare: true) == 0))
			{
				dg.Columns[0].Width = (int)Math.Round(num2 * 2f / 5f);
				dg.Columns[1].Width = (int)Math.Round(num2 * 3f / 5f);
				dg.Columns[2].Width = 0;
				dg.Columns[2].Visible = false;
				dg.Columns[3].Width = 0;
				dg.Columns[3].Visible = false;
				dg.Columns[4].Width = 0;
				dg.Columns[4].Visible = false;
			}
			dg.ReadOnly = true;
			dg.AllowUserToAddRows = false;
		}
	}

	private void VSWp1ebyWra()
	{
		checked
		{
			try
			{
				zmrpl5cr22t = true;
				MultiseleçãoToolStripMenuItem.Checked = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.MultiSelect = false;
				int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
				for (int i = 1; i <= num; i++)
				{
					dg.Rows.Add(Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]), Conversions.ToString(DeclaracoesGeral.mPaginas[3, i]), Conversions.ToString(DeclaracoesGeral.mPaginas[4, i]), Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]), DeclaracoesGeral.mPaginas[1, i]);
				}
				if (Information.UBound(DeclaracoesGeral.mPaginas, 2) > 0)
				{
					int num2 = dg.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[0].Value, DeclaracoesGeral.ativo.Pagina, TextCompare: true))
						{
							dg.Rows[j].Selected = true;
							DeclaracoesGeral.ativo.Unidade = Conversions.ToString(dg.Rows[j].Cells[1].Value);
							DeclaracoesGeral.ativo.Alternativo = Conversions.ToString(dg.Rows[j].Cells[2].Value);
							dg.FirstDisplayedScrollingRowIndex = j;
							tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
							break;
						}
					}
				}
				if (!((Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "D", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "A", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "V", TextCompare: true) == 0)))
				{
					if (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "E", TextCompare: true) == 0)
					{
						dg.ReadOnly = false;
						dg.ContextMenuStrip = cmStrip1;
					}
				}
				else
				{
					dg.ReadOnly = true;
					dg.ContextMenuStrip = null;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				zmrpl5cr22t = false;
			}
		}
	}

	private void EDJp12YldpK(object P_0, EventArgs P_1)
	{
		u8wplmSvBqh = true;
	}

	private void RXnp13sEwHd(object P_0, EventArgs P_1)
	{
		if (u8wplmSvBqh)
		{
			lb1.Text = DeclaracoesGeral.ativo.Pagina;
			DeclaracoesGeral.atalhosPag.atalho1 = lb1.Text;
			Dicionario.gravaAtalhos();
			u8wplmSvBqh = false;
			return;
		}
		Label label;
		string pag = (label = lb1).Text;
		bool flag = ativaPaginaAtalho(ref pag);
		label.Text = pag;
		if (!flag)
		{
			lb1.Text = "";
			DeclaracoesGeral.atalhosPag.atalho1 = "";
			Dicionario.gravaAtalhos();
		}
	}

	private void e7qp1nZuNdI(object P_0, EventArgs P_1)
	{
		if (u8wplmSvBqh)
		{
			lb2.Text = DeclaracoesGeral.ativo.Pagina;
			DeclaracoesGeral.atalhosPag.atalho2 = lb2.Text;
			Dicionario.gravaAtalhos();
			u8wplmSvBqh = false;
			return;
		}
		Label label;
		string pag = (label = lb2).Text;
		bool flag = ativaPaginaAtalho(ref pag);
		label.Text = pag;
		if (!flag)
		{
			lb2.Text = "";
			DeclaracoesGeral.atalhosPag.atalho2 = "";
			Dicionario.gravaAtalhos();
		}
	}

	private void jXHp11IcvOu(object P_0, EventArgs P_1)
	{
		if (u8wplmSvBqh)
		{
			lb3.Text = DeclaracoesGeral.ativo.Pagina;
			DeclaracoesGeral.atalhosPag.atalho3 = lb3.Text;
			Dicionario.gravaAtalhos();
			u8wplmSvBqh = false;
			return;
		}
		Label label;
		string pag = (label = lb3).Text;
		bool flag = ativaPaginaAtalho(ref pag);
		label.Text = pag;
		if (!flag)
		{
			lb3.Text = "";
			DeclaracoesGeral.atalhosPag.atalho3 = "";
			Dicionario.gravaAtalhos();
		}
	}

	private void xPyp1ljbIB8(object P_0, EventArgs P_1)
	{
		if (u8wplmSvBqh)
		{
			lb4.Text = DeclaracoesGeral.ativo.Pagina;
			DeclaracoesGeral.atalhosPag.atalho4 = lb4.Text;
			Dicionario.gravaAtalhos();
			u8wplmSvBqh = false;
			return;
		}
		Label label;
		string pag = (label = lb4).Text;
		bool flag = ativaPaginaAtalho(ref pag);
		label.Text = pag;
		if (!flag)
		{
			lb4.Text = "";
			DeclaracoesGeral.atalhosPag.atalho4 = "";
			Dicionario.gravaAtalhos();
		}
	}

	public bool ativaPaginaAtalho(ref string pag)
	{
		bool result = false;
		checked
		{
			if (pag.Length != 0)
			{
				pag = Pagina.montaNumeroPagina(pag);
				int num = dg.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[0].Value, pag, TextCompare: true))
					{
						Pagina.AtivaPagina(pag);
						dg.Rows[i].Selected = true;
						DeclaracoesGeral.ativo.Unidade = Conversions.ToString(dg.Rows[i].Cells[1].Value);
						DeclaracoesGeral.ativo.Alternativo = Conversions.ToString(dg.Rows[i].Cells[2].Value);
						dg.FirstDisplayedScrollingRowIndex = i;
						tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
						result = true;
						break;
					}
				}
			}
			return result;
		}
	}

	public void AtualizaDGpaginaAtiva()
	{
		checked
		{
			try
			{
				zmrpl5cr22t = true;
				MultiseleçãoToolStripMenuItem.Checked = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.MultiSelect = false;
				int num = dg.Rows.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (Operators.ConditionalCompareObjectEqual(dg.Rows[num2].Cells[0].Value, DeclaracoesGeral.ativo.Pagina, TextCompare: true))
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				dg.Rows[num2].Selected = true;
				DeclaracoesGeral.ativo.Unidade = Conversions.ToString(dg.Rows[num2].Cells[1].Value);
				DeclaracoesGeral.ativo.Alternativo = Conversions.ToString(dg.Rows[num2].Cells[2].Value);
				dg.FirstDisplayedScrollingRowIndex = num2;
				tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				zmrpl5cr22t = false;
			}
		}
	}

	private void tPRp15VpStR(object P_0, EventArgs P_1)
	{
		MultiseleçãoToolStripMenuItem.Checked = false;
		dg.MultiSelect = false;
		string text = tbPagina.Text.Trim();
		if (text.Length == 0)
		{
			return;
		}
		text = Pagina.montaNumeroPagina(text);
		bool flag = false;
		if (!Pagina.LayerValido(text))
		{
			tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
			return;
		}
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[0].Value, text, TextCompare: true))
				{
					Pagina.AtivaPagina(text);
					dg.Rows[i].Selected = true;
					DeclaracoesGeral.ativo.Unidade = Conversions.ToString(dg.Rows[i].Cells[1].Value);
					DeclaracoesGeral.ativo.Alternativo = Conversions.ToString(dg.Rows[i].Cells[2].Value);
					dg.FirstDisplayedScrollingRowIndex = i;
					tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
			}
		}
	}

	private void ykRp10riNnL(object P_0, EventArgs P_1)
	{
		if ((dg.SelectedRows.Count == 1) & !zmrpl5cr22t)
		{
			p50p1Rn9ohn();
		}
	}

	private void p50p1Rn9ohn()
	{
		DeclaracoesGeral.ativo.Pagina = Conversions.ToString(dg.SelectedRows[0].Cells[0].Value);
		DeclaracoesGeral.ativo.Unidade = Conversions.ToString(dg.SelectedRows[0].Cells[1].Value);
		DeclaracoesGeral.ativo.Alternativo = Conversions.ToString(dg.SelectedRows[0].Cells[2].Value);
		Pagina.AtivaPagina(DeclaracoesGeral.ativo.Pagina);
		tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
		Focus();
	}

	private void j9Sp1mKZkcD(object P_0, DataGridViewCellEventArgs P_1)
	{
		string text = "";
		text = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
		if (text == null)
		{
			text = "";
		}
		text = text.Trim();
		if (P_1.ColumnIndex == 0)
		{
			if (Operators.CompareString(text, "", TextCompare: true) != 0)
			{
				text = text.ToUpper();
			}
			if (Operators.CompareString(text, "", TextCompare: true) == 0)
			{
				text = DeclaracoesGeral.ativo.Pagina;
				dg.Rows[P_1.RowIndex].Cells[0].Value = text;
				return;
			}
		}
		dg.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value = text;
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		checked
		{
			try
			{
				switch (P_1.ColumnIndex)
				{
				case 2:
					text2 = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[0].Value);
					text4 = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[1].Value);
					text5 = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
					if (Strings.Len(text5) > 20)
					{
						text5 = Strings.Mid(text5, 1, 20);
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1927]));
						dg.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value = text5;
					}
					XDataGeral.AlteraXDataUnidadeAlternativo(text2, text4, text5);
					Pagina.CarregaPaginas();
					Pagina.OrdenaMatrizPaginas();
					Pagina.AtualizaContTotFl();
					Application.UpdateScreen();
					break;
				case 0:
					if (P_1.RowIndex != 0)
					{
						text2 = dg.Rows[P_1.RowIndex].Cells[0].Value.ToString().Trim();
						if (!Versioned.IsNumeric(text2))
						{
							if (text2.Length == 1 && !Versioned.IsNumeric(text2))
							{
								dg.Rows[P_1.RowIndex].Cells[0].Value = RuntimeHelpers.GetObjectValue(dg.Rows[P_1.RowIndex].Cells[3].Value);
								break;
							}
							int num = text2.Length - 1;
							for (int i = 1; i <= num; i++)
							{
								if (!Versioned.IsNumeric(Strings.Mid(text2, i, 1)))
								{
									dg.Rows[P_1.RowIndex].Cells[0].Value = RuntimeHelpers.GetObjectValue(dg.Rows[P_1.RowIndex].Cells[3].Value);
									return;
								}
							}
						}
						text2 = Pagina.montaNumeroPagina(text2);
						if (!Pagina.LayerValido(text2))
						{
							dg.Rows[P_1.RowIndex].Cells[0].Value = RuntimeHelpers.GetObjectValue(dg.Rows[P_1.RowIndex].Cells[3].Value);
						}
						else
						{
							dg.Rows[P_1.RowIndex].Cells[0].Value = text2;
							text3 = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[3].Value);
							if (Operators.CompareString(text3, text2, TextCompare: true) == 0)
							{
								break;
							}
							if (Pagina.renumerarPagina(text3, text2))
							{
								Y9op1KgeRgW();
								VSWp1ebyWra();
								tbPagina.Text = text2;
							}
							else
							{
								dg.Rows[P_1.RowIndex].Cells[0].Value = RuntimeHelpers.GetObjectValue(dg.Rows[P_1.RowIndex].Cells[3].Value);
							}
						}
						clsConexao.sincronizaCircuitos();
						clsInterligacao.SincronizaCruzamentoInterlig();
						clsDePara.SincronizaDePara(bUpdateProp: false);
						clsDispositivoAuxiliares.SincronizaContatos();
						clsPortas.SincronizaPortas();
					}
					else
					{
						dg.Rows[P_1.RowIndex].Cells[0].Value = RuntimeHelpers.GetObjectValue(dg.Rows[P_1.RowIndex].Cells[3].Value);
					}
					break;
				case 1:
					text2 = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[0].Value);
					text4 = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
					text5 = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[2].Value);
					XDataGeral.AlteraXDataUnidadeAlternativo(text2, text4, text5);
					Pagina.CarregaPaginas();
					Pagina.OrdenaMatrizPaginas();
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void wZ0p1XlFJ5o(object P_0, KeyEventArgs P_1)
	{
		if (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "E", TextCompare: true) != 0)
		{
			return;
		}
		try
		{
			if (P_1.KeyCode != Keys.Insert)
			{
				if (P_1.KeyCode == Keys.Delete)
				{
					cPup1SWxSYc();
				}
			}
			else
			{
				TBNp1Uume8n();
				tbPagina.Text = DeclaracoesGeral.ativo.Pagina;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void TBNp1Uume8n()
	{
		checked
		{
			try
			{
				if (!dg.MultiSelect)
				{
					int index = dg.SelectedRows[0].Index;
					DeclaracoesGeral.tPagina pag = default;
					DeclaracoesGeral.tPagina pagPost = default;
					DeclaracoesGeral.tPagina pagCorrente = default;
					pag.Pagina = Conversions.ToString(dg.Rows[index].Cells[0].Value);
					pagCorrente.Unidade = Conversions.ToString(dg.Rows[index].Cells[1].Value);
					pagCorrente.Alternativo = Conversions.ToString(dg.Rows[index].Cells[2].Value);
					Pagina.capturaTitulosDeUmaPagina(ref pag);
					pagCorrente.Pagina = "";
					if (index != dg.Rows.Count - 1)
					{
						pagPost.Pagina = Conversions.ToString(dg.Rows[index + 1].Cells[0].Value);
					}
					else
					{
						pagPost.Pagina = "1000000";
					}
					Pagina.calculaNovaPagina(ref pag, ref pagCorrente, ref pagPost);
					if (Conversions.ToDouble(pagCorrente.PgNum) != 0.0)
					{
						dg.Rows.Add("", "", "", "", "");
						int num = dg.Rows.Count - 2;
						int num2 = index + 1;
						for (int i = num; i >= num2; i += -1)
						{
							dg.Rows[i + 1].SetValues(dg.Rows[i].Cells[0].Value, dg.Rows[i].Cells[1].Value, dg.Rows[i].Cells[2].Value, dg.Rows[i].Cells[3].Value, dg.Rows[i].Cells[4].Value);
						}
						dg.Rows[index + 1].SetValues(dg.Rows[index].Cells[0].Value, dg.Rows[index].Cells[1].Value, dg.Rows[index].Cells[2].Value, "", "");
						index++;
						dg.Rows[index].Selected = true;
						string text = (pagCorrente.Pagina = Pagina.CriarLayer(pagCorrente.Pagina, pagCorrente.Unidade, pagCorrente.Alternativo));
						dg.Rows[index].Cells[0].Value = pagCorrente.Pagina;
						dg.Rows[index].Cells[3].Value = pagCorrente.Pagina;
						dg.Rows[index].Cells[4].Value = pagCorrente.PgDec;
						if (Operators.CompareString(text, "-1", TextCompare: true) != 0)
						{
							if (Operators.CompareString(text, "0", TextCompare: true) != 0)
							{
								Pagina.CarregaPaginas();
								Pagina.OrdenaMatrizPaginas();
								Pagina.criaCamposFormato("-1", text);
								Pagina.AtualizaContTotFl();
								Pagina.AtivaPagina(text);
								tbPagina.Text = text;
								pagCorrente.Titulo1 = pag.Titulo1;
								pagCorrente.Titulo2 = pag.Titulo2;
								pagCorrente.Titulo3 = pag.Titulo3;
								pagCorrente.Titulo4 = pag.Titulo4;
								Pagina.AtualizaTitulosDeUmaPagina(pagCorrente);
							}
							else
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 33]), MsgBoxStyle.Information, "Elétron");
							}
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 32]), MsgBoxStyle.Information, "Elétron");
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 31]), MsgBoxStyle.Information, "Elétron");
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 30]), MsgBoxStyle.Information, "Elétron");
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	private void Swkp1y1gUG1(object P_0, EventArgs P_1)
	{
		if (dg.ColumnCount != 0)
		{
			if (!MultiseleçãoToolStripMenuItem.Checked)
			{
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.MultiSelect = false;
				AtualizaDGpaginaAtiva();
			}
			else
			{
				dg.Columns[0].ReadOnly = true;
				dg.Columns[1].ReadOnly = true;
				dg.Columns[2].ReadOnly = true;
				dg.MultiSelect = true;
			}
		}
	}

	private void BVdp1gNNvUG(object P_0, EventArgs P_1)
	{
		MultiseleçãoToolStripMenuItem.Checked = !MultiseleçãoToolStripMenuItem.Checked;
	}

	private void uK5p1AIarkk(object P_0, EventArgs P_1)
	{
		try
		{
			AlternativoToolStripMenuItem.Checked = !AlternativoToolStripMenuItem.Checked;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4", writable: true);
			if (!AlternativoToolStripMenuItem.Checked)
			{
				UEipl0tKnkP = false;
				registryKey?.SetValue("Altern", "0");
			}
			else
			{
				UEipl0tKnkP = true;
				registryKey?.SetValue("Altern", "1");
			}
			registryKey.Close();
			Y9op1KgeRgW();
			VSWp1ebyWra();
			if (!AlternativoToolStripMenuItem.Checked)
			{
				EditarAlternativoToolStripMenuItem.Visible = false;
			}
			else
			{
				EditarAlternativoToolStripMenuItem.Visible = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void hgNp1ss9oWw(object P_0, EventArgs P_1)
	{
		try
		{
			TBNp1Uume8n();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void bt6p1Bww9xD(object P_0, EventArgs P_1)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		try
		{
			if (dg.SelectedRows.Count <= 0)
			{
				return;
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			PromptStringOptions val = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 15]), " ")));
			val.AllowSpaces = true;
			val.DefaultValue = dg.SelectedRows[0].Cells[1].Value.ToString();
			val.UseDefaultValue = true;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptResult val2 = editor.GetString(val);
			if ((int)val2.Status != 5100)
			{
				return;
			}
			string text = val2.StringResult.ToUpper().Trim();
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				XDataGeral.AlteraXDataUnidadeAlternativo(Conversions.ToString(selectedRow.Cells[0].Value), text, Conversions.ToString(selectedRow.Cells[2].Value));
				selectedRow.Cells[1].Value = text;
			}
			Pagina.CarregaPaginas();
			Pagina.OrdenaMatrizPaginas();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void T5Qp1VoBCME(object P_0, EventArgs P_1)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		try
		{
			if (dg.SelectedRows.Count <= 0)
			{
				return;
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			PromptStringOptions val = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 16]), " ")));
			val.AllowSpaces = true;
			val.DefaultValue = dg.SelectedRows[0].Cells[2].Value.ToString();
			val.UseDefaultValue = true;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptResult val2 = editor.GetString(val);
			if ((int)val2.Status != 5100)
			{
				return;
			}
			string text = val2.StringResult.ToUpper().Trim();
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				XDataGeral.AlteraXDataUnidadeAlternativo(Conversions.ToString(selectedRow.Cells[0].Value), Conversions.ToString(selectedRow.Cells[1].Value), text);
				selectedRow.Cells[2].Value = text;
			}
			Pagina.CarregaPaginas();
			Pagina.OrdenaMatrizPaginas();
			Pagina.AtualizaContTotFl();
			Application.UpdateScreen();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void z3Kp1uHJC5G(object P_0, EventArgs P_1)
	{
		new frmEditaTitulos();
	}

	private void Blcp1EA4dWJ(object P_0, EventArgs P_1)
	{
		new frmEditaRevisaoSimplificada();
	}

	private void fplp1ZiHjHx(object P_0, EventArgs P_1)
	{
		new frmEditaRevisaoCompleta();
	}

	private void DhWp1iIyTvQ(object P_0, EventArgs P_1)
	{
		cPup1SWxSYc();
	}

	private void cPup1SWxSYc()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Obj, but got Unknown
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			_ = Application.DocumentManager.MdiActiveDocument;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptKeywordOptions val = new PromptKeywordOptions("");
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 23]));
			((PromptOptions)val).Keywords.Add(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 19]));
			((PromptOptions)val).Keywords.Add(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 20]));
			val.AllowNone = false;
			val.AllowArbitraryInput = false;
			PromptResult keywords = editor.GetKeywords(val);
			if (!Operators.ConditionalCompareObjectEqual(keywords.StringResult, DeclaracoesGeral.mMensagem[1, 19], TextCompare: true) || dg.SelectedRows.Count <= 0)
			{
				return;
			}
			int num = JaTp14wdVuV();
			bool flag = MultiseleçãoToolStripMenuItem.Checked;
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				string text = Conversions.ToString(selectedRow.Cells[0].Value);
				try
				{
					if (!Pagina.checaCapa(text))
					{
						Pagina.ApagarElementosPagina(text);
						Pagina.RemoveLayer(text);
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 17]), MsgBoxStyle.Critical, "Elétron");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
					ProjectData.ClearProjectError();
				}
			}
			Pagina.CarregaPaginas();
			Pagina.OrdenaMatrizPaginas();
			Pagina.AtualizaContTotFl();
			clsConexao.sincronizaCircuitos();
			clsInterligacao.SincronizaCruzamentoInterlig();
			clsDePara.SincronizaDePara(bUpdateProp: false);
			clsDispositivoAuxiliares.ApagaContatosOrfaos();
			clsDispositivoAuxiliares.SincronizaContatos();
			clsPortas.SincronizaPortas();
			DeclaracoesGeral._uscPagina.CarregaPG();
			MultiseleçãoToolStripMenuItem.Checked = flag;
			dg.Rows[num].Selected = true;
			dg.FirstDisplayedScrollingRowIndex = num;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Interaction.MsgBox(ex4.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private int JaTp14wdVuV()
	{
		string value = Conversions.ToString(0);
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dg.Rows[i].Selected)
				{
					value = Conversions.ToString(i - 1);
					break;
				}
			}
			if (Conversions.ToDouble(value) < 0.0)
			{
				value = Conversions.ToString(0);
			}
			return Conversions.ToInteger(value);
		}
	}

	private void C8Op1CM1YgS(object P_0, EventArgs P_1)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Invalid comparison between Unknown and I4
		checked
		{
			try
			{
				object[,] array = new object[3, 1];
				object[,] array2 = new object[3, 1];
				string text = "";
				string p = "1000000";
				if (dg.Rows[0].Selected)
				{
					dg.Rows[0].Selected = false;
				}
				if (dg.SelectedRows.Count > 0)
				{
					foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
					{
						if (!item.Selected)
						{
							int num = Information.UBound(array, 2) + 1;
							array = (object[,])Utils.CopyArray(array, new object[3, num + 1]);
							array[0, num] = RuntimeHelpers.GetObjectValue(item.Cells[0].Value);
							array[1, num] = RuntimeHelpers.GetObjectValue(item.Cells[4].Value);
						}
						else
						{
							int num = Information.UBound(array2, 2) + 1;
							array2 = (object[,])Utils.CopyArray(array2, new object[3, num + 1]);
							array2[0, num] = RuntimeHelpers.GetObjectValue(item.Cells[0].Value);
							array2[1, num] = RuntimeHelpers.GetObjectValue(item.Cells[4].Value);
							array2[2, num] = "";
						}
					}
				}
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				while (true)
				{
					PromptStringOptions val = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 24]), " ")));
					val.AllowSpaces = false;
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					PromptResult val2 = editor.GetString(val);
					if (unchecked((int)val2.Status) != 5100)
					{
						break;
					}
					text = val2.StringResult.ToUpper();
					text = Pagina.montaNumeroPagina(text);
					if (!Pagina.checaCapa(text))
					{
						int num2 = Information.UBound(array2, 2);
						int num3 = 1;
						while (true)
						{
							if (num3 <= num2)
							{
								if (!Operators.ConditionalCompareObjectEqual(array2[0, num3], text, TextCompare: true))
								{
									num3++;
									continue;
								}
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 26]), MsgBoxStyle.Information);
								break;
							}
							int num4 = Information.UBound(array, 2);
							int num5 = 1;
							while (true)
							{
								if (num5 <= num4)
								{
									if (!Operators.ConditionalCompareObjectEqual(array[0, num5], text, TextCompare: true))
									{
										num5++;
										continue;
									}
									Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 25]), MsgBoxStyle.Information);
									break;
								}
								double num6 = Pagina.calculaPaginaDecimal(text);
								int num7 = Information.UBound(array, 2);
								for (int i = 1; i <= num7; i++)
								{
									if (Operators.ConditionalCompareObjectGreater(array[1, i], num6, TextCompare: true))
									{
										p = Conversions.ToString(array[0, i]);
										Conversions.ToDouble(array[1, i]);
										break;
									}
								}
								int num8 = Information.UBound(array2, 2);
								int num9 = Pagina.calculaEspacoNumerico(text, p);
								if (num9 >= num8)
								{
									object mPagSel = array2;
									Pagina.definePaginasNumericas(ref mPagSel, text);
									array2 = (object[,])mPagSel;
								}
								else
								{
									num9 = Pagina.calculaEspacoAlfaNumerico(text, p);
									if (num9 < num8)
									{
										Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 27]), MsgBoxStyle.Information);
										break;
									}
									object mPagSel = array2;
									Pagina.definePaginasAlfaNumericas(ref mPagSel, text);
									array2 = (object[,])mPagSel;
								}
								Pagina.renumerarPaginasLote(array2);
								Y9op1KgeRgW();
								VSWp1ebyWra();
								clsConexao.sincronizaCircuitos();
								clsInterligacao.SincronizaCruzamentoInterlig();
								clsDePara.SincronizaDePara(bUpdateProp: false);
								clsDispositivoAuxiliares.SincronizaContatos();
								clsPortas.SincronizaPortas();
								return;
							}
							break;
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 57]), MsgBoxStyle.Information);
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
		}
	}

	private void Es6p1Y15jTb(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				if (fKqplRiGop5)
				{
					return;
				}
				string left = FolhaToolStripMenuItem.Text;
				if (Operators.CompareString(left, "12", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "012", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "0012", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "00012", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "000012", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "0000012", TextCompare: true) == 0)
									{
										DeclaracoesGeral.Conf.LarguraFixaPaginas = 7;
									}
								}
								else
								{
									DeclaracoesGeral.Conf.LarguraFixaPaginas = 6;
								}
							}
							else
							{
								DeclaracoesGeral.Conf.LarguraFixaPaginas = 5;
							}
						}
						else
						{
							DeclaracoesGeral.Conf.LarguraFixaPaginas = 4;
						}
					}
					else
					{
						DeclaracoesGeral.Conf.LarguraFixaPaginas = 3;
					}
				}
				else
				{
					DeclaracoesGeral.Conf.LarguraFixaPaginas = 0;
				}
				XDataGeral.GravarXDataConfiguracao();
				object[,] array = new object[3, 1];
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					int num = Information.UBound(array, 2) + 1;
					array = (object[,])Utils.CopyArray(array, new object[3, num + 1]);
					array[0, num] = RuntimeHelpers.GetObjectValue(item.Cells[0].Value);
					array[1, num] = RuntimeHelpers.GetObjectValue(item.Cells[4].Value);
					array[2, num] = Pagina.montaNumeroPagina(Conversions.ToString(item.Cells[0].Value));
					item.Cells[0].Value = RuntimeHelpers.GetObjectValue(array[2, num]);
					item.Cells[3].Value = RuntimeHelpers.GetObjectValue(item.Cells[0].Value);
				}
				Pagina.renumerarPaginasLote(array);
				DeclaracoesGeral.ativo.Pagina = Pagina.LocalizaPaginaAtiva();
				cmStrip1.Hide();
				Application.UpdateScreen();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void ALbp1rlkV2U(object P_0, EventArgs P_1)
	{
		try
		{
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				string sPag = Conversions.ToString(selectedRow.Cells[0].Value);
				Pagina.InserirColuna(sPag, "ELET1_" + ToolStripMenuItem1.Text);
			}
			Application.UpdateScreen();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void yvkp19tK4tH(object P_0, EventArgs P_1)
	{
		try
		{
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				string sPag = Conversions.ToString(selectedRow.Cells[0].Value);
				Pagina.InserirColuna(sPag, "ELET2_" + ToolStripMenuItem2.Text);
			}
			Application.UpdateScreen();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void ldUp1zs1gc7(object P_0, EventArgs P_1)
	{
		try
		{
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				string sPag = Conversions.ToString(selectedRow.Cells[0].Value);
				Pagina.InserirColuna(sPag, "ELET3_" + ToolStripMenuItem3.Text);
			}
			Application.UpdateScreen();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void DTMplWw4hxb(object P_0, EventArgs P_1)
	{
		try
		{
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				string sPag = Conversions.ToString(selectedRow.Cells[0].Value);
				Pagina.InserirColuna(sPag, "ELET4_" + ToolStripMenuItem4.Text);
			}
			Application.UpdateScreen();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void oIPplp5NlDs(object P_0, EventArgs P_1)
	{
		try
		{
			foreach (DataGridViewRow selectedRow in dg.SelectedRows)
			{
				string sPag = Conversions.ToString(selectedRow.Cells[0].Value);
				Pagina.InserirColuna(sPag, "ELET5_" + ToolStripMenuItem5.Text);
			}
			Application.UpdateScreen();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void dSYplTtjY5W(object P_0, EventArgs P_1)
	{
		PmtplJFugFL();
	}

	private void PmtplJFugFL()
	{
		checked
		{
			if (dg.Columns.Count == 5)
			{
				float num = dg.Width - 20;
				if (!AlternativoToolStripMenuItem.Checked)
				{
					dg.Columns[0].Width = (int)Math.Round(num * 2f / 5f);
					dg.Columns[1].Width = (int)Math.Round(num * 3f / 5f);
					dg.Columns[2].Width = 0;
					dg.Columns[3].Width = 0;
					dg.Columns[4].Width = 0;
				}
				else
				{
					dg.Columns[0].Width = (int)Math.Round(num / 3f);
					dg.Columns[1].Width = (int)Math.Round(num / 3f);
					dg.Columns[2].Width = (int)Math.Round(num / 3f);
					dg.Columns[3].Width = 0;
					dg.Columns[4].Width = 0;
				}
				if ((Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "D", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "A", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "V", TextCompare: true) == 0))
				{
					dg.Columns[0].Width = (int)Math.Round(num * 2f / 5f);
					dg.Columns[1].Width = (int)Math.Round(num * 3f / 5f);
					dg.Columns[2].Width = 0;
					dg.Columns[3].Width = 0;
					dg.Columns[4].Width = 0;
				}
			}
		}
	}

	public void statusBanco(string valor)
	{
		if (!(Conversions.ToDouble(valor) > 0.0))
		{
			PictureBox2.Image = Resources.DB_DISCONNECTED;
		}
		else
		{
			PictureBox2.Image = Resources.DB_CONNECTED;
		}
		Application.DoEvents();
	}

	private void Jnvplhw32hA(object P_0, DataGridViewCellEventArgs P_1)
	{
	}
}
