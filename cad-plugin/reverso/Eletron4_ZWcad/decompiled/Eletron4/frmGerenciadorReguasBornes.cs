using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;
using zgryP3p0xulXcIZvObyh;

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
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btBorneDuplo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual ComboBox CBMigraRegua
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btMigrarBornes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual DataGridView dgReguas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btAtribuiLM
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual DataGridView dgBornes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_Todos
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_IndefinidosFinal
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button BtIndefinirBornesSel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button BtNumerar
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_INT_PCV
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_POT_CL
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_POT_LC
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_PLC
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_PCL
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btSalvar
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual CheckBox CKEdicaoMultiplas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btDiminuiRecuo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btAumentaRecuo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox tbRecuo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LbFiltro
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button BTExportaEXCEL
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button BTImportaEXCEL
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btOrdenarAZ
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btInsereReservaEntre
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_PG_POT_CL
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_PG_POT_LC
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox8
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btAtribuiOrientacao
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual CheckBox ckSul
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual CheckBox ckNorte
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox9
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button Button1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox tbBlocoLayout
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btSelecionaBlocoLayout
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual DataGridView dgBornesExtra
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox10
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox TBExtras
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button BTExtra
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btRomoveReservas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btUltimoChassi
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btPrimeiroChassi
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btBaixoChassi
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btCimaChassi
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox11
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button BTLimpaGeral
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label lbFabricante
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label lbModelo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label lbDesc
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label lbCodigo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox tbFabricante1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox tbModelo1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox tbDescricaoResum1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox tbCodigo1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btPesquisaLM1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerStepThrough]
	private void E73pTjp5X4X()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmGerenciadorReguasBornes()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zh8pTLEpWbP(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kk7pTwmtH1d(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ixCpTxBxRrK(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gQfpTbrII22(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BbDpTMwAdf7(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wwipTOaTPTN(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EAPpTIkm5Ev(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LW8pT7oRY6V(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void baspTqYKYAj(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qmxpTanao3n(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LnXpT86pnWd(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sRypTNv2KVl(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void N13pTFnReVm(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string verificaTipoDosBornes()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OrdenarAZ()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OrdenarNumAZ()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ColocaNaOrdem()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jFUpTQdR02S(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MoveExtras()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecuperaExtras()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NeSpTPajwhg(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GuardaPosicaoPainel()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecuperaPosicaoPainel()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vdGpTcMrMZg(object P_0, DataGridViewCellEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wjGpTKcuHAM(object P_0, KeyEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I5TpTeQpF5A()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void YhGpT2RXFdF()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ProximoBorneReserva(ref DataGridView dg, ref int iMax, ref double Ordem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int EncontraUltimoBorneReal_MaisUM(ref DataGridView dg, ref double Ordem)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaPCL(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaPLC(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaPCL_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaPLC_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaPLCPot_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaPCLPot_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MoveReservasParaOFinal(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PhNpT3PkGtc(object P_0, KeyEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oVFpTnIV4FU(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sdrpT1KV76k()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tEmpTljS2iw(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ubUpT5W6NEm(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VptpT0CHvT7(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SalvarAlteracoes()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaPaineiseReguasNoDG(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, string sPesquisa)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaDgPaineisReguas(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsBornesNoDG(ref DataGridView dg, DeclaracoesEntidades.StructureBorne[] mBornes, ref int iNumUnico)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void formataDgBornes(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaColunasDGBornes(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RXgpTRBo72Y(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaJanela()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kRSpTmk4W2a(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool P4KpTXkfaOM(int P_0, int P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Mv6pTUcTHAV(object P_0, KeyEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aplpTyiiAFx(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I4QpTgUjgt7(object P_0, KeyEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExisteBornesIguais(ref Worksheet oSheet)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExisteBornesIguaisOLD(ref Worksheet oSheet)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ordenarBornesPelaOrdem(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SVepTATWga2(object P_0, DataGridViewCellEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sZWpTsyHti4(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yiFpTBRR6OT(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Lk3pTV132w9(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QBCpTuiTtJS(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CCxpTEw5VKg(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QlApTZTu6Vq(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void I9MpTiyAmTL(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DFGpTSPb0s4(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RbppT47GGo6(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kNfpTCl05Jp(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J78pTYiPiBe(ref DataGridView P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void m5XpTr7fDuU(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UirpT9B4pOC(object P_0, MouseEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void G7wpTz5J00s(object P_0, MouseEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ItgpJWTpbpM(object P_0, DragEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void APkpJpHtFfd(object P_0, DragEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WhxpJT5PWkH(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static frmGerenciadorReguasBornes()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
