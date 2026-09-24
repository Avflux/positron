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
public class frmEditaNomeCircuitos : Form
{
	private IContainer eLhHfs9Zgd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgCircuitos")]
	private DataGridView lXLHDW8Evb;

	[AccessedThroughProperty("btExportar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button HMFHv7dZfR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btImportar")]
	private Button wf4H6kv82G;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEditar")]
	private Button pMRHtEh5Ue;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPaineis")]
	private DataGridView z9QHjURDdK;

	[AccessedThroughProperty("dgPaginas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView KD5HLYwHhU;

	private DeclaracoesEntidades.StructureConexao[] PWaHwrCoDC;

	private bool xFuHxdmWVN;

	internal virtual DataGridView dgCircuitos
	{
		[CompilerGenerated]
		get
		{
			return lXLHDW8Evb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DpwHoaxGC4;
			DataGridView dataGridView = lXLHDW8Evb;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			lXLHDW8Evb = value;
			dataGridView = lXLHDW8Evb;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btExportar
	{
		[CompilerGenerated]
		get
		{
			return HMFHv7dZfR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zodHHBTkkP;
			Button button = HMFHv7dZfR;
			if (button != null)
			{
				button.Click -= value2;
			}
			HMFHv7dZfR = value;
			button = HMFHv7dZfR;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btImportar
	{
		[CompilerGenerated]
		get
		{
			return wf4H6kv82G;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lRSHkrwoth;
			Button button = wf4H6kv82G;
			if (button != null)
			{
				button.Click -= value2;
			}
			wf4H6kv82G = value;
			button = wf4H6kv82G;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEditar
	{
		[CompilerGenerated]
		get
		{
			return pMRHtEh5Ue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ivmHdfgw2D;
			Button button = pMRHtEh5Ue;
			if (button != null)
			{
				button.Click -= value2;
			}
			pMRHtEh5Ue = value;
			button = pMRHtEh5Ue;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPaineis
	{
		[CompilerGenerated]
		get
		{
			return z9QHjURDdK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xDjHhDYHra;
			DataGridView dataGridView = z9QHjURDdK;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			z9QHjURDdK = value;
			dataGridView = z9QHjURDdK;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgPaginas
	{
		[CompilerGenerated]
		get
		{
			return KD5HLYwHhU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PHyHGBFJJ7;
			DataGridView dataGridView = KD5HLYwHhU;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			KD5HLYwHhU = value;
			dataGridView = KD5HLYwHhU;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && eLhHfs9Zgd != null)
			{
				eLhHfs9Zgd.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void T0fHJ3efwe()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dgCircuitos = new DataGridView();
		btExportar = new Button();
		btImportar = new Button();
		btEditar = new Button();
		dgPaineis = new DataGridView();
		dgPaginas = new DataGridView();
		((ISupportInitialize)dgCircuitos).BeginInit();
		((ISupportInitialize)dgPaineis).BeginInit();
		((ISupportInitialize)dgPaginas).BeginInit();
		SuspendLayout();
		dgCircuitos.AllowUserToAddRows = false;
		dgCircuitos.AllowUserToDeleteRows = false;
		dgCircuitos.AllowUserToOrderColumns = true;
		dgCircuitos.AllowUserToResizeRows = false;
		dgCircuitos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgCircuitos.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgCircuitos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgCircuitos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgCircuitos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgCircuitos.Location = new Point(135, 12);
		dgCircuitos.Name = "dgCircuitos";
		dgCircuitos.ReadOnly = true;
		dgCircuitos.RowHeadersVisible = false;
		dgCircuitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgCircuitos.Size = new Size(177, 405);
		dgCircuitos.TabIndex = 10;
		btExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportar.FlatStyle = FlatStyle.Flat;
		btExportar.ForeColor = SystemColors.Control;
		btExportar.Image = Resources.ExportaExcel_20;
		btExportar.Location = new Point(309, 423);
		btExportar.Name = "btExportar";
		btExportar.Size = new Size(30, 40);
		btExportar.TabIndex = 190;
		btExportar.UseVisualStyleBackColor = true;
		btImportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.ImportaExcel_20;
		btImportar.Location = new Point(340, 423);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(30, 40);
		btImportar.TabIndex = 189;
		btImportar.UseVisualStyleBackColor = true;
		btEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btEditar.Enabled = false;
		btEditar.FlatStyle = FlatStyle.Flat;
		btEditar.ForeColor = SystemColors.Control;
		btEditar.Image = Resources.Editar;
		btEditar.Location = new Point(376, 423);
		btEditar.Name = "btEditar";
		btEditar.Size = new Size(40, 40);
		btEditar.TabIndex = 191;
		btEditar.UseVisualStyleBackColor = true;
		dgPaineis.AllowUserToAddRows = false;
		dgPaineis.AllowUserToDeleteRows = false;
		dgPaineis.AllowUserToOrderColumns = true;
		dgPaineis.AllowUserToResizeRows = false;
		dgPaineis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPaineis.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgPaineis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineis.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaineis.Location = new Point(12, 12);
		dgPaineis.Name = "dgPaineis";
		dgPaineis.ReadOnly = true;
		dgPaineis.RowHeadersVisible = false;
		dgPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineis.Size = new Size(117, 405);
		dgPaineis.TabIndex = 10;
		dgPaginas.AllowUserToAddRows = false;
		dgPaginas.AllowUserToDeleteRows = false;
		dgPaginas.AllowUserToOrderColumns = true;
		dgPaginas.AllowUserToResizeRows = false;
		dgPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPaginas.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgPaginas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgPaginas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaginas.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaginas.Location = new Point(318, 12);
		dgPaginas.MultiSelect = false;
		dgPaginas.Name = "dgPaginas";
		dgPaginas.ReadOnly = true;
		dgPaginas.RowHeadersVisible = false;
		dgPaginas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaginas.Size = new Size(94, 405);
		dgPaginas.TabIndex = 10;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(424, 475);
		Controls.Add(btEditar);
		Controls.Add(btExportar);
		Controls.Add(btImportar);
		Controls.Add(dgPaginas);
		Controls.Add(dgPaineis);
		Controls.Add(dgCircuitos);
		MaximumSize = new Size(440, 1400);
		MinimumSize = new Size(440, 400);
		Name = "frmEditaNomeCircuitos";
		Text = "frmEditaNomeCircuitos";
		((ISupportInitialize)dgCircuitos).EndInit();
		((ISupportInitialize)dgPaineis).EndInit();
		((ISupportInitialize)dgPaginas).EndInit();
		ResumeLayout(performLayout: false);
	}

	public frmEditaNomeCircuitos()
	{
		xFuHxdmWVN = false;
		try
		{
			if (!Geral.ExisteForm("frmEditaNomeCircuitos"))
			{
				cDadosAccess.carregaDadosDWG();
				PWaHwrCoDC = new DeclaracoesEntidades.StructureConexao[1];
				T0fHJ3efwe();
				clsConexao.LeTodosCircuitos(ref PWaHwrCoDC);
				Application.ShowModelessDialog((Form)this);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1934]);
				formataDGCircuitos();
				formataDGPaineis();
				CarregaDGPaineis(ref PWaHwrCoDC);
				btEditar.Enabled = false;
				btImportar.Enabled = false;
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

	public void CarregaDGPaineis(ref DeclaracoesEntidades.StructureConexao[] conex)
	{
		List<int> list = new List<int>();
		OrdenaPaineis(ref conex);
		DeclaracoesEntidades.StructureConexao[] array = conex;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			DeclaracoesEntidades.StructureConexao structureConexao = array[i];
			if (structureConexao.Painel != 0 && !list.Contains(structureConexao.Painel))
			{
				dgPaineis.Rows.Add(structureConexao.Painel, DeclaracoesGeral.dicPainel[structureConexao.Painel]);
				list.Add(structureConexao.Painel);
			}
		}
		AtualizaDGPaineis();
	}

	public void CarregaDGCircuitos(ref DeclaracoesEntidades.StructureConexao[] conex)
	{
		OrdenaPaineis(ref conex);
		formataDGPaineis();
		DeclaracoesEntidades.StructureConexao[] array = conex;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			DeclaracoesEntidades.StructureConexao structureConexao = array[i];
			if (structureConexao.Painel != 0)
			{
				dgPaineis.Rows.Add(DeclaracoesGeral.dicPainel[structureConexao.Painel], structureConexao.Potencial, structureConexao.Nome, "");
			}
		}
		AtualizaDGCircuitos();
	}

	public void OrdenaPaineis(ref DeclaracoesEntidades.StructureConexao[] conex)
	{
		DeclaracoesEntidades.StructureConexao structureConexao = default;
		if (Information.UBound(conex) <= 0)
		{
			return;
		}
		int num = Information.UBound(conex);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(conex) - 1;
				int num3 = i;
				for (int j = num2; j >= num3; j += -1)
				{
					if (conex[j].Painel > conex[j + 1].Painel)
					{
						structureConexao = conex[j + 1];
						conex[j + 1] = conex[j];
						conex[j] = structureConexao;
					}
					if (conex[j].Painel == conex[j + 1].Painel && Operators.CompareString(conex[j].Nome, conex[j + 1].Nome, TextCompare: true) > 0)
					{
						structureConexao = conex[j + 1];
						conex[j + 1] = conex[j];
						conex[j] = structureConexao;
					}
					if (conex[j].Painel == conex[j + 1].Painel && Operators.CompareString(conex[j].Nome, conex[j + 1].Nome, TextCompare: true) == 0 && Operators.CompareString(conex[j].Pagina, conex[j + 1].Pagina, TextCompare: true) > 0)
					{
						structureConexao = conex[j + 1];
						conex[j + 1] = conex[j];
						conex[j] = structureConexao;
					}
				}
			}
		}
	}

	private void xDjHhDYHra(object P_0, EventArgs P_1)
	{
		if (dgPaineis.SelectedRows.Count == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		formataDGCircuitos();
		checked
		{
			int num = dgPaineis.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!dgPaineis.Rows[i].Selected)
				{
					continue;
				}
				DeclaracoesEntidades.StructureConexao[] pWaHwrCoDC = PWaHwrCoDC;
				for (int j = 0; j < pWaHwrCoDC.Length; j++)
				{
					DeclaracoesEntidades.StructureConexao structureConexao = pWaHwrCoDC[j];
					if (Operators.ConditionalCompareObjectEqual(structureConexao.Painel, dgPaineis.Rows[i].Cells[0].Value, TextCompare: true) && !list.Contains(structureConexao.Potencial))
					{
						string text = BuscaPaginasDoCircuito(structureConexao.Potencial);
						dgCircuitos.Rows.Add(structureConexao.Painel, DeclaracoesGeral.dicPainel[structureConexao.Painel], structureConexao.Potencial, structureConexao.Nome, text, "");
						list.Add(structureConexao.Potencial);
					}
				}
			}
			AtualizaDGCircuitos();
		}
	}

	private void DpwHoaxGC4(object P_0, EventArgs P_1)
	{
		if (dgCircuitos.SelectedRows.Count == 0)
		{
			return;
		}
		dgPaginas.Rows.Clear();
		dgPaginas.Columns.Clear();
		checked
		{
			if (dgCircuitos.SelectedRows.Count == 1)
			{
				formataDGPaginas();
				List<string> list = new List<string>();
				int num = dgCircuitos.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!dgCircuitos.Rows[i].Selected)
					{
						continue;
					}
					DeclaracoesEntidades.StructureConexao[] pWaHwrCoDC = PWaHwrCoDC;
					for (int j = 0; j < pWaHwrCoDC.Length; j++)
					{
						DeclaracoesEntidades.StructureConexao structureConexao = pWaHwrCoDC[j];
						if (Operators.ConditionalCompareObjectEqual(structureConexao.Potencial, dgCircuitos.Rows[i].Cells[2].Value, TextCompare: true) && !list.Contains(structureConexao.Pagina))
						{
							xFuHxdmWVN = false;
							dgPaginas.Rows.Add(structureConexao.Pagina, structureConexao.Handle);
							list.Add(structureConexao.Pagina);
						}
					}
				}
				AtualizaDGPaginas();
				int num2 = dgPaginas.Rows.Count - 1;
				for (int k = 0; k <= num2; k++)
				{
					dgPaginas.Rows[k].Selected = false;
				}
			}
			xFuHxdmWVN = true;
		}
	}

	private void PHyHGBFJJ7(object P_0, EventArgs P_1)
	{
		if (dgPaginas.SelectedRows.Count == 0 || !xFuHxdmWVN)
		{
			return;
		}
		checked
		{
			int num = dgPaginas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgPaginas.Rows[i].Selected)
				{
					clsBlocos.MostraBloco(Conversions.ToString(dgPaginas.Rows[i].Cells[1].Value));
				}
			}
		}
	}

	private void zodHHBTkkP(object P_0, EventArgs P_1)
	{
		Relatorios_FiacaoEXCEL.ExportaNomesCircuitosEXCEL(dgCircuitos);
		btImportar.Enabled = true;
	}

	private void lRSHkrwoth(object P_0, EventArgs P_1)
	{
		DataGridView withEventsValue = dgCircuitos;
		bool flag = Relatorios_FiacaoEXCEL.ImportaNomesCircuitosEXCEL(ref withEventsValue, PWaHwrCoDC);
		dgCircuitos = withEventsValue;
		if (!flag)
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1950]), MsgBoxStyle.Information, "Eletron");
		}
		else
		{
			btEditar.Enabled = true;
		}
	}

	private void ivmHdfgw2D(object P_0, EventArgs P_1)
	{
		clsConexao.structureAUXDERIVACAO[] sTextoAux = new clsConexao.structureAUXDERIVACAO[1];
		clsConexao.LeTodosTextosAuxiliaresCircuito(ref sTextoAux);
		checked
		{
			int num = dgCircuitos.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				Conversions.ToString(dgCircuitos.Rows[i].Cells[1].Value);
				string right = Conversions.ToString(dgCircuitos.Rows[i].Cells[2].Value);
				string sNovoNome = Conversions.ToString(dgCircuitos.Rows[i].Cells[3].Value);
				if (!Operators.ConditionalCompareObjectEqual(dgCircuitos.Rows[i].Cells[5].Value, "E", TextCompare: true))
				{
					continue;
				}
				clsConexao.structureAUXDERIVACAO[] array = sTextoAux;
				for (int j = 0; j < array.Length; j++)
				{
					clsConexao.structureAUXDERIVACAO structureAUXDERIVACAO = array[j];
					if (Operators.CompareString(structureAUXDERIVACAO.Potencial, right, TextCompare: true) == 0)
					{
						clsConexao.EditaValorNomeCircuito(structureAUXDERIVACAO.sHandle, sNovoNome, structureAUXDERIVACAO.sTipo);
					}
				}
			}
		}
	}

