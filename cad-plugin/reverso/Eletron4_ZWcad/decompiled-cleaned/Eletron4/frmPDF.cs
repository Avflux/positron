using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.PlottingServices;

namespace Eletron4;

[DesignerGenerated]
public class frmPDF : Form
{
	private IContainer pIxDAmYnki;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar CiTDsSCesq;

	[CompilerGenerated]
	[AccessedThroughProperty("dg")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView st8DBKJ9Ik;

	[CompilerGenerated]
	[AccessedThroughProperty("btPDF")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button yhDDVvwueG;

	[AccessedThroughProperty("cbDevices")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox Cs9Dut2m1b;

	[AccessedThroughProperty("cbMedias")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox pWuDEJlgco;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private Label nbgDZ5JmGb;

	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label jNrDiBENMJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private Label WvaDS9d1Yf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPenas")]
	private ComboBox qYvD4U3YVt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	private Button lF5DC1nNK9;

	[AccessedThroughProperty("rbA3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton uXpDYerpux;

	[AccessedThroughProperty("rbA4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton jQeDrt8isc;

	[AccessedThroughProperty("rbAll")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton ji8D9EsABk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbHiperlink")]
	private CheckBox fbjDzkmjnE;

	private clsPDF.structurePaginasPDF[] fEnvWjp8Gn;

	private PlotSettingsValidator gUpvpyN6aC;

	private string CkOvT7a0QS;

	private string X1nvJMmc7L;

	private string ru5vhyJLpZ;

	private bool pgfvo6SC7I;

	private int SIEvGrVFT7;

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return CiTDsSCesq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CiTDsSCesq = value;
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return st8DBKJ9Ik;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			st8DBKJ9Ik = value;
		}
	}

	internal virtual Button btPDF
	{
		[CompilerGenerated]
		get
		{
			return yhDDVvwueG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ri5D0XgcTH;
			Button button = yhDDVvwueG;
			if (button != null)
			{
				button.Click -= value2;
			}
			yhDDVvwueG = value;
			button = yhDDVvwueG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox cbDevices
	{
		[CompilerGenerated]
		get
		{
			return Cs9Dut2m1b;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AyjDnD7iNj;
			ComboBox comboBox = Cs9Dut2m1b;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged -= value2;
			}
			Cs9Dut2m1b = value;
			comboBox = Cs9Dut2m1b;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged += value2;
			}
		}
	}

	internal virtual ComboBox cbMedias
	{
		[CompilerGenerated]
		get
		{
			return pWuDEJlgco;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XLiDlAh8IL;
			ComboBox comboBox = pWuDEJlgco;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged -= value2;
			}
			pWuDEJlgco = value;
			comboBox = pWuDEJlgco;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return nbgDZ5JmGb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nbgDZ5JmGb = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return jNrDiBENMJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jNrDiBENMJ = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return WvaDS9d1Yf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WvaDS9d1Yf = value;
		}
	}

	internal virtual ComboBox cbPenas
	{
		[CompilerGenerated]
		get
		{
			return qYvD4U3YVt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TWBD5Na4M1;
			ComboBox comboBox = qYvD4U3YVt;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged -= value2;
			}
			qYvD4U3YVt = value;
			comboBox = qYvD4U3YVt;
			if (comboBox != null)
			{
				comboBox.SelectedValueChanged += value2;
			}
		}
	}

	internal virtual Button BTCancelar
	{
		[CompilerGenerated]
		get
		{
			return lF5DC1nNK9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = h1rDRAqRGb;
			Button button = lF5DC1nNK9;
			if (button != null)
			{
				button.Click -= value2;
			}
			lF5DC1nNK9 = value;
			button = lF5DC1nNK9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbA3
	{
		[CompilerGenerated]
		get
		{
			return uXpDYerpux;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = a3sDmUODPk;
			RadioButton radioButton = uXpDYerpux;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			uXpDYerpux = value;
			radioButton = uXpDYerpux;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbA4
	{
		[CompilerGenerated]
		get
		{
			return jQeDrt8isc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DejDXP6AX4;
			RadioButton radioButton = jQeDrt8isc;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			jQeDrt8isc = value;
			radioButton = jQeDrt8isc;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbAll
	{
		[CompilerGenerated]
		get
		{
			return ji8D9EsABk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oPIDURWMFH;
			RadioButton radioButton = ji8D9EsABk;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			ji8D9EsABk = value;
			radioButton = ji8D9EsABk;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox cbHiperlink
	{
		[CompilerGenerated]
		get
		{
			return fbjDzkmjnE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fbjDzkmjnE = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && pIxDAmYnki != null)
			{
				pIxDAmYnki.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void XvuD2F5mWQ()
	{
		ProgressBar1 = new ProgressBar();
		dg = new DataGridView();
		btPDF = new Button();
		cbDevices = new ComboBox();
		cbMedias = new ComboBox();
		Label1 = new Label();
		Label2 = new Label();
		Label3 = new Label();
		cbPenas = new ComboBox();
		BTCancelar = new Button();
		rbA3 = new RadioButton();
		rbA4 = new RadioButton();
		rbAll = new RadioButton();
		cbHiperlink = new CheckBox();
		((ISupportInitialize)dg).BeginInit();
		SuspendLayout();
		ProgressBar1.Anchor = AnchorStyles.None;
		ProgressBar1.Location = new Point(10, 246);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(276, 18);
		ProgressBar1.TabIndex = 17;
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		dg.BackgroundColor = Color.White;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(301, 12);
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(145, 252);
		dg.TabIndex = 18;
		btPDF.Image = Resources.PDF_VM_32;
		btPDF.Location = new Point(185, 189);
		btPDF.Name = "btPDF";
		btPDF.Size = new Size(40, 40);
		btPDF.TabIndex = 19;
		btPDF.UseVisualStyleBackColor = true;
		cbDevices.FormattingEnabled = true;
		cbDevices.Location = new Point(10, 30);
		cbDevices.Name = "cbDevices";
		cbDevices.Size = new Size(276, 21);
		cbDevices.TabIndex = 20;
		cbMedias.FormattingEnabled = true;
		cbMedias.Location = new Point(10, 92);
		cbMedias.Name = "cbMedias";
		cbMedias.Size = new Size(276, 21);
		cbMedias.TabIndex = 21;
		Label1.AutoSize = true;
		Label1.Location = new Point(12, 12);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 22;
		Label1.Text = "Label1";
		Label2.AutoSize = true;
		Label2.Location = new Point(12, 72);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 23;
		Label2.Text = "Label2";
		Label3.AutoSize = true;
		Label3.Location = new Point(12, 128);
		Label3.Name = "Label3";
		Label3.Size = new Size(39, 13);
		Label3.TabIndex = 25;
		Label3.Text = "Label3";
		cbPenas.FormattingEnabled = true;
		cbPenas.Location = new Point(10, 147);
		cbPenas.Name = "cbPenas";
		cbPenas.Size = new Size(276, 21);
		cbPenas.TabIndex = 24;
		BTCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(246, 189);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 26;
		BTCancelar.UseVisualStyleBackColor = true;
		rbA3.AutoSize = true;
		rbA3.Location = new Point(143, 69);
		rbA3.Name = "rbA3";
		rbA3.Size = new Size(38, 17);
		rbA3.TabIndex = 27;
		rbA3.TabStop = true;
		rbA3.Text = "A3";
		rbA3.UseVisualStyleBackColor = true;
		rbA4.AutoSize = true;
		rbA4.Location = new Point(187, 69);
		rbA4.Name = "rbA4";
		rbA4.Size = new Size(38, 17);
		rbA4.TabIndex = 28;
		rbA4.TabStop = true;
		rbA4.Text = "A4";
		rbA4.UseVisualStyleBackColor = true;
		rbAll.AutoSize = true;
		rbAll.Location = new Point(231, 69);
		rbAll.Name = "rbAll";
		rbAll.Size = new Size(55, 17);
		rbAll.TabIndex = 29;
		rbAll.TabStop = true;
		rbAll.Text = "Todos";
		rbAll.UseVisualStyleBackColor = true;
		cbHiperlink.AutoSize = true;
		cbHiperlink.Location = new Point(12, 203);
		cbHiperlink.Name = "cbHiperlink";
		cbHiperlink.Size = new Size(123, 17);
		cbHiperlink.TabIndex = 31;
		cbHiperlink.Text = "Hiperlink de Páginas";
		cbHiperlink.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(454, 276);
		Controls.Add(cbHiperlink);
		Controls.Add(rbAll);
		Controls.Add(rbA4);
		Controls.Add(rbA3);
		Controls.Add(BTCancelar);
		Controls.Add(Label3);
		Controls.Add(cbPenas);
		Controls.Add(Label2);
		Controls.Add(Label1);
		Controls.Add(cbMedias);
		Controls.Add(cbDevices);
		Controls.Add(btPDF);
		Controls.Add(dg);
		Controls.Add(ProgressBar1);
		MaximizeBox = false;
		MaximumSize = new Size(470, 315);
		MinimizeBox = false;
		MinimumSize = new Size(470, 315);
		Name = "frmPDF";
		Text = "Exportar PDF Inteligente";
		((ISupportInitialize)dg).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmPDF()
	{
		checked
		{
			if (DeclaracoesGeral.Conf.incluirColuna != 6)
			{
				if (Geral.ExisteForm("frmPDF"))
				{
					return;
				}
				XvuD2F5mWQ();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1768]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1769]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1770]);
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1771]);
				rbAll.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1773]);
				cbHiperlink.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1938]);
				rbA3.Checked = true;
				SIEvGrVFT7 = 3;
				Pagina.CarregaPaginasOrdenadasNova();
				fEnvWjp8Gn = new clsPDF.structurePaginasPDF[1];
				int num = Information.UBound(DeclaracoesGeral.mPaginasNova);
				for (int i = 1; i <= num; i++)
				{
					int num2 = Information.UBound(fEnvWjp8Gn) + 1;
					ref clsPDF.structurePaginasPDF[] reference = ref fEnvWjp8Gn;
					reference = (clsPDF.structurePaginasPDF[])Utils.CopyArray(reference, new clsPDF.structurePaginasPDF[num2 + 1]);
					fEnvWjp8Gn[num2].paginaDWG = DeclaracoesGeral.mPaginasNova[i].Pagina;
					fEnvWjp8Gn[num2].alternativoDWG = DeclaracoesGeral.mPaginasNova[i].Alternativo;
					fEnvWjp8Gn[num2].paginaPDF = 0;
					fEnvWjp8Gn[num2].bSelecionado = false;
					fEnvWjp8Gn[num2].Revisao = DeclaracoesGeral.mPaginasNova[i].Revisao;
				}
				U0CDy6Y7Pm();
				A9oDgabvnO();
				uEID3PVhbg();
				string text = Geral.CADVersion();
				string text2 = text.Substring(0, 1);
				string left = text2;
				if (Operators.CompareString(left, "A", TextCompare: true) != 0 && Operators.CompareString(left, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "Z", TextCompare: true) == 0)
					{
						cbHiperlink.Enabled = false;
						cbHiperlink.Checked = false;
					}
				}
				else
				{
					cbHiperlink.Checked = true;
				}
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1772]), MsgBoxStyle.Exclamation);
			}
		}
	}

	private void uEID3PVhbg()
	{
		gUpvpyN6aC = PlotSettingsValidator.Current;
		StringCollection plotDeviceList = gUpvpyN6aC.GetPlotDeviceList();
		cbDevices.Items.Clear();
		checked
		{
			int num = plotDeviceList.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (plotDeviceList[i].ToUpper().Contains("AUTOCAD PDF") | plotDeviceList[i].ToUpper().Contains("DWG TO PDF") | plotDeviceList[i].ToUpper().Contains("PRINT AS PDF"))
				{
					cbDevices.Items.Add(plotDeviceList[i]);
				}
			}
			StringEnumerator enumerator = gUpvpyN6aC.GetPlotStyleSheetList().GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				if (current.ToUpper().Contains(".CTB"))
				{
					cbPenas.Items.Add(current);
				}
			}
		}
	}

