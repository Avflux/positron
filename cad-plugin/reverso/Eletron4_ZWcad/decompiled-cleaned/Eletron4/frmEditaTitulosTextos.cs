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
public class frmEditaTitulosTextos : Form
{
	private IContainer hSmSbyrnPD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	private FolderBrowserDialog GThSMFvpcj;

	[AccessedThroughProperty("dgPaginas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView nGaSOqXTK8;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip BUZSIJP9wZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDe")]
	[CompilerGenerated]
	private TextBox af2S7qfc9N;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtEditar")]
	private Button ciJSqlci6G;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	private GroupBox BJOSaUGf8p;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDe")]
	private Label LgZS8Y0Fh1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbText")]
	private CheckBox ASMSNnZdsg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTitulo4")]
	private CheckBox rKqSF8SOF7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTitulo3")]
	private CheckBox RwkSQTARoY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTitulo2")]
	[CompilerGenerated]
	private CheckBox TlrSPyD4iO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTitulo1")]
	private CheckBox EXfScqv3TH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPara")]
	private TextBox rBbSKJvdPe;

	[CompilerGenerated]
	[AccessedThroughProperty("lbPara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label igCSeXWRuo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("cbMText")]
	private CheckBox zjQS2o5EUc;

	private DeclaracoesGeral.Titulos fA6S3XxqxP;

	internal virtual DataGridView dgPaginas
	{
		[CompilerGenerated]
		get
		{
			return nGaSOqXTK8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nGaSOqXTK8 = value;
		}
	}

	internal virtual TextBox tbDe
	{
		[CompilerGenerated]
		get
		{
			return af2S7qfc9N;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			af2S7qfc9N = value;
		}
	}

	internal virtual Button BtEditar
	{
		[CompilerGenerated]
		get
		{
			return ciJSqlci6G;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sgrSxhI2bv;
			Button button = ciJSqlci6G;
			if (button != null)
			{
				button.Click -= value2;
			}
			ciJSqlci6G = value;
			button = ciJSqlci6G;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return BJOSaUGf8p;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BJOSaUGf8p = value;
		}
	}

	internal virtual Label lbDe
	{
		[CompilerGenerated]
		get
		{
			return LgZS8Y0Fh1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LgZS8Y0Fh1 = value;
		}
	}

	internal virtual CheckBox cbText
	{
		[CompilerGenerated]
		get
		{
			return ASMSNnZdsg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ASMSNnZdsg = value;
		}
	}

	internal virtual CheckBox cbTitulo4
	{
		[CompilerGenerated]
		get
		{
			return rKqSF8SOF7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rKqSF8SOF7 = value;
		}
	}

	internal virtual CheckBox cbTitulo3
	{
		[CompilerGenerated]
		get
		{
			return RwkSQTARoY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RwkSQTARoY = value;
		}
	}

	internal virtual CheckBox cbTitulo2
	{
		[CompilerGenerated]
		get
		{
			return TlrSPyD4iO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TlrSPyD4iO = value;
		}
	}

	internal virtual CheckBox cbTitulo1
	{
		[CompilerGenerated]
		get
		{
			return EXfScqv3TH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EXfScqv3TH = value;
		}
	}

	internal virtual TextBox tbPara
	{
		[CompilerGenerated]
		get
		{
			return rBbSKJvdPe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rBbSKJvdPe = value;
		}
	}

	internal virtual Label lbPara
	{
		[CompilerGenerated]
		get
		{
			return igCSeXWRuo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			igCSeXWRuo = value;
		}
	}

	internal virtual CheckBox cbMText
	{
		[CompilerGenerated]
		get
		{
			return zjQS2o5EUc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zjQS2o5EUc = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && hSmSbyrnPD != null)
			{
				hSmSbyrnPD.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void K9qSt9nUaH()
	{
		hSmSbyrnPD = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		dgPaginas = new DataGridView();
		FDqpBiUmZij(new ToolTip(hSmSbyrnPD));
		tbDe = new TextBox();
		BtEditar = new Button();
		GroupBox2 = new GroupBox();
		cbMText = new CheckBox();
		tbPara = new TextBox();
		lbPara = new Label();
		cbText = new CheckBox();
		cbTitulo4 = new CheckBox();
		cbTitulo3 = new CheckBox();
		cbTitulo2 = new CheckBox();
		cbTitulo1 = new CheckBox();
		lbDe = new Label();
		((ISupportInitialize)dgPaginas).BeginInit();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		dgPaginas.AllowUserToAddRows = false;
		dgPaginas.AllowUserToDeleteRows = false;
		dgPaginas.AllowUserToOrderColumns = true;
		dgPaginas.AllowUserToResizeRows = false;
		dgPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPaginas.BackgroundColor = SystemColors.ButtonHighlight;
		dgPaginas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgPaginas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaginas.Location = new Point(12, 12);
		dgPaginas.Name = "dgPaginas";
		dgPaginas.ReadOnly = true;
		dgPaginas.RowHeadersVisible = false;
		dgPaginas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaginas.Size = new Size(130, 325);
		dgPaginas.TabIndex = 1;
		tbDe.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDe.Location = new Point(6, 36);
		tbDe.Name = "tbDe";
		tbDe.Size = new Size(100, 20);
		tbDe.TabIndex = 2;
		BtEditar.FlatStyle = FlatStyle.Flat;
		BtEditar.ForeColor = SystemColors.Control;
		BtEditar.Image = Resources.Editar;
		BtEditar.Location = new Point(237, 283);
		BtEditar.Name = "BtEditar";
		BtEditar.Size = new Size(40, 40);
		BtEditar.TabIndex = 10;
		BtEditar.UseVisualStyleBackColor = true;
		GroupBox2.Controls.Add(cbMText);
		GroupBox2.Controls.Add(tbPara);
		GroupBox2.Controls.Add(lbPara);
		GroupBox2.Controls.Add(cbText);
		GroupBox2.Controls.Add(cbTitulo4);
		GroupBox2.Controls.Add(cbTitulo3);
		GroupBox2.Controls.Add(cbTitulo2);
		GroupBox2.Controls.Add(cbTitulo1);
		GroupBox2.Controls.Add(tbDe);
		GroupBox2.Controls.Add(lbDe);
		GroupBox2.Location = new Point(148, 12);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(225, 254);
		GroupBox2.TabIndex = 148;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		cbMText.AutoSize = true;
		cbMText.Location = new Point(10, 218);
		cbMText.Name = "cbMText";
		cbMText.Size = new Size(71, 17);
		cbMText.TabIndex = 9;
		cbMText.Text = "cb MText";
		cbMText.UseVisualStyleBackColor = true;
		tbPara.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPara.Location = new Point(112, 36);
		tbPara.Name = "tbPara";
		tbPara.Size = new Size(100, 20);
		tbPara.TabIndex = 3;
		lbPara.Location = new Point(112, 16);
		lbPara.Name = "lbPara";
		lbPara.Size = new Size(71, 17);
		lbPara.TabIndex = 155;
		lbPara.Text = "lbPara";
		cbText.AutoSize = true;
		cbText.Location = new Point(10, 189);
		cbText.Name = "cbText";
		cbText.Size = new Size(59, 17);
		cbText.TabIndex = 8;
		cbText.Text = "cbText";
		cbText.UseVisualStyleBackColor = true;
		cbTitulo4.AutoSize = true;
		cbTitulo4.Location = new Point(10, 160);
		cbTitulo4.Name = "cbTitulo4";
		cbTitulo4.Size = new Size(70, 17);
		cbTitulo4.TabIndex = 7;
		cbTitulo4.Text = "cbTitulo4";
		cbTitulo4.UseVisualStyleBackColor = true;
		cbTitulo3.AutoSize = true;
		cbTitulo3.Location = new Point(10, 131);
		cbTitulo3.Name = "cbTitulo3";
		cbTitulo3.Size = new Size(70, 17);
		cbTitulo3.TabIndex = 6;
		cbTitulo3.Text = "cbTitulo3";
		cbTitulo3.UseVisualStyleBackColor = true;
		cbTitulo2.AutoSize = true;
		cbTitulo2.Location = new Point(10, 102);
		cbTitulo2.Name = "cbTitulo2";
		cbTitulo2.Size = new Size(70, 17);
		cbTitulo2.TabIndex = 5;
		cbTitulo2.Text = "cbTitulo2";
		cbTitulo2.UseVisualStyleBackColor = true;
		cbTitulo1.AutoSize = true;
		cbTitulo1.Location = new Point(10, 73);
		cbTitulo1.Name = "cbTitulo1";
		cbTitulo1.Size = new Size(70, 17);
		cbTitulo1.TabIndex = 4;
		cbTitulo1.Text = "cbTitulo1";
		cbTitulo1.UseVisualStyleBackColor = true;
		lbDe.Location = new Point(6, 16);
		lbDe.Name = "lbDe";
		lbDe.Size = new Size(71, 17);
		lbDe.TabIndex = 146;
		lbDe.Text = "lbDe";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(380, 349);
		Controls.Add(dgPaginas);
		Controls.Add(GroupBox2);
		Controls.Add(BtEditar);
		ImeMode = ImeMode.On;
		MaximumSize = new Size(396, 600);
		MinimumSize = new Size(396, 387);
		Name = "frmEditaTitulosTextos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Edtar Títulos e Textos";
		((ISupportInitialize)dgPaginas).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return GThSMFvpcj;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		GThSMFvpcj = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return BUZSIJP9wZ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		BUZSIJP9wZ = WithEventsValue;
	}

	public frmEditaTitulosTextos()
	{
		if (Geral.ExisteForm("frmEditaTitulosTextos"))
		{
			return;
		}
		K9qSt9nUaH();
		Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 592]);
		lbDe.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]);
		lbPara.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]);
		GroupBox2.Text = "";
		cbTitulo1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 40]);
		cbTitulo2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 41]);
		cbTitulo3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 42]);
		cbTitulo4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 43]);
		cbText.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1161]);
		cbMText.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1222]);
		w8dpBZ0kvSD().SetToolTip(BtEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 592]));
		Pagina.buscaTitulosExistentes(ref fA6S3XxqxP);
		if (!(!fA6S3XxqxP.bTitulo1 & !fA6S3XxqxP.bTitulo2 & !fA6S3XxqxP.bTitulo3 & !fA6S3XxqxP.bTitulo4))
		{
			cbTitulo1.Enabled = fA6S3XxqxP.bTitulo1;
			cbTitulo2.Enabled = fA6S3XxqxP.bTitulo2;
			cbTitulo3.Enabled = fA6S3XxqxP.bTitulo3;
			cbTitulo4.Enabled = fA6S3XxqxP.bTitulo4;
			QyUSj1syjb();
			sOZSLnbfGo();
			Application.ShowModelessDialog((Form)this);
			uHnSwNE1cF();
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 53]), MsgBoxStyle.Information, "Elétron");
		}
	}

	private void QyUSj1syjb()
	{
		dgPaginas.Rows.Clear();
		dgPaginas.Columns.Clear();
		dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		checked
		{
			int num = dgPaginas.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dgPaginas.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			uHnSwNE1cF();
		}
	}

	private void sOZSLnbfGo()
	{
		try
		{
			dgPaginas.Columns[0].ReadOnly = false;
			dgPaginas.MultiSelect = true;
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgPaginas.Rows.Add(DeclaracoesGeral.mPaginas[0, i]);
			}
			uHnSwNE1cF();
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

	private void uHnSwNE1cF()
	{
		checked
		{
			double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaginas)) ? ((double)(dgPaginas.Width - 4)) : ((double)(dgPaginas.Width - 21)));
			dgPaginas.Columns[0].Width = (int)Math.Round(a);
		}
	}

	private void sgrSxhI2bv(object P_0, EventArgs P_1)
	{
		if (!(cbTitulo1.Checked | cbTitulo2.Checked | cbTitulo3.Checked | cbTitulo4.Checked | cbText.Checked | cbMText.Checked) || Operators.CompareString(tbDe.Text, "", TextCompare: true) == 0)
		{
			return;
		}
		List<string> list = new List<string>();
		checked
		{
			int num = dgPaginas.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgPaginas.Rows[i].Selected)
				{
					list.Add(dgPaginas.Rows[i].Cells[0].Value.ToString());
				}
			}
			clsEditaTitulosTextos.EditaTitulosTextosDoDWG(cbTitulo1.Checked, cbTitulo2.Checked, cbTitulo3.Checked, cbTitulo4.Checked, cbText.Checked, cbMText.Checked, tbDe.Text, tbPara.Text, list);
		}
	}
}
