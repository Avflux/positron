using System;
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
public class frmEstimativaVeiasLivres : Form
{
	private IContainer fbICl1SZ5q;

	[CompilerGenerated]
	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog DwxC5LNPHx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip QIaC0Sh3cl;

	[AccessedThroughProperty("dgTrajeto")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView frdCRQH2nD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCopiar")]
	private Button b2CCmMXO5x;

	private DeclaracoesInterligacao.structureEstimativa[] caUCX9J3Ru;

	internal virtual DataGridView dgTrajeto
	{
		[CompilerGenerated]
		get
		{
			return frdCRQH2nD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			frdCRQH2nD = value;
		}
	}

	internal virtual Button btCopiar
	{
		[CompilerGenerated]
		get
		{
			return b2CCmMXO5x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mRAC11iHWi;
			Button button = b2CCmMXO5x;
			if (button != null)
			{
				button.Click -= value2;
			}
			b2CCmMXO5x = value;
			button = b2CCmMXO5x;
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
			if (disposing && fbICl1SZ5q != null)
			{
				fbICl1SZ5q.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ff1Cn20r00()
	{
		fbICl1SZ5q = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(fbICl1SZ5q));
		dgTrajeto = new DataGridView();
		btCopiar = new Button();
		((ISupportInitialize)dgTrajeto).BeginInit();
		SuspendLayout();
		dgTrajeto.AllowUserToAddRows = false;
		dgTrajeto.AllowUserToDeleteRows = false;
		dgTrajeto.AllowUserToOrderColumns = true;
		dgTrajeto.AllowUserToResizeRows = false;
		dgTrajeto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgTrajeto.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgTrajeto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgTrajeto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgTrajeto.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgTrajeto.Location = new Point(12, 12);
		dgTrajeto.Name = "dgTrajeto";
		dgTrajeto.ReadOnly = true;
		dgTrajeto.RowHeadersVisible = false;
		dgTrajeto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgTrajeto.Size = new Size(390, 292);
		dgTrajeto.TabIndex = 9;
		btCopiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCopiar.FlatStyle = FlatStyle.Flat;
		btCopiar.ForeColor = SystemColors.Control;
		btCopiar.Image = Resources.Copy_32;
		btCopiar.Location = new Point(180, 310);
		btCopiar.Name = "btCopiar";
		btCopiar.Size = new Size(40, 40);
		btCopiar.TabIndex = 35;
		btCopiar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(414, 361);
		Controls.Add(btCopiar);
		Controls.Add(dgTrajeto);
		MaximumSize = new Size(430, 1000);
		MinimumSize = new Size(430, 400);
		Name = "frmEstimativaVeiasLivres";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Estimativa Veias Livres";
		((ISupportInitialize)dgTrajeto).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return DwxC5LNPHx;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		DwxC5LNPHx = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return QIaC0Sh3cl;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		QIaC0Sh3cl = WithEventsValue;
	}

	public frmEstimativaVeiasLivres()
	{
		if (!Geral.ExisteForm("frmEstimativaVeiasLivres"))
		{
			ff1Cn20r00();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1432]);
			Application.ShowModelessDialog((Form)this);
			formataDGVeias();
			caUCX9J3Ru = new DeclaracoesInterligacao.structureEstimativa[1];
			clsInterligacao.Estimativa(ref caUCX9J3Ru);
			CarregaTodasAsVeiasDoCadernoNoDG();
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	public void CarregaTodasAsVeiasDoCadernoNoDG()
	{
		if (Information.UBound(caUCX9J3Ru) != 0)
		{
			int num = Information.UBound(caUCX9J3Ru);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgTrajeto.Rows.Add(caUCX9J3Ru[i].sPn1, caUCX9J3Ru[i].sPn2, caUCX9J3Ru[i].iQuant.ToString());
			}
		}
	}

	private void mRAC11iHWi(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				if (dgTrajeto.RowCount > 0)
				{
					string text = "";
					short num = (short)(dgTrajeto.RowCount - 1);
					for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1))
					{
						string text2 = Conversions.ToString(dgTrajeto.Rows[num2].Cells[0].Value);
						string text3 = Conversions.ToString(dgTrajeto.Rows[num2].Cells[1].Value);
						string text4 = Conversions.ToString(dgTrajeto.Rows[num2].Cells[2].Value);
						text = text + text2 + "\t" + text3 + "\t" + text4 + "\r\n";
					}
					Clipboard.SetText(text);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void formataDGVeias()
	{
		checked
		{
			try
			{
				dgTrajeto.Rows.Clear();
				dgTrajeto.Columns.Clear();
				dgTrajeto.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]));
				dgTrajeto.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]));
				dgTrajeto.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1433]));
				float num = dgTrajeto.Width - 22;
				dgTrajeto.Columns[0].Width = (int)Math.Round(num * 2f / 5f);
				dgTrajeto.Columns[1].Width = (int)Math.Round(num * 2f / 5f);
				dgTrajeto.Columns[2].Width = (int)Math.Round(num / 5f);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}