	private void AyjDnD7iNj(object P_0, EventArgs P_1)
	{
		bP2D1WJHHi();
	}

	private void bP2D1WJHHi()
	{
		CkOvT7a0QS = cbDevices.Text;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			bool flag = false;
			cbMedias.Items.Clear();
			cbMedias.Text = "";
			PlotConfig val2 = PlotConfigManager.SetCurrentConfig(CkOvT7a0QS);
			val2.RefreshMediaNameList();
			StringEnumerator enumerator = val2.CanonicalMediaNames.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				switch (SIEvGrVFT7)
				{
				case 5:
					cbMedias.Items.Add(current);
					if (!flag)
					{
						flag = true;
						cbMedias.Text = current;
					}
					break;
				case 3:
					if (current.Contains("_A3_") | current.Contains(" A3 "))
					{
						cbMedias.Items.Add(current);
						if (!flag)
						{
							flag = true;
							cbMedias.Text = current;
						}
					}
					break;
				case 4:
					if (current.Contains("_A4_") | current.Contains(" A4 "))
					{
						cbMedias.Items.Add(current);
						if (!flag)
						{
							flag = true;
							cbMedias.Text = current;
						}
					}
					break;
				}
			}
			val.Commit();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void XLiDlAh8IL(object P_0, EventArgs P_1)
	{
		X1nvJMmc7L = cbMedias.Text;
	}

