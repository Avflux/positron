using System;
using System.Collections.Generic;
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
public class frmTopograficoAnilha : Form
{
	private IContainer BTPp3HDXbaw;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView ysBp3kEM2u2;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip jVHp3d6W3PB;

	[CompilerGenerated]
	[AccessedThroughProperty("btAnilha")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button a2jp3fcTdGt;

	[AccessedThroughProperty("btCopiar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button yjRp3D4DAEv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgAnilha")]
	private DataGridView P2hp3vMpFst;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	private Button CWPp36Ieohd;

	private int DOLp3taU7At;

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return ysBp3kEM2u2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ysBp3kEM2u2 = value;
		}
	}

	internal virtual Button btAnilha
	{
		[CompilerGenerated]
		get
		{
			return a2jp3fcTdGt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = s3ap3TwVPGm;
			Button button = a2jp3fcTdGt;
			if (button != null)
			{
				button.Click -= value2;
			}
			a2jp3fcTdGt = value;
			button = a2jp3fcTdGt;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCopiar
	{
		[CompilerGenerated]
		get
		{
			return yjRp3D4DAEv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xcbp3JADFyj;
			Button button = yjRp3D4DAEv;
			if (button != null)
			{
				button.Click -= value2;
			}
			yjRp3D4DAEv = value;
			button = yjRp3D4DAEv;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgAnilha
	{
		[CompilerGenerated]
		get
		{
			return P2hp3vMpFst;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			P2hp3vMpFst = value;
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return CWPp36Ieohd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = l7up3GTvVhJ;
			Button button = CWPp36Ieohd;
			if (button != null)
			{
				button.Click -= value2;
			}
			CWPp36Ieohd = value;
			button = CWPp36Ieohd;
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
			if (disposing && BTPp3HDXbaw != null)
			{
				BTPp3HDXbaw.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Aidp3WcClXQ()
	{
		BTPp3HDXbaw = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgEquip = new DataGridView();
		FDqpBiUmZij(new ToolTip(BTPp3HDXbaw));
		btAnilha = new Button();
		btCopiar = new Button();
		dgAnilha = new DataGridView();
		btExporta = new Button();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgAnilha).BeginInit();
		SuspendLayout();
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 12);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(184, 292);
		dgEquip.TabIndex = 8;
		btAnilha.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAnilha.FlatStyle = FlatStyle.Flat;
		btAnilha.ForeColor = SystemColors.Control;
		btAnilha.Image = Resources.Anilha;
		btAnilha.Location = new Point(71, 321);
		btAnilha.Name = "btAnilha";
		btAnilha.Size = new Size(64, 42);
		btAnilha.TabIndex = 58;
		btAnilha.UseVisualStyleBackColor = true;
		btCopiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCopiar.FlatStyle = FlatStyle.Flat;
		btCopiar.ForeColor = SystemColors.Control;
		btCopiar.Image = Resources.Copy_32;
		btCopiar.Location = new Point(45, 386);
		btCopiar.Name = "btCopiar";
		btCopiar.Size = new Size(40, 42);
		btCopiar.TabIndex = 59;
		btCopiar.UseVisualStyleBackColor = true;
		dgAnilha.AllowUserToAddRows = false;
		dgAnilha.AllowUserToDeleteRows = false;
		dgAnilha.AllowUserToResizeRows = false;
		dgAnilha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgAnilha.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgAnilha.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgAnilha.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgAnilha.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgAnilha.Location = new Point(202, 12);
		dgAnilha.Name = "dgAnilha";
		dgAnilha.ReadOnly = true;
		dgAnilha.RowHeadersVisible = false;
		dgAnilha.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgAnilha.Size = new Size(420, 437);
		dgAnilha.TabIndex = 60;
		btExporta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = Resources.ExportaExcel_20;
		btExporta.Location = new Point(112, 385);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 43);
		btExporta.TabIndex = 101;
		btExporta.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(634, 461);
		Controls.Add(btExporta);
		Controls.Add(dgAnilha);
		Controls.Add(btCopiar);
		Controls.Add(btAnilha);
		Controls.Add(dgEquip);
		MinimumSize = new Size(650, 500);
		Name = "frmTopograficoAnilha";
		ShowInTaskbar = false;
		Text = "Anilhas do Topográfico";
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgAnilha).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return jVHp3d6W3PB;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		jVHp3d6W3PB = WithEventsValue;
	}

	public frmTopograficoAnilha()
	{
		Resize += I7vp3h746pD;
		DOLp3taU7At = 0;
		try
		{
			if (!Geral.ExisteForm("frmTopograficoAnilha"))
			{
				Aidp3WcClXQ();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 491]);
				w8dpBZ0kvSD().SetToolTip(btAnilha, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 842]));
				w8dpBZ0kvSD().SetToolTip(btCopiar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 863]));
				Application.ShowModelessDialog((Form)this);
				formataDGEquip();
				YZOp3pSKTbn();
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void YZOp3pSKTbn()
	{
		List<int> lPn = new List<int>();
		clsTopografico.carregarPaineisBlocos(ref lPn);
		foreach (int item in lPn)
		{
			dgEquip.Rows.Add(item, Dicionario.BuscaNomeDoPainel(item));
		}
	}

	private void s3ap3TwVPGm(object P_0, EventArgs P_1)
	{
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		int num = 0;
		num = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		formataDGAnilha();
		DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhas = new DeclaracoesTopografico.structureAnilhaTopografico[1];
		clsTopografico.carregaAnilhas(ref mAnilhas, num);
		DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhas2 = new DeclaracoesTopografico.structureAnilhaTopografico[1];
		clsTopografico.processaAnilhas(ref mAnilhas, ref mAnilhas2);
		int num2 = Information.UBound(mAnilhas2);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				dgAnilha.Rows.Add(mAnilhas2[i].Tag1, mAnilhas2[i].Term1, mAnilhas2[i].Tag2, mAnilhas2[i].Term2, mAnilhas2[i].Secao, mAnilhas2[i].Cor, mAnilhas2[i].Anilha1, mAnilhas2[i].Anilha2);
				if (Operators.CompareString(mAnilhas2[i].Anilha2, "", TextCompare: true) == 0)
				{
					dgAnilha.Rows[dgAnilha.Rows.Count - 1].Cells[7].Style.BackColor = Color.LightCoral;
				}
			}
		}
	}

	private void xcbp3JADFyj(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				string left = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 492], "\t"), DeclaracoesGeral.mMensagem[1, 493]), "\t"), DeclaracoesGeral.mMensagem[1, 494]), "\t"), DeclaracoesGeral.mMensagem[1, 495]), "\t"), DeclaracoesGeral.mMensagem[1, 496]), "\t"), DeclaracoesGeral.mMensagem[1, 497]), "\t"), DeclaracoesGeral.mMensagem[1, 498]), "\t"), DeclaracoesGeral.mMensagem[1, 499]), "\r\n"));
				short num = (short)(dgAnilha.RowCount - 1);
				for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1))
				{
					if (dgAnilha.Rows[num2].Selected)
					{
						left = Conversions.ToString(Operators.AddObject(left, Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dgAnilha.Rows[num2].Cells[0].Value, "\t"), dgAnilha.Rows[num2].Cells[1].Value), "\t"), dgAnilha.Rows[num2].Cells[2].Value), "\t"), dgAnilha.Rows[num2].Cells[3].Value), "\t"), dgAnilha.Rows[num2].Cells[4].Value), "\t"), dgAnilha.Rows[num2].Cells[5].Value), "\t"), dgAnilha.Rows[num2].Cells[6].Value), "\t"), dgAnilha.Rows[num2].Cells[7].Value), "\r\n")));
					}
				}
				Clipboard.SetText(left);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				float num = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void formataDGAnilha()
	{
		checked
		{
			try
			{
				dgAnilha.Rows.Clear();
				dgAnilha.Columns.Clear();
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 492]));
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 493]));
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 494]));
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 495]));
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 496]));
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 497]));
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 498]));
				dgAnilha.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 499]));
				float num = dgAnilha.Width - 22;
				dgAnilha.Columns[0].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[1].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[2].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[3].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[4].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[5].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[6].Width = (int)Math.Round(num * 2f / 10f);
				dgAnilha.Columns[7].Width = (int)Math.Round(num * 2f / 10f);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void I7vp3h746pD(object P_0, EventArgs P_1)
	{
		Cigp3ojMMAw();
	}

	private void Cigp3ojMMAw()
	{
		checked
		{
			if (dgAnilha.ColumnCount == 8)
			{
				float num = dgAnilha.Width - 22;
				dgAnilha.Columns[0].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[1].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[2].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[3].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[4].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[5].Width = (int)Math.Round(num / 10f);
				dgAnilha.Columns[6].Width = (int)Math.Round(num * 2f / 10f);
				dgAnilha.Columns[7].Width = (int)Math.Round(num * 2f / 10f);
			}
		}
	}

	private void l7up3GTvVhJ(object P_0, EventArgs P_1)
	{
		checked
		{
			if (dgAnilha.RowCount > 0)
			{
				btExporta.Enabled = false;
				int num = 0;
				Relatorios_AnilhaEXCEL.RelatorioAnilhas[] array = new Relatorios_AnilhaEXCEL.RelatorioAnilhas[1];
				array[0].Origem = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 492]);
				array[0].TermOrigem = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 493]);
				array[0].Destino = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 494]);
				array[0].TermDestino = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 495]);
				array[0].Secao = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 496]);
				array[0].Cor = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 497]);
				array[0].AnilhaOrigem = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 498]);
				array[0].AnilhaDestino = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 499]);
				string sEquip = Conversions.ToString(dgEquip.SelectedRows[0].Cells[1].Value);
				int num2 = dgAnilha.RowCount - 1;
				for (int i = 0; i <= num2; i++)
				{
					num++;
					array = (Relatorios_AnilhaEXCEL.RelatorioAnilhas[])Utils.CopyArray(array, new Relatorios_AnilhaEXCEL.RelatorioAnilhas[num + 1]);
					array[num].Origem = Conversions.ToString(dgAnilha.Rows[i].Cells[0].Value);
					array[num].TermOrigem = Conversions.ToString(dgAnilha.Rows[i].Cells[1].Value);
					array[num].Destino = Conversions.ToString(dgAnilha.Rows[i].Cells[2].Value);
					array[num].TermDestino = Conversions.ToString(dgAnilha.Rows[i].Cells[3].Value);
					array[num].Secao = Conversions.ToString(dgAnilha.Rows[i].Cells[4].Value);
					array[num].Cor = Conversions.ToString(dgAnilha.Rows[i].Cells[5].Value);
					array[num].AnilhaOrigem = Conversions.ToString(dgAnilha.Rows[i].Cells[6].Value);
					array[num].AnilhaDestino = Conversions.ToString(dgAnilha.Rows[i].Cells[7].Value);
				}
				Relatorios_AnilhaEXCEL.CriaRelatorioAnilhasTopograficoEXCEL(array, sEquip);
				btExporta.Enabled = true;
			}
		}
	}
}
