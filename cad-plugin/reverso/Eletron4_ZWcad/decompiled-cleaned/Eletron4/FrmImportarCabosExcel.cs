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

namespace Eletron4;

[DesignerGenerated]
public class FrmImportarCabosExcel : Form
{
	private IContainer JPaphPgvXxM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btImportar")]
	private Button Kb0phcweI3g;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbP1Var")]
	[CompilerGenerated]
	private TextBox JYJphKZMtD7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBLVar")]
	private TextBox NgjpheS91E0;

	[AccessedThroughProperty("tbP2Var")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox KVmph2MlZwZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox UwAph3RUOcC;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox JmyphnMKxXm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox GbCph1PbSVo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbT1Var")]
	[CompilerGenerated]
	private TextBox irnphleAmG6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbT3Var")]
	private TextBox s5Nph5PBVpb;

	[CompilerGenerated]
	[AccessedThroughProperty("tbT2Var")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox lBFph0GKmyK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btModelo")]
	private Button nTUphRYuuyy;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip QsnphmopFKY;

	internal virtual Button btImportar
	{
		[CompilerGenerated]
		get
		{
			return Kb0phcweI3g;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vaDphFBIGB3;
			Button button = Kb0phcweI3g;
			if (button != null)
			{
				button.Click -= value2;
			}
			Kb0phcweI3g = value;
			button = Kb0phcweI3g;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbP1Var
	{
		[CompilerGenerated]
		get
		{
			return JYJphKZMtD7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JYJphKZMtD7 = value;
		}
	}

	internal virtual TextBox tbBLVar
	{
		[CompilerGenerated]
		get
		{
			return NgjpheS91E0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NgjpheS91E0 = value;
		}
	}

	internal virtual TextBox tbP2Var
	{
		[CompilerGenerated]
		get
		{
			return KVmph2MlZwZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KVmph2MlZwZ = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return UwAph3RUOcC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UwAph3RUOcC = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return JmyphnMKxXm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JmyphnMKxXm = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return GbCph1PbSVo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GbCph1PbSVo = value;
		}
	}

	internal virtual TextBox tbT1Var
	{
		[CompilerGenerated]
		get
		{
			return irnphleAmG6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			irnphleAmG6 = value;
		}
	}

	internal virtual TextBox tbT3Var
	{
		[CompilerGenerated]
		get
		{
			return s5Nph5PBVpb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s5Nph5PBVpb = value;
		}
	}

	internal virtual TextBox tbT2Var
	{
		[CompilerGenerated]
		get
		{
			return lBFph0GKmyK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lBFph0GKmyK = value;
		}
	}

	internal virtual Button btModelo
	{
		[CompilerGenerated]
		get
		{
			return nTUphRYuuyy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KjQphQ4SN9G;
			Button button = nTUphRYuuyy;
			if (button != null)
			{
				button.Click -= value2;
			}
			nTUphRYuuyy = value;
			button = nTUphRYuuyy;
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
			if (disposing && JPaphPgvXxM != null)
			{
				JPaphPgvXxM.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void fncphNPJB0y()
	{
		JPaphPgvXxM = new Container();
		btImportar = new Button();
		tbP1Var = new TextBox();
		tbBLVar = new TextBox();
		tbP2Var = new TextBox();
		GroupBox1 = new GroupBox();
		GroupBox2 = new GroupBox();
		GroupBox3 = new GroupBox();
		tbT1Var = new TextBox();
		tbT3Var = new TextBox();
		tbT2Var = new TextBox();
		btModelo = new Button();
		FDqpBiUmZij(new ToolTip(JPaphPgvXxM));
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		SuspendLayout();
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.ImportaExcel_20;
		btImportar.Location = new Point(213, 90);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(40, 40);
		btImportar.TabIndex = 12;
		btImportar.UseVisualStyleBackColor = true;
		tbP1Var.Location = new Point(10, 19);
		tbP1Var.Name = "tbP1Var";
		tbP1Var.Size = new Size(50, 20);
		tbP1Var.TabIndex = 1;
		tbBLVar.Location = new Point(17, 19);
		tbBLVar.Name = "tbBLVar";
		tbBLVar.Size = new Size(33, 20);
		tbBLVar.TabIndex = 0;
		tbP2Var.Location = new Point(66, 19);
		tbP2Var.Name = "tbP2Var";
		tbP2Var.Size = new Size(50, 20);
		tbP2Var.TabIndex = 4;
		GroupBox1.Controls.Add(tbBLVar);
		GroupBox1.Location = new Point(12, 27);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(57, 49);
		GroupBox1.TabIndex = 15;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "BL";
		GroupBox2.Controls.Add(tbP1Var);
		GroupBox2.Controls.Add(tbP2Var);
		GroupBox2.Location = new Point(75, 27);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(129, 49);
		GroupBox2.TabIndex = 16;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "BL";
		GroupBox3.Controls.Add(tbT1Var);
		GroupBox3.Controls.Add(tbT3Var);
		GroupBox3.Controls.Add(tbT2Var);
		GroupBox3.Location = new Point(12, 82);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(192, 49);
		GroupBox3.TabIndex = 17;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "BL";
		tbT1Var.Location = new Point(17, 19);
		tbT1Var.Name = "tbT1Var";
		tbT1Var.Size = new Size(50, 20);
		tbT1Var.TabIndex = 13;
		tbT3Var.Location = new Point(129, 19);
		tbT3Var.Name = "tbT3Var";
		tbT3Var.Size = new Size(50, 20);
		tbT3Var.TabIndex = 12;
		tbT2Var.Location = new Point(73, 19);
		tbT2Var.Name = "tbT2Var";
		tbT2Var.Size = new Size(50, 20);
		tbT2Var.TabIndex = 11;
		btModelo.FlatStyle = FlatStyle.Flat;
		btModelo.ForeColor = SystemColors.Control;
		btModelo.Image = Resources.ModeloExcel_32;
		btModelo.Location = new Point(210, 27);
		btModelo.Name = "btModelo";
		btModelo.Size = new Size(43, 42);
		btModelo.TabIndex = 19;
		btModelo.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(264, 141);
		Controls.Add(btModelo);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(btImportar);
		Controls.Add(GroupBox1);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(280, 180);
		MinimizeBox = false;
		MinimumSize = new Size(280, 180);
		Name = "FrmImportarCabosExcel";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Importar";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return QsnphmopFKY;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		QsnphmopFKY = WithEventsValue;
	}

	public FrmImportarCabosExcel()
	{
		try
		{
			if (!Geral.ExisteForm("FrmImportarCabosExcel") && clsAuxiliar.BancoValido())
			{
				fncphNPJB0y();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1237]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1232]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1233]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1234]);
				w8dpBZ0kvSD().SetToolTip(btModelo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1316]));
				w8dpBZ0kvSD().SetToolTip(btImportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1237]));
				tbBLVar.Text = "BL";
				tbP1Var.Text = "P1";
				tbP2Var.Text = "P2";
				tbT1Var.Text = "T1";
				tbT2Var.Text = "T2";
				tbT3Var.Text = "T3";
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

	private void vaDphFBIGB3(object P_0, EventArgs P_1)
	{
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		ClsCabos.StructureCabo[] mCabosCaderno = new ClsCabos.StructureCabo[1];
		cDadosAccessInterligacao3.LeTodosOsCabosUsadosNesteCaderno(ref mCabosCaderno, DeclaracoesGeral.arqAtivo.Indice);
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ClsCabos.NomeVeias nv = new ClsCabos.NomeVeias
		{
			blVar = tbBLVar.Text,
			P1Var = tbP1Var.Text,
			P2Var = tbP2Var.Text,
			T1Var = tbT1Var.Text,
			T2Var = tbT2Var.Text,
			T3Var = tbT3Var.Text
		};
		Close();
		if (ExcFuncoesExcel.VerificaExcelAtivoImportar(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false))
		{
			ClsCabos.StructureCabo[] mCabos = new ClsCabos.StructureCabo[1];
			List<string> lmListaCabos = new List<string>();
			cDadosAccessInterligacao3.LeNomeDeCabos(ref lmListaCabos);
			ClsCabos.CarregaOsCabosDoExcel(ref oSheet, ref mCabos, lmListaCabos, nv, mCabosCaderno);
			if (Information.UBound(mCabos) > 0)
			{
				ClsCabos.AdicionaBDCabosDoExcel(ref oSheet, ref mCabos, nv, ref cDadosAccessInterligacao3);
			}
		}
		cDadosAccessInterligacao3.FechaConexao();
	}

	private void KjQphQ4SN9G(object P_0, EventArgs P_1)
	{
		try
		{
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Worksheet oSheet = null;
			ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, "ModeloCabos4");
			ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
			ExcFuncoesExcel.ApagaFigura("ModeloCabos4");
			ClsCabos.ExportaModeloDeCabosParaOExcel(ref oSheet);
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
