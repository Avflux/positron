using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmEstatisticaDeBornes : Form
{
	public struct mQuantBornes
	{
		public int qBorneUS;

		public int qBorneRS;

		public int qBorneTS;

		public int qBorneUD;

		public int qBorneRD;

		public int qBorneTD;

		public int qBorneTotal;
	}

	private IContainer fIxCt7O8gK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog TuQCjNeM8c;

	[AccessedThroughProperty("GroupBox0")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox AEgCLrGwHZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgReguas")]
	private DataGridView vhfCwA9niw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip CG1CxrTOXB;

	[AccessedThroughProperty("LbFiltro")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label v2TCbhl7Pw;

	[AccessedThroughProperty("TBPesquisa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox KAsCMiJEEo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbSimples")]
	private Label lPQCOUdEqI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDuplo")]
	private Label Cj7CI4KvEN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTotal")]
	private Label JXWC7VeNdq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbReserva")]
	private Label YViCqVWP4Q;

	[AccessedThroughProperty("lbUso")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label sHcCaDty5G;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("qBorneUS")]
	private Label CnFC8CJZPu;

	[CompilerGenerated]
	[AccessedThroughProperty("qBorneRS")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label ON3CNijCOM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("qBorneTS")]
	[CompilerGenerated]
	private Label zUdCFV2OGQ;

	[AccessedThroughProperty("qBorneTD")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label QqaCQm3LwT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("qBorneRD")]
	private Label u3YCPaDI8e;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("qBorneUD")]
	private Label dbCCcsMfNh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("qBorneTotal")]
	private Label jWDCKv0P4s;

	private Declaracoes2.StructureModeloDeReguas[] Me6CeruTXf;

	private bool i6KC2SCGOb;

	private bool OnaC3qyor1;

	internal virtual GroupBox GroupBox0
	{
		[CompilerGenerated]
		get
		{
			return AEgCLrGwHZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AEgCLrGwHZ = value;
		}
	}

	internal virtual DataGridView dgReguas
	{
		[CompilerGenerated]
		get
		{
			return vhfCwA9niw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = mUaCDi6h2n;
			MouseEventHandler value3 = oIUCvM3MyR;
			DataGridView dataGridView = vhfCwA9niw;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			vhfCwA9niw = value;
			dataGridView = vhfCwA9niw;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return v2TCbhl7Pw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v2TCbhl7Pw = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return KAsCMiJEEo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = fALCfcTcWb;
			TextBox textBox = KAsCMiJEEo;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			KAsCMiJEEo = value;
			textBox = KAsCMiJEEo;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbSimples
	{
		[CompilerGenerated]
		get
		{
			return lPQCOUdEqI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lPQCOUdEqI = value;
		}
	}

	internal virtual Label lbDuplo
	{
		[CompilerGenerated]
		get
		{
			return Cj7CI4KvEN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Cj7CI4KvEN = value;
		}
	}

	internal virtual Label lbTotal
	{
		[CompilerGenerated]
		get
		{
			return JXWC7VeNdq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JXWC7VeNdq = value;
		}
	}

	internal virtual Label lbReserva
	{
		[CompilerGenerated]
		get
		{
			return YViCqVWP4Q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YViCqVWP4Q = value;
		}
	}

	internal virtual Label lbUso
	{
		[CompilerGenerated]
		get
		{
			return sHcCaDty5G;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sHcCaDty5G = value;
		}
	}

	internal virtual Label qBorneUS
	{
		[CompilerGenerated]
		get
		{
			return CnFC8CJZPu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CnFC8CJZPu = value;
		}
	}

	internal virtual Label qBorneRS
	{
		[CompilerGenerated]
		get
		{
			return ON3CNijCOM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ON3CNijCOM = value;
		}
	}

	internal virtual Label qBorneTS
	{
		[CompilerGenerated]
		get
		{
			return zUdCFV2OGQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zUdCFV2OGQ = value;
		}
	}

	internal virtual Label qBorneTD
	{
		[CompilerGenerated]
		get
		{
			return QqaCQm3LwT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QqaCQm3LwT = value;
		}
	}

	internal virtual Label qBorneRD
	{
		[CompilerGenerated]
		get
		{
			return u3YCPaDI8e;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			u3YCPaDI8e = value;
		}
	}

	internal virtual Label qBorneUD
	{
		[CompilerGenerated]
		get
		{
			return dbCCcsMfNh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dbCCcsMfNh = value;
		}
	}

	internal virtual Label qBorneTotal
	{
		[CompilerGenerated]
		get
		{
			return jWDCKv0P4s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jWDCKv0P4s = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && fIxCt7O8gK != null)
			{
				fIxCt7O8gK.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Q5dCdTbhE7()
	{
		fIxCt7O8gK = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		GroupBox0 = new GroupBox();
		dgReguas = new DataGridView();
		LbFiltro = new Label();
		TBPesquisa = new TextBox();
		FDqpBiUmZij(new ToolTip(fIxCt7O8gK));
		lbSimples = new Label();
		lbDuplo = new Label();
		lbTotal = new Label();
		lbReserva = new Label();
		lbUso = new Label();
		qBorneUS = new Label();
		qBorneRS = new Label();
		qBorneTS = new Label();
		qBorneTD = new Label();
		qBorneRD = new Label();
		qBorneUD = new Label();
		qBorneTotal = new Label();
		GroupBox0.SuspendLayout();
		((ISupportInitialize)dgReguas).BeginInit();
		SuspendLayout();
		GroupBox0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox0.Controls.Add(dgReguas);
		GroupBox0.Controls.Add(LbFiltro);
		GroupBox0.Controls.Add(TBPesquisa);
		GroupBox0.Location = new Point(11, 12);
		GroupBox0.Name = "GroupBox0";
		GroupBox0.Size = new Size(412, 383);
		GroupBox0.TabIndex = 132;
		GroupBox0.TabStop = false;
		dgReguas.AllowUserToAddRows = false;
		dgReguas.AllowUserToDeleteRows = false;
		dgReguas.AllowUserToOrderColumns = true;
		dgReguas.AllowUserToResizeRows = false;
		dgReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgReguas.BackgroundColor = SystemColors.ButtonHighlight;
		dgReguas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguas.Location = new Point(5, 15);
		dgReguas.Name = "dgReguas";
		dgReguas.ReadOnly = true;
		dgReguas.RowHeadersVisible = false;
		dgReguas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguas.Size = new Size(401, 320);
		dgReguas.TabIndex = 117;
		LbFiltro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbFiltro.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro.Location = new Point(5, 347);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(57, 20);
		LbFiltro.TabIndex = 167;
		LbFiltro.Text = "lbFiltro";
		LbFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(68, 347);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(67, 20);
		TBPesquisa.TabIndex = 166;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		lbSimples.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbSimples.BorderStyle = BorderStyle.Fixed3D;
		lbSimples.Location = new Point(61, 441);
		lbSimples.Name = "lbSimples";
		lbSimples.Size = new Size(65, 20);
		lbSimples.TabIndex = 168;
		lbSimples.Text = "lbSimples";
		lbSimples.TextAlign = ContentAlignment.MiddleCenter;
		lbDuplo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbDuplo.BorderStyle = BorderStyle.Fixed3D;
		lbDuplo.Location = new Point(61, 473);
		lbDuplo.Name = "lbDuplo";
		lbDuplo.Size = new Size(65, 20);
		lbDuplo.TabIndex = 169;
		lbDuplo.Text = "lbDuplo";
		lbDuplo.TextAlign = ContentAlignment.MiddleCenter;
		lbTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbTotal.BorderStyle = BorderStyle.Fixed3D;
		lbTotal.Location = new Point(274, 412);
		lbTotal.Name = "lbTotal";
		lbTotal.Size = new Size(149, 20);
		lbTotal.TabIndex = 170;
		lbTotal.Text = "lbTotal";
		lbTotal.TextAlign = ContentAlignment.MiddleCenter;
		lbReserva.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbReserva.BorderStyle = BorderStyle.Fixed3D;
		lbReserva.Location = new Point(203, 412);
		lbReserva.Name = "lbReserva";
		lbReserva.Size = new Size(65, 20);
		lbReserva.TabIndex = 172;
		lbReserva.Text = "lbReserva";
		lbReserva.TextAlign = ContentAlignment.MiddleCenter;
		lbUso.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbUso.BorderStyle = BorderStyle.Fixed3D;
		lbUso.Location = new Point(132, 412);
		lbUso.Name = "lbUso";
		lbUso.Size = new Size(65, 20);
		lbUso.TabIndex = 171;
		lbUso.Text = "lbUso";
		lbUso.TextAlign = ContentAlignment.MiddleCenter;
		qBorneUS.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qBorneUS.BorderStyle = BorderStyle.Fixed3D;
		qBorneUS.Location = new Point(132, 441);
		qBorneUS.Name = "qBorneUS";
		qBorneUS.Size = new Size(65, 20);
		qBorneUS.TabIndex = 173;
		qBorneUS.Text = "qBorneUS";
		qBorneUS.TextAlign = ContentAlignment.MiddleCenter;
		qBorneRS.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qBorneRS.BorderStyle = BorderStyle.Fixed3D;
		qBorneRS.Location = new Point(203, 441);
		qBorneRS.Name = "qBorneRS";
		qBorneRS.Size = new Size(65, 20);
		qBorneRS.TabIndex = 174;
		qBorneRS.Text = "qBorneRS";
		qBorneRS.TextAlign = ContentAlignment.MiddleCenter;
		qBorneTS.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qBorneTS.BorderStyle = BorderStyle.Fixed3D;
		qBorneTS.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		qBorneTS.Location = new Point(274, 441);
		qBorneTS.Name = "qBorneTS";
		qBorneTS.Size = new Size(65, 20);
		qBorneTS.TabIndex = 175;
		qBorneTS.Text = "qBorneTS";
		qBorneTS.TextAlign = ContentAlignment.MiddleCenter;
		qBorneTD.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qBorneTD.BorderStyle = BorderStyle.Fixed3D;
		qBorneTD.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		qBorneTD.Location = new Point(274, 473);
		qBorneTD.Name = "qBorneTD";
		qBorneTD.Size = new Size(65, 20);
		qBorneTD.TabIndex = 178;
		qBorneTD.Text = "qBorneTD";
		qBorneTD.TextAlign = ContentAlignment.MiddleCenter;
		qBorneRD.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qBorneRD.BorderStyle = BorderStyle.Fixed3D;
		qBorneRD.Location = new Point(203, 473);
		qBorneRD.Name = "qBorneRD";
		qBorneRD.Size = new Size(65, 20);
		qBorneRD.TabIndex = 177;
		qBorneRD.Text = "qBorneRD";
		qBorneRD.TextAlign = ContentAlignment.MiddleCenter;
		qBorneUD.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qBorneUD.BorderStyle = BorderStyle.Fixed3D;
		qBorneUD.Location = new Point(132, 473);
		qBorneUD.Name = "qBorneUD";
		qBorneUD.Size = new Size(65, 20);
		qBorneUD.TabIndex = 176;
		qBorneUD.Text = "qBorneUD";
		qBorneUD.TextAlign = ContentAlignment.MiddleCenter;
		qBorneTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qBorneTotal.BorderStyle = BorderStyle.Fixed3D;
		qBorneTotal.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		qBorneTotal.Location = new Point(345, 441);
		qBorneTotal.Name = "qBorneTotal";
		qBorneTotal.Size = new Size(78, 52);
		qBorneTotal.TabIndex = 179;
		qBorneTotal.Text = "Total";
		qBorneTotal.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(434, 502);
		Controls.Add(qBorneTotal);
		Controls.Add(qBorneTD);
		Controls.Add(qBorneRD);
		Controls.Add(qBorneUD);
		Controls.Add(qBorneTS);
		Controls.Add(qBorneRS);
		Controls.Add(qBorneUS);
		Controls.Add(lbReserva);
		Controls.Add(lbUso);
		Controls.Add(lbTotal);
		Controls.Add(lbDuplo);
		Controls.Add(lbSimples);
		Controls.Add(GroupBox0);
		MaximumSize = new Size(450, 1200);
		MinimumSize = new Size(450, 540);
		Name = "frmEstatisticaDeBornes";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Estatistica";
		GroupBox0.ResumeLayout(performLayout: false);
		GroupBox0.PerformLayout();
		((ISupportInitialize)dgReguas).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return TuQCjNeM8c;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		TuQCjNeM8c = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return CG1CxrTOXB;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		CG1CxrTOXB = WithEventsValue;
	}

	public frmEstatisticaDeBornes()
	{
		Resize += FvUC6nnRtb;
		i6KC2SCGOb = false;
		OnaC3qyor1 = true;
		if (Geral.ExisteForm("frmEstatisticaDeBornes") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			Q5dCdTbhE7();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 546]);
			LbFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
			lbUso.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1113]);
			lbReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1035]);
			lbTotal.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1080]);
			lbSimples.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1078]);
			lbDuplo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1079]);
			Me6CeruTXf = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioBorne.ExisteDicBornesReserva();
			DicionarioReguas.LeOsModelosDeRegua(ref Me6CeruTXf);
			mQuantBornes mQuantBornes2 = default;
			clsReguasDeBornes.SomaOsBornes(ref Me6CeruTXf);
			DataGridView dg = dgReguas;
			clsReguasDeBornes.carregaEstatisticaNoDG(ref dg, Me6CeruTXf, TBPesquisa.Text);
			dgReguas = dg;
			dg = dgReguas;
			clsReguasDeBornes.calculaSelecionado(ref dg, ref mQuantBornes2);
			dgReguas = dg;
			qBorneUS.Text = Conversions.ToString(mQuantBornes2.qBorneUS);
			qBorneRS.Text = Conversions.ToString(mQuantBornes2.qBorneRS);
			qBorneTS.Text = Conversions.ToString(mQuantBornes2.qBorneTS);
			qBorneUD.Text = Conversions.ToString(mQuantBornes2.qBorneUD);
			qBorneRD.Text = Conversions.ToString(mQuantBornes2.qBorneRD);
			qBorneTD.Text = Conversions.ToString(mQuantBornes2.qBorneTD);
			qBorneTotal.Text = Conversions.ToString(mQuantBornes2.qBorneTotal);
			if (checked(dgReguas.Rows.Count - 1) > 0)
			{
				dgReguas.Rows[0].Selected = true;
			}
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			OnaC3qyor1 = false;
			dg = dgReguas;
			clsReguasDeBornes.AtualizaColunasDGEstatistica(ref dg);
			dgReguas = dg;
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	private void fALCfcTcWb(object P_0, KeyEventArgs P_1)
	{
		TBPesquisa.Text = TBPesquisa.Text.ToString().ToUpper();
		DataGridView dg = dgReguas;
		clsReguasDeBornes.carregaEstatisticaNoDG(ref dg, Me6CeruTXf, TBPesquisa.Text);
		dgReguas = dg;
		MostraSelecionado();
	}

	private void mUaCDi6h2n(object P_0, KeyEventArgs P_1)
	{
		MostraSelecionado();
	}

	private void oIUCvM3MyR(object P_0, MouseEventArgs P_1)
	{
		MostraSelecionado();
	}

	public void MostraSelecionado()
	{
		mQuantBornes mQuantBornes2 = default;
		DataGridView dg = dgReguas;
		clsReguasDeBornes.calculaSelecionado(ref dg, ref mQuantBornes2);
		dgReguas = dg;
		qBorneUS.Text = Conversions.ToString(mQuantBornes2.qBorneUS);
		qBorneRS.Text = Conversions.ToString(mQuantBornes2.qBorneRS);
		qBorneTS.Text = Conversions.ToString(mQuantBornes2.qBorneTS);
		qBorneUD.Text = Conversions.ToString(mQuantBornes2.qBorneUD);
		qBorneRD.Text = Conversions.ToString(mQuantBornes2.qBorneRD);
		qBorneTD.Text = Conversions.ToString(mQuantBornes2.qBorneTD);
		qBorneTotal.Text = Conversions.ToString(mQuantBornes2.qBorneTotal);
	}

	private void FvUC6nnRtb(object P_0, EventArgs P_1)
	{
		if (!OnaC3qyor1)
		{
			DataGridView dg = dgReguas;
			clsReguasDeBornes.AtualizaColunasDGEstatistica(ref dg);
			dgReguas = dg;
		}
	}
}
