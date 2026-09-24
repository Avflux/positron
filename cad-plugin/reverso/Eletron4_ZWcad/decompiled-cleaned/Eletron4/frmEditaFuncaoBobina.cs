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
public class frmEditaFuncaoBobina : Form
{
	private IContainer KWOG4av1xB;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip zgaGCaJN2e;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGDispositivos")]
	private DataGridView Pk3GY3Yg5H;

	[CompilerGenerated]
	[AccessedThroughProperty("DGContatos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView vrYGrP2b9A;

	[CompilerGenerated]
	[AccessedThroughProperty("btImportarPN")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button actG9Bqm16;

	[AccessedThroughProperty("btExportarPN")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button RNaGzJtsr0;

	[AccessedThroughProperty("DGPaineis")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView JJNHW6rkoi;

	private bool GpBHpIKqxo;

	private ClsFuncoesDispositivo.StructureFuncaoDisp[] hNHHTY0ho9;

	internal virtual DataGridView DGDispositivos
	{
		[CompilerGenerated]
		get
		{
			return Pk3GY3Yg5H;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oJuGUYUBK6;
			MouseEventHandler value3 = HWdGygaccv;
			KeyEventHandler value4 = rNRGggH6Vo;
			KeyEventHandler value5 = gm2GAphdVv;
			DataGridViewCellEventHandler value6 = rwZGBNnDoQ;
			DataGridView dataGridView = Pk3GY3Yg5H;
			if (dataGridView != null)
			{
				dataGridView.SizeChanged -= value2;
				dataGridView.MouseClick -= value3;
				dataGridView.KeyUp -= value4;
				dataGridView.KeyDown -= value5;
				dataGridView.CellDoubleClick -= value6;
			}
			Pk3GY3Yg5H = value;
			dataGridView = Pk3GY3Yg5H;
			if (dataGridView != null)
			{
				dataGridView.SizeChanged += value2;
				dataGridView.MouseClick += value3;
				dataGridView.KeyUp += value4;
				dataGridView.KeyDown += value5;
				dataGridView.CellDoubleClick += value6;
			}
		}
	}

	internal virtual DataGridView DGContatos
	{
		[CompilerGenerated]
		get
		{
			return vrYGrP2b9A;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vrYGrP2b9A = value;
		}
	}

	internal virtual Button btImportarPN
	{
		[CompilerGenerated]
		get
		{
			return actG9Bqm16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fN9GujWrVs;
			Button button = actG9Bqm16;
			if (button != null)
			{
				button.Click -= value2;
			}
			actG9Bqm16 = value;
			button = actG9Bqm16;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportarPN
	{
		[CompilerGenerated]
		get
		{
			return RNaGzJtsr0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ccZGVPiJP1;
			Button button = RNaGzJtsr0;
			if (button != null)
			{
				button.Click -= value2;
			}
			RNaGzJtsr0 = value;
			button = RNaGzJtsr0;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView DGPaineis
	{
		[CompilerGenerated]
		get
		{
			return JJNHW6rkoi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = bEsGZtPnOW;
			KeyEventHandler value3 = dLWGiovpOh;
			MouseEventHandler value4 = RxHGSBTxXi;
			DataGridView dataGridView = JJNHW6rkoi;
			if (dataGridView != null)
			{
				dataGridView.KeyDown -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.MouseUp -= value4;
			}
			JJNHW6rkoi = value;
			dataGridView = JJNHW6rkoi;
			if (dataGridView != null)
			{
				dataGridView.KeyDown += value2;
				dataGridView.KeyUp += value3;
				dataGridView.MouseUp += value4;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && KWOG4av1xB != null)
			{
				KWOG4av1xB.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ryvGXRqrCN()
	{
		KWOG4av1xB = new Container();
		FDqpBiUmZij(new ToolTip(KWOG4av1xB));
		DGDispositivos = new DataGridView();
		DGContatos = new DataGridView();
		btImportarPN = new Button();
		btExportarPN = new Button();
		DGPaineis = new DataGridView();
		((ISupportInitialize)DGDispositivos).BeginInit();
		((ISupportInitialize)DGContatos).BeginInit();
		((ISupportInitialize)DGPaineis).BeginInit();
		SuspendLayout();
		DGDispositivos.AllowUserToAddRows = false;
		DGDispositivos.AllowUserToDeleteRows = false;
		DGDispositivos.AllowUserToOrderColumns = true;
		DGDispositivos.AllowUserToResizeRows = false;
		DGDispositivos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGDispositivos.BorderStyle = BorderStyle.Fixed3D;
		DGDispositivos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGDispositivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGDispositivos.Location = new Point(12, 246);
		DGDispositivos.MultiSelect = false;
		DGDispositivos.Name = "DGDispositivos";
		DGDispositivos.ReadOnly = true;
		DGDispositivos.RowHeadersVisible = false;
		DGDispositivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGDispositivos.Size = new Size(204, 113);
		DGDispositivos.TabIndex = 192;
		DGContatos.AllowUserToAddRows = false;
		DGContatos.AllowUserToDeleteRows = false;
		DGContatos.AllowUserToOrderColumns = true;
		DGContatos.AllowUserToResizeRows = false;
		DGContatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGContatos.BorderStyle = BorderStyle.Fixed3D;
		DGContatos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGContatos.Location = new Point(222, 12);
		DGContatos.MultiSelect = false;
		DGContatos.Name = "DGContatos";
		DGContatos.ReadOnly = true;
		DGContatos.RowHeadersVisible = false;
		DGContatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGContatos.Size = new Size(203, 301);
		DGContatos.TabIndex = 193;
		btImportarPN.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btImportarPN.FlatStyle = FlatStyle.Flat;
		btImportarPN.ForeColor = SystemColors.Control;
		btImportarPN.Image = Resources.ImportaExcel_20;
		btImportarPN.Location = new Point(392, 319);
		btImportarPN.Name = "btImportarPN";
		btImportarPN.Size = new Size(30, 40);
		btImportarPN.TabIndex = 187;
		btImportarPN.UseVisualStyleBackColor = true;
		btExportarPN.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportarPN.FlatStyle = FlatStyle.Flat;
		btExportarPN.ForeColor = SystemColors.Control;
		btExportarPN.Image = Resources.ExportaExcel_20;
		btExportarPN.Location = new Point(361, 319);
		btExportarPN.Name = "btExportarPN";
		btExportarPN.Size = new Size(30, 40);
		btExportarPN.TabIndex = 188;
		btExportarPN.UseVisualStyleBackColor = true;
		DGPaineis.AllowUserToAddRows = false;
		DGPaineis.AllowUserToDeleteRows = false;
		DGPaineis.AllowUserToOrderColumns = true;
		DGPaineis.AllowUserToResizeRows = false;
		DGPaineis.BorderStyle = BorderStyle.Fixed3D;
		DGPaineis.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGPaineis.Location = new Point(12, 12);
		DGPaineis.MultiSelect = false;
		DGPaineis.Name = "DGPaineis";
		DGPaineis.ReadOnly = true;
		DGPaineis.RowHeadersVisible = false;
		DGPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGPaineis.Size = new Size(204, 228);
		DGPaineis.TabIndex = 195;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(434, 371);
		Controls.Add(DGPaineis);
		Controls.Add(DGContatos);
		Controls.Add(DGDispositivos);
		Controls.Add(btExportarPN);
		Controls.Add(btImportarPN);
		MaximumSize = new Size(450, 1380);
		MinimumSize = new Size(450, 380);
		Name = "frmEditaFuncaoBobina";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frm Edita Função das Bobinas";
		((ISupportInitialize)DGDispositivos).EndInit();
		((ISupportInitialize)DGContatos).EndInit();
		((ISupportInitialize)DGPaineis).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return zgaGCaJN2e;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		zgaGCaJN2e = WithEventsValue;
	}

	public frmEditaFuncaoBobina()
	{
		Resize += lRIGsYp6oH;
		GpBHpIKqxo = false;
		hNHHTY0ho9 = null;
		checked
		{
			try
			{
				if (!clsAuxiliar.BancoValido())
				{
					return;
				}
				cDadosAccess.carregaDadosDWG();
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					ryvGXRqrCN();
					ClsFuncoesDispositivo.verificaDispositivos();
					bool flag = true;
					if (Geral.ExisteForm("frmEditaFuncaoBobina"))
					{
						return;
					}
					Application.ShowModelessDialog((Form)this);
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1676]);
					List<string> list = new List<string>();
					if (flag)
					{
						cDadosAccess.carregaPainelDicionario();
						DataGridView dg = DGPaineis;
						ClsFuncoesDispositivo.CarregaOsPaineisEmUsoPelosContatosFuncaoDG(ref dg);
						DGPaineis = dg;
						dg = DGPaineis;
						AtualizaDGPainel(ref dg);
						DGPaineis = dg;
						if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
						{
							Left = 0;
						}
						if (list.Count > 0)
						{
							string text = "IEC";
							if (DeclaracoesGeral.Conf.Norma == 1)
							{
								text = "ANSI";
							}
							string right = DeclaracoesGeral.Conf.DirSimbologiaEletrica + "Contatos\\" + text;
							string text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1371], list.Count), DeclaracoesGeral.mMensagem[1, 1372]), right));
							if (list.Count > 1)
							{
								text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1371], list.Count), DeclaracoesGeral.mMensagem[1, 1373]), right));
							}
							text2 += "\r\n\r\n";
							int num = list.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								if (i > 0)
								{
									text2 += ", \r\n";
								}
								text2 += list[i];
							}
							Interaction.MsgBox(text2, MsgBoxStyle.Information);
						}
					}
					if (!flag)
					{
						Close();
					}
					GpBHpIKqxo = true;
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
	}

	private void oJuGUYUBK6(object P_0, EventArgs P_1)
	{
		AtualizaDGFuncaoContatos();
	}

	private void HWdGygaccv(object P_0, MouseEventArgs P_1)
	{
		AtualizaDGFuncaoContatos();
	}

	private void rNRGggH6Vo(object P_0, KeyEventArgs P_1)
	{
		AtualizaDGFuncaoContatos();
	}

	private void gm2GAphdVv(object P_0, KeyEventArgs P_1)
	{
		AtualizaDGFuncaoContatos();
	}

	public void AtualizaDGFuncaoContatos()
	{
		checked
		{
			if (DGDispositivos.Rows.Count > 0)
			{
				DataGridView dGDisp = DGDispositivos;
				DataGridView dgContatos = DGContatos;
				ClsFuncoesDispositivo.CarregaOsFuncaoContatosAuxiliares(dGDisp, ref dgContatos, Conversions.ToString(DGDispositivos.SelectedRows[0].Cells[0].Value));
				DGContatos = dgContatos;
				string left = "";
				int num = DGContatos.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					left = ((i == DGContatos.Rows.Count) ? Conversions.ToString(Operators.AddObject(left, Operators.ConcatenateObject(DGContatos.Rows[i].Cells[2].Value, ";"))) : Conversions.ToString(Operators.AddObject(left, Operators.ConcatenateObject(Operators.ConcatenateObject(DGContatos.Rows[i].Cells[2].Value, ";"), "\r\n"))));
				}
			}
		}
	}

