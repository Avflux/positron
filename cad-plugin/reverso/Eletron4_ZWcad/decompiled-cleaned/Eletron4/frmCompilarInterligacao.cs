using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
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
public class frmCompilarInterligacao : Form
{
	private IContainer O8NUuVpbZU;

	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView PEyUE8cJU4;

	[AccessedThroughProperty("tbRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox xSGUZGy89Y;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAnalisar")]
	private Button beRUiIW02x;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	private Button t6HUSP5twT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	private Button I6sU4mCkhe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label TmmUCIqRkw;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip tiZUYkhffS;

	[AccessedThroughProperty("btApagarComp")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button Y4KUrR59SJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgERROS")]
	private DataGridView YUVU9QxGuk;

	private DeclaracoesFiacao.structurePontosBlocos[] mknUzyUVsW;

	private DeclaracoesFiacao.structureRevisoes[] TYbyWFwKw7;

	private DeclaracoesInterligacao.structureInterlig[] ssqypmV1FI;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return PEyUE8cJU4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PEyUE8cJU4 = value;
		}
	}

	internal virtual TextBox tbRevisao
	{
		[CompilerGenerated]
		get
		{
			return xSGUZGy89Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xSGUZGy89Y = value;
		}
	}

	internal virtual Button btAnalisar
	{
		[CompilerGenerated]
		get
		{
			return beRUiIW02x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PjTU2VW2uB;
			Button button = beRUiIW02x;
			if (button != null)
			{
				button.Click -= value2;
			}
			beRUiIW02x = value;
			button = beRUiIW02x;
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
			return t6HUSP5twT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bYQUnDSi6X;
			Button button = t6HUSP5twT;
			if (button != null)
			{
				button.Click -= value2;
			}
			t6HUSP5twT = value;
			button = t6HUSP5twT;
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
			return I6sU4mCkhe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uZbURRkc6n;
			Button button = I6sU4mCkhe;
			if (button != null)
			{
				button.Click -= value2;
			}
			I6sU4mCkhe = value;
			button = I6sU4mCkhe;
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
			return TmmUCIqRkw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TmmUCIqRkw = value;
		}
	}

	internal virtual Button btApagarComp
	{
		[CompilerGenerated]
		get
		{
			return Y4KUrR59SJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CZIUsNUGye;
			Button button = Y4KUrR59SJ;
			if (button != null)
			{
				button.Click -= value2;
			}
			Y4KUrR59SJ = value;
			button = Y4KUrR59SJ;
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
			return YUVU9QxGuk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = xkZUBQ71Z8;
			MouseEventHandler value3 = gVVUVHuGMZ;
			DataGridView dataGridView = YUVU9QxGuk;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.MouseUp -= value3;
			}
			YUVU9QxGuk = value;
			dataGridView = YUVU9QxGuk;
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
			if (disposing && O8NUuVpbZU != null)
			{
				O8NUuVpbZU.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Br3Ue1Cm49()
	{
		O8NUuVpbZU = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		tbRevisao = new TextBox();
		btAnalisar = new Button();
		btSalvar = new Button();
		btApagar = new Button();
		Label2 = new Label();
		FDqpBiUmZij(new ToolTip(O8NUuVpbZU));
		btApagarComp = new Button();
		dgERROS = new DataGridView();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgERROS).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
		dgRevisao.Location = new Point(11, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(277, 258);
		dgRevisao.TabIndex = 3;
		tbRevisao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbRevisao.Location = new Point(134, 289);
		tbRevisao.MaxLength = 5;
		tbRevisao.Name = "tbRevisao";
		tbRevisao.Size = new Size(42, 20);
		tbRevisao.TabIndex = 6;
		btAnalisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAnalisar.FlatStyle = FlatStyle.Flat;
		btAnalisar.ForeColor = SystemColors.Control;
		btAnalisar.Image = Resources.Programacao_32;
		btAnalisar.Location = new Point(11, 274);
		btAnalisar.Name = "btAnalisar";
		btAnalisar.Size = new Size(40, 42);
		btAnalisar.TabIndex = 14;
		btAnalisar.UseVisualStyleBackColor = true;
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(194, 274);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 15;
		btSalvar.UseVisualStyleBackColor = true;
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(252, 277);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(36, 36);
		btApagar.TabIndex = 17;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label2.AutoSize = true;
		Label2.Location = new Point(82, 292);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 18;
		Label2.Text = "Label2";
		btApagarComp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarComp.FlatStyle = FlatStyle.Flat;
		btApagarComp.ForeColor = SystemColors.Control;
		btApagarComp.Image = Resources.ApagarComp_32;
		btApagarComp.Location = new Point(313, 271);
		btApagarComp.Name = "btApagarComp";
		btApagarComp.Size = new Size(40, 42);
		btApagarComp.TabIndex = 23;
		btApagarComp.UseVisualStyleBackColor = true;
		dgERROS.AllowUserToAddRows = false;
		dgERROS.AllowUserToDeleteRows = false;
		dgERROS.AllowUserToOrderColumns = true;
		dgERROS.AllowUserToResizeRows = false;
		dgERROS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgERROS.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgERROS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgERROS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgERROS.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgERROS.Location = new Point(294, 12);
		dgERROS.Name = "dgERROS";
		dgERROS.ReadOnly = true;
		dgERROS.RowHeadersVisible = false;
		dgERROS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgERROS.Size = new Size(65, 258);
		dgERROS.TabIndex = 24;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(374, 321);
		Controls.Add(dgERROS);
		Controls.Add(btApagarComp);
		Controls.Add(Label2);
		Controls.Add(btApagar);
		Controls.Add(btSalvar);
		Controls.Add(btAnalisar);
		Controls.Add(tbRevisao);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(390, 1000);
		MinimumSize = new Size(390, 360);
		Name = "frmCompilarInterligacao";
		ShowInTaskbar = false;
		Text = "Interligação";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgERROS).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return tiZUYkhffS;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		tiZUYkhffS = WithEventsValue;
	}

	public frmCompilarInterligacao()
	{
		mknUzyUVsW = new DeclaracoesFiacao.structurePontosBlocos[1];
		TYbyWFwKw7 = new DeclaracoesFiacao.structureRevisoes[1];
		ssqypmV1FI = new DeclaracoesInterligacao.structureInterlig[1];
		try
		{
			if (Geral.ExisteForm("frmCompilarInterligacao") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				Br3Ue1Cm49();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 899]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]);
				w8dpBZ0kvSD().SetToolTip(btAnalisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1400]));
				w8dpBZ0kvSD().SetToolTip(btApagar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 757]));
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1401]));
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					Application.ShowModelessDialog((Form)this);
					formataDGRevisao();
					CarregaDGRevisao();
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

	private void PjTU2VW2uB(object P_0, EventArgs P_1)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected Obj, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected Obj, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Obj, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected Obj, but got Unknown
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected Obj, but got Unknown
		//IL_173a: Unknown result type (might be due to invalid IL or missing references)
		//IL_173f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1749: Unknown result type (might be due to invalid IL or missing references)
		//IL_1750: Expected Obj, but got Unknown
		//IL_179e: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1805: Unknown result type (might be due to invalid IL or missing references)
		//IL_180a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1836: Unknown result type (might be due to invalid IL or missing references)
		//IL_183b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1867: Unknown result type (might be due to invalid IL or missing references)
		//IL_186c: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1d: Expected Obj, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18db: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ea: Expected Obj, but got Unknown
		//IL_0a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_1122: Unknown result type (might be due to invalid IL or missing references)
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_114b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1150: Unknown result type (might be due to invalid IL or missing references)
		//IL_1175: Unknown result type (might be due to invalid IL or missing references)
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1197: Unknown result type (might be due to invalid IL or missing references)
		//IL_119c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14da: Unknown result type (might be due to invalid IL or missing references)
		//IL_11be: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1211: Unknown result type (might be due to invalid IL or missing references)
		//IL_1216: Unknown result type (might be due to invalid IL or missing references)
		//IL_1233: Unknown result type (might be due to invalid IL or missing references)
		//IL_1238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10db: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1107: Unknown result type (might be due to invalid IL or missing references)
		//IL_110c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c59: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1550: Unknown result type (might be due to invalid IL or missing references)
		//IL_1555: Unknown result type (might be due to invalid IL or missing references)
		//IL_1584: Unknown result type (might be due to invalid IL or missing references)
		//IL_1589: Unknown result type (might be due to invalid IL or missing references)
		//IL_125a: Unknown result type (might be due to invalid IL or missing references)
		//IL_125f: Unknown result type (might be due to invalid IL or missing references)
		//IL_127b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1280: Unknown result type (might be due to invalid IL or missing references)
		//IL_129d: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1034: Unknown result type (might be due to invalid IL or missing references)
		//IL_1039: Unknown result type (might be due to invalid IL or missing references)
		//IL_1060: Unknown result type (might be due to invalid IL or missing references)
		//IL_1065: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1604: Unknown result type (might be due to invalid IL or missing references)
		//IL_162b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1630: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1317: Unknown result type (might be due to invalid IL or missing references)
		//IL_131c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1339: Unknown result type (might be due to invalid IL or missing references)
		//IL_133e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1363: Unknown result type (might be due to invalid IL or missing references)
		//IL_1368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_141e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1423: Unknown result type (might be due to invalid IL or missing references)
		//IL_091f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0964: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2475: Unknown result type (might be due to invalid IL or missing references)
		//IL_247b: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0980: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d8: Expected Obj, but got Unknown
		//IL_2415: Unknown result type (might be due to invalid IL or missing references)
		//IL_241c: Expected Obj, but got Unknown
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_099f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd7: Expected Obj, but got Unknown
		//IL_2c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c1b: Expected Obj, but got Unknown
		//IL_249a: Unknown result type (might be due to invalid IL or missing references)
		//IL_24a1: Expected Obj, but got Unknown
		//IL_09b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca0: Expected Obj, but got Unknown
		//IL_09d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0814: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cea: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d24: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d29: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d68: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d71: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_28db: Expected Obj, but got Unknown
		//IL_0856: Unknown result type (might be due to invalid IL or missing references)
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3060: Unknown result type (might be due to invalid IL or missing references)
		//IL_3067: Expected Obj, but got Unknown
		//IL_2555: Unknown result type (might be due to invalid IL or missing references)
		//IL_255a: Unknown result type (might be due to invalid IL or missing references)
		//IL_255e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2563: Unknown result type (might be due to invalid IL or missing references)
		//IL_2598: Unknown result type (might be due to invalid IL or missing references)
		//IL_259d: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_2620: Unknown result type (might be due to invalid IL or missing references)
		//IL_2625: Unknown result type (might be due to invalid IL or missing references)
		//IL_2629: Unknown result type (might be due to invalid IL or missing references)
		//IL_262e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2efa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_276e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2773: Unknown result type (might be due to invalid IL or missing references)
		ApagaBlocoErroFiacao();
		if (!clsInterligacao.ExisteVeiasUsadasNoDesenho())
		{
			return;
		}
		formataDGErros(berros: false);
		btAnalisar.Enabled = false;
		btSalvar.Enabled = false;
		CDadosAccessInterligacao CDadosAccessInterligacao = new CDadosAccessInterligacao();
		clsEditarInterligacao.SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao);
		CDadosAccessInterligacao.FechaConexao();
		clsExportImport.SincronizaExportados();
		bool bExisteErro = false;
		clsExportImport.SincronizaImportados(bApagarImp: true, ref bExisteErro);
		Correcao.LimpaVeiasDeDWGsApagados();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		mknUzyUVsW = new DeclaracoesFiacao.structurePontosBlocos[1];
		ssqypmV1FI = new DeclaracoesInterligacao.structureInterlig[1];
		List<string> list = new List<string>();
		List<ObjectId> list2 = new List<ObjectId>();
		List<string> list3 = new List<string>();
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
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)current.GetObject((OpenMode)0);
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								string text2 = text;
								string left = text2;
								if (Operators.CompareString(left, "I", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "E", TextCompare: true) == 0 || Operators.CompareString(left, "B", TextCompare: true) == 0)
									{
										if (!list.Contains(val6.Name.ToString()))
										{
											list.Add(val6.Name.ToString());
										}
										list2.Add(((DBObject)val6).ObjectId);
									}
									continue;
								}
								DeclaracoesEntidades.StructureExportar exp = default;
								ent = (Entity)(object)val6;
								bExisteErro = XDataExpImp.LerXDataImportado(ref ent, ref exp);
								val6 = (BlockReference)ent;
								if (bExisteErro && ((Operators.CompareString(exp.Tipo, "E", TextCompare: true) == 0) | (Operators.CompareString(exp.Tipo, "B", TextCompare: true) == 0)))
								{
									if (!list.Contains(val6.Name.ToString()))
									{
										list.Add(val6.Name.ToString());
									}
									list2.Add(((DBObject)val6).ObjectId);
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						DataTable dataTable = new DataTable();
						dataTable.Columns.Add("NomeBloco", typeof(string));
						dataTable.Columns.Add("XMin", typeof(double));
						dataTable.Columns.Add("XMax", typeof(double));
						dataTable.Columns.Add("YMin", typeof(double));
						dataTable.Columns.Add("YMax", typeof(double));
						BlockTableRecordEnumerator enumerator3 = default;
						Point3d val11;
						BlockTableRecordEnumerator enumerator4 = default;
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
								enumerator3 = val7.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									ObjectId current3 = enumerator3.Current;
									Entity val8 = (Entity)current3.GetObject((OpenMode)0);
									Polyline val9 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
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
									Line val10 = (Line)(object)((val8 is Line) ? val8 : null);
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
									Circle val12 = (Circle)(object)((val8 is Circle) ? val8 : null);
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
									DBPoint val13 = (DBPoint)(object)((val8 is DBPoint) ? val8 : null);
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
							}
							finally
							{
								((IDisposable)enumerator3)?.Dispose();
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
								enumerator4 = val7.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									ObjectId current4 = enumerator4.Current;
									Entity val14 = (Entity)current4.GetObject((OpenMode)0);
									Polyline val15 = (Polyline)(object)((val14 is Polyline) ? val14 : null);
									if (val15 != null)
									{
										Point2d point2dAt2 = val15.GetPoint2dAt(0);
										if (pHDUmth8C3(point2dAt2.X, num, 1.0) | pHDUmth8C3(point2dAt2.X, num2, 1.0) | pHDUmth8C3(point2dAt2.Y, num3, 1.0) | pHDUmth8C3(point2dAt2.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference = ref mknUzyUVsW;
											reference = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].X = point2dAt2.X;
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].Y = point2dAt2.Y;
										}
										Point2d point2dAt3 = val15.GetPoint2dAt(val15.NumberOfVertices - 1);
										if (pHDUmth8C3(point2dAt3.X, num, 1.0) | pHDUmth8C3(point2dAt3.X, num2, 1.0) | pHDUmth8C3(point2dAt3.Y, num3, 1.0) | pHDUmth8C3(point2dAt3.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference2 = ref mknUzyUVsW;
											reference2 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference2, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].X = point2dAt3.X;
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].Y = point2dAt3.Y;
										}
									}
									Line val16 = (Line)(object)((val14 is Line) ? val14 : null);
									if (val16 != null)
									{
										val11 = val16.StartPoint;
										bool flag = pHDUmth8C3(val11.X, num, 1.0);
										val11 = val16.StartPoint;
										bool num6 = flag | pHDUmth8C3(val11.X, num2, 1.0);
										val11 = val16.StartPoint;
										bool num7 = num6 | pHDUmth8C3(val11.Y, num3, 1.0);
										val11 = val16.StartPoint;
										if (num7 | pHDUmth8C3(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference3 = ref mknUzyUVsW;
											reference3 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference3, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference4 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val16.StartPoint;
											reference4.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference5 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val16.StartPoint;
											reference5.Y = val11.Y;
										}
										val11 = val16.EndPoint;
										bool flag2 = pHDUmth8C3(val11.X, num, 1.0);
										val11 = val16.EndPoint;
										bool num8 = flag2 | pHDUmth8C3(val11.X, num2, 1.0);
										val11 = val16.EndPoint;
										bool num9 = num8 | pHDUmth8C3(val11.Y, num3, 1.0);
										val11 = val16.EndPoint;
										if (num9 | pHDUmth8C3(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference6 = ref mknUzyUVsW;
											reference6 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference6, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference7 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val16.EndPoint;
											reference7.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference8 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val16.EndPoint;
											reference8.Y = val11.Y;
										}
									}
									Circle val17 = (Circle)(object)((val14 is Circle) ? val14 : null);
									if (val17 != null)
									{
										val11 = val17.Center;
										bool flag3 = pHDUmth8C3(val11.X + val17.Radius, num, 1.0);
										val11 = val17.Center;
										bool num10 = flag3 | pHDUmth8C3(val11.X + val17.Radius, num2, 1.0);
										val11 = val17.Center;
										bool num11 = num10 | pHDUmth8C3(val11.Y, num3, 1.0);
										val11 = val17.Center;
										if (num11 | pHDUmth8C3(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference9 = ref mknUzyUVsW;
											reference9 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference9, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference10 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference10.X = val11.X + val17.Radius;
											ref DeclaracoesFiacao.structurePontosBlocos reference11 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference11.Y = val11.Y;
										}
										val11 = val17.Center;
										bool flag4 = pHDUmth8C3(val11.X - val17.Radius, num, 1.0);
										val11 = val17.Center;
										bool num12 = flag4 | pHDUmth8C3(val11.X - val17.Radius, num2, 1.0);
										val11 = val17.Center;
										bool num13 = num12 | pHDUmth8C3(val11.Y, num3, 1.0);
										val11 = val17.Center;
										if (num13 | pHDUmth8C3(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference12 = ref mknUzyUVsW;
											reference12 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference12, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference13 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference13.X = val11.X - val17.Radius;
											ref DeclaracoesFiacao.structurePontosBlocos reference14 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference14.Y = val11.Y;
										}
										val11 = val17.Center;
										bool flag5 = pHDUmth8C3(val11.X, num, 1.0);
										val11 = val17.Center;
										bool num14 = flag5 | pHDUmth8C3(val11.X, num2, 1.0);
										val11 = val17.Center;
										bool num15 = num14 | pHDUmth8C3(val11.Y - val17.Radius, num3, 1.0);
										val11 = val17.Center;
										if (num15 | pHDUmth8C3(val11.Y - val17.Radius, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference15 = ref mknUzyUVsW;
											reference15 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference15, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference16 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference16.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference17 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference17.Y = val11.Y - val17.Radius;
										}
										val11 = val17.Center;
										bool flag6 = pHDUmth8C3(val11.X, num, 1.0);
										val11 = val17.Center;
										bool num16 = flag6 | pHDUmth8C3(val11.X, num2, 1.0);
										val11 = val17.Center;
										bool num17 = num16 | pHDUmth8C3(val11.Y + val17.Radius, num3, 1.0);
										val11 = val17.Center;
										if (num17 | pHDUmth8C3(val11.Y + val17.Radius, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference18 = ref mknUzyUVsW;
											reference18 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference18, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference19 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference19.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference20 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val17.Center;
											reference20.Y = val11.Y + val17.Radius;
										}
									}
									DBPoint val18 = (DBPoint)(object)((val14 is DBPoint) ? val14 : null);
									if (val18 != null)
									{
										val11 = val18.Position;
										bool flag7 = pHDUmth8C3(val11.X, num, 1.0);
										val11 = val18.Position;
										bool num18 = flag7 | pHDUmth8C3(val11.X, num2, 1.0);
										val11 = val18.Position;
										bool num19 = num18 | pHDUmth8C3(val11.Y, num3, 1.0);
										val11 = val18.Position;
										if (num19 | pHDUmth8C3(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference21 = ref mknUzyUVsW;
											reference21 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference21, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(mknUzyUVsW) + 1 + 1]);
											mknUzyUVsW[Information.UBound(mknUzyUVsW)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference22 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val18.Position;
											reference22.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference23 = ref mknUzyUVsW[Information.UBound(mknUzyUVsW)];
											val11 = val18.Position;
											reference23.Y = val11.Y;
										}
									}
								}
							}
							finally
							{
								((IDisposable)enumerator4)?.Dispose();
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
							string text3 = "";
							text3 = "NomeBloco='" + val19.Name + "'";
							DataRow[] array = dataTable.Select(text3);
							int upperBound = array.GetUpperBound(0);
							for (int j = 0; j <= upperBound; j++)
							{
								DataRow dataRow2 = dataTable2.NewRow();
								dataRow2["ObjectID"] = ((DBObject)val19).ObjectId;
								dataRow2["Layer"] = montaCruzamentoPagina(((Entity)val19).Layer.ToString());
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
						BlockTableRecordEnumerator enumerator6 = default;
						try
						{
							enumerator6 = val4.GetEnumerator();
							while (enumerator6.MoveNext())
							{
								ObjectId current6 = enumerator6.Current;
								Entity val20 = (Entity)val2.GetObject(current6, (OpenMode)0);
								Polyline pl = (Polyline)(object)((val20 is Polyline) ? val20 : null);
								if (pl == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) || ilig.NumVeia == -1000)
								{
									continue;
								}
								if (ilig.Tipo != 1)
								{
									if (ilig.Tipo != 2)
									{
										if (ilig.Tipo == 3)
										{
											ref DeclaracoesInterligacao.structureInterlig[] reference24 = ref ssqypmV1FI;
											reference24 = (DeclaracoesInterligacao.structureInterlig[])Utils.CopyArray(reference24, new DeclaracoesInterligacao.structureInterlig[Information.UBound(ssqypmV1FI) + 1 + 1]);
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].Tag_Cabo = ilig.Tag_Cabo;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].Num_Veia = ilig.NumVeia;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].Nome_Veia = ilig.NomeVeia;
											pl.GetPoint2dAt(0);
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].X1 = -1.0;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].Y1 = -1.0;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].painel1 = 0;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer1 = "";
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer1Erro = "";
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].posicao1 = "";
											Point2d point2dAt4 = pl.GetPoint2dAt(pl.NumberOfVertices - 1);
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].X2 = point2dAt4.X;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].Y2 = point2dAt4.Y;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].painel2 = ilig.Painel2;
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer2 = montaCruzamentoPagina(((Entity)pl).Layer.ToString());
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer2Erro = ((Entity)pl).Layer.ToString();
											ssqypmV1FI[Information.UBound(ssqypmV1FI)].posicao2 = "";
										}
										continue;
									}
									int num20 = yHoU3hlYPo(ilig);
									if (num20 == 0)
									{
										ref DeclaracoesInterligacao.structureInterlig[] reference25 = ref ssqypmV1FI;
										reference25 = (DeclaracoesInterligacao.structureInterlig[])Utils.CopyArray(reference25, new DeclaracoesInterligacao.structureInterlig[Information.UBound(ssqypmV1FI) + 1 + 1]);
										num20 = Information.UBound(ssqypmV1FI);
										ssqypmV1FI[num20].painel1 = -1;
										ssqypmV1FI[num20].painel2 = -1;
									}
									ssqypmV1FI[num20].Tag_Cabo = ilig.Tag_Cabo;
									ssqypmV1FI[num20].Num_Veia = ilig.NumVeia;
									ssqypmV1FI[num20].Nome_Veia = ilig.NomeVeia;
									if (ilig.Painel1 <= 0)
									{
										Point2d point2dAt5 = pl.GetPoint2dAt(pl.NumberOfVertices - 1);
										ssqypmV1FI[num20].X2 = point2dAt5.X;
										ssqypmV1FI[num20].Y2 = point2dAt5.Y;
										ssqypmV1FI[num20].painel2 = ilig.Painel2;
										ssqypmV1FI[num20].layer2 = montaCruzamentoPagina(((Entity)pl).Layer.ToString());
										ssqypmV1FI[num20].layer2Erro = ((Entity)pl).Layer.ToString();
										ssqypmV1FI[num20].posicao2 = "";
									}
									else
									{
										Point2d point2dAt6 = pl.GetPoint2dAt(0);
										ssqypmV1FI[num20].X1 = point2dAt6.X;
										ssqypmV1FI[num20].Y1 = point2dAt6.Y;
										ssqypmV1FI[num20].painel1 = ilig.Painel1;
										ssqypmV1FI[num20].layer1 = montaCruzamentoPagina(((Entity)pl).Layer.ToString());
										ssqypmV1FI[num20].layer1Erro = ((Entity)pl).Layer.ToString();
										ssqypmV1FI[num20].posicao1 = "";
									}
								}
								else
								{
									ref DeclaracoesInterligacao.structureInterlig[] reference26 = ref ssqypmV1FI;
									reference26 = (DeclaracoesInterligacao.structureInterlig[])Utils.CopyArray(reference26, new DeclaracoesInterligacao.structureInterlig[Information.UBound(ssqypmV1FI) + 1 + 1]);
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].Tag_Cabo = ilig.Tag_Cabo;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].Num_Veia = ilig.NumVeia;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].Nome_Veia = ilig.NomeVeia;
									Point2d point2dAt7 = pl.GetPoint2dAt(0);
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].X1 = point2dAt7.X;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].Y1 = point2dAt7.Y;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].painel1 = ilig.Painel1;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer1 = montaCruzamentoPagina(((Entity)pl).Layer.ToString());
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer1Erro = ((Entity)pl).Layer.ToString();
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].posicao1 = "";
									Point2d point2dAt8 = pl.GetPoint2dAt(pl.NumberOfVertices - 1);
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].X2 = point2dAt8.X;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].Y2 = point2dAt8.Y;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].painel2 = ilig.Painel2;
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer2 = montaCruzamentoPagina(((Entity)pl).Layer.ToString());
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].layer2Erro = ((Entity)pl).Layer.ToString();
									ssqypmV1FI[Information.UBound(ssqypmV1FI)].posicao2 = "";
								}
							}
						}
						finally
						{
							((IDisposable)enumerator6)?.Dispose();
						}
						DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(ssqypmV1FI);
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num21 = Information.UBound(ssqypmV1FI);
						int dwg = default;
						int dwg2 = default;
						for (int k = 1; k <= num21; k++)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							string text4 = "";
							ssqypmV1FI[k].handle1 = "";
							ssqypmV1FI[k].Documento1 = "";
							ssqypmV1FI[k].tag1 = "";
							ssqypmV1FI[k].alternativo1 = "";
							ssqypmV1FI[k].terminal1 = "";
							ssqypmV1FI[k].tipo1 = "";
							ssqypmV1FI[k].nRegua1 = "";
							ssqypmV1FI[k].handle2 = "";
							ssqypmV1FI[k].Documento2 = "";
							ssqypmV1FI[k].tag2 = "";
							ssqypmV1FI[k].alternativo2 = "";
							ssqypmV1FI[k].terminal2 = "";
							ssqypmV1FI[k].tipo2 = "";
							ssqypmV1FI[k].nRegua2 = "";
							string sRegua;
							string text6;
							string sAlternativo;
							short tipoBorne;
							string documento;
							BlockReference val22;
							string text7;
							string text8;
							short indexModelo;
							Extents3d value;
							string terminal;
							double terminalNum;
							string nRegua;
							if (ssqypmV1FI[k].painel1 > 0)
							{
								ssqypmV1FI[k].layer1.ToString();
								text4 = ssqypmV1FI[k].layer1Erro.ToString();
								if (ssqypmV1FI[k].painel2 != -1)
								{
									string text5 = "";
									text5 = "Layer='" + ssqypmV1FI[k].layer1.ToString() + "' AND " + ssqypmV1FI[k].X1.ToString("F", CultureInfo.InvariantCulture) + ">= XMin AND " + ssqypmV1FI[k].X1.ToString("F", CultureInfo.InvariantCulture) + "<= XMax AND " + ssqypmV1FI[k].Y1.ToString("F", CultureInfo.InvariantCulture) + ">= YMin AND " + ssqypmV1FI[k].Y1.ToString("F", CultureInfo.InvariantCulture) + "<= YMax";
									DataRow[] array2 = dataTable2.Select(text5);
									int upperBound2 = array2.GetUpperBound(0);
									for (int l = 0; l <= upperBound2; l++)
									{
										object obj = array2[l][0];
										ObjectId val21 = ((obj == null) ? default(ObjectId) : ((ObjectId)obj));
										val22 = (BlockReference)val21.GetObject((OpenMode)0);
										sRegua = "";
										text6 = "";
										sAlternativo = "";
										short num22 = 0;
										tipoBorne = 0;
										indexModelo = 0;
										documento = "";
										Entity ent = (Entity)(object)val22;
										string text = "";
										string tipoImportado = XDataDispositivo.verificaTipoDispositivo(ref ent, ref text);
										val22 = (BlockReference)ent;
										text7 = tipoImportado;
										text8 = "";
										string left2 = text7;
										if (Operators.CompareString(left2, "I", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left2, "E", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left2, "B", TextCompare: true) != 0)
												{
													continue;
												}
												object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val22);
												DeclaracoesEntidades.StructureBorne structureBorne = ((obj2 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj2));
												indexModelo = (short)structureBorne.IndiceRegua;
												int iRegua = indexModelo;
												int num23 = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref iRegua, ref sRegua, ref sAlternativo);
												indexModelo = (short)iRegua;
												num22 = (short)num23;
												text6 = "";
												tipoBorne = (short)structureBorne.tipo;
												dwg = DeclaracoesGeral.arqAtivo.Indice;
												documento = DeclaracoesGeral.Conf.Local;
											}
											else
											{
												object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val22);
												DeclaracoesEntidades.StructurePortas structurePortas = ((obj3 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj3));
												sRegua = structurePortas.Nome1;
												text6 = structurePortas.Nome2;
												sAlternativo = structurePortas.Alternativo;
												ent = (Entity)(object)val22;
												short num24 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
												val22 = (BlockReference)ent;
												num22 = num24;
												tipoBorne = -1;
												indexModelo = (short)structurePortas.indiceDoModelo;
												dwg = DeclaracoesGeral.arqAtivo.Indice;
												documento = DeclaracoesGeral.Conf.Local;
											}
										}
										else
										{
											DeclaracoesEntidades.StructureExportar exp2 = default;
											ent = (Entity)(object)val22;
											bExisteErro = XDataExpImp.LerXDataImportado(ref ent, ref exp2);
											val22 = (BlockReference)ent;
											if (bExisteErro && ((Operators.CompareString(exp2.Tipo, "E", TextCompare: true) == 0) | (Operators.CompareString(exp2.Tipo, "B", TextCompare: true) == 0)))
											{
												num22 = (short)exp2.Painel;
												indexModelo = (short)exp2.indexModelo;
												dwg = exp2.DWG;
												documento = DeclaracoesGeral.Conf.Local;
												if (Operators.CompareString(exp2.Tipo, "E", TextCompare: true) != 0)
												{
													if (Operators.CompareString(exp2.Tipo, "B", TextCompare: true) == 0)
													{
														sRegua = exp2.NomeRegua;
														tipoBorne = -3;
													}
												}
												else
												{
													VVHUyfXhQs(ref val22, ref sRegua, ref text6, sAlternativo);
													tipoBorne = -2;
												}
												text8 = exp2.Tipo;
												ssqypmV1FI[k].handle1 = exp2.Handle;
											}
										}
										if (!(((ssqypmV1FI[k].painel1 == num22) | (ssqypmV1FI[k].painel2 == num22)) & (num22 > 0)))
										{
											continue;
										}
										int painel = ssqypmV1FI[k].painel1;
										int painel2 = ssqypmV1FI[k].painel2;
										if (painel != num22 && painel2 == num22)
										{
											ssqypmV1FI[k].painel1 = (short)painel2;
											ssqypmV1FI[k].painel2 = (short)painel;
										}
										if (!((ssqypmV1FI[k].painel1 == num22) & (num22 > 0)))
										{
											continue;
										}
										double x = ssqypmV1FI[k].X1;
										value = ((Drawable)val22).Bounds.Value;
										val11 = value.MinPoint;
										bool flag8 = x >= val11.X - 0.25;
										double x2 = ssqypmV1FI[k].X1;
										value = ((Drawable)val22).Bounds.Value;
										val11 = value.MaxPoint;
										bool num25 = flag8 & (x2 <= val11.X + 0.25);
										double y = ssqypmV1FI[k].Y1;
										value = ((Drawable)val22).Bounds.Value;
										val11 = value.MinPoint;
										bool num26 = num25 & (y >= val11.Y - 0.25);
										double y2 = ssqypmV1FI[k].Y1;
										value = ((Drawable)val22).Bounds.Value;
										val11 = value.MaxPoint;
										if (!(num26 & (y2 <= val11.Y + 0.25)))
										{
											continue;
										}
										terminal = "";
										terminalNum = 0.0;
										nRegua = "";
										if (!pf6UXj3X1f(k, ssqypmV1FI[k].X1, ssqypmV1FI[k].Y1, ref val22, text7, 0.5, ref terminal, ref terminalNum, ref nRegua))
										{
											continue;
										}
										goto IL_26a9;
									}
								}
								InsereBlocoErroInterligacao(text4, ssqypmV1FI[k].X1, ssqypmV1FI[k].Y1);
								if (!list3.Contains(text4))
								{
									list3.Add(text4);
								}
								DeclaracoesGeral.bAnularEventos = true;
							}
							goto IL_2238;
							IL_26a9:
							ssqypmV1FI[k].tag1 = sRegua;
							if (Operators.CompareString(text6, "", TextCompare: true) != 0)
							{
								ref string tag = ref ssqypmV1FI[k].tag1;
								tag = tag + "/" + text6;
							}
							ssqypmV1FI[k].nRegua1 = nRegua;
							ssqypmV1FI[k].alternativo1 = sAlternativo;
							ssqypmV1FI[k].terminal1 = terminal;
							ssqypmV1FI[k].terminalNum1 = terminalNum;
							ssqypmV1FI[k].tipo1 = text7;
							if (Operators.CompareString(text7, "I", TextCompare: true) == 0)
							{
								ssqypmV1FI[k].tipo1 = "I" + text8;
							}
							ssqypmV1FI[k].tipoBorne1 = tipoBorne;
							ssqypmV1FI[k].handle1 = ((object)((DBObject)val22).Handle/*cast due to constrained. prefix*/).ToString();
							ssqypmV1FI[k].indexModelo1 = indexModelo;
							ssqypmV1FI[k].dwg1 = dwg;
							ssqypmV1FI[k].Documento1 = documento;
							goto IL_2238;
							IL_2e35:
							string sRegua2;
							ssqypmV1FI[k].tag2 = sRegua2;
							string text9;
							if (Operators.CompareString(text9, "", TextCompare: true) != 0)
							{
								ref string tag2 = ref ssqypmV1FI[k].tag2;
								tag2 = tag2 + "/" + text9;
							}
							string nRegua2;
							ssqypmV1FI[k].nRegua2 = nRegua2;
							string sAlternativo2;
							ssqypmV1FI[k].alternativo2 = sAlternativo2;
							string terminal2;
							ssqypmV1FI[k].terminal2 = terminal2;
							double terminalNum2;
							ssqypmV1FI[k].terminalNum2 = terminalNum2;
							string text10;
							ssqypmV1FI[k].tipo2 = text10;
							string text11;
							if (Operators.CompareString(text10, "I", TextCompare: true) == 0)
							{
								ssqypmV1FI[k].tipo2 = "I" + text11;
							}
							short tipoBorne2;
							ssqypmV1FI[k].tipoBorne2 = tipoBorne2;
							BlockReference blockRef;
							ssqypmV1FI[k].handle2 = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
							short indexModelo2;
							ssqypmV1FI[k].indexModelo2 = indexModelo2;
							ssqypmV1FI[k].dwg2 = dwg2;
							string documento2;
							ssqypmV1FI[k].Documento2 = documento2;
							continue;
							IL_2238:
							if (ssqypmV1FI[k].painel2 <= 0)
							{
								continue;
							}
							ssqypmV1FI[k].layer2.ToString();
							text4 = ssqypmV1FI[k].layer2Erro.ToString();
							if (ssqypmV1FI[k].painel1 != -1)
							{
								string text12 = "";
								text12 = "Layer='" + ssqypmV1FI[k].layer2.ToString() + "' AND " + ssqypmV1FI[k].X2.ToString("F", CultureInfo.InvariantCulture) + ">= XMin AND " + ssqypmV1FI[k].X2.ToString("F", CultureInfo.InvariantCulture) + "<= XMax AND " + ssqypmV1FI[k].Y2.ToString("F", CultureInfo.InvariantCulture) + ">= YMin AND " + ssqypmV1FI[k].Y2.ToString("F", CultureInfo.InvariantCulture) + "<= YMax";
								DataRow[] array3 = dataTable2.Select(text12);
								int upperBound3 = array3.GetUpperBound(0);
								for (int m = 0; m <= upperBound3; m++)
								{
									object obj4 = array3[m][0];
									ObjectId val23 = ((obj4 == null) ? default(ObjectId) : ((ObjectId)obj4));
									blockRef = (BlockReference)val23.GetObject((OpenMode)0);
									sRegua2 = "";
									text9 = "";
									sAlternativo2 = "";
									short num27 = 0;
									tipoBorne2 = 0;
									indexModelo2 = 0;
									documento2 = "";
									Entity ent = (Entity)(object)blockRef;
									string tipoImportado = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									blockRef = (BlockReference)ent;
									text10 = text;
									text11 = "";
									string left3 = text10;
									if (Operators.CompareString(left3, "I", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left3, "E", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left3, "B", TextCompare: true) != 0)
											{
												continue;
											}
											object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructureBorne structureBorne2 = ((obj5 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj5));
											indexModelo2 = (short)structureBorne2.IndiceRegua;
											int num23 = indexModelo2;
											int iRegua = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref num23, ref sRegua2, ref sAlternativo2);
											indexModelo2 = (short)num23;
											num27 = (short)iRegua;
											text9 = "";
											tipoBorne2 = (short)structureBorne2.tipo;
											dwg2 = DeclaracoesGeral.arqAtivo.Indice;
											documento2 = DeclaracoesGeral.Conf.Local;
										}
										else
										{
											object obj6 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructurePortas structurePortas2 = ((obj6 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj6));
											sRegua2 = structurePortas2.Nome1;
											text9 = structurePortas2.Nome2;
											sAlternativo2 = structurePortas2.Alternativo;
											ent = (Entity)(object)blockRef;
											short num24 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
											blockRef = (BlockReference)ent;
											num27 = num24;
											tipoBorne2 = -1;
											indexModelo2 = (short)structurePortas2.indiceDoModelo;
											dwg2 = DeclaracoesGeral.arqAtivo.Indice;
											documento2 = DeclaracoesGeral.Conf.Local;
										}
									}
									else
									{
										DeclaracoesEntidades.StructureExportar exp3 = default;
										ent = (Entity)(object)blockRef;
										bExisteErro = XDataExpImp.LerXDataImportado(ref ent, ref exp3);
										blockRef = (BlockReference)ent;
										if (bExisteErro && ((Operators.CompareString(exp3.Tipo, "E", TextCompare: true) == 0) | (Operators.CompareString(exp3.Tipo, "B", TextCompare: true) == 0)))
										{
											num27 = (short)exp3.Painel;
											indexModelo2 = (short)exp3.indexModelo;
											dwg2 = exp3.DWG;
											documento2 = DeclaracoesGeral.Conf.Local;
											if (Operators.CompareString(exp3.Tipo, "E", TextCompare: true) != 0)
											{
												if (Operators.CompareString(exp3.Tipo, "B", TextCompare: true) == 0)
												{
													sRegua2 = exp3.NomeRegua;
													tipoBorne2 = -3;
												}
											}
											else
											{
												VVHUyfXhQs(ref blockRef, ref sRegua2, ref text9, sAlternativo2);
												tipoBorne2 = -2;
											}
											text11 = exp3.Tipo;
											ssqypmV1FI[k].handle2 = exp3.Handle;
										}
									}
									if (!((ssqypmV1FI[k].painel2 == num27) & (num27 > 0)))
									{
										continue;
									}
									double x3 = ssqypmV1FI[k].X2;
									value = ((Drawable)blockRef).Bounds.Value;
									val11 = value.MinPoint;
									bool flag9 = x3 >= val11.X - 0.25;
									double x4 = ssqypmV1FI[k].X2;
									value = ((Drawable)blockRef).Bounds.Value;
									val11 = value.MaxPoint;
									bool num28 = flag9 & (x4 <= val11.X + 0.25);
									double y3 = ssqypmV1FI[k].Y2;
									value = ((Drawable)blockRef).Bounds.Value;
									val11 = value.MinPoint;
									bool num29 = num28 & (y3 >= val11.Y - 0.25);
									double y4 = ssqypmV1FI[k].Y2;
									value = ((Drawable)blockRef).Bounds.Value;
									val11 = value.MaxPoint;
									if (!(num29 & (y4 <= val11.Y + 0.25)))
									{
										continue;
									}
									terminal2 = "";
									terminalNum2 = 0.0;
									nRegua2 = "";
									if (!pf6UXj3X1f(k, ssqypmV1FI[k].X2, ssqypmV1FI[k].Y2, ref blockRef, text10, 0.5, ref terminal2, ref terminalNum2, ref nRegua2))
									{
										continue;
									}
									goto IL_2e35;
								}
							}
							InsereBlocoErroInterligacao(text4, ssqypmV1FI[k].X2, ssqypmV1FI[k].Y2);
							if (!list3.Contains(text4))
							{
								list3.Add(text4);
							}
							DeclaracoesGeral.bAnularEventos = true;
						}
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

	private int yHoU3hlYPo(DeclaracoesEntidades.StructureInterligacao P_0)
	{
		int result = 0;
		int num = Information.UBound(ssqypmV1FI);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if ((Operators.CompareString(ssqypmV1FI[i].Tag_Cabo, P_0.Tag_Cabo, TextCompare: true) == 0) & (ssqypmV1FI[i].Num_Veia == P_0.NumVeia))
			{
				result = i;
				break;
			}
		}
		return result;
	}

	private void bYQUnDSi6X(object P_0, EventArgs P_1)
	{
		btSalvar.Enabled = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
		cDadosAtualizaBanco2.LimpaDWGApagadosDoProjeto();
		cDadosAtualizaBanco2.fechaConexao();
		bool flag = false;
		string text = tbRevisao.Text.ToString().Trim();
		checked
		{
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
					try
					{
						DeclaracoesGeral.bAnularEventos = true;
						DeclaracoesGeral._uscPagina.Quantidade = ssqypmV1FI.Length * 2 - 2;
						DeclaracoesGeral._uscPagina.pbIniciar();
						DateTime now = DateTime.Now;
						cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
						int num = Information.UBound(ssqypmV1FI);
						for (int i = 1; i <= num; i++)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							ssqypmV1FI[i].DWG = DeclaracoesGeral.arqAtivo.Indice;
							ssqypmV1FI[i].revisao = text;
							ssqypmV1FI[i].criador = Environment.UserName;
							ssqypmV1FI[i].data = now;
							cDadosAccessInterligacao3.AdicionaItemInterligacao(ssqypmV1FI[i]);
						}
						cDadosAccessInterligacao3.RemoveRevisaoTabelaParaDWG("Portas4I", DeclaracoesGeral.arqAtivo.Indice, text);
						wrlU180vl0(ref cDadosAccessInterligacao3, ref text);
						cDadosAccessInterligacao3.RemoveRevisaoTabelaParaDWG("Bornes4I", DeclaracoesGeral.arqAtivo.Indice, text);
						T6NUlT3ghH(ref cDadosAccessInterligacao3, ref text);
						cDadosAccessInterligacao3.RemoveRevisaoTabelaParaTodosDWG("Cabos4", text);
						RUIU5Sbjhj(ref cDadosAccessInterligacao3, ref text);
						cDadosAccessInterligacao3.RemoveRevisaoTabelaParaTodosDWG("Veias4", text);
						v1TU0cEjWd(ref cDadosAccessInterligacao3, ref text);
						cDadosAccessInterligacao3.fechaConexao();
						now = DateTime.Now;
						text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1460]);
						cDadosAccessInterligacao2 cDadosAccessInterligacao4 = new cDadosAccessInterligacao2();
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaDWG("Interligacao4", DeclaracoesGeral.arqAtivo.Indice, text);
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaDWG("Portas4I", DeclaracoesGeral.arqAtivo.Indice, text);
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaDWG("Bornes4I", DeclaracoesGeral.arqAtivo.Indice, text);
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaTodosDWG("Cabos4", text);
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaTodosDWG("Veias4", text);
						int num2 = Information.UBound(ssqypmV1FI);
						for (int j = 1; j <= num2; j++)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							ssqypmV1FI[j].DWG = DeclaracoesGeral.arqAtivo.Indice;
							ssqypmV1FI[j].revisao = text;
							ssqypmV1FI[j].criador = Environment.UserName;
							ssqypmV1FI[j].data = now;
							cDadosAccessInterligacao4.AdicionaItemInterligacao(ssqypmV1FI[j]);
						}
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaDWG("Portas4I", DeclaracoesGeral.arqAtivo.Indice, text);
						wrlU180vl0(ref cDadosAccessInterligacao4, ref text);
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaDWG("Bornes4I", DeclaracoesGeral.arqAtivo.Indice, text);
						T6NUlT3ghH(ref cDadosAccessInterligacao4, ref text);
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaTodosDWG("Cabos4", text);
						RUIU5Sbjhj(ref cDadosAccessInterligacao4, ref text);
						cDadosAccessInterligacao4.RemoveRevisaoTabelaParaTodosDWG("Veias4", text);
						v1TU0cEjWd(ref cDadosAccessInterligacao4, ref text);
						DeclaracoesGeral._uscPagina.pbFim();
						cDadosAccessInterligacao4.fechaConexao();
						formataDGRevisao();
						CarregaDGRevisao();
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
	}

	private void wrlU180vl0(ref cDadosAccessInterligacao2 P_0, ref string P_1)
	{
		Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
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
					string text4 = "";
					if (!((Operators.CompareString(text3, "", TextCompare: true) != 0) & (Operators.CompareString(text2, "", TextCompare: true) != 0) & (Operators.CompareString(text2, ";", TextCompare: true) != 0)))
					{
						if (!((Operators.CompareString(text, "", TextCompare: true) != 0) & (Operators.CompareString(text, ";", TextCompare: true) != 0)))
						{
							continue;
						}
						List<string> lTerminais = new List<string>();
						Geral.DivideTerminais(ref lTerminais, text);
						foreach (string item in lTerminais)
						{
							double terminalNum = clsConexao.CalculaTerminalNumerico(item);
							P_0.AdicionaItemPortas(P_1, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, "", "", item, terminalNum, "T");
						}
						continue;
					}
					List<string> lTerminais2 = new List<string>();
					Geral.DivideTerminais(ref lTerminais2, text2, bRepete: true);
					List<string> lTerminais3 = new List<string>();
					Geral.DivideTerminais(ref lTerminais3, text3);
					int num4 = 0;
					foreach (string item2 in lTerminais2)
					{
						string text5 = item2;
						if (text5.StartsWith("*"))
						{
							text5 = text5.Remove(0, 1);
						}
						text4 = ((lTerminais3.Count > num4) ? lTerminais3[num4] : text3);
						double terminalNum2 = clsConexao.CalculaTerminalNumerico(text5);
						P_0.AdicionaItemPortas(P_1, DeclaracoesGeral.arqAtivo.Indice, num2, sNomeModelo, text4, text5, "", terminalNum2, "B");
						num4++;
					}
				}
			}
		}
	}

	private void T6NUlT3ghH(ref cDadosAccessInterligacao2 P_0, ref string P_1)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		if (!DicionarioReguas.LeOsModelosDeRegua(ref mModelo))
		{
			return;
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)current.GetObject((OpenMode)0);
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							string text2 = text;
							string left = text2;
							if (Operators.CompareString(left, "B", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureBorne born = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							born.indexPainel = 0;
							int num = Information.UBound(mModelo);
							for (int i = 1; i <= num; i++)
							{
								if (mModelo[i].indexRegua == born.IndiceRegua)
								{
									born.indexPainel = mModelo[i].indexPainel;
									born.NomeRegua = mModelo[i].nomeRegua;
									break;
								}
							}
							if (born.indexPainel == 0)
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
										string text3 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
										if (Operators.CompareString(text3, "", TextCompare: true) != 0)
										{
											ref string pagina = ref born.pagina;
											pagina = pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + text3;
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
							P_0.AdicionaItemBornes(P_1, DeclaracoesGeral.arqAtivo.Indice, born);
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
			int num2 = Information.UBound(mModelo);
			for (int j = 1; j <= num2; j++)
			{
				DeclaracoesEntidades.StructureBorne[] mBornes = new DeclaracoesEntidades.StructureBorne[1];
				int qSimples = 0;
				int qDuplo = 0;
				if (DicionarioBorne.LeDicBornesReserva(mModelo[j].indexRegua, ref mBornes, ref qSimples, ref qDuplo))
				{
					int num3 = Information.UBound(mBornes);
					for (int k = 1; k <= num3; k++)
					{
						mBornes[k].IndiceRegua = mModelo[j].indexRegua;
						mBornes[k].NomeRegua = mModelo[j].nomeRegua;
						mBornes[k].Handle = "";
						mBornes[k].indexPainel = mModelo[j].indexPainel;
						P_0.AdicionaItemBornes(P_1, DeclaracoesGeral.arqAtivo.Indice, mBornes[k]);
					}
				}
			}
		}
	}

	private void RUIU5Sbjhj(ref cDadosAccessInterligacao2 P_0, ref string P_1)
	{
		DeclaracoesInterligacao.structureCabo[] mCabos = new DeclaracoesInterligacao.structureCabo[1];
		P_0.CarregaCabos(ref mCabos);
		DateTime now = DateTime.Now;
		int num = Information.UBound(mCabos);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			mCabos[i].criador = Environment.UserName;
			mCabos[i].data = now;
			P_0.AdicionaItemCabos4(P_1, mCabos[i]);
		}
	}

	private void v1TU0cEjWd(ref cDadosAccessInterligacao2 P_0, ref string P_1)
	{
		DeclaracoesInterligacao.structureVeia[] mVeias = new DeclaracoesInterligacao.structureVeia[1];
		P_0.CarregaVeias(ref mVeias);
		int num = Information.UBound(mVeias);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			P_0.AdicionaItemVeias4(P_1, mVeias[i]);
		}
	}

	private void uZbURRkc6n(object P_0, EventArgs P_1)
	{
		if (dgRevisao.SelectedRows.Count != 0)
		{
			string revisao = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 760]), MsgBoxStyle.YesNo);
			if (msgBoxResult != MsgBoxResult.No)
			{
				cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
				cDadosAccessInterligacao3.RemoveRevisaoTabelaParaDWG("Interligacao4", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessInterligacao3.RemoveRevisaoTabelaParaDWG("Portas4I", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessInterligacao3.RemoveRevisaoTabelaParaDWG("Bornes4I", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessInterligacao3.RemoveRevisaoTabelaParaTodosDWG("Cabos4", revisao);
				cDadosAccessInterligacao3.RemoveRevisaoTabelaParaTodosDWG("Veias4", revisao);
				cDadosAccessInterligacao3.fechaConexao();
				formataDGRevisao();
				CarregaDGRevisao();
			}
		}
	}

	private bool pHDUmth8C3(double P_0, double P_1, double P_2)
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

	private bool pf6UXj3X1f(int P_0, double P_1, double P_2, ref BlockReference P_3, string P_4, double P_5, ref string P_6, ref double P_7, ref string P_8)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			bool flag = false;
			int num3 = Information.UBound(mknUzyUVsW);
			for (int i = 1; i <= num3; i = checked(i + 1))
			{
				if (Operators.CompareString(mknUzyUVsW[i].nome, P_3.Name, TextCompare: true) != 0)
				{
					if (flag)
					{
						break;
					}
					continue;
				}
				flag = true;
				Point3d position = P_3.Position;
				num = position.X + mknUzyUVsW[i].X;
				position = P_3.Position;
				num2 = position.Y + mknUzyUVsW[i].Y;
				double num4 = Math.Sqrt(Math.Pow(num - P_1, 2.0) + Math.Pow(num2 - P_2, 2.0));
				if (!(num4 <= P_5))
				{
					continue;
				}
				if (Operators.CompareString(P_4, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(P_4, "I", TextCompare: true) != 0)
					{
						if (Operators.CompareString(P_4, "E", TextCompare: true) == 0)
						{
							int num5 = 0;
							RdLUgOhOKm(ref P_3, P_1, P_2, ref P_6, ref num5);
							fPoUAHRoiX(ref P_3, P_1, P_2, ref P_8, num5);
							P_7 = clsConexao.CalculaTerminalNumerico(P_6);
						}
					}
					else
					{
						DeclaracoesEntidades.StructureExportar exp = default;
						Entity ent = (Entity)(object)P_3;
						bool flag2 = XDataExpImp.LerXDataImportado(ref ent, ref exp);
						P_3 = (BlockReference)ent;
						if (flag2)
						{
							if (Operators.CompareString(exp.Tipo, "E", TextCompare: true) != 0)
							{
								if (Operators.CompareString(exp.Tipo, "B", TextCompare: true) == 0)
								{
									P_6 = gWYUUqMRJa(ref P_3);
									P_8 = exp.NomeRegua;
									P_7 = -1.0;
								}
							}
							else
							{
								int num6 = 0;
								RdLUgOhOKm(ref P_3, P_1, P_2, ref P_6, ref num6);
								fPoUAHRoiX(ref P_3, P_1, P_2, ref P_8, num6);
								P_7 = clsConexao.CalculaTerminalNumerico(P_6);
							}
						}
					}
					if ((Operators.CompareString(P_6.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(P_6.Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0) & (Operators.CompareString(P_8.Trim(), "", TextCompare: true) != 0))
					{
						result = true;
					}
				}
				else
				{
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref P_3);
					DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
					P_6 = structureBorne.Numero;
					if (Operators.CompareString(structureBorne.NumeroComplem, "", TextCompare: true) != 0)
					{
						P_6 += structureBorne.NumeroComplem;
					}
					P_7 = structureBorne.Ordem;
					if ((Operators.CompareString(P_6.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(P_6.Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0))
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

	private string gWYUUqMRJa(ref BlockReference P_0)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			AttributeCollection attributeCollection = P_0.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val2 = (AttributeReference)topTransaction.GetObject(val, (OpenMode)0);
				if (Operators.CompareString(val2.Tag.ToString().ToUpper(), "T1", TextCompare: true) == 0)
				{
					result = ((DBText)val2).TextString;
					break;
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
		return result;
	}

	private void VVHUyfXhQs(ref BlockReference P_0, ref string P_1, ref string P_2, string P_3)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			AttributeCollection attributeCollection = P_0.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val2 = (AttributeReference)topTransaction.GetObject(val, (OpenMode)0);
				if (Operators.CompareString(val2.Tag.ToString().ToUpper(), "NOME1", TextCompare: true) != 0)
				{
					if (Operators.CompareString(val2.Tag.ToString().ToUpper(), "NOME2", TextCompare: true) != 0)
					{
						if (Operators.CompareString(val2.Tag.ToString().ToUpper(), "ALTERNATIVO", TextCompare: true) == 0)
						{
							P_3 = ((DBText)val2).TextString;
						}
					}
					else
					{
						P_2 = ((DBText)val2).TextString;
					}
				}
				else
				{
					P_1 = ((DBText)val2).TextString;
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

	private void RdLUgOhOKm(ref BlockReference P_0, double P_1, double P_2, ref string P_3, ref int P_4)
	{
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Invalid comparison between Unknown and I4
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 100.0;
		P_4 = 0;
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
				if ((Operators.CompareString(left, "B", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val2.Tag.ToString().ToUpper(), 2)))
				{
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
					if (num < num2)
					{
						P_4 = num5;
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

	private void fPoUAHRoiX(ref BlockReference P_0, double P_1, double P_2, ref string P_3, int P_4)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			AttributeCollection attributeCollection = P_0.AttributeCollection;
			IEnumerator enumerator = attributeCollection.GetEnumerator();
			try
			{
				AttributeReference val2;
				while (true)
				{
					if (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						ObjectId val = ((current == null) ? default(ObjectId) : ((ObjectId)current));
						val2 = (AttributeReference)topTransaction.GetObject(val, (OpenMode)0);
						string left = Strings.Mid(val2.Tag.ToString().ToUpper(), 1, 1);
						string text = Strings.Mid(val2.Tag.ToString().ToUpper(), 2);
						if (Versioned.IsNumeric(text) && ((Operators.CompareString(left, "R", TextCompare: true) == 0) & (P_4 == Conversions.ToInteger(text))))
						{
							break;
						}
						if ((Operators.CompareString(left, "R", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val2.Tag.ToString().ToUpper(), 2)))
						{
							P_3 = ((DBText)val2).TextString;
						}
						continue;
					}
					return;
				}
				P_3 = ((DBText)val2).TextString;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
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

	public void InsereBlocoErroInterligacao(string layer, double x, double y)
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
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected Obj, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
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
			y = Math.Round(y, 4);
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

	private void CZIUsNUGye(object P_0, EventArgs P_1)
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

	public void CarregaDGRevisao()
	{
		TYbyWFwKw7 = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesDwgIligCorrente(DeclaracoesGeral.arqAtivo.Indice, ref TYbyWFwKw7);
			int num = Information.UBound(TYbyWFwKw7);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgRevisao.Rows.Add(TYbyWFwKw7[i].revisao, TYbyWFwKw7[i].criador, TYbyWFwKw7[i].data);
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
			cDadosAccessInterligacao3.fechaConexao();
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

	private void xkZUBQ71Z8(object P_0, MouseEventArgs P_1)
	{
		mostraPagina();
	}

	private void gVVUVHuGMZ(object P_0, MouseEventArgs P_1)
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

	public string montaCruzamentoPagina(string sPagina)
	{
		string text = sPagina;
		if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
		{
			if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
			{
				if (DeclaracoesGeral.Conf.incluirColuna == 6)
				{
					text = "(" + sPagina + ")";
					string text2 = Pagina.BuscaAlternativo(sPagina, bretornaVazio: true);
					if (Operators.CompareString(text2, "", TextCompare: true) != 0)
					{
						text = text + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
					}
				}
			}
			else
			{
				text = Pagina.BuscaAlternativo(sPagina, bretornaVazio: false);
			}
		}
		else
		{
			text = sPagina;
		}
		return text;
	}
}
