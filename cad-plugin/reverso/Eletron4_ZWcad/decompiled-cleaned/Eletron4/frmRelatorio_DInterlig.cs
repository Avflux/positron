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
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_DInterlig : Form
{
	private IContainer ec2nqfSkmL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView RwfnaST10x;

	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView Dlfn8q328w;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionarRegua")]
	[CompilerGenerated]
	private Button eLWnNV78lB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip NranF9D9VU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox qXZnQHIKmK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCadastro")]
	private RadioButton ApunPm26Yd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCrescente")]
	private RadioButton M3CncEQZcF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRegua")]
	[CompilerGenerated]
	private DataGridView KVjnK5kppW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox CcOner4ION;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb2")]
	[CompilerGenerated]
	private RadioButton rMCn23KwIo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb1")]
	private RadioButton nIwn3IBSV3;

	[AccessedThroughProperty("btApagaRegua")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button Ooannss9FJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btJumper")]
	private Button OE1n1hp7N5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarJumper")]
	private Button g3jnl3QI9y;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarCabos")]
	private Button fYcn5hCL9j;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox BKZn0m1jkN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox knRnRwe5Fe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	[CompilerGenerated]
	private GroupBox fe5nmKJZqU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCabos")]
	private Button jpinXEtdD5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox RrOnUmyhrb;

	[AccessedThroughProperty("btApagarVeias")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button K8HnyqmFe5;

	[AccessedThroughProperty("btVeias")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button khvngyuSJI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSincroniza")]
	private Button VEpnAknv1B;

	[AccessedThroughProperty("ProgressBar1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProgressBar VvTns8mab1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxTipoCruz")]
	private GroupBox MRZnBl5xFK;

	[CompilerGenerated]
	[AccessedThroughProperty("rbCruzCheg")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton juBnVw04vj;

	[AccessedThroughProperty("rbCruz")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton kWinum2YWY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbPesquisa")]
	private TextBox llanE8ul7A;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox8")]
	private GroupBox jEPnZfcWC3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private Label m72niUstpD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label OkxnSldwGg;

	[CompilerGenerated]
	[AccessedThroughProperty("tbReserva")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox hq1n4yBjJD;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label sKCnCJ1DM5;

	[AccessedThroughProperty("tbCruzamento")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox yHNnYWlYWp;

	[AccessedThroughProperty("tbVeia")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox fOJnrrSiWc;

	[AccessedThroughProperty("btMirrorJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button oJjn9v24Vj;

	[AccessedThroughProperty("btRebateCabos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button XFvnz8e2JB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSeleciona")]
	private Button DLA1WSZFK6;

	[AccessedThroughProperty("rbFuncao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton sHG1pagk3l;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbC")]
	[CompilerGenerated]
	private RadioButton wGe1TAVbOA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btCima")]
	private Button J391J58MmF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxPaineisCima")]
	[CompilerGenerated]
	private GroupBox WDr1hy7bxb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgUp")]
	private DataGridView ECM1olIKZv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btVerificar")]
	private Button xfy1G0Cn1n;

	[CompilerGenerated]
	[AccessedThroughProperty("btApagarCruzamentos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button VoF1H1rXR9;

	private DeclaracoesFiacao.structurePnRev[] RjU1kPIPP9;

	private DeclaracoesFiacao.structureRevisoes[] gBW1dRfxsx;

	private DeclaracoesInterligacao.structureRI[] UPr1fCeWHt;

	private DeclaracoesInterligacao.structureBornesInseridos[] OJC1DuCleu;

	private string y8h1vRRdNP;

	private int cPf16AVMSm;

	private bool L9v1tmNUfo;

	private bool MDw1jLafTK;

	private DeclaracoesInterligacao.ConfigDInterlig Jah1LWHafV;

	private int orN1wKRAnJ;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return RwfnaST10x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tOf3ZYibFE;
			DataGridView dataGridView = RwfnaST10x;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			RwfnaST10x = value;
			dataGridView = RwfnaST10x;
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
			return Dlfn8q328w;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TBM3C2yAGO;
			DataGridView dataGridView = Dlfn8q328w;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			Dlfn8q328w = value;
			dataGridView = Dlfn8q328w;
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
			return eLWnNV78lB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NQYnpfNtua;
			Button button = eLWnNV78lB;
			if (button != null)
			{
				button.Click -= value2;
			}
			eLWnNV78lB = value;
			button = eLWnNV78lB;
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
			return qXZnQHIKmK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qXZnQHIKmK = value;
		}
	}

	internal virtual RadioButton rbCadastro
	{
		[CompilerGenerated]
		get
		{
			return ApunPm26Yd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OPB34QcKWg;
			RadioButton radioButton = ApunPm26Yd;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			ApunPm26Yd = value;
			radioButton = ApunPm26Yd;
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
			return M3CncEQZcF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			M3CncEQZcF = value;
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return KVjnK5kppW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KVjnK5kppW = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return CcOner4ION;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CcOner4ION = value;
		}
	}

	internal virtual RadioButton rb2
	{
		[CompilerGenerated]
		get
		{
			return rMCn23KwIo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rMCn23KwIo = value;
		}
	}

	internal virtual RadioButton rb1
	{
		[CompilerGenerated]
		get
		{
			return nIwn3IBSV3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nIwn3IBSV3 = value;
		}
	}

	internal virtual Button btApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return Ooannss9FJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = psFnTm7ygg;
			Button button = Ooannss9FJ;
			if (button != null)
			{
				button.Click -= value2;
			}
			Ooannss9FJ = value;
			button = Ooannss9FJ;
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
			return OE1n1hp7N5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TH9nhCGnx2;
			Button button = OE1n1hp7N5;
			if (button != null)
			{
				button.Click -= value2;
			}
			OE1n1hp7N5 = value;
			button = OE1n1hp7N5;
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
			return g3jnl3QI9y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IA5novE6EC;
			Button button = g3jnl3QI9y;
			if (button != null)
			{
				button.Click -= value2;
			}
			g3jnl3QI9y = value;
			button = g3jnl3QI9y;
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
			return fYcn5hCL9j;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UvGnfh5Mel;
			Button button = fYcn5hCL9j;
			if (button != null)
			{
				button.Click -= value2;
			}
			fYcn5hCL9j = value;
			button = fYcn5hCL9j;
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
			return BKZn0m1jkN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BKZn0m1jkN = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return knRnRwe5Fe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			knRnRwe5Fe = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return fe5nmKJZqU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fe5nmKJZqU = value;
		}
	}

	internal virtual Button btCabos
	{
		[CompilerGenerated]
		get
		{
			return jpinXEtdD5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YB0ndcG9Ox;
			Button button = jpinXEtdD5;
			if (button != null)
			{
				button.Click -= value2;
			}
			jpinXEtdD5 = value;
			button = jpinXEtdD5;
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
			return RrOnUmyhrb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RrOnUmyhrb = value;
		}
	}

	internal virtual Button btApagarVeias
	{
		[CompilerGenerated]
		get
		{
			return K8HnyqmFe5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Tevnv6j203;
			Button button = K8HnyqmFe5;
			if (button != null)
			{
				button.Click -= value2;
			}
			K8HnyqmFe5 = value;
			button = K8HnyqmFe5;
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
			return khvngyuSJI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = v6MnDD7fAQ;
			Button button = khvngyuSJI;
			if (button != null)
			{
				button.Click -= value2;
			}
			khvngyuSJI = value;
			button = khvngyuSJI;
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
			return VEpnAknv1B;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GUWn6ju7xG;
			Button button = VEpnAknv1B;
			if (button != null)
			{
				button.Click -= value2;
			}
			VEpnAknv1B = value;
			button = VEpnAknv1B;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return VvTns8mab1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VvTns8mab1 = value;
		}
	}

	internal virtual GroupBox GroupBoxTipoCruz
	{
		[CompilerGenerated]
		get
		{
			return MRZnBl5xFK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MRZnBl5xFK = value;
		}
	}

	internal virtual RadioButton rbCruzCheg
	{
		[CompilerGenerated]
		get
		{
			return juBnVw04vj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = C1FnLWdlnw;
			RadioButton radioButton = juBnVw04vj;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			juBnVw04vj = value;
			radioButton = juBnVw04vj;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbCruz
	{
		[CompilerGenerated]
		get
		{
			return kWinum2YWY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BUJnjX0brg;
			RadioButton radioButton = kWinum2YWY;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			kWinum2YWY = value;
			radioButton = kWinum2YWY;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual TextBox tbPesquisa
	{
		[CompilerGenerated]
		get
		{
			return llanE8ul7A;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = xCQ3iE9hp6;
			TextBox textBox = llanE8ul7A;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			llanE8ul7A = value;
			textBox = llanE8ul7A;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox8
	{
		[CompilerGenerated]
		get
		{
			return jEPnZfcWC3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jEPnZfcWC3 = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return m72niUstpD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m72niUstpD = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return OkxnSldwGg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OkxnSldwGg = value;
		}
	}

	internal virtual TextBox tbReserva
	{
		[CompilerGenerated]
		get
		{
			return hq1n4yBjJD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = RE7n7A7Og9;
			TextBox textBox = hq1n4yBjJD;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			hq1n4yBjJD = value;
			textBox = hq1n4yBjJD;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return sKCnCJ1DM5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sKCnCJ1DM5 = value;
		}
	}

	internal virtual TextBox tbCruzamento
	{
		[CompilerGenerated]
		get
		{
			return yHNnYWlYWp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = jTxnIhDaoh;
			TextBox textBox = yHNnYWlYWp;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			yHNnYWlYWp = value;
			textBox = yHNnYWlYWp;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbVeia
	{
		[CompilerGenerated]
		get
		{
			return fOJnrrSiWc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = v3anO0nRXY;
			TextBox textBox = fOJnrrSiWc;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			fOJnrrSiWc = value;
			textBox = fOJnrrSiWc;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button btMirrorJumper
	{
		[CompilerGenerated]
		get
		{
			return oJjn9v24Vj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = O6HnGfAohl;
			Button button = oJjn9v24Vj;
			if (button != null)
			{
				button.Click -= value2;
			}
			oJjn9v24Vj = value;
			button = oJjn9v24Vj;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btRebateCabos
	{
		[CompilerGenerated]
		get
		{
			return XFvnz8e2JB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ElankG2GUF;
			Button button = XFvnz8e2JB;
			if (button != null)
			{
				button.Click -= value2;
			}
			XFvnz8e2JB = value;
			button = XFvnz8e2JB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return DLA1WSZFK6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dnQnJbZWrn;
			Button button = DLA1WSZFK6;
			if (button != null)
			{
				button.Click -= value2;
			}
			DLA1WSZFK6 = value;
			button = DLA1WSZFK6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbFuncao
	{
		[CompilerGenerated]
		get
		{
			return sHG1pagk3l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MKfnwnwu7X;
			RadioButton radioButton = sHG1pagk3l;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			sHG1pagk3l = value;
			radioButton = sHG1pagk3l;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbC
	{
		[CompilerGenerated]
		get
		{
			return wGe1TAVbOA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WBRnxP8rbQ;
			RadioButton radioButton = wGe1TAVbOA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			wGe1TAVbOA = value;
			radioButton = wGe1TAVbOA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btCima
	{
		[CompilerGenerated]
		get
		{
			return J391J58MmF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vljnHcJLhi;
			Button button = J391J58MmF;
			if (button != null)
			{
				button.Click -= value2;
			}
			J391J58MmF = value;
			button = J391J58MmF;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBoxPaineisCima
	{
		[CompilerGenerated]
		get
		{
			return WDr1hy7bxb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WDr1hy7bxb = value;
		}
	}

	internal virtual DataGridView dgUp
	{
		[CompilerGenerated]
		get
		{
			return ECM1olIKZv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ECM1olIKZv = value;
		}
	}

	internal virtual Button btVerificar
	{
		[CompilerGenerated]
		get
		{
			return xfy1G0Cn1n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CDr39BhCVh;
			Button button = xfy1G0Cn1n;
			if (button != null)
			{
				button.Click -= value2;
			}
			xfy1G0Cn1n = value;
			button = xfy1G0Cn1n;
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
			return VoF1H1rXR9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = k4VntVc0xZ;
			Button button = VoF1H1rXR9;
			if (button != null)
			{
				button.Click -= value2;
			}
			VoF1H1rXR9 = value;
			button = VoF1H1rXR9;
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
			if (disposing && ec2nqfSkmL != null)
			{
				ec2nqfSkmL.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void mT63ViM7fU()
	{
		ec2nqfSkmL = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		btAdicionarRegua = new Button();
		FDqpBiUmZij(new ToolTip(ec2nqfSkmL));
		GroupBox2 = new GroupBox();
		rbCadastro = new RadioButton();
		rbCrescente = new RadioButton();
		dgRegua = new DataGridView();
		GroupBox1 = new GroupBox();
		rbC = new RadioButton();
		rb2 = new RadioButton();
		rb1 = new RadioButton();
		btApagaRegua = new Button();
		btJumper = new Button();
		btApagarJumper = new Button();
		btApagarCabos = new Button();
		GroupBox3 = new GroupBox();
		btVerificar = new Button();
		btSeleciona = new Button();
		GroupBox4 = new GroupBox();
		btMirrorJumper = new Button();
		btRebateCabos = new Button();
		GroupBox5 = new GroupBox();
		btCima = new Button();
		btCabos = new Button();
		GroupBox6 = new GroupBox();
		btVeias = new Button();
		btApagarVeias = new Button();
		btSincroniza = new Button();
		ProgressBar1 = new ProgressBar();
		GroupBoxTipoCruz = new GroupBox();
		rbFuncao = new RadioButton();
		rbCruzCheg = new RadioButton();
		rbCruz = new RadioButton();
		tbPesquisa = new TextBox();
		GroupBox8 = new GroupBox();
		Label3 = new Label();
		Label2 = new Label();
		tbReserva = new TextBox();
		Label1 = new Label();
		tbCruzamento = new TextBox();
		tbVeia = new TextBox();
		GroupBoxPaineisCima = new GroupBox();
		dgUp = new DataGridView();
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
		GroupBoxTipoCruz.SuspendLayout();
		GroupBox8.SuspendLayout();
		GroupBoxPaineisCima.SuspendLayout();
		((ISupportInitialize)dgUp).BeginInit();
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
		dgRevisao.Size = new Size(385, 106);
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
		dgEquip.Location = new Point(12, 150);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(137, 123);
		dgEquip.TabIndex = 8;
		btAdicionarRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAdicionarRegua.FlatStyle = FlatStyle.Flat;
		btAdicionarRegua.ForeColor = SystemColors.Control;
		btAdicionarRegua.Image = Resources.BorneAranha_32;
		btAdicionarRegua.Location = new Point(37, 18);
		btAdicionarRegua.Name = "btAdicionarRegua";
		btAdicionarRegua.Size = new Size(40, 42);
		btAdicionarRegua.TabIndex = 15;
		btAdicionarRegua.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rbCadastro);
		GroupBox2.Controls.Add(rbCrescente);
		GroupBox2.Location = new Point(12, 382);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(137, 73);
		GroupBox2.TabIndex = 47;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordem Bornes Máscara";
		rbCadastro.AutoSize = true;
		rbCadastro.Location = new Point(6, 42);
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
		dgRegua.Location = new Point(155, 124);
		dgRegua.MultiSelect = false;
		dgRegua.Name = "dgRegua";
		dgRegua.ReadOnly = true;
		dgRegua.RowHeadersVisible = false;
		dgRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRegua.Size = new Size(242, 259);
		dgRegua.TabIndex = 48;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbC);
		GroupBox1.Controls.Add(rb2);
		GroupBox1.Controls.Add(rb1);
		GroupBox1.Location = new Point(155, 406);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(157, 49);
		GroupBox1.TabIndex = 49;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Posição";
		rbC.AutoSize = true;
		rbC.Location = new Point(109, 19);
		rbC.Name = "rbC";
		rbC.Size = new Size(41, 17);
		rbC.TabIndex = 52;
		rbC.TabStop = true;
		rbC.Text = "rbC";
		rbC.UseVisualStyleBackColor = true;
		rb2.AutoSize = true;
		rb2.Location = new Point(60, 19);
		rb2.Name = "rb2";
		rb2.Size = new Size(40, 17);
		rb2.TabIndex = 51;
		rb2.TabStop = true;
		rb2.Text = "rb2";
		rb2.UseVisualStyleBackColor = true;
		rb1.AutoSize = true;
		rb1.Location = new Point(11, 19);
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
		btApagaRegua.Location = new Point(73, 18);
		btApagaRegua.Name = "btApagaRegua";
		btApagaRegua.Size = new Size(40, 42);
		btApagaRegua.TabIndex = 50;
		btApagaRegua.UseVisualStyleBackColor = true;
		btJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btJumper.FlatStyle = FlatStyle.Flat;
		btJumper.ForeColor = SystemColors.Control;
		btJumper.Image = Resources.JumperAranha90_32;
		btJumper.Location = new Point(5, 19);
		btJumper.Name = "btJumper";
		btJumper.Size = new Size(32, 42);
		btJumper.TabIndex = 51;
		btJumper.UseVisualStyleBackColor = true;
		btApagarJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarJumper.FlatStyle = FlatStyle.Flat;
		btApagarJumper.ForeColor = SystemColors.Control;
		btApagarJumper.Image = Resources.Delete_32;
		btApagarJumper.Location = new Point(41, 19);
		btApagarJumper.Name = "btApagarJumper";
		btApagarJumper.Size = new Size(32, 42);
		btApagarJumper.TabIndex = 52;
		btApagarJumper.UseVisualStyleBackColor = true;
		btApagarCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCabos.FlatStyle = FlatStyle.Flat;
		btApagarCabos.ForeColor = SystemColors.Control;
		btApagarCabos.Image = Resources.Delete_32;
		btApagarCabos.Location = new Point(73, 18);
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
		GroupBox3.Size = new Size(115, 70);
		GroupBox3.TabIndex = 56;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Réguas de Bornes";
		btVerificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVerificar.FlatStyle = FlatStyle.Flat;
		btVerificar.ForeColor = SystemColors.Control;
		btVerificar.Image = Resources.Check;
		btVerificar.Location = new Point(1, 18);
		btVerificar.Name = "btVerificar";
		btVerificar.Size = new Size(36, 42);
		btVerificar.TabIndex = 51;
		btVerificar.UseVisualStyleBackColor = true;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_16;
		btSeleciona.Location = new Point(132, 124);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(16, 20);
		btSeleciona.TabIndex = 65;
		btSeleciona.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(btMirrorJumper);
		GroupBox4.Controls.Add(btApagarJumper);
		GroupBox4.Controls.Add(btJumper);
		GroupBox4.Location = new Point(282, 459);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(115, 70);
		GroupBox4.TabIndex = 57;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Jumpers";
		btMirrorJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btMirrorJumper.FlatStyle = FlatStyle.Flat;
		btMirrorJumper.ForeColor = SystemColors.Control;
		btMirrorJumper.Image = Resources.JumperRebatido_32;
		btMirrorJumper.Location = new Point(77, 19);
		btMirrorJumper.Name = "btMirrorJumper";
		btMirrorJumper.Size = new Size(32, 42);
		btMirrorJumper.TabIndex = 64;
		btMirrorJumper.UseVisualStyleBackColor = true;
		btRebateCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btRebateCabos.FlatStyle = FlatStyle.Flat;
		btRebateCabos.ForeColor = SystemColors.Control;
		btRebateCabos.Image = Resources.VeiaRebatida;
		btRebateCabos.Location = new Point(140, 18);
		btRebateCabos.Name = "btRebateCabos";
		btRebateCabos.Size = new Size(32, 42);
		btRebateCabos.TabIndex = 65;
		btRebateCabos.UseVisualStyleBackColor = true;
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(btCima);
		GroupBox5.Controls.Add(btCabos);
		GroupBox5.Controls.Add(btApagarCabos);
		GroupBox5.Location = new Point(155, 534);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(115, 70);
		GroupBox5.TabIndex = 58;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Cabos";
		btCima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCima.FlatStyle = FlatStyle.Flat;
		btCima.ForeColor = SystemColors.Control;
		btCima.Image = Resources.DI_Up;
		btCima.Location = new Point(1, 15);
		btCima.Name = "btCima";
		btCima.Size = new Size(32, 42);
		btCima.TabIndex = 65;
		btCima.UseVisualStyleBackColor = true;
		btCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCabos.FlatStyle = FlatStyle.Flat;
		btCabos.ForeColor = SystemColors.Control;
		btCabos.Image = Resources.CaboAranha_32;
		btCabos.Location = new Point(36, 18);
		btCabos.Name = "btCabos";
		btCabos.Size = new Size(40, 42);
		btCabos.TabIndex = 51;
		btCabos.UseVisualStyleBackColor = true;
		GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox6.Controls.Add(btRebateCabos);
		GroupBox6.Controls.Add(btVeias);
		GroupBox6.Controls.Add(btApagarVeias);
		GroupBox6.Location = new Point(284, 534);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(115, 70);
		GroupBox6.TabIndex = 59;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Veias";
		btVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVeias.FlatStyle = FlatStyle.Flat;
		btVeias.ForeColor = SystemColors.Control;
		btVeias.Image = Resources.Veias90;
		btVeias.Location = new Point(16, 18);
		btVeias.Name = "btVeias";
		btVeias.Size = new Size(32, 42);
		btVeias.TabIndex = 55;
		btVeias.UseVisualStyleBackColor = true;
		btApagarVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarVeias.FlatStyle = FlatStyle.Flat;
		btApagarVeias.ForeColor = SystemColors.Control;
		btApagarVeias.Image = Resources.Delete_32;
		btApagarVeias.Location = new Point(60, 18);
		btApagarVeias.Name = "btApagarVeias";
		btApagarVeias.Size = new Size(32, 42);
		btApagarVeias.TabIndex = 52;
		btApagarVeias.UseVisualStyleBackColor = true;
		btSincroniza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSincroniza.FlatStyle = FlatStyle.Flat;
		btSincroniza.ForeColor = SystemColors.Control;
		btSincroniza.Image = Resources.Sincroniza_32;
		btSincroniza.Location = new Point(315, 413);
		btSincroniza.Name = "btSincroniza";
		btSincroniza.Size = new Size(36, 42);
		btSincroniza.TabIndex = 51;
		btSincroniza.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(155, 389);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(242, 11);
		ProgressBar1.TabIndex = 60;
		GroupBoxTipoCruz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBoxTipoCruz.Controls.Add(rbFuncao);
		GroupBoxTipoCruz.Controls.Add(rbCruzCheg);
		GroupBoxTipoCruz.Controls.Add(rbCruz);
		GroupBoxTipoCruz.Location = new Point(12, 459);
		GroupBoxTipoCruz.Name = "GroupBoxTipoCruz";
		GroupBoxTipoCruz.Size = new Size(137, 70);
		GroupBoxTipoCruz.TabIndex = 61;
		GroupBoxTipoCruz.TabStop = false;
		GroupBoxTipoCruz.Text = "Tipo de Cruzamento";
		rbFuncao.AutoSize = true;
		rbFuncao.Location = new Point(6, 44);
		rbFuncao.Name = "rbFuncao";
		rbFuncao.Size = new Size(82, 17);
		rbFuncao.TabIndex = 4;
		rbFuncao.TabStop = true;
		rbFuncao.Text = "FuncaoVeia";
		rbFuncao.UseVisualStyleBackColor = true;
		rbCruzCheg.AutoSize = true;
		rbCruzCheg.Location = new Point(6, 28);
		rbCruzCheg.Name = "rbCruzCheg";
		rbCruzCheg.Size = new Size(126, 17);
		rbCruzCheg.TabIndex = 3;
		rbCruzCheg.TabStop = true;
		rbCruzCheg.Text = "Cruzado+Pt Chegada";
		rbCruzCheg.UseVisualStyleBackColor = true;
		rbCruz.AutoSize = true;
		rbCruz.Location = new Point(6, 13);
		rbCruz.Name = "rbCruz";
		rbCruz.Size = new Size(64, 17);
		rbCruz.TabIndex = 0;
		rbCruz.TabStop = true;
		rbCruz.Text = "Cruzado";
		rbCruz.UseVisualStyleBackColor = true;
		tbPesquisa.Location = new Point(11, 124);
		tbPesquisa.Name = "tbPesquisa";
		tbPesquisa.Size = new Size(115, 20);
		tbPesquisa.TabIndex = 63;
		GroupBox8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox8.Controls.Add(Label3);
		GroupBox8.Controls.Add(Label2);
		GroupBox8.Controls.Add(tbReserva);
		GroupBox8.Controls.Add(Label1);
		GroupBox8.Controls.Add(tbCruzamento);
		GroupBox8.Controls.Add(tbVeia);
		GroupBox8.Location = new Point(12, 279);
		GroupBox8.Name = "GroupBox8";
		GroupBox8.Size = new Size(137, 101);
		GroupBox8.TabIndex = 58;
		GroupBox8.TabStop = false;
		GroupBox8.Text = "Altura Fontes";
		Label3.AutoSize = true;
		Label3.Location = new Point(6, 74);
		Label3.Name = "Label3";
		Label3.Size = new Size(39, 13);
		Label3.TabIndex = 4;
		Label3.Text = "Label3";
		Label2.AutoSize = true;
		Label2.Location = new Point(6, 48);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 3;
		Label2.Text = "Label2";
		tbReserva.Location = new Point(95, 71);
		tbReserva.Name = "tbReserva";
		tbReserva.Size = new Size(34, 20);
		tbReserva.TabIndex = 2;
		Label1.AutoSize = true;
		Label1.Location = new Point(6, 22);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 2;
		Label1.Text = "Label1";
		tbCruzamento.Location = new Point(95, 45);
		tbCruzamento.Name = "tbCruzamento";
		tbCruzamento.Size = new Size(34, 20);
		tbCruzamento.TabIndex = 1;
		tbVeia.Location = new Point(95, 19);
		tbVeia.Name = "tbVeia";
		tbVeia.Size = new Size(34, 20);
		tbVeia.TabIndex = 0;
		GroupBoxPaineisCima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBoxPaineisCima.Controls.Add(dgUp);
		GroupBoxPaineisCima.Location = new Point(12, 535);
		GroupBoxPaineisCima.Name = "GroupBoxPaineisCima";
		GroupBoxPaineisCima.Size = new Size(137, 143);
		GroupBoxPaineisCima.TabIndex = 62;
		GroupBoxPaineisCima.TabStop = false;
		GroupBoxPaineisCima.Text = "Painéis Cima";
		dgUp.AllowUserToAddRows = false;
		dgUp.AllowUserToOrderColumns = true;
		dgUp.AllowUserToResizeRows = false;
		dgUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		dgUp.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgUp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgUp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgUp.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgUp.Location = new Point(6, 19);
		dgUp.MultiSelect = false;
		dgUp.Name = "dgUp";
		dgUp.ReadOnly = true;
		dgUp.RowHeadersVisible = false;
		dgUp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgUp.Size = new Size(125, 118);
		dgUp.TabIndex = 68;
		btApagarCruzamentos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCruzamentos.FlatStyle = FlatStyle.Flat;
		btApagarCruzamentos.ForeColor = SystemColors.Control;
		btApagarCruzamentos.Image = Resources.Delete_32;
		btApagarCruzamentos.Location = new Point(361, 413);
		btApagarCruzamentos.Name = "btApagarCruzamentos";
		btApagarCruzamentos.Size = new Size(36, 42);
		btApagarCruzamentos.TabIndex = 70;
		btApagarCruzamentos.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(404, 611);
		Controls.Add(btApagarCruzamentos);
		Controls.Add(GroupBoxPaineisCima);
		Controls.Add(btSeleciona);
		Controls.Add(GroupBox8);
		Controls.Add(tbPesquisa);
		Controls.Add(GroupBoxTipoCruz);
		Controls.Add(ProgressBar1);
		Controls.Add(btSincroniza);
		Controls.Add(GroupBox6);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(dgRegua);
		Controls.Add(GroupBox2);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(420, 1200);
		MinimumSize = new Size(420, 650);
		Name = "frmRelatorio_DInterlig";
		ShowInTaskbar = false;
		Text = "Diagrama de Interligação";
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
		GroupBoxTipoCruz.ResumeLayout(performLayout: false);
		GroupBoxTipoCruz.PerformLayout();
		GroupBox8.ResumeLayout(performLayout: false);
		GroupBox8.PerformLayout();
		GroupBoxPaineisCima.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgUp).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return NranF9D9VU;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		NranF9D9VU = WithEventsValue;
	}

	public frmRelatorio_DInterlig(int value)
	{
		RjU1kPIPP9 = new DeclaracoesFiacao.structurePnRev[1];
		gBW1dRfxsx = new DeclaracoesFiacao.structureRevisoes[1];
		y8h1vRRdNP = "";
		cPf16AVMSm = 0;
		L9v1tmNUfo = false;
		MDw1jLafTK = false;
		Jah1LWHafV = default;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_DInterlig"))
			{
				mT63ViM7fU();
				dmt3upEkG8(_0020: false);
				orN1wKRAnJ = value;
				switch (orN1wKRAnJ)
				{
				case 11:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1961]);
					break;
				case 1:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 897]);
					break;
				case 2:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1493]);
					break;
				case 3:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1494]);
					break;
				case 4:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1682]);
					break;
				case 5:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1793]);
					break;
				case 6:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1795]);
					break;
				case 7:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1861]);
					break;
				case 8:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1871]);
					break;
				case 9:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1877]);
					break;
				case 10:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1879]);
					break;
				}
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1439]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1419]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1444]);
				GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
				GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1445]);
				GroupBoxTipoCruz.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 825]);
				rbCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1420]);
				rbCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1421]);
				rb1.Text = "1";
				rb2.Text = "2";
				rbC.Text = "C";
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1445]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1530]);
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1434]);
				rbCruz.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 826]);
				rbCruzCheg.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 829]);
				rbFuncao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1659]);
				w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1900]));
				w8dpBZ0kvSD().SetToolTip(btApagarCruzamentos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1901]));
				w8dpBZ0kvSD().SetToolTip(btVerificar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1902]));
				w8dpBZ0kvSD().SetToolTip(btCima, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1903]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				UPr1fCeWHt = new DeclaracoesInterligacao.structureRI[1];
				UPr1fCeWHt[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				OJC1DuCleu = new DeclaracoesInterligacao.structureBornesInseridos[1];
				formataDGRevisao();
				formataDGEquip();
				rbCrescente.Checked = true;
				rb1.Checked = true;
				rbCruzCheg.Checked = true;
				eAt3EQfqRr();
				if (orN1wKRAnJ == 2)
				{
					GroupBoxTipoCruz.Visible = true;
				}
				else
				{
					GroupBoxTipoCruz.Visible = false;
				}
				if (!((orN1wKRAnJ == 1) | (orN1wKRAnJ == 3) | (orN1wKRAnJ == 5) | (orN1wKRAnJ == 6) | (orN1wKRAnJ == 7) | (orN1wKRAnJ == 8) | (orN1wKRAnJ == 9) | (orN1wKRAnJ == 10) | (orN1wKRAnJ == 11)))
				{
					GroupBoxPaineisCima.Visible = false;
				}
				else
				{
					GroupBoxPaineisCima.Visible = true;
				}
				GroupBoxPaineisCima.Location = GroupBoxTipoCruz.Location;
				if (!((orN1wKRAnJ == 1) | (orN1wKRAnJ == 3) | (orN1wKRAnJ == 5) | (orN1wKRAnJ == 6) | (orN1wKRAnJ == 7) | (orN1wKRAnJ == 8) | (orN1wKRAnJ == 9) | (orN1wKRAnJ == 10) | (orN1wKRAnJ == 11)))
				{
					btMirrorJumper.Enabled = false;
					btRebateCabos.Enabled = false;
					btCima.Enabled = false;
				}
				else
				{
					btRebateCabos.Enabled = false;
					CdgnbrQbmr();
				}
				if (orN1wKRAnJ == 4)
				{
					GroupBox1.Visible = false;
				}
				if ((orN1wKRAnJ == 6) | (orN1wKRAnJ == 7) | (orN1wKRAnJ == 10))
				{
					rb2.Visible = false;
				}
				if (!((orN1wKRAnJ == 1) | (orN1wKRAnJ == 3) | (orN1wKRAnJ == 5) | (orN1wKRAnJ == 6) | (orN1wKRAnJ == 7) | (orN1wKRAnJ == 8) | (orN1wKRAnJ == 9) | (orN1wKRAnJ == 10) | (orN1wKRAnJ == 11)))
				{
					rbC.Enabled = false;
				}
				else
				{
					rbC.Enabled = true;
				}
				if (orN1wKRAnJ == 9)
				{
					Label3.Visible = false;
					tbReserva.Visible = false;
				}
				uudnMdBJ9Q();
				dmt3upEkG8(_0020: true);
				tbVeia.Text = Conversions.ToString(Jah1LWHafV.alturaFonteVeia);
				tbCruzamento.Text = Conversions.ToString(Jah1LWHafV.alturaFonteCruzamento);
				tbReserva.Text = Conversions.ToString(Jah1LWHafV.alturaFonteReservas);
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

	private void dmt3upEkG8(bool P_0)
	{
		GroupBox1.Enabled = P_0;
		GroupBox2.Enabled = P_0;
		GroupBox3.Enabled = P_0;
		GroupBox4.Enabled = P_0;
		GroupBox5.Enabled = P_0;
		GroupBox6.Enabled = P_0;
		GroupBoxTipoCruz.Enabled = P_0;
		btSincroniza.Enabled = P_0;
		btSeleciona.Enabled = P_0;
	}

	private void eAt3EQfqRr()
	{
		gBW1dRfxsx = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref gBW1dRfxsx);
			L9v1tmNUfo = true;
			dgRevisao.Rows.Clear();
			L9v1tmNUfo = false;
			int num = Information.UBound(gBW1dRfxsx);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(gBW1dRfxsx[i].revisao, gBW1dRfxsx[i].criador, gBW1dRfxsx[i].data);
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

	private void tOf3ZYibFE(object P_0, EventArgs P_1)
	{
		MDw1jLafTK = true;
		dgEquip.Rows.Clear();
		MDw1jLafTK = false;
		if (!L9v1tmNUfo)
		{
			NMv3S6YP2Z(_0020: false);
		}
	}

	private void xCQ3iE9hp6(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(tbPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !L9v1tmNUfo)
		{
			NMv3S6YP2Z(_0020: true);
		}
	}

	private void NMv3S6YP2Z(bool P_0)
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
			y8h1vRRdNP = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			MDw1jLafTK = true;
			dgEquip.Rows.Clear();
			MDw1jLafTK = false;
			int num = Information.UBound(RjU1kPIPP9);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(RjU1kPIPP9[i].revisao, y8h1vRRdNP, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(RjU1kPIPP9[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(RjU1kPIPP9[i].painel, text);
					}
					else if (text.ToUpper().Contains(tbPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(RjU1kPIPP9[i].painel, text);
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
		RjU1kPIPP9 = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(gBW1dRfxsx) > 0)
			{
				int num = Information.UBound(gBW1dRfxsx);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(gBW1dRfxsx[i].revisao, ref RjU1kPIPP9);
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

	private void OPB34QcKWg(object P_0, EventArgs P_1)
	{
		cba3Y7S961();
	}

	private void TBM3C2yAGO(object P_0, EventArgs P_1)
	{
		cba3Y7S961();
		formataDGCima();
	}

	private void cba3Y7S961()
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				dmt3upEkG8(_0020: false);
				cPf16AVMSm = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				formataDGRegua();
				UPr1fCeWHt = new DeclaracoesInterligacao.structureRI[1];
				UPr1fCeWHt[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cDadosAccessInterligacao3.CarregaReguas(y8h1vRRdNP, cPf16AVMSm, ref UPr1fCeWHt);
				cDadosAccessInterligacao3.CarregaReguasPortas(y8h1vRRdNP, cPf16AVMSm, ref UPr1fCeWHt);
				cDadosAccessInterligacao3.CarregaBornesReguas(y8h1vRRdNP, cPf16AVMSm, ref UPr1fCeWHt, rbCadastro.Checked);
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = checked(SWQ3rPaGQR() * 2);
				ProgressBar1.Value = 0;
				ProgressBar1.Step = 1;
				string revisao = y8h1vRRdNP;
				int painel = cPf16AVMSm;
				ref DeclaracoesInterligacao.structureRI[] uPr1fCeWHt = ref UPr1fCeWHt;
				ProgressBar ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaCabosNosBornesRI(revisao, painel, ref uPr1fCeWHt, ref ProgressBar, orN1wKRAnJ);
				ProgressBar1 = ProgressBar;
				string revisao2 = y8h1vRRdNP;
				int painel2 = cPf16AVMSm;
				ref DeclaracoesInterligacao.structureRI[] uPr1fCeWHt2 = ref UPr1fCeWHt;
				ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaJumpersNosBornesRI(revisao2, painel2, ref uPr1fCeWHt2, ref ProgressBar);
				ProgressBar1 = ProgressBar;
				ijrnW43N4u();
				whA3z7bYZc();
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
			dmt3upEkG8(_0020: true);
		}
	}

	private int SWQ3rPaGQR()
	{
		int num = 0;
		int num2 = Information.UBound(UPr1fCeWHt);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!Information.IsNothing(UPr1fCeWHt[i].Bornes))
				{
					num += UPr1fCeWHt[i].Bornes.Length - 1;
				}
			}
			return num;
		}
	}

	private void CDr39BhCVh(object P_0, EventArgs P_1)
	{
		whA3z7bYZc();
	}

	private void whA3z7bYZc()
	{
		OJC1DuCleu = new DeclaracoesInterligacao.structureBornesInseridos[1];
		clsDInterlig.ContaBornesReguas(cPf16AVMSm, ref OJC1DuCleu);
		checked
		{
			int num = dgRegua.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string right = Conversions.ToString(dgRegua.Rows[i].Cells[1].Value);
				string right2 = Conversions.ToString(dgRegua.Rows[i].Cells[2].Value);
				int num2 = Conversions.ToInteger(dgRegua.Rows[i].Cells[3].Value);
				bool flag = false;
				int num3 = Information.UBound(OJC1DuCleu);
				for (int j = 1; j <= num3; j++)
				{
					if (!((Operators.CompareString(OJC1DuCleu[j].Tag, right, TextCompare: true) == 0) & (Operators.CompareString(OJC1DuCleu[j].NRegua, right2, TextCompare: true) == 0)))
					{
						continue;
					}
					if (num2 != OJC1DuCleu[j].Qtde)
					{
						if ((num2 > OJC1DuCleu[j].Qtde) & (OJC1DuCleu[j].Qtde > 0))
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

	private void ijrnW43N4u()
	{
		if (Information.UBound(UPr1fCeWHt) == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		try
		{
			int num = Information.UBound(UPr1fCeWHt);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Information.IsNothing(UPr1fCeWHt[i].Bornes))
				{
					if (!list.Contains(UPr1fCeWHt[i].DWG))
					{
						list.Add(UPr1fCeWHt[i].DWG);
					}
					continue;
				}
				int num2 = Information.UBound(UPr1fCeWHt[i].Bornes);
				dgRegua.Rows.Add(UPr1fCeWHt[i].Tipo, UPr1fCeWHt[i].Tag, UPr1fCeWHt[i].NRegua, num2);
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

	private void NQYnpfNtua(object P_0, EventArgs P_1)
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				DeclaracoesInterligacao.structureRI structureRI = default;
				if (dgEquip.SelectedRows.Count == 0 || dgRegua.SelectedRows.Count == 0)
				{
					return;
				}
				DeclaracoesGeral.Reguas RH = default;
				if (XDataGeral.LeXDataReguaH(ref RH))
				{
					string text = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
					string text2 = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
					int num = Information.UBound(UPr1fCeWHt);
					for (int i = 1; i <= num; i++)
					{
						if ((Operators.CompareString(UPr1fCeWHt[i].Tag, text, TextCompare: true) == 0) & (Operators.CompareString(UPr1fCeWHt[i].NRegua, text2, TextCompare: true) == 0))
						{
							structureRI = UPr1fCeWHt[i];
							break;
						}
					}
					if (Information.UBound(structureRI.Bornes) == 0)
					{
						return;
					}
					double num2 = RH.LarguraBase - Jah1LWHafV.margemDireita;
					int num3 = 0;
					int num4 = 0;
					bool bInsereNomeRegua = false;
					double num5 = RH.Pti.Y - 3.0 - RH.AltBase;
					Point3d val = new Point3d(RH.Pti.X + Jah1LWHafV.margemEsquerda, RH.AltBase + num5 - Jah1LWHafV.margemCima - 10.0, 0.0);
					Point3d val2 = new Point3d(RH.Pti.X + Jah1LWHafV.margemEsquerda, RH.AltBase + num5 / 2.0 - Jah1LWHafV.margemCima - 10.0, 0.0);
					Point3d val3 = new Point3d(RH.Pti.X + Jah1LWHafV.margemEsquerda, RH.AltBase + num5 / 2.0 - 10.0, 0.0);
					Point3d ptIns = default;
					if (!rb1.Checked)
					{
						if (!rb2.Checked)
						{
							if (rbC.Checked)
							{
								ptIns = val3;
								num4 = 2;
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
					if (Jah1LWHafV.tipo == 9)
					{
						ptIns = clsBlocos.retornaUmPonto();
					}
					List<string> lBornes = new List<string>();
					Point3d pt = default;
					if (clsDInterlig.reguaExiste(cPf16AVMSm, text, text2))
					{
						DeclaracoesInterligacao.PosborneDInterlig ubn = default;
						if (!clsDInterlig.BuscaUltimoBorne(cPf16AVMSm, text, text2, ref ubn, ref lBornes))
						{
							return;
						}
						Pagina.AtivaPagina(ubn.Pagina);
						num4 = ubn.Posicao;
						num3 = ((structureRI.Bornes[1].TipoBorne == 0) ? ((int)Math.Round(Jah1LWHafV.larguraBorne)) : ((int)Math.Round(Jah1LWHafV.larguraBorne * 2.0)));
						ptIns = new Point3d(ubn.PtIns.X + (double)num3, ubn.PtIns.Y, 0.0);
					}
					else if (Jah1LWHafV.tipo != 9 && clsDInterlig.outraReguaExiste(DeclaracoesGeral.ativo.Pagina, ref pt, num4))
					{
						ptIns = new Point3d(pt.X + Jah1LWHafV.distEntreReguas, pt.Y, 0.0);
						if (ptIns.X > num2)
						{
							return;
						}
						bInsereNomeRegua = true;
					}
					int num6 = Information.UBound(structureRI.Bornes);
					int num7 = 1;
					while (true)
					{
						if (num7 <= num6)
						{
							if (!lBornes.Contains(structureRI.Bornes[num7].Borne))
							{
								if (ptIns.X != val.X && !((ptIns.X > val.X) & (ptIns.X < num2)) && ptIns.X >= num2 - 12.0)
								{
									bInsereNomeRegua = true;
									if (!(!Jah1LWHafV.bUsa2LinhasBornes | (Jah1LWHafV.bUsa2LinhasBornes & (num4 == 2))))
									{
										num4 = 2;
									}
									else
									{
										if (Jah1LWHafV.bUsa2LinhasBornes)
										{
											num4 = 1;
										}
										string text3 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
										if (Operators.CompareString(text3, "", TextCompare: true) != 0)
										{
											Pagina.AtivaPagina(text3);
										}
										else if (!Pagina.criarUmaNovaPagina())
										{
											goto IL_0687;
										}
										if (rbC.Checked)
										{
											num4 = 2;
										}
									}
									if (num4 == 1)
									{
										ptIns = val;
									}
									else if (num4 == 2)
									{
										ptIns = val2;
										if (rbC.Checked)
										{
											ptIns = val3;
										}
									}
								}
								DeclaracoesInterligacao.borneAranha bn = new DeclaracoesInterligacao.borneAranha
								{
									Revisao = y8h1vRRdNP,
									Painel = cPf16AVMSm,
									Tag = text,
									NRegua = text2,
									Borne = structureRI.Bornes[num7].Borne,
									TipoBorne = structureRI.Bornes[num7].TipoBorne,
									Ordem = structureRI.Bornes[num7].Ordem,
									Posicao = num4
								};
								string text4 = "";
								if (bn.TipoBorne != 0)
								{
									text4 = "BorneDuplo1.DWG";
									if (num7 == Information.UBound(structureRI.Bornes))
									{
										text4 = "BorneDuplo1F.DWG";
									}
								}
								else
								{
									text4 = "BorneSimples1.DWG";
									if (num7 == Information.UBound(structureRI.Bornes))
									{
										text4 = "BorneSimples1F.DWG";
									}
								}
								if (!File.Exists(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + Jah1LWHafV.diretorio + text4))
								{
									break;
								}
								if (num7 == 1)
								{
									bInsereNomeRegua = true;
								}
								clsDInterlig.InserirBorneDInterlig(text4, bn, ptIns, bInsereNomeRegua, ref Jah1LWHafV);
								bInsereNomeRegua = false;
								if (bn.TipoBorne != 0)
								{
									if (bn.TipoBorne == 1)
									{
										num3 = (int)Math.Round(Jah1LWHafV.larguraBorne * 2.0);
									}
								}
								else
								{
									num3 = (int)Math.Round(Jah1LWHafV.larguraBorne);
								}
								ptIns = new Point3d(ptIns.X + (double)num3, ptIns.Y, 0.0);
							}
							num7++;
							continue;
						}
						goto IL_0687;
						IL_0687:
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
				whA3z7bYZc();
				Application.UpdateScreen();
			}
		}
	}

	private void psFnTm7ygg(object P_0, EventArgs P_1)
	{
		string tag = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
		string nRegua = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
		clsDInterlig.ApagaRegua(y8h1vRRdNP, cPf16AVMSm, tag, nRegua);
		whA3z7bYZc();
		Application.UpdateScreen();
	}

	private void dnQnJbZWrn(object P_0, EventArgs P_1)
	{
		string rev = "";
		int painel = 0;
		checked
		{
			if (clsDInterlig.SelecionaBorne(ref rev, ref painel))
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

	private void TH9nhCGnx2(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.jumper[] mJumpers = new DeclaracoesInterligacao.jumper[1];
		if (!clsDInterlig.carregaBornesJ(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref Jah1LWHafV.bJumperCima, ref Jah1LWHafV))
		{
			return;
		}
		clsDInterlig.buscaJumpers(ref mBornesJ, ref mJumpers, ref UPr1fCeWHt);
		clsDInterlig.ApagaJumper(y8h1vRRdNP, cPf16AVMSm);
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
					clsDInterlig.desenhaJumper2(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref mJumpers, i, ref Jah1LWHafV);
				}
			}
			else
			{
				clsDInterlig.desenhaJumper1(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref mJumpers, i, ref Jah1LWHafV);
			}
		}
		Application.UpdateScreen();
	}

	private void IA5novE6EC(object P_0, EventArgs P_1)
	{
		clsDInterlig.ApagaJumper(y8h1vRRdNP, cPf16AVMSm);
		Application.UpdateScreen();
	}

	private void O6HnGfAohl(object P_0, EventArgs P_1)
	{
		switch (orN1wKRAnJ)
		{
		case 3:
		case 5:
		case 8:
		case 9:
		case 11:
			clsDInterlig.EspelhaJumper(2);
			break;
		case 1:
		case 6:
		case 7:
		case 10:
			clsDInterlig.EspelhaJumper(1);
			break;
		}
		Application.UpdateScreen();
	}

	private void vljnHcJLhi(object P_0, EventArgs P_1)
	{
		formataDGCima();
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		List<string> lPaineis = new List<string>();
		if (!clsDInterlig.carregaBornesJ(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref Jah1LWHafV.bJumperCima, ref Jah1LWHafV))
		{
			return;
		}
		clsDInterlig.CarregaEquipamentosReguaCentral(ref UPr1fCeWHt, ref mBornesJ, ref lPaineis);
		lPaineis.Sort();
		if (lPaineis.Count <= 0)
		{
			return;
		}
		foreach (string item in lPaineis)
		{
			dgUp.Rows.Add(item);
		}
	}

	private void ElankG2GUF(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		DeclaracoesInterligacao.caboAranha[] mOutrosCabos = new DeclaracoesInterligacao.caboAranha[1];
		DeclaracoesInterligacao.caboAranha[] mCabosRebatidos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		List<string> lCabosPagina = new List<string>();
		DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias = new DeclaracoesInterligacao.cruzamentoCaboAranha[1];
		DeclaracoesInterligacao.AltPagUsada[] mAltPag = new DeclaracoesInterligacao.AltPagUsada[1];
		Jah1LWHafV.alturaFonteVeia = Conversions.ToDouble(tbVeia.Text);
		Jah1LWHafV.alturaFonteCruzamento = Conversions.ToDouble(tbCruzamento.Text);
		Jah1LWHafV.alturaFonteReservas = Conversions.ToDouble(tbReserva.Text);
		string revisao = y8h1vRRdNP;
		int painel = cPf16AVMSm;
		bool bJumperCima = false;
		if (clsDInterlig.carregaBornesJ(revisao, painel, ref mBornesJ, ref bJumperCima, ref Jah1LWHafV))
		{
			clsDInterlig.carregaCabosInseridosViaVeias(y8h1vRRdNP, cPf16AVMSm, ref lCabosInseridos);
			clsDInterlig.carregaCabosInseridosPagina(y8h1vRRdNP, cPf16AVMSm, ref lCabosInseridos, ref lCabosPagina);
			clsDInterlig.carregaOutrosCabosDWG(y8h1vRRdNP, cPf16AVMSm, ref mOutrosCabos, lCabosPagina);
			clsDInterlig.carregaCabosDWG(y8h1vRRdNP, cPf16AVMSm, ref mCabos);
			clsDInterlig.ProcuraEditaCabosRebater(y8h1vRRdNP, cPf16AVMSm, ref mCabos, ref mOutrosCabos, ref mCabosRebatidos, lCabosPagina);
			clsDInterlig.SubstituiBlocoOutrosCabos(y8h1vRRdNP, cPf16AVMSm, ref mCabosRebatidos, ref mOutrosCabos, ref Jah1LWHafV, lCabosPagina);
			clsDInterlig.relacionaCabosBornes(cPf16AVMSm, ref UPr1fCeWHt, ref mBornesJ, ref mCabosRebatidos);
			clsDInterlig.RebaterCabos(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref mCabosRebatidos, ref mInfoVeias, lCabosInseridos, ref Jah1LWHafV, ref mAltPag);
			Application.UpdateScreen();
		}
	}

	private void YB0ndcG9Ox(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		List<string> list = new List<string>();
		string revisao = y8h1vRRdNP;
		int painel = cPf16AVMSm;
		bool bJumperCima = false;
		if (!clsDInterlig.carregaBornesJ(revisao, painel, ref mBornesJ, ref bJumperCima, ref Jah1LWHafV))
		{
			return;
		}
		checked
		{
			if (dgUp.Rows.Count > 0)
			{
				int num = dgUp.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					list.Add(Conversions.ToString(dgUp.Rows[i].Cells[0].Value));
				}
			}
			clsDInterlig.carregaCabosInseridos(y8h1vRRdNP, cPf16AVMSm, ref lCabosInseridos);
			clsDInterlig.carregaCabos(y8h1vRRdNP, ref UPr1fCeWHt, ref mBornesJ, ref mCabos, list, ref Jah1LWHafV);
			clsDInterlig.insereCabos(y8h1vRRdNP, cPf16AVMSm, ref mCabos, lCabosInseridos, ref Jah1LWHafV);
			Application.UpdateScreen();
		}
	}

	private void UvGnfh5Mel(object P_0, EventArgs P_1)
	{
		clsDInterlig.ApagaCabos(y8h1vRRdNP, cPf16AVMSm);
		clsDInterlig.ApagaVeias(y8h1vRRdNP, cPf16AVMSm);
		Application.UpdateScreen();
	}

	private void v6MnDD7fAQ(object P_0, EventArgs P_1)
	{
		btVeias.Enabled = false;
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias = new DeclaracoesInterligacao.cruzamentoCaboAranha[1];
		DeclaracoesInterligacao.AltPagUsada[] mAltPag = new DeclaracoesInterligacao.AltPagUsada[1];
		Jah1LWHafV.alturaFonteVeia = Conversions.ToDouble(tbVeia.Text);
		Jah1LWHafV.alturaFonteCruzamento = Conversions.ToDouble(tbCruzamento.Text);
		Jah1LWHafV.alturaFonteReservas = Conversions.ToDouble(tbReserva.Text);
		string revisao = y8h1vRRdNP;
		int painel = cPf16AVMSm;
		bool bJumperCima = false;
		if (clsDInterlig.carregaBornesJ(revisao, painel, ref mBornesJ, ref bJumperCima, ref Jah1LWHafV))
		{
			clsDInterlig.AtualizaBornesJ(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ);
			clsDInterlig.carregaCabosInseridosViaVeias(y8h1vRRdNP, cPf16AVMSm, ref lCabosInseridos);
			clsDInterlig.carregaCabosDWG(y8h1vRRdNP, cPf16AVMSm, ref mCabos);
			clsDInterlig.relacionaCabosBornes(cPf16AVMSm, ref UPr1fCeWHt, ref mBornesJ, ref mCabos);
			clsDInterlig.verificaErro(mCabos);
			clsDInterlig.insereVeias(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos, ref Jah1LWHafV, ref mAltPag);
			if ((Jah1LWHafV.tipo == 0) | (Jah1LWHafV.tipo == 2) | (Jah1LWHafV.tipo == 4) | (Jah1LWHafV.tipo == 5) | (Jah1LWHafV.tipo == 6) | (Jah1LWHafV.tipo == 7) | (Jah1LWHafV.tipo == 8) | (Jah1LWHafV.tipo == 9) | (Jah1LWHafV.tipo == 10))
			{
				clsDInterlig.insereVeiasInv(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos, ref Jah1LWHafV, ref mAltPag);
			}
			clsDInterlig.insereVeias2(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos, ref Jah1LWHafV, ref mAltPag);
			if ((Jah1LWHafV.tipo == 0) | (Jah1LWHafV.tipo == 2) | (Jah1LWHafV.tipo == 4) | (Jah1LWHafV.tipo == 5) | (Jah1LWHafV.tipo == 6) | (Jah1LWHafV.tipo == 7) | (Jah1LWHafV.tipo == 8) | (Jah1LWHafV.tipo == 9) | (Jah1LWHafV.tipo == 10))
			{
				clsDInterlig.insereVeias2Inv(y8h1vRRdNP, cPf16AVMSm, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos, ref Jah1LWHafV, ref mAltPag);
			}
			Application.UpdateScreen();
		}
		btVeias.Enabled = true;
	}

	private void Tevnv6j203(object P_0, EventArgs P_1)
	{
		clsDInterlig.ApagaVeias(y8h1vRRdNP, cPf16AVMSm);
		Application.UpdateScreen();
	}

	private void GUWn6ju7xG(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.caboSync[] mCabosSync = new DeclaracoesInterligacao.caboSync[1];
		DeclaracoesInterligacao.caboSync[] mTodosCabosSync = new DeclaracoesInterligacao.caboSync[1];
		cDadosAccess.carregaDadosDWG();
		clsDInterlig.carregaTodosCabosDWG(y8h1vRRdNP, ref mCabosSync);
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
		cDadosAccessInterligacao3.ApagaCabosRevPn(y8h1vRRdNP, ref lPn);
		cDadosAccessInterligacao3.exportaCabos(y8h1vRRdNP, ref mCabosSync);
		cDadosAccessInterligacao3.leCabos(y8h1vRRdNP, ref mTodosCabosSync);
		clsDInterlig.LimpaCruzamentoCabos();
		clsDInterlig.SincronizaCabos(y8h1vRRdNP, mTodosCabosSync);
		cDadosAccessInterligacao3.fechaConexao();
		Application.UpdateScreen();
	}

	private void k4VntVc0xZ(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1899]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
			cDadosAtualizaBanco2.ApagaAranha4();
			cDadosAtualizaBanco2.fechaConexao();
		}
	}

	private void BUJnjX0brg(object P_0, EventArgs P_1)
	{
		if (rbCruz.Checked)
		{
			Jah1LWHafV.tipoCruzamento = 1;
		}
	}

	private void C1FnLWdlnw(object P_0, EventArgs P_1)
	{
		if (rbCruzCheg.Checked)
		{
			Jah1LWHafV.tipoCruzamento = 2;
		}
	}

	private void MKfnwnwu7X(object P_0, EventArgs P_1)
	{
		if (rbFuncao.Checked)
		{
			Jah1LWHafV.tipoCruzamento = 3;
		}
	}

	private void WBRnxP8rbQ(object P_0, EventArgs P_1)
	{
		CdgnbrQbmr();
	}

	private void CdgnbrQbmr()
	{
		if (!rbC.Checked)
		{
			btCima.Enabled = false;
			btMirrorJumper.Enabled = false;
		}
		else
		{
			btCima.Enabled = true;
			btMirrorJumper.Enabled = true;
		}
	}

	private void uudnMdBJ9Q()
	{
		if (orN1wKRAnJ != 1)
		{
			if (orN1wKRAnJ != 2)
			{
				if (orN1wKRAnJ != 3)
				{
					if (orN1wKRAnJ != 4)
					{
						if (orN1wKRAnJ != 5)
						{
							if (orN1wKRAnJ != 6)
							{
								if (orN1wKRAnJ != 7)
								{
									if (orN1wKRAnJ != 8)
									{
										if (orN1wKRAnJ != 9)
										{
											if (orN1wKRAnJ != 10)
											{
												if (orN1wKRAnJ == 11)
												{
													Jah1LWHafV.tipo = 10;
													Jah1LWHafV.bJumperCima = false;
													Jah1LWHafV.margemEsquerda = 20.0;
													Jah1LWHafV.margemDireita = 195.0;
													Jah1LWHafV.margemCima = 20.0;
													Jah1LWHafV.distEntreReguas = 36.0;
													Jah1LWHafV.distEntreVeias = 5.0;
													Jah1LWHafV.distEntreJumpers = 2.0;
													Jah1LWHafV.distInicialBorneCabo = 18.0;
													Jah1LWHafV.corHatch = 2;
													Jah1LWHafV.corJumper = 2;
													Jah1LWHafV.corTracoVeiasReservas = 7;
													Jah1LWHafV.corTextoVeiasReservas = 7;
													Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
													Jah1LWHafV.corVeias = 2;
													Jah1LWHafV.corTextoVeia = 7;
													Jah1LWHafV.anguloTextoVeia = 0.0;
													Jah1LWHafV.corTextoDestino = 7;
													Jah1LWHafV.anguloTextoDestino = 0.0;
													Jah1LWHafV.alturaInsercaoCabo = 150.0;
													Jah1LWHafV.corLinhaVCabo = 2;
													Jah1LWHafV.diretorio = "Interligação\\Itaipu\\";
													Jah1LWHafV.bUsa2LinhasBornes = true;
													Jah1LWHafV.alturaFonteVeia = 1.5;
													Jah1LWHafV.alturaFonteCruzamento = 1.5;
													Jah1LWHafV.alturaFonteReservas = 2.0;
													Jah1LWHafV.raioHatch = 0.3;
													Jah1LWHafV.larguraBorne = 6.0;
													Jah1LWHafV.textStyle = "Romans";
												}
											}
											else
											{
												Jah1LWHafV.tipo = 9;
												Jah1LWHafV.bJumperCima = true;
												Jah1LWHafV.margemEsquerda = 20.0;
												Jah1LWHafV.margemDireita = 20.0;
												Jah1LWHafV.margemCima = 9.0;
												Jah1LWHafV.distEntreReguas = 36.0;
												Jah1LWHafV.distEntreVeias = 5.0;
												Jah1LWHafV.distEntreJumpers = 2.0;
												Jah1LWHafV.distInicialBorneCabo = 18.0;
												Jah1LWHafV.corHatch = 7;
												Jah1LWHafV.corJumper = 7;
												Jah1LWHafV.corTracoVeiasReservas = 7;
												Jah1LWHafV.corTextoVeiasReservas = 7;
												Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
												Jah1LWHafV.corVeias = 7;
												Jah1LWHafV.corTextoVeia = 7;
												Jah1LWHafV.anguloTextoVeia = 0.0;
												Jah1LWHafV.corTextoDestino = 7;
												Jah1LWHafV.anguloTextoDestino = 0.0;
												Jah1LWHafV.alturaInsercaoCabo = 80.0;
												Jah1LWHafV.corLinhaVCabo = 7;
												Jah1LWHafV.diretorio = "Interligação\\ENEL-SP\\";
												Jah1LWHafV.bUsa2LinhasBornes = true;
												Jah1LWHafV.alturaFonteVeia = 1.2;
												Jah1LWHafV.alturaFonteCruzamento = 1.2;
												Jah1LWHafV.alturaFonteReservas = 1.2;
												Jah1LWHafV.raioHatch = 0.7;
												Jah1LWHafV.larguraBorne = 6.0;
												Jah1LWHafV.textStyle = "Romans";
											}
										}
										else
										{
											Jah1LWHafV.tipo = 8;
											Jah1LWHafV.bJumperCima = false;
											Jah1LWHafV.margemEsquerda = 20.0;
											Jah1LWHafV.margemDireita = 20.0;
											Jah1LWHafV.margemCima = 40.0;
											Jah1LWHafV.distEntreReguas = 36.0;
											Jah1LWHafV.distEntreVeias = 5.0;
											Jah1LWHafV.distEntreJumpers = 2.0;
											Jah1LWHafV.distInicialBorneCabo = 18.0;
											Jah1LWHafV.corHatch = 7;
											Jah1LWHafV.corJumper = 7;
											Jah1LWHafV.corTracoVeiasReservas = 7;
											Jah1LWHafV.corTextoVeiasReservas = 7;
											Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
											Jah1LWHafV.corVeias = 7;
											Jah1LWHafV.corTextoVeia = 7;
											Jah1LWHafV.anguloTextoVeia = 0.0;
											Jah1LWHafV.corTextoDestino = 7;
											Jah1LWHafV.anguloTextoDestino = 0.0;
											Jah1LWHafV.alturaInsercaoCabo = 120.0;
											Jah1LWHafV.corLinhaVCabo = 7;
											Jah1LWHafV.diretorio = "Interligação\\Cemig-GT-PN\\";
											Jah1LWHafV.bUsa2LinhasBornes = true;
											Jah1LWHafV.alturaFonteVeia = 2.0;
											Jah1LWHafV.alturaFonteCruzamento = 2.0;
											Jah1LWHafV.alturaFonteReservas = 1.2;
											Jah1LWHafV.raioHatch = 0.7;
											Jah1LWHafV.larguraBorne = 8.0;
											Jah1LWHafV.textStyle = "INTL_ISO";
										}
									}
									else
									{
										Jah1LWHafV.tipo = 7;
										Jah1LWHafV.bJumperCima = false;
										Jah1LWHafV.margemEsquerda = 20.0;
										Jah1LWHafV.margemDireita = 20.0;
										Jah1LWHafV.margemCima = 9.0;
										Jah1LWHafV.distEntreReguas = 36.0;
										Jah1LWHafV.distEntreVeias = 5.0;
										Jah1LWHafV.distEntreJumpers = 2.0;
										Jah1LWHafV.distInicialBorneCabo = 18.0;
										Jah1LWHafV.corHatch = 2;
										Jah1LWHafV.corJumper = 2;
										Jah1LWHafV.corTracoVeiasReservas = 2;
										Jah1LWHafV.corTextoVeiasReservas = 7;
										Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
										Jah1LWHafV.corVeias = 2;
										Jah1LWHafV.corTextoVeia = 7;
										Jah1LWHafV.anguloTextoVeia = 0.0;
										Jah1LWHafV.corTextoDestino = 7;
										Jah1LWHafV.anguloTextoDestino = 0.0;
										Jah1LWHafV.alturaInsercaoCabo = 70.0;
										Jah1LWHafV.corLinhaVCabo = 2;
										Jah1LWHafV.diretorio = "Interligação\\Furnas\\";
										Jah1LWHafV.bUsa2LinhasBornes = true;
										Jah1LWHafV.alturaFonteVeia = 1.2;
										Jah1LWHafV.alturaFonteCruzamento = 1.2;
										Jah1LWHafV.alturaFonteReservas = 1.2;
										Jah1LWHafV.raioHatch = 0.7;
										Jah1LWHafV.larguraBorne = 6.0;
										Jah1LWHafV.textStyle = "Romans";
									}
								}
								else
								{
									Jah1LWHafV.tipo = 6;
									Jah1LWHafV.bJumperCima = true;
									Jah1LWHafV.margemEsquerda = 20.0;
									Jah1LWHafV.margemDireita = 20.0;
									Jah1LWHafV.margemCima = 50.0;
									Jah1LWHafV.distEntreReguas = 36.0;
									Jah1LWHafV.distEntreVeias = 5.0;
									Jah1LWHafV.distEntreJumpers = 2.0;
									Jah1LWHafV.distInicialBorneCabo = 18.0;
									Jah1LWHafV.corHatch = 7;
									Jah1LWHafV.corJumper = 7;
									Jah1LWHafV.corTracoVeiasReservas = 7;
									Jah1LWHafV.corTextoVeiasReservas = 7;
									Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
									Jah1LWHafV.corVeias = 7;
									Jah1LWHafV.corTextoVeia = 7;
									Jah1LWHafV.anguloTextoVeia = 0.0;
									Jah1LWHafV.corTextoDestino = 7;
									Jah1LWHafV.anguloTextoDestino = 0.0;
									Jah1LWHafV.alturaInsercaoCabo = 30.0;
									Jah1LWHafV.corLinhaVCabo = 7;
									Jah1LWHafV.diretorio = "Interligação\\Taesa\\";
									Jah1LWHafV.bUsa2LinhasBornes = false;
									Jah1LWHafV.alturaFonteVeia = 1.2;
									Jah1LWHafV.alturaFonteCruzamento = 1.5;
									Jah1LWHafV.alturaFonteReservas = 1.2;
									Jah1LWHafV.raioHatch = 0.5;
									Jah1LWHafV.larguraBorne = 6.0;
									Jah1LWHafV.textStyle = "Romans";
								}
							}
							else
							{
								Jah1LWHafV.tipo = 5;
								Jah1LWHafV.bJumperCima = true;
								Jah1LWHafV.margemEsquerda = 20.0;
								Jah1LWHafV.margemDireita = 20.0;
								Jah1LWHafV.margemCima = 50.0;
								Jah1LWHafV.distEntreReguas = 36.0;
								Jah1LWHafV.distEntreVeias = 5.0;
								Jah1LWHafV.distEntreJumpers = 2.0;
								Jah1LWHafV.distInicialBorneCabo = 18.0;
								Jah1LWHafV.corHatch = 7;
								Jah1LWHafV.corJumper = 7;
								Jah1LWHafV.corTracoVeiasReservas = 7;
								Jah1LWHafV.corTextoVeiasReservas = 7;
								Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
								Jah1LWHafV.corVeias = 7;
								Jah1LWHafV.corTextoVeia = 7;
								Jah1LWHafV.anguloTextoVeia = 0.0;
								Jah1LWHafV.corTextoDestino = 7;
								Jah1LWHafV.anguloTextoDestino = 0.0;
								Jah1LWHafV.alturaInsercaoCabo = 30.0;
								Jah1LWHafV.corLinhaVCabo = 7;
								Jah1LWHafV.diretorio = "Interligação\\EDPES\\";
								Jah1LWHafV.bUsa2LinhasBornes = false;
								Jah1LWHafV.alturaFonteVeia = 1.2;
								Jah1LWHafV.alturaFonteCruzamento = 1.5;
								Jah1LWHafV.alturaFonteReservas = 1.2;
								Jah1LWHafV.raioHatch = 0.5;
								Jah1LWHafV.larguraBorne = 6.0;
								Jah1LWHafV.textStyle = "Romans";
							}
						}
						else
						{
							Jah1LWHafV.tipo = 4;
							Jah1LWHafV.bJumperCima = false;
							Jah1LWHafV.margemEsquerda = 20.0;
							Jah1LWHafV.margemDireita = 20.0;
							Jah1LWHafV.margemCima = 9.0;
							Jah1LWHafV.distEntreReguas = 36.0;
							Jah1LWHafV.distEntreVeias = 5.0;
							Jah1LWHafV.distEntreJumpers = 2.0;
							Jah1LWHafV.distInicialBorneCabo = 18.0;
							Jah1LWHafV.corHatch = 2;
							Jah1LWHafV.corJumper = 2;
							Jah1LWHafV.corTracoVeiasReservas = 2;
							Jah1LWHafV.corTextoVeiasReservas = 7;
							Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
							Jah1LWHafV.corVeias = 2;
							Jah1LWHafV.corTextoVeia = 7;
							Jah1LWHafV.anguloTextoVeia = 0.0;
							Jah1LWHafV.corTextoDestino = 7;
							Jah1LWHafV.anguloTextoDestino = 0.0;
							Jah1LWHafV.alturaInsercaoCabo = 70.0;
							Jah1LWHafV.corLinhaVCabo = 2;
							Jah1LWHafV.diretorio = "Interligação\\CPFL-TR\\";
							Jah1LWHafV.bUsa2LinhasBornes = true;
							Jah1LWHafV.alturaFonteVeia = 1.2;
							Jah1LWHafV.alturaFonteCruzamento = 1.2;
							Jah1LWHafV.alturaFonteReservas = 1.2;
							Jah1LWHafV.raioHatch = 0.7;
							Jah1LWHafV.larguraBorne = 6.0;
							Jah1LWHafV.textStyle = "Romans";
						}
					}
					else
					{
						Jah1LWHafV.tipo = 3;
						Jah1LWHafV.bJumperCima = true;
						Jah1LWHafV.margemEsquerda = 10.0;
						Jah1LWHafV.margemDireita = 10.0;
						Jah1LWHafV.margemCima = 47.0;
						Jah1LWHafV.distEntreReguas = 24.0;
						Jah1LWHafV.distEntreVeias = 5.0;
						Jah1LWHafV.distEntreJumpers = 2.5;
						Jah1LWHafV.distInicialBorneCabo = 12.0;
						Jah1LWHafV.corHatch = 7;
						Jah1LWHafV.corJumper = 7;
						Jah1LWHafV.corTracoVeiasReservas = 7;
						Jah1LWHafV.corTextoVeiasReservas = 7;
						Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
						Jah1LWHafV.corVeias = 7;
						Jah1LWHafV.corTextoVeia = 7;
						Jah1LWHafV.anguloTextoVeia = 0.0;
						Jah1LWHafV.corTextoDestino = 7;
						Jah1LWHafV.anguloTextoDestino = 0.0;
						Jah1LWHafV.alturaInsercaoCabo = -63.6;
						Jah1LWHafV.corLinhaVCabo = 7;
						Jah1LWHafV.diretorio = "Interligação\\Equatorial\\";
						Jah1LWHafV.bUsa2LinhasBornes = false;
						Jah1LWHafV.alturaFonteVeia = 1.2;
						Jah1LWHafV.alturaFonteCruzamento = 1.5;
						Jah1LWHafV.alturaFonteReservas = 1.5;
						Jah1LWHafV.raioHatch = 0.4;
						Jah1LWHafV.larguraBorne = 6.0;
						Jah1LWHafV.textStyle = "Romans";
					}
				}
				else
				{
					Jah1LWHafV.tipo = 2;
					Jah1LWHafV.bJumperCima = false;
					Jah1LWHafV.margemEsquerda = 20.0;
					Jah1LWHafV.margemDireita = 20.0;
					Jah1LWHafV.margemCima = 9.0;
					Jah1LWHafV.distEntreReguas = 36.0;
					Jah1LWHafV.distEntreVeias = 5.0;
					Jah1LWHafV.distEntreJumpers = 2.0;
					Jah1LWHafV.distInicialBorneCabo = 18.0;
					Jah1LWHafV.corHatch = 2;
					Jah1LWHafV.corJumper = 2;
					Jah1LWHafV.corTracoVeiasReservas = 2;
					Jah1LWHafV.corTextoVeiasReservas = 1;
					Jah1LWHafV.anguloTextoVeiasReservas = Math.PI / 12.0;
					Jah1LWHafV.corVeias = 2;
					Jah1LWHafV.corTextoVeia = 1;
					Jah1LWHafV.anguloTextoVeia = Math.PI / 12.0;
					Jah1LWHafV.corTextoDestino = 2;
					Jah1LWHafV.anguloTextoDestino = Math.PI / 12.0;
					Jah1LWHafV.alturaInsercaoCabo = 70.0;
					Jah1LWHafV.corLinhaVCabo = 4;
					Jah1LWHafV.diretorio = "Interligação\\CTEEP\\";
					Jah1LWHafV.bUsa2LinhasBornes = true;
					Jah1LWHafV.alturaFonteVeia = 1.2;
					Jah1LWHafV.alturaFonteCruzamento = 1.5;
					Jah1LWHafV.alturaFonteReservas = 1.2;
					Jah1LWHafV.raioHatch = 0.4;
					Jah1LWHafV.larguraBorne = 6.0;
					Jah1LWHafV.textStyle = "Romans";
				}
			}
			else
			{
				Jah1LWHafV.tipo = 1;
				Jah1LWHafV.tipoCruzamento = 2;
				Jah1LWHafV.bJumperCima = false;
				Jah1LWHafV.margemEsquerda = 20.0;
				Jah1LWHafV.margemDireita = 20.0;
				Jah1LWHafV.margemCima = 14.0;
				Jah1LWHafV.distEntreReguas = 36.0;
				Jah1LWHafV.distEntreVeias = 5.0;
				Jah1LWHafV.distEntreJumpers = 2.0;
				Jah1LWHafV.distInicialBorneCabo = 18.0;
				Jah1LWHafV.corHatch = 7;
				Jah1LWHafV.corJumper = 7;
				Jah1LWHafV.corTracoVeiasReservas = 7;
				Jah1LWHafV.corTextoVeiasReservas = 7;
				Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
				Jah1LWHafV.corVeias = 7;
				Jah1LWHafV.corTextoVeia = 1;
				Jah1LWHafV.anguloTextoVeia = Math.PI / 12.0;
				Jah1LWHafV.corTextoDestino = 3;
				Jah1LWHafV.anguloTextoDestino = Math.PI / 12.0;
				Jah1LWHafV.alturaInsercaoCabo = 55.0;
				Jah1LWHafV.diretorio = "Interligação\\CPFL\\";
				Jah1LWHafV.bUsa2LinhasBornes = false;
				Jah1LWHafV.alturaFonteVeia = 1.2;
				Jah1LWHafV.alturaFonteCruzamento = 1.5;
				Jah1LWHafV.alturaFonteReservas = 1.2;
				Jah1LWHafV.raioHatch = 0.4;
				Jah1LWHafV.larguraBorne = 6.0;
				Jah1LWHafV.textStyle = "Romans";
			}
		}
		else
		{
			Jah1LWHafV.tipo = 0;
			Jah1LWHafV.bJumperCima = true;
			Jah1LWHafV.margemEsquerda = 20.0;
			Jah1LWHafV.margemDireita = 20.0;
			Jah1LWHafV.margemCima = 20.0;
			Jah1LWHafV.distEntreReguas = 24.0;
			Jah1LWHafV.distEntreVeias = 3.0;
			Jah1LWHafV.distEntreJumpers = 2.5;
			Jah1LWHafV.distInicialBorneCabo = 12.0;
			Jah1LWHafV.corHatch = 7;
			Jah1LWHafV.corJumper = 7;
			Jah1LWHafV.corTracoVeiasReservas = 7;
			Jah1LWHafV.corTextoVeiasReservas = 7;
			Jah1LWHafV.anguloTextoVeiasReservas = 0.0;
			Jah1LWHafV.corVeias = 7;
			Jah1LWHafV.corTextoVeia = 7;
			Jah1LWHafV.anguloTextoVeia = 0.0;
			Jah1LWHafV.corTextoDestino = 7;
			Jah1LWHafV.anguloTextoDestino = 0.0;
			Jah1LWHafV.alturaInsercaoCabo = 55.0;
			Jah1LWHafV.corLinhaVCabo = 7;
			Jah1LWHafV.diretorio = "Interligação\\Chesf\\";
			Jah1LWHafV.bUsa2LinhasBornes = true;
			Jah1LWHafV.alturaFonteVeia = 1.2;
			Jah1LWHafV.alturaFonteCruzamento = 1.5;
			Jah1LWHafV.alturaFonteReservas = 1.2;
			Jah1LWHafV.raioHatch = 0.4;
			Jah1LWHafV.larguraBorne = 6.0;
			Jah1LWHafV.textStyle = "Romans";
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
				MDw1jLafTK = true;
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
				MDw1jLafTK = false;
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

	public void formataDGCima()
	{
		checked
		{
			try
			{
				dgUp.Rows.Clear();
				dgUp.Columns.Clear();
				dgUp.Columns.Add("", "Nome");
				float num = dgUp.Width - 22;
				dgUp.Columns[0].Width = (int)Math.Round(num);
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

	private void v3anO0nRXY(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void jTxnIhDaoh(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void RE7n7A7Og9(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}
}
