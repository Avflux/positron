using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using YhamV21aratNE3b4GFK;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmDispPrincipal : Form
{
	private IContainer YwbEkZDUVA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GBVisualizacao")]
	private GroupBox E8UEdsuDkj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("CKAlternativo")]
	private CheckBox tylEfNEaZ6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKNome")]
	private CheckBox TAjEDJ38XQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btTrocaModelo")]
	private Button rVcEvej3VW;

	[AccessedThroughProperty("btSeleciona")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button a3hE6OjvPe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDistancia")]
	[CompilerGenerated]
	private TextBox IgqEtO3aw3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistancia")]
	private Label K05EjtgNU4;

	[AccessedThroughProperty("tbAlternativo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox jXvELmiQlC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbTerminais")]
	private TextBox KsyEww2vja;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNome2")]
	private TextBox kYDExdJe5Z;

	[AccessedThroughProperty("tbNome1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox Da6Ebc2jnv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbModelos")]
	private ComboBox aaiEMq5AkU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPainel")]
	private ComboBox vQ2EOT1Iq0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBAlternativo")]
	private Label Eh7EI568xF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LBModelo")]
	private Label U1bE7Kkf5i;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	private DataGridView loEEqh6Rkd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserir")]
	private Button LsPEaHmT3k;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("iDWG")]
	private PictureBox T6oE8GSXEY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBTerminais")]
	[CompilerGenerated]
	private Label zeTENPFWsa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBNome2")]
	private Label gTNEFt8Cq0;

	[CompilerGenerated]
	[AccessedThroughProperty("LBNome1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label hDSEQusvQU;

	[AccessedThroughProperty("LBPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label SoxEPTED5P;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip mX1EcnKaZ6;

	[AccessedThroughProperty("btEditar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button IhlEKTtQuc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox PqKEeoj9hE;

	[CompilerGenerated]
	[AccessedThroughProperty("tbBlocoLayout")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox UX6E21qXGj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBlocoTopografico")]
	private TextBox VcLE3N3iUa;

	[AccessedThroughProperty("btSelecionaBlocoLayout")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button E1kEn5NIBq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbLayout")]
	[CompilerGenerated]
	private Label o5DE12iJ4J;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecionaBlocoTopo")]
	private Button trxElDcYIr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbTopografico")]
	private Label Su7E5QyuBq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBFiltro")]
	private Label fTVE025dMp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBPesquisa")]
	private TextBox w1oERDoRCU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox shAEmaJYPf;

	[AccessedThroughProperty("BTAtualizaModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button HAhEX7eP2i;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBModeloVisualizar")]
	[CompilerGenerated]
	private ComboBox zGiEUrtlbi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbModelosReles")]
	private Label G5YEyu36XM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox NpLEg5vYba;

	[AccessedThroughProperty("lbFabricante")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label qk4EAFrJRR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private Label qSCEsDS4tM;

	[CompilerGenerated]
	[AccessedThroughProperty("lbDesc")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label aL3EBghtTy;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbCodigo")]
	private Label vkrEVs0h1c;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbFabricante2")]
	private TextBox CIrEuSAdhj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFabricante1")]
	[CompilerGenerated]
	private TextBox WG9EEcWdDA;

	[AccessedThroughProperty("tbModelo2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox mtXEZ5G9JN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbModelo1")]
	[CompilerGenerated]
	private TextBox lHCEi2sYh1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricaoResum2")]
	private TextBox ldgESu4x9F;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCodigo2")]
	private TextBox DSwE4C3HTr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbCodigo1")]
	private TextBox XBYECXsRtl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisaLM2")]
	[CompilerGenerated]
	private Button PrAEYX2DMh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisaLM1")]
	private Button I6PErqYkg1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricaoResum1")]
	private TextBox LsAE9LTZIm;

	private Declaracoes2.MDispPrincipal gpHEzKm55X;

	private bool GO7ZWcBWWx;

	private object[,] AuaZpovalE;

	private DeclaracoesEntidades.StructureDispositivo LMdZTA0SF8;

	private string PHLZJm9bxv;

	private ObjectId YL3ZhXXSqg;

	private Declaracoes2.MModelosDeContatos[] VoLZoqJdbS;

	private Declaracoes2.StructureContatosAuxiliares[] dVrZGW0V55;

	private cDadosLM.StructureLM[] aeeZH8LOPC;

	private string kD1ZkWq6NT;

	private string xAbZdOtx4l;

	private DeclaracoesEntidades.StructureDispositivo obiZf08jL7;

	private string g5wZDfka16;

	private List<string> A27Zvqfs4P;

	private int FOgZ6L5AUo;

	private bool nxcZtlpMT6;

	private bool a6VZjhOvkx;

	private string grgZL9oIbg;

	private bool zNcZwvjTcp;

	private DeclaracoesClonar.structureMaterial[] pZYZx3YSYK;

	internal virtual GroupBox GBVisualizacao
	{
		[CompilerGenerated]
		get
		{
			return E8UEdsuDkj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			E8UEdsuDkj = value;
		}
	}

	internal virtual CheckBox CKAlternativo
	{
		[CompilerGenerated]
		get
		{
			return tylEfNEaZ6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tylEfNEaZ6 = value;
		}
	}

	internal virtual CheckBox CKNome
	{
		[CompilerGenerated]
		get
		{
			return TAjEDJ38XQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TAjEDJ38XQ = value;
		}
	}

	internal virtual Button btTrocaModelo
	{
		[CompilerGenerated]
		get
		{
			return rVcEvej3VW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kspumE9gv6;
			Button button = rVcEvej3VW;
			if (button != null)
			{
				button.Click -= value2;
			}
			rVcEvej3VW = value;
			button = rVcEvej3VW;
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
			return a3hE6OjvPe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fVvu5BdcSs;
			Button button = a3hE6OjvPe;
			if (button != null)
			{
				button.Click -= value2;
			}
			a3hE6OjvPe = value;
			button = a3hE6OjvPe;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbDistancia
	{
		[CompilerGenerated]
		get
		{
			return IgqEtO3aw3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IgqEtO3aw3 = value;
		}
	}

	internal virtual Label LBDistancia
	{
		[CompilerGenerated]
		get
		{
			return K05EjtgNU4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			K05EjtgNU4 = value;
		}
	}

	internal virtual TextBox tbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return jXvELmiQlC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = InJuYtiVSb;
			TextBox textBox = jXvELmiQlC;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			jXvELmiQlC = value;
			textBox = jXvELmiQlC;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbTerminais
	{
		[CompilerGenerated]
		get
		{
			return KsyEww2vja;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KsyEww2vja = value;
		}
	}

	internal virtual TextBox tbNome2
	{
		[CompilerGenerated]
		get
		{
			return kYDExdJe5Z;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = bynuCpPIPF;
			TextBox textBox = kYDExdJe5Z;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			kYDExdJe5Z = value;
			textBox = kYDExdJe5Z;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbNome1
	{
		[CompilerGenerated]
		get
		{
			return Da6Ebc2jnv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = LdOu4eY7kB;
			TextBox textBox = Da6Ebc2jnv;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			Da6Ebc2jnv = value;
			textBox = Da6Ebc2jnv;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual ComboBox cbModelos
	{
		[CompilerGenerated]
		get
		{
			return aaiEMq5AkU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = pD0uslYkxx;
			MouseEventHandler value3 = jH7uBLUf8d;
			EventHandler value4 = fu3uVcP3nb;
			EventHandler value5 = kOBEH5AsAE;
			ComboBox comboBox = aaiEMq5AkU;
			if (comboBox != null)
			{
				comboBox.KeyUp -= value2;
				comboBox.MouseUp -= value3;
				comboBox.SelectedIndexChanged -= value4;
				comboBox.TextChanged -= value5;
			}
			aaiEMq5AkU = value;
			comboBox = aaiEMq5AkU;
			if (comboBox != null)
			{
				comboBox.KeyUp += value2;
				comboBox.MouseUp += value3;
				comboBox.SelectedIndexChanged += value4;
				comboBox.TextChanged += value5;
			}
		}
	}

	internal virtual ComboBox cbPainel
	{
		[CompilerGenerated]
		get
		{
			return vQ2EOT1Iq0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nfiur9QfSf;
			ComboBox comboBox = vQ2EOT1Iq0;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			vQ2EOT1Iq0 = value;
			comboBox = vQ2EOT1Iq0;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Label LBAlternativo
	{
		[CompilerGenerated]
		get
		{
			return Eh7EI568xF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Eh7EI568xF = value;
		}
	}

	internal virtual Label LBModelo
	{
		[CompilerGenerated]
		get
		{
			return U1bE7Kkf5i;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			U1bE7Kkf5i = value;
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return loEEqh6Rkd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = sofuE7AIwp;
			KeyEventHandler value3 = NuOuZv8bbT;
			KeyEventHandler value4 = r28ui2F5HX;
			DataGridView dataGridView = loEEqh6Rkd;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
			}
			loEEqh6Rkd = value;
			dataGridView = loEEqh6Rkd;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return LsPEaHmT3k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gtJuRH7FfO;
			Button button = LsPEaHmT3k;
			if (button != null)
			{
				button.Click -= value2;
			}
			LsPEaHmT3k = value;
			button = LsPEaHmT3k;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual PictureBox iDWG
	{
		[CompilerGenerated]
		get
		{
			return T6oE8GSXEY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			T6oE8GSXEY = value;
		}
	}

	internal virtual Label LBTerminais
	{
		[CompilerGenerated]
		get
		{
			return zeTENPFWsa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zeTENPFWsa = value;
		}
	}

	internal virtual Label LBNome2
	{
		[CompilerGenerated]
		get
		{
			return gTNEFt8Cq0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gTNEFt8Cq0 = value;
		}
	}

	internal virtual Label LBNome1
	{
		[CompilerGenerated]
		get
		{
			return hDSEQusvQU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hDSEQusvQU = value;
		}
	}

	internal virtual Label LBPainel
	{
		[CompilerGenerated]
		get
		{
			return SoxEPTED5P;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SoxEPTED5P = value;
		}
	}

	internal virtual Button btEditar
	{
		[CompilerGenerated]
		get
		{
			return IhlEKTtQuc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sl9uz5i1CN;
			Button button = IhlEKTtQuc;
			if (button != null)
			{
				button.Click -= value2;
			}
			IhlEKTtQuc = value;
			button = IhlEKTtQuc;
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
			return PqKEeoj9hE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PqKEeoj9hE = value;
		}
	}

	internal virtual TextBox tbBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return UX6E21qXGj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UX6E21qXGj = value;
		}
	}

	internal virtual TextBox tbBlocoTopografico
	{
		[CompilerGenerated]
		get
		{
			return VcLE3N3iUa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VcLE3N3iUa = value;
		}
	}

	internal virtual Button btSelecionaBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return E1kEn5NIBq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MwLETUjXl7;
			Button button = E1kEn5NIBq;
			if (button != null)
			{
				button.Click -= value2;
			}
			E1kEn5NIBq = value;
			button = E1kEn5NIBq;
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
			return o5DE12iJ4J;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o5DE12iJ4J = value;
		}
	}

	internal virtual Button btSelecionaBlocoTopo
	{
		[CompilerGenerated]
		get
		{
			return trxElDcYIr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DLAEWRhxUt;
			Button button = trxElDcYIr;
			if (button != null)
			{
				button.Click -= value2;
			}
			trxElDcYIr = value;
			button = trxElDcYIr;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbTopografico
	{
		[CompilerGenerated]
		get
		{
			return Su7E5QyuBq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Su7E5QyuBq = value;
		}
	}

	internal virtual Label LBFiltro
	{
		[CompilerGenerated]
		get
		{
			return fTVE025dMp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fTVE025dMp = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return w1oERDoRCU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = fsTEpPDG2Y;
			TextBox textBox = w1oERDoRCU;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			w1oERDoRCU = value;
			textBox = w1oERDoRCU;
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
			return shAEmaJYPf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			shAEmaJYPf = value;
		}
	}

	internal virtual Button BTAtualizaModelo
	{
		[CompilerGenerated]
		get
		{
			return HAhEX7eP2i;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gwvEJEMs19;
			Button button = HAhEX7eP2i;
			if (button != null)
			{
				button.Click -= value2;
			}
			HAhEX7eP2i = value;
			button = HAhEX7eP2i;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox CBModeloVisualizar
	{
		[CompilerGenerated]
		get
		{
			return zGiEUrtlbi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NK0EhuTD8B;
			ComboBox comboBox = zGiEUrtlbi;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			zGiEUrtlbi = value;
			comboBox = zGiEUrtlbi;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Label lbModelosReles
	{
		[CompilerGenerated]
		get
		{
			return G5YEyu36XM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			G5YEyu36XM = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return NpLEg5vYba;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NpLEg5vYba = value;
		}
	}

	internal virtual Label lbFabricante
	{
		[CompilerGenerated]
		get
		{
			return qk4EAFrJRR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qk4EAFrJRR = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return qSCEsDS4tM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qSCEsDS4tM = value;
		}
	}

	internal virtual Label lbDesc
	{
		[CompilerGenerated]
		get
		{
			return aL3EBghtTy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aL3EBghtTy = value;
		}
	}

	internal virtual Label lbCodigo
	{
		[CompilerGenerated]
		get
		{
			return vkrEVs0h1c;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vkrEVs0h1c = value;
		}
	}

	internal virtual TextBox tbFabricante2
	{
		[CompilerGenerated]
		get
		{
			return CIrEuSAdhj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CIrEuSAdhj = value;
		}
	}

	internal virtual TextBox tbFabricante1
	{
		[CompilerGenerated]
		get
		{
			return WG9EEcWdDA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WG9EEcWdDA = value;
		}
	}

	internal virtual TextBox tbModelo2
	{
		[CompilerGenerated]
		get
		{
			return mtXEZ5G9JN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mtXEZ5G9JN = value;
		}
	}

	internal virtual TextBox tbModelo1
	{
		[CompilerGenerated]
		get
		{
			return lHCEi2sYh1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lHCEi2sYh1 = value;
		}
	}

	internal virtual TextBox tbDescricaoResum2
	{
		[CompilerGenerated]
		get
		{
			return ldgESu4x9F;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ldgESu4x9F = value;
		}
	}

	internal virtual TextBox tbCodigo2
	{
		[CompilerGenerated]
		get
		{
			return DSwE4C3HTr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DSwE4C3HTr = value;
		}
	}

	internal virtual TextBox tbCodigo1
	{
		[CompilerGenerated]
		get
		{
			return XBYECXsRtl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XBYECXsRtl = value;
		}
	}

	internal virtual Button btPesquisaLM2
	{
		[CompilerGenerated]
		get
		{
			return PrAEYX2DMh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nuXEG7FsTM;
			Button button = PrAEYX2DMh;
			if (button != null)
			{
				button.Click -= value2;
			}
			PrAEYX2DMh = value;
			button = PrAEYX2DMh;
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
			return I6PErqYkg1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FpxEo9SKAx;
			Button button = I6PErqYkg1;
			if (button != null)
			{
				button.Click -= value2;
			}
			I6PErqYkg1 = value;
			button = I6PErqYkg1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbDescricaoResum1
	{
		[CompilerGenerated]
		get
		{
			return LsAE9LTZIm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LsAE9LTZIm = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && YwbEkZDUVA != null)
			{
				YwbEkZDUVA.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void WbLu1stiAq()
	{
		YwbEkZDUVA = new Container();
		GBVisualizacao = new GroupBox();
		CBModeloVisualizar = new ComboBox();
		CKAlternativo = new CheckBox();
		CKNome = new CheckBox();
		lbModelosReles = new Label();
		btTrocaModelo = new Button();
		btSeleciona = new Button();
		tbDistancia = new TextBox();
		LBDistancia = new Label();
		tbAlternativo = new TextBox();
		tbTerminais = new TextBox();
		tbNome2 = new TextBox();
		tbNome1 = new TextBox();
		cbModelos = new ComboBox();
		cbPainel = new ComboBox();
		LBAlternativo = new Label();
		LBModelo = new Label();
		dg = new DataGridView();
		btInserir = new Button();
		iDWG = new PictureBox();
		LBTerminais = new Label();
		LBNome2 = new Label();
		LBNome1 = new Label();
		LBPainel = new Label();
		FDqpBiUmZij(new ToolTip(YwbEkZDUVA));
		btEditar = new Button();
		GroupBox1 = new GroupBox();
		tbBlocoLayout = new TextBox();
		tbBlocoTopografico = new TextBox();
		lbTopografico = new Label();
		lbLayout = new Label();
		btSelecionaBlocoLayout = new Button();
		btSelecionaBlocoTopo = new Button();
		LBFiltro = new Label();
		TBPesquisa = new TextBox();
		GroupBox2 = new GroupBox();
		BTAtualizaModelo = new Button();
		GroupBox4 = new GroupBox();
		lbFabricante = new Label();
		Label1 = new Label();
		lbDesc = new Label();
		lbCodigo = new Label();
		tbFabricante2 = new TextBox();
		tbFabricante1 = new TextBox();
		tbModelo2 = new TextBox();
		tbModelo1 = new TextBox();
		tbCodigo2 = new TextBox();
		tbCodigo1 = new TextBox();
		btPesquisaLM2 = new Button();
		btPesquisaLM1 = new Button();
		tbDescricaoResum1 = new TextBox();
		tbDescricaoResum2 = new TextBox();
		GBVisualizacao.SuspendLayout();
		((ISupportInitialize)dg).BeginInit();
		((ISupportInitialize)iDWG).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox4.SuspendLayout();
		SuspendLayout();
		GBVisualizacao.Controls.Add(CBModeloVisualizar);
		GBVisualizacao.Controls.Add(CKAlternativo);
		GBVisualizacao.Controls.Add(CKNome);
		GBVisualizacao.Controls.Add(lbModelosReles);
		GBVisualizacao.Location = new Point(238, 180);
		GBVisualizacao.Name = "GBVisualizacao";
		GBVisualizacao.Size = new Size(237, 89);
		GBVisualizacao.TabIndex = 53;
		GBVisualizacao.TabStop = false;
		GBVisualizacao.Text = "GBVisualização";
		CBModeloVisualizar.FormattingEnabled = true;
		CBModeloVisualizar.Location = new Point(9, 62);
		CBModeloVisualizar.Name = "CBModeloVisualizar";
		CBModeloVisualizar.Size = new Size(222, 21);
		CBModeloVisualizar.TabIndex = 169;
		CKAlternativo.AutoSize = true;
		CKAlternativo.Location = new Point(120, 18);
		CKAlternativo.Name = "CKAlternativo";
		CKAlternativo.Size = new Size(118, 17);
		CKAlternativo.TabIndex = 33;
		CKAlternativo.Text = "CKNomeAlternativo";
		CKAlternativo.UseVisualStyleBackColor = true;
		CKNome.AutoSize = true;
		CKNome.Location = new Point(6, 19);
		CKNome.Name = "CKNome";
		CKNome.Size = new Size(108, 17);
		CKNome.TabIndex = 32;
		CKNome.Text = "CKNomesVisiveis";
		CKNome.UseVisualStyleBackColor = true;
		lbModelosReles.AutoSize = true;
		lbModelosReles.Location = new Point(9, 43);
		lbModelosReles.Name = "lbModelosReles";
		lbModelosReles.Size = new Size(77, 13);
		lbModelosReles.TabIndex = 174;
		lbModelosReles.Text = "Modelos Relés";
		btTrocaModelo.FlatStyle = FlatStyle.Flat;
		btTrocaModelo.ForeColor = SystemColors.Control;
		btTrocaModelo.Image = Resources.Selecionar_32;
		btTrocaModelo.Location = new Point(312, 387);
		btTrocaModelo.Name = "btTrocaModelo";
		btTrocaModelo.Size = new Size(40, 40);
		btTrocaModelo.TabIndex = 52;
		btTrocaModelo.UseVisualStyleBackColor = true;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_32;
		btSeleciona.Location = new Point(250, 387);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(40, 40);
		btSeleciona.TabIndex = 43;
		btSeleciona.Tag = "";
		btSeleciona.UseVisualStyleBackColor = true;
		tbDistancia.Location = new Point(186, 16);
		tbDistancia.Name = "tbDistancia";
		tbDistancia.Size = new Size(28, 20);
		tbDistancia.TabIndex = 39;
		tbDistancia.TextAlign = HorizontalAlignment.Center;
		LBDistancia.AutoSize = true;
		LBDistancia.Location = new Point(3, 19);
		LBDistancia.Name = "LBDistancia";
		LBDistancia.Size = new Size(188, 13);
		LBDistancia.TabIndex = 48;
		LBDistancia.Text = "LBDistancia entre terminais do Modelo";
		tbAlternativo.Location = new Point(400, 62);
		tbAlternativo.Name = "tbAlternativo";
		tbAlternativo.Size = new Size(75, 20);
		tbAlternativo.TabIndex = 35;
		tbTerminais.Location = new Point(400, 102);
		tbTerminais.Name = "tbTerminais";
		tbTerminais.Size = new Size(75, 20);
		tbTerminais.TabIndex = 37;
		tbNome2.Location = new Point(319, 62);
		tbNome2.Name = "tbNome2";
		tbNome2.Size = new Size(75, 20);
		tbNome2.TabIndex = 34;
		tbNome1.Location = new Point(238, 62);
		tbNome1.Name = "tbNome1";
		tbNome1.Size = new Size(75, 20);
		tbNome1.TabIndex = 32;
		cbModelos.FormattingEnabled = true;
		cbModelos.Location = new Point(238, 101);
		cbModelos.Name = "cbModelos";
		cbModelos.Size = new Size(156, 21);
		cbModelos.TabIndex = 38;
		cbPainel.FormattingEnabled = true;
		cbPainel.Location = new Point(238, 22);
		cbPainel.Name = "cbPainel";
		cbPainel.Size = new Size(237, 21);
		cbPainel.TabIndex = 31;
		LBAlternativo.AutoSize = true;
		LBAlternativo.Location = new Point(400, 46);
		LBAlternativo.Name = "LBAlternativo";
		LBAlternativo.Size = new Size(98, 13);
		LBAlternativo.TabIndex = 47;
		LBAlternativo.Text = "LBNomeAlternativo";
		LBModelo.AutoSize = true;
		LBModelo.Location = new Point(238, 85);
		LBModelo.Name = "LBModelo";
		LBModelo.Size = new Size(55, 13);
		LBModelo.TabIndex = 46;
		LBModelo.Text = "LBModelo";
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToOrderColumns = true;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dg.BorderStyle = BorderStyle.Fixed3D;
		dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(11, 170);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(221, 259);
		dg.TabIndex = 45;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.OK_32;
		btInserir.Location = new Point(432, 387);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 40);
		btInserir.TabIndex = 41;
		btInserir.UseVisualStyleBackColor = true;
		iDWG.BackColor = SystemColors.Desktop;
		iDWG.Location = new Point(12, 12);
		iDWG.Name = "iDWG";
		iDWG.Size = new Size(210, 128);
		iDWG.SizeMode = PictureBoxSizeMode.Zoom;
		iDWG.TabIndex = 33;
		iDWG.TabStop = false;
		LBTerminais.AutoSize = true;
		LBTerminais.Location = new Point(400, 86);
		LBTerminais.Name = "LBTerminais";
		LBTerminais.Size = new Size(65, 13);
		LBTerminais.TabIndex = 44;
		LBTerminais.Text = "LBTerminais";
		LBNome2.AutoSize = true;
		LBNome2.Location = new Point(319, 46);
		LBNome2.Name = "LBNome2";
		LBNome2.Size = new Size(54, 13);
		LBNome2.TabIndex = 42;
		LBNome2.Text = "LBNome2";
		LBNome1.AutoSize = true;
		LBNome1.Location = new Point(238, 46);
		LBNome1.Name = "LBNome1";
		LBNome1.Size = new Size(54, 13);
		LBNome1.TabIndex = 40;
		LBNome1.Text = "LBNome1";
		LBPainel.AutoSize = true;
		LBPainel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBPainel.Location = new Point(238, 6);
		LBPainel.Name = "LBPainel";
		LBPainel.Size = new Size(49, 13);
		LBPainel.TabIndex = 36;
		LBPainel.Text = "LBPainel";
		btEditar.FlatStyle = FlatStyle.Flat;
		btEditar.ForeColor = SystemColors.Control;
		btEditar.Image = Resources.Editar;
		btEditar.Location = new Point(369, 387);
		btEditar.Name = "btEditar";
		btEditar.Size = new Size(40, 40);
		btEditar.TabIndex = 55;
		btEditar.Tag = "";
		btEditar.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(tbBlocoLayout);
		GroupBox1.Controls.Add(tbBlocoTopografico);
		GroupBox1.Controls.Add(lbTopografico);
		GroupBox1.Controls.Add(lbLayout);
		GroupBox1.Controls.Add(btSelecionaBlocoLayout);
		GroupBox1.Controls.Add(btSelecionaBlocoTopo);
		GroupBox1.Location = new Point(241, 273);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(234, 108);
		GroupBox1.TabIndex = 56;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		tbBlocoLayout.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoLayout.Location = new Point(9, 76);
		tbBlocoLayout.Name = "tbBlocoLayout";
		tbBlocoLayout.Size = new Size(185, 20);
		tbBlocoLayout.TabIndex = 177;
		tbBlocoTopografico.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoTopografico.Location = new Point(9, 32);
		tbBlocoTopografico.Name = "tbBlocoTopografico";
		tbBlocoTopografico.Size = new Size(185, 20);
		tbBlocoTopografico.TabIndex = 172;
		lbTopografico.AutoSize = true;
		lbTopografico.Location = new Point(6, 16);
		lbTopografico.Name = "lbTopografico";
		lbTopografico.Size = new Size(92, 13);
		lbTopografico.TabIndex = 173;
		lbTopografico.Text = "lbTOPOGRAFICO";
		lbLayout.AutoSize = true;
		lbLayout.Location = new Point(6, 60);
		lbLayout.Name = "lbLayout";
		lbLayout.Size = new Size(58, 13);
		lbLayout.TabIndex = 174;
		lbLayout.Text = "lbLAYOUT";
		btSelecionaBlocoLayout.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoLayout.ForeColor = SystemColors.Control;
		btSelecionaBlocoLayout.Image = Resources.Pesquisar_16;
		btSelecionaBlocoLayout.Location = new Point(200, 74);
		btSelecionaBlocoLayout.Name = "btSelecionaBlocoLayout";
		btSelecionaBlocoLayout.Size = new Size(22, 22);
		btSelecionaBlocoLayout.TabIndex = 176;
		btSelecionaBlocoLayout.UseVisualStyleBackColor = true;
		btSelecionaBlocoTopo.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoTopo.ForeColor = SystemColors.Control;
		btSelecionaBlocoTopo.Image = Resources.Pesquisar_16;
		btSelecionaBlocoTopo.Location = new Point(200, 30);
		btSelecionaBlocoTopo.Name = "btSelecionaBlocoTopo";
		btSelecionaBlocoTopo.Size = new Size(22, 22);
		btSelecionaBlocoTopo.TabIndex = 175;
		btSelecionaBlocoTopo.UseVisualStyleBackColor = true;
		LBFiltro.BorderStyle = BorderStyle.Fixed3D;
		LBFiltro.Location = new Point(12, 144);
		LBFiltro.Name = "LBFiltro";
		LBFiltro.Size = new Size(81, 20);
		LBFiltro.TabIndex = 167;
		LBFiltro.Text = "Filtro";
		LBFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(99, 144);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(123, 20);
		TBPesquisa.TabIndex = 166;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		GroupBox2.Controls.Add(BTAtualizaModelo);
		GroupBox2.Controls.Add(tbDistancia);
		GroupBox2.Controls.Add(LBDistancia);
		GroupBox2.Location = new Point(238, 130);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(244, 47);
		GroupBox2.TabIndex = 168;
		GroupBox2.TabStop = false;
		BTAtualizaModelo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTAtualizaModelo.FlatStyle = FlatStyle.Flat;
		BTAtualizaModelo.ForeColor = SystemColors.Control;
		BTAtualizaModelo.Image = Resources.Salvar_16;
		BTAtualizaModelo.Location = new Point(215, 14);
		BTAtualizaModelo.Name = "BTAtualizaModelo";
		BTAtualizaModelo.Size = new Size(22, 22);
		BTAtualizaModelo.TabIndex = 177;
		BTAtualizaModelo.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(lbFabricante);
		GroupBox4.Controls.Add(Label1);
		GroupBox4.Controls.Add(lbDesc);
		GroupBox4.Controls.Add(lbCodigo);
		GroupBox4.Controls.Add(tbFabricante2);
		GroupBox4.Controls.Add(tbFabricante1);
		GroupBox4.Controls.Add(tbModelo2);
		GroupBox4.Controls.Add(tbModelo1);
		GroupBox4.Controls.Add(tbCodigo2);
		GroupBox4.Controls.Add(tbCodigo1);
		GroupBox4.Controls.Add(btPesquisaLM2);
		GroupBox4.Controls.Add(btPesquisaLM1);
		GroupBox4.Controls.Add(tbDescricaoResum1);
		GroupBox4.Controls.Add(tbDescricaoResum2);
		GroupBox4.Location = new Point(11, 442);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(464, 89);
		GroupBox4.TabIndex = 172;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "GroupBox4";
		lbFabricante.Location = new Point(345, 17);
		lbFabricante.Name = "lbFabricante";
		lbFabricante.Size = new Size(111, 16);
		lbFabricante.TabIndex = 207;
		lbFabricante.Text = "Fabricante";
		Label1.Location = new Point(227, 16);
		Label1.Name = "Label1";
		Label1.Size = new Size(111, 16);
		Label1.TabIndex = 206;
		Label1.Text = "Modelo";
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
		tbFabricante2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante2.Location = new Point(333, 61);
		tbFabricante2.Name = "tbFabricante2";
		tbFabricante2.ReadOnly = true;
		tbFabricante2.Size = new Size(100, 20);
		tbFabricante2.TabIndex = 203;
		tbFabricante1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante1.Location = new Point(333, 35);
		tbFabricante1.Name = "tbFabricante1";
		tbFabricante1.ReadOnly = true;
		tbFabricante1.Size = new Size(100, 20);
		tbFabricante1.TabIndex = 202;
		tbModelo2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo2.Location = new Point(227, 61);
		tbModelo2.Name = "tbModelo2";
		tbModelo2.ReadOnly = true;
		tbModelo2.Size = new Size(100, 20);
		tbModelo2.TabIndex = 201;
		tbModelo1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo1.Location = new Point(227, 36);
		tbModelo1.Name = "tbModelo1";
		tbModelo1.ReadOnly = true;
		tbModelo1.Size = new Size(100, 20);
		tbModelo1.TabIndex = 200;
		tbCodigo2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo2.Location = new Point(8, 61);
		tbCodigo2.Name = "tbCodigo2";
		tbCodigo2.ReadOnly = true;
		tbCodigo2.Size = new Size(73, 20);
		tbCodigo2.TabIndex = 197;
		tbCodigo1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo1.Location = new Point(8, 36);
		tbCodigo1.Name = "tbCodigo1";
		tbCodigo1.ReadOnly = true;
		tbCodigo1.Size = new Size(73, 20);
		tbCodigo1.TabIndex = 196;
		btPesquisaLM2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM2.FlatStyle = FlatStyle.Flat;
		btPesquisaLM2.ForeColor = SystemColors.Control;
		btPesquisaLM2.Image = Resources.Pesquisar_16;
		btPesquisaLM2.Location = new Point(439, 59);
		btPesquisaLM2.Name = "btPesquisaLM2";
		btPesquisaLM2.Size = new Size(22, 22);
		btPesquisaLM2.TabIndex = 195;
		btPesquisaLM2.UseVisualStyleBackColor = true;
		btPesquisaLM1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM1.FlatStyle = FlatStyle.Flat;
		btPesquisaLM1.ForeColor = SystemColors.Control;
		btPesquisaLM1.Image = Resources.Pesquisar_16;
		btPesquisaLM1.Location = new Point(439, 33);
		btPesquisaLM1.Name = "btPesquisaLM1";
		btPesquisaLM1.Size = new Size(22, 24);
		btPesquisaLM1.TabIndex = 194;
		btPesquisaLM1.UseVisualStyleBackColor = true;
		tbDescricaoResum1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum1.Location = new Point(87, 36);
		tbDescricaoResum1.Name = "tbDescricaoResum1";
		tbDescricaoResum1.ReadOnly = true;
		tbDescricaoResum1.Size = new Size(134, 20);
		tbDescricaoResum1.TabIndex = 198;
		tbDescricaoResum2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum2.Location = new Point(87, 61);
		tbDescricaoResum2.Name = "tbDescricaoResum2";
		tbDescricaoResum2.ReadOnly = true;
		tbDescricaoResum2.Size = new Size(134, 20);
		tbDescricaoResum2.TabIndex = 199;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(484, 536);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox2);
		Controls.Add(LBFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(GroupBox1);
		Controls.Add(btEditar);
		Controls.Add(GBVisualizacao);
		Controls.Add(btTrocaModelo);
		Controls.Add(btSeleciona);
		Controls.Add(tbAlternativo);
		Controls.Add(tbTerminais);
		Controls.Add(tbNome2);
		Controls.Add(tbNome1);
		Controls.Add(cbModelos);
		Controls.Add(cbPainel);
		Controls.Add(LBAlternativo);
		Controls.Add(LBModelo);
		Controls.Add(dg);
		Controls.Add(btInserir);
		Controls.Add(iDWG);
		Controls.Add(LBTerminais);
		Controls.Add(LBNome2);
		Controls.Add(LBNome1);
		Controls.Add(LBPainel);
		MaximizeBox = false;
		MaximumSize = new Size(500, 1000);
		MinimizeBox = false;
		MinimumSize = new Size(500, 575);
		Name = "frmDispPrincipal";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "frmDispPrincipal";
		GBVisualizacao.ResumeLayout(performLayout: false);
		GBVisualizacao.PerformLayout();
		((ISupportInitialize)dg).EndInit();
		((ISupportInitialize)iDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return mX1EcnKaZ6;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		mX1EcnKaZ6 = WithEventsValue;
	}

	public frmDispPrincipal()
	{
		gpHEzKm55X = default;
		GO7ZWcBWWx = true;
		PHLZJm9bxv = "";
		aeeZH8LOPC = null;
		kD1ZkWq6NT = "";
		xAbZdOtx4l = "";
		obiZf08jL7 = default;
		g5wZDfka16 = "";
		A27Zvqfs4P = new List<string>();
		FOgZ6L5AUo = 0;
		nxcZtlpMT6 = false;
		a6VZjhOvkx = false;
		grgZL9oIbg = "";
		zNcZwvjTcp = false;
		try
		{
			a6VZjhOvkx = false;
			if (clsAuxiliar.BancoValido())
			{
				cDadosAccess.carregaDadosDWG();
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					WbLu1stiAq();
					if (Geral.ExisteForm("frmDispPrincipal"))
					{
						return;
					}
					clsDispositivo.EncontraModelosComContatos(ref A27Zvqfs4P);
					if (!((Operators.CompareString(DeclaracoesGeral.Conf.DirSimbologiaEletrica, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.DirSimbologiaEletrica)))
					{
						string prompt = Conversions.ToString(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1721], " "), DeclaracoesGeral.Conf.DirSimbologiaEletrica));
						Interaction.MsgBox(prompt, MsgBoxStyle.Information);
					}
					else
					{
						Application.ShowModelessDialog((Form)this);
						Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 625]);
						LBPainel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]);
						LBNome1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 627]);
						LBNome2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 628]);
						LBAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 629]);
						LBModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 630]);
						LBTerminais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]);
						LBFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
						LBDistancia.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 632]);
						GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]);
						lbCodigo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1245]);
						lbDesc.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
						LBModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
						lbFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]);
						GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 192]);
						lbTopografico.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 657]);
						lbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 658]);
						w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 975]));
						w8dpBZ0kvSD().SetToolTip(btTrocaModelo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 634]));
						w8dpBZ0kvSD().SetToolTip(btEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1108]));
						w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 635]));
						w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoTopo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
						w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoLayout, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
						GBVisualizacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 648]);
						CKNome.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 649]);
						CKAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 650]);
						CBModeloVisualizar.Items.Clear();
						lbModelosReles.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1744]);
						CBModeloVisualizar.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1745]));
						CBModeloVisualizar.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1746]));
						CBModeloVisualizar.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1747]));
						CBModeloVisualizar.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1748]));
						if (DeclaracoesGeral.Conf.ModeloBobina != 0)
						{
							if (DeclaracoesGeral.Conf.ModeloBobina != 1)
							{
								if (DeclaracoesGeral.Conf.ModeloBobina != 2)
								{
									if (DeclaracoesGeral.Conf.ModeloBobina == 3)
									{
										CBModeloVisualizar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1748]);
									}
								}
								else
								{
									CBModeloVisualizar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1747]);
								}
							}
							else
							{
								CBModeloVisualizar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1745]);
							}
						}
						else
						{
							CBModeloVisualizar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1746]);
						}
						FOgZ6L5AUo = DeclaracoesGeral.Conf.ModeloBobina;
						tbCodigo1.Text = Conversions.ToString(0);
						tbCodigo2.Text = Conversions.ToString(0);
						tbDistancia.Text = "1";
						iDWG.Image = null;
						CKNome.Checked = true;
						CKAlternativo.Checked = false;
						object[,] array = new object[3, 1]
						{
							{ "Bloco" },
							{ "Caminho" },
							{ "NomeCompleto" }
						};
						object[,] array2 = new object[3, 1]
						{
							{ "Bloco" },
							{ "Caminho" },
							{ "NomeCompleto" }
						};
						AuaZpovalE = new object[3, 1];
						AuaZpovalE[0, 0] = "Bloco";
						AuaZpovalE[1, 0] = "Caminho";
						AuaZpovalE[2, 0] = "NomeCompleto";
						if (!((Operators.CompareString(DeclaracoesGeral.Conf.DirSimbologiaEletrica, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.DirSimbologiaEletrica)))
						{
							tbNome1.Text = "";
							tbNome2.Text = "";
							tbTerminais.Text = "";
							tbAlternativo.Text = "";
							lyMuyffiou(gpHEzKm55X.bComplementar);
						}
						else
						{
							ref object[,] auaZpovalE = ref AuaZpovalE;
							ref object[,] reference = ref auaZpovalE;
							object mBlocos = auaZpovalE;
							clsDispositivo.CarregaBlocos(ref mBlocos, "P");
							reference = (object[,])mBlocos;
							DataGridView withEventsValue = dg;
							ref object[,] auaZpovalE2 = ref AuaZpovalE;
							reference = ref auaZpovalE2;
							mBlocos = auaZpovalE2;
							h7Rul7ZDlu(ref withEventsValue, ref mBlocos, TBPesquisa.Text);
							reference = (object[,])mBlocos;
							dg = withEventsValue;
						}
						ComboBox Combo = cbPainel;
						Dicionario.CarregaPaineis(ref Combo);
						cbPainel = Combo;
						DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref VoLZoqJdbS);
						Combo = cbModelos;
						clsDispositivo.carregaModelosNoCombo(ref Combo, ref VoLZoqJdbS);
						cbModelos = Combo;
						lyMuyffiou(gpHEzKm55X.bComplementar);
						xUVugDnmiA();
						cDadosLM cDadosLM2 = new cDadosLM();
						pZYZx3YSYK = cDadosLM2.CarregaDadosLMMatriz();
						cDadosLM2.fechaConexao();
						if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
						{
							object mBlocos = array;
							clsDispositivo.CarregaBlocosNaMatriz(ref mBlocos, DeclaracoesGeral.Conf.dirSimbologiaTopografico);
							array = (object[,])mBlocos;
						}
						if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
						{
							object mBlocos = array2;
							clsDispositivo.CarregaBlocosNaMatriz(ref mBlocos, DeclaracoesGeral.Conf.dirSimbologiaLayout);
							array2 = (object[,])mBlocos;
						}
						tbBlocoTopografico.Enabled = false;
						tbBlocoTopografico.BackColor = Color.Silver;
						tbBlocoTopografico.Enabled = false;
						if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
						{
							tbBlocoTopografico.BackColor = Color.White;
						}
						tbBlocoLayout.Enabled = false;
						tbBlocoLayout.BackColor = Color.Silver;
						tbBlocoLayout.Enabled = false;
						if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
						{
							tbBlocoLayout.BackColor = Color.White;
						}
						btTrocaModelo.Enabled = false;
						btEditar.Enabled = false;
						if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
						{
							Left = 0;
						}
						clsDispositivoAuxiliares.VerificaTamanhoContatosAuxiliares();
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
				}
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
		a6VZjhOvkx = true;
	}

	private void h7Rul7ZDlu(ref DataGridView P_0, ref object P_1, string P_2)
	{
		checked
		{
			try
			{
				bool flag = false;
				P_0.Rows.Clear();
				P_0.Columns.Clear();
				P_0.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 997]));
				P_0.Columns.Add("", "Caminho");
				P_0.Columns.Add("", "NomeCompleto");
				P_0.ColumnHeadersVisible = false;
				P_0.Columns[0].Visible = true;
				P_0.Columns[1].Visible = false;
				P_0.Columns[2].Visible = false;
				P_0.Columns[0].ReadOnly = false;
				P_0.Columns[1].ReadOnly = false;
				P_0.Columns[2].ReadOnly = false;
				P_0.MultiSelect = false;
				if (Information.UBound((Array)P_1, 2) >= 2 && Information.UBound((Array)P_1, 2) > 0)
				{
					int num = Information.UBound((Array)P_1, 2) - 1;
					for (int i = num; i >= 1; i += -1)
					{
						int num2 = i;
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, j }, null), NewLateBinding.LateIndexGet(P_1, new object[2]
							{
								0,
								j + 1
							}, null), TextCompare: true))
							{
								int num3 = 0;
								do
								{
									object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(P_1, new object[2]
									{
										num3,
										j + 1
									}, null));
									NewLateBinding.LateIndexSet(P_1, new object[3]
									{
										num3,
										j + 1,
										NewLateBinding.LateIndexGet(P_1, new object[2] { num3, j }, null)
									}, null);
									NewLateBinding.LateIndexSet(P_1, new object[3] { num3, j, objectValue }, null);
									num3++;
								}
								while (num3 <= 2);
							}
						}
					}
				}
				btInserir.Enabled = false;
				int num4 = Information.UBound((Array)P_1, 2);
				for (int k = 1; k <= num4; k++)
				{
					if (LikeOperator.LikeString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, k }, null).ToString().ToUpper(), "*" + P_2.ToUpper() + "*", CompareMethod.Text))
					{
						P_0.Rows.Add(Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 1, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 2, k }, null)));
						flag = true;
					}
				}
				if (!flag)
				{
					iDWG.Image = null;
				}
				else
				{
					P_0.Rows[0].Selected = true;
					iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(P_0.Rows[0].Cells[1].Value));
					btInserir.Enabled = true;
				}
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(P_0)) ? ((double)(P_0.Width - 4)) : ((double)(P_0.Width - 21)));
				P_0.Columns[0].Width = (int)Math.Round(a);
				P_0.Columns[1].Width = 0;
				P_0.Columns[2].Width = 0;
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

	private void fVvu5BdcSs(object P_0, EventArgs P_1)
	{
		gpHEzKm55X.sHandle = "";
		cbPainel.Text = "";
		cbModelos.Text = "";
		tbNome1.Text = "";
		tbNome2.Text = "";
		tbAlternativo.Text = "";
		tbDistancia.Text = "0";
		tbTerminais.Text = "";
		tbBlocoTopografico.Text = "";
		tbBlocoLayout.Text = "";
		tbCodigo1.Text = Conversions.ToString(0);
		tbDescricaoResum1.Text = "";
		tbModelo1.Text = "";
		tbFabricante1.Text = "";
		tbCodigo2.Text = Conversions.ToString(0);
		tbDescricaoResum2.Text = "";
		tbModelo2.Text = "";
		tbFabricante2.Text = "";
		tbBlocoLayout.Enabled = true;
		tbBlocoTopografico.Enabled = true;
		g5wZDfka16 = clsDispositivo.selecionaDispositivoPrincipalInserido(ref gpHEzKm55X, ref obiZf08jL7);
		if (Operators.CompareString(gpHEzKm55X.sHandle, "", TextCompare: true) == 0)
		{
			return;
		}
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(gpHEzKm55X.sNomeBloco, dg.Rows[i].Cells[2].Value, TextCompare: true))
				{
					dg.Rows[i].Selected = true;
					dg.CurrentCell = dg.Rows[i].Cells[0];
					TN8u908vU3();
					break;
				}
			}
			tbNome1.Text = gpHEzKm55X.sNome1;
			tbNome2.Text = gpHEzKm55X.sNome2;
			tbAlternativo.Text = gpHEzKm55X.sAlternativo;
			tbBlocoLayout.Enabled = true;
			tbBlocoTopografico.Enabled = true;
			cbPainel.Text = Dicionario.BuscaNomeDoPainel(gpHEzKm55X.iPainel);
			cbModelos.Text = clsDispositivo.BuscaNomeDoModelo(gpHEzKm55X.iIndexModelo, ref VoLZoqJdbS);
			grgZL9oIbg = cbModelos.Text;
			tbDistancia.Text = Conversions.ToString(Math.Round(gpHEzKm55X.dAltura, 2));
			MiWu0gbG4g(gpHEzKm55X.LM1, 1);
			MiWu0gbG4g(gpHEzKm55X.LM2, 2);
			tbBlocoTopografico.BackColor = Color.Silver;
			tbBlocoTopografico.Enabled = false;
			if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
			{
				tbBlocoTopografico.BackColor = Color.White;
			}
			tbBlocoLayout.BackColor = Color.Silver;
			tbBlocoLayout.Enabled = false;
			if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
			{
				tbBlocoLayout.BackColor = Color.White;
			}
			tbTerminais.Text = gpHEzKm55X.sTerminais;
			tbBlocoLayout.Text = gpHEzKm55X.sLayout;
			tbBlocoTopografico.Text = gpHEzKm55X.sTopografico;
			Declaracoes2.dDistanciaModelo0 = gpHEzKm55X.dAltura;
			lyMuyffiou(gpHEzKm55X.bComplementar);
			xUVugDnmiA();
			if (gpHEzKm55X.bComplementar)
			{
				tbBlocoLayout.Enabled = false;
				tbBlocoTopografico.Enabled = false;
				tbDistancia.Text = "";
			}
			btTrocaModelo.Enabled = true;
			btEditar.Enabled = true;
		}
	}

	private void MiWu0gbG4g(int P_0, int P_1)
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
		int num = Information.UBound(pZYZx3YSYK);
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (pZYZx3YSYK[num2].CodigoInterno == P_0)
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
			tbDescricaoResum1.Text = pZYZx3YSYK[num2].DescricaoResumida;
			tbModelo1.Text = pZYZx3YSYK[num2].Modelo;
			tbFabricante1.Text = pZYZx3YSYK[num2].Fabricante;
			break;
		case 2:
			tbCodigo2.Text = Conversions.ToString(P_0);
			tbDescricaoResum2.Text = pZYZx3YSYK[num2].DescricaoResumida;
			tbModelo2.Text = pZYZx3YSYK[num2].Modelo;
			tbFabricante2.Text = pZYZx3YSYK[num2].Fabricante;
			break;
		}
	}

	private void gtJuRH7FfO(object P_0, EventArgs P_1)
	{
		Hide();
		try
		{
			if (lyMuyffiou(gpHEzKm55X.bComplementar))
			{
				t03uAdmWrh();
				string sCaminhoBloco = "";
				string sNomeBlocoDWG = "";
				if (dg.SelectedRows.Count > 0)
				{
					sCaminhoBloco = Conversions.ToString(dg.SelectedRows[0].Cells[1].Value);
					sNomeBlocoDWG = Conversions.ToString(dg.SelectedRows[0].Cells[2].Value);
				}
				LMdZTA0SF8.Nome1 = tbNome1.Text.Trim();
				LMdZTA0SF8.Nome2 = tbNome2.Text.Trim();
				LMdZTA0SF8.Alternativo = tbAlternativo.Text.Trim();
				LMdZTA0SF8.Painel = checked((short)Dicionario.BuscaIndiceDoPainel(cbPainel.Text));
				string str = Conversions.ToString(0.5);
				str = Strings.Mid(str, 2, 1);
				tbDistancia.Text = tbDistancia.Text.Replace(".", str);
				tbDistancia.Text = tbDistancia.Text.Replace(",", str);
				if (!Versioned.IsNumeric(tbDistancia.Text))
				{
					tbDistancia.Text = Conversions.ToString(1);
				}
				Declaracoes2.dDistanciaModelo0 = Conversions.ToDouble(tbDistancia.Text);
				int iLM = Conversions.ToInteger(tbCodigo1.Text);
				int iLM2 = Conversions.ToInteger(tbCodigo2.Text);
				string sFabricante = tbFabricante1.Text;
				LMdZTA0SF8.iLM1 = iLM;
				LMdZTA0SF8.iLM2 = iLM2;
				LMdZTA0SF8.dAlturaModelo = Declaracoes2.dDistanciaModelo0;
				LMdZTA0SF8.Modelo = cbModelos.Text;
				LMdZTA0SF8.NomeVisivel = CKNome.Checked;
				LMdZTA0SF8.AlternativoVisivel = CKAlternativo.Checked;
				LMdZTA0SF8.Topografico = tbBlocoTopografico.Text;
				LMdZTA0SF8.Layout = tbBlocoLayout.Text;
				if (!(Versioned.IsNumeric(tbDistancia.Text) & (Operators.CompareString(tbDistancia.Text, "", TextCompare: true) != 0)))
				{
					LMdZTA0SF8.distContAux = 0.0;
				}
				else
				{
					LMdZTA0SF8.distContAux = Conversions.ToDouble(tbDistancia.Text);
				}
				string tipo = "";
				short painel = LMdZTA0SF8.Painel;
				string nome = LMdZTA0SF8.Nome1;
				string nome2 = LMdZTA0SF8.Nome2;
				string alternativo = LMdZTA0SF8.Alternativo;
				string handle = "";
				int num = clsDispositivo.verificaExisteNomeDispositivo(painel, nome, nome2, alternativo, ref handle, ref tipo);
				bool flag = false;
				if (num != 0)
				{
					if (num != 1)
					{
						if (num != 2)
						{
							if (num == 3)
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 967]), MsgBoxStyle.Information);
								flag = true;
							}
						}
						else if (Operators.CompareString(tipo, "P", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tipo, "M", TextCompare: true) == 0)
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 966]), MsgBoxStyle.Information);
								flag = true;
							}
						}
						else
						{
							MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 675]), MsgBoxStyle.YesNo, "Elétron");
							if (msgBoxResult != MsgBoxResult.Yes)
							{
								flag = true;
							}
							else
							{
								flag = false;
								LMdZTA0SF8.Complementar = true;
								LMdZTA0SF8.iLM1 = 0;
								LMdZTA0SF8.iLM2 = 0;
								LMdZTA0SF8.ChavePrimaria = Conversions.ToString(0);
								LMdZTA0SF8.distContAux = 0.0;
								LMdZTA0SF8.Layout = "";
								LMdZTA0SF8.Topografico = "";
							}
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 966]), MsgBoxStyle.Information);
						flag = true;
					}
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					clsDispositivo.InserirBlocoSimbologia(sCaminhoBloco, sNomeBlocoDWG, tbTerminais.Text, ref LMdZTA0SF8, VoLZoqJdbS, dVrZGW0V55, sFabricante, bOcultaModelo: true);
					if (FOgZ6L5AUo != 0)
					{
						if (FOgZ6L5AUo != 1)
						{
							if (FOgZ6L5AUo != 2)
							{
								if (FOgZ6L5AUo == 3)
								{
									clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo3(LMdZTA0SF8.Handle);
								}
							}
							else
							{
								clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo2(LMdZTA0SF8.Handle);
							}
						}
						else
						{
							clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo1(LMdZTA0SF8.Handle);
						}
					}
					else
					{
						clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo0(LMdZTA0SF8.Handle);
					}
				}
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
		Show();
	}

	private void kspumE9gv6(object P_0, EventArgs P_1)
	{
		zNcZwvjTcp = Conversions.ToBoolean(clsDispositivo.BuscaModeloExistente(gpHEzKm55X.sHandle));
		if (!((Operators.CompareString(grgZL9oIbg, cbModelos.Text, TextCompare: true) != 0) | !zNcZwvjTcp))
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1823]), MsgBoxStyle.Information);
			return;
		}
		btTrocaModelo.Enabled = false;
		btEditar.Enabled = false;
		if (gpHEzKm55X.iIndexModelo != 0)
		{
			UfyuU87Jt2();
		}
		else
		{
			Ws9uXoGR38();
		}
		if (FOgZ6L5AUo != 0)
		{
			if (FOgZ6L5AUo != 1)
			{
				if (FOgZ6L5AUo != 2)
				{
					if (FOgZ6L5AUo == 3)
					{
						clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo3(gpHEzKm55X.sHandle);
					}
				}
				else
				{
					clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo2(gpHEzKm55X.sHandle);
				}
			}
			else
			{
				clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo1(gpHEzKm55X.sHandle);
			}
		}
		else
		{
			clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo0(gpHEzKm55X.sHandle);
		}
		gpHEzKm55X.sHandle = "";
	}

	private void Ws9uXoGR38()
	{
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected Obj, but got Unknown
		if (!lyMuyffiou(gpHEzKm55X.bComplementar) || Operators.CompareString(cbModelos.Text.Trim(), "", TextCompare: true) == 0)
		{
			return;
		}
		obiZf08jL7.Modelo = cbModelos.Text;
		obiZf08jL7.indexModelo = clsDispositivo.carregaOsContatosDoModeloselecionado(obiZf08jL7.Modelo, ref VoLZoqJdbS, ref dVrZGW0V55);
		int iLM = Conversions.ToInteger(tbCodigo1.Text);
		int iLM2 = Conversions.ToInteger(tbCodigo2.Text);
		obiZf08jL7.NomeVisivel = CKNome.Checked;
		obiZf08jL7.AlternativoVisivel = CKAlternativo.Checked;
		obiZf08jL7.Topografico = tbBlocoTopografico.Text;
		obiZf08jL7.Layout = tbBlocoLayout.Text;
		obiZf08jL7.iLM1 = iLM;
		obiZf08jL7.iLM2 = iLM2;
		string sFabricante = tbFabricante1.Text;
		if (!((Operators.CompareString(tbDistancia.Text, "", TextCompare: true) != 0) & Versioned.IsNumeric(tbDistancia.Text)))
		{
			obiZf08jL7.distContAux = 0.0;
		}
		else
		{
			obiZf08jL7.distContAux = Conversions.ToDouble(tbDistancia.Text);
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockReference blockRef = (BlockReference)Geral.HandleToObject(g5wZDfka16);
				if (blockRef != null)
				{
					((DBObject)blockRef).UpgradeOpen();
					XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref obiZf08jL7);
					if (Information.UBound(dVrZGW0V55) > 0)
					{
						clsDispositivo.insereTabelaModelo(ref blockRef, obiZf08jL7, VoLZoqJdbS, dVrZGW0V55, sFabricante, bOcultaModelo: true, obiZf08jL7.distContAux);
					}
					((Entity)blockRef).Draw();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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
		clsBlocos.Unhighlight();
	}

	private void UfyuU87Jt2()
	{
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected Obj, but got Unknown
		if (!lyMuyffiou(gpHEzKm55X.bComplementar) || Operators.CompareString(gpHEzKm55X.sHandle, "", TextCompare: true) == 0)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				PHLZJm9bxv = gpHEzKm55X.sHandle;
				if (Operators.CompareString(cbModelos.Text.Trim(), "", TextCompare: true) != 0)
				{
					if (dg.SelectedRows.Count > 0)
					{
						Conversions.ToString(dg.SelectedRows[0].Cells[1].Value);
						Conversions.ToString(dg.SelectedRows[0].Cells[2].Value);
					}
					int indexModelo = obiZf08jL7.indexModelo;
					obiZf08jL7.Modelo = cbModelos.Text;
					obiZf08jL7.indexModelo = clsDispositivo.carregaOsContatosDoModeloselecionado(obiZf08jL7.Modelo, ref VoLZoqJdbS, ref dVrZGW0V55);
					if (clsDispositivoAuxiliares.podeTrocarModelo(gpHEzKm55X.sHandle, indexModelo, obiZf08jL7.indexModelo, VoLZoqJdbS))
					{
						clsDispositivoAuxiliares.ApagaModelo(g5wZDfka16);
						Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
						int num = Conversions.ToInteger(tbCodigo1.Text);
						int num2 = Conversions.ToInteger(tbCodigo2.Text);
						obiZf08jL7.NomeVisivel = CKNome.Checked;
						obiZf08jL7.AlternativoVisivel = CKAlternativo.Checked;
						obiZf08jL7.Topografico = tbBlocoTopografico.Text;
						obiZf08jL7.Layout = tbBlocoLayout.Text;
						obiZf08jL7.iLM1 = num;
						obiZf08jL7.iLM2 = num2;
						string sFabricante = tbFabricante1.Text;
						gpHEzKm55X.LM1 = num;
						gpHEzKm55X.LM2 = num2;
						gpHEzKm55X.sTerminais = tbTerminais.Text;
						gpHEzKm55X.sTopografico = tbBlocoTopografico.Text;
						gpHEzKm55X.sLayout = tbBlocoLayout.Text;
						gpHEzKm55X.iIndexModelo = obiZf08jL7.indexModelo;
						clsDispositivo.EditaNomeDoDispositivoPrincipal(ref gpHEzKm55X, tbNome1.Text.Trim(), tbNome2.Text.Trim(), tbAlternativo.Text.Trim(), CKNome.Checked, CKAlternativo.Checked, gpHEzKm55X.sHandle);
						if (!((Operators.CompareString(tbDistancia.Text, "", TextCompare: true) != 0) & Versioned.IsNumeric(tbDistancia.Text)))
						{
							obiZf08jL7.distContAux = 0.0;
						}
						else
						{
							obiZf08jL7.distContAux = Conversions.ToDouble(tbDistancia.Text);
						}
						BlockReference blockRef = (BlockReference)Geral.HandleToObject(g5wZDfka16);
						if (blockRef != null)
						{
							if (Information.UBound(dVrZGW0V55) > 0)
							{
								clsDispositivo.insereTabelaModelo(ref blockRef, obiZf08jL7, VoLZoqJdbS, dVrZGW0V55, sFabricante, bOcultaModelo: true);
								clsDispositivoAuxiliares.AtualizaContatos(g5wZDfka16, obiZf08jL7.indexModelo, dVrZGW0V55);
							}
							((DBObject)blockRef).UpgradeOpen();
							XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref obiZf08jL7);
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 912]), MsgBoxStyle.Critical, "Elétron");
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	private bool lyMuyffiou(bool P_0)
	{
		bool result = true;
		tbNome1.BackColor = Color.White;
		tbNome1.ForeColor = Color.Black;
		cbPainel.BackColor = Color.White;
		cbPainel.ForeColor = Color.Black;
		tbDistancia.BackColor = Color.White;
		tbDistancia.ForeColor = Color.Black;
		w8dpBZ0kvSD().SetToolTip(tbNome1, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 644]));
		w8dpBZ0kvSD().SetToolTip(cbPainel, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
		w8dpBZ0kvSD().SetToolTip(cbModelos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 630]));
		if (Operators.CompareString(tbNome1.Text, "", TextCompare: true) == 0)
		{
			tbNome1.BackColor = Color.Aqua;
			result = false;
			w8dpBZ0kvSD().SetToolTip(tbNome1, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 636]));
		}
		if (Operators.CompareString(cbPainel.Text, "", TextCompare: true) == 0)
		{
			cbPainel.BackColor = Color.Aqua;
			result = false;
			w8dpBZ0kvSD().SetToolTip(cbPainel, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 637]));
		}
		if ((Operators.CompareString(cbPainel.Text, "", TextCompare: true) == 0) | (Operators.CompareString(cbPainel.Text, "?", TextCompare: true) == 0))
		{
			cbPainel.BackColor = Color.Aqua;
			result = false;
			w8dpBZ0kvSD().SetToolTip(cbPainel, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 638]));
		}
		if ((Operators.CompareString(cbModelos.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(tbDistancia.Text.Trim(), "", TextCompare: true) == 0))
		{
			tbDistancia.BackColor = Color.Aqua;
			result = false;
			w8dpBZ0kvSD().SetToolTip(cbModelos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 639]));
		}
		if (Operators.CompareString(tbNome1.Text, "", TextCompare: true) != 0)
		{
			string right = tbNome1.Text;
			if (Operators.CompareString(tbNome2.Text, "", TextCompare: true) != 0)
			{
				right = tbNome1.Text + "/" + tbNome2.Text;
			}
			w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 640], " "), right)));
		}
		if (Operators.CompareString(tbDistancia.Text.Trim(), "", TextCompare: true) == 0)
		{
			if (Operators.CompareString(cbModelos.Text.Trim(), "", TextCompare: true) == 0)
			{
				w8dpBZ0kvSD().SetToolTip(tbDistancia, "");
			}
			else
			{
				w8dpBZ0kvSD().SetToolTip(tbDistancia, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 643]));
			}
		}
		else
		{
			string right2 = tbNome1.Text;
			if (Operators.CompareString(tbNome2.Text, "", TextCompare: true) != 0)
			{
				right2 = tbNome1.Text + DeclaracoesGeral.Conf.SeparadorCruzamento + tbNome2.Text;
			}
			string caption = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 641], right2), DeclaracoesGeral.mMensagem[1, 642]), cbModelos.Text));
			w8dpBZ0kvSD().SetToolTip(tbDistancia, caption);
		}
		if (Operators.CompareString(cbModelos.Text, "", TextCompare: true) != 0)
		{
			tbBlocoTopografico.Enabled = false;
			tbBlocoLayout.Enabled = false;
			btSelecionaBlocoTopo.Enabled = false;
			btSelecionaBlocoLayout.Enabled = false;
			tbTerminais.Enabled = false;
			GroupBox2.Enabled = true;
		}
		else
		{
			tbBlocoTopografico.Enabled = true;
			tbBlocoLayout.Enabled = true;
			btSelecionaBlocoTopo.Enabled = true;
			btSelecionaBlocoLayout.Enabled = true;
			tbTerminais.Enabled = true;
		}
		GroupBox2.Enabled = true;
		int num = Information.UBound(VoLZoqJdbS);
		int iIndiceSelecionado = default;
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(VoLZoqJdbS[i].sNomeModelo, cbModelos.Text, TextCompare: true) == 0)
			{
				iIndiceSelecionado = VoLZoqJdbS[i].iIndiceModelo;
				break;
			}
		}
		if (iIndiceSelecionado != 0)
		{
			Declaracoes2.dDistanciaModelo0 = clsDispositivoAuxiliares.BuscaAlturaDoModeloEspecifico(iIndiceSelecionado);
		}
		else
		{
			Declaracoes2.dDistanciaModelo0 = 0.0;
		}
		if (!(Declaracoes2.dDistanciaModelo0 < 0.0))
		{
			tbDistancia.Text = Conversions.ToString(Declaracoes2.dDistanciaModelo0);
		}
		else
		{
			Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = new Declaracoes2.StructureContatosAuxiliares[1];
			DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref mCONTATOS);
			if (mCONTATOS.Count() <= 1)
			{
				GroupBox2.Enabled = false;
				tbDistancia.Text = "";
				result = true;
			}
			else
			{
				GroupBox2.Enabled = true;
				tbDistancia.Text = "0";
			}
		}
		return result;
	}

	private bool xUVugDnmiA()
	{
		bool result = true;
		if (Strings.Len(tbAlternativo.Text.Trim()) == 0)
		{
			tbAlternativo.Text = tbAlternativo.Text.Trim();
		}
		if (Operators.CompareString(tbAlternativo.Text, "", TextCompare: true) != 0)
		{
			CKAlternativo.Enabled = true;
		}
		else
		{
			CKAlternativo.Checked = false;
			CKAlternativo.Enabled = false;
		}
		return result;
	}

	private void t03uAdmWrh()
	{
		LMdZTA0SF8.Nome1 = "";
		LMdZTA0SF8.Nome2 = "";
		LMdZTA0SF8.Alternativo = "";
		LMdZTA0SF8.Painel = 0;
		LMdZTA0SF8.indexModelo = 0;
		LMdZTA0SF8.Complementar = false;
		LMdZTA0SF8.iLM1 = 0;
		LMdZTA0SF8.iLM2 = 0;
		LMdZTA0SF8.tipoContatoAux = 0;
		LMdZTA0SF8.Topografico = "";
		LMdZTA0SF8.Layout = "";
	}

	private void pD0uslYkxx(object P_0, KeyEventArgs P_1)
	{
		lyMuyffiou(gpHEzKm55X.bComplementar);
	}

	private void jH7uBLUf8d(object P_0, MouseEventArgs P_1)
	{
		lyMuyffiou(gpHEzKm55X.bComplementar);
	}

	private void fu3uVcP3nb(object P_0, EventArgs P_1)
	{
		LMdZTA0SF8.Handle = "";
		tbTerminais.Text = clsDispositivo.BuscaTerminaisNoModelo(cbModelos.Text, ref VoLZoqJdbS);
		gn0uukQrxa(cbModelos.Text);
		lyMuyffiou(gpHEzKm55X.bComplementar);
	}

	private void gn0uukQrxa(string P_0)
	{
		tbBlocoTopografico.Text = "";
		tbBlocoLayout.Text = "";
		int num = -1;
		int num2 = -1;
		if (Information.UBound(VoLZoqJdbS) > 0)
		{
			int num3 = Information.UBound(VoLZoqJdbS);
			for (int i = 1; i <= num3; i = checked(i + 1))
			{
				if (Operators.CompareString(P_0, VoLZoqJdbS[i].sNomeModelo, TextCompare: true) == 0)
				{
					num = VoLZoqJdbS[i].iLM1;
					num2 = VoLZoqJdbS[i].iLM2;
					tbBlocoTopografico.Text = VoLZoqJdbS[i].sBlocoTopografico;
					tbBlocoLayout.Text = VoLZoqJdbS[i].sBlocoLayout;
					break;
				}
			}
		}
		MiWu0gbG4g(num, 1);
		MiWu0gbG4g(num2, 2);
		tbBlocoTopografico.BackColor = Color.Silver;
		if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
		{
			tbBlocoTopografico.BackColor = Color.White;
		}
		tbBlocoLayout.BackColor = Color.Silver;
		if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
		{
			tbBlocoLayout.BackColor = Color.White;
		}
	}

	private void sofuE7AIwp(object P_0, MouseEventArgs P_1)
	{
		Pa0uSGbLKZ();
	}

	private void NuOuZv8bbT(object P_0, KeyEventArgs P_1)
	{
		Pa0uSGbLKZ();
	}

	private void r28ui2F5HX(object P_0, KeyEventArgs P_1)
	{
		Pa0uSGbLKZ();
	}

	private void Pa0uSGbLKZ()
	{
		TN8u908vU3();
	}

	private void LdOu4eY7kB(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = tbNome1;
		clsTextos.NomeValido(ref tbNome);
		tbNome1 = tbNome;
		xUVugDnmiA();
		lyMuyffiou(gpHEzKm55X.bComplementar);
		btTrocaModelo.Enabled = false;
	}

	private void bynuCpPIPF(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = tbNome2;
		clsTextos.NomeValido(ref tbNome);
		tbNome2 = tbNome;
		btTrocaModelo.Enabled = false;
	}

	private void InJuYtiVSb(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = tbAlternativo;
		clsTextos.NomeValido(ref tbNome);
		tbAlternativo = tbNome;
		tbAlternativo.Focus();
		xUVugDnmiA();
		btTrocaModelo.Enabled = false;
	}

	private void nfiur9QfSf(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.ativo.Painel = Dicionario.BuscaIndiceDoPainel(cbPainel.Text);
		lyMuyffiou(gpHEzKm55X.bComplementar);
	}

	private void TN8u908vU3()
	{
		if (dg.SelectedRows.Count > 0)
		{
			iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(dg.SelectedRows[0].Cells[1].Value));
		}
	}

	private void sl9uz5i1CN(object P_0, EventArgs P_1)
	{
		btTrocaModelo.Enabled = false;
		btEditar.Enabled = false;
		if (Operators.CompareString(gpHEzKm55X.sHandle, "", TextCompare: true) != 0)
		{
			int lM = Conversions.ToInteger(tbCodigo1.Text);
			int lM2 = Conversions.ToInteger(tbCodigo2.Text);
			if (!gpHEzKm55X.bComplementar)
			{
				string tipo = "";
				int num = clsDispositivo.verificaExisteNomeDispositivo(obiZf08jL7.Painel, tbNome1.Text.Trim(), tbNome2.Text.Trim(), tbAlternativo.Text.Trim(), ref gpHEzKm55X.sHandle, ref tipo);
				bool flag = false;
				if (num != 0)
				{
					if (num != 1)
					{
						if (num != 2)
						{
							if (num == 3)
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 967]), MsgBoxStyle.Information);
								flag = true;
							}
						}
						else if ((Operators.CompareString(tipo, "P", TextCompare: true) == 0) | (Operators.CompareString(tipo, "M", TextCompare: true) == 0))
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 966]), MsgBoxStyle.Information);
							flag = true;
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 966]), MsgBoxStyle.Information);
						flag = true;
					}
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					goto IL_0489;
				}
			}
			gpHEzKm55X.LM1 = lM;
			gpHEzKm55X.LM2 = lM2;
			gpHEzKm55X.sTerminais = tbTerminais.Text;
			gpHEzKm55X.sTopografico = tbBlocoTopografico.Text;
			gpHEzKm55X.sLayout = tbBlocoLayout.Text;
			clsDispositivo.EditaNomeDoDispositivoPrincipal(ref gpHEzKm55X, tbNome1.Text.Trim(), tbNome2.Text.Trim(), tbAlternativo.Text.Trim(), CKNome.Checked, CKAlternativo.Checked, gpHEzKm55X.sHandle);
			if (gpHEzKm55X.iIndexModelo > 0)
			{
				clsDispositivoAuxiliares.EditaNomeDoModelo(gpHEzKm55X.sHandle, tbNome1.Text.Trim(), tbNome2.Text.Trim(), tbAlternativo.Text.Trim(), CKNome.Checked, CKAlternativo.Checked);
				clsDispositivoAuxiliares.EditaNomeDoContatoAuxiliar(gpHEzKm55X.sHandle, tbNome1.Text.Trim(), tbNome2.Text.Trim(), tbAlternativo.Text.Trim(), CKNome.Checked, CKAlternativo.Checked);
				if (FOgZ6L5AUo != 0)
				{
					if (FOgZ6L5AUo != 1)
					{
						if (FOgZ6L5AUo != 2)
						{
							if (FOgZ6L5AUo == 3)
							{
								clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo3(gpHEzKm55X.sHandle);
							}
						}
						else
						{
							clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo2(gpHEzKm55X.sHandle);
						}
					}
					else
					{
						clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo1(gpHEzKm55X.sHandle);
					}
				}
				else
				{
					clsDispositivo.EditaUmModeloDeDispositivoPrincipalTipo0(gpHEzKm55X.sHandle);
				}
			}
			string text = gpHEzKm55X.sNome1;
			if (Operators.CompareString(gpHEzKm55X.sNome2.Trim(), "", TextCompare: true) != 0)
			{
				text = text + "/" + gpHEzKm55X.sNome2;
			}
			string text2 = tbNome1.Text;
			if (Operators.CompareString(tbNome2.Text.Trim(), "", TextCompare: true) != 0)
			{
				text2 = text2 + "/" + tbNome2.Text;
			}
			clsLayoutMec.EditaNomeAlternativoLayoutMec(obiZf08jL7.Painel, text, text2, tbAlternativo.Text);
			clsDispositivoTacito.editaLayoutRapido(gpHEzKm55X.iPainel.ToString(), text, text2, tbAlternativo.Text);
			if (clsBlocos.ExisteAtributo(gpHEzKm55X.sHandle, "FABRICANTE") | clsBlocos.ExisteAtributo(gpHEzKm55X.sHandle, "PAINEL"))
			{
				clsUtilitarios.EditaDipAuxPainelModeloFabricante();
			}
		}
		goto IL_0489;
		IL_0489:
		gpHEzKm55X.sHandle = "";
	}

	private void DLAEWRhxUt(object P_0, EventArgs P_1)
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
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoTopografico.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	private void fsTEpPDG2Y(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text, "", TextCompare: true) == 0))
		{
			DataGridView withEventsValue = dg;
			ref object[,] auaZpovalE = ref AuaZpovalE;
			object obj = auaZpovalE;
			h7Rul7ZDlu(ref withEventsValue, ref obj, TBPesquisa.Text);
			auaZpovalE = (object[,])obj;
			dg = withEventsValue;
		}
	}

	private void MwLETUjXl7(object P_0, EventArgs P_1)
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
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoLayout.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	private void gwvEJEMs19(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(cbModelos.Text.Trim(), "", TextCompare: true) == 0)
		{
			return;
		}
		MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1749], cbModelos.Text), "?"), MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			if (gpHEzKm55X.iIndexModelo == 0)
			{
				gpHEzKm55X.iIndexModelo = clsDispositivo.BuscaIndiceDoModelo(cbModelos.Text, ref VoLZoqJdbS);
			}
			clsDispositivoAuxiliares.CorrigeAlturaDoModelosSelecionado(gpHEzKm55X.iIndexModelo, Conversions.ToDouble(tbDistancia.Text));
			if (gpHEzKm55X.iIndexModelo != 0)
			{
				Declaracoes2.StructureFuncoesDispositivo[] mFuncoes = null;
				clsDispositivoAuxiliares.GuardaAsFuncoesDosModelos(ref mFuncoes);
				Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = new Declaracoes2.StructureContatosAuxiliares[1];
				DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref gpHEzKm55X.iIndexModelo, ref mCONTATOS);
				clsDispositivo.ApagaOsContatoAuxiliarDoModelo(gpHEzKm55X.iIndexModelo);
				clsDispositivo.ReInsereContatosModelo(mCONTATOS, gpHEzKm55X.iIndexModelo);
				Correcao.CorrigeContatosAux(gpHEzKm55X.iIndexModelo);
				ClsFuncoesDispositivo.AtualizaFuncaoDosModelos();
				clsDispositivoAuxiliares.EscreveAsFuncoesDosModelos(ref mFuncoes);
			}
		}
	}

	private void NK0EhuTD8B(object P_0, EventArgs P_1)
	{
		if (!a6VZjhOvkx)
		{
			return;
		}
		if (!Operators.ConditionalCompareObjectEqual(CBModeloVisualizar.Text, DeclaracoesGeral.mMensagem[1, 1746], TextCompare: true))
		{
			if (!Operators.ConditionalCompareObjectEqual(CBModeloVisualizar.Text, DeclaracoesGeral.mMensagem[1, 1745], TextCompare: true))
			{
				if (!Operators.ConditionalCompareObjectEqual(CBModeloVisualizar.Text, DeclaracoesGeral.mMensagem[1, 1747], TextCompare: true))
				{
					if (Operators.ConditionalCompareObjectEqual(CBModeloVisualizar.Text, DeclaracoesGeral.mMensagem[1, 1748], TextCompare: true))
					{
						FOgZ6L5AUo = 3;
					}
				}
				else
				{
					FOgZ6L5AUo = 2;
				}
			}
			else
			{
				FOgZ6L5AUo = 1;
			}
		}
		else
		{
			FOgZ6L5AUo = 0;
		}
	}

	private void FpxEo9SKAx(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo1.Text));
		tbCodigo1.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum1.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo1.Text = frmPesquisaMateriais2.modelo;
		tbFabricante1.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}

	private void nuXEG7FsTM(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo2.Text));
		tbCodigo2.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum2.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo2.Text = frmPesquisaMateriais2.modelo;
		tbFabricante2.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}

	private void kOBEH5AsAE(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(cbModelos.Text.Trim(), "", TextCompare: true) != 0)
		{
			btPesquisaLM1.Enabled = false;
			btPesquisaLM2.Enabled = false;
		}
		else
		{
			btPesquisaLM1.Enabled = true;
			btPesquisaLM2.Enabled = true;
		}
	}
}
