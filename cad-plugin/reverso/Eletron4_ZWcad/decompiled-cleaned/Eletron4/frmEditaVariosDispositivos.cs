using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmEditaVariosDispositivos : Form
{
	private IContainer NOrH9mdOQT;

	[AccessedThroughProperty("dgDispositivos")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView FwMHzV0tpT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgPaineis")]
	private DataGridView lXPkWq4hYl;

	[CompilerGenerated]
	[AccessedThroughProperty("btEditar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button U67kpFoFYk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportar")]
	private Button qxrkTDbwjp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btImportar")]
	private Button uaCkJ3a4te;

	private clsDispositivo.mBlocosPrincipal[] F8XkhM1Z3K;

	private bool Ls5kooaQuC;

	private int R4mkGAovlh;

	internal virtual DataGridView dgDispositivos
	{
		[CompilerGenerated]
		get
		{
			return FwMHzV0tpT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = FbwHViwmhV;
			MouseEventHandler value3 = tbUHujgXSX;
			DataGridView dataGridView = FwMHzV0tpT;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			FwMHzV0tpT = value;
			dataGridView = FwMHzV0tpT;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual DataGridView dgPaineis
	{
		[CompilerGenerated]
		get
		{
			return lXPkWq4hYl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = BrKHEe6RmU;
			MouseEventHandler value3 = KGuHZ3JcPG;
			DataGridView dataGridView = lXPkWq4hYl;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			lXPkWq4hYl = value;
			dataGridView = lXPkWq4hYl;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual Button btEditar
	{
		[CompilerGenerated]
		get
		{
			return U67kpFoFYk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = u4nHCrHNAY;
			Button button = U67kpFoFYk;
			if (button != null)
			{
				button.Click -= value2;
			}
			U67kpFoFYk = value;
			button = U67kpFoFYk;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportar
	{
		[CompilerGenerated]
		get
		{
			return qxrkTDbwjp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mH3HSls5f9;
			Button button = qxrkTDbwjp;
			if (button != null)
			{
				button.Click -= value2;
			}
			qxrkTDbwjp = value;
			button = qxrkTDbwjp;
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
			return uaCkJ3a4te;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ew4H44EcAL;
			Button button = uaCkJ3a4te;
			if (button != null)
			{
				button.Click -= value2;
			}
			uaCkJ3a4te = value;
			button = uaCkJ3a4te;
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
			if (disposing && NOrH9mdOQT != null)
			{
				NOrH9mdOQT.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Xg8Hsh8Vrs()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgDispositivos = new DataGridView();
		dgPaineis = new DataGridView();
		btEditar = new Button();
		btExportar = new Button();
		btImportar = new Button();
		((ISupportInitialize)dgDispositivos).BeginInit();
		((ISupportInitialize)dgPaineis).BeginInit();
		SuspendLayout();
		dgDispositivos.AllowUserToAddRows = false;
		dgDispositivos.AllowUserToDeleteRows = false;
		dgDispositivos.AllowUserToOrderColumns = true;
		dgDispositivos.AllowUserToResizeRows = false;
		dgDispositivos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgDispositivos.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgDispositivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgDispositivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDispositivos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDispositivos.Location = new Point(203, 12);
		dgDispositivos.MultiSelect = false;
		dgDispositivos.Name = "dgDispositivos";
		dgDispositivos.ReadOnly = true;
		dgDispositivos.RowHeadersVisible = false;
		dgDispositivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDispositivos.Size = new Size(322, 292);
		dgDispositivos.TabIndex = 9;
		dgPaineis.AllowUserToAddRows = false;
		dgPaineis.AllowUserToDeleteRows = false;
		dgPaineis.AllowUserToOrderColumns = true;
		dgPaineis.AllowUserToResizeRows = false;
		dgPaineis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPaineis.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgPaineis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineis.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaineis.Location = new Point(8, 12);
		dgPaineis.MultiSelect = false;
		dgPaineis.Name = "dgPaineis";
		dgPaineis.ReadOnly = true;
		dgPaineis.RowHeadersVisible = false;
		dgPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineis.Size = new Size(189, 337);
		dgPaineis.TabIndex = 181;
		btEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btEditar.Enabled = false;
		btEditar.FlatStyle = FlatStyle.Flat;
		btEditar.ForeColor = SystemColors.Control;
		btEditar.Image = Resources.Editar;
		btEditar.Location = new Point(482, 309);
		btEditar.Name = "btEditar";
		btEditar.Size = new Size(40, 40);
		btEditar.TabIndex = 187;
		btEditar.UseVisualStyleBackColor = true;
		btExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportar.FlatStyle = FlatStyle.Flat;
		btExportar.ForeColor = SystemColors.Control;
		btExportar.Image = Resources.ExportaExcel_20;
		btExportar.Location = new Point(395, 309);
		btExportar.Name = "btExportar";
		btExportar.Size = new Size(30, 40);
		btExportar.TabIndex = 186;
		btExportar.UseVisualStyleBackColor = true;
		btImportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.ImportaExcel_20;
		btImportar.Location = new Point(436, 309);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(30, 40);
		btImportar.TabIndex = 185;
		btImportar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(534, 361);
		Controls.Add(btEditar);
		Controls.Add(btExportar);
		Controls.Add(btImportar);
		Controls.Add(dgPaineis);
		Controls.Add(dgDispositivos);
		MinimumSize = new Size(550, 400);
		Name = "frmEditaVariosDispositivos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Editar Disp e Masc";
		((ISupportInitialize)dgDispositivos).EndInit();
		((ISupportInitialize)dgPaineis).EndInit();
		ResumeLayout(performLayout: false);
	}

	public frmEditaVariosDispositivos()
	{
		Resize += PbrHiDp11Q;
		Ls5kooaQuC = false;
		R4mkGAovlh = 0;
		if (!Geral.ExisteForm("frmEditaVariosDispositivos"))
		{
			Xg8Hsh8Vrs();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1602]);
			BVBHBepM5K();
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	private void BVBHBepM5K()
	{
		clsDispositivo.pesquisaDispositivosPeMnoDWG(ref F8XkhM1Z3K);
		formataDGPaineis();
		List<int> list = new List<int>();
		int num = Information.UBound(F8XkhM1Z3K);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!list.Contains(F8XkhM1Z3K[i].iPainel))
			{
				dgPaineis.Rows.Add(F8XkhM1Z3K[i].iPainel, F8XkhM1Z3K[i].sPainel);
				list.Add(F8XkhM1Z3K[i].iPainel);
				Ls5kooaQuC = true;
			}
		}
		AtualizaDGPaineis();
		if (Ls5kooaQuC)
		{
			DataGridView withEventsValue = dgPaineis;
			ynGHYafeEu(ref withEventsValue);
			dgPaineis = withEventsValue;
			dgPaineis.Rows[0].Selected = true;
		}
		CarregaDispPaineis();
	}

	public void CarregaTodosOsBlocosNoDG(ref DataGridView dg, structureCadernoMigra[] VeiasCaderno, string sNome, string sFormacao)
	{
		formataDGBlocos();
		int num = Information.UBound(VeiasCaderno);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			dg.Rows.Add(VeiasCaderno[i].sTag0, "", "", VeiasCaderno[i].iPn1, VeiasCaderno[i].iPn2);
		}
		AtualizaDGBlocos();
	}

	public void formataDGPaineis()
	{
		try
		{
			dgPaineis.Rows.Clear();
			dgPaineis.Columns.Clear();
			dgPaineis.Columns.Add("PN", "#");
			dgPaineis.Columns.Add("PAINEL", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
			AtualizaDGBlocos();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGPaineis()
	{
		checked
		{
			if (dgPaineis.Columns.Count != 0)
			{
				double num = dgPaineis.Width - 21;
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineis))
				{
					num = dgPaineis.Width - 4;
				}
				dgPaineis.Columns[0].Width = 30;
				dgPaineis.Columns[0].Visible = true;
				dgPaineis.Columns[1].Width = (int)Math.Round(num - 30.0);
				dgPaineis.Columns[1].Visible = true;
				dgPaineis.MultiSelect = false;
			}
		}
	}

	public void formataDGBlocos()
	{
		try
		{
			dgDispositivos.Rows.Clear();
			dgDispositivos.Columns.Clear();
			dgDispositivos.Columns.Add("Nome_1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 627]));
			dgDispositivos.Columns.Add("Nome_2", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 628]));
			dgDispositivos.Columns.Add("Alternativo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 629]));
			dgDispositivos.Columns.Add("PN", "PN");
			dgDispositivos.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 660]));
			dgDispositivos.Columns.Add("Handle", "Handle");
			dgDispositivos.Columns.Add("BEDITADO", "BEDITADO");
			dgDispositivos.Columns.Add("Nome_1", "Nome_1");
			dgDispositivos.Columns.Add("Nome_2", "Nome_2");
			dgDispositivos.Columns.Add("Alternativo_", "Alternativo_");
			AtualizaDGBlocos();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGBlocos()
	{
		checked
		{
			if (dgDispositivos.Columns.Count != 0)
			{
				double num = dgDispositivos.Width - 21;
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDispositivos))
				{
					num = dgDispositivos.Width - 4;
				}
				double num2 = 4.0;
				dgDispositivos.Columns[0].Width = (int)Math.Round(num / num2);
				dgDispositivos.Columns[0].Visible = true;
				dgDispositivos.Columns[1].Width = (int)Math.Round(num / num2);
				dgDispositivos.Columns[1].Visible = true;
				dgDispositivos.Columns[2].Width = (int)Math.Round(num / num2);
				dgDispositivos.Columns[2].Visible = true;
				dgDispositivos.Columns[3].Width = 0;
				dgDispositivos.Columns[3].Visible = false;
				dgDispositivos.Columns[4].Width = (int)Math.Round(num / num2);
				dgDispositivos.Columns[4].Visible = true;
				dgDispositivos.Columns[5].Width = 0;
				dgDispositivos.Columns[5].Visible = false;
				dgDispositivos.Columns[6].Width = 0;
				dgDispositivos.Columns[6].Visible = false;
				dgDispositivos.Columns[7].Width = 0;
				dgDispositivos.Columns[7].Visible = false;
				dgDispositivos.Columns[8].Width = 0;
				dgDispositivos.Columns[8].Visible = false;
				dgDispositivos.Columns[9].Width = 0;
				dgDispositivos.Columns[9].Visible = false;
				dgDispositivos.MultiSelect = true;
			}
		}
	}

	private void FbwHViwmhV(object P_0, KeyEventArgs P_1)
	{
		MostraBloco();
	}

	private void tbUHujgXSX(object P_0, MouseEventArgs P_1)
	{
		MostraBloco();
	}

	public void MostraBloco()
	{
		if (dgDispositivos.Columns.Count != 0)
		{
			string sHandle = Conversions.ToString(dgDispositivos.SelectedRows[0].Cells[5].Value);
			Correcao.mostraBloco(sHandle);
		}
	}

	private void BrKHEe6RmU(object P_0, KeyEventArgs P_1)
	{
		if (Ls5kooaQuC)
		{
			CarregaDispPaineis();
		}
	}

	private void KGuHZ3JcPG(object P_0, MouseEventArgs P_1)
	{
		if (Ls5kooaQuC)
		{
			CarregaDispPaineis();
		}
	}

	public void CarregaDispPaineis()
	{
		if (dgPaineis.Columns.Count == 0 || dgPaineis.SelectedRows.Count == 0)
		{
			return;
		}
		R4mkGAovlh = Conversions.ToInteger(dgPaineis.SelectedRows[0].Cells[0].Value);
		formataDGBlocos();
		bool flag = false;
		int num = Information.UBound(F8XkhM1Z3K);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (F8XkhM1Z3K[i].iPainel == R4mkGAovlh && !F8XkhM1Z3K[i].bComplementar)
			{
				dgDispositivos.Rows.Add(F8XkhM1Z3K[i].sNome1, F8XkhM1Z3K[i].sNome2, F8XkhM1Z3K[i].sAlternativo, F8XkhM1Z3K[i].iPainel, F8XkhM1Z3K[i].sTipo, F8XkhM1Z3K[i].sHandle, flag, F8XkhM1Z3K[i].sNome1, F8XkhM1Z3K[i].sNome2, F8XkhM1Z3K[i].sAlternativo);
			}
		}
		DataGridView withEventsValue = dgDispositivos;
		PEuHrq4lvt(ref withEventsValue);
		dgDispositivos = withEventsValue;
		AtualizaDGBlocos();
	}

	private void PbrHiDp11Q(object P_0, EventArgs P_1)
	{
		if (dgPaineis.Columns.Count != 0)
		{
			AtualizaDGPaineis();
			AtualizaDGBlocos();
		}
	}

	private void mH3HSls5f9(object P_0, EventArgs P_1)
	{
		bloquiarBtoes(bBloqueia: true);
		if (dgDispositivos.RowCount > 0)
		{
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Workbook oBook = null;
			Worksheet oSheet = null;
			ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, Conversions.ToString(dgPaineis.SelectedRows[0].Cells[1].Value));
			if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
			{
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				DataGridView dg = dgDispositivos;
				excDispositivos.ExportaDispositivosParaOExcel(ref oSheet, ref dg);
				dgDispositivos = dg;
				_ = "A2:C" + Conversions.ToString(ExcFuncoesExcel.BuscaIndiceMaximoUsado(ref oSheet, "A"));
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
		}
		bloquiarBtoes(bBloqueia: false);
	}

	private void ew4H44EcAL(object P_0, EventArgs P_1)
	{
		bloquiarBtoes(bBloqueia: true);
		if (Ls5kooaQuC)
		{
			CarregaDispPaineis();
		}
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		checked
		{
			if (ExcFuncoesExcel.VerificaExcelAtivoImportar(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false))
			{
				DataGridView dg = dgDispositivos;
				excDispositivos.ExisteNomesIguais(ref oSheet, ref dg);
				dgDispositivos = dg;
				int num = dgDispositivos.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDispositivos.Rows[i].Cells[6].Value, true, TextCompare: true))
					{
						btEditar.Enabled = true;
						break;
					}
				}
			}
			bloquiarBtoes(bBloqueia: false);
		}
	}

	private void u4nHCrHNAY(object P_0, EventArgs P_1)
	{
		bloquiarBtoes(bBloqueia: true);
		clsDispositivo.mBlocosPrincipal[] array = new clsDispositivo.mBlocosPrincipal[1];
		checked
		{
			int num = dgDispositivos.RowCount - 1;
			int num3 = default;
			for (int i = 0; i <= num; i++)
			{
				if (!Operators.ConditionalCompareObjectEqual(dgDispositivos.Rows[i].Cells[6].Value, true, TextCompare: true))
				{
					continue;
				}
				int num2 = Information.UBound(F8XkhM1Z3K);
				for (int j = 1; j <= num2; j++)
				{
					if (R4mkGAovlh != F8XkhM1Z3K[j].iPainel)
					{
						continue;
					}
					string text = clsTextos.TiraNothing(Conversions.ToString(dgDispositivos.Rows[i].Cells[7].Value));
					if (Operators.CompareString(text, F8XkhM1Z3K[j].sNome1, TextCompare: true) != 0)
					{
						continue;
					}
					string text2 = clsTextos.TiraNothing(Conversions.ToString(dgDispositivos.Rows[i].Cells[8].Value));
					if (Operators.CompareString(text2, F8XkhM1Z3K[j].sNome2, TextCompare: true) != 0)
					{
						continue;
					}
					string left = clsTextos.TiraNothing(Conversions.ToString(dgDispositivos.Rows[i].Cells[9].Value));
					if (Operators.CompareString(left, F8XkhM1Z3K[j].sAlternativo, TextCompare: true) == 0)
					{
						string text3 = clsTextos.TiraNothing(Conversions.ToString(dgDispositivos.Rows[i].Cells[0].Value));
						string text4 = clsTextos.TiraNothing(Conversions.ToString(dgDispositivos.Rows[i].Cells[1].Value));
						string text5 = clsTextos.TiraNothing(Conversions.ToString(dgDispositivos.Rows[i].Cells[2].Value));
						num3++;
						array = (clsDispositivo.mBlocosPrincipal[])Utils.CopyArray(array, new clsDispositivo.mBlocosPrincipal[num3 + 1]);
						array[num3] = F8XkhM1Z3K[j];
						array[num3].sNome1 = text3;
						array[num3].sNome2 = text4;
						array[num3].sAlternativo = text5;
						string text6 = text3;
						if (Operators.CompareString(text4.Trim(), "", TextCompare: true) != 0)
						{
							text6 = text6 + "/" + text4;
						}
						string text7 = text;
						if (Operators.CompareString(text2.Trim(), "", TextCompare: true) != 0)
						{
							text7 = text7 + "/" + text2;
						}
						clsLayoutMec.EditaNomeAlternativoLayoutMec(R4mkGAovlh, text7, text6, text5);
						clsDispositivoTacito.editaLayoutRapido(Conversions.ToString(R4mkGAovlh), text7, text6, text5);
					}
				}
			}
			DeclaracoesGeral._uscPagina.Quantidade = num3;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num4 = num3;
			for (int k = 1; k <= num4; k++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				if (Operators.ConditionalCompareObjectEqual(array[k].sTipo.ToUpper(), NewLateBinding.LateGet(DeclaracoesGeral.mMensagem[1, 804], null, "ToUpper", new object[0], null, null, null), TextCompare: true))
				{
					clsDispositivo.editaUmBlocoDispositivoPrincipal(array[k].sHandle, array[k].iPainel, array[k].sNome1, array[k].sNome2, array[k].sAlternativo);
				}
				if (Operators.ConditionalCompareObjectEqual(array[k].sTipo.ToUpper(), NewLateBinding.LateGet(DeclaracoesGeral.mMensagem[1, 524], null, "ToUpper", new object[0], null, null, null), TextCompare: true))
				{
					clsMascara.EditaAsMascarasDoDispositivo(array[k].sHandle, array[k].iPainel, array[k].sNome1, array[k].sNome2, array[k].sAlternativo);
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
			int num5 = Conversions.ToInteger(dgPaineis.SelectedRows[0].Cells[0].Value);
			BVBHBepM5K();
			int num6 = dgPaineis.RowCount - 1;
			for (int l = 0; l <= num6; l++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgPaineis.Rows[l].Cells[0].Value, num5, TextCompare: true))
				{
					dgPaineis.Rows[l].Selected = true;
					CarregaDispPaineis();
					break;
				}
			}
			bloquiarBtoes(bBloqueia: false);
		}
	}

	private static void ynGHYafeEu(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = P_0.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = P_0.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					if (Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[1].Value, P_0.Rows[j + 1].Cells[1].Value, TextCompare: true))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num3].Value);
							P_0.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num3].Value);
							P_0.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 1);
					}
				}
			}
		}
	}

	private static void PEuHrq4lvt(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = P_0.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = P_0.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					if (Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[0].Value, P_0.Rows[j + 1].Cells[0].Value, TextCompare: true))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num3].Value);
							P_0.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num3].Value);
							P_0.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 9);
					}
					if (Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[0].Value, P_0.Rows[j + 1].Cells[0].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[1].Value, P_0.Rows[j + 1].Cells[1].Value, TextCompare: true))
					{
						int num4 = 0;
						do
						{
							object objectValue2 = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num4].Value);
							P_0.Rows[j].Cells[num4].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num4].Value);
							P_0.Rows[j + 1].Cells[num4].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							num4++;
						}
						while (num4 <= 9);
					}
					if (Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[0].Value, P_0.Rows[j + 1].Cells[0].Value, TextCompare: true) && Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[1].Value, P_0.Rows[j + 1].Cells[1].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[2].Value, P_0.Rows[j + 1].Cells[2].Value, TextCompare: true))
					{
						int num5 = 0;
						do
						{
							object objectValue3 = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num5].Value);
							P_0.Rows[j].Cells[num5].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num5].Value);
							P_0.Rows[j + 1].Cells[num5].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							num5++;
						}
						while (num5 <= 9);
					}
				}
			}
			int num6 = P_0.Rows.Count - 2;
			for (int k = 0; k <= num6; k++)
			{
				int num7 = P_0.Rows.Count - 2;
				for (int l = num7; l >= 0; l += -1)
				{
					if (Operators.ConditionalCompareObjectGreater(P_0.Rows[l].Cells[4].Value, P_0.Rows[l + 1].Cells[4].Value, TextCompare: true))
					{
						int num8 = 0;
						do
						{
							object objectValue4 = RuntimeHelpers.GetObjectValue(P_0.Rows[l].Cells[num8].Value);
							P_0.Rows[l].Cells[num8].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[l + 1].Cells[num8].Value);
							P_0.Rows[l + 1].Cells[num8].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							num8++;
						}
						while (num8 <= 9);
					}
				}
			}
		}
	}

	public void bloquiarBtoes(bool bBloqueia)
	{
		btExportar.Enabled = !bBloqueia;
		btImportar.Enabled = !bBloqueia;
		btEditar.Enabled = false;
		checked
		{
			int num = dgDispositivos.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDispositivos.Rows[num2].Cells[6].Value, true, TextCompare: true))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			btEditar.Enabled = true;
		}
	}
}
