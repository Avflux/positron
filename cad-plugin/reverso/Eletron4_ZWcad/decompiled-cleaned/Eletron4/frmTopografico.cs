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
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmTopografico : Form
{
	private IContainer I7Rpeu9UDkr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView luFpeEnjI1m;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView ygFpeZh2CQN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGDisp")]
	private DataGridView o47peiXibbV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbAlternativo")]
	private CheckBox knBpeSPLGT8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWG")]
	[CompilerGenerated]
	private DataGridView ATXpe47DhPo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox ogbpeC2vGZZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbReguas")]
	private RadioButton kJEpeYYI3JK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbDispositivos")]
	private RadioButton gTYperykSq0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btInserir")]
	private Button LIdpe97YIhh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbLayout")]
	private CheckBox rwApezwO6in;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip taGp2Wko237;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornes")]
	private DataGridView Klhp2pX7TJ9;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox oYVp2TeZIho;

	[AccessedThroughProperty("rb3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton otjp2Js2oii;

	[AccessedThroughProperty("rb2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton I7Lp2heGhZa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb1")]
	[CompilerGenerated]
	private RadioButton xwOp2o3DQsf;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("rb0")]
	private RadioButton yMOp2GOJ4Wx;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox agXp2HAH8c6;

	[AccessedThroughProperty("btAtualizar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button URdp2kJoNxw;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox kRZp2duhMAi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox xP5p2fkAcyr;

	[AccessedThroughProperty("PictureBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PictureBox vpvp2D1KyEY;

	[AccessedThroughProperty("GroupBox5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox BVNp2vPWHHd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbVertical")]
	private RadioButton byUp26aLilf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbhorizontal")]
	private RadioButton ta1p2tQhxW8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox HIKp2jxkPhh;

	[AccessedThroughProperty("rbEsquerda")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton fZDp2LC2mty;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox4")]
	private PictureBox qyTp2wIMkT2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox7")]
	private GroupBox Oekp2xwRG3u;

	[AccessedThroughProperty("btLigaCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button rqcp2bKoC0s;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btDesligaCabo")]
	[CompilerGenerated]
	private Button wjhp2MgdjpG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbSecao")]
	private ComboBox yTTp2OrjvGc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("rbDireita")]
	private RadioButton WkVp2ISFosK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	[CompilerGenerated]
	private Button Nb7p27eUQ2j;

	[CompilerGenerated]
	[AccessedThroughProperty("btReinserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button eZbp2qtPngM;

	[CompilerGenerated]
	[AccessedThroughProperty("tbBlocoTopografico")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox eGcp2aN4YcO;

	[CompilerGenerated]
	[AccessedThroughProperty("btSelecionaBlocoTopo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button uTVp280Pfiu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	private Button QjJp2NBOru7;

	[AccessedThroughProperty("rb4")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton AJvp2FshdCe;

	[CompilerGenerated]
	[AccessedThroughProperty("btSincLM")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button tCOp2QCYWj4;

	[AccessedThroughProperty("cbIgnorarExcedentes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox kk1p2PhLFk3;

	[AccessedThroughProperty("rb5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton om1p2c7MVl6;

	[AccessedThroughProperty("cbIgnorarFaltantes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox RIwp2KPrhQq;

	[AccessedThroughProperty("rb6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton K1op2e4kNG2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox3")]
	[CompilerGenerated]
	private PictureBox POOp22yohpP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDelimitadorTT")]
	private TextBox YB9p23AYrXj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSufixoCruzado")]
	private TextBox NpTp2n3RLIM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPrefixoCruzado")]
	private TextBox QhCp21r7Bk9;

	[AccessedThroughProperty("tbDelimitadorD")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox Cbrp2l9c8Lm;

	[AccessedThroughProperty("tbPrefixoPonto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox kPfp25RtwyG;

	[AccessedThroughProperty("tbSufixoPonto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox a19p20N3qx6;

	[AccessedThroughProperty("PictureBox5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private PictureBox Us8p2RMhVcX;

	[AccessedThroughProperty("tbDelimitadorTT2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox ojwp2mNGjmR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("rb7")]
	private RadioButton oM0p2XguTAY;

	[AccessedThroughProperty("GroupBox8")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox Ctcp2UcsJjk;

	[AccessedThroughProperty("rbTerminaisSeparados")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton gprp2yYjKdn;

	[AccessedThroughProperty("rbTerminaisJuntos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton TPYp2giE0Ou;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox6")]
	private PictureBox rNEp2A7giJX;

	private DeclaracoesFiacao.structurePnRev[] UNyp2sGn2ZH;

	private DeclaracoesFiacao.structureRevisoes[] fOGp2BxxmPx;

	private int sbbp2VLRHdS;

	private string e2Yp2uWib9t;

	private int otCp2ELmLKx;

	private string DHKp2ZAuW1y;

	private int LRgp2iXGy8m;

	private bool J1Mp2SXF0vt;

	private bool YBqp249doRB;

	private bool YN0p2CZ2tbU;

	private bool Idjp2YjKx9o;

	private DeclaracoesTopografico.structureConfigTopografico V2Hp2rKOwIX;

	private DataGridViewCellStyle YUDp29r8eIV;

	private DataGridViewCellStyle Yk1p2zO4TTY;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return luFpeEnjI1m;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cFDpePQrn6G;
			DataGridView dataGridView = luFpeEnjI1m;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			luFpeEnjI1m = value;
			dataGridView = luFpeEnjI1m;
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
			return ygFpeZh2CQN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VXipeKagury;
			DataGridView dataGridView = ygFpeZh2CQN;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			ygFpeZh2CQN = value;
			dataGridView = ygFpeZh2CQN;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView DGDisp
	{
		[CompilerGenerated]
		get
		{
			return o47peiXibbV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oK7peno34py;
			DataGridView dataGridView = o47peiXibbV;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			o47peiXibbV = value;
			dataGridView = o47peiXibbV;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual CheckBox cbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return knBpeSPLGT8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pWupeAxi70W;
			CheckBox checkBox = knBpeSPLGT8;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			knBpeSPLGT8 = value;
			checkBox = knBpeSPLGT8;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return ATXpe47DhPo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dBJpeF5sxms;
			DataGridView dataGridView = ATXpe47DhPo;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			ATXpe47DhPo = value;
			dataGridView = ATXpe47DhPo;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return ogbpeC2vGZZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ogbpeC2vGZZ = value;
		}
	}

	internal virtual RadioButton rbReguas
	{
		[CompilerGenerated]
		get
		{
			return kJEpeYYI3JK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kJEpeYYI3JK = value;
		}
	}

	internal virtual RadioButton rbDispositivos
	{
		[CompilerGenerated]
		get
		{
			return gTYperykSq0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Wt7peecoAJu;
			RadioButton radioButton = gTYperykSq0;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			gTYperykSq0 = value;
			radioButton = gTYperykSq0;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return LIdpe97YIhh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xf5pem5gCcG;
			Button button = LIdpe97YIhh;
			if (button != null)
			{
				button.Click -= value2;
			}
			LIdpe97YIhh = value;
			button = LIdpe97YIhh;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbLayout
	{
		[CompilerGenerated]
		get
		{
			return rwApezwO6in;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = i9xpesdwPdi;
			CheckBox checkBox = rwApezwO6in;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			rwApezwO6in = value;
			checkBox = rwApezwO6in;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgBornes
	{
		[CompilerGenerated]
		get
		{
			return Klhp2pX7TJ9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Klhp2pX7TJ9 = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return oYVp2TeZIho;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oYVp2TeZIho = value;
		}
	}

	internal virtual RadioButton rb3
	{
		[CompilerGenerated]
		get
		{
			return otjp2Js2oii;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			otjp2Js2oii = value;
		}
	}

	internal virtual RadioButton rb2
	{
		[CompilerGenerated]
		get
		{
			return I7Lp2heGhZa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			I7Lp2heGhZa = value;
		}
	}

	internal virtual RadioButton rb1
	{
		[CompilerGenerated]
		get
		{
			return xwOp2o3DQsf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xwOp2o3DQsf = value;
		}
	}

	internal virtual RadioButton rb0
	{
		[CompilerGenerated]
		get
		{
			return yMOp2GOJ4Wx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yMOp2GOJ4Wx = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return agXp2HAH8c6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			agXp2HAH8c6 = value;
		}
	}

	internal virtual Button btAtualizar
	{
		[CompilerGenerated]
		get
		{
			return URdp2kJoNxw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Cuspe1MFqLS;
			Button button = URdp2kJoNxw;
			if (button != null)
			{
				button.Click -= value2;
			}
			URdp2kJoNxw = value;
			button = URdp2kJoNxw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return kRZp2duhMAi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kRZp2duhMAi = value;
		}
	}

	internal virtual PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return xP5p2fkAcyr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xP5p2fkAcyr = value;
		}
	}

	internal virtual PictureBox PictureBox2
	{
		[CompilerGenerated]
		get
		{
			return vpvp2D1KyEY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vpvp2D1KyEY = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return BVNp2vPWHHd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BVNp2vPWHHd = value;
		}
	}

	internal virtual RadioButton rbVertical
	{
		[CompilerGenerated]
		get
		{
			return byUp26aLilf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			byUp26aLilf = value;
		}
	}

	internal virtual RadioButton rbhorizontal
	{
		[CompilerGenerated]
		get
		{
			return ta1p2tQhxW8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ta1p2tQhxW8 = value;
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return HIKp2jxkPhh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HIKp2jxkPhh = value;
		}
	}

	internal virtual RadioButton rbEsquerda
	{
		[CompilerGenerated]
		get
		{
			return fZDp2LC2mty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fZDp2LC2mty = value;
		}
	}

	internal virtual PictureBox PictureBox4
	{
		[CompilerGenerated]
		get
		{
			return qyTp2wIMkT2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qyTp2wIMkT2 = value;
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return Oekp2xwRG3u;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Oekp2xwRG3u = value;
		}
	}

	internal virtual Button btLigaCabo
	{
		[CompilerGenerated]
		get
		{
			return rqcp2bKoC0s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LLcpeliFk2v;
			Button button = rqcp2bKoC0s;
			if (button != null)
			{
				button.Click -= value2;
			}
			rqcp2bKoC0s = value;
			button = rqcp2bKoC0s;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btDesligaCabo
	{
		[CompilerGenerated]
		get
		{
			return wjhp2MgdjpG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Pprpe5872Vm;
			Button button = wjhp2MgdjpG;
			if (button != null)
			{
				button.Click -= value2;
			}
			wjhp2MgdjpG = value;
			button = wjhp2MgdjpG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox cbSecao
	{
		[CompilerGenerated]
		get
		{
			return yTTp2OrjvGc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yTTp2OrjvGc = value;
		}
	}

	internal virtual RadioButton rbDireita
	{
		[CompilerGenerated]
		get
		{
			return WkVp2ISFosK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WkVp2ISFosK = value;
		}
	}

	internal virtual Button btApagar
	{
		[CompilerGenerated]
		get
		{
			return Nb7p27eUQ2j;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RO5peXCOVEU;
			Button button = Nb7p27eUQ2j;
			if (button != null)
			{
				button.Click -= value2;
			}
			Nb7p27eUQ2j = value;
			button = Nb7p27eUQ2j;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btReinserir
	{
		[CompilerGenerated]
		get
		{
			return eZbp2qtPngM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ng3peUurKPN;
			Button button = eZbp2qtPngM;
			if (button != null)
			{
				button.Click -= value2;
			}
			eZbp2qtPngM = value;
			button = eZbp2qtPngM;
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
			return eGcp2aN4YcO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eGcp2aN4YcO = value;
		}
	}

	internal virtual Button btSelecionaBlocoTopo
	{
		[CompilerGenerated]
		get
		{
			return uTVp280Pfiu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = D1Ipe0MfrZ5;
			Button button = uTVp280Pfiu;
			if (button != null)
			{
				button.Click -= value2;
			}
			uTVp280Pfiu = value;
			button = uTVp280Pfiu;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return QjJp2NBOru7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = N9upeRc5iGB;
			Button button = QjJp2NBOru7;
			if (button != null)
			{
				button.Click -= value2;
			}
			QjJp2NBOru7 = value;
			button = QjJp2NBOru7;
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
			return AJvp2FshdCe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AJvp2FshdCe = value;
		}
	}

	internal virtual Button btSincLM
	{
		[CompilerGenerated]
		get
		{
			return tCOp2QCYWj4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hrMpeyABSeV;
			Button button = tCOp2QCYWj4;
			if (button != null)
			{
				button.Click -= value2;
			}
			tCOp2QCYWj4 = value;
			button = tCOp2QCYWj4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbIgnorarExcedentes
	{
		[CompilerGenerated]
		get
		{
			return kk1p2PhLFk3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kk1p2PhLFk3 = value;
		}
	}

	internal virtual RadioButton rb5
	{
		[CompilerGenerated]
		get
		{
			return om1p2c7MVl6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			om1p2c7MVl6 = value;
		}
	}

	internal virtual CheckBox cbIgnorarFaltantes
	{
		[CompilerGenerated]
		get
		{
			return RIwp2KPrhQq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RIwp2KPrhQq = value;
		}
	}

	internal virtual RadioButton rb6
	{
		[CompilerGenerated]
		get
		{
			return K1op2e4kNG2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			K1op2e4kNG2 = value;
		}
	}

	internal virtual PictureBox PictureBox3
	{
		[CompilerGenerated]
		get
		{
			return POOp22yohpP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			POOp22yohpP = value;
		}
	}

	internal virtual TextBox tbDelimitadorTT
	{
		[CompilerGenerated]
		get
		{
			return YB9p23AYrXj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rAKpegX6gFp;
			TextBox textBox = YB9p23AYrXj;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			YB9p23AYrXj = value;
			textBox = YB9p23AYrXj;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	internal virtual TextBox tbSufixoCruzado
	{
		[CompilerGenerated]
		get
		{
			return NpTp2n3RLIM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NpTp2n3RLIM = value;
		}
	}

	internal virtual TextBox tbPrefixoCruzado
	{
		[CompilerGenerated]
		get
		{
			return QhCp21r7Bk9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QhCp21r7Bk9 = value;
		}
	}

	internal virtual TextBox tbDelimitadorD
	{
		[CompilerGenerated]
		get
		{
			return Cbrp2l9c8Lm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Cbrp2l9c8Lm = value;
		}
	}

	internal virtual TextBox tbPrefixoPonto
	{
		[CompilerGenerated]
		get
		{
			return kPfp25RtwyG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kPfp25RtwyG = value;
		}
	}

	internal virtual TextBox tbSufixoPonto
	{
		[CompilerGenerated]
		get
		{
			return a19p20N3qx6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a19p20N3qx6 = value;
		}
	}

	internal virtual PictureBox PictureBox5
	{
		[CompilerGenerated]
		get
		{
			return Us8p2RMhVcX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Us8p2RMhVcX = value;
		}
	}

	internal virtual TextBox tbDelimitadorTT2
	{
		[CompilerGenerated]
		get
		{
			return ojwp2mNGjmR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ojwp2mNGjmR = value;
		}
	}

	internal virtual RadioButton rb7
	{
		[CompilerGenerated]
		get
		{
			return oM0p2XguTAY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oM0p2XguTAY = value;
		}
	}

	internal virtual GroupBox GroupBox8
	{
		[CompilerGenerated]
		get
		{
			return Ctcp2UcsJjk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ctcp2UcsJjk = value;
		}
	}

	internal virtual RadioButton rbTerminaisSeparados
	{
		[CompilerGenerated]
		get
		{
			return gprp2yYjKdn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gprp2yYjKdn = value;
		}
	}

	internal virtual RadioButton rbTerminaisJuntos
	{
		[CompilerGenerated]
		get
		{
			return TPYp2giE0Ou;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TPYp2giE0Ou = value;
		}
	}

	internal virtual PictureBox PictureBox6
	{
		[CompilerGenerated]
		get
		{
			return rNEp2A7giJX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rNEp2A7giJX = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && I7Rpeu9UDkr != null)
			{
				I7Rpeu9UDkr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void HappeNQjugp()
	{
		I7Rpeu9UDkr = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTopografico));
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		DGDisp = new DataGridView();
		cbAlternativo = new CheckBox();
		dgDWG = new DataGridView();
		GroupBox1 = new GroupBox();
		rbReguas = new RadioButton();
		rbDispositivos = new RadioButton();
		btInserir = new Button();
		cbLayout = new CheckBox();
		FDqpBiUmZij(new ToolTip(I7Rpeu9UDkr));
		dgBornes = new DataGridView();
		GroupBox2 = new GroupBox();
		rb7 = new RadioButton();
		rb6 = new RadioButton();
		rb1 = new RadioButton();
		rb3 = new RadioButton();
		rb0 = new RadioButton();
		rb5 = new RadioButton();
		rb4 = new RadioButton();
		rb2 = new RadioButton();
		PictureBox3 = new PictureBox();
		GroupBox3 = new GroupBox();
		tbDelimitadorTT2 = new TextBox();
		tbDelimitadorTT = new TextBox();
		tbSufixoCruzado = new TextBox();
		tbPrefixoCruzado = new TextBox();
		tbDelimitadorD = new TextBox();
		tbPrefixoPonto = new TextBox();
		tbSufixoPonto = new TextBox();
		PictureBox5 = new PictureBox();
		btAtualizar = new Button();
		GroupBox4 = new GroupBox();
		btSalvar = new Button();
		tbBlocoTopografico = new TextBox();
		btSelecionaBlocoTopo = new Button();
		PictureBox1 = new PictureBox();
		PictureBox2 = new PictureBox();
		GroupBox5 = new GroupBox();
		rbVertical = new RadioButton();
		rbhorizontal = new RadioButton();
		GroupBox6 = new GroupBox();
		rbDireita = new RadioButton();
		rbEsquerda = new RadioButton();
		PictureBox4 = new PictureBox();
		GroupBox7 = new GroupBox();
		btLigaCabo = new Button();
		btDesligaCabo = new Button();
		cbSecao = new ComboBox();
		btApagar = new Button();
		btReinserir = new Button();
		btSincLM = new Button();
		cbIgnorarExcedentes = new CheckBox();
		cbIgnorarFaltantes = new CheckBox();
		GroupBox8 = new GroupBox();
		rbTerminaisSeparados = new RadioButton();
		rbTerminaisJuntos = new RadioButton();
		PictureBox6 = new PictureBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)DGDisp).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)dgBornes).BeginInit();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)PictureBox3).BeginInit();
		GroupBox3.SuspendLayout();
		((ISupportInitialize)PictureBox5).BeginInit();
		GroupBox4.SuspendLayout();
		((ISupportInitialize)PictureBox1).BeginInit();
		((ISupportInitialize)PictureBox2).BeginInit();
		GroupBox5.SuspendLayout();
		GroupBox6.SuspendLayout();
		((ISupportInitialize)PictureBox4).BeginInit();
		GroupBox7.SuspendLayout();
		GroupBox8.SuspendLayout();
		((ISupportInitialize)PictureBox6).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
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
		dgRevisao.Location = new Point(241, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(97, 175);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
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
		dgEquip.Location = new Point(344, 12);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(180, 175);
		dgEquip.TabIndex = 8;
		DGDisp.AllowUserToAddRows = false;
		DGDisp.AllowUserToDeleteRows = false;
		DGDisp.AllowUserToOrderColumns = true;
		DGDisp.AllowUserToResizeRows = false;
		DGDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		DGDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		DGDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGDisp.Location = new Point(241, 193);
		DGDisp.MultiSelect = false;
		DGDisp.Name = "DGDisp";
		DGDisp.ReadOnly = true;
		DGDisp.RowHeadersVisible = false;
		DGDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGDisp.Size = new Size(189, 411);
		DGDisp.TabIndex = 9;
		cbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAlternativo.AutoSize = true;
		cbAlternativo.Location = new Point(143, 491);
		cbAlternativo.Name = "cbAlternativo";
		cbAlternativo.Size = new Size(76, 17);
		cbAlternativo.TabIndex = 18;
		cbAlternativo.Text = "Alternativo";
		cbAlternativo.UseVisualStyleBackColor = true;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDWG.Location = new Point(12, 12);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(223, 92);
		dgDWG.TabIndex = 17;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbReguas);
		GroupBox1.Controls.Add(rbDispositivos);
		GroupBox1.Location = new Point(11, 474);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(120, 63);
		GroupBox1.TabIndex = 18;
		GroupBox1.TabStop = false;
		rbReguas.AutoSize = true;
		rbReguas.Location = new Point(6, 35);
		rbReguas.Name = "rbReguas";
		rbReguas.Size = new Size(113, 17);
		rbReguas.TabIndex = 17;
		rbReguas.TabStop = true;
		rbReguas.Text = "Réguas de Bornes";
		rbReguas.UseVisualStyleBackColor = true;
		rbDispositivos.AutoSize = true;
		rbDispositivos.Location = new Point(6, 15);
		rbDispositivos.Name = "rbDispositivos";
		rbDispositivos.Size = new Size(81, 17);
		rbDispositivos.TabIndex = 16;
		rbDispositivos.TabStop = true;
		rbDispositivos.Text = "Dispositivos";
		rbDispositivos.UseVisualStyleBackColor = true;
		btInserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.OK_32;
		btInserir.Location = new Point(189, 556);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 42);
		btInserir.TabIndex = 23;
		btInserir.UseVisualStyleBackColor = true;
		cbLayout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbLayout.AutoSize = true;
		cbLayout.Location = new Point(143, 512);
		cbLayout.Name = "cbLayout";
		cbLayout.Size = new Size(92, 17);
		cbLayout.TabIndex = 19;
		cbLayout.Text = "Ordem Layout";
		cbLayout.UseVisualStyleBackColor = true;
		dgBornes.AllowUserToAddRows = false;
		dgBornes.AllowUserToDeleteRows = false;
		dgBornes.AllowUserToResizeRows = false;
		dgBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgBornes.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgBornes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgBornes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornes.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgBornes.Location = new Point(436, 473);
		dgBornes.Name = "dgBornes";
		dgBornes.ReadOnly = true;
		dgBornes.RowHeadersVisible = false;
		dgBornes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornes.Size = new Size(88, 131);
		dgBornes.TabIndex = 43;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rb7);
		GroupBox2.Controls.Add(rb6);
		GroupBox2.Controls.Add(rb1);
		GroupBox2.Controls.Add(rb3);
		GroupBox2.Controls.Add(rb0);
		GroupBox2.Controls.Add(rb5);
		GroupBox2.Controls.Add(rb4);
		GroupBox2.Controls.Add(rb2);
		GroupBox2.Controls.Add(PictureBox3);
		GroupBox2.Location = new Point(12, 111);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(223, 205);
		GroupBox2.TabIndex = 44;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Tipo de Cruzamento";
		rb7.AutoSize = true;
		rb7.Location = new Point(199, 39);
		rb7.Name = "rb7";
		rb7.Size = new Size(14, 13);
		rb7.TabIndex = 66;
		rb7.TabStop = true;
		rb7.UseVisualStyleBackColor = true;
		rb6.AutoSize = true;
		rb6.Location = new Point(199, 178);
		rb6.Name = "rb6";
		rb6.Size = new Size(14, 13);
		rb6.TabIndex = 7;
		rb6.TabStop = true;
		rb6.UseVisualStyleBackColor = true;
		rb1.AutoSize = true;
		rb1.Location = new Point(199, 58);
		rb1.Name = "rb1";
		rb1.Size = new Size(14, 13);
		rb1.TabIndex = 1;
		rb1.TabStop = true;
		rb1.UseVisualStyleBackColor = true;
		rb3.AutoSize = true;
		rb3.Location = new Point(199, 157);
		rb3.Name = "rb3";
		rb3.Size = new Size(14, 13);
		rb3.TabIndex = 6;
		rb3.TabStop = true;
		rb3.UseVisualStyleBackColor = true;
		rb0.AutoSize = true;
		rb0.Location = new Point(199, 77);
		rb0.Name = "rb0";
		rb0.Size = new Size(14, 13);
		rb0.TabIndex = 2;
		rb0.TabStop = true;
		rb0.UseVisualStyleBackColor = true;
		rb5.AutoSize = true;
		rb5.Location = new Point(199, 117);
		rb5.Name = "rb5";
		rb5.Size = new Size(14, 13);
		rb5.TabIndex = 4;
		rb5.TabStop = true;
		rb5.UseVisualStyleBackColor = true;
		rb4.AutoSize = true;
		rb4.Location = new Point(199, 97);
		rb4.Name = "rb4";
		rb4.Size = new Size(14, 13);
		rb4.TabIndex = 3;
		rb4.TabStop = true;
		rb4.UseVisualStyleBackColor = true;
		rb2.AutoSize = true;
		rb2.Location = new Point(199, 137);
		rb2.Name = "rb2";
		rb2.Size = new Size(14, 13);
		rb2.TabIndex = 5;
		rb2.TabStop = true;
		rb2.UseVisualStyleBackColor = true;
		PictureBox3.Image = Resources.PadraCruzTopografico;
		PictureBox3.Location = new Point(-1, 17);
		PictureBox3.Name = "PictureBox3";
		PictureBox3.Size = new Size(197, 180);
		PictureBox3.TabIndex = 65;
		PictureBox3.TabStop = false;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(tbDelimitadorTT2);
		GroupBox3.Controls.Add(tbDelimitadorTT);
		GroupBox3.Controls.Add(tbSufixoCruzado);
		GroupBox3.Controls.Add(tbPrefixoCruzado);
		GroupBox3.Controls.Add(tbDelimitadorD);
		GroupBox3.Controls.Add(tbPrefixoPonto);
		GroupBox3.Controls.Add(tbSufixoPonto);
		GroupBox3.Controls.Add(PictureBox5);
		GroupBox3.Location = new Point(11, 332);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(224, 57);
		GroupBox3.TabIndex = 45;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Delimitadores";
		tbDelimitadorTT2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbDelimitadorTT2.Location = new Point(160, 23);
		tbDelimitadorTT2.Name = "tbDelimitadorTT2";
		tbDelimitadorTT2.ReadOnly = true;
		tbDelimitadorTT2.Size = new Size(16, 22);
		tbDelimitadorTT2.TabIndex = 212;
		tbDelimitadorTT2.TextAlign = HorizontalAlignment.Center;
		tbDelimitadorTT.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbDelimitadorTT.Location = new Point(42, 23);
		tbDelimitadorTT.Name = "tbDelimitadorTT";
		tbDelimitadorTT.Size = new Size(16, 22);
		tbDelimitadorTT.TabIndex = 9;
		tbDelimitadorTT.TextAlign = HorizontalAlignment.Center;
		tbSufixoCruzado.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbSufixoCruzado.Location = new Point(193, 23);
		tbSufixoCruzado.Name = "tbSufixoCruzado";
		tbSufixoCruzado.Size = new Size(16, 22);
		tbSufixoCruzado.TabIndex = 13;
		tbSufixoCruzado.TextAlign = HorizontalAlignment.Center;
		tbPrefixoCruzado.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbPrefixoCruzado.Location = new Point(119, 23);
		tbPrefixoCruzado.Name = "tbPrefixoCruzado";
		tbPrefixoCruzado.Size = new Size(16, 22);
		tbPrefixoCruzado.TabIndex = 12;
		tbPrefixoCruzado.TextAlign = HorizontalAlignment.Center;
		tbDelimitadorD.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbDelimitadorD.Location = new Point(100, 23);
		tbDelimitadorD.Name = "tbDelimitadorD";
		tbDelimitadorD.Size = new Size(16, 22);
		tbDelimitadorD.TabIndex = 11;
		tbDelimitadorD.TextAlign = HorizontalAlignment.Center;
		tbPrefixoPonto.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbPrefixoPonto.Location = new Point(12, 23);
		tbPrefixoPonto.Name = "tbPrefixoPonto";
		tbPrefixoPonto.Size = new Size(16, 22);
		tbPrefixoPonto.TabIndex = 8;
		tbPrefixoPonto.TextAlign = HorizontalAlignment.Center;
		tbSufixoPonto.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbSufixoPonto.Location = new Point(82, 23);
		tbSufixoPonto.Name = "tbSufixoPonto";
		tbSufixoPonto.Size = new Size(16, 22);
		tbSufixoPonto.TabIndex = 10;
		tbSufixoPonto.TextAlign = HorizontalAlignment.Center;
		PictureBox5.Anchor = AnchorStyles.Left;
		PictureBox5.Image = Resources.FormatoAnilhas;
		PictureBox5.Location = new Point(28, 20);
		PictureBox5.Name = "PictureBox5";
		PictureBox5.Size = new Size(186, 30);
		PictureBox5.TabIndex = 211;
		PictureBox5.TabStop = false;
		btAtualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAtualizar.FlatStyle = FlatStyle.Flat;
		btAtualizar.ForeColor = SystemColors.Control;
		btAtualizar.Image = (Image)componentResourceManager.GetObject("btAtualizar.Image");
		btAtualizar.Location = new Point(93, 391);
		btAtualizar.Name = "btAtualizar";
		btAtualizar.Size = new Size(40, 42);
		btAtualizar.TabIndex = 46;
		btAtualizar.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(btSalvar);
		GroupBox4.Controls.Add(tbBlocoTopografico);
		GroupBox4.Controls.Add(btSelecionaBlocoTopo);
		GroupBox4.Location = new Point(241, 607);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(283, 49);
		GroupBox4.TabIndex = 47;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Bloco";
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_16;
		btSalvar.Location = new Point(248, 17);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(22, 22);
		btSalvar.TabIndex = 163;
		btSalvar.UseVisualStyleBackColor = true;
		tbBlocoTopografico.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbBlocoTopografico.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoTopografico.Location = new Point(10, 19);
		tbBlocoTopografico.Name = "tbBlocoTopografico";
		tbBlocoTopografico.Size = new Size(205, 20);
		tbBlocoTopografico.TabIndex = 161;
		btSelecionaBlocoTopo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSelecionaBlocoTopo.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoTopo.ForeColor = SystemColors.Control;
		btSelecionaBlocoTopo.Image = Resources.Pesquisar_16;
		btSelecionaBlocoTopo.Location = new Point(220, 17);
		btSelecionaBlocoTopo.Name = "btSelecionaBlocoTopo";
		btSelecionaBlocoTopo.Size = new Size(22, 22);
		btSelecionaBlocoTopo.TabIndex = 162;
		btSelecionaBlocoTopo.UseVisualStyleBackColor = true;
		PictureBox1.BackgroundImage = Resources.Direita1;
		PictureBox1.BackgroundImageLayout = ImageLayout.None;
		PictureBox1.Location = new Point(16, 16);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(24, 24);
		PictureBox1.TabIndex = 48;
		PictureBox1.TabStop = false;
		PictureBox2.BackgroundImage = Resources.Baixo1;
		PictureBox2.BackgroundImageLayout = ImageLayout.None;
		PictureBox2.Location = new Point(46, 16);
		PictureBox2.Name = "PictureBox2";
		PictureBox2.Size = new Size(24, 24);
		PictureBox2.TabIndex = 49;
		PictureBox2.TabStop = false;
		GroupBox5.Controls.Add(rbVertical);
		GroupBox5.Controls.Add(rbhorizontal);
		GroupBox5.Controls.Add(PictureBox1);
		GroupBox5.Controls.Add(PictureBox2);
		GroupBox5.Location = new Point(438, 193);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(86, 67);
		GroupBox5.TabIndex = 50;
		GroupBox5.TabStop = false;
		rbVertical.AutoSize = true;
		rbVertical.Location = new Point(51, 46);
		rbVertical.Name = "rbVertical";
		rbVertical.Size = new Size(14, 13);
		rbVertical.TabIndex = 28;
		rbVertical.TabStop = true;
		rbVertical.UseVisualStyleBackColor = true;
		rbhorizontal.AutoSize = true;
		rbhorizontal.Location = new Point(22, 46);
		rbhorizontal.Name = "rbhorizontal";
		rbhorizontal.Size = new Size(14, 13);
		rbhorizontal.TabIndex = 27;
		rbhorizontal.TabStop = true;
		rbhorizontal.UseVisualStyleBackColor = true;
		GroupBox6.Controls.Add(rbDireita);
		GroupBox6.Controls.Add(rbEsquerda);
		GroupBox6.Controls.Add(PictureBox4);
		GroupBox6.Location = new Point(436, 264);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(88, 74);
		GroupBox6.TabIndex = 53;
		GroupBox6.TabStop = false;
		rbDireita.AutoSize = true;
		rbDireita.Location = new Point(73, 46);
		rbDireita.Name = "rbDireita";
		rbDireita.Size = new Size(14, 13);
		rbDireita.TabIndex = 30;
		rbDireita.TabStop = true;
		rbDireita.UseVisualStyleBackColor = true;
		rbEsquerda.AutoSize = true;
		rbEsquerda.Location = new Point(6, 19);
		rbEsquerda.Name = "rbEsquerda";
		rbEsquerda.Size = new Size(14, 13);
		rbEsquerda.TabIndex = 29;
		rbEsquerda.TabStop = true;
		rbEsquerda.UseVisualStyleBackColor = true;
		PictureBox4.BackgroundImage = Resources.Borne_46;
		PictureBox4.BackgroundImageLayout = ImageLayout.None;
		PictureBox4.Location = new Point(22, 17);
		PictureBox4.Name = "PictureBox4";
		PictureBox4.Size = new Size(47, 48);
		PictureBox4.TabIndex = 49;
		PictureBox4.TabStop = false;
		GroupBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox7.Controls.Add(btLigaCabo);
		GroupBox7.Controls.Add(btDesligaCabo);
		GroupBox7.Controls.Add(cbSecao);
		GroupBox7.Location = new Point(12, 542);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(172, 62);
		GroupBox7.TabIndex = 54;
		GroupBox7.TabStop = false;
		GroupBox7.Text = "Seção + Cor";
		btLigaCabo.FlatStyle = FlatStyle.Flat;
		btLigaCabo.ForeColor = SystemColors.Control;
		btLigaCabo.Image = Resources.Liga_32;
		btLigaCabo.Location = new Point(94, 16);
		btLigaCabo.Name = "btLigaCabo";
		btLigaCabo.Size = new Size(40, 42);
		btLigaCabo.TabIndex = 21;
		btLigaCabo.UseVisualStyleBackColor = true;
		btDesligaCabo.FlatStyle = FlatStyle.Flat;
		btDesligaCabo.ForeColor = SystemColors.Control;
		btDesligaCabo.Image = Resources.Desliga_32;
		btDesligaCabo.Location = new Point(129, 16);
		btDesligaCabo.Name = "btDesligaCabo";
		btDesligaCabo.Size = new Size(40, 42);
		btDesligaCabo.TabIndex = 22;
		btDesligaCabo.UseVisualStyleBackColor = true;
		cbSecao.FormattingEnabled = true;
		cbSecao.Location = new Point(10, 28);
		cbSecao.Name = "cbSecao";
		cbSecao.Size = new Size(78, 21);
		cbSecao.TabIndex = 20;
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Apagador_32;
		btApagar.Location = new Point(12, 614);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 24;
		btApagar.UseVisualStyleBackColor = true;
		btReinserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btReinserir.FlatStyle = FlatStyle.Flat;
		btReinserir.ForeColor = SystemColors.Control;
		btReinserir.Image = Resources.OKmult_32;
		btReinserir.Location = new Point(58, 614);
		btReinserir.Name = "btReinserir";
		btReinserir.Size = new Size(40, 42);
		btReinserir.TabIndex = 25;
		btReinserir.UseVisualStyleBackColor = true;
		btSincLM.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSincLM.FlatStyle = FlatStyle.Flat;
		btSincLM.ForeColor = SystemColors.Control;
		btSincLM.Image = Resources.Restaura_32;
		btSincLM.Location = new Point(104, 614);
		btSincLM.Name = "btSincLM";
		btSincLM.Size = new Size(40, 42);
		btSincLM.TabIndex = 26;
		btSincLM.UseVisualStyleBackColor = true;
		cbIgnorarExcedentes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbIgnorarExcedentes.AutoSize = true;
		cbIgnorarExcedentes.Location = new Point(12, 436);
		cbIgnorarExcedentes.Name = "cbIgnorarExcedentes";
		cbIgnorarExcedentes.Size = new Size(211, 17);
		cbIgnorarExcedentes.TabIndex = 14;
		cbIgnorarExcedentes.Text = "Ignorar Terminais Excedentes do Bloco";
		cbIgnorarExcedentes.UseVisualStyleBackColor = true;
		cbIgnorarFaltantes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbIgnorarFaltantes.AutoSize = true;
		cbIgnorarFaltantes.Location = new Point(12, 459);
		cbIgnorarFaltantes.Name = "cbIgnorarFaltantes";
		cbIgnorarFaltantes.Size = new Size(198, 17);
		cbIgnorarFaltantes.TabIndex = 15;
		cbIgnorarFaltantes.Text = "Ignorar Terminais Faltantes do Bloco";
		cbIgnorarFaltantes.UseVisualStyleBackColor = true;
		GroupBox8.Controls.Add(rbTerminaisSeparados);
		GroupBox8.Controls.Add(rbTerminaisJuntos);
		GroupBox8.Controls.Add(PictureBox6);
		GroupBox8.Location = new Point(436, 344);
		GroupBox8.Name = "GroupBox8";
		GroupBox8.Size = new Size(88, 123);
		GroupBox8.TabIndex = 55;
		GroupBox8.TabStop = false;
		GroupBox8.Text = "_Borne Duplo";
		rbTerminaisSeparados.AutoSize = true;
		rbTerminaisSeparados.Location = new Point(6, 83);
		rbTerminaisSeparados.Name = "rbTerminaisSeparados";
		rbTerminaisSeparados.Size = new Size(14, 13);
		rbTerminaisSeparados.TabIndex = 30;
		rbTerminaisSeparados.UseVisualStyleBackColor = true;
		rbTerminaisJuntos.AutoSize = true;
		rbTerminaisJuntos.Checked = true;
		rbTerminaisJuntos.Location = new Point(6, 38);
		rbTerminaisJuntos.Name = "rbTerminaisJuntos";
		rbTerminaisJuntos.Size = new Size(14, 13);
		rbTerminaisJuntos.TabIndex = 29;
		rbTerminaisJuntos.TabStop = true;
		rbTerminaisJuntos.UseVisualStyleBackColor = true;
		PictureBox6.BackgroundImage = Resources.BorneDuplo;
		PictureBox6.BackgroundImageLayout = ImageLayout.None;
		PictureBox6.Location = new Point(26, 15);
		PictureBox6.Name = "PictureBox6";
		PictureBox6.Size = new Size(56, 103);
		PictureBox6.TabIndex = 50;
		PictureBox6.TabStop = false;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(534, 661);
		Controls.Add(GroupBox8);
		Controls.Add(cbIgnorarFaltantes);
		Controls.Add(cbIgnorarExcedentes);
		Controls.Add(btSincLM);
		Controls.Add(btReinserir);
		Controls.Add(btApagar);
		Controls.Add(GroupBox7);
		Controls.Add(GroupBox6);
		Controls.Add(GroupBox5);
		Controls.Add(btAtualizar);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(dgBornes);
		Controls.Add(cbLayout);
		Controls.Add(btInserir);
		Controls.Add(GroupBox1);
		Controls.Add(dgDWG);
		Controls.Add(cbAlternativo);
		Controls.Add(DGDisp);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximizeBox = false;
		MaximumSize = new Size(550, 1000);
		MinimizeBox = false;
		MinimumSize = new Size(550, 700);
		Name = "frmTopografico";
		ShowInTaskbar = false;
		Text = "Topográfico";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)DGDisp).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		((ISupportInitialize)dgBornes).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)PictureBox3).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		((ISupportInitialize)PictureBox5).EndInit();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)PictureBox2).EndInit();
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox5.PerformLayout();
		GroupBox6.ResumeLayout(performLayout: false);
		GroupBox6.PerformLayout();
		((ISupportInitialize)PictureBox4).EndInit();
		GroupBox7.ResumeLayout(performLayout: false);
		GroupBox8.ResumeLayout(performLayout: false);
		GroupBox8.PerformLayout();
		((ISupportInitialize)PictureBox6).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return taGp2Wko237;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		taGp2Wko237 = WithEventsValue;
	}

	public frmTopografico()
	{
		Resize += b9PpeBtluZP;
		UNyp2sGn2ZH = new DeclaracoesFiacao.structurePnRev[1];
		fOGp2BxxmPx = new DeclaracoesFiacao.structureRevisoes[1];
		sbbp2VLRHdS = 0;
		e2Yp2uWib9t = "";
		otCp2ELmLKx = 0;
		DHKp2ZAuW1y = "";
		LRgp2iXGy8m = 0;
		J1Mp2SXF0vt = false;
		YBqp249doRB = false;
		YN0p2CZ2tbU = false;
		Idjp2YjKx9o = false;
		V2Hp2rKOwIX = default;
		YUDp29r8eIV = new DataGridViewCellStyle();
		Yk1p2zO4TTY = new DataGridViewCellStyle();
		try
		{
			if (!Geral.ExisteForm("frmTopografico"))
			{
				HappeNQjugp();
				YUDp29r8eIV.BackColor = Color.LightGreen;
				Yk1p2zO4TTY.BackColor = Color.LightCoral;
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 552]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]);
				cbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 795]);
				cbIgnorarExcedentes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 859]);
				cbIgnorarFaltantes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1529]);
				rbDispositivos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]);
				rbReguas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 825]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 831]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 824]);
				GroupBox7.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 834]);
				GroupBox8.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1075]);
				w8dpBZ0kvSD().SetToolTip(btAtualizar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 835]));
				w8dpBZ0kvSD().SetToolTip(btLigaCabo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 836]));
				w8dpBZ0kvSD().SetToolTip(btDesligaCabo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 837]));
				w8dpBZ0kvSD().SetToolTip(btApagar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 838]));
				w8dpBZ0kvSD().SetToolTip(btReinserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 839]));
				w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 840]));
				w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoTopo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 841]));
				w8dpBZ0kvSD().SetToolTip(rbhorizontal, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 844]));
				w8dpBZ0kvSD().SetToolTip(rbVertical, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 845]));
				w8dpBZ0kvSD().SetToolTip(rbEsquerda, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 846]));
				w8dpBZ0kvSD().SetToolTip(rbDireita, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 847]));
				w8dpBZ0kvSD().SetToolTip(btSincLM, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 862]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao();
				formataDGEquip();
				formataDGDisp();
				formataDGBornes();
				CarregaDGDWG();
				rbDispositivos.Checked = true;
				cbAlternativo.Checked = false;
				cbLayout.Checked = false;
				cbIgnorarExcedentes.Checked = true;
				cbIgnorarFaltantes.Checked = false;
				rbEsquerda.Checked = true;
				rbVertical.Checked = true;
				XDataTopografico.LerXDataConfiguracao(ref V2Hp2rKOwIX);
				tbDelimitadorD.Text = V2Hp2rKOwIX.delimitadorD;
				tbDelimitadorTT.Text = V2Hp2rKOwIX.delimitadorTT;
				tbPrefixoCruzado.Text = V2Hp2rKOwIX.prefixoCruzado;
				tbSufixoCruzado.Text = V2Hp2rKOwIX.sufixoCruzado;
				tbPrefixoPonto.Text = V2Hp2rKOwIX.prefixoPonto;
				tbSufixoPonto.Text = V2Hp2rKOwIX.sufixoPonto;
				switch (V2Hp2rKOwIX.padrao)
				{
				case 5:
					rb5.Checked = true;
					break;
				case 0:
					rb0.Checked = true;
					break;
				case 1:
					rb1.Checked = true;
					break;
				case 2:
					rb2.Checked = true;
					break;
				case 3:
					rb3.Checked = true;
					break;
				case 4:
					rb4.Checked = true;
					break;
				}
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				DataGridView dg = dgDWG;
				AtualizaDGDWG(ref dg);
				dgDWG = dg;
				dg = dgRevisao;
				AtualizaDGRevisao(ref dg);
				dgRevisao = dg;
				dg = dgEquip;
				AtualizaDGEquip(ref dg);
				dgEquip = dg;
				dg = DGDisp;
				AtualizaDGDisp(ref dg);
				DGDisp = dg;
				dg = dgBornes;
				AtualizaDGBornes(ref dg);
				dgBornes = dg;
				if (!(File.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico + "AUXILIARES\\DUPLOD_R.DWG") & File.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico + "AUXILIARES\\DUPLOD_L.DWG")))
				{
					rbTerminaisJuntos.Checked = true;
					rbTerminaisJuntos.Enabled = false;
					rbTerminaisSeparados.Enabled = false;
					PictureBox6.Enabled = false;
				}
				else
				{
					rbTerminaisJuntos.Enabled = true;
					rbTerminaisSeparados.Enabled = true;
					rbTerminaisJuntos.Checked = true;
					PictureBox6.Enabled = true;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void dBJpeF5sxms(object P_0, EventArgs P_1)
	{
		J1Mp2SXF0vt = true;
		dgRevisao.Rows.Clear();
		J1Mp2SXF0vt = false;
		YBqp249doRB = true;
		dgEquip.Rows.Clear();
		YBqp249doRB = false;
		YN0p2CZ2tbU = true;
		DGDisp.Rows.Clear();
		YN0p2CZ2tbU = false;
		Idjp2YjKx9o = true;
		dgBornes.Rows.Clear();
		Idjp2YjKx9o = false;
		GqlpeQYOeKI();
	}

	private void GqlpeQYOeKI()
	{
		sbbp2VLRHdS = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		fOGp2BxxmPx = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(sbbp2VLRHdS, ref fOGp2BxxmPx);
			J1Mp2SXF0vt = true;
			dgRevisao.Rows.Clear();
			J1Mp2SXF0vt = false;
			int num = Information.UBound(fOGp2BxxmPx);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(fOGp2BxxmPx[i].revisao);
			}
			DataGridView dg = dgRevisao;
			AtualizaDGRevisao(ref dg);
			dgRevisao = dg;
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void cFDpePQrn6G(object P_0, EventArgs P_1)
	{
		YBqp249doRB = true;
		dgEquip.Rows.Clear();
		YBqp249doRB = false;
		YN0p2CZ2tbU = true;
		DGDisp.Rows.Clear();
		YN0p2CZ2tbU = false;
		if (!J1Mp2SXF0vt)
		{
			SmApecvO89Z();
		}
	}

	private void SmApecvO89Z()
	{
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgRevisao.SelectedRows.Count == 1)
			{
				e2Yp2uWib9t = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
				YBqp249doRB = true;
				dgEquip.Rows.Clear();
				YBqp249doRB = false;
				int num = Information.UBound(UNyp2sGn2ZH);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					if (Operators.CompareString(UNyp2sGn2ZH[i].revisao, e2Yp2uWib9t, TextCompare: true) == 0)
					{
						dgEquip.Rows.Add(UNyp2sGn2ZH[i].painel, Dicionario.BuscaNomeDoPainel(UNyp2sGn2ZH[i].painel));
					}
				}
			}
			DataGridView dg = dgEquip;
			AtualizaDGEquip(ref dg);
			dgEquip = dg;
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	public void CarregaPnRev()
	{
		UNyp2sGn2ZH = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(fOGp2BxxmPx) > 0)
			{
				int num = Information.UBound(fOGp2BxxmPx);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(sbbp2VLRHdS, fOGp2BxxmPx[i].revisao, ref UNyp2sGn2ZH);
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void VXipeKagury(object P_0, EventArgs P_1)
	{
		YN0p2CZ2tbU = true;
		DGDisp.Rows.Clear();
		YN0p2CZ2tbU = false;
		Idjp2YjKx9o = true;
		dgBornes.Rows.Clear();
		Idjp2YjKx9o = false;
		if (!YBqp249doRB)
		{
			Nnppe23P62l();
			Amnpe3HE2Up();
		}
	}

	private void Wt7peecoAJu(object P_0, EventArgs P_1)
	{
		YN0p2CZ2tbU = true;
		formataDGDisp();
		YN0p2CZ2tbU = false;
		if (!YBqp249doRB)
		{
			Nnppe23P62l();
		}
		if (!rbDispositivos.Checked)
		{
			if (rbReguas.Checked)
			{
				cbLayout.Checked = false;
				cbLayout.Enabled = false;
				dgBornes.Enabled = true;
				btSelecionaBlocoTopo.Enabled = false;
				btSalvar.Enabled = false;
				tbBlocoTopografico.Text = "";
			}
		}
		else
		{
			cbAlternativo.Enabled = true;
			cbLayout.Enabled = true;
			Idjp2YjKx9o = true;
			dgBornes.Rows.Clear();
			Idjp2YjKx9o = false;
			dgBornes.Enabled = false;
			btSelecionaBlocoTopo.Enabled = true;
			btSalvar.Enabled = true;
		}
	}

	private void Nnppe23P62l()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		checked
		{
			try
			{
				DataGridView dg;
				if (dgEquip.SelectedRows.Count == 1)
				{
					otCp2ELmLKx = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
					DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
					cDadosAccessFiacao2.CarregaDispTipoIndexModelo(sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, ref mDisp);
					List<string> list = new List<string>();
					clsTopografico.carregaDispositivosInseridos(otCp2ELmLKx, list);
					YN0p2CZ2tbU = true;
					DGDisp.Rows.Clear();
					YN0p2CZ2tbU = false;
					int num = Information.UBound(mDisp);
					for (int i = 1; i <= num; i++)
					{
						if (!((Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) != 0) & rbDispositivos.Checked))
						{
							if ((Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) == 0) & rbReguas.Checked)
							{
								DGDisp.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem.ToString(), "", 0);
							}
						}
						else
						{
							DGDisp.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem.ToString(), mDisp[i].BlocoTopográfico, mDisp[i].Indice);
						}
					}
					if (cbLayout.Checked)
					{
						DataGridViewColumn dataGridViewColumn = DGDisp.Columns[4];
						DGDisp.Sort(dataGridViewColumn, ListSortDirection.Ascending);
					}
					int num2 = DGDisp.RowCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (list.Contains(Conversions.ToString(DGDisp.Rows[j].Cells[0].Value)))
						{
							DGDisp.Rows[j].Cells[0].Style = Yk1p2zO4TTY;
						}
						else
						{
							DGDisp.Rows[j].Cells[0].Style = YUDp29r8eIV;
						}
					}
					dg = DGDisp;
					AtualizaDGDisp(ref dg);
					DGDisp = dg;
				}
				if (!rbReguas.Checked)
				{
					return;
				}
				DeclaracoesGeral._uscPagina.Quantidade = DGDisp.RowCount - 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num3 = DGDisp.RowCount - 1;
				for (int k = 0; k <= num3; k++)
				{
					int indexModelo = Conversions.ToInteger(DGDisp.Rows[k].Cells[3].Value);
					string reguaSel = Conversions.ToString(DGDisp.Rows[k].Cells[0].Value);
					if (!verificaTodosBornesInseridos(indexModelo, sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, reguaSel))
					{
						DGDisp.Rows[k].Cells[0].Style = YUDp29r8eIV;
					}
					else
					{
						DGDisp.Rows[k].Cells[0].Style = Yk1p2zO4TTY;
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DeclaracoesGeral._uscPagina.pbFim();
				dg = DGDisp;
				AtualizaDGDisp(ref dg);
				DGDisp = dg;
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
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	public static bool verificaTodosBornesInseridos(int indexModelo, int indiceSel, string revisaoSel, int painelSel, string reguaSel)
	{
		bool result = true;
		DeclaracoesFiacao.structureFiacao[] mfiacao = new DeclaracoesFiacao.structureFiacao[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		cDadosAccessFiacao2.CarregaTerminaisRegua(indiceSel, revisaoSel, painelSel, indexModelo, ref mfiacao);
		cDadosAccessFiacao2.fechaConexao();
		List<string> list = new List<string>();
		clsTopografico.carregaBornesInseridos(painelSel, reguaSel, list);
		int num = Information.UBound(mfiacao);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!list.Contains(mfiacao[i].Terminal))
			{
				result = false;
				break;
			}
		}
		return result;
	}

	private void Amnpe3HE2Up()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			List<string> lSecao = new List<string>();
			cDadosAccessFiacao2.CarregaSecaoCabos(sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, ref lSecao);
			cbSecao.Items.Clear();
			foreach (string item in lSecao)
			{
				cbSecao.Items.Add(item);
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void oK7peno34py(object P_0, EventArgs P_1)
	{
		if (Idjp2YjKx9o || DGDisp.SelectedRows.Count == 0)
		{
			return;
		}
		checked
		{
			if (!rbDispositivos.Checked)
			{
				if (!rbReguas.Checked)
				{
					return;
				}
				Idjp2YjKx9o = true;
				dgBornes.Rows.Clear();
				Idjp2YjKx9o = false;
				DeclaracoesFiacao.structureFiacao[] mfiacao = new DeclaracoesFiacao.structureFiacao[1];
				cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
				int indexRegua = Conversions.ToInteger(DGDisp.SelectedRows[0].Cells[3].Value);
				cDadosAccessFiacao2.CarregaTerminaisRegua(sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, indexRegua, ref mfiacao);
				cDadosAccessFiacao2.fechaConexao();
				List<string> list = new List<string>();
				string regua = Conversions.ToString(DGDisp.SelectedRows[0].Cells[0].Value);
				clsTopografico.carregaBornesInseridos(otCp2ELmLKx, regua, list);
				if (Information.UBound(mfiacao) > 0)
				{
					int num = Information.UBound(mfiacao);
					for (int i = 1; i <= num; i++)
					{
						dgBornes.Rows.Add(mfiacao[i].Terminal, mfiacao[i].TipoBorne);
					}
					int num2 = dgBornes.RowCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (list.Contains(Conversions.ToString(dgBornes.Rows[j].Cells[0].Value)))
						{
							dgBornes.Rows[j].Cells[0].Style = Yk1p2zO4TTY;
							dgBornes.Rows[j].Selected = false;
						}
						else
						{
							dgBornes.Rows[j].Cells[0].Style = YUDp29r8eIV;
							dgBornes.Rows[j].Selected = true;
						}
					}
				}
				DataGridView dg = dgBornes;
				AtualizaDGBornes(ref dg);
				dgBornes = dg;
			}
			else
			{
				tbBlocoTopografico.Text = Conversions.ToString(DGDisp.SelectedRows[0].Cells[5].Value);
			}
		}
	}

	private void Cuspe1MFqLS(object P_0, EventArgs P_1)
	{
		V2Hp2rKOwIX.delimitadorD = tbDelimitadorD.Text;
		V2Hp2rKOwIX.delimitadorTT = tbDelimitadorTT.Text;
		V2Hp2rKOwIX.prefixoCruzado = tbPrefixoCruzado.Text;
		V2Hp2rKOwIX.sufixoCruzado = tbSufixoCruzado.Text;
		V2Hp2rKOwIX.prefixoPonto = tbPrefixoPonto.Text;
		V2Hp2rKOwIX.sufixoPonto = tbSufixoPonto.Text;
		if (!rb0.Checked)
		{
			if (!rb1.Checked)
			{
				if (!rb2.Checked)
				{
					if (!rb3.Checked)
					{
						if (!rb4.Checked)
						{
							if (!rb5.Checked)
							{
								if (!rb6.Checked)
								{
									if (rb7.Checked)
									{
										V2Hp2rKOwIX.padrao = 7;
									}
								}
								else
								{
									V2Hp2rKOwIX.padrao = 6;
								}
							}
							else
							{
								V2Hp2rKOwIX.padrao = 5;
							}
						}
						else
						{
							V2Hp2rKOwIX.padrao = 4;
						}
					}
					else
					{
						V2Hp2rKOwIX.padrao = 3;
					}
				}
				else
				{
					V2Hp2rKOwIX.padrao = 2;
				}
			}
			else
			{
				V2Hp2rKOwIX.padrao = 1;
			}
		}
		else
		{
			V2Hp2rKOwIX.padrao = 0;
		}
		XDataTopografico.GravarXDataConfiguracao(V2Hp2rKOwIX);
		clsTopografico.AtualizarTerminais(ref V2Hp2rKOwIX, cbAlternativo.Checked);
	}

	private void LLcpeliFk2v(object P_0, EventArgs P_1)
	{
		string text = cbSecao.Text;
		if (Operators.CompareString(text.Trim(), "", TextCompare: true) != 0)
		{
			clsTopografico.mostraSecao(text);
		}
	}

	private void Pprpe5872Vm(object P_0, EventArgs P_1)
	{
		clsTopografico.ocultaSecao();
	}

	private void D1Ipe0MfrZ5(object P_0, EventArgs P_1)
	{
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico)))
		{
			tbBlocoTopografico.Text = "";
			return;
		}
		tbBlocoTopografico.BackColor = Color.White;
		DeclaracoesGeral.gsCaminhoBloco = DeclaracoesGeral.Conf.dirSimbologiaTopografico;
		frmVisualizarBloco frmVisualizarBloco2 = new frmVisualizarBloco();
		Application.ShowModalDialog((Form)frmVisualizarBloco2);
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoTopografico.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	private void N9upeRc5iGB(object P_0, EventArgs P_1)
	{
		DGDisp.SelectedRows[0].Cells[5].Value = tbBlocoTopografico.Text;
		int indice = Conversions.ToInteger(DGDisp.SelectedRows[0].Cells[6].Value);
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		cDadosAccessFiacao2.AtualizaBlocoTopografico(indice, tbBlocoTopografico.Text);
	}

	private void xf5pem5gCcG(object P_0, EventArgs P_1)
	{
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Expected Obj, but got Unknown
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b2: Expected Obj, but got Unknown
		//IL_08b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		checked
		{
			if (!(rbDispositivos.Checked & (DGDisp.SelectedRows.Count == 1)))
			{
				if (rbReguas.Checked)
				{
					bool flag = false;
					int num = DGDisp.RowCount - 1;
					for (int i = 0; i <= num; i++)
					{
						if (DGDisp.Rows[i].Selected)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						int num2 = 100000;
						int num3 = 100000;
						int num4 = 5;
						int num5 = 10;
						List<int> list = new List<int>();
						DeclaracoesGeral.Reguas RH = default;
						XDataGeral.LeXDataReguaH(ref RH);
						double num6 = RH.LarguraBase - 20.0;
						DeclaracoesTopografico.structureBorneTopografico bTpg = new DeclaracoesTopografico.structureBorneTopografico
						{
							painel = otCp2ELmLKx,
							regua = Conversions.ToString(DGDisp.SelectedRows[0].Cells[0].Value)
						};
						if (!rbEsquerda.Checked)
						{
							bTpg.posEntrada = "R";
						}
						else
						{
							bTpg.posEntrada = "L";
						}
						string tipo = Conversions.ToString(DGDisp.SelectedRows[0].Cells[2].Value);
						int indexModelo = Conversions.ToInteger(DGDisp.SelectedRows[0].Cells[3].Value);
						DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes = new DeclaracoesTopografico.structureLigTermTopografico[1];
						mLigacoes[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
						DeclaracoesFiacao.structureLink[] mLink = new DeclaracoesFiacao.structureLink[1];
						clsTopografico.carregarLigacoes(bTpg.regua, ref mLigacoes, sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, tipo, indexModelo, ref mLink);
						int num7 = 0;
						BlockReference val = null;
						Point3d val2 = default;
						Extents3d val3 = default;
						ObjectId val4 = ObjectId.Null;
						string sblockRef = "";
						int num8 = dgBornes.RowCount - 1;
						for (int j = 0; j <= num8; j++)
						{
							if (!dgBornes.Rows[j].Selected)
							{
								continue;
							}
							num7++;
							bTpg.borne = Conversions.ToString(dgBornes.Rows[j].Cells[0].Value);
							bTpg.tipoBorne = Conversions.ToInteger(dgBornes.Rows[j].Cells[1].Value);
							DeclaracoesTopografico.structureLigTermTopografico mLigacao = default;
							int num9 = Information.UBound(mLigacoes);
							for (int k = 0; k <= num9; k++)
							{
								if (Operators.CompareString(mLigacoes[k].Terminal, bTpg.borne, TextCompare: true) == 0)
								{
									mLigacao = mLigacoes[k];
									break;
								}
							}
							DeclaracoesFiacao.structureLink structureLink = default;
							int num10 = Information.UBound(mLink);
							for (int l = 0; l <= num10; l++)
							{
								if (Operators.CompareString(mLink[l].borne, bTpg.borne, TextCompare: true) == 0)
								{
									structureLink = mLink[l];
									break;
								}
							}
							string text = "BORNE";
							text = ((bTpg.tipoBorne == 0) ? (text + "S") : (text + "D"));
							text = (rbVertical.Checked ? (text + "0") : (text + "90"));
							text += ".dwg";
							if (File.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico + "Auxiliares\\" + text))
							{
								Database database = Application.DocumentManager.MdiActiveDocument.Database;
								_ = Application.DocumentManager.MdiActiveDocument.Editor;
								Transaction val5 = database.TransactionManager.StartTransaction();
								try
								{
									Point3d val7;
									double num11;
									double num12;
									if (num7 != 1)
									{
										num11 = 0.0;
										num12 = 0.0;
										if (num2 >= 100000)
										{
											goto IL_05ee;
										}
										if (bTpg.tipoBorne != 0)
										{
											num2 -= num5;
											if (!((double)num2 < RH.AltBase + (double)num5))
											{
												goto IL_05ee;
											}
											val4 = ObjectId.Null;
										}
										else
										{
											num2 -= num4;
											if (!((double)num2 < RH.AltBase + (double)num4))
											{
												goto IL_05ee;
											}
											val4 = ObjectId.Null;
										}
									}
									else
									{
										ObjectId val6 = Geral.HandleToID(clsTopografico.InserirPrimeiroBorneTopografico(bTpg, text));
										list.Add(j);
										if (!val6.IsValid)
										{
											val4 = ObjectId.Null;
										}
										else
										{
											val = (BlockReference)val5.GetObject(val6, (OpenMode)0);
											val4 = val6;
											sblockRef = ((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString();
											val2 = val.Position;
											val3 = ((Drawable)val).Bounds.Value;
											double num13 = val2.Y;
											val7 = val3.MaxPoint;
											double num14 = val7.Y;
											val7 = val3.MinPoint;
											num2 = (int)Math.Round(num13 - (num14 - val7.Y));
											double num15 = val2.X;
											val7 = val3.MaxPoint;
											double num16 = val7.X;
											val7 = val3.MinPoint;
											num3 = (int)Math.Round(num15 - (num16 - val7.X));
										}
									}
									goto IL_08e9;
									IL_05ee:
									if (num3 >= 100000)
									{
										goto IL_05fc;
									}
									if (bTpg.tipoBorne != 0)
									{
										num3 -= num5;
										if (!(num6 < (double)num3))
										{
											goto IL_05fc;
										}
										val4 = ObjectId.Null;
									}
									else
									{
										num3 -= num4;
										if (!(num6 < (double)num3))
										{
											goto IL_05fc;
										}
										val4 = ObjectId.Null;
									}
									goto IL_08e9;
									IL_08e9:
									DeclaracoesGeral.bAnularEventos = true;
									val5.Commit();
									DeclaracoesGeral.bAnularEventos = false;
									goto end_IL_05c0;
									IL_05fc:
									if (!rbVertical.Checked)
									{
										val7 = val3.MaxPoint;
										double num17 = val7.X;
										val7 = val3.MinPoint;
										num11 = num17 - val7.X;
										num12 = 0.0;
									}
									else
									{
										num11 = 0.0;
										val7 = val3.MaxPoint;
										double num18 = val7.Y;
										val7 = val3.MinPoint;
										num12 = num18 - val7.Y;
									}
									Point3d ptIns = new Point3d(val2.X + num11, val2.Y - num12, 0.0);
									num2 = (int)Math.Round(ptIns.Y);
									num3 = (int)Math.Round(ptIns.X);
									if (bTpg.tipoBorne == 0)
									{
										num4 = (int)Math.Round(num12);
									}
									if (bTpg.tipoBorne == 1)
									{
										num5 = (int)Math.Round(num12);
									}
									ObjectId val8 = Geral.HandleToID(clsTopografico.InserirOutroBorneTopografico(bTpg, text, ptIns));
									list.Add(j);
									if (!val8.IsValid)
									{
										val4 = ObjectId.Null;
									}
									else
									{
										val = (BlockReference)val5.GetObject(val8, (OpenMode)0);
										val4 = val8;
										sblockRef = ((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString();
										val2 = val.Position;
										val3 = ((Drawable)val).Bounds.Value;
									}
									goto IL_08e9;
									end_IL_05c0:;
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									val5.Abort();
									ProjectData.ClearProjectError();
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
								}
								if (!val4.IsValid)
								{
									continue;
								}
								if (!Information.IsNothing(structureLink) & (structureLink.bUp | structureLink.bDown))
								{
									text = "BORNE";
									text = ((bTpg.tipoBorne == 0) ? (text + "S") : (text + "D"));
									text = (rbVertical.Checked ? (text + "0") : (text + "90"));
									if (structureLink.bUp)
									{
										text += "U";
									}
									if (structureLink.bDown)
									{
										text += "D";
									}
									text += bTpg.posEntrada;
									text += ".dwg";
									clsTopografico.InserirLinkTopografico(bTpg, text, sblockRef);
								}
								if (list.Contains(j))
								{
									clsTopografico.InserirTerminaisBorne(bTpg, ref V2Hp2rKOwIX, ref sblockRef, ref mLigacao, cbAlternativo.Checked, rbTerminaisSeparados.Checked);
								}
								continue;
							}
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
							return;
						}
						bool flag2 = false;
						int num19 = dgBornes.RowCount - 1;
						for (int m = num19; m >= 0; m += -1)
						{
							if (dgBornes.Rows[m].Selected)
							{
								if (!list.Contains(m))
								{
									flag2 = true;
									continue;
								}
								dgBornes.Rows[m].Cells[0].Style = Yk1p2zO4TTY;
								dgBornes.Rows[m].Selected = false;
							}
						}
						if (!flag2)
						{
							bool flag3 = true;
							int num20 = dgBornes.RowCount - 1;
							for (int n = num20; n >= 0; n += -1)
							{
								if (dgBornes.Rows[n].Cells[0].Style.BackColor != Color.LightCoral)
								{
									flag3 = false;
								}
							}
							if (flag3)
							{
								DGDisp.SelectedRows[0].Cells[0].Style = Yk1p2zO4TTY;
								DGDisp.SelectedRows[0].Selected = false;
							}
						}
					}
				}
			}
			else
			{
				DeclaracoesTopografico.structureDispTopografico dTpg = new DeclaracoesTopografico.structureDispTopografico
				{
					tag = Conversions.ToString(DGDisp.SelectedRows[0].Cells[0].Value),
					alternativo = Conversions.ToString(DGDisp.SelectedRows[0].Cells[1].Value),
					painel = otCp2ELmLKx
				};
				string tipo2 = Conversions.ToString(DGDisp.SelectedRows[0].Cells[2].Value);
				int indexModelo2 = Conversions.ToInteger(DGDisp.SelectedRows[0].Cells[3].Value);
				string text2 = tbBlocoTopografico.Text;
				if (!File.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico + text2))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
					return;
				}
				string sblockRef2 = clsTopografico.InserirBlocoDispTopografico(dTpg, text2);
				if (Operators.CompareString(sblockRef2, "", TextCompare: true) != 0)
				{
					DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes2 = new DeclaracoesTopografico.structureLigTermTopografico[1];
					mLigacoes2[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
					DeclaracoesFiacao.structureLink[] mLink2 = new DeclaracoesFiacao.structureLink[1];
					clsTopografico.carregarLigacoes(dTpg.tag, ref mLigacoes2, sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, tipo2, indexModelo2, ref mLink2);
					clsTopografico.InserirTerminaisDispositivo(dTpg, ref V2Hp2rKOwIX, ref sblockRef2, ref mLigacoes2, cbIgnorarExcedentes.Checked, cbAlternativo.Checked, cbIgnorarFaltantes.Checked);
					DGDisp.SelectedRows[0].Cells[0].Style = Yk1p2zO4TTY;
				}
			}
			if (!rbDispositivos.Checked)
			{
				if (rbReguas.Checked)
				{
					bool flag4 = false;
					int num21 = dgBornes.RowCount - 1;
					for (int num22 = 0; num22 <= num21; num22++)
					{
						if (dgBornes.Rows[num22].Cells[0].Style.BackColor == Color.LightGreen)
						{
							dgBornes.Rows[num22].Selected = true;
							if (!flag4)
							{
								dgBornes.FirstDisplayedScrollingRowIndex = num22;
								flag4 = true;
							}
						}
					}
				}
			}
			else
			{
				int num23 = DGDisp.RowCount - 1;
				for (int num24 = 0; num24 <= num23; num24++)
				{
					if (DGDisp.Rows[num24].Cells[0].Style.BackColor == Color.LightGreen)
					{
						DGDisp.Rows[num24].Selected = true;
						DGDisp.FirstDisplayedScrollingRowIndex = num24;
						break;
					}
				}
			}
			PointMonitorToolTips.StartMonitor();
		}
	}

	private void RO5peXCOVEU(object P_0, EventArgs P_1)
	{
		string tipo = "";
		MsgBoxResult msgBoxResult = default;
		if (!rbDispositivos.Checked)
		{
			if (rbReguas.Checked)
			{
				msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 864]), MsgBoxStyle.YesNo);
				tipo = "B";
			}
		}
		else
		{
			msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 860]), MsgBoxStyle.YesNo);
			tipo = "D";
		}
		if (msgBoxResult != MsgBoxResult.No)
		{
			clsTopografico.ApagarTodasLigacoes(otCp2ELmLKx, tipo);
		}
	}

	private void ng3peUurKPN(object P_0, EventArgs P_1)
	{
		checked
		{
			MsgBoxResult msgBoxResult;
			if (!rbDispositivos.Checked)
			{
				if (!rbReguas.Checked)
				{
					return;
				}
				msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 865]), MsgBoxStyle.YesNo);
				if (msgBoxResult != MsgBoxResult.No)
				{
					clsTopografico.ApagarTodasLigacoes(otCp2ELmLKx, "B");
					int num = DGDisp.RowCount - 1;
					for (int i = 0; i <= num; i++)
					{
						string regua = Conversions.ToString(DGDisp.Rows[i].Cells[0].Value);
						int indexModelo = Conversions.ToInteger(DGDisp.Rows[i].Cells[3].Value);
						clsTopografico.ReinserirTodasLigacoesRegua(ref V2Hp2rKOwIX, sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, regua, indexModelo, cbAlternativo.Checked, rbTerminaisSeparados.Checked);
					}
				}
				return;
			}
			msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 861]), MsgBoxStyle.YesNo);
			if (msgBoxResult != MsgBoxResult.No)
			{
				clsTopografico.ApagarTodasLigacoes(otCp2ELmLKx, "D");
				DeclaracoesTopografico.structureDispsTpg[] array = new DeclaracoesTopografico.structureDispsTpg[DGDisp.RowCount - 1 + 1];
				int num2 = DGDisp.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					array[j].Tag = Conversions.ToString(DGDisp.Rows[j].Cells[0].Value);
					array[j].tipo = Conversions.ToString(DGDisp.Rows[j].Cells[2].Value);
					array[j].indexModelo = Conversions.ToInteger(DGDisp.Rows[j].Cells[3].Value);
				}
				clsTopografico.ReinserirTodasLigacoesDispositivos(ref V2Hp2rKOwIX, sbbp2VLRHdS, e2Yp2uWib9t, otCp2ELmLKx, cbIgnorarExcedentes.Checked, cbAlternativo.Checked, array, cbIgnorarFaltantes.Checked);
			}
		}
	}

	private void hrMpeyABSeV(object P_0, EventArgs P_1)
	{
		cDadosLM.structureDispLM[] sDisp = null;
		cDadosLM cDadosLM2 = new cDadosLM();
		cDadosLM2.CarregaDadosDispositivos(ref sDisp, sbbp2VLRHdS, otCp2ELmLKx);
		cDadosLM2.fechaConexao();
		clsTopografico.inserirItemLMDisp(otCp2ELmLKx, sDisp);
	}

	private void rAKpegX6gFp(object P_0, EventArgs P_1)
	{
		tbDelimitadorTT2.Text = tbDelimitadorTT.Text;
	}

	public void formataDGDWG()
	{
		try
		{
			dgDWG.Rows.Clear();
			dgDWG.Columns.Clear();
			dgDWG.Columns.Add("", "DWG");
			dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 786]));
			DataGridView dg = dgDWG;
			AtualizaDGDWG(ref dg);
			dgDWG = dg;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGDWG(ref DataGridView dg)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double num = dg.Width - 22;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
					{
						num = dg.Width - 4;
					}
					dg.Columns[0].Width = (int)Math.Round(num / 5.0);
					dg.Columns[1].Width = (int)Math.Round(num * 4.0 / 5.0);
					dg.MultiSelect = false;
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

	public void CarregaDGDWG()
	{
		DeclaracoesGeral.arqLogico[] mDWG = new DeclaracoesGeral.arqLogico[1];
		cDadosAccess.carregaDadosTodosDWG(ref mDWG);
		checked
		{
			try
			{
				int num = Information.UBound(mDWG);
				for (int i = 1; i <= num; i++)
				{
					dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (DeclaracoesGeral.arqAtivo.Indice == mDWG[i].Indice)
					{
						dgDWG.Rows[dgDWG.Rows.Count - 1].Selected = true;
					}
				}
				DataGridView dg = dgDWG;
				AtualizaDGDWG(ref dg);
				dgDWG = dg;
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

	public void formataDGRevisao()
	{
		try
		{
			dgRevisao.Rows.Clear();
			dgRevisao.Columns.Clear();
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
			DataGridView dg = dgRevisao;
			AtualizaDGRevisao(ref dg);
			dgRevisao = dg;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGRevisao(ref DataGridView dg)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double a = dg.Width - 22;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
					{
						a = dg.Width - 4;
					}
					dg.Columns[0].Width = (int)Math.Round(a);
					dg.MultiSelect = false;
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

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				YBqp249doRB = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				DataGridView dg = dgEquip;
				AtualizaDGEquip(ref dg);
				dgEquip = dg;
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
				YBqp249doRB = false;
			}
		}
	}

	public void AtualizaDGEquip(ref DataGridView dg)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double a = dg.Width - 22;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
					{
						a = dg.Width - 4;
					}
					dg.Columns[0].Width = 0;
					dgEquip.Columns[0].Visible = false;
					dg.Columns[1].Width = (int)Math.Round(a);
					dg.MultiSelect = false;
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

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				YN0p2CZ2tbU = true;
				DGDisp.Rows.Clear();
				DGDisp.Columns.Clear();
				if (!rbDispositivos.Checked)
				{
					DGDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]));
				}
				else
				{
					DGDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 767]));
				}
				DGDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]));
				DGDisp.Columns.Add("", "");
				DGDisp.Columns.Add("", "");
				DGDisp.Columns.Add("", "");
				DGDisp.Columns.Add("", "");
				DGDisp.Columns.Add("", "");
				int num = DGDisp.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DGDisp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				DataGridView dg = DGDisp;
				AtualizaDGDisp(ref dg);
				DGDisp = dg;
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
				YN0p2CZ2tbU = false;
			}
		}
	}

	public void AtualizaDGDisp(ref DataGridView dg)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double num = dg.Width - 22;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
					{
						num = dg.Width - 4;
					}
					if (cbAlternativo.Checked)
					{
						dg.Columns[0].Width = (int)Math.Round(num / 2.0);
						dg.Columns[1].Width = (int)Math.Round(num / 2.0);
						dg.Columns[1].Visible = true;
					}
					else
					{
						dg.Columns[0].Width = (int)Math.Round(num);
						dg.Columns[1].Width = 0;
						dg.Columns[1].Visible = false;
					}
					dg.Columns[2].Width = 0;
					dg.Columns[2].Visible = false;
					dg.Columns[3].Width = 0;
					dg.Columns[3].Visible = false;
					dg.Columns[4].Width = 0;
					dg.Columns[4].Visible = false;
					dg.Columns[5].Width = 0;
					dg.Columns[5].Visible = false;
					dg.Columns[6].Width = 0;
					dg.Columns[6].Visible = false;
					dg.MultiSelect = false;
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

	public void formataDGBornes()
	{
		checked
		{
			try
			{
				Idjp2YjKx9o = true;
				dgBornes.Rows.Clear();
				dgBornes.Columns.Clear();
				dgBornes.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]));
				dgBornes.Columns.Add("", "TIPO");
				int num = dgBornes.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgBornes.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				DataGridView dg = dgBornes;
				AtualizaDGBornes(ref dg);
				dgBornes = dg;
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
				Idjp2YjKx9o = false;
			}
		}
	}

	public void AtualizaDGBornes(ref DataGridView dg)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double a = dg.Width - 21;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
					{
						a = dg.Width - 4;
					}
					dg.Columns[0].Width = (int)Math.Round(a);
					dg.Columns[1].Width = 0;
					dg.Columns[1].Visible = false;
					dg.MultiSelect = true;
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

	private void pWupeAxi70W(object P_0, EventArgs P_1)
	{
		checked
		{
			float num = DGDisp.Width - 22;
			if (cbAlternativo.Checked)
			{
				DGDisp.Columns[0].Width = (int)Math.Round(num / 2f);
				DGDisp.Columns[1].Width = (int)Math.Round(num / 2f);
				DGDisp.Columns[1].Visible = true;
			}
			else
			{
				DGDisp.Columns[0].Width = (int)Math.Round(num);
				DGDisp.Columns[1].Width = (int)Math.Round(num);
				DGDisp.Columns[1].Visible = false;
			}
		}
	}

	private void i9xpesdwPdi(object P_0, EventArgs P_1)
	{
		if (cbLayout.Checked)
		{
			DataGridViewColumn dataGridViewColumn = DGDisp.Columns[4];
			DGDisp.Sort(dataGridViewColumn, ListSortDirection.Ascending);
		}
		else
		{
			DataGridViewColumn dataGridViewColumn2 = DGDisp.Columns[0];
			DGDisp.Sort(dataGridViewColumn2, ListSortDirection.Ascending);
		}
	}

	public void AtualizaDGDispInseridos(DeclaracoesTopografico.structureDispTopografico dTpg)
	{
		checked
		{
			if (otCp2ELmLKx == dTpg.painel)
			{
				int num = DGDisp.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string left = Conversions.ToString(DGDisp.Rows[i].Cells[0].Value);
					string left2 = Conversions.ToString(DGDisp.Rows[i].Cells[1].Value);
					if ((Operators.CompareString(left, dTpg.tag, TextCompare: true) == 0) & (Operators.CompareString(left2, dTpg.alternativo, TextCompare: true) == 0))
					{
						DGDisp.Rows[i].Cells[0].Style = YUDp29r8eIV;
						DGDisp.Rows[i].Cells[1].Style = YUDp29r8eIV;
						DGDisp.Rows[i].Selected = false;
						break;
					}
				}
			}
			if (!rbDispositivos.Checked)
			{
				if (!rbReguas.Checked)
				{
					return;
				}
				bool flag = false;
				int num2 = dgBornes.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (dgBornes.Rows[j].Cells[0].Style.BackColor == Color.LightGreen)
					{
						dgBornes.Rows[j].Selected = true;
						if (!flag)
						{
							dgBornes.FirstDisplayedScrollingRowIndex = j;
							flag = true;
						}
					}
				}
				return;
			}
			int num3 = DGDisp.RowCount - 1;
			int num4 = 0;
			while (true)
			{
				if (num4 <= num3)
				{
					if (DGDisp.Rows[num4].Cells[0].Style.BackColor == Color.LightGreen)
					{
						break;
					}
					num4++;
					continue;
				}
				return;
			}
			DGDisp.Rows[num4].Selected = true;
			DGDisp.FirstDisplayedScrollingRowIndex = num4;
		}
	}

	public void AtualizadgBornesInseridos(DeclaracoesTopografico.structureBorneTopografico bTpg)
	{
		if (otCp2ELmLKx != bTpg.painel)
		{
			return;
		}
		checked
		{
			int num = DGDisp.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string left = Conversions.ToString(DGDisp.Rows[i].Cells[0].Value);
				if (Operators.CompareString(left, bTpg.regua, TextCompare: true) != 0)
				{
					continue;
				}
				int num2 = dgBornes.Rows.Count - 1;
				int num3 = 0;
				while (num3 <= num2)
				{
					if (!Operators.ConditionalCompareObjectEqual(dgBornes.Rows[num3].Cells[0].Value, bTpg.borne, TextCompare: true))
					{
						num3++;
						continue;
					}
					goto IL_00c5;
				}
				continue;
				IL_00c5:
				dgBornes.Rows[num3].Cells[0].Style = YUDp29r8eIV;
				dgBornes.Rows[num3].Selected = false;
				break;
			}
			List<string> list = new List<string>();
			clsTopografico.carregaBornesInseridos(otCp2ELmLKx, bTpg.regua, list);
			if (list.Count != 0)
			{
				return;
			}
			int num4 = DGDisp.Rows.Count - 1;
			int num5 = 0;
			while (true)
			{
				if (num5 <= num4)
				{
					if (Operators.ConditionalCompareObjectEqual(DGDisp.Rows[num5].Cells[0].Value, bTpg.regua, TextCompare: true))
					{
						break;
					}
					num5++;
					continue;
				}
				return;
			}
			DGDisp.Rows[num5].Cells[0].Style = YUDp29r8eIV;
			DGDisp.Rows[num5].Cells[1].Style = YUDp29r8eIV;
		}
	}

	private void b9PpeBtluZP(object P_0, EventArgs P_1)
	{
		zYnpeVn4UMW();
	}

	private void zYnpeVn4UMW()
	{
		DataGridView dg = dgDWG;
		AtualizaDGDWG(ref dg);
		dgDWG = dg;
		dg = dgRevisao;
		AtualizaDGRevisao(ref dg);
		dgRevisao = dg;
		dg = dgEquip;
		AtualizaDGEquip(ref dg);
		dgEquip = dg;
		dg = DGDisp;
		AtualizaDGDisp(ref dg);
		DGDisp = dg;
		dg = dgBornes;
		AtualizaDGBornes(ref dg);
		dgBornes = dg;
	}
}
