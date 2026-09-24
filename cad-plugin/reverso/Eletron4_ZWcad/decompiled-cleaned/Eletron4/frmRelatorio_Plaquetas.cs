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
public class frmRelatorio_Plaquetas : Form
{
	private IContainer y7ZpNmK64FF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	private DataGridView M0vpNXPHvkg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button bKTpNUEO6YZ;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip T9qpNy9mLTt;

	[AccessedThroughProperty("btExporta")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button BqkpNg2gWNC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPlaquetas")]
	private DataGridView BC3pNAcEX1r;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEportaExcel")]
	private Button OEbpNsVMCCa;

	private DeclaracoesFiacao.structureRelPlaquetas[] hRjpNBBqHnY;

	private int guSpNVNQtvy;

	private string p8VpNuW0iDt;

	private bool oI6pNErOdqD;

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return M0vpNXPHvkg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = NUUpNeeobWb;
			EventHandler value3 = QxIpN2t24wM;
			DataGridView dataGridView = M0vpNXPHvkg;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.SelectionChanged -= value3;
			}
			M0vpNXPHvkg = value;
			dataGridView = M0vpNXPHvkg;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.SelectionChanged += value3;
			}
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return bKTpNUEO6YZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = V59pNnOY6iy;
			Button button = bKTpNUEO6YZ;
			if (button != null)
			{
				button.Click -= value2;
			}
			bKTpNUEO6YZ = value;
			button = bKTpNUEO6YZ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return BqkpNg2gWNC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TvMpN0hI1LW;
			Button button = BqkpNg2gWNC;
			if (button != null)
			{
				button.Click -= value2;
			}
			BqkpNg2gWNC = value;
			button = BqkpNg2gWNC;
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
			return BC3pNAcEX1r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = VbwpN1QOEEe;
			DataGridView dataGridView = BC3pNAcEX1r;
			if (dataGridView != null)
			{
				dataGridView.CellValueChanged -= value2;
			}
			BC3pNAcEX1r = value;
			dataGridView = BC3pNAcEX1r;
			if (dataGridView != null)
			{
				dataGridView.CellValueChanged += value2;
			}
		}
	}

	internal virtual Button btEportaExcel
	{
		[CompilerGenerated]
		get
		{
			return OEbpNsVMCCa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nZUpNRR1mHo;
			Button button = OEbpNsVMCCa;
			if (button != null)
			{
				button.Click -= value2;
			}
			OEbpNsVMCCa = value;
			button = OEbpNsVMCCa;
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
			if (disposing && y7ZpNmK64FF != null)
			{
				y7ZpNmK64FF.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void GbDpNQqGLOy()
	{
		y7ZpNmK64FF = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Plaquetas));
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgEquip = new DataGridView();
		btPesquisar = new Button();
		FDqpBiUmZij(new ToolTip(y7ZpNmK64FF));
		btExporta = new Button();
		dgPlaquetas = new DataGridView();
		btEportaExcel = new Button();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgPlaquetas).BeginInit();
		SuspendLayout();
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 12);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(178, 389);
		dgEquip.TabIndex = 8;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(18, 407);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExporta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(81, 407);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 50;
		btExporta.UseVisualStyleBackColor = true;
		dgPlaquetas.AllowUserToAddRows = false;
		dgPlaquetas.AllowUserToDeleteRows = false;
		dgPlaquetas.AllowUserToOrderColumns = true;
		dgPlaquetas.AllowUserToResizeRows = false;
		dgPlaquetas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPlaquetas.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgPlaquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgPlaquetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPlaquetas.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPlaquetas.Location = new Point(196, 12);
		dgPlaquetas.MultiSelect = false;
		dgPlaquetas.Name = "dgPlaquetas";
		dgPlaquetas.ReadOnly = true;
		dgPlaquetas.RowHeadersVisible = false;
		dgPlaquetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPlaquetas.Size = new Size(726, 437);
		dgPlaquetas.TabIndex = 51;
		btEportaExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btEportaExcel.FlatStyle = FlatStyle.Flat;
		btEportaExcel.ForeColor = SystemColors.Control;
		btEportaExcel.Image = Resources.ExportaExcel_20;
		btEportaExcel.Location = new Point(144, 407);
		btEportaExcel.Name = "btEportaExcel";
		btEportaExcel.Size = new Size(40, 42);
		btEportaExcel.TabIndex = 53;
		btEportaExcel.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(934, 461);
		Controls.Add(btEportaExcel);
		Controls.Add(dgPlaquetas);
		Controls.Add(btExporta);
		Controls.Add(btPesquisar);
		Controls.Add(dgEquip);
		MinimumSize = new Size(950, 500);
		Name = "frmRelatorio_Plaquetas";
		ShowInTaskbar = false;
		Text = "Gerenciador de Plaquetas";
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgPlaquetas).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return T9qpNy9mLTt;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		T9qpNy9mLTt = WithEventsValue;
	}

	public frmRelatorio_Plaquetas()
	{
		Resize += d1BpNlXWDUG;
		guSpNVNQtvy = 0;
		p8VpNuW0iDt = "";
		oI6pNErOdqD = false;
		try
		{
			if (Geral.ExisteForm("frmRelatorio_Plaquetas") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				GbDpNQqGLOy();
				Application.ShowModelessDialog((Form)this);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 589]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 815]));
				w8dpBZ0kvSD().SetToolTip(btExporta, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 599], " "), DeclaracoesGeral.mMensagem[1, 582])));
				formataDGEquip();
				CarregaDGEquip();
				formataDGPlaquetas();
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
		cDadosAccessPlaquetas cDadosAccessPlaquetas2 = new cDadosAccessPlaquetas();
		try
		{
			cDadosAccessPlaquetas2.CarregaPaineis(dgEquip);
			AtualizaDGEquip();
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
			cDadosAccessPlaquetas2.fechaConexao();
		}
	}

	private bool YRMpNPeKZTM(Declaracoes2.StructurePlaquetas[] P_0)
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

	private bool RaepNcE5D7f(string P_0, Declaracoes2.StructurePlaquetas[] P_1)
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

	private bool Dq6pNKnHJke(int P_0, Declaracoes2.StructurePlaquetas[] P_1)
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

	private void NUUpNeeobWb(object P_0, KeyEventArgs P_1)
	{
		JYCpN3Q5AGb();
	}

	private void QxIpN2t24wM(object P_0, EventArgs P_1)
	{
		JYCpN3Q5AGb();
	}

	private void JYCpN3Q5AGb()
	{
		formataDGPlaquetas();
		guSpNVNQtvy = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		p8VpNuW0iDt = dgEquip.SelectedRows[0].Cells[1].Value.ToString();
	}

	private void V59pNnOY6iy(object P_0, EventArgs P_1)
	{
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		formataDGPlaquetas();
		checked
		{
			try
			{
				cDadosAccessPlaquetas cDadosAccessPlaquetas2 = new cDadosAccessPlaquetas();
				cDadosAccessPlaquetas2.CarregaPlaquetas(dgPlaquetas, guSpNVNQtvy);
				cDadosAccessPlaquetas2.fechaConexao();
				hRjpNBBqHnY = new DeclaracoesFiacao.structureRelPlaquetas[1];
				int num = 1;
				int num2 = dgPlaquetas.RowCount - 1;
				for (int i = 0; i <= num2; i++)
				{
					string text = dgPlaquetas.Rows[i].Cells[3].Value.ToString();
					string text2 = dgPlaquetas.Rows[i].Cells[4].Value.ToString();
					string text3 = dgPlaquetas.Rows[i].Cells[5].Value.ToString();
					string text4 = dgPlaquetas.Rows[i].Cells[6].Value.ToString();
					string text5 = dgPlaquetas.Rows[i].Cells[7].Value.ToString();
					bool flag = true;
					int num3 = Information.UBound(hRjpNBBqHnY);
					for (int j = 0; j <= num3; j++)
					{
						if ((Operators.CompareString(hRjpNBBqHnY[j].Nome, text, TextCompare: true) == 0) & (Operators.CompareString(hRjpNBBqHnY[j].Desc1, text2, TextCompare: true) == 0) & (Operators.CompareString(hRjpNBBqHnY[j].Desc2, text3, TextCompare: true) == 0) & (Operators.CompareString(hRjpNBBqHnY[j].Desc3, text4, TextCompare: true) == 0) & (Operators.CompareString(hRjpNBBqHnY[j].Modelo, text5, TextCompare: true) == 0))
						{
							hRjpNBBqHnY[j].Quant = Conversions.ToString(Conversions.ToInteger(hRjpNBBqHnY[j].Quant) + 1);
							flag = false;
							break;
						}
					}
					if (flag)
					{
						ref DeclaracoesFiacao.structureRelPlaquetas[] reference = ref hRjpNBBqHnY;
						reference = (DeclaracoesFiacao.structureRelPlaquetas[])Utils.CopyArray(reference, new DeclaracoesFiacao.structureRelPlaquetas[num + 1]);
						hRjpNBBqHnY[num].Indice = Conversions.ToString(num);
						hRjpNBBqHnY[num].Nome = text;
						hRjpNBBqHnY[num].Desc1 = text2;
						hRjpNBBqHnY[num].Desc2 = text3;
						hRjpNBBqHnY[num].Desc3 = text4;
						hRjpNBBqHnY[num].Modelo = text5;
						hRjpNBBqHnY[num].Quant = "1";
						hRjpNBBqHnY[num].Painel = p8VpNuW0iDt;
						num++;
					}
					flag = true;
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
			AtualizaDGPlaquetas();
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
			double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip)) ? ((double)(dgEquip.Width - 4)) : ((double)(dgEquip.Width - 21)));
			dgEquip.Columns[0].Width = 0;
			dgEquip.Columns[0].Visible = false;
			dgEquip.Columns[1].Width = (int)Math.Round(a);
		}
	}

	public void AtualizaDGPlaquetas()
	{
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPlaquetas)) ? ((double)(dgPlaquetas.Width - 4)) : ((double)(dgPlaquetas.Width - 21)));
			dgPlaquetas.Columns[0].Width = 0;
			dgPlaquetas.Columns[0].Visible = false;
			dgPlaquetas.Columns[1].Width = 0;
			dgPlaquetas.Columns[1].Visible = false;
			dgPlaquetas.Columns[2].Width = 0;
			dgPlaquetas.Columns[2].Visible = false;
			dgPlaquetas.Columns[3].Width = (int)Math.Round(num * 2.0 / 9.0);
			dgPlaquetas.Columns[4].Width = (int)Math.Round(num * 2.0 / 9.0);
			dgPlaquetas.Columns[5].Width = (int)Math.Round(num * 2.0 / 9.0);
			dgPlaquetas.Columns[6].Width = (int)Math.Round(num * 2.0 / 9.0);
			dgPlaquetas.Columns[7].Width = (int)Math.Round(num / 9.0);
			int num2 = dgPlaquetas.Columns.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				dgPlaquetas.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
			dgPlaquetas.Columns[3].ReadOnly = true;
			AtualizaDGPlaquetas();
			dgPlaquetas.Columns[0].ReadOnly = false;
			dgPlaquetas.Columns[1].ReadOnly = false;
			dgPlaquetas.Columns[2].ReadOnly = false;
			dgPlaquetas.Columns[3].ReadOnly = false;
			dgPlaquetas.Columns[4].ReadOnly = false;
			dgPlaquetas.Columns[5].ReadOnly = false;
			dgPlaquetas.Columns[6].ReadOnly = false;
			dgPlaquetas.Columns[7].ReadOnly = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void VbwpN1QOEEe(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (((P_1.ColumnIndex == 4) | (P_1.ColumnIndex == 5) | (P_1.ColumnIndex == 6)) && dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value.ToString().Length > 40)
		{
			dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value = Strings.Mid(Conversions.ToString(dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value), 1, 40);
		}
		if (P_1.ColumnIndex == 7 && dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value.ToString().Length > 10)
		{
			dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value = Strings.Mid(Conversions.ToString(dgPlaquetas[P_1.ColumnIndex, P_1.RowIndex].Value), 1, 10);
		}
	}

	private void d1BpNlXWDUG(object P_0, EventArgs P_1)
	{
		IoBpN5HamKJ();
	}

	private void IoBpN5HamKJ()
	{
		if (dgPlaquetas.Columns.Count == 8)
		{
			AtualizaDGPlaquetas();
		}
	}

	private void TvMpN0hI1LW(object P_0, EventArgs P_1)
	{
		if (!Information.IsNothing(hRjpNBBqHnY) && Information.UBound(hRjpNBBqHnY) > 0)
		{
			new frmRelatorio_PlaquetasDWG(hRjpNBBqHnY, "PL", guSpNVNQtvy);
		}
	}

	private void nZUpNRR1mHo(object P_0, EventArgs P_1)
	{
		btEportaExcel.Enabled = false;
		Relatorios_PlaquetasEXCEL.CriaPlaquetasEXCEL(hRjpNBBqHnY, p8VpNuW0iDt);
		btEportaExcel.Enabled = true;
	}
}
