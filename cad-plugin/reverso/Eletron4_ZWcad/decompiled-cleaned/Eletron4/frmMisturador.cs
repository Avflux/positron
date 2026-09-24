using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmMisturador : Form
{
	private IContainer AcDNEFK367;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBuscaBoudingBox")]
	private Button ElwNZ9suWT;

	[AccessedThroughProperty("btImportar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button GXcNi0VdE4;

	[AccessedThroughProperty("btSelecionaArquivos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button rSKNSJ7buJ;

	[AccessedThroughProperty("ProgressBar1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProgressBar wYUN4HBfGx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgDWG")]
	private DataGridView rxdNCssF83;

	[CompilerGenerated]
	[AccessedThroughProperty("rbCriarPáginas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton J1PNYFyWT3;

	[AccessedThroughProperty("rbFaixaPaginas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton cQ4NrU9jvJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip yvPN9h1tDx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox IixNzEpWK1;

	[AccessedThroughProperty("tbfim")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox PFuFWUiqFr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbinicio")]
	private TextBox hVQFp5Smp1;

	[CompilerGenerated]
	[AccessedThroughProperty("lbInicio")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label BbrFTTAPnL;

	[AccessedThroughProperty("lbFim")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label fnNFJ5V4uj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTCancelar")]
	private Button PMHFhYnYnR;

	private DataGridViewCellStyle nQdFoDeTXE;

	private DataGridViewCellStyle KjJFGoS8jR;

	public Color Corzero;

	private Point3d Yy8FHc8cJr;

	private Point3d M6nFkyZ0t4;

	private bool hnZFdI1iRQ;

	private int oyfFfMFhTy;

	private int fdZFDJeQ5q;

	internal virtual Button btBuscaBoudingBox
	{
		[CompilerGenerated]
		get
		{
			return ElwNZ9suWT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sJENmOeXdX;
			Button button = ElwNZ9suWT;
			if (button != null)
			{
				button.Click -= value2;
			}
			ElwNZ9suWT = value;
			button = ElwNZ9suWT;
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
			return GXcNi0VdE4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zONNyhgoS7;
			Button button = GXcNi0VdE4;
			if (button != null)
			{
				button.Click -= value2;
			}
			GXcNi0VdE4 = value;
			button = GXcNi0VdE4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSelecionaArquivos
	{
		[CompilerGenerated]
		get
		{
			return rSKNSJ7buJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oVLNRGjYZr;
			Button button = rSKNSJ7buJ;
			if (button != null)
			{
				button.Click -= value2;
			}
			rSKNSJ7buJ = value;
			button = rSKNSJ7buJ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return wYUN4HBfGx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wYUN4HBfGx = value;
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return rxdNCssF83;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = h1iNBSAL4J;
			DataGridViewCellEventHandler value3 = V4NNVbxh7N;
			DataGridView dataGridView = rxdNCssF83;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.CellEndEdit -= value3;
			}
			rxdNCssF83 = value;
			dataGridView = rxdNCssF83;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.CellEndEdit += value3;
			}
		}
	}

	internal virtual RadioButton rbCriarPáginas
	{
		[CompilerGenerated]
		get
		{
			return J1PNYFyWT3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			J1PNYFyWT3 = value;
		}
	}

	internal virtual RadioButton rbFaixaPaginas
	{
		[CompilerGenerated]
		get
		{
			return cQ4NrU9jvJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NKxNUNvOmI;
			RadioButton radioButton = cQ4NrU9jvJ;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			cQ4NrU9jvJ = value;
			radioButton = cQ4NrU9jvJ;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return IixNzEpWK1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IixNzEpWK1 = value;
		}
	}

	internal virtual TextBox tbfim
	{
		[CompilerGenerated]
		get
		{
			return PFuFWUiqFr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = T3XNADNWa6;
			TextBox textBox = PFuFWUiqFr;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			PFuFWUiqFr = value;
			textBox = PFuFWUiqFr;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbinicio
	{
		[CompilerGenerated]
		get
		{
			return hVQFp5Smp1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = FHmNgadMke;
			TextBox textBox = hVQFp5Smp1;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			hVQFp5Smp1 = value;
			textBox = hVQFp5Smp1;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbInicio
	{
		[CompilerGenerated]
		get
		{
			return BbrFTTAPnL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BbrFTTAPnL = value;
		}
	}

	internal virtual Label lbFim
	{
		[CompilerGenerated]
		get
		{
			return fnNFJ5V4uj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fnNFJ5V4uj = value;
		}
	}

	internal virtual Button BTCancelar
	{
		[CompilerGenerated]
		get
		{
			return PMHFhYnYnR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IrWNubrm4E;
			Button button = PMHFhYnYnR;
			if (button != null)
			{
				button.Click -= value2;
			}
			PMHFhYnYnR = value;
			button = PMHFhYnYnR;
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
			if (disposing && AcDNEFK367 != null)
			{
				AcDNEFK367.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void kujN0Sl6r1()
	{
		AcDNEFK367 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		btBuscaBoudingBox = new Button();
		btImportar = new Button();
		btSelecionaArquivos = new Button();
		ProgressBar1 = new ProgressBar();
		dgDWG = new DataGridView();
		rbCriarPáginas = new RadioButton();
		rbFaixaPaginas = new RadioButton();
		FDqpBiUmZij(new ToolTip(AcDNEFK367));
		GroupBox1 = new GroupBox();
		tbfim = new TextBox();
		tbinicio = new TextBox();
		lbInicio = new Label();
		lbFim = new Label();
		BTCancelar = new Button();
		((ISupportInitialize)dgDWG).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		btBuscaBoudingBox.FlatStyle = FlatStyle.Flat;
		btBuscaBoudingBox.ForeColor = SystemColors.Control;
		btBuscaBoudingBox.Image = Resources.Selecao32;
		btBuscaBoudingBox.Location = new Point(471, 12);
		btBuscaBoudingBox.Name = "btBuscaBoudingBox";
		btBuscaBoudingBox.Size = new Size(40, 40);
		btBuscaBoudingBox.TabIndex = 17;
		btBuscaBoudingBox.UseVisualStyleBackColor = true;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.Start;
		btImportar.Location = new Point(542, 12);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(40, 40);
		btImportar.TabIndex = 14;
		btImportar.UseVisualStyleBackColor = true;
		btSelecionaArquivos.AutoSize = true;
		btSelecionaArquivos.FlatStyle = FlatStyle.Flat;
		btSelecionaArquivos.ForeColor = SystemColors.Control;
		btSelecionaArquivos.Image = Resources.DWG;
		btSelecionaArquivos.Location = new Point(12, 10);
		btSelecionaArquivos.Name = "btSelecionaArquivos";
		btSelecionaArquivos.Size = new Size(40, 44);
		btSelecionaArquivos.TabIndex = 19;
		btSelecionaArquivos.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(2, 272);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(641, 10);
		ProgressBar1.TabIndex = 20;
		dgDWG.AllowDrop = true;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.Location = new Point(10, 64);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(622, 202);
		dgDWG.TabIndex = 179;
		rbCriarPáginas.AutoSize = true;
		rbCriarPáginas.Location = new Point(70, 35);
		rbCriarPáginas.Name = "rbCriarPáginas";
		rbCriarPáginas.Size = new Size(93, 17);
		rbCriarPáginas.TabIndex = 181;
		rbCriarPáginas.TabStop = true;
		rbCriarPáginas.Text = "rbCriarPáginas";
		rbCriarPáginas.UseVisualStyleBackColor = true;
		rbFaixaPaginas.AutoSize = true;
		rbFaixaPaginas.Location = new Point(70, 12);
		rbFaixaPaginas.Name = "rbFaixaPaginas";
		rbFaixaPaginas.Size = new Size(97, 17);
		rbFaixaPaginas.TabIndex = 180;
		rbFaixaPaginas.TabStop = true;
		rbFaixaPaginas.Text = "rbFaixaPaginas";
		rbFaixaPaginas.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(tbfim);
		GroupBox1.Controls.Add(tbinicio);
		GroupBox1.Controls.Add(lbInicio);
		GroupBox1.Controls.Add(lbFim);
		GroupBox1.Location = new Point(206, 9);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(241, 46);
		GroupBox1.TabIndex = 186;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "sFaixa de Paginas";
		tbfim.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbfim.Location = new Point(176, 17);
		tbfim.Name = "tbfim";
		tbfim.Size = new Size(52, 20);
		tbfim.TabIndex = 187;
		tbinicio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbinicio.Location = new Point(59, 18);
		tbinicio.Name = "tbinicio";
		tbinicio.Size = new Size(52, 20);
		tbinicio.TabIndex = 186;
		lbInicio.AutoSize = true;
		lbInicio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lbInicio.Location = new Point(13, 21);
		lbInicio.Name = "lbInicio";
		lbInicio.Size = new Size(40, 13);
		lbInicio.TabIndex = 188;
		lbInicio.Text = "lbInicio";
		lbFim.AutoSize = true;
		lbFim.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lbFim.Location = new Point(130, 20);
		lbFim.Name = "lbFim";
		lbFim.Size = new Size(36, 13);
		lbFim.TabIndex = 189;
		lbFim.Text = "LBFim";
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(588, 12);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 188;
		BTCancelar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(644, 288);
		Controls.Add(BTCancelar);
		Controls.Add(GroupBox1);
		Controls.Add(rbCriarPáginas);
		Controls.Add(rbFaixaPaginas);
		Controls.Add(dgDWG);
		Controls.Add(ProgressBar1);
		Controls.Add(btSelecionaArquivos);
		Controls.Add(btBuscaBoudingBox);
		Controls.Add(btImportar);
		MinimumSize = new Size(660, 320);
		Name = "frmMisturador";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Importar Funcional";
		((ISupportInitialize)dgDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return yvPN9h1tDx;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		yvPN9h1tDx = WithEventsValue;
	}

	public frmMisturador()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Resize += DVdNsa3kx2;
		nQdFoDeTXE = new DataGridViewCellStyle();
		KjJFGoS8jR = new DataGridViewCellStyle();
		Yy8FHc8cJr = default;
		M6nFkyZ0t4 = default;
		hnZFdI1iRQ = true;
		if (!Geral.ExisteForm("frmMisturador"))
		{
			kujN0Sl6r1();
			nQdFoDeTXE.BackColor = Color.White;
			KjJFGoS8jR.BackColor = Color.LightCoral;
			rbFaixaPaginas.Checked = true;
			oyfFfMFhTy = 6;
			fdZFDJeQ5q = 5;
			tbinicio.Text = Conversions.ToString(oyfFfMFhTy);
			tbfim.Text = Conversions.ToString(fdZFDJeQ5q);
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1389]);
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1390]);
			lbInicio.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1391]);
			lbFim.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1392]);
			rbFaixaPaginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1390]);
			rbCriarPáginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1393]);
			clsMisturador.EncontraCorLayerZeroDoFormato(ref Corzero);
			w8dpBZ0kvSD().SetToolTip(btSelecionaArquivos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1394]));
			w8dpBZ0kvSD().SetToolTip(btBuscaBoudingBox, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1395]));
			w8dpBZ0kvSD().SetToolTip(btImportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 870]));
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	private void oVLNRGjYZr(object P_0, EventArgs P_1)
	{
		dgDWG.Rows.Clear();
		dgDWG.Columns.Clear();
		dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 998]));
		dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		checked
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				OpenFileDialog openFileDialog2 = openFileDialog;
				openFileDialog2.AddExtension = true;
				openFileDialog2.CheckFileExists = true;
				openFileDialog2.CheckPathExists = true;
				openFileDialog2.FilterIndex = 0;
				openFileDialog2.Filter = "AutoCAD DWG (*.dwg)|*.dwg";
				openFileDialog2.InitialDirectory = DeclaracoesGeral.Conf.DirSimbologiaEletrica;
				openFileDialog2.Multiselect = true;
				openFileDialog2.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1608]);
				openFileDialog2 = null;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						int num = openFileDialog.FileNames.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							dgDWG.Rows.Add(openFileDialog.FileNames[i]);
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			CalculaPaginas();
			XgaNXoqARn();
		}
	}

	private void sJENmOeXdX(object P_0, EventArgs P_1)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		string name = Application.DocumentManager.MdiActiveDocument.Name;
		DocumentCollection documentManager = Application.DocumentManager;
		List<string> list = new List<string>();
		foreach (Document item in documentManager)
		{
			Document val = item;
			list.Add(val.Name);
		}
		Visible = false;
		string text = "";
		if (dgDWG.Rows.Count > 0)
		{
			if (dgDWG.SelectedRows.Count == 0)
			{
				dgDWG.Rows[0].Selected = true;
			}
			if (dgDWG.SelectedRows.Count == 1)
			{
				text = Conversions.ToString(dgDWG.SelectedRows[0].Cells[0].Value);
				clsMisturador.BuscaPontos(text, ref Yy8FHc8cJr, ref M6nFkyZ0t4);
				hnZFdI1iRQ = false;
			}
		}
		Visible = true;
		foreach (Document item2 in documentManager)
		{
			Document val2 = item2;
			if (!list.Contains(val2.Name))
			{
				DocumentExtension.CloseAndDiscard(val2);
			}
		}
		IEnumerator enumerator3 = documentManager.GetEnumerator();
		try
		{
			Document val3;
			do
			{
				if (enumerator3.MoveNext())
				{
					val3 = (Document)enumerator3.Current;
					continue;
				}
				return;
			}
			while (Operators.CompareString(val3.Name, name, TextCompare: true) != 0);
			documentManager.MdiActiveDocument = val3;
		}
		finally
		{
			IDisposable disposable = enumerator3 as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void XgaNXoqARn()
	{
		checked
		{
			if (dgDWG.Rows.Count > 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDWG)) ? ((double)(dgDWG.Width - 5)) : ((double)(dgDWG.Width - 22)));
				dgDWG.Columns[0].Width = (int)Math.Round(num * 0.9);
				dgDWG.Columns[1].Width = (int)Math.Round(num * 0.1);
				dgDWG.MultiSelect = true;
				dgDWG.Columns[0].ReadOnly = true;
				dgDWG.Columns[1].ReadOnly = false;
			}
		}
	}

	public bool CalculaPaginas()
	{
		bool result = true;
		checked
		{
			if (dgDWG.Rows.Count != 0)
			{
				int num = dgDWG.Rows.Count - 1;
				for (int i = num; i >= 0; i += -1)
				{
					dgDWG.Rows[i].Cells[1].Value = "";
				}
				btBuscaBoudingBox.Enabled = true;
				btImportar.Enabled = true;
				BTCancelar.Enabled = true;
				if (!rbFaixaPaginas.Checked)
				{
					int num2 = 0;
					if (Versioned.IsNumeric(tbinicio.Text) && Conversions.ToInteger(tbinicio.Text) > 1)
					{
						int num3 = dgDWG.Rows.Count - 1;
						for (int j = 0; j <= num3; j++)
						{
							string layer = Conversions.ToString(Conversions.ToInteger(tbinicio.Text) + num2);
							layer = Pagina.montaNumeroPagina(layer);
							dgDWG.Rows[j].Cells[1].Value = layer;
							num2++;
							if (!Versioned.IsNumeric(layer))
							{
								dgDWG.Rows[j].Cells[1].Style = KjJFGoS8jR;
								btImportar.Enabled = false;
								result = false;
							}
							else
							{
								dgDWG.Rows[j].Cells[1].Style = nQdFoDeTXE;
							}
						}
					}
				}
				else if ((Versioned.IsNumeric(tbinicio.Text) & Versioned.IsNumeric(tbfim.Text)) && Conversions.ToInteger(tbinicio.Text) > Conversions.ToInteger(tbfim.Text.Trim()))
				{
					int num4 = dgDWG.Rows.Count - 1;
					for (int k = num4; k >= 0; k += -1)
					{
						string layer2 = Strings.Mid(Conversions.ToString(dgDWG.Rows[k].Cells[0].Value), Strings.Len(RuntimeHelpers.GetObjectValue(dgDWG.Rows[k].Cells[0].Value)) - Conversions.ToInteger(tbinicio.Text) + 1, Conversions.ToInteger(tbinicio.Text) - Conversions.ToInteger(tbfim.Text) + 1);
						bool flag = false;
						layer2 = Pagina.montaNumeroPagina(layer2);
						dgDWG.Rows[k].Cells[1].Value = layer2;
						dgDWG.Rows[k].Cells[1].Style = nQdFoDeTXE;
						if (!Pagina.LayerValido(layer2))
						{
							flag = true;
						}
						if (Operators.CompareString(layer2, "", TextCompare: true) == 0)
						{
							flag = true;
						}
						if (flag)
						{
							dgDWG.Rows[k].Cells[1].Style = KjJFGoS8jR;
							btImportar.Enabled = false;
							result = false;
						}
					}
				}
				int num5 = dgDWG.Rows.Count - 1;
				for (int l = 0; l <= num5; l++)
				{
					int num6 = l + 1;
					int num7 = dgDWG.Rows.Count - 1;
					for (int m = num6; m <= num7; m++)
					{
						if (Operators.ConditionalCompareObjectEqual(dgDWG.Rows[l].Cells[1].Value, dgDWG.Rows[m].Cells[1].Value, TextCompare: true))
						{
							dgDWG.Rows[l].Cells[1].Style = KjJFGoS8jR;
							dgDWG.Rows[m].Cells[1].Style = KjJFGoS8jR;
							btImportar.Enabled = false;
							result = false;
						}
					}
					if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgDWG.Rows[l].Cells[1].Value)) && Conversions.ToInteger(dgDWG.Rows[l].Cells[1].Value) < 1)
					{
						dgDWG.Rows[l].Cells[1].Style = KjJFGoS8jR;
						btImportar.Enabled = false;
						result = false;
					}
				}
			}
			else
			{
				btBuscaBoudingBox.Enabled = false;
				btImportar.Enabled = false;
				BTCancelar.Enabled = false;
				result = false;
			}
			return result;
		}
	}

	private void NKxNUNvOmI(object P_0, EventArgs P_1)
	{
		if (!rbFaixaPaginas.Checked)
		{
			oyfFfMFhTy = Conversions.ToInteger(tbinicio.Text);
			fdZFDJeQ5q = Conversions.ToInteger(tbfim.Text);
			string text = Conversions.ToString(DeclaracoesGeral.mPaginas[0, Information.UBound(DeclaracoesGeral.mPaginas, 2)]);
			while (Operators.CompareString(Strings.Mid(text, 1, 1), "0", TextCompare: true) == 0)
			{
				text = Strings.Mid(text, 2);
			}
			tbinicio.Text = Conversions.ToString(Conversions.ToDouble(text) + 1.0);
			tbfim.Visible = false;
			lbFim.Visible = false;
		}
		else
		{
			tbfim.Visible = true;
			lbFim.Visible = true;
			tbinicio.Text = Conversions.ToString(oyfFfMFhTy);
			tbfim.Text = Conversions.ToString(fdZFDJeQ5q);
		}
		CalculaPaginas();
	}

	private void zONNyhgoS7(object P_0, EventArgs P_1)
	{
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected Obj, but got Unknown
		//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Expected Obj, but got Unknown
		//IL_07db: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Expected Obj, but got Unknown
		//IL_07f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected Obj, but got Unknown
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Expected Obj, but got Unknown
		//IL_08a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Expected Obj, but got Unknown
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_0927: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected Obj, but got Unknown
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_094f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0954: Unknown result type (might be due to invalid IL or missing references)
		//IL_0958: Unknown result type (might be due to invalid IL or missing references)
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected Obj, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected Obj, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected Obj, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0979: Unknown result type (might be due to invalid IL or missing references)
		//IL_0981: Unknown result type (might be due to invalid IL or missing references)
		//IL_0988: Expected Obj, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected Obj, but got Unknown
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Expected Obj, but got Unknown
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a72: Expected Obj, but got Unknown
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected Obj, but got Unknown
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1b: Expected Obj, but got Unknown
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bPararRelatorio = false;
		List<string> lLayers = new List<string>();
		List<string> lHandles = new List<string>();
		string text = "";
		Conversions.ToString(0);
		checked
		{
			try
			{
				PointMonitorToolTips.StopMonitor();
				DeclaracoesGeral.bSuspenderEventoExpImpClonar = true;
				ObjectIdCollection val = null;
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = dgDWG.Rows.Count;
				ProgressBar1.Value = 0;
				long ipontoInicial = 0L;
				bool flag = false;
				dgDWG.FirstDisplayedScrollingRowIndex = 0;
				int num = dgDWG.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDWG.Rows[i].Selected = true;
					text = Conversions.ToString(dgDWG.Rows[i].Cells[1].Value);
					text = Pagina.montaNumeroPagina(text);
					if (Operators.CompareString(Pagina.CriarLayer(text, "", ""), "-1", TextCompare: true) != 0)
					{
						Pagina.criaCamposFormato("-1", text);
						flag = true;
					}
				}
				if (flag)
				{
					Pagina.CarregaPaginas();
					Pagina.OrdenaMatrizPaginas();
					Pagina.AtualizaContTotFl();
					DeclaracoesGeral._uscPagina.CarregaPG();
				}
				Application.DoEvents();
				clsMisturador.LeTodososOsLayers(ref lLayers);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				int num2 = dgDWG.Rows.Count - 1;
				SymbolTableEnumerator enumerator = default;
				BlockTableRecordEnumerator enumerator2 = default;
				BlockTableRecordEnumerator enumerator3 = default;
				for (int j = 0; j <= num2; j++)
				{
					uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
					DataGridViewCell dataGridViewCell;
					string pag = Conversions.ToString((dataGridViewCell = dgDWG.Rows[j].Cells[1]).Value);
					uscPagina.ativaPaginaAtalho(ref pag);
					dataGridViewCell.Value = pag;
					Pagina.AtivaPagina(Conversions.ToString(dgDWG.Rows[j].Cells[1].Value));
					clsMisturador.LeTodososOshandles(ref lHandles, ref ipontoInicial);
					ProgressBar1.Value++;
					if (j > 5)
					{
						dgDWG.FirstDisplayedScrollingRowIndex = j - 5;
					}
					dgDWG.Rows[j].Selected = false;
					string text2 = Conversions.ToString(dgDWG.Rows[j].Cells[0].Value);
					Database val2 = new Database(false, true);
					try
					{
						val2.ReadDwgFile(text2, FileShare.Read, true, "");
						clsMisturador.LayerColor[] array = new clsMisturador.LayerColor[1];
						int num3 = 0;
						array = new clsMisturador.LayerColor[1];
						Transaction val3 = val2.TransactionManager.StartTransaction();
						try
						{
							LayerTable val4 = (LayerTable)val3.GetObject(val2.LayerTableId, (OpenMode)0);
							try
							{
								enumerator = val4.GetEnumerator();
								while (enumerator.MoveNext())
								{
									ObjectId current = enumerator.Current;
									LayerTableRecord val5 = (LayerTableRecord)val3.GetObject(current, (OpenMode)0);
									if (Corzero != val5.Color)
									{
										array = (clsMisturador.LayerColor[])Utils.CopyArray(array, new clsMisturador.LayerColor[num3 + 1]);
										array[num3].Cor = val5.Color;
										array[num3].lAYER = ((SymbolTableRecord)val5).Name;
										array[num3].vISISVEL = Conversions.ToString(val5.IsOff);
										num3++;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
						Transaction val6 = (Transaction)(object)val2.TransactionManager.StartOpenCloseTransaction();
						try
						{
							val = new ObjectIdCollection();
							BlockTable val7 = (BlockTable)val6.GetObject(val2.BlockTableId, (OpenMode)0);
							BlockTableRecord val8 = (BlockTableRecord)val6.GetObject(((SymbolTable)val7)[BlockTableRecord.ModelSpace], (OpenMode)0);
							Point3d val9 = new Point3d(1000000.0, 1000000.0, 0.0);
							Point3d val10 = default;
							Extents3d value;
							Point3d val15;
							try
							{
								enumerator2 = val8.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									ObjectId current2 = enumerator2.Current;
									Entity val11 = (Entity)val6.GetObject(current2, (OpenMode)0);
									if (Information.IsNothing(((Drawable)val11).Bounds))
									{
										continue;
									}
									bool flag2 = false;
									Polyline val12 = (Polyline)(object)((val11 is Polyline) ? val11 : null);
									if (val12 == null)
									{
										Line val13 = (Line)(object)((val11 is Line) ? val11 : null);
										if (val13 == null)
										{
											BlockReference val14 = (BlockReference)(object)((val11 is BlockReference) ? val11 : null);
											if (val14 != null)
											{
												flag2 = true;
											}
										}
										else
										{
											flag2 = true;
										}
									}
									else
									{
										flag2 = true;
									}
									if (flag2)
									{
										value = ((Drawable)val11).Bounds.Value;
										val15 = value.MinPoint;
										double num4 = val15.X;
										value = ((Drawable)val11).Bounds.Value;
										val15 = value.MinPoint;
										val10 = new Point3d(num4, val15.Y, 0.0);
										if (val9.X >= val10.X)
										{
											val9 = new Point3d(val10.X, val9.Y, 0.0);
										}
										if (val9.Y >= val10.Y)
										{
											val9 = new Point3d(val9.X, val10.Y, 0.0);
										}
									}
								}
							}
							finally
							{
								((IDisposable)enumerator2)?.Dispose();
							}
							Math.Round(val9.X, 2);
							Math.Round(val9.Y, 2);
							try
							{
								enumerator3 = val8.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									ObjectId current3 = enumerator3.Current;
									Entity val16 = (Entity)val6.GetObject(current3, (OpenMode)0);
									if (val16.Visible)
									{
										Point3d val17 = default;
										Point3d val18 = default;
										if (!Information.IsNothing(((Drawable)val16).Bounds))
										{
											value = ((Drawable)val16).Bounds.Value;
											val15 = value.MinPoint;
											double num5 = Math.Round(val15.X, 2);
											value = ((Drawable)val16).Bounds.Value;
											val15 = value.MinPoint;
											val17 = new Point3d(num5, Math.Round(val15.Y, 2), 0.0);
											value = ((Drawable)val16).Bounds.Value;
											val15 = value.MaxPoint;
											double num6 = Math.Round(val15.X, 2);
											value = ((Drawable)val16).Bounds.Value;
											val15 = value.MaxPoint;
											val18 = new Point3d(num6, Math.Round(val15.Y, 2), 0.0);
											if (!hnZFdI1iRQ)
											{
												if (((val17.X >= Yy8FHc8cJr.X) & (val17.Y >= Yy8FHc8cJr.Y) & (val18.X <= M6nFkyZ0t4.X) & (val18.Y <= M6nFkyZ0t4.Y)) && val16.Visible)
												{
													val.Add(((DBObject)val16).ObjectId);
												}
											}
											else if (val16.Visible)
											{
												val.Add(((DBObject)val16).ObjectId);
											}
										}
									}
									if (DeclaracoesGeral.bPararRelatorio)
									{
										break;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator3)?.Dispose();
							}
							DeclaracoesGeral.bAnularEventos = true;
							val6.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							val6.Abort();
							Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
							ProjectData.ClearProjectError();
						}
						finally
						{
							((IDisposable)val6)?.Dispose();
						}
						IdMapping val19 = new IdMapping();
						DocumentLock val20 = Application.DocumentManager.MdiActiveDocument.LockDocument();
						try
						{
							Database database = Application.DocumentManager.MdiActiveDocument.Database;
							_ = Application.DocumentManager.MdiActiveDocument.Editor;
							Transaction val21 = database.TransactionManager.StartTransaction();
							try
							{
								try
								{
									BlockTable val22 = (BlockTable)val21.GetObject(database.BlockTableId, (OpenMode)0);
									BlockTableRecord val23 = (BlockTableRecord)val21.GetObject(((SymbolTable)val22)[BlockTableRecord.ModelSpace], (OpenMode)0);
									val2.WblockCloneObjects(val, ((DBObject)val23).ObjectId, val19, (DuplicateRecordCloning)1, false);
									DeclaracoesGeral.bAnularEventos = true;
									val21.Commit();
									DeclaracoesGeral.bAnularEventos = false;
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									val21.Abort();
									throw;
								}
								finally
								{
									DeclaracoesGeral.bAnularEventos = false;
								}
							}
							finally
							{
								((IDisposable)val21)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val20)?.Dispose();
						}
						DocumentLock val24 = Application.DocumentManager.MdiActiveDocument.LockDocument();
						try
						{
							Database db = Application.DocumentManager.MdiActiveDocument.Database;
							_ = Application.DocumentManager.MdiActiveDocument.Editor;
							Transaction val25 = db.TransactionManager.StartTransaction();
							try
							{
								BlockTable val26 = (BlockTable)val25.GetObject(db.BlockTableId, (OpenMode)1);
								BlockTableRecord mdl = (BlockTableRecord)val25.GetObject(((SymbolTable)val26)[BlockTableRecord.ModelSpace], (OpenMode)1);
								text = Conversions.ToString(dgDWG.Rows[j].Cells[1].Value);
								Point3d val27 = new Point3d(0.0, 0.0, 0.0);
								Vector3d vectorTo = val27.GetVectorTo(new Point3d(0.0, 0.0, 0.0));
								foreach (object item in val19)
								{
									IdPair val28 = ((item == null) ? default(IdPair) : ((IdPair)item));
									ObjectId key = val28.Key;
									ObjectId value2 = val28.Value;
									if (!val.Contains(key))
									{
										continue;
									}
									Entity val29 = (Entity)val25.GetObject(value2, (OpenMode)1);
									((DBObject)val29).UpgradeOpen();
									string layer = val29.Layer;
									val29.Layer = text;
									clsMisturador.LayerColor[] array2 = array;
									for (int k = 0; k < array2.Length; k++)
									{
										clsMisturador.LayerColor layerColor = array2[k];
										if (Operators.CompareString(layer, clsTextos.TiraNothing(layerColor.lAYER), TextCompare: true) == 0)
										{
											((DBObject)val29).UpgradeOpen();
											val29.Color = layerColor.Cor;
										}
									}
								}
								foreach (object item2 in val19)
								{
									IdPair val30 = ((item2 == null) ? default(IdPair) : ((IdPair)item2));
									ObjectId key2 = val30.Key;
									ObjectId value3 = val30.Value;
									if (val.Contains(key2))
									{
										Entity val31 = (Entity)val25.GetObject(value3, (OpenMode)1);
										val31.Layer = text;
									}
									if (val.Contains(key2))
									{
										Entity val32 = (Entity)val25.GetObject(value3, (OpenMode)1);
										val32.TransformBy(Matrix3d.Displacement(vectorTo));
									}
								}
								foreach (object item3 in val19)
								{
									IdPair val33 = ((item3 == null) ? default(IdPair) : ((IdPair)item3));
									ObjectId key3 = val33.Key;
									ObjectId value4 = val33.Value;
									if (val.Contains(key3))
									{
										Entity ent = (Entity)val25.GetObject(value4, (OpenMode)1);
										if (((DBObject)ent).XData != (ResultBuffer)null)
										{
											clsMisturador.ApagarxDataDaEntity(ref db, ref ent);
										}
										BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
										if (blockRef != null)
										{
											clsBlocos.LimpaAtributoInvisivel(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
											clsMisturador.burstNoBloco(ref mdl, ref blockRef, text);
											((DBObject)ent).Erase();
										}
									}
								}
								DeclaracoesGeral.bAnularEventos = true;
								val25.Commit();
								DeclaracoesGeral.bAnularEventos = false;
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								ProjectData.ClearProjectError();
							}
							finally
							{
								((IDisposable)val25)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val24)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
					if (j == 0)
					{
						clsMisturador.zoomall();
					}
					if (!DeclaracoesGeral.bPararRelatorio)
					{
						clsMisturador.MoveOsOutrosaLayersParaPagiana(ref lHandles, text);
						continue;
					}
					break;
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				throw;
			}
			finally
			{
			}
			Database newDb = Application.DocumentManager.MdiActiveDocument.Database;
			ExportarPG.PurgeDatabase(ref newDb);
			ProgressBar1.Value = 0;
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1396]), MsgBoxStyle.Information);
			PointMonitorToolTips.StartMonitor();
			DeclaracoesGeral.bSuspenderEventoExpImpClonar = false;
		}
	}

	private void FHmNgadMke(object P_0, KeyEventArgs P_1)
	{
		CalculaPaginas();
	}

	private void T3XNADNWa6(object P_0, KeyEventArgs P_1)
	{
		CalculaPaginas();
	}

	private void DVdNsa3kx2(object P_0, EventArgs P_1)
	{
		XgaNXoqARn();
	}

	private void h1iNBSAL4J(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyValue == 46)
		{
			if (dgDWG.SelectedRows.Count > 0)
			{
				dgDWG.Rows.RemoveAt(dgDWG.SelectedRows[0].Index);
			}
			CalculaPaginas();
		}
	}

	private void V4NNVbxh7N(object P_0, DataGridViewCellEventArgs P_1)
	{
		string text = "";
		text = Conversions.ToString(dgDWG.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
		if (text == null)
		{
			text = "";
		}
		text = text.Trim();
		text = text.ToUpper();
		checked
		{
			if (!Pagina.LayerValido(text))
			{
				string layer = Strings.Mid(Conversions.ToString(dgDWG.Rows[P_1.RowIndex].Cells[0].Value), Strings.Len(RuntimeHelpers.GetObjectValue(dgDWG.Rows[P_1.RowIndex].Cells[0].Value)) - Conversions.ToInteger(tbinicio.Text) + 1, Conversions.ToInteger(tbinicio.Text) - Conversions.ToInteger(tbfim.Text) + 1);
				layer = Pagina.montaNumeroPagina(layer);
				dgDWG.Rows[P_1.RowIndex].Cells[1].Value = layer;
				text = layer;
			}
			int num = dgDWG.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (P_1.RowIndex != i)
				{
					dgDWG.Rows[i].Cells[1].Value = Pagina.montaNumeroPagina(Conversions.ToString(dgDWG.Rows[i].Cells[1].Value));
				}
			}
			text = Pagina.montaNumeroPagina(text);
			int num2 = dgDWG.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				dgDWG.Rows[j].Cells[1].Style = nQdFoDeTXE;
				if (P_1.RowIndex == j)
				{
					dgDWG.Rows[j].Cells[1].Value = text;
					if (!Pagina.LayerValido(text))
					{
						dgDWG.Rows[j].Cells[1].Style = KjJFGoS8jR;
					}
					else
					{
						dgDWG.Rows[j].Cells[1].Style = nQdFoDeTXE;
					}
				}
			}
			btImportar.Enabled = true;
			int num3 = dgDWG.Rows.Count - 1;
			for (int k = 0; k <= num3; k++)
			{
				int num4 = k + 1;
				int num5 = dgDWG.Rows.Count - 1;
				for (int l = num4; l <= num5; l++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDWG.Rows[k].Cells[1].Value, dgDWG.Rows[l].Cells[1].Value, TextCompare: true))
					{
						dgDWG.Rows[k].Cells[1].Style = KjJFGoS8jR;
						dgDWG.Rows[l].Cells[1].Style = KjJFGoS8jR;
						btImportar.Enabled = false;
					}
				}
				if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgDWG.Rows[k].Cells[1].Value)) && Conversions.ToInteger(dgDWG.Rows[k].Cells[1].Value) < 1)
				{
					dgDWG.Rows[k].Cells[1].Style = KjJFGoS8jR;
					btImportar.Enabled = false;
				}
				if (!Pagina.LayerValido(Conversions.ToString(dgDWG.Rows[k].Cells[1].Value)))
				{
					btImportar.Enabled = false;
				}
			}
		}
	}

	private void IrWNubrm4E(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		Application.DoEvents();
	}
}
