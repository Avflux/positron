using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmEditaRevisaoCompleta : Form
{
	private IContainer t2Zivj5AgY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	[CompilerGenerated]
	private DataGridView XxNi6NYrnR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cmStrip1")]
	private ContextMenuStrip ELUituhQ3t;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CopiarToolStripMenuItem")]
	private ToolStripMenuItem bmCijLjoP5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ColarToolStripMenuItem")]
	private ToolStripMenuItem TxHiL1mKQK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripSeparator1")]
	[CompilerGenerated]
	private ToolStripSeparator GBGiwyoSVy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DeToolStripTextBox")]
	[CompilerGenerated]
	private ToolStripTextBox HgXixM7JwZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ParaToolStripTextBox")]
	private ToolStripTextBox cc9ib4mHBM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SubstituirToolStripMenuItem")]
	private ToolStripMenuItem zoviM2JZMo;

	[CompilerGenerated]
	[AccessedThroughProperty("LimparStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem SRriOcxAUE;

	[AccessedThroughProperty("ToolStripSeparator2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripSeparator MH0iILimsd;

	[AccessedThroughProperty("EditarToolStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripMenuItem TDhi7tqjhi;

	private string uJniq7t8Ak;

	private DeclaracoesGeral.Revisoes B4PiaNRPwT;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return XxNi6NYrnR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = APeih1WTWH;
			DataGridView dataGridView = XxNi6NYrnR;
			if (dataGridView != null)
			{
				dataGridView.Click -= value2;
			}
			XxNi6NYrnR = value;
			dataGridView = XxNi6NYrnR;
			if (dataGridView != null)
			{
				dataGridView.Click += value2;
			}
		}
	}

	internal virtual ContextMenuStrip cmStrip1
	{
		[CompilerGenerated]
		get
		{
			return ELUituhQ3t;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ELUituhQ3t = value;
		}
	}

	internal virtual ToolStripMenuItem CopiarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return bmCijLjoP5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wegiovvVuc;
			ToolStripMenuItem toolStripMenuItem = bmCijLjoP5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			bmCijLjoP5 = value;
			toolStripMenuItem = bmCijLjoP5;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ColarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return TxHiL1mKQK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = e9WiGoBn8A;
			ToolStripMenuItem toolStripMenuItem = TxHiL1mKQK;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			TxHiL1mKQK = value;
			toolStripMenuItem = TxHiL1mKQK;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		[CompilerGenerated]
		get
		{
			return GBGiwyoSVy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GBGiwyoSVy = value;
		}
	}

	internal virtual ToolStripTextBox DeToolStripTextBox
	{
		[CompilerGenerated]
		get
		{
			return HgXixM7JwZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HgXixM7JwZ = value;
		}
	}

	internal virtual ToolStripTextBox ParaToolStripTextBox
	{
		[CompilerGenerated]
		get
		{
			return cc9ib4mHBM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cc9ib4mHBM = value;
		}
	}

	internal virtual ToolStripMenuItem SubstituirToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return zoviM2JZMo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QPUikak4gJ;
			ToolStripMenuItem toolStripMenuItem = zoviM2JZMo;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			zoviM2JZMo = value;
			toolStripMenuItem = zoviM2JZMo;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem LimparStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return SRriOcxAUE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IYiiHS3lU2;
			ToolStripMenuItem toolStripMenuItem = SRriOcxAUE;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			SRriOcxAUE = value;
			toolStripMenuItem = SRriOcxAUE;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		[CompilerGenerated]
		get
		{
			return MH0iILimsd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MH0iILimsd = value;
		}
	}

	internal virtual ToolStripMenuItem EditarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return TDhi7tqjhi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NX5idRlEeH;
			ToolStripMenuItem toolStripMenuItem = TDhi7tqjhi;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			TDhi7tqjhi = value;
			toolStripMenuItem = TDhi7tqjhi;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && t2Zivj5AgY != null)
			{
				t2Zivj5AgY.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Pv7iT8vUMh()
	{
		t2Zivj5AgY = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditaRevisaoCompleta));
		dg = new DataGridView();
		cmStrip1 = new ContextMenuStrip(t2Zivj5AgY);
		CopiarToolStripMenuItem = new ToolStripMenuItem();
		ColarToolStripMenuItem = new ToolStripMenuItem();
		LimparStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator1 = new ToolStripSeparator();
		DeToolStripTextBox = new ToolStripTextBox();
		ParaToolStripTextBox = new ToolStripTextBox();
		SubstituirToolStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator2 = new ToolStripSeparator();
		EditarToolStripMenuItem = new ToolStripMenuItem();
		((ISupportInitialize)dg).BeginInit();
		cmStrip1.SuspendLayout();
		SuspendLayout();
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = Color.FromArgb(224, 224, 224);
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.ContextMenuStrip = cmStrip1;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dg.DefaultCellStyle = dataGridViewCellStyle2;
		dg.Location = new Point(12, 12);
		dg.Name = "dg";
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dg.Size = new Size(660, 438);
		dg.TabIndex = 0;
		cmStrip1.BackColor = SystemColors.Control;
		cmStrip1.Items.AddRange(new ToolStripItem[9] { CopiarToolStripMenuItem, ColarToolStripMenuItem, LimparStripMenuItem, ToolStripSeparator1, DeToolStripTextBox, ParaToolStripTextBox, SubstituirToolStripMenuItem, ToolStripSeparator2, EditarToolStripMenuItem });
		cmStrip1.Name = "cmStrip1";
		cmStrip1.Size = new Size(161, 176);
		CopiarToolStripMenuItem.Image = Resources.Copiar;
		CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem";
		CopiarToolStripMenuItem.Size = new Size(160, 22);
		CopiarToolStripMenuItem.Text = "Copiar";
		ColarToolStripMenuItem.Image = Resources.Colar;
		ColarToolStripMenuItem.Name = "ColarToolStripMenuItem";
		ColarToolStripMenuItem.Size = new Size(160, 22);
		ColarToolStripMenuItem.Text = "Colar";
		LimparStripMenuItem.Image = Resources.Limpar;
		LimparStripMenuItem.Name = "LimparStripMenuItem";
		LimparStripMenuItem.Size = new Size(160, 22);
		LimparStripMenuItem.Text = "Limpar";
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(157, 6);
		DeToolStripTextBox.Name = "DeToolStripTextBox";
		DeToolStripTextBox.Size = new Size(100, 23);
		DeToolStripTextBox.Text = "de";
		ParaToolStripTextBox.Name = "ParaToolStripTextBox";
		ParaToolStripTextBox.Size = new Size(100, 23);
		ParaToolStripTextBox.Text = "para";
		SubstituirToolStripMenuItem.Image = Resources.Substituir;
		SubstituirToolStripMenuItem.Name = "SubstituirToolStripMenuItem";
		SubstituirToolStripMenuItem.Size = new Size(160, 22);
		SubstituirToolStripMenuItem.Text = "Substituir";
		ToolStripSeparator2.Name = "ToolStripSeparator2";
		ToolStripSeparator2.Size = new Size(157, 6);
		EditarToolStripMenuItem.Image = Resources.DWG1;
		EditarToolStripMenuItem.Name = "EditarToolStripMenuItem";
		EditarToolStripMenuItem.Size = new Size(160, 22);
		EditarToolStripMenuItem.Text = "Editar";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(684, 462);
		Controls.Add(dg);
		Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		MinimumSize = new Size(700, 500);
		Name = "frmEditaRevisaoCompleta";
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmEditaTitulos";
		((ISupportInitialize)dg).EndInit();
		cmStrip1.ResumeLayout(performLayout: false);
		cmStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	public frmEditaRevisaoCompleta()
	{
		Resize += xZBifOCTVA;
		uJniq7t8Ak = "";
		if (!Geral.ExisteForm("frmEditaRevisaoCompleta"))
		{
			Pv7iT8vUMh();
			Pagina.restauraCampos();
			limpaDG();
			zwRiJ8qk2J();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 69]);
			CopiarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 45]);
			ColarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 46]);
			LimparStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 51]);
			SubstituirToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 47]);
			EditarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 52]);
			DeToolStripTextBox.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]);
			ParaToolStripTextBox.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]);
			DeToolStripTextBox.BackColor = Color.LightGray;
			DeToolStripTextBox.BorderStyle = BorderStyle.Fixed3D;
			ParaToolStripTextBox.BackColor = Color.LightGray;
			ParaToolStripTextBox.BorderStyle = BorderStyle.Fixed3D;
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	public void limpaDG()
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 39]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 63]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 64]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 65]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 66]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 67]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 68]));
				float num = dg.Width - 30;
				dg.Columns[0].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[1].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[2].Width = (int)Math.Round(num * 40f / 100f);
				dg.Columns[3].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[4].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[5].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[6].Width = (int)Math.Round(num * 10f / 100f);
				int num2 = dg.Columns.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void zwRiJ8qk2J()
	{
		try
		{
			Revisao.capturaRevisoesCompletas();
			int num = (DeclaracoesGeral.Conf.CCapa ? 1 : 2);
			int num2 = ((!DeclaracoesGeral.Conf.CCorpo) ? 1 : Information.UBound(DeclaracoesGeral.mRevCompleta));
			int num3 = num;
			int num4 = num2;
			for (int i = num3; i <= num4; i = checked(i + 1))
			{
				dg.Rows.Add(DeclaracoesGeral.mRevCompleta[i].Pagina, DeclaracoesGeral.mRevCompleta[i].Revisao, DeclaracoesGeral.mRevCompleta[i].Descricao, DeclaracoesGeral.mRevCompleta[i].Data, DeclaracoesGeral.mRevCompleta[i].Elaborador, DeclaracoesGeral.mRevCompleta[i].Verificador, DeclaracoesGeral.mRevCompleta[i].Aprovador);
			}
			dg.Columns[0].ReadOnly = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void APeih1WTWH(object P_0, EventArgs P_1)
	{
		if (dg.SelectedCells.Count != 1)
		{
			CopiarToolStripMenuItem.Enabled = false;
		}
		else
		{
			CopiarToolStripMenuItem.Enabled = true;
		}
	}

	private void wegiovvVuc(object P_0, EventArgs P_1)
	{
		if (dg.SelectedCells.Count == 1)
		{
			uJniq7t8Ak = Conversions.ToString(dg.SelectedCells[0].Value);
		}
	}

	private void e9WiGoBn8A(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.ColumnIndex > 0)
			{
				selectedCell.Value = uJniq7t8Ak;
			}
		}
	}

	private void IYiiHS3lU2(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.ColumnIndex > 0)
			{
				selectedCell.Value = "";
			}
		}
	}

	private void QPUikak4gJ(object P_0, EventArgs P_1)
	{
		string text = DeToolStripTextBox.Text;
		string newValue = ParaToolStripTextBox.Text;
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.Value.ToString().Contains(text) & (selectedCell.ColumnIndex > 0))
			{
				selectedCell.Value = selectedCell.Value.ToString().Replace(text, newValue).Trim();
			}
		}
	}

	private void NX5idRlEeH(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					int num = 1;
					do
					{
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(item.Cells[num].Value)))
						{
							item.Cells[num].Value = "";
						}
						num++;
					}
					while (num <= 6);
				}
				int num2 = (DeclaracoesGeral.Conf.CCapa ? 1 : 2);
				int num3 = ((!DeclaracoesGeral.Conf.CCorpo) ? 1 : Information.UBound(DeclaracoesGeral.mRevCompleta));
				int num4 = num2;
				int num5 = num3;
				for (int i = num4; i <= num5; i++)
				{
					DeclaracoesGeral.mRevCompleta[i].Revisao = Conversions.ToString(dg.Rows[i - num2].Cells[1].Value);
					DeclaracoesGeral.mRevCompleta[i].Descricao = Conversions.ToString(dg.Rows[i - num2].Cells[2].Value);
					DeclaracoesGeral.mRevCompleta[i].Data = Conversions.ToString(dg.Rows[i - num2].Cells[3].Value);
					DeclaracoesGeral.mRevCompleta[i].Elaborador = Conversions.ToString(dg.Rows[i - num2].Cells[4].Value);
					DeclaracoesGeral.mRevCompleta[i].Verificador = Conversions.ToString(dg.Rows[i - num2].Cells[5].Value);
					DeclaracoesGeral.mRevCompleta[i].Aprovador = Conversions.ToString(dg.Rows[i - num2].Cells[6].Value);
				}
				Revisao.AtualizaRevCompleta();
				Close();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void xZBifOCTVA(object P_0, EventArgs P_1)
	{
		tt4iDtS0Ar();
	}

	private void tt4iDtS0Ar()
	{
		checked
		{
			if (dg.Columns.Count == 7)
			{
				float num = dg.Width - 30;
				dg.Columns[0].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[1].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[2].Width = (int)Math.Round(num * 40f / 100f);
				dg.Columns[3].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[4].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[5].Width = (int)Math.Round(num * 10f / 100f);
				dg.Columns[6].Width = (int)Math.Round(num * 10f / 100f);
			}
		}
	}
}
