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
public class frmEditaRevisaoSimplificada : Form
{
	private IContainer CiZi31R54A;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	private DataGridView Xi9inJPvKK;

	[AccessedThroughProperty("cmStrip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContextMenuStrip uc8i1JBokF;

	[AccessedThroughProperty("CopiarToolStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripMenuItem V7vilZ2TXe;

	[AccessedThroughProperty("ColarToolStripMenuItem")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem SmVi5LnQri;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripSeparator1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripSeparator C3Ci00CbI7;

	[AccessedThroughProperty("LimparStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripMenuItem hkSiRJKcPm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("EditarToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem QvoimuYOSJ;

	private string KoGiXsv9vN;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return Xi9inJPvKK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jMviF3tmHg;
			DataGridView dataGridView = Xi9inJPvKK;
			if (dataGridView != null)
			{
				dataGridView.Click -= value2;
			}
			Xi9inJPvKK = value;
			dataGridView = Xi9inJPvKK;
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
			return uc8i1JBokF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uc8i1JBokF = value;
		}
	}

	internal virtual ToolStripMenuItem CopiarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return V7vilZ2TXe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FpJiQxuNsP;
			ToolStripMenuItem toolStripMenuItem = V7vilZ2TXe;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			V7vilZ2TXe = value;
			toolStripMenuItem = V7vilZ2TXe;
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
			return SmVi5LnQri;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QC0iPTRbb6;
			ToolStripMenuItem toolStripMenuItem = SmVi5LnQri;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			SmVi5LnQri = value;
			toolStripMenuItem = SmVi5LnQri;
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
			return C3Ci00CbI7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			C3Ci00CbI7 = value;
		}
	}

	internal virtual ToolStripMenuItem LimparStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return hkSiRJKcPm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jAIicaogKX;
			ToolStripMenuItem toolStripMenuItem = hkSiRJKcPm;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			hkSiRJKcPm = value;
			toolStripMenuItem = hkSiRJKcPm;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem EditarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return QvoimuYOSJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = C6GiKcqEd2;
			ToolStripMenuItem toolStripMenuItem = QvoimuYOSJ;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			QvoimuYOSJ = value;
			toolStripMenuItem = QvoimuYOSJ;
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
			if (disposing && CiZi31R54A != null)
			{
				CiZi31R54A.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ohwi8egh4f()
	{
		CiZi31R54A = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditaRevisaoSimplificada));
		dg = new DataGridView();
		cmStrip1 = new ContextMenuStrip(CiZi31R54A);
		CopiarToolStripMenuItem = new ToolStripMenuItem();
		ColarToolStripMenuItem = new ToolStripMenuItem();
		LimparStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator1 = new ToolStripSeparator();
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
		dg.Size = new Size(190, 438);
		dg.TabIndex = 0;
		cmStrip1.BackColor = SystemColors.Control;
		cmStrip1.Items.AddRange(new ToolStripItem[5] { CopiarToolStripMenuItem, ColarToolStripMenuItem, LimparStripMenuItem, ToolStripSeparator1, EditarToolStripMenuItem });
		cmStrip1.Name = "cmStrip1";
		cmStrip1.Size = new Size(112, 98);
		CopiarToolStripMenuItem.Image = Resources.Copiar;
		CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem";
		CopiarToolStripMenuItem.Size = new Size(111, 22);
		CopiarToolStripMenuItem.Text = "Copiar";
		ColarToolStripMenuItem.Image = Resources.Colar;
		ColarToolStripMenuItem.Name = "ColarToolStripMenuItem";
		ColarToolStripMenuItem.Size = new Size(111, 22);
		ColarToolStripMenuItem.Text = "Colar";
		LimparStripMenuItem.Image = Resources.Limpar;
		LimparStripMenuItem.Name = "LimparStripMenuItem";
		LimparStripMenuItem.Size = new Size(111, 22);
		LimparStripMenuItem.Text = "Limpar";
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(108, 6);
		EditarToolStripMenuItem.Image = Resources.DWG1;
		EditarToolStripMenuItem.Name = "EditarToolStripMenuItem";
		EditarToolStripMenuItem.Size = new Size(111, 22);
		EditarToolStripMenuItem.Text = "Editar";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(214, 462);
		Controls.Add(dg);
		Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		MinimumSize = new Size(230, 500);
		Name = "frmEditaRevisaoSimplificada";
		StartPosition = FormStartPosition.CenterParent;
		Text = "Rev Simplificada";
		((ISupportInitialize)dg).EndInit();
		cmStrip1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	public frmEditaRevisaoSimplificada()
	{
		Resize += jc2ieyA0JO;
		KoGiXsv9vN = "";
		if (!Geral.ExisteForm("frmEditaRevisaoSimplificada"))
		{
			ohwi8egh4f();
			Pagina.restauraCampos();
			limpaDG();
			uy7iNUG3AA();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 61]);
			CopiarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 45]);
			ColarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 46]);
			LimparStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 51]);
			EditarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 52]);
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
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 62]));
				float num = dg.Width - 30;
				dg.Columns[0].Width = (int)Math.Round(num / 2f);
				dg.Columns[1].Width = (int)Math.Round(num / 2f);
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

	private void uy7iNUG3AA()
	{
		try
		{
			Revisao.capturaRevisoesSimplificadas();
			int num = (DeclaracoesGeral.Conf.SCapa ? 1 : 2);
			int num2 = ((!DeclaracoesGeral.Conf.SCorpo) ? 1 : Information.UBound(DeclaracoesGeral.mRevSimplificada, 2));
			int num3 = num;
			int num4 = num2;
			for (int i = num3; i <= num4; i = checked(i + 1))
			{
				dg.Rows.Add(DeclaracoesGeral.mRevSimplificada[0, i], DeclaracoesGeral.mRevSimplificada[1, i]);
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

	private void jMviF3tmHg(object P_0, EventArgs P_1)
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

	private void FpJiQxuNsP(object P_0, EventArgs P_1)
	{
		if (dg.SelectedCells.Count == 1)
		{
			KoGiXsv9vN = Conversions.ToString(dg.SelectedCells[0].Value);
		}
	}

	private void QC0iPTRbb6(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.ColumnIndex > 0)
			{
				selectedCell.Value = KoGiXsv9vN;
			}
		}
	}

	private void jAIicaogKX(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.ColumnIndex > 0)
			{
				selectedCell.Value = "";
			}
		}
	}

	private void C6GiKcqEd2(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(item.Cells[1].Value)))
					{
						item.Cells[1].Value = "";
					}
				}
				int num = (DeclaracoesGeral.Conf.SCapa ? 1 : 2);
				int num2 = ((!DeclaracoesGeral.Conf.SCorpo) ? 1 : Information.UBound(DeclaracoesGeral.mRevSimplificada, 2));
				int num3 = num;
				int num4 = num2;
				for (int i = num3; i <= num4; i++)
				{
					DeclaracoesGeral.mRevSimplificada[1, i] = RuntimeHelpers.GetObjectValue(dg.Rows[i - num].Cells[1].Value);
				}
				Revisao.AtualizaRevSimplificada();
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

	private void jc2ieyA0JO(object P_0, EventArgs P_1)
	{
		nZfi2W6nmd();
	}

	private void nZfi2W6nmd()
	{
		checked
		{
			if (dg.Columns.Count == 2)
			{
				float num = dg.Width - 30;
				dg.Columns[0].Width = (int)Math.Round(num / 2f);
				dg.Columns[1].Width = (int)Math.Round(num / 2f);
			}
		}
	}
}
