using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmPesquisaVeiasIndefinidas : Form
{
	private IContainer LQ8p6kmGsCA;

	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog wBJp6dwMAmf;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip yWFp6fvirR4;

	[CompilerGenerated]
	[AccessedThroughProperty("dgVeiasDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView pRSp6DaX3ti;

	internal virtual DataGridView dgVeiasDWG
	{
		[CompilerGenerated]
		get
		{
			return pRSp6DaX3ti;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = NL5p6o46xtS;
			MouseEventHandler value3 = H7sp6GPXF80;
			DataGridView dataGridView = pRSp6DaX3ti;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			pRSp6DaX3ti = value;
			dataGridView = pRSp6DaX3ti;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && LQ8p6kmGsCA != null)
			{
				LQ8p6kmGsCA.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void aoTp6JZ4Gk3()
	{
		LQ8p6kmGsCA = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(LQ8p6kmGsCA));
		dgVeiasDWG = new DataGridView();
		((ISupportInitialize)dgVeiasDWG).BeginInit();
		SuspendLayout();
		dgVeiasDWG.AllowUserToAddRows = false;
		dgVeiasDWG.AllowUserToDeleteRows = false;
		dgVeiasDWG.AllowUserToOrderColumns = true;
		dgVeiasDWG.AllowUserToResizeRows = false;
		dgVeiasDWG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgVeiasDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgVeiasDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgVeiasDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgVeiasDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgVeiasDWG.Location = new Point(1, 1);
		dgVeiasDWG.MultiSelect = false;
		dgVeiasDWG.Name = "dgVeiasDWG";
		dgVeiasDWG.ReadOnly = true;
		dgVeiasDWG.RowHeadersVisible = false;
		dgVeiasDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgVeiasDWG.Size = new Size(380, 157);
		dgVeiasDWG.TabIndex = 9;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(384, 161);
		Controls.Add(dgVeiasDWG);
		MinimumSize = new Size(400, 200);
		Name = "frmPesquisaVeiasIndefinidas";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Lista de Cabos";
		((ISupportInitialize)dgVeiasDWG).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return wBJp6dwMAmf;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		wBJp6dwMAmf = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return yWFp6fvirR4;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		yWFp6fvirR4 = WithEventsValue;
	}

	public frmPesquisaVeiasIndefinidas()
	{
		Resize += Otfp6h0f11R;
		if (Geral.ExisteForm("frmPesquisaVeiasIndefinidas ") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			aoTp6JZ4Gk3();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 568]);
			structureVeiasCaderno[] VeiasCaderno = new structureVeiasCaderno[1];
			clsEditarInterligacao.carregaTodasAsVeiasIndefinidasDoCaderno(ref VeiasCaderno);
			DataGridView dg = dgVeiasDWG;
			CarregaTodasAsVeiasDoCadernoNoDG(ref dg, VeiasCaderno);
			dgVeiasDWG = dg;
			Application.ShowModelessDialog((Form)this);
			if (dgVeiasDWG.Rows.Count > 0)
			{
				dgVeiasDWG.Rows[0].Selected = false;
			}
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	public void CarregaNovamenteAsVeias()
	{
		structureVeiasCaderno[] VeiasCaderno = new structureVeiasCaderno[1];
		clsEditarInterligacao.carregaTodasAsVeiasIndefinidasDoCaderno(ref VeiasCaderno);
		DataGridView dg = dgVeiasDWG;
		CarregaTodasAsVeiasDoCadernoNoDG(ref dg, VeiasCaderno);
		dgVeiasDWG = dg;
	}

	public void CarregaTodasAsVeiasDoCadernoNoDG(ref DataGridView dg, structureVeiasCaderno[] VeiasCaderno)
	{
		formataDGVeiasDWG();
		int num = Information.UBound(VeiasCaderno);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			int num2 = VeiasCaderno[i].iPn1;
			int num3 = VeiasCaderno[i].iPn2;
			if (num2 > num3)
			{
				num2 = VeiasCaderno[i].iPn2;
				num3 = VeiasCaderno[i].iPn1;
			}
			string text = Dicionario.BuscaNomeDoPainel(num2);
			string text2 = Dicionario.BuscaNomeDoPainel(num3);
			if (Operators.CompareString(text, "???", TextCompare: true) == 0)
			{
				text = " ";
			}
			if (Operators.CompareString(text2, "???", TextCompare: true) == 0)
			{
				text2 = " ";
			}
			dg.Rows.Add(i, VeiasCaderno[i].sPagina, text, text2, VeiasCaderno[i].sHandleCabo1);
		}
		AtualizaDGVeiasDWG();
	}

	public void formataDGVeiasDWG()
	{
		try
		{
			dgVeiasDWG.Rows.Clear();
			dgVeiasDWG.Columns.Clear();
			dgVeiasDWG.Columns.Add("Indice", "#");
			dgVeiasDWG.Columns.Add("pAGINA", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
			dgVeiasDWG.Columns.Add("PN1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 429]));
			dgVeiasDWG.Columns.Add("PN2", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 432]));
			dgVeiasDWG.Columns.Add("Handle", "Handle");
			AtualizaDGVeiasDWG();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGVeiasDWG()
	{
		checked
		{
			if (dgVeiasDWG.Columns.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgVeiasDWG)) ? ((double)(dgVeiasDWG.Width - 4)) : ((double)(dgVeiasDWG.Width - 21)));
				dgVeiasDWG.Columns[0].Width = (int)Math.Round(num * 0.1);
				dgVeiasDWG.Columns[0].Visible = true;
				dgVeiasDWG.Columns[1].Width = (int)Math.Round(num * 0.3);
				dgVeiasDWG.Columns[1].Visible = true;
				dgVeiasDWG.Columns[2].Width = (int)Math.Round(num * 0.3);
				dgVeiasDWG.Columns[2].Visible = true;
				dgVeiasDWG.Columns[3].Width = (int)Math.Round(num * 0.3);
				dgVeiasDWG.Columns[3].Visible = true;
				dgVeiasDWG.Columns[4].Width = 0;
				dgVeiasDWG.Columns[4].Visible = false;
			}
		}
	}

	private void Otfp6h0f11R(object P_0, EventArgs P_1)
	{
		AtualizaDGVeiasDWG();
	}

	private void NL5p6o46xtS(object P_0, KeyEventArgs P_1)
	{
		wkpp6H6CivH();
	}

	private void H7sp6GPXF80(object P_0, MouseEventArgs P_1)
	{
		wkpp6H6CivH();
	}

	private void wkpp6H6CivH()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		clsBlocos.Unhighlight();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				int num = dgVeiasDWG.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!dgVeiasDWG.Rows[i].Selected)
					{
						continue;
					}
					string sHandle = Conversions.ToString(dgVeiasDWG.Rows[i].Cells[4].Value);
					ObjectId val2 = Geral.HandleToID(sHandle);
					if (val2.IsValid)
					{
						Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
						try
						{
							clsInterligacao.AtivaUmaHighlightZoom(sHandle);
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}
}
