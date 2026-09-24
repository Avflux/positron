using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmEditaTitulos : Form
{
	private IContainer dl1i4Bss4e;

	[CompilerGenerated]
	[AccessedThroughProperty("dg")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView agwiCH4nqU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("cmStrip1")]
	private ContextMenuStrip gK9iYiLqZE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CopiarToolStripMenuItem")]
	private ToolStripMenuItem y3Qir6ViXa;

	[AccessedThroughProperty("ColarToolStripMenuItem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolStripMenuItem aTni9mAKhn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripSeparator1")]
	[CompilerGenerated]
	private ToolStripSeparator uKZizCrgFf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DeToolStripTextBox")]
	private ToolStripTextBox mwqSWLFsMf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ParaToolStripTextBox")]
	private ToolStripTextBox hw8SppG3Rd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SubstituirToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem qASSTnt4cO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LimparStripMenuItem")]
	private ToolStripMenuItem p5RSJOHbfZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator SSuShjIO5A;

	[AccessedThroughProperty("EditarToolStripMenuItem")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem nKxSoZHjHy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripSeparator3")]
	[CompilerGenerated]
	private ToolStripSeparator l8LSGacZ3U;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ExportarStripMenuItem")]
	private ToolStripMenuItem iqsSHJBYT9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ImportarStripMenuItem")]
	private ToolStripMenuItem VmxSkCi3tL;

	private string XUwSdURHrc;

	private DeclaracoesGeral.Titulos tidSfLwHqV;

	private int psySDY2q20;

	private int n5rSvh5RTD;

	private bool i2eS6vmHxm;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return agwiCH4nqU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uoWigeQmqK;
			DataGridViewCellEventHandler value3 = SBsiSR9Mfr;
			DataGridView dataGridView = agwiCH4nqU;
			if (dataGridView != null)
			{
				dataGridView.Click -= value2;
				dataGridView.CellEndEdit -= value3;
			}
			agwiCH4nqU = value;
			dataGridView = agwiCH4nqU;
			if (dataGridView != null)
			{
				dataGridView.Click += value2;
				dataGridView.CellEndEdit += value3;
			}
		}
	}

	internal virtual ContextMenuStrip cmStrip1
	{
		[CompilerGenerated]
		get
		{
			return gK9iYiLqZE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gK9iYiLqZE = value;
		}
	}

	internal virtual ToolStripMenuItem CopiarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return y3Qir6ViXa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = d4BiAQhf4h;
			ToolStripMenuItem toolStripMenuItem = y3Qir6ViXa;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			y3Qir6ViXa = value;
			toolStripMenuItem = y3Qir6ViXa;
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
			return aTni9mAKhn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Y4nisXqkkF;
			ToolStripMenuItem toolStripMenuItem = aTni9mAKhn;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			aTni9mAKhn = value;
			toolStripMenuItem = aTni9mAKhn;
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
			return uKZizCrgFf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uKZizCrgFf = value;
		}
	}

	internal virtual ToolStripTextBox DeToolStripTextBox
	{
		[CompilerGenerated]
		get
		{
			return mwqSWLFsMf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mwqSWLFsMf = value;
		}
	}

	internal virtual ToolStripTextBox ParaToolStripTextBox
	{
		[CompilerGenerated]
		get
		{
			return hw8SppG3Rd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hw8SppG3Rd = value;
		}
	}

	internal virtual ToolStripMenuItem SubstituirToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return qASSTnt4cO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DrQiVfVSwm;
			ToolStripMenuItem toolStripMenuItem = qASSTnt4cO;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			qASSTnt4cO = value;
			toolStripMenuItem = qASSTnt4cO;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem LimparStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return p5RSJOHbfZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = doXiB5CyjB;
			ToolStripMenuItem toolStripMenuItem = p5RSJOHbfZ;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			p5RSJOHbfZ = value;
			toolStripMenuItem = p5RSJOHbfZ;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		[CompilerGenerated]
		get
		{
			return SSuShjIO5A;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SSuShjIO5A = value;
		}
	}

	internal virtual ToolStripMenuItem EditarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return nKxSoZHjHy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RmDiunMFty;
			ToolStripMenuItem toolStripMenuItem = nKxSoZHjHy;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			nKxSoZHjHy = value;
			toolStripMenuItem = nKxSoZHjHy;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator3
	{
		[CompilerGenerated]
		get
		{
			return l8LSGacZ3U;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			l8LSGacZ3U = value;
		}
	}

	internal virtual ToolStripMenuItem ExportarStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return iqsSHJBYT9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yYbiZcMX8O;
			ToolStripMenuItem toolStripMenuItem = iqsSHJBYT9;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			iqsSHJBYT9 = value;
			toolStripMenuItem = iqsSHJBYT9;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ImportarStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return VmxSkCi3tL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UeHiiy4Rlu;
			ToolStripMenuItem toolStripMenuItem = VmxSkCi3tL;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			VmxSkCi3tL = value;
			toolStripMenuItem = VmxSkCi3tL;
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
			if (disposing && dl1i4Bss4e != null)
			{
				dl1i4Bss4e.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void pKiiUPgyX2()
	{
		dl1i4Bss4e = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditaTitulos));
		dg = new DataGridView();
		cmStrip1 = new ContextMenuStrip(dl1i4Bss4e);
		CopiarToolStripMenuItem = new ToolStripMenuItem();
		ColarToolStripMenuItem = new ToolStripMenuItem();
		LimparStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator3 = new ToolStripSeparator();
		ExportarStripMenuItem = new ToolStripMenuItem();
		ImportarStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator1 = new ToolStripSeparator();
		DeToolStripTextBox = new ToolStripTextBox();
		ParaToolStripTextBox = new ToolStripTextBox();
		SubstituirToolStripMenuItem = new ToolStripMenuItem();
		ToolStripSeparator2 = new ToolStripSeparator();
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
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dg.DefaultCellStyle = dataGridViewCellStyle2;
		dg.Location = new Point(12, 12);
		dg.Name = "dg";
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dg.Size = new Size(660, 468);
		dg.TabIndex = 0;
		cmStrip1.BackColor = SystemColors.Control;
		cmStrip1.Items.AddRange(new ToolStripItem[12]
		{
			CopiarToolStripMenuItem, ColarToolStripMenuItem, LimparStripMenuItem, ToolStripSeparator3, ExportarStripMenuItem, ImportarStripMenuItem, ToolStripSeparator1, DeToolStripTextBox, ParaToolStripTextBox, SubstituirToolStripMenuItem,
			ToolStripSeparator2, EditarToolStripMenuItem
		});
		cmStrip1.Name = "cmStrip1";
		cmStrip1.Size = new Size(161, 230);
		CopiarToolStripMenuItem.Image = Resources.Copiar;
		CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem";
		CopiarToolStripMenuItem.Size = new Size(160, 22);
		CopiarToolStripMenuItem.Text = "Copiar";
		ColarToolStripMenuItem.Image = Resources.Colar;
		ColarToolStripMenuItem.Name = "ColarToolStripMenuItem";
		ColarToolStripMenuItem.Size = new Size(160, 22);
		ColarToolStripMenuItem.Text = "Colar";
		LimparStripMenuItem.Image = Resources.Limpar;
		LimparStripMenuItem.Name = "LimparStripMenuItem";
		LimparStripMenuItem.Size = new Size(160, 22);
		LimparStripMenuItem.Text = "Limpar";
		ToolStripSeparator3.Name = "ToolStripSeparator3";
		ToolStripSeparator3.Size = new Size(157, 6);
		ExportarStripMenuItem.Image = (Image)componentResourceManager.GetObject("ExportarStripMenuItem.Image");
		ExportarStripMenuItem.Name = "ExportarStripMenuItem";
		ExportarStripMenuItem.Size = new Size(160, 22);
		ExportarStripMenuItem.Text = "Exportar";
		ImportarStripMenuItem.Image = (Image)componentResourceManager.GetObject("ImportarStripMenuItem.Image");
		ImportarStripMenuItem.Name = "ImportarStripMenuItem";
		ImportarStripMenuItem.Size = new Size(160, 22);
		ImportarStripMenuItem.Text = "Importar";
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(157, 6);
		DeToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75f);
		DeToolStripTextBox.Name = "DeToolStripTextBox";
		DeToolStripTextBox.Size = new Size(100, 25);
		DeToolStripTextBox.Text = "de";
		ParaToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75f);
		ParaToolStripTextBox.Name = "ParaToolStripTextBox";
		ParaToolStripTextBox.Size = new Size(100, 25);
		ParaToolStripTextBox.Text = "para";
		SubstituirToolStripMenuItem.Image = Resources.Substituir;
		SubstituirToolStripMenuItem.Name = "SubstituirToolStripMenuItem";
		SubstituirToolStripMenuItem.Size = new Size(160, 22);
		SubstituirToolStripMenuItem.Text = "Substituir";
		ToolStripSeparator2.Name = "ToolStripSeparator2";
		ToolStripSeparator2.Size = new Size(157, 6);
		EditarToolStripMenuItem.Image = Resources.DWG1;
		EditarToolStripMenuItem.Name = "EditarToolStripMenuItem";
		EditarToolStripMenuItem.Size = new Size(160, 22);
		EditarToolStripMenuItem.Text = "Editar";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(684, 492);
		Controls.Add(dg);
		Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		MinimumSize = new Size(700, 500);
		Name = "frmEditaTitulos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmEditaTitulos";
		((ISupportInitialize)dg).EndInit();
		cmStrip1.ResumeLayout(performLayout: false);
		cmStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	public frmEditaTitulos()
	{
		Resize += fMMiEQnsvR;
		XUwSdURHrc = "";
		psySDY2q20 = 0;
		n5rSvh5RTD = 1;
		i2eS6vmHxm = false;
		if (Geral.ExisteForm("frmEditaTitulos"))
		{
			return;
		}
		pKiiUPgyX2();
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4", writable: true);
		if (registryKey != null)
		{
			i2eS6vmHxm = Conversions.ToBoolean(registryKey.GetValue("Altern", "0"));
		}
		else
		{
			registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\\\Cadgraph\\\\Eletron4");
			registryKey.SetValue("Altern", "0");
			i2eS6vmHxm = false;
		}
		registryKey.Close();
		Pagina.restauraCampos();
		Pagina.buscaTitulosExistentes(ref tidSfLwHqV);
		checked
		{
			if (!(!tidSfLwHqV.bTitulo1 & !tidSfLwHqV.bTitulo2 & !tidSfLwHqV.bTitulo3 & !tidSfLwHqV.bTitulo4))
			{
				limpaDG();
				wFKiyTSi1h();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 50]);
				CopiarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 45]);
				ColarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 46]);
				LimparStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 51]);
				SubstituirToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 47]);
				EditarToolStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 52]);
				DeToolStripTextBox.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]);
				ParaToolStripTextBox.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]);
				ExportarStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1382]);
				ImportarStripMenuItem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1383]);
				DeToolStripTextBox.BackColor = Color.LightGray;
				DeToolStripTextBox.BorderStyle = BorderStyle.Fixed3D;
				ParaToolStripTextBox.BackColor = Color.LightGray;
				ParaToolStripTextBox.BorderStyle = BorderStyle.Fixed3D;
				Application.ShowModelessDialog((Form)this);
				int num = dg.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (Operators.CompareString(dg.Rows[num2].Cells[0].Value.ToString(), DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				dg.Rows[num2].Selected = true;
				dg.CurrentCell = dg.Rows[num2].Cells[0];
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 53]), MsgBoxStyle.Information, "Elétron");
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
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 40]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 41]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 42]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 43]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 11]));
				dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]));
				n5rSvh5RTD = 4;
				if (!tidSfLwHqV.bTitulo1)
				{
					n5rSvh5RTD--;
				}
				if (!tidSfLwHqV.bTitulo2)
				{
					n5rSvh5RTD--;
				}
				if (!tidSfLwHqV.bTitulo3)
				{
					n5rSvh5RTD--;
				}
				if (!tidSfLwHqV.bTitulo4)
				{
					n5rSvh5RTD--;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void AtualizaDG()
	{
		checked
		{
			if (dg.Columns.Count > 0)
			{
				double num;
				if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
				{
					num = dg.Width - 21;
				}
				else
				{
					num = dg.Width - 4;
				}
				num = dg.Width - 25;
				double num2 = num * 0.05;
				double num3 = num * 0.1;
				dg.Columns[0].Width = (int)Math.Round(num2);
				num -= num2;
				dg.Columns[5].Width = (int)Math.Round(num3);
				num -= num3;
				if (!i2eS6vmHxm)
				{
					dg.Columns[6].Width = 0;
					dg.Columns[6].Visible = false;
				}
				else
				{
					dg.Columns[6].Width = (int)Math.Round(num3);
					num -= num3;
				}
				psySDY2q20 = (int)Math.Round(num / (double)n5rSvh5RTD);
				if (!tidSfLwHqV.bTitulo1)
				{
					dg.Columns[1].Width = 0;
					dg.Columns[1].Visible = false;
				}
				else
				{
					dg.Columns[1].Width = psySDY2q20;
				}
				if (!tidSfLwHqV.bTitulo2)
				{
					dg.Columns[3].Width = 0;
					dg.Columns[3].Visible = false;
				}
				else
				{
					dg.Columns[2].Width = psySDY2q20;
				}
				if (!tidSfLwHqV.bTitulo3)
				{
					dg.Columns[3].Width = 0;
					dg.Columns[3].Visible = false;
				}
				else
				{
					dg.Columns[3].Width = psySDY2q20;
				}
				if (!tidSfLwHqV.bTitulo4)
				{
					dg.Columns[4].Width = 0;
					dg.Columns[4].Visible = false;
				}
				else
				{
					dg.Columns[4].Width = psySDY2q20;
				}
				int num4 = dg.Columns.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
		}
	}

	private void wFKiyTSi1h()
	{
		try
		{
			Pagina.capturaTitulos();
			int num = Information.UBound(DeclaracoesGeral.mTitulos, 2);
			for (int i = 2; i <= num; i = checked(i + 1))
			{
				dg.Rows.Add(DeclaracoesGeral.mTitulos[0, i], DeclaracoesGeral.mTitulos[1, i], DeclaracoesGeral.mTitulos[2, i], DeclaracoesGeral.mTitulos[3, i], DeclaracoesGeral.mTitulos[4, i], DeclaracoesGeral.mTitulos[5, i], DeclaracoesGeral.mTitulos[6, i]);
			}
			dg.Columns[0].ReadOnly = true;
			AtualizaDG();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void uoWigeQmqK(object P_0, EventArgs P_1)
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

	private void d4BiAQhf4h(object P_0, EventArgs P_1)
	{
		if (dg.SelectedCells.Count == 1)
		{
			XUwSdURHrc = Conversions.ToString(dg.SelectedCells[0].Value);
		}
	}

	private void Y4nisXqkkF(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.ColumnIndex <= 0)
			{
				continue;
			}
			if (selectedCell.ColumnIndex != 6)
			{
				selectedCell.Value = XUwSdURHrc;
				continue;
			}
			string text = XUwSdURHrc;
			if (Strings.Len(text) > 20)
			{
				text = Strings.Mid(text, 1, 20);
			}
			selectedCell.Value = text;
		}
	}

	private void doXiB5CyjB(object P_0, EventArgs P_1)
	{
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.ColumnIndex > 0)
			{
				selectedCell.Value = "";
			}
		}
	}

	private void DrQiVfVSwm(object P_0, EventArgs P_1)
	{
		string text = DeToolStripTextBox.Text;
		string newValue = ParaToolStripTextBox.Text;
		foreach (DataGridViewCell selectedCell in dg.SelectedCells)
		{
			if (selectedCell.Value.ToString().Contains(text) & (selectedCell.ColumnIndex > 0))
			{
				string text2 = selectedCell.Value.ToString().Replace(text, newValue).Trim();
				if (selectedCell.ColumnIndex == 6 && Strings.Len(text2) > 20)
				{
					text2 = Strings.Mid(text2, 1, 20);
				}
				selectedCell.Value = text2;
			}
		}
	}

	private void RmDiunMFty(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					int num = 1;
					do
					{
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(item.Cells[num].Value)))
						{
							item.Cells[num].Value = "";
						}
						num++;
					}
					while (num <= 4);
				}
				foreach (DataGridViewRow item2 in (IEnumerable)dg.Rows)
				{
					DeclaracoesGeral.mTitulos[1, item2.Index + 2] = RuntimeHelpers.GetObjectValue(item2.Cells[1].Value);
					DeclaracoesGeral.mTitulos[2, item2.Index + 2] = RuntimeHelpers.GetObjectValue(item2.Cells[2].Value);
					DeclaracoesGeral.mTitulos[3, item2.Index + 2] = RuntimeHelpers.GetObjectValue(item2.Cells[3].Value);
					DeclaracoesGeral.mTitulos[4, item2.Index + 2] = RuntimeHelpers.GetObjectValue(item2.Cells[4].Value);
					DeclaracoesGeral.mTitulos[5, item2.Index + 2] = RuntimeHelpers.GetObjectValue(item2.Cells[5].Value);
					DeclaracoesGeral.mTitulos[6, item2.Index + 2] = RuntimeHelpers.GetObjectValue(item2.Cells[6].Value);
				}
				Pagina.AtualizaTitulos();
				int num2 = Information.UBound(DeclaracoesGeral.mTitulos, 2);
				for (int i = 1; i <= num2; i++)
				{
					string pagina = Conversions.ToString(DeclaracoesGeral.mTitulos[0, i]);
					string unidade = Conversions.ToString(DeclaracoesGeral.mTitulos[5, i]);
					string alternativo = Conversions.ToString(DeclaracoesGeral.mTitulos[6, i]);
					clsTextos.AtualizaUnidadeAlternativo(pagina, unidade, alternativo);
				}
				Pagina.CarregaPaginas();
				Pagina.OrdenaMatrizPaginas();
				DeclaracoesGeral._uscPagina.CarregaPG();
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

	private void fMMiEQnsvR(object P_0, EventArgs P_1)
	{
		AtualizaDG();
	}

	private void yYbiZcMX8O(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		DataGridView withEventsValue = dg;
		clsTextos.ExportaPaginas(ref oSheet, ref withEventsValue, tidSfLwHqV, i2eS6vmHxm);
		dg = withEventsValue;
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
	}

	private void UeHiiy4Rlu(object P_0, EventArgs P_1)
	{
		if (dg.RowCount <= 0)
		{
			return;
		}
		clsTextos.mTitulos[] mTitulos = null;
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		clsTextos.ImportaTitulos(ref oSheet, ref mTitulos, tidSfLwHqV, i2eS6vmHxm);
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		checked
		{
			int num = dg.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = Information.UBound(mTitulos);
				for (int j = 1; j <= num2; j++)
				{
					if (tidSfLwHqV.bTitulo1 && Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString(), mTitulos[j].sPagina, TextCompare: true) == 0 && mTitulos[j].indice == 1 && Operators.CompareString(dg.Rows[i].Cells[1].Value.ToString(), mTitulos[j].sTitulo, TextCompare: true) != 0)
					{
						dg.Rows[i].Cells[1].Value = mTitulos[j].sTitulo;
					}
					if (tidSfLwHqV.bTitulo2 && Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString(), mTitulos[j].sPagina, TextCompare: true) == 0 && mTitulos[j].indice == 2 && Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString(), mTitulos[j].sTitulo, TextCompare: true) != 0)
					{
						dg.Rows[i].Cells[2].Value = mTitulos[j].sTitulo;
					}
					if (tidSfLwHqV.bTitulo3 && Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString(), mTitulos[j].sPagina, TextCompare: true) == 0 && mTitulos[j].indice == 3 && Operators.CompareString(dg.Rows[i].Cells[3].Value.ToString(), mTitulos[j].sTitulo, TextCompare: true) != 0)
					{
						dg.Rows[i].Cells[3].Value = mTitulos[j].sTitulo;
					}
					if (tidSfLwHqV.bTitulo4 && Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString(), mTitulos[j].sPagina, TextCompare: true) == 0 && mTitulos[j].indice == 4 && Operators.CompareString(dg.Rows[i].Cells[4].Value.ToString(), mTitulos[j].sTitulo, TextCompare: true) != 0)
					{
						dg.Rows[i].Cells[4].Value = mTitulos[j].sTitulo;
					}
					if (Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString(), mTitulos[j].sPagina, TextCompare: true) == 0 && mTitulos[j].indice == 5 && Operators.CompareString(dg.Rows[i].Cells[5].Value.ToString(), mTitulos[j].sTitulo, TextCompare: true) != 0)
					{
						dg.Rows[i].Cells[5].Value = mTitulos[j].sTitulo;
					}
					if (i2eS6vmHxm && Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString(), mTitulos[j].sPagina, TextCompare: true) == 0 && mTitulos[j].indice == 6 && Operators.CompareString(dg.Rows[i].Cells[6].Value.ToString(), mTitulos[j].sTitulo, TextCompare: true) != 0)
					{
						dg.Rows[i].Cells[6].Value = mTitulos[j].sTitulo;
					}
				}
			}
		}
	}

	private void SBsiSR9Mfr(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (i2eS6vmHxm && P_1.ColumnIndex == 6)
		{
			string text = Conversions.ToString(dg.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
			if (Strings.Len(text) > 20)
			{
				text = Strings.Mid(text, 1, 20);
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1927]));
				dg.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value = text;
			}
		}
	}
}
