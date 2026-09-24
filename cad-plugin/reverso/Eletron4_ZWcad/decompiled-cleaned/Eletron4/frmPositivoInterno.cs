using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmPositivoInterno : Form
{
	private IContainer g72vSbNF8s;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPaineis")]
	private DataGridView cvTv4JqXan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgReguas")]
	private DataGridView mJIvCrxZkr;

	[AccessedThroughProperty("dgBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView vUOvYgFwSa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionaPositivoInterno")]
	private Button y2Dvr8B6MA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btRemovePositivoInterno")]
	private Button tWPv9XbVvQ;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip WkgvzM8T5k;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btOcultarBorne")]
	private Button N8q6WYDShm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSequencial")]
	private TextBox p3l6pkq01O;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionarJumper")]
	private Button raY6Tqjank;

	private Declaracoes2.StructureModeloDeReguas[] T676JZ85D3;

	private DeclaracoesEntidades.StructureBorne[] NZf6hoJPPQ;

	private List<int> jC06oDsl4i;

	private DataGridViewCellStyle ol96GMDJew;

	private DataGridViewCellStyle GrD6Ha6Z7f;

	private DataGridViewCellStyle R5c6k86mmo;

	internal virtual DataGridView dgPaineis
	{
		[CompilerGenerated]
		get
		{
			return cvTv4JqXan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vODvRs6crp;
			DataGridView dataGridView = cvTv4JqXan;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			cvTv4JqXan = value;
			dataGridView = cvTv4JqXan;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgReguas
	{
		[CompilerGenerated]
		get
		{
			return mJIvCrxZkr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GBZvXHE7yY;
			DataGridView dataGridView = mJIvCrxZkr;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			mJIvCrxZkr = value;
			dataGridView = mJIvCrxZkr;
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
			return vUOvYgFwSa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vUOvYgFwSa = value;
		}
	}

	internal virtual Button btAdicionaPositivoInterno
	{
		[CompilerGenerated]
		get
		{
			return y2Dvr8B6MA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Nf6vyyTrG2;
			Button button = y2Dvr8B6MA;
			if (button != null)
			{
				button.Click -= value2;
			}
			y2Dvr8B6MA = value;
			button = y2Dvr8B6MA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btRemovePositivoInterno
	{
		[CompilerGenerated]
		get
		{
			return tWPv9XbVvQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jBovscgti5;
			Button button = tWPv9XbVvQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			tWPv9XbVvQ = value;
			button = tWPv9XbVvQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btOcultarBorne
	{
		[CompilerGenerated]
		get
		{
			return N8q6WYDShm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BiFvApfiSI;
			Button button = N8q6WYDShm;
			if (button != null)
			{
				button.Click -= value2;
			}
			N8q6WYDShm = value;
			button = N8q6WYDShm;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbSequencial
	{
		[CompilerGenerated]
		get
		{
			return p3l6pkq01O;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = sB7vESbNL4;
			TextBox textBox = p3l6pkq01O;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			p3l6pkq01O = value;
			textBox = p3l6pkq01O;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button btAdicionarJumper
	{
		[CompilerGenerated]
		get
		{
			return raY6Tqjank;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FuQvg8qFoi;
			Button button = raY6Tqjank;
			if (button != null)
			{
				button.Click -= value2;
			}
			raY6Tqjank = value;
			button = raY6Tqjank;
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
			if (disposing && g72vSbNF8s != null)
			{
				g72vSbNF8s.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void oqJv5rwSda()
	{
		g72vSbNF8s = new Container();
		dgPaineis = new DataGridView();
		dgReguas = new DataGridView();
		dgBornes = new DataGridView();
		btAdicionaPositivoInterno = new Button();
		btRemovePositivoInterno = new Button();
		FDqpBiUmZij(new ToolTip(g72vSbNF8s));
		btOcultarBorne = new Button();
		tbSequencial = new TextBox();
		btAdicionarJumper = new Button();
		((ISupportInitialize)dgPaineis).BeginInit();
		((ISupportInitialize)dgReguas).BeginInit();
		((ISupportInitialize)dgBornes).BeginInit();
		SuspendLayout();
		dgPaineis.AllowDrop = true;
		dgPaineis.AllowUserToAddRows = false;
		dgPaineis.AllowUserToDeleteRows = false;
		dgPaineis.AllowUserToResizeRows = false;
		dgPaineis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPaineis.BackgroundColor = Color.White;
		dgPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineis.Location = new Point(12, 12);
		dgPaineis.MultiSelect = false;
		dgPaineis.Name = "dgPaineis";
		dgPaineis.RowHeadersVisible = false;
		dgPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineis.Size = new Size(141, 387);
		dgPaineis.TabIndex = 194;
		dgReguas.AllowDrop = true;
		dgReguas.AllowUserToAddRows = false;
		dgReguas.AllowUserToDeleteRows = false;
		dgReguas.AllowUserToResizeRows = false;
		dgReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgReguas.BackgroundColor = Color.White;
		dgReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguas.Location = new Point(159, 12);
		dgReguas.MultiSelect = false;
		dgReguas.Name = "dgReguas";
		dgReguas.RowHeadersVisible = false;
		dgReguas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguas.Size = new Size(141, 387);
		dgReguas.TabIndex = 195;
		dgBornes.AllowDrop = true;
		dgBornes.AllowUserToAddRows = false;
		dgBornes.AllowUserToDeleteRows = false;
		dgBornes.AllowUserToOrderColumns = true;
		dgBornes.AllowUserToResizeRows = false;
		dgBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgBornes.BackgroundColor = Color.White;
		dgBornes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornes.Location = new Point(306, 12);
		dgBornes.Name = "dgBornes";
		dgBornes.RowHeadersVisible = false;
		dgBornes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornes.Size = new Size(141, 313);
		dgBornes.TabIndex = 196;
		btAdicionaPositivoInterno.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btAdicionaPositivoInterno.FlatStyle = FlatStyle.Flat;
		btAdicionaPositivoInterno.ForeColor = SystemColors.Control;
		btAdicionaPositivoInterno.Image = Resources.Adiciona_32;
		btAdicionaPositivoInterno.Location = new Point(306, 359);
		btAdicionaPositivoInterno.Name = "btAdicionaPositivoInterno";
		btAdicionaPositivoInterno.Size = new Size(40, 40);
		btAdicionaPositivoInterno.TabIndex = 197;
		btAdicionaPositivoInterno.UseVisualStyleBackColor = true;
		btRemovePositivoInterno.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btRemovePositivoInterno.FlatStyle = FlatStyle.Flat;
		btRemovePositivoInterno.ForeColor = SystemColors.Control;
		btRemovePositivoInterno.Image = Resources.Subtrai;
		btRemovePositivoInterno.Location = new Point(398, 359);
		btRemovePositivoInterno.Name = "btRemovePositivoInterno";
		btRemovePositivoInterno.Size = new Size(40, 40);
		btRemovePositivoInterno.TabIndex = 198;
		btRemovePositivoInterno.UseVisualStyleBackColor = true;
		btOcultarBorne.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btOcultarBorne.FlatStyle = FlatStyle.Flat;
		btOcultarBorne.ForeColor = SystemColors.Control;
		btOcultarBorne.Image = Resources.Ocultar_32;
		btOcultarBorne.Location = new Point(398, 328);
		btOcultarBorne.Name = "btOcultarBorne";
		btOcultarBorne.Size = new Size(40, 40);
		btOcultarBorne.TabIndex = 199;
		btOcultarBorne.UseVisualStyleBackColor = true;
		tbSequencial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbSequencial.Location = new Point(330, 339);
		tbSequencial.MaxLength = 3;
		tbSequencial.Name = "tbSequencial";
		tbSequencial.Size = new Size(43, 20);
		tbSequencial.TabIndex = 200;
		btAdicionarJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btAdicionarJumper.FlatStyle = FlatStyle.Flat;
		btAdicionarJumper.ForeColor = SystemColors.Control;
		btAdicionarJumper.Image = Resources.JumperGE_32;
		btAdicionarJumper.Location = new Point(352, 359);
		btAdicionarJumper.Name = "btAdicionarJumper";
		btAdicionarJumper.Size = new Size(40, 40);
		btAdicionarJumper.TabIndex = 201;
		btAdicionarJumper.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(460, 411);
		Controls.Add(btAdicionarJumper);
		Controls.Add(tbSequencial);
		Controls.Add(btOcultarBorne);
		Controls.Add(btRemovePositivoInterno);
		Controls.Add(btAdicionaPositivoInterno);
		Controls.Add(dgBornes);
		Controls.Add(dgReguas);
		Controls.Add(dgPaineis);
		MaximumSize = new Size(476, 900);
		MinimumSize = new Size(476, 450);
		Name = "frmPositivoInterno";
		Text = "frmPositivoInterno";
		((ISupportInitialize)dgPaineis).EndInit();
		((ISupportInitialize)dgReguas).EndInit();
		((ISupportInitialize)dgBornes).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return WkgvzM8T5k;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		WkgvzM8T5k = WithEventsValue;
	}

	public frmPositivoInterno()
	{
		Resize += fHJvZPlPZH;
		jC06oDsl4i = new List<int>();
		ol96GMDJew = new DataGridViewCellStyle();
		GrD6Ha6Z7f = new DataGridViewCellStyle();
		R5c6k86mmo = new DataGridViewCellStyle();
		if (Geral.ExisteForm("frmPositivoInterno") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			oqJv5rwSda();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1942]);
			w8dpBZ0kvSD().SetToolTip(btAdicionaPositivoInterno, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1945]));
			w8dpBZ0kvSD().SetToolTip(btAdicionarJumper, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1952]));
			w8dpBZ0kvSD().SetToolTip(btRemovePositivoInterno, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1946]));
			w8dpBZ0kvSD().SetToolTip(btOcultarBorne, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1951]));
			Application.ShowModelessDialog((Form)this);
			formataDGPaineis();
			formataDGReguas();
			formataDGBornes();
			T676JZ85D3 = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref T676JZ85D3);
			NZf6hoJPPQ = new DeclaracoesEntidades.StructureBorne[1];
			clsBornes.capturaTodosOsBornesDoDesenho(-1, ref NZf6hoJPPQ);
			int num = Information.UBound(T676JZ85D3);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				int indexPainel = T676JZ85D3[i].indexPainel;
				if (!jC06oDsl4i.Contains(indexPainel))
				{
					jC06oDsl4i.Add(indexPainel);
				}
			}
			dqsv0dfnGN();
			mQQvBv56qb();
			tbSequencial.Text = "1";
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			ol96GMDJew.BackColor = Color.LightBlue;
			GrD6Ha6Z7f.BackColor = Color.White;
			R5c6k86mmo.BackColor = Color.LightCoral;
			Application.ShowModelessDialog((Form)this);
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

	private void dqsv0dfnGN()
	{
		dgPaineis.Rows.Clear();
		foreach (int item in jC06oDsl4i)
		{
			dgPaineis.Rows.Add(item, Dicionario.BuscaNomeDoPainel(item));
		}
	}

	private void vODvRs6crp(object P_0, EventArgs P_1)
	{
		if (dgPaineis.ColumnCount == 2 && dgPaineis.SelectedRows.Count == 1)
		{
			int num = Conversions.ToInteger(dgPaineis.SelectedRows[0].Cells[0].Value);
			dNovmcZraq(num);
		}
	}

	private void dNovmcZraq(int P_0)
	{
		dgReguas.Rows.Clear();
		int num = Information.UBound(T676JZ85D3);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (T676JZ85D3[i].indexPainel == P_0)
			{
				dgReguas.Rows.Add(T676JZ85D3[i].indexRegua, T676JZ85D3[i].nomeRegua);
			}
		}
		DcovVphJHK();
	}

	private void GBZvXHE7yY(object P_0, EventArgs P_1)
	{
		if (dgReguas.ColumnCount == 2 && dgReguas.SelectedRows.Count == 1)
		{
			int num = Conversions.ToInteger(dgReguas.SelectedRows[0].Cells[0].Value);
			fRZvUP5QoC(num);
		}
	}

	private void fRZvUP5QoC(int P_0)
	{
		dgBornes.Rows.Clear();
		int num = Information.UBound(NZf6hoJPPQ);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (NZf6hoJPPQ[i].IndiceRegua != P_0)
				{
					continue;
				}
				dgBornes.Rows.Add(NZf6hoJPPQ[i].Numero, NZf6hoJPPQ[i].pagina, NZf6hoJPPQ[i].PosInt_Jumper, NZf6hoJPPQ[i].Handle);
				if (!NZf6hoJPPQ[i].PosInt_Jumper.StartsWith("PI"))
				{
					if (Operators.CompareString(NZf6hoJPPQ[i].PosInt_Jumper, "X", TextCompare: true) != 0)
					{
						dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[0].Style = GrD6Ha6Z7f;
					}
					else
					{
						dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[0].Style = R5c6k86mmo;
					}
				}
				else
				{
					dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[0].Style = ol96GMDJew;
				}
			}
			Ndevu4lq9o();
		}
	}

	private void Nf6vyyTrG2(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		string text = "PI-" + tbSequencial.Text.Trim();
		if (dgBornes.SelectedRows.Count <= 0)
		{
			return;
		}
		foreach (DataGridViewRow selectedRow in dgBornes.SelectedRows)
		{
			selectedRow.Cells[2].Value = text;
			selectedRow.Cells[0].Style = ol96GMDJew;
			list.Add(Conversions.ToString(selectedRow.Cells[3].Value));
		}
		if (list.Count > 0)
		{
			clsBornes.PositivoInterno(list, text);
		}
		NZf6hoJPPQ = new DeclaracoesEntidades.StructureBorne[1];
		clsBornes.capturaTodosOsBornesDoDesenho(-1, ref NZf6hoJPPQ);
		tbSequencial.Text = checked(Conversions.ToInteger(tbSequencial.Text) + 1).ToString();
	}

	private void FuQvg8qFoi(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		string text = "JP-" + tbSequencial.Text.Trim();
		if (dgBornes.SelectedRows.Count <= 0)
		{
			return;
		}
		foreach (DataGridViewRow selectedRow in dgBornes.SelectedRows)
		{
			selectedRow.Cells[2].Value = text;
			selectedRow.Cells[0].Style = ol96GMDJew;
			list.Add(Conversions.ToString(selectedRow.Cells[3].Value));
		}
		if (list.Count > 0)
		{
			clsBornes.PositivoInterno(list, text);
		}
		NZf6hoJPPQ = new DeclaracoesEntidades.StructureBorne[1];
		clsBornes.capturaTodosOsBornesDoDesenho(-1, ref NZf6hoJPPQ);
		tbSequencial.Text = checked(Conversions.ToInteger(tbSequencial.Text) + 1).ToString();
	}

	private void BiFvApfiSI(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		if (dgBornes.SelectedRows.Count <= 0)
		{
			return;
		}
		foreach (DataGridViewRow selectedRow in dgBornes.SelectedRows)
		{
			selectedRow.Cells[2].Value = "X";
			selectedRow.Cells[0].Style = R5c6k86mmo;
			list.Add(Conversions.ToString(selectedRow.Cells[3].Value));
		}
		if (list.Count > 0)
		{
			clsBornes.PositivoInterno(list, "X");
		}
		NZf6hoJPPQ = new DeclaracoesEntidades.StructureBorne[1];
		clsBornes.capturaTodosOsBornesDoDesenho(-1, ref NZf6hoJPPQ);
	}

	private void jBovscgti5(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		if (dgBornes.SelectedRows.Count <= 0)
		{
			return;
		}
		foreach (DataGridViewRow selectedRow in dgBornes.SelectedRows)
		{
			if (Conversions.ToBoolean(Operators.OrObject(selectedRow.Cells[2].Value.ToString().StartsWith("PI"), Operators.CompareObjectEqual(selectedRow.Cells[2].Value, "X", TextCompare: true))))
			{
				list.Add(Conversions.ToString(selectedRow.Cells[3].Value));
			}
			selectedRow.Cells[2].Value = "";
			selectedRow.Cells[0].Style = GrD6Ha6Z7f;
		}
		if (list.Count > 0)
		{
			clsBornes.PositivoInterno(list, "");
		}
		NZf6hoJPPQ = new DeclaracoesEntidades.StructureBorne[1];
		clsBornes.capturaTodosOsBornesDoDesenho(-1, ref NZf6hoJPPQ);
	}

	public void formataDGPaineis()
	{
		try
		{
			dgPaineis.Rows.Clear();
			dgPaineis.Columns.Clear();
			dgPaineis.Columns.Add("", "#");
			dgPaineis.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1943]));
			mQQvBv56qb();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void mQQvBv56qb()
	{
		checked
		{
			if (dgPaineis.Columns.Count == 2)
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineis)) ? ((float)(dgPaineis.Width - 5)) : ((float)(dgPaineis.Width - 22)));
				dgPaineis.Columns[0].Width = (int)Math.Round(num * 1f / 4f);
				dgPaineis.Columns[1].Width = (int)Math.Round(num * 3f / 4f);
			}
		}
	}

	public void formataDGReguas()
	{
		try
		{
			dgReguas.Rows.Clear();
			dgReguas.Columns.Clear();
			dgReguas.Columns.Add("", "#");
			dgReguas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1944]));
			DcovVphJHK();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void DcovVphJHK()
	{
		checked
		{
			if (dgReguas.Columns.Count == 2)
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgReguas)) ? ((float)(dgReguas.Width - 5)) : ((float)(dgReguas.Width - 22)));
				dgReguas.Columns[0].Width = (int)Math.Round(num * 1f / 4f);
				dgReguas.Columns[1].Width = (int)Math.Round(num * 3f / 4f);
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
				dgBornes.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 789]));
				dgBornes.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 39]));
				dgBornes.Columns.Add("", "PI");
				dgBornes.Columns.Add("", "Handle");
				int num = dgPaineis.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgBornes.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				Ndevu4lq9o();
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

	private void Ndevu4lq9o()
	{
		if (dgBornes.Columns.Count != 4)
		{
			return;
		}
		checked
		{
			float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBornes)) ? ((float)(dgBornes.Width - 5)) : ((float)(dgBornes.Width - 22)));
			dgBornes.Columns[0].Width = (int)Math.Round(num * 1f / 3f);
			dgBornes.Columns[1].Width = (int)Math.Round(num * 1f / 3f);
			dgBornes.Columns[2].Width = (int)Math.Round(num * 1f / 3f);
			dgBornes.Columns[3].Width = 0;
			dgBornes.Columns[3].Visible = false;
			int num2 = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (!dgBornes.Rows[i].Cells[2].Value.ToString().StartsWith("PI-"))
				{
					if (!dgBornes.Rows[i].Cells[2].Value.ToString().StartsWith("JP-"))
					{
						if (!Operators.ConditionalCompareObjectEqual(dgBornes.Rows[i].Cells[2].Value, "X", TextCompare: true))
						{
							dgBornes.Rows[i].Cells[0].Style = GrD6Ha6Z7f;
						}
						else
						{
							dgBornes.Rows[i].Cells[0].Style = R5c6k86mmo;
						}
					}
					else
					{
						dgBornes.Rows[i].Cells[0].Style = ol96GMDJew;
					}
				}
				else
				{
					dgBornes.Rows[i].Cells[0].Style = ol96GMDJew;
				}
			}
			int num3 = dgBornes.Columns.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgBornes.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}
	}

	private void sB7vESbNL4(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void fHJvZPlPZH(object P_0, EventArgs P_1)
	{
		mTcvia33y3();
	}

	private void mTcvia33y3()
	{
		mQQvBv56qb();
		DcovVphJHK();
		Ndevu4lq9o();
	}
}
