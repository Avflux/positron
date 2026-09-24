using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmEstatisticaDeCabos : Form
{
	private IContainer zSokLSBREM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog vqLkw4hfAm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip HoekxQV71C;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	[CompilerGenerated]
	private DataGridView Q1Ikb8pYSX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox18")]
	private GroupBox s9kkM85SUk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBFormacao")]
	private RadioButton b1LkOIiYQs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBFuncao")]
	private RadioButton E5IkIXP94X;

	[AccessedThroughProperty("RBTrajeto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton aBDk76js4p;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btExportaEXCEL")]
	private Button isRkqSX3tU;

	private List<string> Si4kaqKOpu;

	private List<string> aaok8Enuht;

	private List<string> s3BkNESafw;

	private Declaracoes2.EstatisticasDeCabos[] VCVkF34yJx;

	private int ikdkQu3CIi;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return Q1Ikb8pYSX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Q1Ikb8pYSX = value;
		}
	}

	internal virtual GroupBox GroupBox18
	{
		[CompilerGenerated]
		get
		{
			return s9kkM85SUk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s9kkM85SUk = value;
		}
	}

	internal virtual RadioButton RBFormacao
	{
		[CompilerGenerated]
		get
		{
			return b1LkOIiYQs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iVPkfDw7tn;
			RadioButton radioButton = b1LkOIiYQs;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			b1LkOIiYQs = value;
			radioButton = b1LkOIiYQs;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RBFuncao
	{
		[CompilerGenerated]
		get
		{
			return E5IkIXP94X;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yXokDfunLa;
			RadioButton radioButton = E5IkIXP94X;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			E5IkIXP94X = value;
			radioButton = E5IkIXP94X;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RBTrajeto
	{
		[CompilerGenerated]
		get
		{
			return aBDk76js4p;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mTukviDQZB;
			RadioButton radioButton = aBDk76js4p;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			aBDk76js4p = value;
			radioButton = aBDk76js4p;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btExportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return isRkqSX3tU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = poxkjhv2fW;
			Button button = isRkqSX3tU;
			if (button != null)
			{
				button.Click -= value2;
			}
			isRkqSX3tU = value;
			button = isRkqSX3tU;
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
			if (disposing && zSokLSBREM != null)
			{
				zSokLSBREM.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void P8MkHDlo9g()
	{
		zSokLSBREM = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(zSokLSBREM));
		dg = new DataGridView();
		GroupBox18 = new GroupBox();
		RBFormacao = new RadioButton();
		RBFuncao = new RadioButton();
		RBTrajeto = new RadioButton();
		btExportaEXCEL = new Button();
		((ISupportInitialize)dg).BeginInit();
		GroupBox18.SuspendLayout();
		SuspendLayout();
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToOrderColumns = true;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.EditMode = DataGridViewEditMode.EditProgrammatically;
		dg.Location = new Point(12, 12);
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(520, 191);
		dg.TabIndex = 36;
		GroupBox18.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox18.Controls.Add(RBFormacao);
		GroupBox18.Controls.Add(RBFuncao);
		GroupBox18.Controls.Add(RBTrajeto);
		GroupBox18.Location = new Point(12, 209);
		GroupBox18.Name = "GroupBox18";
		GroupBox18.Size = new Size(474, 42);
		GroupBox18.TabIndex = 66;
		GroupBox18.TabStop = false;
		RBFormacao.AutoSize = true;
		RBFormacao.Location = new Point(6, 17);
		RBFormacao.Name = "RBFormacao";
		RBFormacao.Size = new Size(78, 17);
		RBFormacao.TabIndex = 2;
		RBFormacao.TabStop = true;
		RBFormacao.Text = "_Formacao";
		RBFormacao.UseVisualStyleBackColor = true;
		RBFuncao.AutoSize = true;
		RBFuncao.Location = new Point(189, 17);
		RBFuncao.Name = "RBFuncao";
		RBFuncao.Size = new Size(67, 17);
		RBFuncao.TabIndex = 1;
		RBFuncao.TabStop = true;
		RBFuncao.Text = "_Funcao";
		RBFuncao.UseVisualStyleBackColor = true;
		RBTrajeto.AutoSize = true;
		RBTrajeto.Location = new Point(361, 17);
		RBTrajeto.Name = "RBTrajeto";
		RBTrajeto.Size = new Size(64, 17);
		RBTrajeto.TabIndex = 0;
		RBTrajeto.TabStop = true;
		RBTrajeto.Text = "_Trajeto";
		RBTrajeto.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(492, 209);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 67;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(544, 261);
		Controls.Add(btExportaEXCEL);
		Controls.Add(GroupBox18);
		Controls.Add(dg);
		ImeMode = ImeMode.On;
		MinimumSize = new Size(560, 300);
		Name = "frmEstatisticaDeCabos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "_Estatisticas de Cabos por";
		((ISupportInitialize)dg).EndInit();
		GroupBox18.ResumeLayout(performLayout: false);
		GroupBox18.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return vqLkw4hfAm;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		vqLkw4hfAm = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return HoekxQV71C;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		HoekxQV71C = WithEventsValue;
	}

	public frmEstatisticaDeCabos()
	{
		Resize += BnnktwdI2n;
		Si4kaqKOpu = new List<string>();
		aaok8Enuht = new List<string>();
		s3BkNESafw = new List<string>();
		ikdkQu3CIi = 0;
		if (!Geral.ExisteForm("frmEstatisticaDeCabos"))
		{
			P8MkHDlo9g();
			VCVkF34yJx = new Declaracoes2.EstatisticasDeCabos[1];
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			cDadosAccessInterligacao3.LeTodosOsCabosEmUso(ref aaok8Enuht, ref Si4kaqKOpu, ref s3BkNESafw, ref VCVkF34yJx);
			cDadosAccessInterligacao3.FechaConexao();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1756]);
			RBFormacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]);
			RBFuncao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1430]);
			RBTrajeto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1248]);
			RBFormacao.Enabled = false;
			RBFuncao.Enabled = false;
			RBTrajeto.Enabled = false;
			if (Si4kaqKOpu.Count > 0)
			{
				RBFormacao.Enabled = true;
			}
			if (aaok8Enuht.Count > 0)
			{
				RBFuncao.Enabled = true;
			}
			if (s3BkNESafw.Count > 0)
			{
				RBTrajeto.Enabled = true;
			}
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			RBFormacao.Checked = true;
		}
	}

	public void formataDGCabos()
	{
		try
		{
			dg.Rows.Clear();
			dg.Columns.Clear();
			dg.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject("# ", DeclaracoesGeral.mMensagem[1, 514])));
			if (!RBFormacao.Checked)
			{
				if (!RBFuncao.Checked)
				{
					if (RBTrajeto.Checked)
					{
						dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1248]));
					}
				}
				else
				{
					dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
				}
			}
			else
			{
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
			}
			dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]));
			qnPkkbgPBU();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void qnPkkbgPBU()
	{
		checked
		{
			if (dg.Columns.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 5)) : ((double)(dg.Width - 22)));
				num -= 90.0;
				dg.Columns[0].Width = 90;
				dg.Columns[1].Width = (int)Math.Round(num * 0.7);
				dg.Columns[2].Width = (int)Math.Round(num * 0.3);
				int num2 = 0;
				do
				{
					dg.Columns[num2].Visible = true;
					dg.Columns[num2].ReadOnly = false;
					num2++;
				}
				while (num2 <= 2);
				dg.MultiSelect = true;
			}
		}
	}

	private void OlbkdikPqi()
	{
		if (!RBFormacao.Checked)
		{
			if (!RBFuncao.Checked)
			{
				if (RBTrajeto.Checked)
				{
					Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1757], DeclaracoesGeral.mMensagem[1, 1248]));
					ikdkQu3CIi = 2;
				}
			}
			else
			{
				Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1757], DeclaracoesGeral.mMensagem[1, 1430]));
				ikdkQu3CIi = 1;
			}
		}
		else
		{
			Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1757], DeclaracoesGeral.mMensagem[1, 1285]));
			ikdkQu3CIi = 0;
		}
		Hpgk6bJ1Ce();
	}

	private void iVPkfDw7tn(object P_0, EventArgs P_1)
	{
		OlbkdikPqi();
	}

	private void yXokDfunLa(object P_0, EventArgs P_1)
	{
		OlbkdikPqi();
	}

	private void mTukviDQZB(object P_0, EventArgs P_1)
	{
		OlbkdikPqi();
	}

	private void Hpgk6bJ1Ce()
	{
		formataDGCabos();
		checked
		{
			if (!RBFormacao.Checked)
			{
				if (!RBFuncao.Checked)
				{
					if (RBTrajeto.Checked)
					{
						bool flag = true;
						foreach (string item in s3BkNESafw)
						{
							Declaracoes2.EstatisticasDeCabos[] vCVkF34yJx = VCVkF34yJx;
							for (int i = 0; i < vCVkF34yJx.Length; i++)
							{
								Declaracoes2.EstatisticasDeCabos estatisticasDeCabos = vCVkF34yJx[i];
								flag = true;
								if (Operators.CompareString(item, estatisticasDeCabos.Trajeto, TextCompare: true) != 0)
								{
									continue;
								}
								int num = dg.Rows.Count - 1;
								for (int j = 0; j <= num; j++)
								{
									if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[1].Value, item, TextCompare: true))
									{
										dg.Rows[j].Cells[0].Value = Conversions.ToInteger(dg.Rows[j].Cells[0].Value) + 1;
										dg.Rows[j].Cells[2].Value = Conversions.ToDouble(dg.Rows[j].Cells[2].Value) + estatisticasDeCabos.Comprimento;
										flag = false;
									}
								}
								if (flag && Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(estatisticasDeCabos.Comprimento)), "", TextCompare: true) != 0)
								{
									dg.Rows.Add(1, estatisticasDeCabos.Trajeto, estatisticasDeCabos.Comprimento);
								}
							}
						}
					}
				}
				else
				{
					bool flag2 = true;
					foreach (string item2 in aaok8Enuht)
					{
						Declaracoes2.EstatisticasDeCabos[] vCVkF34yJx2 = VCVkF34yJx;
						for (int k = 0; k < vCVkF34yJx2.Length; k++)
						{
							Declaracoes2.EstatisticasDeCabos estatisticasDeCabos2 = vCVkF34yJx2[k];
							flag2 = true;
							if (Operators.CompareString(item2, estatisticasDeCabos2.Funcao, TextCompare: true) != 0)
							{
								continue;
							}
							int num2 = dg.Rows.Count - 1;
							for (int l = 0; l <= num2; l++)
							{
								if (Operators.ConditionalCompareObjectEqual(dg.Rows[l].Cells[1].Value, item2, TextCompare: true))
								{
									dg.Rows[l].Cells[0].Value = Conversions.ToInteger(dg.Rows[l].Cells[0].Value) + 1;
									dg.Rows[l].Cells[2].Value = Conversions.ToDouble(dg.Rows[l].Cells[2].Value) + estatisticasDeCabos2.Comprimento;
									flag2 = false;
								}
							}
							if (flag2 && Operators.CompareString(clsTextos.TiraNothing(estatisticasDeCabos2.Funcao), "", TextCompare: true) != 0)
							{
								dg.Rows.Add(1, estatisticasDeCabos2.Funcao, estatisticasDeCabos2.Comprimento);
							}
						}
					}
				}
			}
			else
			{
				bool flag3 = true;
				foreach (string item3 in Si4kaqKOpu)
				{
					Declaracoes2.EstatisticasDeCabos[] vCVkF34yJx3 = VCVkF34yJx;
					for (int m = 0; m < vCVkF34yJx3.Length; m++)
					{
						Declaracoes2.EstatisticasDeCabos estatisticasDeCabos3 = vCVkF34yJx3[m];
						flag3 = true;
						if (Operators.CompareString(item3, estatisticasDeCabos3.Formacao, TextCompare: true) != 0)
						{
							continue;
						}
						int num3 = dg.Rows.Count - 1;
						for (int n = 0; n <= num3; n++)
						{
							if (Operators.ConditionalCompareObjectEqual(dg.Rows[n].Cells[1].Value, item3, TextCompare: true))
							{
								dg.Rows[n].Cells[0].Value = Conversions.ToInteger(dg.Rows[n].Cells[0].Value) + 1;
								dg.Rows[n].Cells[2].Value = Conversions.ToDouble(dg.Rows[n].Cells[2].Value) + estatisticasDeCabos3.Comprimento;
								flag3 = false;
							}
						}
						if (flag3 && Operators.CompareString(clsTextos.TiraNothing(estatisticasDeCabos3.Formacao), "", TextCompare: true) != 0)
						{
							dg.Rows.Add(1, estatisticasDeCabos3.Formacao, estatisticasDeCabos3.Comprimento);
						}
					}
				}
			}
			qnPkkbgPBU();
		}
	}

	private void BnnktwdI2n(object P_0, EventArgs P_1)
	{
		qnPkkbgPBU();
	}

	private void poxkjhv2fW(object P_0, EventArgs P_1)
	{
		Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, ikdkQu3CIi);
	}
}
