using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmCompilarFiacao : Form
{
	private IContainer tlrUtkH3At;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView aNUUjIqxZx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbRevisao")]
	private TextBox L31ULO24w8;

	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView jPCUwit34L;

	[AccessedThroughProperty("btAnalisar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button UsVUxF1StO;

	[AccessedThroughProperty("btSalvar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button H8gUbbxqgv;

	[AccessedThroughProperty("btApagar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button mJUUMATNQg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private Label gxtUOBZYx9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip SlYUIVnY8j;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private Label YcbU7VFYBi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPaineis")]
	private TextBox NPYUqySBMG;

	[AccessedThroughProperty("cbPreservar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox R3eUa6364o;

	[AccessedThroughProperty("btApagarComp")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button FCHU8lbvVa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgERROS")]
	[CompilerGenerated]
	private DataGridView IoLUNhrsXb;

	private DeclaracoesFiacao.structurePontosBlocos[] KmGUFiSNQK;

	private DeclaracoesFiacao.structurePnRev[] wxdUQ52YPH;

	private DeclaracoesFiacao.structureRevisoes[] vbwUPAPV2R;

	private DeclaracoesFiacao.structurePontosPotencial[] RUqUcVBHEP;

	private List<int> enPUKxbphX;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return aNUUjIqxZx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YwhUh2tjEl;
			DataGridView dataGridView = aNUUjIqxZx;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			aNUUjIqxZx = value;
			dataGridView = aNUUjIqxZx;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual TextBox tbRevisao
	{
		[CompilerGenerated]
		get
		{
			return L31ULO24w8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			L31ULO24w8 = value;
		}
	}

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return jPCUwit34L;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jPCUwit34L = value;
		}
	}

	internal virtual Button btAnalisar
	{
		[CompilerGenerated]
		get
		{
			return UsVUxF1StO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VowXCrBGXt;
			Button button = UsVUxF1StO;
			if (button != null)
			{
				button.Click -= value2;
			}
			UsVUxF1StO = value;
			button = UsVUxF1StO;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return H8gUbbxqgv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = scDXYM2SC8;
			Button button = H8gUbbxqgv;
			if (button != null)
			{
				button.Click -= value2;
			}
			H8gUbbxqgv = value;
			button = H8gUbbxqgv;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagar
	{
		[CompilerGenerated]
		get
		{
			return mJUUMATNQg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AeGUJPgHv4;
			Button button = mJUUMATNQg;
			if (button != null)
			{
				button.Click -= value2;
			}
			mJUUMATNQg = value;
			button = mJUUMATNQg;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return gxtUOBZYx9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gxtUOBZYx9 = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return YcbU7VFYBi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YcbU7VFYBi = value;
		}
	}

	internal virtual TextBox tbPaineis
	{
		[CompilerGenerated]
		get
		{
			return NPYUqySBMG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NPYUqySBMG = value;
		}
	}

	internal virtual CheckBox cbPreservar
	{
		[CompilerGenerated]
		get
		{
			return R3eUa6364o;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			R3eUa6364o = value;
		}
	}

	internal virtual Button btApagarComp
	{
		[CompilerGenerated]
		get
		{
			return FCHU8lbvVa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = buDUDVd1vH;
			Button button = FCHU8lbvVa;
			if (button != null)
			{
				button.Click -= value2;
			}
			FCHU8lbvVa = value;
			button = FCHU8lbvVa;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgERROS
	{
		[CompilerGenerated]
		get
		{
			return IoLUNhrsXb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = A1xUvoBou0;
			MouseEventHandler value3 = WsUU64i0Se;
			DataGridView dataGridView = IoLUNhrsXb;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.MouseUp -= value3;
			}
			IoLUNhrsXb = value;
			dataGridView = IoLUNhrsXb;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && tlrUtkH3At != null)
			{
				tlrUtkH3At.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void paLX42wYDB()
	{
		tlrUtkH3At = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		tbRevisao = new TextBox();
		dgEquip = new DataGridView();
		btAnalisar = new Button();
		btSalvar = new Button();
		btApagar = new Button();
		Label2 = new Label();
		FDqpBiUmZij(new ToolTip(tlrUtkH3At));
		Label3 = new Label();
		tbPaineis = new TextBox();
		cbPreservar = new CheckBox();
		btApagarComp = new Button();
		dgERROS = new DataGridView();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgERROS).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao.Location = new Point(249, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(246, 252);
		dgRevisao.TabIndex = 3;
		tbRevisao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbRevisao.Location = new Point(402, 378);
		tbRevisao.MaxLength = 5;
		tbRevisao.Name = "tbRevisao";
		tbRevisao.Size = new Size(42, 20);
		tbRevisao.TabIndex = 6;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 12);
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(160, 330);
		dgEquip.TabIndex = 7;
		btAnalisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAnalisar.FlatStyle = FlatStyle.Flat;
		btAnalisar.ForeColor = SystemColors.Control;
		btAnalisar.Image = Resources.Programacao_32;
		btAnalisar.Location = new Point(73, 359);
		btAnalisar.Name = "btAnalisar";
		btAnalisar.Size = new Size(40, 42);
		btAnalisar.TabIndex = 14;
		btAnalisar.UseVisualStyleBackColor = true;
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(450, 353);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 15;
		btSalvar.UseVisualStyleBackColor = true;
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(459, 300);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(36, 36);
		btApagar.TabIndex = 17;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Label2.AutoSize = true;
		Label2.Location = new Point(347, 381);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 18;
		Label2.Text = "Label2";
		Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Label3.AutoSize = true;
		Label3.Location = new Point(246, 275);
		Label3.Name = "Label3";
		Label3.Size = new Size(39, 13);
		Label3.TabIndex = 19;
		Label3.Text = "Label3";
		tbPaineis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbPaineis.BackColor = SystemColors.InactiveBorder;
		tbPaineis.Location = new Point(249, 293);
		tbPaineis.Multiline = true;
		tbPaineis.Name = "tbPaineis";
		tbPaineis.ReadOnly = true;
		tbPaineis.Size = new Size(195, 49);
		tbPaineis.TabIndex = 20;
		cbPreservar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		cbPreservar.AutoSize = true;
		cbPreservar.CheckAlign = ContentAlignment.MiddleRight;
		cbPreservar.Location = new Point(363, 355);
		cbPreservar.Name = "cbPreservar";
		cbPreservar.Size = new Size(81, 17);
		cbPreservar.TabIndex = 21;
		cbPreservar.Text = "CheckBox1";
		cbPreservar.UseVisualStyleBackColor = true;
		btApagarComp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarComp.FlatStyle = FlatStyle.Flat;
		btApagarComp.ForeColor = SystemColors.Control;
		btApagarComp.Image = Resources.ApagarComp_32;
		btApagarComp.Location = new Point(189, 300);
		btApagarComp.Name = "btApagarComp";
		btApagarComp.Size = new Size(40, 42);
		btApagarComp.TabIndex = 22;
		btApagarComp.UseVisualStyleBackColor = true;
		dgERROS.AllowUserToAddRows = false;
		dgERROS.AllowUserToDeleteRows = false;
		dgERROS.AllowUserToOrderColumns = true;
		dgERROS.AllowUserToResizeRows = false;
		dgERROS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgERROS.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgERROS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgERROS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgERROS.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgERROS.Location = new Point(178, 12);
		dgERROS.Name = "dgERROS";
		dgERROS.ReadOnly = true;
		dgERROS.RowHeadersVisible = false;
		dgERROS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgERROS.Size = new Size(65, 252);
		dgERROS.TabIndex = 23;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(507, 407);
		Controls.Add(dgERROS);
		Controls.Add(btApagarComp);
		Controls.Add(cbPreservar);
		Controls.Add(tbPaineis);
		Controls.Add(Label3);
		Controls.Add(Label2);
		Controls.Add(btApagar);
		Controls.Add(btSalvar);
		Controls.Add(btAnalisar);
		Controls.Add(dgEquip);
		Controls.Add(tbRevisao);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(523, 800);
		MinimumSize = new Size(523, 445);
		Name = "frmCompilarFiacao";
		ShowInTaskbar = false;
		Text = "Fiação";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgERROS).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return SlYUIVnY8j;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		SlYUIVnY8j = WithEventsValue;
	}

	public frmCompilarFiacao()
	{
		KmGUFiSNQK = new DeclaracoesFiacao.structurePontosBlocos[1];
		wxdUQ52YPH = new DeclaracoesFiacao.structurePnRev[1];
		vbwUPAPV2R = new DeclaracoesFiacao.structureRevisoes[1];
		RUqUcVBHEP = new DeclaracoesFiacao.structurePontosPotencial[1];
		try
		{
			if (Geral.ExisteForm("frmCompilarFiacao") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				paLX42wYDB();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 555]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]);
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 764]);
				cbPreservar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 765]);
				cbPreservar.Checked = true;
				w8dpBZ0kvSD().SetToolTip(btAnalisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 756]));
				w8dpBZ0kvSD().SetToolTip(btApagar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 757]));
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 758]));
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					Application.ShowModelessDialog((Form)this);
					formataDGEquip();
					CarregaDGEquip();
					formataDGRevisao();
					CarregaDGRevisao();
					CarregaPnRev();
					tQrUo1QSMG();
					formataDGErros(berros: false);
					btSalvar.Enabled = false;
					if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
					{
						Left = 0;
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 763]), MsgBoxStyle.Exclamation);
					new frmGerenciadorDWG();
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void VowXCrBGXt(object P_0, EventArgs P_1)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Obj, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected Obj, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected Obj, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected Obj, but got Unknown
		//IL_17a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ba: Expected Obj, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1808: Unknown result type (might be due to invalid IL or missing references)
		//IL_1838: Unknown result type (might be due to invalid IL or missing references)
		//IL_183d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1869: Unknown result type (might be due to invalid IL or missing references)
		//IL_186e: Unknown result type (might be due to invalid IL or missing references)
		//IL_189a: Unknown result type (might be due to invalid IL or missing references)
		//IL_189f: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Expected Obj, but got Unknown
		//IL_194b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1950: Unknown result type (might be due to invalid IL or missing references)
		//IL_1954: Unknown result type (might be due to invalid IL or missing references)
		//IL_195c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1963: Expected Obj, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2461: Unknown result type (might be due to invalid IL or missing references)
		//IL_2467: Unknown result type (might be due to invalid IL or missing references)
		//IL_1efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f11: Expected Obj, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_0855: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_101c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_1045: Unknown result type (might be due to invalid IL or missing references)
		//IL_104a: Unknown result type (might be due to invalid IL or missing references)
		//IL_106f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1074: Unknown result type (might be due to invalid IL or missing references)
		//IL_1091: Unknown result type (might be due to invalid IL or missing references)
		//IL_1096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_139b: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Unknown result type (might be due to invalid IL or missing references)
		//IL_112d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_144a: Unknown result type (might be due to invalid IL or missing references)
		//IL_144f: Unknown result type (might be due to invalid IL or missing references)
		//IL_147e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1483: Unknown result type (might be due to invalid IL or missing references)
		//IL_1154: Unknown result type (might be due to invalid IL or missing references)
		//IL_1159: Unknown result type (might be due to invalid IL or missing references)
		//IL_1175: Unknown result type (might be due to invalid IL or missing references)
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1197: Unknown result type (might be due to invalid IL or missing references)
		//IL_119c: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1569: Unknown result type (might be due to invalid IL or missing references)
		//IL_156e: Unknown result type (might be due to invalid IL or missing references)
		//IL_158a: Unknown result type (might be due to invalid IL or missing references)
		//IL_158f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1525: Unknown result type (might be due to invalid IL or missing references)
		//IL_152a: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1211: Unknown result type (might be due to invalid IL or missing references)
		//IL_1216: Unknown result type (might be due to invalid IL or missing references)
		//IL_1233: Unknown result type (might be due to invalid IL or missing references)
		//IL_1238: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1262: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1655: Unknown result type (might be due to invalid IL or missing references)
		//IL_165a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1681: Unknown result type (might be due to invalid IL or missing references)
		//IL_1686: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1318: Unknown result type (might be due to invalid IL or missing references)
		//IL_131d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0901: Unknown result type (might be due to invalid IL or missing references)
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2186: Unknown result type (might be due to invalid IL or missing references)
		//IL_218b: Unknown result type (might be due to invalid IL or missing references)
		//IL_218f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2194: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_220d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2212: Unknown result type (might be due to invalid IL or missing references)
		//IL_2216: Unknown result type (might be due to invalid IL or missing references)
		//IL_221b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2251: Unknown result type (might be due to invalid IL or missing references)
		//IL_2256: Unknown result type (might be due to invalid IL or missing references)
		//IL_225a: Unknown result type (might be due to invalid IL or missing references)
		//IL_225f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_076d: Unknown result type (might be due to invalid IL or missing references)
		//IL_093f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_0781: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Unknown result type (might be due to invalid IL or missing references)
		//IL_095b: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2405: Unknown result type (might be due to invalid IL or missing references)
		//IL_240a: Unknown result type (might be due to invalid IL or missing references)
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		ApagaBlocoErroFiacao();
		formataDGErros(berros: false);
		btAnalisar.Enabled = false;
		btSalvar.Enabled = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		KmGUFiSNQK = new DeclaracoesFiacao.structurePontosBlocos[1];
		RUqUcVBHEP = new DeclaracoesFiacao.structurePontosPotencial[1];
		List<string> list = new List<string>();
		List<ObjectId> list2 = new List<ObjectId>();
		List<string> list3 = new List<string>();
		enPUKxbphX = new List<int>();
		foreach (DataGridViewRow selectedRow in dgEquip.SelectedRows)
		{
			enPUKxbphX.Add(Conversions.ToInteger(selectedRow.Cells[0].Value));
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					try
					{
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val4.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current = enumerator2.Current;
								Entity val5 = (Entity)current.GetObject((OpenMode)0);
								try
								{
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									try
									{
										if (val6 == null)
										{
											continue;
										}
										Entity ent = (Entity)(object)val6;
										string tipoImportado = "";
										string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										string left = text;
										if (Operators.CompareString(left, "", TextCompare: true) != 0 && Operators.CompareString(left, "I", TextCompare: true) != 0 && Operators.CompareString(left, "M", TextCompare: true) != 0 && (Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "E", TextCompare: true) == 0 || Operators.CompareString(left, "B", TextCompare: true) == 0))
										{
											if (!list.Contains(val6.Name.ToString()))
											{
												list.Add(val6.Name.ToString());
											}
											list2.Add(((DBObject)val6).ObjectId);
										}
									}
									finally
									{
										((IDisposable)val6)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						DataTable dataTable = new DataTable();
						dataTable.Columns.Add("NomeBloco", typeof(string));
						dataTable.Columns.Add("XMin", typeof(double));
						dataTable.Columns.Add("XMax", typeof(double));
						dataTable.Columns.Add("YMin", typeof(double));
						dataTable.Columns.Add("YMax", typeof(double));
						BlockTableRecordEnumerator enumerator4 = default;
						Point3d val11;
						BlockTableRecordEnumerator enumerator5 = default;
						foreach (string item in list)
						{
							if (!((SymbolTable)val3).Has(item))
							{
								continue;
							}
							BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[item], (OpenMode)0);
							double num = 1000000.0;
							double num2 = -1000000.0;
							double num3 = 1000000.0;
							double num4 = -1000000.0;
							try
							{
								enumerator4 = val7.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									ObjectId current3 = enumerator4.Current;
									Entity val8 = (Entity)current3.GetObject((OpenMode)0);
									try
									{
										Polyline val9 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
										try
										{
											if (val9 != null)
											{
												int num5 = val9.NumberOfVertices - 1;
												for (int i = 0; i <= num5; i++)
												{
													Point2d point2dAt = val9.GetPoint2dAt(i);
													if (point2dAt.X < num)
													{
														num = point2dAt.X;
													}
													if (point2dAt.X > num2)
													{
														num2 = point2dAt.X;
													}
													if (point2dAt.Y < num3)
													{
														num3 = point2dAt.Y;
													}
													if (point2dAt.Y > num4)
													{
														num4 = point2dAt.Y;
													}
												}
											}
										}
										finally
										{
											((IDisposable)val9)?.Dispose();
										}
										Line val10 = (Line)(object)((val8 is Line) ? val8 : null);
										try
										{
											if (val10 != null)
											{
												val11 = val10.StartPoint;
												if (val11.X < num)
												{
													val11 = val10.StartPoint;
													num = val11.X;
												}
												val11 = val10.StartPoint;
												if (val11.X > num2)
												{
													val11 = val10.StartPoint;
													num2 = val11.X;
												}
												val11 = val10.StartPoint;
												if (val11.Y < num3)
												{
													val11 = val10.StartPoint;
													num3 = val11.Y;
												}
												val11 = val10.StartPoint;
												if (val11.Y > num4)
												{
													val11 = val10.StartPoint;
													num4 = val11.Y;
												}
												val11 = val10.EndPoint;
												if (val11.X < num)
												{
													val11 = val10.EndPoint;
													num = val11.X;
												}
												val11 = val10.EndPoint;
												if (val11.X > num2)
												{
													val11 = val10.EndPoint;
													num2 = val11.X;
												}
												val11 = val10.EndPoint;
												if (val11.Y < num3)
												{
													val11 = val10.EndPoint;
													num3 = val11.Y;
												}
												val11 = val10.EndPoint;
												if (val11.Y > num4)
												{
													val11 = val10.EndPoint;
													num4 = val11.Y;
												}
											}
										}
										finally
										{
											((IDisposable)val10)?.Dispose();
										}
										Circle val12 = (Circle)(object)((val8 is Circle) ? val8 : null);
										try
										{
											if (val12 != null)
											{
												val11 = val12.Center;
												if (val11.X + val12.Radius < num)
												{
													val11 = val12.Center;
													num = val11.X + val12.Radius;
												}
												val11 = val12.Center;
												if (val11.X + val12.Radius > num2)
												{
													val11 = val12.Center;
													num2 = val11.X + val12.Radius;
												}
												val11 = val12.Center;
												if (val11.Y < num3)
												{
													val11 = val12.Center;
													num3 = val11.Y;
												}
												val11 = val12.Center;
												if (val11.Y > num4)
												{
													val11 = val12.Center;
													num4 = val11.Y;
												}
												val11 = val12.Center;
												if (val11.X - val12.Radius < num)
												{
													val11 = val12.Center;
													num = val11.X - val12.Radius;
												}
												val11 = val12.Center;
												if (val11.X - val12.Radius > num2)
												{
													val11 = val12.Center;
													num2 = val11.X - val12.Radius;
												}
												val11 = val12.Center;
												if (val11.Y < num3)
												{
													val11 = val12.Center;
													num3 = val11.Y;
												}
												val11 = val12.Center;
												if (val11.Y > num4)
												{
													val11 = val12.Center;
													num4 = val11.Y;
												}
												val11 = val12.Center;
												if (val11.X < num)
												{
													val11 = val12.Center;
													num = val11.X;
												}
												val11 = val12.Center;
												if (val11.X > num2)
												{
													val11 = val12.Center;
													num2 = val11.X;
												}
												val11 = val12.Center;
												if (val11.Y - val12.Radius < num3)
												{
													val11 = val12.Center;
													num3 = val11.Y - val12.Radius;
												}
												val11 = val12.Center;
												if (val11.Y - val12.Radius > num4)
												{
													val11 = val12.Center;
													num4 = val11.Y - val12.Radius;
												}
												val11 = val12.Center;
												if (val11.X < num)
												{
													val11 = val12.Center;
													num = val11.X;
												}
												val11 = val12.Center;
												if (val11.X > num2)
												{
													val11 = val12.Center;
													num2 = val11.X;
												}
												val11 = val12.Center;
												if (val11.Y + val12.Radius < num3)
												{
													val11 = val12.Center;
													num3 = val11.Y + val12.Radius;
												}
												val11 = val12.Center;
												if (val11.Y + val12.Radius > num4)
												{
													val11 = val12.Center;
													num4 = val11.Y + val12.Radius;
												}
											}
										}
										finally
										{
											((IDisposable)val12)?.Dispose();
										}
										DBPoint val13 = (DBPoint)(object)((val8 is DBPoint) ? val8 : null);
										try
										{
											if (val13 != null)
											{
												val11 = val13.Position;
												if (val11.X < num)
												{
													val11 = val13.Position;
													num = val11.X;
												}
												val11 = val13.Position;
												if (val11.X > num2)
												{
													val11 = val13.Position;
													num2 = val11.X;
												}
												val11 = val13.Position;
												if (val11.Y < num3)
												{
													val11 = val13.Position;
													num3 = val11.Y;
												}
												val11 = val13.Position;
												if (val11.Y > num4)
												{
													val11 = val13.Position;
													num4 = val11.Y;
												}
											}
										}
										finally
										{
											((IDisposable)val13)?.Dispose();
										}
									}
									finally
									{
										((IDisposable)val8)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)enumerator4)?.Dispose();
							}
							DataRow dataRow = dataTable.NewRow();
							dataRow["NomeBloco"] = item;
							dataRow["XMin"] = num - 0.1;
							dataRow["XMax"] = num2 + 0.1;
							dataRow["YMin"] = num3 - 0.1;
							dataRow["YMax"] = num4 + 0.1;
							dataTable.Rows.Add(dataRow);
							try
							{
								enumerator5 = val7.GetEnumerator();
								while (enumerator5.MoveNext())
								{
									ObjectId current4 = enumerator5.Current;
									Entity val14 = (Entity)current4.GetObject((OpenMode)0);
									try
									{
										Polyline val15 = (Polyline)(object)((val14 is Polyline) ? val14 : null);
										try
										{
											if (val15 != null)
											{
												Point2d point2dAt2 = val15.GetPoint2dAt(0);
												if (e2gUGSU5el(point2dAt2.X, num, 1.0) | e2gUGSU5el(point2dAt2.X, num2, 1.0) | e2gUGSU5el(point2dAt2.Y, num3, 1.0) | e2gUGSU5el(point2dAt2.Y, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK = ref KmGUFiSNQK;
													kmGUFiSNQK = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].X = point2dAt2.X;
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].Y = point2dAt2.Y;
												}
												Point2d point2dAt3 = val15.GetPoint2dAt(val15.NumberOfVertices - 1);
												if (e2gUGSU5el(point2dAt3.X, num, 1.0) | e2gUGSU5el(point2dAt3.X, num2, 1.0) | e2gUGSU5el(point2dAt3.Y, num3, 1.0) | e2gUGSU5el(point2dAt3.Y, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK2 = ref KmGUFiSNQK;
													kmGUFiSNQK2 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK2, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].X = point2dAt3.X;
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].Y = point2dAt3.Y;
												}
											}
										}
										finally
										{
											((IDisposable)val15)?.Dispose();
										}
										Line val16 = (Line)(object)((val14 is Line) ? val14 : null);
										try
										{
											if (val16 != null)
											{
												val11 = val16.StartPoint;
												bool flag = e2gUGSU5el(val11.X, num, 1.0);
												val11 = val16.StartPoint;
												bool num6 = flag | e2gUGSU5el(val11.X, num2, 1.0);
												val11 = val16.StartPoint;
												bool num7 = num6 | e2gUGSU5el(val11.Y, num3, 1.0);
												val11 = val16.StartPoint;
												if (num7 | e2gUGSU5el(val11.Y, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK3 = ref KmGUFiSNQK;
													kmGUFiSNQK3 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK3, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													ref DeclaracoesFiacao.structurePontosBlocos reference = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val16.StartPoint;
													reference.X = val11.X;
													ref DeclaracoesFiacao.structurePontosBlocos reference2 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val16.StartPoint;
													reference2.Y = val11.Y;
												}
												val11 = val16.EndPoint;
												bool flag2 = e2gUGSU5el(val11.X, num, 1.0);
												val11 = val16.EndPoint;
												bool num8 = flag2 | e2gUGSU5el(val11.X, num2, 1.0);
												val11 = val16.EndPoint;
												bool num9 = num8 | e2gUGSU5el(val11.Y, num3, 1.0);
												val11 = val16.EndPoint;
												if (num9 | e2gUGSU5el(val11.Y, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK4 = ref KmGUFiSNQK;
													kmGUFiSNQK4 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK4, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													ref DeclaracoesFiacao.structurePontosBlocos reference3 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val16.EndPoint;
													reference3.X = val11.X;
													ref DeclaracoesFiacao.structurePontosBlocos reference4 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val16.EndPoint;
													reference4.Y = val11.Y;
												}
											}
										}
										finally
										{
											((IDisposable)val16)?.Dispose();
										}
										Circle val17 = (Circle)(object)((val14 is Circle) ? val14 : null);
										try
										{
											if (val17 != null)
											{
												val11 = val17.Center;
												bool flag3 = e2gUGSU5el(val11.X + val17.Radius, num, 1.0);
												val11 = val17.Center;
												bool num10 = flag3 | e2gUGSU5el(val11.X + val17.Radius, num2, 1.0);
												val11 = val17.Center;
												bool num11 = num10 | e2gUGSU5el(val11.Y, num3, 1.0);
												val11 = val17.Center;
												if (num11 | e2gUGSU5el(val11.Y, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK5 = ref KmGUFiSNQK;
													kmGUFiSNQK5 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK5, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													ref DeclaracoesFiacao.structurePontosBlocos reference5 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference5.X = val11.X + val17.Radius;
													ref DeclaracoesFiacao.structurePontosBlocos reference6 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference6.Y = val11.Y;
												}
												val11 = val17.Center;
												bool flag4 = e2gUGSU5el(val11.X - val17.Radius, num, 1.0);
												val11 = val17.Center;
												bool num12 = flag4 | e2gUGSU5el(val11.X - val17.Radius, num2, 1.0);
												val11 = val17.Center;
												bool num13 = num12 | e2gUGSU5el(val11.Y, num3, 1.0);
												val11 = val17.Center;
												if (num13 | e2gUGSU5el(val11.Y, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK6 = ref KmGUFiSNQK;
													kmGUFiSNQK6 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK6, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													ref DeclaracoesFiacao.structurePontosBlocos reference7 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference7.X = val11.X - val17.Radius;
													ref DeclaracoesFiacao.structurePontosBlocos reference8 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference8.Y = val11.Y;
												}
												val11 = val17.Center;
												bool flag5 = e2gUGSU5el(val11.X, num, 1.0);
												val11 = val17.Center;
												bool num14 = flag5 | e2gUGSU5el(val11.X, num2, 1.0);
												val11 = val17.Center;
												bool num15 = num14 | e2gUGSU5el(val11.Y - val17.Radius, num3, 1.0);
												val11 = val17.Center;
												if (num15 | e2gUGSU5el(val11.Y - val17.Radius, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK7 = ref KmGUFiSNQK;
													kmGUFiSNQK7 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK7, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													ref DeclaracoesFiacao.structurePontosBlocos reference9 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference9.X = val11.X;
													ref DeclaracoesFiacao.structurePontosBlocos reference10 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference10.Y = val11.Y - val17.Radius;
												}
												val11 = val17.Center;
												bool flag6 = e2gUGSU5el(val11.X, num, 1.0);
												val11 = val17.Center;
												bool num16 = flag6 | e2gUGSU5el(val11.X, num2, 1.0);
												val11 = val17.Center;
												bool num17 = num16 | e2gUGSU5el(val11.Y + val17.Radius, num3, 1.0);
												val11 = val17.Center;
												if (num17 | e2gUGSU5el(val11.Y + val17.Radius, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK8 = ref KmGUFiSNQK;
													kmGUFiSNQK8 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK8, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													ref DeclaracoesFiacao.structurePontosBlocos reference11 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference11.X = val11.X;
													ref DeclaracoesFiacao.structurePontosBlocos reference12 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val17.Center;
													reference12.Y = val11.Y + val17.Radius;
												}
											}
										}
										finally
										{
											((IDisposable)val17)?.Dispose();
										}
										DBPoint val18 = (DBPoint)(object)((val14 is DBPoint) ? val14 : null);
										try
										{
											if (val18 != null)
											{
												val11 = val18.Position;
												bool flag7 = e2gUGSU5el(val11.X, num, 1.0);
												val11 = val18.Position;
												bool num18 = flag7 | e2gUGSU5el(val11.X, num2, 1.0);
												val11 = val18.Position;
												bool num19 = num18 | e2gUGSU5el(val11.Y, num3, 1.0);
												val11 = val18.Position;
												if (num19 | e2gUGSU5el(val11.Y, num4, 1.0))
												{
													ref DeclaracoesFiacao.structurePontosBlocos[] kmGUFiSNQK9 = ref KmGUFiSNQK;
													kmGUFiSNQK9 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(kmGUFiSNQK9, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(KmGUFiSNQK) + 1 + 1]);
													KmGUFiSNQK[Information.UBound(KmGUFiSNQK)].nome = item;
													ref DeclaracoesFiacao.structurePontosBlocos reference13 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val18.Position;
													reference13.X = val11.X;
													ref DeclaracoesFiacao.structurePontosBlocos reference14 = ref KmGUFiSNQK[Information.UBound(KmGUFiSNQK)];
													val11 = val18.Position;
													reference14.Y = val11.Y;
												}
											}
										}
										finally
										{
											((IDisposable)val18)?.Dispose();
										}
									}
									finally
									{
										((IDisposable)val14)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)enumerator5)?.Dispose();
							}
						}
						DataTable dataTable2 = new DataTable();
						dataTable2.Columns.Add("ObjectID", typeof(ObjectId));
						dataTable2.Columns.Add("Layer", typeof(string));
						dataTable2.Columns.Add("XMin", typeof(double));
						dataTable2.Columns.Add("XMax", typeof(double));
						dataTable2.Columns.Add("YMin", typeof(double));
						dataTable2.Columns.Add("YMax", typeof(double));
						foreach (ObjectId item2 in list2)
						{
							ObjectId current5 = item2;
							BlockReference val19 = (BlockReference)current5.GetObject((OpenMode)0);
							try
							{
								string text2 = "";
								text2 = "NomeBloco='" + val19.Name + "'";
								DataRow[] array = dataTable.Select(text2);
								int upperBound = array.GetUpperBound(0);
								for (int j = 0; j <= upperBound; j++)
								{
									DataRow dataRow2 = dataTable2.NewRow();
									dataRow2["ObjectID"] = ((DBObject)val19).ObjectId;
									dataRow2["Layer"] = ((Entity)val19).Layer.ToString();
									val11 = val19.Position;
									dataRow2["XMin"] = Operators.AddObject(val11.X, array[j][1]);
									val11 = val19.Position;
									dataRow2["XMax"] = Operators.AddObject(val11.X, array[j][2]);
									val11 = val19.Position;
									dataRow2["YMin"] = Operators.AddObject(val11.Y, array[j][3]);
									val11 = val19.Position;
									dataRow2["YMax"] = Operators.AddObject(val11.Y, array[j][4]);
									dataTable2.Rows.Add(dataRow2);
								}
							}
							finally
							{
								((IDisposable)val19)?.Dispose();
							}
						}
						BlockTableRecordEnumerator enumerator7 = default;
						try
						{
							enumerator7 = val4.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								ObjectId current6 = enumerator7.Current;
								Entity val20 = (Entity)val2.GetObject(current6, (OpenMode)0);
								try
								{
									Polyline val21 = (Polyline)(object)((val20 is Polyline) ? val20 : null);
									try
									{
										if (val21 == null)
										{
											continue;
										}
										DeclaracoesEntidades.StructureConexao conex = default;
										Polyline pl = val21;
										if (!XDataConexao.lerXDataConexao(ref pl, ref conex) || !enPUKxbphX.Contains(conex.Painel))
										{
											continue;
										}
										if (((conex.Tipo == 1) & conex.Disp1) | (conex.Tipo == 2))
										{
											Point2d point2dAt4 = val21.GetPoint2dAt(0);
											ref DeclaracoesFiacao.structurePontosPotencial[] rUqUcVBHEP = ref RUqUcVBHEP;
											rUqUcVBHEP = (DeclaracoesFiacao.structurePontosPotencial[])Utils.CopyArray(rUqUcVBHEP, new DeclaracoesFiacao.structurePontosPotencial[Information.UBound(RUqUcVBHEP) + 1 + 1]);
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].X = point2dAt4.X;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].Y = point2dAt4.Y;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].potencial = conex.Potencial;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].painel = conex.Painel;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].secao = conex.Secao;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].cor = conex.Cor;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].layer = ((Entity)val21).Layer.ToString();
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].Aplicacao = conex.Aplicacao;
											if ((conex.Tipo == 1) | (conex.Tipo == 2))
											{
												RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].bJumper = false;
											}
										}
										if (((conex.Tipo == 1) & conex.Disp2) | (conex.Tipo == 2) | ((conex.Tipo == 3) & (Operators.CompareString(conex.Jumper.ToUpper(), "", TextCompare: true) == 0)))
										{
											Point2d point2dAt5 = val21.GetPoint2dAt(val21.NumberOfVertices - 1);
											ref DeclaracoesFiacao.structurePontosPotencial[] rUqUcVBHEP2 = ref RUqUcVBHEP;
											rUqUcVBHEP2 = (DeclaracoesFiacao.structurePontosPotencial[])Utils.CopyArray(rUqUcVBHEP2, new DeclaracoesFiacao.structurePontosPotencial[Information.UBound(RUqUcVBHEP) + 1 + 1]);
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].X = point2dAt5.X;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].Y = point2dAt5.Y;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].potencial = conex.Potencial;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].painel = conex.Painel;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].secao = conex.Secao;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].cor = conex.Cor;
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].layer = ((Entity)val21).Layer.ToString();
											RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].Aplicacao = conex.Aplicacao;
											if ((conex.Tipo == 1) | (conex.Tipo == 2) | ((conex.Tipo == 3) & (Operators.CompareString(conex.Jumper.ToUpper(), "", TextCompare: true) == 0)))
											{
												RUqUcVBHEP[Information.UBound(RUqUcVBHEP)].bJumper = false;
											}
										}
									}
									finally
									{
										((IDisposable)val21)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val20)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator7)?.Dispose();
						}
						DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(RUqUcVBHEP);
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num20 = Information.UBound(RUqUcVBHEP);
						for (int k = 1; k <= num20; k++)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							string text3 = "";
							text3 = "Layer='" + RUqUcVBHEP[k].layer.ToString() + "' AND " + RUqUcVBHEP[k].X.ToString("F", CultureInfo.InvariantCulture) + ">= XMin AND " + RUqUcVBHEP[k].X.ToString("F", CultureInfo.InvariantCulture) + "<= XMax AND " + RUqUcVBHEP[k].Y.ToString("F", CultureInfo.InvariantCulture) + ">= YMin AND " + RUqUcVBHEP[k].Y.ToString("F", CultureInfo.InvariantCulture) + "<= YMax";
							DataRow[] array2 = dataTable2.Select(text3);
							int upperBound2 = array2.GetUpperBound(0);
							int num21 = 0;
							while (true)
							{
								if (num21 <= upperBound2)
								{
									object obj = array2[num21][0];
									ObjectId val22 = ((obj == null) ? default(ObjectId) : ((ObjectId)obj));
									BlockReference val23 = (BlockReference)val22.GetObject((OpenMode)0);
									try
									{
										string sRegua = "";
										string text4 = "";
										string sAlternativo = "";
										short num22 = 0;
										short tipoBorne = 0;
										short indexModelo = 0;
										Entity ent = (Entity)(object)val23;
										string tipoImportado = "";
										string text5 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										string left2 = text5;
										if (Operators.CompareString(left2, "", TextCompare: true) != 0 && Operators.CompareString(left2, "I", TextCompare: true) != 0 && Operators.CompareString(left2, "M", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left2, "P", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left2, "A", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left2, "E", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left2, "B", TextCompare: true) == 0)
														{
															BlockReference blockRef = val23;
															object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
															DeclaracoesEntidades.StructureBorne structureBorne = ((obj2 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj2));
															indexModelo = (short)structureBorne.IndiceRegua;
															int iRegua = indexModelo;
															int num23 = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref iRegua, ref sRegua, ref sAlternativo);
															indexModelo = (short)iRegua;
															num22 = (short)num23;
															text4 = "";
															tipoBorne = (short)structureBorne.tipo;
														}
													}
													else
													{
														BlockReference blockRef = val23;
														object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
														DeclaracoesEntidades.StructurePortas structurePortas = ((obj3 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj3));
														sRegua = structurePortas.Nome1;
														text4 = structurePortas.Nome2;
														sAlternativo = structurePortas.Alternativo;
														ent = (Entity)(object)val23;
														num22 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
														tipoBorne = -1;
														indexModelo = (short)structurePortas.indiceDoModelo;
													}
												}
												else
												{
													BlockReference blockRef = val23;
													object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj4 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj4));
													sRegua = structureAuxiliar.Nome1;
													text4 = structureAuxiliar.Nome2;
													sAlternativo = structureAuxiliar.Alternativo;
													ent = (Entity)(object)val23;
													num22 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
													tipoBorne = -1;
													indexModelo = (short)structureAuxiliar.IndexModelo;
												}
											}
											else
											{
												BlockReference blockRef = val23;
												object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj5 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj5));
												sRegua = structureDispositivo.Nome1;
												text4 = structureDispositivo.Nome2;
												sAlternativo = structureDispositivo.Alternativo;
												num22 = structureDispositivo.Painel;
												tipoBorne = -1;
												indexModelo = (short)structureDispositivo.indexModelo;
											}
											if ((RUqUcVBHEP[k].painel == num22) & (num22 > 0))
											{
												double num24 = RUqUcVBHEP[k].X;
												Extents3d value = ((Drawable)val23).Bounds.Value;
												val11 = value.MinPoint;
												bool flag8 = num24 >= val11.X - 0.25;
												double num25 = RUqUcVBHEP[k].X;
												value = ((Drawable)val23).Bounds.Value;
												val11 = value.MaxPoint;
												bool num26 = flag8 & (num25 <= val11.X + 0.25);
												double num27 = RUqUcVBHEP[k].Y;
												value = ((Drawable)val23).Bounds.Value;
												val11 = value.MinPoint;
												bool num28 = num26 & (num27 >= val11.Y - 0.25);
												double num29 = RUqUcVBHEP[k].Y;
												value = ((Drawable)val23).Bounds.Value;
												val11 = value.MaxPoint;
												if (num28 & (num29 <= val11.Y + 0.25))
												{
													string terminal = "";
													double terminalNum = 0.0;
													string nRegua = "";
													int num30 = k;
													BlockReference blockRef = val23;
													if (ltZUHdAX7R(num30, ref blockRef, text5, 0.5, ref terminal, ref terminalNum, ref nRegua))
													{
														RUqUcVBHEP[k].tag = sRegua;
														if (Operators.CompareString(text4, "", TextCompare: true) != 0)
														{
															ref string tag = ref RUqUcVBHEP[k].tag;
															tag = tag + "/" + text4;
														}
														RUqUcVBHEP[k].nRegua = nRegua;
														RUqUcVBHEP[k].alternativo = sAlternativo;
														RUqUcVBHEP[k].terminal = terminal;
														RUqUcVBHEP[k].terminalNum = terminalNum;
														RUqUcVBHEP[k].tipo = text5;
														if (Operators.CompareString(text5, "B", TextCompare: true) != 0)
														{
															RUqUcVBHEP[k].PosicaoNum = 0;
															RUqUcVBHEP[k].dOrdem = -1.0;
														}
														else
														{
															RUqUcVBHEP[k].PosicaoNum = 1;
															RUqUcVBHEP[k].dOrdem = DicionarioReguas.BuscaIndiceDeUmaRegua(sRegua, num22);
														}
														RUqUcVBHEP[k].tipoBorne = tipoBorne;
														RUqUcVBHEP[k].handle = ((object)((DBObject)val23).Handle/*cast due to constrained. prefix*/).ToString();
														RUqUcVBHEP[k].indexModelo = indexModelo;
														RUqUcVBHEP[k].bLink = false;
														break;
													}
												}
											}
										}
									}
									finally
									{
										((IDisposable)val23)?.Dispose();
									}
									num21++;
									continue;
								}
								InsereBlocoErroFiacao(RUqUcVBHEP[k].layer, RUqUcVBHEP[k].X, RUqUcVBHEP[k].Y);
								if (!list3.Contains(RUqUcVBHEP[k].layer.ToString()))
								{
									list3.Add(RUqUcVBHEP[k].layer.ToString());
								}
								DeclaracoesGeral.bAnularEventos = true;
								break;
							}
						}
						list3.Sort();
						if (list3.Count <= 0)
						{
							btSalvar.Enabled = true;
						}
						else
						{
							formataDGErros(berros: true);
							list3.Sort();
							foreach (string item3 in list3)
							{
								dgERROS.Rows.Add(item3);
							}
						}
						DataGridView withEventsValue = dgERROS;
						OrdenarAZ(ref withEventsValue);
						dgERROS = withEventsValue;
						btAnalisar.Enabled = true;
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						DeclaracoesGeral._uscPagina.pbFim();
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val2.Abort();
						ProjectData.ClearProjectError();
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			if (dgERROS.RowCount > 0)
			{
				dgERROS.Rows[0].Selected = false;
			}
		}
	}

	public void OrdenarAZ(ref DataGridView dgERROS)
	{
		if (dgERROS.Rows.Count == 0)
		{
			return;
		}
		string text = "";
		string text2 = "";
		checked
		{
			if (dgERROS.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = dgERROS.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = dgERROS.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					text = Conversions.ToString(dgERROS.Rows[j].Cells[0].Value);
					text2 = Conversions.ToString(dgERROS.Rows[j + 1].Cells[0].Value);
					if (!(Versioned.IsNumeric(text) & Versioned.IsNumeric(text2)))
					{
						if (Operators.CompareString(text, text2, TextCompare: true) > 0)
						{
							string value = Conversions.ToString(dgERROS.Rows[j].Cells[0].Value);
							dgERROS.Rows[j].Cells[0].Value = RuntimeHelpers.GetObjectValue(dgERROS.Rows[j + 1].Cells[0].Value);
							dgERROS.Rows[j + 1].Cells[0].Value = value;
						}
					}
					else if (Conversions.ToDouble(text) > Conversions.ToDouble(text2))
					{
						string value2 = Conversions.ToString(dgERROS.Rows[j].Cells[0].Value);
						dgERROS.Rows[j].Cells[0].Value = RuntimeHelpers.GetObjectValue(dgERROS.Rows[j + 1].Cells[0].Value);
						dgERROS.Rows[j + 1].Cells[0].Value = value2;
					}
				}
			}
		}
	}

	private void scDXYM2SC8(object P_0, EventArgs P_1)
	{
		btSalvar.Enabled = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		checked
		{
			if (DicionarioLayout.ExisteDicLayout())
			{
				cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
				cDadosAtualizaBanco2.LimpaDWGApagadosDoProjeto();
				cDadosAtualizaBanco2.fechaConexao();
				bool flag = false;
				string text = tbRevisao.Text.ToString().Trim();
				if (Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					if (dgRevisao.RowCount > 0)
					{
						foreach (DataGridViewRow item in (IEnumerable)dgRevisao.Rows)
						{
							string left = Conversions.ToString(item.Cells[0].Value);
							if (Operators.CompareString(left, text, TextCompare: true) == 0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						DeclaracoesGeral.bAnularEventos = true;
						try
						{
							DeclaracoesFiacao.structurePosicaoDisp[] mPosicao = new DeclaracoesFiacao.structurePosicaoDisp[1];
							foreach (int item2 in enPUKxbphX)
							{
								DicionarioLayout.buscaDicLayoutPainel("P", item2, ref mPosicao);
								DicionarioLayout.buscaDicLayoutPainel("C", item2, ref mPosicao);
							}
							DataTable dataTable = new DataTable();
							dataTable.Columns.Add("Painel", typeof(int));
							dataTable.Columns.Add("Potencial", typeof(int));
							dataTable.Columns.Add("Ordem", typeof(double));
							dataTable.Columns.Add("Pagina", typeof(string));
							dataTable.Columns.Add("Tag", typeof(string));
							dataTable.Columns.Add("Alternativo", typeof(string));
							dataTable.Columns.Add("Terminal", typeof(string));
							dataTable.Columns.Add("TerminalNum", typeof(double));
							dataTable.Columns.Add("Tipo", typeof(string));
							dataTable.Columns.Add("Secao", typeof(string));
							dataTable.Columns.Add("Cor", typeof(string));
							dataTable.Columns.Add("PosicaoNum", typeof(int));
							dataTable.Columns.Add("TipoBorne", typeof(int));
							dataTable.Columns.Add("BJumper", typeof(bool));
							dataTable.Columns.Add("BLink", typeof(bool));
							dataTable.Columns.Add("Handle", typeof(string));
							dataTable.Columns.Add("IndexModelo", typeof(int));
							dataTable.Columns.Add("NRegua", typeof(string));
							dataTable.Columns.Add("Aplicacao", typeof(int));
							int num = Information.UBound(RUqUcVBHEP);
							for (int i = 1; i <= num; i++)
							{
								DataRow dataRow = dataTable.NewRow();
								dataRow["Painel"] = RUqUcVBHEP[i].painel;
								dataRow["Potencial"] = RUqUcVBHEP[i].potencial;
								dataRow["Pagina"] = RUqUcVBHEP[i].layer;
								dataRow["Tag"] = RUqUcVBHEP[i].tag;
								dataRow["Alternativo"] = RUqUcVBHEP[i].alternativo;
								dataRow["Terminal"] = RUqUcVBHEP[i].terminal;
								dataRow["TerminalNum"] = RUqUcVBHEP[i].terminalNum;
								dataRow["Tipo"] = RUqUcVBHEP[i].tipo;
								dataRow["Secao"] = RUqUcVBHEP[i].secao;
								dataRow["Cor"] = RUqUcVBHEP[i].cor;
								dataRow["TipoBorne"] = RUqUcVBHEP[i].tipoBorne;
								dataRow["BJumper"] = RUqUcVBHEP[i].bJumper;
								dataRow["BLink"] = RUqUcVBHEP[i].bLink;
								dataRow["Handle"] = RUqUcVBHEP[i].handle;
								dataRow["IndexModelo"] = RUqUcVBHEP[i].indexModelo;
								dataRow["NRegua"] = RUqUcVBHEP[i].nRegua;
								dataRow["Aplicacao"] = RUqUcVBHEP[i].Aplicacao;
								if (Operators.CompareString(RUqUcVBHEP[i].tipo, "B", TextCompare: true) != 0)
								{
									dataRow["PosicaoNum"] = 0;
									dataRow["Ordem"] = 0;
									int num2 = Information.UBound(mPosicao);
									for (int j = 1; j <= num2; j++)
									{
										if ((mPosicao[j].painel == RUqUcVBHEP[i].painel) & (Operators.CompareString(mPosicao[j].tag, RUqUcVBHEP[i].tag, TextCompare: true) == 0))
										{
											dataRow["PosicaoNum"] = mPosicao[j].posicaoNum;
											dataRow["Ordem"] = mPosicao[j].ordem;
											break;
										}
									}
								}
								else
								{
									dataRow["PosicaoNum"] = RUqUcVBHEP[i].PosicaoNum;
									dataRow["Ordem"] = RUqUcVBHEP[i].dOrdem;
								}
								dataTable.Rows.Add(dataRow);
							}
							string filterExpression = "Potencial > 0";
							string sort = "Potencial ASC, PosicaoNum DESC, Ordem, TerminalNum, Terminal";
							DataRow[] array = dataTable.Select(filterExpression, sort);
							int num3 = 0;
							int num4 = 0;
							DeclaracoesGeral._uscPagina.Quantidade = array.GetUpperBound(0);
							DeclaracoesGeral._uscPagina.pbIniciar();
							DateTime now = DateTime.Now;
							cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
							int upperBound = array.GetUpperBound(0);
							for (int k = 0; k <= upperBound; k++)
							{
								DeclaracoesGeral._uscPagina.pbPasso();
								DeclaracoesFiacao.structurePontosPotencial pot = new DeclaracoesFiacao.structurePontosPotencial
								{
									painel = Conversions.ToShort(array[k][0]),
									potencial = Conversions.ToInteger(array[k][1]),
									dOrdem = Conversions.ToDouble(array[k][2])
								};
								if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
								{
									if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
									{
										if (DeclaracoesGeral.Conf.incluirColuna == 6)
										{
											pot.layer = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", array[k][3]), ")"));
											string text2 = Pagina.BuscaAlternativo(Conversions.ToString(array[k][3]), bretornaVazio: true);
											if (Operators.CompareString(text2, "", TextCompare: true) != 0)
											{
												ref string layer = ref pot.layer;
												layer = layer + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
											}
										}
									}
									else
									{
										pot.layer = Pagina.BuscaAlternativo(Conversions.ToString(array[k][3]), bretornaVazio: false);
									}
								}
								else
								{
									pot.layer = Conversions.ToString(array[k][3]);
								}
								pot.tag = Conversions.ToString(array[k][4]);
								pot.alternativo = Conversions.ToString(array[k][5]);
								pot.terminal = Conversions.ToString(array[k][6]);
								pot.terminalNum = Conversions.ToDouble(array[k][7]);
								pot.tipo = Conversions.ToString(array[k][8]);
								pot.secao = Conversions.ToString(array[k][9]);
								pot.cor = Conversions.ToString(array[k][10]);
								pot.PosicaoNum = Conversions.ToInteger(array[k][11]);
								pot.tipoBorne = Conversions.ToShort(array[k][12]);
								pot.bJumper = Conversions.ToBoolean(array[k][13]);
								pot.bLink = Conversions.ToBoolean(array[k][14]);
								pot.handle = Conversions.ToString(array[k][15]);
								pot.indexModelo = Conversions.ToShort(array[k][16]);
								pot.nRegua = Conversions.ToString(array[k][17]);
								pot.Aplicacao = Conversions.ToInteger(array[k][18]);
								if (pot.potencial != num3)
								{
									num3 = pot.potencial;
									num4 = 0;
								}
								num4 = (pot.Ordem = num4 + 1);
								pot.revisao = text;
								pot.dwg = DeclaracoesGeral.arqAtivo.Indice;
								pot.criador = Environment.UserName;
								pot.data = now;
								cDadosAccessFiacao2.AdicionaItemPotencial(pot);
							}
							if (cbPreservar.Checked && Information.UBound(wxdUQ52YPH) != 0)
							{
								DeclaracoesFiacao.structurePnRev[] array2 = new DeclaracoesFiacao.structurePnRev[1];
								array2 = new DeclaracoesFiacao.structurePnRev[1];
								foreach (int item3 in enPUKxbphX)
								{
									int num5 = Information.UBound(wxdUQ52YPH);
									for (int l = 1; l <= num5; l++)
									{
										if (wxdUQ52YPH[l].painel == item3)
										{
											array2 = (DeclaracoesFiacao.structurePnRev[])Utils.CopyArray(array2, new DeclaracoesFiacao.structurePnRev[Information.UBound(array2) + 1 + 1]);
											array2[Information.UBound(array2)].painel = wxdUQ52YPH[l].painel;
											array2[Information.UBound(array2)].revisao = wxdUQ52YPH[l].revisao;
											break;
										}
									}
								}
								DataTable varTableFiacaoH = new DataTable();
								varTableFiacaoH.Columns.Add("Potencial", typeof(int));
								varTableFiacaoH.Columns.Add("Handle", typeof(string));
								varTableFiacaoH.Columns.Add("Terminal", typeof(string));
								varTableFiacaoH.Columns.Add("Ordem", typeof(double));
								varTableFiacaoH.Columns.Add("BLink", typeof(bool));
								DeclaracoesFiacao.structurePontosPotencial[] mPot = new DeclaracoesFiacao.structurePontosPotencial[1];
								int num6 = Information.UBound(array2);
								for (int m = 1; m <= num6; m++)
								{
									cDadosAccessFiacao2.CarregaPotenciais(DeclaracoesGeral.arqAtivo.Indice, array2[m].revisao, array2[m].painel, ref mPot);
								}
								int num7 = Information.UBound(mPot);
								for (int n = 1; n <= num7; n++)
								{
									DataRow dataRow2 = varTableFiacaoH.NewRow();
									dataRow2["Potencial"] = mPot[n].potencial;
									dataRow2["Handle"] = mPot[n].handle;
									dataRow2["Terminal"] = mPot[n].terminal;
									dataRow2["Ordem"] = mPot[n].Ordem;
									dataRow2["BLink"] = mPot[n].bLink;
									varTableFiacaoH.Rows.Add(dataRow2);
								}
								if (varTableFiacaoH.Rows.Count > 0)
								{
									cDadosAccessFiacao2.AtualizaPotenciais(DeclaracoesGeral.arqAtivo.Indice, text, ref varTableFiacaoH);
									cDadosAccessFiacao2.ReordenaOrdemPotenciais(DeclaracoesGeral.arqAtivo.Indice, text);
								}
							}
							cDadosAccessFiacao2.RemoveRevisaoTabela("Circuitos4F", DeclaracoesGeral.arqAtivo.Indice, text);
							t6yXrlfi5w(ref cDadosAccessFiacao2);
							cDadosAccessFiacao2.RemoveRevisaoTabela("Contatos4F", DeclaracoesGeral.arqAtivo.Indice, text);
							WPcX9UGCKZ(ref cDadosAccessFiacao2);
							cDadosAccessFiacao2.RemoveRevisaoTabela("Portas4F", DeclaracoesGeral.arqAtivo.Indice, text);
							NNYXzPbSi2(ref cDadosAccessFiacao2);
							cDadosAccessFiacao2.RemoveRevisaoTabela("Bornes4F", DeclaracoesGeral.arqAtivo.Indice, text);
							F85UWVZrkZ(ref cDadosAccessFiacao2);
							cDadosAccessFiacao2.RemoveRevisaoTabela("Dispositivos4F", DeclaracoesGeral.arqAtivo.Indice, text);
							eIxUpEGYnp(ref cDadosAccessFiacao2, ref mPosicao);
							cDadosAccessFiacao2.RemoveRevisaoTabela("Aplicacao4F", DeclaracoesGeral.arqAtivo.Indice, text);
							FiRUTW6Q6W(ref cDadosAccessFiacao2);
							DeclaracoesGeral._uscPagina.pbFim();
							cDadosAccessFiacao2.fechaConexao();
							formataDGRevisao();
							CarregaDGRevisao();
							CarregaPnRev();
							tQrUo1QSMG();
							return;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							Interaction.MsgBox(ex2.Message);
							ProjectData.ClearProjectError();
							return;
						}
						finally
						{
							DeclaracoesGeral.bAnularEventos = false;
						}
					}
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 762]), MsgBoxStyle.Exclamation);
					btSalvar.Enabled = true;
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 761]), MsgBoxStyle.Exclamation);
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 759]), MsgBoxStyle.Exclamation);
			}
		}
	}

	private void t6yXrlfi5w(ref cDadosAccessFiacao P_0)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		string revisao = tbRevisao.Text.ToString().Trim();
		List<int> list = new List<int>();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl != null)
						{
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex) && enPUKxbphX.Contains(conex.Painel) && ((conex.Tipo == 1) & (Operators.CompareString(conex.Nome.Trim(), "", TextCompare: true) != 0)) && !list.Contains(conex.Potencial))
							{
								list.Add(conex.Potencial);
								P_0.AdicionaItemCircuitos(revisao, DeclaracoesGeral.arqAtivo.Indice, conex.Painel, conex.Nome, conex.Potencial);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void WPcX9UGCKZ(ref cDadosAccessFiacao P_0)
	{
		string revisao = tbRevisao.Text.ToString().Trim();
		Declaracoes2.MModelosDeContatos[] mModelo = new Declaracoes2.MModelosDeContatos[1];
		List<int> lModelosEmUso = new List<int>();
		clsDispositivoTacito.carregaModelosUsadosBobinas(ref lModelosEmUso, ref enPUKxbphX);
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
		checked
		{
			try
			{
				if (Information.UBound(mModelo) <= 0)
				{
					return;
				}
				int num = Information.UBound(mModelo);
				for (int i = 1; i <= num; i++)
				{
					List<string> lTerminais = new List<string>();
					List<string> lOrientacoes = new List<string>();
					long num2 = mModelo[i].iIndiceModelo;
					string sNomeModelo = mModelo[i].sNomeModelo;
					if (!lModelosEmUso.Contains((int)num2))
					{
						continue;
					}
					string text = "";
					string text2 = "";
					if (Operators.CompareString(mModelo[i].sTerminaisDoDispositivo.Trim(), "", TextCompare: true) != 0)
					{
						text = mModelo[i].sTerminaisDoDispositivo.Trim();
						Geral.DivideTerminais(ref lTerminais, text);
					}
					if (Operators.CompareString(mModelo[i].sOrientacao.Trim(), "", TextCompare: true) != 0)
					{
						text2 = mModelo[i].sOrientacao.Trim();
						Geral.DivideOrientacoes(ref lOrientacoes, text2);
					}
					text = clsDispositivoTacito.carregaTerminaisBobinas((int)num2, ref enPUKxbphX);
					if (Operators.CompareString(text, "", TextCompare: true) != 0)
					{
						Geral.DivideTerminais(ref lTerminais, text);
					}
					int num3 = 1;
					foreach (string item in lTerminais)
					{
						double terminalNum = clsConexao.CalculaTerminalNumerico(item);
						string orientacao = "";
						if (lOrientacoes.Count >= num3)
						{
							orientacao = lOrientacoes.ElementAt(num3 - 1);
						}
						P_0.AdicionaItemContatos(revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, item, terminalNum, orientacao);
						P_0.atualizaItemOrientacaoFiacao(orientacao, revisao, DeclaracoesGeral.arqAtivo.Indice, num2, item, "P");
						num3++;
					}
					Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = new Declaracoes2.StructureContatosAuxiliares[1];
					int iIndiceSelecionado = (int)num2;
					bool flag = DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref mCONTATOS);
					num2 = iIndiceSelecionado;
					if (!flag)
					{
						continue;
					}
					int num4 = Information.UBound(mCONTATOS);
					for (int j = 1; j <= num4; j++)
					{
						List<string> lOrientacoes2 = new List<string>();
						string text3 = "";
						if (Operators.CompareString(mCONTATOS[j].sOrientacao.Trim(), "", TextCompare: true) == 0)
						{
							int num5 = 1;
							do
							{
								lOrientacoes2.Add("");
								num5++;
							}
							while (num5 <= 3);
						}
						else
						{
							text3 = mCONTATOS[j].sOrientacao.Trim();
							Geral.DivideOrientacoes(ref lOrientacoes2, text3);
							if (lOrientacoes2.Count < 3)
							{
								int num6 = 3 - lOrientacoes2.Count;
								for (int k = 1; k <= num6; k++)
								{
									lOrientacoes2.Add("");
								}
							}
						}
						string sT = mCONTATOS[j].sT1;
						if (Operators.CompareString(sT.Trim(), "", TextCompare: true) != 0)
						{
							double terminalNum2 = clsConexao.CalculaTerminalNumerico(sT);
							P_0.AdicionaItemContatos(revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, sT, terminalNum2, lOrientacoes2.ElementAt(0));
							P_0.atualizaItemOrientacaoFiacao(lOrientacoes2.ElementAt(0), revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sT, "A");
						}
						sT = mCONTATOS[j].sT2;
						if (Operators.CompareString(sT.Trim(), "", TextCompare: true) != 0)
						{
							double terminalNum3 = clsConexao.CalculaTerminalNumerico(sT);
							P_0.AdicionaItemContatos(revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, sT, terminalNum3, lOrientacoes2.ElementAt(1));
							P_0.atualizaItemOrientacaoFiacao(lOrientacoes2.ElementAt(1), revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sT, "A");
						}
						sT = mCONTATOS[j].sT3;
						if (Operators.CompareString(sT.Trim(), "", TextCompare: true) != 0)
						{
							double terminalNum4 = clsConexao.CalculaTerminalNumerico(sT);
							P_0.AdicionaItemContatos(revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, sT, terminalNum4, lOrientacoes2.ElementAt(2));
							P_0.atualizaItemOrientacaoFiacao(lOrientacoes2.ElementAt(2), revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sT, "A");
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	private void NNYXzPbSi2(ref cDadosAccessFiacao P_0)
	{
		string revisao = tbRevisao.Text.ToString().Trim();
		Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
		List<int> lModelosEmUso = new List<int>();
		clsDispositivoTacito.carregaModelosUsadosMascaras(ref lModelosEmUso, ref enPUKxbphX);
		if (!DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: true))
		{
			return;
		}
		int num = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				long num2 = mModelo[i].iIndiceModelo;
				string sNomeModelo = mModelo[i].sNomeModelo;
				if (!lModelosEmUso.Contains((int)num2))
				{
					continue;
				}
				Declaracoes2.MModeloDePortas[] mPortas = new Declaracoes2.MModeloDePortas[1];
				int iIndiceSelecionado = (int)num2;
				bool flag = DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado, sNomeModelo, ref mPortas);
				num2 = iIndiceSelecionado;
				if (!flag)
				{
					continue;
				}
				int num3 = Information.UBound(mPortas);
				for (int j = 1; j <= num3; j++)
				{
					string text = mPortas[j].sTerminais.Trim();
					string text2 = mPortas[j].sBornes.Trim();
					string text3 = mPortas[j].sRegua.Trim();
					string text4 = mPortas[j].sOrientacao.Trim();
					string text5 = "";
					if (!((Operators.CompareString(text3, "", TextCompare: true) != 0) & (Operators.CompareString(text2, "", TextCompare: true) != 0) & (Operators.CompareString(text2, ";", TextCompare: true) != 0)))
					{
						if (!((Operators.CompareString(text, "", TextCompare: true) != 0) & (Operators.CompareString(text, ";", TextCompare: true) != 0)))
						{
							continue;
						}
						List<string> lTerminais = new List<string>();
						List<string> lOrientacoes = new List<string>();
						Geral.DivideTerminais(ref lTerminais, text);
						if (Operators.CompareString(text4, "", TextCompare: true) == 0)
						{
							int count = lTerminais.Count;
							for (int k = 1; k <= count; k++)
							{
								lOrientacoes.Add("");
							}
						}
						else
						{
							Geral.DivideOrientacoes(ref lOrientacoes, text4);
							if (lOrientacoes.Count < lTerminais.Count)
							{
								int num4 = lOrientacoes.Count + 1;
								int count2 = lTerminais.Count;
								for (int l = num4; l <= count2; l++)
								{
									lOrientacoes.Add("");
								}
							}
						}
						int num5 = 0;
						foreach (string item in lTerminais)
						{
							double terminalNum = clsConexao.CalculaTerminalNumerico(item);
							P_0.AdicionaItemPortas(revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, "", "", item, terminalNum, "T", lOrientacoes.ElementAt(num5));
							P_0.atualizaItemOrientacaoFiacao(lOrientacoes.ElementAt(num5), revisao, DeclaracoesGeral.arqAtivo.Indice, num2, item, "E");
							num5++;
						}
						continue;
					}
					List<string> lTerminais2 = new List<string>();
					Geral.DivideTerminais(ref lTerminais2, text2, bRepete: true);
					List<string> lTerminais3 = new List<string>();
					Geral.DivideTerminais(ref lTerminais3, text3);
					int num6 = 0;
					foreach (string item2 in lTerminais2)
					{
						string text6 = item2;
						if (text6.StartsWith("*"))
						{
							text6 = text6.Remove(0, 1);
						}
						text5 = ((lTerminais3.Count > num6) ? lTerminais3[num6] : text3);
						double terminalNum2 = clsConexao.CalculaTerminalNumerico(text6);
						P_0.AdicionaItemPortas(revisao, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, text5, text6, "", terminalNum2, "B");
						num6++;
					}
				}
			}
		}
	}

	private void F85UWVZrkZ(ref cDadosAccessFiacao P_0)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected Obj, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		string revisao = tbRevisao.Text.ToString().Trim();
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		Declaracoes2.StructureModeloDeReguas[] array = new Declaracoes2.StructureModeloDeReguas[1];
		if (!DicionarioReguas.LeOsModelosDeRegua(ref mModelo))
		{
			return;
		}
		int num = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (enPUKxbphX.Contains(mModelo[i].indexPainel))
				{
					array = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(array, new Declaracoes2.StructureModeloDeReguas[Information.UBound(array) + 1 + 1]);
					array[Information.UBound(array)] = mModelo[i];
				}
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)current.GetObject((OpenMode)0);
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 == null)
									{
										continue;
									}
									Entity ent = (Entity)(object)val6;
									string tipoImportado = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									string left = text;
									if (Operators.CompareString(left, "B", TextCompare: true) != 0)
									{
										continue;
									}
									BlockReference blockRef = val6;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructureBorne born = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
									born.indexPainel = 0;
									int num2 = Information.UBound(mModelo);
									for (int j = 1; j <= num2; j++)
									{
										if (mModelo[j].indexRegua == born.IndiceRegua)
										{
											born.indexPainel = mModelo[j].indexPainel;
											born.NomeRegua = mModelo[j].nomeRegua;
											break;
										}
									}
									if (born.indexPainel == 0 || !enPUKxbphX.Contains(born.indexPainel))
									{
										continue;
									}
									born.Alternativo = "";
									born.reserva = false;
									born.Handle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
									{
										if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
										{
											if (DeclaracoesGeral.Conf.incluirColuna == 6)
											{
												born.pagina = "(" + ((Entity)val6).Layer.ToString() + ")";
												string text2 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
												if (Operators.CompareString(text2, "", TextCompare: true) != 0)
												{
													ref string pagina = ref born.pagina;
													pagina = pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
												}
											}
										}
										else
										{
											born.pagina = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: false);
										}
									}
									else
									{
										born.pagina = ((Entity)val6).Layer.ToString();
									}
									if (Operators.CompareString(born.Orientacao.Trim(), "", TextCompare: true) == 0)
									{
										born.Orientacao = "";
									}
									P_0.AdicionaItemBornes(revisao, DeclaracoesGeral.arqAtivo.Indice, born);
									P_0.atualizaItemOrientacaoFiacao(born.Orientacao, revisao, DeclaracoesGeral.arqAtivo.Indice, born.IndiceRegua, born.Numero, "B");
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			int num3 = Information.UBound(array);
			for (int k = 1; k <= num3; k++)
			{
				DeclaracoesEntidades.StructureBorne[] mBornes = new DeclaracoesEntidades.StructureBorne[1];
				int qSimples = 0;
				int qDuplo = 0;
				if (!DicionarioBorne.LeDicBornesReserva(array[k].indexRegua, ref mBornes, ref qSimples, ref qDuplo))
				{
					continue;
				}
				int num4 = Information.UBound(mBornes);
				for (int l = 1; l <= num4; l++)
				{
					mBornes[l].IndiceRegua = array[k].indexRegua;
					mBornes[l].NomeRegua = array[k].nomeRegua;
					mBornes[l].Handle = "";
					mBornes[l].indexPainel = array[k].indexPainel;
					if (Operators.CompareString(mBornes[l].Orientacao.Trim(), "", TextCompare: true) == 0)
					{
						mBornes[l].Orientacao = "";
					}
					P_0.AdicionaItemBornes(revisao, DeclaracoesGeral.arqAtivo.Indice, mBornes[l]);
				}
			}
		}
	}

	private void eIxUpEGYnp(ref cDadosAccessFiacao P_0, ref DeclaracoesFiacao.structurePosicaoDisp[] P_1)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		string revisao = tbRevisao.Text.ToString().Trim();
		Declaracoes2.MModelosDeContatos[] mModelo = new Declaracoes2.MModelosDeContatos[1];
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
		Declaracoes2.MModeloDeMascara[] mModelo2 = new Declaracoes2.MModeloDeMascara[1];
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo2, bComplementarModelo: true);
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)current.GetObject((OpenMode)0);
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 == null)
									{
										continue;
									}
									Entity ent = (Entity)(object)val6;
									string tipoImportado = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									string text2 = "";
									string text3 = "";
									string text4 = "";
									int num = 0;
									string text5 = "";
									string text6 = "";
									string blocoTopografico = "";
									string blocoLayout = "";
									int posicaoNum = 0;
									int ordem = 0;
									string left = text;
									BlockReference blockRef;
									if (Operators.CompareString(left, "M", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "P", TextCompare: true) != 0)
										{
											continue;
										}
										blockRef = val6;
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
										if (structureDispositivo.Complementar || !enPUKxbphX.Contains(structureDispositivo.Painel))
										{
											continue;
										}
										text2 = structureDispositivo.Nome1;
										text3 = structureDispositivo.Nome2;
										Tag = text2;
										if (Operators.CompareString(text3, "", TextCompare: true) != 0)
										{
											Tag = Operators.AddObject(Tag, "/" + text3);
										}
										text4 = structureDispositivo.Alternativo;
										num = structureDispositivo.Painel;
										text5 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
										if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
										{
											if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
											{
												if (DeclaracoesGeral.Conf.incluirColuna == 6)
												{
													text6 = "(" + ((Entity)val6).Layer.ToString() + ")";
													string text7 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
													if (Operators.CompareString(text7, "", TextCompare: true) != 0)
													{
														text6 = text6 + DeclaracoesGeral.Conf.SeparadorCruzamento + text7;
													}
												}
											}
											else
											{
												text6 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: false);
											}
										}
										else
										{
											text6 = ((Entity)val6).Layer.ToString();
										}
										if (structureDispositivo.indexModelo != 0)
										{
											int num2 = Information.UBound(mModelo);
											for (int i = 1; i <= num2; i++)
											{
												if (mModelo[i].iIndiceModelo == structureDispositivo.indexModelo)
												{
													blocoTopografico = mModelo[i].sBlocoTopografico;
													blocoLayout = mModelo[i].sBlocoLayout;
													break;
												}
											}
										}
										else
										{
											blocoTopografico = structureDispositivo.Topografico;
											blocoLayout = structureDispositivo.Layout;
										}
										int num3 = Information.UBound(P_1);
										for (int j = 1; j <= num3; j++)
										{
											if (Conversions.ToBoolean(Operators.AndObject(P_1[j].painel == num, Operators.CompareObjectEqual(P_1[j].tag, Tag, TextCompare: true))))
											{
												posicaoNum = P_1[j].posicaoNum;
												ordem = P_1[j].ordem;
												break;
											}
										}
										P_0.AdicionaItemDispositivos(revisao, DeclaracoesGeral.arqAtivo.Indice, num, Conversions.ToString(Tag), text4, text, text5, text6, blocoTopografico, blocoLayout, posicaoNum, ordem);
										continue;
									}
									blockRef = val6;
									object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
									if (structureMascara.Complementar || !enPUKxbphX.Contains(structureMascara.Painel))
									{
										continue;
									}
									text2 = structureMascara.Nome1;
									text3 = structureMascara.Nome2;
									Tag = text2;
									if (Operators.CompareString(text3, "", TextCompare: true) != 0)
									{
										Tag = Operators.AddObject(Tag, "/" + text3);
									}
									text4 = structureMascara.Alternativo;
									num = structureMascara.Painel;
									text5 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
									{
										if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
										{
											if (DeclaracoesGeral.Conf.incluirColuna == 6)
											{
												text6 = "(" + ((Entity)val6).Layer.ToString() + ")";
												string text8 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
												if (Operators.CompareString(text8, "", TextCompare: true) != 0)
												{
													text6 = text6 + DeclaracoesGeral.Conf.SeparadorCruzamento + text8;
												}
											}
										}
										else
										{
											text6 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: false);
										}
									}
									else
									{
										text6 = ((Entity)val6).Layer.ToString();
									}
									if (structureMascara.indexModelo > 0)
									{
										int num4 = Information.UBound(mModelo2);
										for (int k = 1; k <= num4; k++)
										{
											if (mModelo2[k].iIndiceModelo == structureMascara.indexModelo)
											{
												blocoTopografico = mModelo2[k].sBlocoTopografico;
												blocoLayout = mModelo2[k].sBlocoLayout;
												break;
											}
										}
									}
									int num5 = Information.UBound(P_1);
									for (int l = 1; l <= num5; l++)
									{
										if (Conversions.ToBoolean(Operators.AndObject(P_1[l].painel == num, Operators.CompareObjectEqual(P_1[l].tag, Tag, TextCompare: true))))
										{
											posicaoNum = P_1[l].posicaoNum;
											ordem = P_1[l].ordem;
											break;
										}
									}
									P_0.AdicionaItemDispositivos(revisao, DeclaracoesGeral.arqAtivo.Indice, num, Conversions.ToString(Tag), text4, text, text5, text6, blocoTopografico, blocoLayout, posicaoNum, ordem);
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	private void FiRUTW6Q6W(ref cDadosAccessFiacao P_0)
	{
		string revisao = tbRevisao.Text.ToString().Trim();
		DeclaracoesFiacao.structureAplicacao[] mAplicacao = new DeclaracoesFiacao.structureAplicacao[1];
		DicionarioAplicacao.LeOsTiposDeAplicacoes(ref mAplicacao);
		int num = Information.UBound(mAplicacao);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			P_0.AdicionaItemAplicacao(revisao, DeclaracoesGeral.arqAtivo.Indice, mAplicacao[i].Indice, mAplicacao[i].Nome, mAplicacao[i].Secao, mAplicacao[i].Cor, mAplicacao[i].TipoCabo, mAplicacao[i].Isolacao);
		}
	}

	private void AeGUJPgHv4(object P_0, EventArgs P_1)
	{
		if (dgRevisao.SelectedRows.Count != 0)
		{
			string revisao = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 760]), MsgBoxStyle.YesNo);
			if (msgBoxResult != MsgBoxResult.No)
			{
				cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
				cDadosAccessFiacao2.RemoveRevisaoTabela("Fiacao", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessFiacao2.RemoveRevisaoTabela("Contatos4F", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessFiacao2.RemoveRevisaoTabela("Portas4F", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessFiacao2.RemoveRevisaoTabela("Bornes4F", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessFiacao2.RemoveRevisaoTabela("Dispositivos4F", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessFiacao2.RemoveRevisaoTabela("Circuitos4F", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessFiacao2.RemoveRevisaoTabela("Aplicacao4F", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessFiacao2.fechaConexao();
				formataDGRevisao();
				CarregaDGRevisao();
				CarregaPnRev();
				tQrUo1QSMG();
			}
		}
	}

	private void YwhUh2tjEl(object P_0, EventArgs P_1)
	{
		tQrUo1QSMG();
	}

	private void tQrUo1QSMG()
	{
		tbPaineis.Text = "";
		if (dgRevisao.SelectedRows.Count != 1)
		{
			return;
		}
		string right = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
		int num = Information.UBound(wxdUQ52YPH);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (Operators.CompareString(wxdUQ52YPH[i].revisao, right, TextCompare: true) == 0)
				{
					TextBox textBox;
					(textBox = tbPaineis).Text = textBox.Text + Dicionario.BuscaNomeDoPainel(wxdUQ52YPH[i].painel) + "  +  ";
				}
			}
			if (tbPaineis.Text.Length > 4)
			{
				tbPaineis.Text = tbPaineis.Text.Substring(0, tbPaineis.Text.Length - 5);
			}
		}
	}

	private bool e2gUGSU5el(double P_0, double P_1, double P_2)
	{
		bool result = false;
		double num = P_1 - P_0;
		if (num < 0.0)
		{
			num *= -1.0;
		}
		if (num <= P_2)
		{
			result = true;
		}
		return result;
	}

	private bool ltZUHdAX7R(int P_0, ref BlockReference P_1, string P_2, double P_3, ref string P_4, ref double P_5, ref string P_6)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			double num = RUqUcVBHEP[P_0].X;
			double num2 = RUqUcVBHEP[P_0].Y;
			double num3 = 0.0;
			double num4 = 0.0;
			bool flag = false;
			int num5 = Information.UBound(KmGUFiSNQK);
			for (int i = 1; i <= num5; i = checked(i + 1))
			{
				if (Operators.CompareString(KmGUFiSNQK[i].nome, P_1.Name, TextCompare: true) != 0)
				{
					if (flag)
					{
						break;
					}
					continue;
				}
				flag = true;
				Point3d position = P_1.Position;
				num3 = position.X + KmGUFiSNQK[i].X;
				position = P_1.Position;
				num4 = position.Y + KmGUFiSNQK[i].Y;
				double num6 = Math.Sqrt(Math.Pow(num3 - num, 2.0) + Math.Pow(num4 - num2, 2.0));
				if (!(num6 <= P_3))
				{
					continue;
				}
				if (Operators.CompareString(P_2, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(P_2, "P", TextCompare: true) != 0 && Operators.CompareString(P_2, "A", TextCompare: true) != 0)
					{
						if (Operators.CompareString(P_2, "E", TextCompare: true) == 0)
						{
							int num7 = 1;
							int num8 = 0;
							WtfUdoRkDO(ref P_1, num, num2, ref P_4, ref num7, ref num8);
							if (num7 != 2)
							{
								P_6 = "";
							}
							else
							{
								f2yUfcqdnE(ref P_1, num, num2, ref P_6, num8);
							}
						}
					}
					else
					{
						bH5UkrkXfZ(ref P_1, num, num2, ref P_4);
					}
					P_5 = clsConexao.CalculaTerminalNumerico(P_4);
					if ((Operators.CompareString(P_4.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(P_4.Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0))
					{
						result = true;
					}
				}
				else
				{
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref P_1);
					DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
					P_4 = structureBorne.Numero;
					if (Operators.CompareString(structureBorne.NumeroComplem, "", TextCompare: true) != 0)
					{
						P_4 += structureBorne.NumeroComplem;
					}
					P_5 = structureBorne.Ordem;
					if ((Operators.CompareString(P_4.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(P_4.Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0))
					{
						result = true;
					}
				}
				break;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
		return result;
	}

	private void bH5UkrkXfZ(ref BlockReference P_0, double P_1, double P_2, ref string P_3)
	{
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Invalid comparison between Unknown and I4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 100.0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			AttributeCollection attributeCollection = P_0.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val2 = (AttributeReference)topTransaction.GetObject(val, (OpenMode)0);
				double num3 = 0.0;
				double num4 = 0.0;
				string left = Strings.Mid(val2.Tag.ToString().ToUpper(), 1, 1);
				if ((Operators.CompareString(left, "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val2.Tag.ToString().ToUpper(), 2)))
				{
					Point3d val3;
					if ((int)((DBText)val2).Justify != 10)
					{
						val3 = ((DBText)val2).AlignmentPoint;
						num3 = val3.X;
						val3 = ((DBText)val2).AlignmentPoint;
						num4 = val3.Y;
					}
					else
					{
						val3 = ((DBText)val2).Position;
						num3 = val3.X;
						val3 = ((DBText)val2).Position;
						num4 = val3.Y;
					}
					num = Math.Sqrt(Math.Pow(num3 - P_1, 2.0) + Math.Pow(num4 - P_2, 2.0));
					if (num < num2)
					{
						num2 = num;
						P_3 = ((DBText)val2).TextString;
					}
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
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	private void WtfUdoRkDO(ref BlockReference P_0, double P_1, double P_2, ref string P_3, ref int P_4, ref int P_5)
	{
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Invalid comparison between Unknown and I4
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 100.0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			AttributeCollection attributeCollection = P_0.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val2 = (AttributeReference)topTransaction.GetObject(val, (OpenMode)0);
				try
				{
					double num3 = 0.0;
					double num4 = 0.0;
					string text = Strings.Mid(val2.Tag.ToString().ToUpper(), 1, 1);
					if (!(((Operators.CompareString(text, "T", TextCompare: true) == 0) | (Operators.CompareString(text, "B", TextCompare: true) == 0)) & Versioned.IsNumeric(Strings.Mid(val2.Tag.ToString().ToUpper(), 2))))
					{
						continue;
					}
					int num5 = Conversions.ToInteger(Strings.Mid(val2.Tag.ToString().ToUpper(), 2));
					Point3d val3;
					if ((int)((DBText)val2).Justify != 10)
					{
						val3 = ((DBText)val2).AlignmentPoint;
						num3 = val3.X;
						val3 = ((DBText)val2).AlignmentPoint;
						num4 = val3.Y;
					}
					else
					{
						val3 = ((DBText)val2).Position;
						num3 = val3.X;
						val3 = ((DBText)val2).Position;
						num4 = val3.Y;
					}
					num = Math.Sqrt(Math.Pow(num3 - P_1, 2.0) + Math.Pow(num4 - P_2, 2.0));
					if (!(num < num2))
					{
						continue;
					}
					P_5 = num5;
					num2 = num;
					P_3 = ((DBText)val2).TextString;
					string left = text;
					if (Operators.CompareString(left, "T", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "B", TextCompare: true) == 0)
						{
							P_4 = 2;
						}
					}
					else
					{
						P_4 = 1;
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
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
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	private void f2yUfcqdnE(ref BlockReference P_0, double P_1, double P_2, ref string P_3, int P_4)
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			AttributeCollection attributeCollection = P_0.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val2 = (AttributeReference)topTransaction.GetObject(val, (OpenMode)0);
				try
				{
					string left = Strings.Mid(val2.Tag.ToString().ToUpper(), 1, 1);
					string text = Strings.Mid(val2.Tag.ToString().ToUpper(), 2);
					if (!Versioned.IsNumeric(text) || !((Operators.CompareString(left, "R", TextCompare: true) == 0) & (P_4 == Conversions.ToInteger(text))))
					{
						if ((Operators.CompareString(left, "R", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val2.Tag.ToString().ToUpper(), 2)))
						{
							P_3 = ((DBText)val2).TextString;
						}
						continue;
					}
					P_3 = ((DBText)val2).TextString;
					break;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
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
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public void InsereBlocoErroFiacao(string layer, double x, double y)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cadgraph\\Eletron4\\";
		string text2 = "ErroFiacao";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			ObjectId val = ObjectId.Null;
			BlockTable val2 = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
			if (!((SymbolTable)val2).Has(text2))
			{
				Database val4 = new Database(false, true);
				string text3 = text + text2 + ".dwg";
				val4.ReadDwgFile(text3, FileShare.Read, true, "");
				((DBObject)val2).UpgradeOpen();
				DeclaracoesGeral.bAnularEventos = true;
				val = database.Insert(text2, val4, false);
				((DisposableWrapper)val4).Dispose();
			}
			else
			{
				BlockTableRecord val5 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[text2], (OpenMode)0);
				val = ((DBObject)val5).Id;
			}
			Point3d val6 = new Point3d(x, y, 0.0);
			BlockReference val7 = new BlockReference(val6, val);
			((Entity)val7).Layer = layer;
			val3.AppendEntity((Entity)(object)val7);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	private void buDUDVd1vH(object P_0, EventArgs P_1)
	{
		formataDGErros(berros: false);
		ApagaBlocoErroFiacao();
	}

	public void ApagaBlocoErroFiacao()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
					if (!((SymbolTable)val3).Has("ErroFiacao"))
					{
						return;
					}
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)["ErroFiacao"], (OpenMode)1);
					ObjectIdCollection blockReferenceIds = val4.GetBlockReferenceIds(true, true);
					foreach (object item in blockReferenceIds)
					{
						ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						BlockReference val6 = (BlockReference)val2.GetObject(val5, (OpenMode)1, false, true);
						((DBObject)val6).Erase();
					}
					((DBObject)val4).Erase(true);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
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

	public void CarregaDGEquip()
	{
		try
		{
			List<int> lEquip = new List<int>();
			clsConexao.carregaEquipComFiacao(ref lEquip);
			if (Information.IsNothing(DeclaracoesGeral.dicPainel))
			{
				cDadosAccess.carregaPainelDicionario();
			}
			foreach (int key in DeclaracoesGeral.dicPainel.Keys)
			{
				if (lEquip.Contains(key))
				{
					dgEquip.Rows.Add(key, DeclaracoesGeral.dicPainel[key]);
				}
			}
			dgEquip.SelectAll();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void formataDGRevisao()
	{
		checked
		{
			try
			{
				dgRevisao.Rows.Clear();
				dgRevisao.Columns.Clear();
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 753]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 754]));
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num * 2f / 8f);
				dgRevisao.Columns[1].Width = (int)Math.Round(num * 2f / 8f);
				dgRevisao.Columns[2].Width = (int)Math.Round(num * 4f / 8f);
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

	public void formataDGErros(bool berros)
	{
		try
		{
			dgERROS.Rows.Clear();
			dgERROS.Columns.Clear();
			if (berros)
			{
				dgERROS.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 755]));
				AtualizaDGErros();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGErros()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgERROS)) ? ((double)(dgERROS.Width - 4)) : ((double)(dgERROS.Width - 21)));
				dgERROS.Columns[0].Width = (int)Math.Round(a);
				int num = dgERROS.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgERROS.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
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

	public void CarregaDGRevisao()
	{
		vbwUPAPV2R = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(DeclaracoesGeral.arqAtivo.Indice, ref vbwUPAPV2R);
			int num = Information.UBound(vbwUPAPV2R);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgRevisao.Rows.Add(vbwUPAPV2R[i].revisao, vbwUPAPV2R[i].criador, vbwUPAPV2R[i].data);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	public void CarregaPnRev()
	{
		wxdUQ52YPH = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(vbwUPAPV2R) > 0)
			{
				int num = Information.UBound(vbwUPAPV2R);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(DeclaracoesGeral.arqAtivo.Indice, vbwUPAPV2R[i].revisao, ref wxdUQ52YPH);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void A1xUvoBou0(object P_0, MouseEventArgs P_1)
	{
		mostraPagina();
	}

	private void WsUU64i0Se(object P_0, MouseEventArgs P_1)
	{
		mostraPagina();
	}

	public void mostraPagina()
	{
		if (dgERROS.RowCount != 0 && dgERROS.SelectedRows.Count > 0)
		{
			Pagina.AtivaPagina(Conversions.ToString(dgERROS.SelectedRows[0].Cells[0].Value));
			uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
			DataGridViewCell dataGridViewCell;
			string pag = Conversions.ToString((dataGridViewCell = dgERROS.SelectedRows[0].Cells[0]).Value);
			uscPagina.ativaPaginaAtalho(ref pag);
			dataGridViewCell.Value = pag;
		}
	}
}
