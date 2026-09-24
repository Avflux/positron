using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmLink : Form
{
	private IContainer jR0pdnbX7Uy;

	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView NIHpd1E09gK;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView IlWpdlIud7c;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRegua")]
	private DataGridView cRRpd5xtp5n;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWG")]
	private DataGridView E00pd0TDaZj;

	[AccessedThroughProperty("dgBornes")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView W49pdRRBeJB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btMultiLink")]
	private Button fJQpdm85uTS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip pPKpdXtCDiy;

	private DeclaracoesFiacao.structurePnRev[] cMtpdUqAfQN;

	private DeclaracoesFiacao.structureRevisoes[] rLKpdyogjos;

	private int xo2pdgX5nJV;

	private string rbwpdAwpAxV;

	private int qMLpdsmBbf4;

	private int PODpdBTkCMQ;

	private bool I6npdVXAwHj;

	private bool UfBpduNjk9e;

	private bool S2DpdED9RxE;

	private bool gJspdZZeuJe;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return NIHpd1E09gK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = r6ppd7TtmvE;
			DataGridView dataGridView = NIHpd1E09gK;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			NIHpd1E09gK = value;
			dataGridView = NIHpd1E09gK;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return IlWpdlIud7c;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SCipdavAlwp;
			DataGridView dataGridView = IlWpdlIud7c;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			IlWpdlIud7c = value;
			dataGridView = IlWpdlIud7c;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return cRRpd5xtp5n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ajxpdN6hHSH;
			DataGridView dataGridView = cRRpd5xtp5n;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			cRRpd5xtp5n = value;
			dataGridView = cRRpd5xtp5n;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return E00pd0TDaZj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lSTpdOK47hF;
			DataGridView dataGridView = E00pd0TDaZj;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			E00pd0TDaZj = value;
			dataGridView = E00pd0TDaZj;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgBornes
	{
		[CompilerGenerated]
		get
		{
			return W49pdRRBeJB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = hPepdPxMdy2;
			DataGridView dataGridView = W49pdRRBeJB;
			if (dataGridView != null)
			{
				dataGridView.KeyDown -= value2;
			}
			W49pdRRBeJB = value;
			dataGridView = W49pdRRBeJB;
			if (dataGridView != null)
			{
				dataGridView.KeyDown += value2;
			}
		}
	}

	internal virtual Button btMultiLink
	{
		[CompilerGenerated]
		get
		{
			return fJQpdm85uTS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uDupdcuPPNn;
			Button button = fJQpdm85uTS;
			if (button != null)
			{
				button.Click -= value2;
			}
			fJQpdm85uTS = value;
			button = fJQpdm85uTS;
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
			if (disposing && jR0pdnbX7Uy != null)
			{
				jR0pdnbX7Uy.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void KIcpdMmiBMY()
	{
		jR0pdnbX7Uy = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgRegua = new DataGridView();
		dgDWG = new DataGridView();
		dgBornes = new DataGridView();
		btMultiLink = new Button();
		FDqpBiUmZij(new ToolTip(jR0pdnbX7Uy));
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgRegua).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		((ISupportInitialize)dgBornes).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao.Location = new Point(277, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(90, 175);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 193);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(186, 357);
		dgEquip.TabIndex = 8;
		dgRegua.AllowUserToAddRows = false;
		dgRegua.AllowUserToDeleteRows = false;
		dgRegua.AllowUserToOrderColumns = true;
		dgRegua.AllowUserToResizeRows = false;
		dgRegua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgRegua.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgRegua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgRegua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRegua.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRegua.Location = new Point(204, 193);
		dgRegua.MultiSelect = false;
		dgRegua.Name = "dgRegua";
		dgRegua.ReadOnly = true;
		dgRegua.RowHeadersVisible = false;
		dgRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRegua.Size = new Size(163, 357);
		dgRegua.TabIndex = 9;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDWG.Location = new Point(12, 12);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(259, 175);
		dgDWG.TabIndex = 17;
		dgBornes.AllowUserToAddRows = false;
		dgBornes.AllowUserToDeleteRows = false;
		dgBornes.AllowUserToResizeRows = false;
		dgBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgBornes.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgBornes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgBornes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornes.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgBornes.Location = new Point(373, 12);
		dgBornes.Name = "dgBornes";
		dgBornes.ReadOnly = true;
		dgBornes.RowHeadersVisible = false;
		dgBornes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornes.Size = new Size(129, 492);
		dgBornes.TabIndex = 18;
		btMultiLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btMultiLink.FlatStyle = FlatStyle.Flat;
		btMultiLink.ForeColor = SystemColors.Control;
		btMultiLink.Image = Resources.OKmult_32;
		btMultiLink.Location = new Point(417, 510);
		btMultiLink.Name = "btMultiLink";
		btMultiLink.Size = new Size(40, 40);
		btMultiLink.TabIndex = 19;
		btMultiLink.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(514, 562);
		Controls.Add(btMultiLink);
		Controls.Add(dgBornes);
		Controls.Add(dgDWG);
		Controls.Add(dgRegua);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(700, 1000);
		MinimumSize = new Size(530, 600);
		Name = "frmLink";
		ShowInTaskbar = false;
		Text = "Jumper Interno";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgRegua).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		((ISupportInitialize)dgBornes).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return pPKpdXtCDiy;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		pPKpdXtCDiy = WithEventsValue;
	}

	public frmLink()
	{
		Resize += TYNpd2AhV2M;
		cMtpdUqAfQN = new DeclaracoesFiacao.structurePnRev[1];
		rLKpdyogjos = new DeclaracoesFiacao.structureRevisoes[1];
		xo2pdgX5nJV = 0;
		rbwpdAwpAxV = "";
		qMLpdsmBbf4 = 0;
		PODpdBTkCMQ = 0;
		I6npdVXAwHj = false;
		UfBpduNjk9e = false;
		S2DpdED9RxE = false;
		gJspdZZeuJe = false;
		try
		{
			if (!Geral.ExisteForm("frmLink"))
			{
				KIcpdMmiBMY();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 791]);
				w8dpBZ0kvSD().SetToolTip(btMultiLink, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 790]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao();
				formataDGEquip();
				formataDGDisp();
				formataDGBornes();
				CarregaDGDWG();
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

	private void lSTpdOK47hF(object P_0, EventArgs P_1)
	{
		I6npdVXAwHj = true;
		dgRevisao.Rows.Clear();
		I6npdVXAwHj = false;
		UfBpduNjk9e = true;
		dgEquip.Rows.Clear();
		UfBpduNjk9e = false;
		S2DpdED9RxE = true;
		dgRegua.Rows.Clear();
		S2DpdED9RxE = false;
		gJspdZZeuJe = true;
		dgBornes.Rows.Clear();
		gJspdZZeuJe = false;
		UfApdIC1xna();
	}

	private void UfApdIC1xna()
	{
		xo2pdgX5nJV = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		rLKpdyogjos = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(xo2pdgX5nJV, ref rLKpdyogjos);
			I6npdVXAwHj = true;
			dgRevisao.Rows.Clear();
			I6npdVXAwHj = false;
			int num = Information.UBound(rLKpdyogjos);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(rLKpdyogjos[i].revisao);
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void r6ppd7TtmvE(object P_0, EventArgs P_1)
	{
		UfBpduNjk9e = true;
		dgEquip.Rows.Clear();
		UfBpduNjk9e = false;
		S2DpdED9RxE = true;
		dgRegua.Rows.Clear();
		S2DpdED9RxE = false;
		gJspdZZeuJe = true;
		dgBornes.Rows.Clear();
		gJspdZZeuJe = false;
		if (!I6npdVXAwHj)
		{
			qa7pdqtid9v();
		}
	}

	private void qa7pdqtid9v()
	{
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			rbwpdAwpAxV = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			UfBpduNjk9e = true;
			dgEquip.Rows.Clear();
			UfBpduNjk9e = false;
			int num = Information.UBound(cMtpdUqAfQN);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(cMtpdUqAfQN[i].revisao, rbwpdAwpAxV, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(cMtpdUqAfQN[i].painel, Dicionario.BuscaNomeDoPainel(cMtpdUqAfQN[i].painel));
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
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	public void CarregaPnRev()
	{
		cMtpdUqAfQN = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(rLKpdyogjos) > 0)
			{
				int num = Information.UBound(rLKpdyogjos);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(xo2pdgX5nJV, rLKpdyogjos[i].revisao, ref cMtpdUqAfQN);
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
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void SCipdavAlwp(object P_0, EventArgs P_1)
	{
		S2DpdED9RxE = true;
		dgRegua.Rows.Clear();
		S2DpdED9RxE = false;
		gJspdZZeuJe = true;
		dgBornes.Rows.Clear();
		gJspdZZeuJe = false;
		if (!UfBpduNjk9e)
		{
			Jg0pd8aTKmm();
		}
	}

	private void Jg0pd8aTKmm()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				qMLpdsmBbf4 = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				DeclaracoesFiacao.structureRB[] mReguas = new DeclaracoesFiacao.structureRB[1];
				cDadosAccessFiacao2.CarregaReguas(xo2pdgX5nJV, rbwpdAwpAxV, qMLpdsmBbf4, ref mReguas);
				S2DpdED9RxE = true;
				dgRegua.Rows.Clear();
				S2DpdED9RxE = false;
				int num = Information.UBound(mReguas);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgRegua.Rows.Add(mReguas[i].indexRegua, mReguas[i].regua);
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
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void ajxpdN6hHSH(object P_0, EventArgs P_1)
	{
		gJspdZZeuJe = true;
		dgBornes.Rows.Clear();
		gJspdZZeuJe = false;
		if (!gJspdZZeuJe)
		{
			bbfpdF63vf9();
		}
	}

	private void bbfpdF63vf9()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		checked
		{
			try
			{
				if (dgRegua.SelectedRows.Count != 1)
				{
					return;
				}
				PODpdBTkCMQ = Conversions.ToInteger(dgRegua.SelectedRows[0].Cells[0].Value);
				DeclaracoesFiacao.structureBN[] mBornes = new DeclaracoesFiacao.structureBN[1];
				mBornes[0].Potenciais = new int[1];
				mBornes[0].Potenciais[0] = 0;
				mBornes[0].Ordens = new int[1];
				mBornes[0].Ordens[0] = 0;
				cDadosAccessFiacao2.CarregaBornes(xo2pdgX5nJV, rbwpdAwpAxV, qMLpdsmBbf4, PODpdBTkCMQ, ref mBornes);
				gJspdZZeuJe = true;
				dgBornes.Rows.Clear();
				gJspdZZeuJe = false;
				if (Information.UBound(mBornes) <= 0)
				{
					return;
				}
				cDadosAccessFiacao2.CarregaPotenciaisNaMatriz(xo2pdgX5nJV, rbwpdAwpAxV, qMLpdsmBbf4, PODpdBTkCMQ, ref mBornes);
				int num = 0;
				int num2 = Information.UBound(mBornes);
				for (int i = 1; i <= num2; i++)
				{
					num = mBornes[i].Potencial;
					if (i != 1)
					{
						if (!((num > 0) & (num == mBornes[i - 1].Potencial)))
						{
							eAupdQsHGtd();
							dgBornes.Rows.Add(mBornes[i].indice, num, mBornes[i].bLink, mBornes[i].borne, "");
							if (mBornes[i].bLink)
							{
								dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[4].Style.BackColor = Color.DarkRed;
							}
						}
						else
						{
							dgBornes.Rows.Add(mBornes[i].indice, num, mBornes[i].bLink, mBornes[i].borne, "");
							if (mBornes[i].bLink)
							{
								dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[4].Style.BackColor = Color.DarkRed;
							}
						}
					}
					else
					{
						dgBornes.Rows.Add(mBornes[i].indice, num, mBornes[i].bLink, mBornes[i].borne, "");
						if (mBornes[i].bLink)
						{
							dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[4].Style.BackColor = Color.DarkRed;
						}
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
			finally
			{
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	private void eAupdQsHGtd()
	{
		dgBornes.Rows.Add(0, -1, "", "", "");
		checked
		{
			dgBornes.Rows[dgBornes.Rows.Count - 1].Height = 5;
			dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[3].Style.BackColor = Color.DarkGray;
			dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[4].Style.BackColor = Color.DarkGray;
		}
	}

	private void hPepdPxMdy2(object P_0, KeyEventArgs P_1)
	{
		try
		{
			if (P_1.KeyCode != Keys.Insert)
			{
				if (P_1.KeyCode == Keys.Delete)
				{
					aGfpderRRU4();
				}
			}
			else
			{
				nRGpdKh0rXi();
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

	private void uDupdcuPPNn(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewRow item in (IEnumerable)dgBornes.Rows)
		{
			item.Selected = false;
		}
		int num = 20;
		checked
		{
			int num2 = dgBornes.Rows.Count - 2;
			for (int i = 0; i <= num2; i++)
			{
				if (i > 10)
				{
					dgBornes.FirstDisplayedScrollingRowIndex = i - 10;
				}
				if (i > num)
				{
					num += 20;
					Application.DoEvents();
					Thread.Sleep(100);
				}
				int num3 = Conversions.ToInteger(dgBornes.Rows[i].Cells[1].Value);
				if (num3 != -1)
				{
					dgBornes.Rows[i].Selected = true;
					bool flag = false;
					int num4 = i + 1;
					int num5 = dgBornes.Rows.Count - 1;
					for (int j = num4; j <= num5 && Operators.ConditionalCompareObjectEqual(dgBornes.Rows[j].Cells[1].Value, num3, TextCompare: true); j++)
					{
						dgBornes.Rows[j].Selected = true;
						flag = true;
						i = j;
					}
					if (flag)
					{
						nRGpdKh0rXi();
					}
				}
				foreach (DataGridViewRow item2 in (IEnumerable)dgBornes.Rows)
				{
					item2.Selected = false;
				}
			}
			dgBornes.FirstDisplayedScrollingRowIndex = 0;
		}
	}

	private void nRGpdKh0rXi()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		checked
		{
			try
			{
				int num = dgBornes.SelectedRows.Count;
				int num2 = -1;
				if (num > 1)
				{
					foreach (DataGridViewRow selectedRow in dgBornes.SelectedRows)
					{
						if (!Operators.ConditionalCompareObjectEqual(selectedRow.Cells[0].Value, 0, TextCompare: true))
						{
							if (num2 == -1)
							{
								num2 = Conversions.ToInteger(selectedRow.Cells[1].Value);
							}
							if (Operators.ConditionalCompareObjectNotEqual(selectedRow.Cells[1].Value, num2, TextCompare: true))
							{
								return;
							}
						}
						else
						{
							num--;
							selectedRow.Selected = false;
						}
					}
				}
				if (num < 2 || num2 == 0)
				{
					return;
				}
				int num3 = -1;
				int num4 = dgBornes.Rows.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					if (dgBornes.Rows[i].Selected)
					{
						if (num3 == -1)
						{
							num3 = i;
						}
						if (i - num3 > 1)
						{
							return;
						}
						num3 = i;
					}
				}
				foreach (DataGridViewRow selectedRow2 in dgBornes.SelectedRows)
				{
					cDadosAccessFiacao2.InsereLink(xo2pdgX5nJV, rbwpdAwpAxV, qMLpdsmBbf4, PODpdBTkCMQ, Conversions.ToString(selectedRow2.Cells[3].Value), Conversions.ToInteger(selectedRow2.Cells[1].Value));
					selectedRow2.Cells[4].Style.BackColor = Color.DarkRed;
					selectedRow2.Selected = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
			finally
			{
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	private void aGfpderRRU4()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		checked
		{
			try
			{
				foreach (DataGridViewRow selectedRow in dgBornes.SelectedRows)
				{
					int num = Conversions.ToInteger(selectedRow.Cells[1].Value);
					cDadosAccessFiacao2.RemoveLink(xo2pdgX5nJV, rbwpdAwpAxV, qMLpdsmBbf4, PODpdBTkCMQ, Conversions.ToInteger(selectedRow.Cells[1].Value));
					int num2 = dgBornes.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (Conversions.ToInteger(dgBornes.Rows[i].Cells[1].Value) == num)
						{
							dgBornes.Rows[i].Cells[4].Style.BackColor = Color.White;
							dgBornes.Rows[i].Selected = false;
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
			finally
			{
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	public void formataDGDWG()
	{
		checked
		{
			try
			{
				dgDWG.Rows.Clear();
				dgDWG.Columns.Clear();
				dgDWG.Columns.Add("", "DWG");
				dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 786]));
				float num = dgDWG.Width - 22;
				dgDWG.Columns[0].Width = (int)Math.Round(num / 5f);
				dgDWG.Columns[1].Width = (int)Math.Round(num * 4f / 5f);
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

	public void CarregaDGDWG()
	{
		DeclaracoesGeral.arqLogico[] mDWG = new DeclaracoesGeral.arqLogico[1];
		cDadosAccess.carregaDadosTodosDWG(ref mDWG);
		checked
		{
			try
			{
				int num = Information.UBound(mDWG);
				for (int i = 1; i <= num; i++)
				{
					dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (DeclaracoesGeral.arqAtivo.Indice == mDWG[i].Indice)
					{
						dgDWG.Rows[dgDWG.Rows.Count - 1].Selected = true;
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

	public void formataDGRevisao()
	{
		checked
		{
			try
			{
				dgRevisao.Rows.Clear();
				dgRevisao.Columns.Clear();
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num);
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

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				UfBpduNjk9e = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 787]));
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num2);
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
				UfBpduNjk9e = false;
			}
		}
	}

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				S2DpdED9RxE = true;
				dgRegua.Rows.Clear();
				dgRegua.Columns.Clear();
				dgRegua.Columns.Add("", "Indice");
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]));
				float num = dgRegua.Width - 22;
				dgRegua.Columns[0].Width = 0;
				dgRegua.Columns[0].Visible = false;
				dgRegua.Columns[1].Width = (int)Math.Round(num);
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
				S2DpdED9RxE = false;
			}
		}
	}

	public void formataDGBornes()
	{
		checked
		{
			try
			{
				dgBornes.Rows.Clear();
				dgBornes.Columns.Clear();
				dgBornes.Columns.Add("", "");
				dgBornes.Columns.Add("", "");
				dgBornes.Columns.Add("", "");
				dgBornes.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 789]));
				dgBornes.Columns.Add("", "");
				int num = dgBornes.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgBornes.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgBornes.Width - 20;
				dgBornes.Columns[0].Width = 0;
				dgBornes.Columns[0].Visible = false;
				dgBornes.Columns[1].Width = 0;
				dgBornes.Columns[1].Visible = false;
				dgBornes.Columns[2].Width = 0;
				dgBornes.Columns[2].Visible = false;
				dgBornes.Columns[3].Width = (int)Math.Round(num2 * 5f / 6f);
				dgBornes.Columns[4].Width = (int)Math.Round(num2 / 6f);
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

	private void TYNpd2AhV2M(object P_0, EventArgs P_1)
	{
		hlMpd3jb0kM();
	}

	private void hlMpd3jb0kM()
	{
		checked
		{
			if (dgDWG.Columns.Count == 2)
			{
				float num = dgDWG.Width - 22;
				dgDWG.Columns[0].Width = (int)Math.Round(num / 5f);
				dgDWG.Columns[1].Width = (int)Math.Round(num * 4f / 5f);
			}
			if (dgEquip.Columns.Count == 2)
			{
				float num = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[1].Width = (int)Math.Round(num);
			}
		}
	}
}