	private void TWBD5Na4M1(object P_0, EventArgs P_1)
	{
		ru5vhyJLpZ = cbPenas.Text;
	}

	private void Ri5D0XgcTH(object P_0, EventArgs P_1)
	{
		if (dg.SelectedRows.Count == 0 || ((Operators.CompareString(CkOvT7a0QS, "", TextCompare: true) == 0) | (Operators.CompareString(X1nvJMmc7L, "", TextCompare: true) == 0) | (Operators.CompareString(ru5vhyJLpZ, "", TextCompare: true) == 0)))
		{
			return;
		}
		DeclaracoesGeral.bPararRelatorio = false;
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (!dg.Rows[i].Selected)
				{
					fEnvWjp8Gn[i + 1].bSelecionado = false;
					continue;
				}
				fEnvWjp8Gn[i + 1].bSelecionado = true;
				num++;
			}
			try
			{
				if (cbHiperlink.Checked)
				{
					clsPDF.Hyperlink(bAdd: true);
				}
				_ = fEnvWjp8Gn.Count() - 1;
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = num;
				ProgressBar1.Value = 1;
				ProgressBar1.Step = 1;
				int num3 = fEnvWjp8Gn.Count() - 1;
				int num4 = 1;
				int num5 = 1;
				while (true)
				{
					if (((num4 >> 31) ^ num5) <= ((num4 >> 31) ^ num3))
					{
						if (!DeclaracoesGeral.bPararRelatorio)
						{
							if (fEnvWjp8Gn[num5].bSelecionado)
							{
								Pagina.AtivaPagina(fEnvWjp8Gn[num5].paginaDWG);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref fEnvWjp8Gn[num5].paginaDWG);
								clsPDF.PltPdf(CkOvT7a0QS, X1nvJMmc7L, ru5vhyJLpZ, fEnvWjp8Gn[num5].paginaDWG, pgfvo6SC7I);
								ProgressBar1.Increment(1);
							}
							num5 += num4;
							continue;
						}
						break;
					}
					clsPDF.MergePDF(ref fEnvWjp8Gn);
					string text = "";
					string nomePDF = "";
					text = clsPDF.TrocaHyperlink(ref fEnvWjp8Gn, ref nomePDF);
					if (Operators.CompareString(text, "", TextCompare: true) != 0)
					{
						using Process process = new Process();
						process.StartInfo.FileName = text;
						process.StartInfo.UseShellExecute = true;
						process.Start();
					}
					Thread.Sleep(5000);
					File.Delete(nomePDF);
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				Interaction.MsgBox(ex4.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
			finally
			{
				clsPDF.Hyperlink(bAdd: false);
			}
			ProgressBar1.Value = 0;
		}
	}

