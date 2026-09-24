using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

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
		[CompilerGenerated]
		get
		{
			return uLFdJWDy4Q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MlBklxfQjP;
			Button button = uLFdJWDy4Q;
			if (button != null)
			{
				button.Click -= value2;
			}
			uLFdJWDy4Q = value;
			button = uLFdJWDy4Q;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView DgErros
	{
		[CompilerGenerated]
		get
		{
			return cl4dh4FDHk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = NhmkgKrO6M;
			MouseEventHandler value3 = g6odWToXyq;
			DataGridView dataGridView = cl4dh4FDHk;
			if (dataGridView != null)
			{
				dataGridView.CellContentClick -= value2;
				dataGridView.MouseClick -= value3;
			}
			cl4dh4FDHk = value;
			dataGridView = cl4dh4FDHk;
			if (dataGridView != null)
			{
				dataGridView.CellContentClick += value2;
				dataGridView.MouseClick += value3;
			}
		}
	}

	internal virtual TextBox tbDistancia
	{
		[CompilerGenerated]
		get
		{
			return Ba7doUi9aq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ba7doUi9aq = value;
		}
	}

	internal virtual Label LBDistancia
	{
		[CompilerGenerated]
		get
		{
			return eTNdGJ8Dle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eTNdGJ8Dle = value;
		}
	}

	internal virtual Button btOrdenarAZ
	{
		[CompilerGenerated]
		get
		{
			return Tc5dHqJm7n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pv6k5AfkMj;
			Button button = Tc5dHqJm7n;
			if (button != null)
			{
				button.Click -= value2;
			}
			Tc5dHqJm7n = value;
			button = Tc5dHqJm7n;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btInsereBornes
	{
		[CompilerGenerated]
		get
		{
			return iXjdkZIb3A;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CZ1kBQOPJT;
			Button button = iXjdkZIb3A;
			if (button != null)
			{
				button.Click -= value2;
			}
			iXjdkZIb3A = value;
			button = iXjdkZIb3A;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btInsereVeias
	{
		[CompilerGenerated]
		get
		{
			return UNmddyCGEt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ga8kVg6848;
			Button button = UNmddyCGEt;
			if (button != null)
			{
				button.Click -= value2;
			}
			UNmddyCGEt = value;
			button = UNmddyCGEt;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btInsereJumpers
	{
		[CompilerGenerated]
		get
		{
			return CcLdf5998b;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qgZkuxjIh7;
			Button button = CcLdf5998b;
			if (button != null)
			{
				button.Click -= value2;
			}
			CcLdf5998b = value;
			button = CcLdf5998b;
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
			return CoqdDa9sgd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CoqdDa9sgd = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return r5qdvoF0jy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			r5qdvoF0jy = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return Mkyd6BkNZF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Mkyd6BkNZF = value;
		}
	}

	internal virtual RadioButton ckRegua
	{
		[CompilerGenerated]
		get
		{
			return TWmdtbsQW4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TWmdtbsQW4 = value;
		}
	}

	internal virtual RadioButton CKPainel
	{
		[CompilerGenerated]
		get
		{
			return lFSdjupuSG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lFSdjupuSG = value;
		}
	}

	internal virtual Button BTExportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return p8BdLTr0PA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Lj4kEk3nPI;
			Button button = p8BdLTr0PA;
			if (button != null)
			{
				button.Click -= value2;
			}
			p8BdLTr0PA = value;
			button = p8BdLTr0PA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Ponto1
	{
		[CompilerGenerated]
		get
		{
			return sctdwnyGQx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sctdwnyGQx = value;
		}
	}

	internal virtual Button Ponto2
	{
		[CompilerGenerated]
		get
		{
			return j43dxHFRBm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			j43dxHFRBm = value;
		}
	}

	internal virtual Button btApagarImportado
	{
		[CompilerGenerated]
		get
		{
			return EgmdbPNROp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HVxkZ0SVj0;
			Button button = EgmdbPNROp;
			if (button != null)
			{
				button.Click -= value2;
			}
			EgmdbPNROp = value;
			button = EgmdbPNROp;
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
			return J2NdMvfsWd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			J2NdMvfsWd = value;
		}
	}

	internal virtual Button btRemove
	{
		[CompilerGenerated]
		get
		{
			return veudOvyYFG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = B6Fkr4YObe;
			Button button = veudOvyYFG;
			if (button != null)
			{
				button.Click -= value2;
			}
			veudOvyYFG = value;
			button = veudOvyYFG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbReservaPossivel
	{
		[CompilerGenerated]
		get
		{
			return ChbdI1EyVD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ChbdI1EyVD = value;
		}
	}

	internal virtual Button btAdiciona
	{
		[CompilerGenerated]
		get
		{
			return xAAd7VQUUT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fevkYqSDfQ;
			Button button = xAAd7VQUUT;
			if (button != null)
			{
				button.Click -= value2;
			}
			xAAd7VQUUT = value;
			button = xAAd7VQUUT;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LbReguas
	{
		[CompilerGenerated]
		get
		{
			return KNqdq19Z70;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KNqdq19Z70 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && YLcdpG82h9 != null)
			{
				YLcdpG82h9.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void fPPknNO6fP()
	{
		YLcdpG82h9 = new Container();
		FDqpBiUmZij(new ToolTip(YLcdpG82h9));
		btColar = new Button();
		DgErros = new DataGridView();
		tbDistancia = new TextBox();
		LBDistancia = new Label();
		btOrdenarAZ = new Button();
		btInsereBornes = new Button();
		btInsereVeias = new Button();
		btInsereJumpers = new Button();
		GroupBox1 = new GroupBox();
		BTExportaEXCEL = new Button();
		GroupBox2 = new GroupBox();
		ckRegua = new RadioButton();
		CKPainel = new RadioButton();
		GroupBox3 = new GroupBox();
		Ponto1 = new Button();
		Ponto2 = new Button();
		btApagarImportado = new Button();
		dgReguas = new DataGridView();
		btAdiciona = new Button();
		btRemove = new Button();
		lbReservaPossivel = new Label();
		LbReguas = new Label();
		((ISupportInitialize)DgErros).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		((ISupportInitialize)dgReguas).BeginInit();
		SuspendLayout();
		btColar.FlatStyle = FlatStyle.Flat;
		btColar.ForeColor = SystemColors.Control;
		btColar.Image = Resources.Paste_32;
		btColar.Location = new Point(104, 16);
		btColar.Name = "btColar";
		btColar.Size = new Size(42, 42);
		btColar.TabIndex = 196;
		btColar.UseVisualStyleBackColor = true;
		DgErros.AllowDrop = true;
		DgErros.AllowUserToAddRows = false;
		DgErros.AllowUserToDeleteRows = false;
		DgErros.AllowUserToResizeRows = false;
		DgErros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DgErros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DgErros.Location = new Point(371, 12);
		DgErros.MultiSelect = false;
		DgErros.Name = "DgErros";
		DgErros.RowHeadersVisible = false;
		DgErros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DgErros.Size = new Size(903, 454);
		DgErros.TabIndex = 201;
		tbDistancia.Location = new Point(273, 31);
		tbDistancia.Name = "tbDistancia";
		tbDistancia.Size = new Size(54, 20);
		tbDistancia.TabIndex = 202;
		LBDistancia.Location = new Point(270, 11);
		LBDistancia.Name = "LBDistancia";
		LBDistancia.Size = new Size(64, 17);
		LBDistancia.TabIndex = 203;
		LBDistancia.Text = "LBDistância";
		LBDistancia.TextAlign = ContentAlignment.BottomLeft;
		btOrdenarAZ.FlatStyle = FlatStyle.Flat;
		btOrdenarAZ.ForeColor = SystemColors.Control;
		btOrdenarAZ.Image = Resources.Ordem_32;
		btOrdenarAZ.Location = new Point(200, 16);
		btOrdenarAZ.Name = "btOrdenarAZ";
		btOrdenarAZ.Size = new Size(42, 42);
		btOrdenarAZ.TabIndex = 209;
		btOrdenarAZ.UseVisualStyleBackColor = true;
		btInsereBornes.FlatStyle = FlatStyle.Flat;
		btInsereBornes.ForeColor = SystemColors.Control;
		btInsereBornes.Image = Resources.Bornes_32;
		btInsereBornes.Location = new Point(37, 13);
		btInsereBornes.Name = "btInsereBornes";
		btInsereBornes.Size = new Size(32, 32);
		btInsereBornes.TabIndex = 210;
		btInsereBornes.UseVisualStyleBackColor = true;
		btInsereVeias.FlatStyle = FlatStyle.Flat;
		btInsereVeias.ForeColor = SystemColors.Control;
		btInsereVeias.Image = Resources.ConexaoTT_32;
		btInsereVeias.Location = new Point(144, 13);
		btInsereVeias.Name = "btInsereVeias";
		btInsereVeias.Size = new Size(32, 32);
		btInsereVeias.TabIndex = 211;
		btInsereVeias.UseVisualStyleBackColor = true;
		btInsereJumpers.FlatStyle = FlatStyle.Flat;
		btInsereJumpers.ForeColor = SystemColors.Control;
		btInsereJumpers.Image = Resources.JumperExt_32;
		btInsereJumpers.Location = new Point(251, 13);
		btInsereJumpers.Name = "btInsereJumpers";
		btInsereJumpers.Size = new Size(32, 32);
		btInsereJumpers.TabIndex = 212;
		btInsereJumpers.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(BTExportaEXCEL);
		GroupBox1.Controls.Add(btColar);
		GroupBox1.Controls.Add(btOrdenarAZ);
		GroupBox1.Location = new Point(5, 5);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(248, 70);
		GroupBox1.TabIndex = 213;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "gbColar";
		BTExportaEXCEL.FlatStyle = FlatStyle.Flat;
		BTExportaEXCEL.ForeColor = SystemColors.Control;
		BTExportaEXCEL.Image = Resources.ModeloExcel_32;
		BTExportaEXCEL.Location = new Point(9, 16);
		BTExportaEXCEL.Name = "BTExportaEXCEL";
		BTExportaEXCEL.Size = new Size(42, 42);
		BTExportaEXCEL.TabIndex = 217;
		BTExportaEXCEL.UseVisualStyleBackColor = true;
		GroupBox2.Controls.Add(ckRegua);
		GroupBox2.Controls.Add(CKPainel);
		GroupBox2.Controls.Add(LBDistancia);
		GroupBox2.Controls.Add(tbDistancia);
		GroupBox2.Location = new Point(5, 78);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(347, 65);
		GroupBox2.TabIndex = 214;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "gbVisualizar";
		ckRegua.AutoSize = true;
		ckRegua.Location = new Point(179, 32);
		ckRegua.Name = "ckRegua";
		ckRegua.Size = new Size(69, 17);
		ckRegua.TabIndex = 217;
		ckRegua.TabStop = true;
		ckRegua.Text = "ckRegua";
		ckRegua.UseVisualStyleBackColor = true;
		CKPainel.AutoSize = true;
		CKPainel.Location = new Point(6, 32);
		CKPainel.Name = "CKPainel";
		CKPainel.Size = new Size(101, 17);
		CKPainel.TabIndex = 216;
		CKPainel.TabStop = true;
		CKPainel.Text = "ckPainel-Regua";
		CKPainel.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(btInsereBornes);
		GroupBox3.Controls.Add(btInsereVeias);
		GroupBox3.Controls.Add(btInsereJumpers);
		GroupBox3.Location = new Point(5, 414);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(345, 52);
		GroupBox3.TabIndex = 215;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "gbInserir";
		Ponto1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Ponto1.Location = new Point(374, 456);
		Ponto1.Name = "Ponto1";
		Ponto1.Size = new Size(14, 8);
		Ponto1.TabIndex = 216;
		Ponto1.Text = "Button1";
		Ponto1.UseVisualStyleBackColor = true;
		Ponto2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Ponto2.Location = new Point(1250, 456);
		Ponto2.Name = "Ponto2";
		Ponto2.Size = new Size(14, 8);
		Ponto2.TabIndex = 217;
		Ponto2.Text = "Button2";
		Ponto2.UseVisualStyleBackColor = true;
		btApagarImportado.FlatStyle = FlatStyle.Flat;
		btApagarImportado.ForeColor = SystemColors.Control;
		btApagarImportado.Image = Resources.Delete_32;
		btApagarImportado.Location = new Point(289, 21);
		btApagarImportado.Name = "btApagarImportado";
		btApagarImportado.Size = new Size(42, 42);
		btApagarImportado.TabIndex = 220;
		btApagarImportado.UseVisualStyleBackColor = true;
		dgReguas.AllowDrop = true;
		dgReguas.AllowUserToAddRows = false;
		dgReguas.AllowUserToDeleteRows = false;
		dgReguas.AllowUserToResizeRows = false;
		dgReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgReguas.BackgroundColor = Color.White;
		dgReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguas.Location = new Point(5, 173);
		dgReguas.MultiSelect = false;
		dgReguas.Name = "dgReguas";
		dgReguas.RowHeadersVisible = false;
		dgReguas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguas.Size = new Size(345, 196);
		dgReguas.TabIndex = 221;
		btAdiciona.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAdiciona.Image = Resources.Verifica_Duplo_32;
		btAdiciona.ImageAlign = ContentAlignment.TopRight;
		btAdiciona.Location = new Point(297, 373);
		btAdiciona.Name = "btAdiciona";
		btAdiciona.Size = new Size(25, 25);
		btAdiciona.TabIndex = 223;
		btAdiciona.UseVisualStyleBackColor = true;
		btRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btRemove.Image = Resources.Apagar;
		btRemove.ImageAlign = ContentAlignment.BottomRight;
		btRemove.Location = new Point(325, 374);
		btRemove.Name = "btRemove";
		btRemove.Size = new Size(25, 25);
		btRemove.TabIndex = 222;
		btRemove.UseVisualStyleBackColor = true;
		lbReservaPossivel.Location = new Point(5, 149);
		lbReservaPossivel.Name = "lbReservaPossivel";
		lbReservaPossivel.Size = new Size(137, 17);
		lbReservaPossivel.TabIndex = 225;
		lbReservaPossivel.Text = "LBDistância";
		lbReservaPossivel.TextAlign = ContentAlignment.BottomLeft;
		LbReguas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbReguas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LbReguas.Location = new Point(48, 372);
		LbReguas.Name = "LbReguas";
		LbReguas.Size = new Size(227, 29);
		LbReguas.TabIndex = 226;
		LbReguas.Text = "btReguas Os Bornes Reservas serão adicionadas nas Réguas marcadas com R";
		LbReguas.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1284, 474);
		Controls.Add(lbReservaPossivel);
		Controls.Add(dgReguas);
		Controls.Add(btAdiciona);
		Controls.Add(btRemove);
		Controls.Add(btApagarImportado);
		Controls.Add(Ponto2);
		Controls.Add(Ponto1);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(DgErros);
		Controls.Add(LbReguas);
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmImportarInterligExcel";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Importar Interligação Excel";
		((ISupportInitialize)DgErros).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgReguas).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return YBVdTxCPE5;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		YBVdTxCPE5 = WithEventsValue;
	}

	public frmImportarInterligExcel()
	{
		Resize += aGekzH1ypY;
		W5UdPD77fx = new DataGridViewCellStyle();
		BfcdcPQJdm = new List<string>();
		znldK10gKg = 0;
		try
		{
			if (Geral.ExisteForm("frmImportarInterligExcel") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				fPPknNO6fP();
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				IniciaForme();
				BfcdcPQJdm.Clear();
				clsBornesInterligAuto.capturaBornesDoDesenho(ref BfcdcPQJdm);
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void IniciaForme()
	{
		Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1507]);
		w8dpBZ0kvSD().SetToolTip(btColar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 46]));
		GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 46]);
		GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 648]);
		CKPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 626], "+"), DeclaracoesGeral.mMensagem[1, 924]));
		ckRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]);
		LBDistancia.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 798]);
		GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 35]);
		w8dpBZ0kvSD().SetToolTip(btInsereBornes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1574]));
		w8dpBZ0kvSD().SetToolTip(btInsereVeias, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 564]));
		w8dpBZ0kvSD().SetToolTip(btInsereJumpers, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1571]));
		w8dpBZ0kvSD().SetToolTip(BTExportaEXCEL, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1552]));
		w8dpBZ0kvSD().SetToolTip(btApagarImportado, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1539]));
		w8dpBZ0kvSD().SetToolTip(btAdiciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1735]));
		w8dpBZ0kvSD().SetToolTip(btRemove, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1736]));
		lbReservaPossivel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]);
		LbReguas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1737]);
		tbDistancia.Text = "60";
		Ponto1.Visible = false;
		Ponto2.Visible = false;
		Application.ShowModelessDialog((Form)this);
		XoHksOT0tt();
		W5UdPD77fx.BackColor = Color.LightCoral;
		CKPainel.Checked = true;
		ckRegua.Checked = true;
		checked
		{
			mCabosImp = new structureImpCabos[znldK10gKg + 1];
			double num = Ponto1.Location.Y;
			double a = Ponto1.Location.X;
			MaximumSize = new Size((int)Math.Round(a), 1000);
			MinimumSize = new Size((int)Math.Round(a), 500);
			Size = new Size((int)Math.Round(a), (int)Math.Round(num));
			AnMdex3ejB = num;
			DgErros.Visible = false;
			btColar.Enabled = true;
			dgReguas.Rows.Clear();
			dgReguas.Columns.Clear();
			bNXda7tOpL = new ClsBornesInterligCpfl.StructureBornesCPFL[1];
			dIXd8Bb0qu = new ClsBornesInterligCpfl.StructureInterligCFEL[1];
			y3YdNenDbb = new ClsBornesInterligCpfl.StructureInterligCFEL[1];
			lWFdF8fcFM = new ClsBornesInterligCpfl.StructureJUMPERCFEL[1];
			MRhdQAkPrV = new ClsBornesInterligCpfl.StructureCadastroCabos[1];
			BfcdcPQJdm.Clear();
			btInsereBornes.Enabled = false;
			btInsereVeias.Enabled = false;
			btInsereJumpers.Enabled = false;
			btOrdenarAZ.Enabled = false;
		}
	}

	private void sl7k1uF90d(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(P_0)) ? ((double)(P_0.Width - 4)) : ((double)(P_0.Width - 21)));
				P_0.Columns[0].Width = (int)Math.Round(a);
				P_0.Columns[1].Width = 0;
				P_0.Columns[2].Width = 0;
				P_0.Columns[0].Visible = true;
				P_0.Columns[1].Visible = false;
				P_0.Columns[2].Visible = false;
				P_0.Columns[0].ReadOnly = false;
				P_0.Columns[1].ReadOnly = false;
				P_0.Columns[2].ReadOnly = false;
				P_0.MultiSelect = false;
			}
		}
	}

	public static bool adicionaUmBorne(ref clsBornes.StructureBlocoBorne myBorne, bool bTodosNomesVisiveis, bool bPainel, bool bRegua, ref double dDeslocamento, ref Point3d Point, string sHorientacao, bool bDeslocamento, Point3d Point2 = default(Point3d))
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		bool result = true;
		if (!((Point.X == 0.0) & (Point.Y == 0.0)))
		{
			clsBornes.InserirBorne(ref myBorne, 2, bTodosNomesVisiveis, bPainel, bRegua, ref Point);
		}
		else
		{
			clsBornes.InserirBorne(ref myBorne, 1, bPrimeiro: true, bPainel, bRegua, ref Point);
		}
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			ObjectId val2 = Geral.HandleToID(myBorne.Handle);
			if (val2.IsValid)
			{
				BlockReference val3 = (BlockReference)val.GetObject(val2, (OpenMode)0);
				try
				{
					if (!((Point.X == 0.0) & (Point.Y == 0.0)))
					{
						clsBornesInterligAuto.mAtt[] array = new clsBornesInterligAuto.mAtt[1];
						string sHandle = ((object)((DBObject)val3).Handle/*cast due to constrained. prefix*/).ToString();
						clsBlocos.OcultaAtributos(ref sHandle, ref array);
						Extents3d value;
						Point3d val4;
						if (!bDeslocamento)
						{
							if (Operators.CompareString(sHorientacao, "H", TextCompare: true) != 0)
							{
								double num = Point.Y;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MaxPoint;
								if (num != val4.Y)
								{
									value = ((Drawable)val3).Bounds.Value;
									val4 = value.MaxPoint;
									double num2 = val4.Y;
									value = ((Drawable)val3).Bounds.Value;
									val4 = value.MinPoint;
									double num3 = num2 - val4.Y;
									value = ((Drawable)val3).Bounds.Value;
									val4 = value.MaxPoint;
									dDeslocamento = (num3 - (val4.Y - Point.Y)) * -1.0;
								}
								else
								{
									dDeslocamento = 0.0;
								}
							}
							else
							{
								double num4 = Point.X;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MinPoint;
								if (num4 != val4.X)
								{
									value = ((Drawable)val3).Bounds.Value;
									val4 = value.MaxPoint;
									double num5 = val4.X;
									value = ((Drawable)val3).Bounds.Value;
									val4 = value.MinPoint;
									double num6 = num5 - val4.X;
									value = ((Drawable)val3).Bounds.Value;
									val4 = value.MaxPoint;
									dDeslocamento = (num6 - (val4.X - Point.X)) * -1.0;
								}
								else
								{
									dDeslocamento = 0.0;
								}
							}
						}
						else if (Operators.CompareString(sHorientacao, "H", TextCompare: true) != 0)
						{
							double num7 = Point.Y;
							value = ((Drawable)val3).Bounds.Value;
							val4 = value.MaxPoint;
							if (num7 != val4.Y)
							{
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MaxPoint;
								double num8 = val4.Y;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MinPoint;
								double num9 = num8 - val4.Y;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MaxPoint;
								dDeslocamento = num9 - (val4.Y - Point.Y);
							}
							else
							{
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MaxPoint;
								double num10 = val4.Y;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MinPoint;
								dDeslocamento = num10 - val4.Y;
							}
						}
						else
						{
							double num11 = Point.X;
							value = ((Drawable)val3).Bounds.Value;
							val4 = value.MinPoint;
							if (num11 != val4.X)
							{
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MaxPoint;
								double num12 = val4.X;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MinPoint;
								double num13 = num12 - val4.X;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MaxPoint;
								dDeslocamento = num13 - (val4.X - Point.X);
							}
							else
							{
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MaxPoint;
								double num14 = val4.X;
								value = ((Drawable)val3).Bounds.Value;
								val4 = value.MinPoint;
								dDeslocamento = num14 - val4.X;
							}
						}
						Point3d val5 = Point2;
						val4 = default;
						if (val5 != val4)
						{
							string sHandle2 = ((object)((DBObject)val3).Handle/*cast due to constrained. prefix*/).ToString();
							double num15 = 0.0;
							double num16 = 0.0;
							if (Operators.CompareString(sHorientacao, "H", TextCompare: true) != 0)
							{
								if (Point.X != Point2.X)
								{
									num15 = Point2.X - Point.X;
									Point = new Point3d(Point.X + num15, Point.Y, 0.0);
									clsBornesInterligAuto.moveoBloco(ref sHandle2, num15, num16);
								}
							}
							else if (Point.Y != Point2.Y)
							{
								num16 = Point2.Y - Point.Y;
								Point = new Point3d(Point.X, Point.Y + num16, 0.0);
								clsBornesInterligAuto.moveoBloco(ref sHandle2, num15, num16);
							}
						}
						sHandle = ((object)((DBObject)val3).Handle/*cast due to constrained. prefix*/).ToString();
						clsBlocos.DesOcultaAtributos(ref sHandle, ref array);
						myBorne.conector = "";
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					}
					else
					{
						result = false;
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	private void MlBklxfQjP(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = false;
		btColar.Enabled = false;
		bNXda7tOpL = new ClsBornesInterligCpfl.StructureBornesCPFL[1];
		dIXd8Bb0qu = new ClsBornesInterligCpfl.StructureInterligCFEL[1];
		y3YdNenDbb = new ClsBornesInterligCpfl.StructureInterligCFEL[1];
		lWFdF8fcFM = new ClsBornesInterligCpfl.StructureJUMPERCFEL[1];
		MRhdQAkPrV = new ClsBornesInterligCpfl.StructureCadastroCabos[1];
		RaVkAYNd7H();
		bool flag = wC4kR6WMOG();
		XoHksOT0tt();
		double num = Ponto1.Location.Y;
		double a = Ponto1.Location.X;
		checked
		{
			if (!((DgErros.RowCount == 0) & flag))
			{
				num = Ponto2.Location.Y;
				a = Ponto2.Location.X;
				MaximumSize = new Size((int)Math.Round(a), 1000);
				MinimumSize = new Size((int)Math.Round(a), 500);
				Size = new Size((int)Math.Round(a), (int)Math.Round(num));
				DgErros.Visible = true;
				btColar.Enabled = true;
			}
			else
			{
				MaximumSize = new Size((int)Math.Round(a), 1000);
				MinimumSize = new Size((int)Math.Round(a), 500);
				Size = new Size((int)Math.Round(a), (int)Math.Round(AnMdex3ejB));
				DgErros.Visible = false;
				TWtkXxyFQN();
				qFjkmD80uk();
				VghkUtfnlC();
				btColar.Enabled = false;
				ClsBornesInterligCpfl.CapturaBornesDoDesenhoCpfl(ref bNXda7tOpL);
			}
			if (Information.UBound(bNXda7tOpL) > 0)
			{
				btOrdenarAZ.Enabled = true;
				btInsereBornes.Enabled = true;
			}
			XoHksOT0tt();
			if (DgErros.RowCount > 0)
			{
				btOrdenarAZ.Enabled = false;
				btInsereBornes.Enabled = false;
				int num2 = DgErros.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					DgErros.Rows[i].Selected = false;
				}
			}
		}
	}

	private void pv6k5AfkMj(object P_0, EventArgs P_1)
	{
		btInsereBornes.Enabled = false;
		qefk0ftUf3();
		btInsereBornes.Enabled = true;
		btOrdenarAZ.Enabled = false;
		dgReguas.Rows.Clear();
		dgReguas.Columns.Clear();
		DataGridView withEventsValue = dgReguas;
		FRJkiy7AZ8(ref withEventsValue);
		dgReguas = withEventsValue;
		hmIk4goYh0();
		withEventsValue = dgReguas;
		lCJkSws37d(ref withEventsValue);
		dgReguas = withEventsValue;
	}

	private void qefk0ftUf3()
	{
		checked
		{
			if (Information.UBound(bNXda7tOpL) >= 0)
			{
				int num = 0;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(bNXda7tOpL) * 2;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num2 = Information.UBound(bNXda7tOpL);
				for (int i = 1; i <= num2; i++)
				{
					if (!Versioned.IsNumeric(bNXda7tOpL[i].sBorne))
					{
						string text = bNXda7tOpL[i].sBorne;
						string text2 = Strings.Mid(text, 1, Strings.Len(text) - 1);
						if (Versioned.IsNumeric(text2))
						{
							string text3 = Strings.Mid(text, Strings.Len(text), 1);
							if ((Strings.Asc(text3) >= 65) & (Strings.Asc(text3) <= 90))
							{
								text = Conversions.ToString(Conversions.ToDouble(text2) + (double)Strings.Asc(text3) / 100.0);
							}
						}
						if (!Versioned.IsNumeric(text))
						{
							bNXda7tOpL[i].iOrdem = 0.0;
						}
						else
						{
							bNXda7tOpL[i].iOrdem = Conversions.ToDouble(text);
						}
					}
					else
					{
						bNXda7tOpL[i].iOrdem = Conversions.ToDouble(bNXda7tOpL[i].sBorne);
					}
					if (Information.UBound(bNXda7tOpL) * 2 <= 1000)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						continue;
					}
					num++;
					if (num > 500)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num);
						num = 0;
					}
				}
				int num3 = Information.UBound(bNXda7tOpL);
				for (int j = 1; j <= num3; j++)
				{
					int num4 = Information.UBound(bNXda7tOpL) - 1;
					int num5 = j;
					for (int k = num4; k >= num5; k += -1)
					{
						if (bNXda7tOpL[k].iPainel > bNXda7tOpL[k + 1].iPainel)
						{
							ClsBornesInterligCpfl.StructureBornesCPFL structureBornesCPFL = bNXda7tOpL[k + 1];
							bNXda7tOpL[k + 1] = bNXda7tOpL[k];
							bNXda7tOpL[k] = structureBornesCPFL;
						}
						if (bNXda7tOpL[k].iPainel == bNXda7tOpL[k + 1].iPainel)
						{
							if (bNXda7tOpL[k].iRegua > bNXda7tOpL[k + 1].iRegua)
							{
								ClsBornesInterligCpfl.StructureBornesCPFL structureBornesCPFL = bNXda7tOpL[k + 1];
								bNXda7tOpL[k + 1] = bNXda7tOpL[k];
								bNXda7tOpL[k] = structureBornesCPFL;
							}
							if (bNXda7tOpL[k].iPainel == bNXda7tOpL[k + 1].iPainel && bNXda7tOpL[k].iRegua == bNXda7tOpL[k + 1].iRegua && bNXda7tOpL[k].iOrdem > bNXda7tOpL[k + 1].iOrdem)
							{
								ClsBornesInterligCpfl.StructureBornesCPFL structureBornesCPFL = bNXda7tOpL[k + 1];
								bNXda7tOpL[k + 1] = bNXda7tOpL[k];
								bNXda7tOpL[k] = structureBornesCPFL;
							}
						}
					}
					if (Information.UBound(bNXda7tOpL) * 2 <= 1000)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						continue;
					}
					num++;
					if (num > 500)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num);
						num = 0;
					}
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	private bool wC4kR6WMOG()
	{
		//IL_1605: Unknown result type (might be due to invalid IL or missing references)
		//IL_160a: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a8: Unknown result type (might be due to invalid IL or missing references)
		bool result = true;
		string text = Clipboard.GetText();
		checked
		{
			if (Operators.CompareString(Strings.Trim(text), "", TextCompare: true) != 0)
			{
				if (Strings.Asc(Strings.Mid(text, Strings.Len(text) - 1, 1)) != 13)
				{
					text += "\r\n";
				}
				int num = 0;
				string[] array = text.Split('\r');
				int num2 = 0;
				string right = "";
				ClsBornesInterligCpfl.StructureTamanhoCaboCPFE[] array2 = new ClsBornesInterligCpfl.StructureTamanhoCaboCPFE[1];
				List<string> list = new List<string>();
				try
				{
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					DeclaracoesGeral._uscPagina.Quantidade = array.Length - 2;
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num8 = 0;
					int num9 = array.Length - 2;
					for (int i = 0; i <= num9; i++)
					{
						num8++;
						if (num8 == 100)
						{
							DeclaracoesGeral._uscPagina.pbPasso(num8);
							num8 = 0;
						}
						bool flag = true;
						bool flag2 = true;
						string text2 = "";
						string text3 = "";
						string text4 = "";
						string text5 = "";
						string text6 = "";
						string text7 = "";
						string text8 = "";
						string text9 = "";
						string text10 = "";
						string text11 = "";
						string text12 = "";
						string text13 = "";
						bool bBlindado = false;
						string sTipo = "";
						int iAterrar = 0;
						double dComprimento = 0.0;
						string sTajeto = "";
						string[] array3 = array[i].Split('\t');
						int num10 = array3.Length - 1;
						for (int j = 0; j <= num10; j++)
						{
							if (array3[j].ToString().Contains("\n"))
							{
								array3[j] = array3[j].ToString().Replace("\n", "");
							}
							string text14 = array3[j].Trim();
							if (Information.IsNothing(text14))
							{
								text14 = "";
							}
							switch (j)
							{
							case 13:
								sTajeto = text14.ToString().Trim();
								break;
							case 0:
								text2 = text14.ToString().Trim();
								break;
							case 1:
								text3 = text14.ToString().Trim();
								break;
							case 2:
								text4 = text14.ToString().Trim();
								text4 = text4.ToUpper();
								if (text4.EndsWith("(BLINDADO)"))
								{
									bBlindado = true;
									text4 = text4.Replace("(BLINDADO)", "").Trim();
								}
								break;
							case 4:
								text5 = text14.ToString().Trim();
								break;
							case 5:
								text6 = text14.ToString().Trim();
								break;
							case 6:
								text7 = text14.ToString().Trim();
								break;
							case 7:
								text8 = text14.ToString().Trim();
								break;
							case 8:
								text9 = text14.ToString().Trim();
								break;
							case 9:
								text10 = text14.ToString().Trim();
								break;
							case 10:
								text11 = text14.ToString().Trim();
								break;
							case 11:
								iAterrar = (Versioned.IsNumeric(text14.ToString()) ? Conversions.ToInteger(text14) : 0);
								break;
							case 12:
								dComprimento = (Versioned.IsNumeric(text14.ToString()) ? Conversions.ToDouble(text14) : 0.0);
								break;
							}
						}
						string text15 = "";
						text15 = text5 + "-" + text7 + "-" + text6;
						if (BfcdcPQJdm.Contains(text15))
						{
							continue;
						}
						text15 = text11 + "-" + text9 + "-" + text10;
						if (BfcdcPQJdm.Contains(text15) || (((Operators.CompareString(text2, "", TextCompare: true) == 0) | (Operators.CompareString(text2, "", TextCompare: true) != 0)) & ((Operators.CompareString(text4, "", TextCompare: true) == 0) & (Operators.CompareString(text5, "", TextCompare: true) == 0)) & (Operators.CompareString(text6, "", TextCompare: true) == 0) & (Operators.CompareString(text7, "", TextCompare: true) == 0) & (Operators.CompareString(text8, "", TextCompare: true) == 0) & (Operators.CompareString(text9, "", TextCompare: true) == 0) & (Operators.CompareString(text10, "", TextCompare: true) == 0) & (Operators.CompareString(text11, "", TextCompare: true) == 0)))
						{
							continue;
						}
						if (Operators.CompareString(text6, "", TextCompare: true) == 0)
						{
							text6 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						}
						if (Operators.CompareString(text7, "", TextCompare: true) == 0)
						{
							text7 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						}
						if (Operators.CompareString(text9, "", TextCompare: true) == 0)
						{
							text9 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						}
						if (Operators.CompareString(text10, "", TextCompare: true) == 0)
						{
							text10 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						}
						if (Operators.CompareString(text2.ToString().ToUpper(), "JUMPER", TextCompare: true) == 0)
						{
							num7++;
							ref ClsBornesInterligCpfl.StructureJUMPERCFEL[] reference = ref lWFdF8fcFM;
							reference = (ClsBornesInterligCpfl.StructureJUMPERCFEL[])Utils.CopyArray(reference, new ClsBornesInterligCpfl.StructureJUMPERCFEL[num7 + 1]);
							lWFdF8fcFM[num7].sPainelDE = text5;
							lWFdF8fcFM[num7].sReguaDE = text7;
							lWFdF8fcFM[num7].sBorneDE = text6;
							lWFdF8fcFM[num7].sPainelPARA = text11;
							lWFdF8fcFM[num7].sReguaPARA = text9;
							lWFdF8fcFM[num7].sBornePARA = text10;
							lWFdF8fcFM[num7].sSecao = text4;
							lWFdF8fcFM[num7].sCor = text8;
							lWFdF8fcFM[num7].sFuncao = text3;
							if (Operators.CompareString(text5, text11, TextCompare: true) != 0)
							{
								DgErros.Rows.Add(text2, text3, text12, text13, text5, text6, text7, text8, text9, text10, text11);
								XoHksOT0tt();
								int index = DgErros.Rows.Count - 1;
								DgErros.Rows[index].Cells[4].Style = W5UdPD77fx;
								DgErros.Rows[index].Cells[10].Style = W5UdPD77fx;
								continue;
							}
						}
						else
						{
							if (((Operators.CompareString(text2, "", TextCompare: true) == 0) & (Operators.CompareString(text3, "", TextCompare: true) == 0)) && ((Operators.CompareString(text5, "", TextCompare: true) != 0) & (Operators.CompareString(text7, "", TextCompare: true) != 0) & (Operators.CompareString(text6, "", TextCompare: true) != 0)))
							{
								goto IL_066e;
							}
							if ((Operators.CompareString(text6, "", TextCompare: true) == 0) | (Operators.CompareString(text6, "0", TextCompare: true) == 0))
							{
								text10 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							}
							if ((Operators.CompareString(text10, "", TextCompare: true) == 0) | (Operators.CompareString(text10, "0", TextCompare: true) == 0))
							{
								text10 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							}
							if (Operators.CompareString(text4, "", TextCompare: true) != 0)
							{
								string[] array4 = text4.Split('x');
								if (Information.UBound(array4) != 0)
								{
									text12 = array4[0];
									text13 = array4[1];
								}
								else
								{
									text12 = "1";
									text13 = array4[0];
								}
							}
							else
							{
								text12 = "";
								text13 = "";
							}
							if (!(((Operators.CompareString(text2, "", TextCompare: true) != 0) & !Versioned.IsNumeric(text12) & !text8.Contains("BL")) | (Strings.Len(text6) > 10) | (Strings.Len(text10) > 10)))
							{
								if (text8.Contains("BL"))
								{
									if (Operators.CompareString(text5, "", TextCompare: true) != 0)
									{
										string text16 = text8;
										text16 = text16.Replace("BL", "");
										text16 = ((!Versioned.IsNumeric(text16)) ? Conversions.ToString(0) : Conversions.ToString(Conversions.ToInteger(text16) * -1));
										num6++;
										ref ClsBornesInterligCpfl.StructureInterligCFEL[] reference2 = ref y3YdNenDbb;
										reference2 = (ClsBornesInterligCpfl.StructureInterligCFEL[])Utils.CopyArray(reference2, new ClsBornesInterligCpfl.StructureInterligCFEL[num6 + 1]);
										y3YdNenDbb[num6].sPainelDE = text5;
										y3YdNenDbb[num6].sReguaDE = text7;
										y3YdNenDbb[num6].sBorneDE = text6;
										y3YdNenDbb[num6].sPainelPARA = "";
										y3YdNenDbb[num6].sReguaPARA = "";
										y3YdNenDbb[num6].sBornePARA = "";
										y3YdNenDbb[num6].s_Cabo = text2;
										y3YdNenDbb[num6].sNome = text8;
										y3YdNenDbb[num6].indice = Conversions.ToInteger(text16);
										y3YdNenDbb[num6].sTipo = sTipo;
									}
									if (Operators.CompareString(text11, "", TextCompare: true) != 0)
									{
										string text17 = text8;
										text17 = text17.Replace("BL", "");
										text17 = ((!Versioned.IsNumeric(text17)) ? Conversions.ToString(-99) : Conversions.ToString((50 + Conversions.ToInteger(text17)) * -1));
										num6++;
										ref ClsBornesInterligCpfl.StructureInterligCFEL[] reference3 = ref y3YdNenDbb;
										reference3 = (ClsBornesInterligCpfl.StructureInterligCFEL[])Utils.CopyArray(reference3, new ClsBornesInterligCpfl.StructureInterligCFEL[num6 + 1]);
										y3YdNenDbb[num6].sPainelDE = text11;
										y3YdNenDbb[num6].sReguaDE = text9;
										y3YdNenDbb[num6].sBorneDE = text10;
										y3YdNenDbb[num6].sPainelPARA = "";
										y3YdNenDbb[num6].sReguaPARA = "";
										y3YdNenDbb[num6].sBornePARA = "";
										y3YdNenDbb[num6].s_Cabo = text2;
										y3YdNenDbb[num6].sNome = text8;
										y3YdNenDbb[num6].indice = Conversions.ToInteger(text17);
										y3YdNenDbb[num6].sTipo = sTipo;
									}
									goto IL_05fb;
								}
							}
							else if ((Operators.CompareString(text2, "", TextCompare: true) == 0) | (Operators.CompareString(text4, "", TextCompare: true) == 0) | (Operators.CompareString(text5, "", TextCompare: true) == 0) | (Operators.CompareString(text7, "", TextCompare: true) == 0) | (Operators.CompareString(text9, "", TextCompare: true) == 0) | (Operators.CompareString(text11, "", TextCompare: true) == 0) | ((Operators.CompareString(text2, "JUMPER", TextCompare: true) != 0) & (Operators.CompareString(text5, text11, TextCompare: true) == 0)) | (Strings.Len(text6) > 10) | (Strings.Len(text10) > 10))
							{
								if (Operators.CompareString(text4, "", TextCompare: true) != 0)
								{
									string[] array5 = text4.Split('x');
									if (Information.UBound(array5) != 0)
									{
										text12 = array5[0];
										text13 = array5[1];
									}
									else
									{
										text12 = "1";
										text13 = array5[0];
									}
								}
								else
								{
									text12 = "";
									text13 = "";
								}
								DgErros.Rows.Add(text2, text3, text12, text13, text5, text6, text7, text8, text9, text10, text11, num2);
								result = false;
								int num11 = DgErros.Rows.Count - 1;
								if (Operators.CompareString(text2, "", TextCompare: true) == 0)
								{
									DgErros.Rows[num11].Cells[0].Style = W5UdPD77fx;
								}
								if (Operators.CompareString(text4, "", TextCompare: true) == 0)
								{
									DgErros.Rows[num11].Cells[2].Style = W5UdPD77fx;
									DgErros.Rows[num11].Cells[3].Style = W5UdPD77fx;
								}
								if (Operators.CompareString(text5, "", TextCompare: true) == 0)
								{
									DgErros.Rows[num11].Cells[4].Style = W5UdPD77fx;
								}
								if (Operators.CompareString(text7, "", TextCompare: true) == 0)
								{
									DgErros.Rows[num11].Cells[6].Style = W5UdPD77fx;
								}
								if (Operators.CompareString(text9, "", TextCompare: true) == 0)
								{
									DgErros.Rows[num11].Cells[8].Style = W5UdPD77fx;
								}
								if (Operators.CompareString(text11, "", TextCompare: true) == 0)
								{
									DgErros.Rows[num11].Cells[10].Style = W5UdPD77fx;
								}
								if ((Operators.CompareString(text2, "JUMPER", TextCompare: true) != 0) & (Operators.CompareString(text5, text11, TextCompare: true) == 0))
								{
									DgErros.Rows[num11].Cells[4].Style = W5UdPD77fx;
									DgErros.Rows[num11].Cells[10].Style = W5UdPD77fx;
								}
								if (Strings.Len(text6) > 10)
								{
									DgErros.Rows[num11].Cells[5].Style = W5UdPD77fx;
								}
								if (Strings.Len(text10) > 10)
								{
									DgErros.Rows[num11].Cells[9].Style = W5UdPD77fx;
								}
								if (num11 == 0)
								{
									XoHksOT0tt();
								}
								continue;
							}
							if (Operators.CompareString(text2, right, TextCompare: true) != 0)
							{
								num2 = 0;
								right = text2;
							}
							num2++;
							if (num2 != 1)
							{
								int num12 = Information.UBound(array2);
								for (int k = 1; k <= num12; k++)
								{
									if (Operators.CompareString(array2[k].sCabo, text2, TextCompare: true) == 0)
									{
										array2[num].iVeias++;
									}
								}
							}
							else
							{
								text4 = text4.Replace("x", "X");
								string[] array6 = text4.Split('X');
								if (Information.UBound(array6) != 0)
								{
									text12 = array6[0];
									text13 = array6[1];
								}
								else
								{
									text12 = "1";
									text13 = array6[0];
								}
								num++;
								array2 = (ClsBornesInterligCpfl.StructureTamanhoCaboCPFE[])Utils.CopyArray(array2, new ClsBornesInterligCpfl.StructureTamanhoCaboCPFE[num + 1]);
								array2[num].sCabo = text2;
								array2[num].iVeias = 1;
								if (!Versioned.IsNumeric(text12))
								{
									if (text12.Contains("P"))
									{
										string text18 = text12.Replace("P", "");
										text18 = text18.Trim();
										if (Versioned.IsNumeric(text18))
										{
											array2[num].iTotVeias = Conversions.ToInteger(text18) * 2;
											array2[num].iQuant = 0;
										}
										sTipo = "P";
									}
									if (text12.Contains("T"))
									{
										string text19 = text12.Replace("T", "");
										text19 = text19.Trim();
										if (Versioned.IsNumeric(text19))
										{
											array2[num].iTotVeias = Conversions.ToInteger(text19) * 3;
											array2[num].iQuant = 0;
										}
										sTipo = "T";
									}
								}
								else
								{
									array2[num].iTotVeias = Conversions.ToInteger(text12);
									array2[num].iQuant = 0;
								}
							}
							if (Operators.CompareString(text8.Trim(), "", TextCompare: true) == 0)
							{
								text8 = Conversions.ToString(num2);
							}
							flag = true;
							int num13 = Information.UBound(MRhdQAkPrV);
							for (int l = 1; l <= num13; l++)
							{
								if (Operators.CompareString(MRhdQAkPrV[l].sCabo, text2, TextCompare: true) == 0)
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								num3++;
								ref ClsBornesInterligCpfl.StructureCadastroCabos[] mRhdQAkPrV = ref MRhdQAkPrV;
								mRhdQAkPrV = (ClsBornesInterligCpfl.StructureCadastroCabos[])Utils.CopyArray(mRhdQAkPrV, new ClsBornesInterligCpfl.StructureCadastroCabos[num3 + 1]);
								MRhdQAkPrV[num3].sCabo = text2;
								MRhdQAkPrV[num3].sFormacao = text4;
								MRhdQAkPrV[num3].sEquipDE = text5;
								MRhdQAkPrV[num3].sEquipPARA = text11;
								MRhdQAkPrV[num3].sVeias = text12;
								MRhdQAkPrV[num3].sSecao = text13;
								MRhdQAkPrV[num3].sFuncao = text3;
								MRhdQAkPrV[num3].bBlindado = bBlindado;
								MRhdQAkPrV[num3].iAterrar = iAterrar;
								MRhdQAkPrV[num3].dComprimento = dComprimento;
								MRhdQAkPrV[num3].sTajeto = sTajeto;
							}
							num5++;
							ref ClsBornesInterligCpfl.StructureInterligCFEL[] reference4 = ref dIXd8Bb0qu;
							reference4 = (ClsBornesInterligCpfl.StructureInterligCFEL[])Utils.CopyArray(reference4, new ClsBornesInterligCpfl.StructureInterligCFEL[num5 + 1]);
							dIXd8Bb0qu[num5].sPainelDE = text5;
							dIXd8Bb0qu[num5].sReguaDE = text7;
							dIXd8Bb0qu[num5].sBorneDE = text6;
							dIXd8Bb0qu[num5].sPainelPARA = text11;
							dIXd8Bb0qu[num5].sReguaPARA = text9;
							dIXd8Bb0qu[num5].sBornePARA = text10;
							dIXd8Bb0qu[num5].s_Cabo = text2;
							dIXd8Bb0qu[num5].sNome = text8;
							dIXd8Bb0qu[num5].indice = num2;
							dIXd8Bb0qu[num5].sTipo = sTipo;
						}
						goto IL_05fb;
						IL_066e:
						if (flag2)
						{
							num4++;
							ref ClsBornesInterligCpfl.StructureBornesCPFL[] reference5 = ref bNXda7tOpL;
							reference5 = (ClsBornesInterligCpfl.StructureBornesCPFL[])Utils.CopyArray(reference5, new ClsBornesInterligCpfl.StructureBornesCPFL[num4 + 1]);
							bNXda7tOpL[num4].sPainel = text5;
							bNXda7tOpL[num4].iPainel = 0;
							bNXda7tOpL[num4].sRegua = text7;
							bNXda7tOpL[num4].iRegua = 0;
							bNXda7tOpL[num4].sBorne = text6;
							bNXda7tOpL[num4].sHandle = "";
							bNXda7tOpL[num4].Layer = "";
							bNXda7tOpL[num4].Point1 = new Point3d(0.0, 0.0, 0.0);
							bNXda7tOpL[num4].bCDE1 = false;
							bNXda7tOpL[num4].bCDE2 = false;
							bNXda7tOpL[num4].bCDE3 = false;
							bNXda7tOpL[num4].bCDE4 = false;
							bNXda7tOpL[num4].bJDE1 = false;
							bNXda7tOpL[num4].bJDE2 = false;
							bNXda7tOpL[num4].bJDE3 = false;
							bNXda7tOpL[num4].bJDE4 = false;
						}
						flag2 = true;
						if (!((Operators.CompareString(text9, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0) & (Operators.CompareString(text10, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)))
						{
							string item = text11 + "|" + text9 + "|" + text10;
							if (list.Contains(item))
							{
								flag2 = false;
							}
							else
							{
								list.Add(item);
								flag2 = true;
							}
						}
						else
						{
							flag2 = false;
						}
						if (flag2)
						{
							num4++;
							ref ClsBornesInterligCpfl.StructureBornesCPFL[] reference6 = ref bNXda7tOpL;
							reference6 = (ClsBornesInterligCpfl.StructureBornesCPFL[])Utils.CopyArray(reference6, new ClsBornesInterligCpfl.StructureBornesCPFL[num4 + 1]);
							bNXda7tOpL[num4].sPainel = text11;
							bNXda7tOpL[num4].iPainel = 0;
							bNXda7tOpL[num4].sRegua = text9;
							bNXda7tOpL[num4].iRegua = 0;
							bNXda7tOpL[num4].sBorne = text10;
							bNXda7tOpL[num4].sHandle = "";
							bNXda7tOpL[num4].Layer = "";
							bNXda7tOpL[num4].Point1 = new Point3d(0.0, 0.0, 0.0);
							bNXda7tOpL[num4].bCDE1 = false;
							bNXda7tOpL[num4].bCDE2 = false;
							bNXda7tOpL[num4].bCDE3 = false;
							bNXda7tOpL[num4].bCDE4 = false;
							bNXda7tOpL[num4].bJDE1 = false;
							bNXda7tOpL[num4].bJDE2 = false;
							bNXda7tOpL[num4].bJDE3 = false;
							bNXda7tOpL[num4].bJDE4 = false;
						}
						continue;
						IL_05fb:
						flag2 = true;
						if (!((Operators.CompareString(text7, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0) & (Operators.CompareString(text6, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)))
						{
							string item2 = text5 + "|" + text7 + "|" + text6;
							if (list.Contains(item2))
							{
								flag2 = false;
							}
							else
							{
								list.Add(item2);
								flag2 = true;
							}
						}
						else
						{
							flag2 = false;
						}
						goto IL_066e;
					}
					string text20 = "";
					int num14 = Information.UBound(dIXd8Bb0qu);
					for (int m = 1; m <= num14; m++)
					{
						if (!dIXd8Bb0qu[m].sNome.EndsWith("BL"))
						{
							continue;
						}
						int num15 = Information.UBound(array2);
						for (int n = 1; n <= num15; n++)
						{
							if (Operators.CompareString(dIXd8Bb0qu[m].s_Cabo, array2[n].sCabo, TextCompare: true) == 0)
							{
								array2[n].iQuant++;
							}
						}
					}
					int num16 = Information.UBound(array2);
					for (int num17 = 1; num17 <= num16; num17++)
					{
						if (array2[num17].iVeias > array2[num17].iTotVeias + array2[num17].iQuant)
						{
							if (Operators.CompareString(text20, "", TextCompare: true) == 0)
							{
								result = false;
								text20 = "Os cabos abaixo possui mais veias so que o cabo lançado:\r\n\r\n";
							}
							text20 = text20 + array2[num17].sCabo + " falata " + Conversions.ToString(array2[num].iVeias - array2[num17].iTotVeias) + " Veias\r\n";
						}
					}
					if (Operators.CompareString(text20, "", TextCompare: true) != 0)
					{
						Interaction.MsgBox(text20);
					}
					DeclaracoesGeral._uscPagina.pbFim();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1572], "\r\n"), DeclaracoesGeral.mMensagem[1, 1573]), DgErros.ColumnCount), ".")));
					ProjectData.ClearProjectError();
				}
			}
			return result;
		}
	}

	private void qFjkmD80uk()
	{
		checked
		{
			try
			{
				List<string> lmListaCabos = new List<string>();
				CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
				cDadosAccessInterligacao3.LeNomeDeCabos(ref lmListaCabos);
				cDadosAccessInterligacao3.FechaConexao();
				int num = Information.UBound(MRhdQAkPrV);
				for (int i = 1; i <= num; i++)
				{
					if (!lmListaCabos.Contains(MRhdQAkPrV[i].sCabo))
					{
						znldK10gKg++;
						ref structureImpCabos[] reference = ref mCabosImp;
						reference = (structureImpCabos[])Utils.CopyArray(reference, new structureImpCabos[znldK10gKg + 1]);
						mCabosImp[znldK10gKg].sDe = MRhdQAkPrV[i].sEquipDE;
						mCabosImp[znldK10gKg].sPara = MRhdQAkPrV[i].sEquipPARA;
						mCabosImp[znldK10gKg].sCabo = MRhdQAkPrV[i].sCabo;
						mCabosImp[znldK10gKg].sVeias = MRhdQAkPrV[i].sVeias;
						mCabosImp[znldK10gKg].sSecao = MRhdQAkPrV[i].sSecao;
						mCabosImp[znldK10gKg].sFuncao = MRhdQAkPrV[i].sFuncao;
						mCabosImp[znldK10gKg].bBlindado = MRhdQAkPrV[i].bBlindado;
						mCabosImp[znldK10gKg].dComprimento = MRhdQAkPrV[i].dComprimento;
						mCabosImp[znldK10gKg].sTajeto = MRhdQAkPrV[i].sTajeto;
						mCabosImp[znldK10gKg].iAterrar = MRhdQAkPrV[i].iAterrar;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void TWtkXxyFQN()
	{
		ClsBornesInterligCpfl.StructureBorneInseidos2[] mBornesAdd = new ClsBornesInterligCpfl.StructureBorneInseidos2[1];
		if (ClsBornesInterligCpfl.VerificaBornesCpfl(ref mBornesAdd, ref dIXd8Bb0qu, ref lWFdF8fcFM))
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1560]), MsgBoxStyle.Information);
			return;
		}
		ClsBornesInterligCpfl.CadastraPaineisCpfl(ref mBornesAdd, ref bNXda7tOpL, ref dIXd8Bb0qu, ref y3YdNenDbb, ref lWFdF8fcFM, ref MRhdQAkPrV);
		ClsBornesInterligCpfl.CadastraReguasCpfl(ref mBornesAdd, ref bNXda7tOpL, ref dIXd8Bb0qu, ref y3YdNenDbb, ref lWFdF8fcFM);
	}

	private void VghkUtfnlC()
	{
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		ClsCabos.CarregaOsCabosDoDG(ref mCabosImp, ref cDadosAccessInterligacao3);
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(dIXd8Bb0qu);
		DeclaracoesGeral._uscPagina.pbIniciar();
		int num = 1;
		int num2 = Information.UBound(dIXd8Bb0qu);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				dIXd8Bb0qu[i].indice = qNQkyvX9DZ(dIXd8Bb0qu[i].sNome, dIXd8Bb0qu[i].indice);
				cDadosAccessInterligacao3.EditaOnomeDaVeiaDeUmCabo(dIXd8Bb0qu[i].sNome, dIXd8Bb0qu[i].s_Cabo, dIXd8Bb0qu[i].indice);
				if (Information.UBound(dIXd8Bb0qu) <= 1000)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
					continue;
				}
				num++;
				if (num > 500)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num);
					num = 0;
				}
			}
			cDadosAccessInterligacao3.FechaConexao();
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	private static int qNQkyvX9DZ(string P_0, int P_1)
	{
		int result = P_1;
		ClsCabos.NomeVeias nomeVeias = new ClsCabos.NomeVeias
		{
			blVar = "BL",
			P1Var = "P1",
			P2Var = "P2",
			T1Var = "T1",
			T2Var = "T2",
			T3Var = "T3"
		};
		string text = "";
		checked
		{
			if (Operators.CompareString(P_0, "BL", TextCompare: true) != 0)
			{
				if (!P_0.Contains("P"))
				{
					if (P_0.Contains("T"))
					{
						int num = 0;
						int num2 = 1;
						int num3 = 1;
						num = 1;
						while (true)
						{
							IL_010d:
							text = nomeVeias.T1Var;
							while (true)
							{
								if (Operators.CompareString(P_0, Conversions.ToString(num2) + text, TextCompare: true) != 0)
								{
									num3++;
									if (num3 > 50)
									{
										break;
									}
									num++;
									switch (num)
									{
									case 1:
										break;
									case 4:
										num = 1;
										text = nomeVeias.T1Var;
										num2++;
										continue;
									default:
										continue;
									case 2:
										text = nomeVeias.T2Var;
										continue;
									case 3:
										text = nomeVeias.T3Var;
										continue;
									}
									goto IL_010d;
								}
								result = num3;
								break;
							}
							break;
						}
					}
				}
				else
				{
					int num = 0;
					int num2 = 1;
					int num4 = 1;
					num = 1;
					while (true)
					{
						IL_0099:
						text = nomeVeias.P1Var;
						while (true)
						{
							if (Operators.CompareString(P_0, Conversions.ToString(num2) + text, TextCompare: true) != 0)
							{
								num4++;
								if (num4 > 50)
								{
									break;
								}
								num++;
								switch (num)
								{
								case 1:
									break;
								case 3:
									num = 1;
									text = nomeVeias.P1Var;
									num2++;
									continue;
								default:
									continue;
								case 2:
									text = nomeVeias.P2Var;
									continue;
								}
								goto IL_0099;
							}
							result = num4;
							break;
						}
						break;
					}
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}

	private void NhmkgKrO6M(object P_0, DataGridViewCellEventArgs P_1)
	{
		checked
		{
			int num = DgErros.Rows.Count - 1;
			for (int i = 0; i <= num && !DgErros.Rows[i].Selected; i++)
			{
			}
		}
	}

	private void RaVkAYNd7H()
	{
		DgErros.Rows.Clear();
		DgErros.Columns.Clear();
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1288]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1430]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1569]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 889]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1241]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 984]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 984]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]));
		DgErros.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1242]));
		DgErros.Columns.Add("", "iIndice");
	}

	private void XoHksOT0tt()
	{
		checked
		{
			if (DgErros.RowCount != 0)
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DgErros)) ? ((float)(DgErros.Width - 4)) : ((float)(DgErros.Width - 22)));
				DgErros.Columns[0].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[1].Width = (int)Math.Round(num * 2f / 14f);
				DgErros.Columns[2].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[3].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[4].Width = (int)Math.Round(num * 2f / 14f);
				DgErros.Columns[5].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[6].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[7].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[8].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[9].Width = (int)Math.Round(num * 1f / 14f);
				DgErros.Columns[10].Width = (int)Math.Round(num * 2f / 14f);
				DgErros.Columns[11].Width = 0;
				DgErros.Columns[0].Visible = true;
				DgErros.Columns[1].Visible = true;
				DgErros.Columns[2].Visible = true;
				DgErros.Columns[3].Visible = true;
				DgErros.Columns[4].Visible = true;
				DgErros.Columns[5].Visible = true;
				DgErros.Columns[6].Visible = true;
				DgErros.Columns[7].Visible = true;
				DgErros.Columns[8].Visible = true;
				DgErros.Columns[9].Visible = true;
				DgErros.Columns[10].Visible = true;
				DgErros.Columns[11].Visible = false;
				int num2 = 0;
				do
				{
					DgErros.Columns[num2].ReadOnly = true;
					num2++;
				}
				while (num2 <= 11);
			}
		}
	}

	private void CZ1kBQOPJT(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = false;
		List<string> list = new List<string>();
		checked
		{
			int num = dgReguas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgReguas.Rows[i].Cells[6].Value, "R", TextCompare: true))
				{
					list.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgReguas.Rows[i].Cells[1].Value, "-"), dgReguas.Rows[i].Cells[3].Value)));
				}
			}
			ClsBornesInterligCpfl.AdicionaBornesReserva(ref bNXda7tOpL, list);
			ClsBornesInterligCpfl.AdicionaBornesNoDWG(Conversions.ToDouble(tbDistancia.Text), ref bNXda7tOpL, CKPainel.Checked, bOrdem: true);
			btInsereBornes.Enabled = false;
			if (Information.UBound(dIXd8Bb0qu) > 0)
			{
				btInsereVeias.Enabled = true;
			}
			if (Information.UBound(lWFdF8fcFM) > 0)
			{
				btInsereJumpers.Enabled = true;
			}
		}
	}

	private void ga8kVg6848(object P_0, EventArgs P_1)
	{
		if (!DeclaracoesGeral.bPararRelatorio)
		{
			ClsBornesInterligCpfl.AdicionaCabosNoDWG(ref bNXda7tOpL, ref dIXd8Bb0qu, Conversions.ToDouble(tbDistancia.Text));
			ClsBornesInterligCpfl.AdicionaBlindagensNoDWG(ref bNXda7tOpL, ref y3YdNenDbb, Conversions.ToDouble(tbDistancia.Text));
			btInsereVeias.Enabled = false;
			clsEditarInterligacao.InsereTextosDeCabos();
			CDadosAccessInterligacao CDadosAccessInterligacao = new CDadosAccessInterligacao();
			clsEditarInterligacao.SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao);
			CDadosAccessInterligacao.FechaConexao();
		}
	}

	private void qgZkuxjIh7(object P_0, EventArgs P_1)
	{
		if (!DeclaracoesGeral.bPararRelatorio)
		{
			ClsBornesInterligCpfl.AdicionaJUMPERSNoDWG(ref bNXda7tOpL, ref lWFdF8fcFM, Conversions.ToDouble(tbDistancia.Text));
			btInsereJumpers.Enabled = false;
		}
	}

	private void Lj4kEk3nPI(object P_0, EventArgs P_1)
	{
		try
		{
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Worksheet oSheet = null;
			ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, "INTERLIGACAO_CPFL");
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			ClsBornesInterligCpfl.ExportaModeloBornesInterligacaoCPFL(ref oSheet);
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void HVxkZ0SVj0(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1719]), MsgBoxStyle.YesNo);
		if (msgBoxResult != MsgBoxResult.No && Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1283]), MsgBoxStyle.YesNo) != MsgBoxResult.No)
		{
			ClsBornesInterligCpfl.ApagaTodosOsBornesReserva();
			ClsBornesInterligCpfl.LimpaTodoDesenho();
			IniciaForme();
			Geral.FechaForm("frmImportarBornesExcelCpfl");
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			new frmImportarInterligExcel();
		}
	}

	private void FRJkiy7AZ8(ref DataGridView P_0)
	{
		P_0.Rows.Clear();
		P_0.Columns.Clear();
		P_0.Columns.Add("", "ordem");
		P_0.Columns.Add("", "iPN");
		P_0.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1005]));
		P_0.Columns.Add("", "iRégua");
		P_0.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 984]));
		P_0.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1734]));
		P_0.Columns.Add("", "RES");
	}

	private void lCJkSws37d(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.RowCount != 0)
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(P_0)) ? ((float)(P_0.Width - 4)) : ((float)(P_0.Width - 22)));
				P_0.Columns[0].Width = 0;
				P_0.Columns[1].Width = 0;
				P_0.Columns[2].Width = (int)Math.Round((double)num * 0.45);
				P_0.Columns[3].Width = 0;
				P_0.Columns[4].Width = (int)Math.Round((double)num * 0.25);
				P_0.Columns[5].Width = (int)Math.Round((double)num * 0.15);
				P_0.Columns[6].Width = (int)Math.Round((double)num * 0.15);
				P_0.Columns[0].Visible = false;
				P_0.Columns[1].Visible = false;
				P_0.Columns[2].Visible = true;
				P_0.Columns[3].Visible = false;
				P_0.Columns[4].Visible = true;
				P_0.Columns[5].Visible = true;
				P_0.Columns[6].Visible = true;
				P_0.MultiSelect = true;
				int num2 = 0;
				do
				{
					P_0.Columns[num2].ReadOnly = true;
					num2++;
				}
				while (num2 <= 5);
				int num3 = P_0.Columns.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					P_0.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			else
			{
				P_0.Rows.Clear();
				P_0.Columns.Clear();
			}
		}
	}

	private void hmIk4goYh0()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		ClsBornesInterligCpfl.StructureBornesCPFL[] array = bNXda7tOpL;
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				ClsBornesInterligCpfl.StructureBornesCPFL structureBornesCPFL = array[i];
				if (!Information.IsNothing(structureBornesCPFL.sBorne) && !Versioned.IsNumeric(structureBornesCPFL.sBorne) && !list.Contains(structureBornesCPFL.sPainel + "-" + structureBornesCPFL.sRegua))
				{
					list.Add(structureBornesCPFL.sPainel + "-" + structureBornesCPFL.sRegua);
				}
			}
			int num = 1;
			ClsBornesInterligCpfl.StructureBornesCPFL[] array2 = bNXda7tOpL;
			for (int j = 0; j < array2.Length; j++)
			{
				ClsBornesInterligCpfl.StructureBornesCPFL structureBornesCPFL2 = array2[j];
				if (!Information.IsNothing(structureBornesCPFL2.sBorne) && !list.Contains(structureBornesCPFL2.sPainel + "-" + structureBornesCPFL2.sRegua) && !list2.Contains(structureBornesCPFL2.sPainel + "-" + structureBornesCPFL2.sRegua))
				{
					list2.Add(structureBornesCPFL2.sPainel + "-" + structureBornesCPFL2.sRegua);
					int num2 = VXUkCcURNK(structureBornesCPFL2.sPainel + "-" + structureBornesCPFL2.sRegua);
					dgReguas.Rows.Add(num, structureBornesCPFL2.iPainel, structureBornesCPFL2.sPainel, structureBornesCPFL2.iRegua, structureBornesCPFL2.sRegua, num2);
					dgReguas.Rows[0].Selected = true;
					num++;
				}
			}
		}
	}

	private int VXUkCcURNK(string P_0)
	{
		int num = 0;
		ClsBornesInterligCpfl.StructureBornesCPFL[] array = bNXda7tOpL;
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				ClsBornesInterligCpfl.StructureBornesCPFL structureBornesCPFL = array[i];
				if (Operators.CompareString(clsTextos.TiraNothing(structureBornesCPFL.sPainel) + "-" + clsTextos.TiraNothing(structureBornesCPFL.sRegua), P_0, TextCompare: true) == 0)
				{
					num++;
				}
			}
			return num;
		}
	}

	private void fevkYqSDfQ(object P_0, EventArgs P_1)
	{
		if (DeclaracoesGeral.bPararRelatorio)
		{
			return;
		}
		checked
		{
			int num = dgReguas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgReguas.Rows[i].Selected)
				{
					dgReguas.Rows[i].Cells[6].Value = "R";
				}
			}
		}
	}

	private void B6Fkr4YObe(object P_0, EventArgs P_1)
	{
		if (DeclaracoesGeral.bPararRelatorio)
		{
			return;
		}
		checked
		{
			int num = dgReguas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgReguas.Rows[i].Selected)
				{
					dgReguas.Rows[i].Cells[6].Value = "";
				}
			}
		}
	}

	private void EC0k9upyR9(DataGridView P_0)
	{
		checked
		{
			if (P_0.Rows.Count >= 2)
			{
				int num = P_0.Rows.Count - 2;
				for (int i = num; i >= 0; i += -1)
				{
					int num2 = i;
					for (int j = 0; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectGreater(P_0[0, j].Value, P_0[0, j + 1].Value, TextCompare: true))
						{
							int num3 = 0;
							do
							{
								object objectValue = RuntimeHelpers.GetObjectValue(P_0[num3, j + 1].Value);
								P_0[num3, j + 1].Value = RuntimeHelpers.GetObjectValue(P_0[num3, j].Value);
								P_0[num3, j].Value = RuntimeHelpers.GetObjectValue(objectValue);
								num3++;
							}
							while (num3 <= 4);
						}
					}
				}
			}
			lCJkSws37d(ref P_0);
		}
	}

	private void aGekzH1ypY(object P_0, EventArgs P_1)
	{
		AnMdex3ejB = Size.Height;
	}

	private void g6odWToXyq(object P_0, MouseEventArgs P_1)
	{
		if (DgErros.Rows.Count == 1)
		{
			DgErros.Rows[0].Selected = false;
		}
	}
}