	public static void MarcaContatoAuxiliarUsado(DataGridView dgContatos)
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		checked
		{
			if (dgContatos.SelectedRows.Count > 0)
			{
				int num = 0;
				do
				{
					dgContatos.SelectedRows[0].Cells[num].Style = dataGridViewCellStyle;
					num++;
				}
				while (num <= 7);
				dgContatos.SelectedRows[0].Cells[7].Value = DeclaracoesGeral.ativo.Pagina;
				dgContatos.SelectedRows[0].Selected = false;
			}
			int num2 = dgContatos.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgContatos.Rows[num3].Cells[0].Style.BackColor != Color.LightCoral)
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			dgContatos.Rows[num3].Selected = true;
			if (num3 >= 3)
			{
				dgContatos.FirstDisplayedScrollingRowIndex = num3 - 2;
			}
		}
	}

	public static void FormataDGDisp(ref DataGridView dg)
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("PN", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1085]));
		dg.Columns.Add("Indice", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 999]));
		dg.Columns.Add("Dispositivo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1000]));
		dg.Columns.Add("Nome1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1001]));
		dg.Columns.Add("Nome2", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1002]));
		dg.Columns.Add("Nome3", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1003]));
		dg.Columns.Add("Handle", "Handle");
		dg.ColumnHeadersVisible = true;
		dg.MultiSelect = false;
	}

	public static void AtualizaColunasDGContatosDisp(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[2].Visible = true;
				dg.Columns[3].Visible = false;
				dg.Columns[4].Visible = false;
				dg.Columns[5].Visible = false;
				dg.Columns[6].Visible = false;
				dg.Columns[0].Width = (int)Math.Round(num * 0.5);
				dg.Columns[1].Width = 0;
				dg.Columns[2].Width = (int)Math.Round(num * 0.5);
				dg.Columns[3].Width = 0;
				dg.Columns[4].Width = 0;
				dg.Columns[5].Width = 0;
				dg.Columns[6].Width = 0;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
				dg.Columns[4].ReadOnly = false;
				dg.Columns[5].ReadOnly = false;
				dg.Columns[6].ReadOnly = false;
			}
		}
	}

	public static void AtualizaDGPainel(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Visible = false;
				dg.Columns[1].Visible = true;
				dg.Columns[0].Width = 0;
				dg.Columns[1].Width = (int)Math.Round(a);
				dg.MultiSelect = true;
			}
		}
	}

	public static void AtualizaColunasDGBlocosAuxiliares(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				dg.ColumnHeadersVisible = true;
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.ColumnHeadersVisible = false;
				dg.Columns[0].Width = (int)Math.Round(a);
				dg.Columns[1].Width = 0;
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.MultiSelect = false;
			}
		}
	}

	private void lRIGsYp6oH(object P_0, EventArgs P_1)
	{
		DataGridView dg = DGDispositivos;
		AtualizaColunasDGContatosDisp(ref dg);
		DGDispositivos = dg;
		dg = DGContatos;
		ClsFuncoesDispositivo.AtualizaColunasDGContatosAuxiliaresMODELO(ref dg);
		DGContatos = dg;
	}

	private void rwZGBNnDoQ(object P_0, DataGridViewCellEventArgs P_1)
	{
		string text = Conversions.ToString(DGDispositivos.SelectedRows[0].Cells[5].Value);
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			clsBlocos.MostraBloco(text);
		}
	}

	private void ccZGVPiJP1(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
		{
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
		excContatos.ExportaFuncoesContatos(ref oSheet, ref hNHHTY0ho9);
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
	}

	private void fN9GujWrVs(object P_0, EventArgs P_1)
	{
		if (Information.UBound(hNHHTY0ho9) <= 0)
		{
			return;
		}
		ClsFuncoesDispositivo.ImportaPN(ref hNHHTY0ho9);
		ClsFuncoesDispositivo.AtualizaFuncaoDisp(ref hNHHTY0ho9);
		vRuGEEHE90();
		checked
		{
			int num = DGPaineis.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGPaineis.Rows[i].Selected)
				{
					ClsFuncoesDispositivo.AtualizaValoresDosModelos(Conversions.ToInteger(DGPaineis.Rows[i].Cells[0].Value));
				}
			}
		}
	}

	private void vRuGEEHE90()
	{
		if (!GpBHpIKqxo)
		{
			return;
		}
		List<int> list = new List<int>();
		checked
		{
			int num = DGPaineis.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGPaineis.Rows[i].Selected)
				{
					list.Add(Conversions.ToInteger(DGPaineis.Rows[i].Cells[0].Value));
				}
			}
			DataGridView dg = DGDispositivos;
			FormataDGDisp(ref dg);
			DGDispositivos = dg;
			dg = DGDispositivos;
			ClsFuncoesDispositivo.CarregaContatosAuxiliaresInseridosFuncaoPaineis(ref dg, ref hNHHTY0ho9, list);
			DGDispositivos = dg;
			dg = DGDispositivos;
			AtualizaColunasDGContatosDisp(ref dg);
			DGDispositivos = dg;
			if (DGDispositivos.Rows.Count > 0)
			{
				DataGridView dGDisp = DGDispositivos;
				dg = DGContatos;
				ClsFuncoesDispositivo.CarregaOsFuncaoContatosAuxiliaresPaineis(dGDisp, ref dg, list);
				DGContatos = dg;
			}
			AtualizaDGFuncaoContatos();
		}
	}

	private void bEsGZtPnOW(object P_0, KeyEventArgs P_1)
	{
	}

	private void dLWGiovpOh(object P_0, KeyEventArgs P_1)
	{
		vRuGEEHE90();
	}

	private void RxHGSBTxXi(object P_0, MouseEventArgs P_1)
	{
		vRuGEEHE90();
	}
}
