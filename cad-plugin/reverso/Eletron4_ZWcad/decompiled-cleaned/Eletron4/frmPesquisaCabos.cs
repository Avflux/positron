using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
public class frmPesquisaCabos : Form
{
	private IContainer N1rpvrVrKhc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog fjrpv9OWFM6;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip lvdpvzRew3p;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgCabos")]
	private DataGridView Kc4p6Wx0jPk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgVeias")]
	private DataGridView p5wp6pqDfdw;

	private structureVeiasCaderno[] PJ5p6TFIbHs;

	internal virtual DataGridView dgCabos
	{
		[CompilerGenerated]
		get
		{
			return Kc4p6Wx0jPk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = z61pvEW9nBi;
			MouseEventHandler value3 = YUNpvZjYISX;
			DataGridView dataGridView = Kc4p6Wx0jPk;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			Kc4p6Wx0jPk = value;
			dataGridView = Kc4p6Wx0jPk;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual DataGridView dgVeias
	{
		[CompilerGenerated]
		get
		{
			return p5wp6pqDfdw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = hNTpvSlNRsh;
			MouseEventHandler value3 = geCpv4QLLfT;
			DataGridView dataGridView = p5wp6pqDfdw;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			p5wp6pqDfdw = value;
			dataGridView = p5wp6pqDfdw;
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
			if (disposing && N1rpvrVrKhc != null)
			{
				N1rpvrVrKhc.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void M31pvuFo6Vc()
	{
		N1rpvrVrKhc = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(N1rpvrVrKhc));
		dgCabos = new DataGridView();
		dgVeias = new DataGridView();
		((ISupportInitialize)dgCabos).BeginInit();
		((ISupportInitialize)dgVeias).BeginInit();
		SuspendLayout();
		dgCabos.AllowUserToAddRows = false;
		dgCabos.AllowUserToDeleteRows = false;
		dgCabos.AllowUserToOrderColumns = true;
		dgCabos.AllowUserToResizeRows = false;
		dgCabos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgCabos.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgCabos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgCabos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgCabos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgCabos.Location = new Point(1, 1);
		dgCabos.MultiSelect = false;
		dgCabos.Name = "dgCabos";
		dgCabos.ReadOnly = true;
		dgCabos.RowHeadersVisible = false;
		dgCabos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgCabos.Size = new Size(200, 377);
		dgCabos.TabIndex = 9;
		dgVeias.AllowUserToAddRows = false;
		dgVeias.AllowUserToDeleteRows = false;
		dgVeias.AllowUserToOrderColumns = true;
		dgVeias.AllowUserToResizeRows = false;
		dgVeias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgVeias.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgVeias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgVeias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgVeias.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgVeias.Location = new Point(211, 1);
		dgVeias.MultiSelect = false;
		dgVeias.Name = "dgVeias";
		dgVeias.ReadOnly = true;
		dgVeias.RowHeadersVisible = false;
		dgVeias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgVeias.Size = new Size(200, 377);
		dgVeias.TabIndex = 10;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(414, 381);
		Controls.Add(dgVeias);
		Controls.Add(dgCabos);
		MaximumSize = new Size(430, 1000);
		MinimumSize = new Size(430, 400);
		Name = "frmPesquisaCabos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Lista de Cabos";
		((ISupportInitialize)dgCabos).EndInit();
		((ISupportInitialize)dgVeias).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return fjrpv9OWFM6;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		fjrpv9OWFM6 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return lvdpvzRew3p;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		lvdpvzRew3p = WithEventsValue;
	}

	public frmPesquisaCabos()
	{
		Resize += FdhpvYAGGd3;
		if (Geral.ExisteForm("frmPesquisaCabos") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			M31pvuFo6Vc();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 580]);
			PJ5p6TFIbHs = new structureVeiasCaderno[1];
			List<string> lCabos = new List<string>();
			List<string> lCabos2 = new List<string>();
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			cDadosAccessInterligacao3.LeCabosVeiasUsadasCaderno(ref PJ5p6TFIbHs, ref lCabos);
			cDadosAccessInterligacao3.LeCabosTodosCabos(ref lCabos2, ref lCabos);
			Application.ShowModelessDialog((Form)this);
			formataDGCabos();
			DataGridView dg = dgCabos;
			CarregaTodasCabosDoCadernoNoDG(ref dg, PJ5p6TFIbHs, bCor: false);
			dgCabos = dg;
			PJ5p6TFIbHs = new structureVeiasCaderno[1];
			cDadosAccessInterligacao3.LeCabosVeiasUsadasOutrosCaderno(ref PJ5p6TFIbHs, ref lCabos2);
			if (PJ5p6TFIbHs.Count() > 1)
			{
				dgCabos.Rows.Add(DeclaracoesGeral.mMensagem[1, 1638].ToString().ToUpper(), "");
				dgCabos.Rows[checked(dgCabos.RowCount - 1)].Cells[0].Style.BackColor = Color.LightCoral;
				dg = dgCabos;
				CarregaTodasCabosDoCadernoNoDG(ref dg, PJ5p6TFIbHs, bCor: true);
				dgCabos = dg;
			}
			cDadosAccessInterligacao3.LeCabosVeiasTodos(ref PJ5p6TFIbHs);
			cDadosAccessInterligacao3.FechaConexao();
			if (dgCabos.Rows.Count > 0)
			{
				dgCabos.Rows[0].Selected = false;
			}
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			if (Information.UBound(PJ5p6TFIbHs) == 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1284]), MsgBoxStyle.Information);
				Close();
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	public void CarregaTodasCabosDoCadernoNoDG(ref DataGridView dg, structureVeiasCaderno[] VeiasCaderno, bool bCor)
	{
		List<string> list = new List<string>();
		list.Clear();
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				list.Add(Conversions.ToString(dg.Rows[i].Cells[0].Value));
			}
			int num2 = Information.UBound(VeiasCaderno);
			for (int j = 1; j <= num2; j++)
			{
				if (!list.Contains(VeiasCaderno[j].sTag))
				{
					list.Add(VeiasCaderno[j].sTag);
					dg.Rows.Add(VeiasCaderno[j].sTag, bCor);
					if (bCor)
					{
						dg.Rows[dg.RowCount - 1].Cells[0].Style.BackColor = Color.LightGray;
					}
				}
			}
			AtualizaDGCabos();
		}
	}

