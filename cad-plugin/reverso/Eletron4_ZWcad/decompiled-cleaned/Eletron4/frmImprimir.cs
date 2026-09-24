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
public class frmImprimir : Form
{
	private IContainer ng8poiJlMM5;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox TFCpoSAfaeH;

	[AccessedThroughProperty("OpDecrescente")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton Cp3po41aHBg;

	[CompilerGenerated]
	[AccessedThroughProperty("OpCrescente")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton VXMpoCyDrJW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	private Button EFipoYo1pS6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Plotar")]
	private Button TbXporlaB8Q;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar Oe5po9hkwI6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	[CompilerGenerated]
	private DataGridView gRfpozZk6yR;

	private string[,] htmpGW3t5rP;

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return TFCpoSAfaeH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TFCpoSAfaeH = value;
		}
	}

	internal virtual RadioButton OpDecrescente
	{
		[CompilerGenerated]
		get
		{
			return Cp3po41aHBg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Cp3po41aHBg = value;
		}
	}

	internal virtual RadioButton OpCrescente
	{
		[CompilerGenerated]
		get
		{
			return VXMpoCyDrJW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VXMpoCyDrJW = value;
		}
	}

	internal virtual Button BTCancelar
	{
		[CompilerGenerated]
		get
		{
			return EFipoYo1pS6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Y1Lpou1MAtm;
			Button button = EFipoYo1pS6;
			if (button != null)
			{
				button.Click -= value2;
			}
			EFipoYo1pS6 = value;
			button = EFipoYo1pS6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Plotar
	{
		[CompilerGenerated]
		get
		{
			return TbXporlaB8Q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pZQpoVrQ9eK;
			Button button = TbXporlaB8Q;
			if (button != null)
			{
				button.Click -= value2;
			}
			TbXporlaB8Q = value;
			button = TbXporlaB8Q;
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
			return Oe5po9hkwI6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Oe5po9hkwI6 = value;
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return gRfpozZk6yR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gRfpozZk6yR = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && ng8poiJlMM5 != null)
			{
				ng8poiJlMM5.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void EjEpoBfm3p0()
	{
		GroupBox2 = new GroupBox();
		OpDecrescente = new RadioButton();
		OpCrescente = new RadioButton();
		BTCancelar = new Button();
		Plotar = new Button();
		ProgressBar1 = new ProgressBar();
		dg = new DataGridView();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dg).BeginInit();
		SuspendLayout();
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(OpDecrescente);
		GroupBox2.Controls.Add(OpCrescente);
		GroupBox2.Location = new Point(13, 283);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(147, 70);
		GroupBox2.TabIndex = 4;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordem de Impressão";
		OpDecrescente.AutoSize = true;
		OpDecrescente.Location = new Point(19, 45);
		OpDecrescente.Name = "OpDecrescente";
		OpDecrescente.Size = new Size(86, 17);
		OpDecrescente.TabIndex = 1;
		OpDecrescente.TabStop = true;
		OpDecrescente.Text = "Decrescente";
		OpDecrescente.UseVisualStyleBackColor = true;
		OpCrescente.AutoSize = true;
		OpCrescente.Location = new Point(19, 20);
		OpCrescente.Name = "OpCrescente";
		OpCrescente.Size = new Size(73, 17);
		OpCrescente.TabIndex = 0;
		OpCrescente.TabStop = true;
		OpCrescente.Text = "Crescente";
		OpCrescente.UseVisualStyleBackColor = true;
		BTCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(88, 354);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 15;
		BTCancelar.UseVisualStyleBackColor = true;
		Plotar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Plotar.FlatStyle = FlatStyle.Flat;
		Plotar.ForeColor = SystemColors.Control;
		Plotar.Image = Resources.Imprimir_32;
		Plotar.Location = new Point(32, 354);
		Plotar.Name = "Plotar";
		Plotar.Size = new Size(40, 42);
		Plotar.TabIndex = 16;
		Plotar.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom;
		ProgressBar1.Location = new Point(18, 402);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(142, 18);
		ProgressBar1.TabIndex = 17;
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = Color.White;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(11, 12);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(149, 265);
		dg.TabIndex = 18;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(169, 427);
		Controls.Add(dg);
		Controls.Add(ProgressBar1);
		Controls.Add(Plotar);
		Controls.Add(BTCancelar);
		Controls.Add(GroupBox2);
		MaximizeBox = false;
		MaximumSize = new Size(185, 800);
		MinimizeBox = false;
		MinimumSize = new Size(185, 455);
		Name = "frmImprimir";
		Text = "Imprimir";
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dg).EndInit();
		ResumeLayout(performLayout: false);
	}

	public frmImprimir()
	{
		if (Geral.ExisteForm("frmImprimir"))
		{
			return;
		}
		EjEpoBfm3p0();
		Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1476]);
		GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1473]);
		OpCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1474]);
		OpDecrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1475]);
		htmpGW3t5rP = new string[2, 1];
		int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(htmpGW3t5rP, 2) + 1;
				ref string[,] reference = ref htmpGW3t5rP;
				reference = (string[,])Utils.CopyArray(reference, new string[2, num2 + 1]);
				htmpGW3t5rP[0, num2] = Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]);
				htmpGW3t5rP[1, num2] = " ";
			}
			Revisao.capturaRevisoesCompletas();
			int num3 = Information.UBound(htmpGW3t5rP, 2);
			for (int j = 1; j <= num3; j++)
			{
				int num4 = Information.UBound(DeclaracoesGeral.mRevCompleta);
				for (int k = 1; k <= num4; k++)
				{
					if (Operators.CompareString(htmpGW3t5rP[0, j].Trim(), DeclaracoesGeral.mRevCompleta[k].Pagina, TextCompare: true) == 0)
					{
						htmpGW3t5rP[1, j] = DeclaracoesGeral.mRevCompleta[k].Revisao;
						break;
					}
				}
			}
			Revisao.capturaRevisoesSimplificadas();
			int num5 = Information.UBound(htmpGW3t5rP, 2);
			for (int l = 1; l <= num5; l++)
			{
				int num6 = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
				for (int m = 1; m <= num6; m++)
				{
					if (Operators.ConditionalCompareObjectEqual(htmpGW3t5rP[0, l], DeclaracoesGeral.mRevSimplificada[0, m], TextCompare: true) && Operators.CompareString(htmpGW3t5rP[1, l].Trim(), "", TextCompare: true) == 0)
					{
						htmpGW3t5rP[1, l] = Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, m]);
						break;
					}
				}
			}
			if (Information.UBound(htmpGW3t5rP, 2) >= 2 && Information.UBound(htmpGW3t5rP, 2) > 0)
			{
				int num7 = Information.UBound(htmpGW3t5rP, 2) - 1;
				for (int n = num7; n >= 1; n += -1)
				{
					int num8 = n;
					for (int num9 = 1; num9 <= num8; num9++)
					{
						if (Pagina.calculaPaginaDecimal(htmpGW3t5rP[0, num9]) > Pagina.calculaPaginaDecimal(htmpGW3t5rP[0, num9 + 1]))
						{
							int num10 = 0;
							do
							{
								object obj = htmpGW3t5rP[num10, num9 + 1];
								htmpGW3t5rP[num10, num9 + 1] = htmpGW3t5rP[num10, num9];
								htmpGW3t5rP[num10, num9] = Conversions.ToString(obj);
								num10++;
							}
							while (num10 <= 1);
						}
					}
				}
			}
			HqLpoERdESD();
			rBmpoZrU8e4();
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	private void pZQpoVrQ9eK(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = false;
		int num = 0;
		int num2 = 0;
		int num3 = 1;
		checked
		{
			if (!OpDecrescente.Checked)
			{
				num = 0;
				num2 = dg.Rows.Count - 1;
				num3 = 1;
			}
			else
			{
				num = dg.Rows.Count - 1;
				num2 = 0;
				num3 = -1;
			}
			int num4 = 0;
			int num5 = dg.Rows.Count - 1;
			for (int i = 0; i <= num5; i++)
			{
				if (dg.Rows[i].Selected)
				{
					num4++;
				}
			}
			ProgressBar1.Minimum = 0;
			ProgressBar1.Maximum = num4;
			ProgressBar1.Value = 0;
			ProgressBar1.Step = 1;
			int num6 = 0;
			int num7 = num;
			int num8 = num2;
			int num9 = num3;
			for (int j = num7; ((num9 >> 31) ^ j) <= ((num9 >> 31) ^ num8); j += num9)
			{
				if (DeclaracoesGeral.bPararRelatorio)
				{
					break;
				}
				if (dg.Rows[j].Selected && Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[0].Value, null, TextCompare: true))
				{
					Pagina.AtivaPagina(Conversions.ToString(dg.Rows[j].Cells[0].Value));
					ImprimirPG.ImprimirPaginaCorrente();
					ProgressBar1.Increment(1);
					Application.DoEvents();
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					num6++;
				}
			}
			ProgressBar1.Value = 0;
		}
	}

	private void Y1Lpou1MAtm(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 335]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			DeclaracoesGeral.bPararRelatorio = true;
			Application.DoEvents();
		}
	}

	private void HqLpoERdESD()
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dg.Columns.Add("", "REV");
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			float num2 = dg.Width - 20;
			dg.Columns[0].Width = (int)Math.Round(num2 * 3f / 5f);
			dg.Columns[1].Width = (int)Math.Round(num2 * 2f / 5f);
		}
	}

	private void rBmpoZrU8e4()
	{
		try
		{
			dg.Columns[0].ReadOnly = false;
			dg.Columns[1].ReadOnly = false;
			dg.MultiSelect = true;
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(htmpGW3t5rP[0, i].ToString().Trim(), "", TextCompare: true) != 0)
				{
					dg.Rows.Add(htmpGW3t5rP[0, i], htmpGW3t5rP[1, i]);
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
