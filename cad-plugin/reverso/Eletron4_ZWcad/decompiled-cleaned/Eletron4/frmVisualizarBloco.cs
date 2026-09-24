using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using YhamV21aratNE3b4GFK;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmVisualizarBloco : Form
{
	private IContainer X1qpnIxudw5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBL")]
	[CompilerGenerated]
	private DataGridView RdVpn7l99yZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip jJMpnqFpByd;

	[AccessedThroughProperty("GroupBoxDWG")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox eHmpnanWq7R;

	[AccessedThroughProperty("btViewBranco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button BOIpn8w62um;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btViewPreto")]
	private Button t0ipnNqFtyw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btViewColor")]
	private Button A8wpnFJowS8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("iDWG")]
	private PictureBox mwkpnQyxdfR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSeleciona")]
	private Button SDhpnPhPxOl;

	[AccessedThroughProperty("LbFiltro")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label I1Hpncjtb58;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBPesquisa")]
	private TextBox gf0pnKZHBrT;

	[AccessedThroughProperty("btLimpa")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button SZOpne0876m;

	private string ODwpn2Be4Ly;

	private string YMSpn3wMYPD;

	private object[,] DZdpnnSSF15;

	private bool CKSpn1TQjTh;

	internal virtual DataGridView dgBL
	{
		[CompilerGenerated]
		get
		{
			return RdVpn7l99yZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = h4mpntnreYM;
			KeyEventHandler value3 = TKRpnj4a7a9;
			KeyEventHandler value4 = JfhpnLMMiX3;
			EventHandler value5 = qxFpnOGLsN0;
			DataGridView dataGridView = RdVpn7l99yZ;
			if (dataGridView != null)
			{
				dataGridView.CellMouseUp -= value2;
				dataGridView.KeyDown -= value3;
				dataGridView.KeyUp -= value4;
				dataGridView.DoubleClick -= value5;
			}
			RdVpn7l99yZ = value;
			dataGridView = RdVpn7l99yZ;
			if (dataGridView != null)
			{
				dataGridView.CellMouseUp += value2;
				dataGridView.KeyDown += value3;
				dataGridView.KeyUp += value4;
				dataGridView.DoubleClick += value5;
			}
		}
	}

	internal virtual GroupBox GroupBoxDWG
	{
		[CompilerGenerated]
		get
		{
			return eHmpnanWq7R;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eHmpnanWq7R = value;
		}
	}

	internal virtual Button btViewBranco
	{
		[CompilerGenerated]
		get
		{
			return BOIpn8w62um;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BOIpn8w62um = value;
		}
	}

	internal virtual Button btViewPreto
	{
		[CompilerGenerated]
		get
		{
			return t0ipnNqFtyw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			t0ipnNqFtyw = value;
		}
	}

	internal virtual Button btViewColor
	{
		[CompilerGenerated]
		get
		{
			return A8wpnFJowS8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			A8wpnFJowS8 = value;
		}
	}

	internal virtual PictureBox iDWG
	{
		[CompilerGenerated]
		get
		{
			return mwkpnQyxdfR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mwkpnQyxdfR = value;
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return SDhpnPhPxOl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XydpnbfU1Ma;
			Button button = SDhpnPhPxOl;
			if (button != null)
			{
				button.Click -= value2;
			}
			SDhpnPhPxOl = value;
			button = SDhpnPhPxOl;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return I1Hpncjtb58;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			I1Hpncjtb58 = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return gf0pnKZHBrT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = bfipnwQmGll;
			TextBox textBox = gf0pnKZHBrT;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			gf0pnKZHBrT = value;
			textBox = gf0pnKZHBrT;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btLimpa
	{
		[CompilerGenerated]
		get
		{
			return SZOpne0876m;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PbMpnMeXcW1;
			Button button = SZOpne0876m;
			if (button != null)
			{
				button.Click -= value2;
			}
			SZOpne0876m = value;
			button = SZOpne0876m;
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
			if (disposing && X1qpnIxudw5 != null)
			{
				X1qpnIxudw5.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void JpApnvFedFE()
	{
		X1qpnIxudw5 = new Container();
		dgBL = new DataGridView();
		FDqpBiUmZij(new ToolTip(X1qpnIxudw5));
		GroupBoxDWG = new GroupBox();
		btViewBranco = new Button();
		btViewPreto = new Button();
		btViewColor = new Button();
		iDWG = new PictureBox();
		btSeleciona = new Button();
		LbFiltro = new Label();
		TBPesquisa = new TextBox();
		btLimpa = new Button();
		((ISupportInitialize)dgBL).BeginInit();
		GroupBoxDWG.SuspendLayout();
		((ISupportInitialize)iDWG).BeginInit();
		SuspendLayout();
		dgBL.AllowUserToAddRows = false;
		dgBL.AllowUserToDeleteRows = false;
		dgBL.AllowUserToResizeRows = false;
		dgBL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgBL.BackgroundColor = Color.White;
		dgBL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBL.Location = new Point(250, 32);
		dgBL.MultiSelect = false;
		dgBL.Name = "dgBL";
		dgBL.ReadOnly = true;
		dgBL.RowHeadersVisible = false;
		dgBL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBL.Size = new Size(286, 141);
		dgBL.TabIndex = 19;
		GroupBoxDWG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBoxDWG.Controls.Add(btViewBranco);
		GroupBoxDWG.Controls.Add(btViewPreto);
		GroupBoxDWG.Controls.Add(btViewColor);
		GroupBoxDWG.Controls.Add(iDWG);
		GroupBoxDWG.Location = new Point(3, 3);
		GroupBoxDWG.Name = "GroupBoxDWG";
		GroupBoxDWG.Size = new Size(241, 170);
		GroupBoxDWG.TabIndex = 141;
		GroupBoxDWG.TabStop = false;
		btViewBranco.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btViewBranco.BackColor = SystemColors.HighlightText;
		btViewBranco.FlatStyle = FlatStyle.Popup;
		btViewBranco.ForeColor = SystemColors.Window;
		btViewBranco.Location = new Point(220, 118);
		btViewBranco.Name = "btViewBranco";
		btViewBranco.Size = new Size(15, 40);
		btViewBranco.TabIndex = 143;
		btViewBranco.UseVisualStyleBackColor = false;
		btViewPreto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btViewPreto.BackColor = SystemColors.ActiveCaptionText;
		btViewPreto.FlatStyle = FlatStyle.Popup;
		btViewPreto.ForeColor = SystemColors.Window;
		btViewPreto.Location = new Point(220, 64);
		btViewPreto.Name = "btViewPreto";
		btViewPreto.Size = new Size(15, 40);
		btViewPreto.TabIndex = 142;
		btViewPreto.UseVisualStyleBackColor = false;
		btViewColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btViewColor.FlatStyle = FlatStyle.Popup;
		btViewColor.ForeColor = SystemColors.Window;
		btViewColor.Image = Resources.Cores;
		btViewColor.Location = new Point(220, 10);
		btViewColor.Name = "btViewColor";
		btViewColor.Size = new Size(15, 40);
		btViewColor.TabIndex = 141;
		btViewColor.UseVisualStyleBackColor = true;
		iDWG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		iDWG.BackColor = SystemColors.Desktop;
		iDWG.Location = new Point(6, 10);
		iDWG.Name = "iDWG";
		iDWG.Size = new Size(211, 154);
		iDWG.SizeMode = PictureBoxSizeMode.Zoom;
		iDWG.TabIndex = 140;
		iDWG.TabStop = false;
		btSeleciona.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.OK_32;
		btSeleciona.Location = new Point(542, 133);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(40, 40);
		btSeleciona.TabIndex = 142;
		btSeleciona.UseVisualStyleBackColor = true;
		LbFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LbFiltro.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro.Location = new Point(250, 9);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(81, 20);
		LbFiltro.TabIndex = 167;
		LbFiltro.Text = "Filtro";
		LbFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(337, 9);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(199, 20);
		TBPesquisa.TabIndex = 166;
		btLimpa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btLimpa.FlatStyle = FlatStyle.Flat;
		btLimpa.ForeColor = SystemColors.Control;
		btLimpa.Image = Resources.Apagador_32;
		btLimpa.Location = new Point(542, 87);
		btLimpa.Name = "btLimpa";
		btLimpa.Size = new Size(40, 40);
		btLimpa.TabIndex = 168;
		btLimpa.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(584, 176);
		Controls.Add(btLimpa);
		Controls.Add(LbFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(btSeleciona);
		Controls.Add(GroupBoxDWG);
		Controls.Add(dgBL);
		MinimumSize = new Size(600, 215);
		Name = "frmVisualizarBloco";
		ShowIcon = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Migrar Porta";
		((ISupportInitialize)dgBL).EndInit();
		GroupBoxDWG.ResumeLayout(performLayout: false);
		((ISupportInitialize)iDWG).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return jJMpnqFpByd;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		jJMpnqFpByd = WithEventsValue;
	}

	public frmVisualizarBloco()
	{
		Resize += Qsqpnx7tb3W;
		ODwpn2Be4Ly = "";
		CKSpn1TQjTh = true;
		DataGridView dg;
		try
		{
			if (Geral.ExisteForm("frmVisualizarBloco"))
			{
				return;
			}
			JpApnvFedFE();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 193]);
			if ((Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.gsCaminhoBloco))
			{
				DZdpnnSSF15 = new object[3, 1];
				DZdpnnSSF15[0, 0] = "Bloco";
				DZdpnnSSF15[1, 0] = "Caminho";
				DZdpnnSSF15[2, 0] = "NomeCompleto";
				ref object[,] dZdpnnSSF = ref DZdpnnSSF15;
				object mBlocos = dZdpnnSSF;
				clsDispositivo.CarregaBlocosNaMatriz(ref mBlocos, DeclaracoesGeral.gsCaminhoBloco);
				dZdpnnSSF = (object[,])mBlocos;
				DeclaracoesGeral.gsCaminhoBloco = "";
			}
			dg = dgBL;
			carregaBlocos(ref dg, DZdpnnSSF15, TBPesquisa.Text);
			dgBL = dg;
			CKSpn1TQjTh = false;
			KQ0pn62sfcL();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		dg = dgBL;
		AtualizaColunasDGBlocos(ref dg);
		dgBL = dg;
	}

	private void KQ0pn62sfcL()
	{
		bool flag = false;
		checked
		{
			int num = dgBL.Rows.Count - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (dgBL.Rows[i].Selected)
				{
					flag = true;
					break;
				}
			}
			if (!flag && dgBL.Rows.Count > 0)
			{
				dgBL.Rows[0].Selected = true;
			}
			int num2 = dgBL.Rows.Count - 1;
			for (int j = num2; j >= 0; j += -1)
			{
				if (dgBL.Rows[j].Selected)
				{
					ODwpn2Be4Ly = dgBL.Rows[j].Cells[1].Value.ToString();
					YMSpn3wMYPD = dgBL.Rows[j].Cells[2].Value.ToString();
					break;
				}
			}
			iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(ODwpn2Be4Ly);
		}
	}

	private void h4mpntnreYM(object P_0, DataGridViewCellMouseEventArgs P_1)
	{
		KQ0pn62sfcL();
	}

	private void TKRpnj4a7a9(object P_0, KeyEventArgs P_1)
	{
		KQ0pn62sfcL();
	}

	private void JfhpnLMMiX3(object P_0, KeyEventArgs P_1)
	{
		KQ0pn62sfcL();
	}

	public static void carregaBlocos(ref DataGridView dg, object[,] mBlocos, string sPesquisa)
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("Bloco", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		dg.Columns.Add("Caminho", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 993]));
		dg.Columns.Add("NomeCompleto", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		int num = Information.UBound(mBlocos, 2);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (LikeOperator.LikeString(mBlocos[0, i].ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text))
			{
				dg.Rows.Add(mBlocos[0, i].ToString(), mBlocos[1, i].ToString(), mBlocos[2, i].ToString());
			}
		}
		AtualizaColunasDGBlocos(ref dg);
	}

	public static void AtualizaColunasDGBlocos(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[2].Visible = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[0].Width = (int)Math.Round(num * 1.0);
				dg.Columns[1].Width = 0;
				dg.Columns[2].Width = 0;
			}
			else
			{
				dg.Columns.Clear();
			}
		}
	}

	private void bfipnwQmGll(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text, "", TextCompare: true) == 0))
		{
			TBPesquisa.Text = TBPesquisa.Text.ToString().ToUpper();
			DataGridView dg = dgBL;
			carregaBlocos(ref dg, DZdpnnSSF15, TBPesquisa.Text);
			dgBL = dg;
			dg = dgBL;
			AtualizaColunasDGBlocos(ref dg);
			dgBL = dg;
		}
	}

	private void Qsqpnx7tb3W(object P_0, EventArgs P_1)
	{
		if (!CKSpn1TQjTh)
		{
			DataGridView dg = dgBL;
			AtualizaColunasDGBlocos(ref dg);
			dgBL = dg;
		}
	}

	private void XydpnbfU1Ma(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.gsCaminhoBloco = YMSpn3wMYPD;
		Close();
	}

	private void PbMpnMeXcW1(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.gsCaminhoBloco = " ";
		Close();
	}

	private void qxFpnOGLsN0(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgBL.Rows.Count - 1;
			int num2 = num;
			while (true)
			{
				if (num2 >= 0)
				{
					if (dgBL.Rows[num2].Selected)
					{
						break;
					}
					num2 += -1;
					continue;
				}
				return;
			}
			ODwpn2Be4Ly = dgBL.Rows[num2].Cells[1].Value.ToString();
			YMSpn3wMYPD = dgBL.Rows[num2].Cells[2].Value.ToString();
			DeclaracoesGeral.gsCaminhoBloco = YMSpn3wMYPD;
			Close();
		}
	}
}