	private void z61pvEW9nBi(object P_0, KeyEventArgs P_1)
	{
		MI1pvipBDIv();
	}

	private void YUNpvZjYISX(object P_0, MouseEventArgs P_1)
	{
		MI1pvipBDIv();
	}

	private void MI1pvipBDIv()
	{
		string sCabo = Conversions.ToString(dgCabos.SelectedRows[0].Cells[0].Value);
		DataGridView dg = dgVeias;
		CarregaTodasAsVeiasDoCadernoNoDG(ref dg, sCabo, PJ5p6TFIbHs);
		dgVeias = dg;
	}

	public void formataDGCabos()
	{
		try
		{
			dgCabos.Rows.Clear();
			dgCabos.Columns.Clear();
			dgCabos.Columns.Add("Cabo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]));
			dgCabos.Columns.Add("Tipo", "Tipo");
			AtualizaDGCabos();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGCabos()
	{
		checked
		{
			if (dgCabos.Columns.Count != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(a);
				dgCabos.Columns[0].Visible = true;
				dgCabos.Columns[1].Width = 0;
				dgCabos.Columns[1].Visible = false;
			}
		}
	}

	public void CarregaTodasAsVeiasDoCadernoNoDG(ref DataGridView dg, string sCabo, structureVeiasCaderno[] VeiasCaderno)
	{
		formataDGVeias();
		int num = Information.UBound(VeiasCaderno);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(VeiasCaderno[i].sTag, sCabo, TextCompare: true) == 0)
			{
				string text = Conversions.ToString(VeiasCaderno[i].iIndice);
				if (Operators.CompareString(VeiasCaderno[i].sNomeVeia, "", TextCompare: true) != 0)
				{
					text = VeiasCaderno[i].sNomeVeia;
				}
				if (!Operators.ConditionalCompareObjectEqual(dgCabos.SelectedRows[0].Cells[1].Value, true, TextCompare: true))
				{
					dg.Rows.Add(VeiasCaderno[i].iIndice, text, VeiasCaderno[i].sPagina, VeiasCaderno[i].sHandleCabo1, VeiasCaderno[i].iIndice);
				}
				else if (Operators.CompareString(VeiasCaderno[i].sCaderno, "", TextCompare: true) == 0)
				{
					dg.Rows.Add(VeiasCaderno[i].iIndice, text, VeiasCaderno[i].sPagina, "", VeiasCaderno[i].iIndice);
				}
				else
				{
					dg.Rows.Add(VeiasCaderno[i].iIndice, text, VeiasCaderno[i].sCaderno + "-" + VeiasCaderno[i].sPagina, "", VeiasCaderno[i].iIndice);
				}
			}
		}
		ClsCabos.OrdenaVeias(ref dg);
		AtualizaDGVeias();
		if (dgVeias.Rows.Count > 0)
		{
			dgVeias.Rows[0].Selected = false;
		}
	}

	private void hNTpvSlNRsh(object P_0, KeyEventArgs P_1)
	{
		vp1pvC6nLi1();
	}

	private void geCpv4QLLfT(object P_0, MouseEventArgs P_1)
	{
		vp1pvC6nLi1();
	}

	private void vp1pvC6nLi1()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		clsBlocos.Unhighlight();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				int num = dgVeias.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!dgVeias.Rows[i].Selected)
					{
						continue;
					}
					string text = Conversions.ToString(dgVeias.Rows[i].Cells[3].Value);
					if (Operators.CompareString(text, "", TextCompare: true) == 0)
					{
						dgVeias.Rows[i].Selected = false;
						continue;
					}
					ObjectId val2 = Geral.HandleToID(text);
					if (val2.IsValid)
					{
						Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
						try
						{
							clsInterligacao.AtivaUmaHighlightZoom(text);
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

	public void formataDGVeias()
	{
		try
		{
			dgVeias.Rows.Clear();
			dgVeias.Columns.Clear();
			dgVeias.Columns.Add("Indice", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 915]));
			dgVeias.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]));
			dgVeias.Columns.Add("Pagina", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 772]));
			dgVeias.Columns.Add("Handle", "Handle");
			dgVeias.Columns.Add("Ordena", "Ordena");
			AtualizaDGVeias();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGVeias()
	{
		checked
		{
			if (dgVeias.Columns.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgVeias)) ? ((double)(dgVeias.Width - 4)) : ((double)(dgVeias.Width - 21)));
				dgVeias.Columns[0].Width = 0;
				dgVeias.Columns[0].Visible = false;
				dgVeias.Columns[1].Width = (int)Math.Round(num * 0.3);
				dgVeias.Columns[1].Visible = true;
				dgVeias.Columns[2].Width = (int)Math.Round(num * 0.7);
				dgVeias.Columns[2].Visible = true;
				dgVeias.Columns[3].Width = 0;
				dgVeias.Columns[3].Visible = false;
				dgVeias.Columns[4].Width = 0;
				dgVeias.Columns[4].Visible = false;
			}
		}
	}

	private void FdhpvYAGGd3(object P_0, EventArgs P_1)
	{
		AtualizaDGCabos();
		AtualizaDGVeias();
	}
}
