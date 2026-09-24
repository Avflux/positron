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
public class frmCadastroDePaineis : Form
{
	private IContainer OMt0J85FYc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	[CompilerGenerated]
	private Button vin0hQnTQb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	private DataGridView aTF0oNjDi8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelQuantidade")]
	private Label EJ70GdIeFi;

	[AccessedThroughProperty("btInserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button VVm0HXlFBE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEditar")]
	private Button aRi0kY4kgr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBNome")]
	private TextBox IAm0d5DD3f;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgH")]
	private DataGridView nqM0fAE4wQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LabelQuantidadeH")]
	private Label wmg0Dy3F9D;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	private Button NGq0vZXQ9j;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btUsados")]
	private Button BQV0615LfF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btUsadosH")]
	private Button svr0t4NDOv;

	[AccessedThroughProperty("btExportar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button fTC0jgO9T8;

	[CompilerGenerated]
	[AccessedThroughProperty("btImportar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button BOJ0LQsKgw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btModelosPN")]
	private Button WMN0wMCwDo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox Q450xsIlef;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarPaineisHistorico")]
	[CompilerGenerated]
	private Button ule0bU093D;

	private string uVs0M7XkAb;

	private string JdI0OsOr4l;

	private DateTime wSD0IM5GAL;

	private int orw07WAlEJ;

	private int BGf0qb0euK;

	private int gyU0aPn8IE;

	private int TAf084KA8Y;

	private string snn0NmaXbA;

	private string cAf0FUUQie;

	private object[,] LTL0QdA8jF;

	private object[,] PsC0PsmPuX;

	private object[,] N6S0c6J1rv;

	private int pV00K6n9YB;

	private bool hNk0eP7Sy2;

	private List<int> Ob802ITZ5B;

	internal virtual Button btApagar
	{
		[CompilerGenerated]
		get
		{
			return vin0hQnTQb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Jdo5UK5mw7;
			Button button = vin0hQnTQb;
			if (button != null)
			{
				button.Click -= value2;
			}
			vin0hQnTQb = value;
			button = vin0hQnTQb;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return aTF0oNjDi8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = KW65Sw2qoO;
			DataGridView dataGridView = aTF0oNjDi8;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
			}
			aTF0oNjDi8 = value;
			dataGridView = aTF0oNjDi8;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
			}
		}
	}

