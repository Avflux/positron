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
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmGerenciadorReguasBornes : Form
{
	public struct StructureRegua
	{
		public string sPainel;

		public int iPainel;

		public string sReguaA;

		public int iRegua;
	}

	public struct structureDadosFiacao
	{
		public long Potencial;

		public string Handle;
	}

	public struct structureTipoPotencial
	{
		public long Potencial;

		public string Tipo;
	}

	public struct structureDadosInterligacao
	{
		public string Cabo;

		public int Veia;

		public string Handle;
	}

	private IContainer CVNpJJxZ6pl;

	[CompilerGenerated]
	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog worpJhPHKWw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip XO3pJoEgxYt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBorneSimples")]
	private Button dA0pJGUDdNa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBorneDuplo")]
	private Button wFlpJH4JcFU;

	[CompilerGenerated]
	[AccessedThroughProperty("CBMigraRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox KXgpJkjGPyP;

	[AccessedThroughProperty("btMigrarBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button yAFpJdwRXUw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgReguas")]
	private DataGridView QRbpJfJ3uny;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAtribuiLM")]
	[CompilerGenerated]
	private Button mippJDOd0AE;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox Dp1pJvS0uad;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornes")]
	private DataGridView WZupJ6UIoYS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox yFZpJtovCQr;

	[AccessedThroughProperty("RB_Todos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton QRlpJjlfFwr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB_IndefinidosFinal")]
	private RadioButton mDjpJL6PFxj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtIndefinirBornesSel")]
	private Button GgKpJwsgUlQ;

	[CompilerGenerated]
	[AccessedThroughProperty("BtNumerar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button VZhpJxRE9fe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	private GroupBox m6NpJb3CdmJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB_INT_PCV")]
	private RadioButton PBZpJMZfNxn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB_POT_CL")]
	private RadioButton xTLpJODQ7Vj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB_POT_LC")]
	private RadioButton ffPpJIaXl89;

	[AccessedThroughProperty("RB_PLC")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton DPspJ7V8do3;

	[AccessedThroughProperty("RB_PCL")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton nY5pJqEq3k4;

	[AccessedThroughProperty("btSalvar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button J9CpJatBvWE;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox qdopJ8Q378x;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKEdicaoMultiplas")]
	private CheckBox Q41pJN7K7Fc;

	[AccessedThroughProperty("GroupBox6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox qHMpJFHYvFx;

	[AccessedThroughProperty("btDiminuiRecuo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button VRcpJQSIOK7;

	[AccessedThroughProperty("btAumentaRecuo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button xXupJP2WIAZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbRecuo")]
	[CompilerGenerated]
	private TextBox AdCpJcsNM2s;

	[AccessedThroughProperty("LbFiltro")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label N4ApJK0SiET;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBPesquisa")]
	private TextBox n8GpJe77970;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox7")]
	private GroupBox FA4pJ2PVYZY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTExportaEXCEL")]
	private Button SAqpJ3Rd5jt;

	[AccessedThroughProperty("BTImportaEXCEL")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button XL7pJnhe2Vm;

	[AccessedThroughProperty("btOrdenarAZ")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button V47pJ1MS1Pi;

	[AccessedThroughProperty("btInsereReservaEntre")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button UN1pJlB66mD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB_PG_POT_CL")]
	[CompilerGenerated]
	private RadioButton HY6pJ5MeRyS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB_PG_POT_LC")]
	[CompilerGenerated]
	private RadioButton B8lpJ02h1m9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox8")]
	private GroupBox EoIpJRmS1fF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAtribuiOrientacao")]
	private Button T0QpJmEJ7oW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckSul")]
	private CheckBox X2hpJXccJYV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckNorte")]
	private CheckBox dCZpJUdeNkT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox9")]
	private GroupBox FkJpJyoN8OP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button pFNpJgkchxc;

	[AccessedThroughProperty("tbBlocoLayout")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox F2qpJADHrMg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecionaBlocoLayout")]
	private Button Q2ZpJsLuDTc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornesExtra")]
	private DataGridView dvIpJBoHSk2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox10")]
	private GroupBox Hp1pJV2hyWd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBExtras")]
	private TextBox o4ZpJuMdyPF;

	[CompilerGenerated]
	[AccessedThroughProperty("BTExtra")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button ysrpJEfBy2G;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btRomoveReservas")]
	private Button IM1pJZOn93l;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btUltimoChassi")]
	private Button MCHpJi3SWe1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPrimeiroChassi")]
	private Button SGjpJSBqk7v;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBaixoChassi")]
	private Button YjCpJ4CrX1J;

	[AccessedThroughProperty("btCimaChassi")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button E5YpJCTILCD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox11")]
	private GroupBox tnVpJYed9aX;

	[CompilerGenerated]
	[AccessedThroughProperty("BTLimpaGeral")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button vavpJronEfW;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox bRypJ9EMqJu;

	[CompilerGenerated]
	[AccessedThroughProperty("lbFabricante")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label F1epJzZ3reR;

	[AccessedThroughProperty("lbModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label D88phW4aDmJ;

	[AccessedThroughProperty("lbDesc")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label v2AphpwkuE1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbCodigo")]
	private Label VGJphTrRwYF;

	[AccessedThroughProperty("tbFabricante1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox PVYphJoOR1Y;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbModelo1")]
	private TextBox eOAphhrfN6l;

	[AccessedThroughProperty("tbDescricaoResum1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox O3Lphov80A8;

	[AccessedThroughProperty("tbCodigo1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox XHlphG3YQK4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisaLM1")]
	[CompilerGenerated]
	private Button HhqphH6rPKq;

	private string m8Qphkag17n;

	private StructureRegua pLxphdx8X8q;

	private StructureRegua[] qfQphfVBOau;

	private Declaracoes2.StructureModeloDeReguas[] GC6phD60Llo;

	private DeclaracoesEntidades.StructureBorne[] AuSphv29XNQ;

	private DeclaracoesEntidades.StructureBorne[] sCXph6C4lyQ;

	private structureDadosFiacao[] fJLphtEQVvs;

	private string QCXphjEHtXO;

	private string erCphL1d3Ee;

	private bool y0hphw4tbHT;

	private string udsphxagTYf;

	private int vfcphbxiZf6;

	private int AlOphM2M7b2;

	private int pcAphO3XWWQ;

	private bool hJ4phInBpLi;

	private DeclaracoesClonar.structureMaterial[] W4Qph7v7o0L;

	private bool Mh0phqkE313;

	private int Wt4phaMFEc0;

	private int Happh8ZEYMe;

	internal virtual Button btBorneSimples
	{
		[CompilerGenerated]
		get
		{
			return dA0pJGUDdNa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gQfpTbrII22;
			Button button = dA0pJGUDdNa;
			if (button != null)
			{
				button.Click -= value2;
			}
			dA0pJGUDdNa = value;
			button = dA0pJGUDdNa;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btBorneDuplo
	{
		[CompilerGenerated]
		get
		{
			return wFlpJH4JcFU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BbDpTMwAdf7;
			Button button = wFlpJH4JcFU;
			if (button != null)
			{
				button.Click -= value2;
			}
			wFlpJH4JcFU = value;
			button = wFlpJH4JcFU;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox CBMigraRegua
	{
		[CompilerGenerated]
		get
		{
			return KXgpJkjGPyP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kRSpTmk4W2a;
			ComboBox comboBox = KXgpJkjGPyP;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			KXgpJkjGPyP = value;
			comboBox = KXgpJkjGPyP;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Button btMigrarBornes
	{
		[CompilerGenerated]
		get
		{
			return yAFpJdwRXUw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ubUpT5W6NEm;
			Button button = yAFpJdwRXUw;
			if (button != null)
			{
				button.Click -= value2;
			}
			yAFpJdwRXUw = value;
			button = yAFpJdwRXUw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgReguas
	{
		[CompilerGenerated]
		get
		{
			return QRbpJfJ3uny;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zh8pTLEpWbP;
			DataGridView dataGridView = QRbpJfJ3uny;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			QRbpJfJ3uny = value;
			dataGridView = QRbpJfJ3uny;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btAtribuiLM
	{
		[CompilerGenerated]
		get
		{
			return mippJDOd0AE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kk7pTwmtH1d;
			Button button = mippJDOd0AE;
			if (button != null)
			{
				button.Click -= value2;
			}
			mippJDOd0AE = value;
			button = mippJDOd0AE;
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
			return Dp1pJvS0uad;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Dp1pJvS0uad = value;
		}
	}

	internal virtual DataGridView dgBornes
	{
		[CompilerGenerated]
		get
		{
			return WZupJ6UIoYS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = vdGpTcMrMZg;
			KeyEventHandler value3 = wjGpTKcuHAM;
			KeyEventHandler value4 = PhNpT3PkGtc;
			EventHandler value5 = oVFpTnIV4FU;
			DataGridViewCellEventHandler value6 = SVepTATWga2;
			MouseEventHandler value7 = UirpT9B4pOC;
			MouseEventHandler value8 = G7wpTz5J00s;
			DragEventHandler value9 = ItgpJWTpbpM;
			DragEventHandler value10 = APkpJpHtFfd;
			DataGridView dataGridView = WZupJ6UIoYS;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit -= value2;
				dataGridView.KeyDown -= value3;
				dataGridView.KeyUp -= value4;
				dataGridView.SelectionChanged -= value5;
				dataGridView.CellContentClick -= value6;
				dataGridView.MouseUp -= value7;
				dataGridView.MouseDown -= value8;
				dataGridView.DragEnter -= value9;
				dataGridView.DragDrop -= value10;
			}
			WZupJ6UIoYS = value;
			dataGridView = WZupJ6UIoYS;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit += value2;
				dataGridView.KeyDown += value3;
				dataGridView.KeyUp += value4;
				dataGridView.SelectionChanged += value5;
				dataGridView.CellContentClick += value6;
				dataGridView.MouseUp += value7;
				dataGridView.MouseDown += value8;
				dataGridView.DragEnter += value9;
				dataGridView.DragDrop += value10;
			}
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return yFZpJtovCQr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yFZpJtovCQr = value;
		}
	}

	internal virtual RadioButton RB_Todos
	{
		[CompilerGenerated]
		get
		{
			return QRlpJjlfFwr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QRlpJjlfFwr = value;
		}
	}

	internal virtual RadioButton RB_IndefinidosFinal
	{
		[CompilerGenerated]
		get
		{
			return mDjpJL6PFxj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sZWpTsyHti4;
			RadioButton radioButton = mDjpJL6PFxj;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			mDjpJL6PFxj = value;
			radioButton = mDjpJL6PFxj;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button BtIndefinirBornesSel
	{
		[CompilerGenerated]
		get
		{
			return GgKpJwsgUlQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wwipTOaTPTN;
			Button button = GgKpJwsgUlQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			GgKpJwsgUlQ = value;
			button = GgKpJwsgUlQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BtNumerar
	{
		[CompilerGenerated]
		get
		{
			return VZhpJxRE9fe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jFUpTQdR02S;
			Button button = VZhpJxRE9fe;
			if (button != null)
			{
				button.Click -= value2;
			}
			VZhpJxRE9fe = value;
			button = VZhpJxRE9fe;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return m6NpJb3CdmJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m6NpJb3CdmJ = value;
		}
	}

	internal virtual RadioButton RB_INT_PCV
	{
		[CompilerGenerated]
		get
		{
			return PBZpJMZfNxn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PBZpJMZfNxn = value;
		}
	}

	internal virtual RadioButton RB_POT_CL
	{
		[CompilerGenerated]
		get
		{
			return xTLpJODQ7Vj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xTLpJODQ7Vj = value;
		}
	}

	internal virtual RadioButton RB_POT_LC
	{
		[CompilerGenerated]
		get
		{
			return ffPpJIaXl89;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ffPpJIaXl89 = value;
		}
	}

	internal virtual RadioButton RB_PLC
	{
		[CompilerGenerated]
		get
		{
			return DPspJ7V8do3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DPspJ7V8do3 = value;
		}
	}

	internal virtual RadioButton RB_PCL
	{
		[CompilerGenerated]
		get
		{
			return nY5pJqEq3k4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nY5pJqEq3k4 = value;
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return J9CpJatBvWE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NeSpTPajwhg;
			Button button = J9CpJatBvWE;
			if (button != null)
			{
				button.Click -= value2;
			}
			J9CpJatBvWE = value;
			button = J9CpJatBvWE;
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
			return qdopJ8Q378x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qdopJ8Q378x = value;
		}
	}

	internal virtual CheckBox CKEdicaoMultiplas
	{
		[CompilerGenerated]
		get
		{
			return Q41pJN7K7Fc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VptpT0CHvT7;
			CheckBox checkBox = Q41pJN7K7Fc;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			Q41pJN7K7Fc = value;
			checkBox = Q41pJN7K7Fc;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return qHMpJFHYvFx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qHMpJFHYvFx = value;
		}
	}

	internal virtual Button btDiminuiRecuo
	{
		[CompilerGenerated]
		get
		{
			return VRcpJQSIOK7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qmxpTanao3n;
			Button button = VRcpJQSIOK7;
			if (button != null)
			{
				button.Click -= value2;
			}
			VRcpJQSIOK7 = value;
			button = VRcpJQSIOK7;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btAumentaRecuo
	{
		[CompilerGenerated]
		get
		{
			return xXupJP2WIAZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = baspTqYKYAj;
			Button button = xXupJP2WIAZ;
			if (button != null)
			{
				button.Click -= value2;
			}
			xXupJP2WIAZ = value;
			button = xXupJP2WIAZ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbRecuo
	{
		[CompilerGenerated]
		get
		{
			return AdCpJcsNM2s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = aplpTyiiAFx;
			KeyEventHandler value3 = I4QpTgUjgt7;
			TextBox textBox = AdCpJcsNM2s;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
				textBox.KeyUp -= value3;
			}
			AdCpJcsNM2s = value;
			textBox = AdCpJcsNM2s;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
				textBox.KeyUp += value3;
			}
		}
	}

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return N4ApJK0SiET;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			N4ApJK0SiET = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return n8GpJe77970;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = Mv6pTUcTHAV;
			TextBox textBox = n8GpJe77970;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			n8GpJe77970 = value;
			textBox = n8GpJe77970;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return FA4pJ2PVYZY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FA4pJ2PVYZY = value;
		}
	}

	internal virtual Button BTExportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return SAqpJ3Rd5jt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LnXpT86pnWd;
			Button button = SAqpJ3Rd5jt;
			if (button != null)
			{
				button.Click -= value2;
			}
			SAqpJ3Rd5jt = value;
			button = SAqpJ3Rd5jt;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTImportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return XL7pJnhe2Vm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sRypTNv2KVl;
			Button button = XL7pJnhe2Vm;
			if (button != null)
			{
				button.Click -= value2;
			}
			XL7pJnhe2Vm = value;
			button = XL7pJnhe2Vm;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btOrdenarAZ
	{
		[CompilerGenerated]
		get
		{
			return V47pJ1MS1Pi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = N13pTFnReVm;
			Button button = V47pJ1MS1Pi;
			if (button != null)
			{
				button.Click -= value2;
			}
			V47pJ1MS1Pi = value;
			button = V47pJ1MS1Pi;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btInsereReservaEntre
	{
		[CompilerGenerated]
		get
		{
			return UN1pJlB66mD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EAPpTIkm5Ev;
			Button button = UN1pJlB66mD;
			if (button != null)
			{
				button.Click -= value2;
			}
			UN1pJlB66mD = value;
			button = UN1pJlB66mD;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton RB_PG_POT_CL
	{
		[CompilerGenerated]
		get
		{
			return HY6pJ5MeRyS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HY6pJ5MeRyS = value;
		}
	}

	internal virtual RadioButton RB_PG_POT_LC
	{
		[CompilerGenerated]
		get
		{
			return B8lpJ02h1m9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			B8lpJ02h1m9 = value;
		}
	}

	internal virtual GroupBox GroupBox8
	{
		[CompilerGenerated]
		get
		{
			return EoIpJRmS1fF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EoIpJRmS1fF = value;
		}
	}

	internal virtual Button btAtribuiOrientacao
	{
		[CompilerGenerated]
		get
		{
			return T0QpJmEJ7oW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ixCpTxBxRrK;
			Button button = T0QpJmEJ7oW;
			if (button != null)
			{
				button.Click -= value2;
			}
			T0QpJmEJ7oW = value;
			button = T0QpJmEJ7oW;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox ckSul
	{
		[CompilerGenerated]
		get
		{
			return X2hpJXccJYV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = Lk3pTV132w9;
			CheckBox checkBox = X2hpJXccJYV;
			if (checkBox != null)
			{
				checkBox.MouseUp -= value2;
			}
			X2hpJXccJYV = value;
			checkBox = X2hpJXccJYV;
			if (checkBox != null)
			{
				checkBox.MouseUp += value2;
			}
		}
	}

	internal virtual CheckBox ckNorte
	{
		[CompilerGenerated]
		get
		{
			return dCZpJUdeNkT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = yiFpTBRR6OT;
			CheckBox checkBox = dCZpJUdeNkT;
			if (checkBox != null)
			{
				checkBox.MouseUp -= value2;
			}
			dCZpJUdeNkT = value;
			checkBox = dCZpJUdeNkT;
			if (checkBox != null)
			{
				checkBox.MouseUp += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox9
	{
		[CompilerGenerated]
		get
		{
			return FkJpJyoN8OP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FkJpJyoN8OP = value;
		}
	}

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return pFNpJgkchxc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CCxpTEw5VKg;
			Button button = pFNpJgkchxc;
			if (button != null)
			{
				button.Click -= value2;
			}
			pFNpJgkchxc = value;
			button = pFNpJgkchxc;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return F2qpJADHrMg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			F2qpJADHrMg = value;
		}
	}

	internal virtual Button btSelecionaBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return Q2ZpJsLuDTc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QBCpTuiTtJS;
			Button button = Q2ZpJsLuDTc;
			if (button != null)
			{
				button.Click -= value2;
			}
			Q2ZpJsLuDTc = value;
			button = Q2ZpJsLuDTc;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgBornesExtra
	{
		[CompilerGenerated]
		get
		{
			return dvIpJBoHSk2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dvIpJBoHSk2 = value;
		}
	}

	internal virtual GroupBox GroupBox10
	{
		[CompilerGenerated]
		get
		{
			return Hp1pJV2hyWd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Hp1pJV2hyWd = value;
		}
	}

	internal virtual TextBox TBExtras
	{
		[CompilerGenerated]
		get
		{
			return o4ZpJuMdyPF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o4ZpJuMdyPF = value;
		}
	}

	internal virtual Button BTExtra
	{
		[CompilerGenerated]
		get
		{
			return ysrpJEfBy2G;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QlApTZTu6Vq;
			Button button = ysrpJEfBy2G;
			if (button != null)
			{
				button.Click -= value2;
			}
			ysrpJEfBy2G = value;
			button = ysrpJEfBy2G;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btRomoveReservas
	{
		[CompilerGenerated]
		get
		{
			return IM1pJZOn93l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LW8pT7oRY6V;
			Button button = IM1pJZOn93l;
			if (button != null)
			{
				button.Click -= value2;
			}
			IM1pJZOn93l = value;
			button = IM1pJZOn93l;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btUltimoChassi
	{
		[CompilerGenerated]
		get
		{
			return MCHpJi3SWe1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kNfpTCl05Jp;
			Button button = MCHpJi3SWe1;
			if (button != null)
			{
				button.Click -= value2;
			}
			MCHpJi3SWe1 = value;
			button = MCHpJi3SWe1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPrimeiroChassi
	{
		[CompilerGenerated]
		get
		{
			return SGjpJSBqk7v;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = I9MpTiyAmTL;
			Button button = SGjpJSBqk7v;
			if (button != null)
			{
				button.Click -= value2;
			}
			SGjpJSBqk7v = value;
			button = SGjpJSBqk7v;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btBaixoChassi
	{
		[CompilerGenerated]
		get
		{
			return YjCpJ4CrX1J;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RbppT47GGo6;
			Button button = YjCpJ4CrX1J;
			if (button != null)
			{
				button.Click -= value2;
			}
			YjCpJ4CrX1J = value;
			button = YjCpJ4CrX1J;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCimaChassi
	{
		[CompilerGenerated]
		get
		{
			return E5YpJCTILCD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DFGpTSPb0s4;
			Button button = E5YpJCTILCD;
			if (button != null)
			{
				button.Click -= value2;
			}
			E5YpJCTILCD = value;
			button = E5YpJCTILCD;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox11
	{
		[CompilerGenerated]
		get
		{
			return tnVpJYed9aX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tnVpJYed9aX = value;
		}
	}

	internal virtual Button BTLimpaGeral
	{
		[CompilerGenerated]
		get
		{
			return vavpJronEfW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WhxpJT5PWkH;
			Button button = vavpJronEfW;
			if (button != null)
			{
				button.Click -= value2;
			}
			vavpJronEfW = value;
			button = vavpJronEfW;
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
			return bRypJ9EMqJu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bRypJ9EMqJu = value;
		}
	}

	internal virtual Label lbFabricante
	{
		[CompilerGenerated]
		get
		{
			return F1epJzZ3reR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			F1epJzZ3reR = value;
		}
	}

	internal virtual Label lbModelo
	{
		[CompilerGenerated]
		get
		{
			return D88phW4aDmJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			D88phW4aDmJ = value;
		}
	}

	internal virtual Label lbDesc
	{
		[CompilerGenerated]
		get
		{
			return v2AphpwkuE1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v2AphpwkuE1 = value;
		}
	}

	internal virtual Label lbCodigo
	{
		[CompilerGenerated]
		get
		{
			return VGJphTrRwYF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VGJphTrRwYF = value;
		}
	}

	internal virtual TextBox tbFabricante1
	{
		[CompilerGenerated]
		get
		{
			return PVYphJoOR1Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PVYphJoOR1Y = value;
		}
	}

	internal virtual TextBox tbModelo1
	{
		[CompilerGenerated]
		get
		{
			return eOAphhrfN6l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eOAphhrfN6l = value;
		}
	}

	internal virtual TextBox tbDescricaoResum1
	{
		[CompilerGenerated]
		get
		{
			return O3Lphov80A8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			O3Lphov80A8 = value;
		}
	}

	internal virtual TextBox tbCodigo1
	{
		[CompilerGenerated]
		get
		{
			return XHlphG3YQK4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XHlphG3YQK4 = value;
		}
	}

	internal virtual Button btPesquisaLM1
	{
		[CompilerGenerated]
		get
		{
			return HhqphH6rPKq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = m5XpTr7fDuU;
			Button button = HhqphH6rPKq;
			if (button != null)
			{
				button.Click -= value2;
			}
			HhqphH6rPKq = value;
			button = HhqphH6rPKq;
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
			if (disposing && CVNpJJxZ6pl != null)
			{
				CVNpJJxZ6pl.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void E73pTjp5X4X()
	{
		CVNpJJxZ6pl = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		dgReguas = new DataGridView();
		FDqpBiUmZij(new ToolTip(CVNpJJxZ6pl));
		btBorneSimples = new Button();
		btBorneDuplo = new Button();
		btAtribuiLM = new Button();
		BtIndefinirBornesSel = new Button();
		CBMigraRegua = new ComboBox();
		btMigrarBornes = new Button();
		GroupBox2 = new GroupBox();
		dgBornes = new DataGridView();
		GroupBox4 = new GroupBox();
		RB_Todos = new RadioButton();
		RB_IndefinidosFinal = new RadioButton();
		BtNumerar = new Button();
		GroupBox5 = new GroupBox();
		RB_INT_PCV = new RadioButton();
		RB_PG_POT_CL = new RadioButton();
		RB_PG_POT_LC = new RadioButton();
		RB_PLC = new RadioButton();
		RB_PCL = new RadioButton();
		RB_POT_CL = new RadioButton();
		RB_POT_LC = new RadioButton();
		btSalvar = new Button();
		GroupBox3 = new GroupBox();
		btRomoveReservas = new Button();
		btInsereReservaEntre = new Button();
		CKEdicaoMultiplas = new CheckBox();
		GroupBox6 = new GroupBox();
		tbRecuo = new TextBox();
		btDiminuiRecuo = new Button();
		btAumentaRecuo = new Button();
		LbFiltro = new Label();
		TBPesquisa = new TextBox();
		GroupBox7 = new GroupBox();
		btOrdenarAZ = new Button();
		BTExportaEXCEL = new Button();
		BTImportaEXCEL = new Button();
		GroupBox8 = new GroupBox();
		ckSul = new CheckBox();
		ckNorte = new CheckBox();
		btAtribuiOrientacao = new Button();
		GroupBox9 = new GroupBox();
		tbBlocoLayout = new TextBox();
		Button1 = new Button();
		btSelecionaBlocoLayout = new Button();
		dgBornesExtra = new DataGridView();
		GroupBox10 = new GroupBox();
		TBExtras = new TextBox();
		BTExtra = new Button();
		btUltimoChassi = new Button();
		btPrimeiroChassi = new Button();
		btBaixoChassi = new Button();
		btCimaChassi = new Button();
		GroupBox11 = new GroupBox();
		BTLimpaGeral = new Button();
		GroupBox1 = new GroupBox();
		lbFabricante = new Label();
		lbModelo = new Label();
		lbDesc = new Label();
		lbCodigo = new Label();
		tbFabricante1 = new TextBox();
		tbModelo1 = new TextBox();
		tbDescricaoResum1 = new TextBox();
		tbCodigo1 = new TextBox();
		btPesquisaLM1 = new Button();
		((ISupportInitialize)dgReguas).BeginInit();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgBornes).BeginInit();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox6.SuspendLayout();
		GroupBox7.SuspendLayout();
		GroupBox8.SuspendLayout();
		GroupBox9.SuspendLayout();
		((ISupportInitialize)dgBornesExtra).BeginInit();
		GroupBox10.SuspendLayout();
		GroupBox11.SuspendLayout();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		dgReguas.AllowDrop = true;
		dgReguas.AllowUserToAddRows = false;
		dgReguas.AllowUserToDeleteRows = false;
		dgReguas.AllowUserToOrderColumns = true;
		dgReguas.AllowUserToResizeRows = false;
		dgReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgReguas.BackgroundColor = Color.White;
		dgReguas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguas.Location = new Point(12, 38);
		dgReguas.MultiSelect = false;
		dgReguas.Name = "dgReguas";
		dgReguas.ReadOnly = true;
		dgReguas.RowHeadersVisible = false;
		dgReguas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguas.Size = new Size(191, 625);
		dgReguas.TabIndex = 172;
		btBorneSimples.FlatStyle = FlatStyle.Flat;
		btBorneSimples.ForeColor = SystemColors.Control;
		btBorneSimples.Image = Resources.BornesS_32;
		btBorneSimples.ImageAlign = ContentAlignment.MiddleLeft;
		btBorneSimples.Location = new Point(12, 12);
		btBorneSimples.Name = "btBorneSimples";
		btBorneSimples.Size = new Size(40, 40);
		btBorneSimples.TabIndex = 154;
		btBorneSimples.UseVisualStyleBackColor = true;
		btBorneDuplo.FlatStyle = FlatStyle.Flat;
		btBorneDuplo.ForeColor = SystemColors.Control;
		btBorneDuplo.Image = Resources.BornesD_32;
		btBorneDuplo.Location = new Point(58, 12);
		btBorneDuplo.Name = "btBorneDuplo";
		btBorneDuplo.Size = new Size(40, 40);
		btBorneDuplo.TabIndex = 155;
		btBorneDuplo.UseVisualStyleBackColor = true;
		btAtribuiLM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		btAtribuiLM.FlatStyle = FlatStyle.Flat;
		btAtribuiLM.ForeColor = SystemColors.Control;
		btAtribuiLM.Image = Resources.Editar_16;
		btAtribuiLM.Location = new Point(312, 65);
		btAtribuiLM.Name = "btAtribuiLM";
		btAtribuiLM.Size = new Size(21, 21);
		btAtribuiLM.TabIndex = 170;
		btAtribuiLM.UseVisualStyleBackColor = true;
		BtIndefinirBornesSel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BtIndefinirBornesSel.FlatStyle = FlatStyle.Flat;
		BtIndefinirBornesSel.ForeColor = SystemColors.Control;
		BtIndefinirBornesSel.Image = Resources.Apagador_32;
		BtIndefinirBornesSel.Location = new Point(41, 61);
		BtIndefinirBornesSel.Name = "BtIndefinirBornesSel";
		BtIndefinirBornesSel.Size = new Size(40, 40);
		BtIndefinirBornesSel.TabIndex = 154;
		BtIndefinirBornesSel.UseVisualStyleBackColor = true;
		CBMigraRegua.FormattingEnabled = true;
		CBMigraRegua.Location = new Point(10, 20);
		CBMigraRegua.Name = "CBMigraRegua";
		CBMigraRegua.Size = new Size(148, 21);
		CBMigraRegua.TabIndex = 160;
		btMigrarBornes.FlatStyle = FlatStyle.Flat;
		btMigrarBornes.ForeColor = SystemColors.Control;
		btMigrarBornes.Image = Resources.BorneMigra;
		btMigrarBornes.Location = new Point(163, 12);
		btMigrarBornes.Name = "btMigrarBornes";
		btMigrarBornes.Size = new Size(65, 30);
		btMigrarBornes.TabIndex = 159;
		btMigrarBornes.Tag = "";
		btMigrarBornes.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox2.Controls.Add(CBMigraRegua);
		GroupBox2.Controls.Add(btMigrarBornes);
		GroupBox2.Location = new Point(502, 203);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(235, 50);
		GroupBox2.TabIndex = 175;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		dgBornes.AllowDrop = true;
		dgBornes.AllowUserToAddRows = false;
		dgBornes.AllowUserToDeleteRows = false;
		dgBornes.AllowUserToResizeRows = false;
		dgBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgBornes.BackgroundColor = Color.White;
		dgBornes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornes.Location = new Point(209, 12);
		dgBornes.MultiSelect = false;
		dgBornes.Name = "dgBornes";
		dgBornes.RowHeadersVisible = false;
		dgBornes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornes.Size = new Size(285, 651);
		dgBornes.TabIndex = 176;
		GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox4.Controls.Add(RB_Todos);
		GroupBox4.Controls.Add(RB_IndefinidosFinal);
		GroupBox4.Location = new Point(502, 419);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(345, 49);
		GroupBox4.TabIndex = 149;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "GroupBox4";
		RB_Todos.AutoSize = true;
		RB_Todos.Location = new Point(13, 19);
		RB_Todos.Name = "RB_Todos";
		RB_Todos.Size = new Size(64, 17);
		RB_Todos.TabIndex = 0;
		RB_Todos.TabStop = true;
		RB_Todos.Text = "rbTodos";
		RB_Todos.UseVisualStyleBackColor = true;
		RB_IndefinidosFinal.AutoSize = true;
		RB_IndefinidosFinal.Location = new Point(89, 19);
		RB_IndefinidosFinal.Name = "RB_IndefinidosFinal";
		RB_IndefinidosFinal.Size = new Size(195, 17);
		RB_IndefinidosFinal.TabIndex = 2;
		RB_IndefinidosFinal.TabStop = true;
		RB_IndefinidosFinal.Text = "rbIndefinidos a partir do ultimo borne";
		RB_IndefinidosFinal.UseVisualStyleBackColor = true;
		BtNumerar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BtNumerar.FlatStyle = FlatStyle.Flat;
		BtNumerar.ForeColor = SystemColors.Control;
		BtNumerar.Image = Resources.EditarBornes_32;
		BtNumerar.Location = new Point(232, 57);
		BtNumerar.Name = "BtNumerar";
		BtNumerar.Size = new Size(40, 40);
		BtNumerar.TabIndex = 153;
		BtNumerar.UseVisualStyleBackColor = true;
		GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox5.Controls.Add(RB_INT_PCV);
		GroupBox5.Controls.Add(BtNumerar);
		GroupBox5.Controls.Add(RB_PG_POT_CL);
		GroupBox5.Controls.Add(RB_PG_POT_LC);
		GroupBox5.Controls.Add(RB_PLC);
		GroupBox5.Controls.Add(RB_PCL);
		GroupBox5.Location = new Point(552, 469);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(295, 145);
		GroupBox5.TabIndex = 151;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "GroupBox5";
		RB_INT_PCV.AutoSize = true;
		RB_INT_PCV.Location = new Point(13, 112);
		RB_INT_PCV.Name = "RB_INT_PCV";
		RB_INT_PCV.Size = new Size(188, 17);
		RB_INT_PCV.TabIndex = 6;
		RB_INT_PCV.TabStop = true;
		RB_INT_PCV.Text = "Interligação ( Painel, Cabo e Veia )";
		RB_INT_PCV.UseVisualStyleBackColor = true;
		RB_PG_POT_CL.AutoSize = true;
		RB_PG_POT_CL.Location = new Point(13, 66);
		RB_PG_POT_CL.Name = "RB_PG_POT_CL";
		RB_PG_POT_CL.Size = new Size(176, 17);
		RB_PG_POT_CL.TabIndex = 5;
		RB_PG_POT_CL.TabStop = true;
		RB_PG_POT_CL.Text = "PG, Potencial ( Coluna e Linha )";
		RB_PG_POT_CL.UseVisualStyleBackColor = true;
		RB_PG_POT_LC.AutoSize = true;
		RB_PG_POT_LC.Location = new Point(13, 89);
		RB_PG_POT_LC.Name = "RB_PG_POT_LC";
		RB_PG_POT_LC.Size = new Size(176, 17);
		RB_PG_POT_LC.TabIndex = 4;
		RB_PG_POT_LC.TabStop = true;
		RB_PG_POT_LC.Text = "PG, Potencial ( Linha e Coluna )";
		RB_PG_POT_LC.UseVisualStyleBackColor = true;
		RB_PLC.AutoSize = true;
		RB_PLC.Location = new Point(13, 43);
		RB_PLC.Name = "RB_PLC";
		RB_PLC.Size = new Size(135, 17);
		RB_PLC.TabIndex = 3;
		RB_PLC.TabStop = true;
		RB_PLC.Text = "Página, Linha e Coluna";
		RB_PLC.UseVisualStyleBackColor = true;
		RB_PCL.AutoSize = true;
		RB_PCL.Location = new Point(13, 20);
		RB_PCL.Name = "RB_PCL";
		RB_PCL.Size = new Size(135, 17);
		RB_PCL.TabIndex = 2;
		RB_PCL.TabStop = true;
		RB_PCL.Text = "Página, Coluna e Linha";
		RB_PCL.UseVisualStyleBackColor = true;
		RB_POT_CL.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		RB_POT_CL.AutoSize = true;
		RB_POT_CL.Enabled = false;
		RB_POT_CL.Location = new Point(805, 487);
		RB_POT_CL.Name = "RB_POT_CL";
		RB_POT_CL.Size = new Size(155, 17);
		RB_POT_CL.TabIndex = 5;
		RB_POT_CL.TabStop = true;
		RB_POT_CL.Text = "Potencial ( Coluna e Linha )";
		RB_POT_CL.UseVisualStyleBackColor = true;
		RB_POT_CL.Visible = false;
		RB_POT_LC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		RB_POT_LC.AutoSize = true;
		RB_POT_LC.Enabled = false;
		RB_POT_LC.Location = new Point(805, 510);
		RB_POT_LC.Name = "RB_POT_LC";
		RB_POT_LC.Size = new Size(155, 17);
		RB_POT_LC.TabIndex = 4;
		RB_POT_LC.TabStop = true;
		RB_POT_LC.Text = "Potencial ( Linha e Coluna )";
		RB_POT_LC.UseVisualStyleBackColor = true;
		RB_POT_LC.Visible = false;
		btSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(665, 616);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 178;
		btSalvar.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox3.Controls.Add(btRomoveReservas);
		GroupBox3.Controls.Add(btInsereReservaEntre);
		GroupBox3.Controls.Add(btBorneSimples);
		GroupBox3.Controls.Add(BtIndefinirBornesSel);
		GroupBox3.Controls.Add(btBorneDuplo);
		GroupBox3.Location = new Point(743, 203);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(104, 211);
		GroupBox3.TabIndex = 180;
		GroupBox3.TabStop = false;
		btRomoveReservas.BackColor = SystemColors.Control;
		btRomoveReservas.FlatStyle = FlatStyle.Flat;
		btRomoveReservas.ForeColor = SystemColors.Control;
		btRomoveReservas.Image = Resources.RemoveBornes;
		btRomoveReservas.Location = new Point(11, 163);
		btRomoveReservas.Name = "btRomoveReservas";
		btRomoveReservas.Size = new Size(85, 37);
		btRomoveReservas.TabIndex = 161;
		btRomoveReservas.Tag = "";
		btRomoveReservas.UseVisualStyleBackColor = false;
		btInsereReservaEntre.FlatStyle = FlatStyle.Flat;
		btInsereReservaEntre.ForeColor = SystemColors.Control;
		btInsereReservaEntre.Image = Resources.CompletaBornes;
		btInsereReservaEntre.Location = new Point(9, 113);
		btInsereReservaEntre.Name = "btInsereReservaEntre";
		btInsereReservaEntre.Size = new Size(85, 37);
		btInsereReservaEntre.TabIndex = 160;
		btInsereReservaEntre.Tag = "";
		btInsereReservaEntre.UseVisualStyleBackColor = true;
		CKEdicaoMultiplas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		CKEdicaoMultiplas.AutoSize = true;
		CKEdicaoMultiplas.Location = new Point(502, 12);
		CKEdicaoMultiplas.Name = "CKEdicaoMultiplas";
		CKEdicaoMultiplas.Size = new Size(114, 17);
		CKEdicaoMultiplas.TabIndex = 181;
		CKEdicaoMultiplas.Text = "CKEdicaoMultiplas";
		CKEdicaoMultiplas.UseVisualStyleBackColor = true;
		GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox6.Controls.Add(tbRecuo);
		GroupBox6.Controls.Add(btDiminuiRecuo);
		GroupBox6.Controls.Add(btAumentaRecuo);
		GroupBox6.Location = new Point(502, 252);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(235, 50);
		GroupBox6.TabIndex = 182;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "GroupBox6";
		tbRecuo.Location = new Point(10, 20);
		tbRecuo.Name = "tbRecuo";
		tbRecuo.Size = new Size(35, 20);
		tbRecuo.TabIndex = 183;
		tbRecuo.Text = "0";
		tbRecuo.TextAlign = HorizontalAlignment.Center;
		btDiminuiRecuo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btDiminuiRecuo.FlatStyle = FlatStyle.Flat;
		btDiminuiRecuo.ForeColor = SystemColors.Control;
		btDiminuiRecuo.Image = Resources.Bornes_32Menos;
		btDiminuiRecuo.Location = new Point(161, 12);
		btDiminuiRecuo.Name = "btDiminuiRecuo";
		btDiminuiRecuo.Size = new Size(65, 30);
		btDiminuiRecuo.TabIndex = 156;
		btDiminuiRecuo.UseVisualStyleBackColor = true;
		btAumentaRecuo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btAumentaRecuo.FlatStyle = FlatStyle.Flat;
		btAumentaRecuo.ForeColor = SystemColors.Control;
		btAumentaRecuo.Image = Resources.Bornes_32Mais;
		btAumentaRecuo.Location = new Point(76, 12);
		btAumentaRecuo.Name = "btAumentaRecuo";
		btAumentaRecuo.Size = new Size(65, 30);
		btAumentaRecuo.TabIndex = 155;
		btAumentaRecuo.UseVisualStyleBackColor = true;
		LbFiltro.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro.Location = new Point(12, 12);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(81, 20);
		LbFiltro.TabIndex = 184;
		LbFiltro.Text = "lbFiltro";
		LbFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(99, 12);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(104, 20);
		TBPesquisa.TabIndex = 183;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox7.Controls.Add(btOrdenarAZ);
		GroupBox7.Controls.Add(BTExportaEXCEL);
		GroupBox7.Controls.Add(BTImportaEXCEL);
		GroupBox7.Location = new Point(502, 354);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(235, 60);
		GroupBox7.TabIndex = 187;
		GroupBox7.TabStop = false;
		btOrdenarAZ.FlatStyle = FlatStyle.Flat;
		btOrdenarAZ.ForeColor = SystemColors.Control;
		btOrdenarAZ.Image = Resources.Ordem_32;
		btOrdenarAZ.Location = new Point(188, 14);
		btOrdenarAZ.Name = "btOrdenarAZ";
		btOrdenarAZ.Size = new Size(32, 32);
		btOrdenarAZ.TabIndex = 190;
		btOrdenarAZ.UseVisualStyleBackColor = true;
		BTExportaEXCEL.FlatStyle = FlatStyle.Flat;
		BTExportaEXCEL.ForeColor = SystemColors.Control;
		BTExportaEXCEL.Image = Resources.ExportaExcel_20;
		BTExportaEXCEL.Location = new Point(10, 9);
		BTExportaEXCEL.Name = "BTExportaEXCEL";
		BTExportaEXCEL.Size = new Size(25, 42);
		BTExportaEXCEL.TabIndex = 188;
		BTExportaEXCEL.UseVisualStyleBackColor = true;
		BTImportaEXCEL.FlatStyle = FlatStyle.Flat;
		BTImportaEXCEL.ForeColor = SystemColors.Control;
		BTImportaEXCEL.Image = Resources.ImportaExcel_20;
		BTImportaEXCEL.Location = new Point(99, 9);
		BTImportaEXCEL.Name = "BTImportaEXCEL";
		BTImportaEXCEL.Size = new Size(25, 42);
		BTImportaEXCEL.TabIndex = 187;
		BTImportaEXCEL.UseVisualStyleBackColor = true;
		GroupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox8.Controls.Add(ckSul);
		GroupBox8.Controls.Add(ckNorte);
		GroupBox8.Controls.Add(btAtribuiOrientacao);
		GroupBox8.Location = new Point(742, 141);
		GroupBox8.Name = "GroupBox8";
		GroupBox8.Size = new Size(105, 59);
		GroupBox8.TabIndex = 188;
		GroupBox8.TabStop = false;
		GroupBox8.Text = "GroupBox8";
		ckSul.AutoSize = true;
		ckSul.Location = new Point(5, 37);
		ckSul.Name = "ckSul";
		ckSul.Size = new Size(53, 17);
		ckSul.TabIndex = 183;
		ckSul.Text = "ckSul";
		ckSul.UseVisualStyleBackColor = true;
		ckNorte.AutoSize = true;
		ckNorte.Location = new Point(5, 20);
		ckNorte.Name = "ckNorte";
		ckNorte.Size = new Size(64, 17);
		ckNorte.TabIndex = 182;
		ckNorte.Text = "ckNorte";
		ckNorte.UseVisualStyleBackColor = true;
		btAtribuiOrientacao.FlatStyle = FlatStyle.Flat;
		btAtribuiOrientacao.ForeColor = SystemColors.Control;
		btAtribuiOrientacao.Image = Resources.Editar_16;
		btAtribuiOrientacao.Location = new Point(75, 21);
		btAtribuiOrientacao.Name = "btAtribuiOrientacao";
		btAtribuiOrientacao.Size = new Size(21, 26);
		btAtribuiOrientacao.TabIndex = 171;
		btAtribuiOrientacao.UseVisualStyleBackColor = true;
		GroupBox9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox9.Controls.Add(tbBlocoLayout);
		GroupBox9.Controls.Add(Button1);
		GroupBox9.Controls.Add(btSelecionaBlocoLayout);
		GroupBox9.Location = new Point(502, 141);
		GroupBox9.Name = "GroupBox9";
		GroupBox9.Size = new Size(235, 59);
		GroupBox9.TabIndex = 189;
		GroupBox9.TabStop = false;
		GroupBox9.Text = "cbLayout";
		tbBlocoLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoLayout.Location = new Point(10, 20);
		tbBlocoLayout.Name = "tbBlocoLayout";
		tbBlocoLayout.ReadOnly = true;
		tbBlocoLayout.Size = new Size(164, 20);
		tbBlocoLayout.TabIndex = 191;
		Button1.FlatStyle = FlatStyle.Flat;
		Button1.ForeColor = SystemColors.Control;
		Button1.Image = Resources.Editar_16;
		Button1.Location = new Point(205, 20);
		Button1.Name = "Button1";
		Button1.Size = new Size(21, 21);
		Button1.TabIndex = 170;
		Button1.UseVisualStyleBackColor = true;
		btSelecionaBlocoLayout.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoLayout.ForeColor = SystemColors.Control;
		btSelecionaBlocoLayout.Image = Resources.Pesquisar_16;
		btSelecionaBlocoLayout.Location = new Point(181, 19);
		btSelecionaBlocoLayout.Name = "btSelecionaBlocoLayout";
		btSelecionaBlocoLayout.Size = new Size(22, 22);
		btSelecionaBlocoLayout.TabIndex = 190;
		btSelecionaBlocoLayout.UseVisualStyleBackColor = true;
		dgBornesExtra.AllowDrop = true;
		dgBornesExtra.AllowUserToAddRows = false;
		dgBornesExtra.AllowUserToDeleteRows = false;
		dgBornesExtra.AllowUserToResizeRows = false;
		dgBornesExtra.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgBornesExtra.BackgroundColor = Color.White;
		dgBornesExtra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornesExtra.Location = new Point(209, 563);
		dgBornesExtra.MultiSelect = false;
		dgBornesExtra.Name = "dgBornesExtra";
		dgBornesExtra.RowHeadersVisible = false;
		dgBornesExtra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornesExtra.Size = new Size(285, 100);
		dgBornesExtra.TabIndex = 190;
		GroupBox10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox10.Controls.Add(TBExtras);
		GroupBox10.Controls.Add(BTExtra);
		GroupBox10.Location = new Point(502, 302);
		GroupBox10.Name = "GroupBox10";
		GroupBox10.Size = new Size(235, 50);
		GroupBox10.TabIndex = 191;
		GroupBox10.TabStop = false;
		GroupBox10.Text = "Extra: POSTE,TAMPAS...";
		TBExtras.Location = new Point(10, 19);
		TBExtras.MaxLength = 10;
		TBExtras.Name = "TBExtras";
		TBExtras.Size = new Size(164, 20);
		TBExtras.TabIndex = 198;
		TBExtras.Text = "TAMPA";
		BTExtra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTExtra.FlatStyle = FlatStyle.Flat;
		BTExtra.ForeColor = SystemColors.Control;
		BTExtra.Image = Resources.AtribuirDir_32;
		BTExtra.Location = new Point(181, 8);
		BTExtra.Name = "BTExtra";
		BTExtra.Size = new Size(40, 40);
		BTExtra.TabIndex = 155;
		BTExtra.UseVisualStyleBackColor = true;
		btUltimoChassi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btUltimoChassi.Image = Resources.Ultimo_16;
		btUltimoChassi.Location = new Point(10, 105);
		btUltimoChassi.Name = "btUltimoChassi";
		btUltimoChassi.Size = new Size(23, 23);
		btUltimoChassi.TabIndex = 201;
		btUltimoChassi.UseVisualStyleBackColor = true;
		btPrimeiroChassi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btPrimeiroChassi.Image = Resources.Primeiro_16;
		btPrimeiroChassi.Location = new Point(10, 18);
		btPrimeiroChassi.Name = "btPrimeiroChassi";
		btPrimeiroChassi.Size = new Size(23, 23);
		btPrimeiroChassi.TabIndex = 200;
		btPrimeiroChassi.UseVisualStyleBackColor = true;
		btBaixoChassi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btBaixoChassi.Image = Resources.Baixo_16;
		btBaixoChassi.Location = new Point(10, 76);
		btBaixoChassi.Name = "btBaixoChassi";
		btBaixoChassi.Size = new Size(23, 23);
		btBaixoChassi.TabIndex = 199;
		btBaixoChassi.UseVisualStyleBackColor = true;
		btCimaChassi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btCimaChassi.Image = Resources.Cima_16;
		btCimaChassi.Location = new Point(10, 47);
		btCimaChassi.Name = "btCimaChassi";
		btCimaChassi.Size = new Size(23, 23);
		btCimaChassi.TabIndex = 198;
		btCimaChassi.UseVisualStyleBackColor = true;
		GroupBox11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox11.Controls.Add(btCimaChassi);
		GroupBox11.Controls.Add(btUltimoChassi);
		GroupBox11.Controls.Add(btBaixoChassi);
		GroupBox11.Controls.Add(btPrimeiroChassi);
		GroupBox11.Location = new Point(502, 467);
		GroupBox11.Name = "GroupBox11";
		GroupBox11.Size = new Size(44, 147);
		GroupBox11.TabIndex = 202;
		GroupBox11.TabStop = false;
		BTLimpaGeral.BackColor = SystemColors.Control;
		BTLimpaGeral.FlatStyle = FlatStyle.Flat;
		BTLimpaGeral.ForeColor = SystemColors.Control;
		BTLimpaGeral.Image = Resources.RemoveBornes;
		BTLimpaGeral.Location = new Point(801, 620);
		BTLimpaGeral.Name = "BTLimpaGeral";
		BTLimpaGeral.Size = new Size(39, 37);
		BTLimpaGeral.TabIndex = 203;
		BTLimpaGeral.Tag = "";
		BTLimpaGeral.UseVisualStyleBackColor = false;
		BTLimpaGeral.Visible = false;
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox1.Controls.Add(lbFabricante);
		GroupBox1.Controls.Add(lbModelo);
		GroupBox1.Controls.Add(btAtribuiLM);
		GroupBox1.Controls.Add(lbDesc);
		GroupBox1.Controls.Add(lbCodigo);
		GroupBox1.Controls.Add(tbFabricante1);
		GroupBox1.Controls.Add(tbModelo1);
		GroupBox1.Controls.Add(tbDescricaoResum1);
		GroupBox1.Controls.Add(tbCodigo1);
		GroupBox1.Controls.Add(btPesquisaLM1);
		GroupBox1.Location = new Point(502, 35);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(345, 106);
		GroupBox1.TabIndex = 204;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		lbFabricante.Location = new Point(123, 56);
		lbFabricante.Name = "lbFabricante";
		lbFabricante.Size = new Size(111, 16);
		lbFabricante.TabIndex = 207;
		lbFabricante.Text = "Fabricante";
		lbModelo.Location = new Point(6, 55);
		lbModelo.Name = "lbModelo";
		lbModelo.Size = new Size(111, 16);
		lbModelo.TabIndex = 206;
		lbModelo.Text = "Modelo";
		lbDesc.Location = new Point(87, 14);
		lbDesc.Name = "lbDesc";
		lbDesc.Size = new Size(197, 16);
		lbDesc.TabIndex = 205;
		lbDesc.Text = "Descrição Resumida";
		lbCodigo.Location = new Point(6, 14);
		lbCodigo.Name = "lbCodigo";
		lbCodigo.Size = new Size(75, 16);
		lbCodigo.TabIndex = 204;
		lbCodigo.Text = "Codigo";
		tbFabricante1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante1.Location = new Point(123, 76);
		tbFabricante1.Name = "tbFabricante1";
		tbFabricante1.ReadOnly = true;
		tbFabricante1.Size = new Size(161, 20);
		tbFabricante1.TabIndex = 202;
		tbModelo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo1.Location = new Point(6, 76);
		tbModelo1.Name = "tbModelo1";
		tbModelo1.ReadOnly = true;
		tbModelo1.Size = new Size(111, 20);
		tbModelo1.TabIndex = 200;
		tbDescricaoResum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum1.Location = new Point(87, 33);
		tbDescricaoResum1.Name = "tbDescricaoResum1";
		tbDescricaoResum1.ReadOnly = true;
		tbDescricaoResum1.Size = new Size(197, 20);
		tbDescricaoResum1.TabIndex = 198;
		tbCodigo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo1.Location = new Point(8, 33);
		tbCodigo1.Name = "tbCodigo1";
		tbCodigo1.ReadOnly = true;
		tbCodigo1.Size = new Size(73, 20);
		tbCodigo1.TabIndex = 196;
		btPesquisaLM1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM1.FlatStyle = FlatStyle.Flat;
		btPesquisaLM1.ForeColor = SystemColors.Control;
		btPesquisaLM1.Image = Resources.Pesquisar_16;
		btPesquisaLM1.Location = new Point(311, 35);
		btPesquisaLM1.Name = "btPesquisaLM1";
		btPesquisaLM1.Size = new Size(22, 24);
		btPesquisaLM1.TabIndex = 194;
		btPesquisaLM1.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(859, 671);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox8);
		Controls.Add(BTLimpaGeral);
		Controls.Add(GroupBox11);
		Controls.Add(GroupBox10);
		Controls.Add(dgBornesExtra);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox9);
		Controls.Add(GroupBox7);
		Controls.Add(LbFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(RB_POT_CL);
		Controls.Add(GroupBox6);
		Controls.Add(RB_POT_LC);
		Controls.Add(CKEdicaoMultiplas);
		Controls.Add(GroupBox4);
		Controls.Add(btSalvar);
		Controls.Add(dgBornes);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox2);
		Controls.Add(dgReguas);
		MaximizeBox = false;
		MinimizeBox = false;
		MinimumSize = new Size(875, 710);
		Name = "frmGerenciadorReguasBornes";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Editor da Regua";
		((ISupportInitialize)dgReguas).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgBornes).EndInit();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox5.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox6.ResumeLayout(performLayout: false);
		GroupBox6.PerformLayout();
		GroupBox7.ResumeLayout(performLayout: false);
		GroupBox8.ResumeLayout(performLayout: false);
		GroupBox8.PerformLayout();
		GroupBox9.ResumeLayout(performLayout: false);
		GroupBox9.PerformLayout();
		((ISupportInitialize)dgBornesExtra).EndInit();
		GroupBox10.ResumeLayout(performLayout: false);
		GroupBox10.PerformLayout();
		GroupBox11.ResumeLayout(performLayout: false);
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return worpJhPHKWw;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		worpJhPHKWw = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return XO3pJoEgxYt;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		XO3pJoEgxYt = WithEventsValue;
	}

	public frmGerenciadorReguasBornes()
	{
		Resize += RXgpTRBo72Y;
		m8Qphkag17n = "";
		AuSphv29XNQ = null;
		sCXph6C4lyQ = null;
		fJLphtEQVvs = null;
		QCXphjEHtXO = "";
		erCphL1d3Ee = "";
		y0hphw4tbHT = true;
		udsphxagTYf = "";
		vfcphbxiZf6 = 1;
		AlOphM2M7b2 = 0;
		pcAphO3XWWQ = 0;
		hJ4phInBpLi = false;
		Mh0phqkE313 = false;
		Wt4phaMFEc0 = 0;
		Happh8ZEYMe = 0;
		if (Geral.ExisteForm("frmGerenciadorReguasBornes") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			E73pTjp5X4X();
			GC6phD60Llo = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref GC6phD60Llo);
			cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
			cDadosAccessFiacao2.BuscatodosOsBornesPotenciais(ref fJLphtEQVvs);
			cDadosAccessFiacao2.fechaConexao();
			DataGridView dg = dgReguas;
			CarregaPaineiseReguasNoDG(ref dg, GC6phD60Llo, TBPesquisa.Text.ToString());
			dgReguas = dg;
			dg = dgReguas;
			AtualizaDgPaineisReguas(ref dg);
			dgReguas = dg;
			cDadosLM cDadosLM2 = new cDadosLM();
			W4Qph7v7o0L = cDadosLM2.CarregaDadosLMMatriz();
			cDadosLM2.fechaConexao();
			if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout)))
			{
				tbBlocoLayout.BackColor = Color.Silver;
				tbBlocoLayout.Enabled = false;
			}
			else
			{
				tbBlocoLayout.BackColor = Color.White;
				tbBlocoLayout.Enabled = true;
			}
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1147]);
			CKEdicaoMultiplas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1077]);
			w8dpBZ0kvSD().SetToolTip(btAtribuiLM, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1092]));
			LbFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1071]);
			w8dpBZ0kvSD().SetToolTip(btMigrarBornes, Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1093], CBMigraRegua.Text)));
			GroupBox3.Text = "";
			w8dpBZ0kvSD().SetToolTip(btBorneSimples, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1074]));
			w8dpBZ0kvSD().SetToolTip(btBorneDuplo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1075]));
			w8dpBZ0kvSD().SetToolTip(btMigrarBornes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1093]));
			w8dpBZ0kvSD().SetToolTip(BtIndefinirBornesSel, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1094]));
			w8dpBZ0kvSD().SetToolTip(btInsereReservaEntre, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1350]));
			GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1095]);
			GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1056]);
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]);
			lbCodigo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1245]);
			lbDesc.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
			lbModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
			lbFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]);
			RB_Todos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1060]);
			RB_IndefinidosFinal.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1096]);
			RB_PCL.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1064]);
			RB_PLC.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1065]);
			RB_POT_CL.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1066]);
			RB_POT_LC.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1067]);
			RB_PG_POT_CL.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1791]);
			RB_PG_POT_LC.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1792]);
			RB_POT_CL.Visible = false;
			RB_POT_LC.Visible = false;
			RB_PCL.Checked = true;
			RB_Todos.Checked = true;
			GroupBox4.Enabled = true;
			RB_INT_PCV.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1068]);
			w8dpBZ0kvSD().SetToolTip(BtNumerar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1057]));
			GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1175]);
			w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1089]));
			GroupBox7.Text = "";
			w8dpBZ0kvSD().SetToolTip(BTExportaEXCEL, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1198]));
			w8dpBZ0kvSD().SetToolTip(BTImportaEXCEL, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1197]));
			w8dpBZ0kvSD().SetToolTip(btOrdenarAZ, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1199]));
			GroupBox8.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]);
			ckNorte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1847]);
			ckSul.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1848]);
			GroupBox9.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 867]);
			GroupBox10.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1889]);
			cDadosAccessFiacao cDadosAccessFiacao3 = new cDadosAccessFiacao();
			DeclaracoesFiacao.structureRevisoes[] array = new DeclaracoesFiacao.structureRevisoes[1];
			array = new DeclaracoesFiacao.structureRevisoes[1];
			cDadosAccessFiacao3.CarregaRevisoesDwgCorrente(DeclaracoesGeral.arqAtivo.Indice, ref array);
			erCphL1d3Ee = array[Information.UBound(array)].revisao;
			cDadosAccessFiacao3.fechaConexao();
			if (!Information.IsNothing(erCphL1d3Ee))
			{
				RB_POT_CL.Enabled = true;
				RB_POT_LC.Enabled = true;
				RB_PG_POT_CL.Enabled = true;
				RB_PG_POT_LC.Enabled = true;
			}
			else
			{
				RB_POT_CL.Enabled = false;
				RB_POT_LC.Enabled = false;
				RB_PG_POT_CL.Enabled = false;
				RB_PG_POT_LC.Enabled = false;
			}
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			DeclaracoesFiacao.structureRevisoes[] array2 = new DeclaracoesFiacao.structureRevisoes[1];
			array2 = new DeclaracoesFiacao.structureRevisoes[1];
			cDadosAccessInterligacao3.CarregaRevisoesDwgIligCorrente(DeclaracoesGeral.arqAtivo.Indice, ref array2);
			QCXphjEHtXO = array2[Information.UBound(array2)].revisao;
			cDadosAccessInterligacao3.FechaConexao();
			if (Operators.CompareString(QCXphjEHtXO.Trim(), "", TextCompare: true) != 0)
			{
				RB_INT_PCV.Enabled = true;
			}
			else
			{
				RB_INT_PCV.Enabled = false;
			}
			dgBornesExtra.Visible = false;
			btSalvar.Enabled = false;
			tbCodigo1.Text = "0";
			Application.ShowModelessDialog((Form)this);
			if (checked(dgBornes.Rows.Count - 1) > 0)
			{
				dgBornes.Rows[0].Selected = true;
			}
			CKEdicaoMultiplas.Location = new Point(GroupBox1.Location.X, 12);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			AtualizaJanela();
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	private void zh8pTLEpWbP(object P_0, EventArgs P_1)
	{
		if (btSalvar.Enabled)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1055]), MsgBoxStyle.YesNo);
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				SalvarAlteracoes();
			}
		}
		btSalvar.Enabled = false;
		pLxphdx8X8q.iPainel = 0;
		pLxphdx8X8q.sPainel = "";
		pLxphdx8X8q.iRegua = 0;
		pLxphdx8X8q.sReguaA = "";
		checked
		{
			int num = dgReguas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgReguas.Rows[i].Selected)
				{
					pLxphdx8X8q.iPainel = Conversions.ToInteger(dgReguas.Rows[i].Cells[0].Value);
					pLxphdx8X8q.sPainel = Conversions.ToString(dgReguas.Rows[i].Cells[1].Value);
					pLxphdx8X8q.iRegua = Conversions.ToInteger(dgReguas.Rows[i].Cells[2].Value);
					pLxphdx8X8q.sReguaA = Conversions.ToString(dgReguas.Rows[i].Cells[3].Value);
					break;
				}
			}
			udsphxagTYf = pLxphdx8X8q.sPainel + "_" + pLxphdx8X8q.sReguaA;
			vfcphbxiZf6 = 1;
			DeclaracoesEntidades.StructureBorne[] array = null;
			array = new DeclaracoesEntidades.StructureBorne[1];
			clsBornes.capturaTodosOsBornesDoDesenho(pLxphdx8X8q.iRegua, ref array);
			int iRegua = pLxphdx8X8q.iRegua;
			int qSimples = 0;
			int qDuplo = 0;
			DicionarioBorne.LeDicBornesReserva(iRegua, ref array, ref qSimples, ref qDuplo);
			clsBornes.AdicionaPotencialAosBornes(ref array, fJLphtEQVvs);
			dgReguas.Enabled = false;
			DataGridView dg = dgBornes;
			CarregaOsBornesNoDG(ref dg, array, ref vfcphbxiZf6);
			dgBornes = dg;
			dg = dgBornes;
			AtualizaColunasDGBornes(ref dg);
			dgBornes = dg;
			if (dgBornes.Rows.Count - 1 > 0)
			{
				dgBornes.Rows[0].Selected = true;
				dgBornes.FirstDisplayedScrollingRowIndex = 0;
			}
			qfQphfVBOau = new StructureRegua[1];
			if (dgReguas.Rows.Count > 0)
			{
				int num2 = dgReguas.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(pLxphdx8X8q.iPainel, dgReguas.Rows[j].Cells[0].Value, TextCompare: true), Operators.CompareObjectNotEqual(pLxphdx8X8q.iRegua, dgReguas.Rows[j].Cells[2].Value, TextCompare: true))))
					{
						int num3 = Information.UBound(qfQphfVBOau) + 1;
						ref StructureRegua[] reference = ref qfQphfVBOau;
						reference = (StructureRegua[])Utils.CopyArray(reference, new StructureRegua[num3 + 1]);
						qfQphfVBOau[num3].iPainel = Conversions.ToInteger(dgReguas.Rows[j].Cells[0].Value);
						qfQphfVBOau[num3].sPainel = Conversions.ToString(dgReguas.Rows[j].Cells[1].Value);
						qfQphfVBOau[num3].iRegua = Conversions.ToInteger(dgReguas.Rows[j].Cells[2].Value);
						qfQphfVBOau[num3].sReguaA = Conversions.ToString(dgReguas.Rows[j].Cells[3].Value);
					}
				}
			}
			CBMigraRegua.Items.Clear();
			CBMigraRegua.Text = "";
			GroupBox5.Enabled = true;
			int num4 = Information.UBound(GC6phD60Llo);
			for (int k = 1; k <= num4; k++)
			{
				if (GC6phD60Llo[k].indexPainel == pLxphdx8X8q.iPainel && GC6phD60Llo[k].indexRegua != pLxphdx8X8q.iRegua)
				{
					CBMigraRegua.Items.Add(GC6phD60Llo[k].nomeRegua);
					if (Operators.CompareString(CBMigraRegua.Text, "", TextCompare: true) == 0)
					{
						CBMigraRegua.Text = GC6phD60Llo[k].nomeRegua;
					}
				}
			}
			if (Operators.CompareString(CBMigraRegua.Text, "", TextCompare: true) != 0)
			{
				GroupBox2.Enabled = true;
			}
			else
			{
				GroupBox2.Enabled = false;
			}
			dgReguas.Enabled = true;
			CKEdicaoMultiplas.Checked = true;
			CKEdicaoMultiplas.Checked = false;
			List<string> list = new List<string>();
			int num5 = Information.UBound(array);
			for (int l = 1; l <= num5; l++)
			{
				string numero = array[l].Numero;
				if (Operators.CompareString(numero, "0", TextCompare: true) != 0)
				{
					list.Add(array[l].Numero);
				}
				else
				{
					list.Add("?");
				}
			}
			if (list.Count > 0 && list.Contains("?") && list.Contains("?"))
			{
				RB_Todos.Checked = true;
			}
			int num6 = dgBornes.Rows.Count - 1;
			for (int m = 0; m <= num6; m++)
			{
				if (Conversions.ToDouble(dgBornes.Rows[m].Cells[1].Value) != (double)m + 1.0)
				{
					dgBornes.Rows[m].Cells[1].Value = m + 1;
					btSalvar.Enabled = true;
				}
			}
			if (btSalvar.Enabled)
			{
				SalvarAlteracoes();
			}
			dgReguas.Focus();
			verificaTipoDosBornes();
		}
	}

	private void kk7pTwmtH1d(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					dgBornes.Rows[i].Cells[5].Value = tbCodigo1.Text;
				}
			}
			btSalvar.Enabled = true;
		}
	}

	private void ixCpTxBxRrK(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		bool flag = false;
		string text = "";
		if (!ckNorte.Checked)
		{
			if (ckSul.Checked)
			{
				text = "S";
			}
		}
		else
		{
			text = "N";
		}
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dgBornes.Rows[i].Cells[15].Value, text, TextCompare: true), Operators.CompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))))
				{
					flag = true;
					dgBornes.Rows[i].Cells[15].Value = text;
				}
			}
			if (flag)
			{
				btSalvar.Enabled = true;
			}
		}
	}

	private void gQfpTbrII22(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					dgBornes.Rows[i].Cells[4].Value = "S";
				}
			}
			btSalvar.Enabled = true;
		}
	}

	private void BbDpTMwAdf7(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					dgBornes.Rows[i].Cells[4].Value = "D";
				}
			}
			btSalvar.Enabled = true;
		}
	}

	private void wwipTOaTPTN(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					dgBornes.Rows[i].Cells[2].Value = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					dgBornes.Rows[i].Cells[8].Value = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
				}
			}
			btSalvar.Enabled = true;
		}
	}

	private void EAPpTIkm5Ev(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		MoveExtras();
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = Conversions.ToString(dgBornes.Rows[i].Cells[2].Value);
				if (Operators.CompareString(text, "?", TextCompare: true) == 0)
				{
					text = "0.1";
				}
				if (clsBornes.BorneNumericoValido(text) != 0.0)
				{
					if (!Versioned.IsNumeric(text))
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1334]), MsgBoxStyle.Information);
						return;
					}
					continue;
				}
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1193]), MsgBoxStyle.Information);
				return;
			}
			string text2 = "S";
			string value = "0";
			double num2 = 0.0;
			int num3 = 0;
			List<string> list = new List<string>();
			string text3 = "";
			if (ckNorte.Checked)
			{
				text3 = "N";
			}
			if (ckSul.Checked)
			{
				text3 = "S";
			}
			string text4 = tbBlocoLayout.Text;
			int num4 = dgBornes.Rows.Count - 1;
			int index = 0;
			if (0 <= num4)
			{
				value = ((Operators.CompareString(tbCodigo1.Text, "0", TextCompare: true) == 0) ? Conversions.ToString(dgBornes.Rows[index].Cells[5].Value) : tbCodigo1.Text);
				text2 = Conversions.ToString(dgBornes.Rows[index].Cells[4].Value);
			}
			int num5 = dgBornes.Rows.Count - 1;
			int num6 = 0;
			while (true)
			{
				if (num6 <= num5 && num6 != dgBornes.Rows.Count - 1)
				{
					string text5 = Conversions.ToString(dgBornes.Rows[num6].Cells[2].Value);
					string text6 = Conversions.ToString(dgBornes.Rows[num6 + 1].Cells[2].Value);
					if (Operators.CompareString(text5, "?", TextCompare: true) == 0)
					{
						text5 = Conversions.ToString(0);
					}
					if (Operators.CompareString(text6, "?", TextCompare: true) == 0)
					{
						text6 = Conversions.ToString(0);
					}
					if (Conversions.ToInteger(text5) <= Conversions.ToInteger(text6))
					{
						num6++;
						continue;
					}
					break;
				}
				int num7 = Conversions.ToInteger(dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[2].Value);
				int num8 = 1;
				DeclaracoesGeral._uscPagina.Quantidade = num7;
				DeclaracoesGeral._uscPagina.pbIniciar();
				List<string> list2 = new List<string>();
				int num9 = dgBornes.Rows.Count - 1;
				for (int j = 0; j <= num9; j++)
				{
					string text7 = Conversions.ToString(dgBornes.Rows[j].Cells[2].Value);
					if (Operators.CompareString(text7, "?", TextCompare: true) == 0)
					{
						text7 = Conversions.ToString(0);
					}
					list2.Add(text7);
				}
				dgBornes.FirstDisplayedScrollingRowIndex = 1;
				int num10 = num7;
				for (int k = 1; k <= num10; k++)
				{
					if (!list2.Contains(k.ToString()))
					{
						num3 = k;
						dgBornes.Rows.Add(pLxphdx8X8q.iRegua, num2, num3, "", text2, Conversions.ToInteger(value), DeclaracoesGeral.mMensagem[1, 1050], "", num3, "", "", "", "", "", "", text3, text4, excBornes.NomeUnico(ref vfcphbxiZf6));
						list.Add(Conversions.ToString(num3));
					}
					if (num7 <= 100)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						continue;
					}
					num8++;
					if (num8 == 10)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num8);
						num8 = 0;
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
				DeclaracoesGeral._uscPagina.Quantidade = dgBornes.Rows.Count;
				DeclaracoesGeral._uscPagina.pbIniciar();
				num8 = 1;
				if (dgBornes.Rows.Count - 1 >= 1)
				{
					int num11 = dgBornes.Rows.Count - 2;
					for (int l = 0; l <= num11; l++)
					{
						int num12 = dgBornes.Rows.Count - 2;
						for (int m = num12; m >= 0; m += -1)
						{
							string text8 = Conversions.ToString(dgBornes.Rows[m].Cells[2].Value);
							string text9 = Conversions.ToString(dgBornes.Rows[m + 1].Cells[2].Value);
							if (Operators.CompareString(text8, "?", TextCompare: true) == 0)
							{
								text8 = Conversions.ToString(0);
							}
							if (Operators.CompareString(text9, "?", TextCompare: true) == 0)
							{
								text9 = Conversions.ToString(0);
							}
							if (Conversions.ToInteger(text8) > Conversions.ToInteger(text9))
							{
								int num13 = dgBornes.ColumnCount - 1;
								for (int n = 0; n <= num13; n++)
								{
									object objectValue = RuntimeHelpers.GetObjectValue(dgBornes.Rows[m].Cells[n].Value);
									dgBornes.Rows[m].Cells[n].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[m + 1].Cells[n].Value);
									dgBornes.Rows[m + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue);
								}
							}
						}
						if (num7 <= 100)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							continue;
						}
						num8++;
						if (num7 <= 1000)
						{
							if (num8 == 10)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num8);
								num8 = 0;
							}
						}
						else if (num8 == 100)
						{
							DeclaracoesGeral._uscPagina.pbPasso(num8);
							num8 = 0;
							System.Windows.Forms.Application.DoEvents();
							dgBornes.FirstDisplayedScrollingRowIndex = l;
						}
					}
				}
				int num14 = dgBornes.Rows.Count - 2;
				for (int num15 = 0; num15 <= num14; num15++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[num15 + 1].Cells[5].Value, 0, TextCompare: true) && Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[num15].Cells[5].Value, 0, TextCompare: true))
					{
						dgBornes.Rows[num15 + 1].Cells[5].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[num15].Cells[5].Value);
					}
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[num15 + 1].Cells[15].Value, "", TextCompare: true) && Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[num15].Cells[15].Value, "", TextCompare: true))
					{
						dgBornes.Rows[num15 + 1].Cells[15].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[num15].Cells[15].Value);
					}
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[num15 + 1].Cells[16].Value, "", TextCompare: true) && Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[num15].Cells[16].Value, "", TextCompare: true))
					{
						dgBornes.Rows[num15 + 1].Cells[16].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[num15].Cells[16].Value);
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
				int num16 = dgBornes.Rows.Count - 1;
				for (int num17 = 0; num17 <= num16; num17++)
				{
					dgBornes.Rows[num17].Cells[1].Value = num17 + 1;
					if (dgBornes.Rows[num17].Selected)
					{
						dgBornes.FirstDisplayedScrollingRowIndex = num17;
					}
				}
				DataGridView dg = dgBornes;
				AtualizaColunasDGBornes(ref dg);
				dgBornes = dg;
				RecuperaExtras();
				btSalvar.Enabled = true;
				break;
			}
		}
	}

	private void LW8pT7oRY6V(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					dgBornes.Rows.RemoveAt(i);
					btSalvar.Enabled = true;
				}
			}
			if (btSalvar.Enabled)
			{
				int num2 = dgBornes.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgBornes.Rows[j].Cells[1].Value = j + 1;
				}
				DataGridView dg = dgBornes;
				ordenarBornesPelaOrdem(ref dg);
				dgBornes = dg;
			}
		}
	}

	private void baspTqYKYAj(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0 || Conversions.ToDouble(tbRecuo.Text) == 0.0)
		{
			return;
		}
		bool flag = false;
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.White;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.LightCoral;
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dgBornes.Rows[i].Cells[2].Style = dataGridViewCellStyle;
			}
			if (CKEdicaoMultiplas.Checked)
			{
				return;
			}
			bool flag2 = false;
			int num2 = dgBornes.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (dgBornes.Rows[j].Selected)
				{
					flag2 = true;
				}
				if (!flag2 || !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgBornes.Rows[j].Cells[2].Value)))
				{
					continue;
				}
				double num3 = Conversions.ToInteger(dgBornes.Rows[j].Cells[2].Value) + Conversions.ToInteger(tbRecuo.Text);
				if (j >= 0)
				{
					if (P4KpTXkfaOM((int)Math.Round(num3), j))
					{
						dgBornes.Rows[j].Cells[2].Value = Conversions.ToString(num3);
						continue;
					}
					flag = true;
					dgBornes.Rows[j].Cells[2].Value = Conversions.ToString(num3);
					dgBornes.Rows[j].Cells[2].Style = dataGridViewCellStyle2;
				}
			}
			if (!flag)
			{
				int num4 = dgBornes.Rows.Count - 1;
				for (int k = 0; k <= num4; k++)
				{
					dgBornes.Rows[k].Cells[8].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[k].Cells[2].Value);
				}
				btSalvar.Enabled = true;
				return;
			}
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1178]), MsgBoxStyle.Information);
			int num5 = dgBornes.Rows.Count - 1;
			for (int l = 0; l <= num5; l++)
			{
				dgBornes.Rows[l].Cells[2].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[l].Cells[8].Value);
				dgBornes.Rows[l].Cells[2].Style = dataGridViewCellStyle;
			}
			btSalvar.Enabled = false;
		}
	}

	private void qmxpTanao3n(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0 || Conversions.ToDouble(tbRecuo.Text) == 0.0)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.White;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.LightCoral;
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dgBornes.Rows[i].Cells[2].Style = dataGridViewCellStyle;
			}
			if (CKEdicaoMultiplas.Checked)
			{
				return;
			}
			bool flag3 = false;
			int num2 = dgBornes.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (dgBornes.Rows[j].Selected)
				{
					flag3 = true;
				}
				if (!flag3 || !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgBornes.Rows[j].Cells[2].Value)))
				{
					continue;
				}
				double num3 = Conversions.ToInteger(dgBornes.Rows[j].Cells[2].Value) - Conversions.ToInteger(tbRecuo.Text);
				if (j >= 0)
				{
					if (P4KpTXkfaOM((int)Math.Round(num3), j))
					{
						dgBornes.Rows[j].Cells[2].Value = Conversions.ToString(num3);
						continue;
					}
					flag = true;
					dgBornes.Rows[j].Cells[2].Value = Conversions.ToString(num3);
					dgBornes.Rows[j].Cells[2].Style = dataGridViewCellStyle2;
				}
			}
			int num4 = dgBornes.Rows.Count - 1;
			for (int k = 0; k <= num4; k++)
			{
				if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgBornes.Rows[k].Cells[2].Value)) && Conversions.ToInteger(dgBornes.Rows[k].Cells[2].Value) < 1)
				{
					flag2 = true;
					dgBornes.Rows[k].Cells[2].Style = dataGridViewCellStyle2;
					dgBornes.Rows[k].Cells[2].Value = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 289]);
				}
			}
			if (!(flag | flag2))
			{
				int num5 = dgBornes.Rows.Count - 1;
				for (int l = 0; l <= num5; l++)
				{
					dgBornes.Rows[l].Cells[8].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[l].Cells[2].Value);
				}
				btSalvar.Enabled = true;
				return;
			}
			string text = "";
			if (flag)
			{
				text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1178]);
			}
			if (flag2)
			{
				if (Operators.CompareString(text, "", TextCompare: true) == 0)
				{
					text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1179]);
				}
				else
				{
					text += "\r\n";
					text = Conversions.ToString(Operators.AddObject(text, DeclaracoesGeral.mMensagem[1, 1179]));
				}
			}
			Interaction.MsgBox(text, MsgBoxStyle.Information);
			int num6 = dgBornes.Rows.Count - 1;
			for (int m = 0; m <= num6; m++)
			{
				dgBornes.Rows[m].Cells[2].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[m].Cells[8].Value);
				dgBornes.Rows[m].Cells[2].Style = dataGridViewCellStyle;
			}
			btSalvar.Enabled = false;
		}
	}

	private void LnXpT86pnWd(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		DeclaracoesEntidades.StructureBorne[] mBornes = new DeclaracoesEntidades.StructureBorne[1];
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = Information.UBound(mBornes) + 1;
				mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num2 + 1]);
				mBornes[num2].Ordem = Conversions.ToDouble(dgBornes.Rows[i].Cells[1].Value);
				mBornes[num2].Numero = Conversions.ToString(dgBornes.Rows[i].Cells[2].Value);
				mBornes[num2].tipo = 0;
				object value = dgBornes.Rows[i].Cells[4].Value;
				if (!Operators.ConditionalCompareObjectEqual(value, "S", TextCompare: true))
				{
					if (!Operators.ConditionalCompareObjectEqual(value, "D", TextCompare: true))
					{
						if (Operators.ConditionalCompareObjectEqual(value, "X", TextCompare: true))
						{
							mBornes[num2].tipo = 2;
						}
					}
					else
					{
						mBornes[num2].tipo = 1;
					}
				}
				else
				{
					mBornes[num2].tipo = 0;
				}
				mBornes[num2].lm = Conversions.ToInteger(dgBornes.Rows[i].Cells[5].Value);
				mBornes[num2].pagina = Conversions.ToString(dgBornes.Rows[i].Cells[6].Value);
				if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(dgBornes.Rows[i].Cells[7].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
				{
					mBornes[num2].Handle = Conversions.ToString(dgBornes.Rows[i].Cells[7].Value);
				}
				else
				{
					mBornes[num2].Handle = Conversions.ToString(dgBornes.Rows[i].Cells[6].Value);
				}
				mBornes[num2].Orientacao = Conversions.ToString(dgBornes.Rows[i].Cells[15].Value);
				mBornes[num2].BlocoLayout = Conversions.ToString(dgBornes.Rows[i].Cells[16].Value);
			}
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, udsphxagTYf))
			{
				ExcFuncoesExcel.LimpaSheet(ref oSheet);
			}
			else
			{
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, udsphxagTYf);
			}
			if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
			{
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
			}
			excBornes.ExportaBornes(ref oSheet, ref mBornes);
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			_ = "B2:D" + Conversions.ToString(ExcFuncoesExcel.BuscaIndiceMaximoUsado(ref oSheet, "A"));
		}
	}

	private void sRypTNv2KVl(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			DataGridView dg = dgBornes;
			formataDgBornes(ref dg);
			dgBornes = dg;
		}
		object obj = null;
		Worksheet oSheet = null;
		DeclaracoesEntidades.StructureBorne[] mBornes = new DeclaracoesEntidades.StructureBorne[1];
		Microsoft.Office.Interop.Excel.Application oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
		bool flag = ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, udsphxagTYf);
		obj = oExcelNew;
		checked
		{
			if (flag)
			{
				if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
				{
					oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
					obj = oExcelNew;
				}
				oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				obj = oExcelNew;
				if (ExisteBornesIguais(ref oSheet))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1228]));
					DeclaracoesGeral._uscPagina.pbFim();
					return;
				}
				excBornes.ImportaBornes(ref oSheet, ref mBornes);
				int num = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true), Operators.CompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))))
					{
						dgBornes.Rows[i].Cells[1].Value = "0";
						dgBornes.Rows[i].Cells[2].Value = "?";
						dgBornes.Rows[i].Cells[4].Value = "S";
						dgBornes.Rows[i].Cells[5].Value = "0";
					}
				}
				int num2 = dgBornes.Rows.Count - 1;
				for (int j = num2; j >= 0; j += -1)
				{
					if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dgBornes.Rows[j].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true), Operators.CompareObjectEqual(dgBornes.Rows[j].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))))
					{
						dgBornes.Rows.RemoveAt(j);
					}
				}
				int num3 = dgBornes.Rows.Count - 1;
				for (int k = num3; k >= 0; k += -1)
				{
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
					{
						dgBornes.Rows.RemoveAt(k);
					}
					int num4 = Information.UBound(mBornes);
					for (int l = num4; l >= 1; l += -1)
					{
						if (Operators.CompareString(mBornes[l].Handle, "", TextCompare: true) != 0 && Operators.ConditionalCompareObjectEqual(dgBornes.Rows[k].Cells[7].Value, mBornes[l].Handle, TextCompare: true))
						{
							dgBornes.Rows[k].Cells[1].Value = mBornes[l].Ordem;
							dgBornes.Rows[k].Cells[2].Value = mBornes[l].Numero;
							dgBornes.Rows[k].Cells[4].Value = "S";
							if (mBornes[l].tipo != 0)
							{
								dgBornes.Rows[k].Cells[4].Value = "D";
							}
							else
							{
								dgBornes.Rows[k].Cells[4].Value = "S";
							}
							dgBornes.Rows[k].Cells[5].Value = mBornes[l].lm;
							dgBornes.Rows[k].Cells[15].Value = mBornes[l].Orientacao;
							dgBornes.Rows[k].Cells[16].Value = mBornes[l].BlocoLayout;
							break;
						}
					}
				}
				int num5 = Information.UBound(mBornes);
				for (int m = num5; m >= 1; m += -1)
				{
					if (Operators.CompareString(mBornes[m].pagina, "", TextCompare: true) != 0)
					{
						string text = mBornes[m].Numero;
						if (Operators.CompareString(mBornes[m].Numero, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)
						{
							text = Conversions.ToString(0);
						}
						if (!Operators.ConditionalCompareObjectEqual(mBornes[m].pagina, DeclaracoesGeral.mMensagem[1, 375], TextCompare: true))
						{
							if (Operators.ConditionalCompareObjectEqual(mBornes[m].pagina, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
							{
								dgBornes.Rows.Add(pLxphdx8X8q.iRegua, mBornes[m].Ordem, text, "", "X", mBornes[m].lm, DeclaracoesGeral.mMensagem[1, 1890], "", text, "", "", "", "", "", "", "", mBornes[m].BlocoLayout, excBornes.NomeUnico(ref vfcphbxiZf6));
							}
						}
						else
						{
							dgBornes.Rows.Add(pLxphdx8X8q.iRegua, mBornes[m].Ordem, text, "", "S", mBornes[m].lm, DeclaracoesGeral.mMensagem[1, 1050], "", text, "", "", "", "", "", "", mBornes[m].Orientacao, mBornes[m].BlocoLayout, excBornes.NomeUnico(ref vfcphbxiZf6));
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DataGridView dg = dgBornes;
				AtualizaColunasDGBornes(ref dg);
				dgBornes = dg;
				ColocaNaOrdem();
				btSalvar.Enabled = true;
				BtNumerar.Enabled = false;
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	private void N13pTFnReVm(object P_0, EventArgs P_1)
	{
		GuardaPosicaoPainel();
		MoveExtras();
		string left = verificaTipoDosBornes();
		if (Operators.CompareString(left, "N", TextCompare: true) != 0)
		{
			if (Operators.CompareString(left, "NL", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "A", TextCompare: true) == 0)
				{
					OrdenarAZ();
				}
			}
			else
			{
				OrdenarNumAZ();
			}
		}
		else
		{
			OrdenarAZ();
		}
		RecuperaExtras();
		RecuperaPosicaoPainel();
		btSalvar.Enabled = true;
	}

	public string verificaTipoDosBornes()
	{
		string text = "N";
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(dgBornes.Rows[i].Cells[2].Value)), "", TextCompare: true) == 0)
				{
					dgBornes.Rows[i].Cells[2].Value = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					btSalvar.Enabled = true;
				}
				string text2 = dgBornes.Rows[i].Cells[2].Value.ToString().ToUpper();
				if (Operators.CompareString(text2, "?", TextCompare: true) == 0)
				{
					text2 = Conversions.ToString(0);
				}
				if (Versioned.IsNumeric(text2))
				{
					continue;
				}
				string expression = Strings.Mid(text2, 1, Strings.Len(text2) - 1);
				if (Versioned.IsNumeric(expression) & (Operators.CompareString(text, "A", TextCompare: true) != 0))
				{
					string text3 = Strings.Mid(text2, Strings.Len(text2), 1);
					if ((((Strings.Asc(text3) >= 48) & (Strings.Asc(text3) <= 57)) | ((Strings.Asc(text3) >= 65) & (Strings.Asc(text3) <= 90))) & (Operators.CompareString(text, "A", TextCompare: true) != 0))
					{
						text = "NL";
					}
				}
				if (!Versioned.IsNumeric(Strings.Mid(text2, 1, Strings.Len(text2) - 1)) & !Versioned.IsNumeric(Strings.Mid(text2, Strings.Len(text2), 1)))
				{
					text = "A";
				}
			}
			if (Operators.CompareString(text, "N", TextCompare: true) != 0)
			{
				w8dpBZ0kvSD().SetToolTip(btOrdenarAZ, Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], ": 1, 2, 2A, 2B, 3, A, A1, A2, AA ...")));
			}
			else
			{
				w8dpBZ0kvSD().SetToolTip(btOrdenarAZ, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1199]));
			}
			return text;
		}
	}

	public void OrdenarAZ()
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		bool flag = false;
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = dgBornes.Rows.Count * 3;
			DeclaracoesGeral._uscPagina.pbIniciar();
			if (dgBornes.Rows.Count - 1 >= 1)
			{
				int num = dgBornes.Rows.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					int num2 = dgBornes.Rows.Count - 2;
					for (int j = num2; j >= 0; j += -1)
					{
						string text = Conversions.ToString(dgBornes.Rows[j].Cells[2].Value);
						string text2 = Conversions.ToString(dgBornes.Rows[j + 1].Cells[2].Value);
						if (Operators.CompareString(text, "?", TextCompare: true) == 0)
						{
							text = Conversions.ToString(0);
						}
						if (Operators.CompareString(text2, "?", TextCompare: true) == 0)
						{
							text2 = Conversions.ToString(0);
						}
						if (!(Versioned.IsNumeric(text) & Versioned.IsNumeric(text2)))
						{
							if (Operators.CompareString(text, text2, TextCompare: true) > 0)
							{
								int num3 = dgBornes.ColumnCount - 1;
								for (int k = 0; k <= num3; k++)
								{
									object objectValue = RuntimeHelpers.GetObjectValue(dgBornes.Rows[j].Cells[k].Value);
									dgBornes.Rows[j].Cells[k].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[j + 1].Cells[k].Value);
									dgBornes.Rows[j + 1].Cells[k].Value = RuntimeHelpers.GetObjectValue(objectValue);
									flag = true;
								}
							}
						}
						else if (Conversions.ToDouble(text) > Conversions.ToDouble(text2))
						{
							int num4 = dgBornes.ColumnCount - 1;
							for (int l = 0; l <= num4; l++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dgBornes.Rows[j].Cells[l].Value);
								dgBornes.Rows[j].Cells[l].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[j + 1].Cells[l].Value);
								dgBornes.Rows[j + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue2);
								flag = true;
							}
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
			}
			int num5 = dgBornes.Rows.Count - 1;
			for (int m = 0; m <= num5; m++)
			{
				dgBornes.Rows[m].Cells[1].Value = m + 1;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			if (flag)
			{
				btSalvar.Enabled = true;
			}
		}
	}

	public void OrdenarNumAZ()
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		bool flag = false;
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = dgBornes.Rows.Count * 3;
			DeclaracoesGeral._uscPagina.pbIniciar();
			if (dgBornes.Rows.Count - 1 >= 1)
			{
				int num = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = Conversions.ToString(dgBornes.Rows[i].Cells[2].Value);
					if (!(Versioned.IsNumeric(Strings.Mid(text, 1, text.Length - 1)) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) <= 90)))
					{
						if (!(Versioned.IsNumeric(Strings.Mid(text, 1, text.Length - 1)) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) >= 97) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) <= 122)))
						{
							dgBornes.Rows[i].Cells[1].Value = text;
							continue;
						}
						double num2 = Conversions.ToDouble(Strings.Mid(text, 1, text.Length - 1));
						text = text.ToUpper();
						num2 += (double)Strings.Asc(Strings.Mid(text, text.Length, 1)) / 101.0;
						dgBornes.Rows[i].Cells[1].Value = num2;
					}
					else
					{
						double num3 = Conversions.ToDouble(Strings.Mid(text, 1, text.Length - 1));
						num3 += (double)Strings.Asc(Strings.Mid(text, text.Length, 1)) / 100.0;
						dgBornes.Rows[i].Cells[1].Value = num3;
					}
				}
				int num4 = dgBornes.Rows.Count - 2;
				for (int j = 0; j <= num4; j++)
				{
					int num5 = dgBornes.Rows.Count - 2;
					for (int k = num5; k >= 0; k += -1)
					{
						string text2 = dgBornes.Rows[k].Cells[1].Value.ToString().ToUpper();
						string text3 = dgBornes.Rows[k + 1].Cells[1].Value.ToString().ToUpper();
						if (Operators.CompareString(text2, "?", TextCompare: true) == 0)
						{
							text2 = Conversions.ToString(0);
						}
						if (Operators.CompareString(text3, "?", TextCompare: true) == 0)
						{
							text3 = Conversions.ToString(0);
						}
						if (!(Versioned.IsNumeric(text2) & Versioned.IsNumeric(text3)))
						{
							if (Operators.CompareString(text2, text3, TextCompare: true) > 0)
							{
								int num6 = dgBornes.ColumnCount - 1;
								for (int l = 0; l <= num6; l++)
								{
									object objectValue = RuntimeHelpers.GetObjectValue(dgBornes.Rows[k].Cells[l].Value);
									dgBornes.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[k + 1].Cells[l].Value);
									dgBornes.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
									flag = true;
								}
							}
						}
						else if (Conversions.ToDouble(text2) > Conversions.ToDouble(text3))
						{
							int num7 = dgBornes.ColumnCount - 1;
							for (int m = 0; m <= num7; m++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dgBornes.Rows[k].Cells[m].Value);
								dgBornes.Rows[k].Cells[m].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[k + 1].Cells[m].Value);
								dgBornes.Rows[k + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue2);
								flag = true;
							}
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
			}
			int num8 = dgBornes.Rows.Count - 1;
			for (int n = 0; n <= num8; n++)
			{
				dgBornes.Rows[n].Cells[1].Value = n + 1;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			if (flag)
			{
				btSalvar.Enabled = true;
			}
		}
	}

	public void ColocaNaOrdem()
	{
		checked
		{
			if (dgBornes.Rows.Count == 0 || dgBornes.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = dgBornes.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = dgBornes.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					string text = Conversions.ToString(dgBornes.Rows[j].Cells[1].Value);
					string text2 = Conversions.ToString(dgBornes.Rows[j + 1].Cells[1].Value);
					if ((Versioned.IsNumeric(text) & Versioned.IsNumeric(text2)) && Conversions.ToDouble(text) > Conversions.ToDouble(text2))
					{
						int num3 = dgBornes.ColumnCount - 1;
						for (int k = 0; k <= num3; k++)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dgBornes.Rows[j].Cells[k].Value);
							dgBornes.Rows[j].Cells[k].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[j + 1].Cells[k].Value);
							dgBornes.Rows[j + 1].Cells[k].Value = RuntimeHelpers.GetObjectValue(objectValue);
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
		}
	}

	private void jFUpTQdR02S(object P_0, EventArgs P_1)
	{
		y0hphw4tbHT = true;
		MoveExtras();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		int num = 1;
		checked
		{
			DataGridView dg;
			if (RB_Todos.Checked)
			{
				dg = dgBornes;
				MoveReservasParaOFinal(ref dg);
				dgBornes = dg;
				num = 1;
				if (RB_PCL.Checked)
				{
					dg = dgBornes;
					OrdenaPCL(ref dg);
					dgBornes = dg;
				}
				if (RB_PLC.Checked)
				{
					dg = dgBornes;
					OrdenaPLC(ref dg);
					dgBornes = dg;
				}
				if (RB_POT_CL.Checked)
				{
					clsBornes.mBornes[] mBornes = null;
					dg = dgBornes;
					clsBornes.OrdenaReguaDeBornesPorPotencial(ref dg, ref mBornes, "LC");
					dgBornes = dg;
					dg = dgBornes;
					AtualizaColunasDGBornes(ref dg);
					dgBornes = dg;
				}
				if (RB_POT_LC.Checked)
				{
					clsBornes.mBornes[] mBornes2 = null;
					dg = dgBornes;
					clsBornes.OrdenaReguaDeBornesPorPotencial(ref dg, ref mBornes2, "CL");
					dgBornes = dg;
					dg = dgBornes;
					AtualizaColunasDGBornes(ref dg);
					dgBornes = dg;
				}
				if (RB_PG_POT_CL.Checked)
				{
					clsBornes.mBornes[] mBornes3 = null;
					dg = dgBornes;
					clsBornes.OrdenaReguaDeBornesPorPGPotencial(ref dg, ref mBornes3, "LC");
					dgBornes = dg;
					dg = dgBornes;
					AtualizaColunasDGBornes(ref dg);
					dgBornes = dg;
				}
				if (RB_PG_POT_LC.Checked)
				{
					clsBornes.mBornes[] mBornes4 = null;
					dg = dgBornes;
					clsBornes.OrdenaReguaDeBornesPorPGPotencial(ref dg, ref mBornes4, "CL");
					dgBornes = dg;
					dg = dgBornes;
					AtualizaColunasDGBornes(ref dg);
					dgBornes = dg;
				}
				if (RB_INT_PCV.Checked)
				{
					dg = dgBornes;
					cDadosAccessInterligacao3.OrdenaINTERLIG_Tudo(ref dg, QCXphjEHtXO, pLxphdx8X8q.iPainel);
					dgBornes = dg;
				}
				dg = dgBornes;
				MoveReservasParaOFinal(ref dg);
				dgBornes = dg;
				int num2 = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.CompareString(dgBornes.Rows[i].Cells[1].Value.ToString(), num.ToString(), TextCompare: true) != 0)
					{
						dgBornes.Rows[i].Cells[1].Value = num;
					}
					if (Operators.CompareString(dgBornes.Rows[i].Cells[2].Value.ToString(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido.ToString(), TextCompare: true) == 0)
					{
						dgBornes.Rows[i].Cells[2].Value = 0;
					}
					if (Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[i].Cells[2].Value, num.ToString(), TextCompare: true))
					{
						dgBornes.Rows[i].Cells[2].Value = num;
					}
					num++;
				}
			}
			if (RB_IndefinidosFinal.Checked)
			{
				double Ordem = 0.0;
				dg = dgBornes;
				int num3 = EncontraUltimoBorneReal_MaisUM(ref dg, ref Ordem);
				dgBornes = dg;
				num = num3;
				if (RB_PCL.Checked)
				{
					dg = dgBornes;
					OrdenaPCL_Indefinidos(ref dg, Ordem, num);
					dgBornes = dg;
				}
				if (RB_PLC.Checked)
				{
					dg = dgBornes;
					OrdenaPLC_Indefinidos(ref dg, Ordem, num);
					dgBornes = dg;
				}
				if (RB_POT_CL.Checked)
				{
					dg = dgBornes;
					OrdenaPCLPot_Indefinidos(ref dg, Ordem, num);
					dgBornes = dg;
				}
				if (RB_POT_LC.Checked)
				{
					dg = dgBornes;
					OrdenaPLCPot_Indefinidos(ref dg, Ordem, num);
					dgBornes = dg;
				}
				if (RB_PG_POT_CL.Checked)
				{
					dg = dgBornes;
					OrdenaPCLPot_Indefinidos(ref dg, Ordem, num);
					dgBornes = dg;
				}
				if (RB_PG_POT_LC.Checked)
				{
					dg = dgBornes;
					OrdenaPLCPot_Indefinidos(ref dg, Ordem, num);
					dgBornes = dg;
				}
				if (RB_INT_PCV.Checked)
				{
					dg = dgBornes;
					cDadosAccessInterligacao3.OrdenaINTERLIG_Indefinidos(ref dg, Ordem, num, QCXphjEHtXO, pLxphdx8X8q.iPainel);
					dgBornes = dg;
				}
				int num4 = dgBornes.Rows.Count - 1;
				int num5 = 0;
				while (true)
				{
					if (num5 <= num4)
					{
						if (clsBornes.BorneNumericoValido(Conversions.ToString(dgBornes.Rows[num5].Cells[2].Value)) == 0.0)
						{
							break;
						}
						num5++;
						continue;
					}
					OrdenarAZ();
					break;
				}
			}
			dg = dgBornes;
			ordenarBornesPelaOrdem(ref dg);
			dgBornes = dg;
			if (RB_IndefinidosFinal.Checked)
			{
				RB_IndefinidosFinal.Checked = false;
				RB_IndefinidosFinal.Checked = true;
			}
			btSalvar.Enabled = true;
			cDadosAccessInterligacao3.FechaConexao();
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num6 = dgBornes.Rows.Count - 1;
			for (int j = 0; j <= num6; j++)
			{
				if (list.Contains(Conversions.ToString(dgBornes.Rows[j].Cells[2].Value)))
				{
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[j].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
					{
						list2.Add(Conversions.ToString(j));
					}
				}
				else
				{
					list.Add(Conversions.ToString(dgBornes.Rows[j].Cells[2].Value));
				}
			}
			int num7 = list2.Count - 1;
			for (int k = num7; k >= 0; k += -1)
			{
				dgBornes.Rows.RemoveAt(Conversions.ToInteger(list2[k]));
			}
			RecuperaExtras();
			verificaTipoDosBornes();
		}
	}

	public void MoveExtras()
	{
		double num = -1000.0;
		double num2 = 0.0;
		DataGridView dg = dgBornesExtra;
		formataDgBornes(ref dg);
		dgBornesExtra = dg;
		checked
		{
			int num3 = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (Operators.CompareString(dgBornes.Rows[i].Cells[2].Value.ToString(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)
				{
					continue;
				}
				if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(i != 0, Operators.CompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true)), num2 == 0.0)))
				{
					num2 = 9000000.0;
				}
				if (!Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					num = Conversions.ToDouble(Operators.AddObject(dgBornes.Rows[i].Cells[1].Value, 1));
					if (dgBornes.Rows.Count > 2 && i + 1 == dgBornes.Rows.Count - 1 && Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i + 1].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
					{
						num += 9000000.0;
					}
					continue;
				}
				dgBornesExtra.Rows.Add("");
				int num4 = dgBornes.ColumnCount - 1;
				for (int j = 0; j <= num4; j++)
				{
					dgBornesExtra.Rows[dgBornesExtra.Rows.Count - 1].Cells[j].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[i].Cells[j].Value);
				}
				if (!(num < 0.0))
				{
					dgBornesExtra.Rows[dgBornesExtra.RowCount - 1].Cells[1].Value = num - 1.0 + 0.5 + num2;
					num = Conversions.ToDouble(Operators.AddObject(num, Operators.AddObject(dgBornesExtra.Rows[dgBornesExtra.RowCount - 1].Cells[1].Value, 0.5)));
				}
				else
				{
					dgBornesExtra.Rows[dgBornesExtra.RowCount - 1].Cells[1].Value = num + num2;
					num++;
				}
			}
			dg = dgBornesExtra;
			AtualizaColunasDGBornes(ref dg);
			dgBornesExtra = dg;
			int num5 = dgBornes.Rows.Count - 1;
			for (int k = num5; k >= 0; k += -1)
			{
				if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					dgBornes.Rows.RemoveAt(k);
				}
			}
			dg = dgBornesExtra;
			AtualizaColunasDGBornes(ref dg);
			dgBornesExtra = dg;
			int num6 = dgBornes.Rows.Count - 1;
			for (int l = 0; l <= num6; l++)
			{
				dgBornes.Rows[l].Selected = false;
			}
		}
	}

	public void RecuperaExtras()
	{
		checked
		{
			int num = dgBornesExtra.Rows.Count - 1;
			DataGridView dg;
			for (int i = 0; i <= num; i++)
			{
				dgBornes.Rows.Add("");
				int num2 = dgBornesExtra.ColumnCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[j].Value = RuntimeHelpers.GetObjectValue(dgBornesExtra.Rows[i].Cells[j].Value);
				}
				dg = dgBornes;
				ordenarBornesPelaOrdem(ref dg);
				dgBornes = dg;
				int num3 = dgBornes.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					dgBornes.Rows[k].Cells[1].Value = k + 1;
				}
				dg = dgBornes;
				ordenarBornesPelaOrdem(ref dg);
				dgBornes = dg;
			}
			dg = dgBornesExtra;
			formataDgBornes(ref dg);
			dgBornesExtra = dg;
			dg = dgBornes;
			AtualizaColunasDGBornes(ref dg);
			dgBornes = dg;
		}
	}

	private void NeSpTPajwhg(object P_0, EventArgs P_1)
	{
		GuardaPosicaoPainel();
		y0hphw4tbHT = true;
		SalvarAlteracoes();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		TBPesquisa.Enabled = true;
		TBPesquisa.Focus();
		BtNumerar.Enabled = true;
		RecuperaPosicaoPainel();
	}

	public void GuardaPosicaoPainel()
	{
		checked
		{
			int num = dgReguas.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgReguas.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			AlOphM2M7b2 = Conversions.ToInteger(dgReguas.Rows[num2].Cells[0].Value);
			pcAphO3XWWQ = Conversions.ToInteger(dgReguas.Rows[num2].Cells[2].Value);
		}
	}

	public void RecuperaPosicaoPainel()
	{
		checked
		{
			int num = dgReguas.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(AlOphM2M7b2, dgReguas.Rows[num2].Cells[0].Value, TextCompare: true), Operators.CompareObjectEqual(pcAphO3XWWQ, dgReguas.Rows[num2].Cells[2].Value, TextCompare: true))))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			dgReguas.Rows[num2].Selected = true;
		}
	}

	private void vdGpTcMrMZg(object P_0, DataGridViewCellEventArgs P_1)
	{
		string text = "";
		text = Conversions.ToString(dgBornes.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
		bool flag = false;
		if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[P_1.RowIndex].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
		{
			flag = true;
		}
		if (text == null)
		{
			text = "";
		}
		if (Strings.Len(text) > 10)
		{
			text = Conversions.ToString(dgBornes.Rows[P_1.RowIndex].Cells[8].Value);
			dgBornes.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value = text;
		}
		text = text.Trim();
		if ((Operators.CompareString(text.ToString(), "0", TextCompare: true) == 0) | (Operators.CompareString(text.ToString(), "?", TextCompare: true) == 0))
		{
			text = "?";
			dgBornes.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value = "?";
		}
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (((Operators.CompareString(dgBornes.Rows[i].Cells[2].Value.ToString(), text.ToString(), TextCompare: true) == 0) & (P_1.RowIndex != i)) && !((Operators.CompareString(text.ToString(), "0", TextCompare: true) == 0) | (Operators.CompareString(text.ToString(), "?", TextCompare: true) == 0)))
				{
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[6].Value.ToString(), DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
					{
						int num2 = 2;
						do
						{
							if ((num2 != 4) & (num2 != 5))
							{
								dgBornes.Rows[i].Cells[num2].Value = RuntimeHelpers.GetObjectValue(dgBornes.Rows[P_1.RowIndex].Cells[num2].Value);
							}
							num2++;
						}
						while (num2 <= 14);
						dgBornes.Rows.RemoveAt(P_1.RowIndex);
						btSalvar.Enabled = true;
						break;
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dgBornes.Rows[i].Cells[6].Value.ToString(), DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true), flag)))
					{
						btSalvar.Enabled = true;
						break;
					}
					dgBornes.Rows[P_1.RowIndex].Cells[2].Value = dgBornes.Rows[P_1.RowIndex].Cells[8].Value.ToString();
					MessageBox.Show(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1047]), "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				if (P_1.RowIndex == i && Operators.CompareString(dgBornes.Rows[i].Cells[2].Value.ToString(), dgBornes.Rows[i].Cells[8].Value.ToString(), TextCompare: true) != 0)
				{
					btSalvar.Enabled = true;
				}
			}
		}
	}

	private void wjGpTKcuHAM(object P_0, KeyEventArgs P_1)
	{
		try
		{
			if (P_1.KeyCode != Keys.Insert)
			{
				if (P_1.KeyCode == Keys.Delete && y0hphw4tbHT)
				{
					y0hphw4tbHT = false;
					if (dgBornes.Rows.Count > 0)
					{
						YhGpT2RXFdF();
					}
					if (dgBornes.Rows.Count == 0)
					{
						dgBornes.Rows.Clear();
						dgBornes.Columns.Clear();
					}
					y0hphw4tbHT = true;
				}
			}
			else if (y0hphw4tbHT)
			{
				y0hphw4tbHT = false;
				if (!CKEdicaoMultiplas.Checked)
				{
					if (dgBornes.Rows.Count == 0)
					{
						DataGridView dg = dgBornes;
						formataDgBornes(ref dg);
						dgBornes = dg;
					}
					I5TpTeQpF5A();
				}
				y0hphw4tbHT = true;
			}
			if ((P_1.KeyCode > Keys.Delete) | (P_1.KeyCode < Keys.Insert))
			{
				y0hphw4tbHT = true;
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

	private void I5TpTeQpF5A()
	{
		string right = "";
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		string right2 = "";
		string right3 = "";
		checked
		{
			DataGridView dg;
			if (dgBornes.Rows.Count > 0)
			{
				right = Conversions.ToString(dgBornes.SelectedRows[0].Cells[2].Value);
				MoveExtras();
				int num = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[2].Value, right, TextCompare: true))
					{
						dgBornes.Rows[i].Selected = true;
						break;
					}
				}
				dg = dgBornes;
				AtualizaColunasDGBornes(ref dg);
				dgBornes = dg;
			}
			try
			{
				double Ordem = 0.0;
				string text = Conversions.ToString(0);
				string text2 = "S";
				int num2 = 0;
				int index = 0;
				int num3 = 0;
				bool flag4 = false;
				string value = "0";
				int num4 = 1;
				string text3 = "";
				if (ckNorte.Checked)
				{
					text3 = "N";
				}
				if (ckSul.Checked)
				{
					text3 = "S";
				}
				string text4 = tbBlocoLayout.Text;
				if (CKEdicaoMultiplas.Checked)
				{
					goto IL_00a1;
				}
				if (dgBornes.Rows.Count == 0)
				{
					text = Conversions.ToString(0);
					flag4 = true;
					goto IL_00a1;
				}
				int num5 = dgBornes.Rows.Count - 1;
				int num6 = 0;
				while (true)
				{
					if (num6 <= num5)
					{
						if (Operators.ConditionalCompareObjectNotEqual(text4, dgBornes.Rows[num6].Cells[16].Value, TextCompare: true))
						{
							text4 = Conversions.ToString(dgBornes.Rows[num6].Cells[16].Value);
						}
						if (!dgBornes.Rows[num6].Selected)
						{
							num6++;
							continue;
						}
						index = num6;
						if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgBornes.Rows[num6].Cells[2].Value)))
						{
							if (num6 == dgBornes.Rows.Count - 1)
							{
								int num7 = dgBornes.Rows.Count - 1;
								for (int j = 0; j <= num7; j++)
								{
									if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgBornes.Rows[j].Cells[2].Value)) && Operators.ConditionalCompareObjectLess(num4, dgBornes.Rows[j].Cells[2].Value, TextCompare: true))
									{
										num4 = Conversions.ToInteger(dgBornes.Rows[j].Cells[2].Value) + 1;
									}
								}
								goto IL_024e;
							}
							if (dgBornes.Rows.Count > 1)
							{
								right2 = Conversions.ToString(dgBornes.Rows[num6].Cells[2].Value);
								right3 = Conversions.ToString(dgBornes.Rows[num6 + 1].Cells[2].Value);
								flag = true;
								break;
							}
						}
						Ordem = Conversions.ToDouble(Operators.AddObject(dgBornes.Rows[index].Cells[1].Value, 0.5));
						if (num6 + 1 <= dgBornes.Rows.Count - 1)
						{
							num3 = num6 + 1;
							if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgBornes.Rows[num3].Cells[2].Value)))
							{
								right2 = Conversions.ToString(dgBornes.Rows[num6].Cells[2].Value);
								right3 = Conversions.ToString(dgBornes.Rows[num6 + 1].Cells[2].Value);
								flag2 = true;
								break;
							}
						}
					}
					goto IL_024e;
					IL_024e:
					if (num4 != 1)
					{
						text = Conversions.ToString(num4);
					}
					else
					{
						text = Conversions.ToString(dgBornes.Rows[index].Cells[2].Value);
						right = text;
					}
					if (num3 == 0)
					{
						flag4 = false;
					}
					else
					{
						num2 = Conversions.ToInteger(dgBornes.Rows[num3].Cells[2].Value);
						if ((Versioned.IsNumeric(text) & Versioned.IsNumeric(num2)) && (((double)Conversions.ToInteger(text) == Conversions.ToDouble(text)) & ((double)num2 == (double)num2)))
						{
							if (Conversions.ToDouble(text) + 1.0 == (double)num2)
							{
								flag4 = false;
								flag3 = true;
								break;
							}
							flag4 = true;
						}
					}
					goto IL_00a1;
				}
				goto end_IL_0033;
				IL_00a1:
				int num8 = dgBornes.Rows.Count - 1;
				for (int k = 0; k <= num8; k++)
				{
					if (dgBornes.Rows[k].Selected)
					{
						value = ((Operators.CompareString(tbCodigo1.Text, "0", TextCompare: true) == 0) ? Conversions.ToString(dgBornes.Rows[k].Cells[5].Value) : tbCodigo1.Text);
						text2 = Conversions.ToString(dgBornes.Rows[k].Cells[4].Value);
						break;
					}
				}
				if (!flag4)
				{
					if (Versioned.IsNumeric(text))
					{
						dg = dgBornes;
						int iMax = Conversions.ToInteger(text);
						ProximoBorneReserva(ref dg, ref iMax, ref Ordem);
						text = Conversions.ToString(iMax);
						dgBornes = dg;
						int num9 = dgBornes.Rows.Count - 1;
						for (int l = 0; l <= num9; l++)
						{
							if (dgBornes.Rows[l].Selected)
							{
								index = l;
							}
						}
						dgBornes.Rows.Add(pLxphdx8X8q.iRegua, Ordem, text, "", text2, Conversions.ToInteger(value), DeclaracoesGeral.mMensagem[1, 1050], "", text, "", "", "", "", "", "", text3, text4, excBornes.NomeUnico(ref vfcphbxiZf6));
						right = text;
						dg = dgBornes;
						AtualizaColunasDGBornes(ref dg);
						dgBornes = dg;
						index = dgBornes.Rows.Count - 1;
						dgBornes.Rows[index].Selected = true;
						dgBornes.FirstDisplayedScrollingRowIndex = index;
						btSalvar.Enabled = true;
					}
				}
				else
				{
					text = Conversions.ToString(Conversions.ToInteger(text) + 1);
					dgBornes.Rows.Add(pLxphdx8X8q.iRegua, Ordem, text, "", text2, Conversions.ToInteger(value), DeclaracoesGeral.mMensagem[1, 1050], "", text, "", "", "", "", "", "", text3, text4, excBornes.NomeUnico(ref vfcphbxiZf6));
					right = text;
					if (dgBornes.Rows.Count - 1 >= 1)
					{
						dg = dgBornes;
						ordenarBornesPelaOrdem(ref dg);
						dgBornes = dg;
						int num10 = dgBornes.Rows.Count - 1;
						for (int m = 0; m <= num10; m++)
						{
							dgBornes.Rows[m].Cells[1].Value = m + 1;
						}
					}
					dg = dgBornes;
					AtualizaColunasDGBornes(ref dg);
					dgBornes = dg;
					btSalvar.Enabled = true;
					dgBornes.Rows[num3].Selected = true;
					if (num3 <= 10)
					{
						dgBornes.FirstDisplayedScrollingRowIndex = 0;
					}
					else
					{
						dgBornes.FirstDisplayedScrollingRowIndex = num3 - 10;
					}
				}
				end_IL_0033:;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			if (dgBornes.Rows.Count > 0)
			{
				RecuperaExtras();
			}
			int num11 = dgBornes.Rows.Count - 1;
			for (int n = 0; n <= num11; n++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[n].Cells[2].Value, right, TextCompare: true))
				{
					dgBornes.Rows[n].Selected = true;
					break;
				}
			}
			dg = dgBornes;
			AtualizaColunasDGBornes(ref dg);
			dgBornes = dg;
			if (flag)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1335], right2), " "), DeclaracoesGeral.mMensagem[1, 137].ToString().ToLower()), " "), right3), MsgBoxStyle.Information);
			}
			if (flag2)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1335], right2), " "), DeclaracoesGeral.mMensagem[1, 137].ToString().ToLower()), " "), right3), MsgBoxStyle.Information);
			}
			if (flag3)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1333]), MsgBoxStyle.Information);
			}
		}
	}

	private void YhGpT2RXFdF()
	{
		checked
		{
			try
			{
				if (dgBornes.SelectedRows.Count <= 0 || !Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dgBornes.SelectedRows[0].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true), Operators.CompareObjectEqual(dgBornes.SelectedRows[0].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))))
				{
					return;
				}
				List<int> list = new List<int>();
				int num = dgBornes.Rows.Count - 1;
				for (int i = num; i >= 0; i += -1)
				{
					if (dgBornes.Rows[i].Selected)
					{
						list.Add(i);
					}
				}
				int num2 = list.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgBornes.Rows.RemoveAt(list[j]);
				}
				int num3 = dgBornes.Rows.Count - 1;
				for (int k = num3; k >= 0; k += -1)
				{
					if (dgBornes.Rows[k].Selected)
					{
						if (k <= 10)
						{
							dgBornes.FirstDisplayedScrollingRowIndex = 0;
						}
						else
						{
							dgBornes.FirstDisplayedScrollingRowIndex = k - 10;
						}
					}
				}
				DataGridView dg = dgBornes;
				AtualizaColunasDGBornes(ref dg);
				dgBornes = dg;
				btSalvar.Enabled = true;
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

	public static void ProximoBorneReserva(ref DataGridView dg, ref int iMax, ref double Ordem)
	{
		iMax = 0;
		Ordem = 0.0;
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = Conversions.ToString(dg.Rows[i].Cells[2].Value);
				if (Versioned.IsNumeric(text))
				{
					double num2 = Conversions.ToInteger(text);
					if ((double)iMax < num2)
					{
						iMax = (int)Math.Round(num2);
					}
					Ordem = Conversions.ToDouble(dg.Rows[i].Cells[1].Value);
				}
			}
			iMax++;
			Ordem++;
		}
	}

	public static int EncontraUltimoBorneReal_MaisUM(ref DataGridView dg, ref double Ordem)
	{
		int num = 0;
		Ordem = 0.0;
		int num2 = 0;
		checked
		{
			int num3 = dg.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dg.Rows[i].Cells[6].Value.ToString(), DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true), Operators.CompareObjectNotEqual(dg.Rows[i].Cells[6].Value.ToString(), DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))))
				{
					string text = Conversions.ToString(dg.Rows[i].Cells[2].Value);
					if (Versioned.IsNumeric(text))
					{
						double num4 = Conversions.ToInteger(text);
						if ((double)num < num4)
						{
							num = (int)Math.Round(num4);
						}
					}
					if (Operators.ConditionalCompareObjectLess(Ordem, dg.Rows[i].Cells[1].Value, TextCompare: true))
					{
						Ordem = Conversions.ToDouble(dg.Rows[i].Cells[1].Value);
					}
				}
				if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					num2++;
				}
			}
			num++;
			Ordem = Ordem + (double)num2 + 1.0;
			return num;
		}
	}

	public static void OrdenaPCL(ref DataGridView dg)
	{
		int index = 9;
		int index2 = 10;
		int index3 = 11;
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num3 = dg.Rows.Count - 2 - num;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = dg.Rows.Count - 2 - num;
					for (int k = num4; k >= 0; k += -1)
					{
						if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							continue;
						}
						double num5 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k].Cells[index].Value));
						double num6 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k + 1].Cells[index].Value));
						if (num5 > num6)
						{
							int num7 = dg.ColumnCount - 1;
							for (int l = 0; l <= num7; l++)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[l].Value);
								dg.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[l].Value);
								dg.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectGreater(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true))
						{
							int num8 = dg.ColumnCount - 1;
							for (int m = 0; m <= num8; m++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[m].Value);
								dg.Rows[k].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[m].Value);
								dg.Rows[k + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectEqual(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true) && Operators.ConditionalCompareObjectLess(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true))
						{
							int num9 = dg.ColumnCount - 1;
							for (int n = 0; n <= num9; n++)
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[n].Value);
								dg.Rows[k].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[n].Value);
								dg.Rows[k + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							}
						}
					}
				}
			}
			int num10 = dg.Rows.Count - 1;
			for (int num11 = 0; num11 <= num10; num11++)
			{
				dg.Rows[num11].Cells[1].Value = num11 + 1;
			}
		}
	}

	public static void OrdenaPLC(ref DataGridView dg)
	{
		int index = 9;
		int index2 = 10;
		int index3 = 11;
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num3 = dg.Rows.Count - 2 - num;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = dg.Rows.Count - 2 - num;
					for (int k = num4; k >= 0; k += -1)
					{
						if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							continue;
						}
						double num5 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k].Cells[index].Value));
						double num6 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k + 1].Cells[index].Value));
						if (num5 > num6)
						{
							int num7 = dg.ColumnCount - 1;
							for (int l = 0; l <= num7; l++)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[l].Value);
								dg.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[l].Value);
								dg.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectLess(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true))
						{
							int num8 = dg.ColumnCount - 1;
							for (int m = 0; m <= num8; m++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[m].Value);
								dg.Rows[k].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[m].Value);
								dg.Rows[k + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectEqual(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true))
						{
							int num9 = dg.ColumnCount - 1;
							for (int n = 0; n <= num9; n++)
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[n].Value);
								dg.Rows[k].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[n].Value);
								dg.Rows[k + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							}
						}
					}
				}
			}
			int num10 = dg.Rows.Count - 1;
			for (int num11 = 0; num11 <= num10; num11++)
			{
				dg.Rows[num11].Cells[1].Value = num11 + 1;
			}
		}
	}

	public static void OrdenaPCL_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
		int index = 9;
		int index2 = 10;
		int index3 = 11;
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					num++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num3 = num;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = num - 1;
					for (int k = num4; k >= 0; k += -1)
					{
						if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							continue;
						}
						double num5 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k].Cells[index].Value));
						double num6 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k + 1].Cells[index].Value));
						if (num5 > num6)
						{
							int num7 = dg.ColumnCount - 1;
							for (int l = 0; l <= num7; l++)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[l].Value);
								dg.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[l].Value);
								dg.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectGreater(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true))
						{
							int num8 = dg.ColumnCount - 1;
							for (int m = 0; m <= num8; m++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[m].Value);
								dg.Rows[k].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[m].Value);
								dg.Rows[k + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectEqual(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true) && Operators.ConditionalCompareObjectLess(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true))
						{
							int num9 = dg.ColumnCount - 1;
							for (int n = 0; n <= num9; n++)
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[n].Value);
								dg.Rows[k].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[n].Value);
								dg.Rows[k + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							}
						}
					}
				}
			}
			int num10 = dg.Rows.Count - 1;
			for (int num11 = 0; num11 <= num10; num11++)
			{
				if (Operators.CompareString(dg.Rows[num11].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					dg.Rows[num11].Cells[2].Value = Conversions.ToString((int)Math.Round(proximoBorne));
					dg.Rows[num11].Cells[1].Value = (int)Math.Round(ordem);
					proximoBorne++;
					ordem++;
				}
			}
			int num12 = 0;
			int num13 = dg.Rows.Count - 1;
			for (int num14 = 0; num14 <= num13; num14++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[num14].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num12++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num15 = dg.Rows.Count - 2 - num12;
				for (int num16 = 0; num16 <= num15; num16++)
				{
					int num17 = dg.Rows.Count - 2 - num12;
					for (int num18 = num17; num18 >= 0; num18 += -1)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[num18].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[num18].Cells[1].Value, dg.Rows[num18 + 1].Cells[1].Value, TextCompare: true))
						{
							int num19 = dg.ColumnCount - 1;
							for (int num20 = 0; num20 <= num19; num20++)
							{
								object objectValue4 = RuntimeHelpers.GetObjectValue(dg.Rows[num18].Cells[num20].Value);
								dg.Rows[num18].Cells[num20].Value = RuntimeHelpers.GetObjectValue(dg.Rows[num18 + 1].Cells[num20].Value);
								dg.Rows[num18 + 1].Cells[num20].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							}
						}
					}
				}
			}
			int num21 = dg.Rows.Count - 1;
			for (int num22 = 0; num22 <= num21; num22++)
			{
				dg.Rows[num22].Cells[1].Value = num22 + 1;
			}
		}
	}

	public static void OrdenaPLC_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
		int index = 9;
		int index2 = 10;
		int index3 = 11;
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					num++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num3 = num;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = num - 1;
					for (int k = num4; k >= 0; k += -1)
					{
						if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							continue;
						}
						double num5 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k].Cells[index].Value));
						double num6 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k + 1].Cells[index].Value));
						if (num5 > num6)
						{
							int num7 = dg.ColumnCount - 1;
							for (int l = 0; l <= num7; l++)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[l].Value);
								dg.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[l].Value);
								dg.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectLess(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true))
						{
							int num8 = dg.ColumnCount - 1;
							for (int m = 0; m <= num8; m++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[m].Value);
								dg.Rows[k].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[m].Value);
								dg.Rows[k + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectEqual(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true))
						{
							int num9 = dg.ColumnCount - 1;
							for (int n = 0; n <= num9; n++)
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[n].Value);
								dg.Rows[k].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[n].Value);
								dg.Rows[k + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							}
						}
					}
				}
			}
			int num10 = dg.Rows.Count - 1;
			for (int num11 = 0; num11 <= num10; num11++)
			{
				if (Operators.CompareString(dg.Rows[num11].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					dg.Rows[num11].Cells[1].Value = (int)Math.Round(ordem);
					dg.Rows[num11].Cells[2].Value = Conversions.ToString((int)Math.Round(proximoBorne));
					proximoBorne++;
					ordem++;
				}
			}
			int num12 = 0;
			int num13 = dg.Rows.Count - 1;
			for (int num14 = 0; num14 <= num13; num14++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[num14].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num12++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num15 = dg.Rows.Count - 2 - num12;
				for (int num16 = 0; num16 <= num15; num16++)
				{
					int num17 = dg.Rows.Count - 2 - num12;
					for (int num18 = num17; num18 >= 0; num18 += -1)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[num18].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[num18].Cells[1].Value, dg.Rows[num18 + 1].Cells[1].Value, TextCompare: true))
						{
							int num19 = dg.ColumnCount - 1;
							for (int num20 = 0; num20 <= num19; num20++)
							{
								object objectValue4 = RuntimeHelpers.GetObjectValue(dg.Rows[num18].Cells[num20].Value);
								dg.Rows[num18].Cells[num20].Value = RuntimeHelpers.GetObjectValue(dg.Rows[num18 + 1].Cells[num20].Value);
								dg.Rows[num18 + 1].Cells[num20].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							}
						}
					}
				}
			}
			int num21 = dg.Rows.Count - 1;
			for (int num22 = 0; num22 <= num21; num22++)
			{
				dg.Rows[num22].Cells[1].Value = num22 + 1;
			}
		}
	}

	public static void OrdenaPLCPot_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
		int index = 9;
		int index2 = 10;
		int index3 = 11;
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					num++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num3 = num;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = num - 1;
					for (int k = num4; k >= 0; k += -1)
					{
						if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							continue;
						}
						double num5 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k].Cells[index].Value));
						double num6 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k + 1].Cells[index].Value));
						if (num5 > num6)
						{
							int num7 = dg.ColumnCount - 1;
							for (int l = 0; l <= num7; l++)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[l].Value);
								dg.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[l].Value);
								dg.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectLess(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true))
						{
							int num8 = dg.ColumnCount - 1;
							for (int m = 0; m <= num8; m++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[m].Value);
								dg.Rows[k].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[m].Value);
								dg.Rows[k + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectEqual(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true))
						{
							int num9 = dg.ColumnCount - 1;
							for (int n = 0; n <= num9; n++)
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[n].Value);
								dg.Rows[k].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[n].Value);
								dg.Rows[k + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							}
						}
						int num10 = 0;
						int num11 = 0;
						num10 = Conversions.ToInteger(dg.Rows[k].Cells[12].Value);
						num11 = Conversions.ToInteger(dg.Rows[k + 1].Cells[12].Value);
						if (num10 > num11)
						{
							int num12 = dg.ColumnCount - 1;
							for (int num13 = 0; num13 <= num12; num13++)
							{
								object objectValue4 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[num13].Value);
								dg.Rows[k].Cells[num13].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[num13].Value);
								dg.Rows[k + 1].Cells[num13].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							}
						}
					}
				}
			}
			int num14 = dg.Rows.Count - 1;
			for (int num15 = 0; num15 <= num14; num15++)
			{
				if (Operators.CompareString(dg.Rows[num15].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					dg.Rows[num15].Cells[2].Value = Conversions.ToString((int)Math.Round(proximoBorne));
					dg.Rows[num15].Cells[1].Value = (int)Math.Round(ordem);
					proximoBorne++;
					ordem++;
				}
			}
			int num16 = 0;
			int num17 = dg.Rows.Count - 1;
			for (int num18 = 0; num18 <= num17; num18++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[num18].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num16++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num19 = dg.Rows.Count - 2 - num16;
				for (int num20 = 0; num20 <= num19; num20++)
				{
					int num21 = dg.Rows.Count - 2 - num16;
					for (int num22 = num21; num22 >= 0; num22 += -1)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[num22].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[num22].Cells[1].Value, dg.Rows[num22 + 1].Cells[1].Value, TextCompare: true))
						{
							int num23 = dg.ColumnCount - 1;
							for (int num24 = 0; num24 <= num23; num24++)
							{
								object objectValue5 = RuntimeHelpers.GetObjectValue(dg.Rows[num22].Cells[num24].Value);
								dg.Rows[num22].Cells[num24].Value = RuntimeHelpers.GetObjectValue(dg.Rows[num22 + 1].Cells[num24].Value);
								dg.Rows[num22 + 1].Cells[num24].Value = RuntimeHelpers.GetObjectValue(objectValue5);
							}
						}
					}
				}
			}
			int num25 = dg.Rows.Count - 1;
			for (int num26 = 0; num26 <= num25; num26++)
			{
				dg.Rows[num26].Cells[1].Value = num26 + 1;
			}
		}
	}

	public static void OrdenaPCLPot_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
		int index = 9;
		int index2 = 10;
		int index3 = 11;
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					num++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num3 = num;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = num - 1;
					for (int k = num4; k >= 0; k += -1)
					{
						if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							continue;
						}
						double num5 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k].Cells[index].Value));
						double num6 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[k + 1].Cells[index].Value));
						if (num5 > num6)
						{
							int num7 = dg.ColumnCount - 1;
							for (int l = 0; l <= num7; l++)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[l].Value);
								dg.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[l].Value);
								dg.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectGreater(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true))
						{
							int num8 = dg.ColumnCount - 1;
							for (int m = 0; m <= num8; m++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[m].Value);
								dg.Rows[k].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[m].Value);
								dg.Rows[k + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							}
						}
						if (num5 == num6 && Operators.ConditionalCompareObjectEqual(dg.Rows[k].Cells[index2].Value, dg.Rows[k + 1].Cells[index2].Value, TextCompare: true) && Operators.ConditionalCompareObjectLess(dg.Rows[k].Cells[index3].Value, dg.Rows[k + 1].Cells[index3].Value, TextCompare: true))
						{
							int num9 = dg.ColumnCount - 1;
							for (int n = 0; n <= num9; n++)
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[n].Value);
								dg.Rows[k].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[n].Value);
								dg.Rows[k + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							}
						}
						int num10 = 0;
						int num11 = 0;
						num10 = Conversions.ToInteger(dg.Rows[k].Cells[12].Value);
						num11 = Conversions.ToInteger(dg.Rows[k + 1].Cells[12].Value);
						if (num10 > num11)
						{
							int num12 = dg.ColumnCount - 1;
							for (int num13 = 0; num13 <= num12; num13++)
							{
								object objectValue4 = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[num13].Value);
								dg.Rows[k].Cells[num13].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[num13].Value);
								dg.Rows[k + 1].Cells[num13].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							}
						}
					}
				}
			}
			int num14 = dg.Rows.Count - 1;
			for (int num15 = 0; num15 <= num14; num15++)
			{
				if (Operators.CompareString(dg.Rows[num15].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
				{
					dg.Rows[num15].Cells[2].Value = Conversions.ToString((int)Math.Round(proximoBorne));
					dg.Rows[num15].Cells[1].Value = (int)Math.Round(ordem);
					proximoBorne++;
					ordem++;
				}
			}
			int num16 = 0;
			int num17 = dg.Rows.Count - 1;
			for (int num18 = 0; num18 <= num17; num18++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[num18].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num16++;
				}
			}
			if (dg.Rows.Count - 1 >= 1)
			{
				int num19 = dg.Rows.Count - 2 - num16;
				for (int num20 = 0; num20 <= num19; num20++)
				{
					int num21 = dg.Rows.Count - 2 - num16;
					for (int num22 = num21; num22 >= 0; num22 += -1)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[num22].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[num22].Cells[1].Value, dg.Rows[num22 + 1].Cells[1].Value, TextCompare: true))
						{
							int num23 = dg.ColumnCount - 1;
							for (int num24 = 0; num24 <= num23; num24++)
							{
								object objectValue5 = RuntimeHelpers.GetObjectValue(dg.Rows[num22].Cells[num24].Value);
								dg.Rows[num22].Cells[num24].Value = RuntimeHelpers.GetObjectValue(dg.Rows[num22 + 1].Cells[num24].Value);
								dg.Rows[num22 + 1].Cells[num24].Value = RuntimeHelpers.GetObjectValue(objectValue5);
							}
						}
					}
				}
			}
			int num25 = dg.Rows.Count - 1;
			for (int num26 = 0; num26 <= num25; num26++)
			{
				dg.Rows[num26].Cells[1].Value = num26 + 1;
			}
		}
	}

	public static void MoveReservasParaOFinal(ref DataGridView dg)
	{
		double num = 1.0;
		double num2 = 9000000.0;
		checked
		{
			int num3 = dg.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (!Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					dg.Rows[i].Cells[1].Value = num;
					num++;
				}
				else
				{
					dg.Rows[i].Cells[1].Value = num2;
					num2++;
				}
			}
			ordenarBornesPelaOrdem(ref dg);
			num = 1.0;
			int num4 = dg.Rows.Count - 1;
			for (int j = 0; j <= num4; j++)
			{
				dg.Rows[j].Cells[1].Value = num;
				num++;
			}
		}
	}

	private void PhNpT3PkGtc(object P_0, KeyEventArgs P_1)
	{
		sdrpT1KV76k();
	}

	private void oVFpTnIV4FU(object P_0, EventArgs P_1)
	{
		sdrpT1KV76k();
	}

	private void sdrpT1KV76k()
	{
		tbCodigo1.Text = "0";
		tbBlocoLayout.Text = "";
		int num = 0;
		checked
		{
			int num2 = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					num = Conversions.ToInteger(dgBornes.Rows[i].Cells[5].Value);
					tbBlocoLayout.Text = Conversions.ToString(dgBornes.Rows[i].Cells[16].Value);
					ckNorte.Checked = false;
					ckSul.Checked = false;
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[15].Value, "N", TextCompare: true))
					{
						ckNorte.Checked = true;
					}
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[15].Value, "S", TextCompare: true))
					{
						ckSul.Checked = true;
					}
					break;
				}
			}
			tEmpTljS2iw(num);
		}
	}

	private void tEmpTljS2iw(int P_0)
	{
		tbCodigo1.Text = Conversions.ToString(0);
		tbDescricaoResum1.Text = "";
		tbModelo1.Text = "";
		tbFabricante1.Text = "";
		int num = Information.UBound(W4Qph7v7o0L);
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (W4Qph7v7o0L[num2].CodigoInterno == P_0)
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return;
		}
		tbCodigo1.Text = Conversions.ToString(P_0);
		tbDescricaoResum1.Text = W4Qph7v7o0L[num2].DescricaoResumida;
		tbModelo1.Text = W4Qph7v7o0L[num2].Modelo;
		tbFabricante1.Text = W4Qph7v7o0L[num2].Fabricante;
	}

	private void ubUpT5W6NEm(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		int indiceRegua = -1;
		string text = CBMigraRegua.Text;
		string text2 = "";
		if (Operators.CompareString(text, "", TextCompare: true) == 0)
		{
			return;
		}
		int num = Information.UBound(GC6phD60Llo);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (GC6phD60Llo[i].indexPainel == pLxphdx8X8q.iPainel && Operators.CompareString(GC6phD60Llo[i].nomeRegua, text, TextCompare: true) == 0)
				{
					indiceRegua = GC6phD60Llo[i].indexRegua;
					text2 = Dicionario.BuscaNomeDoPainel(GC6phD60Llo[i].indexPainel);
					break;
				}
			}
			if (Operators.CompareString(text2, "", TextCompare: true) == 0)
			{
				return;
			}
			int num2 = dgBornes.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (dgBornes.Rows[j].Selected && Operators.ConditionalCompareObjectEqual(dgBornes.Rows[j].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					dgBornes.Rows[j].Selected = false;
				}
			}
			int num3 = 0;
			int num4 = dgBornes.Rows.Count - 1;
			for (int k = 0; k <= num4; k++)
			{
				if (dgBornes.Rows[k].Selected)
				{
					num3++;
				}
			}
			if (num3 <= 0)
			{
				return;
			}
			string prompt = "";
			if (num3 == 1)
			{
				prompt = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1180], text), " ?"));
			}
			if (num3 > 1)
			{
				prompt = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1181], Conversions.ToString(num3)), DeclaracoesGeral.mMensagem[1, 1182]), text), " ?"));
			}
			MsgBoxResult msgBoxResult = Interaction.MsgBox(prompt, MsgBoxStyle.YesNo);
			if (msgBoxResult == MsgBoxResult.No)
			{
				return;
			}
			sCXph6C4lyQ = new DeclaracoesEntidades.StructureBorne[1];
			int num5 = dgBornes.Rows.Count - 1;
			for (int l = 0; l <= num5; l++)
			{
				if (!dgBornes.Rows[l].Selected)
				{
					continue;
				}
				string left = Conversions.ToString(dgBornes.Rows[l].Cells[7].Value);
				if (Operators.CompareString(left, "", TextCompare: true) != 0 && Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[l].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					int num6 = Information.UBound(sCXph6C4lyQ) + 1;
					ref DeclaracoesEntidades.StructureBorne[] reference = ref sCXph6C4lyQ;
					reference = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(reference, new DeclaracoesEntidades.StructureBorne[num6 + 1]);
					sCXph6C4lyQ[num6].NomeRegua = text;
					sCXph6C4lyQ[num6].NomePainel = text2;
					sCXph6C4lyQ[num6].IndiceRegua = indiceRegua;
					sCXph6C4lyQ[num6].Ordem = 0.0;
					sCXph6C4lyQ[num6].Numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					sCXph6C4lyQ[num6].Alternativo = "";
					sCXph6C4lyQ[num6].tipo = 0;
					if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[l].Cells[4].Value, "D", TextCompare: true))
					{
						sCXph6C4lyQ[num6].tipo = 1;
					}
					sCXph6C4lyQ[num6].lm = Conversions.ToInteger(dgBornes.Rows[l].Cells[5].Value);
					sCXph6C4lyQ[num6].Handle = Conversions.ToString(dgBornes.Rows[l].Cells[7].Value);
					sCXph6C4lyQ[num6].Orientacao = Conversions.ToString(dgBornes.Rows[l].Cells[15].Value);
					sCXph6C4lyQ[num6].BlocoLayout = Conversions.ToString(dgBornes.Rows[l].Cells[16].Value);
					sCXph6C4lyQ[num6].reserva = false;
					dgBornes.Rows[l].Cells[2].Value = "#MIGRAR#";
				}
			}
			clsBornes.EditarOsTodosOsBornesMigradosDasReguaSelecionada(sCXph6C4lyQ, pLxphdx8X8q.sReguaA);
			int num7 = dgBornes.Rows.Count - 1;
			for (int m = num7; m >= 0; m += -1)
			{
				if (Operators.CompareString(dgBornes.Rows[m].Cells[2].Value.ToString(), "#MIGRAR#", TextCompare: true) == 0)
				{
					dgBornes.Rows.RemoveAt(m);
				}
			}
			int num8 = dgBornes.Rows.Count - 1;
			for (int n = 0; n <= num8; n++)
			{
				dgBornes.Rows[n].Selected = false;
			}
			if (dgBornes.Rows.Count - 1 >= 0)
			{
				dgBornes.Rows[0].Selected = true;
			}
		}
	}

	private void VptpT0CHvT7(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count <= 0)
		{
			return;
		}
		int index = 0;
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					index = i;
					break;
				}
			}
			if (!CKEdicaoMultiplas.Checked)
			{
				dgBornes.MultiSelect = false;
				GroupBox4.Enabled = true;
				GroupBox5.Enabled = true;
				GroupBox6.Enabled = true;
				btInsereReservaEntre.Enabled = true;
				w8dpBZ0kvSD().SetToolTip(btAumentaRecuo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1176]));
				w8dpBZ0kvSD().SetToolTip(btDiminuiRecuo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1177]));
			}
			else
			{
				dgBornes.MultiSelect = true;
				GroupBox4.Enabled = false;
				GroupBox5.Enabled = false;
				GroupBox6.Enabled = false;
				btInsereReservaEntre.Enabled = false;
			}
			dgBornes.Rows[index].Selected = true;
		}
	}

	public void SalvarAlteracoes()
	{
		sCXph6C4lyQ = new DeclaracoesEntidades.StructureBorne[1];
		AuSphv29XNQ = new DeclaracoesEntidades.StructureBorne[1];
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string left = Conversions.ToString(dgBornes.Rows[i].Cells[7].Value);
				int tipo = 0;
				object value = dgBornes.Rows[i].Cells[4].Value;
				if (!Operators.ConditionalCompareObjectEqual(value, "S", TextCompare: true))
				{
					if (!Operators.ConditionalCompareObjectEqual(value, "D", TextCompare: true))
					{
						if (Operators.ConditionalCompareObjectEqual(value, "X", TextCompare: true))
						{
							tipo = 2;
						}
					}
					else
					{
						tipo = 1;
					}
				}
				else
				{
					tipo = 0;
				}
				if (Operators.CompareString(left, "", TextCompare: true) != 0)
				{
					int num2 = Information.UBound(sCXph6C4lyQ) + 1;
					ref DeclaracoesEntidades.StructureBorne[] reference = ref sCXph6C4lyQ;
					reference = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(reference, new DeclaracoesEntidades.StructureBorne[num2 + 1]);
					sCXph6C4lyQ[num2].Ordem = Conversions.ToDouble(dgBornes.Rows[i].Cells[1].Value);
					sCXph6C4lyQ[num2].Numero = Conversions.ToString(dgBornes.Rows[i].Cells[2].Value);
					sCXph6C4lyQ[num2].Alternativo = Conversions.ToString(dgBornes.Rows[i].Cells[3].Value);
					sCXph6C4lyQ[num2].tipo = tipo;
					sCXph6C4lyQ[num2].lm = Conversions.ToInteger(dgBornes.Rows[i].Cells[5].Value);
					sCXph6C4lyQ[num2].Handle = Conversions.ToString(dgBornes.Rows[i].Cells[7].Value);
					sCXph6C4lyQ[num2].reserva = false;
					sCXph6C4lyQ[num2].Orientacao = Conversions.ToString(dgBornes.Rows[i].Cells[15].Value);
					sCXph6C4lyQ[num2].BlocoLayout = Conversions.ToString(dgBornes.Rows[i].Cells[16].Value);
				}
				if (Operators.CompareString(left, "", TextCompare: true) == 0)
				{
					int num3 = Information.UBound(AuSphv29XNQ) + 1;
					ref DeclaracoesEntidades.StructureBorne[] auSphv29XNQ = ref AuSphv29XNQ;
					auSphv29XNQ = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(auSphv29XNQ, new DeclaracoesEntidades.StructureBorne[num3 + 1]);
					AuSphv29XNQ[num3].Ordem = Conversions.ToDouble(dgBornes.Rows[i].Cells[1].Value);
					AuSphv29XNQ[num3].Numero = Conversions.ToString(dgBornes.Rows[i].Cells[2].Value);
					AuSphv29XNQ[num3].Alternativo = Conversions.ToString(dgBornes.Rows[i].Cells[3].Value);
					AuSphv29XNQ[num3].tipo = tipo;
					AuSphv29XNQ[num3].lm = Conversions.ToInteger(dgBornes.Rows[i].Cells[5].Value);
					AuSphv29XNQ[num3].Handle = "";
					AuSphv29XNQ[num3].reserva = true;
					AuSphv29XNQ[num3].Orientacao = Conversions.ToString(dgBornes.Rows[i].Cells[15].Value);
					AuSphv29XNQ[num3].BlocoLayout = Conversions.ToString(dgBornes.Rows[i].Cells[16].Value);
				}
			}
			DicionarioBorne.gravaDicBornesReserva(pLxphdx8X8q.iRegua, ref AuSphv29XNQ);
			clsBornes.EditarOsTodosOsBornesDasReguasSelecionada(sCXph6C4lyQ);
			btSalvar.Enabled = false;
		}
	}

	public static void CarregaPaineiseReguasNoDG(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, string sPesquisa)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mMODELO == null || Information.UBound(mMODELO) <= 0)
				{
					return;
				}
				dg.Columns.Add("IndicePainel", "#");
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dg.Columns.Add("indiceRegua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1043]));
				dg.ColumnHeadersVisible = true;
				int num = Information.UBound(mMODELO);
				for (int i = 1; i <= num; i++)
				{
					string nomeRegua = mMODELO[i].nomeRegua;
					string text = Dicionario.BuscaNomeDoPainel(mMODELO[i].indexPainel);
					if (LikeOperator.LikeString(text.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(nomeRegua.ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text))
					{
						dg.Rows.Add(mMODELO[i].indexPainel, text, mMODELO[i].indexRegua, nomeRegua);
					}
				}
				int num2 = dg.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[num3].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[num3].Value)))
						{
							dg.Rows[j].Cells[num3].Value = "";
						}
						num3++;
					}
					while (num3 <= 3);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public void AtualizaDgPaineisReguas(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount <= 0)
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
			}
			else if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = 0;
				dg.Columns[1].Width = (int)Math.Round(num * 0.5);
				dg.Columns[2].Width = 0;
				dg.Columns[3].Width = (int)Math.Round(num * 0.5);
				dg.Columns[0].Visible = false;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = false;
				dg.Columns[3].Visible = true;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
			}
		}
	}

	public static void CarregaOsBornesNoDG(ref DataGridView dg, DeclaracoesEntidades.StructureBorne[] mBornes, ref int iNumUnico)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mBornes == null || Information.UBound(mBornes) == 0)
				{
					return;
				}
				formataDgBornes(ref dg);
				dg.ColumnHeadersVisible = true;
				string text = "S";
				if (Information.UBound(mBornes) > 0)
				{
					int num = Information.UBound(mBornes);
					for (int i = 1; i <= num; i++)
					{
						string text2 = clsTextos.TiraNothing(mBornes[i].pagina);
						if (Operators.CompareString(mBornes[i].Numero, "0", TextCompare: true) == 0)
						{
							mBornes[i].Numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						}
						if (Operators.CompareString(text2, "", TextCompare: true) == 0)
						{
							text2 = ((mBornes[i].tipo == 2) ? Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1890]) : Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1050]));
						}
						text = "S";
						switch (mBornes[i].tipo)
						{
						case 2:
							text = "X";
							break;
						case 0:
							text = "S";
							break;
						case 1:
							text = "D";
							break;
						}
						dg.Rows.Add(mBornes[i].IndiceRegua, mBornes[i].Ordem, mBornes[i].Numero, mBornes[i].Alternativo, text, mBornes[i].lm, text2, mBornes[i].Handle, mBornes[i].Numero, mBornes[i].sPagina, mBornes[i].iLinha, mBornes[i].iColuna, mBornes[i].Potencial, mBornes[i].CaboOrigem, mBornes[i].VeiaOrigem, mBornes[i].Orientacao, mBornes[i].BlocoLayout, excBornes.NomeUnico(ref iNumUnico));
						if (i == 1)
						{
							AtualizaColunasDGBornes(ref dg);
						}
						dg.Rows[i - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
				}
				ordenarBornesPelaOrdem(ref dg);
				int num2 = dg.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (!dg.Rows[j].Selected)
					{
						dg.FirstDisplayedScrollingRowIndex = j;
						break;
					}
				}
				int num3 = dg.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					int num4 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(dg.Rows[k].Cells[num4].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[num4].Value)))
						{
							dg.Rows[k].Cells[num4].Value = "";
						}
						num4++;
					}
					while (num4 <= 14);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void formataDgBornes(ref DataGridView dg)
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("IndiceRegua", "#");
		dg.Columns.Add("Ordem", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1082]));
		dg.Columns.Add("Numero", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1083]));
		dg.Columns.Add("Alternativo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]));
		dg.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 262]));
		dg.Columns.Add("ListaDeMateriais", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1084]));
		dg.Columns.Add("Pagina", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 993]));
		dg.Columns.Add("Handle", "Handle");
		dg.Columns.Add("NumeroOriginal", "NumeroOriginal");
		dg.Columns.Add("sPG", "sPG");
		dg.Columns.Add("sLin", "sLin");
		dg.Columns.Add("sCol", "sCol");
		dg.Columns.Add("iPot", "iPot");
		dg.Columns.Add("Cabo", "Cabo");
		dg.Columns.Add("Veia", "Veia");
		dg.Columns.Add("ORI", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]));
		dg.Columns.Add("Layout", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 658]));
		dg.Columns.Add("NomeUnico", "NomeUnico");
		checked
		{
			double num = dg.Width - 21;
			dg.Columns[0].Width = 0;
			dg.Columns[1].Width = 0;
			dg.Columns[2].Width = (int)Math.Round(num * 0.25);
			dg.Columns[3].Width = 0;
			dg.Columns[4].Width = (int)Math.Round(num * 0.16);
			dg.Columns[5].Width = (int)Math.Round(num * 0.11);
			dg.Columns[6].Width = (int)Math.Round(num * 0.16);
			dg.Columns[7].Width = 0;
			dg.Columns[8].Width = 0;
			dg.Columns[9].Width = 0;
			dg.Columns[10].Width = 0;
			dg.Columns[11].Width = 0;
			dg.Columns[12].Width = 0;
			dg.Columns[13].Width = 0;
			dg.Columns[14].Width = 0;
			dg.Columns[15].Width = (int)Math.Round(num * 0.1);
			dg.Columns[16].Width = (int)Math.Round(num * 0.22);
			dg.Columns[17].Width = 0;
			dg.Columns[0].Visible = false;
			dg.Columns[1].Visible = false;
			dg.Columns[2].Visible = true;
			dg.Columns[3].Visible = false;
			dg.Columns[4].Visible = true;
			dg.Columns[5].Visible = true;
			dg.Columns[6].Visible = true;
			dg.Columns[7].Visible = false;
			dg.Columns[8].Visible = false;
			dg.Columns[9].Visible = false;
			dg.Columns[10].Visible = false;
			dg.Columns[11].Visible = false;
			dg.Columns[12].Visible = false;
			dg.Columns[13].Visible = false;
			dg.Columns[14].Visible = false;
			dg.Columns[15].Visible = true;
			dg.Columns[16].Visible = true;
			dg.Columns[17].Visible = false;
		}
	}

	public static void AtualizaColunasDGBornes(ref DataGridView dg)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
		{
			dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			dg.Columns[0].Width = 0;
			dg.Columns[1].Width = 0;
			dg.Columns[2].Width = (int)Math.Round(num * 0.25);
			dg.Columns[3].Width = 0;
			dg.Columns[4].Width = (int)Math.Round(num * 0.16);
			dg.Columns[5].Width = (int)Math.Round(num * 0.11);
			dg.Columns[6].Width = (int)Math.Round(num * 0.16);
			dg.Columns[7].Width = 0;
			dg.Columns[8].Width = 0;
			dg.Columns[9].Width = 0;
			dg.Columns[10].Width = 0;
			dg.Columns[11].Width = 0;
			dg.Columns[12].Width = 0;
			dg.Columns[13].Width = 0;
			dg.Columns[14].Width = 0;
			dg.Columns[15].Width = (int)Math.Round(num * 0.1);
			dg.Columns[16].Width = (int)Math.Round(num * 0.22);
			dg.Columns[17].Width = 0;
			dg.Columns[0].Visible = false;
			dg.Columns[1].Visible = false;
			dg.Columns[2].Visible = true;
			dg.Columns[3].Visible = false;
			dg.Columns[4].Visible = true;
			dg.Columns[5].Visible = true;
			dg.Columns[6].Visible = true;
			dg.Columns[7].Visible = false;
			dg.Columns[8].Visible = false;
			dg.Columns[9].Visible = false;
			dg.Columns[10].Visible = false;
			dg.Columns[11].Visible = false;
			dg.Columns[12].Visible = false;
			dg.Columns[13].Visible = false;
			dg.Columns[14].Visible = false;
			dg.Columns[15].Visible = true;
			dg.Columns[16].Visible = true;
			dg.Columns[17].Visible = false;
			int num2 = dg.Columns.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				dg.Columns[i].ReadOnly = true;
			}
			dg.Columns[2].ReadOnly = false;
			int num3 = dg.Columns.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dg.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}
	}

	private void RXgpTRBo72Y(object P_0, EventArgs P_1)
	{
		AtualizaJanela();
	}

	public void AtualizaJanela()
	{
		DataGridView dg = dgBornes;
		AtualizaColunasDGBornes(ref dg);
		dgBornes = dg;
		dg = dgReguas;
		AtualizaDgPaineisReguas(ref dg);
		dgReguas = dg;
		CKEdicaoMultiplas.Location = new Point(GroupBox1.Location.X, 12);
	}

	private void kRSpTmk4W2a(object P_0, EventArgs P_1)
	{
		w8dpBZ0kvSD().SetToolTip(btMigrarBornes, Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1093], CBMigraRegua.Text)));
	}

	private bool P4KpTXkfaOM(int P_0, int P_1)
	{
		bool result = true;
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		for (int i = 0; i <= P_1; i = checked(i + 1))
		{
			if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgBornes.Rows[i].Cells[2].Value)) && Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[2].Value, P_0, TextCompare: true))
			{
				dgBornes.Rows[i].Cells[2].Style = dataGridViewCellStyle;
				result = false;
			}
		}
		return result;
	}

	private void Mv6pTUcTHAV(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text, "", TextCompare: true) == 0))
		{
			TBPesquisa.Enabled = false;
			DataGridView dg = dgReguas;
			CarregaPaineiseReguasNoDG(ref dg, GC6phD60Llo, TBPesquisa.Text.ToString());
			dgReguas = dg;
			dg = dgReguas;
			AtualizaDgPaineisReguas(ref dg);
			dgReguas = dg;
			TBPesquisa.Enabled = true;
			TBPesquisa.Focus();
		}
	}

	private void aplpTyiiAFx(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void I4QpTgUjgt7(object P_0, KeyEventArgs P_1)
	{
		try
		{
			if (Versioned.IsNumeric(tbRecuo.Text))
			{
				tbRecuo.Text = Conversions.ToString(Conversions.ToInteger(tbRecuo.Text));
				int selectionStart = Strings.Len(tbRecuo.Text);
				tbRecuo.SelectionStart = selectionStart;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			tbRecuo.Text = "?";
			ProjectData.ClearProjectError();
		}
	}

	public static bool ExisteBornesIguais(ref Worksheet oSheet)
	{
		bool result = false;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		string text = Conversions.ToString(0);
		long num = ((_Worksheet)oSheet).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_End(XlDirection.xlDown).Row;
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = (int)(num * 5L);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num2 = 1;
			int num3 = (int)num;
			for (int i = 2; i <= num3; i++)
			{
				ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
				string cell = "E" + Conversions.ToString(i);
				if (!Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					string cell2 = "C" + Conversions.ToString(i);
					((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X");
				}
				else
				{
					string cell3 = "B" + Conversions.ToString(i);
					if (Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
					}
					cell3 = "B" + Conversions.ToString(i);
					if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)0);
					}
					cell3 = "C" + Conversions.ToString(i);
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), "D", TextCompare: true))
					{
						((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"S");
					}
					cell3 = "D" + Conversions.ToString(i);
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), 0, TextCompare: true))
					{
						if (Conversions.ToDouble(text) == 0.0)
						{
							text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						}
						if (Operators.ConditionalCompareObjectNotEqual(text, ((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), TextCompare: true))
						{
							text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						}
					}
					if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text);
					}
					cell3 = "E" + Conversions.ToString(i);
					if (Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 375]));
					}
				}
				cell = "A" + Conversions.ToString(i);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)num2);
				num2++;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			int num4 = (int)num;
			for (int j = 2; j <= num4; j++)
			{
				string cell4 = "E" + Conversions.ToString(j);
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), DeclaracoesGeral.mMensagem[1, 1890], TextCompare: true))
				{
					cell4 = "B" + j;
					string text2 = ((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.ToUpper()
						.Trim();
					if (list2.Contains(text2))
					{
						if (Operators.CompareString(text2, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
						{
							list.Add(cell4);
							((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
							ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(Conversions.ToInteger(j.ToString())), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1567]), 3, 1, 60);
							result = true;
						}
					}
					else
					{
						list2.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					}
					if (Strings.Len(text2) > 10)
					{
						((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
						ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(Conversions.ToInteger(j.ToString())), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1690]), 3, 1, 120);
						result = true;
					}
					cell4 = "E" + j;
					text2 = ((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.ToUpper()
						.Trim();
					if (list3.Contains(text2))
					{
						if (Operators.ConditionalCompareObjectNotEqual(text2, DeclaracoesGeral.mMensagem[1, 375], TextCompare: true))
						{
							list3.Add(cell4);
							((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
							ExcFuncoesExcel.PintaCelula(ref oSheet, "E", Conversions.ToString(Conversions.ToInteger(j.ToString())), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1567]), 3, 1, 60);
							result = true;
						}
					}
					else
					{
						list3.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			return result;
		}
	}

	public static bool ExisteBornesIguaisOLD(ref Worksheet oSheet)
	{
		bool result = false;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		string text = Conversions.ToString(0);
		long num = ((_Worksheet)oSheet).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_End(XlDirection.xlDown).Row;
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = (int)(num * 5L);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num2 = 1;
			int num3 = (int)num;
			for (int i = 2; i <= num3; i++)
			{
				ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
				string cell = "A" + Conversions.ToString(i);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)num2);
				string cell2 = "B" + Conversions.ToString(i);
				if (Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
				}
				cell2 = "B" + Conversions.ToString(i);
				if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)
				{
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)0);
				}
				cell2 = "C" + Conversions.ToString(i);
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), "D", TextCompare: true))
				{
					((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"S");
				}
				cell2 = "D" + Conversions.ToString(i);
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), 0, TextCompare: true))
				{
					if (Conversions.ToDouble(text) == 0.0)
					{
						text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					}
					if (Operators.ConditionalCompareObjectNotEqual(text, ((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), TextCompare: true))
					{
						text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					}
				}
				if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
				{
					((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text);
				}
				cell2 = "E" + Conversions.ToString(i);
				if (Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 375]));
				}
				num2++;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			int num4 = (int)num;
			for (int j = 2; j <= num4; j++)
			{
				string text2 = "B" + j;
				string text3 = ((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
					.ToUpper()
					.Trim();
				if (list2.Contains(text3))
				{
					if (Operators.CompareString(text3, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
					{
						list.Add(text2);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
						ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(Conversions.ToInteger(j.ToString())), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1567]), 3, 1, 60);
						result = true;
					}
				}
				else
				{
					list2.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
				}
				if (Strings.Len(text3) > 10)
				{
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
					ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(Conversions.ToInteger(j.ToString())), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1690]), 3, 1, 120);
					result = true;
				}
				text2 = "E" + j;
				text3 = ((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
					.ToUpper()
					.Trim();
				if (list3.Contains(text3))
				{
					if (Operators.ConditionalCompareObjectNotEqual(text3, DeclaracoesGeral.mMensagem[1, 375], TextCompare: true))
					{
						list3.Add(text2);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
						ExcFuncoesExcel.PintaCelula(ref oSheet, "E", Conversions.ToString(Conversions.ToInteger(j.ToString())), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1567]), 3, 1, 60);
						result = true;
					}
				}
				else
				{
					list3.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			return result;
		}
	}

	public static void ordenarBornesPelaOrdem(ref DataGridView dg)
	{
		checked
		{
			if (dg.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = -1000;
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if ((Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(dg.Rows[i].Cells[2].Value)), "?", TextCompare: true) == 0) | (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(dg.Rows[i].Cells[2].Value)), "0", TextCompare: true) == 0))
				{
					dg.Rows[i].Cells[1].Value = num;
					num++;
				}
			}
			int num3 = dg.Rows.Count - 2;
			for (int j = 0; j <= num3; j++)
			{
				int num4 = dg.Rows.Count - 2;
				for (int k = num4; k >= 0; k += -1)
				{
					if (Conversions.ToDouble(dg.Rows[k].Cells[1].Value) > Conversions.ToDouble(dg.Rows[k + 1].Cells[1].Value))
					{
						int num5 = dg.ColumnCount - 1;
						for (int l = 0; l <= num5; l++)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[l].Value);
							dg.Rows[k].Cells[l].Value = RuntimeHelpers.GetObjectValue(dg.Rows[k + 1].Cells[l].Value);
							dg.Rows[k + 1].Cells[l].Value = RuntimeHelpers.GetObjectValue(objectValue);
						}
					}
				}
			}
		}
	}

	private void SVepTATWga2(object P_0, DataGridViewCellEventArgs P_1)
	{
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num && !dgBornes.Rows[i].Selected; i++)
			{
			}
		}
	}

	private void sZWpTsyHti4(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string left = dgBornes.Rows[i].Cells[2].Value.ToString();
				if (Operators.CompareString(left, "0", TextCompare: true) != 0 && Operators.CompareString(left, "?", TextCompare: true) != 0)
				{
					list.Add(Conversions.ToString(dgBornes.Rows[i].Cells[2].Value));
				}
				else
				{
					dgBornes.Rows[i].Cells[2].Value = "?";
				}
			}
			if (dgBornes.Rows.Count != list.Count)
			{
				if (list.Count == 0)
				{
					RB_Todos.Checked = true;
				}
			}
			else
			{
				RB_Todos.Checked = true;
			}
		}
	}

	private void yiFpTBRR6OT(object P_0, EventArgs P_1)
	{
		if (ckNorte.Checked)
		{
			ckSul.Checked = false;
		}
	}

	private void Lk3pTV132w9(object P_0, EventArgs P_1)
	{
		if (ckSul.Checked)
		{
			ckNorte.Checked = false;
		}
	}

	private void QBCpTuiTtJS(object P_0, EventArgs P_1)
	{
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout)))
		{
			tbBlocoLayout.BackColor = Color.Silver;
			return;
		}
		tbBlocoLayout.BackColor = Color.White;
		DeclaracoesGeral.gsCaminhoBloco = DeclaracoesGeral.Conf.dirSimbologiaLayout;
		frmVisualizarBloco frmVisualizarBloco2 = new frmVisualizarBloco();
		Application.ShowModalDialog((Form)frmVisualizarBloco2);
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoLayout.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	private void CCxpTEw5VKg(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			return;
		}
		bool flag = false;
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					if (Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[i].Cells[16].Value, tbBlocoLayout.Text, TextCompare: true))
					{
						flag = true;
					}
					dgBornes.Rows[i].Cells[16].Value = tbBlocoLayout.Text;
				}
			}
			if (flag)
			{
				btSalvar.Enabled = true;
			}
		}
	}

	private void QlApTZTu6Vq(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0)
		{
			DataGridView dg = dgBornes;
			formataDgBornes(ref dg);
			dgBornes = dg;
		}
		checked
		{
			try
			{
				double num = 0.0;
				string text = TBExtras.Text;
				string text2 = "X";
				int num2 = 0;
				string text3 = "";
				if (!ckNorte.Checked)
				{
				}
				if (!ckSul.Checked)
				{
				}
				string text4 = tbBlocoLayout.Text;
				if (CKEdicaoMultiplas.Checked)
				{
					return;
				}
				text3 = tbCodigo1.Text;
				int num3 = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					if (dgBornes.Rows[i].Selected)
					{
						num = ((i == 0) ? 0.5 : Conversions.ToDouble(Operators.AddObject(dgBornes.Rows[i].Cells[1].Value, 0.5)));
						break;
					}
				}
				text = TBExtras.Text;
				dgBornes.Rows.Add(pLxphdx8X8q.iRegua, num, text, "", text2, Conversions.ToInteger(text3), DeclaracoesGeral.mMensagem[1, 1890], "", text, "", "", "", "", "", "", "", text4, excBornes.NomeUnico(ref vfcphbxiZf6));
				DataGridView dg;
				if (dgBornes.Rows.Count - 1 >= 1)
				{
					dg = dgBornes;
					ordenarBornesPelaOrdem(ref dg);
					dgBornes = dg;
					int num4 = dgBornes.Rows.Count - 1;
					for (int j = 0; j <= num4; j++)
					{
						dgBornes.Rows[j].Cells[1].Value = j + 1;
					}
				}
				dg = dgBornes;
				AtualizaColunasDGBornes(ref dg);
				dgBornes = dg;
				btSalvar.Enabled = true;
				dgBornes.Rows[num2].Selected = true;
				if (num2 <= 10)
				{
					dgBornes.FirstDisplayedScrollingRowIndex = 0;
				}
				else
				{
					dgBornes.FirstDisplayedScrollingRowIndex = num2 - 10;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	private void I9MpTiyAmTL(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0 || Mh0phqkE313)
		{
			return;
		}
		Mh0phqkE313 = true;
		DataGridView withEventsValue = dgBornes;
		J78pTYiPiBe(ref withEventsValue);
		dgBornes = withEventsValue;
		int num = -1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					dgBornes.Rows[i].Cells[1].Value = num;
					list.Add(Conversions.ToString(dgBornes.Rows[i].Cells[17].Value));
					num++;
					dgBornes.Rows[i].Selected = false;
				}
			}
			withEventsValue = dgBornes;
			ordenarBornesPelaOrdem(ref withEventsValue);
			dgBornes = withEventsValue;
			num = 1;
			int num3 = dgBornes.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgBornes.Rows[j].Cells[1].Value = num;
				if (list.Contains(Conversions.ToString(dgBornes.Rows[j].Cells[17].Value)))
				{
					dgBornes.Rows[j].Selected = true;
					dgBornes.FirstDisplayedScrollingRowIndex = 0;
				}
				num++;
			}
			Mh0phqkE313 = false;
			btSalvar.Enabled = true;
		}
	}

	private void DFGpTSPb0s4(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0 || Mh0phqkE313)
		{
			return;
		}
		Mh0phqkE313 = true;
		DataGridView withEventsValue = dgBornes;
		J78pTYiPiBe(ref withEventsValue);
		dgBornes = withEventsValue;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgBornes.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgBornes.Rows[num3].Selected)
					{
						if (num3 == 0)
						{
							break;
						}
						list.Add(Conversions.ToString(dgBornes.Rows[num3].Cells[17].Value));
					}
					num3++;
					continue;
				}
				int num4 = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num4 && !dgBornes.Rows[i].Selected; i++)
				{
					num = i;
				}
				int num5 = -1000;
				if (num > 0)
				{
					int num6 = num - 1;
					for (int j = 0; j <= num6; j++)
					{
						dgBornes.Rows[j].Cells[1].Value = num5;
					}
				}
				int num7 = dgBornes.Rows.Count - 1;
				for (int k = 0; k <= num7; k++)
				{
					dgBornes.Rows[k].Selected = false;
				}
				num5 = 1000;
				int num8 = num;
				int num9 = dgBornes.Rows.Count - 1;
				for (int l = num8; l <= num9; l++)
				{
					if (!list.Contains(Conversions.ToString(dgBornes.Rows[l].Cells[17].Value)))
					{
						dgBornes.Rows[l].Cells[1].Value = num5;
						num5++;
					}
				}
				withEventsValue = dgBornes;
				ordenarBornesPelaOrdem(ref withEventsValue);
				dgBornes = withEventsValue;
				num5 = 1;
				int num10 = dgBornes.Rows.Count - 1;
				for (int m = 0; m <= num10; m++)
				{
					dgBornes.Rows[m].Cells[1].Value = num5;
					if (list.Contains(Conversions.ToString(dgBornes.Rows[m].Cells[17].Value)))
					{
						dgBornes.Rows[m].Selected = true;
						if (flag)
						{
							flag = false;
							dgBornes.FirstDisplayedScrollingRowIndex = m;
						}
					}
					num5++;
				}
				break;
			}
			Mh0phqkE313 = false;
			btSalvar.Enabled = true;
		}
	}

	private void RbppT47GGo6(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0 || Mh0phqkE313)
		{
			return;
		}
		Mh0phqkE313 = true;
		DataGridView withEventsValue = dgBornes;
		J78pTYiPiBe(ref withEventsValue);
		dgBornes = withEventsValue;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					num = i;
					list.Add(Conversions.ToString(dgBornes.Rows[i].Cells[17].Value));
				}
			}
			if (num < dgBornes.Rows.Count - 1)
			{
				num++;
				int num3 = -1000;
				int num4 = dgBornes.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (j > num)
					{
						num3 = 1000;
						num = 1000;
					}
					if (!list.Contains(Conversions.ToString(dgBornes.Rows[j].Cells[17].Value)))
					{
						dgBornes.Rows[j].Cells[1].Value = num3;
						num3++;
					}
				}
				int num5 = dgBornes.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					dgBornes.Rows[k].Selected = false;
				}
				withEventsValue = dgBornes;
				ordenarBornesPelaOrdem(ref withEventsValue);
				dgBornes = withEventsValue;
				num3 = 1;
				int num6 = dgBornes.Rows.Count - 1;
				for (int l = 0; l <= num6; l++)
				{
					dgBornes.Rows[l].Cells[1].Value = num3;
					if (list.Contains(Conversions.ToString(dgBornes.Rows[l].Cells[17].Value)))
					{
						dgBornes.Rows[l].Selected = true;
						if (flag)
						{
							flag = false;
							dgBornes.FirstDisplayedScrollingRowIndex = l;
						}
					}
					num3++;
				}
			}
			Mh0phqkE313 = false;
			btSalvar.Enabled = true;
		}
	}

	private void kNfpTCl05Jp(object P_0, EventArgs P_1)
	{
		if (dgBornes.Rows.Count == 0 || Mh0phqkE313)
		{
			return;
		}
		Mh0phqkE313 = true;
		DataGridView withEventsValue = dgBornes;
		J78pTYiPiBe(ref withEventsValue);
		dgBornes = withEventsValue;
		int num = 1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					dgBornes.Rows[i].Cells[1].Value = num;
					list.Add(Conversions.ToString(dgBornes.Rows[i].Cells[17].Value));
					num++;
					dgBornes.Rows[i].Selected = false;
				}
			}
			withEventsValue = dgBornes;
			ordenarBornesPelaOrdem(ref withEventsValue);
			dgBornes = withEventsValue;
			num = 1;
			int num3 = dgBornes.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgBornes.Rows[j].Cells[1].Value = num;
				if (list.Contains(Conversions.ToString(dgBornes.Rows[j].Cells[17].Value)))
				{
					dgBornes.Rows[j].Selected = true;
					dgBornes.FirstDisplayedScrollingRowIndex = j;
				}
				num++;
			}
			Mh0phqkE313 = false;
			btSalvar.Enabled = true;
		}
	}

	private void J78pTYiPiBe(ref DataGridView P_0)
	{
		int num = 1;
		checked
		{
			int num2 = P_0.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				P_0.Rows[i].Cells[1].Value = num;
				num++;
			}
		}
	}

	private void m5XpTr7fDuU(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo1.Text));
		tbCodigo1.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum1.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo1.Text = frmPesquisaMateriais2.modelo;
		tbFabricante1.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}

	private void UirpT9B4pOC(object P_0, MouseEventArgs P_1)
	{
		checked
		{
			if (CKEdicaoMultiplas.Checked)
			{
				int num = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgBornes.Rows[i].Selected && !CKEdicaoMultiplas.Checked)
					{
						dgBornes.Rows[i].Selected = false;
					}
				}
			}
			int num2 = dgBornes.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgBornes.Rows[num3].Selected)
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			tEmpTljS2iw(Conversions.ToInteger(dgBornes.Rows[num3].Cells[5].Value));
		}
	}

	private void G7wpTz5J00s(object P_0, MouseEventArgs P_1)
	{
		if (CKEdicaoMultiplas.Checked)
		{
			return;
		}
		DataGridView.HitTestInfo hitTestInfo = dgBornes.HitTest(P_1.X, P_1.Y);
		if (hitTestInfo.RowIndex >= 0)
		{
			DataGridViewRow data = dgBornes.Rows[hitTestInfo.RowIndex];
			Wt4phaMFEc0 = 2;
			Happh8ZEYMe = hitTestInfo.RowIndex;
			dgBornes.Rows[Happh8ZEYMe].Selected = true;
			dgBornes.DoDragDrop(data, DragDropEffects.All);
			if (hitTestInfo.ColumnIndex == 6)
			{
				clsBlocos.MostraBloco(Conversions.ToString(dgBornes.Rows[Happh8ZEYMe].Cells[7].Value));
			}
			ckSul.Checked = false;
			ckNorte.Checked = false;
		}
	}

	private void ItgpJWTpbpM(object P_0, DragEventArgs P_1)
	{
		if (!CKEdicaoMultiplas.Checked)
		{
			P_1.Effect = DragDropEffects.Copy;
		}
	}

	private void APkpJpHtFfd(object P_0, DragEventArgs P_1)
	{
		if (CKEdicaoMultiplas.Checked)
		{
			return;
		}
		Point point = dgBornes.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgBornes.HitTest(point.X, point.Y);
		if (Happh8ZEYMe == hitTestInfo.RowIndex)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		int rowIndex = hitTestInfo.RowIndex;
		bool flag = true;
		checked
		{
			if (rowIndex > -1)
			{
				if (rowIndex < 0)
				{
					return;
				}
				dgBornes.Rows.Insert(rowIndex, dataGridViewRow.Cells[0].Value, dataGridViewRow.Cells[1].Value, dataGridViewRow.Cells[2].Value, dataGridViewRow.Cells[3].Value, dataGridViewRow.Cells[4].Value, dataGridViewRow.Cells[5].Value, dataGridViewRow.Cells[6].Value, dataGridViewRow.Cells[7].Value, dataGridViewRow.Cells[8].Value, dataGridViewRow.Cells[9].Value, dataGridViewRow.Cells[10].Value, dataGridViewRow.Cells[11].Value, dataGridViewRow.Cells[12].Value, dataGridViewRow.Cells[13].Value, dataGridViewRow.Cells[14].Value, dataGridViewRow.Cells[15].Value, dataGridViewRow.Cells[16].Value, dataGridViewRow.Cells[17].Value);
				_ = dgBornes.SelectedRows[0].Index;
				if (Happh8ZEYMe > rowIndex)
				{
					Happh8ZEYMe++;
				}
				dgBornes.Rows.RemoveAt(Happh8ZEYMe);
				btSalvar.Enabled = true;
			}
			foreach (DataGridViewRow item in (IEnumerable)dgBornes.Rows)
			{
				dgBornes.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
			if (!flag)
			{
				return;
			}
			if (dgBornes.Rows.Count - 1 >= 2 && dgBornes.Rows.Count - 1 > 0)
			{
				int num = dgBornes.Rows.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					int num2 = dgBornes.Rows.Count - 2;
					for (int j = num2; j >= 0; j += -1)
					{
						double num3 = Conversions.ToDouble(dgBornes.Rows[j].Cells[1].Value);
						double num4 = Conversions.ToDouble(dgBornes.Rows[j + 1].Cells[1].Value);
						if (num3 > num4)
						{
							dgBornes.Rows[j + 1].Cells[1].Value = num3;
							dgBornes.Rows[j].Cells[1].Value = num4;
						}
					}
				}
			}
			int num5 = dgBornes.Rows.Count - 2;
			for (int k = 0; k <= num5; k++)
			{
				int num6 = k;
				int num7 = dgBornes.Rows.Count - 2;
				for (int l = num6; l <= num7; l++)
				{
					double num8 = Conversions.ToDouble(dgBornes.Rows[l].Cells[1].Value);
					double num9 = Conversions.ToDouble(dgBornes.Rows[l + 1].Cells[1].Value);
					if (num8 == num9)
					{
						dgBornes.Rows[l].Cells[1].Value = Operators.AddObject(dgBornes.Rows[l].Cells[1].Value, 1);
					}
				}
			}
		}
	}

	private void WhxpJT5PWkH(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
		{
			return;
		}
		bool flag = true;
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (Operators.ConditionalCompareObjectNotEqual(dgBornes.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			int num2 = dgBornes.Rows.Count - 1;
			for (int j = num2; j >= 0; j += -1)
			{
				if (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[j].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					dgBornes.Rows.RemoveAt(j);
					btSalvar.Enabled = true;
				}
			}
			if (btSalvar.Enabled)
			{
				int num3 = dgBornes.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					dgBornes.Rows[k].Cells[1].Value = k + 1;
				}
				DataGridView dg = dgBornes;
				ordenarBornesPelaOrdem(ref dg);
				dgBornes = dg;
			}
			GuardaPosicaoPainel();
			y0hphw4tbHT = true;
			SalvarAlteracoes();
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			TBPesquisa.Enabled = true;
			TBPesquisa.Focus();
			BtNumerar.Enabled = true;
			int num4 = dgReguas.Rows.Count - 1;
			for (int l = 0; l <= num4; l++)
			{
				if (dgReguas.Rows[l].Selected && Operators.ConditionalCompareObjectEqual(dgReguas.Rows[l].Cells[1].Value, "???", TextCompare: true))
				{
					dgReguas.Rows.RemoveAt(l);
					break;
				}
			}
			RecuperaPosicaoPainel();
		}
	}
}