	private void h1rDRAqRGb(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 335]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			DeclaracoesGeral.bPararRelatorio = true;
		}
	}

	private void a3sDmUODPk(object P_0, EventArgs P_1)
	{
		if (rbA3.Checked)
		{
			SIEvGrVFT7 = 3;
		}
		if (Operators.CompareString(CkOvT7a0QS, "", TextCompare: true) != 0)
		{
			bP2D1WJHHi();
		}
	}

	private void DejDXP6AX4(object P_0, EventArgs P_1)
	{
		if (rbA4.Checked)
		{
			SIEvGrVFT7 = 4;
		}
		if (Operators.CompareString(CkOvT7a0QS, "", TextCompare: true) != 0)
		{
			bP2D1WJHHi();
		}
	}

	private void oPIDURWMFH(object P_0, EventArgs P_1)
	{
		if (rbAll.Checked)
		{
			SIEvGrVFT7 = 5;
		}
		if (Operators.CompareString(CkOvT7a0QS, "", TextCompare: true) != 0)
		{
			bP2D1WJHHi();
		}
	}

	private void U0CDy6Y7Pm()
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 63]));
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			float num2 = dg.Width - 25;
			dg.Columns[0].Width = (int)Math.Round(3f * num2 / 5f);
			dg.Columns[1].Width = (int)Math.Round(2f * num2 / 5f);
		}
	}

	private void A9oDgabvnO()
	{
		try
		{
			int num = Information.UBound(fEnvWjp8Gn);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
				{
					if ((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5))
					{
						if (Operators.CompareString(fEnvWjp8Gn[i].alternativoDWG.Trim(), "", TextCompare: true) == 0)
						{
							dg.Rows.Add(fEnvWjp8Gn[i].paginaDWG, fEnvWjp8Gn[i].Revisao);
						}
						else
						{
							dg.Rows.Add(fEnvWjp8Gn[i].alternativoDWG, fEnvWjp8Gn[i].Revisao);
						}
					}
				}
				else
				{
					dg.Rows.Add(fEnvWjp8Gn[i].paginaDWG, fEnvWjp8Gn[i].Revisao);
				}
			}
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