	internal virtual Label LabelQuantidade
	{
		[CompilerGenerated]
		get
		{
			return EJ70GdIeFi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EJ70GdIeFi = value;
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return VVm0HXlFBE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oye5mXAr3p;
			Button button = VVm0HXlFBE;
			if (button != null)
			{
				button.Click -= value2;
			}
			VVm0HXlFBE = value;
			button = VVm0HXlFBE;
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
			return aRi0kY4kgr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ONi5X2FhSc;
			Button button = aRi0kY4kgr;
			if (button != null)
			{
				button.Click -= value2;
			}
			aRi0kY4kgr = value;
			button = aRi0kY4kgr;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBNome
	{
		[CompilerGenerated]
		get
		{
			return IAm0d5DD3f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = b660paA9XQ;
			TextBox textBox = IAm0d5DD3f;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			IAm0d5DD3f = value;
			textBox = IAm0d5DD3f;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual DataGridView dgH
	{
		[CompilerGenerated]
		get
		{
			return nqM0fAE4wQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = WkX54G9S8m;
			DataGridView dataGridView = nqM0fAE4wQ;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
			}
			nqM0fAE4wQ = value;
			dataGridView = nqM0fAE4wQ;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
			}
		}
	}

	internal virtual Label LabelQuantidadeH
	{
		[CompilerGenerated]
		get
		{
			return wmg0Dy3F9D;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wmg0Dy3F9D = value;
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return NGq0vZXQ9j;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aMc5Aj57aW;
			Button button = NGq0vZXQ9j;
			if (button != null)
			{
				button.Click -= value2;
			}
			NGq0vZXQ9j = value;
			button = NGq0vZXQ9j;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btUsados
	{
		[CompilerGenerated]
		get
		{
			return BQV0615LfF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qZo5yY2G3P;
			Button button = BQV0615LfF;
			if (button != null)
			{
				button.Click -= value2;
			}
			BQV0615LfF = value;
			button = BQV0615LfF;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btUsadosH
	{
		[CompilerGenerated]
		get
		{
			return svr0t4NDOv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lPq5gWRx1N;
			Button button = svr0t4NDOv;
			if (button != null)
			{
				button.Click -= value2;
			}
			svr0t4NDOv = value;
			button = svr0t4NDOv;
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
			return fTC0jgO9T8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qCa5zIGTil;
			Button button = fTC0jgO9T8;
			if (button != null)
			{
				button.Click -= value2;
			}
			fTC0jgO9T8 = value;
			button = fTC0jgO9T8;
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
			return BOJ0LQsKgw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = R9c0WoBJY2;
			Button button = BOJ0LQsKgw;
			if (button != null)
			{
				button.Click -= value2;
			}
			BOJ0LQsKgw = value;
			button = BOJ0LQsKgw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btModelosPN
	{
		[CompilerGenerated]
		get
		{
			return WMN0wMCwDo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uR359rDcn5;
			Button button = WMN0wMCwDo;
			if (button != null)
			{
				button.Click -= value2;
			}
			WMN0wMCwDo = value;
			button = WMN0wMCwDo;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return Q450xsIlef;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Q450xsIlef = value;
		}
	}

	internal virtual Button btApagarPaineisHistorico
	{
		[CompilerGenerated]
		get
		{
			return ule0bU093D;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = a6k0TKKmn2;
			Button button = ule0bU093D;
			if (button != null)
			{
				button.Click -= value2;
			}
			ule0bU093D = value;
			button = ule0bU093D;
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
			if (disposing && OMt0J85FYc != null)
			{
				OMt0J85FYc.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void my15RwGaTg()
	{
		btApagar = new Button();
		dg = new DataGridView();
		LabelQuantidade = new Label();
		btInserir = new Button();
		btEditar = new Button();
		TBNome = new TextBox();
		dgH = new DataGridView();
		LabelQuantidadeH = new Label();
		btSalvar = new Button();
		btUsados = new Button();
		btUsadosH = new Button();
		btExportar = new Button();
		btImportar = new Button();
		btModelosPN = new Button();
		GroupBox1 = new GroupBox();
		btApagarPaineisHistorico = new Button();
		((ISupportInitialize)dg).BeginInit();
		((ISupportInitialize)dgH).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(330, 17);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(38, 38);
		btApagar.TabIndex = 4;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToOrderColumns = true;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dg.BorderStyle = BorderStyle.Fixed3D;
		dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(10, 23);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(330, 259);
		dg.TabIndex = 1;
		LabelQuantidade.BorderStyle = BorderStyle.Fixed3D;
		LabelQuantidade.ImageAlign = ContentAlignment.MiddleLeft;
		LabelQuantidade.Location = new Point(10, 5);
		LabelQuantidade.Name = "LabelQuantidade";
		LabelQuantidade.Size = new Size(292, 17);
		LabelQuantidade.TabIndex = 9;
		LabelQuantidade.Text = "Label1";
		LabelQuantidade.TextAlign = ContentAlignment.MiddleCenter;
		btInserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.Adiciona_32;
		btInserir.Location = new Point(248, 17);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(38, 38);
		btInserir.TabIndex = 10;
		btInserir.UseVisualStyleBackColor = true;
		btEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btEditar.FlatStyle = FlatStyle.Flat;
		btEditar.ForeColor = SystemColors.Control;
		btEditar.Image = Resources.Editar;
		btEditar.Location = new Point(289, 18);
		btEditar.Name = "btEditar";
		btEditar.Size = new Size(38, 38);
		btEditar.TabIndex = 11;
		btEditar.UseVisualStyleBackColor = true;
		TBNome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBNome.Location = new Point(12, 27);
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(119, 20);
		TBNome.TabIndex = 13;
		dgH.AllowUserToAddRows = false;
		dgH.AllowUserToDeleteRows = false;
		dgH.AllowUserToOrderColumns = true;
		dgH.AllowUserToResizeRows = false;
		dgH.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgH.BorderStyle = BorderStyle.Fixed3D;
		dgH.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgH.Location = new Point(350, 23);
		dgH.MultiSelect = false;
		dgH.Name = "dgH";
		dgH.ReadOnly = true;
		dgH.RowHeadersVisible = false;
		dgH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgH.Size = new Size(330, 259);
		dgH.TabIndex = 14;
		LabelQuantidadeH.BorderStyle = BorderStyle.Fixed3D;
		LabelQuantidadeH.Location = new Point(350, 5);
		LabelQuantidadeH.Name = "LabelQuantidadeH";
		LabelQuantidadeH.Size = new Size(292, 17);
		LabelQuantidadeH.TabIndex = 15;
		LabelQuantidadeH.Text = "Label2";
		LabelQuantidadeH.TextAlign = ContentAlignment.MiddleCenter;
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(642, 305);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(38, 38);
		btSalvar.TabIndex = 16;
		btSalvar.UseVisualStyleBackColor = true;
		btUsados.Location = new Point(309, 4);
		btUsados.Name = "btUsados";
		btUsados.Size = new Size(32, 19);
		btUsados.TabIndex = 17;
		btUsados.Text = "- - -";
		btUsados.UseVisualStyleBackColor = true;
		btUsadosH.Location = new Point(647, 5);
		btUsadosH.Name = "btUsadosH";
		btUsadosH.Size = new Size(32, 19);
		btUsadosH.TabIndex = 18;
		btUsadosH.Text = "- - -";
		btUsadosH.UseVisualStyleBackColor = true;
		btExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportar.FlatStyle = FlatStyle.Flat;
		btExportar.ForeColor = SystemColors.Control;
		btExportar.Image = Resources.ExportaExcel_20;
		btExportar.Location = new Point(184, 15);
		btExportar.Name = "btExportar";
		btExportar.Size = new Size(30, 38);
		btExportar.TabIndex = 188;
		btExportar.UseVisualStyleBackColor = true;
		btImportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.ImportaExcel_20;
		btImportar.Location = new Point(217, 15);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(30, 38);
		btImportar.TabIndex = 187;
		btImportar.UseVisualStyleBackColor = true;
		btModelosPN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btModelosPN.FlatStyle = FlatStyle.Flat;
		btModelosPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btModelosPN.ForeColor = SystemColors.Control;
		btModelosPN.Image = Resources.Excel_32;
		btModelosPN.Location = new Point(143, 15);
		btModelosPN.Name = "btModelosPN";
		btModelosPN.Size = new Size(38, 38);
		btModelosPN.TabIndex = 189;
		btModelosPN.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(btApagarPaineisHistorico);
		GroupBox1.Controls.Add(TBNome);
		GroupBox1.Controls.Add(btModelosPN);
		GroupBox1.Controls.Add(btApagar);
		GroupBox1.Controls.Add(btExportar);
		GroupBox1.Controls.Add(btInserir);
		GroupBox1.Controls.Add(btImportar);
		GroupBox1.Controls.Add(btEditar);
		GroupBox1.Location = new Point(9, 288);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(417, 65);
		GroupBox1.TabIndex = 190;
		GroupBox1.TabStop = false;
		btApagarPaineisHistorico.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btApagarPaineisHistorico.FlatStyle = FlatStyle.Flat;
		btApagarPaineisHistorico.ForeColor = SystemColors.Control;
		btApagarPaineisHistorico.Image = Resources.Apagador_32;
		btApagarPaineisHistorico.Location = new Point(373, 18);
		btApagarPaineisHistorico.Name = "btApagarPaineisHistorico";
		btApagarPaineisHistorico.Size = new Size(38, 38);
		btApagarPaineisHistorico.TabIndex = 190;
		btApagarPaineisHistorico.Tag = "";
		btApagarPaineisHistorico.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(689, 361);
		Controls.Add(GroupBox1);
		Controls.Add(btUsadosH);
		Controls.Add(btUsados);
		Controls.Add(LabelQuantidadeH);
		Controls.Add(dg);
		Controls.Add(LabelQuantidade);
		Controls.Add(btSalvar);
		Controls.Add(dgH);
		MinimumSize = new Size(515, 400);
		Name = "frmCadastroDePaineis";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Cadastro de Paineis";
		((ISupportInitialize)dg).EndInit();
		((ISupportInitialize)dgH).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	public frmCadastroDePaineis()
	{
		Resize += yFy5r7FxdF;
		hNk0eP7Sy2 = false;
		Ob802ITZ5B = new List<int>();
		checked
		{
			if (!Geral.ExisteForm("frmCadastroDePaineis"))
			{
				my15RwGaTg();
				LTL0QdA8jF = new object[2, 1];
				LTL0QdA8jF[0, 0] = "INDICE";
				LTL0QdA8jF[1, 0] = "PAINEL";
				hNk0eP7Sy2 = true;
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 531]);
				ToolTip toolTip = new ToolTip();
				toolTip.AutoPopDelay = 5000;
				toolTip.InitialDelay = 1000;
				toolTip.ReshowDelay = 500;
				toolTip.ShowAlways = true;
				toolTip.SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1086]));
				toolTip.SetToolTip(btEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1087]));
				toolTip.SetToolTip(btApagarPaineisHistorico, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1729]));
				toolTip.SetToolTip(btApagar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1088]));
				toolTip.SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1089]));
				toolTip.SetToolTip(btUsados, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1090]));
				toolTip.SetToolTip(btUsadosH, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1090]));
				toolTip.SetToolTip(btModelosPN, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1606]));
				toolTip.SetToolTip(btExportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1382]));
				toolTip.SetToolTip(btImportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1383]));
				GroupBox1.Enabled = false;
				uVs0M7XkAb = Environment.UserName;
				JdI0OsOr4l = Environment.UserName;
				wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
				Application.ShowModelessDialog((Form)this);
				Carregar(bCarrega: true);
				int num = dgH.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgH.Rows[i].Selected = false;
				}
			}
		}
	}

	public void Carregar(bool bCarrega)
	{
		VerificaPaineis();
		if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
		{
			Left = 0;
		}
		ref object[,] lTL0QdA8jF = ref LTL0QdA8jF;
		object mPaineis = lTL0QdA8jF;
		clsPainel.PaineisDocumento(ref mPaineis);
		lTL0QdA8jF = (object[,])mPaineis;
		DataGridView withEventsValue = dg;
		cDadosAccess.carregaPNDG(ref withEventsValue, "Paineis");
		dg = withEventsValue;
		withEventsValue = dgH;
		cDadosAccess.carregaPNDG(ref withEventsValue, "PaineisH");
		dgH = withEventsValue;
		AtualizaPnUsados();
		AtualizaDGs();
		zGw5YTPUdj(dg);
		GroupBox1.Enabled = true;
		PaineisDuplicados(bCarrega);
	}

	public void PaineisDuplicados(bool bCarrega)
	{
		new List<int>();
		checked
		{
			int num = dg.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				dg[1, i].ErrorText = "";
			}
			int num2 = -1;
			int num3 = dg.RowCount - 1;
			for (int j = 0; j <= num3; j++)
			{
				string text = "";
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[1].Value)))
				{
					text = Conversions.ToString(dg.Rows[j].Cells[1].Value);
				}
				Conversions.ToInteger(dg.Rows[j].Cells[0].Value);
				if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
				{
					dg[1, j].ErrorText = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1885]);
					if (num2 == -1)
					{
						num2 = j;
					}
				}
				int num4 = dg.RowCount - 1;
				for (int k = 0; k <= num4; k++)
				{
					if (j != k && Operators.CompareString(text, clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[1].Value)), TextCompare: true) == 0)
					{
						dg[1, k].ErrorText = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 956]);
						dg[1, j].ErrorText = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 956]);
						if (num2 == -1)
						{
							num2 = j;
						}
					}
				}
			}
			if (bCarrega && num2 != -1)
			{
				dg.Rows[num2].Selected = true;
				dg.FirstDisplayedScrollingRowIndex = num2;
			}
		}
	}

	private void oye5mXAr3p(object P_0, EventArgs P_1)
	{
		string text = TBNome.Text.Trim();
		if (Operators.CompareString(text, "", TextCompare: true) == 0)
		{
			return;
		}
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		checked
		{
			try
			{
				DataGridView withEventsValue = dg;
				bool flag = EncontraNoDG(ref withEventsValue, text, ref pV00K6n9YB);
				dg = withEventsValue;
				if (!flag)
				{
					withEventsValue = dgH;
					bool flag2 = EncontraNoDG(ref withEventsValue, text, ref pV00K6n9YB);
					dgH = withEventsValue;
					if (!flag2)
					{
						DataGridView Dg = dg;
						withEventsValue = dgH;
						excPaineis.AdicionaNovoPainelNoDG(ref Dg, ref withEventsValue, text);
						dgH = withEventsValue;
						dg = Dg;
					}
					else
					{
						int num = dgH.Rows.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(dgH[1, i].Value, null, "ToUpper", new object[0], null, null, null), text.ToString().ToUpper(), TextCompare: true))
							{
								dgH.Rows[i].Selected = true;
							}
						}
						withEventsValue = dg;
						DataGridView Dg = dgH;
						excPaineis.AdicionaPainelisExcluidoDoDG(ref withEventsValue, ref Dg, text);
						dgH = Dg;
						dg = withEventsValue;
					}
					AtualizaPnUsados();
					AtualizaDGs();
					return;
				}
				int num2 = dg.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(dg[1, j].Value, null, "ToUpper", new object[0], null, null, null), text.ToString().ToUpper(), TextCompare: true))
					{
						dg.Rows[j].Selected = true;
						dg.FirstDisplayedScrollingRowIndex = j;
					}
				}
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 956]), MsgBoxStyle.Critical, "Eletron");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
				ProjectData.ClearProjectError();
			}
		}
	}

	private void ONi5X2FhSc(object P_0, EventArgs P_1)
	{
		string text = TBNome.Text.Trim();
		if (Operators.CompareString(text, "", TextCompare: true) == 0)
		{
			return;
		}
		int num = -1;
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		try
		{
			DataGridView withEventsValue = dg;
			bool flag = EncontraNoDG(ref withEventsValue, text, ref pV00K6n9YB);
			dg = withEventsValue;
			if (!flag)
			{
				withEventsValue = dgH;
				bool flag2 = EncontraNoDG(ref withEventsValue, text, ref pV00K6n9YB);
				dgH = withEventsValue;
				if (!flag2)
				{
					JJq5u9FFDK(text);
				}
				else
				{
					string text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 958], text), DeclaracoesGeral.mMensagem[1, 1171]), "\r\n"), DeclaracoesGeral.mMensagem[1, 1185]));
					text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(text2 + "\r\n\r\n", DeclaracoesGeral.mMensagem[1, 1186]), pV00K6n9YB), DeclaracoesGeral.mMensagem[1, 1187]));
					num = (int)Interaction.MsgBox(text2, MsgBoxStyle.YesNo);
					if (num == 6)
					{
						mnM5E9Tnfl(text);
						JJq5u9FFDK(text);
						cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
						cDadosAccessPaineis2.ApagaPainel("PaineisH", pV00K6n9YB);
						cDadosAccessPaineis2.fechaConexao();
						cDadosAccessDuplicaCaderno cDadosAccessDuplicaCaderno2 = new cDadosAccessDuplicaCaderno();
						List<int> lDisp = new List<int>();
						List<int> lMasc = new List<int>();
						cDadosAccessDuplicaCaderno2.BuscaIndicesFiacao(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice, ref lDisp, ref lMasc);
						cDadosAccessDuplicaCaderno2.ApagaFiacao(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice);
						cDadosAccessDuplicaCaderno2.ApagaContatos4F(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice, lDisp);
						cDadosAccessDuplicaCaderno2.ApagaCircuitos4F(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice);
						cDadosAccessDuplicaCaderno2.ApagaPortas4F(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice, lMasc);
						cDadosAccessDuplicaCaderno2.ApagaDispositivos4F(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice);
						cDadosAccessDuplicaCaderno2.ApagaBornes4F(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice);
						cDadosAccessDuplicaCaderno2.ApagaVarios3(pV00K6n9YB, DeclaracoesGeral.arqAtivo.Indice);
						cDadosAccessDuplicaCaderno2.fechaConexao();
					}
				}
				VerificaPaineis();
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 956]), MsgBoxStyle.Critical, "Eletron");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	private void Jdo5UK5mw7(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				string text = snn0NmaXbA;
				DataGridView withEventsValue = dg;
				DataGridView withEventsValue2 = dgH;
				xen5ZoB6rl(text, ref withEventsValue, ref withEventsValue2);
				dgH = withEventsValue2;
				dg = withEventsValue;
				AtualizaPnUsados();
				AtualizaDGs();
				int num = dgH.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgH.Rows[i].Selected = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
				ProjectData.ClearProjectError();
			}
		}
	}

	private void qZo5yY2G3P(object P_0, EventArgs P_1)
	{
		zGw5YTPUdj(dg);
	}

	private void lPq5gWRx1N(object P_0, EventArgs P_1)
	{
		zGw5YTPUdj(dgH);
	}

	private void aMc5Aj57aW(object P_0, EventArgs P_1)
	{
		string text = "";
		string text2 = "";
		object value = "";
		checked
		{
			try
			{
				List<int> list = new List<int>();
				DeclaracoesGeral._uscPagina.Quantidade = dg.Rows.Count + dgH.Rows.Count;
				DeclaracoesGeral._uscPagina.pbIniciar();
				cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
				int num = dg.Rows.Count - 1;
				bool flag = default;
				for (int i = 0; i <= num; i++)
				{
					text = "";
					text2 = Environment.UserName;
					wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
					int num2 = 0;
					int num3 = Conversions.ToInteger(dg.Rows[i].Cells[0].Value);
					string text3 = Conversions.ToString(dg.Rows[i].Cells[1].Value);
					if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						text = Conversions.ToString(dg.Rows[i].Cells[2].Value);
					}
					if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[9].Value)))
					{
						num2 = Conversions.ToInteger(dg.Rows[i].Cells[9].Value);
					}
					if (Operators.CompareString(dg.Rows[i].Cells[3].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						text2 = Conversions.ToString(dg.Rows[i].Cells[3].Value);
						if (Operators.CompareString(dg.Rows[i].Cells[4].Value.ToString().Trim(), "", TextCompare: true) != 0)
						{
							value = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[4].Value);
							flag = Conversions.ToBoolean(dg.Rows[i].Cells[5].Value);
						}
					}
					bool flag2 = Conversions.ToBoolean(dg.Rows[i].Cells[6].Value);
					Conversions.ToBoolean(dg.Rows[i].Cells[7].Value);
					bool flag3 = Conversions.ToBoolean(dg.Rows[i].Cells[8].Value);
					if (flag2)
					{
						cDadosAccessPaineis2.ApagaPainel("Paineis", num3);
						cDadosAccessPaineis2.AdicionaPainel("Paineis", num3, text3, text, text2, Conversions.ToDate(value));
						cDadosAccessPaineis2.ApagaPainel("PaineisH", num3);
						if (num2 > 0)
						{
							cDadosAccessPaineis2.ApagaPainel("PaineisH", num2);
						}
					}
					if (flag3)
					{
						cDadosAccessPaineis2.ApagaPainel("Paineis", num3);
						cDadosAccessPaineis2.AdicionaPainel("Paineis", num3, text3, text, text2, Conversions.ToDate(value));
						if (flag)
						{
							clsPainel.AtualizaBornes(num3, text3);
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				cDadosAccessPaineis2.fechaConexao();
				int num4 = dgH.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					text = "";
					text2 = "";
					value = "";
					int num3 = Conversions.ToInteger(dgH.Rows[j].Cells[0].Value);
					string text3 = Conversions.ToString(dgH.Rows[j].Cells[1].Value);
					if (Operators.CompareString(dgH.Rows[j].Cells[2].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						text = Conversions.ToString(dgH.Rows[j].Cells[2].Value);
					}
					if (Operators.CompareString(dgH.Rows[j].Cells[3].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						text2 = Conversions.ToString(dgH.Rows[j].Cells[3].Value);
						if (Operators.CompareString(dgH.Rows[j].Cells[4].Value.ToString().Trim(), "", TextCompare: true) != 0)
						{
							value = RuntimeHelpers.GetObjectValue(dgH.Rows[j].Cells[4].Value);
							flag = Conversions.ToBoolean(dgH.Rows[j].Cells[5].Value);
							bool flag2 = Conversions.ToBoolean(dgH.Rows[j].Cells[6].Value);
							Conversions.ToBoolean(dgH.Rows[j].Cells[7].Value);
							bool flag3 = Conversions.ToBoolean(dgH.Rows[j].Cells[8].Value);
						}
					}
					cDadosAccessDuplicaCaderno cDadosAccessDuplicaCaderno2 = new cDadosAccessDuplicaCaderno();
					List<int> lDisp = new List<int>();
					List<int> lMasc = new List<int>();
					cDadosAccessDuplicaCaderno2.BuscaIndicesFiacao(num3, DeclaracoesGeral.arqAtivo.Indice, ref lDisp, ref lMasc);
					cDadosAccessDuplicaCaderno2.ApagaFiacao(num3, DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaContatos4F(num3, DeclaracoesGeral.arqAtivo.Indice, lDisp);
					cDadosAccessDuplicaCaderno2.ApagaCircuitos4F(num3, DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaPortas4F(num3, DeclaracoesGeral.arqAtivo.Indice, lMasc);
					cDadosAccessDuplicaCaderno2.ApagaDispositivos4F(num3, DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaBornes4F(num3, DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.ApagaVarios3(num3, DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessDuplicaCaderno2.fechaConexao();
					cDadosAccessPaineis2 = new cDadosAccessPaineis();
					cDadosAccessPaineis2.ApagaPainel("PaineisH", num3);
					cDadosAccessPaineis2.AdicionaPainel("PaineisH", num3, text3, text, text2, Conversions.ToDate(value));
					cDadosAccessPaineis2.ApagaPainel("Paineis", num3);
					cDadosAccessPaineis2.fechaConexao();
					if (flag && !list.Contains(num3))
					{
						list.Add(num3);
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DeclaracoesGeral._uscPagina.pbFim();
				if (list.Count > 0)
				{
					clsPainel.ApagaPaineisDocumento(list);
				}
				cDadosAccessPaineis2 = new cDadosAccessPaineis();
				foreach (int item in Ob802ITZ5B)
				{
					cDadosAccessPaineis2.ApagaPainel("PaineisH", item);
					cDadosAccessPaineis2.ApagaPainel("Paineis", item);
				}
				cDadosAccessPaineis2.fechaConexao();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
			Carregar(bCarrega: true);
			Close();
			clsUtilitarios.EditaPortaDipAuxPainelModeloFabricante();
			cDadosAccess.carregaPainelDicionario();
			clsUtilitarios.CorrigePainelET1DosBornes();
		}
	}

	public void AtualizaPnUsados()
	{
		VerificaPaineis();
		ref object[,] lTL0QdA8jF = ref LTL0QdA8jF;
		object mPainelOrigem = lTL0QdA8jF;
		MarcaPaineisUsados(ref mPainelOrigem);
		lTL0QdA8jF = (object[,])mPainelOrigem;
		AtualizaDGs();
		checked
		{
			int num = dgH.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dgH.Rows[i].Selected = false;
			}
		}
	}

	public void AdicionaNomeDePaineisNaMatriz()
	{
		int num = Information.UBound(LTL0QdA8jF, 2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(PsC0PsmPuX, 2);
				for (int j = 1; j <= num2; j++)
				{
					if (Conversions.ToInteger(PsC0PsmPuX[0, j]) == Conversions.ToInteger(LTL0QdA8jF[0, i]))
					{
						LTL0QdA8jF[1, i] = RuntimeHelpers.GetObjectValue(PsC0PsmPuX[1, j]);
						break;
					}
				}
			}
		}
	}

	public void MarcaPaineisUsados(ref object mPainelOrigem)
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.White;
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = 0;
				do
				{
					dg[num2, i].Style = dataGridViewCellStyle2;
					num2++;
				}
				while (num2 <= 4);
				int num3 = Information.UBound((Array)mPainelOrigem, 2);
				for (int j = 1; j <= num3; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dg[0, i].Value, NewLateBinding.LateIndexGet(mPainelOrigem, new object[2] { 0, j }, null).ToString(), TextCompare: true))
					{
						int num4 = 0;
						do
						{
							dg[num4, i].Style = dataGridViewCellStyle;
							num4++;
						}
						while (num4 <= 4);
						dg.Rows[i].Cells[5].Value = true;
						break;
					}
				}
			}
			int num5 = dgH.Rows.Count - 1;
			for (int k = 0; k <= num5; k++)
			{
				int num6 = 0;
				do
				{
					dgH[num6, k].Style = dataGridViewCellStyle2;
					num6++;
				}
				while (num6 <= 4);
				int num7 = Information.UBound((Array)mPainelOrigem, 2);
				for (int l = 1; l <= num7; l++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgH[0, k].Value, NewLateBinding.LateIndexGet(mPainelOrigem, new object[2] { 0, l }, null).ToString(), TextCompare: true))
					{
						int num8 = 0;
						do
						{
							dgH[num8, k].Style = dataGridViewCellStyle;
							num8++;
						}
						while (num8 <= 4);
						dgH.Rows[k].Cells[5].Value = true;
						break;
					}
				}
			}
		}
	}

	private void IQO5sCFVqY(ref DataGridView P_0, ref object P_1)
	{
		try
		{
			P_0.Columns[0].ReadOnly = false;
			P_0.Columns[1].ReadOnly = false;
			P_0.Columns[2].ReadOnly = false;
			P_0.Columns[3].ReadOnly = false;
			P_0.Columns[4].ReadOnly = false;
			P_0.MultiSelect = false;
			int num = Information.UBound((Array)P_1, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				P_0.Rows.Add(Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, i }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 1, i }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 2, i }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 3, i }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 4, i }, null)));
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

	public static void AtualizaDG(ref DataGridView dgSel)
	{
		checked
		{
			if (dgSel.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgSel)) ? ((double)(dgSel.Width - 4)) : ((double)(dgSel.Width - 21)));
				dgSel.Columns[0].Width = (int)Math.Round(num * 0.16);
				dgSel.Columns[1].Width = (int)Math.Round(num * 0.3);
				dgSel.Columns[2].Width = (int)Math.Round(num * 0.18);
				dgSel.Columns[3].Width = (int)Math.Round(num * 0.18);
				dgSel.Columns[4].Width = (int)Math.Round(num * 0.18);
				dgSel.Columns[5].Width = 0;
				dgSel.Columns[5].Visible = false;
				dgSel.Columns[6].Width = 0;
				dgSel.Columns[6].Visible = false;
				dgSel.Columns[7].Width = 0;
				dgSel.Columns[7].Visible = false;
				dgSel.Columns[8].Width = 0;
				dgSel.Columns[8].Visible = false;
				dgSel.Columns[9].Width = 0;
				dgSel.Columns[9].Visible = false;
			}
		}
	}

	private int A0k5B6QY4u(ref DataGridView P_0)
	{
		int result = -1;
		checked
		{
			int num = P_0.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (P_0.Rows[i].Selected)
				{
					result = Conversions.ToInteger(P_0.Rows[i].Cells[0].Value);
					break;
				}
			}
			return result;
		}
	}

	private int NxH5VZJhfk(ref DataGridView P_0)
	{
		int result = -1;
		checked
		{
			int num = P_0.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (P_0.Rows[i].Selected)
				{
					result = i;
					break;
				}
			}
			return result;
		}
	}

	public bool EncontraNoDG(ref DataGridView dg, string sNome, ref int iPn)
	{
		bool result = false;
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(dg[1, i].Value, null, "ToUpper", new object[0], null, null, null), sNome.ToString().ToUpper(), TextCompare: true))
				{
					iPn = Conversions.ToInteger(dg[0, i].Value);
					result = true;
					break;
				}
			}
			return result;
		}
	}

	private void JJq5u9FFDK(string P_0)
	{
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		checked
		{
			try
			{
				int num = dg.Rows.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (dg.Rows[num2].Selected)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				dg.Rows[num2].Cells[1].Value = P_0;
				dg.Rows[num2].Cells[3].Value = JdI0OsOr4l;
				dg.Rows[num2].Cells[4].Value = wSD0IM5GAL;
				dg.Rows[num2].Cells[8].Value = true;
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

	private void mnM5E9Tnfl(string P_0)
	{
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		checked
		{
			try
			{
				int num = dgH.Rows.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (Operators.CompareString(dgH.Rows[num2].Cells[1].Value.ToString().ToUpper(), P_0.ToString().ToUpper(), TextCompare: true) == 0)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				dgH.Rows.RemoveAt(num2);
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

	private void xen5ZoB6rl(string P_0, ref DataGridView P_1, ref DataGridView P_2)
	{
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		checked
		{
			try
			{
				int num = P_1.Rows.Count - 1;
				int num2 = 0;
				string right;
				while (true)
				{
					if (num2 <= num)
					{
						right = Conversions.ToString(P_1.Rows[num2].Cells[1].Value);
						if (P_1.Rows[num2].Selected)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				if (Operators.ConditionalCompareObjectEqual(P_1.Rows[num2].Cells[5].Value, false, TextCompare: true))
				{
					MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 958], right), DeclaracoesGeral.mMensagem[1, 959]), MsgBoxStyle.YesNo);
					if (msgBoxResult == MsgBoxResult.No)
					{
						return;
					}
				}
				P_2.Rows.Add(P_1.Rows[num2].Cells[0].Value, P_1.Rows[num2].Cells[1].Value, P_1.Rows[num2].Cells[2].Value, JdI0OsOr4l, wSD0IM5GAL, P_1.Rows[num2].Cells[5].Value, false, true, false);
				P_1.Rows.RemoveAt(num2);
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

	private void xBK5ikxXt9(ref DataGridView P_0, ref object P_1, string P_2)
	{
		checked
		{
			try
			{
				int num = Information.UBound((Array)P_1, 2);
				int num2 = 1;
				while (true)
				{
					if (num2 <= num)
					{
						if (Operators.CompareString(NewLateBinding.LateIndexGet(P_1, new object[2] { 1, num2 }, null).ToString(), P_2, TextCompare: true) == 0)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				P_0.Rows.Add(Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, num2 }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 1, num2 }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 2, num2 }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 3, num2 }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 4, num2 }, null)));
				P_0.Rows.RemoveAt(num2 - 1);
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

	public void EditaPainel(ref object mPainel, string sNomeSelecionado, string sNome)
	{
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		int num = Information.UBound(PsC0PsmPuX, 2);
		int num2 = 1;
		while (true)
		{
			if (num2 <= num)
			{
				if (Operators.ConditionalCompareObjectEqual(PsC0PsmPuX[1, num2], sNomeSelecionado, TextCompare: true))
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return;
		}
		NewLateBinding.LateIndexSet(mPainel, new object[3] { 1, num2, sNome }, null);
		NewLateBinding.LateIndexSet(mPainel, new object[3] { 3, num2, JdI0OsOr4l }, null);
		NewLateBinding.LateIndexSet(mPainel, new object[3] { 4, num2, wSD0IM5GAL }, null);
	}

	public void VerificaPaineis()
	{
		LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dg.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
		if (dg.Rows.Count >= 1)
		{
			LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dg.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1085]));
		}
		LabelQuantidadeH.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgH.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
		if (dgH.Rows.Count >= 1)
		{
			LabelQuantidadeH.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgH.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1085]));
		}
		TBNome.Text = "";
	}

	public void AdicionaPainel(ref object mPainel, string sNomePainel)
	{
		int num = 0;
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		int num2 = Information.UBound(PsC0PsmPuX, 2);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (Operators.ConditionalCompareObjectLess(num, PsC0PsmPuX[0, i], TextCompare: true))
				{
					num = Conversions.ToInteger(PsC0PsmPuX[0, i]);
				}
			}
			int num3 = Information.UBound(N6S0c6J1rv, 2);
			for (int j = 1; j <= num3; j++)
			{
				if (Operators.ConditionalCompareObjectLess(num, N6S0c6J1rv[0, j], TextCompare: true))
				{
					num = Conversions.ToInteger(N6S0c6J1rv[0, j]);
				}
			}
			num++;
			int num4 = Information.UBound(N6S0c6J1rv, 2);
			for (int k = 1; k <= num4; k++)
			{
				if (Operators.ConditionalCompareObjectEqual(N6S0c6J1rv[1, k], sNomePainel, TextCompare: true))
				{
					num = Conversions.ToInteger(N6S0c6J1rv[0, k]);
					uVs0M7XkAb = Conversions.ToString(N6S0c6J1rv[2, k]);
					break;
				}
			}
			int num5 = Information.UBound(PsC0PsmPuX, 2);
			for (int l = 1; l <= num5; l++)
			{
				if (Operators.ConditionalCompareObjectEqual(PsC0PsmPuX[1, l], sNomePainel, TextCompare: true))
				{
					num = Conversions.ToInteger(PsC0PsmPuX[0, l]);
					uVs0M7XkAb = Conversions.ToString(PsC0PsmPuX[2, l]);
					break;
				}
			}
			mPainel = Utils.CopyArray((Array)mPainel, new object[5, Information.UBound((Array)mPainel, 2) + 1 + 1]);
			NewLateBinding.LateIndexSet(mPainel, new object[3]
			{
				0,
				Information.UBound((Array)mPainel, 2),
				num
			}, null);
			NewLateBinding.LateIndexSet(mPainel, new object[3]
			{
				1,
				Information.UBound((Array)mPainel, 2),
				sNomePainel
			}, null);
			NewLateBinding.LateIndexSet(mPainel, new object[3]
			{
				2,
				Information.UBound((Array)mPainel, 2),
				uVs0M7XkAb
			}, null);
			NewLateBinding.LateIndexSet(mPainel, new object[3]
			{
				3,
				Information.UBound((Array)mPainel, 2),
				JdI0OsOr4l
			}, null);
			NewLateBinding.LateIndexSet(mPainel, new object[3]
			{
				4,
				Information.UBound((Array)mPainel, 2),
				wSD0IM5GAL
			}, null);
		}
	}

	public void ApagaPainelis(string sNomePainel)
	{
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		int num = Information.UBound(PsC0PsmPuX, 2);
		int num2 = 1;
		checked
		{
			while (true)
			{
				if (num2 <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(PsC0PsmPuX[1, num2], sNomePainel, TextCompare: true))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			ref object[,] n6S0c6J1rv = ref N6S0c6J1rv;
			n6S0c6J1rv = (object[,])Utils.CopyArray(n6S0c6J1rv, new object[5, Information.UBound(N6S0c6J1rv, 2) + 1 + 1]);
			N6S0c6J1rv[0, Information.UBound(N6S0c6J1rv, 2)] = RuntimeHelpers.GetObjectValue(PsC0PsmPuX[0, num2]);
			N6S0c6J1rv[1, Information.UBound(N6S0c6J1rv, 2)] = RuntimeHelpers.GetObjectValue(PsC0PsmPuX[1, num2]);
			N6S0c6J1rv[2, Information.UBound(N6S0c6J1rv, 2)] = RuntimeHelpers.GetObjectValue(PsC0PsmPuX[2, num2]);
			N6S0c6J1rv[3, Information.UBound(N6S0c6J1rv, 2)] = JdI0OsOr4l;
			N6S0c6J1rv[4, Information.UBound(N6S0c6J1rv, 2)] = wSD0IM5GAL;
			int num3 = 0;
			do
			{
				PsC0PsmPuX[num3, num2] = "";
				num3++;
			}
			while (num3 <= 4);
		}
	}

	public void EditaPainel(ref object mPainel, string sNomePainel, ref DataGridView dg)
	{
		string right = "";
		wSD0IM5GAL = Conversions.ToDate(DateTime.Now.ToString());
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dg.Rows[i].Selected)
				{
					right = Conversions.ToString(dg.Rows[i].Cells[1].Value);
					break;
				}
			}
			int num2 = Information.UBound((Array)mPainel, 2);
			int num3 = 1;
			while (true)
			{
				if (num3 <= num2)
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPainel, new object[2] { 1, num3 }, null), right, TextCompare: true))
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			NewLateBinding.LateIndexSet(mPainel, new object[3] { 1, num3, sNomePainel }, null);
			NewLateBinding.LateIndexSet(mPainel, new object[3] { 3, num3, JdI0OsOr4l }, null);
			NewLateBinding.LateIndexSet(mPainel, new object[3] { 4, num3, wSD0IM5GAL }, null);
		}
	}

	public void ApagaUmPainelDeletados(ref object mPainel)
	{
		checked
		{
			if (Information.UBound((Array)mPainel, 2) >= 2 && Information.UBound((Array)mPainel, 2) > 0)
			{
				int num = Information.UBound((Array)mPainel, 2) - 1;
				for (int i = num; i >= 1; i += -1)
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(mPainel, new object[2] { 1, i }, null), null, "trim", new object[0], null, null, null), "", TextCompare: true))
					{
						int num2 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mPainel, new object[2]
							{
								num2,
								i + 1
							}, null));
							NewLateBinding.LateIndexSet(mPainel, new object[3]
							{
								num2,
								i + 1,
								NewLateBinding.LateIndexGet(mPainel, new object[2] { num2, i }, null)
							}, null);
							NewLateBinding.LateIndexSet(mPainel, new object[3] { num2, i, objectValue }, null);
							num2++;
						}
						while (num2 <= 4);
					}
				}
			}
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPainel, new object[2]
			{
				1,
				Information.UBound((Array)mPainel, 2)
			}, null), "", TextCompare: true))
			{
				mPainel = Utils.CopyArray((Array)mPainel, new object[5, Information.UBound((Array)mPainel, 2) - 1 + 1]);
			}
		}
	}

	public void ApagaUmPainelDaMatriz(ref object mPainel, string sNomePainel)
	{
		int num = Information.UBound((Array)mPainel, 2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPainel, new object[2] { 1, i }, null), sNomePainel, TextCompare: true))
				{
					int num2 = 0;
					do
					{
						NewLateBinding.LateIndexSet(mPainel, new object[3] { num2, i, "" }, null);
						num2++;
					}
					while (num2 <= 4);
					break;
				}
			}
			if (Information.UBound((Array)mPainel, 2) >= 2 && Information.UBound((Array)mPainel, 2) > 0)
			{
				int num3 = Information.UBound((Array)mPainel, 2) - 1;
				for (int j = num3; j >= 1; j += -1)
				{
					if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPainel, new object[2] { 1, j }, null), "", TextCompare: true))
					{
						continue;
					}
					int num4 = j;
					for (int k = 1; k <= num4; k++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(mPainel, new object[2] { 1, k }, null), "", TextCompare: true), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mPainel, new object[2]
						{
							1,
							k + 1
						}, null), "", TextCompare: true))))
						{
							int num5 = 0;
							do
							{
								object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mPainel, new object[2]
								{
									num5,
									k + 1
								}, null));
								NewLateBinding.LateIndexSet(mPainel, new object[3]
								{
									num5,
									k + 1,
									NewLateBinding.LateIndexGet(mPainel, new object[2] { num5, k }, null)
								}, null);
								NewLateBinding.LateIndexSet(mPainel, new object[3] { num5, k, objectValue }, null);
								num5++;
							}
							while (num5 <= 4);
						}
					}
				}
			}
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPainel, new object[2]
			{
				1,
				Information.UBound((Array)mPainel, 2)
			}, null), "", TextCompare: true))
			{
				mPainel = Utils.CopyArray((Array)mPainel, new object[5, Information.UBound((Array)mPainel, 2) - 1 + 1]);
			}
		}
	}

	private void KW65Sw2qoO(object P_0, MouseEventArgs P_1)
	{
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dg.Rows[i].Selected)
				{
					DataGridView withEventsValue = dg;
					int num2 = A0k5B6QY4u(ref withEventsValue);
					dg = withEventsValue;
					orw07WAlEJ = num2;
					withEventsValue = dg;
					int num3 = NxH5VZJhfk(ref withEventsValue);
					dg = withEventsValue;
					gyU0aPn8IE = num3;
					if (gyU0aPn8IE == -1)
					{
						break;
					}
					snn0NmaXbA = Conversions.ToString(dg.Rows[gyU0aPn8IE].Cells[1].Value);
					TBNome.Text = snn0NmaXbA;
				}
			}
		}
	}

	private void WkX54G9S8m(object P_0, MouseEventArgs P_1)
	{
		DataGridView withEventsValue = dgH;
		int bGf0qb0euK = A0k5B6QY4u(ref withEventsValue);
		dgH = withEventsValue;
		BGf0qb0euK = bGf0qb0euK;
		withEventsValue = dgH;
		int tAf084KA8Y = NxH5VZJhfk(ref withEventsValue);
		dgH = withEventsValue;
		TAf084KA8Y = tAf084KA8Y;
		if (TAf084KA8Y != -1)
		{
			cAf0FUUQie = Conversions.ToString(dgH.Rows[TAf084KA8Y].Cells[1].Value);
			TBNome.Text = cAf0FUUQie;
		}
	}

	private void uko5CifxDD()
	{
		PsC0PsmPuX = new object[5, 1];
		N6S0c6J1rv = new object[5, 1];
		PsC0PsmPuX[0, 0] = "Indice do Painel";
		PsC0PsmPuX[1, 0] = "Nome do Painel";
		PsC0PsmPuX[2, 0] = "Criador";
		PsC0PsmPuX[3, 0] = "Editor";
		PsC0PsmPuX[4, 0] = "Data";
		N6S0c6J1rv[0, 0] = "Indice do Painel";
		N6S0c6J1rv[1, 0] = "Nome do Painel";
		N6S0c6J1rv[2, 0] = "Criador";
		N6S0c6J1rv[3, 0] = "Editor";
		N6S0c6J1rv[4, 0] = "Data";
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				num = i + 1;
				ref object[,] psC0PsmPuX = ref PsC0PsmPuX;
				psC0PsmPuX = (object[,])Utils.CopyArray(psC0PsmPuX, new object[5, num + 1]);
				PsC0PsmPuX[0, num] = "";
				PsC0PsmPuX[1, num] = "";
				PsC0PsmPuX[2, num] = "";
				PsC0PsmPuX[3, num] = "";
				PsC0PsmPuX[4, num] = "";
				if (Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString().Trim(), "", TextCompare: true) != 0)
				{
					PsC0PsmPuX[0, num] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[0].Value);
				}
				if (Operators.CompareString(dg.Rows[i].Cells[1].Value.ToString().Trim(), "", TextCompare: true) != 0)
				{
					PsC0PsmPuX[1, num] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[1].Value);
				}
				if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString().Trim(), "", TextCompare: true) != 0)
				{
					PsC0PsmPuX[2, num] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[2].Value);
				}
				if (Operators.CompareString(dg.Rows[i].Cells[3].Value.ToString().Trim(), "", TextCompare: true) != 0)
				{
					PsC0PsmPuX[3, num] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[3].Value);
				}
				if (Operators.CompareString(dg.Rows[i].Cells[4].Value.ToString().Trim(), "", TextCompare: true) != 0)
				{
					PsC0PsmPuX[4, num] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[4].Value);
				}
			}
			int num3 = dgH.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgH.Rows[j].Cells[5].Value, true, TextCompare: true))
				{
					num = j + 1;
					ref object[,] n6S0c6J1rv = ref N6S0c6J1rv;
					n6S0c6J1rv = (object[,])Utils.CopyArray(n6S0c6J1rv, new object[5, num + 1]);
					N6S0c6J1rv[0, num] = "";
					N6S0c6J1rv[1, num] = "";
					N6S0c6J1rv[2, num] = "";
					N6S0c6J1rv[3, num] = "";
					N6S0c6J1rv[4, num] = "";
					if (Operators.CompareString(dgH.Rows[j].Cells[0].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						N6S0c6J1rv[0, num] = RuntimeHelpers.GetObjectValue(dgH.Rows[j].Cells[0].Value);
					}
					if (Operators.CompareString(dgH.Rows[j].Cells[1].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						N6S0c6J1rv[1, num] = RuntimeHelpers.GetObjectValue(dgH.Rows[j].Cells[1].Value);
					}
					if (Operators.CompareString(dgH.Rows[j].Cells[2].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						N6S0c6J1rv[2, num] = RuntimeHelpers.GetObjectValue(dgH.Rows[j].Cells[2].Value);
					}
					if (Operators.CompareString(dgH.Rows[j].Cells[3].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						N6S0c6J1rv[3, num] = RuntimeHelpers.GetObjectValue(dgH.Rows[j].Cells[3].Value);
					}
					if (Operators.CompareString(dgH.Rows[j].Cells[4].Value.ToString().Trim(), "", TextCompare: true) != 0)
					{
						N6S0c6J1rv[4, num] = RuntimeHelpers.GetObjectValue(dgH.Rows[j].Cells[4].Value);
					}
				}
			}
			AdicionaNomeDePaineisNaMatriz();
		}
	}

	public void CadastraPaineisNoBD()
	{
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(PsC0PsmPuX, 2) + Information.UBound(N6S0c6J1rv, 2) - 2;
			object[,] array = new object[2, 1]
			{
				{ "INDICE" },
				{ "PAINEL" }
			};
			bool flag = true;
			object mPaineis = array;
			cDadosAccess.carregaDadosPNs(ref mPaineis, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1085]));
			array = (object[,])mPaineis;
			cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
			int num = Information.UBound(PsC0PsmPuX, 2);
			for (int i = 1; i <= num; i++)
			{
				flag = true;
				int num2 = Information.UBound(array, 2);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(PsC0PsmPuX[0, i], array[0, j], TextCompare: true))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					int num3 = 0;
					string text = " ";
					string sCriador = " ";
					string sEditor = " ";
					DateTime sData = default;
					num3 = Conversions.ToInteger(PsC0PsmPuX[0, i]);
					text = Conversions.ToString(PsC0PsmPuX[1, i]);
					if (Operators.CompareString(PsC0PsmPuX[2, i].ToString().Trim(), "", TextCompare: true) != 0)
					{
						sCriador = Conversions.ToString(PsC0PsmPuX[2, i]);
					}
					if (Operators.CompareString(PsC0PsmPuX[3, i].ToString().Trim(), "", TextCompare: true) != 0)
					{
						sEditor = Conversions.ToString(PsC0PsmPuX[3, i]);
					}
					if (Operators.CompareString(PsC0PsmPuX[4, i].ToString().Trim(), "", TextCompare: true) != 0)
					{
						sData = Conversions.ToDate(PsC0PsmPuX[4, i]);
					}
					cDadosAccessPaineis2.AdicionaPainel("Paineis", num3, text, sCriador, sEditor, sData);
					cDadosAccessPaineis2.ApagaPainel("PaineisH", Conversions.ToInteger(PsC0PsmPuX[0, i]));
					DeclaracoesGeral._uscPagina.pbPasso();
				}
			}
			cDadosAccessPaineis2.fechaConexao();
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	private void zGw5YTPUdj(DataGridView P_0)
	{
		checked
		{
			if (P_0.Rows.Count >= 2)
			{
				int num = P_0.Rows.Count - 2;
				for (int i = num; i >= 0; i += -1)
				{
					int num2 = i;
					for (int j = 0; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectGreater(P_0[5, j].Value, P_0[5, j + 1].Value, TextCompare: true))
						{
							int num3 = 0;
							do
							{
								object objectValue = RuntimeHelpers.GetObjectValue(P_0[num3, j + 1].Value);
								P_0[num3, j + 1].Value = RuntimeHelpers.GetObjectValue(P_0[num3, j].Value);
								P_0[num3, j].Value = RuntimeHelpers.GetObjectValue(objectValue);
								num3++;
							}
							while (num3 <= 5);
						}
					}
				}
			}
			AtualizaPnUsados();
		}
	}

	private void yFy5r7FxdF(object P_0, EventArgs P_1)
	{
		if (hNk0eP7Sy2)
		{
			AtualizaDGs();
		}
	}

	public void AtualizaDGs()
	{
		DataGridView dgSel = dg;
		AtualizaDG(ref dgSel);
		dg = dgSel;
		dgSel = dgH;
		AtualizaDG(ref dgSel);
		dgH = dgSel;
		double num = Width;
		checked
		{
			if (dgH.Rows.Count <= 0)
			{
				dgH.Visible = false;
				LabelQuantidadeH.Visible = false;
				btUsadosH.Visible = false;
				dg.Width = (int)Math.Round(num - 35.0);
				btUsados.Location = new Point((int)Math.Round(num - 25.0 - (double)btUsados.Width), btUsados.Location.Y);
				LabelQuantidade.Width = btUsados.Location.X - 15;
			}
			else
			{
				dgH.Visible = true;
				LabelQuantidadeH.Visible = true;
				btUsadosH.Visible = true;
				dg.Width = (int)Math.Round((num - 30.0) / 2.0);
				dgH.Width = dg.Width;
				LabelQuantidadeH.Location = new Point(dgH.Location.X, LabelQuantidadeH.Location.Y);
				dgH.Location = new Point(dg.Width + 10, dg.Location.Y);
				btUsados.Location = new Point(dg.Width - btUsados.Width, btUsados.Location.Y);
				btUsadosH.Location = new Point(dg.Width + 10 + dgH.Width - btUsadosH.Width, btUsadosH.Location.Y);
				LabelQuantidade.Width = btUsados.Location.X - 15;
				LabelQuantidadeH.Width = LabelQuantidade.Width;
			}
		}
	}

	private void uR359rDcn5(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
		{
			ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
			excPaineis.ExportaModeloPaineisParaImportarOExcel(ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1085]));
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
	}

	private void qCa5zIGTil(object P_0, EventArgs P_1)
	{
		short num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.ConditionalCompareObjectLess(num, dg[0, i].Value, TextCompare: true))
				{
					num = Conversions.ToShort(dg[0, i].Value);
				}
			}
			int num3 = dgH.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if (Operators.ConditionalCompareObjectLess(num, dgH[0, j].Value, TextCompare: true))
				{
					num = Conversions.ToShort(dgH[0, j].Value);
				}
			}
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Workbook oBook = null;
			Worksheet oSheet = null;
			if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
			{
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				DataGridView withEventsValue = dg;
				excPaineis.ExportaPaineisParaOExcel(ref oSheet, ref withEventsValue, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1085]), num);
				dg = withEventsValue;
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
		}
	}

	private void R9c0WoBJY2(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		checked
		{
			int num = dgH.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				list.Add(dgH[1, i].Value.ToString().ToUpper());
			}
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Workbook oBook = null;
			Worksheet oSheet = null;
			if (ExcFuncoesExcel.VerificaExcelAtivoImportar(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false))
			{
				DataGridView withEventsValue = dg;
				DataGridView withEventsValue2 = dgH;
				excPaineis.VerificaImportaPaineis(ref oSheet, ref withEventsValue, ref withEventsValue2, list);
				dgH = withEventsValue2;
				dg = withEventsValue;
				int num2 = dg.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[8].Value, true, TextCompare: true))
					{
						btSalvar.Enabled = true;
						break;
					}
				}
			}
			AtualizaPnUsados();
			AtualizaDGs();
			zGw5YTPUdj(dg);
		}
	}

	private void b660paA9XQ(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = TBNome;
		clsTextos.NomeValido(ref tbNome);
		TBNome = tbNome;
	}

	private void a6k0TKKmn2(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				string text = "";
				int num = dgH.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? Conversions.ToString(dgH.Rows[i].Cells[1].Value) : Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(", ", dgH.Rows[i].Cells[1].Value))));
				}
				string text2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1720]);
				text2 = text2 + "\r\n\r\n" + text;
				MsgBoxResult msgBoxResult = Interaction.MsgBox(text2, MsgBoxStyle.YesNo);
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					text2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1283]);
					msgBoxResult = Interaction.MsgBox(text2, MsgBoxStyle.YesNo);
					if (msgBoxResult == MsgBoxResult.Yes)
					{
						int num2 = dgH.RowCount - 1;
						for (int j = num2; j >= 0; j += -1)
						{
							Ob802ITZ5B.Add(Conversions.ToInteger(dgH.Rows[j].Cells[0].Value));
							dgH.Rows.RemoveAt(j);
						}
					}
				}
				AtualizaPnUsados();
				AtualizaDGs();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
		}
	}
}
