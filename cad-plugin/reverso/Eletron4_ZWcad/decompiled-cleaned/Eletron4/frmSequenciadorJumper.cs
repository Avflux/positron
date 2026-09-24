using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmSequenciadorJumper : Form
{
	private IContainer r8OpcBFXDFu;

	[AccessedThroughProperty("dgRevisao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView MUSpcVuE8gc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip tynpcu5Z1Tb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	private DataGridView d4HpcEMUgvv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDisp")]
	private DataGridView vMBpcZTKdyg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPot")]
	private DataGridView xGupciqdyj7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgSeq")]
	private DataGridView zeHpcSNotV6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lblSecao")]
	private Label fy7pc4b2n2l;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lblCor")]
	private Label u7gpcCDYm8t;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	[CompilerGenerated]
	private Button mv2pcY1qebj;

	[CompilerGenerated]
	[AccessedThroughProperty("cbNumConexoes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox xOMpcrsFKEG;

	private DeclaracoesFiacao.structurePnRev[] TOBpc9nqUri;

	private DeclaracoesFiacao.structureRevisoes[] I7lpczGpIkT;

	private Dictionary<int, int> yJ3pKWVxiiA;

	private string J7EpKpkQNtd;

	private int KWLpKTOYtNR;

	private string MjRpKJgPr18;

	private int gvbpKhoKP6l;

	private bool sd4pKoTVWoc;

	private bool a9SpKGhcoss;

	private bool tDLpKHSnc84;

	private int jchpKkfXpiN;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return MUSpcVuE8gc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hFjpcnuJKJD;
			DataGridView dataGridView = MUSpcVuE8gc;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			MUSpcVuE8gc = value;
			dataGridView = MUSpcVuE8gc;
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
			return d4HpcEMUgvv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Lvfpcll6tqc;
			DataGridView dataGridView = d4HpcEMUgvv;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			d4HpcEMUgvv = value;
			dataGridView = d4HpcEMUgvv;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDisp
	{
		[CompilerGenerated]
		get
		{
			return vMBpcZTKdyg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lHvpcRfvbNJ;
			DataGridView dataGridView = vMBpcZTKdyg;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			vMBpcZTKdyg = value;
			dataGridView = vMBpcZTKdyg;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgPot
	{
		[CompilerGenerated]
		get
		{
			return xGupciqdyj7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ONDpcXycDZS;
			DataGridView dataGridView = xGupciqdyj7;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			xGupciqdyj7 = value;
			dataGridView = xGupciqdyj7;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgSeq
	{
		[CompilerGenerated]
		get
		{
			return zeHpcSNotV6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = IwmpcyoJEdl;
			MouseEventHandler value3 = VyYpcgXcdr9;
			DragEventHandler value4 = ixhpcASkKnG;
			DragEventHandler value5 = I5mpcsHtv02;
			DataGridView dataGridView = zeHpcSNotV6;
			if (dataGridView != null)
			{
				dataGridView.KeyDown -= value2;
				dataGridView.MouseDown -= value3;
				dataGridView.DragDrop -= value4;
				dataGridView.DragEnter -= value5;
			}
			zeHpcSNotV6 = value;
			dataGridView = zeHpcSNotV6;
			if (dataGridView != null)
			{
				dataGridView.KeyDown += value2;
				dataGridView.MouseDown += value3;
				dataGridView.DragDrop += value4;
				dataGridView.DragEnter += value5;
			}
		}
	}

	internal virtual Label lblSecao
	{
		[CompilerGenerated]
		get
		{
			return fy7pc4b2n2l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fy7pc4b2n2l = value;
		}
	}

	internal virtual Label lblCor
	{
		[CompilerGenerated]
		get
		{
			return u7gpcCDYm8t;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			u7gpcCDYm8t = value;
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return mv2pcY1qebj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eCIpc3bSapp;
			Button button = mv2pcY1qebj;
			if (button != null)
			{
				button.Click -= value2;
			}
			mv2pcY1qebj = value;
			button = mv2pcY1qebj;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbNumConexoes
	{
		[CompilerGenerated]
		get
		{
			return xOMpcrsFKEG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = T9Cpc0jiDLH;
			CheckBox checkBox = xOMpcrsFKEG;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			xOMpcrsFKEG = value;
			checkBox = xOMpcrsFKEG;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && r8OpcBFXDFu != null)
			{
				r8OpcBFXDFu.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void GMnpc2g1wVs()
	{
		r8OpcBFXDFu = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		FDqpBiUmZij(new ToolTip(r8OpcBFXDFu));
		dgEquip = new DataGridView();
		dgDisp = new DataGridView();
		dgPot = new DataGridView();
		dgSeq = new DataGridView();
		lblSecao = new Label();
		lblCor = new Label();
		btSalvar = new Button();
		cbNumConexoes = new CheckBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		((ISupportInitialize)dgPot).BeginInit();
		((ISupportInitialize)dgSeq).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
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
		dgRevisao.Location = new Point(12, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(355, 62);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
		dgEquip.Location = new Point(12, 80);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(155, 309);
		dgEquip.TabIndex = 8;
		dgDisp.AllowUserToAddRows = false;
		dgDisp.AllowUserToDeleteRows = false;
		dgDisp.AllowUserToOrderColumns = true;
		dgDisp.AllowUserToResizeRows = false;
		dgDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
		dgDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDisp.Location = new Point(173, 80);
		dgDisp.MultiSelect = false;
		dgDisp.Name = "dgDisp";
		dgDisp.ReadOnly = true;
		dgDisp.RowHeadersVisible = false;
		dgDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDisp.Size = new Size(194, 278);
		dgDisp.TabIndex = 9;
		dgPot.AllowUserToAddRows = false;
		dgPot.AllowUserToDeleteRows = false;
		dgPot.AllowUserToOrderColumns = true;
		dgPot.AllowUserToResizeRows = false;
		dgPot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgPot.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgPot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgPot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPot.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPot.Location = new Point(373, 12);
		dgPot.MultiSelect = false;
		dgPot.Name = "dgPot";
		dgPot.ReadOnly = true;
		dgPot.RowHeadersVisible = false;
		dgPot.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPot.Size = new Size(101, 377);
		dgPot.TabIndex = 10;
		dgSeq.AllowDrop = true;
		dgSeq.AllowUserToAddRows = false;
		dgSeq.AllowUserToDeleteRows = false;
		dgSeq.AllowUserToResizeRows = false;
		dgSeq.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgSeq.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgSeq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgSeq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgSeq.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgSeq.Location = new Point(480, 12);
		dgSeq.MultiSelect = false;
		dgSeq.Name = "dgSeq";
		dgSeq.ReadOnly = true;
		dgSeq.RowHeadersVisible = false;
		dgSeq.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgSeq.Size = new Size(242, 318);
		dgSeq.TabIndex = 11;
		lblSecao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lblSecao.AutoSize = true;
		lblSecao.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblSecao.Location = new Point(495, 340);
		lblSecao.Name = "lblSecao";
		lblSecao.Size = new Size(65, 18);
		lblSecao.TabIndex = 14;
		lblSecao.Text = "lblSecao";
		lblCor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lblCor.AutoSize = true;
		lblCor.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblCor.Location = new Point(495, 358);
		lblCor.Name = "lblCor";
		lblCor.Size = new Size(47, 18);
		lblCor.TabIndex = 15;
		lblCor.Text = "lblCor";
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(677, 344);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 16;
		btSalvar.UseVisualStyleBackColor = true;
		cbNumConexoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbNumConexoes.AutoSize = true;
		cbNumConexoes.Location = new Point(188, 372);
		cbNumConexoes.Name = "cbNumConexoes";
		cbNumConexoes.Size = new Size(81, 17);
		cbNumConexoes.TabIndex = 17;
		cbNumConexoes.Text = "CheckBox1";
		cbNumConexoes.TextAlign = ContentAlignment.BottomLeft;
		cbNumConexoes.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(734, 401);
		Controls.Add(cbNumConexoes);
		Controls.Add(btSalvar);
		Controls.Add(lblCor);
		Controls.Add(lblSecao);
		Controls.Add(dgSeq);
		Controls.Add(dgPot);
		Controls.Add(dgDisp);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(750, 950);
		MinimumSize = new Size(750, 440);
		Name = "frmSequenciadorJumper";
		ShowInTaskbar = false;
		Text = "Sequenciador de Jumpers";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		((ISupportInitialize)dgPot).EndInit();
		((ISupportInitialize)dgSeq).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return tynpcu5Z1Tb;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		tynpcu5Z1Tb = WithEventsValue;
	}

	public frmSequenciadorJumper()
	{
		TOBpc9nqUri = new DeclaracoesFiacao.structurePnRev[1];
		I7lpczGpIkT = new DeclaracoesFiacao.structureRevisoes[1];
		J7EpKpkQNtd = "";
		KWLpKTOYtNR = 0;
		MjRpKJgPr18 = "";
		gvbpKhoKP6l = 0;
		sd4pKoTVWoc = false;
		a9SpKGhcoss = false;
		tDLpKHSnc84 = false;
		jchpKkfXpiN = 0;
		try
		{
			if (Geral.ExisteForm("frmSequenciadorJumper") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				GMnpc2g1wVs();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1408]);
				cbNumConexoes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 773]);
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 774]));
				Application.ShowModelessDialog((Form)this);
				formataDGRevisao();
				formataDGEquip();
				formataDGDisp();
				formataDGPot();
				formataDGSeq();
				CarregaDGRevisao();
				CarregaPnRev();
				vjmpc1g9prf();
				btSalvar.Enabled = false;
				cbNumConexoes.Checked = true;
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

	private void eCIpc3bSapp(object P_0, EventArgs P_1)
	{
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			int num = 0;
			foreach (DataGridViewRow item in (IEnumerable)dgSeq.Rows)
			{
				num = checked(num + 1);
				int indice = Conversions.ToInteger(item.Cells[0].Value);
				cDadosAccessJumper2.AtualizaOrdemTerminal(indice, num);
				int num2 = Conversions.ToInteger(item.Cells[5].Value);
				if (num2 > 0)
				{
					cDadosAccessJumper2.AtualizaOrdemTerminal(num2, num);
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
			cDadosAccessJumper2.fechaConexao();
			btSalvar.Enabled = false;
		}
	}

	private void hFjpcnuJKJD(object P_0, EventArgs P_1)
	{
		vjmpc1g9prf();
		btSalvar.Enabled = false;
	}

	private void vjmpc1g9prf()
	{
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			J7EpKpkQNtd = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			yJ3pKWVxiiA = new Dictionary<int, int>();
			cDadosAccessJumper2.CarregaDicPotenciais(DeclaracoesGeral.arqAtivo.Indice, J7EpKpkQNtd, ref yJ3pKWVxiiA);
			sd4pKoTVWoc = true;
			dgEquip.Rows.Clear();
			sd4pKoTVWoc = false;
			int num = Information.UBound(TOBpc9nqUri);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(TOBpc9nqUri[i].revisao, J7EpKpkQNtd, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(TOBpc9nqUri[i].painel, Dicionario.BuscaNomeDoPainel(TOBpc9nqUri[i].painel));
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	private void Lvfpcll6tqc(object P_0, EventArgs P_1)
	{
		if (!sd4pKoTVWoc)
		{
			TFhpc5g2YRV();
		}
		btSalvar.Enabled = false;
	}

	private void TFhpc5g2YRV()
	{
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			if (dgEquip.SelectedRows.Count != 1)
			{
				return;
			}
			KWLpKTOYtNR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			List<string> list = cDadosAccessJumper2.carregaDispositivos(DeclaracoesGeral.arqAtivo.Indice, J7EpKpkQNtd, KWLpKTOYtNR);
			a9SpKGhcoss = true;
			dgDisp.Rows.Clear();
			a9SpKGhcoss = false;
			dgDisp.Rows.Add(DeclaracoesGeral.mMensagem[1, 768]);
			foreach (string item in list)
			{
				dgDisp.Rows.Add(item);
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	private void T9Cpc0jiDLH(object P_0, EventArgs P_1)
	{
		lvKpcmQChAo();
		btSalvar.Enabled = false;
	}

	private void lHvpcRfvbNJ(object P_0, EventArgs P_1)
	{
		if (!a9SpKGhcoss)
		{
			lvKpcmQChAo();
		}
		btSalvar.Enabled = false;
	}

	private void lvKpcmQChAo()
	{
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			if (dgDisp.SelectedRows.Count != 1)
			{
				return;
			}
			MjRpKJgPr18 = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
			List<int> list = (dgDisp.Rows[0].Selected ? cDadosAccessJumper2.carregaTodosPotenciais(DeclaracoesGeral.arqAtivo.Indice, J7EpKpkQNtd, KWLpKTOYtNR, "", cbNumConexoes.Checked, ref yJ3pKWVxiiA) : cDadosAccessJumper2.carregaTodosPotenciais(DeclaracoesGeral.arqAtivo.Indice, J7EpKpkQNtd, KWLpKTOYtNR, MjRpKJgPr18, cbNumConexoes.Checked, ref yJ3pKWVxiiA));
			tDLpKHSnc84 = true;
			dgPot.Rows.Clear();
			tDLpKHSnc84 = false;
			dgSeq.Rows.Clear();
			foreach (int item in list)
			{
				dgPot.Rows.Add(item.ToString());
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	private void ONDpcXycDZS(object P_0, EventArgs P_1)
	{
		if (!tDLpKHSnc84)
		{
			RkqpcUuRL4v();
		}
		btSalvar.Enabled = false;
	}

	private void RkqpcUuRL4v()
	{
		if (dgPot.RowCount == 0)
		{
			return;
		}
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			formataDGSeq();
			if (dgDisp.SelectedRows.Count == 1)
			{
				gvbpKhoKP6l = Conversions.ToInteger(dgPot.SelectedRows[0].Cells[0].Value);
				int indice = DeclaracoesGeral.arqAtivo.Indice;
				string j7EpKpkQNtd = J7EpKpkQNtd;
				int kWLpKTOYtNR = KWLpKTOYtNR;
				int potencial = gvbpKhoKP6l;
				DataGridView withEventsValue = dgSeq;
				Label withEventsValue2 = lblSecao;
				Label withEventsValue3 = lblCor;
				cDadosAccessJumper2.CarregaSequenciamento(indice, j7EpKpkQNtd, kWLpKTOYtNR, potencial, ref withEventsValue, ref withEventsValue2, ref withEventsValue3);
				lblCor = withEventsValue3;
				lblSecao = withEventsValue2;
				dgSeq = withEventsValue;
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	private void IwmpcyoJEdl(object P_0, KeyEventArgs P_1)
	{
		checked
		{
			try
			{
				if (P_1.KeyCode != Keys.Home)
				{
					if (P_1.KeyCode == Keys.End)
					{
						DataGridViewRow dataGridViewRow = dgSeq.SelectedRows[0];
						dgSeq.Rows.RemoveAt(dgSeq.SelectedRows[0].Index);
						dgSeq.Rows.Add(dataGridViewRow);
						dgSeq.Rows[dgSeq.Rows.Count - 1].Selected = true;
						dgSeq.CurrentCell = dgSeq.Rows[dgSeq.Rows.Count - 1].Cells[1];
						btSalvar.Enabled = true;
					}
				}
				else
				{
					DataGridViewRow dataGridViewRow2 = dgSeq.SelectedRows[0];
					dgSeq.Rows.RemoveAt(dgSeq.SelectedRows[0].Index);
					dgSeq.Rows.Insert(0, dataGridViewRow2);
					dgSeq.Rows[0].Selected = true;
					dgSeq.CurrentCell = dgSeq.Rows[0].Cells[1];
					btSalvar.Enabled = true;
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

	public void formataDGRevisao()
	{
		checked
		{
			try
			{
				dgRevisao.Rows.Clear();
				dgRevisao.Columns.Clear();
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 753]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 754]));
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num * 2f / 8f);
				dgRevisao.Columns[1].Width = (int)Math.Round(num * 2f / 8f);
				dgRevisao.Columns[2].Width = (int)Math.Round(num * 4f / 8f);
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

	public void CarregaDGRevisao()
	{
		I7lpczGpIkT = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			cDadosAccessJumper2.CarregaUltimaRevisaoDwgCorrente(DeclaracoesGeral.arqAtivo.Indice, ref I7lpczGpIkT);
			if (Information.UBound(I7lpczGpIkT) > 0)
			{
				int num = Information.UBound(I7lpczGpIkT);
				dgRevisao.Rows.Add(I7lpczGpIkT[num].revisao, I7lpczGpIkT[num].criador, I7lpczGpIkT[num].data);
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				sd4pKoTVWoc = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
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
				sd4pKoTVWoc = false;
			}
		}
	}

	public void CarregaPnRev()
	{
		TOBpc9nqUri = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			if (Information.UBound(I7lpczGpIkT) > 0)
			{
				int num = Information.UBound(I7lpczGpIkT);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessJumper2.CarregaPnRev(DeclaracoesGeral.arqAtivo.Indice, I7lpczGpIkT[i].revisao, ref TOBpc9nqUri);
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				a9SpKGhcoss = true;
				dgDisp.Rows.Clear();
				dgDisp.Columns.Clear();
				dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 767]));
				int num = dgDisp.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDisp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgDisp.Width - 22;
				dgDisp.Columns[0].Width = (int)Math.Round(num2);
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
				a9SpKGhcoss = false;
			}
		}
	}

	public void formataDGPot()
	{
		checked
		{
			try
			{
				tDLpKHSnc84 = true;
				dgPot.Rows.Clear();
				dgPot.Columns.Clear();
				dgPot.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 769]));
				int num = dgPot.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgPot.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgPot.Width - 22;
				dgPot.Columns[0].Width = (int)Math.Round(num2);
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
				tDLpKHSnc84 = false;
			}
		}
	}

	public void formataDGSeq()
	{
		checked
		{
			try
			{
				dgSeq.Rows.Clear();
				dgSeq.Columns.Clear();
				dgSeq.Columns.Add("", "Indice");
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 770]));
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]));
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 771]));
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 772]));
				dgSeq.Columns.Add("", "IndiceCORR");
				int num = dgSeq.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgSeq.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgSeq.Width - 22;
				dgSeq.Columns[0].Width = 0;
				dgSeq.Columns[0].Visible = false;
				dgSeq.Columns[1].Width = (int)Math.Round(num2 / 4f);
				dgSeq.Columns[2].Width = (int)Math.Round(num2 / 4f);
				dgSeq.Columns[3].Width = (int)Math.Round(num2 / 4f);
				dgSeq.Columns[4].Width = (int)Math.Round(num2 / 4f);
				dgSeq.Columns[5].Width = 0;
				dgSeq.Columns[5].Visible = false;
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

	private void VyYpcgXcdr9(object P_0, MouseEventArgs P_1)
	{
		DataGridView.HitTestInfo hitTestInfo = dgSeq.HitTest(P_1.X, P_1.Y);
		if (hitTestInfo.RowIndex >= 0)
		{
			DataGridViewRow data = dgSeq.Rows[hitTestInfo.RowIndex];
			jchpKkfXpiN = hitTestInfo.RowIndex;
			dgSeq.Rows[jchpKkfXpiN].Selected = true;
			dgSeq.DoDragDrop(data, DragDropEffects.All);
		}
	}

	private void ixhpcASkKnG(object P_0, DragEventArgs P_1)
	{
		Point point = dgSeq.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgSeq.HitTest(point.X, point.Y);
		if (jchpKkfXpiN == hitTestInfo.RowIndex)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		dataGridViewRow2.Cells[2].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[2].Value);
		dataGridViewRow2.Cells[3].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[3].Value);
		dataGridViewRow2.Cells[4].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[4].Value);
		dataGridViewRow2.Cells[5].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[5].Value);
		checked
		{
			if (hitTestInfo.RowIndex == -1)
			{
				dgSeq.Rows.Add(dataGridViewRow2);
				dgSeq.Rows.RemoveAt(jchpKkfXpiN);
			}
			else
			{
				dgSeq.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
				if (jchpKkfXpiN > hitTestInfo.RowIndex)
				{
					jchpKkfXpiN++;
				}
				dgSeq.Rows.RemoveAt(jchpKkfXpiN);
			}
			btSalvar.Enabled = true;
		}
	}

	private void I5mpcsHtv02(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}
}
