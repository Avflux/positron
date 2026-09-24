using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmExportarImportarTextos : Form
{
	private IContainer Ic5rIrkR4g;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog anFr7ODr6X;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgPaginas")]
	private DataGridView b9NrqINTne;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip OsNraecpeR;

	[AccessedThroughProperty("BtEditar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button GBcr8vtpif;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox ptHrNsltMj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTExportaEX")]
	[CompilerGenerated]
	private Button DPUrFruNHt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTImportaEX")]
	private Button VT8rQjudig;

	[AccessedThroughProperty("btPesquisar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button BRTrPMS9FB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("CBAddNum")]
	private CheckBox Hr5rceSv4f;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbQuantidadeCaracter")]
	private Label Sl7rKGRjXZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbQuant")]
	private TextBox Fd5reckIDU;

	private clsTextos.mTitulos[] rv4r2PXaFG;

	private clsTextos.mTextos[] yX0r3JiYcn;

	internal virtual DataGridView dgPaginas
	{
		[CompilerGenerated]
		get
		{
			return b9NrqINTne;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			b9NrqINTne = value;
		}
	}

	internal virtual Button BtEditar
	{
		[CompilerGenerated]
		get
		{
			return GBcr8vtpif;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CiZrGDbthJ;
			Button button = GBcr8vtpif;
			if (button != null)
			{
				button.Click -= value2;
			}
			GBcr8vtpif = value;
			button = GBcr8vtpif;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return ptHrNsltMj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ptHrNsltMj = value;
		}
	}

	internal virtual Button BTExportaEX
	{
		[CompilerGenerated]
		get
		{
			return DPUrFruNHt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Y8arfmNLjh;
			Button button = DPUrFruNHt;
			if (button != null)
			{
				button.Click -= value2;
			}
			DPUrFruNHt = value;
			button = DPUrFruNHt;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTImportaEX
	{
		[CompilerGenerated]
		get
		{
			return VT8rQjudig;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hI6rDH7gou;
			Button button = VT8rQjudig;
			if (button != null)
			{
				button.Click -= value2;
			}
			VT8rQjudig = value;
			button = VT8rQjudig;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return BRTrPMS9FB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = va2rHu3uCB;
			Button button = BRTrPMS9FB;
			if (button != null)
			{
				button.Click -= value2;
			}
			BRTrPMS9FB = value;
			button = BRTrPMS9FB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CBAddNum
	{
		[CompilerGenerated]
		get
		{
			return Hr5rceSv4f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Hr5rceSv4f = value;
		}
	}

	internal virtual Label lbQuantidadeCaracter
	{
		[CompilerGenerated]
		get
		{
			return Sl7rKGRjXZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Sl7rKGRjXZ = value;
		}
	}

	internal virtual TextBox tbQuant
	{
		[CompilerGenerated]
		get
		{
			return Fd5reckIDU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = tBerM3FDG0;
			KeyPressEventHandler value3 = tgXrOkSsWX;
			TextBox textBox = Fd5reckIDU;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.KeyPress -= value3;
			}
			Fd5reckIDU = value;
			textBox = Fd5reckIDU;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.KeyPress += value3;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && Ic5rIrkR4g != null)
			{
				Ic5rIrkR4g.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void pqTroG4J8E()
	{
		Ic5rIrkR4g = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		dgPaginas = new DataGridView();
		FDqpBiUmZij(new ToolTip(Ic5rIrkR4g));
		BtEditar = new Button();
		GroupBox2 = new GroupBox();
		lbQuantidadeCaracter = new Label();
		tbQuant = new TextBox();
		CBAddNum = new CheckBox();
		BTExportaEX = new Button();
		BTImportaEX = new Button();
		btPesquisar = new Button();
		((ISupportInitialize)dgPaginas).BeginInit();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		dgPaginas.AllowUserToAddRows = false;
		dgPaginas.AllowUserToDeleteRows = false;
		dgPaginas.AllowUserToOrderColumns = true;
		dgPaginas.AllowUserToResizeRows = false;
		dgPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPaginas.BackgroundColor = SystemColors.ButtonHighlight;
		dgPaginas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgPaginas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaginas.Location = new Point(12, 12);
		dgPaginas.Name = "dgPaginas";
		dgPaginas.ReadOnly = true;
		dgPaginas.RowHeadersVisible = false;
		dgPaginas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaginas.Size = new Size(724, 309);
		dgPaginas.TabIndex = 117;
		BtEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BtEditar.FlatStyle = FlatStyle.Flat;
		BtEditar.ForeColor = SystemColors.Control;
		BtEditar.Image = Resources.Editar;
		BtEditar.Location = new Point(665, 16);
		BtEditar.Name = "BtEditar";
		BtEditar.Size = new Size(40, 40);
		BtEditar.TabIndex = 144;
		BtEditar.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox2.Controls.Add(lbQuantidadeCaracter);
		GroupBox2.Controls.Add(tbQuant);
		GroupBox2.Controls.Add(CBAddNum);
		GroupBox2.Controls.Add(BtEditar);
		GroupBox2.Controls.Add(BTExportaEX);
		GroupBox2.Controls.Add(BTImportaEX);
		GroupBox2.Controls.Add(btPesquisar);
		GroupBox2.Location = new Point(12, 327);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(724, 65);
		GroupBox2.TabIndex = 148;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		lbQuantidadeCaracter.AutoSize = true;
		lbQuantidadeCaracter.Location = new Point(270, 31);
		lbQuantidadeCaracter.Name = "lbQuantidadeCaracter";
		lbQuantidadeCaracter.Size = new Size(182, 13);
		lbQuantidadeCaracter.TabIndex = 153;
		lbQuantidadeCaracter.Text = "Inserir textos com mais de 1 caracter ";
		tbQuant.Location = new Point(232, 28);
		tbQuant.Name = "tbQuant";
		tbQuant.Size = new Size(32, 20);
		tbQuant.TabIndex = 152;
		CBAddNum.AutoSize = true;
		CBAddNum.Location = new Point(16, 30);
		CBAddNum.Name = "CBAddNum";
		CBAddNum.Size = new Size(147, 17);
		CBAddNum.TabIndex = 151;
		CBAddNum.Text = "Inserir Numeros na Busca";
		CBAddNum.UseVisualStyleBackColor = true;
		BTExportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTExportaEX.FlatStyle = FlatStyle.Flat;
		BTExportaEX.ForeColor = SystemColors.Control;
		BTExportaEX.Image = Resources.ExportaExcel_20;
		BTExportaEX.Location = new Point(599, 16);
		BTExportaEX.Name = "BTExportaEX";
		BTExportaEX.Size = new Size(22, 40);
		BTExportaEX.TabIndex = 150;
		BTExportaEX.UseVisualStyleBackColor = true;
		BTImportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTImportaEX.FlatStyle = FlatStyle.Flat;
		BTImportaEX.ForeColor = SystemColors.Control;
		BTImportaEX.Image = Resources.ImportaExcel_20;
		BTImportaEX.Location = new Point(627, 16);
		BTImportaEX.Name = "BTImportaEX";
		BTImportaEX.Size = new Size(22, 40);
		BTImportaEX.TabIndex = 149;
		BTImportaEX.UseVisualStyleBackColor = true;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(543, 16);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 40);
		btPesquisar.TabIndex = 149;
		btPesquisar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(744, 402);
		Controls.Add(dgPaginas);
		Controls.Add(GroupBox2);
		ImeMode = ImeMode.On;
		MinimumSize = new Size(760, 430);
		Name = "frmExportarImportarTextos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Exportar e Importar Textos";
		((ISupportInitialize)dgPaginas).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return anFr7ODr6X;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		anFr7ODr6X = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return OsNraecpeR;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		OsNraecpeR = WithEventsValue;
	}

	public frmExportarImportarTextos()
	{
		Resize += K1ArwU8Xyy;
		if (!Geral.ExisteForm("frmExportarImportarTextos"))
		{
			pqTroG4J8E();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 593]);
			GroupBox2.Text = "";
			w8dpBZ0kvSD().SetToolTip(BtEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 592]));
			tbQuant.Text = "0";
			lbQuantidadeCaracter.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1589], tbQuant.Text), DeclaracoesGeral.mMensagem[1, 1590]));
			CBAddNum.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1520]);
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	private void CiZrGDbthJ(object P_0, EventArgs P_1)
	{
		if (checked(dgPaginas.RowCount - 1) != 0)
		{
			DataGridView dg = dgPaginas;
			clsTextos.EditaTodosTextosETitulos(ref dg, ref yX0r3JiYcn);
			dgPaginas = dg;
			clsTextos.ApagaTextoEmBrabcoSemXdata();
			wgBrdqtJ8J();
		}
	}

	private void va2rHu3uCB(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(tbQuant.Text.Trim(), "", TextCompare: true) == 0)
		{
			tbQuant.Text = "0";
		}
		clsTextos.capturaTodosTextosETitulos(ref yX0r3JiYcn, CBAddNum.Checked, tbQuant.Text);
		wgBrdqtJ8J();
	}

	private void j4Arkgiury()
	{
		try
		{
			dgPaginas.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
			dgPaginas.RowsDefaultCellStyle.BackColor = Color.White;
			dgPaginas.Columns[0].ReadOnly = false;
			dgPaginas.MultiSelect = false;
			int num = Information.UBound(rv4r2PXaFG);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgPaginas.Rows.Add(rv4r2PXaFG[i].sPagina, rv4r2PXaFG[i].indice, rv4r2PXaFG[i].sTitulo, rv4r2PXaFG[i].shandle);
			}
			MfIr6FCWEc();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	private void wgBrdqtJ8J()
	{
		checked
		{
			try
			{
				dgPaginas.RowsDefaultCellStyle.BackColor = Color.LightYellow;
				dgPaginas.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(yX0r3JiYcn) + 5;
				DeclaracoesGeral._uscPagina.pbIniciar();
				brMrjjP804();
				DeclaracoesGeral._uscPagina.pbPasso();
				int num = Information.UBound(yX0r3JiYcn);
				for (int i = 1; i <= num; i++)
				{
					dgPaginas.Rows.Add(i, yX0r3JiYcn[i].sPagina, yX0r3JiYcn[i].sTipo, yX0r3JiYcn[i].sTexto, yX0r3JiYcn[i].shandle, Pagina.calculaPaginaDecimal(yX0r3JiYcn[i].sPagina));
					if (i == 1)
					{
						KYtrLJdUx3();
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DataGridViewColumn dataGridViewColumn = dgPaginas.Columns[5];
				dgPaginas.Sort(dataGridViewColumn, ListSortDirection.Ascending);
				KYtrLJdUx3();
				int num2 = dgPaginas.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgPaginas.Rows[j].Cells[0].Value = j + 1;
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				int num3 = 0;
				yX0r3JiYcn = new clsTextos.mTextos[1];
				int num4 = dgPaginas.RowCount - 1;
				for (int k = 0; k <= num4; k++)
				{
					num3++;
					ref clsTextos.mTextos[] reference = ref yX0r3JiYcn;
					reference = (clsTextos.mTextos[])Utils.CopyArray(reference, new clsTextos.mTextos[num3 + 1]);
					yX0r3JiYcn[num3].sIndice = Conversions.ToString(dgPaginas.Rows[k].Cells[0].Value);
					yX0r3JiYcn[num3].sPagina = Conversions.ToString(dgPaginas.Rows[k].Cells[1].Value);
					yX0r3JiYcn[num3].sTipo = Conversions.ToString(dgPaginas.Rows[k].Cells[2].Value);
					yX0r3JiYcn[num3].sTexto = Conversions.ToString(dgPaginas.Rows[k].Cells[3].Value);
					yX0r3JiYcn[num3].shandle = Conversions.ToString(dgPaginas.Rows[k].Cells[4].Value);
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	private void Y8arfmNLjh(object P_0, EventArgs P_1)
	{
		BTExportaEX.Enabled = false;
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		DataGridView dg = dgPaginas;
		clsTextos.ExportaTextos(ref oSheet, ref dg);
		dgPaginas = dg;
		BTExportaEX.Enabled = true;
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
	}

	private void hI6rDH7gou(object P_0, EventArgs P_1)
	{
		if (dgPaginas.RowCount <= 0)
		{
			return;
		}
		clsTextos.mTextos[] mTextosAtualizados = yX0r3JiYcn;
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		DataGridView dg = dgPaginas;
		clsTextos.ImportaTextos(ref oSheet, ref dg, ref mTextosAtualizados);
		dgPaginas = dg;
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = dgPaginas.RowCount - 1;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num = dgPaginas.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				bool flag = false;
				int num2 = Information.UBound(mTextosAtualizados);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.CompareString(dgPaginas.Rows[i].Cells[0].Value.ToString(), mTextosAtualizados[j].sIndice, TextCompare: true) == 0)
					{
						if (Operators.CompareString(dgPaginas.Rows[i].Cells[3].Value.ToString(), mTextosAtualizados[j].sTexto, TextCompare: true) != 0)
						{
							flag = true;
							dgPaginas.Rows[i].Cells[3].Value = mTextosAtualizados[j].sTexto;
						}
						break;
					}
				}
				if (flag)
				{
					dgPaginas.Rows[i].Cells[3].Style.BackColor = Color.LightCoral;
					dgPaginas.Rows[i].Cells[3].Style.ForeColor = Color.Black;
					if (i >= 4)
					{
						dgPaginas.FirstDisplayedScrollingRowIndex = i - 3;
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	private void JlsrvUFyFw()
	{
		dgPaginas.Rows.Clear();
		dgPaginas.Columns.Clear();
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 999]));
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 205]));
		dgPaginas.Columns.Add("", "Handle");
		MfIr6FCWEc();
	}

	private void MfIr6FCWEc()
	{
		checked
		{
			if (dgPaginas.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaginas)) ? ((double)(dgPaginas.Width - 4)) : ((double)(dgPaginas.Width - 21)));
				dgPaginas.Columns[0].Width = 50;
				dgPaginas.Columns[0].Visible = true;
				dgPaginas.Columns[1].Width = 50;
				dgPaginas.Columns[1].Visible = true;
				dgPaginas.Columns[2].Width = (int)Math.Round(num - 100.0);
				dgPaginas.Columns[2].Visible = true;
				dgPaginas.Columns[3].Width = 0;
				dgPaginas.Columns[3].Visible = false;
			}
		}
	}

	private void YFUrtCwQ0a()
	{
		if (dgPaginas.RowCount == 0)
		{
			return;
		}
		string right = Conversions.ToString(1);
		bool flag = false;
		checked
		{
			int num = dgPaginas.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(dgPaginas.Rows[i].Cells[0].Value.ToString(), right, TextCompare: true) != 0)
				{
					flag = !flag;
					right = dgPaginas.Rows[i].Cells[0].Value.ToString();
				}
				int num2 = 0;
				do
				{
					if (!flag)
					{
						dgPaginas.Rows[i].Cells[num2].Style.BackColor = Color.White;
						dgPaginas.Rows[i].Cells[num2].Style.ForeColor = Color.Black;
					}
					else
					{
						dgPaginas.Rows[i].Cells[num2].Style.BackColor = Color.LightYellow;
						dgPaginas.Rows[i].Cells[num2].Style.ForeColor = Color.Black;
					}
					num2++;
				}
				while (num2 <= 3);
			}
		}
	}

	private void brMrjjP804()
	{
		dgPaginas.Rows.Clear();
		dgPaginas.Columns.Clear();
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 999]));
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 217]));
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1303]));
		dgPaginas.Columns.Add("", "Handle");
		dgPaginas.Columns.Add("", "iPG");
		KYtrLJdUx3();
	}

	private void KYtrLJdUx3()
	{
		checked
		{
			if (dgPaginas.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaginas)) ? ((double)(dgPaginas.Width - 4)) : ((double)(dgPaginas.Width - 21)));
				dgPaginas.Columns[0].Width = 50;
				dgPaginas.Columns[0].Visible = true;
				dgPaginas.Columns[1].Width = 50;
				dgPaginas.Columns[1].Visible = true;
				dgPaginas.Columns[2].Width = 0;
				dgPaginas.Columns[2].Visible = false;
				dgPaginas.Columns[3].Width = (int)Math.Round(num - 100.0);
				dgPaginas.Columns[3].Visible = true;
				dgPaginas.Columns[4].Width = 0;
				dgPaginas.Columns[4].Visible = false;
				dgPaginas.Columns[5].Width = 0;
				dgPaginas.Columns[5].Visible = false;
			}
		}
	}

	private void K1ArwU8Xyy(object P_0, EventArgs P_1)
	{
		KYtrLJdUx3();
	}

	private void Xowrx5tyK7(object P_0, EventArgs P_1)
	{
		dgPaginas.Rows.Clear();
		dgPaginas.Columns.Clear();
	}

	private void UnHrb6xZxy(object P_0, EventArgs P_1)
	{
		dgPaginas.Rows.Clear();
		dgPaginas.Columns.Clear();
	}

	private void tBerM3FDG0(object P_0, KeyEventArgs P_1)
	{
		tbQuant.Text = tbQuant.Text.Trim();
		if (Operators.CompareString(tbQuant.Text, "", TextCompare: true) == 0)
		{
			tbQuant.Text = "0";
		}
		if (!Versioned.IsNumeric(tbQuant.Text))
		{
			tbQuant.Text = "0";
		}
		lbQuantidadeCaracter.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1589], tbQuant.Text), DeclaracoesGeral.mMensagem[1, 1590]));
	}

	private void tgXrOkSsWX(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}
}
