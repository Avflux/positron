using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmGerenciadorMatIndep : Form
{
	private IContainer ooZppgGnFwF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPaineis")]
	private DataGridView ppappA5btlP;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip gSCppskgTqJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTEditaLM")]
	[CompilerGenerated]
	private Button dykppBRrn1p;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAdicionaLM")]
	private Button l3ippVH3fbn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTApagaLM")]
	private Button bibppuDCval;

	[CompilerGenerated]
	[AccessedThroughProperty("LbTag")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label gvOppEsWmUs;

	[AccessedThroughProperty("TBTag")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox aURppZZAEXf;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbQuantidade")]
	private Label iIvppirPyvS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBQuantidade")]
	private TextBox XE4ppSny2Nv;

	[AccessedThroughProperty("dgDisp")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView w4xpp4gRlOF;

	[AccessedThroughProperty("GroupBox4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox a2EppCcSRO0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbFabricante")]
	[CompilerGenerated]
	private Label wKYppYe27T4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbModelo")]
	[CompilerGenerated]
	private Label H21pprXDZM8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDesc")]
	[CompilerGenerated]
	private Label kxopp9IZY4i;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbCodigo")]
	private Label QCTppz5p6QQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFabricante1")]
	private TextBox PDopTWIoWs7;

	[AccessedThroughProperty("tbModelo1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox r87pTptPhqg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricaoResum1")]
	private TextBox OQwpTT4EqSb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCodigo1")]
	private TextBox tsvpTJigGhQ;

	[CompilerGenerated]
	[AccessedThroughProperty("btPesquisaLM1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button zgppThYhsn7;

	private string onCpTo358Oy;

	private int mTqpTGZErsQ;

	private bool RoPpTHKyjmG;

	private bool jstpTkBBjLm;

	private clsLM.mPN[] Ap3pTdrGUfS;

	private int rfCpTfmCm7Q;

	private bool fjYpTDDQNkw;

	private int[] a7ipTvhuQli;

	private bool UxCpT6QcFwa;

	private DeclaracoesClonar.structureMaterial[] sFDpTtH7Q6V;

	internal virtual DataGridView dgPaineis
	{
		[CompilerGenerated]
		get
		{
			return ppappA5btlP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VWApplKq3XZ;
			DataGridView dataGridView = ppappA5btlP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			ppappA5btlP = value;
			dataGridView = ppappA5btlP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button BTEditaLM
	{
		[CompilerGenerated]
		get
		{
			return dykppBRrn1p;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eK4ppmS0dUi;
			Button button = dykppBRrn1p;
			if (button != null)
			{
				button.Click -= value2;
			}
			dykppBRrn1p = value;
			button = dykppBRrn1p;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAdicionaLM
	{
		[CompilerGenerated]
		get
		{
			return l3ippVH3fbn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jnTppR04rG4;
			Button button = l3ippVH3fbn;
			if (button != null)
			{
				button.Click -= value2;
			}
			l3ippVH3fbn = value;
			button = l3ippVH3fbn;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTApagaLM
	{
		[CompilerGenerated]
		get
		{
			return bibppuDCval;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eUVppXAWerf;
			Button button = bibppuDCval;
			if (button != null)
			{
				button.Click -= value2;
			}
			bibppuDCval = value;
			button = bibppuDCval;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LbTag
	{
		[CompilerGenerated]
		get
		{
			return gvOppEsWmUs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gvOppEsWmUs = value;
		}
	}

	internal virtual TextBox TBTag
	{
		[CompilerGenerated]
		get
		{
			return aURppZZAEXf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aURppZZAEXf = value;
		}
	}

	internal virtual Label lbQuantidade
	{
		[CompilerGenerated]
		get
		{
			return iIvppirPyvS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iIvppirPyvS = value;
		}
	}

	internal virtual TextBox TBQuantidade
	{
		[CompilerGenerated]
		get
		{
			return XE4ppSny2Nv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XE4ppSny2Nv = value;
		}
	}

	internal virtual DataGridView dgDisp
	{
		[CompilerGenerated]
		get
		{
			return w4xpp4gRlOF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = U7Epp0og4bx;
			DataGridView dataGridView = w4xpp4gRlOF;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			w4xpp4gRlOF = value;
			dataGridView = w4xpp4gRlOF;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return a2EppCcSRO0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a2EppCcSRO0 = value;
		}
	}

	internal virtual Label lbFabricante
	{
		[CompilerGenerated]
		get
		{
			return wKYppYe27T4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wKYppYe27T4 = value;
		}
	}

	internal virtual Label lbModelo
	{
		[CompilerGenerated]
		get
		{
			return H21pprXDZM8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			H21pprXDZM8 = value;
		}
	}

	internal virtual Label lbDesc
	{
		[CompilerGenerated]
		get
		{
			return kxopp9IZY4i;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kxopp9IZY4i = value;
		}
	}

	internal virtual Label lbCodigo
	{
		[CompilerGenerated]
		get
		{
			return QCTppz5p6QQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QCTppz5p6QQ = value;
		}
	}

	internal virtual TextBox tbFabricante1
	{
		[CompilerGenerated]
		get
		{
			return PDopTWIoWs7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PDopTWIoWs7 = value;
		}
	}

	internal virtual TextBox tbModelo1
	{
		[CompilerGenerated]
		get
		{
			return r87pTptPhqg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			r87pTptPhqg = value;
		}
	}

	internal virtual TextBox tbDescricaoResum1
	{
		[CompilerGenerated]
		get
		{
			return OQwpTT4EqSb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OQwpTT4EqSb = value;
		}
	}

	internal virtual TextBox tbCodigo1
	{
		[CompilerGenerated]
		get
		{
			return tsvpTJigGhQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tsvpTJigGhQ = value;
		}
	}

	internal virtual Button btPesquisaLM1
	{
		[CompilerGenerated]
		get
		{
			return zgppThYhsn7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = K7hppy1EMVI;
			Button button = zgppThYhsn7;
			if (button != null)
			{
				button.Click -= value2;
			}
			zgppThYhsn7 = value;
			button = zgppThYhsn7;
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
			if (disposing && ooZppgGnFwF != null)
			{
				ooZppgGnFwF.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void pvLppnJmGme()
	{
		ooZppgGnFwF = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgPaineis = new DataGridView();
		FDqpBiUmZij(new ToolTip(ooZppgGnFwF));
		BTEditaLM = new Button();
		BTAdicionaLM = new Button();
		BTApagaLM = new Button();
		LbTag = new Label();
		TBTag = new TextBox();
		lbQuantidade = new Label();
		TBQuantidade = new TextBox();
		dgDisp = new DataGridView();
		GroupBox4 = new GroupBox();
		lbFabricante = new Label();
		lbModelo = new Label();
		lbDesc = new Label();
		lbCodigo = new Label();
		tbFabricante1 = new TextBox();
		tbModelo1 = new TextBox();
		tbDescricaoResum1 = new TextBox();
		tbCodigo1 = new TextBox();
		btPesquisaLM1 = new Button();
		((ISupportInitialize)dgPaineis).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		GroupBox4.SuspendLayout();
		SuspendLayout();
		dgPaineis.AllowUserToAddRows = false;
		dgPaineis.AllowUserToDeleteRows = false;
		dgPaineis.AllowUserToOrderColumns = true;
		dgPaineis.AllowUserToResizeRows = false;
		dgPaineis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPaineis.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgPaineis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineis.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaineis.Location = new Point(12, 12);
		dgPaineis.MultiSelect = false;
		dgPaineis.Name = "dgPaineis";
		dgPaineis.ReadOnly = true;
		dgPaineis.RowHeadersVisible = false;
		dgPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineis.Size = new Size(182, 154);
		dgPaineis.TabIndex = 8;
		BTEditaLM.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTEditaLM.FlatStyle = FlatStyle.Flat;
		BTEditaLM.ForeColor = SystemColors.Control;
		BTEditaLM.Image = Resources.Editar;
		BTEditaLM.Location = new Point(660, 209);
		BTEditaLM.Name = "BTEditaLM";
		BTEditaLM.Size = new Size(40, 40);
		BTEditaLM.TabIndex = 135;
		BTEditaLM.UseVisualStyleBackColor = true;
		BTAdicionaLM.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTAdicionaLM.FlatStyle = FlatStyle.Flat;
		BTAdicionaLM.ForeColor = SystemColors.Control;
		BTAdicionaLM.Image = Resources.Adiciona_32;
		BTAdicionaLM.Location = new Point(691, 172);
		BTAdicionaLM.Name = "BTAdicionaLM";
		BTAdicionaLM.Size = new Size(40, 40);
		BTAdicionaLM.TabIndex = 134;
		BTAdicionaLM.UseVisualStyleBackColor = true;
		BTApagaLM.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTApagaLM.FlatStyle = FlatStyle.Flat;
		BTApagaLM.ForeColor = SystemColors.Control;
		BTApagaLM.Image = Resources.Delete_32;
		BTApagaLM.Location = new Point(708, 209);
		BTApagaLM.Name = "BTApagaLM";
		BTApagaLM.Size = new Size(40, 40);
		BTApagaLM.TabIndex = 133;
		BTApagaLM.Tag = "";
		BTApagaLM.UseVisualStyleBackColor = true;
		LbTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbTag.Location = new Point(12, 169);
		LbTag.Name = "LbTag";
		LbTag.Size = new Size(64, 16);
		LbTag.TabIndex = 170;
		LbTag.Text = "lbDisp";
		TBTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBTag.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTag.Location = new Point(12, 183);
		TBTag.Name = "TBTag";
		TBTag.Size = new Size(64, 20);
		TBTag.TabIndex = 169;
		lbQuantidade.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbQuantidade.Location = new Point(12, 211);
		lbQuantidade.Name = "lbQuantidade";
		lbQuantidade.Size = new Size(82, 15);
		lbQuantidade.TabIndex = 174;
		lbQuantidade.Text = "lbQuantidade";
		TBQuantidade.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBQuantidade.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBQuantidade.Location = new Point(12, 229);
		TBQuantidade.Name = "TBQuantidade";
		TBQuantidade.Size = new Size(64, 20);
		TBQuantidade.TabIndex = 173;
		dgDisp.AllowDrop = true;
		dgDisp.AllowUserToAddRows = false;
		dgDisp.AllowUserToDeleteRows = false;
		dgDisp.AllowUserToResizeRows = false;
		dgDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDisp.Location = new Point(203, 10);
		dgDisp.MultiSelect = false;
		dgDisp.Name = "dgDisp";
		dgDisp.RowHeadersVisible = false;
		dgDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDisp.Size = new Size(545, 156);
		dgDisp.TabIndex = 178;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(lbFabricante);
		GroupBox4.Controls.Add(lbModelo);
		GroupBox4.Controls.Add(lbDesc);
		GroupBox4.Controls.Add(lbCodigo);
		GroupBox4.Controls.Add(tbFabricante1);
		GroupBox4.Controls.Add(tbModelo1);
		GroupBox4.Controls.Add(tbDescricaoResum1);
		GroupBox4.Controls.Add(tbCodigo1);
		GroupBox4.Controls.Add(btPesquisaLM1);
		GroupBox4.Location = new Point(100, 183);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(552, 65);
		GroupBox4.TabIndex = 179;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "GroupBox4";
		lbFabricante.Location = new Point(407, 17);
		lbFabricante.Name = "lbFabricante";
		lbFabricante.Size = new Size(111, 16);
		lbFabricante.TabIndex = 207;
		lbFabricante.Text = "Fabricante";
		lbModelo.Location = new Point(290, 16);
		lbModelo.Name = "lbModelo";
		lbModelo.Size = new Size(111, 16);
		lbModelo.TabIndex = 206;
		lbModelo.Text = "Modelo";
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
		tbFabricante1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante1.Location = new Point(407, 36);
		tbFabricante1.Name = "tbFabricante1";
		tbFabricante1.ReadOnly = true;
		tbFabricante1.Size = new Size(111, 20);
		tbFabricante1.TabIndex = 202;
		tbModelo1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo1.Location = new Point(290, 36);
		tbModelo1.Name = "tbModelo1";
		tbModelo1.ReadOnly = true;
		tbModelo1.Size = new Size(111, 20);
		tbModelo1.TabIndex = 200;
		tbDescricaoResum1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum1.Location = new Point(87, 36);
		tbDescricaoResum1.Name = "tbDescricaoResum1";
		tbDescricaoResum1.ReadOnly = true;
		tbDescricaoResum1.Size = new Size(197, 20);
		tbDescricaoResum1.TabIndex = 198;
		tbCodigo1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo1.Location = new Point(8, 36);
		tbCodigo1.Name = "tbCodigo1";
		tbCodigo1.ReadOnly = true;
		tbCodigo1.Size = new Size(73, 20);
		tbCodigo1.TabIndex = 196;
		btPesquisaLM1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM1.FlatStyle = FlatStyle.Flat;
		btPesquisaLM1.ForeColor = SystemColors.Control;
		btPesquisaLM1.Image = Resources.Pesquisar_16;
		btPesquisaLM1.Location = new Point(524, 33);
		btPesquisaLM1.Name = "btPesquisaLM1";
		btPesquisaLM1.Size = new Size(22, 24);
		btPesquisaLM1.TabIndex = 194;
		btPesquisaLM1.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(764, 261);
		Controls.Add(dgDisp);
		Controls.Add(TBQuantidade);
		Controls.Add(TBTag);
		Controls.Add(BTEditaLM);
		Controls.Add(BTAdicionaLM);
		Controls.Add(BTApagaLM);
		Controls.Add(dgPaineis);
		Controls.Add(lbQuantidade);
		Controls.Add(LbTag);
		Controls.Add(GroupBox4);
		MaximizeBox = false;
		MinimumSize = new Size(780, 300);
		Name = "frmGerenciadorMatIndep";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Relatórios de Materiais";
		((ISupportInitialize)dgPaineis).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return gSCppskgTqJ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		gSCppskgTqJ = WithEventsValue;
	}

	public frmGerenciadorMatIndep()
	{
		Resize += LRqppUWsUxd;
		onCpTo358Oy = "";
		mTqpTGZErsQ = 0;
		RoPpTHKyjmG = false;
		jstpTkBBjLm = false;
		rfCpTfmCm7Q = 0;
		fjYpTDDQNkw = false;
		UxCpT6QcFwa = false;
		try
		{
			if (!Geral.ExisteForm("frmGerenciadorMatIndep") && clsAuxiliar.BancoValido())
			{
				pvLppnJmGme();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 586]);
				LbTag.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 804]);
				lbQuantidade.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 797]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]);
				lbCodigo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1245]);
				lbDesc.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
				lbModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
				lbFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]);
				cDadosAccess.carregaDadosDWG();
				cDadosLM cDadosLM2 = new cDadosLM();
				sFDpTtH7Q6V = cDadosLM2.CarregaDadosLMMatriz();
				cDadosLM2.fechaConexao();
				clsLM.PaineisDocumentoLM(ref Ap3pTdrGUfS);
				formataDGPainelLM();
				CarregaDGPainelLM(Ap3pTdrGUfS);
				AtualizaDGPainelLM();
				w8dpBZ0kvSD().SetToolTip(BTAdicionaLM, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1164]));
				w8dpBZ0kvSD().SetToolTip(BTEditaLM, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1165]));
				w8dpBZ0kvSD().SetToolTip(BTApagaLM, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1166]));
				tbCodigo1.Text = "0";
				formataDGDisp();
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				oZXpp56N3Ah();
				dgDisp.MultiSelect = true;
				rfCpTfmCm7Q = 100000;
				a7ipTvhuQli = new int[1];
				UxCpT6QcFwa = true;
				AtualizaDGPainelLM();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void ODLpp1Gpc7y(int P_0)
	{
		tbCodigo1.Text = Conversions.ToString(0);
		tbDescricaoResum1.Text = "";
		tbModelo1.Text = "";
		tbFabricante1.Text = "";
		int num = Information.UBound(sFDpTtH7Q6V);
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (sFDpTtH7Q6V[num2].CodigoInterno == P_0)
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return;
		}
		tbCodigo1.Text = Conversions.ToString(P_0);
		tbDescricaoResum1.Text = sFDpTtH7Q6V[num2].DescricaoResumida;
		tbModelo1.Text = sFDpTtH7Q6V[num2].Modelo;
		tbFabricante1.Text = sFDpTtH7Q6V[num2].Fabricante;
	}

	private void VWApplKq3XZ(object P_0, EventArgs P_1)
	{
		oZXpp56N3Ah();
	}

	private void oZXpp56N3Ah()
	{
		cDadosLM cDadosLM2 = new cDadosLM();
		try
		{
			cDadosLM.structureDispLM[] sDisp = null;
			if (dgPaineis.SelectedRows.Count > 0)
			{
				mTqpTGZErsQ = Conversions.ToInteger(dgPaineis.SelectedRows[0].Cells[0].Value);
				cDadosLM2.CarregaDadosDispositivos(ref sDisp, DeclaracoesGeral.arqAtivo.Indice, mTqpTGZErsQ);
				formataDGDisp();
				CarregaDGDisp(ref sDisp);
			}
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
			cDadosLM2.fechaConexao();
		}
	}

	public void CarregaDGPainelLM(clsLM.mPN[] mPainel)
	{
		try
		{
			if (Information.UBound(mPainel) > 0)
			{
				jstpTkBBjLm = true;
				int num = Information.UBound(mPainel);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgPaineis.Rows.Add(mPainel[i].iPainel, mPainel[i].sPainel);
				}
				jstpTkBBjLm = false;
				if (dgPaineis.RowCount > 0)
				{
					dgPaineis.Rows[0].Selected = true;
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

	public void CarregaDGDisp(ref cDadosLM.structureDispLM[] sDisp)
	{
		try
		{
			if (Information.UBound(sDisp) > 0)
			{
				jstpTkBBjLm = true;
				int num = Information.UBound(sDisp);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgDisp.Rows.Add(sDisp[i].Indice, sDisp[i].iDWG, sDisp[i].iPainel, sDisp[i].sTag, sDisp[i].iIndiceMaterial, sDisp[i].iQuantidade, sDisp[i].lOrdem, sDisp[i].bAvulso, sDisp[i].sDestino, sDisp[i].sDescDestino, sDisp[i].sAlternativo, sDisp[i].sHandle);
				}
				jstpTkBBjLm = false;
				if (dgDisp.RowCount > 0)
				{
					dgDisp.CurrentCell = dgDisp[3, 0];
					dgDisp.Rows[0].Selected = true;
				}
				Redimensionar();
			}
			MesclaDGDisp();
			if (dgDisp.RowCount > 0)
			{
				dgDisp.CurrentCell = dgDisp[3, 0];
				dgDisp.Rows[0].Selected = true;
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

	public void MesclaDGDisp()
	{
		checked
		{
			try
			{
				bool flag = false;
				int num = dgDisp.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDisp[4, i].ErrorText = "";
				}
				int num2 = dgDisp.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = 3;
					do
					{
						dgDisp.Rows[j].Cells[num3].Style.BackColor = Color.LightGray;
						dgDisp.Rows[j].Cells[num3].Style.ForeColor = Color.Black;
						num3++;
					}
					while (num3 <= 5);
					if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[j].Cells[11].Value, "", TextCompare: true))
					{
						int num4 = 3;
						do
						{
							dgDisp.Rows[j].Cells[num4].Style.BackColor = Color.LemonChiffon;
							dgDisp.Rows[j].Cells[num4].Style.ForeColor = Color.Black;
							num4++;
						}
						while (num4 <= 5);
					}
					if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[j].Cells[7].Value, true, TextCompare: true))
					{
						int num5 = 3;
						do
						{
							dgDisp.Rows[j].Cells[num5].Style.BackColor = Color.LightCyan;
							dgDisp.Rows[j].Cells[num5].Style.ForeColor = Color.Black;
							num5++;
						}
						while (num5 <= 5);
					}
					flag = false;
					int num6 = Information.UBound(sFDpTtH7Q6V);
					for (int k = 0; k <= num6; k++)
					{
						if (Operators.ConditionalCompareObjectEqual(sFDpTtH7Q6V[k].CodigoInterno, dgDisp.Rows[j].Cells[4].Value, TextCompare: true))
						{
							flag = true;
							break;
						}
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dgDisp.Rows[j].Cells[11].Value, "", TextCompare: true), Operators.CompareString(dgDisp.Rows[j].Cells[4].Value.ToString(), "0", TextCompare: true) == 0)))
					{
						dgDisp[4, j].ErrorText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1203], "\r\n"), DeclaracoesGeral.mMensagem[1, 1202]));
					}
					if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[j].Cells[7].Value, true, TextCompare: true))
					{
						int num7 = 3;
						do
						{
							dgDisp[num7, j].ToolTipText = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1200]);
							num7++;
						}
						while (num7 <= 5);
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dgDisp.Rows[j].Cells[11].Value, "", TextCompare: true), Operators.CompareObjectEqual(dgDisp.Rows[j].Cells[7].Value, false, TextCompare: true))))
					{
						int num8 = 3;
						do
						{
							dgDisp[num8, j].ToolTipText = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1201]);
							num8++;
						}
						while (num8 <= 5);
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dgDisp.Rows[j].Cells[11].Value, "", TextCompare: true), Operators.CompareString(dgDisp.Rows[j].Cells[4].Value.ToString(), "0", TextCompare: true) == 0)))
					{
						if (!Operators.ConditionalCompareObjectEqual(dgDisp.Rows[j].Cells[7].Value, true, TextCompare: true))
						{
							dgDisp[4, j].ErrorText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1201], "\r\n"), DeclaracoesGeral.mMensagem[1, 1202]));
						}
						else
						{
							dgDisp[4, j].ErrorText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1200], "\r\n"), DeclaracoesGeral.mMensagem[1, 1202]));
						}
					}
					if (!flag & (Operators.CompareString(dgDisp.Rows[j].Cells[4].Value.ToString(), "0", TextCompare: true) != 0))
					{
						dgDisp.Rows[j].Cells[4].Style.BackColor = Color.LightCoral;
						dgDisp.Rows[j].Cells[4].Style.ForeColor = Color.White;
						dgDisp[4, j].ErrorText = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1204], "\r\n"), DeclaracoesGeral.mMensagem[1, 1205]));
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
	}

	private void U7Epp0og4bx(object P_0, EventArgs P_1)
	{
		int num = 0;
		TBTag.Text = "";
		TBQuantidade.Text = "";
		tbCodigo1.Text = Conversions.ToString(0);
		tbDescricaoResum1.Text = "";
		tbModelo1.Text = "";
		tbFabricante1.Text = "";
		BTEditaLM.Enabled = false;
		BTApagaLM.Enabled = false;
		num = 0;
		checked
		{
			int num2 = dgDisp.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgDisp.Rows[i].Selected)
				{
					num = i;
					break;
				}
			}
			if (dgDisp.Rows.Count != 0)
			{
				if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[num].Cells[11].Value, "", TextCompare: true))
				{
					BTEditaLM.Enabled = true;
					BTApagaLM.Enabled = false;
				}
				if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[num].Cells[7].Value, true, TextCompare: true))
				{
					BTEditaLM.Enabled = true;
					BTApagaLM.Enabled = true;
				}
				TBTag.Text = Conversions.ToString(dgDisp.Rows[num].Cells[3].Value);
				TBQuantidade.Text = Conversions.ToString(dgDisp.Rows[num].Cells[5].Value);
				ODLpp1Gpc7y(Conversions.ToInteger(dgDisp.Rows[num].Cells[4].Value));
			}
		}
	}

	private void jnTppR04rG4(object P_0, EventArgs P_1)
	{
		checked
		{
			if (Operators.CompareString(tbCodigo1.Text, "0", TextCompare: true) != 0)
			{
				string text = "";
				dgDisp.Rows.Add(rfCpTfmCm7Q, DeclaracoesGeral.arqAtivo.Indice, mTqpTGZErsQ, TBTag.Text, Conversions.ToInteger(tbCodigo1.Text), Conversions.ToInteger(TBQuantidade.Text), rfCpTfmCm7Q, true, "", "", text, "");
				cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
				DataGridView dg = dgDisp;
				cDadosAccessMateriais2.AdicionaUmItemMaterialAvulso(ref dg, dgDisp.Rows.Count - 1);
				dgDisp = dg;
				cDadosAccessMateriais2.fechaConexao();
				rfCpTfmCm7Q++;
				oZXpp56N3Ah();
				MesclaDGDisp();
				dgDisp.Rows[dgDisp.Rows.Count - 1].Selected = true;
				dgDisp.FirstDisplayedScrollingRowIndex = dgDisp.Rows.Count - 1;
			}
		}
	}

	private void eK4ppmS0dUi(object P_0, EventArgs P_1)
	{
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		if ((Operators.CompareString(TBQuantidade.Text.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(TBQuantidade.Text.Trim(), "0", TextCompare: true) == 0))
		{
			TBQuantidade.Text = "1";
		}
		checked
		{
			int num = dgDisp.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgDisp.Rows[i].Selected)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[i].Cells[7].Value, true, TextCompare: true))
					{
						dgDisp.Rows[i].Cells[3].Value = TBTag.Text;
						dgDisp.Rows[i].Cells[4].Value = Conversions.ToInteger(tbCodigo1.Text);
						dgDisp.Rows[i].Cells[5].Value = TBQuantidade.Text;
						BTEditaLM.Enabled = true;
						BTApagaLM.Enabled = true;
						cDadosAccessMateriais2.RemoveMaterialAvulso(Conversions.ToInteger(dgDisp.Rows[i].Cells[0].Value));
						DataGridView dg = dgDisp;
						cDadosAccessMateriais2.AdicionaUmItemMaterialAvulso(ref dg, i);
						dgDisp = dg;
					}
					if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[i].Cells[11].Value, "", TextCompare: true))
					{
						dgDisp.Rows[i].Cells[4].Value = Conversions.ToInteger(tbCodigo1.Text);
						BTEditaLM.Enabled = true;
						BTApagaLM.Enabled = false;
						int indiceLM = Conversions.ToInteger(dgDisp.Rows[i].Cells[4].Value);
						int indice = Conversions.ToInteger(dgDisp.Rows[i].Cells[0].Value);
						cDadosAccessMateriais2.EditaUmItemMaterialAvulso(indiceLM, indice);
						object[,] array = null;
						array = new object[3, 1];
						int num2 = Information.UBound(array, 2) + 1;
						array = (object[,])Utils.CopyArray(array, new object[3, num2 + 1]);
						array[0, num2] = Conversions.ToInteger(dgDisp.Rows[i].Cells[0].Value);
						array[1, num2] = Conversions.ToInteger(dgDisp.Rows[i].Cells[4].Value);
						array[2, num2] = Conversions.ToString(dgDisp.Rows[i].Cells[11].Value);
						clsDispositivo.EditaLMDoDispositivo(array);
					}
				}
			}
			MesclaDGDisp();
			cDadosAccessMateriais2.fechaConexao();
		}
	}

	private void eUVppXAWerf(object P_0, EventArgs P_1)
	{
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		int num = 0;
		checked
		{
			int num2 = dgDisp.Rows.Count - 1;
			for (int i = num2; i >= 0; i += -1)
			{
				if (Conversions.ToBoolean(Operators.AndObject(dgDisp.Rows[i].Selected, Operators.CompareObjectEqual(dgDisp.Rows[i].Cells[7].Value, true, TextCompare: true))))
				{
					cDadosAccessMateriais2.RemoveMaterialAvulso(Conversions.ToInteger(dgDisp.Rows[i].Cells[0].Value));
					num = i - 1;
				}
			}
			oZXpp56N3Ah();
			MesclaDGDisp();
			cDadosAccessMateriais2.fechaConexao();
			oZXpp56N3Ah();
			if (num > 0)
			{
				dgDisp.Rows[num].Selected = true;
				dgDisp.FirstDisplayedScrollingRowIndex = num;
			}
		}
	}

	public void Redimensionar()
	{
		checked
		{
			if (dgDisp.Columns.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDisp)) ? ((double)(dgDisp.Width - 4)) : ((double)(dgDisp.Width - 21)));
				dgDisp.Columns[0].Width = 0;
				dgDisp.Columns[0].Visible = false;
				dgDisp.Columns[1].Width = 0;
				dgDisp.Columns[1].Visible = false;
				dgDisp.Columns[2].Width = 0;
				dgDisp.Columns[2].Visible = false;
				dgDisp.Columns[3].Width = (int)Math.Round(num * 0.5);
				dgDisp.Columns[3].Visible = true;
				dgDisp.Columns[4].Width = (int)Math.Round(num * 0.25);
				dgDisp.Columns[4].Visible = true;
				dgDisp.Columns[5].Width = (int)Math.Round(num * 0.25);
				dgDisp.Columns[5].Visible = true;
				dgDisp.Columns[6].Width = 0;
				dgDisp.Columns[6].Visible = false;
				dgDisp.Columns[7].Width = 0;
				dgDisp.Columns[7].Visible = false;
				dgDisp.Columns[8].Width = 0;
				dgDisp.Columns[8].Visible = false;
				dgDisp.Columns[9].Width = 0;
				dgDisp.Columns[9].Visible = false;
				dgDisp.Columns[10].Width = 0;
				dgDisp.Columns[10].Visible = false;
				dgDisp.Columns[11].Width = 0;
				dgDisp.Columns[11].Visible = false;
			}
		}
	}

	public void formataDGPainelLM()
	{
		try
		{
			RoPpTHKyjmG = true;
			dgPaineis.Rows.Clear();
			dgPaineis.Columns.Clear();
			dgPaineis.Columns.Add("Indice", "");
			dgPaineis.Columns.Add("Equipamento", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
			AtualizaDGPainelLM();
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
			RoPpTHKyjmG = false;
		}
	}

	public void AtualizaDGPainelLM()
	{
		checked
		{
			try
			{
				int num = dgPaineis.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgPaineis.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineis)) ? ((double)(dgPaineis.Width - 4)) : ((double)(dgPaineis.Width - 21)));
				dgPaineis.Columns[0].Width = (int)Math.Round(a);
				dgPaineis.Columns[0].Visible = false;
				dgPaineis.Columns[1].Width = (int)Math.Round(a);
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
				RoPpTHKyjmG = false;
			}
		}
	}

	public void formataDGDisp()
	{
		try
		{
			jstpTkBBjLm = true;
			dgDisp.Rows.Clear();
			dgDisp.Columns.Clear();
			dgDisp.Columns.Add("#", "");
			dgDisp.Columns.Add("DWG", "");
			dgDisp.Columns.Add("PN", "");
			dgDisp.Columns.Add("TAG", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 804]));
			dgDisp.Columns.Add("Material", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]));
			dgDisp.Columns.Add("Quantidade", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 797]));
			dgDisp.Columns.Add("Ordem", "");
			dgDisp.Columns.Add("Avulso", "");
			dgDisp.Columns.Add("DESC", "");
			dgDisp.Columns.Add("DESCDEST", "");
			dgDisp.Columns.Add("Alternativo", "");
			dgDisp.Columns.Add("indexModelo", "");
			Redimensionar();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void LRqppUWsUxd(object P_0, EventArgs P_1)
	{
		if (UxCpT6QcFwa)
		{
			AtualizaDGPainelLM();
			Redimensionar();
		}
	}

	private void K7hppy1EMVI(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo1.Text));
		tbCodigo1.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum1.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo1.Text = frmPesquisaMateriais2.modelo;
		tbFabricante1.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}
}
