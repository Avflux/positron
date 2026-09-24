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
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmPlaquetas : Form
{
	private IContainer DsTp6g7hMQq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView oKwp6Av70OL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button kLIp6sWFfGE;

	[AccessedThroughProperty("btSalvar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button YQmp6Bf6QgH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPlaquetas")]
	[CompilerGenerated]
	private DataGridView D1rp6V8wmiu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserirTag")]
	private Button muop6uwiLIL;

	[AccessedThroughProperty("btInserirAlternativo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button cCxp6E5Egm1;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip haIp6ZxmAsB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPaste")]
	private Button IxCp6iZxba1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbLayout")]
	private CheckBox JIBp6SJMVgV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionaTexto")]
	private Button H3hp649OxQ5;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox sDDp6C094Ff;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox wqjp6Y3uEXl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbValorAdd")]
	private TextBox skdp6rny03a;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTExportaEX")]
	private Button BW8p69cdaoU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTImportaEX")]
	private Button SJWp6zCspmC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox w1CptWQDeCw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtEditar")]
	private Button bCFptpMyfIG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPara")]
	private TextBox khgptTV5dT9;

	[CompilerGenerated]
	[AccessedThroughProperty("lbPara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label m6optJqbnrh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDe")]
	[CompilerGenerated]
	private TextBox G9lpthSHu4T;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDe")]
	private Label iCYptoNyt1B;

	[CompilerGenerated]
	[AccessedThroughProperty("ckMod")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox xYUptGHlIyM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckDesc2")]
	[CompilerGenerated]
	private CheckBox FvSptHlSwF3;

	[CompilerGenerated]
	[AccessedThroughProperty("ckDesc3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox AxJptkkCo8N;

	[AccessedThroughProperty("ckDesc1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox tTPptd9EcWg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	[CompilerGenerated]
	private GroupBox SUyptfhlpaM;

	[AccessedThroughProperty("TBPlaquetaExtra")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox g0tptDyS6m9;

	[AccessedThroughProperty("BtEtiquetasExtras")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button Ct4ptvXchZV;

	[AccessedThroughProperty("TBStatus")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox K6Npt6ocNCK;

	private int ctVpttXc3gp;

	private bool f3Yptj3ocLq;

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return oKwp6Av70OL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oKwp6Av70OL = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return kLIp6sWFfGE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DN0p6NIpRYn;
			Button button = kLIp6sWFfGE;
			if (button != null)
			{
				button.Click -= value2;
			}
			kLIp6sWFfGE = value;
			button = kLIp6sWFfGE;
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
			return YQmp6Bf6QgH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fUnp6n1LIBh;
			Button button = YQmp6Bf6QgH;
			if (button != null)
			{
				button.Click -= value2;
			}
			YQmp6Bf6QgH = value;
			button = YQmp6Bf6QgH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPlaquetas
	{
		[CompilerGenerated]
		get
		{
			return D1rp6V8wmiu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = h5Pp63La2yf;
			DataGridViewCellEventHandler value3 = Tfep61xZMoV;
			DataGridView dataGridView = D1rp6V8wmiu;
			if (dataGridView != null)
			{
				dataGridView.KeyDown -= value2;
				dataGridView.CellValueChanged -= value3;
			}
			D1rp6V8wmiu = value;
			dataGridView = D1rp6V8wmiu;
			if (dataGridView != null)
			{
				dataGridView.KeyDown += value2;
				dataGridView.CellValueChanged += value3;
			}
		}
	}

	internal virtual Button btInserirTag
	{
		[CompilerGenerated]
		get
		{
			return muop6uwiLIL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cNvp6KNjqTu;
			Button button = muop6uwiLIL;
			if (button != null)
			{
				button.Click -= value2;
			}
			muop6uwiLIL = value;
			button = muop6uwiLIL;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btInserirAlternativo
	{
		[CompilerGenerated]
		get
		{
			return cCxp6E5Egm1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = z5yp6ei0L9U;
			Button button = cCxp6E5Egm1;
			if (button != null)
			{
				button.Click -= value2;
			}
			cCxp6E5Egm1 = value;
			button = cCxp6E5Egm1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPaste
	{
		[CompilerGenerated]
		get
		{
			return IxCp6iZxba1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GUgp62BHl1f;
			Button button = IxCp6iZxba1;
			if (button != null)
			{
				button.Click -= value2;
			}
			IxCp6iZxba1 = value;
			button = IxCp6iZxba1;
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
			return JIBp6SJMVgV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JIBp6SJMVgV = value;
		}
	}

	internal virtual Button btAdicionaTexto
	{
		[CompilerGenerated]
		get
		{
			return H3hp649OxQ5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hjDp600tH1Q;
			Button button = H3hp649OxQ5;
			if (button != null)
			{
				button.Click -= value2;
			}
			H3hp649OxQ5 = value;
			button = H3hp649OxQ5;
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
			return sDDp6C094Ff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sDDp6C094Ff = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return wqjp6Y3uEXl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wqjp6Y3uEXl = value;
		}
	}

	internal virtual TextBox tbValorAdd
	{
		[CompilerGenerated]
		get
		{
			return skdp6rny03a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			skdp6rny03a = value;
		}
	}

	internal virtual Button BTExportaEX
	{
		[CompilerGenerated]
		get
		{
			return BW8p69cdaoU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lS0p6XPoDjj;
			Button button = BW8p69cdaoU;
			if (button != null)
			{
				button.Click -= value2;
			}
			BW8p69cdaoU = value;
			button = BW8p69cdaoU;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTImportaEX
	{
		[CompilerGenerated]
		get
		{
			return SJWp6zCspmC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = t6np6U8GoDe;
			Button button = SJWp6zCspmC;
			if (button != null)
			{
				button.Click -= value2;
			}
			SJWp6zCspmC = value;
			button = SJWp6zCspmC;
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
			return w1CptWQDeCw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			w1CptWQDeCw = value;
		}
	}

	internal virtual Button BtEditar
	{
		[CompilerGenerated]
		get
		{
			return bCFptpMyfIG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qNpp6yqnA7C;
			Button button = bCFptpMyfIG;
			if (button != null)
			{
				button.Click -= value2;
			}
			bCFptpMyfIG = value;
			button = bCFptpMyfIG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbPara
	{
		[CompilerGenerated]
		get
		{
			return khgptTV5dT9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			khgptTV5dT9 = value;
		}
	}

	internal virtual Label lbPara
	{
		[CompilerGenerated]
		get
		{
			return m6optJqbnrh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m6optJqbnrh = value;
		}
	}

	internal virtual TextBox tbDe
	{
		[CompilerGenerated]
		get
		{
			return G9lpthSHu4T;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			G9lpthSHu4T = value;
		}
	}

	internal virtual Label lbDe
	{
		[CompilerGenerated]
		get
		{
			return iCYptoNyt1B;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iCYptoNyt1B = value;
		}
	}

	internal virtual CheckBox ckMod
	{
		[CompilerGenerated]
		get
		{
			return xYUptGHlIyM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xYUptGHlIyM = value;
		}
	}

	internal virtual CheckBox ckDesc2
	{
		[CompilerGenerated]
		get
		{
			return FvSptHlSwF3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FvSptHlSwF3 = value;
		}
	}

	internal virtual CheckBox ckDesc3
	{
		[CompilerGenerated]
		get
		{
			return AxJptkkCo8N;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AxJptkkCo8N = value;
		}
	}

	internal virtual CheckBox ckDesc1
	{
		[CompilerGenerated]
		get
		{
			return tTPptd9EcWg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tTPptd9EcWg = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return SUyptfhlpaM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SUyptfhlpaM = value;
		}
	}

	internal virtual TextBox TBPlaquetaExtra
	{
		[CompilerGenerated]
		get
		{
			return g0tptDyS6m9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			g0tptDyS6m9 = value;
		}
	}

	internal virtual Button BtEtiquetasExtras
	{
		[CompilerGenerated]
		get
		{
			return Ct4ptvXchZV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CZIp6RBhuy2;
			Button button = Ct4ptvXchZV;
			if (button != null)
			{
				button.Click -= value2;
			}
			Ct4ptvXchZV = value;
			button = Ct4ptvXchZV;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBStatus
	{
		[CompilerGenerated]
		get
		{
			return K6Npt6ocNCK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			K6Npt6ocNCK = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && DsTp6g7hMQq != null)
			{
				DsTp6g7hMQq.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void sfxp68hTwZp()
	{
		DsTp6g7hMQq = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPlaquetas));
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgEquip = new DataGridView();
		btPesquisar = new Button();
		btSalvar = new Button();
		dgPlaquetas = new DataGridView();
		btInserirTag = new Button();
		btInserirAlternativo = new Button();
		FDqpBiUmZij(new ToolTip(DsTp6g7hMQq));
		btPaste = new Button();
		cbLayout = new CheckBox();
		btAdicionaTexto = new Button();
		GroupBox1 = new GroupBox();
		GroupBox2 = new GroupBox();
		tbValorAdd = new TextBox();
		BTExportaEX = new Button();
		BTImportaEX = new Button();
		GroupBox3 = new GroupBox();
		ckMod = new CheckBox();
		ckDesc2 = new CheckBox();
		ckDesc3 = new CheckBox();
		ckDesc1 = new CheckBox();
		BtEditar = new Button();
		tbPara = new TextBox();
		tbDe = new TextBox();
		lbPara = new Label();
		lbDe = new Label();
		GroupBox5 = new GroupBox();
		TBPlaquetaExtra = new TextBox();
		BtEtiquetasExtras = new Button();
		TBStatus = new TextBox();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgPlaquetas).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox5.SuspendLayout();
		SuspendLayout();
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(14, 12);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(238, 315);
		dgEquip.TabIndex = 8;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(204, 333);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = (Image)componentResourceManager.GetObject("btSalvar.Image");
		btSalvar.Location = new Point(205, 543);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 43);
		btSalvar.TabIndex = 43;
		btSalvar.UseVisualStyleBackColor = true;
		dgPlaquetas.AllowUserToAddRows = false;
		dgPlaquetas.AllowUserToDeleteRows = false;
		dgPlaquetas.AllowUserToResizeRows = false;
		dgPlaquetas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPlaquetas.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgPlaquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgPlaquetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPlaquetas.Location = new Point(256, 12);
		dgPlaquetas.Name = "dgPlaquetas";
		dgPlaquetas.RowHeadersVisible = false;
		dgPlaquetas.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgPlaquetas.Size = new Size(667, 529);
		dgPlaquetas.TabIndex = 45;
		btInserirTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btInserirTag.FlatStyle = FlatStyle.Flat;
		btInserirTag.ForeColor = SystemColors.Control;
		btInserirTag.Image = (Image)componentResourceManager.GetObject("btInserirTag.Image");
		btInserirTag.Location = new Point(162, 544);
		btInserirTag.Name = "btInserirTag";
		btInserirTag.Size = new Size(40, 42);
		btInserirTag.TabIndex = 47;
		btInserirTag.UseVisualStyleBackColor = true;
		btInserirAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btInserirAlternativo.FlatStyle = FlatStyle.Flat;
		btInserirAlternativo.ForeColor = SystemColors.Control;
		btInserirAlternativo.Image = (Image)componentResourceManager.GetObject("btInserirAlternativo.Image");
		btInserirAlternativo.Location = new Point(118, 544);
		btInserirAlternativo.Name = "btInserirAlternativo";
		btInserirAlternativo.Size = new Size(40, 42);
		btInserirAlternativo.TabIndex = 48;
		btInserirAlternativo.UseVisualStyleBackColor = true;
		btPaste.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPaste.FlatStyle = FlatStyle.Flat;
		btPaste.ForeColor = SystemColors.Control;
		btPaste.Image = Resources.Paste_32;
		btPaste.Location = new Point(12, 544);
		btPaste.Name = "btPaste";
		btPaste.Size = new Size(40, 42);
		btPaste.TabIndex = 49;
		btPaste.UseVisualStyleBackColor = true;
		cbLayout.AutoSize = true;
		cbLayout.Location = new Point(11, 15);
		cbLayout.Name = "cbLayout";
		cbLayout.Size = new Size(92, 17);
		cbLayout.TabIndex = 50;
		cbLayout.Text = "Ordem Layout";
		cbLayout.UseVisualStyleBackColor = true;
		btAdicionaTexto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btAdicionaTexto.FlatStyle = FlatStyle.Flat;
		btAdicionaTexto.ForeColor = SystemColors.Control;
		btAdicionaTexto.Image = Resources.Adiciona_32;
		btAdicionaTexto.Location = new Point(71, 13);
		btAdicionaTexto.Name = "btAdicionaTexto";
		btAdicionaTexto.Size = new Size(38, 38);
		btAdicionaTexto.TabIndex = 51;
		btAdicionaTexto.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(cbLayout);
		GroupBox1.Location = new Point(12, 333);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(116, 42);
		GroupBox1.TabIndex = 52;
		GroupBox1.TabStop = false;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(tbValorAdd);
		GroupBox2.Controls.Add(btAdicionaTexto);
		GroupBox2.Location = new Point(12, 384);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(116, 55);
		GroupBox2.TabIndex = 53;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		tbValorAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tbValorAdd.Location = new Point(4, 23);
		tbValorAdd.Name = "tbValorAdd";
		tbValorAdd.Size = new Size(70, 20);
		tbValorAdd.TabIndex = 52;
		BTExportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTExportaEX.FlatStyle = FlatStyle.Flat;
		BTExportaEX.ForeColor = SystemColors.Control;
		BTExportaEX.Image = Resources.ExportaExcel_20;
		BTExportaEX.Location = new Point(58, 544);
		BTExportaEX.Name = "BTExportaEX";
		BTExportaEX.Size = new Size(22, 40);
		BTExportaEX.TabIndex = 152;
		BTExportaEX.UseVisualStyleBackColor = true;
		BTImportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTImportaEX.FlatStyle = FlatStyle.Flat;
		BTImportaEX.ForeColor = SystemColors.Control;
		BTImportaEX.Image = Resources.ImportaExcel_20;
		BTImportaEX.Location = new Point(92, 544);
		BTImportaEX.Name = "BTImportaEX";
		BTImportaEX.Size = new Size(22, 40);
		BTImportaEX.TabIndex = 151;
		BTImportaEX.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(ckMod);
		GroupBox3.Controls.Add(ckDesc2);
		GroupBox3.Controls.Add(ckDesc3);
		GroupBox3.Controls.Add(ckDesc1);
		GroupBox3.Controls.Add(BtEditar);
		GroupBox3.Controls.Add(tbPara);
		GroupBox3.Controls.Add(tbDe);
		GroupBox3.Controls.Add(lbPara);
		GroupBox3.Controls.Add(lbDe);
		GroupBox3.Location = new Point(12, 439);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(238, 99);
		GroupBox3.TabIndex = 154;
		GroupBox3.TabStop = false;
		ckMod.AutoSize = true;
		ckMod.Location = new Point(104, 77);
		ckMod.Name = "ckMod";
		ckMod.Size = new Size(59, 17);
		ckMod.TabIndex = 159;
		ckMod.Text = "ckMod";
		ckMod.UseVisualStyleBackColor = true;
		ckDesc2.AutoSize = true;
		ckDesc2.Location = new Point(104, 33);
		ckDesc2.Name = "ckDesc2";
		ckDesc2.Size = new Size(69, 17);
		ckDesc2.TabIndex = 158;
		ckDesc2.Text = "ckDesc2";
		ckDesc2.UseVisualStyleBackColor = true;
		ckDesc3.AutoSize = true;
		ckDesc3.Location = new Point(104, 55);
		ckDesc3.Name = "ckDesc3";
		ckDesc3.Size = new Size(69, 17);
		ckDesc3.TabIndex = 157;
		ckDesc3.Text = "ckDesc3";
		ckDesc3.UseVisualStyleBackColor = true;
		ckDesc1.AutoSize = true;
		ckDesc1.Location = new Point(104, 11);
		ckDesc1.Name = "ckDesc1";
		ckDesc1.Size = new Size(69, 17);
		ckDesc1.TabIndex = 156;
		ckDesc1.Text = "ckDesc1";
		ckDesc1.UseVisualStyleBackColor = true;
		BtEditar.FlatStyle = FlatStyle.Flat;
		BtEditar.ForeColor = SystemColors.Control;
		BtEditar.Image = Resources.Editar;
		BtEditar.Location = new Point(192, 53);
		BtEditar.Name = "BtEditar";
		BtEditar.Size = new Size(40, 40);
		BtEditar.TabIndex = 153;
		BtEditar.UseVisualStyleBackColor = true;
		tbPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPara.Location = new Point(6, 73);
		tbPara.Name = "tbPara";
		tbPara.Size = new Size(87, 20);
		tbPara.TabIndex = 3;
		tbDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDe.Location = new Point(6, 28);
		tbDe.Name = "tbDe";
		tbDe.Size = new Size(87, 20);
		tbDe.TabIndex = 2;
		lbPara.Location = new Point(6, 55);
		lbPara.Name = "lbPara";
		lbPara.Size = new Size(71, 17);
		lbPara.TabIndex = 155;
		lbPara.Text = "lbPara";
		lbDe.Location = new Point(6, 10);
		lbDe.Name = "lbDe";
		lbDe.Size = new Size(71, 17);
		lbDe.TabIndex = 146;
		lbDe.Text = "lbDe";
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(TBPlaquetaExtra);
		GroupBox5.Controls.Add(BtEtiquetasExtras);
		GroupBox5.Location = new Point(134, 384);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(116, 55);
		GroupBox5.TabIndex = 164;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "GroupBox5";
		TBPlaquetaExtra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TBPlaquetaExtra.Location = new Point(4, 23);
		TBPlaquetaExtra.Name = "TBPlaquetaExtra";
		TBPlaquetaExtra.Size = new Size(70, 20);
		TBPlaquetaExtra.TabIndex = 52;
		BtEtiquetasExtras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BtEtiquetasExtras.FlatStyle = FlatStyle.Flat;
		BtEtiquetasExtras.ForeColor = SystemColors.Control;
		BtEtiquetasExtras.Image = Resources.AtribuirEsq_32;
		BtEtiquetasExtras.Location = new Point(71, 11);
		BtEtiquetasExtras.Name = "BtEtiquetasExtras";
		BtEtiquetasExtras.Size = new Size(40, 42);
		BtEtiquetasExtras.TabIndex = 51;
		BtEtiquetasExtras.UseVisualStyleBackColor = true;
		TBStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TBStatus.BackColor = SystemColors.MenuBar;
		TBStatus.BorderStyle = BorderStyle.None;
		TBStatus.Enabled = false;
		TBStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
		TBStatus.ForeColor = SystemColors.InfoText;
		TBStatus.Location = new Point(256, 546);
		TBStatus.Multiline = true;
		TBStatus.Name = "TBStatus";
		TBStatus.ReadOnly = true;
		TBStatus.Size = new Size(667, 40);
		TBStatus.TabIndex = 165;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(934, 592);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox3);
		Controls.Add(BTExportaEX);
		Controls.Add(BTImportaEX);
		Controls.Add(GroupBox2);
		Controls.Add(btPesquisar);
		Controls.Add(GroupBox1);
		Controls.Add(btSalvar);
		Controls.Add(btPaste);
		Controls.Add(btInserirAlternativo);
		Controls.Add(btInserirTag);
		Controls.Add(dgPlaquetas);
		Controls.Add(dgEquip);
		Controls.Add(TBStatus);
		MinimumSize = new Size(950, 570);
		Name = "frmPlaquetas";
		ShowInTaskbar = false;
		Text = "Gerenciador de Plaquetas";
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgPlaquetas).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox5.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return haIp6ZxmAsB;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		haIp6ZxmAsB = WithEventsValue;
	}

	public frmPlaquetas()
	{
		Resize += j9gp6lwqoih;
		ctVpttXc3gp = 0;
		f3Yptj3ocLq = false;
		try
		{
			if (Geral.ExisteForm("frmPlaquetas") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				sfxp68hTwZp();
				Application.ShowModelessDialog((Form)this);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 811]);
				lbDe.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]);
				lbPara.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1645]);
				GroupBox5.Text = DeclaracoesGeral.mMensagem[1, 1890].ToString().ToUpper();
				cbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 795]);
				w8dpBZ0kvSD().SetToolTip(btInserirTag, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 813]));
				w8dpBZ0kvSD().SetToolTip(btInserirAlternativo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 814]));
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 815]));
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 816]));
				w8dpBZ0kvSD().SetToolTip(btPaste, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 817]));
				w8dpBZ0kvSD().SetToolTip(BtEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 294]));
				w8dpBZ0kvSD().SetToolTip(tbValorAdd, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1933]));
				ckDesc1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 805]);
				ckDesc2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 806]);
				ckDesc3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 807]);
				ckMod.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 808]);
				TBStatus.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 808], ":"), "\r\n"), "ELÉTRON ASC"), ": 1, 2, 3, A ,B, C... |  "), "ELÉTRON DESC"), ": C, B, A, 3, 2, 1. |  "), "ELETRONORTE"), ": C, B, A, 3, 2, 1. |  "), "ELETROSUL"), ": D, D1, A, A1, B, B1, C, C1, E, ... |  "), "CHESF"), ": 1, 2, 3, A ,B, C... |  "), "CTEEP"), ": 5, 2, ESPECIAL, 00"));
				formataDGEquip();
				CarregaDGEquip();
				AtualizaDGEquip();
				formataDGPlaquetas();
				cbLayout.Checked = false;
				AtualizaDGPlaquetas();
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
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

	public void CarregaDGEquip()
	{
		try
		{
			List<int> lEquip = new List<int>();
			clsConexao.carregaEquipComFiacao(ref lEquip);
			foreach (int key in DeclaracoesGeral.dicPainel.Keys)
			{
				if (lEquip.Contains(key))
				{
					dgEquip.Rows.Add(key, DeclaracoesGeral.dicPainel[key]);
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

	private void DN0p6NIpRYn(object P_0, EventArgs P_1)
	{
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		formataDGPlaquetas();
		Declaracoes2.StructurePlaquetas[] array = new Declaracoes2.StructurePlaquetas[1];
		Declaracoes2.StructurePlaquetas[] mPlaquetas = new Declaracoes2.StructurePlaquetas[1];
		ctVpttXc3gp = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		string nome = dgEquip.SelectedRows[0].Cells[1].Value.ToString();
		checked
		{
			try
			{
				Dictionary<string, string> dictionary = clsDispositivoTacito.carregaNomeDispositivosPM(ctVpttXc3gp);
				DeclaracoesFiacao.structurePosicaoDisp[] mPosicao = new DeclaracoesFiacao.structurePosicaoDisp[1];
				DicionarioLayout.buscaDicLayoutPainel("P", ctVpttXc3gp, ref mPosicao);
				DicionarioLayout.buscaDicLayoutPainel("X", ctVpttXc3gp, ref mPosicao);
				DicionarioLayout.buscaDicLayoutPainel("C", ctVpttXc3gp, ref mPosicao);
				int num = 0;
				Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				if (Information.UBound(mModelo) >= 2 && Information.UBound(mModelo) > 0)
				{
					int num2 = Information.UBound(mModelo);
					for (int i = 1; i <= num2; i++)
					{
						int num3 = Information.UBound(mModelo) - 1;
						for (int j = num3; j >= 1; j += -1)
						{
							if (Operators.CompareString(mModelo[j].nomeRegua, mModelo[j + 1].nomeRegua, TextCompare: true) > 0)
							{
								Declaracoes2.StructureModeloDeReguas structureModeloDeReguas = mModelo[j + 1];
								mModelo[j + 1] = mModelo[j];
								mModelo[j] = structureModeloDeReguas;
							}
						}
					}
				}
				if (DicionarioPlaqueta.ExisteDicPlaquetaPainel(ctVpttXc3gp.ToString()))
				{
					DicionarioPlaqueta.LeDicPlaquetas(ctVpttXc3gp.ToString(), ref mPlaquetas);
				}
				if (Qeup6Q2w18h(mPlaquetas))
				{
					int num4 = Information.UBound(mPlaquetas);
					for (int k = 0; k <= num4; k++)
					{
						if (Operators.CompareString(mPlaquetas[k].Tipo, "P", TextCompare: true) == 0)
						{
							int num5 = Information.UBound(array) + 1;
							array = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(array, new Declaracoes2.StructurePlaquetas[num5 + 1]);
							array[num5].Tipo = "P";
							array[num5].Handle = "";
							array[num5].IndiceRegua = 0;
							array[num5].Nome = nome;
							array[num5].Desc1 = mPlaquetas[k].Desc1;
							array[num5].Desc2 = mPlaquetas[k].Desc2;
							array[num5].Desc3 = mPlaquetas[k].Desc3;
							array[num5].Modelo = mPlaquetas[k].Modelo;
							array[num5].Ordem = 0;
						}
						if (Operators.CompareString(mPlaquetas[k].Tipo, "X", TextCompare: true) == 0)
						{
							int num6 = Information.UBound(array) + 1;
							array = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(array, new Declaracoes2.StructurePlaquetas[num6 + 1]);
							array[num6].Tipo = "X";
							array[num6].Handle = "";
							array[num6].IndiceRegua = 0;
							string text = mPlaquetas[k].Desc1;
							if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
							{
								text = mPlaquetas[k].Desc2;
							}
							if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
							{
								text = mPlaquetas[k].Desc3;
							}
							array[num6].Nome = text;
							array[num6].Desc1 = mPlaquetas[k].Desc1;
							array[num6].Desc2 = mPlaquetas[k].Desc2;
							array[num6].Desc3 = mPlaquetas[k].Desc3;
							array[num6].Modelo = mPlaquetas[k].Modelo;
							array[num6].Ordem = Conversions.ToInteger(mPlaquetas[k].Handle.Replace("#", ""));
						}
					}
				}
				else
				{
					int num7 = Information.UBound(array) + 1;
					array = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(array, new Declaracoes2.StructurePlaquetas[num7 + 1]);
					array[num7].Tipo = "P";
					array[num7].Handle = "";
					array[num7].IndiceRegua = 0;
					array[num7].Nome = nome;
					array[num7].Desc1 = "";
					array[num7].Desc2 = "";
					array[num7].Desc3 = "";
					array[num7].Modelo = "";
					array[num7].Ordem = 0;
				}
				foreach (string key in dictionary.Keys)
				{
					num = Ahfp6F9mhsI(dictionary[key], mPosicao);
					if (FIIp6PWGiAN(key, mPlaquetas))
					{
						int num8 = Information.UBound(mPlaquetas);
						for (int l = 0; l <= num8; l++)
						{
							if ((Operators.CompareString(mPlaquetas[l].Tipo, "D", TextCompare: true) == 0) & (Operators.CompareString(mPlaquetas[l].Handle, key, TextCompare: true) == 0))
							{
								int num9 = Information.UBound(array) + 1;
								array = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(array, new Declaracoes2.StructurePlaquetas[num9 + 1]);
								array[num9].Tipo = "D";
								array[num9].Handle = key;
								array[num9].IndiceRegua = 0;
								array[num9].Nome = dictionary[key];
								array[num9].Desc1 = mPlaquetas[l].Desc1;
								array[num9].Desc2 = mPlaquetas[l].Desc2;
								array[num9].Desc3 = mPlaquetas[l].Desc3;
								array[num9].Modelo = mPlaquetas[l].Modelo;
								array[num9].Ordem = num;
							}
						}
					}
					else
					{
						int num10 = Information.UBound(array) + 1;
						array = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(array, new Declaracoes2.StructurePlaquetas[num10 + 1]);
						array[num10].Tipo = "D";
						array[num10].Handle = key;
						array[num10].IndiceRegua = 0;
						array[num10].Nome = dictionary[key];
						array[num10].Desc1 = "";
						array[num10].Desc2 = "";
						array[num10].Desc3 = "";
						array[num10].Modelo = "";
						array[num10].Ordem = num;
					}
				}
				if (Information.UBound(array) >= 2 && Information.UBound(array) > 0)
				{
					int num11 = Information.UBound(array);
					for (int m = 2; m <= num11; m++)
					{
						int num12 = Information.UBound(array) - 1;
						for (int n = num12; n >= 2; n += -1)
						{
							if (Operators.CompareString(array[n].Nome, array[n + 1].Nome, TextCompare: true) > 0)
							{
								Declaracoes2.StructurePlaquetas structurePlaquetas = array[n + 1];
								array[n + 1] = array[n];
								array[n] = structurePlaquetas;
							}
						}
					}
				}
				num = 1000;
				int num13 = Information.UBound(mModelo);
				for (int num14 = 0; num14 <= num13; num14++)
				{
					if (mModelo[num14].indexPainel != ctVpttXc3gp)
					{
						continue;
					}
					int indexRegua = mModelo[num14].indexRegua;
					num++;
					if (v65p6cJEGj3(indexRegua, mPlaquetas))
					{
						int num15 = Information.UBound(mPlaquetas);
						for (int num16 = 0; num16 <= num15; num16++)
						{
							if ((Operators.CompareString(mPlaquetas[num16].Tipo, "R", TextCompare: true) == 0) & (mPlaquetas[num16].IndiceRegua == indexRegua))
							{
								int num17 = Information.UBound(array) + 1;
								array = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(array, new Declaracoes2.StructurePlaquetas[num17 + 1]);
								array[num17].Tipo = "R";
								array[num17].Handle = "";
								array[num17].IndiceRegua = indexRegua;
								array[num17].Nome = mModelo[num14].nomeRegua;
								array[num17].Desc1 = mPlaquetas[num16].Desc1;
								array[num17].Desc2 = mPlaquetas[num16].Desc2;
								array[num17].Desc3 = mPlaquetas[num16].Desc3;
								array[num17].Modelo = mPlaquetas[num16].Modelo;
								array[num17].Ordem = num;
							}
						}
					}
					else
					{
						int num18 = Information.UBound(array) + 1;
						array = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(array, new Declaracoes2.StructurePlaquetas[num18 + 1]);
						array[num18].Tipo = "R";
						array[num18].Handle = "";
						array[num18].IndiceRegua = indexRegua;
						array[num18].Nome = mModelo[num14].nomeRegua;
						array[num18].Desc1 = "";
						array[num18].Desc2 = "";
						array[num18].Desc3 = "";
						array[num18].Modelo = "";
						array[num18].Ordem = num;
					}
				}
				int num19 = Information.UBound(array);
				for (int num20 = 1; num20 <= num19; num20++)
				{
					dgPlaquetas.Rows.Add(array[num20].Tipo, array[num20].Handle, array[num20].IndiceRegua, array[num20].Nome, array[num20].Desc1, array[num20].Desc2, array[num20].Desc3, array[num20].Modelo, array[num20].Ordem, num20);
				}
				if (cbLayout.Checked)
				{
					DataGridViewColumn dataGridViewColumn = dgPlaquetas.Columns[8];
					dgPlaquetas.Sort(dataGridViewColumn, ListSortDirection.Ascending);
				}
				AtualizaDGPlaquetas();
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
			}
		}
	}

	private int Ahfp6F9mhsI(string P_0, DeclaracoesFiacao.structurePosicaoDisp[] P_1)
	{
		int result = 0;
		int num = Information.UBound(P_1);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (Operators.CompareString(P_1[i].tag, P_0, TextCompare: true) != 0)
				{
					continue;
				}
				if (P_1[i].posicaoNum != 3)
				{
					if (P_1[i].posicaoNum == 2)
					{
						result = P_1[i].ordem + 500;
					}
				}
				else
				{
					result = P_1[i].ordem;
				}
				break;
			}
			return result;
		}
	}

	private bool Qeup6Q2w18h(Declaracoes2.StructurePlaquetas[] P_0)
	{
		bool result = false;
		int num = Information.UBound(P_0);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_0[i].Tipo, "P", TextCompare: true) == 0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private bool FIIp6PWGiAN(string P_0, Declaracoes2.StructurePlaquetas[] P_1)
	{
		bool result = false;
		int num = Information.UBound(P_1);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_1[i].Handle, P_0, TextCompare: true) == 0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private bool v65p6cJEGj3(int P_0, Declaracoes2.StructurePlaquetas[] P_1)
	{
		bool result = false;
		int num = Information.UBound(P_1);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (P_1[i].IndiceRegua == P_0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void cNvp6KNjqTu(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewCell selectedCell in dgPlaquetas.SelectedCells)
		{
			if (selectedCell.ColumnIndex >= 4)
			{
				string value = Conversions.ToString(dgPlaquetas[3, selectedCell.RowIndex].Value);
				selectedCell.Value = value;
				selectedCell.Selected = false;
			}
		}
	}

	private void z5yp6ei0L9U(object P_0, EventArgs P_1)
	{
		ctVpttXc3gp = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		Dictionary<string, string> dictionary = clsDispositivoTacito.carregaAlternativoDispositivosPM(ctVpttXc3gp);
		foreach (DataGridViewCell selectedCell in dgPlaquetas.SelectedCells)
		{
			if (selectedCell.ColumnIndex >= 4)
			{
				string text = Conversions.ToString(dgPlaquetas[1, selectedCell.RowIndex].Value);
				if (Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					string value = dictionary[text];
					selectedCell.Value = value;
					selectedCell.Selected = false;
				}
			}
		}
	}

	private void GUgp62BHl1f(object P_0, EventArgs P_1)
	{
		string text = Clipboard.GetText();
		if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
		{
			return;
		}
		try
		{
			foreach (DataGridViewCell selectedCell in dgPlaquetas.SelectedCells)
			{
				if (selectedCell.ColumnIndex >= 4)
				{
					selectedCell.Value = text;
					selectedCell.Selected = false;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void h5Pp63La2yf(object P_0, KeyEventArgs P_1)
	{
		checked
		{
			try
			{
				if (P_1.KeyCode != Keys.Insert)
				{
					if (P_1.KeyCode != Keys.Delete)
					{
						return;
					}
					while (true)
					{
						IL_00e2:
						foreach (DataGridViewCell selectedCell in dgPlaquetas.SelectedCells)
						{
							if (selectedCell.ColumnIndex == 3 && selectedCell.RowIndex > 0 && Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(selectedCell.Value, dgPlaquetas[3, selectedCell.RowIndex - 1].Value, TextCompare: true), Operators.CompareObjectEqual(dgPlaquetas[0, selectedCell.RowIndex].Value, "X", TextCompare: true))))
							{
								int rowIndex = selectedCell.RowIndex;
								dgPlaquetas.Rows.RemoveAt(selectedCell.RowIndex);
								dgPlaquetas.Refresh();
								dgPlaquetas[3, rowIndex].Selected = false;
								goto IL_00e2;
							}
						}
						break;
					}
					{
						foreach (DataGridViewCell selectedCell2 in dgPlaquetas.SelectedCells)
						{
							if (selectedCell2.ColumnIndex >= 4)
							{
								selectedCell2.Value = "";
								selectedCell2.Selected = false;
							}
						}
						return;
					}
				}
				foreach (DataGridViewCell selectedCell3 in dgPlaquetas.SelectedCells)
				{
					if (selectedCell3.ColumnIndex == 3)
					{
						dgPlaquetas.Rows.InsertCopy(selectedCell3.RowIndex, selectedCell3.RowIndex + 1);
						int num = dgPlaquetas.Columns.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							dgPlaquetas[i, selectedCell3.RowIndex + 1].Value = RuntimeHelpers.GetObjectValue(dgPlaquetas[i, selectedCell3.RowIndex].Value);
						}
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

	private void fUnp6n1LIBh(object P_0, EventArgs P_1)
	{
		Declaracoes2.StructurePlaquetas[] mPlaquetas = new Declaracoes2.StructurePlaquetas[1];
		int num = 0;
		checked
		{
			int num2 = dgPlaquetas.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				mPlaquetas = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(mPlaquetas, new Declaracoes2.StructurePlaquetas[num + 1]);
				mPlaquetas[num].Tipo = Conversions.ToString(dgPlaquetas.Rows[i].Cells[0].Value);
				if (!Operators.ConditionalCompareObjectEqual(dgPlaquetas.Rows[i].Cells[0].Value, "X", TextCompare: true))
				{
					mPlaquetas[num].Handle = Conversions.ToString(dgPlaquetas.Rows[i].Cells[1].Value);
				}
				else
				{
					mPlaquetas[num].Handle = "#" + Conversions.ToString(num);
				}
				mPlaquetas[num].IndiceRegua = Conversions.ToInteger(dgPlaquetas.Rows[i].Cells[2].Value);
				mPlaquetas[num].Desc1 = Conversions.ToString(dgPlaquetas.Rows[i].Cells[4].Value);
				mPlaquetas[num].Desc2 = Conversions.ToString(dgPlaquetas.Rows[i].Cells[5].Value);
				mPlaquetas[num].Desc3 = Conversions.ToString(dgPlaquetas.Rows[i].Cells[6].Value);
				mPlaquetas[num].Modelo = Conversions.ToString(dgPlaquetas.Rows[i].Cells[7].Value);
				num++;
			}
			DicionarioPlaqueta.gravaDicPlaqueta(ctVpttXc3gp.ToString(), ref mPlaquetas);
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 787]));
				AtualizaDGEquip();
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void AtualizaDGEquip()
	{
		checked
		{
			if (dgEquip.Rows.Count != 0)
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip)) ? ((float)(dgEquip.Width - 4)) : ((float)(dgEquip.Width - 20)));
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num);
				dgEquip.Columns[1].Visible = true;
			}
		}
	}

	public void formataDGPlaquetas()
	{
		try
		{
			dgPlaquetas.Rows.Clear();
			dgPlaquetas.Columns.Clear();
			dgPlaquetas.Columns.Add("", "TIPO");
			dgPlaquetas.Columns.Add("", "HANDLE");
			dgPlaquetas.Columns.Add("", "INDICE");
			dgPlaquetas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 804]));
			dgPlaquetas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 805]));
			dgPlaquetas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 806]));
			dgPlaquetas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 807]));
			dgPlaquetas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 808]));
			dgPlaquetas.Columns.Add("", "ORDEM");
			dgPlaquetas.Columns.Add("", "ORDEMDG");
			dgPlaquetas.Columns[3].ReadOnly = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGPlaquetas()
	{
		checked
		{
			if (dgPlaquetas.Rows.Count != 0)
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPlaquetas)) ? ((float)(dgPlaquetas.Width - 4)) : ((float)(dgPlaquetas.Width - 22)));
				dgPlaquetas.Columns[0].Width = 0;
				dgPlaquetas.Columns[0].Visible = false;
				dgPlaquetas.Columns[1].Width = 0;
				dgPlaquetas.Columns[1].Visible = false;
				dgPlaquetas.Columns[2].Width = 0;
				dgPlaquetas.Columns[2].Visible = false;
				dgPlaquetas.Columns[3].Width = (int)Math.Round(num * 2f / 9f);
				dgPlaquetas.Columns[4].Width = (int)Math.Round(num * 2f / 9f);
				dgPlaquetas.Columns[5].Width = (int)Math.Round(num * 2f / 9f);
				dgPlaquetas.Columns[6].Width = (int)Math.Round(num * 2f / 9f);
				dgPlaquetas.Columns[7].Width = (int)Math.Round(num / 9f);
				dgPlaquetas.Columns[8].Width = 0;
				dgPlaquetas.Columns[8].Visible = false;
				dgPlaquetas.Columns[9].Width = 0;
				dgPlaquetas.Columns[9].Visible = false;
			}
			else
			{
				dgPlaquetas.Rows.Clear();
				dgPlaquetas.Columns.Clear();
			}
		}
	}

	private void Tfep61xZMoV(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value)))
		{
			dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value = "";
		}
		if (((P_1.ColumnIndex == 4) | (P_1.ColumnIndex == 5) | (P_1.ColumnIndex == 6)) && dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value.ToString().Length > 40)
		{
			dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value = Strings.Mid(Conversions.ToString(dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value), 1, 40);
		}
		if (P_1.ColumnIndex == 7 && dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value.ToString().Length > 10)
		{
			dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value = Strings.Mid(Conversions.ToString(dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value), 1, 10);
		}
	}

	private void j9gp6lwqoih(object P_0, EventArgs P_1)
	{
		UYJp65eBAPX();
	}

	private void UYJp65eBAPX()
	{
		AtualizaDGEquip();
		AtualizaDGPlaquetas();
	}

	private void hjDp600tH1Q(object P_0, EventArgs P_1)
	{
		string value = tbValorAdd.Text;
		int num = 0;
		try
		{
			foreach (DataGridViewCell selectedCell in dgPlaquetas.SelectedCells)
			{
				if (selectedCell.ColumnIndex >= 4)
				{
					selectedCell.Value = value;
				}
				num = selectedCell.RowIndex;
				if (Operators.ConditionalCompareObjectEqual(dgPlaquetas.Rows[num].Cells[0].Value, "X", TextCompare: true))
				{
					if (selectedCell.ColumnIndex == 4)
					{
						dgPlaquetas.Rows[selectedCell.RowIndex].Cells[3].Value = value;
					}
					selectedCell.Value = value;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void CZIp6RBhuy2(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(TBPlaquetaExtra.Text.Trim(), "", TextCompare: true) == 0)
		{
			return;
		}
		int index = 0;
		int num = 0;
		foreach (DataGridViewCell selectedCell in dgPlaquetas.SelectedCells)
		{
			num = selectedCell.RowIndex;
		}
		checked
		{
			int num2 = dgPlaquetas.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgPlaquetas.Rows[i].Cells[0].Value, "P", TextCompare: true))
				{
					index = i;
				}
				if (i == num)
				{
					double num3 = Conversions.ToDouble(dgPlaquetas.Rows[i].Cells[9].Value);
					num3 += 0.5;
					dgPlaquetas.Rows.Add("X", dgPlaquetas.Rows[index].Cells[1].Value, dgPlaquetas.Rows[i].Cells[2].Value, TBPlaquetaExtra.Text, TBPlaquetaExtra.Text, "", "", dgPlaquetas.Rows[i].Cells[7].Value, dgPlaquetas.Rows[i].Cells[8].Value, num3.ToString());
					break;
				}
			}
			qHqp6mu3Ik6(dgPlaquetas);
			int num4 = dgPlaquetas.Rows.Count - 1;
			for (int j = 0; j <= num4; j++)
			{
				dgPlaquetas.Rows[j].Cells[9].Value = j + 1;
			}
			AtualizaDGPlaquetas();
		}
	}

	private void qHqp6mu3Ik6(DataGridView P_0)
	{
		if (P_0.Rows.Count < 2)
		{
			return;
		}
		checked
		{
			int num = P_0.Rows.Count - 2;
			for (int i = num; i >= 0; i += -1)
			{
				int num2 = i;
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectGreater(P_0[9, j].Value, P_0[9, j + 1].Value, TextCompare: true))
					{
						int num3 = P_0.Columns.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(P_0[k, j + 1].Value);
							P_0[k, j + 1].Value = RuntimeHelpers.GetObjectValue(P_0[k, j].Value);
							P_0[k, j].Value = RuntimeHelpers.GetObjectValue(objectValue);
						}
					}
				}
			}
		}
	}

	private void lS0p6XPoDjj(object P_0, EventArgs P_1)
	{
		if (dgPlaquetas.RowCount > 0)
		{
			BTExportaEX.Enabled = false;
			object obj = null;
			object obj2 = null;
			Worksheet oSheet = null;
			Microsoft.Office.Interop.Excel.Application oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
			Workbook oBook = (Workbook)obj2;
			ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
			obj2 = oBook;
			obj = oExcelNew;
			oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
			ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
			obj = oExcelNew;
			DataGridView dg = dgPlaquetas;
			Relatorios_PlaquetasEXCEL.ExportaPlaquetas(ref oSheet, ref dg);
			dgPlaquetas = dg;
			BTExportaEX.Enabled = true;
			oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			obj = oExcelNew;
		}
	}

	private void t6np6U8GoDe(object P_0, EventArgs P_1)
	{
		if (dgPlaquetas.RowCount > 0)
		{
			BTExportaEX.Enabled = false;
			object obj = null;
			object obj2 = null;
			Worksheet oSheet = null;
			Microsoft.Office.Interop.Excel.Application oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
			Workbook oBook = (Workbook)obj2;
			ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false);
			obj2 = oBook;
			obj = oExcelNew;
			oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
			ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
			obj = oExcelNew;
			DataGridView dg = dgPlaquetas;
			Relatorios_PlaquetasEXCEL.ImportarPlaquetas(ref oSheet, ref dg);
			dgPlaquetas = dg;
			BTExportaEX.Enabled = true;
			oExcelNew = (Microsoft.Office.Interop.Excel.Application)obj;
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			obj = oExcelNew;
			AtualizaDGPlaquetas();
		}
	}

	private void qNpp6yqnA7C(object P_0, EventArgs P_1)
	{
		string oldValue = tbDe.Text;
		string newValue = tbPara.Text;
		checked
		{
			int num = dgPlaquetas.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = "";
				if (ckDesc1.Checked)
				{
					text = Conversions.ToString(dgPlaquetas.Rows[i].Cells[4].Value);
					dgPlaquetas.Rows[i].Cells[4].Value = text.Replace(oldValue, newValue);
				}
				if (ckDesc2.Checked)
				{
					text = Conversions.ToString(dgPlaquetas.Rows[i].Cells[5].Value);
					dgPlaquetas.Rows[i].Cells[5].Value = text.Replace(oldValue, newValue);
				}
				if (ckDesc3.Checked)
				{
					text = Conversions.ToString(dgPlaquetas.Rows[i].Cells[6].Value);
					dgPlaquetas.Rows[i].Cells[6].Value = text.Replace(oldValue, newValue);
				}
				if (ckMod.Checked)
				{
					text = Conversions.ToString(dgPlaquetas.Rows[i].Cells[7].Value);
					dgPlaquetas.Rows[i].Cells[7].Value = text.Replace(oldValue, newValue);
				}
			}
		}
	}
}