	public string BuscaPaginasDoCircuito(int iPot)
	{
		List<string> list = new List<string>();
		string text = "";
		DeclaracoesEntidades.StructureConexao[] pWaHwrCoDC = PWaHwrCoDC;
		for (int i = 0; i < pWaHwrCoDC.Length; i = checked(i + 1))
		{
			DeclaracoesEntidades.StructureConexao structureConexao = pWaHwrCoDC[i];
			if (structureConexao.Potencial == iPot && !list.Contains(structureConexao.Pagina))
			{
				list.Add(structureConexao.Pagina);
			}
		}
		list.Sort();
		foreach (string item in list)
		{
			text = text + item.ToString() + "; ";
		}
		return text;
	}

	public void formataDGPaginas()
	{
		try
		{
			dgPaginas.Rows.Clear();
			dgPaginas.Columns.Clear();
			dgPaginas.Columns.Add("Página", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 772]));
			dgPaginas.Columns.Add("Handle", "");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGPaginas()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaginas)) ? ((float)(dgPaginas.Width - 5)) : ((float)(dgPaginas.Width - 22)));
				dgPaginas.Columns[0].Width = (int)Math.Round(num);
				dgPaginas.Columns[1].Width = 0;
				dgPaginas.Columns[0].Visible = true;
				dgPaginas.Columns[1].Visible = false;
				dgPaginas.Columns[0].ReadOnly = false;
				dgPaginas.Columns[1].ReadOnly = false;
				DataGridViewColumn dataGridViewColumn = dgPaginas.Columns[0];
				dgPaginas.Sort(dataGridViewColumn, ListSortDirection.Ascending);
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

	public void formataDGCircuitos()
	{
		try
		{
			dgCircuitos.Rows.Clear();
			dgCircuitos.Columns.Clear();
			dgCircuitos.Columns.Add("", "#");
			dgCircuitos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
			dgCircuitos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 428]));
			dgCircuitos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 686]));
			dgCircuitos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 772]));
			dgCircuitos.Columns.Add("", "EDITADO");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGCircuitos()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCircuitos)) ? ((float)(dgCircuitos.Width - 5)) : ((float)(dgCircuitos.Width - 22)));
				dgCircuitos.Columns[0].Width = 0;
				dgCircuitos.Columns[1].Width = 0;
				dgCircuitos.Columns[2].Width = 0;
				dgCircuitos.Columns[3].Width = (int)Math.Round(num);
				dgCircuitos.Columns[4].Width = 0;
				dgCircuitos.Columns[5].Width = 0;
				dgCircuitos.Columns[0].Visible = false;
				dgCircuitos.Columns[1].Visible = false;
				dgCircuitos.Columns[2].Visible = false;
				dgCircuitos.Columns[3].Visible = true;
				dgCircuitos.Columns[4].Visible = false;
				dgCircuitos.Columns[5].Visible = false;
				dgCircuitos.Columns[0].ReadOnly = false;
				dgCircuitos.Columns[1].ReadOnly = false;
				dgCircuitos.Columns[2].ReadOnly = false;
				dgCircuitos.Columns[3].ReadOnly = false;
				dgCircuitos.Columns[4].ReadOnly = false;
				dgCircuitos.Columns[5].ReadOnly = false;
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

	public void formataDGPaineis()
	{
		try
		{
			dgPaineis.Rows.Clear();
			dgPaineis.Columns.Clear();
			dgPaineis.Columns.Add("", "#");
			dgPaineis.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGPaineis()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineis)) ? ((float)(dgPaineis.Width - 5)) : ((float)(dgPaineis.Width - 22)));
				dgPaineis.Columns[0].Width = 0;
				dgPaineis.Columns[1].Width = (int)Math.Round(num);
				dgPaineis.Columns[0].Visible = false;
				dgPaineis.Columns[1].Visible = true;
				dgPaineis.Columns[0].ReadOnly = false;
				dgPaineis.Columns[1].ReadOnly = false;
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
}
