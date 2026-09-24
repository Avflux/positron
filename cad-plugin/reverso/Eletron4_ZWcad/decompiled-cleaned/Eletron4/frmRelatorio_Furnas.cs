using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Furnas : Form
{
	private IContainer gfhIX8i9hA;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip sMcIUIb8JP;

	[CompilerGenerated]
	[AccessedThroughProperty("tbLargura")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox O4sIyUEkq0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lPTFim")]
	private Label vxpIgbcrGX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbOrdenadaY")]
	[CompilerGenerated]
	private TextBox DvEIAE5ZiH;

	[AccessedThroughProperty("lPTIni")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label h5mIsrfmPU;

	[CompilerGenerated]
	[AccessedThroughProperty("BTY")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button T8wIBCrVeu;

	[CompilerGenerated]
	[AccessedThroughProperty("btApaga")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button cxXIVHyx1r;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTX")]
	private Button naVIuBC1uq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	private Button rtnIE0SiIr;

	private double oHEIZv17qO;

	private double XeKIieo8Is;

	private double Rw0IS8187F;

	internal virtual TextBox tbLargura
	{
		[CompilerGenerated]
		get
		{
			return O4sIyUEkq0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			O4sIyUEkq0 = value;
		}
	}

	internal virtual Label lPTFim
	{
		[CompilerGenerated]
		get
		{
			return vxpIgbcrGX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vxpIgbcrGX = value;
		}
	}

	internal virtual TextBox tbOrdenadaY
	{
		[CompilerGenerated]
		get
		{
			return DvEIAE5ZiH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DvEIAE5ZiH = value;
		}
	}

	internal virtual Label lPTIni
	{
		[CompilerGenerated]
		get
		{
			return h5mIsrfmPU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			h5mIsrfmPU = value;
		}
	}

	internal virtual Button BTY
	{
		[CompilerGenerated]
		get
		{
			return T8wIBCrVeu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ogUI5MODkg;
			Button button = T8wIBCrVeu;
			if (button != null)
			{
				button.Click -= value2;
			}
			T8wIBCrVeu = value;
			button = T8wIBCrVeu;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApaga
	{
		[CompilerGenerated]
		get
		{
			return cxXIVHyx1r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ax8IRLoZfq;
			Button button = cxXIVHyx1r;
			if (button != null)
			{
				button.Click -= value2;
			}
			cxXIVHyx1r = value;
			button = cxXIVHyx1r;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTX
	{
		[CompilerGenerated]
		get
		{
			return naVIuBC1uq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CPfI0g5wc5;
			Button button = naVIuBC1uq;
			if (button != null)
			{
				button.Click -= value2;
			}
			naVIuBC1uq = value;
			button = naVIuBC1uq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return rtnIE0SiIr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kkLImbxtaS;
			Button button = rtnIE0SiIr;
			if (button != null)
			{
				button.Click -= value2;
			}
			rtnIE0SiIr = value;
			button = rtnIE0SiIr;
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
			if (disposing && gfhIX8i9hA != null)
			{
				gfhIX8i9hA.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void yHKIlOYL8Z()
	{
		gfhIX8i9hA = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Furnas));
		FDqpBiUmZij(new ToolTip(gfhIX8i9hA));
		tbLargura = new TextBox();
		lPTFim = new Label();
		tbOrdenadaY = new TextBox();
		lPTIni = new Label();
		BTY = new Button();
		btApaga = new Button();
		BTX = new Button();
		btExporta = new Button();
		SuspendLayout();
		tbLargura.BackColor = SystemColors.ActiveBorder;
		tbLargura.Location = new Point(12, 75);
		tbLargura.Name = "tbLargura";
		tbLargura.Size = new Size(66, 20);
		tbLargura.TabIndex = 24;
		lPTFim.AutoSize = true;
		lPTFim.Location = new Point(9, 59);
		lPTFim.Name = "lPTFim";
		lPTFim.Size = new Size(56, 13);
		lPTFim.TabIndex = 23;
		lPTFim.Text = "LBLargura";
		tbOrdenadaY.BackColor = SystemColors.ActiveBorder;
		tbOrdenadaY.Location = new Point(12, 25);
		tbOrdenadaY.Name = "tbOrdenadaY";
		tbOrdenadaY.ReadOnly = true;
		tbOrdenadaY.Size = new Size(66, 20);
		tbOrdenadaY.TabIndex = 26;
		lPTIni.AutoSize = true;
		lPTIni.Location = new Point(9, 9);
		lPTIni.Name = "lPTIni";
		lPTIni.Size = new Size(27, 13);
		lPTIni.TabIndex = 25;
		lPTIni.Text = "LBY";
		BTY.FlatStyle = FlatStyle.Flat;
		BTY.ForeColor = SystemColors.Control;
		BTY.Image = Resources.Altura;
		BTY.Location = new Point(84, 9);
		BTY.Name = "BTY";
		BTY.Size = new Size(40, 40);
		BTY.TabIndex = 27;
		BTY.UseVisualStyleBackColor = true;
		btApaga.FlatStyle = FlatStyle.Flat;
		btApaga.ForeColor = SystemColors.Control;
		btApaga.Image = Resources.Delete_32;
		btApaga.Location = new Point(166, 59);
		btApaga.Name = "btApaga";
		btApaga.Size = new Size(40, 40);
		btApaga.TabIndex = 28;
		btApaga.UseVisualStyleBackColor = true;
		BTX.FlatStyle = FlatStyle.Flat;
		BTX.ForeColor = SystemColors.Control;
		BTX.Image = Resources.Largura;
		BTX.Location = new Point(84, 55);
		BTX.Name = "BTX";
		BTX.Size = new Size(40, 40);
		BTX.TabIndex = 29;
		BTX.UseVisualStyleBackColor = true;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(166, 9);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 119;
		btExporta.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(224, 111);
		Controls.Add(btExporta);
		Controls.Add(BTX);
		Controls.Add(btApaga);
		Controls.Add(BTY);
		Controls.Add(tbOrdenadaY);
		Controls.Add(lPTIni);
		Controls.Add(tbLargura);
		Controls.Add(lPTFim);
		MaximizeBox = false;
		MaximumSize = new Size(240, 150);
		MinimizeBox = false;
		MinimumSize = new Size(240, 150);
		Name = "frmRelatorio_Furnas";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmRelatório Furnas";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return sMcIUIb8JP;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		sMcIUIb8JP = WithEventsValue;
	}

	public frmRelatorio_Furnas()
	{
		Rw0IS8187F = 0.0;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Furnas"))
			{
				yHKIlOYL8Z();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1862]);
				lPTIni.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1867]);
				lPTFim.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1868]);
				tbLargura.Text = "";
				tbOrdenadaY.Text = "";
				Application.ShowModelessDialog((Form)this);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void ogUI5MODkg(object P_0, EventArgs P_1)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Invalid comparison between Unknown and I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		oHEIZv17qO = 0.0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			_ = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 1865]) }, null, null, null);
			if ((int)((PromptResult)val2).Status != -5002)
			{
				TextBox textBox = tbOrdenadaY;
				Point3d value = val2.Value;
				textBox.Text = Math.Round(value.Y, 2).ToString();
				value = val2.Value;
				Rw0IS8187F = Conversions.ToDouble(Math.Round(value.X, 2).ToString());
				oHEIZv17qO = -1.0;
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	private void CPfI0g5wc5(object P_0, EventArgs P_1)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			_ = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 1866]) }, null, null, null);
			if ((int)((PromptResult)val2).Status != -5002)
			{
				TextBox textBox = tbLargura;
				Point3d value = val2.Value;
				textBox.Text = Math.Round(value.X, 2).ToString();
				XeKIieo8Is = -1.0;
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	private void ax8IRLoZfq(object P_0, EventArgs P_1)
	{
		Relatorios_FurnasDWG.ApagaRelatorioFURNAS();
	}

	private void kkLImbxtaS(object P_0, EventArgs P_1)
	{
		if ((oHEIZv17qO == -1.0) & (XeKIieo8Is == -1.0))
		{
			Relatorios_FurnasDWG.CriarRelatorioRevisaoFurnasDWG(Conversions.ToDouble(tbOrdenadaY.Text), Rw0IS8187F, Conversions.ToDouble(tbLargura.Text));
		}
	}
}
