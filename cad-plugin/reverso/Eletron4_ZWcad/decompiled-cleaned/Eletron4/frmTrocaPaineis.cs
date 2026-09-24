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
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmTrocaPaineis : Form
{
	private IContainer kCYp3uBUEZ6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPaineisDWG")]
	private DataGridView Vjgp3EsOJuk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip c1ip3ZMij0f;

	[CompilerGenerated]
	[AccessedThroughProperty("btTrocaosPaineis")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button yxjp3iuYIuA;

	[AccessedThroughProperty("BTAdicionaParaTroca")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button ybNp3SD2qOE;

	[AccessedThroughProperty("dgOutrosPaineis")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView Px2p34guewB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBNome")]
	private TextBox TWlp3COwI9V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserir")]
	[CompilerGenerated]
	private Button tupp3YGhOvX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelPN")]
	private Label OQLp3rbdcZU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExcluirPainel")]
	private Button Nufp39OEoLt;

	private clsTrocaPainel.mPN[] bAYp3z3EW1F;

	private clsTrocaPainel.mPNOutros[] zF6pnWMI1Jo;

	private List<string> Kl3pnpnY1Oq;

	private bool nQTpnTEBCKh;

	private int y8mpnJOrohe;

	internal virtual DataGridView dgPaineisDWG
	{
		[CompilerGenerated]
		get
		{
			return Vjgp3EsOJuk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = UBKp3gSy7eQ;
			DataGridView dataGridView = Vjgp3EsOJuk;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			Vjgp3EsOJuk = value;
			dataGridView = Vjgp3EsOJuk;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button btTrocaosPaineis
	{
		[CompilerGenerated]
		get
		{
			return yxjp3iuYIuA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YRBp3ViHS2t;
			Button button = yxjp3iuYIuA;
			if (button != null)
			{
				button.Click -= value2;
			}
			yxjp3iuYIuA = value;
			button = yxjp3iuYIuA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAdicionaParaTroca
	{
		[CompilerGenerated]
		get
		{
			return ybNp3SD2qOE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = z6sp3UP4vvT;
			Button button = ybNp3SD2qOE;
			if (button != null)
			{
				button.Click -= value2;
			}
			ybNp3SD2qOE = value;
			button = ybNp3SD2qOE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgOutrosPaineis
	{
		[CompilerGenerated]
		get
		{
			return Px2p34guewB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Px2p34guewB = value;
		}
	}

	internal virtual TextBox TBNome
	{
		[CompilerGenerated]
		get
		{
			return TWlp3COwI9V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = ODxp3yOULUQ;
			TextBox textBox = TWlp3COwI9V;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			TWlp3COwI9V = value;
			textBox = TWlp3COwI9V;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return tupp3YGhOvX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Mg8p3sVuDJE;
			Button button = tupp3YGhOvX;
			if (button != null)
			{
				button.Click -= value2;
			}
			tupp3YGhOvX = value;
			button = tupp3YGhOvX;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelPN
	{
		[CompilerGenerated]
		get
		{
			return OQLp3rbdcZU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OQLp3rbdcZU = value;
		}
	}

	internal virtual Button btExcluirPainel
	{
		[CompilerGenerated]
		get
		{
			return Nufp39OEoLt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FD8p3B8kCFW;
			Button button = Nufp39OEoLt;
			if (button != null)
			{
				button.Click -= value2;
			}
			Nufp39OEoLt = value;
			button = Nufp39OEoLt;
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
			if (disposing && kCYp3uBUEZ6 != null)
			{
				kCYp3uBUEZ6.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void kkEp3mkq0iM()
	{
		kCYp3uBUEZ6 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgPaineisDWG = new DataGridView();
		FDqpBiUmZij(new ToolTip(kCYp3uBUEZ6));
		btTrocaosPaineis = new Button();
		BTAdicionaParaTroca = new Button();
		dgOutrosPaineis = new DataGridView();
		TBNome = new TextBox();
		btInserir = new Button();
		LabelPN = new Label();
		btExcluirPainel = new Button();
		((ISupportInitialize)dgPaineisDWG).BeginInit();
		((ISupportInitialize)dgOutrosPaineis).BeginInit();
		SuspendLayout();
		dgPaineisDWG.AllowUserToAddRows = false;
		dgPaineisDWG.AllowUserToDeleteRows = false;
		dgPaineisDWG.AllowUserToOrderColumns = true;
		dgPaineisDWG.AllowUserToResizeRows = false;
		dgPaineisDWG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPaineisDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgPaineisDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgPaineisDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineisDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaineisDWG.Location = new Point(12, 12);
		dgPaineisDWG.MultiSelect = false;
		dgPaineisDWG.Name = "dgPaineisDWG";
		dgPaineisDWG.ReadOnly = true;
		dgPaineisDWG.RowHeadersVisible = false;
		dgPaineisDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineisDWG.Size = new Size(444, 326);
		dgPaineisDWG.TabIndex = 8;
		btTrocaosPaineis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btTrocaosPaineis.FlatStyle = FlatStyle.Flat;
		btTrocaosPaineis.ForeColor = SystemColors.Control;
		btTrocaosPaineis.Image = Resources.Sincroniza_32;
		btTrocaosPaineis.Location = new Point(462, 298);
		btTrocaosPaineis.Name = "btTrocaosPaineis";
		btTrocaosPaineis.Size = new Size(40, 40);
		btTrocaosPaineis.TabIndex = 135;
		btTrocaosPaineis.UseVisualStyleBackColor = true;
		BTAdicionaParaTroca.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTAdicionaParaTroca.FlatStyle = FlatStyle.Flat;
		BTAdicionaParaTroca.ForeColor = SystemColors.Control;
		BTAdicionaParaTroca.Image = Resources.AtribuirDir_32;
		BTAdicionaParaTroca.Location = new Point(462, 119);
		BTAdicionaParaTroca.Name = "BTAdicionaParaTroca";
		BTAdicionaParaTroca.Size = new Size(40, 40);
		BTAdicionaParaTroca.TabIndex = 134;
		BTAdicionaParaTroca.UseVisualStyleBackColor = true;
		dgOutrosPaineis.AllowDrop = true;
		dgOutrosPaineis.AllowUserToAddRows = false;
		dgOutrosPaineis.AllowUserToDeleteRows = false;
		dgOutrosPaineis.AllowUserToResizeRows = false;
		dgOutrosPaineis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgOutrosPaineis.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgOutrosPaineis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgOutrosPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgOutrosPaineis.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgOutrosPaineis.Location = new Point(508, 37);
		dgOutrosPaineis.MultiSelect = false;
		dgOutrosPaineis.Name = "dgOutrosPaineis";
		dgOutrosPaineis.RowHeadersVisible = false;
		dgOutrosPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgOutrosPaineis.Size = new Size(264, 301);
		dgOutrosPaineis.TabIndex = 178;
		TBNome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBNome.Location = new Point(633, 11);
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(102, 20);
		TBNome.TabIndex = 180;
		btInserir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.Adiciona_32;
		btInserir.Location = new Point(733, 0);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(39, 40);
		btInserir.TabIndex = 179;
		btInserir.UseVisualStyleBackColor = true;
		LabelPN.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LabelPN.BorderStyle = BorderStyle.Fixed3D;
		LabelPN.Location = new Point(508, 9);
		LabelPN.Name = "LabelPN";
		LabelPN.Size = new Size(119, 22);
		LabelPN.TabIndex = 181;
		LabelPN.Text = "LB Novo Painel";
		LabelPN.TextAlign = ContentAlignment.MiddleCenter;
		btExcluirPainel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExcluirPainel.FlatStyle = FlatStyle.Flat;
		btExcluirPainel.ForeColor = SystemColors.Control;
		btExcluirPainel.Image = Resources.Delete_32;
		btExcluirPainel.Location = new Point(462, 165);
		btExcluirPainel.Name = "btExcluirPainel";
		btExcluirPainel.Size = new Size(40, 40);
		btExcluirPainel.TabIndex = 182;
		btExcluirPainel.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(784, 350);
		Controls.Add(btExcluirPainel);
		Controls.Add(LabelPN);
		Controls.Add(dgOutrosPaineis);
		Controls.Add(TBNome);
		Controls.Add(btInserir);
		Controls.Add(btTrocaosPaineis);
		Controls.Add(BTAdicionaParaTroca);
		Controls.Add(dgPaineisDWG);
		MaximizeBox = false;
		MinimumSize = new Size(800, 370);
		Name = "frmTrocaPaineis";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "FRM TROCA PAINÉIS";
		((ISupportInitialize)dgPaineisDWG).EndInit();
		((ISupportInitialize)dgOutrosPaineis).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return c1ip3ZMij0f;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		c1ip3ZMij0f = WithEventsValue;
	}

	public frmTrocaPaineis(bool bAbre)
	{
		Resize += kh4p3XKoWRW;
		Kl3pnpnY1Oq = new List<string>();
		nQTpnTEBCKh = false;
		y8mpnJOrohe = 0;
		try
		{
			if (Geral.ExisteForm("frmTrocaPainel") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			kkEp3mkq0iM();
			nQTpnTEBCKh = bAbre;
			cDadosAccess.carregaDadosDWG();
			zF6pnWMI1Jo = new clsTrocaPainel.mPNOutros[1];
			clsTrocaPainel.PaineisDoDocumento(ref bAYp3z3EW1F);
			clsTrocaPainel.PaineisOutros(ref bAYp3z3EW1F, ref zF6pnWMI1Jo);
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1015]);
			LabelPN.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1086]);
			w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1086]));
			w8dpBZ0kvSD().SetToolTip(btExcluirPainel, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1379]));
			w8dpBZ0kvSD().SetToolTip(BTAdicionaParaTroca, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1015]));
			w8dpBZ0kvSD().SetToolTip(btTrocaosPaineis, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 538]));
			formataDGPainelDWG();
			formataDGOutrosPaineis();
			CarregaDGPainel(bAYp3z3EW1F);
			CarregaOutrosPainel(zF6pnWMI1Jo);
			AtualizaDGPainelDWG();
			AtualizaDGOutrosPaineis();
			btTrocaosPaineis.Enabled = false;
			if (Information.IsNothing(DeclaracoesGeral.dicPainel))
			{
				cDadosAccess.carregaPainelDicionario();
			}
			foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
			{
				Kl3pnpnY1Oq.Add(item.Value.ToUpper());
				if (y8mpnJOrohe <= item.Key)
				{
					y8mpnJOrohe = checked(item.Key + 1);
				}
			}
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void formataDGPainelDWG()
	{
		checked
		{
			try
			{
				dgPaineisDWG.Rows.Clear();
				dgPaineisDWG.Columns.Clear();
				dgPaineisDWG.Columns.Add("Indice", "");
				dgPaineisDWG.Columns.Add("Equipamento", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1225]));
				dgPaineisDWG.Columns.Add("Indice", "");
				dgPaineisDWG.Columns.Add("Equipamento", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1226]));
				int num = dgPaineisDWG.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgPaineisDWG.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				AtualizaDGPainelDWG();
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

	public void formataDGOutrosPaineis()
	{
		try
		{
			dgOutrosPaineis.Rows.Clear();
			dgOutrosPaineis.Columns.Clear();
			dgOutrosPaineis.Columns.Add("Indice", "");
			dgOutrosPaineis.Columns.Add("Equipamento", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1227]));
			AtualizaDGOutrosPaineis();
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

	public void AtualizaDGPainelDWG()
	{
		checked
		{
			try
			{
				if (dgPaineisDWG.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineisDWG)) ? ((double)(dgPaineisDWG.Width - 4)) : ((double)(dgPaineisDWG.Width - 21)));
					dgPaineisDWG.Columns[0].Width = (int)Math.Round(num * 0.1);
					dgPaineisDWG.Columns[1].Width = (int)Math.Round(num * 0.4);
					dgPaineisDWG.Columns[2].Width = (int)Math.Round(num * 0.1);
					dgPaineisDWG.Columns[3].Width = (int)Math.Round(num * 0.4);
					dgPaineisDWG.MultiSelect = false;
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
			}
		}
	}

	public void AtualizaDGOutrosPaineis()
	{
		checked
		{
			try
			{
				if (dgOutrosPaineis.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgOutrosPaineis)) ? ((double)(dgOutrosPaineis.Width - 4)) : ((double)(dgOutrosPaineis.Width - 21)));
					dgOutrosPaineis.Columns[0].Width = (int)Math.Round(num * 0.2);
					dgOutrosPaineis.Columns[1].Width = (int)Math.Round(num * 0.8);
					dgOutrosPaineis.MultiSelect = false;
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
			}
		}
	}

	public void CarregaDGPainel(clsTrocaPainel.mPN[] mPainel)
	{
		try
		{
			if (Information.UBound(mPainel) > 0)
			{
				int num = Information.UBound(mPainel);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgPaineisDWG.Rows.Add(mPainel[i].iPainel, mPainel[i].sPainel, "", "");
				}
				DataGridViewColumn dataGridViewColumn = dgPaineisDWG.Columns[1];
				dgPaineisDWG.Sort(dataGridViewColumn, ListSortDirection.Ascending);
				dgPaineisDWG.Rows[0].Selected = true;
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

	public void CarregaOutrosPainel(clsTrocaPainel.mPNOutros[] mPainel)
	{
		try
		{
			if (Information.UBound(mPainel) > 0)
			{
				int num = Information.UBound(mPainel);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgOutrosPaineis.Rows.Add(mPainel[i].iPainel, mPainel[i].sPainel);
				}
				DataGridViewColumn dataGridViewColumn = dgOutrosPaineis.Columns[1];
				dgOutrosPaineis.Sort(dataGridViewColumn, ListSortDirection.Ascending);
				dgOutrosPaineis.Rows[0].Selected = true;
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

	private void kh4p3XKoWRW(object P_0, EventArgs P_1)
	{
		AtualizaDGPainelDWG();
		AtualizaDGOutrosPaineis();
	}

	private void z6sp3UP4vvT(object P_0, EventArgs P_1)
	{
		int num = 0;
		int num2 = 0;
		string text = "";
		if (dgPaineisDWG.SelectedRows.Count == 0)
		{
			return;
		}
		checked
		{
			if (Operators.CompareString(dgPaineisDWG.SelectedRows[0].Cells[2].Value.ToString().Trim(), "", TextCompare: true) != 0)
			{
				num = ((Operators.CompareString(dgPaineisDWG.SelectedRows[0].Cells[2].Value.ToString(), "*", TextCompare: true) != 0) ? Conversions.ToInteger(dgPaineisDWG.SelectedRows[0].Cells[2].Value) : 0);
				text = Conversions.ToString(dgPaineisDWG.SelectedRows[0].Cells[3].Value);
				if (dgOutrosPaineis.SelectedRows[0].Index >= 10)
				{
					dgOutrosPaineis.FirstDisplayedScrollingRowIndex = dgOutrosPaineis.SelectedRows[0].Index - 9;
				}
			}
			dgPaineisDWG.SelectedRows[0].Cells[2].Value = RuntimeHelpers.GetObjectValue(dgOutrosPaineis.SelectedRows[0].Cells[0].Value);
			dgPaineisDWG.SelectedRows[0].Cells[3].Value = RuntimeHelpers.GetObjectValue(dgOutrosPaineis.SelectedRows[0].Cells[1].Value);
			dgPaineisDWG.SelectedRows[0].Cells[0].Style.BackColor = Color.White;
			dgPaineisDWG.SelectedRows[0].Cells[1].Style.BackColor = Color.White;
			int index = dgOutrosPaineis.SelectedRows[0].Index;
			if (index < dgOutrosPaineis.RowCount - 1)
			{
				num2 = Conversions.ToInteger(dgOutrosPaineis.Rows[index + 1].Cells[0].Value);
			}
			dgOutrosPaineis.Rows.RemoveAt(dgOutrosPaineis.SelectedRows[0].Index);
			if (num > 0)
			{
				dgOutrosPaineis.Rows.Add(num, text);
				DataGridViewColumn dataGridViewColumn = dgOutrosPaineis.Columns[0];
				dgOutrosPaineis.Sort(dataGridViewColumn, ListSortDirection.Ascending);
			}
			int num3 = dgPaineisDWG.RowCount - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (Operators.CompareString(dgPaineisDWG.Rows[i].Cells[2].Value.ToString().Trim(), "", TextCompare: true) == 0)
				{
					dgPaineisDWG.Rows[i].Selected = true;
					if (i >= 10)
					{
						dgPaineisDWG.FirstDisplayedScrollingRowIndex = i - 9;
					}
					break;
				}
			}
			if (num2 != 0)
			{
				int num4 = dgOutrosPaineis.RowCount - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (Conversions.ToInteger(dgOutrosPaineis.Rows[j].Cells[0].Value) == num2)
					{
						dgOutrosPaineis.Rows[j].Selected = true;
						if (j >= 10)
						{
							dgOutrosPaineis.FirstDisplayedScrollingRowIndex = j - 9;
						}
						break;
					}
				}
			}
			btTrocaosPaineis.Enabled = true;
		}
	}

	private void ODxp3yOULUQ(object P_0, KeyEventArgs P_1)
	{
		t0fp3AwkPxc();
	}

	private void UBKp3gSy7eQ(object P_0, DataGridViewCellEventArgs P_1)
	{
		checked
		{
			int num = dgPaineisDWG.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgPaineisDWG.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			TBNome.Text = Conversions.ToString(dgPaineisDWG.Rows[num2].Cells[1].Value);
			t0fp3AwkPxc();
		}
	}

	private void t0fp3AwkPxc()
	{
		btInserir.Enabled = true;
		if (Operators.CompareString(TBNome.Text.Trim(), "", TextCompare: true) == 0)
		{
			TBNome.Text = "";
		}
		if (Kl3pnpnY1Oq.Contains(TBNome.Text.ToUpper()))
		{
			btInserir.Enabled = false;
		}
		checked
		{
			int num = dgPaineisDWG.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(dgPaineisDWG.Rows[num2].Cells[3].Value, TBNome.Text.ToUpper(), TextCompare: true))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			btInserir.Enabled = false;
		}
	}

	private void Mg8p3sVuDJE(object P_0, EventArgs P_1)
	{
		int num = 0;
		checked
		{
			int num2 = dgPaineisDWG.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgPaineisDWG.Rows[i].Selected & btInserir.Enabled)
				{
					if (i >= 6)
					{
						dgPaineisDWG.FirstDisplayedScrollingRowIndex = i - 5;
					}
					dgPaineisDWG.Rows[i].Cells[2].Value = "*";
					dgPaineisDWG.Rows[i].Cells[3].Value = TBNome.Text;
					dgPaineisDWG.Rows[i].Cells[0].Style.BackColor = Color.White;
					dgPaineisDWG.Rows[i].Cells[1].Style.BackColor = Color.White;
					num = i + 1;
					btTrocaosPaineis.Enabled = true;
					break;
				}
			}
			if (num <= dgPaineisDWG.Rows.Count - 1)
			{
				dgPaineisDWG.Rows[num].Selected = true;
				TBNome.Text = Conversions.ToString(dgPaineisDWG.Rows[num].Cells[1].Value);
			}
			t0fp3AwkPxc();
		}
	}

	private void FD8p3B8kCFW(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgPaineisDWG.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgPaineisDWG.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			dgPaineisDWG.Rows[num2].Cells[2].Value = "";
			dgPaineisDWG.Rows[num2].Cells[3].Value = DeclaracoesGeral.mMensagem[1, 1375].ToString().ToUpper();
			btTrocaosPaineis.Enabled = true;
			dgPaineisDWG.Rows[num2].Cells[0].Style.BackColor = Color.LightCoral;
			dgPaineisDWG.Rows[num2].Cells[1].Style.BackColor = Color.LightCoral;
			if (num2 < dgPaineisDWG.Rows.Count - 1)
			{
				dgPaineisDWG.Rows[num2 + 1].Selected = true;
				if (num2 >= 6)
				{
					dgPaineisDWG.FirstDisplayedScrollingRowIndex = num2 - 5;
				}
			}
		}
	}

	private void YRBp3ViHS2t(object P_0, EventArgs P_1)
	{
		PointMonitorToolTips.StopMonitor();
		btTrocaosPaineis.Enabled = false;
		string text = "";
		List<int> list = new List<int>();
		string userName = Environment.UserName;
		string sEditor = "";
		object value = DateTime.Now.ToString();
		cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
		checked
		{
			int num = dgPaineisDWG.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(dgPaineisDWG.Rows[i].Cells[2].Value.ToString(), "*", TextCompare: true) == 0)
				{
					text = Conversions.ToString(dgPaineisDWG.Rows[i].Cells[3].Value);
					dgPaineisDWG.Rows[i].Cells[2].Value = y8mpnJOrohe;
					cDadosAccessPaineis2.AdicionaPainel("Paineis", y8mpnJOrohe, text, userName, sEditor, Conversions.ToDate(value));
					y8mpnJOrohe++;
					dgPaineisDWG.FirstDisplayedScrollingRowIndex = 0;
				}
			}
			cDadosAccessPaineis2.fechaConexao();
			int num2 = dgPaineisDWG.RowCount - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(dgPaineisDWG.Rows[j].Cells[2].Value.ToString(), "", TextCompare: true) == 0, Operators.CompareObjectEqual(dgPaineisDWG.Rows[j].Cells[3].Value, DeclaracoesGeral.mMensagem[1, 1375].ToString().ToUpper(), TextCompare: true))))
				{
					cDadosAccessDuplicaCaderno cDadosAccessDuplicaCaderno2 = new cDadosAccessDuplicaCaderno();
					List<int> lDisp = new List<int>();
					List<int> lMasc = new List<int>();
					cDadosAccessDuplicaCaderno2.BuscaIndicesFiacao(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice, ref lDisp, ref lMasc);
					cDadosAccessDuplicaCaderno2.ApagaFiacao(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaContatos4F(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice, lDisp);
					cDadosAccessDuplicaCaderno2.ApagaCircuitos4F(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaPortas4F(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice, lMasc);
					cDadosAccessDuplicaCaderno2.ApagaDispositivos4F(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaBornes4F(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaVarios3(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value), DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.fechaConexao();
					list.Add(Conversions.ToInteger(dgPaineisDWG.Rows[j].Cells[0].Value));
					dgPaineisDWG.Rows[j].Cells[0].Value = "";
					dgPaineisDWG.Rows[j].Cells[1].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(dgPaineisDWG.Rows[j].Cells[1].Value, " - "), DeclaracoesGeral.mMensagem[1, 1170].ToString().ToUpper());
					dgPaineisDWG.Rows[j].Cells[2].Value = "";
					dgPaineisDWG.Rows[j].Cells[3].Value = "";
					dgPaineisDWG.Rows[j].Cells[0].Style.BackColor = Color.LightCoral;
					dgPaineisDWG.Rows[j].Cells[1].Style.BackColor = Color.LightCoral;
					dgPaineisDWG.Rows[j].Cells[2].Style.BackColor = Color.LightCoral;
					dgPaineisDWG.Rows[j].Cells[3].Style.BackColor = Color.LightCoral;
				}
			}
			if (list.Count > 0)
			{
				clsPainel.ApagaPaineisDocumento(list);
			}
			int num3 = 0;
			int num4 = 0;
			DeclaracoesGeral.bSuspenderEvento = true;
			Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
			if (dgPaineisDWG.RowCount > 0)
			{
				dgPaineisDWG.FirstDisplayedScrollingRowIndex = 0;
			}
			cDadosAccessPaineis cDadosAccessPaineis3 = new cDadosAccessPaineis();
			int num5 = dgPaineisDWG.RowCount - 1;
			for (int k = 0; k <= num5; k++)
			{
				if (Operators.CompareString(dgPaineisDWG.Rows[k].Cells[2].Value.ToString(), "", TextCompare: true) != 0)
				{
					num3 = Conversions.ToInteger(dgPaineisDWG.Rows[k].Cells[0].Value);
					num4 = Conversions.ToInteger(dgPaineisDWG.Rows[k].Cells[2].Value);
					cDadosAccessPaineis3.TrocaPaineis(DeclaracoesGeral.arqAtivo.Indice, num3, num4);
				}
			}
			cDadosAccessPaineis3.fechaConexao();
			cDadosAccess.carregaPainelDicionario();
			int num6 = dgPaineisDWG.RowCount - 1;
			for (int l = 0; l <= num6; l++)
			{
				if (Operators.CompareString(dgPaineisDWG.Rows[l].Cells[2].Value.ToString(), "", TextCompare: true) == 0)
				{
					continue;
				}
				dgPaineisDWG.Rows[l].Selected = true;
				Application.DoEvents();
				num3 = Conversions.ToInteger(dgPaineisDWG.Rows[l].Cells[0].Value);
				num4 = Conversions.ToInteger(dgPaineisDWG.Rows[l].Cells[2].Value);
				string value2 = Conversions.ToString(dgPaineisDWG.Rows[l].Cells[0].Value);
				string value3 = Conversions.ToString(dgPaineisDWG.Rows[l].Cells[1].Value);
				dgPaineisDWG.Rows[l].Cells[0].Value = RuntimeHelpers.GetObjectValue(dgPaineisDWG.Rows[l].Cells[2].Value);
				dgPaineisDWG.Rows[l].Cells[1].Value = RuntimeHelpers.GetObjectValue(dgPaineisDWG.Rows[l].Cells[3].Value);
				dgPaineisDWG.Rows[l].Cells[2].Value = value2;
				dgPaineisDWG.Rows[l].Cells[3].Value = value3;
				clsTrocaPainel.TrocaPainelDisp_P_M_C(num3, num4);
				clsTrocaPainel.TrocaPainelLAYOUT(num3, num4);
				clsTrocaPainel.TrocaPainelTOPO(num3, num4);
				DeclaracoesEntidades.StructureLayout[] mTags = new DeclaracoesEntidades.StructureLayout[1];
				if (DicionarioLayout.LeDicLayout("P" + num3, ref mTags))
				{
					DicionarioLayout.ApagaDicLayoutPainel("P", num3.ToString());
					DicionarioLayout.gravaDicLayout("P" + num4, ref mTags);
				}
				DeclaracoesEntidades.StructureLayout[] mTags2 = new DeclaracoesEntidades.StructureLayout[1];
				if (DicionarioLayout.LeDicLayout("C" + num3, ref mTags2))
				{
					DicionarioLayout.ApagaDicLayoutPainel("C", num3.ToString());
					DicionarioLayout.gravaDicLayout("C" + num4, ref mTags2);
				}
				Declaracoes2.StructurePlaquetas[] mPlaquetas = new Declaracoes2.StructurePlaquetas[1];
				if (DicionarioPlaqueta.LeDicPlaquetas(num3.ToString(), ref mPlaquetas))
				{
					DicionarioPlaqueta.ApagaDicPlaquetasPainel(num3.ToString());
					DicionarioPlaqueta.gravaDicPlaqueta(num4.ToString(), ref mPlaquetas);
				}
				int num7 = Information.UBound(mModelo);
				for (int m = 1; m <= num7; m++)
				{
					if (mModelo[m].indexPainel == num3)
					{
						mModelo[m].indexPainel = num4;
						DicionarioReguas.GravaOsModelosDeRegua(mModelo);
						clsBornes.EditarOsBornesDasReguasSelecionada(mModelo, m);
					}
				}
				dgPaineisDWG.Rows[l].Cells[0].Style.BackColor = Color.LightGreen;
				dgPaineisDWG.Rows[l].Cells[2].Style.BackColor = Color.LightGray;
				dgPaineisDWG.Rows[l].Cells[1].Style.BackColor = Color.LightGreen;
				dgPaineisDWG.Rows[l].Cells[3].Style.BackColor = Color.LightGray;
				dgPaineisDWG.Rows[l].Selected = false;
				if (l >= 10)
				{
					dgPaineisDWG.FirstDisplayedScrollingRowIndex = l - 9;
				}
			}
			clsUtilitarios.EditaPortaDipAuxPainelModeloFabricante();
			clsUtilitarios.CorrigePainelET1DosBornes();
			DeclaracoesGeral.bSuspenderEvento = false;
			PointMonitorToolTips.StartMonitor();
			if (nQTpnTEBCKh)
			{
				Close();
				new frmClonarCabos();
			}
			btTrocaosPaineis.Enabled = true;
		}
	}
}
