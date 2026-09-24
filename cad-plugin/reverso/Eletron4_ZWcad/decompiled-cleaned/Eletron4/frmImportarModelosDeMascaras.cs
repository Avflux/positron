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
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.EditorInput;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmImportarModelosDeMascaras : Form
{
	private IContainer aWXfn7JnIe;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip OgKf1K3i7c;

	[CompilerGenerated]
	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog yJVflWbNml;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGModelosEXT_Importar")]
	[CompilerGenerated]
	private DataGridView XVuf544CLE;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox THif0do79e;

	[AccessedThroughProperty("lbLayout")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label y2NfRmQNHJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbTopografico")]
	private Label zZwfmbZhwf;

	[AccessedThroughProperty("tbBlocoLayout")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox IbOfXxAbJ0;

	[AccessedThroughProperty("tbBlocoTopografico")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox KLQfUPUOo1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LbModelo")]
	private Label nkwfy8xKZT;

	[CompilerGenerated]
	[AccessedThroughProperty("tbModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox LGtfgTThnh;

	[CompilerGenerated]
	[AccessedThroughProperty("lbMateriais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label ssYfAKuyjZ;

	[AccessedThroughProperty("btSelCadrno")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button GQ3fswhufB;

	[AccessedThroughProperty("tbCaminho")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox EihfByMRu6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbLM1")]
	[CompilerGenerated]
	private TextBox aPdfVG1p8f;

	[CompilerGenerated]
	[AccessedThroughProperty("tbLM2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox IBcfuCHh6r;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbIndex")]
	private Label Vn5fE6r2vq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbIndice")]
	private TextBox OMLfZFs0db;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAdiciona")]
	private Button iSKfiLnDh4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox uQTfSYhYFa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("DGModelosDWG_Caderno")]
	private DataGridView aZXf4iQ2vA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private GroupBox XVxfCUPnrF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPortasEXT_Importar")]
	private DataGridView Gn0fYYk5Tx;

	[AccessedThroughProperty("dgPortasDWG_Caderno")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView Aeffr7fXq2;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBoxPortaDestino")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox qTWf9EMdJW;

	[AccessedThroughProperty("GroupBoxPortaOrigem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox VFDfzYQM18;

	[AccessedThroughProperty("btPesquisaLM2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button ao8DWLhPn6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisaLM1")]
	private Button eXLDpn7xkB;

	private int BCIDTvwlCV;

	private int MuCDJ9HO5x;

	private DataGridViewCellStyle WNhDhCRGkc;

	private DataGridViewCellStyle tZdDoSC7bV;

	private Declaracoes2.MModeloDeMascara[] l6ADGRJr41;

	private Declaracoes2.MModeloDePortas[] wCFDHSws11;

	private Declaracoes2.MModeloDeMascara[] lHeDkZJk2p;

	private Declaracoes2.MModeloDePortas[] V6dDdic8qZ;

	private bool le9DfqdSDw;

	internal virtual DataGridView DGModelosEXT_Importar
	{
		[CompilerGenerated]
		get
		{
			return XVuf544CLE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = Uh9fNmERIN;
			KeyEventHandler value3 = P0wfFsmcWl;
			DataGridView dataGridView = XVuf544CLE;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
			}
			XVuf544CLE = value;
			dataGridView = XVuf544CLE;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyUp += value3;
			}
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return THif0do79e;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			THif0do79e = value;
		}
	}

	internal virtual Label lbLayout
	{
		[CompilerGenerated]
		get
		{
			return y2NfRmQNHJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			y2NfRmQNHJ = value;
		}
	}

	internal virtual Label lbTopografico
	{
		[CompilerGenerated]
		get
		{
			return zZwfmbZhwf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zZwfmbZhwf = value;
		}
	}

	internal virtual TextBox tbBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return IbOfXxAbJ0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IbOfXxAbJ0 = value;
		}
	}

	internal virtual TextBox tbBlocoTopografico
	{
		[CompilerGenerated]
		get
		{
			return KLQfUPUOo1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KLQfUPUOo1 = value;
		}
	}

	internal virtual Label LbModelo
	{
		[CompilerGenerated]
		get
		{
			return nkwfy8xKZT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nkwfy8xKZT = value;
		}
	}

	internal virtual TextBox tbModelo
	{
		[CompilerGenerated]
		get
		{
			return LGtfgTThnh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = i42fKdSpTm;
			TextBox textBox = LGtfgTThnh;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			LGtfgTThnh = value;
			textBox = LGtfgTThnh;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbMateriais
	{
		[CompilerGenerated]
		get
		{
			return ssYfAKuyjZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ssYfAKuyjZ = value;
		}
	}

	internal virtual Button btSelCadrno
	{
		[CompilerGenerated]
		get
		{
			return GQ3fswhufB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = t9ufqLdQCv;
			Button button = GQ3fswhufB;
			if (button != null)
			{
				button.Click -= value2;
			}
			GQ3fswhufB = value;
			button = GQ3fswhufB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbCaminho
	{
		[CompilerGenerated]
		get
		{
			return EihfByMRu6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EihfByMRu6 = value;
		}
	}

	internal virtual TextBox tbLM1
	{
		[CompilerGenerated]
		get
		{
			return aPdfVG1p8f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aPdfVG1p8f = value;
		}
	}

	internal virtual TextBox tbLM2
	{
		[CompilerGenerated]
		get
		{
			return IBcfuCHh6r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IBcfuCHh6r = value;
		}
	}

	internal virtual Label lbIndex
	{
		[CompilerGenerated]
		get
		{
			return Vn5fE6r2vq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Vn5fE6r2vq = value;
		}
	}

	internal virtual TextBox tbIndice
	{
		[CompilerGenerated]
		get
		{
			return OMLfZFs0db;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = EMmfccXLrn;
			TextBox textBox = OMLfZFs0db;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			OMLfZFs0db = value;
			textBox = OMLfZFs0db;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button BTAdiciona
	{
		[CompilerGenerated]
		get
		{
			return iSKfiLnDh4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nt6fal09l8;
			Button button = iSKfiLnDh4;
			if (button != null)
			{
				button.Click -= value2;
			}
			iSKfiLnDh4 = value;
			button = iSKfiLnDh4;
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
			return uQTfSYhYFa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uQTfSYhYFa = value;
		}
	}

	internal virtual DataGridView DGModelosDWG_Caderno
	{
		[CompilerGenerated]
		get
		{
			return aZXf4iQ2vA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = GhnfQ6ZESv;
			KeyEventHandler value3 = v0KfPwwxFS;
			DataGridView dataGridView = aZXf4iQ2vA;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
			}
			aZXf4iQ2vA = value;
			dataGridView = aZXf4iQ2vA;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyUp += value3;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return XVxfCUPnrF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XVxfCUPnrF = value;
		}
	}

	internal virtual DataGridView dgPortasEXT_Importar
	{
		[CompilerGenerated]
		get
		{
			return Gn0fYYk5Tx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = Uh9fNmERIN;
			KeyEventHandler value3 = P0wfFsmcWl;
			DataGridView dataGridView = Gn0fYYk5Tx;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
			}
			Gn0fYYk5Tx = value;
			dataGridView = Gn0fYYk5Tx;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyUp += value3;
			}
		}
	}

	internal virtual DataGridView dgPortasDWG_Caderno
	{
		[CompilerGenerated]
		get
		{
			return Aeffr7fXq2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Aeffr7fXq2 = value;
		}
	}

	internal virtual GroupBox GroupBoxPortaDestino
	{
		[CompilerGenerated]
		get
		{
			return qTWf9EMdJW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qTWf9EMdJW = value;
		}
	}

	internal virtual GroupBox GroupBoxPortaOrigem
	{
		[CompilerGenerated]
		get
		{
			return VFDfzYQM18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VFDfzYQM18 = value;
		}
	}

	internal virtual Button btPesquisaLM2
	{
		[CompilerGenerated]
		get
		{
			return ao8DWLhPn6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VnHf3lFa7e;
			Button button = ao8DWLhPn6;
			if (button != null)
			{
				button.Click -= value2;
			}
			ao8DWLhPn6 = value;
			button = ao8DWLhPn6;
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
			return eXLDpn7xkB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gVvf2X8Rlo;
			Button button = eXLDpn7xkB;
			if (button != null)
			{
				button.Click -= value2;
			}
			eXLDpn7xkB = value;
			button = eXLDpn7xkB;
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
			if (disposing && aWXfn7JnIe != null)
			{
				aWXfn7JnIe.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Q9Sf7jmhJd()
	{
		aWXfn7JnIe = new Container();
		FDqpBiUmZij(new ToolTip(aWXfn7JnIe));
		aHypBEW66iS(new FolderBrowserDialog());
		DGModelosEXT_Importar = new DataGridView();
		GroupBox3 = new GroupBox();
		btPesquisaLM2 = new Button();
		btPesquisaLM1 = new Button();
		lbIndex = new Label();
		tbIndice = new TextBox();
		BTAdiciona = new Button();
		tbLM1 = new TextBox();
		tbLM2 = new TextBox();
		lbLayout = new Label();
		lbTopografico = new Label();
		tbBlocoLayout = new TextBox();
		tbBlocoTopografico = new TextBox();
		LbModelo = new Label();
		tbModelo = new TextBox();
		lbMateriais = new Label();
		btSelCadrno = new Button();
		tbCaminho = new TextBox();
		GroupBox2 = new GroupBox();
		DGModelosDWG_Caderno = new DataGridView();
		GroupBox1 = new GroupBox();
		dgPortasEXT_Importar = new DataGridView();
		dgPortasDWG_Caderno = new DataGridView();
		GroupBoxPortaDestino = new GroupBox();
		GroupBoxPortaOrigem = new GroupBox();
		((ISupportInitialize)DGModelosEXT_Importar).BeginInit();
		GroupBox3.SuspendLayout();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)DGModelosDWG_Caderno).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)dgPortasEXT_Importar).BeginInit();
		((ISupportInitialize)dgPortasDWG_Caderno).BeginInit();
		GroupBoxPortaDestino.SuspendLayout();
		GroupBoxPortaOrigem.SuspendLayout();
		SuspendLayout();
		DGModelosEXT_Importar.AllowUserToAddRows = false;
		DGModelosEXT_Importar.AllowUserToDeleteRows = false;
		DGModelosEXT_Importar.AllowUserToOrderColumns = true;
		DGModelosEXT_Importar.AllowUserToResizeRows = false;
		DGModelosEXT_Importar.BackgroundColor = SystemColors.ButtonHighlight;
		DGModelosEXT_Importar.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGModelosEXT_Importar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGModelosEXT_Importar.Location = new Point(5, 15);
		DGModelosEXT_Importar.MultiSelect = false;
		DGModelosEXT_Importar.Name = "DGModelosEXT_Importar";
		DGModelosEXT_Importar.ReadOnly = true;
		DGModelosEXT_Importar.RowHeadersVisible = false;
		DGModelosEXT_Importar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGModelosEXT_Importar.Size = new Size(587, 150);
		DGModelosEXT_Importar.TabIndex = 117;
		GroupBox3.Controls.Add(btPesquisaLM2);
		GroupBox3.Controls.Add(btPesquisaLM1);
		GroupBox3.Controls.Add(lbIndex);
		GroupBox3.Controls.Add(tbIndice);
		GroupBox3.Controls.Add(BTAdiciona);
		GroupBox3.Controls.Add(tbLM1);
		GroupBox3.Controls.Add(tbLM2);
		GroupBox3.Controls.Add(lbLayout);
		GroupBox3.Controls.Add(lbTopografico);
		GroupBox3.Controls.Add(tbBlocoLayout);
		GroupBox3.Controls.Add(tbBlocoTopografico);
		GroupBox3.Controls.Add(LbModelo);
		GroupBox3.Controls.Add(tbModelo);
		GroupBox3.Controls.Add(lbMateriais);
		GroupBox3.Controls.Add(DGModelosEXT_Importar);
		GroupBox3.Location = new Point(12, 66);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(600, 270);
		GroupBox3.TabIndex = 144;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "gbDWGImportar";
		btPesquisaLM2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM2.FlatStyle = FlatStyle.Flat;
		btPesquisaLM2.ForeColor = SystemColors.Control;
		btPesquisaLM2.Image = Resources.Pesquisar_16;
		btPesquisaLM2.Location = new Point(326, 192);
		btPesquisaLM2.Name = "btPesquisaLM2";
		btPesquisaLM2.Size = new Size(22, 22);
		btPesquisaLM2.TabIndex = 201;
		btPesquisaLM2.UseVisualStyleBackColor = true;
		btPesquisaLM1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM1.FlatStyle = FlatStyle.Flat;
		btPesquisaLM1.ForeColor = SystemColors.Control;
		btPesquisaLM1.Image = Resources.Pesquisar_16;
		btPesquisaLM1.Location = new Point(237, 192);
		btPesquisaLM1.Name = "btPesquisaLM1";
		btPesquisaLM1.Size = new Size(22, 22);
		btPesquisaLM1.TabIndex = 200;
		btPesquisaLM1.UseVisualStyleBackColor = true;
		lbIndex.Location = new Point(6, 176);
		lbIndex.Name = "lbIndex";
		lbIndex.Size = new Size(28, 13);
		lbIndex.TabIndex = 192;
		lbIndex.Text = "lb#";
		lbIndex.TextAlign = ContentAlignment.MiddleLeft;
		tbIndice.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbIndice.Location = new Point(6, 194);
		tbIndice.Name = "tbIndice";
		tbIndice.Size = new Size(27, 20);
		tbIndice.TabIndex = 191;
		BTAdiciona.FlatStyle = FlatStyle.Flat;
		BTAdiciona.ForeColor = SystemColors.Control;
		BTAdiciona.Image = Resources.Adiciona_32;
		BTAdiciona.Location = new Point(542, 183);
		BTAdiciona.Name = "BTAdiciona";
		BTAdiciona.Size = new Size(40, 40);
		BTAdiciona.TabIndex = 189;
		BTAdiciona.UseVisualStyleBackColor = true;
		tbLM1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLM1.Location = new Point(186, 194);
		tbLM1.Name = "tbLM1";
		tbLM1.Size = new Size(50, 20);
		tbLM1.TabIndex = 190;
		tbLM2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLM2.Location = new Point(270, 194);
		tbLM2.Name = "tbLM2";
		tbLM2.Size = new Size(50, 20);
		tbLM2.TabIndex = 189;
		lbLayout.Location = new Point(299, 222);
		lbLayout.Name = "lbLayout";
		lbLayout.Size = new Size(107, 13);
		lbLayout.TabIndex = 179;
		lbLayout.Text = "lbLAYOUT";
		lbLayout.TextAlign = ContentAlignment.MiddleLeft;
		lbTopografico.Location = new Point(5, 222);
		lbTopografico.Name = "lbTopografico";
		lbTopografico.Size = new Size(112, 13);
		lbTopografico.TabIndex = 178;
		lbTopografico.Text = "lbTOPOGRAFICO";
		lbTopografico.TextAlign = ContentAlignment.MiddleLeft;
		tbBlocoLayout.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoLayout.Location = new Point(299, 240);
		tbBlocoLayout.Name = "tbBlocoLayout";
		tbBlocoLayout.Size = new Size(283, 20);
		tbBlocoLayout.TabIndex = 177;
		tbBlocoTopografico.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoTopografico.Location = new Point(5, 240);
		tbBlocoTopografico.Name = "tbBlocoTopografico";
		tbBlocoTopografico.Size = new Size(283, 20);
		tbBlocoTopografico.TabIndex = 174;
		LbModelo.Location = new Point(40, 176);
		LbModelo.Name = "LbModelo";
		LbModelo.Size = new Size(82, 13);
		LbModelo.TabIndex = 140;
		LbModelo.Text = "lbMODELO";
		LbModelo.TextAlign = ContentAlignment.MiddleLeft;
		tbModelo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo.Location = new Point(40, 194);
		tbModelo.Name = "tbModelo";
		tbModelo.Size = new Size(137, 20);
		tbModelo.TabIndex = 133;
		lbMateriais.AutoSize = true;
		lbMateriais.Location = new Point(186, 176);
		lbMateriais.Name = "lbMateriais";
		lbMateriais.Size = new Size(73, 13);
		lbMateriais.TabIndex = 168;
		lbMateriais.Text = "lbMATERIAIS";
		lbMateriais.TextAlign = ContentAlignment.MiddleLeft;
		btSelCadrno.FlatStyle = FlatStyle.Flat;
		btSelCadrno.ForeColor = SystemColors.Control;
		btSelCadrno.Image = Resources.DWG;
		btSelCadrno.Location = new Point(552, 9);
		btSelCadrno.Name = "btSelCadrno";
		btSelCadrno.Size = new Size(40, 40);
		btSelCadrno.TabIndex = 148;
		btSelCadrno.UseVisualStyleBackColor = true;
		tbCaminho.BackColor = Color.Silver;
		tbCaminho.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCaminho.Location = new Point(9, 22);
		tbCaminho.Name = "tbCaminho";
		tbCaminho.Size = new Size(537, 20);
		tbCaminho.TabIndex = 187;
		GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(DGModelosDWG_Caderno);
		GroupBox2.Location = new Point(14, 345);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(600, 294);
		GroupBox2.TabIndex = 189;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "gbDWGCorrente";
		DGModelosDWG_Caderno.AllowUserToAddRows = false;
		DGModelosDWG_Caderno.AllowUserToDeleteRows = false;
		DGModelosDWG_Caderno.AllowUserToOrderColumns = true;
		DGModelosDWG_Caderno.AllowUserToResizeRows = false;
		DGModelosDWG_Caderno.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGModelosDWG_Caderno.BackgroundColor = SystemColors.ButtonHighlight;
		DGModelosDWG_Caderno.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGModelosDWG_Caderno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGModelosDWG_Caderno.Location = new Point(5, 15);
		DGModelosDWG_Caderno.MultiSelect = false;
		DGModelosDWG_Caderno.Name = "DGModelosDWG_Caderno";
		DGModelosDWG_Caderno.ReadOnly = true;
		DGModelosDWG_Caderno.RowHeadersVisible = false;
		DGModelosDWG_Caderno.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGModelosDWG_Caderno.Size = new Size(587, 269);
		DGModelosDWG_Caderno.TabIndex = 117;
		GroupBox1.Controls.Add(btSelCadrno);
		GroupBox1.Controls.Add(tbCaminho);
		GroupBox1.Location = new Point(12, 12);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(602, 53);
		GroupBox1.TabIndex = 190;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		dgPortasEXT_Importar.AllowUserToAddRows = false;
		dgPortasEXT_Importar.AllowUserToDeleteRows = false;
		dgPortasEXT_Importar.AllowUserToOrderColumns = true;
		dgPortasEXT_Importar.AllowUserToResizeRows = false;
		dgPortasEXT_Importar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dgPortasEXT_Importar.BackgroundColor = SystemColors.ButtonHighlight;
		dgPortasEXT_Importar.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgPortasEXT_Importar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPortasEXT_Importar.Location = new Point(5, 15);
		dgPortasEXT_Importar.MultiSelect = false;
		dgPortasEXT_Importar.Name = "dgPortasEXT_Importar";
		dgPortasEXT_Importar.ReadOnly = true;
		dgPortasEXT_Importar.RowHeadersVisible = false;
		dgPortasEXT_Importar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPortasEXT_Importar.Size = new Size(312, 299);
		dgPortasEXT_Importar.TabIndex = 117;
		dgPortasDWG_Caderno.AllowUserToAddRows = false;
		dgPortasDWG_Caderno.AllowUserToDeleteRows = false;
		dgPortasDWG_Caderno.AllowUserToOrderColumns = true;
		dgPortasDWG_Caderno.AllowUserToResizeRows = false;
		dgPortasDWG_Caderno.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPortasDWG_Caderno.BackgroundColor = SystemColors.ButtonHighlight;
		dgPortasDWG_Caderno.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgPortasDWG_Caderno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPortasDWG_Caderno.Location = new Point(5, 15);
		dgPortasDWG_Caderno.MultiSelect = false;
		dgPortasDWG_Caderno.Name = "dgPortasDWG_Caderno";
		dgPortasDWG_Caderno.ReadOnly = true;
		dgPortasDWG_Caderno.RowHeadersVisible = false;
		dgPortasDWG_Caderno.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPortasDWG_Caderno.Size = new Size(312, 269);
		dgPortasDWG_Caderno.TabIndex = 191;
		GroupBoxPortaDestino.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBoxPortaDestino.Controls.Add(dgPortasDWG_Caderno);
		GroupBoxPortaDestino.Location = new Point(625, 345);
		GroupBoxPortaDestino.Name = "GroupBoxPortaDestino";
		GroupBoxPortaDestino.Size = new Size(324, 294);
		GroupBoxPortaDestino.TabIndex = 195;
		GroupBoxPortaDestino.TabStop = false;
		GroupBoxPortaDestino.Text = "GroupBoxPortaDestino";
		GroupBoxPortaOrigem.Controls.Add(dgPortasEXT_Importar);
		GroupBoxPortaOrigem.Location = new Point(623, 14);
		GroupBoxPortaOrigem.Name = "GroupBoxPortaOrigem";
		GroupBoxPortaOrigem.Size = new Size(324, 324);
		GroupBoxPortaOrigem.TabIndex = 194;
		GroupBoxPortaOrigem.TabStop = false;
		GroupBoxPortaOrigem.Text = "GroupBoxPortaOrigem";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(959, 645);
		Controls.Add(GroupBoxPortaDestino);
		Controls.Add(GroupBoxPortaOrigem);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox3);
		MaximizeBox = false;
		MaximumSize = new Size(975, 1000);
		MinimumSize = new Size(975, 610);
		Name = "frmImportarModelosDeMascaras";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmClonar Modelos de Mascara";
		((ISupportInitialize)DGModelosEXT_Importar).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGModelosDWG_Caderno).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		((ISupportInitialize)dgPortasEXT_Importar).EndInit();
		((ISupportInitialize)dgPortasDWG_Caderno).EndInit();
		GroupBoxPortaDestino.ResumeLayout(performLayout: false);
		GroupBoxPortaOrigem.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return OgKf1K3i7c;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		OgKf1K3i7c = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return yJVflWbNml;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		yJVflWbNml = WithEventsValue;
	}

	public frmImportarModelosDeMascaras()
	{
		FormClosed += JO4feMCkQ4;
		BCIDTvwlCV = 0;
		MuCDJ9HO5x = 0;
		WNhDhCRGkc = new DataGridViewCellStyle();
		tZdDoSC7bV = new DataGridViewCellStyle();
		l6ADGRJr41 = null;
		wCFDHSws11 = null;
		lHeDkZJk2p = null;
		V6dDdic8qZ = null;
		le9DfqdSDw = false;
		try
		{
			if (!Geral.ExisteForm("frmImportarModelosDeMascaras") && clsAuxiliar.BancoValido())
			{
				Q9Sf7jmhJd();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1640]);
				GroupBox1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 600], " - "), DeclaracoesGeral.mMensagem[1, 109]));
				GroupBox2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 109], " - "), DeclaracoesGeral.mMensagem[1, 1142]));
				GroupBox3.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 600], " - "), DeclaracoesGeral.mMensagem[1, 1142]));
				GroupBoxPortaDestino.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 109], " - "), DeclaracoesGeral.mMensagem[1, 921]));
				GroupBoxPortaOrigem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 600], " - "), DeclaracoesGeral.mMensagem[1, 921]));
				lbIndex.Text = "#";
				LbModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
				lbMateriais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 656]);
				lbTopografico.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 657]);
				lbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 658]);
				BTAdiciona.Enabled = false;
				tbCaminho.ReadOnly = true;
				Application.ShowModelessDialog((Form)this);
				l6ADGRJr41 = new Declaracoes2.MModeloDeMascara[1];
				DicionarioMascaras.LeOsModelosDeMascaras(ref l6ADGRJr41, bComplementarModelo: true);
				DataGridView dg = DGModelosDWG_Caderno;
				clsMascara.carregaModelosDeMascaraNoDG(ref dg, l6ADGRJr41);
				DGModelosDWG_Caderno = dg;
				DGModelosDWG_Caderno.Rows[0].Selected = false;
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

	private void t9ufqLdQCv(object P_0, EventArgs P_1)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		tbCaminho.ReadOnly = false;
		PromptOpenFileOptions val = new PromptOpenFileOptions(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1652]));
		((PromptFileOptions)val).InitialDirectory = DeclaracoesGeral.Conf.DirProjeto;
		((PromptFileOptions)val).Filter = "AutoCAD DWG (*.dwg)|*.dwg";
		PromptFileNameResult fileNameForOpen = editor.GetFileNameForOpen(val);
		tbCaminho.Text = ((PromptResult)fileNameForOpen).StringResult;
		DGModelosEXT_Importar.Rows.Clear();
		DGModelosEXT_Importar.Columns.Clear();
		tbModelo.Text = "";
		tbLM1.Text = "";
		tbLM2.Text = "";
		tbBlocoTopografico.Text = "";
		tbBlocoLayout.Text = "";
		if (clsImportarModelos.CadernoEletron(tbCaminho.Text))
		{
			clsImportarModelos.CarregaModelosMascarasOutroCadreno(tbCaminho.Text, ref lHeDkZJk2p);
			DataGridView dg = DGModelosEXT_Importar;
			clsMascara.carregaModelosDeMascaraNoDG(ref dg, lHeDkZJk2p);
			DGModelosEXT_Importar = dg;
			if (DGModelosEXT_Importar.RowCount != 0)
			{
				DGModelosEXT_Importar.Rows[0].Selected = false;
				tbIndice.BackColor = Color.White;
				tbModelo.BackColor = Color.White;
				dgPortasEXT_Importar.Rows.Clear();
				dgPortasEXT_Importar.Columns.Clear();
				BTAdiciona.Enabled = true;
				tbCaminho.ReadOnly = true;
				AnalisaModelos("T");
			}
		}
		else
		{
			DGModelosDWG_Caderno.Rows.Clear();
			DGModelosDWG_Caderno.Columns.Clear();
			DGModelosEXT_Importar.Rows.Clear();
			DGModelosEXT_Importar.Columns.Clear();
			dgPortasEXT_Importar.Rows.Clear();
			dgPortasEXT_Importar.Columns.Clear();
			dgPortasDWG_Caderno.Rows.Clear();
			dgPortasDWG_Caderno.Columns.Clear();
		}
	}

	private void nt6fal09l8(object P_0, EventArgs P_1)
	{
		if (DGModelosEXT_Importar.SelectedRows.Count == 0)
		{
			return;
		}
		if (!Versioned.IsNumeric(tbLM1.Text))
		{
			tbLM1.Text = Conversions.ToString(0);
		}
		if (!Versioned.IsNumeric(tbLM2.Text))
		{
			tbLM2.Text = Conversions.ToString(0);
		}
		checked
		{
			int num = Information.UBound(l6ADGRJr41) - 1;
			int num2 = 0;
			int num4 = default;
			while (true)
			{
				if (num2 <= num)
				{
					tbModelo.BackColor = Color.White;
					tbModelo.ForeColor = Color.Black;
					if (!Operators.ConditionalCompareObjectEqual(DGModelosDWG_Caderno.Rows[num2].Cells[1].Value, tbModelo.Text.ToString(), TextCompare: true))
					{
						num2++;
						continue;
					}
					tbModelo.BackColor = Color.Red;
					tbModelo.ForeColor = Color.White;
					break;
				}
				int num3 = Conversions.ToInteger(tbIndice.Text);
				num4 = unchecked(0 - (DicionarioMascaras.LeOsModelosDeMascaras(ref l6ADGRJr41, bComplementarModelo: true) ? 1 : 0));
				int num5 = Information.UBound(l6ADGRJr41) + 1;
				ref Declaracoes2.MModeloDeMascara[] reference = ref l6ADGRJr41;
				reference = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(reference, new Declaracoes2.MModeloDeMascara[num5 + 1]);
				bool flag = true;
				if (DGModelosDWG_Caderno.RowCount != 0)
				{
					int num6 = DGModelosDWG_Caderno.Rows.Count - 1;
					for (int i = 0; i <= num6; i++)
					{
						if (Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value.ToString()) >= num4)
						{
							num4 = Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value.ToString()) + 1;
						}
						if (Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value.ToString()) == num3)
						{
							flag = false;
						}
					}
				}
				if ((num4 < num3) | flag)
				{
					num4 = num3;
				}
				if (num4 == 0)
				{
					num4 = 1;
				}
				l6ADGRJr41[num5].iIndiceModelo = num4;
				l6ADGRJr41[num5].sNomeModelo = tbModelo.Text.ToString();
				l6ADGRJr41[num5].iLM1 = Conversions.ToInteger(tbLM1.Text);
				l6ADGRJr41[num5].iLM2 = Conversions.ToInteger(tbLM2.Text);
				l6ADGRJr41[num5].sBlocoTopografico = tbBlocoTopografico.Text.ToString();
				l6ADGRJr41[num5].sBlocoLayout = tbBlocoLayout.Text.ToString();
				l6ADGRJr41[num5].Orientacao = "";
				DicionarioMascaras.GravaOsModelosDeMascara(l6ADGRJr41);
				DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(Conversions.ToInteger(tbIndice.Text), ref V6dDdic8qZ);
				break;
			}
			DicionarioMascaras.LeOsModelosDeMascaras(ref l6ADGRJr41, bComplementarModelo: true);
			DataGridView dg = DGModelosDWG_Caderno;
			clsMascara.carregaModelosDeMascaraNoDG(ref dg, l6ADGRJr41);
			DGModelosDWG_Caderno = dg;
			int num7 = DGModelosDWG_Caderno.Rows.Count - 1;
			for (int j = 0; j <= num7; j++)
			{
				if (Operators.CompareString(DGModelosDWG_Caderno.Rows[j].Cells[0].Value.ToString(), num4.ToString(), TextCompare: true) == 0)
				{
					DGModelosDWG_Caderno.Rows[j].Cells[0].Selected = true;
					DGModelosDWG_Caderno.FirstDisplayedScrollingRowIndex = j;
					mostraModeloDWG();
					break;
				}
			}
			DGModelosEXT_Importar.Focus();
		}
	}

	private void ylRf8eH2AM(object P_0, EventArgs P_1)
	{
		if (DGModelosDWG_Caderno.SelectedRows.Count == 0 || DGModelosEXT_Importar.SelectedRows.Count == 0 || Operators.CompareString(tbIndice.Text, DGModelosDWG_Caderno.SelectedRows[0].Cells[0].Value.ToString(), TextCompare: true) != 0)
		{
			return;
		}
		bool flag = false;
		int num = Information.UBound(l6ADGRJr41);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if ((double)l6ADGRJr41[i].iIndiceModelo != Conversions.ToDouble(tbIndice.Text.ToString()))
			{
				if (Operators.CompareString(l6ADGRJr41[i].sNomeModelo, tbModelo.Text.ToString(), TextCompare: true) == 0)
				{
					l6ADGRJr41[i].iIndiceModelo = Conversions.ToInteger(tbIndice.Text);
					l6ADGRJr41[i].iLM1 = Conversions.ToInteger(tbLM1.Text);
					l6ADGRJr41[i].iLM2 = Conversions.ToInteger(tbLM2.Text);
					l6ADGRJr41[i].sBlocoTopografico = tbBlocoTopografico.Text.ToString();
					l6ADGRJr41[i].sBlocoLayout = tbBlocoLayout.Text.ToString();
					l6ADGRJr41[i].Orientacao = "";
					flag = true;
					break;
				}
				continue;
			}
			l6ADGRJr41[i].sNomeModelo = tbModelo.Text.ToString();
			l6ADGRJr41[i].iLM1 = Conversions.ToInteger(tbLM1.Text);
			l6ADGRJr41[i].iLM2 = Conversions.ToInteger(tbLM2.Text);
			l6ADGRJr41[i].sBlocoTopografico = tbBlocoTopografico.Text.ToString();
			l6ADGRJr41[i].sBlocoLayout = tbBlocoLayout.Text.ToString();
			l6ADGRJr41[i].Orientacao = "";
			flag = true;
			break;
		}
		if (flag)
		{
			DicionarioMascaras.GravaOsModelosDeMascara(l6ADGRJr41);
			DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(Conversions.ToInteger(tbIndice.Text), ref V6dDdic8qZ);
			DicionarioMascaras.LeOsModelosDeMascaras(ref l6ADGRJr41, bComplementarModelo: true);
			DataGridView dg = DGModelosDWG_Caderno;
			clsMascara.carregaModelosDeMascaraNoDG(ref dg, l6ADGRJr41);
			DGModelosDWG_Caderno = dg;
			TextBox textBox = tbIndice;
			int iIndiceSelecionado = Conversions.ToInteger(textBox.Text);
			DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado, tbModelo.Text, ref wCFDHSws11);
			textBox.Text = Conversions.ToString(iIndiceSelecionado);
			dg = dgPortasDWG_Caderno;
			clsDispositivoMascaras.carregaContatosNoDGMascara(ref dg, ref wCFDHSws11, bPintaDG: false);
			dgPortasDWG_Caderno = dg;
			dg = dgPortasDWG_Caderno;
			AtualizaColunasDGPortasMascara(ref dg);
			dgPortasDWG_Caderno = dg;
			le9DfqdSDw = true;
		}
	}

	public void AnalisaModelos(string sValorDigitado)
	{
		checked
		{
			if (!(((DGModelosDWG_Caderno.SelectedRows.Count == 0) & (DGModelosEXT_Importar.SelectedRows.Count == 0)) | ((DGModelosDWG_Caderno.SelectedRows.Count == 1) & (DGModelosEXT_Importar.SelectedRows.Count == 0))))
			{
				tbIndice.BackColor = Color.White;
				tbModelo.BackColor = Color.White;
				WNhDhCRGkc.BackColor = Color.LightCoral;
				tZdDoSC7bV.BackColor = Color.White;
				if (DGModelosDWG_Caderno.Rows.Count > 0)
				{
					BTAdiciona.Enabled = true;
					BTAdiciona.Enabled = true;
				}
				int num = DGModelosDWG_Caderno.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DGModelosDWG_Caderno.Rows[i].Cells[0].Style = tZdDoSC7bV;
					DGModelosDWG_Caderno.Rows[i].Cells[1].Style = tZdDoSC7bV;
				}
				int num2 = DGModelosDWG_Caderno.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.CompareString(tbIndice.Text.ToString(), DGModelosDWG_Caderno.Rows[j].Cells[0].Value.ToString(), TextCompare: true) == 0)
					{
						tbIndice.BackColor = Color.LightCoral;
						DGModelosDWG_Caderno.FirstDisplayedScrollingRowIndex = j;
						if (DGModelosDWG_Caderno.SelectedRows.Count == 1)
						{
							tbIndice.BackColor = Color.White;
							if (Operators.CompareString(sValorDigitado, "I", TextCompare: true) == 0)
							{
								tbIndice.Text = DGModelosDWG_Caderno.SelectedRows[0].Cells[0].Value.ToString();
							}
						}
						BTAdiciona.Enabled = false;
					}
					if (Operators.CompareString(tbModelo.Text.ToString(), DGModelosDWG_Caderno.Rows[j].Cells[1].Value.ToString(), TextCompare: true) == 0)
					{
						tbModelo.BackColor = Color.LightCoral;
						if (Operators.CompareString(sValorDigitado, "M", TextCompare: true) == 0 && Operators.ConditionalCompareObjectEqual(tbModelo.Text.ToString(), DGModelosDWG_Caderno.SelectedRows[0].Cells[1].Value, TextCompare: true))
						{
							tbModelo.BackColor = Color.White;
						}
						DGModelosDWG_Caderno.FirstDisplayedScrollingRowIndex = j;
						BTAdiciona.Enabled = false;
					}
				}
				if (!((DGModelosDWG_Caderno.Rows.Count == 0) & (DGModelosEXT_Importar.Rows.Count > 0)))
				{
					if (DGModelosDWG_Caderno.SelectedRows.Count == 0 || DGModelosEXT_Importar.SelectedRows.Count == 0)
					{
						return;
					}
					if (!((Operators.CompareString(tbIndice.Text.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(tbModelo.Text.Trim(), "", TextCompare: true) == 0)))
					{
						if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(tbIndice.Text.ToString(), DGModelosDWG_Caderno.SelectedRows[0].Cells[0].Value, TextCompare: true), tbModelo.BackColor == Color.LightCoral)))
						{
							if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(tbIndice.Text.ToString(), DGModelosDWG_Caderno.SelectedRows[0].Cells[0].Value, TextCompare: true), Operators.CompareObjectNotEqual(tbModelo.Text.ToString(), DGModelosDWG_Caderno.SelectedRows[0].Cells[1].Value, TextCompare: true))))
							{
								BTAdiciona.Enabled = false;
							}
						}
						else
						{
							BTAdiciona.Enabled = false;
						}
					}
					else
					{
						BTAdiciona.Enabled = false;
					}
				}
				else
				{
					BTAdiciona.Enabled = true;
				}
			}
			else
			{
				BTAdiciona.Enabled = false;
			}
		}
	}

	private void Uh9fNmERIN(object P_0, DataGridViewCellEventArgs P_1)
	{
		mostraModeloMascaraEXT();
	}

	private void P0wfFsmcWl(object P_0, KeyEventArgs P_1)
	{
		mostraModeloMascaraEXT();
	}

	public void mostraModeloMascaraEXT()
	{
		checked
		{
			int num = DGModelosEXT_Importar.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!DGModelosEXT_Importar.Rows[i].Selected)
				{
					continue;
				}
				if (Operators.ConditionalCompareObjectNotEqual(BCIDTvwlCV, DGModelosEXT_Importar.Rows[i].Cells[0].Value, TextCompare: true))
				{
					BCIDTvwlCV = Conversions.ToInteger(DGModelosEXT_Importar.Rows[i].Cells[0].Value);
					tbIndice.Text = Conversions.ToString(DGModelosEXT_Importar.Rows[i].Cells[0].Value);
					tbModelo.Text = Conversions.ToString(DGModelosEXT_Importar.Rows[i].Cells[1].Value);
					tbLM1.Text = DGModelosEXT_Importar.Rows[i].Cells[2].Value.ToString();
					tbLM2.Text = DGModelosEXT_Importar.Rows[i].Cells[3].Value.ToString();
					tbBlocoTopografico.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
					{
						tbBlocoTopografico.BackColor = Color.White;
					}
					tbBlocoTopografico.Text = DGModelosEXT_Importar.Rows[i].Cells[4].Value.ToString().ToUpper().Trim();
					tbBlocoLayout.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
					{
						tbBlocoLayout.BackColor = Color.White;
					}
					tbBlocoLayout.Text = DGModelosEXT_Importar.Rows[i].Cells[5].Value.ToString().ToUpper().Trim();
					int iIndiceModelo = Conversions.ToInteger(DGModelosEXT_Importar.Rows[i].Cells[0].Value);
					string nomeModelo = Conversions.ToString(DGModelosEXT_Importar.Rows[i].Cells[1].Value);
					V6dDdic8qZ = new Declaracoes2.MModeloDePortas[1];
					clsImportarModelos.CarregaPortasOutroCadreno(tbCaminho.Text, iIndiceModelo, nomeModelo, ref V6dDdic8qZ);
					DataGridView dg = dgPortasEXT_Importar;
					clsDispositivoMascaras.carregaContatosNoDGMascara(ref dg, ref V6dDdic8qZ, bPintaDG: false);
					dgPortasEXT_Importar = dg;
					dg = dgPortasEXT_Importar;
					AtualizaColunasDGPortasMascara(ref dg);
					dgPortasEXT_Importar = dg;
				}
				break;
			}
			string text = "";
			text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1642], ""), tbModelo.Text), DeclaracoesGeral.mMensagem[1, 1644]), DeclaracoesGeral.Conf.Local));
			w8dpBZ0kvSD().SetToolTip(BTAdiciona, text);
			AnalisaModelos("T");
		}
	}

	private void GhnfQ6ZESv(object P_0, DataGridViewCellEventArgs P_1)
	{
		mostraModeloDWG();
	}

	private void v0KfPwwxFS(object P_0, KeyEventArgs P_1)
	{
		mostraModeloDWG();
	}

	public void mostraModeloDWG()
	{
		checked
		{
			int num = DGModelosDWG_Caderno.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGModelosDWG_Caderno.Rows[i].Selected)
				{
					int iIndiceSelecionado = Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value);
					string sNomeModelo = Conversions.ToString(DGModelosDWG_Caderno.Rows[i].Cells[1].Value);
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado, sNomeModelo, ref wCFDHSws11);
					DataGridView dg = dgPortasDWG_Caderno;
					clsDispositivoMascaras.carregaContatosNoDGMascara(ref dg, ref wCFDHSws11, bPintaDG: false);
					dgPortasDWG_Caderno = dg;
					dg = dgPortasDWG_Caderno;
					AtualizaColunasDGPortasMascara(ref dg);
					dgPortasDWG_Caderno = dg;
					break;
				}
			}
			if (DGModelosEXT_Importar.Rows.Count != 0)
			{
				AnalisaModelos("M");
			}
		}
	}

	public static void AtualizaColunasDGPortasMascara(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				num -= 110.0;
				dg.Columns[0].Width = 30;
				dg.Columns[1].Width = 0;
				dg.Columns[2].Width = (int)Math.Round(num * 0.3);
				dg.Columns[3].Width = (int)Math.Round(num * 0.4);
				dg.Columns[4].Width = 40;
				dg.Columns[5].Width = 40;
				dg.Columns[6].Width = (int)Math.Round(num * 0.3);
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[2].Visible = true;
				dg.Columns[3].Visible = true;
				dg.Columns[4].Visible = true;
				dg.Columns[5].Visible = true;
				dg.Columns[6].Visible = true;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
				dg.Columns[4].ReadOnly = false;
				dg.Columns[5].ReadOnly = false;
				dg.Columns[6].ReadOnly = false;
				dg.MultiSelect = false;
			}
		}
	}

	private void EMmfccXLrn(object P_0, KeyEventArgs P_1)
	{
		AnalisaModelos("M");
	}

	private void i42fKdSpTm(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = tbModelo;
		clsTextos.NomeValido(ref tbNome);
		tbModelo = tbNome;
		AnalisaModelos("M");
	}

	private void JO4feMCkQ4(object P_0, FormClosedEventArgs P_1)
	{
		if (le9DfqdSDw)
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.SendStringToExecute("_.corrigePortas \n", true, false, true);
		}
	}

	private void gVvf2X8Rlo(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbLM1.Text));
		tbLM1.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		frmPesquisaMateriais2.Dispose();
	}

	private void VnHf3lFa7e(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbLM2.Text));
		tbLM2.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		frmPesquisaMateriais2.Dispose();
	}
}
