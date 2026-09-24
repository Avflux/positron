using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

[DesignerGenerated]
public class frmImportarInterligExcel : Form
{
	public struct structureImpCabos
	{
		public string sDe;

		public string sPara;

		public string sCabo;

		public string sVeias;

		public string sSecao;

		public string sFuncao;

		public bool bBlindado;

		public int iAterrar;

		public double dComprimento;

		public string sTajeto;
	}

	private IContainer YLcdpG82h9;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip YBVdTxCPE5;

	[AccessedThroughProperty("btColar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button uLFdJWDy4Q;

	[AccessedThroughProperty("DgErros")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView cl4dh4FDHk;

	[AccessedThroughProperty("tbDistancia")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox Ba7doUi9aq;

	[AccessedThroughProperty("LBDistancia")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label eTNdGJ8Dle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btOrdenarAZ")]
	private Button Tc5dHqJm7n;

	[AccessedThroughProperty("btInsereBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button iXjdkZIb3A;

	[AccessedThroughProperty("btInsereVeias")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button UNmddyCGEt;

	[AccessedThroughProperty("btInsereJumpers")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button CcLdf5998b;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private GroupBox CoqdDa9sgd;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox r5qdvoF0jy;

	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox Mkyd6BkNZF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckRegua")]
	private RadioButton TWmdtbsQW4;

	[CompilerGenerated]
	[AccessedThroughProperty("CKPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton lFSdjupuSG;

	[CompilerGenerated]
	[AccessedThroughProperty("BTExportaEXCEL")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button p8BdLTr0PA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Ponto1")]
	private Button sctdwnyGQx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Ponto2")]
	private Button j43dxHFRBm;

	[AccessedThroughProperty("btApagarImportado")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button EgmdbPNROp;

	[AccessedThroughProperty("dgReguas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView J2NdMvfsWd;

	[AccessedThroughProperty("btRemove")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button veudOvyYFG;

	[AccessedThroughProperty("lbReservaPossivel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label ChbdI1EyVD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdiciona")]
	private Button xAAd7VQUUT;

	[AccessedThroughProperty("LbReguas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label KNqdq19Z70;

	private ClsBornesInterligCpfl.StructureBornesCPFL[] bNXda7tOpL;

	private ClsBornesInterligCpfl.StructureInterligCFEL[] dIXd8Bb0qu;

	private ClsBornesInterligCpfl.StructureInterligCFEL[] y3YdNenDbb;

	private ClsBornesInterligCpfl.StructureJUMPERCFEL[] lWFdF8fcFM;

	private ClsBornesInterligCpfl.StructureCadastroCabos[] MRhdQAkPrV;

	private DataGridViewCellStyle W5UdPD77fx;

	private List<string> BfcdcPQJdm;

	private int znldK10gKg;

	public structureImpCabos[] mCabosImp;

	private double AnMdex3ejB;

	internal virtual Button btColar
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

	internal virtual DataGridView DgErros
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

	internal virtual TextBox tbDistancia
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

	internal virtual Label LBDistancia
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

	internal virtual Button btInsereBornes
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

	internal virtual Button btInsereVeias
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

	internal virtual Button btInsereJumpers
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

	internal virtual RadioButton ckRegua
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

	internal virtual RadioButton CKPainel
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

	internal virtual Button Ponto1
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

	internal virtual Button Ponto2
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

	internal virtual Button btApagarImportado
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

	internal virtual Button btRemove
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

	internal virtual Label lbReservaPossivel
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

	internal virtual Button btAdiciona
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

	internal virtual Label LbReguas
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
	private void fPPknNO6fP()
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
	public frmImportarInterligExcel()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void IniciaForme()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sl7k1uF90d(ref DataGridView P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool adicionaUmBorne(ref clsBornes.StructureBlocoBorne myBorne, bool bTodosNomesVisiveis, bool bPainel, bool bRegua, ref double dDeslocamento, ref Point3d Point, string sHorientacao, bool bDeslocamento, Point3d Point2 = default(Point3d))
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MlBklxfQjP(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pv6k5AfkMj(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qefk0ftUf3()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool wC4kR6WMOG()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qFjkmD80uk()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TWtkXxyFQN()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VghkUtfnlC()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int qNQkyvX9DZ(string P_0, int P_1)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NhmkgKrO6M(object P_0, DataGridViewCellEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RaVkAYNd7H()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XoHksOT0tt()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CZ1kBQOPJT(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ga8kVg6848(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qgZkuxjIh7(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Lj4kEk3nPI(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HVxkZ0SVj0(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FRJkiy7AZ8(ref DataGridView P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lCJkSws37d(ref DataGridView P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hmIk4goYh0()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int VXUkCcURNK(string P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fevkYqSDfQ(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void B6Fkr4YObe(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EC0k9upyR9(DataGridView P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aGekzH1ypY(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void g6odWToXyq(object P_0, MouseEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static frmImportarInterligExcel()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
