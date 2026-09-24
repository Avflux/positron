using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

[DesignerGenerated]
public class frmConfiguracaoGeral : Form
{
	private IContainer T0NyrOXDCq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	private FolderBrowserDialog Wyby9BM05h;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox9")]
	private GroupBox qfoyzsBxjU;

	[AccessedThroughProperty("tbSimbologiaEletrica")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox dH5gWIxn2O;

	[AccessedThroughProperty("SelDirSimbologiaEletrica")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button lp4gppv34Q;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GBAccess")]
	private GroupBox zUGgTOayxp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbProjeto")]
	private TextBox By3gJEH2lg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SelProj")]
	private Button UOWgh3gCwv;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox dkGgoreX5K;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIdioma2")]
	private RadioButton HBcgGbGp97;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIdioma1")]
	private RadioButton inigH39sdR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox NQVgklXun6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCaderno")]
	private TextBox IQigdAX4So;

	[AccessedThroughProperty("GroupBox10")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox oScgfBW5AX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbSimbologiaTopografico")]
	private TextBox OM8gDehgwr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("SelDirSimbologiaTopografico")]
	private Button YUPgv2imor;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox CIDg6GWanF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("rbIncluirColuna2")]
	private RadioButton IFqgt2L6cC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIncluirColuna1")]
	private RadioButton xC9gj9DDLD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIncluirColuna0")]
	[CompilerGenerated]
	private RadioButton Ew1gL4JhaH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	[CompilerGenerated]
	private GroupBox YcrgwXFsnJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSeparadorCruzamento")]
	[CompilerGenerated]
	private TextBox qH9gx77w7P;

	[AccessedThroughProperty("tbSeparadorCaboVeia")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox Ehbgb7kk5s;

	[AccessedThroughProperty("Label7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label lDcgM73xjm;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label KqwgOmCsKb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private Label fOggILYagV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btCorTextoInterligacao")]
	private Button c3Zg7iItge;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorInterligacao")]
	private Button HbHgqf5xOm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private Label YhsgaFxFUr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorTextoCircuito")]
	private Button nDMg8Epd1U;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private Label ds7gNOmAiU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbTerminalIndefinido")]
	private TextBox WsQgFwLRMH;

	[CompilerGenerated]
	[AccessedThroughProperty("Label6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label jJ0gQDKje1;

	[AccessedThroughProperty("btCorConexao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button XMfgPp2lZn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox11")]
	[CompilerGenerated]
	private GroupBox eEMgcfbjCr;

	[AccessedThroughProperty("tbSimbologiaLayout")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox JpQgKou8at;

	[AccessedThroughProperty("selDirSimbologiaLayout")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button Ce0gebAk44;

	[CompilerGenerated]
	[AccessedThroughProperty("rbIncluirColuna3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton dkNg2SInfg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox Oojg3SAEPT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label8")]
	private Label ehOgnuDfRD;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox Yrag1vT2LI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFonteCircuitos")]
	private TextBox rhlglhGtbC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label10")]
	private Label Tmgg57W9VY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label11")]
	private Label vtVg0evoOm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbFonteCabos")]
	private TextBox iaSgRnkRFr;

	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox oYAgmqmAmE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbANSI")]
	[CompilerGenerated]
	private RadioButton MsugXmCKwa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIEC")]
	private RadioButton XiMgUJWprd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIncluirColuna4")]
	[CompilerGenerated]
	private RadioButton YxUgyKlyk5;

	[AccessedThroughProperty("GroupBox12")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox x3rggprDGj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label14")]
	private Label XZUgAkK1yW;

	[CompilerGenerated]
	[AccessedThroughProperty("tbSufixoCruzamentoExterno")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox rDFgsSlssc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label13")]
	private Label kXOgB371j2;

	[AccessedThroughProperty("tbPrefixoCruzamentoExterno")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox I5UgVgUUx1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox13")]
	[CompilerGenerated]
	private GroupBox PYdgu2UIm4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSufixoCruzamentoInterno")]
	private TextBox JqSgE2ms1l;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label12")]
	[CompilerGenerated]
	private Label nNigZ8ksIb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPrefixoCruzamentoInterno")]
	[CompilerGenerated]
	private TextBox zIFgijJ67v;

	[AccessedThroughProperty("Label15")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label Y4fgSRGPwO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox14")]
	private GroupBox xRAg4Q3WOg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSimbologiaRelatorios")]
	private TextBox N82gC2ApxB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("selDirSimbologiaRelatorios")]
	private Button iUlgYlRY89;

	[AccessedThroughProperty("GroupBox15")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox Xg2grXhtkH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label sZLg9McrrE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSufixoCruzamentoFF")]
	[CompilerGenerated]
	private TextBox sBigzgw9e0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label9")]
	private Label zL6AWsxtoS;

	[AccessedThroughProperty("tbPrefixoCruzamentoFF")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox AYWApdJQ68;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox16")]
	[CompilerGenerated]
	private GroupBox PS8ATmCRZf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEletrosul")]
	private Button s3WAJM2b9V;

	[CompilerGenerated]
	[AccessedThroughProperty("btEletronorte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button fJrAhKPdiq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIncluirColuna6")]
	private RadioButton IkkAohgM65;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbIncluirColuna5")]
	private RadioButton bfcAGWgAXf;

	[AccessedThroughProperty("btChesf")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button Ob1AHewwgW;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label16")]
	[CompilerGenerated]
	private Label QLWAk6XMjf;

	[AccessedThroughProperty("tbSeparadorCarimbo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox exkAdGM5Uq;

	[AccessedThroughProperty("Label17")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label auTAfsnZeb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFonteCruzamento")]
	private TextBox Y0JADTICc5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox17")]
	private GroupBox ufeAvPx10n;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("RBBobinaContato2")]
	private RadioButton uwYA66JCph;

	[CompilerGenerated]
	[AccessedThroughProperty("RBContato1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton j3HAt4MgyZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBBobina0")]
	private RadioButton pduAjYyapX;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox18")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox eALAL95iP4;

	[AccessedThroughProperty("RBLayInter1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton ao5AwoS2eb;

	[CompilerGenerated]
	[AccessedThroughProperty("RBLayInter0")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton y4lAx40kbv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBBobinaContatoES3")]
	[CompilerGenerated]
	private RadioButton oqTAblFPbn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBLayInter2")]
	private RadioButton Q8pAMMC6AA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("RBLayInter3")]
	private RadioButton a0DAO6XfRg;

	[AccessedThroughProperty("GroupBox4B")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox uNMAISDah4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label18")]
	private Label tvcA7piWwk;

	[CompilerGenerated]
	[AccessedThroughProperty("cbEstilosLinha")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox YqpAq0Gssc;

	[AccessedThroughProperty("tbEstiloLinhaEscala")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox sDvAa34gOw;

	[AccessedThroughProperty("GroupBox19")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox YpcA8oVFmK;

	[AccessedThroughProperty("rbSQLite")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton LpgAN18XSw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbAccess")]
	[CompilerGenerated]
	private RadioButton qaHAFtTXVi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label19")]
	[CompilerGenerated]
	private Label BYlAQR9BnD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSeparadorReguaBorne")]
	private TextBox fplAPFR6OL;

	[AccessedThroughProperty("TabControl1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TabControl WtTAcd7Mog;

	[AccessedThroughProperty("TabPage1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TabPage T2cAKD6Onv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPage2")]
	private TabPage O33AedOyP6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage HCmA2QGePf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	private Button t1OA3n2UAV;

	[AccessedThroughProperty("rbSQLSVR")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton G3YAnWfY0v;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GBSql")]
	private GroupBox S0UA1ygRHN;

	[AccessedThroughProperty("tbSenha")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox GiYAl4pxMB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbPassword")]
	private Label Y2iA5hXTNa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbUserName")]
	private Label qxGA0cBsK0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbDataBase")]
	private Label hyIARjnu65;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDataSource")]
	[CompilerGenerated]
	private Label lkkAmPXF4J;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbUser")]
	private TextBox XWaAXGxmnb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBancoDeDados")]
	private TextBox pWDAUO1m7r;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDataSource")]
	[CompilerGenerated]
	private TextBox rmoAyDBegm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btConectarSQLServer")]
	private Button d65AgudJSY;

	private DeclaracoesGeral.ConfigCaderno amNAASpuLi;

	private ColorDialog g99AsoPXck;

	private int HxDABOf8PQ;

	private int yyBAVMdZD9;

	private int zv6AuRqfkM;

	private int I4BAET7wWy;

	private string giTAZtl5Jx;

	private double s47Ai339S3;

	private int B75AS37BMQ;

	private double rFIA42LRGA;

	private double fMNAC3p4wq;

	private double W9rAYJJbUt;

	private string FlvArBeJw2;

	private string wcjA9lxGO0;

	private string oWMAzOOMa6;

	private string gX8sWkfPAf;

	private string cIasp9aTSt;

	private string DVdsTyaLbW;

	private string e9XsJ9TO5R;

	private string W1bshep6d8;

	private string XDwsokBYdE;

	private string dtpsGFoxJa;

	private string YDqsHewLar;

	private string oHusk134TR;

	private int j1qsdseLgF;

	private int HInsfhv1wc;

	private LyneTypes.structureEstiloInterligacao[] ppOsDwAfPf;

	private string l0xsvTTL8Z;

	private string BO9s6arZYU;

	private string NuJstYUNpy;

	private string GUCsjZD0Yw;

	internal virtual GroupBox GroupBox9
	{
		[CompilerGenerated]
		get
		{
			return qfoyzsBxjU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qfoyzsBxjU = value;
		}
	}

	internal virtual TextBox tbSimbologiaEletrica
	{
		[CompilerGenerated]
		get
		{
			return dH5gWIxn2O;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dH5gWIxn2O = value;
		}
	}

	internal virtual Button SelDirSimbologiaEletrica
	{
		[CompilerGenerated]
		get
		{
			return lp4gppv34Q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DZSyXvJNw5;
			Button button = lp4gppv34Q;
			if (button != null)
			{
				button.Click -= value2;
			}
			lp4gppv34Q = value;
			button = lp4gppv34Q;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GBAccess
	{
		[CompilerGenerated]
		get
		{
			return zUGgTOayxp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zUGgTOayxp = value;
		}
	}

	internal virtual TextBox tbProjeto
	{
		[CompilerGenerated]
		get
		{
			return By3gJEH2lg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			By3gJEH2lg = value;
		}
	}

	internal virtual Button SelProj
	{
		[CompilerGenerated]
		get
		{
			return UOWgh3gCwv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = q3bymcEYak;
			Button button = UOWgh3gCwv;
			if (button != null)
			{
				button.Click -= value2;
			}
			UOWgh3gCwv = value;
			button = UOWgh3gCwv;
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
			return dkGgoreX5K;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dkGgoreX5K = value;
		}
	}

	internal virtual RadioButton rbIdioma2
	{
		[CompilerGenerated]
		get
		{
			return HBcgGbGp97;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HBcgGbGp97 = value;
		}
	}

	internal virtual RadioButton rbIdioma1
	{
		[CompilerGenerated]
		get
		{
			return inigH39sdR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			inigH39sdR = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return NQVgklXun6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NQVgklXun6 = value;
		}
	}

	internal virtual TextBox tbCaderno
	{
		[CompilerGenerated]
		get
		{
			return IQigdAX4So;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IQigdAX4So = value;
		}
	}

	internal virtual GroupBox GroupBox10
	{
		[CompilerGenerated]
		get
		{
			return oScgfBW5AX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oScgfBW5AX = value;
		}
	}

	internal virtual TextBox tbSimbologiaTopografico
	{
		[CompilerGenerated]
		get
		{
			return OM8gDehgwr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OM8gDehgwr = value;
		}
	}

	internal virtual Button SelDirSimbologiaTopografico
	{
		[CompilerGenerated]
		get
		{
			return YUPgv2imor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SB4yUhCSbn;
			Button button = YUPgv2imor;
			if (button != null)
			{
				button.Click -= value2;
			}
			YUPgv2imor = value;
			button = YUPgv2imor;
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
			return CIDg6GWanF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CIDg6GWanF = value;
		}
	}

	internal virtual RadioButton rbIncluirColuna2
	{
		[CompilerGenerated]
		get
		{
			return IFqgt2L6cC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IFqgt2L6cC = value;
		}
	}

	internal virtual RadioButton rbIncluirColuna1
	{
		[CompilerGenerated]
		get
		{
			return xC9gj9DDLD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xC9gj9DDLD = value;
		}
	}

	internal virtual RadioButton rbIncluirColuna0
	{
		[CompilerGenerated]
		get
		{
			return Ew1gL4JhaH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ew1gL4JhaH = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return YcrgwXFsnJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YcrgwXFsnJ = value;
		}
	}

	internal virtual TextBox tbSeparadorCruzamento
	{
		[CompilerGenerated]
		get
		{
			return qH9gx77w7P;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qH9gx77w7P = value;
		}
	}

	internal virtual TextBox tbSeparadorCaboVeia
	{
		[CompilerGenerated]
		get
		{
			return Ehbgb7kk5s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ehbgb7kk5s = value;
		}
	}

	internal virtual Label Label7
	{
		[CompilerGenerated]
		get
		{
			return lDcgM73xjm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lDcgM73xjm = value;
		}
	}

	internal virtual Label Label5
	{
		[CompilerGenerated]
		get
		{
			return KqwgOmCsKb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KqwgOmCsKb = value;
		}
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return fOggILYagV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fOggILYagV = value;
		}
	}

	internal virtual Button btCorTextoInterligacao
	{
		[CompilerGenerated]
		get
		{
			return c3Zg7iItge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OL7yVSLk87;
			Button button = c3Zg7iItge;
			if (button != null)
			{
				button.Click -= value2;
			}
			c3Zg7iItge = value;
			button = c3Zg7iItge;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCorInterligacao
	{
		[CompilerGenerated]
		get
		{
			return HbHgqf5xOm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XXQyBV2sY7;
			Button button = HbHgqf5xOm;
			if (button != null)
			{
				button.Click -= value2;
			}
			HbHgqf5xOm = value;
			button = HbHgqf5xOm;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return YhsgaFxFUr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YhsgaFxFUr = value;
		}
	}

	internal virtual Button btCorTextoCircuito
	{
		[CompilerGenerated]
		get
		{
			return nDMg8Epd1U;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lSLysFWfWo;
			Button button = nDMg8Epd1U;
			if (button != null)
			{
				button.Click -= value2;
			}
			nDMg8Epd1U = value;
			button = nDMg8Epd1U;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return ds7gNOmAiU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ds7gNOmAiU = value;
		}
	}

	internal virtual TextBox tbTerminalIndefinido
	{
		[CompilerGenerated]
		get
		{
			return WsQgFwLRMH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WsQgFwLRMH = value;
		}
	}

	internal virtual Label Label6
	{
		[CompilerGenerated]
		get
		{
			return jJ0gQDKje1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jJ0gQDKje1 = value;
		}
	}

	internal virtual Button btCorConexao
	{
		[CompilerGenerated]
		get
		{
			return XMfgPp2lZn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SKZyA37jpe;
			Button button = XMfgPp2lZn;
			if (button != null)
			{
				button.Click -= value2;
			}
			XMfgPp2lZn = value;
			button = XMfgPp2lZn;
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
			return eEMgcfbjCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eEMgcfbjCr = value;
		}
	}

	internal virtual TextBox tbSimbologiaLayout
	{
		[CompilerGenerated]
		get
		{
			return JpQgKou8at;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JpQgKou8at = value;
		}
	}

	internal virtual Button selDirSimbologiaLayout
	{
		[CompilerGenerated]
		get
		{
			return Ce0gebAk44;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YifyyJIEOo;
			Button button = Ce0gebAk44;
			if (button != null)
			{
				button.Click -= value2;
			}
			Ce0gebAk44 = value;
			button = Ce0gebAk44;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbIncluirColuna3
	{
		[CompilerGenerated]
		get
		{
			return dkNg2SInfg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dkNg2SInfg = value;
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return Oojg3SAEPT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Oojg3SAEPT = value;
		}
	}

	internal virtual Label Label8
	{
		[CompilerGenerated]
		get
		{
			return ehOgnuDfRD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ehOgnuDfRD = value;
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return Yrag1vT2LI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Yrag1vT2LI = value;
		}
	}

	internal virtual TextBox tbFonteCircuitos
	{
		[CompilerGenerated]
		get
		{
			return rhlglhGtbC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = CQvyuqIU3r;
			TextBox textBox = rhlglhGtbC;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			rhlglhGtbC = value;
			textBox = rhlglhGtbC;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label Label10
	{
		[CompilerGenerated]
		get
		{
			return Tmgg57W9VY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Tmgg57W9VY = value;
		}
	}

	internal virtual Label Label11
	{
		[CompilerGenerated]
		get
		{
			return vtVg0evoOm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vtVg0evoOm = value;
		}
	}

	internal virtual TextBox tbFonteCabos
	{
		[CompilerGenerated]
		get
		{
			return iaSgRnkRFr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = R9uyEZRasr;
			TextBox textBox = iaSgRnkRFr;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			iaSgRnkRFr = value;
			textBox = iaSgRnkRFr;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return oYAgmqmAmE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oYAgmqmAmE = value;
		}
	}

	internal virtual RadioButton rbANSI
	{
		[CompilerGenerated]
		get
		{
			return MsugXmCKwa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MsugXmCKwa = value;
		}
	}

	internal virtual RadioButton rbIEC
	{
		[CompilerGenerated]
		get
		{
			return XiMgUJWprd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XiMgUJWprd = value;
		}
	}

	internal virtual RadioButton rbIncluirColuna4
	{
		[CompilerGenerated]
		get
		{
			return YxUgyKlyk5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YxUgyKlyk5 = value;
		}
	}

	internal virtual GroupBox GroupBox12
	{
		[CompilerGenerated]
		get
		{
			return x3rggprDGj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			x3rggprDGj = value;
		}
	}

	internal virtual Label Label14
	{
		[CompilerGenerated]
		get
		{
			return XZUgAkK1yW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XZUgAkK1yW = value;
		}
	}

	internal virtual TextBox tbSufixoCruzamentoExterno
	{
		[CompilerGenerated]
		get
		{
			return rDFgsSlssc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rDFgsSlssc = value;
		}
	}

	internal virtual Label Label13
	{
		[CompilerGenerated]
		get
		{
			return kXOgB371j2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kXOgB371j2 = value;
		}
	}

	internal virtual TextBox tbPrefixoCruzamentoExterno
	{
		[CompilerGenerated]
		get
		{
			return I5UgVgUUx1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			I5UgVgUUx1 = value;
		}
	}

	internal virtual GroupBox GroupBox13
	{
		[CompilerGenerated]
		get
		{
			return PYdgu2UIm4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PYdgu2UIm4 = value;
		}
	}

	internal virtual TextBox tbSufixoCruzamentoInterno
	{
		[CompilerGenerated]
		get
		{
			return JqSgE2ms1l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JqSgE2ms1l = value;
		}
	}

	internal virtual Label Label12
	{
		[CompilerGenerated]
		get
		{
			return nNigZ8ksIb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nNigZ8ksIb = value;
		}
	}

	internal virtual TextBox tbPrefixoCruzamentoInterno
	{
		[CompilerGenerated]
		get
		{
			return zIFgijJ67v;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zIFgijJ67v = value;
		}
	}

	internal virtual Label Label15
	{
		[CompilerGenerated]
		get
		{
			return Y4fgSRGPwO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Y4fgSRGPwO = value;
		}
	}

	internal virtual GroupBox GroupBox14
	{
		[CompilerGenerated]
		get
		{
			return xRAg4Q3WOg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xRAg4Q3WOg = value;
		}
	}

	internal virtual TextBox tbSimbologiaRelatorios
	{
		[CompilerGenerated]
		get
		{
			return N82gC2ApxB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			N82gC2ApxB = value;
		}
	}

	internal virtual Button selDirSimbologiaRelatorios
	{
		[CompilerGenerated]
		get
		{
			return iUlgYlRY89;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jlyygCXVXI;
			Button button = iUlgYlRY89;
			if (button != null)
			{
				button.Click -= value2;
			}
			iUlgYlRY89 = value;
			button = iUlgYlRY89;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox15
	{
		[CompilerGenerated]
		get
		{
			return Xg2grXhtkH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Xg2grXhtkH = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return sZLg9McrrE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sZLg9McrrE = value;
		}
	}

	internal virtual TextBox tbSufixoCruzamentoFF
	{
		[CompilerGenerated]
		get
		{
			return sBigzgw9e0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sBigzgw9e0 = value;
		}
	}

	internal virtual Label Label9
	{
		[CompilerGenerated]
		get
		{
			return zL6AWsxtoS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zL6AWsxtoS = value;
		}
	}

	internal virtual TextBox tbPrefixoCruzamentoFF
	{
		[CompilerGenerated]
		get
		{
			return AYWApdJQ68;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AYWApdJQ68 = value;
		}
	}

	internal virtual GroupBox GroupBox16
	{
		[CompilerGenerated]
		get
		{
			return PS8ATmCRZf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PS8ATmCRZf = value;
		}
	}

	internal virtual Button btEletrosul
	{
		[CompilerGenerated]
		get
		{
			return s3WAJM2b9V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QD0y0V9eIp;
			Button button = s3WAJM2b9V;
			if (button != null)
			{
				button.Click -= value2;
			}
			s3WAJM2b9V = value;
			button = s3WAJM2b9V;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEletronorte
	{
		[CompilerGenerated]
		get
		{
			return fJrAhKPdiq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = t86y5UlFWX;
			Button button = fJrAhKPdiq;
			if (button != null)
			{
				button.Click -= value2;
			}
			fJrAhKPdiq = value;
			button = fJrAhKPdiq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbIncluirColuna6
	{
		[CompilerGenerated]
		get
		{
			return IkkAohgM65;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IkkAohgM65 = value;
		}
	}

	internal virtual RadioButton rbIncluirColuna5
	{
		[CompilerGenerated]
		get
		{
			return bfcAGWgAXf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bfcAGWgAXf = value;
		}
	}

	internal virtual Button btChesf
	{
		[CompilerGenerated]
		get
		{
			return Ob1AHewwgW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zYIyRqNngg;
			Button button = Ob1AHewwgW;
			if (button != null)
			{
				button.Click -= value2;
			}
			Ob1AHewwgW = value;
			button = Ob1AHewwgW;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label16
	{
		[CompilerGenerated]
		get
		{
			return QLWAk6XMjf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QLWAk6XMjf = value;
		}
	}

	internal virtual TextBox tbSeparadorCarimbo
	{
		[CompilerGenerated]
		get
		{
			return exkAdGM5Uq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exkAdGM5Uq = value;
		}
	}

	internal virtual Label Label17
	{
		[CompilerGenerated]
		get
		{
			return auTAfsnZeb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			auTAfsnZeb = value;
		}
	}

	internal virtual TextBox tbFonteCruzamento
	{
		[CompilerGenerated]
		get
		{
			return Y0JADTICc5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Y0JADTICc5 = value;
		}
	}

	internal virtual GroupBox GroupBox17
	{
		[CompilerGenerated]
		get
		{
			return ufeAvPx10n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ufeAvPx10n = value;
		}
	}

	internal virtual RadioButton RBBobinaContato2
	{
		[CompilerGenerated]
		get
		{
			return uwYA66JCph;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uwYA66JCph = value;
		}
	}

	internal virtual RadioButton RBContato1
	{
		[CompilerGenerated]
		get
		{
			return j3HAt4MgyZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			j3HAt4MgyZ = value;
		}
	}

	internal virtual RadioButton RBBobina0
	{
		[CompilerGenerated]
		get
		{
			return pduAjYyapX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pduAjYyapX = value;
		}
	}

	internal virtual GroupBox GroupBox18
	{
		[CompilerGenerated]
		get
		{
			return eALAL95iP4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eALAL95iP4 = value;
		}
	}

	internal virtual RadioButton RBLayInter1
	{
		[CompilerGenerated]
		get
		{
			return ao5AwoS2eb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ao5AwoS2eb = value;
		}
	}

	internal virtual RadioButton RBLayInter0
	{
		[CompilerGenerated]
		get
		{
			return y4lAx40kbv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			y4lAx40kbv = value;
		}
	}

	internal virtual RadioButton RBBobinaContatoES3
	{
		[CompilerGenerated]
		get
		{
			return oqTAblFPbn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oqTAblFPbn = value;
		}
	}

	internal virtual RadioButton RBLayInter2
	{
		[CompilerGenerated]
		get
		{
			return Q8pAMMC6AA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Q8pAMMC6AA = value;
		}
	}

	internal virtual RadioButton RBLayInter3
	{
		[CompilerGenerated]
		get
		{
			return a0DAO6XfRg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a0DAO6XfRg = value;
		}
	}

	internal virtual GroupBox GroupBox4B
	{
		[CompilerGenerated]
		get
		{
			return uNMAISDah4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uNMAISDah4 = value;
		}
	}

	internal virtual Label Label18
	{
		[CompilerGenerated]
		get
		{
			return tvcA7piWwk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tvcA7piWwk = value;
		}
	}

	internal virtual ComboBox cbEstilosLinha
	{
		[CompilerGenerated]
		get
		{
			return YqpAq0Gssc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tD6yZygnhx;
			ComboBox comboBox = YqpAq0Gssc;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			YqpAq0Gssc = value;
			comboBox = YqpAq0Gssc;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox tbEstiloLinhaEscala
	{
		[CompilerGenerated]
		get
		{
			return sDvAa34gOw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sDvAa34gOw = value;
		}
	}

	internal virtual GroupBox GroupBox19
	{
		[CompilerGenerated]
		get
		{
			return YpcA8oVFmK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YpcA8oVFmK = value;
		}
	}

	internal virtual RadioButton rbSQLite
	{
		[CompilerGenerated]
		get
		{
			return LpgAN18XSw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sGoy4Xx4Wm;
			RadioButton radioButton = LpgAN18XSw;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			LpgAN18XSw = value;
			radioButton = LpgAN18XSw;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbAccess
	{
		[CompilerGenerated]
		get
		{
			return qaHAFtTXVi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rSfySAjauK;
			RadioButton radioButton = qaHAFtTXVi;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			qaHAFtTXVi = value;
			radioButton = qaHAFtTXVi;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label Label19
	{
		[CompilerGenerated]
		get
		{
			return BYlAQR9BnD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BYlAQR9BnD = value;
		}
	}

	internal virtual TextBox tbSeparadorReguaBorne
	{
		[CompilerGenerated]
		get
		{
			return fplAPFR6OL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fplAPFR6OL = value;
		}
	}

	internal virtual TabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return WtTAcd7Mog;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WtTAcd7Mog = value;
		}
	}

	internal virtual TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return T2cAKD6Onv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			T2cAKD6Onv = value;
		}
	}

	internal virtual TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return O33AedOyP6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			O33AedOyP6 = value;
		}
	}

	internal virtual TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return HCmA2QGePf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HCmA2QGePf = value;
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return t1OA3n2UAV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GuKynurbxa;
			Button button = t1OA3n2UAV;
			if (button != null)
			{
				button.Click -= value2;
			}
			t1OA3n2UAV = value;
			button = t1OA3n2UAV;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbSQLSVR
	{
		[CompilerGenerated]
		get
		{
			return G3YAnWfY0v;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MS8yirH2QO;
			RadioButton radioButton = G3YAnWfY0v;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			G3YAnWfY0v = value;
			radioButton = G3YAnWfY0v;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GBSql
	{
		[CompilerGenerated]
		get
		{
			return S0UA1ygRHN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			S0UA1ygRHN = value;
		}
	}

	internal virtual TextBox tbSenha
	{
		[CompilerGenerated]
		get
		{
			return GiYAl4pxMB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GiYAl4pxMB = value;
		}
	}

	internal virtual Label lbPassword
	{
		[CompilerGenerated]
		get
		{
			return Y2iA5hXTNa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Y2iA5hXTNa = value;
		}
	}

	internal virtual Label lbUserName
	{
		[CompilerGenerated]
		get
		{
			return qxGA0cBsK0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qxGA0cBsK0 = value;
		}
	}

	internal virtual Label lbDataBase
	{
		[CompilerGenerated]
		get
		{
			return hyIARjnu65;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hyIARjnu65 = value;
		}
	}

	internal virtual Label lbDataSource
	{
		[CompilerGenerated]
		get
		{
			return lkkAmPXF4J;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lkkAmPXF4J = value;
		}
	}

	internal virtual TextBox tbUser
	{
		[CompilerGenerated]
		get
		{
			return XWaAXGxmnb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XWaAXGxmnb = value;
		}
	}

	internal virtual TextBox tbBancoDeDados
	{
		[CompilerGenerated]
		get
		{
			return pWDAUO1m7r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pWDAUO1m7r = value;
		}
	}

	internal virtual TextBox tbDataSource
	{
		[CompilerGenerated]
		get
		{
			return rmoAyDBegm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rmoAyDBegm = value;
		}
	}

	internal virtual Button btConectarSQLServer
	{
		[CompilerGenerated]
		get
		{
			return d65AgudJSY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jB1yY6W3uu;
			Button button = d65AgudJSY;
			if (button != null)
			{
				button.Click -= value2;
			}
			d65AgudJSY = value;
			button = d65AgudJSY;
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
			if (disposing && T0NyrOXDCq != null)
			{
				T0NyrOXDCq.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void HFdy3lXg4r()
	{
		aHypBEW66iS(new FolderBrowserDialog());
		GroupBox9 = new GroupBox();
		tbSimbologiaEletrica = new TextBox();
		SelDirSimbologiaEletrica = new Button();
		GBAccess = new GroupBox();
		tbProjeto = new TextBox();
		SelProj = new Button();
		GroupBox1 = new GroupBox();
		rbIdioma2 = new RadioButton();
		rbIdioma1 = new RadioButton();
		GroupBox3 = new GroupBox();
		tbCaderno = new TextBox();
		GroupBox10 = new GroupBox();
		tbSimbologiaTopografico = new TextBox();
		SelDirSimbologiaTopografico = new Button();
		GroupBox5 = new GroupBox();
		rbIncluirColuna6 = new RadioButton();
		rbIncluirColuna5 = new RadioButton();
		rbIncluirColuna4 = new RadioButton();
		rbIncluirColuna3 = new RadioButton();
		rbIncluirColuna2 = new RadioButton();
		rbIncluirColuna1 = new RadioButton();
		rbIncluirColuna0 = new RadioButton();
		GroupBox4 = new GroupBox();
		Label3 = new Label();
		Label2 = new Label();
		btCorTextoCircuito = new Button();
		btCorConexao = new Button();
		Label5 = new Label();
		Label4 = new Label();
		btCorTextoInterligacao = new Button();
		btCorInterligacao = new Button();
		tbSeparadorCruzamento = new TextBox();
		tbSeparadorCaboVeia = new TextBox();
		Label7 = new Label();
		tbTerminalIndefinido = new TextBox();
		Label6 = new Label();
		GroupBox11 = new GroupBox();
		tbSimbologiaLayout = new TextBox();
		selDirSimbologiaLayout = new Button();
		GroupBox6 = new GroupBox();
		Label19 = new Label();
		tbSeparadorReguaBorne = new TextBox();
		Label16 = new Label();
		tbSeparadorCarimbo = new TextBox();
		Label8 = new Label();
		GroupBox7 = new GroupBox();
		Label17 = new Label();
		tbFonteCircuitos = new TextBox();
		Label10 = new Label();
		tbFonteCruzamento = new TextBox();
		Label11 = new Label();
		tbFonteCabos = new TextBox();
		GroupBox2 = new GroupBox();
		rbANSI = new RadioButton();
		rbIEC = new RadioButton();
		GroupBox12 = new GroupBox();
		Label14 = new Label();
		tbSufixoCruzamentoExterno = new TextBox();
		Label13 = new Label();
		tbPrefixoCruzamentoExterno = new TextBox();
		GroupBox13 = new GroupBox();
		tbSufixoCruzamentoInterno = new TextBox();
		Label12 = new Label();
		tbPrefixoCruzamentoInterno = new TextBox();
		Label15 = new Label();
		GroupBox14 = new GroupBox();
		tbSimbologiaRelatorios = new TextBox();
		selDirSimbologiaRelatorios = new Button();
		GroupBox15 = new GroupBox();
		Label1 = new Label();
		tbSufixoCruzamentoFF = new TextBox();
		Label9 = new Label();
		tbPrefixoCruzamentoFF = new TextBox();
		GroupBox16 = new GroupBox();
		btChesf = new Button();
		btEletrosul = new Button();
		btEletronorte = new Button();
		GroupBox17 = new GroupBox();
		RBBobinaContatoES3 = new RadioButton();
		RBBobinaContato2 = new RadioButton();
		RBContato1 = new RadioButton();
		RBBobina0 = new RadioButton();
		GroupBox18 = new GroupBox();
		RBLayInter3 = new RadioButton();
		RBLayInter2 = new RadioButton();
		RBLayInter1 = new RadioButton();
		RBLayInter0 = new RadioButton();
		GroupBox4B = new GroupBox();
		tbEstiloLinhaEscala = new TextBox();
		Label18 = new Label();
		cbEstilosLinha = new ComboBox();
		GroupBox19 = new GroupBox();
		rbSQLSVR = new RadioButton();
		rbSQLite = new RadioButton();
		rbAccess = new RadioButton();
		TabControl1 = new TabControl();
		TabPage1 = new TabPage();
		GBSql = new GroupBox();
		btConectarSQLServer = new Button();
		tbSenha = new TextBox();
		lbPassword = new Label();
		lbUserName = new Label();
		lbDataBase = new Label();
		lbDataSource = new Label();
		tbUser = new TextBox();
		tbBancoDeDados = new TextBox();
		tbDataSource = new TextBox();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		btSalvar = new Button();
		GroupBox9.SuspendLayout();
		GBAccess.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox10.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox11.SuspendLayout();
		GroupBox6.SuspendLayout();
		GroupBox7.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox12.SuspendLayout();
		GroupBox13.SuspendLayout();
		GroupBox14.SuspendLayout();
		GroupBox15.SuspendLayout();
		GroupBox16.SuspendLayout();
		GroupBox17.SuspendLayout();
		GroupBox18.SuspendLayout();
		GroupBox4B.SuspendLayout();
		GroupBox19.SuspendLayout();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		GBSql.SuspendLayout();
		TabPage2.SuspendLayout();
		TabPage3.SuspendLayout();
		SuspendLayout();
		GroupBox9.Controls.Add(tbSimbologiaEletrica);
		GroupBox9.Controls.Add(SelDirSimbologiaEletrica);
		GroupBox9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GroupBox9.Location = new Point(6, 6);
		GroupBox9.Name = "GroupBox9";
		GroupBox9.Size = new Size(415, 66);
		GroupBox9.TabIndex = 16;
		GroupBox9.TabStop = false;
		GroupBox9.Text = "Simbologia Elétrica";
		tbSimbologiaEletrica.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSimbologiaEletrica.Location = new Point(6, 19);
		tbSimbologiaEletrica.Multiline = true;
		tbSimbologiaEletrica.Name = "tbSimbologiaEletrica";
		tbSimbologiaEletrica.Size = new Size(361, 32);
		tbSimbologiaEletrica.TabIndex = 5;
		SelDirSimbologiaEletrica.FlatStyle = FlatStyle.Flat;
		SelDirSimbologiaEletrica.ForeColor = SystemColors.Control;
		SelDirSimbologiaEletrica.Image = Resources.Folder;
		SelDirSimbologiaEletrica.Location = new Point(373, 19);
		SelDirSimbologiaEletrica.Name = "SelDirSimbologiaEletrica";
		SelDirSimbologiaEletrica.Size = new Size(36, 36);
		SelDirSimbologiaEletrica.TabIndex = 6;
		SelDirSimbologiaEletrica.UseVisualStyleBackColor = true;
		GBAccess.Controls.Add(tbProjeto);
		GBAccess.Controls.Add(SelProj);
		GBAccess.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GBAccess.Location = new Point(6, 164);
		GBAccess.Name = "GBAccess";
		GBAccess.Size = new Size(415, 81);
		GBAccess.TabIndex = 17;
		GBAccess.TabStop = false;
		GBAccess.Text = "Banco do Projeto";
		tbProjeto.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbProjeto.Location = new Point(6, 19);
		tbProjeto.Multiline = true;
		tbProjeto.Name = "tbProjeto";
		tbProjeto.Size = new Size(361, 50);
		tbProjeto.TabIndex = 3;
		SelProj.FlatStyle = FlatStyle.Flat;
		SelProj.ForeColor = SystemColors.Control;
		SelProj.Image = Resources.Database_32;
		SelProj.Location = new Point(373, 25);
		SelProj.Name = "SelProj";
		SelProj.Size = new Size(36, 36);
		SelProj.TabIndex = 4;
		SelProj.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(rbIdioma2);
		GroupBox1.Controls.Add(rbIdioma1);
		GroupBox1.Location = new Point(6, 6);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(104, 74);
		GroupBox1.TabIndex = 18;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Idioma";
		rbIdioma2.AutoSize = true;
		rbIdioma2.Location = new Point(19, 47);
		rbIdioma2.Name = "rbIdioma2";
		rbIdioma2.Size = new Size(59, 17);
		rbIdioma2.TabIndex = 1;
		rbIdioma2.TabStop = true;
		rbIdioma2.Text = "English";
		rbIdioma2.UseVisualStyleBackColor = true;
		rbIdioma1.AutoSize = true;
		rbIdioma1.Location = new Point(19, 24);
		rbIdioma1.Name = "rbIdioma1";
		rbIdioma1.Size = new Size(73, 17);
		rbIdioma1.TabIndex = 0;
		rbIdioma1.TabStop = true;
		rbIdioma1.Text = "Português";
		rbIdioma1.UseVisualStyleBackColor = true;
		GroupBox3.Controls.Add(tbCaderno);
		GroupBox3.Location = new Point(236, 6);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(185, 74);
		GroupBox3.TabIndex = 20;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Nome do Caderno";
		tbCaderno.Location = new Point(6, 34);
		tbCaderno.Name = "tbCaderno";
		tbCaderno.Size = new Size(173, 20);
		tbCaderno.TabIndex = 2;
		GroupBox10.Controls.Add(tbSimbologiaTopografico);
		GroupBox10.Controls.Add(SelDirSimbologiaTopografico);
		GroupBox10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GroupBox10.Location = new Point(6, 77);
		GroupBox10.Name = "GroupBox10";
		GroupBox10.Size = new Size(415, 66);
		GroupBox10.TabIndex = 17;
		GroupBox10.TabStop = false;
		GroupBox10.Text = "Simbologia Topográfico";
		tbSimbologiaTopografico.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSimbologiaTopografico.Location = new Point(6, 19);
		tbSimbologiaTopografico.Multiline = true;
		tbSimbologiaTopografico.Name = "tbSimbologiaTopografico";
		tbSimbologiaTopografico.Size = new Size(361, 32);
		tbSimbologiaTopografico.TabIndex = 7;
		SelDirSimbologiaTopografico.FlatStyle = FlatStyle.Flat;
		SelDirSimbologiaTopografico.ForeColor = SystemColors.Control;
		SelDirSimbologiaTopografico.Image = Resources.Folder;
		SelDirSimbologiaTopografico.Location = new Point(373, 19);
		SelDirSimbologiaTopografico.Name = "SelDirSimbologiaTopografico";
		SelDirSimbologiaTopografico.Size = new Size(36, 36);
		SelDirSimbologiaTopografico.TabIndex = 8;
		SelDirSimbologiaTopografico.UseVisualStyleBackColor = true;
		GroupBox5.Controls.Add(rbIncluirColuna6);
		GroupBox5.Controls.Add(rbIncluirColuna5);
		GroupBox5.Controls.Add(rbIncluirColuna4);
		GroupBox5.Controls.Add(rbIncluirColuna3);
		GroupBox5.Controls.Add(rbIncluirColuna2);
		GroupBox5.Controls.Add(rbIncluirColuna1);
		GroupBox5.Controls.Add(rbIncluirColuna0);
		GroupBox5.Location = new Point(6, 64);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(200, 175);
		GroupBox5.TabIndex = 41;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Cruzamento de Páginas";
		rbIncluirColuna6.AutoSize = true;
		rbIncluirColuna6.Location = new Point(13, 152);
		rbIncluirColuna6.Name = "rbIncluirColuna6";
		rbIncluirColuna6.Size = new Size(117, 17);
		rbIncluirColuna6.TabIndex = 6;
		rbIncluirColuna6.TabStop = true;
		rbIncluirColuna6.Text = "(Página) Alternativo";
		rbIncluirColuna6.UseVisualStyleBackColor = true;
		rbIncluirColuna5.AutoSize = true;
		rbIncluirColuna5.Location = new Point(13, 130);
		rbIncluirColuna5.Name = "rbIncluirColuna5";
		rbIncluirColuna5.Size = new Size(126, 17);
		rbIncluirColuna5.TabIndex = 5;
		rbIncluirColuna5.TabStop = true;
		rbIncluirColuna5.Text = "Alternativo  +  Coluna";
		rbIncluirColuna5.UseVisualStyleBackColor = true;
		rbIncluirColuna4.AutoSize = true;
		rbIncluirColuna4.Location = new Point(13, 108);
		rbIncluirColuna4.Name = "rbIncluirColuna4";
		rbIncluirColuna4.Size = new Size(120, 17);
		rbIncluirColuna4.TabIndex = 4;
		rbIncluirColuna4.TabStop = true;
		rbIncluirColuna4.Text = "Coluna + Alternativo";
		rbIncluirColuna4.UseVisualStyleBackColor = true;
		rbIncluirColuna3.AutoSize = true;
		rbIncluirColuna3.Location = new Point(13, 86);
		rbIncluirColuna3.Name = "rbIncluirColuna3";
		rbIncluirColuna3.Size = new Size(75, 17);
		rbIncluirColuna3.TabIndex = 3;
		rbIncluirColuna3.TabStop = true;
		rbIncluirColuna3.Text = "Alternativo";
		rbIncluirColuna3.UseVisualStyleBackColor = true;
		rbIncluirColuna2.AutoSize = true;
		rbIncluirColuna2.Location = new Point(13, 64);
		rbIncluirColuna2.Name = "rbIncluirColuna2";
		rbIncluirColuna2.Size = new Size(103, 17);
		rbIncluirColuna2.TabIndex = 2;
		rbIncluirColuna2.TabStop = true;
		rbIncluirColuna2.Text = "Coluna + Página";
		rbIncluirColuna2.UseVisualStyleBackColor = true;
		rbIncluirColuna1.AutoSize = true;
		rbIncluirColuna1.Location = new Point(13, 42);
		rbIncluirColuna1.Name = "rbIncluirColuna1";
		rbIncluirColuna1.Size = new Size(103, 17);
		rbIncluirColuna1.TabIndex = 1;
		rbIncluirColuna1.TabStop = true;
		rbIncluirColuna1.Text = "Página + Coluna";
		rbIncluirColuna1.UseVisualStyleBackColor = true;
		rbIncluirColuna0.AutoSize = true;
		rbIncluirColuna0.Location = new Point(13, 20);
		rbIncluirColuna0.Name = "rbIncluirColuna0";
		rbIncluirColuna0.Size = new Size(58, 17);
		rbIncluirColuna0.TabIndex = 0;
		rbIncluirColuna0.TabStop = true;
		rbIncluirColuna0.Text = "Página";
		rbIncluirColuna0.UseVisualStyleBackColor = true;
		GroupBox4.Controls.Add(Label3);
		GroupBox4.Controls.Add(Label2);
		GroupBox4.Controls.Add(btCorTextoCircuito);
		GroupBox4.Controls.Add(btCorConexao);
		GroupBox4.Location = new Point(221, 64);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(197, 70);
		GroupBox4.TabIndex = 40;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Cores";
		Label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label3.Location = new Point(29, 45);
		Label3.Name = "Label3";
		Label3.Size = new Size(111, 23);
		Label3.TabIndex = 38;
		Label3.Text = "Texto Circuito";
		Label3.TextAlign = ContentAlignment.TopRight;
		Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label2.Location = new Point(29, 20);
		Label2.Name = "Label2";
		Label2.Size = new Size(111, 23);
		Label2.TabIndex = 37;
		Label2.Text = "Conexão";
		Label2.TextAlign = ContentAlignment.TopRight;
		btCorTextoCircuito.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btCorTextoCircuito.BackColor = SystemColors.ActiveCaption;
		btCorTextoCircuito.Location = new Point(147, 40);
		btCorTextoCircuito.Name = "btCorTextoCircuito";
		btCorTextoCircuito.Size = new Size(35, 23);
		btCorTextoCircuito.TabIndex = 1;
		btCorTextoCircuito.UseVisualStyleBackColor = false;
		btCorConexao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btCorConexao.BackColor = SystemColors.ActiveCaption;
		btCorConexao.Location = new Point(147, 15);
		btCorConexao.Name = "btCorConexao";
		btCorConexao.Size = new Size(35, 23);
		btCorConexao.TabIndex = 0;
		btCorConexao.UseVisualStyleBackColor = false;
		Label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label5.Location = new Point(27, 45);
		Label5.Name = "Label5";
		Label5.Size = new Size(118, 23);
		Label5.TabIndex = 43;
		Label5.Text = "Texto Interligação";
		Label5.TextAlign = ContentAlignment.TopRight;
		Label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label4.Location = new Point(24, 20);
		Label4.Name = "Label4";
		Label4.Size = new Size(118, 23);
		Label4.TabIndex = 42;
		Label4.Text = "Interligação";
		Label4.TextAlign = ContentAlignment.TopRight;
		btCorTextoInterligacao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btCorTextoInterligacao.BackColor = SystemColors.ActiveCaption;
		btCorTextoInterligacao.Location = new Point(148, 40);
		btCorTextoInterligacao.Name = "btCorTextoInterligacao";
		btCorTextoInterligacao.Size = new Size(35, 23);
		btCorTextoInterligacao.TabIndex = 40;
		btCorTextoInterligacao.UseVisualStyleBackColor = false;
		btCorInterligacao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btCorInterligacao.BackColor = SystemColors.ActiveCaption;
		btCorInterligacao.Location = new Point(148, 15);
		btCorInterligacao.Name = "btCorInterligacao";
		btCorInterligacao.Size = new Size(35, 23);
		btCorInterligacao.TabIndex = 39;
		btCorInterligacao.UseVisualStyleBackColor = false;
		tbSeparadorCruzamento.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSeparadorCruzamento.Location = new Point(150, 70);
		tbSeparadorCruzamento.Name = "tbSeparadorCruzamento";
		tbSeparadorCruzamento.Size = new Size(35, 20);
		tbSeparadorCruzamento.TabIndex = 48;
		tbSeparadorCruzamento.TextAlign = HorizontalAlignment.Center;
		tbSeparadorCaboVeia.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSeparadorCaboVeia.Location = new Point(150, 42);
		tbSeparadorCaboVeia.Name = "tbSeparadorCaboVeia";
		tbSeparadorCaboVeia.Size = new Size(35, 20);
		tbSeparadorCaboVeia.TabIndex = 46;
		tbSeparadorCaboVeia.TextAlign = HorizontalAlignment.Center;
		Label7.Location = new Point(26, 45);
		Label7.Name = "Label7";
		Label7.Size = new Size(120, 17);
		Label7.TabIndex = 45;
		Label7.Text = "Label7";
		Label7.TextAlign = ContentAlignment.MiddleRight;
		tbTerminalIndefinido.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbTerminalIndefinido.Location = new Point(150, 16);
		tbTerminalIndefinido.Name = "tbTerminalIndefinido";
		tbTerminalIndefinido.Size = new Size(35, 20);
		tbTerminalIndefinido.TabIndex = 27;
		tbTerminalIndefinido.TextAlign = HorizontalAlignment.Center;
		Label6.Location = new Point(24, 17);
		Label6.Name = "Label6";
		Label6.Size = new Size(120, 17);
		Label6.TabIndex = 36;
		Label6.Text = "Label6";
		Label6.TextAlign = ContentAlignment.MiddleRight;
		GroupBox11.Controls.Add(tbSimbologiaLayout);
		GroupBox11.Controls.Add(selDirSimbologiaLayout);
		GroupBox11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GroupBox11.Location = new Point(6, 148);
		GroupBox11.Name = "GroupBox11";
		GroupBox11.Size = new Size(415, 66);
		GroupBox11.TabIndex = 18;
		GroupBox11.TabStop = false;
		GroupBox11.Text = "Simbologia Layout";
		tbSimbologiaLayout.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSimbologiaLayout.Location = new Point(6, 19);
		tbSimbologiaLayout.Multiline = true;
		tbSimbologiaLayout.Name = "tbSimbologiaLayout";
		tbSimbologiaLayout.Size = new Size(361, 32);
		tbSimbologiaLayout.TabIndex = 7;
		selDirSimbologiaLayout.FlatStyle = FlatStyle.Flat;
		selDirSimbologiaLayout.ForeColor = SystemColors.Control;
		selDirSimbologiaLayout.Image = Resources.Folder;
		selDirSimbologiaLayout.Location = new Point(373, 19);
		selDirSimbologiaLayout.Name = "selDirSimbologiaLayout";
		selDirSimbologiaLayout.Size = new Size(36, 36);
		selDirSimbologiaLayout.TabIndex = 8;
		selDirSimbologiaLayout.UseVisualStyleBackColor = true;
		GroupBox6.Controls.Add(Label19);
		GroupBox6.Controls.Add(tbSeparadorReguaBorne);
		GroupBox6.Controls.Add(Label16);
		GroupBox6.Controls.Add(tbSeparadorCarimbo);
		GroupBox6.Controls.Add(Label8);
		GroupBox6.Controls.Add(tbTerminalIndefinido);
		GroupBox6.Controls.Add(Label6);
		GroupBox6.Controls.Add(Label7);
		GroupBox6.Controls.Add(tbSeparadorCruzamento);
		GroupBox6.Controls.Add(tbSeparadorCaboVeia);
		GroupBox6.Location = new Point(6, 241);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(200, 155);
		GroupBox6.TabIndex = 42;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Caracteres";
		Label19.Location = new Point(0, 125);
		Label19.Name = "Label19";
		Label19.Size = new Size(144, 20);
		Label19.TabIndex = 53;
		Label19.Text = "Label19";
		Label19.TextAlign = ContentAlignment.TopRight;
		tbSeparadorReguaBorne.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSeparadorReguaBorne.Location = new Point(150, 122);
		tbSeparadorReguaBorne.Name = "tbSeparadorReguaBorne";
		tbSeparadorReguaBorne.Size = new Size(35, 20);
		tbSeparadorReguaBorne.TabIndex = 52;
		tbSeparadorReguaBorne.TextAlign = HorizontalAlignment.Center;
		Label16.Location = new Point(18, 99);
		Label16.Name = "Label16";
		Label16.Size = new Size(126, 20);
		Label16.TabIndex = 51;
		Label16.Text = "Label16";
		Label16.TextAlign = ContentAlignment.TopRight;
		tbSeparadorCarimbo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSeparadorCarimbo.Location = new Point(150, 96);
		tbSeparadorCarimbo.Name = "tbSeparadorCarimbo";
		tbSeparadorCarimbo.Size = new Size(35, 20);
		tbSeparadorCarimbo.TabIndex = 50;
		tbSeparadorCarimbo.TextAlign = HorizontalAlignment.Center;
		Label8.Location = new Point(18, 73);
		Label8.Name = "Label8";
		Label8.Size = new Size(126, 20);
		Label8.TabIndex = 49;
		Label8.Text = "Label8";
		Label8.TextAlign = ContentAlignment.TopRight;
		GroupBox7.Controls.Add(Label17);
		GroupBox7.Controls.Add(tbFonteCircuitos);
		GroupBox7.Controls.Add(Label10);
		GroupBox7.Controls.Add(tbFonteCruzamento);
		GroupBox7.Controls.Add(Label11);
		GroupBox7.Controls.Add(tbFonteCabos);
		GroupBox7.Location = new Point(6, 402);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(200, 91);
		GroupBox7.TabIndex = 50;
		GroupBox7.TabStop = false;
		GroupBox7.Text = "Altura Textos";
		Label17.Location = new Point(6, 40);
		Label17.Name = "Label17";
		Label17.Size = new Size(138, 19);
		Label17.TabIndex = 47;
		Label17.Text = "Label17";
		Label17.TextAlign = ContentAlignment.MiddleRight;
		tbFonteCircuitos.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteCircuitos.Location = new Point(150, 13);
		tbFonteCircuitos.Name = "tbFonteCircuitos";
		tbFonteCircuitos.Size = new Size(35, 20);
		tbFonteCircuitos.TabIndex = 27;
		tbFonteCircuitos.TextAlign = HorizontalAlignment.Center;
		Label10.Location = new Point(6, 14);
		Label10.Name = "Label10";
		Label10.Size = new Size(138, 19);
		Label10.TabIndex = 36;
		Label10.Text = "Label10";
		Label10.TextAlign = ContentAlignment.MiddleRight;
		tbFonteCruzamento.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteCruzamento.Location = new Point(150, 39);
		tbFonteCruzamento.Name = "tbFonteCruzamento";
		tbFonteCruzamento.Size = new Size(35, 20);
		tbFonteCruzamento.TabIndex = 48;
		tbFonteCruzamento.TextAlign = HorizontalAlignment.Center;
		Label11.Location = new Point(6, 65);
		Label11.Name = "Label11";
		Label11.Size = new Size(138, 19);
		Label11.TabIndex = 45;
		Label11.Text = "Label11";
		Label11.TextAlign = ContentAlignment.MiddleRight;
		tbFonteCabos.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteCabos.Location = new Point(150, 65);
		tbFonteCabos.Name = "tbFonteCabos";
		tbFonteCabos.Size = new Size(35, 20);
		tbFonteCabos.TabIndex = 46;
		tbFonteCabos.TextAlign = HorizontalAlignment.Center;
		GroupBox2.Controls.Add(rbANSI);
		GroupBox2.Controls.Add(rbIEC);
		GroupBox2.Location = new Point(116, 6);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(116, 74);
		GroupBox2.TabIndex = 42;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Contatos Auxiliares";
		rbANSI.AutoSize = true;
		rbANSI.Location = new Point(11, 48);
		rbANSI.Name = "rbANSI";
		rbANSI.Size = new Size(50, 17);
		rbANSI.TabIndex = 1;
		rbANSI.TabStop = true;
		rbANSI.Text = "ANSI";
		rbANSI.UseVisualStyleBackColor = true;
		rbIEC.AutoSize = true;
		rbIEC.Location = new Point(11, 25);
		rbIEC.Name = "rbIEC";
		rbIEC.Size = new Size(42, 17);
		rbIEC.TabIndex = 0;
		rbIEC.TabStop = true;
		rbIEC.Text = "IEC";
		rbIEC.UseVisualStyleBackColor = true;
		GroupBox12.Controls.Add(Label14);
		GroupBox12.Controls.Add(tbSufixoCruzamentoExterno);
		GroupBox12.Controls.Add(Label13);
		GroupBox12.Controls.Add(tbPrefixoCruzamentoExterno);
		GroupBox12.Location = new Point(221, 383);
		GroupBox12.Name = "GroupBox12";
		GroupBox12.Size = new Size(200, 70);
		GroupBox12.TabIndex = 60;
		GroupBox12.TabStop = false;
		GroupBox12.Text = "Cruzamento Log Func";
		Label14.Location = new Point(29, 49);
		Label14.Name = "Label14";
		Label14.Size = new Size(112, 18);
		Label14.TabIndex = 61;
		Label14.Text = "Label14";
		Label14.TextAlign = ContentAlignment.MiddleRight;
		tbSufixoCruzamentoExterno.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSufixoCruzamentoExterno.Location = new Point(147, 44);
		tbSufixoCruzamentoExterno.Name = "tbSufixoCruzamentoExterno";
		tbSufixoCruzamentoExterno.Size = new Size(35, 20);
		tbSufixoCruzamentoExterno.TabIndex = 60;
		tbSufixoCruzamentoExterno.TextAlign = HorizontalAlignment.Center;
		Label13.Location = new Point(29, 24);
		Label13.Name = "Label13";
		Label13.Size = new Size(112, 18);
		Label13.TabIndex = 59;
		Label13.Text = "Label13";
		Label13.TextAlign = ContentAlignment.MiddleRight;
		tbPrefixoCruzamentoExterno.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPrefixoCruzamentoExterno.Location = new Point(147, 19);
		tbPrefixoCruzamentoExterno.Name = "tbPrefixoCruzamentoExterno";
		tbPrefixoCruzamentoExterno.Size = new Size(35, 20);
		tbPrefixoCruzamentoExterno.TabIndex = 58;
		tbPrefixoCruzamentoExterno.TextAlign = HorizontalAlignment.Center;
		GroupBox13.Controls.Add(tbSufixoCruzamentoInterno);
		GroupBox13.Controls.Add(Label12);
		GroupBox13.Controls.Add(tbPrefixoCruzamentoInterno);
		GroupBox13.Controls.Add(Label15);
		GroupBox13.Location = new Point(221, 237);
		GroupBox13.Name = "GroupBox13";
		GroupBox13.Size = new Size(199, 70);
		GroupBox13.TabIndex = 59;
		GroupBox13.TabStop = false;
		GroupBox13.Text = "Cruzamento Interno";
		tbSufixoCruzamentoInterno.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSufixoCruzamentoInterno.Location = new Point(147, 41);
		tbSufixoCruzamentoInterno.Name = "tbSufixoCruzamentoInterno";
		tbSufixoCruzamentoInterno.Size = new Size(35, 20);
		tbSufixoCruzamentoInterno.TabIndex = 57;
		tbSufixoCruzamentoInterno.TextAlign = HorizontalAlignment.Center;
		Label12.Location = new Point(29, 46);
		Label12.Name = "Label12";
		Label12.Size = new Size(112, 18);
		Label12.TabIndex = 56;
		Label12.Text = "Label12";
		Label12.TextAlign = ContentAlignment.MiddleRight;
		tbPrefixoCruzamentoInterno.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPrefixoCruzamentoInterno.Location = new Point(147, 16);
		tbPrefixoCruzamentoInterno.Name = "tbPrefixoCruzamentoInterno";
		tbPrefixoCruzamentoInterno.Size = new Size(35, 20);
		tbPrefixoCruzamentoInterno.TabIndex = 54;
		tbPrefixoCruzamentoInterno.TextAlign = HorizontalAlignment.Center;
		Label15.Location = new Point(29, 21);
		Label15.Name = "Label15";
		Label15.Size = new Size(112, 18);
		Label15.TabIndex = 55;
		Label15.Text = "Label15";
		Label15.TextAlign = ContentAlignment.MiddleRight;
		GroupBox14.Controls.Add(tbSimbologiaRelatorios);
		GroupBox14.Controls.Add(selDirSimbologiaRelatorios);
		GroupBox14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GroupBox14.Location = new Point(6, 216);
		GroupBox14.Name = "GroupBox14";
		GroupBox14.Size = new Size(415, 66);
		GroupBox14.TabIndex = 61;
		GroupBox14.TabStop = false;
		GroupBox14.Text = "Simbologia Relatórios";
		tbSimbologiaRelatorios.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSimbologiaRelatorios.Location = new Point(6, 19);
		tbSimbologiaRelatorios.Multiline = true;
		tbSimbologiaRelatorios.Name = "tbSimbologiaRelatorios";
		tbSimbologiaRelatorios.Size = new Size(361, 32);
		tbSimbologiaRelatorios.TabIndex = 7;
		selDirSimbologiaRelatorios.FlatStyle = FlatStyle.Flat;
		selDirSimbologiaRelatorios.ForeColor = SystemColors.Control;
		selDirSimbologiaRelatorios.Image = Resources.Folder;
		selDirSimbologiaRelatorios.Location = new Point(373, 19);
		selDirSimbologiaRelatorios.Name = "selDirSimbologiaRelatorios";
		selDirSimbologiaRelatorios.Size = new Size(36, 36);
		selDirSimbologiaRelatorios.TabIndex = 8;
		selDirSimbologiaRelatorios.UseVisualStyleBackColor = true;
		GroupBox15.Controls.Add(Label1);
		GroupBox15.Controls.Add(tbSufixoCruzamentoFF);
		GroupBox15.Controls.Add(Label9);
		GroupBox15.Controls.Add(tbPrefixoCruzamentoFF);
		GroupBox15.Location = new Point(221, 310);
		GroupBox15.Name = "GroupBox15";
		GroupBox15.Size = new Size(199, 70);
		GroupBox15.TabIndex = 62;
		GroupBox15.TabStop = false;
		GroupBox15.Text = "Cruzamento Func Func";
		Label1.Location = new Point(29, 45);
		Label1.Name = "Label1";
		Label1.Size = new Size(112, 18);
		Label1.TabIndex = 61;
		Label1.Text = "Label1";
		Label1.TextAlign = ContentAlignment.MiddleRight;
		tbSufixoCruzamentoFF.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbSufixoCruzamentoFF.Location = new Point(147, 40);
		tbSufixoCruzamentoFF.Name = "tbSufixoCruzamentoFF";
		tbSufixoCruzamentoFF.Size = new Size(35, 20);
		tbSufixoCruzamentoFF.TabIndex = 60;
		tbSufixoCruzamentoFF.TextAlign = HorizontalAlignment.Center;
		Label9.Location = new Point(29, 20);
		Label9.Name = "Label9";
		Label9.Size = new Size(112, 18);
		Label9.TabIndex = 59;
		Label9.Text = "Label9";
		Label9.TextAlign = ContentAlignment.MiddleRight;
		tbPrefixoCruzamentoFF.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPrefixoCruzamentoFF.Location = new Point(147, 15);
		tbPrefixoCruzamentoFF.Name = "tbPrefixoCruzamentoFF";
		tbPrefixoCruzamentoFF.Size = new Size(35, 20);
		tbPrefixoCruzamentoFF.TabIndex = 58;
		tbPrefixoCruzamentoFF.TextAlign = HorizontalAlignment.Center;
		GroupBox16.Controls.Add(btChesf);
		GroupBox16.Controls.Add(btEletrosul);
		GroupBox16.Controls.Add(btEletronorte);
		GroupBox16.Location = new Point(6, 6);
		GroupBox16.Name = "GroupBox16";
		GroupBox16.Size = new Size(316, 53);
		GroupBox16.TabIndex = 63;
		GroupBox16.TabStop = false;
		GroupBox16.Text = "Configurar Padrão";
		btChesf.Font = new Font("Trebuchet MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btChesf.ForeColor = Color.DarkBlue;
		btChesf.Location = new Point(214, 17);
		btChesf.Name = "btChesf";
		btChesf.Size = new Size(95, 25);
		btChesf.TabIndex = 67;
		btChesf.Text = "Chesf";
		btChesf.UseVisualStyleBackColor = true;
		btEletrosul.Font = new Font("Trebuchet MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btEletrosul.ForeColor = Color.DarkBlue;
		btEletrosul.Location = new Point(110, 17);
		btEletrosul.Name = "btEletrosul";
		btEletrosul.Size = new Size(95, 25);
		btEletrosul.TabIndex = 66;
		btEletrosul.Text = "Eletrosul";
		btEletrosul.UseVisualStyleBackColor = true;
		btEletronorte.Font = new Font("Trebuchet MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btEletronorte.ForeColor = Color.DarkBlue;
		btEletronorte.Location = new Point(6, 17);
		btEletronorte.Name = "btEletronorte";
		btEletronorte.Size = new Size(95, 25);
		btEletronorte.TabIndex = 64;
		btEletronorte.Text = "Eletronorte";
		btEletronorte.UseVisualStyleBackColor = true;
		GroupBox17.Controls.Add(RBBobinaContatoES3);
		GroupBox17.Controls.Add(RBBobinaContato2);
		GroupBox17.Controls.Add(RBContato1);
		GroupBox17.Controls.Add(RBBobina0);
		GroupBox17.Location = new Point(220, 458);
		GroupBox17.Name = "GroupBox17";
		GroupBox17.Size = new Size(200, 105);
		GroupBox17.TabIndex = 64;
		GroupBox17.TabStop = false;
		GroupBox17.Text = "_Visualização Modelos Reles";
		RBBobinaContatoES3.AutoSize = true;
		RBBobinaContatoES3.Location = new Point(13, 80);
		RBBobinaContatoES3.Name = "RBBobinaContatoES3";
		RBBobinaContatoES3.Size = new Size(194, 17);
		RBBobinaContatoES3.TabIndex = 3;
		RBBobinaContatoES3.TabStop = true;
		RBBobinaContatoES3.Text = "_Na Bobina e no Contato (Eletrosul)";
		RBBobinaContatoES3.UseVisualStyleBackColor = true;
		RBBobinaContato2.AutoSize = true;
		RBBobinaContato2.Location = new Point(13, 60);
		RBBobinaContato2.Name = "RBBobinaContato2";
		RBBobinaContato2.Size = new Size(145, 17);
		RBBobinaContato2.TabIndex = 2;
		RBBobinaContato2.TabStop = true;
		RBBobinaContato2.Text = "_Na Bobina e no Contato";
		RBBobinaContato2.UseVisualStyleBackColor = true;
		RBContato1.AutoSize = true;
		RBContato1.Location = new Point(13, 20);
		RBContato1.Name = "RBContato1";
		RBContato1.Size = new Size(85, 17);
		RBContato1.TabIndex = 1;
		RBContato1.TabStop = true;
		RBContato1.Text = "_No Contato";
		RBContato1.UseVisualStyleBackColor = true;
		RBBobina0.AutoSize = true;
		RBBobina0.Location = new Point(13, 40);
		RBBobina0.Name = "RBBobina0";
		RBBobina0.Size = new Size(81, 17);
		RBBobina0.TabIndex = 0;
		RBBobina0.TabStop = true;
		RBBobina0.Text = "_Na Bobina";
		RBBobina0.UseVisualStyleBackColor = true;
		GroupBox18.Controls.Add(RBLayInter3);
		GroupBox18.Controls.Add(RBLayInter2);
		GroupBox18.Controls.Add(RBLayInter1);
		GroupBox18.Controls.Add(RBLayInter0);
		GroupBox18.Location = new Point(6, 495);
		GroupBox18.Name = "GroupBox18";
		GroupBox18.Size = new Size(200, 67);
		GroupBox18.TabIndex = 65;
		GroupBox18.TabStop = false;
		GroupBox18.Text = "_Representação Cabo/Veia";
		RBLayInter3.AutoSize = true;
		RBLayInter3.Location = new Point(110, 46);
		RBLayInter3.Name = "RBLayInter3";
		RBLayInter3.Size = new Size(76, 17);
		RBLayInter3.TabIndex = 3;
		RBLayInter3.TabStop = true;
		RBLayInter3.Text = "_ENEL-SP";
		RBLayInter3.UseVisualStyleBackColor = true;
		RBLayInter2.AutoSize = true;
		RBLayInter2.Location = new Point(9, 24);
		RBLayInter2.Name = "RBLayInter2";
		RBLayInter2.Size = new Size(64, 17);
		RBLayInter2.TabIndex = 2;
		RBLayInter2.TabStop = true;
		RBLayInter2.Text = "_Elétron";
		RBLayInter2.UseVisualStyleBackColor = true;
		RBLayInter1.AutoSize = true;
		RBLayInter1.Location = new Point(110, 24);
		RBLayInter1.Name = "RBLayInter1";
		RBLayInter1.Size = new Size(71, 17);
		RBLayInter1.TabIndex = 1;
		RBLayInter1.TabStop = true;
		RBLayInter1.Text = "_Eletrosul";
		RBLayInter1.UseVisualStyleBackColor = true;
		RBLayInter0.AutoSize = true;
		RBLayInter0.Location = new Point(9, 44);
		RBLayInter0.Name = "RBLayInter0";
		RBLayInter0.Size = new Size(82, 17);
		RBLayInter0.TabIndex = 0;
		RBLayInter0.TabStop = true;
		RBLayInter0.Text = "_Eletronorte";
		RBLayInter0.UseVisualStyleBackColor = true;
		GroupBox4B.Controls.Add(tbEstiloLinhaEscala);
		GroupBox4B.Controls.Add(Label18);
		GroupBox4B.Controls.Add(cbEstilosLinha);
		GroupBox4B.Controls.Add(Label5);
		GroupBox4B.Controls.Add(btCorInterligacao);
		GroupBox4B.Controls.Add(Label4);
		GroupBox4B.Controls.Add(btCorTextoInterligacao);
		GroupBox4B.Location = new Point(220, 137);
		GroupBox4B.Name = "GroupBox4B";
		GroupBox4B.Size = new Size(199, 98);
		GroupBox4B.TabIndex = 66;
		GroupBox4B.TabStop = false;
		GroupBox4B.Text = "Cruzamento Interno";
		tbEstiloLinhaEscala.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbEstiloLinhaEscala.Location = new Point(152, 69);
		tbEstiloLinhaEscala.Name = "tbEstiloLinhaEscala";
		tbEstiloLinhaEscala.Size = new Size(30, 20);
		tbEstiloLinhaEscala.TabIndex = 55;
		tbEstiloLinhaEscala.TextAlign = HorizontalAlignment.Center;
		Label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label18.Location = new Point(6, 71);
		Label18.Name = "Label18";
		Label18.Size = new Size(35, 23);
		Label18.TabIndex = 45;
		Label18.Text = "Estilo";
		Label18.TextAlign = ContentAlignment.TopRight;
		cbEstilosLinha.FormattingEnabled = true;
		cbEstilosLinha.Location = new Point(44, 69);
		cbEstilosLinha.MaxLength = 50;
		cbEstilosLinha.Name = "cbEstilosLinha";
		cbEstilosLinha.Size = new Size(105, 21);
		cbEstilosLinha.TabIndex = 44;
		GroupBox19.Controls.Add(rbSQLSVR);
		GroupBox19.Controls.Add(rbSQLite);
		GroupBox19.Controls.Add(rbAccess);
		GroupBox19.Location = new Point(6, 105);
		GroupBox19.Name = "GroupBox19";
		GroupBox19.Size = new Size(415, 53);
		GroupBox19.TabIndex = 19;
		GroupBox19.TabStop = false;
		GroupBox19.Text = "Banco de Dados";
		rbSQLSVR.AutoSize = true;
		rbSQLSVR.Location = new Point(277, 24);
		rbSQLSVR.Name = "rbSQLSVR";
		rbSQLSVR.Size = new Size(80, 17);
		rbSQLSVR.TabIndex = 2;
		rbSQLSVR.TabStop = true;
		rbSQLSVR.Text = "SQL Server";
		rbSQLSVR.UseVisualStyleBackColor = true;
		rbSQLite.AutoSize = true;
		rbSQLite.Location = new Point(154, 24);
		rbSQLite.Name = "rbSQLite";
		rbSQLite.Size = new Size(57, 17);
		rbSQLite.TabIndex = 1;
		rbSQLite.TabStop = true;
		rbSQLite.Text = "SQLite";
		rbSQLite.UseVisualStyleBackColor = true;
		rbAccess.AutoSize = true;
		rbAccess.Location = new Point(19, 24);
		rbAccess.Name = "rbAccess";
		rbAccess.Size = new Size(60, 17);
		rbAccess.TabIndex = 0;
		rbAccess.TabStop = true;
		rbAccess.Text = "Access";
		rbAccess.UseVisualStyleBackColor = true;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Controls.Add(TabPage3);
		TabControl1.Location = new Point(12, 12);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(435, 597);
		TabControl1.TabIndex = 67;
		TabPage1.BackColor = SystemColors.Control;
		TabPage1.Controls.Add(GBSql);
		TabPage1.Controls.Add(GroupBox1);
		TabPage1.Controls.Add(GroupBox19);
		TabPage1.Controls.Add(GBAccess);
		TabPage1.Controls.Add(GroupBox3);
		TabPage1.Controls.Add(GroupBox2);
		TabPage1.Location = new Point(4, 22);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(427, 571);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Banco de Dados";
		GBSql.Controls.Add(btConectarSQLServer);
		GBSql.Controls.Add(tbSenha);
		GBSql.Controls.Add(lbPassword);
		GBSql.Controls.Add(lbUserName);
		GBSql.Controls.Add(lbDataBase);
		GBSql.Controls.Add(lbDataSource);
		GBSql.Controls.Add(tbUser);
		GBSql.Controls.Add(tbBancoDeDados);
		GBSql.Controls.Add(tbDataSource);
		GBSql.Location = new Point(6, 251);
		GBSql.Name = "GBSql";
		GBSql.Size = new Size(415, 128);
		GBSql.TabIndex = 43;
		GBSql.TabStop = false;
		GBSql.Text = "SQL Server";
		btConectarSQLServer.BackColor = Color.Transparent;
		btConectarSQLServer.FlatStyle = FlatStyle.Flat;
		btConectarSQLServer.ForeColor = SystemColors.Control;
		btConectarSQLServer.Image = Resources.SQLServer_32;
		btConectarSQLServer.Location = new Point(320, 62);
		btConectarSQLServer.Name = "btConectarSQLServer";
		btConectarSQLServer.Size = new Size(36, 36);
		btConectarSQLServer.TabIndex = 26;
		btConectarSQLServer.UseVisualStyleBackColor = false;
		tbSenha.Location = new Point(116, 97);
		tbSenha.Name = "tbSenha";
		tbSenha.PasswordChar = '*';
		tbSenha.Size = new Size(128, 20);
		tbSenha.TabIndex = 25;
		tbSenha.UseSystemPasswordChar = true;
		lbPassword.AutoSize = true;
		lbPassword.Location = new Point(6, 100);
		lbPassword.Name = "lbPassword";
		lbPassword.Size = new Size(38, 13);
		lbPassword.TabIndex = 23;
		lbPassword.Text = "Senha";
		lbUserName.AutoSize = true;
		lbUserName.Location = new Point(6, 74);
		lbUserName.Name = "lbUserName";
		lbUserName.Size = new Size(86, 13);
		lbUserName.TabIndex = 24;
		lbUserName.Text = "Nome doUsuário";
		lbDataBase.AutoSize = true;
		lbDataBase.Location = new Point(6, 48);
		lbDataBase.Name = "lbDataBase";
		lbDataBase.Size = new Size(87, 13);
		lbDataBase.TabIndex = 23;
		lbDataBase.Text = "Banco de Dados";
		lbDataSource.AutoSize = true;
		lbDataSource.Location = new Point(6, 22);
		lbDataSource.Name = "lbDataSource";
		lbDataSource.Size = new Size(64, 13);
		lbDataSource.TabIndex = 22;
		lbDataSource.Text = "DataSource";
		tbUser.Location = new Point(116, 71);
		tbUser.Name = "tbUser";
		tbUser.Size = new Size(128, 20);
		tbUser.TabIndex = 3;
		tbBancoDeDados.Location = new Point(116, 45);
		tbBancoDeDados.Name = "tbBancoDeDados";
		tbBancoDeDados.Size = new Size(128, 20);
		tbBancoDeDados.TabIndex = 2;
		tbDataSource.Location = new Point(116, 19);
		tbDataSource.Name = "tbDataSource";
		tbDataSource.ScrollBars = ScrollBars.Vertical;
		tbDataSource.Size = new Size(293, 20);
		tbDataSource.TabIndex = 1;
		TabPage2.BackColor = SystemColors.Control;
		TabPage2.Controls.Add(GroupBox9);
		TabPage2.Controls.Add(GroupBox10);
		TabPage2.Controls.Add(GroupBox11);
		TabPage2.Controls.Add(GroupBox14);
		TabPage2.Location = new Point(4, 22);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(427, 571);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Bibliotecas";
		TabPage3.BackColor = SystemColors.Control;
		TabPage3.Controls.Add(GroupBox16);
		TabPage3.Controls.Add(GroupBox4B);
		TabPage3.Controls.Add(GroupBox18);
		TabPage3.Controls.Add(GroupBox4);
		TabPage3.Controls.Add(GroupBox17);
		TabPage3.Controls.Add(GroupBox5);
		TabPage3.Controls.Add(GroupBox6);
		TabPage3.Controls.Add(GroupBox15);
		TabPage3.Controls.Add(GroupBox7);
		TabPage3.Controls.Add(GroupBox12);
		TabPage3.Controls.Add(GroupBox13);
		TabPage3.Location = new Point(4, 22);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(427, 571);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Geral";
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(205, 615);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 68;
		btSalvar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(459, 663);
		Controls.Add(btSalvar);
		Controls.Add(TabControl1);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmConfiguracaoGeral";
		StartPosition = FormStartPosition.CenterParent;
		Text = "Configuração Geral";
		GroupBox9.ResumeLayout(performLayout: false);
		GroupBox9.PerformLayout();
		GBAccess.ResumeLayout(performLayout: false);
		GBAccess.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox10.ResumeLayout(performLayout: false);
		GroupBox10.PerformLayout();
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox5.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox11.ResumeLayout(performLayout: false);
		GroupBox11.PerformLayout();
		GroupBox6.ResumeLayout(performLayout: false);
		GroupBox6.PerformLayout();
		GroupBox7.ResumeLayout(performLayout: false);
		GroupBox7.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox12.ResumeLayout(performLayout: false);
		GroupBox12.PerformLayout();
		GroupBox13.ResumeLayout(performLayout: false);
		GroupBox13.PerformLayout();
		GroupBox14.ResumeLayout(performLayout: false);
		GroupBox14.PerformLayout();
		GroupBox15.ResumeLayout(performLayout: false);
		GroupBox15.PerformLayout();
		GroupBox16.ResumeLayout(performLayout: false);
		GroupBox17.ResumeLayout(performLayout: false);
		GroupBox17.PerformLayout();
		GroupBox18.ResumeLayout(performLayout: false);
		GroupBox18.PerformLayout();
		GroupBox4B.ResumeLayout(performLayout: false);
		GroupBox4B.PerformLayout();
		GroupBox19.ResumeLayout(performLayout: false);
		GroupBox19.PerformLayout();
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		GBSql.ResumeLayout(performLayout: false);
		GBSql.PerformLayout();
		TabPage2.ResumeLayout(performLayout: false);
		TabPage3.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return Wyby9BM05h;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		Wyby9BM05h = WithEventsValue;
	}

	public frmConfiguracaoGeral()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		amNAASpuLi = default;
		g99AsoPXck = new ColorDialog();
		HFdy3lXg4r();
		Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 101]);
		GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 102]);
		GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 500]);
		GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 104]);
		GroupBox4.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 501], " - "), DeclaracoesGeral.mMensagem[1, 559]));
		GroupBox4B.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 501], " - "), DeclaracoesGeral.mMensagem[1, 508]));
		GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 179]);
		GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 502]);
		GroupBox7.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 503]);
		GBAccess.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 507]);
		GroupBox9.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 504]);
		GroupBox10.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 505]);
		GroupBox11.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 506]);
		GroupBox14.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1442]);
		GroupBox13.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 851]);
		GroupBox12.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 852]);
		GroupBox15.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1457]);
		GroupBox16.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1499]);
		GroupBox19.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1924]);
		Label15.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 853]);
		Label12.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 854]);
		Label13.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 853]);
		Label14.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 854]);
		Label9.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 853]);
		Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 854]);
		Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 516]);
		Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 517]);
		Label4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 508]);
		Label5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 509]);
		rbIncluirColuna0.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 180]);
		rbIncluirColuna1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 181]);
		rbIncluirColuna2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 182]);
		rbIncluirColuna3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1508]);
		rbIncluirColuna4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 481]);
		rbIncluirColuna5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1500]);
		rbIncluirColuna6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1501]);
		Label6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 510]);
		Label7.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 511]);
		Label8.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 512]);
		Label16.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 855]);
		Label19.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1937]);
		Label10.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 513]);
		Label11.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
		Label17.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1732]);
		Label18.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 165]);
		GroupBox18.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1741]);
		RBLayInter0.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1742]);
		RBLayInter1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1743]);
		RBLayInter2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1750]);
		RBLayInter3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1878]);
		GroupBox17.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1744]);
		RBBobina0.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1745]);
		RBContato1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1746]);
		RBBobinaContato2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1747]);
		RBBobinaContatoES3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1748]);
		rbAccess.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1925]);
		rbSQLite.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1926]);
		lbDataBase.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1962]);
		lbUserName.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1965]);
		lbPassword.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1966]);
		TabControl1.TabPages[0].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1962]);
		TabControl1.TabPages[1].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1963]);
		TabControl1.TabPages[2].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1964]);
		clsLyneTypes.BuscaLyneTypes(ref ppOsDwAfPf);
		cbEstilosLinha.Text = "";
		LyneTypes.structureEstiloInterligacao[] array = ppOsDwAfPf;
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				LyneTypes.structureEstiloInterligacao structureEstiloInterligacao = array[i];
				if (Operators.CompareString(cbEstilosLinha.Text, "", TextCompare: true) == 0)
				{
					cbEstilosLinha.Text = structureEstiloInterligacao.Linetype;
					tbEstiloLinhaEscala.Text = Conversions.ToString(structureEstiloInterligacao.LinetypeScale);
				}
				cbEstilosLinha.Items.Add(structureEstiloInterligacao.Linetype);
			}
			if (Operators.CompareString(clsTextos.TiraNothing(DeclaracoesGeral.Conf.EstiloLinha), "", TextCompare: true) == 0)
			{
				DeclaracoesGeral.Conf.EstiloLinha = "Continuous";
				DeclaracoesGeral.Conf.EstiloLinhaEscala = 1.0;
			}
			cbEstilosLinha.Text = DeclaracoesGeral.Conf.EstiloLinha;
			tbEstiloLinhaEscala.Text = Conversions.ToString(DeclaracoesGeral.Conf.EstiloLinhaEscala);
			if (Operators.CompareString(DeclaracoesGeral.ConfElet.Idioma, "[PT]", TextCompare: true) != 0)
			{
				if (Operators.CompareString(DeclaracoesGeral.ConfElet.Idioma, "[EN]", TextCompare: true) == 0)
				{
					rbIdioma2.Checked = true;
				}
			}
			else
			{
				rbIdioma1.Checked = true;
			}
			if (DeclaracoesGeral.Conf.Norma != 0)
			{
				if (DeclaracoesGeral.Conf.Norma == 1)
				{
					rbANSI.Checked = true;
				}
			}
			else
			{
				rbIEC.Checked = true;
			}
			if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "A", TextCompare: true) != 0)
			{
				if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "S", TextCompare: true) != 0)
				{
					if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "SV", TextCompare: true) == 0)
					{
						rbSQLSVR.Checked = true;
					}
				}
				else
				{
					rbSQLite.Checked = true;
				}
			}
			else
			{
				rbAccess.Checked = true;
			}
			tbCaderno.Text = DeclaracoesGeral.Conf.Local;
			Color val = Color.FromColorIndex((ColorMethod)194, (short)DeclaracoesGeral.Conf.CorConexao);
			btCorConexao.BackColor = val.ColorValue;
			val = Color.FromColorIndex((ColorMethod)194, (short)DeclaracoesGeral.Conf.CorTextoCircuito);
			btCorTextoCircuito.BackColor = val.ColorValue;
			val = Color.FromColorIndex((ColorMethod)194, (short)DeclaracoesGeral.Conf.CorInterligacao);
			btCorInterligacao.BackColor = val.ColorValue;
			val = Color.FromColorIndex((ColorMethod)194, (short)DeclaracoesGeral.Conf.CorTextoInterligacao);
			btCorTextoInterligacao.BackColor = val.ColorValue;
			cbEstilosLinha.Text = DeclaracoesGeral.Conf.EstiloLinha;
			tbEstiloLinhaEscala.Text = Conversions.ToString(DeclaracoesGeral.Conf.EstiloLinhaEscala);
			amNAASpuLi.CorConexao = DeclaracoesGeral.Conf.CorConexao;
			amNAASpuLi.CorTextoCircuito = DeclaracoesGeral.Conf.CorTextoCircuito;
			amNAASpuLi.CorInterligacao = DeclaracoesGeral.Conf.CorInterligacao;
			amNAASpuLi.CorTextoInterligacao = DeclaracoesGeral.Conf.CorTextoInterligacao;
			if (DeclaracoesGeral.Conf.incluirColuna != 0)
			{
				if (DeclaracoesGeral.Conf.incluirColuna != 1)
				{
					if (DeclaracoesGeral.Conf.incluirColuna != 2)
					{
						if (DeclaracoesGeral.Conf.incluirColuna != 3)
						{
							if (DeclaracoesGeral.Conf.incluirColuna != 4)
							{
								if (DeclaracoesGeral.Conf.incluirColuna != 5)
								{
									if (DeclaracoesGeral.Conf.incluirColuna == 6)
									{
										rbIncluirColuna6.Checked = true;
									}
								}
								else
								{
									rbIncluirColuna5.Checked = true;
								}
							}
							else
							{
								rbIncluirColuna4.Checked = true;
							}
						}
						else
						{
							rbIncluirColuna3.Checked = true;
						}
					}
					else
					{
						rbIncluirColuna2.Checked = true;
					}
				}
				else
				{
					rbIncluirColuna1.Checked = true;
				}
			}
			else
			{
				rbIncluirColuna0.Checked = true;
			}
			tbTerminalIndefinido.Text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			tbSeparadorCaboVeia.Text = DeclaracoesGeral.Conf.SeparadorCaboVeia;
			tbSeparadorCruzamento.Text = DeclaracoesGeral.Conf.SeparadorCruzamento;
			tbSeparadorCarimbo.Text = DeclaracoesGeral.Conf.SeparadorCarimbo;
			tbPrefixoCruzamentoInterno.Text = DeclaracoesGeral.Conf.PrefixoCruzInterno;
			tbSufixoCruzamentoInterno.Text = DeclaracoesGeral.Conf.SufixoCruzInterno;
			tbPrefixoCruzamentoExterno.Text = DeclaracoesGeral.Conf.PrefixoCruzExterno;
			tbSufixoCruzamentoExterno.Text = DeclaracoesGeral.Conf.SufixoCruzExterno;
			tbPrefixoCruzamentoFF.Text = DeclaracoesGeral.Conf.PrefixoCruzFF;
			tbSufixoCruzamentoFF.Text = DeclaracoesGeral.Conf.SufixoCruzFF;
			tbFonteCircuitos.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
			tbFonteCruzamento.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCruzamento);
			tbFonteCabos.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCabos);
			tbSeparadorReguaBorne.Text = DeclaracoesGeral.Conf.SeparadorPainelRegua;
			tbProjeto.Text = DeclaracoesGeral.Conf.DirProjeto;
			tbSimbologiaEletrica.Text = DeclaracoesGeral.Conf.DirSimbologiaEletrica;
			tbSimbologiaTopografico.Text = DeclaracoesGeral.Conf.dirSimbologiaTopografico;
			tbSimbologiaLayout.Text = DeclaracoesGeral.Conf.dirSimbologiaLayout;
			tbSimbologiaRelatorios.Text = DeclaracoesGeral.Conf.dirSimbologiaRelatorios;
			tbDataSource.Text = DeclaracoesGeral.Conf.DataSource;
			tbBancoDeDados.Text = DeclaracoesGeral.Conf.BancoDeDados;
			tbUser.Text = DeclaracoesGeral.Conf.User;
			tbSenha.Text = DeclaracoesGeral.Conf.Senha;
			vtLy1XHoKW();
			SelProj.Image = Resources.Database_32;
			SelDirSimbologiaEletrica.Image = Resources.Folder;
			SelDirSimbologiaTopografico.Image = Resources.Folder;
			selDirSimbologiaLayout.Image = Resources.Folder;
			HxDABOf8PQ = DeclaracoesGeral.Conf.CorConexao;
			yyBAVMdZD9 = DeclaracoesGeral.Conf.CorTextoCircuito;
			zv6AuRqfkM = DeclaracoesGeral.Conf.CorInterligacao;
			giTAZtl5Jx = DeclaracoesGeral.Conf.EstiloLinha;
			s47Ai339S3 = DeclaracoesGeral.Conf.EstiloLinhaEscala;
			I4BAET7wWy = DeclaracoesGeral.Conf.CorTextoInterligacao;
			B75AS37BMQ = DeclaracoesGeral.Conf.incluirColuna;
			rFIA42LRGA = DeclaracoesGeral.Conf.FonteCabos;
			fMNAC3p4wq = DeclaracoesGeral.Conf.FonteCircuito;
			W9rAYJJbUt = DeclaracoesGeral.Conf.FonteCruzamento;
			FlvArBeJw2 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			wcjA9lxGO0 = DeclaracoesGeral.Conf.SeparadorCaboVeia;
			gX8sWkfPAf = DeclaracoesGeral.Conf.SeparadorCruzamento;
			cIasp9aTSt = DeclaracoesGeral.Conf.SeparadorCarimbo;
			DVdsTyaLbW = DeclaracoesGeral.Conf.PrefixoCruzInterno;
			e9XsJ9TO5R = DeclaracoesGeral.Conf.SufixoCruzInterno;
			W1bshep6d8 = DeclaracoesGeral.Conf.PrefixoCruzExterno;
			XDwsokBYdE = DeclaracoesGeral.Conf.SufixoCruzExterno;
			dtpsGFoxJa = DeclaracoesGeral.Conf.PrefixoCruzFF;
			YDqsHewLar = DeclaracoesGeral.Conf.SufixoCruzFF;
			oHusk134TR = DeclaracoesGeral.Conf.DirProjeto;
			oWMAzOOMa6 = DeclaracoesGeral.Conf.SeparadorPainelRegua;
			l0xsvTTL8Z = DeclaracoesGeral.Conf.DataSource;
			BO9s6arZYU = DeclaracoesGeral.Conf.BancoDeDados;
			NuJstYUNpy = DeclaracoesGeral.Conf.User;
			GUCsjZD0Yw = DeclaracoesGeral.Conf.Senha;
			j1qsdseLgF = DeclaracoesGeral.Conf.ModeloBobina;
			HInsfhv1wc = DeclaracoesGeral.Conf.InterligacaoLayout;
			if (DeclaracoesGeral.Conf.ModeloBobina != 0)
			{
				if (DeclaracoesGeral.Conf.ModeloBobina != 1)
				{
					if (DeclaracoesGeral.Conf.ModeloBobina != 2)
					{
						if (DeclaracoesGeral.Conf.ModeloBobina == 3)
						{
							RBBobinaContatoES3.Checked = true;
						}
					}
					else
					{
						RBBobinaContato2.Checked = true;
					}
				}
				else
				{
					RBBobina0.Checked = true;
				}
			}
			else
			{
				RBContato1.Checked = true;
			}
			if (DeclaracoesGeral.Conf.InterligacaoLayout != 0)
			{
				if (DeclaracoesGeral.Conf.InterligacaoLayout != 1)
				{
					if (DeclaracoesGeral.Conf.InterligacaoLayout != 2)
					{
						if (DeclaracoesGeral.Conf.InterligacaoLayout == 3)
						{
							RBLayInter3.Checked = true;
						}
					}
					else
					{
						RBLayInter2.Checked = true;
					}
				}
				else
				{
					RBLayInter1.Checked = true;
				}
			}
			else
			{
				RBLayInter0.Checked = true;
			}
			Application.ShowModalDialog(Application.MainWindow.Handle, (Form)this, false);
		}
	}

	private void GuKynurbxa(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral._uscPagina.Quantidade = 13;
		DeclaracoesGeral._uscPagina.pbIniciar();
		try
		{
			DeclaracoesGeral._uscPagina.pbPasso();
			if (!rbIdioma1.Checked)
			{
				if (rbIdioma2.Checked)
				{
					DeclaracoesGeral.ConfElet.Idioma = "[EN]";
				}
			}
			else
			{
				DeclaracoesGeral.ConfElet.Idioma = "[PT]";
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4", writable: true);
			if (registryKey == null)
			{
				registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4");
			}
			registryKey.SetValue("Idioma", DeclaracoesGeral.ConfElet.Idioma);
			registryKey.Close();
			DeclaracoesGeral.Conf.CorConexao = amNAASpuLi.CorConexao;
			DeclaracoesGeral.Conf.CorTextoCircuito = amNAASpuLi.CorTextoCircuito;
			DeclaracoesGeral.Conf.CorInterligacao = amNAASpuLi.CorInterligacao;
			DeclaracoesGeral.Conf.CorTextoInterligacao = amNAASpuLi.CorTextoInterligacao;
			DeclaracoesGeral.Conf.EstiloLinha = cbEstilosLinha.Text;
			DeclaracoesGeral.Conf.EstiloLinhaEscala = Conversions.ToDouble(tbEstiloLinhaEscala.Text);
			if (!rbAccess.Checked)
			{
				if (!rbSQLite.Checked)
				{
					if (rbSQLSVR.Checked)
					{
						DeclaracoesGeral.Conf.Banco = "SV";
					}
				}
				else
				{
					DeclaracoesGeral.Conf.Banco = "S";
				}
			}
			else
			{
				DeclaracoesGeral.Conf.Banco = "A";
			}
			if (!rbIEC.Checked)
			{
				if (rbANSI.Checked)
				{
					DeclaracoesGeral.Conf.Norma = 1;
				}
			}
			else
			{
				DeclaracoesGeral.Conf.Norma = 0;
			}
			DeclaracoesGeral.Conf.Local = tbCaderno.Text.ToString().Trim();
			DeclaracoesGeral.Conf.DirProjeto = tbProjeto.Text.ToString().Trim();
			DeclaracoesGeral.Conf.DirSimbologiaEletrica = tbSimbologiaEletrica.Text.ToString().Trim();
			DeclaracoesGeral.Conf.dirSimbologiaTopografico = tbSimbologiaTopografico.Text.ToString().Trim();
			DeclaracoesGeral.Conf.dirSimbologiaLayout = tbSimbologiaLayout.Text.ToString().Trim();
			DeclaracoesGeral.Conf.dirSimbologiaRelatorios = tbSimbologiaRelatorios.Text.ToString().Trim();
			DeclaracoesGeral.Conf.DataSource = tbDataSource.Text.Trim();
			DeclaracoesGeral.Conf.BancoDeDados = tbBancoDeDados.Text.Trim();
			DeclaracoesGeral.Conf.User = tbUser.Text.Trim();
			DeclaracoesGeral.Conf.Senha = tbSenha.Text.Trim();
			DeclaracoesGeral.Conf.SeparadorCruzamento = tbSeparadorCruzamento.Text;
			DeclaracoesGeral.Conf.SeparadorCarimbo = tbSeparadorCarimbo.Text;
			DeclaracoesGeral.Conf.PrefixoCruzInterno = tbPrefixoCruzamentoInterno.Text;
			DeclaracoesGeral.Conf.SufixoCruzInterno = tbSufixoCruzamentoInterno.Text;
			DeclaracoesGeral.Conf.PrefixoCruzExterno = tbPrefixoCruzamentoExterno.Text;
			DeclaracoesGeral.Conf.SufixoCruzExterno = tbSufixoCruzamentoExterno.Text;
			DeclaracoesGeral.Conf.PrefixoCruzFF = tbPrefixoCruzamentoFF.Text;
			DeclaracoesGeral.Conf.SufixoCruzFF = tbSufixoCruzamentoFF.Text;
			DeclaracoesGeral.Conf.SeparadorCaboVeia = tbSeparadorCaboVeia.Text;
			DeclaracoesGeral.Conf.CaracterTerminalIndefinido = tbTerminalIndefinido.Text;
			DeclaracoesGeral.Conf.SeparadorPainelRegua = tbSeparadorReguaBorne.Text;
			DeclaracoesGeral.Conf.FonteCabos = Conversions.ToDouble(tbFonteCabos.Text);
			DeclaracoesGeral.Conf.FonteCircuito = Conversions.ToDouble(tbFonteCircuitos.Text);
			DeclaracoesGeral.Conf.FonteCruzamento = Conversions.ToDouble(tbFonteCruzamento.Text);
			if (!rbIncluirColuna0.Checked)
			{
				if (!rbIncluirColuna1.Checked)
				{
					if (!rbIncluirColuna2.Checked)
					{
						if (!rbIncluirColuna3.Checked)
						{
							if (!rbIncluirColuna4.Checked)
							{
								if (!rbIncluirColuna5.Checked)
								{
									if (rbIncluirColuna6.Checked)
									{
										DeclaracoesGeral.Conf.incluirColuna = 6;
									}
								}
								else
								{
									DeclaracoesGeral.Conf.incluirColuna = 5;
								}
							}
							else
							{
								DeclaracoesGeral.Conf.incluirColuna = 4;
							}
						}
						else
						{
							DeclaracoesGeral.Conf.incluirColuna = 3;
						}
					}
					else
					{
						DeclaracoesGeral.Conf.incluirColuna = 2;
					}
				}
				else
				{
					DeclaracoesGeral.Conf.incluirColuna = 1;
				}
			}
			else
			{
				DeclaracoesGeral.Conf.incluirColuna = 0;
			}
			if (!RBBobina0.Checked)
			{
				if (!RBContato1.Checked)
				{
					if (!RBBobinaContato2.Checked)
					{
						if (RBBobinaContatoES3.Checked)
						{
							DeclaracoesGeral.Conf.ModeloBobina = 3;
						}
					}
					else
					{
						DeclaracoesGeral.Conf.ModeloBobina = 2;
					}
				}
				else
				{
					DeclaracoesGeral.Conf.ModeloBobina = 0;
				}
			}
			else
			{
				DeclaracoesGeral.Conf.ModeloBobina = 1;
			}
			if (!RBLayInter0.Checked)
			{
				if (!RBLayInter1.Checked)
				{
					if (!RBLayInter2.Checked)
					{
						if (RBLayInter3.Checked)
						{
							DeclaracoesGeral.Conf.InterligacaoLayout = 3;
						}
					}
					else
					{
						DeclaracoesGeral.Conf.InterligacaoLayout = 2;
					}
				}
				else
				{
					DeclaracoesGeral.Conf.InterligacaoLayout = 1;
				}
			}
			else
			{
				DeclaracoesGeral.Conf.InterligacaoLayout = 0;
			}
			Close();
			DeclaracoesGeral._uscPagina.pbPasso();
			XDataGeral.GravarXDataConfiguracao();
			XDataGeral.GravarXDataConfiguracao2();
			DeclaracoesGeral._uscPagina.pbPasso();
			Mensagem mensagem = new Mensagem();
			mensagem.CarregaMensagens();
			PointMonitorToolTips.StopMonitor();
			DeclaracoesGeral._uscPagina.pbPasso();
			bool flag = false;
			if (!(rbAccess.Checked | rbSQLite.Checked))
			{
				if (rbSQLSVR.Checked)
				{
					if ((Operators.CompareString(BO9s6arZYU, DeclaracoesGeral.Conf.BancoDeDados, TextCompare: true) != 0) & (Operators.CompareString(l0xsvTTL8Z, DeclaracoesGeral.Conf.DataSource, TextCompare: true) != 0))
					{
						flag = true;
					}
					PointMonitorToolTips.StartMonitor();
				}
			}
			else if (Operators.CompareString(DeclaracoesGeral.Conf.DirProjeto, "", TextCompare: true) != 0 && File.Exists(DeclaracoesGeral.Conf.DirProjeto))
			{
				if (Operators.CompareString(oHusk134TR.Trim(), DeclaracoesGeral.Conf.DirProjeto.Trim(), TextCompare: true) != 0)
				{
					flag = true;
				}
				PointMonitorToolTips.StartMonitor();
			}
			if (flag)
			{
				ACorrecaoBD.CorrigeBD();
				cDadosAccess.carregaPainelDicionario();
			}
			DeclaracoesGeral._uscPagina.pbPasso();
			if (Caderno.ExisteFormato())
			{
				if (HxDABOf8PQ != DeclaracoesGeral.Conf.CorConexao)
				{
					clsConexao clsConexao2 = new clsConexao();
					clsConexao2.editarConexoesDerivacoes();
				}
				if ((yyBAVMdZD9 != DeclaracoesGeral.Conf.CorTextoCircuito) | (fMNAC3p4wq != DeclaracoesGeral.Conf.FonteCircuito) | (W9rAYJJbUt != DeclaracoesGeral.Conf.FonteCruzamento) | (B75AS37BMQ != DeclaracoesGeral.Conf.incluirColuna))
				{
					clsConexao clsConexao3 = new clsConexao();
					clsConexao3.AlterarCorTamanhoTextoAuxiliarTipo123();
					clsDePara.SincronizaDePara();
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				if ((B75AS37BMQ != DeclaracoesGeral.Conf.incluirColuna) | (Operators.CompareString(gX8sWkfPAf, DeclaracoesGeral.Conf.SeparadorCruzamento, TextCompare: true) != 0) | (Operators.CompareString(DVdsTyaLbW, DeclaracoesGeral.Conf.PrefixoCruzInterno, TextCompare: true) != 0) | (Operators.CompareString(e9XsJ9TO5R, DeclaracoesGeral.Conf.SufixoCruzInterno, TextCompare: true) != 0) | (Operators.CompareString(W1bshep6d8, DeclaracoesGeral.Conf.PrefixoCruzExterno, TextCompare: true) != 0) | (Operators.CompareString(XDwsokBYdE, DeclaracoesGeral.Conf.SufixoCruzExterno, TextCompare: true) != 0))
				{
					Pagina.restauraCampos();
					clsConexao.sincronizaCircuitos();
					clsInterligacao.SincronizaCruzamentoInterlig();
					clsDePara.SincronizaDePara();
					clsPortas.SincronizaPortas();
					clsDispositivoAuxiliares.SincronizaContatos();
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				if (zv6AuRqfkM != DeclaracoesGeral.Conf.CorInterligacao)
				{
					clsInterligacao.editarCorVeias();
					if (DeclaracoesGeral.Conf.InterligacaoLayout == 1)
					{
						clsEletrosul.AtualizaCorTodasVeiasEletrosulElipseLinha();
					}
				}
				if ((Operators.CompareString(giTAZtl5Jx, DeclaracoesGeral.Conf.EstiloLinha, TextCompare: true) != 0) | (s47Ai339S3 != DeclaracoesGeral.Conf.EstiloLinhaEscala))
				{
					ClsCabos.CriaEstiloDeLinha(ref DeclaracoesGeral.Conf.EstiloLinha, DeclaracoesGeral.Conf.EstiloLinhaEscala);
					clsInterligacao.editarEstiloVeias();
				}
				if ((I4BAET7wWy != DeclaracoesGeral.Conf.CorTextoInterligacao) | (rFIA42LRGA != DeclaracoesGeral.Conf.FonteCabos) | (Operators.CompareString(wcjA9lxGO0, DeclaracoesGeral.Conf.SeparadorCaboVeia, TextCompare: true) != 0))
				{
					clsInterligacao.AlterarCorTamanhoSeparadorTextoAuxiliarVeias();
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				if (Operators.CompareString(FlvArBeJw2, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
				{
					clsPortas.SincronizaPortas();
					clsDispositivoAuxiliares.SincronizaContatos();
				}
				if (j1qsdseLgF != DeclaracoesGeral.Conf.ModeloBobina)
				{
					if (DeclaracoesGeral.Conf.ModeloBobina != 0)
					{
						if (DeclaracoesGeral.Conf.ModeloBobina != 1)
						{
							if (DeclaracoesGeral.Conf.ModeloBobina != 2)
							{
								if (DeclaracoesGeral.Conf.ModeloBobina == 3)
								{
									clsDispositivo.ModeloDoDispositivoPrincipalTipo3();
								}
							}
							else
							{
								clsDispositivo.ModeloDoDispositivoPrincipalTipo2();
							}
						}
						else
						{
							clsDispositivo.ModeloDoDispositivoPrincipalTipo1();
						}
					}
					else
					{
						clsDispositivo.ModeloDoDispositivoPrincipalTipo0();
					}
				}
				if (HInsfhv1wc != DeclaracoesGeral.Conf.InterligacaoLayout)
				{
					if (DeclaracoesGeral.Conf.InterligacaoLayout != 0)
					{
						if (DeclaracoesGeral.Conf.InterligacaoLayout != 1)
						{
							if (DeclaracoesGeral.Conf.InterligacaoLayout != 2)
							{
								if (DeclaracoesGeral.Conf.InterligacaoLayout == 3)
								{
									clsEletron.RecriaTextosCabo(bApaga: true);
								}
							}
							else
							{
								clsEletron.RecriaTextosCabo(bApaga: true);
							}
						}
						else
						{
							clsEletrosul.RecriaTextosCaboEletrosul(bApaga: true);
						}
					}
					else
					{
						clsEletron.RecriaTextosCabo(bApaga: true);
					}
				}
				if (Operators.CompareString(oWMAzOOMa6, DeclaracoesGeral.Conf.SeparadorPainelRegua, TextCompare: true) != 0)
				{
					clsUtilitarios.CorrigePainelET1DosBornes();
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 100]), MsgBoxStyle.Critical, "Elétron");
			ProjectData.ClearProjectError();
		}
		DeclaracoesGeral._uscPagina.pbFim();
	}

	private bool vtLy1XHoKW(bool P_0 = false)
	{
		bool result = true;
		tbSimbologiaEletrica.Text = ya3ylM2Mck(tbSimbologiaEletrica.Text.ToString().Trim());
		tbSimbologiaTopografico.Text = ya3ylM2Mck(tbSimbologiaTopografico.Text.ToString().Trim());
		tbSimbologiaLayout.Text = ya3ylM2Mck(tbSimbologiaLayout.Text.ToString().Trim());
		tbSimbologiaRelatorios.Text = ya3ylM2Mck(tbSimbologiaRelatorios.Text.ToString().Trim());
		tbProjeto.BackColor = Color.White;
		tbSimbologiaEletrica.BackColor = Color.White;
		tbSimbologiaTopografico.BackColor = Color.White;
		tbSimbologiaLayout.BackColor = Color.White;
		tbSimbologiaRelatorios.BackColor = Color.White;
		if ((rbAccess.Checked | rbSQLite.Checked) && Operators.CompareString(tbProjeto.Text, "", TextCompare: true) != 0 && !File.Exists(tbProjeto.Text))
		{
			tbProjeto.BackColor = Color.LightCoral;
			result = false;
		}
		if (P_0)
		{
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		if (Operators.CompareString(tbSimbologiaEletrica.Text, "", TextCompare: true) != 0 && !Directory.Exists(tbSimbologiaEletrica.Text))
		{
			tbSimbologiaEletrica.BackColor = Color.LightCoral;
			result = false;
		}
		if (P_0)
		{
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		if (Operators.CompareString(tbSimbologiaTopografico.Text, "", TextCompare: true) != 0 && !Directory.Exists(tbSimbologiaTopografico.Text))
		{
			tbSimbologiaTopografico.BackColor = Color.LightCoral;
			result = false;
		}
		if (P_0)
		{
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		if (Operators.CompareString(tbSimbologiaLayout.Text, "", TextCompare: true) != 0 && !Directory.Exists(tbSimbologiaLayout.Text))
		{
			tbSimbologiaLayout.BackColor = Color.LightCoral;
			result = false;
		}
		if (P_0)
		{
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		if (Operators.CompareString(tbSimbologiaRelatorios.Text, "", TextCompare: true) != 0 && !Directory.Exists(tbSimbologiaRelatorios.Text))
		{
			tbSimbologiaRelatorios.BackColor = Color.LightCoral;
			result = false;
		}
		return result;
	}

	private string ya3ylM2Mck(string P_0)
	{
		string result = P_0;
		if (Operators.CompareString(P_0, "", TextCompare: true) != 0 && Operators.CompareString(Strings.Mid(P_0, P_0.Length, 1), "\\", TextCompare: true) != 0)
		{
			result = P_0 + "\\";
		}
		return result;
	}

	private void t86y5UlFWX(object P_0, EventArgs P_1)
	{
		amNAASpuLi.CorConexao = 7;
		checked
		{
			Color val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorConexao);
			btCorConexao.BackColor = val.ColorValue;
			amNAASpuLi.CorTextoCircuito = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorTextoCircuito);
			btCorTextoCircuito.BackColor = val.ColorValue;
			amNAASpuLi.CorInterligacao = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorInterligacao);
			btCorInterligacao.BackColor = val.ColorValue;
			amNAASpuLi.CorTextoInterligacao = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorTextoInterligacao);
			btCorTextoInterligacao.BackColor = val.ColorValue;
			cbEstilosLinha.Text = DeclaracoesGeral.Conf.EstiloLinha;
			tbEstiloLinhaEscala.Text = Conversions.ToString(DeclaracoesGeral.Conf.EstiloLinhaEscala);
			tbTerminalIndefinido.Text = "?";
			tbSeparadorCaboVeia.Text = "/";
			tbSeparadorCruzamento.Text = "/";
			tbSeparadorReguaBorne.Text = "/";
			tbSeparadorCarimbo.Text = "-";
			tbPrefixoCruzamentoInterno.Text = "(";
			tbSufixoCruzamentoInterno.Text = ")";
			tbPrefixoCruzamentoFF.Text = "(";
			tbSufixoCruzamentoFF.Text = ")";
			tbFonteCircuitos.Text = Conversions.ToString(1.8);
			tbFonteCabos.Text = Conversions.ToString(1.8);
			rbIEC.Checked = true;
			rbIncluirColuna0.Checked = true;
			RBLayInter0.Checked = true;
			RBContato1.Checked = true;
		}
	}

	private void QD0y0V9eIp(object P_0, EventArgs P_1)
	{
		amNAASpuLi.CorConexao = 7;
		checked
		{
			Color val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorConexao);
			btCorConexao.BackColor = val.ColorValue;
			amNAASpuLi.CorTextoCircuito = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorTextoCircuito);
			btCorTextoCircuito.BackColor = val.ColorValue;
			amNAASpuLi.CorInterligacao = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorInterligacao);
			btCorInterligacao.BackColor = val.ColorValue;
			amNAASpuLi.CorTextoInterligacao = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorTextoInterligacao);
			btCorTextoInterligacao.BackColor = val.ColorValue;
			cbEstilosLinha.Text = DeclaracoesGeral.Conf.EstiloLinha;
			tbEstiloLinhaEscala.Text = Conversions.ToString(DeclaracoesGeral.Conf.EstiloLinhaEscala);
			tbTerminalIndefinido.Text = "?";
			tbSeparadorCaboVeia.Text = "-";
			tbSeparadorCruzamento.Text = "/";
			tbSeparadorCarimbo.Text = "/";
			tbSeparadorReguaBorne.Text = "/";
			tbPrefixoCruzamentoInterno.Text = "(";
			tbSufixoCruzamentoInterno.Text = ")";
			tbPrefixoCruzamentoFF.Text = "(";
			tbSufixoCruzamentoFF.Text = ")";
			tbFonteCircuitos.Text = Conversions.ToString(1.8);
			tbFonteCabos.Text = Conversions.ToString(1.8);
			rbIEC.Checked = true;
			rbIncluirColuna0.Checked = true;
			RBLayInter1.Checked = true;
			RBBobinaContatoES3.Checked = true;
		}
	}

	private void zYIyRqNngg(object P_0, EventArgs P_1)
	{
		amNAASpuLi.CorConexao = 7;
		checked
		{
			Color val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorConexao);
			btCorConexao.BackColor = val.ColorValue;
			amNAASpuLi.CorTextoCircuito = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorTextoCircuito);
			btCorTextoCircuito.BackColor = val.ColorValue;
			amNAASpuLi.CorInterligacao = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorInterligacao);
			btCorInterligacao.BackColor = val.ColorValue;
			amNAASpuLi.CorTextoInterligacao = 7;
			val = Color.FromColorIndex((ColorMethod)194, (short)amNAASpuLi.CorTextoInterligacao);
			btCorTextoInterligacao.BackColor = val.ColorValue;
			cbEstilosLinha.Text = DeclaracoesGeral.Conf.EstiloLinha;
			tbEstiloLinhaEscala.Text = Conversions.ToString(DeclaracoesGeral.Conf.EstiloLinhaEscala);
			tbTerminalIndefinido.Text = "?";
			tbSeparadorCaboVeia.Text = "/";
			tbSeparadorCruzamento.Text = "/";
			tbSeparadorReguaBorne.Text = "/";
			tbSeparadorCarimbo.Text = "-";
			tbPrefixoCruzamentoInterno.Text = "(";
			tbSufixoCruzamentoInterno.Text = ")";
			tbPrefixoCruzamentoFF.Text = "(";
			tbSufixoCruzamentoFF.Text = ")";
			tbFonteCircuitos.Text = Conversions.ToString(1.5);
			tbFonteCabos.Text = Conversions.ToString(1.5);
			rbANSI.Checked = true;
			rbIncluirColuna2.Checked = true;
			RBLayInter2.Checked = true;
			RBBobina0.Checked = true;
		}
	}

	private void q3bymcEYak(object P_0, EventArgs P_1)
	{
		try
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 237]);
			if (!rbAccess.Checked)
			{
				if (rbSQLite.Checked)
				{
					openFileDialog.Filter = "SQLite (*.db)|*.db";
					openFileDialog.DefaultExt = ".db";
				}
			}
			else
			{
				openFileDialog.Filter = "Access (*.accdb; *.mdb)|*.accdb;*.mdb";
				openFileDialog.DefaultExt = ".accdb";
			}
			openFileDialog.FileName = "";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ValidateNames = true;
			if (openFileDialog.ShowDialog().Value)
			{
				tbProjeto.Text = openFileDialog.FileName;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Elétron");
			ProjectData.ClearProjectError();
		}
		finally
		{
			vtLy1XHoKW();
		}
	}

	private void DZSyXvJNw5(object P_0, EventArgs P_1)
	{
		I8spBuIa499().Description = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 235]);
		I8spBuIa499().RootFolder = Environment.SpecialFolder.MyComputer;
		I8spBuIa499().ShowNewFolderButton = false;
		if (I8spBuIa499().ShowDialog() == DialogResult.OK)
		{
			tbSimbologiaEletrica.Text = I8spBuIa499().SelectedPath + "\\";
		}
		vtLy1XHoKW();
	}

	private void SB4yUhCSbn(object P_0, EventArgs P_1)
	{
		I8spBuIa499().Description = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 236]);
		I8spBuIa499().RootFolder = Environment.SpecialFolder.MyComputer;
		I8spBuIa499().ShowNewFolderButton = false;
		if (I8spBuIa499().ShowDialog() == DialogResult.OK)
		{
			tbSimbologiaTopografico.Text = I8spBuIa499().SelectedPath + "\\";
		}
		vtLy1XHoKW();
	}

	private void YifyyJIEOo(object P_0, EventArgs P_1)
	{
		I8spBuIa499().Description = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 515]);
		I8spBuIa499().RootFolder = Environment.SpecialFolder.MyComputer;
		I8spBuIa499().ShowNewFolderButton = false;
		if (I8spBuIa499().ShowDialog() == DialogResult.OK)
		{
			tbSimbologiaLayout.Text = I8spBuIa499().SelectedPath + "\\";
		}
		vtLy1XHoKW();
	}

	private void jlyygCXVXI(object P_0, EventArgs P_1)
	{
		I8spBuIa499().Description = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1443]);
		I8spBuIa499().RootFolder = Environment.SpecialFolder.MyComputer;
		I8spBuIa499().ShowNewFolderButton = false;
		if (I8spBuIa499().ShowDialog() == DialogResult.OK)
		{
			tbSimbologiaRelatorios.Text = I8spBuIa499().SelectedPath + "\\";
		}
		vtLy1XHoKW();
	}

	private void SKZyA37jpe(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = g99AsoPXck.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			amNAASpuLi.CorConexao = g99AsoPXck.Color.ColorIndex;
			btCorConexao.BackColor = g99AsoPXck.Color.ColorValue;
		}
	}

	private void lSLysFWfWo(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = g99AsoPXck.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			amNAASpuLi.CorTextoCircuito = g99AsoPXck.Color.ColorIndex;
			btCorTextoCircuito.BackColor = g99AsoPXck.Color.ColorValue;
		}
	}

	private void XXQyBV2sY7(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = g99AsoPXck.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			amNAASpuLi.CorInterligacao = g99AsoPXck.Color.ColorIndex;
			btCorInterligacao.BackColor = g99AsoPXck.Color.ColorValue;
		}
	}

	private void OL7yVSLk87(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = g99AsoPXck.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			amNAASpuLi.CorTextoInterligacao = g99AsoPXck.Color.ColorIndex;
			btCorTextoInterligacao.BackColor = g99AsoPXck.Color.ColorValue;
		}
	}

	private void CQvyuqIU3r(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void R9uyEZRasr(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void tD6yZygnhx(object P_0, EventArgs P_1)
	{
		int num = Information.UBound(ppOsDwAfPf);
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (Operators.CompareString(ppOsDwAfPf[num2].Linetype, cbEstilosLinha.Text, TextCompare: true) == 0)
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return;
		}
		tbEstiloLinhaEscala.Text = Conversions.ToString(ppOsDwAfPf[num2].LinetypeScale);
	}

	private void MS8yirH2QO(object P_0, EventArgs P_1)
	{
		f9JyCMMBWM();
	}

	private void rSfySAjauK(object P_0, EventArgs P_1)
	{
		f9JyCMMBWM();
	}

	private void sGoy4Xx4Wm(object P_0, EventArgs P_1)
	{
		f9JyCMMBWM();
	}

	private void f9JyCMMBWM()
	{
		if (!rbSQLSVR.Checked)
		{
			if (rbSQLite.Checked | rbAccess.Checked)
			{
				tbProjeto.Enabled = true;
				GBSql.Location = new Point(6, 251);
				GBAccess.Visible = true;
				GBSql.Visible = false;
			}
		}
		else
		{
			tbProjeto.Text = "";
			tbProjeto.Enabled = false;
			GBSql.Location = new Point(6, 164);
			GBAccess.Visible = false;
			GBSql.Visible = true;
		}
	}

	private void jB1yY6W3uu(object P_0, EventArgs P_1)
	{
		try
		{
			DeclaracoesGeral.Conf.DataSource = tbDataSource.Text.Trim();
			DeclaracoesGeral.Conf.BancoDeDados = tbBancoDeDados.Text.Trim();
			DeclaracoesGeral.Conf.User = tbUser.Text.Trim();
			DeclaracoesGeral.Conf.Senha = tbSenha.Text.Trim();
			cDadosSQLServer cDadosSQLServer2 = new cDadosSQLServer();
			if (!cDadosSQLServer2.testaConexao())
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1968]), MsgBoxStyle.Critical, "Elétron");
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1967]), MsgBoxStyle.Information, "Elétron");
			}
			cDadosSQLServer2.fechaConexao();
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
