using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmImportarProjetos : Form
{
	private IContainer N45phEsd9Sp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip FxLphZh8B7C;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	private FolderBrowserDialog wsYphijDghV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelNovoBanco")]
	private Button ESXphSKIC7c;

	[AccessedThroughProperty("tbBancoCorrente")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox k7jph45rJpB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbBancoCorrente")]
	private Label DQZphC0mAhI;

	[AccessedThroughProperty("tbBancoImportado")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox k5CphYPjLLN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbBancoImportado")]
	private Label anQphrb99fp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWGOriginal")]
	private DataGridView RNSph9B8KBE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCaminho")]
	[CompilerGenerated]
	private TextBox EtPphzdx3rG;

	[AccessedThroughProperty("btMigrarosPaineis")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button DjApoWapRFw;

	[AccessedThroughProperty("btSelDirNovosDocumentos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button flvpoprXtxy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgPnParaMigrar")]
	private DataGridView YUwpoTYyyof;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWGNovo")]
	private DataGridView PvApoJFaDQA;

	[AccessedThroughProperty("btAdicionaDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button ieipoh98ivA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDestino")]
	private Label sL3pooBsZCX;

	[AccessedThroughProperty("lbSufixoNome")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label mf6poGwGIgM;

	[AccessedThroughProperty("tbComplementoNome")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox VeSpoHCE1gB;

	[AccessedThroughProperty("ProgressBar1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ProgressBar JZmpokeNFpn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private Label whOpod5n6fh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private Label EOrpofG9haN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private Label hxhpoDYveeW;

	[CompilerGenerated]
	[AccessedThroughProperty("CKFiacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox NLopovTjrnF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GBOpcoes")]
	private GroupBox KWbpo6jfZsm;

	[AccessedThroughProperty("CKPlaquetas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox ufHpotU4eGj;

	[AccessedThroughProperty("CKCabosDWG")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox d9VpojUM8wj;

	[CompilerGenerated]
	[AccessedThroughProperty("RBNaoImportarMateriais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton dDcpoLpxMrr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBImportarMateriais")]
	private RadioButton rfkpowxpQ9n;

	private DataGridViewCellStyle A8bpox0W2ho;

	private DataGridViewCellStyle D2ZpobdKhgj;

	private DataGridViewCellStyle yjZpoMe77dI;

	private DataGridViewCellStyle rQjpoOD4lak;

	private clsImportarProjetos.mEquip[] fZMpoImMwjU;

	private clsImportarProjetos.mEquip[] wnPpo7Hvhxx;

	private clsImportarProjetos.mDWG[] lYqpoquxcnc;

	private clsImportarProjetos.mDWG[] t4tpoarINgG;

	private clsImportarProjetos.mCabos[] zGwpo8dyWwX;

	private clsImportarProjetos.mCabos[] lx8poNgxqVs;

	private clsImportarProjetos.mExpo[] M8spoFSYuUY;

	private clsImportarProjetos.mExpo[] optpoQqHhxA;

	private clsImportarProjetos.mAtt[] QVtpoPas4ni;

	private clsImportarProjetos.mAtt[] b3UpocWnVp7;

	private string YlQpoKpILGj;

	private string ddJpoexXETZ;

	private clsImportarProjetos.mIndiceTrocaPN[] XTZpo2asTNH;

	private clsImportarProjetos.mTrocaImportados[] t49po37Qk0j;

	private clsImportarProjetos.mIndiceTrocaDWG[] uPjponugNjK;

	private List<int> hEFpo1x0TMm;

	private List<int> kxtpolpfkGy;

	private clsImportarProjetos.mTrocaCabos[] heupo5nJegp;

	private List<string> V32po0lyUGE;

	private int uuWpoRv0jRO;

	private List<int> N8cpomA9e8L;

	private cDadosLM.structureLMRelelatorio[] l7tpoXyie98;

	private cDadosLM.structureLMRelelatorio[] DwGpoU1nnoe;

	private cDadosLM.structureLMRelelatorio[] RuYpoy4uu61;

	private clsImportarProjetos.mTrocaImportados[] DxbpognKNEw;

	private string PplpoAsDtxZ;

	private int uohposIOrRR;

	internal virtual Button btSelNovoBanco
	{
		[CompilerGenerated]
		get
		{
			return ESXphSKIC7c;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = i3GphUNEmv3;
			Button button = ESXphSKIC7c;
			if (button != null)
			{
				button.Click -= value2;
			}
			ESXphSKIC7c = value;
			button = ESXphSKIC7c;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbBancoCorrente
	{
		[CompilerGenerated]
		get
		{
			return k7jph45rJpB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			k7jph45rJpB = value;
		}
	}

	internal virtual Label lbBancoCorrente
	{
		[CompilerGenerated]
		get
		{
			return DQZphC0mAhI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DQZphC0mAhI = value;
		}
	}

	internal virtual TextBox tbBancoImportado
	{
		[CompilerGenerated]
		get
		{
			return k5CphYPjLLN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			k5CphYPjLLN = value;
		}
	}

	internal virtual Label lbBancoImportado
	{
		[CompilerGenerated]
		get
		{
			return anQphrb99fp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			anQphrb99fp = value;
		}
	}

	internal virtual DataGridView dgDWGOriginal
	{
		[CompilerGenerated]
		get
		{
			return RNSph9B8KBE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RNSph9B8KBE = value;
		}
	}

	internal virtual TextBox tbCaminho
	{
		[CompilerGenerated]
		get
		{
			return EtPphzdx3rG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EtPphzdx3rG = value;
		}
	}

	internal virtual Button btMigrarosPaineis
	{
		[CompilerGenerated]
		get
		{
			return DjApoWapRFw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SnZphVTWC1e;
			Button button = DjApoWapRFw;
			if (button != null)
			{
				button.Click -= value2;
			}
			DjApoWapRFw = value;
			button = DjApoWapRFw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSelDirNovosDocumentos
	{
		[CompilerGenerated]
		get
		{
			return flvpoprXtxy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TbiphADk8re;
			Button button = flvpoprXtxy;
			if (button != null)
			{
				button.Click -= value2;
			}
			flvpoprXtxy = value;
			button = flvpoprXtxy;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPnParaMigrar
	{
		[CompilerGenerated]
		get
		{
			return YUwpoTYyyof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YUwpoTYyyof = value;
		}
	}

	internal virtual DataGridView dgDWGNovo
	{
		[CompilerGenerated]
		get
		{
			return PvApoJFaDQA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PvApoJFaDQA = value;
		}
	}

	internal virtual Button btAdicionaDWG
	{
		[CompilerGenerated]
		get
		{
			return ieipoh98ivA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SRVphBhu9QY;
			Button button = ieipoh98ivA;
			if (button != null)
			{
				button.Click -= value2;
			}
			ieipoh98ivA = value;
			button = ieipoh98ivA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbDestino
	{
		[CompilerGenerated]
		get
		{
			return sL3pooBsZCX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sL3pooBsZCX = value;
		}
	}

	internal virtual Label lbSufixoNome
	{
		[CompilerGenerated]
		get
		{
			return mf6poGwGIgM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mf6poGwGIgM = value;
		}
	}

	internal virtual TextBox tbComplementoNome
	{
		[CompilerGenerated]
		get
		{
			return VeSpoHCE1gB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VeSpoHCE1gB = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return JZmpokeNFpn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JZmpokeNFpn = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return whOpod5n6fh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			whOpod5n6fh = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return EOrpofG9haN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EOrpofG9haN = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return hxhpoDYveeW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hxhpoDYveeW = value;
		}
	}

	internal virtual CheckBox CKFiacao
	{
		[CompilerGenerated]
		get
		{
			return NLopovTjrnF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NLopovTjrnF = value;
		}
	}

	internal virtual GroupBox GBOpcoes
	{
		[CompilerGenerated]
		get
		{
			return KWbpo6jfZsm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KWbpo6jfZsm = value;
		}
	}

	internal virtual CheckBox CKPlaquetas
	{
		[CompilerGenerated]
		get
		{
			return ufHpotU4eGj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ufHpotU4eGj = value;
		}
	}

	internal virtual CheckBox CKCabosDWG
	{
		[CompilerGenerated]
		get
		{
			return d9VpojUM8wj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			d9VpojUM8wj = value;
		}
	}

	internal virtual RadioButton RBNaoImportarMateriais
	{
		[CompilerGenerated]
		get
		{
			return dDcpoLpxMrr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dDcpoLpxMrr = value;
		}
	}

	internal virtual RadioButton RBImportarMateriais
	{
		[CompilerGenerated]
		get
		{
			return rfkpowxpQ9n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rfkpowxpQ9n = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && N45phEsd9Sp != null)
			{
				N45phEsd9Sp.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void N1hphXVOYOP()
	{
		N45phEsd9Sp = new Container();
		FDqpBiUmZij(new ToolTip(N45phEsd9Sp));
		aHypBEW66iS(new FolderBrowserDialog());
		btSelNovoBanco = new Button();
		tbBancoCorrente = new TextBox();
		lbBancoCorrente = new Label();
		tbBancoImportado = new TextBox();
		lbBancoImportado = new Label();
		dgPnParaMigrar = new DataGridView();
		dgDWGOriginal = new DataGridView();
		tbCaminho = new TextBox();
		btMigrarosPaineis = new Button();
		btSelDirNovosDocumentos = new Button();
		dgDWGNovo = new DataGridView();
		btAdicionaDWG = new Button();
		lbDestino = new Label();
		lbSufixoNome = new Label();
		tbComplementoNome = new TextBox();
		ProgressBar1 = new ProgressBar();
		Label1 = new Label();
		Label2 = new Label();
		Label3 = new Label();
		CKFiacao = new CheckBox();
		GBOpcoes = new GroupBox();
		RBNaoImportarMateriais = new RadioButton();
		RBImportarMateriais = new RadioButton();
		CKPlaquetas = new CheckBox();
		CKCabosDWG = new CheckBox();
		((ISupportInitialize)dgPnParaMigrar).BeginInit();
		((ISupportInitialize)dgDWGOriginal).BeginInit();
		((ISupportInitialize)dgDWGNovo).BeginInit();
		GBOpcoes.SuspendLayout();
		SuspendLayout();
		btSelNovoBanco.FlatStyle = FlatStyle.Flat;
		btSelNovoBanco.ForeColor = SystemColors.Control;
		btSelNovoBanco.Image = Resources.Database_32;
		btSelNovoBanco.Location = new Point(735, 58);
		btSelNovoBanco.Name = "btSelNovoBanco";
		btSelNovoBanco.Size = new Size(36, 36);
		btSelNovoBanco.TabIndex = 147;
		btSelNovoBanco.UseVisualStyleBackColor = true;
		tbBancoCorrente.BackColor = Color.Silver;
		tbBancoCorrente.Location = new Point(17, 32);
		tbBancoCorrente.Name = "tbBancoCorrente";
		tbBancoCorrente.Size = new Size(754, 20);
		tbBancoCorrente.TabIndex = 148;
		lbBancoCorrente.AutoSize = true;
		lbBancoCorrente.Location = new Point(15, 16);
		lbBancoCorrente.Name = "lbBancoCorrente";
		lbBancoCorrente.Size = new Size(86, 13);
		lbBancoCorrente.TabIndex = 150;
		lbBancoCorrente.Text = "lbBancoCorrente";
		tbBancoImportado.BackColor = Color.Silver;
		tbBancoImportado.Location = new Point(19, 71);
		tbBancoImportado.Name = "tbBancoImportado";
		tbBancoImportado.Size = new Size(711, 20);
		tbBancoImportado.TabIndex = 149;
		lbBancoImportado.AutoSize = true;
		lbBancoImportado.Location = new Point(17, 55);
		lbBancoImportado.Name = "lbBancoImportado";
		lbBancoImportado.Size = new Size(93, 13);
		lbBancoImportado.TabIndex = 151;
		lbBancoImportado.Text = "lbBancoImportado";
		dgPnParaMigrar.AllowDrop = true;
		dgPnParaMigrar.AllowUserToAddRows = false;
		dgPnParaMigrar.AllowUserToDeleteRows = false;
		dgPnParaMigrar.AllowUserToResizeRows = false;
		dgPnParaMigrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPnParaMigrar.BackgroundColor = Color.White;
		dgPnParaMigrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPnParaMigrar.Location = new Point(555, 211);
		dgPnParaMigrar.MultiSelect = false;
		dgPnParaMigrar.Name = "dgPnParaMigrar";
		dgPnParaMigrar.RowHeadersVisible = false;
		dgPnParaMigrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPnParaMigrar.Size = new Size(216, 296);
		dgPnParaMigrar.TabIndex = 183;
		dgDWGOriginal.AllowDrop = true;
		dgDWGOriginal.AllowUserToAddRows = false;
		dgDWGOriginal.AllowUserToDeleteRows = false;
		dgDWGOriginal.AllowUserToOrderColumns = true;
		dgDWGOriginal.AllowUserToResizeRows = false;
		dgDWGOriginal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgDWGOriginal.BackgroundColor = Color.White;
		dgDWGOriginal.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgDWGOriginal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWGOriginal.Location = new Point(20, 209);
		dgDWGOriginal.MultiSelect = false;
		dgDWGOriginal.Name = "dgDWGOriginal";
		dgDWGOriginal.ReadOnly = true;
		dgDWGOriginal.RowHeadersVisible = false;
		dgDWGOriginal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWGOriginal.Size = new Size(240, 298);
		dgDWGOriginal.TabIndex = 179;
		tbCaminho.BackColor = Color.Silver;
		tbCaminho.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCaminho.Location = new Point(151, 110);
		tbCaminho.Name = "tbCaminho";
		tbCaminho.Size = new Size(578, 20);
		tbCaminho.TabIndex = 148;
		btMigrarosPaineis.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btMigrarosPaineis.FlatStyle = FlatStyle.Flat;
		btMigrarosPaineis.ForeColor = SystemColors.Control;
		btMigrarosPaineis.Image = Resources.MigrarBD_32;
		btMigrarosPaineis.Location = new Point(731, 512);
		btMigrarosPaineis.Name = "btMigrarosPaineis";
		btMigrarosPaineis.Size = new Size(40, 40);
		btMigrarosPaineis.TabIndex = 150;
		btMigrarosPaineis.UseVisualStyleBackColor = true;
		btSelDirNovosDocumentos.FlatStyle = FlatStyle.Flat;
		btSelDirNovosDocumentos.ForeColor = SystemColors.Control;
		btSelDirNovosDocumentos.Image = Resources.Folder;
		btSelDirNovosDocumentos.Location = new Point(735, 100);
		btSelDirNovosDocumentos.Name = "btSelDirNovosDocumentos";
		btSelDirNovosDocumentos.Size = new Size(36, 36);
		btSelDirNovosDocumentos.TabIndex = 149;
		btSelDirNovosDocumentos.UseVisualStyleBackColor = true;
		dgDWGNovo.AllowDrop = true;
		dgDWGNovo.AllowUserToAddRows = false;
		dgDWGNovo.AllowUserToDeleteRows = false;
		dgDWGNovo.AllowUserToOrderColumns = true;
		dgDWGNovo.AllowUserToResizeRows = false;
		dgDWGNovo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgDWGNovo.BackgroundColor = Color.White;
		dgDWGNovo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgDWGNovo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWGNovo.Location = new Point(307, 211);
		dgDWGNovo.MultiSelect = false;
		dgDWGNovo.Name = "dgDWGNovo";
		dgDWGNovo.ReadOnly = true;
		dgDWGNovo.RowHeadersVisible = false;
		dgDWGNovo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWGNovo.Size = new Size(240, 296);
		dgDWGNovo.TabIndex = 184;
		btAdicionaDWG.Anchor = AnchorStyles.Left;
		btAdicionaDWG.FlatStyle = FlatStyle.Flat;
		btAdicionaDWG.ForeColor = SystemColors.Control;
		btAdicionaDWG.Image = Resources.Adiciona_32;
		btAdicionaDWG.Location = new Point(265, 328);
		btAdicionaDWG.Name = "btAdicionaDWG";
		btAdicionaDWG.Size = new Size(36, 36);
		btAdicionaDWG.TabIndex = 185;
		btAdicionaDWG.UseVisualStyleBackColor = true;
		lbDestino.AutoSize = true;
		lbDestino.Location = new Point(148, 94);
		lbDestino.Name = "lbDestino";
		lbDestino.Size = new Size(51, 13);
		lbDestino.TabIndex = 186;
		lbDestino.Text = "lbDestino";
		lbSufixoNome.AutoSize = true;
		lbSufixoNome.Location = new Point(17, 94);
		lbSufixoNome.Name = "lbSufixoNome";
		lbSufixoNome.Size = new Size(72, 13);
		lbSufixoNome.TabIndex = 188;
		lbSufixoNome.Text = "lbSufixoNome";
		tbComplementoNome.BackColor = Color.White;
		tbComplementoNome.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbComplementoNome.Location = new Point(20, 110);
		tbComplementoNome.Name = "tbComplementoNome";
		tbComplementoNome.Size = new Size(125, 20);
		tbComplementoNome.TabIndex = 187;
		tbComplementoNome.TextAlign = HorizontalAlignment.Center;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ProgressBar1.Location = new Point(20, 522);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(710, 24);
		ProgressBar1.TabIndex = 189;
		Label1.AutoSize = true;
		Label1.Location = new Point(17, 195);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 190;
		Label1.Text = "Label1";
		Label2.AutoSize = true;
		Label2.Location = new Point(304, 195);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 191;
		Label2.Text = "Label2";
		Label3.AutoSize = true;
		Label3.Location = new Point(552, 195);
		Label3.Name = "Label3";
		Label3.Size = new Size(39, 13);
		Label3.TabIndex = 192;
		Label3.Text = "Label3";
		CKFiacao.AutoSize = true;
		CKFiacao.Checked = true;
		CKFiacao.CheckState = CheckState.Checked;
		CKFiacao.Location = new Point(6, 19);
		CKFiacao.Name = "CKFiacao";
		CKFiacao.Size = new Size(122, 17);
		CKFiacao.TabIndex = 193;
		CKFiacao.Text = "ckFiacao Compilada";
		CKFiacao.UseVisualStyleBackColor = true;
		GBOpcoes.Controls.Add(RBNaoImportarMateriais);
		GBOpcoes.Controls.Add(RBImportarMateriais);
		GBOpcoes.Controls.Add(CKPlaquetas);
		GBOpcoes.Controls.Add(CKCabosDWG);
		GBOpcoes.Controls.Add(CKFiacao);
		GBOpcoes.Location = new Point(20, 141);
		GBOpcoes.Name = "GBOpcoes";
		GBOpcoes.Size = new Size(751, 51);
		GBOpcoes.TabIndex = 194;
		GBOpcoes.TabStop = false;
		GBOpcoes.Text = "GroupBox1";
		RBNaoImportarMateriais.AutoSize = true;
		RBNaoImportarMateriais.Location = new Point(462, 10);
		RBNaoImportarMateriais.Name = "RBNaoImportarMateriais";
		RBNaoImportarMateriais.Size = new Size(207, 17);
		RBNaoImportarMateriais.TabIndex = 201;
		RBNaoImportarMateriais.TabStop = true;
		RBNaoImportarMateriais.Text = "Importar Materiais e alterar códigos LM";
		RBNaoImportarMateriais.UseVisualStyleBackColor = true;
		RBImportarMateriais.AutoSize = true;
		RBImportarMateriais.Location = new Point(462, 29);
		RBImportarMateriais.Name = "RBImportarMateriais";
		RBImportarMateriais.Size = new Size(244, 17);
		RBImportarMateriais.TabIndex = 200;
		RBImportarMateriais.TabStop = true;
		RBImportarMateriais.Text = "Não importar Materiais e preservar códigos LM";
		RBImportarMateriais.UseVisualStyleBackColor = true;
		CKPlaquetas.AutoSize = true;
		CKPlaquetas.Checked = true;
		CKPlaquetas.CheckState = CheckState.Checked;
		CKPlaquetas.Location = new Point(176, 19);
		CKPlaquetas.Name = "CKPlaquetas";
		CKPlaquetas.Size = new Size(85, 17);
		CKPlaquetas.TabIndex = 197;
		CKPlaquetas.Text = "ckPlaquetas";
		CKPlaquetas.UseVisualStyleBackColor = true;
		CKCabosDWG.AutoSize = true;
		CKCabosDWG.Checked = true;
		CKCabosDWG.CheckState = CheckState.Checked;
		CKCabosDWG.Location = new Point(301, 19);
		CKCabosDWG.Name = "CKCabosDWG";
		CKCabosDWG.Size = new Size(113, 17);
		CKCabosDWG.TabIndex = 194;
		CKCabosDWG.Text = "ckCabos do DWG";
		CKCabosDWG.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(784, 561);
		Controls.Add(GBOpcoes);
		Controls.Add(tbComplementoNome);
		Controls.Add(ProgressBar1);
		Controls.Add(lbSufixoNome);
		Controls.Add(btAdicionaDWG);
		Controls.Add(dgDWGNovo);
		Controls.Add(dgPnParaMigrar);
		Controls.Add(btMigrarosPaineis);
		Controls.Add(dgDWGOriginal);
		Controls.Add(tbCaminho);
		Controls.Add(btSelDirNovosDocumentos);
		Controls.Add(btSelNovoBanco);
		Controls.Add(tbBancoImportado);
		Controls.Add(lbBancoImportado);
		Controls.Add(tbBancoCorrente);
		Controls.Add(lbBancoCorrente);
		Controls.Add(Label1);
		Controls.Add(Label2);
		Controls.Add(Label3);
		Controls.Add(lbDestino);
		MaximizeBox = false;
		MaximumSize = new Size(800, 600);
		MinimumSize = new Size(800, 600);
		Name = "frmImportarProjetos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmImportar Projetos";
		((ISupportInitialize)dgPnParaMigrar).EndInit();
		((ISupportInitialize)dgDWGOriginal).EndInit();
		((ISupportInitialize)dgDWGNovo).EndInit();
		GBOpcoes.ResumeLayout(performLayout: false);
		GBOpcoes.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return FxLphZh8B7C;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		FxLphZh8B7C = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return wsYphijDghV;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		wsYphijDghV = WithEventsValue;
	}

	public frmImportarProjetos()
	{
		A8bpox0W2ho = new DataGridViewCellStyle();
		D2ZpobdKhgj = new DataGridViewCellStyle();
		yjZpoMe77dI = new DataGridViewCellStyle();
		rQjpoOD4lak = new DataGridViewCellStyle();
		YlQpoKpILGj = "";
		ddJpoexXETZ = "";
		hEFpo1x0TMm = new List<int>();
		kxtpolpfkGy = new List<int>();
		V32po0lyUGE = new List<string>();
		uuWpoRv0jRO = 1;
		N8cpomA9e8L = new List<int>();
		PplpoAsDtxZ = DeclaracoesGeral.Conf.DirProjeto;
		uohposIOrRR = 1;
		checked
		{
			try
			{
				if (Geral.ExisteForm("frmImportarProjetos") || !clsAuxiliar.BancoValido())
				{
					return;
				}
				N1hphXVOYOP();
				YlQpoKpILGj = DeclaracoesGeral.Conf.DirProjeto.ToString();
				tbBancoCorrente.Text = YlQpoKpILGj;
				M8spoFSYuUY = new clsImportarProjetos.mExpo[1];
				QVtpoPas4ni = new clsImportarProjetos.mAtt[1];
				DeclaracoesGeral._uscPagina.Quantidade = 7;
				DeclaracoesGeral._uscPagina.pbIniciar();
				cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
				try
				{
					cDadosAccessImportarProj2.CarregaCabosImpProj(ref zGwpo8dyWwX, bUso: false);
					DeclaracoesGeral._uscPagina.pbPasso();
					cDadosAccessImportarProj2.CarregaEquipImpProj(ref fZMpoImMwjU);
					DeclaracoesGeral._uscPagina.pbPasso();
					cDadosAccessImportarProj2.CarregaDWGImpProj(ref lYqpoquxcnc);
					DeclaracoesGeral._uscPagina.pbPasso();
					cDadosAccessImportarProj2.CarregaExportadosImpProj(ref M8spoFSYuUY, ref QVtpoPas4ni);
					DeclaracoesGeral._uscPagina.pbPasso();
					cDadosAccessImportarProj2.CarregaTodaLMDoImpProj(ref DwGpoU1nnoe);
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				finally
				{
					cDadosAccessImportarProj2.fechaConexao();
				}
				A8bpox0W2ho.BackColor = Color.LightGreen;
				D2ZpobdKhgj.BackColor = Color.LightCoral;
				yjZpoMe77dI.BackColor = Color.LightYellow;
				rQjpoOD4lak.BackColor = Color.White;
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 598]);
				tbComplementoNome.Text = "-ORI";
				Application.ShowModelessDialog((Form)this);
				lbBancoCorrente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 107]);
				lbBancoImportado.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1356]);
				lbDestino.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1357]);
				lbSufixoNome.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 854]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1364]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1359]);
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]);
				GBOpcoes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1762]);
				CKFiacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1763]);
				CKPlaquetas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1764]);
				RBImportarMateriais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1765]);
				RBNaoImportarMateriais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1774]);
				CKCabosDWG.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1766]);
				RBNaoImportarMateriais.Checked = true;
				btSelDirNovosDocumentos.Enabled = false;
				btAdicionaDWG.Enabled = false;
				btMigrarosPaineis.Enabled = false;
				uuWpoRv0jRO = 1;
				DxbpognKNEw = new clsImportarProjetos.mTrocaImportados[1];
				DeclaracoesGeral._uscPagina.pbPasso();
				int num = Information.UBound(M8spoFSYuUY);
				for (int i = 1; i <= num; i++)
				{
					if (uuWpoRv0jRO <= M8spoFSYuUY[i].Codigo)
					{
						uuWpoRv0jRO = M8spoFSYuUY[i].Codigo + 1;
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				DeclaracoesGeral._uscPagina.pbFim();
				cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
				uohposIOrRR = cDadosAccessPaineis2.ProximoIndicePainel();
				cDadosAccessPaineis2.fechaConexao();
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void i3GphUNEmv3(object P_0, EventArgs P_1)
	{
		try
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 237]);
			if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "A", TextCompare: true) != 0)
			{
				if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "S", TextCompare: true) == 0)
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
			tbBancoImportado.Text = "";
			tbCaminho.Text = "";
			dgDWGNovo.Rows.Clear();
			dgDWGNovo.Columns.Clear();
			dgDWGOriginal.Rows.Clear();
			dgDWGOriginal.Columns.Clear();
			dgPnParaMigrar.Rows.Clear();
			dgPnParaMigrar.Columns.Clear();
			if (!openFileDialog.ShowDialog().Value)
			{
				ddJpoexXETZ = "";
				tbBancoImportado.Text = "";
				btMigrarosPaineis.Enabled = false;
				return;
			}
			ddJpoexXETZ = openFileDialog.FileName;
			tbBancoImportado.Text = ddJpoexXETZ;
			btSelDirNovosDocumentos.Enabled = true;
			if (Operators.CompareString(tbBancoCorrente.Text, tbBancoImportado.Text, TextCompare: true) == 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1767]));
				tbBancoImportado.Text = "";
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

	private void yp8phyAmvGi()
	{
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = dgDWGOriginal.RowCount - 1;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num = dgDWGOriginal.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				dgDWGOriginal.Rows[i].Cells[1].Style = A8bpox0W2ho;
				dgDWGOriginal.Rows[i].Cells[4].Style = A8bpox0W2ho;
				int num2 = Information.UBound(lYqpoquxcnc);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDWGOriginal.Rows[i].Cells[1].Value, lYqpoquxcnc[j].sNome, TextCompare: true))
					{
						dgDWGOriginal.Rows[i].Cells[1].Style = D2ZpobdKhgj;
						dgDWGOriginal.Rows[i].Cells[4].Style = D2ZpobdKhgj;
					}
				}
				string path = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgDWGOriginal.Rows[i].Cells[2].Value, dgDWGOriginal.Rows[i].Cells[1].Value), ".dwg"));
				if (!File.Exists(path) | !File.Exists(path))
				{
					dgDWGOriginal.Rows[i].Cells[1].Style = D2ZpobdKhgj;
					dgDWGOriginal.Rows[i].Cells[4].Style = D2ZpobdKhgj;
				}
				ProgressBar1.PerformStep();
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	private void rNsphgJwi82(string P_0, int P_1, string P_2, string P_3, string P_4, DateTime P_5)
	{
		cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
		cDadosAccessPaineis2.AdicionaPainel("Paineis", P_1, P_2, P_3, P_4, P_5);
		cDadosAccessPaineis2.fechaConexao();
	}

	public void VerificaCabos()
	{
		checked
		{
			int num = dgDWGNovo.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				hEFpo1x0TMm.Add(Conversions.ToInteger(dgDWGNovo.Rows[i].Cells[0].Value));
			}
			if (hEFpo1x0TMm.Count > 0)
			{
				CarregaDGCabos(zGwpo8dyWwX);
			}
		}
	}

	public void CarregaDGPainel(ref DataGridView dg, clsImportarProjetos.mEquip[] mPainel)
	{
		formataDGPainel(ref dg);
		try
		{
			if (Information.UBound(mPainel) > 0)
			{
				int num = Information.UBound(mPainel);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dg.Rows.Add(Conversions.ToString(mPainel[i].iPainel), mPainel[i].sPainel, Conversions.ToString(mPainel[i].iPainel), mPainel[i].sPainel);
				}
				DataGridViewColumn dataGridViewColumn = dg.Columns[0];
				dg.Sort(dataGridViewColumn, ListSortDirection.Ascending);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		AtualizaDGPainel(ref dg);
	}

	public void formataDGPainel(ref DataGridView dg)
	{
		try
		{
			dg.Rows.Clear();
			dg.Columns.Clear();
			dg.Columns.Add("Indice", "#");
			dg.Columns.Add("Equipamento Copia", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
			dg.Columns.Add("Indice", "#2");
			dg.Columns.Add("Equipamento Original", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 626], "2")));
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

	public void AtualizaDGPainel(ref DataGridView dg)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double num = dg.Width - 21;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
					{
						num = dg.Width - 4;
					}
					dg.Columns[0].Width = (int)Math.Round(num * 0.2);
					dg.Columns[0].Visible = true;
					dg.Columns[1].Width = (int)Math.Round(num * 0.8);
					dg.Columns[1].Visible = true;
					dg.Columns[2].Width = 0;
					dg.Columns[2].Visible = false;
					dg.Columns[3].Width = 0;
					dg.Columns[3].Visible = false;
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

	public void formataDGDWG(ref DataGridView dg)
	{
		try
		{
			dg.Rows.Clear();
			dg.Columns.Clear();
			dg.Columns.Add("DWG", "");
			dg.Columns.Add(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 109]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 109]));
			dg.Columns.Add("Diretório", "Diretório");
			dg.Columns.Add("DWGOri", "DWGOri");
			dg.Columns.Add("ArquivoOri", "");
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

	public void CarregaDGDWG(ref DataGridView dg, clsImportarProjetos.mDWG[] mDWG, bool bCopia)
	{
		formataDGDWG(ref dg);
		checked
		{
			try
			{
				if (Information.UBound(mDWG) <= 0)
				{
					dg.Rows.Clear();
					dg.Columns.Clear();
				}
				else
				{
					int num = Information.UBound(mDWG);
					for (int i = 1; i <= num; i++)
					{
						dg.Rows.Add(mDWG[i].iDWG, mDWG[i].sNome, mDWG[i].sCaminho, "");
						int index = dg.RowCount - 1;
						dg.Rows[index].Cells[1].Style = D2ZpobdKhgj;
						dg.Rows[index].Cells[4].Style = D2ZpobdKhgj;
						if (dg.RowCount < 1)
						{
							AtualizaDGDWG(ref dg, bCopia);
						}
					}
					DataGridViewColumn dataGridViewColumn = dg.Columns[0];
					dg.Sort(dataGridViewColumn, ListSortDirection.Ascending);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			AtualizaDGDWG(ref dg, bCopia);
		}
	}

	public void AtualizaDGDWG(ref DataGridView dg, bool bCopia)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double num = 0.0;
					if (bCopia)
					{
						num = 20.0;
					}
					double a = (double)(dg.Width - 21) - num;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
					{
						a = (double)(dg.Width - 4) - num;
					}
					dg.Columns[0].Width = 0;
					dg.Columns[0].Visible = false;
					dg.Columns[1].Width = (int)Math.Round(a);
					dg.Columns[1].Visible = true;
					dg.Columns[2].Width = 0;
					dg.Columns[2].Visible = false;
					dg.Columns[3].Width = 0;
					dg.Columns[3].Visible = false;
					dg.Columns[4].Width = 0;
					dg.Columns[4].Visible = false;
					if (bCopia)
					{
						dg.Columns[4].Width = (int)Math.Round(num);
						dg.Columns[4].Visible = true;
					}
					dg.MultiSelect = false;
				}
				else
				{
					dg.Rows.Clear();
					dg.Columns.Clear();
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

	public void formataDGCabos(ref DataGridView dg)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				dg.Columns.Add("DWG", "");
				dg.Columns.Add("Cabos", "Cabos");
				dg.Columns.Add("DWGOri", "");
				dg.Columns.Add("CabosOri", "CabosOri");
				int num = dg.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void CarregaDGCabos(clsImportarProjetos.mCabos[] mCabos)
	{
		try
		{
			if (Information.UBound(mCabos) > 0)
			{
				int num = Information.UBound(mCabos);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					V32po0lyUGE.Add(mCabos[i].sNomeCabo);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void TbiphADk8re(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bSuspenderEvento = true;
		dgDWGNovo.Rows.Clear();
		dgDWGNovo.Columns.Clear();
		dgDWGOriginal.Rows.Clear();
		dgDWGOriginal.Columns.Clear();
		dgPnParaMigrar.Rows.Clear();
		dgPnParaMigrar.Columns.Clear();
		ProgressBar1.Minimum = 0;
		checked
		{
			ProgressBar1.Maximum = 9 + dgDWGOriginal.RowCount;
			ProgressBar1.Value = 0;
			ProgressBar1.Step = 1;
			I8spBuIa499().Description = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1360]);
			I8spBuIa499().RootFolder = Environment.SpecialFolder.MyComputer;
			I8spBuIa499().ShowNewFolderButton = false;
			if (I8spBuIa499().ShowDialog() != DialogResult.OK)
			{
				btAdicionaDWG.Enabled = false;
				return;
			}
			tbCaminho.Text = I8spBuIa499().SelectedPath + "\\";
			tbCaminho.Text = tbCaminho.Text.Replace("\\\\", "\\");
			ProgressBar1.PerformStep();
			M8spoFSYuUY = new clsImportarProjetos.mExpo[1];
			QVtpoPas4ni = new clsImportarProjetos.mAtt[1];
			uuWpoRv0jRO = 1;
			wnPpo7Hvhxx = new clsImportarProjetos.mEquip[1];
			t4tpoarINgG = new clsImportarProjetos.mDWG[1];
			lx8poNgxqVs = new clsImportarProjetos.mCabos[1];
			optpoQqHhxA = new clsImportarProjetos.mExpo[1];
			b3UpocWnVp7 = new clsImportarProjetos.mAtt[1];
			heupo5nJegp = new clsImportarProjetos.mTrocaCabos[1];
			uPjponugNjK = new clsImportarProjetos.mIndiceTrocaDWG[1];
			XTZpo2asTNH = new clsImportarProjetos.mIndiceTrocaPN[1];
			t49po37Qk0j = new clsImportarProjetos.mTrocaImportados[1];
			DeclaracoesGeral.Conf.DirProjeto = ddJpoexXETZ;
			ACorrecaoBD.CorrigeBD();
			ProgressBar1.PerformStep();
			Correcao.CorrecaoCabosNothing();
			ProgressBar1.PerformStep();
			cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
			int num = cDadosAccessPaineis2.ProximoIndicePainel();
			if (num > uohposIOrRR)
			{
				uohposIOrRR = num;
			}
			cDadosAccessPaineis2.fechaConexao();
			cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
			try
			{
				lx8poNgxqVs = new clsImportarProjetos.mCabos[1];
				wnPpo7Hvhxx = new clsImportarProjetos.mEquip[1];
				t4tpoarINgG = new clsImportarProjetos.mDWG[1];
				optpoQqHhxA = new clsImportarProjetos.mExpo[1];
				b3UpocWnVp7 = new clsImportarProjetos.mAtt[1];
				cDadosAccessImportarProj2.CarregaCabosImpProj(ref lx8poNgxqVs, bUso: true);
				ProgressBar1.PerformStep();
				cDadosAccessImportarProj2.CarregaEquipImpProj(ref wnPpo7Hvhxx);
				ProgressBar1.PerformStep();
				cDadosAccessImportarProj2.CarregaDWGImpProj(ref t4tpoarINgG);
				ProgressBar1.PerformStep();
				cDadosAccessImportarProj2.CarregaExportadosImpProj(ref optpoQqHhxA, ref b3UpocWnVp7);
				ProgressBar1.PerformStep();
				cDadosAccessImportarProj2.CarregaTodaLMDoImpProj(ref l7tpoXyie98);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				cDadosAccessImportarProj2.fechaConexao();
			}
			ProgressBar1.Increment(1);
			DataGridView dg = dgDWGOriginal;
			CarregaDGDWG(ref dg, t4tpoarINgG, bCopia: false);
			dgDWGOriginal = dg;
			ProgressBar1.PerformStep();
			DeclaracoesGeral.Conf.DirProjeto = PplpoAsDtxZ;
			if (Operators.CompareString(YlQpoKpILGj, ddJpoexXETZ, TextCompare: true) == 0)
			{
				btMigrarosPaineis.Enabled = false;
			}
			if (!File.Exists(YlQpoKpILGj) | !File.Exists(ddJpoexXETZ))
			{
				btMigrarosPaineis.Enabled = false;
			}
			ProgressBar1.PerformStep();
			yp8phyAmvGi();
			ProgressBar1.Value = 0;
			int num2 = dgDWGOriginal.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				dgDWGOriginal.Rows[i].Selected = false;
				btAdicionaDWG.Enabled = true;
			}
			DeclaracoesGeral.bSuspenderEvento = false;
		}
	}

	private int XiUphsSUqgF(int P_0)
	{
		int result = P_0;
		if (!RBNaoImportarMateriais.Checked)
		{
			int num = Information.UBound(DxbpognKNEw);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (DxbpognKNEw[i].iIndice == P_0)
				{
					result = DxbpognKNEw[i].iIndiceNovo;
					break;
				}
			}
		}
		return result;
	}

	private void SRVphBhu9QY(object P_0, EventArgs P_1)
	{
		btMigrarosPaineis.Enabled = false;
		btAdicionaDWG.Enabled = false;
		dgDWGOriginal.Enabled = false;
		DeclaracoesGeral.bSuspenderEvento = true;
		object[,] array = new object[2, 1];
		clsImportarProjetos.mEquip[] array2 = new clsImportarProjetos.mEquip[1];
		ProgressBar1.Minimum = 0;
		ProgressBar1.Maximum = 5;
		ProgressBar1.Step = 1;
		ProgressBar1.Value = 0;
		ProgressBar1.PerformStep();
		bool flag = true;
		bool flag2 = false;
		bool flag3 = false;
		ProgressBar1.PerformStep();
		checked
		{
			int num = dgDWGOriginal.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				DataGridView dg;
				if (num2 <= num)
				{
					if (dgDWGOriginal.Rows[num2].Selected)
					{
						if (dgDWGOriginal.Rows[num2].Cells[1].Style.BackColor == Color.LightCoral)
						{
							break;
						}
						ProgressBar1.PerformStep();
						if (Operators.ConditionalCompareObjectEqual(dgDWGOriginal.Rows[num2].Cells[4].Value, "", TextCompare: true))
						{
							dgDWGOriginal.Rows[num2].Cells[4].Value = "=>";
							dg = dgDWGOriginal;
							AtualizaDGDWG(ref dg, bCopia: true);
							dgDWGOriginal = dg;
							try
							{
								int num3 = Information.UBound(lYqpoquxcnc);
								int num4 = 1;
								while (true)
								{
									if (num4 <= num3)
									{
										if (!Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dgDWGOriginal.Rows[num2].Cells[1].Value, tbComplementoNome.Text), lYqpoquxcnc[num4].sNome, TextCompare: true))
										{
											num4++;
											continue;
										}
										flag = false;
										Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 325]), MsgBoxStyle.Information);
										dgDWGOriginal.Rows[num2].Cells[4].Value = "";
										goto end_IL_009d;
									}
									if (flag)
									{
										string dwgFile = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgDWGOriginal.Rows[num2].Cells[2].Value, dgDWGOriginal.Rows[num2].Cells[1].Value), ".dwg"));
										object mPaineis = array;
										clsImportarProjetos.EncontraPaineisDoDesenho(dwgFile, ref mPaineis, wnPpo7Hvhxx, ref N8cpomA9e8L);
										array = (object[,])mPaineis;
										if (dgDWGNovo.RowCount == 0)
										{
											dg = dgDWGNovo;
											formataDGDWG(ref dg);
											dgDWGNovo = dg;
										}
										dgDWGNovo.Rows.Add(dgDWGOriginal.Rows[num2].Cells[0].Value, Operators.ConcatenateObject(dgDWGOriginal.Rows[num2].Cells[1].Value, tbComplementoNome.Text), dgDWGOriginal.Rows[num2].Cells[2].Value, dgDWGOriginal.Rows[num2].Cells[0].Value, dgDWGOriginal.Rows[num2].Cells[1].Value);
										dg = dgDWGNovo;
										AtualizaDGDWG(ref dg, bCopia: false);
										dgDWGNovo = dg;
									}
									break;
								}
								goto IL_0408;
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								ProjectData.ClearProjectError();
								goto IL_0408;
							}
						}
					}
					goto IL_00bf;
				}
				ProgressBar1.PerformStep();
				int num5 = dgPnParaMigrar.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					dgPnParaMigrar.Rows[i].Cells[0].Style = rQjpoOD4lak;
					dgPnParaMigrar[1, i].ErrorText = "";
					if (Operators.ConditionalCompareObjectEqual(dgPnParaMigrar.Rows[i].Cells[3].Value, "???", TextCompare: true))
					{
						dgPnParaMigrar[1, i].ErrorText = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1883]);
					}
				}
				int num6 = dgPnParaMigrar.Rows.Count - 1;
				for (int j = 0; j <= num6; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgPnParaMigrar.Rows[j].Cells[3].Value, "???", TextCompare: true))
					{
						dgPnParaMigrar.FirstDisplayedScrollingRowIndex = j;
						break;
					}
				}
				dg = dgPnParaMigrar;
				AtualizaDGPainel(ref dg);
				dgPnParaMigrar = dg;
				ProgressBar1.PerformStep();
				VerificaCabos();
				break;
				IL_00bf:
				num2++;
				continue;
				IL_0408:
				int num7 = Information.UBound(array, 2);
				for (int k = 1; k <= num7; k++)
				{
					array2 = (clsImportarProjetos.mEquip[])Utils.CopyArray(array2, new clsImportarProjetos.mEquip[k + 1]);
					array2[k].iPainel = Conversions.ToInteger(array[0, k]);
					array2[k].sPainel = Conversions.ToString(array[1, k]);
					if (!kxtpolpfkGy.Contains(Conversions.ToInteger(array[0, k])))
					{
						kxtpolpfkGy.Add(Conversions.ToInteger(array[0, k]));
					}
					if (Operators.ConditionalCompareObjectLess(uohposIOrRR, array[0, k], TextCompare: true))
					{
						uohposIOrRR = Conversions.ToInteger(Operators.AddObject(array[0, k], 1));
					}
				}
				int num8 = dgPnParaMigrar.RowCount - 1;
				for (int l = 0; l <= num8; l++)
				{
					if (Operators.ConditionalCompareObjectLessEqual(uohposIOrRR, dgPnParaMigrar.Rows[l].Cells[0].Value, TextCompare: true))
					{
						uohposIOrRR = Conversions.ToInteger(Operators.AddObject(dgPnParaMigrar.Rows[l].Cells[0].Value, 1));
					}
				}
				if (flag)
				{
					dg = dgDWGNovo;
					AtualizaDGDWG(ref dg, bCopia: false);
					dgDWGNovo = dg;
					dg = dgPnParaMigrar;
					AtualizaDGPainel(ref dg);
					dgPnParaMigrar = dg;
					int num9 = Information.UBound(array2);
					for (int m = 1; m <= num9; m++)
					{
						flag = true;
						flag2 = false;
						flag3 = false;
						int num10 = dgPnParaMigrar.RowCount - 1;
						int num11 = 0;
						while (true)
						{
							if (num11 <= num10)
							{
								if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dgPnParaMigrar.Rows[num11].Cells[2].Value, array2[m].iPainel, TextCompare: true), Operators.CompareObjectEqual(dgPnParaMigrar.Rows[num11].Cells[3].Value, array2[m].sPainel, TextCompare: true))))
								{
									flag = false;
									flag3 = false;
									flag2 = false;
									break;
								}
								if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dgPnParaMigrar.Rows[num11].Cells[2].Value, array2[m].iPainel, TextCompare: true), Operators.CompareObjectEqual(dgPnParaMigrar.Rows[num11].Cells[3].Value, array2[m].sPainel, TextCompare: true))))
								{
									if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dgPnParaMigrar.Rows[num11].Cells[2].Value, array2[m].iPainel, TextCompare: true), Operators.CompareObjectNotEqual(dgPnParaMigrar.Rows[num11].Cells[3].Value, array2[m].sPainel, TextCompare: true))))
									{
										num11++;
										continue;
									}
									flag = false;
									flag3 = true;
								}
								else
								{
									flag = false;
									flag2 = true;
								}
							}
							int num12 = Information.UBound(fZMpoImMwjU);
							for (int n = 0; n <= num12; n++)
							{
								if (!((fZMpoImMwjU[n].iPainel == array2[m].iPainel) & (Operators.CompareString(fZMpoImMwjU[n].sPainel, array2[m].sPainel, TextCompare: true) == 0)))
								{
									if ((fZMpoImMwjU[n].iPainel != array2[m].iPainel) & (Operators.CompareString(fZMpoImMwjU[n].sPainel, array2[m].sPainel, TextCompare: true) == 0))
									{
										flag = false;
										flag2 = true;
									}
									if ((fZMpoImMwjU[n].iPainel == array2[m].iPainel) & (Operators.CompareString(fZMpoImMwjU[n].sPainel, array2[m].sPainel, TextCompare: true) != 0))
									{
										flag = false;
										flag3 = true;
									}
									continue;
								}
								flag = false;
								break;
							}
							if (!flag)
							{
								if (flag2 & flag3)
								{
									if (dgPnParaMigrar.RowCount == 0)
									{
										dg = dgPnParaMigrar;
										formataDGPainel(ref dg);
										dgPnParaMigrar = dg;
									}
									string text = array2[m].sPainel + "[1]";
									dgPnParaMigrar.Rows.Add(uohposIOrRR, text.ToString(), array2[m].iPainel, array2[m].sPainel.ToString());
									if (!kxtpolpfkGy.Contains(uohposIOrRR))
									{
										kxtpolpfkGy.Add(uohposIOrRR);
									}
									uohposIOrRR++;
								}
								if (flag2 & !flag3)
								{
									if (dgPnParaMigrar.RowCount == 0)
									{
										dg = dgPnParaMigrar;
										formataDGPainel(ref dg);
										dgPnParaMigrar = dg;
									}
									string text2 = array2[m].sPainel + "[1]";
									dgPnParaMigrar.Rows.Add(array2[m].iPainel, text2.ToString(), array2[m].iPainel, array2[m].sPainel.ToString());
									if (!kxtpolpfkGy.Contains(uohposIOrRR))
									{
										kxtpolpfkGy.Add(uohposIOrRR);
									}
									uohposIOrRR++;
								}
								if (!flag2 & flag3)
								{
									if (dgPnParaMigrar.RowCount == 0)
									{
										dg = dgPnParaMigrar;
										formataDGPainel(ref dg);
										dgPnParaMigrar = dg;
									}
									string sPainel = array2[m].sPainel;
									dgPnParaMigrar.Rows.Add(uohposIOrRR, sPainel.ToString(), array2[m].iPainel, array2[m].sPainel.ToString());
									if (!kxtpolpfkGy.Contains(uohposIOrRR))
									{
										kxtpolpfkGy.Add(uohposIOrRR);
									}
									uohposIOrRR++;
								}
							}
							else
							{
								if (dgPnParaMigrar.RowCount == 0)
								{
									dg = dgPnParaMigrar;
									formataDGPainel(ref dg);
									dgPnParaMigrar = dg;
								}
								dgPnParaMigrar.Rows.Add(array2[m].iPainel, array2[m].sPainel.ToString(), array2[m].iPainel, array2[m].sPainel.ToString());
							}
							if (dgPnParaMigrar.RowCount == 0)
							{
								dg = dgPnParaMigrar;
								AtualizaDGPainel(ref dg);
								dgPnParaMigrar = dg;
							}
							break;
						}
					}
				}
				goto IL_00bf;
				continue;
				end_IL_009d:
				break;
			}
			if (dgDWGNovo.Rows.Count > 0)
			{
				btMigrarosPaineis.Enabled = true;
			}
			ProgressBar1.Value = 0;
			DeclaracoesGeral.bSuspenderEvento = false;
			btAdicionaDWG.Enabled = true;
			dgDWGOriginal.Enabled = true;
		}
	}

	private void SnZphVTWC1e(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bSuspenderEvento = true;
		Conversions.ToInteger("1");
		int count = dgDWGNovo.Rows.Count;
		int rowCount = dgPnParaMigrar.RowCount;
		checked
		{
			int maximum = 4 + count + 3 + rowCount + 4 + count * rowCount + 4 * count + 2;
			ProgressBar1.Minimum = 0;
			ProgressBar1.Maximum = maximum;
			ProgressBar1.Value = 0;
			ProgressBar1.Step = 1;
			ProgressBar1.PerformStep();
			heupo5nJegp = new clsImportarProjetos.mTrocaCabos[1];
			ProgressBar1.PerformStep();
			int num = 0;
			uPjponugNjK = new clsImportarProjetos.mIndiceTrocaDWG[1];
			int num2 = 0;
			XTZpo2asTNH = new clsImportarProjetos.mIndiceTrocaPN[1];
			int num3 = 0;
			t49po37Qk0j = new clsImportarProjetos.mTrocaImportados[1];
			List<int> list = new List<int>();
			ProgressBar1.PerformStep();
			if (dgDWGNovo.Rows.Count <= 1)
			{
				optpoQqHhxA = new clsImportarProjetos.mExpo[1];
				b3UpocWnVp7 = new clsImportarProjetos.mAtt[1];
			}
			else
			{
				int num4 = Information.UBound(optpoQqHhxA);
				for (int i = 1; i <= num4; i++)
				{
					if (optpoQqHhxA[i].Codigo >= uuWpoRv0jRO)
					{
						uuWpoRv0jRO = optpoQqHhxA[i].Codigo + 1;
					}
				}
				int num5 = Information.UBound(optpoQqHhxA);
				for (int j = 1; j <= num5; j++)
				{
					if (!list.Contains(optpoQqHhxA[j].Codigo))
					{
						list.Add(optpoQqHhxA[j].Codigo);
						num3++;
						ref clsImportarProjetos.mTrocaImportados[] reference = ref t49po37Qk0j;
						reference = (clsImportarProjetos.mTrocaImportados[])Utils.CopyArray(reference, new clsImportarProjetos.mTrocaImportados[num3 + 1]);
						t49po37Qk0j[num3].iIndice = optpoQqHhxA[j].Codigo;
						uuWpoRv0jRO++;
						t49po37Qk0j[num3].iIndiceNovo = uuWpoRv0jRO;
					}
				}
				int num6 = Information.UBound(optpoQqHhxA);
				for (int k = 1; k <= num6; k++)
				{
					int num7 = Information.UBound(t49po37Qk0j);
					for (int l = 1; l <= num7; l++)
					{
						if (optpoQqHhxA[k].Codigo == t49po37Qk0j[l].iIndice)
						{
							optpoQqHhxA[k].Codigo = t49po37Qk0j[l].iIndiceNovo;
						}
					}
					optpoQqHhxA[k].Painel = clsImportarProjetos.BuscaNovoPainel(XTZpo2asTNH, optpoQqHhxA[k].Painel);
				}
			}
			ProgressBar1.PerformStep();
			int num8 = 0;
			clsImportarProjetos.mDWG[] array = new clsImportarProjetos.mDWG[1];
			List<string> lCabos = new List<string>();
			clsImportarProjetos.mTodosCabos[] array2 = null;
			array2 = new clsImportarProjetos.mTodosCabos[1];
			clsImportarProjetos.mTodasVeias[] array3 = null;
			array3 = new clsImportarProjetos.mTodasVeias[1];
			List<string> list2 = new List<string>();
			cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
			try
			{
				int num9 = 1;
				try
				{
					num9 = cDadosAccessImportarProj2.BuscaProximoIndiceDWG();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					cDadosAccessImportarProj2.fechaConexao();
					ProjectData.ClearProjectError();
				}
				finally
				{
				}
				int num10 = dgDWGNovo.Rows.Count - 1;
				for (int m = 0; m <= num10; m++)
				{
					num++;
					ref clsImportarProjetos.mIndiceTrocaDWG[] reference2 = ref uPjponugNjK;
					reference2 = (clsImportarProjetos.mIndiceTrocaDWG[])Utils.CopyArray(reference2, new clsImportarProjetos.mIndiceTrocaDWG[num + 1]);
					uPjponugNjK[num].iDWG = Conversions.ToInteger(dgDWGNovo.Rows[m].Cells[0].Value);
					uPjponugNjK[num].iDWG_Troca = num9;
					DeclaracoesGeral.arqAtivo.Indice = num9;
					num8++;
					array = (clsImportarProjetos.mDWG[])Utils.CopyArray(array, new clsImportarProjetos.mDWG[num8 + 1]);
					array[num8].iDWG = num9;
					array[num8].sCaminho = tbCaminho.Text;
					array[num8].sNome = Conversions.ToString(dgDWGNovo.Rows[m].Cells[1].Value);
					string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgDWGNovo.Rows[m].Cells[2].Value, dgDWGNovo.Rows[m].Cells[4].Value), ".dwg"));
					string text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(tbCaminho.Text, dgDWGNovo.Rows[m].Cells[1].Value), ".dwg"));
					if (File.Exists(text))
					{
						File.Copy(text, text2);
						list2.Add(text2);
					}
					ProgressBar1.PerformStep();
					num9++;
				}
				int num11 = Information.UBound(optpoQqHhxA);
				for (int n = 1; n <= num11; n++)
				{
					optpoQqHhxA[n].DWG = clsImportarProjetos.BuscaNovoDWG(uPjponugNjK, optpoQqHhxA[n].DWG);
					optpoQqHhxA[n].DWGDest = clsImportarProjetos.BuscaNovoDWG(uPjponugNjK, optpoQqHhxA[n].DWGDest);
					optpoQqHhxA[n].Codigo = clsImportarProjetos.BuscaNovoCodidoExportado(t49po37Qk0j, optpoQqHhxA[n].Codigo);
				}
				ProgressBar1.PerformStep();
				int num12 = Information.UBound(b3UpocWnVp7);
				for (int num13 = 1; num13 <= num12; num13++)
				{
					int num14 = Information.UBound(uPjponugNjK);
					for (int num15 = 1; num15 <= num14; num15++)
					{
						if (b3UpocWnVp7[num13].DWG == uPjponugNjK[num15].iDWG)
						{
							b3UpocWnVp7[num13].DWG = uPjponugNjK[num15].iDWG_Troca;
							break;
						}
					}
				}
				ProgressBar1.PerformStep();
				try
				{
					cDadosAccessImportarProj2.CadastraNovosDWGS(array);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				finally
				{
					cDadosAccessImportarProj2.fechaConexao();
				}
				ProgressBar1.PerformStep();
				string userName = Environment.UserName;
				string text3 = "";
				DeclaracoesGeral._uscPagina.Quantidade = dgPnParaMigrar.RowCount - 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num16 = dgPnParaMigrar.RowCount - 1;
				for (int num17 = 0; num17 <= num16; num17++)
				{
					if (num17 > 0)
					{
						num2++;
					}
					ref clsImportarProjetos.mIndiceTrocaPN[] xTZpo2asTNH = ref XTZpo2asTNH;
					xTZpo2asTNH = (clsImportarProjetos.mIndiceTrocaPN[])Utils.CopyArray(xTZpo2asTNH, new clsImportarProjetos.mIndiceTrocaPN[num2 + 1]);
					XTZpo2asTNH[num2].iPainelNovo = Conversions.ToInteger(dgPnParaMigrar.Rows[num17].Cells[0].Value);
					XTZpo2asTNH[num2].sPainelNovo = Conversions.ToString(dgPnParaMigrar.Rows[num17].Cells[1].Value);
					XTZpo2asTNH[num2].iPainel = Conversions.ToInteger(dgPnParaMigrar.Rows[num17].Cells[2].Value);
					XTZpo2asTNH[num2].sPainel = Conversions.ToString(dgPnParaMigrar.Rows[num17].Cells[3].Value);
					int num18 = Conversions.ToInteger(dgPnParaMigrar.Rows[num17].Cells[0].Value);
					string text4 = Conversions.ToString(dgPnParaMigrar.Rows[num17].Cells[1].Value);
					object value = DateTime.Now.ToString();
					cDadosAccess.carregaPainelDicionario();
					if (!((Dicionario.BuscaIndiceDoPainel(text4) == num18) | (Operators.CompareString(Dicionario.BuscaNomeDoPainel(num18), text4, TextCompare: true) == 0)))
					{
						rNsphgJwi82("Paineis", num18, text4, userName, text3, Conversions.ToDate(value));
					}
					ProgressBar1.PerformStep();
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DeclaracoesGeral._uscPagina.pbFim();
				ProgressBar1.PerformStep();
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
			if (CKCabosDWG.Checked)
			{
				string dirProjeto = DeclaracoesGeral.Conf.DirProjeto;
				DeclaracoesGeral.Conf.DirProjeto = tbBancoImportado.Text;
				cDadosAccessImportarProj cDadosAccessImportarProj3 = new cDadosAccessImportarProj();
				try
				{
					cDadosAccessImportarProj3.CarregaCabosCompletosImpProj(kxtpolpfkGy, hEFpo1x0TMm, ref heupo5nJegp, ref V32po0lyUGE, lCabos, ref array2, ref array3);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
				finally
				{
					ProgressBar1.PerformStep();
					cDadosAccessImportarProj3.fechaConexao();
					DeclaracoesGeral.Conf.DirProjeto = dirProjeto;
				}
				int num19 = Information.UBound(array2);
				for (int num20 = 1; num20 <= num19; num20++)
				{
					array2[num20].Pn1 = clsImportarProjetos.BuscaNovoPainel(XTZpo2asTNH, array2[num20].Pn1);
					array2[num20].Pn2 = clsImportarProjetos.BuscaNovoPainel(XTZpo2asTNH, array2[num20].Pn2);
				}
				int num21 = Information.UBound(array3);
				for (int num22 = 1; num22 <= num21; num22++)
				{
					if (array3[num22].Arquivo > 0)
					{
						array3[num22].Arquivo = clsImportarProjetos.BuscaNovoDWG(uPjponugNjK, array3[num22].Arquivo);
					}
				}
			}
			ProgressBar1.PerformStep();
			cDadosAccessImportarProj cDadosAccessImportarProj4 = new cDadosAccessImportarProj();
			try
			{
				if (Information.UBound(array2) > 0)
				{
					cDadosAccessImportarProj4.AdicionaNovosCabos(ref array2);
					cDadosAccessImportarProj4.AdicionaNovasVeias(ref array3);
				}
				if (dgDWGNovo.RowCount > 1)
				{
					cDadosAccessImportarProj4.AdicionaNovosImportados(ref optpoQqHhxA, ref b3UpocWnVp7);
				}
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				ProjectData.ClearProjectError();
			}
			finally
			{
				ProgressBar1.PerformStep();
				cDadosAccessImportarProj4.fechaConexao();
			}
			DeclaracoesGeral.bSuspenderEvento = false;
			int num23 = list2.Count - 1;
			for (int num24 = 0; num24 <= num23; num24++)
			{
				_ = list2[num24];
				sZ0phuqDAWG(list2[num24], RBImportarMateriais.Checked, CKPlaquetas.Checked, CKCabosDWG.Checked, RBNaoImportarMateriais.Checked);
			}
			Pagina.CarregaPaginas();
			Pagina.OrdenaMatrizPaginas();
			if (Information.UBound(DeclaracoesGeral.mPaginas, 2) > 0)
			{
				DeclaracoesGeral.ativo.Pagina = Pagina.LocalizaPaginaAtiva();
				Pagina.AtivaPagina(DeclaracoesGeral.ativo.Pagina);
				DeclaracoesGeral.ativo.Painel = 0;
				Comandos.GerenciadorPagina();
			}
			if (!RBNaoImportarMateriais.Checked && Information.UBound(RuYpoy4uu61) > 0)
			{
				cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
				int num25 = Information.UBound(RuYpoy4uu61);
				for (int num26 = 1; num26 <= num25; num26++)
				{
					if (N8cpomA9e8L.Contains(Conversions.ToInteger(RuYpoy4uu61[num26].Index)))
					{
						int num27 = XiUphsSUqgF(Conversions.ToInteger(RuYpoy4uu61[num26].Index));
						if (RBImportarMateriais.Checked && num27 > 0)
						{
							cDadosAccessMateriais2.AdicionaItemMaterial(num27, RuYpoy4uu61[num26].CodCli, RuYpoy4uu61[num26].sModelo, RuYpoy4uu61[num26].sFabricante, RuYpoy4uu61[num26].Desc, RuYpoy4uu61[num26].DescCompleta);
						}
					}
				}
				cDadosAccessMateriais2.fechaConexao();
			}
			ProgressBar1.PerformStep();
			if (CKFiacao.Checked)
			{
				migraCompilados(tbBancoCorrente.Text, tbBancoImportado.Text, uPjponugNjK, XTZpo2asTNH);
			}
			ProgressBar1.PerformStep();
			ProgressBar1.Value = 0;
			Close();
		}
	}

	public void migraCompilados(string sBancoCorrente, string sBancoImportado, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA)
	{
		try
		{
			DeclaracoesFiacao.structureRevisoes[] array = new DeclaracoesFiacao.structureRevisoes[1];
			array = new DeclaracoesFiacao.structureRevisoes[1];
			DeclaracoesGeral.Conf.DirProjeto = sBancoImportado;
			cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
			cDadosAccessFiacao2.CarregaMaioresRevisoesDwg(ref array);
			cDadosAccessFiacao2.fechaConexao();
			DataTable dt = new DataTable();
			DataTable dt2 = new DataTable();
			DataTable dt3 = new DataTable();
			DataTable dt4 = new DataTable();
			DataTable dt5 = new DataTable();
			DataTable dt6 = new DataTable();
			cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
			DeclaracoesGeral._uscPagina.Quantidade = 6;
			DeclaracoesGeral._uscPagina.pbIniciar();
			DeclaracoesGeral._uscPagina.pbPasso();
			cDadosAccessImportarProj2.LeBanco("SELECT Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo, Aplicacao, Orientacao, Criador, Data FROM Fiacao", ref dt);
			DeclaracoesGeral._uscPagina.pbPasso();
			cDadosAccessImportarProj2.LeBanco("SELECT Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, Ordem, Tipo, Pagina, bReserva, LM, Orientacao, BlocoLayout FROM Bornes4F", ref dt2);
			DeclaracoesGeral._uscPagina.pbPasso();
			cDadosAccessImportarProj2.LeBanco("SELECT Revisao, DWG, Painel, Circuito, Potencial FROM Circuitos4F", ref dt3);
			DeclaracoesGeral._uscPagina.pbPasso();
			cDadosAccessImportarProj2.LeBanco("SELECT Revisao, DWG, IndexModelo, NomeModelo, Terminal, TerminalNum, Orientacao FROM Contatos4F", ref dt4);
			DeclaracoesGeral._uscPagina.pbPasso();
			cDadosAccessImportarProj2.LeBanco("SELECT Revisao, DWG, Painel, Tag, Alternativo, Tipo, Handle, Pagina, BlocoTopografico, BlocoLayout, PosicaoNum, Ordem FROM Dispositivos4F", ref dt5);
			DeclaracoesGeral._uscPagina.pbPasso();
			cDadosAccessImportarProj2.LeBanco("SELECT Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, Tipo, Orientacao FROM Portas4F", ref dt6);
			DeclaracoesGeral._uscPagina.pbPasso();
			DeclaracoesGeral._uscPagina.pbFim();
			cDadosAccessImportarProj2.fechaConexao();
			DeclaracoesGeral.Conf.DirProjeto = sBancoCorrente;
			new AcessoAccess();
			cDadosAccessImportarProj cDadosAccessImportarProj3 = new cDadosAccessImportarProj();
			DeclaracoesGeral._uscPagina.Quantidade = checked(dt.Rows.Count + dt2.Rows.Count + dt3.Rows.Count + dt4.Rows.Count + dt5.Rows.Count + dt6.Rows.Count);
			DeclaracoesGeral._uscPagina.pbIniciar();
			long I = 0L;
			cDadosAccessImportarProj3.AdicionaItemFiacaosDT(dt, mIndiceTrocaDWG, iIndicePN_TROCA, ref I, array);
			cDadosAccessImportarProj3.AdicionaItemBornesDT(dt2, mIndiceTrocaDWG, iIndicePN_TROCA, ref I, array);
			cDadosAccessImportarProj3.AdicionaItemCircuitos4FDT(dt3, mIndiceTrocaDWG, iIndicePN_TROCA, ref I, array);
			cDadosAccessImportarProj3.AdicionaItemContatos4FDT(dt4, mIndiceTrocaDWG, iIndicePN_TROCA, ref I, array);
			cDadosAccessImportarProj3.AdicionaItemDispositivos4FDT(dt5, mIndiceTrocaDWG, iIndicePN_TROCA, ref I, array);
			cDadosAccessImportarProj3.AdicionaItemPortas4FDT(dt6, mIndiceTrocaDWG, iIndicePN_TROCA, ref I, array);
			DeclaracoesGeral._uscPagina.pbFim();
			cDadosAccessImportarProj3.fechaConexao();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DeclaracoesGeral.Conf.DirProjeto = sBancoCorrente;
			ProjectData.ClearProjectError();
		}
	}

	private void sZ0phuqDAWG(string P_0, bool P_1, bool P_2, bool P_3, bool P_4)
	{
		DeclaracoesGeral.bCancelarEventoTrocaDocumento = true;
		Document val = DocumentCollectionExtension.Open(Application.DocumentManager, P_0, false);
		checked
		{
			if (Caderno.ExisteFormato())
			{
				Geral.travaDWG(bTravar: false);
				int num = 0;
				int num2 = 0;
				XDataGeral.LerXDataConfiguracao();
				XDataGeral.LerXDataConfiguracao2();
				DeclaracoesGeral.ConfigCaderno configCaderno = default;
				DeclaracoesGeral.Conf.DirProjeto = tbBancoCorrente.Text;
				XDataGeral.GravarXDataConfiguracao();
				XDataGeral.GravarXDataConfiguracao2();
				Database database = val.Database;
				database.SaveAs(val.Name, true, (DwgVersion)31, database.SecurityParameters);
				Pagina.CarregaPaginas();
				Pagina.OrdenaMatrizPaginas();
				if (Information.UBound(DeclaracoesGeral.mPaginas, 2) > 0)
				{
					DeclaracoesGeral.ativo.Pagina = Pagina.LocalizaPaginaAtiva();
					Pagina.AtivaPagina(DeclaracoesGeral.ativo.Pagina);
					DeclaracoesGeral.ativo.Painel = 0;
					Comandos.GerenciadorPagina();
				}
				DeclaracoesGeral.bSuspenderEvento = true;
				ProgressBar1.PerformStep();
				Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				Declaracoes2.MModelosDeContatos[] array = null;
				array = new Declaracoes2.MModelosDeContatos[1];
				DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref array);
				if (P_4)
				{
					ProgressBar1.PerformStep();
				}
				else
				{
					new List<int>();
					int num3 = Information.UBound(DwGpoU1nnoe);
					for (int i = 1; i <= num3; i++)
					{
						if (Conversions.ToDouble(DwGpoU1nnoe[i].Index) != 0.0)
						{
							N8cpomA9e8L.Add(Conversions.ToInteger(DwGpoU1nnoe[i].Index));
						}
					}
					RuYpoy4uu61 = DwGpoU1nnoe;
					int num4 = Information.UBound(RuYpoy4uu61);
					int num5 = 0;
					int num6 = Information.UBound(l7tpoXyie98);
					for (int j = 1; j <= num6; j++)
					{
						if ((double)num5 < Conversions.ToDouble(l7tpoXyie98[j].Index))
						{
							num5 = Conversions.ToInteger(l7tpoXyie98[j].Index);
						}
					}
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(DwGpoU1nnoe);
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num7 = Information.UBound(l7tpoXyie98);
					for (int k = 1; k <= num7; k++)
					{
						num5++;
						ref clsImportarProjetos.mTrocaImportados[] dxbpognKNEw = ref DxbpognKNEw;
						dxbpognKNEw = (clsImportarProjetos.mTrocaImportados[])Utils.CopyArray(dxbpognKNEw, new clsImportarProjetos.mTrocaImportados[Information.UBound(DxbpognKNEw) + 1 + 1]);
						DxbpognKNEw[Information.UBound(DxbpognKNEw)].iIndice = Conversions.ToInteger(l7tpoXyie98[k].Index);
						DxbpognKNEw[Information.UBound(DxbpognKNEw)].iIndiceNovo = 0;
						if (P_1)
						{
							DxbpognKNEw[Information.UBound(DxbpognKNEw)].iIndiceNovo = num5;
						}
						num4++;
						ref cDadosLM.structureLMRelelatorio[] ruYpoy4uu = ref RuYpoy4uu61;
						ruYpoy4uu = (cDadosLM.structureLMRelelatorio[])Utils.CopyArray(ruYpoy4uu, new cDadosLM.structureLMRelelatorio[num4 + 1]);
						RuYpoy4uu61[num4] = l7tpoXyie98[k];
						RuYpoy4uu61[k].Index = Conversions.ToString(0);
						if (P_1)
						{
							RuYpoy4uu61[k].Index = Conversions.ToString(num5);
						}
					}
					int num8 = Information.UBound(array);
					for (int l = 1; l <= num8; l++)
					{
						if (!P_1)
						{
							array[l].iLM1 = 0;
							array[l].iLM2 = 0;
						}
						else
						{
							array[l].iLM1 = XiUphsSUqgF(array[l].iLM1);
							array[l].iLM2 = XiUphsSUqgF(array[l].iLM2);
						}
					}
					DicionarioContatos.GravaOsModelosDeDispositivosDeDicionario(ref array);
					ProgressBar1.PerformStep();
					Declaracoes2.MModeloDeMascara[] mModelo2 = new Declaracoes2.MModeloDeMascara[1];
					DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo2, bComplementarModelo: true);
					int num9 = Information.UBound(mModelo2);
					for (int m = 1; m <= num9; m++)
					{
						if (!P_1)
						{
							mModelo2[m].iLM1 = 0L;
							mModelo2[m].iLM2 = 0L;
						}
						else
						{
							mModelo2[m].iLM1 = XiUphsSUqgF((int)mModelo2[m].iLM1);
							mModelo2[m].iLM2 = XiUphsSUqgF((int)mModelo2[m].iLM2);
						}
					}
					DicionarioMascaras.GravaOsModelosDeMascara(mModelo2);
					DeclaracoesGeral._uscPagina.pbFim();
					if (!Information.IsNothing(DxbpognKNEw) && Information.UBound(DxbpognKNEw) > 0)
					{
						clsImportarProjetos.MudaLMdosBlocos(DxbpognKNEw, P_1);
					}
				}
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(XTZpo2asTNH);
				DeclaracoesGeral._uscPagina.pbIniciar();
				ProgressBar1.PerformStep();
				int num10 = Information.UBound(XTZpo2asTNH);
				for (int n = 0; n <= num10; n++)
				{
					if (XTZpo2asTNH[n].iPainel != XTZpo2asTNH[n].iPainelNovo)
					{
						num = XTZpo2asTNH[n].iPainel;
						num2 = XTZpo2asTNH[n].iPainelNovo;
						clsTrocaPainel.TrocaPainelDisp_P_M_C(num, num2);
						clsTrocaPainel.TrocaPainelLAYOUT(num, num2);
						clsTrocaPainel.TrocaPainelTOPO(num, num2);
						DeclaracoesEntidades.StructureLayout[] mTags = new DeclaracoesEntidades.StructureLayout[1];
						if (DicionarioLayout.LeDicLayout("P" + num, ref mTags))
						{
							DicionarioLayout.ApagaDicLayoutPainel("P", num.ToString());
							DicionarioLayout.gravaDicLayout("P" + num2, ref mTags);
						}
						DeclaracoesEntidades.StructureLayout[] mTags2 = new DeclaracoesEntidades.StructureLayout[1];
						if (DicionarioLayout.LeDicLayout("C" + num, ref mTags2))
						{
							DicionarioLayout.ApagaDicLayoutPainel("C", num.ToString());
							DicionarioLayout.gravaDicLayout("C" + num2, ref mTags2);
						}
						Declaracoes2.StructurePlaquetas[] mPlaquetas = new Declaracoes2.StructurePlaquetas[1];
						if (DicionarioPlaqueta.LeDicPlaquetas(num.ToString(), ref mPlaquetas))
						{
							DicionarioPlaqueta.ApagaDicPlaquetasPainel(num.ToString());
							DicionarioPlaqueta.gravaDicPlaqueta(num2.ToString(), ref mPlaquetas);
						}
						int num11 = Information.UBound(mModelo);
						for (int num12 = 1; num12 <= num11; num12++)
						{
							if (mModelo[num12].indexPainel == num)
							{
								mModelo[num12].indexPainel = num2;
								DicionarioReguas.GravaOsModelosDeRegua(mModelo);
								clsBornes.EditarOsBornesDasReguasSelecionada(mModelo, num12);
							}
						}
					}
					ProgressBar1.PerformStep();
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				if (!P_2)
				{
					Correcao.ApagaPlaquetas();
				}
				if (!P_3)
				{
					clsImportarProjetos.IndefineTodosAsVeiasDWG();
				}
				else if (Information.UBound(heupo5nJegp) > 0)
				{
					clsImportarProjetos.AtualizaNomeDasVeias(heupo5nJegp);
				}
				if (dgDWGNovo.RowCount > 1)
				{
					clsImportarProjetos.AualizaCodigoDWG_ExportadosImportados(uPjponugNjK, t49po37Qk0j);
				}
				ProgressBar1.PerformStep();
			}
			DocumentExtension.CloseAndSave(val, P_0);
			DeclaracoesGeral.bSuspenderEvento = false;
			DeclaracoesGeral.bCancelarEventoTrocaDocumento = false;
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}
}
