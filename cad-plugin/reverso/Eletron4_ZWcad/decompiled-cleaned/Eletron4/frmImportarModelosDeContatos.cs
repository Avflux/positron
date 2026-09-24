using System;
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
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.EditorInput;

namespace Eletron4;

[DesignerGenerated]
public class frmImportarModelosDeContatos : Form
{
	private IContainer WTTdyACo5Y;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip vHMdg7UxFp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	private FolderBrowserDialog O0QdAGhy99;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGModelosEXT_Importar")]
	[CompilerGenerated]
	private DataGridView pbHdscbnQN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Groupbox3")]
	private GroupBox xMJdBj8UYl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbLayout")]
	[CompilerGenerated]
	private Label SJWdVc9VI0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTopografico")]
	private Label Y7bdu7M8ef;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBlocoLayout")]
	private TextBox h9GdExNEn6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBlocoTopografico")]
	private TextBox jADdZr3hBo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbModelo")]
	private Label k4KdiSfMKk;

	[AccessedThroughProperty("tbModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox qDmdSBxj75;

	[AccessedThroughProperty("lbMateriais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label qvcd45YVi7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelCadrno")]
	private Button s5GdCGk2pe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCaminho")]
	private TextBox peBdY9L6RZ;

	[AccessedThroughProperty("tbLM1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox e8idrhHj9q;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbLM2")]
	private TextBox D8vd9pvKaM;

	[AccessedThroughProperty("lbIndex")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label PNMdzetS8h;

	[AccessedThroughProperty("tbIndice")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox kekfWB4pVF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTAdiciona")]
	private Button yK5fphxXPP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Groupbox2")]
	private GroupBox VuufTdVYSm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGModelosDWG_Caderno")]
	private DataGridView IILfJWjkmU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox H2nfhDXrqJ;

	[AccessedThroughProperty("dgAuxiliaresEXT_Importar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView Mu4foIXrlA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgAuxiliaresDWG_Caderno")]
	[CompilerGenerated]
	private DataGridView tDcfGGtJCJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTerminaisModelo")]
	private Label JiBfH2htwi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBTerminais")]
	[CompilerGenerated]
	private TextBox mQSfk6RD1h;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxContatosOrigem")]
	private GroupBox BQafdKbJrR;

	[AccessedThroughProperty("GroupBoxContatosDestino")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox JumffA6DMs;

	[CompilerGenerated]
	[AccessedThroughProperty("lbOrientacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label RrxfDfX8pk;

	[AccessedThroughProperty("tbOrientacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox f5Kfvu7bnG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btPesquisaLM2")]
	private Button wMlf6j7YDD;

	[CompilerGenerated]
	[AccessedThroughProperty("btPesquisaLM1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button IEAftvSb2g;

	private int VcCfj45e9c;

	private int s0yfLjsaC9;

	private DataGridViewCellStyle g1RfwCfP51;

	private DataGridViewCellStyle ApTfxfDmMw;

	private Declaracoes2.MModelosDeContatos[] Sxsfbwh1i8;

	private Declaracoes2.StructureContatosAuxiliares[] G4GfMJG1yq;

	private Declaracoes2.MModelosDeContatos[] uVYfO64OaU;

	private Declaracoes2.StructureContatosAuxiliares[] De3fIokX52;

	internal virtual DataGridView DGModelosEXT_Importar
	{
		[CompilerGenerated]
		get
		{
			return pbHdscbnQN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = Aind1RxGuh;
			KeyEventHandler value3 = X59dlNrVTK;
			DataGridView dataGridView = pbHdscbnQN;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
			}
			pbHdscbnQN = value;
			dataGridView = pbHdscbnQN;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyUp += value3;
			}
		}
	}

	internal virtual GroupBox Groupbox3
	{
		[CompilerGenerated]
		get
		{
			return xMJdBj8UYl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xMJdBj8UYl = value;
		}
	}

	internal virtual Label lbLayout
	{
		[CompilerGenerated]
		get
		{
			return SJWdVc9VI0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SJWdVc9VI0 = value;
		}
	}

	internal virtual Label lbTopografico
	{
		[CompilerGenerated]
		get
		{
			return Y7bdu7M8ef;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Y7bdu7M8ef = value;
		}
	}

	internal virtual TextBox tbBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return h9GdExNEn6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			h9GdExNEn6 = value;
		}
	}

	internal virtual TextBox tbBlocoTopografico
	{
		[CompilerGenerated]
		get
		{
			return jADdZr3hBo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jADdZr3hBo = value;
		}
	}

	internal virtual Label LbModelo
	{
		[CompilerGenerated]
		get
		{
			return k4KdiSfMKk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			k4KdiSfMKk = value;
		}
	}

	internal virtual TextBox tbModelo
	{
		[CompilerGenerated]
		get
		{
			return qDmdSBxj75;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = mT4dmMsu1r;
			TextBox textBox = qDmdSBxj75;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			qDmdSBxj75 = value;
			textBox = qDmdSBxj75;
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
			return qvcd45YVi7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qvcd45YVi7 = value;
		}
	}

	internal virtual Button btSelCadrno
	{
		[CompilerGenerated]
		get
		{
			return s5GdCGk2pe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rodd33o8Ro;
			Button button = s5GdCGk2pe;
			if (button != null)
			{
				button.Click -= value2;
			}
			s5GdCGk2pe = value;
			button = s5GdCGk2pe;
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
			return peBdY9L6RZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			peBdY9L6RZ = value;
		}
	}

	internal virtual TextBox tbLM1
	{
		[CompilerGenerated]
		get
		{
			return e8idrhHj9q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			e8idrhHj9q = value;
		}
	}

	internal virtual TextBox tbLM2
	{
		[CompilerGenerated]
		get
		{
			return D8vd9pvKaM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			D8vd9pvKaM = value;
		}
	}

	internal virtual Label lbIndex
	{
		[CompilerGenerated]
		get
		{
			return PNMdzetS8h;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PNMdzetS8h = value;
		}
	}

	internal virtual TextBox tbIndice
	{
		[CompilerGenerated]
		get
		{
			return kekfWB4pVF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = d40dR2nkOE;
			TextBox textBox = kekfWB4pVF;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			kekfWB4pVF = value;
			textBox = kekfWB4pVF;
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
			return yK5fphxXPP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zw7dni9Vhf;
			Button button = yK5fphxXPP;
			if (button != null)
			{
				button.Click -= value2;
			}
			yK5fphxXPP = value;
			button = yK5fphxXPP;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox Groupbox2
	{
		[CompilerGenerated]
		get
		{
			return VuufTdVYSm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VuufTdVYSm = value;
		}
	}

	internal virtual DataGridView DGModelosDWG_Caderno
	{
		[CompilerGenerated]
		get
		{
			return IILfJWjkmU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = eImd5oEnIF;
			KeyEventHandler value3 = VQZd0REtID;
			DataGridView dataGridView = IILfJWjkmU;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
			}
			IILfJWjkmU = value;
			dataGridView = IILfJWjkmU;
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
			return H2nfhDXrqJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			H2nfhDXrqJ = value;
		}
	}

	internal virtual DataGridView dgAuxiliaresEXT_Importar
	{
		[CompilerGenerated]
		get
		{
			return Mu4foIXrlA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = Aind1RxGuh;
			KeyEventHandler value3 = X59dlNrVTK;
			DataGridView dataGridView = Mu4foIXrlA;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
			}
			Mu4foIXrlA = value;
			dataGridView = Mu4foIXrlA;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyUp += value3;
			}
		}
	}

	internal virtual DataGridView dgAuxiliaresDWG_Caderno
	{
		[CompilerGenerated]
		get
		{
			return tDcfGGtJCJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tDcfGGtJCJ = value;
		}
	}

	internal virtual Label lbTerminaisModelo
	{
		[CompilerGenerated]
		get
		{
			return JiBfH2htwi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JiBfH2htwi = value;
		}
	}

	internal virtual TextBox TBTerminais
	{
		[CompilerGenerated]
		get
		{
			return mQSfk6RD1h;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mQSfk6RD1h = value;
		}
	}

	internal virtual GroupBox GroupBoxContatosOrigem
	{
		[CompilerGenerated]
		get
		{
			return BQafdKbJrR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BQafdKbJrR = value;
		}
	}

	internal virtual GroupBox GroupBoxContatosDestino
	{
		[CompilerGenerated]
		get
		{
			return JumffA6DMs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JumffA6DMs = value;
		}
	}

	internal virtual Label lbOrientacao
	{
		[CompilerGenerated]
		get
		{
			return RrxfDfX8pk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RrxfDfX8pk = value;
		}
	}

	internal virtual TextBox tbOrientacao
	{
		[CompilerGenerated]
		get
		{
			return f5Kfvu7bnG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			f5Kfvu7bnG = value;
		}
	}

	internal virtual Button btPesquisaLM2
	{
		[CompilerGenerated]
		get
		{
			return wMlf6j7YDD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iuXdUxWdL8;
			Button button = wMlf6j7YDD;
			if (button != null)
			{
				button.Click -= value2;
			}
			wMlf6j7YDD = value;
			button = wMlf6j7YDD;
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
			return IEAftvSb2g;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tlmdXRYjLT;
			Button button = IEAftvSb2g;
			if (button != null)
			{
				button.Click -= value2;
			}
			IEAftvSb2g = value;
			button = IEAftvSb2g;
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
			if (disposing && WTTdyACo5Y != null)
			{
				WTTdyACo5Y.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void fEwd26mATJ()
	{
		WTTdyACo5Y = new Container();
		FDqpBiUmZij(new ToolTip(WTTdyACo5Y));
		aHypBEW66iS(new FolderBrowserDialog());
		DGModelosEXT_Importar = new DataGridView();
		Groupbox3 = new GroupBox();
		btPesquisaLM2 = new Button();
		btPesquisaLM1 = new Button();
		lbOrientacao = new Label();
		tbOrientacao = new TextBox();
		lbTerminaisModelo = new Label();
		TBTerminais = new TextBox();
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
		dgAuxiliaresEXT_Importar = new DataGridView();
		btSelCadrno = new Button();
		tbCaminho = new TextBox();
		Groupbox2 = new GroupBox();
		DGModelosDWG_Caderno = new DataGridView();
		dgAuxiliaresDWG_Caderno = new DataGridView();
		GroupBox1 = new GroupBox();
		GroupBoxContatosOrigem = new GroupBox();
		GroupBoxContatosDestino = new GroupBox();
		((ISupportInitialize)DGModelosEXT_Importar).BeginInit();
		Groupbox3.SuspendLayout();
		((ISupportInitialize)dgAuxiliaresEXT_Importar).BeginInit();
		Groupbox2.SuspendLayout();
		((ISupportInitialize)DGModelosDWG_Caderno).BeginInit();
		((ISupportInitialize)dgAuxiliaresDWG_Caderno).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBoxContatosOrigem.SuspendLayout();
		GroupBoxContatosDestino.SuspendLayout();
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
		Groupbox3.Controls.Add(btPesquisaLM2);
		Groupbox3.Controls.Add(btPesquisaLM1);
		Groupbox3.Controls.Add(lbOrientacao);
		Groupbox3.Controls.Add(tbOrientacao);
		Groupbox3.Controls.Add(lbTerminaisModelo);
		Groupbox3.Controls.Add(TBTerminais);
		Groupbox3.Controls.Add(lbIndex);
		Groupbox3.Controls.Add(tbIndice);
		Groupbox3.Controls.Add(BTAdiciona);
		Groupbox3.Controls.Add(tbLM1);
		Groupbox3.Controls.Add(tbLM2);
		Groupbox3.Controls.Add(lbLayout);
		Groupbox3.Controls.Add(lbTopografico);
		Groupbox3.Controls.Add(tbBlocoLayout);
		Groupbox3.Controls.Add(tbBlocoTopografico);
		Groupbox3.Controls.Add(LbModelo);
		Groupbox3.Controls.Add(tbModelo);
		Groupbox3.Controls.Add(lbMateriais);
		Groupbox3.Controls.Add(DGModelosEXT_Importar);
		Groupbox3.Location = new Point(12, 68);
		Groupbox3.Name = "Groupbox3";
		Groupbox3.Size = new Size(600, 270);
		Groupbox3.TabIndex = 144;
		Groupbox3.TabStop = false;
		Groupbox3.Text = "gbDWGImportar";
		btPesquisaLM2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM2.FlatStyle = FlatStyle.Flat;
		btPesquisaLM2.ForeColor = SystemColors.Control;
		btPesquisaLM2.Image = Resources.Pesquisar_16;
		btPesquisaLM2.Location = new Point(318, 192);
		btPesquisaLM2.Name = "btPesquisaLM2";
		btPesquisaLM2.Size = new Size(22, 22);
		btPesquisaLM2.TabIndex = 199;
		btPesquisaLM2.UseVisualStyleBackColor = true;
		btPesquisaLM1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM1.FlatStyle = FlatStyle.Flat;
		btPesquisaLM1.ForeColor = SystemColors.Control;
		btPesquisaLM1.Image = Resources.Pesquisar_16;
		btPesquisaLM1.Location = new Point(239, 192);
		btPesquisaLM1.Name = "btPesquisaLM1";
		btPesquisaLM1.Size = new Size(22, 22);
		btPesquisaLM1.TabIndex = 198;
		btPesquisaLM1.UseVisualStyleBackColor = true;
		lbOrientacao.AutoSize = true;
		lbOrientacao.Location = new Point(455, 177);
		lbOrientacao.Name = "lbOrientacao";
		lbOrientacao.Size = new Size(67, 13);
		lbOrientacao.TabIndex = 197;
		lbOrientacao.Text = "lbOrientação";
		tbOrientacao.BackColor = SystemColors.Window;
		tbOrientacao.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbOrientacao.Location = new Point(458, 194);
		tbOrientacao.Name = "tbOrientacao";
		tbOrientacao.ReadOnly = true;
		tbOrientacao.Size = new Size(90, 20);
		tbOrientacao.TabIndex = 196;
		lbTerminaisModelo.AutoSize = true;
		lbTerminaisModelo.Location = new Point(356, 177);
		lbTerminaisModelo.Name = "lbTerminaisModelo";
		lbTerminaisModelo.Size = new Size(95, 13);
		lbTerminaisModelo.TabIndex = 195;
		lbTerminaisModelo.Text = "lbTerminaisModelo";
		TBTerminais.BackColor = SystemColors.Window;
		TBTerminais.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTerminais.Location = new Point(356, 194);
		TBTerminais.Name = "TBTerminais";
		TBTerminais.ReadOnly = true;
		TBTerminais.Size = new Size(96, 20);
		TBTerminais.TabIndex = 194;
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
		BTAdiciona.Location = new Point(554, 183);
		BTAdiciona.Name = "BTAdiciona";
		BTAdiciona.Size = new Size(40, 40);
		BTAdiciona.TabIndex = 189;
		BTAdiciona.UseVisualStyleBackColor = true;
		tbLM1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLM1.Location = new Point(190, 194);
		tbLM1.Name = "tbLM1";
		tbLM1.Size = new Size(46, 20);
		tbLM1.TabIndex = 190;
		tbLM2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLM2.Location = new Point(269, 194);
		tbLM2.Name = "tbLM2";
		tbLM2.Size = new Size(46, 20);
		tbLM2.TabIndex = 189;
		lbLayout.Location = new Point(299, 224);
		lbLayout.Name = "lbLayout";
		lbLayout.Size = new Size(107, 13);
		lbLayout.TabIndex = 179;
		lbLayout.Text = "lbLAYOUT";
		lbLayout.TextAlign = ContentAlignment.MiddleLeft;
		lbTopografico.Location = new Point(6, 224);
		lbTopografico.Name = "lbTopografico";
		lbTopografico.Size = new Size(112, 13);
		lbTopografico.TabIndex = 178;
		lbTopografico.Text = "lbTOPOGRAFICO";
		lbTopografico.TextAlign = ContentAlignment.MiddleLeft;
		tbBlocoLayout.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoLayout.Location = new Point(299, 242);
		tbBlocoLayout.Name = "tbBlocoLayout";
		tbBlocoLayout.Size = new Size(283, 20);
		tbBlocoLayout.TabIndex = 177;
		tbBlocoTopografico.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoTopografico.Location = new Point(6, 242);
		tbBlocoTopografico.Name = "tbBlocoTopografico";
		tbBlocoTopografico.Size = new Size(282, 20);
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
		tbModelo.Size = new Size(144, 20);
		tbModelo.TabIndex = 133;
		lbMateriais.AutoSize = true;
		lbMateriais.Location = new Point(190, 176);
		lbMateriais.Name = "lbMateriais";
		lbMateriais.Size = new Size(73, 13);
		lbMateriais.TabIndex = 168;
		lbMateriais.Text = "lbMATERIAIS";
		lbMateriais.TextAlign = ContentAlignment.MiddleLeft;
		dgAuxiliaresEXT_Importar.AllowUserToAddRows = false;
		dgAuxiliaresEXT_Importar.AllowUserToDeleteRows = false;
		dgAuxiliaresEXT_Importar.AllowUserToOrderColumns = true;
		dgAuxiliaresEXT_Importar.AllowUserToResizeRows = false;
		dgAuxiliaresEXT_Importar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgAuxiliaresEXT_Importar.BackgroundColor = SystemColors.ButtonHighlight;
		dgAuxiliaresEXT_Importar.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgAuxiliaresEXT_Importar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgAuxiliaresEXT_Importar.Location = new Point(5, 15);
		dgAuxiliaresEXT_Importar.MultiSelect = false;
		dgAuxiliaresEXT_Importar.Name = "dgAuxiliaresEXT_Importar";
		dgAuxiliaresEXT_Importar.ReadOnly = true;
		dgAuxiliaresEXT_Importar.RowHeadersVisible = false;
		dgAuxiliaresEXT_Importar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgAuxiliaresEXT_Importar.Size = new Size(312, 299);
		dgAuxiliaresEXT_Importar.TabIndex = 117;
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
		Groupbox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		Groupbox2.Controls.Add(DGModelosDWG_Caderno);
		Groupbox2.Location = new Point(14, 345);
		Groupbox2.Name = "Groupbox2";
		Groupbox2.Size = new Size(600, 247);
		Groupbox2.TabIndex = 189;
		Groupbox2.TabStop = false;
		Groupbox2.Text = "gbDWGCorrente";
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
		DGModelosDWG_Caderno.Size = new Size(587, 222);
		DGModelosDWG_Caderno.TabIndex = 117;
		dgAuxiliaresDWG_Caderno.AllowUserToAddRows = false;
		dgAuxiliaresDWG_Caderno.AllowUserToDeleteRows = false;
		dgAuxiliaresDWG_Caderno.AllowUserToOrderColumns = true;
		dgAuxiliaresDWG_Caderno.AllowUserToResizeRows = false;
		dgAuxiliaresDWG_Caderno.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgAuxiliaresDWG_Caderno.BackgroundColor = SystemColors.ButtonHighlight;
		dgAuxiliaresDWG_Caderno.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgAuxiliaresDWG_Caderno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgAuxiliaresDWG_Caderno.Location = new Point(5, 15);
		dgAuxiliaresDWG_Caderno.MultiSelect = false;
		dgAuxiliaresDWG_Caderno.Name = "dgAuxiliaresDWG_Caderno";
		dgAuxiliaresDWG_Caderno.ReadOnly = true;
		dgAuxiliaresDWG_Caderno.RowHeadersVisible = false;
		dgAuxiliaresDWG_Caderno.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgAuxiliaresDWG_Caderno.Size = new Size(312, 222);
		dgAuxiliaresDWG_Caderno.TabIndex = 191;
		GroupBox1.Controls.Add(btSelCadrno);
		GroupBox1.Controls.Add(tbCaminho);
		GroupBox1.Location = new Point(12, 14);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(602, 53);
		GroupBox1.TabIndex = 190;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		GroupBoxContatosOrigem.Controls.Add(dgAuxiliaresEXT_Importar);
		GroupBoxContatosOrigem.Location = new Point(623, 14);
		GroupBoxContatosOrigem.Name = "GroupBoxContatosOrigem";
		GroupBoxContatosOrigem.Size = new Size(324, 324);
		GroupBoxContatosOrigem.TabIndex = 192;
		GroupBoxContatosOrigem.TabStop = false;
		GroupBoxContatosOrigem.Text = "GroupBoxContatosOrigem";
		GroupBoxContatosDestino.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBoxContatosDestino.Controls.Add(dgAuxiliaresDWG_Caderno);
		GroupBoxContatosDestino.Location = new Point(625, 345);
		GroupBoxContatosDestino.Name = "GroupBoxContatosDestino";
		GroupBoxContatosDestino.Size = new Size(324, 247);
		GroupBoxContatosDestino.TabIndex = 193;
		GroupBoxContatosDestino.TabStop = false;
		GroupBoxContatosDestino.Text = "GroupBoxContatosDestino";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(959, 598);
		Controls.Add(GroupBoxContatosDestino);
		Controls.Add(GroupBoxContatosOrigem);
		Controls.Add(GroupBox1);
		Controls.Add(Groupbox2);
		Controls.Add(Groupbox3);
		MaximizeBox = false;
		MaximumSize = new Size(975, 1000);
		MinimumSize = new Size(975, 610);
		Name = "frmImportarModelosDeContatos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmClonar Modelos de Contatos";
		((ISupportInitialize)DGModelosEXT_Importar).EndInit();
		Groupbox3.ResumeLayout(performLayout: false);
		Groupbox3.PerformLayout();
		((ISupportInitialize)dgAuxiliaresEXT_Importar).EndInit();
		Groupbox2.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGModelosDWG_Caderno).EndInit();
		((ISupportInitialize)dgAuxiliaresDWG_Caderno).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBoxContatosOrigem.ResumeLayout(performLayout: false);
		GroupBoxContatosDestino.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return vHMdg7UxFp;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		vHMdg7UxFp = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return O0QdAGhy99;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		O0QdAGhy99 = WithEventsValue;
	}

	public frmImportarModelosDeContatos()
	{
		VcCfj45e9c = 0;
		s0yfLjsaC9 = 0;
		g1RfwCfP51 = new DataGridViewCellStyle();
		ApTfxfDmMw = new DataGridViewCellStyle();
		Sxsfbwh1i8 = null;
		G4GfMJG1yq = null;
		uVYfO64OaU = null;
		De3fIokX52 = null;
		try
		{
			if (!Geral.ExisteForm("frmImportarModelosDeContatos") && clsAuxiliar.BancoValido())
			{
				fEwd26mATJ();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1653]);
				GroupBox1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 600], " - "), DeclaracoesGeral.mMensagem[1, 109]));
				Groupbox2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 109], " - "), DeclaracoesGeral.mMensagem[1, 1654]));
				Groupbox3.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 600], " - "), DeclaracoesGeral.mMensagem[1, 1654]));
				GroupBoxContatosOrigem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 600], " - "), DeclaracoesGeral.mMensagem[1, 653]));
				GroupBoxContatosDestino.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 109], " - "), DeclaracoesGeral.mMensagem[1, 653]));
				lbIndex.Text = "#";
				LbModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
				lbMateriais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 656]);
				lbTerminaisModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 659]);
				lbOrientacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]);
				lbTopografico.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 657]);
				lbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 658]);
				BTAdiciona.Enabled = true;
				tbCaminho.ReadOnly = true;
				Application.ShowModelessDialog((Form)this);
				Sxsfbwh1i8 = new Declaracoes2.MModelosDeContatos[1];
				DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref Sxsfbwh1i8);
				DataGridView dg = DGModelosDWG_Caderno;
				clsDispositivo.carregaModelosNoDG(ref dg, Sxsfbwh1i8);
				DGModelosDWG_Caderno = dg;
				DGModelosDWG_Caderno.Rows[0].Selected = false;
				BTAdiciona.Enabled = false;
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

	private void rodd33o8Ro(object P_0, EventArgs P_1)
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
			clsImportarModelos.CarregaModelosContatosOutroCaderno(tbCaminho.Text, ref uVYfO64OaU);
			DataGridView dg = DGModelosEXT_Importar;
			clsDispositivo.carregaModelosNoDG(ref dg, uVYfO64OaU);
			DGModelosEXT_Importar = dg;
			if (DGModelosEXT_Importar.RowCount != 0)
			{
				DGModelosEXT_Importar.Rows[0].Selected = false;
				tbIndice.BackColor = Color.White;
				tbModelo.BackColor = Color.White;
				dgAuxiliaresEXT_Importar.Rows.Clear();
				dgAuxiliaresEXT_Importar.Columns.Clear();
				BTAdiciona.Enabled = true;
				tbCaminho.ReadOnly = true;
				AnalisaModelos("T");
			}
		}
		else
		{
			DGModelosEXT_Importar.Rows.Clear();
			DGModelosEXT_Importar.Columns.Clear();
			dgAuxiliaresEXT_Importar.Rows.Clear();
			dgAuxiliaresEXT_Importar.Columns.Clear();
			DGModelosDWG_Caderno.Rows.Clear();
			DGModelosDWG_Caderno.Columns.Clear();
			dgAuxiliaresDWG_Caderno.Rows.Clear();
			dgAuxiliaresDWG_Caderno.Columns.Clear();
		}
	}

	private void zw7dni9Vhf(object P_0, EventArgs P_1)
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
			int num = Information.UBound(Sxsfbwh1i8) - 1;
			int num2 = 0;
			int num5 = default;
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
				clsDispositivo.ApagaUmModelo(num3);
				int num4 = 0;
				num5 = DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref Sxsfbwh1i8);
				num4 = Information.UBound(Sxsfbwh1i8) + 1;
				ref Declaracoes2.MModelosDeContatos[] sxsfbwh1i = ref Sxsfbwh1i8;
				sxsfbwh1i = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(sxsfbwh1i, new Declaracoes2.MModelosDeContatos[num4 + 1]);
				bool flag = true;
				if (DGModelosDWG_Caderno.RowCount != 0)
				{
					int num6 = DGModelosDWG_Caderno.Rows.Count - 1;
					for (int i = 0; i <= num6; i++)
					{
						if (Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value.ToString()) >= num5)
						{
							num5 = Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value.ToString()) + 1;
						}
						if (Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value.ToString()) == num3)
						{
							flag = false;
						}
					}
				}
				if ((num5 < num3) | flag)
				{
					num5 = num3;
				}
				if (num5 == 0)
				{
					num5 = 1;
				}
				Sxsfbwh1i8[num4].iIndiceModelo = num5;
				Sxsfbwh1i8[num4].sNomeModelo = tbModelo.Text.ToString();
				Sxsfbwh1i8[num4].iLM1 = Conversions.ToInteger(tbLM1.Text);
				Sxsfbwh1i8[num4].iLM2 = Conversions.ToInteger(tbLM2.Text);
				Sxsfbwh1i8[num4].sBlocoTopografico = tbBlocoTopografico.Text.ToString();
				Sxsfbwh1i8[num4].sBlocoLayout = tbBlocoLayout.Text.ToString();
				Sxsfbwh1i8[num4].sTerminaisDoDispositivo = TBTerminais.Text;
				Sxsfbwh1i8[num4].sOrientacao = tbOrientacao.Text;
				DicionarioContatos.GravaOsModelosDeDispositivosDeDicionario(ref Sxsfbwh1i8);
				int iMaxIndice = 0;
				int num7 = De3fIokX52.Count() - 1;
				for (int j = 0; j <= num7; j++)
				{
					if (De3fIokX52[j].iIndice >= iMaxIndice)
					{
						iMaxIndice = De3fIokX52[j].iIndice + 1;
					}
				}
				DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(num5, ref iMaxIndice, De3fIokX52);
				break;
			}
			Sxsfbwh1i8 = new Declaracoes2.MModelosDeContatos[1];
			DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref Sxsfbwh1i8);
			DataGridView dg = DGModelosDWG_Caderno;
			clsDispositivo.carregaModelosNoDG(ref dg, Sxsfbwh1i8);
			DGModelosDWG_Caderno = dg;
			int num8 = DGModelosDWG_Caderno.Rows.Count - 1;
			for (int k = 0; k <= num8; k++)
			{
				if (Operators.CompareString(DGModelosDWG_Caderno.Rows[k].Cells[0].Value.ToString(), num5.ToString(), TextCompare: true) == 0)
				{
					DGModelosDWG_Caderno.Rows[k].Cells[0].Selected = true;
					DGModelosDWG_Caderno.FirstDisplayedScrollingRowIndex = k;
					mostraModeloDWG();
					break;
				}
			}
			DGModelosEXT_Importar.Focus();
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
				g1RfwCfP51.BackColor = Color.LightCoral;
				ApTfxfDmMw.BackColor = Color.White;
				if (DGModelosDWG_Caderno.Rows.Count > 0)
				{
					BTAdiciona.Enabled = true;
				}
				int num = DGModelosDWG_Caderno.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DGModelosDWG_Caderno.Rows[i].Cells[0].Style = ApTfxfDmMw;
					DGModelosDWG_Caderno.Rows[i].Cells[1].Style = ApTfxfDmMw;
				}
				int num2 = dgAuxiliaresDWG_Caderno.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgAuxiliaresDWG_Caderno.Rows[j].Cells[4].Style = ApTfxfDmMw;
				}
				int num3 = DGModelosDWG_Caderno.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (Operators.CompareString(tbIndice.Text.ToString(), DGModelosDWG_Caderno.Rows[k].Cells[0].Value.ToString(), TextCompare: true) == 0)
					{
						tbIndice.BackColor = Color.LightCoral;
						DGModelosDWG_Caderno.FirstDisplayedScrollingRowIndex = k;
						if (DGModelosDWG_Caderno.SelectedRows.Count == 1)
						{
							tbIndice.BackColor = Color.White;
							if (Operators.CompareString(sValorDigitado, "I", TextCompare: true) == 0)
							{
								tbIndice.Text = DGModelosDWG_Caderno.Rows[k].Cells[0].Value.ToString();
							}
						}
						BTAdiciona.Enabled = false;
					}
					if (Operators.CompareString(tbModelo.Text.ToString(), DGModelosDWG_Caderno.Rows[k].Cells[1].Value.ToString(), TextCompare: true) == 0)
					{
						tbModelo.BackColor = Color.LightCoral;
						if (Operators.CompareString(sValorDigitado, "M", TextCompare: true) == 0 && Operators.ConditionalCompareObjectEqual(tbModelo.Text.ToString(), DGModelosDWG_Caderno.Rows[k].Cells[1].Value, TextCompare: true))
						{
							tbModelo.BackColor = Color.White;
						}
						DGModelosDWG_Caderno.FirstDisplayedScrollingRowIndex = k;
						BTAdiciona.Enabled = false;
					}
				}
				if ((!Information.IsNothing(De3fIokX52) & !Information.IsNothing(G4GfMJG1yq)) && ((De3fIokX52.Count() > 0) & (G4GfMJG1yq.Count() > 0)))
				{
					int num4 = De3fIokX52.Count();
					if (De3fIokX52.Count() > G4GfMJG1yq.Count())
					{
						num4 = G4GfMJG1yq.Count();
					}
					int num5 = 0;
					int num6 = 0;
					int num7 = num4 - 1;
					for (num6 = 1; num6 <= num7; num6++)
					{
						num5 = num6 - 1;
						if (!((Operators.CompareString(G4GfMJG1yq[num6].sTipo, "NA", TextCompare: true) == 0) & (Operators.CompareString(De3fIokX52[num6].sTipo, "RV", TextCompare: true) == 0)))
						{
						}
						if (!((Operators.CompareString(G4GfMJG1yq[num6].sTipo, "NF", TextCompare: true) == 0) & (Operators.CompareString(De3fIokX52[num6].sTipo, "RV", TextCompare: true) == 0)))
						{
						}
						if (((Operators.CompareString(G4GfMJG1yq[num6].sTipo, "NA", TextCompare: true) == 0) & (Operators.CompareString(De3fIokX52[num6].sTipo, "NF", TextCompare: true) == 0)) && clsDispositivoAuxiliares.ExisteDispositivoAuxiliar(s0yfLjsaC9, De3fIokX52[num6].iIndice) && !BTAdiciona.Enabled)
						{
							dgAuxiliaresDWG_Caderno.Rows[num5].Cells[4].Style = g1RfwCfP51;
						}
						if (((Operators.CompareString(G4GfMJG1yq[num6].sTipo, "NF", TextCompare: true) == 0) & (Operators.CompareString(De3fIokX52[num6].sTipo, "NA", TextCompare: true) == 0)) && clsDispositivoAuxiliares.ExisteDispositivoAuxiliar(s0yfLjsaC9, De3fIokX52[num6].iIndice) && !BTAdiciona.Enabled)
						{
							dgAuxiliaresDWG_Caderno.Rows[num5].Cells[4].Style = g1RfwCfP51;
						}
						if (((Operators.CompareString(G4GfMJG1yq[num6].sTipo, "RV", TextCompare: true) == 0) & (Operators.CompareString(De3fIokX52[num6].sTipo, "NA", TextCompare: true) == 0)) && clsDispositivoAuxiliares.ExisteDispositivoDiferente(De3fIokX52[num6].sTipo, s0yfLjsaC9, G4GfMJG1yq[num6].iIndice) && !BTAdiciona.Enabled)
						{
							dgAuxiliaresDWG_Caderno.Rows[num5].Cells[4].Style = g1RfwCfP51;
						}
						if (((Operators.CompareString(G4GfMJG1yq[num6].sTipo, "RV", TextCompare: true) == 0) & (Operators.CompareString(De3fIokX52[num6].sTipo, "NF", TextCompare: true) == 0)) && clsDispositivoAuxiliares.ExisteDispositivoDiferente(De3fIokX52[num6].sTipo, s0yfLjsaC9, G4GfMJG1yq[num6].iIndice) && !BTAdiciona.Enabled)
						{
							dgAuxiliaresDWG_Caderno.Rows[num5].Cells[4].Style = g1RfwCfP51;
						}
					}
					int num8 = num6;
					int num9 = G4GfMJG1yq.Count() - 1;
					for (int l = num8; l <= num9; l++)
					{
						num5 = l - 1;
						if (clsDispositivoAuxiliares.ExisteDispositivoAuxiliar(s0yfLjsaC9, G4GfMJG1yq[l].iIndice) && !BTAdiciona.Enabled)
						{
							dgAuxiliaresDWG_Caderno.Rows[num5].Cells[4].Style = g1RfwCfP51;
						}
					}
				}
				if ((DGModelosDWG_Caderno.Rows.Count == 0) & (DGModelosEXT_Importar.Rows.Count > 0))
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

	private void Aind1RxGuh(object P_0, DataGridViewCellEventArgs P_1)
	{
		mostraModeloMascaraEXT();
	}

	private void X59dlNrVTK(object P_0, KeyEventArgs P_1)
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
				if (Operators.ConditionalCompareObjectNotEqual(VcCfj45e9c, DGModelosEXT_Importar.Rows[i].Cells[0].Value, TextCompare: true))
				{
					VcCfj45e9c = Conversions.ToInteger(DGModelosEXT_Importar.Rows[i].Cells[0].Value);
					tbIndice.Text = Conversions.ToString(DGModelosEXT_Importar.Rows[i].Cells[0].Value);
					tbModelo.Text = Conversions.ToString(DGModelosEXT_Importar.Rows[i].Cells[1].Value);
					tbLM1.Text = DGModelosEXT_Importar.Rows[i].Cells[2].Value.ToString();
					tbLM2.Text = DGModelosEXT_Importar.Rows[i].Cells[3].Value.ToString();
					tbBlocoTopografico.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
					{
						tbBlocoTopografico.BackColor = Color.White;
					}
					tbBlocoTopografico.Text = DGModelosEXT_Importar.Rows[i].Cells[5].Value.ToString().ToUpper().Trim();
					tbBlocoLayout.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
					{
						tbBlocoLayout.BackColor = Color.White;
					}
					tbBlocoLayout.Text = DGModelosEXT_Importar.Rows[i].Cells[6].Value.ToString().ToUpper().Trim();
					TBTerminais.Text = Conversions.ToString(DGModelosEXT_Importar.Rows[i].Cells[9].Value);
					tbOrientacao.Text = DGModelosEXT_Importar.Rows[i].Cells[10].Value.ToString().ToUpper();
					int iIndiceModelo = Conversions.ToInteger(DGModelosEXT_Importar.Rows[i].Cells[0].Value);
					string nomeModelo = Conversions.ToString(DGModelosEXT_Importar.Rows[i].Cells[1].Value);
					clsImportarModelos.CarregaContatosAuxOutroCadreno(tbCaminho.Text, iIndiceModelo, nomeModelo, ref De3fIokX52);
					DataGridView DGContatos = dgAuxiliaresEXT_Importar;
					clsDispositivoAuxiliares.carregaContatosNoDG(ref DGContatos, De3fIokX52);
					dgAuxiliaresEXT_Importar = DGContatos;
				}
				break;
			}
			string text = "";
			text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1655], ""), tbModelo.Text), DeclaracoesGeral.mMensagem[1, 1644]), DeclaracoesGeral.Conf.Local));
			w8dpBZ0kvSD().SetToolTip(BTAdiciona, text);
			AnalisaModelos("T");
		}
	}

	private void eImd5oEnIF(object P_0, DataGridViewCellEventArgs P_1)
	{
		mostraModeloDWG();
	}

	private void VQZd0REtID(object P_0, KeyEventArgs P_1)
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
					s0yfLjsaC9 = Conversions.ToInteger(DGModelosDWG_Caderno.Rows[i].Cells[0].Value);
					DGModelosDWG_Caderno.FirstDisplayedScrollingRowIndex = i;
					G4GfMJG1yq = new Declaracoes2.StructureContatosAuxiliares[1];
					DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref s0yfLjsaC9, ref G4GfMJG1yq);
					DataGridView DGContatos = dgAuxiliaresDWG_Caderno;
					clsDispositivoAuxiliares.carregaContatosNoDG(ref DGContatos, G4GfMJG1yq);
					dgAuxiliaresDWG_Caderno = DGContatos;
					break;
				}
			}
			if (DGModelosEXT_Importar.Rows.Count != 0)
			{
				AnalisaModelos("M");
			}
		}
	}

	private void d40dR2nkOE(object P_0, KeyEventArgs P_1)
	{
		AnalisaModelos("M");
	}

	private void mT4dmMsu1r(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = tbModelo;
		clsTextos.NomeValido(ref tbNome);
		tbModelo = tbNome;
		AnalisaModelos("M");
	}

	private void tlmdXRYjLT(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbLM1.Text));
		tbLM1.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		frmPesquisaMateriais2.Dispose();
	}

	private void iuXdUxWdL8(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbLM2.Text));
		tbLM2.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		frmPesquisaMateriais2.Dispose();
	}
}
