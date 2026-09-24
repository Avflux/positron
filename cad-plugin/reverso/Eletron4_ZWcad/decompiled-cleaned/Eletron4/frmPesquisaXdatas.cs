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
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmPesquisaXdatas : Form
{
	private IContainer qUVp6xxcGGo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BtApaga")]
	private Button XFDp6baeJTZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DG")]
	[CompilerGenerated]
	private DataGridView OCjp6M7ASUt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip pWFp6OVfZcg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtPesquisa")]
	private Button HT6p6IdxdkK;

	[AccessedThroughProperty("CkXdataEletron")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox qL4p67b3mhq;

	private List<string> DACp6qx7DRr;

	private List<string> xfsp6aDfFYE;

	internal virtual Button BtApaga
	{
		[CompilerGenerated]
		get
		{
			return XFDp6baeJTZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Hl5p6wKgTZt;
			Button button = XFDp6baeJTZ;
			if (button != null)
			{
				button.Click -= value2;
			}
			XFDp6baeJTZ = value;
			button = XFDp6baeJTZ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView DG
	{
		[CompilerGenerated]
		get
		{
			return OCjp6M7ASUt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OCjp6M7ASUt = value;
		}
	}

	internal virtual Button BtPesquisa
	{
		[CompilerGenerated]
		get
		{
			return HT6p6IdxdkK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bHlp6LuZdHh;
			Button button = HT6p6IdxdkK;
			if (button != null)
			{
				button.Click -= value2;
			}
			HT6p6IdxdkK = value;
			button = HT6p6IdxdkK;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CkXdataEletron
	{
		[CompilerGenerated]
		get
		{
			return qL4p67b3mhq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qL4p67b3mhq = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && qUVp6xxcGGo != null)
			{
				qUVp6xxcGGo.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void vMKp6vKuoW1()
	{
		qUVp6xxcGGo = new Container();
		BtApaga = new Button();
		DG = new DataGridView();
		FDqpBiUmZij(new ToolTip(qUVp6xxcGGo));
		BtPesquisa = new Button();
		CkXdataEletron = new CheckBox();
		((ISupportInitialize)DG).BeginInit();
		SuspendLayout();
		BtApaga.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BtApaga.FlatStyle = FlatStyle.Flat;
		BtApaga.ForeColor = SystemColors.Control;
		BtApaga.Image = Resources.Delete_32;
		BtApaga.Location = new Point(254, 407);
		BtApaga.Name = "BtApaga";
		BtApaga.Size = new Size(40, 42);
		BtApaga.TabIndex = 16;
		BtApaga.UseVisualStyleBackColor = true;
		DG.AllowUserToAddRows = false;
		DG.AllowUserToDeleteRows = false;
		DG.AllowUserToResizeRows = false;
		DG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DG.BackgroundColor = Color.White;
		DG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DG.Location = new Point(6, 12);
		DG.MultiSelect = false;
		DG.Name = "DG";
		DG.ReadOnly = true;
		DG.RowHeadersVisible = false;
		DG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DG.Size = new Size(286, 389);
		DG.TabIndex = 18;
		BtPesquisa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BtPesquisa.FlatStyle = FlatStyle.Flat;
		BtPesquisa.ForeColor = SystemColors.Control;
		BtPesquisa.Image = Resources.Pesquisar_32;
		BtPesquisa.Location = new Point(208, 407);
		BtPesquisa.Name = "BtPesquisa";
		BtPesquisa.Size = new Size(40, 42);
		BtPesquisa.TabIndex = 19;
		BtPesquisa.UseVisualStyleBackColor = true;
		CkXdataEletron.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CkXdataEletron.AutoSize = true;
		CkXdataEletron.Location = new Point(12, 421);
		CkXdataEletron.Name = "CkXdataEletron";
		CkXdataEletron.Size = new Size(121, 17);
		CkXdataEletron.TabIndex = 20;
		CkXdataEletron.Text = "Incluir xData Eletron";
		CkXdataEletron.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(304, 461);
		Controls.Add(CkXdataEletron);
		Controls.Add(BtPesquisa);
		Controls.Add(DG);
		Controls.Add(BtApaga);
		MaximizeBox = false;
		MaximumSize = new Size(320, 1500);
		MinimizeBox = false;
		MinimumSize = new Size(320, 500);
		Name = "frmPesquisaXdatas";
		ShowInTaskbar = false;
		Text = "Apaga xData Selecionado";
		((ISupportInitialize)DG).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return pWFp6OVfZcg;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		pWFp6OVfZcg = WithEventsValue;
	}

	public frmPesquisaXdatas()
	{
		DACp6qx7DRr = new List<string>();
		xfsp6aDfFYE = new List<string>();
		try
		{
			if (!Geral.ExisteForm("frmEditaConexao"))
			{
				vMKp6vKuoW1();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1930]);
				CkXdataEletron.Checked = false;
				CkXdataEletron.Visible = false;
				e4vp6t1s1VL();
				DTXp66plP1w();
				Application.ShowModelessDialog((Form)this);
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

	private void DTXp66plP1w()
	{
		clsApagaXdatas.StructureXDATA[] array = new clsApagaXdatas.StructureXDATA[1];
		array = new clsApagaXdatas.StructureXDATA[1];
		try
		{
			xfsp6aDfFYE.Clear();
			DACp6qx7DRr.Clear();
			if (!CkXdataEletron.Checked)
			{
				xfsp6aDfFYE.Add("ACAD");
				xfsp6aDfFYE.Add("ARANHA");
				xfsp6aDfFYE.Add("AUXBORNES");
				xfsp6aDfFYE.Add("AUXCONEXAO");
				xfsp6aDfFYE.Add("AUXDERIVACAO");
				xfsp6aDfFYE.Add("AUXINTERLIG");
				xfsp6aDfFYE.Add("CONEXAO");
				xfsp6aDfFYE.Add("DEFINICAO");
				xfsp6aDfFYE.Add("DEPARA");
				xfsp6aDfFYE.Add("DIAGLOG");
				xfsp6aDfFYE.Add("DISPOSITIVO");
				xfsp6aDfFYE.Add("DISP_FUNCAO");
				xfsp6aDfFYE.Add("DISTRIBUICAODEPOTENCIAIS");
				xfsp6aDfFYE.Add("ELETROSUL");
				xfsp6aDfFYE.Add("ELETRON");
				xfsp6aDfFYE.Add("EXPORTADO");
				xfsp6aDfFYE.Add("INTERLIGACAO");
				xfsp6aDfFYE.Add("LAYOUT");
				xfsp6aDfFYE.Add("LINHATEXTOLP");
				xfsp6aDfFYE.Add("MODELO");
				xfsp6aDfFYE.Add("TEXTOLP");
				xfsp6aDfFYE.Add("AUXIMPORTADO");
				xfsp6aDfFYE.Add("IMPORTADO");
				xfsp6aDfFYE.Add("LAYOUT");
				xfsp6aDfFYE.Add("MATERIAIS");
				xfsp6aDfFYE.Add("PLAQUETAS");
				xfsp6aDfFYE.Add("AUXEXPORTADO");
				xfsp6aDfFYE.Add("ELETRON");
				xfsp6aDfFYE.Add("PADRAOINTERLIGACAOBORNE");
				xfsp6aDfFYE.Add("PADRAOINTERLIGACAOCABO");
				xfsp6aDfFYE.Add("PADRAOINTERLIGACAOCABOLINHA");
				xfsp6aDfFYE.Add("FIACAODWG");
				xfsp6aDfFYE.Add("DINTERLIG");
				xfsp6aDfFYE.Add("TOPOGRAFICO");
			}
			clsApagaXdatas.BuscaxDatasNaoEletron(ref array);
			e4vp6t1s1VL();
			DG.Columns[0].ReadOnly = false;
			DG.MultiSelect = true;
			int num = Information.UBound(array);
			for (int i = 0; i <= num; i = checked(i + 1))
			{
				if (!CkXdataEletron.Checked)
				{
					if (!xfsp6aDfFYE.Contains(array[i].sXdata))
					{
						DG.Rows.Add(array[i].sXdata, array[i].Quant);
					}
				}
				else
				{
					DG.Rows.Add(array[i].sXdata, array[i].Quant);
				}
			}
			wRjp6jaJG6g();
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

	private void e4vp6t1s1VL()
	{
		DG.Rows.Clear();
		DG.Columns.Clear();
		DG.Columns.Add("", "xData");
		DG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 797]));
		wRjp6jaJG6g();
	}

	private void wRjp6jaJG6g()
	{
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DG)) ? ((double)(DG.Width - 4)) : ((double)(DG.Width - 21)));
			DG.Columns[0].Width = (int)Math.Round(num * 0.7);
			DG.Columns[1].Width = (int)Math.Round(num * 0.3);
		}
	}

	private void bHlp6LuZdHh(object P_0, EventArgs P_1)
	{
		DTXp66plP1w();
	}

	private void Hl5p6wKgTZt(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		new List<string>();
		checked
		{
			int num = DG.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DG.Rows[i].Selected)
				{
					list.Add(Conversions.ToString(DG.Rows[i].Cells[0].Value));
				}
			}
			int num2 = clsApagaXdatas.ApagaxDatasSelecionados(list);
			DTXp66plP1w();
			Interaction.MsgBox(num2 + " xData apagados", MsgBoxStyle.Information);
		}
	}
}
