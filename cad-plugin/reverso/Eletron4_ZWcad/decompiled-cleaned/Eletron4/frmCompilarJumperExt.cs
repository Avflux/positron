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
public class frmCompilarJumperExt : Form
{
	private IContainer Gdxyt17KNr;

	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView TW4yjhJDPX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbRevisao")]
	private TextBox LGRyLx9XXH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btAnalisar")]
	private Button jMpyw1iVEE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	[CompilerGenerated]
	private Button UcRyxV4TXh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	private Button N1AybeVnYd;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label MmByMrCcI8;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip jR5yO5jgYo;

	[CompilerGenerated]
	[AccessedThroughProperty("cbPreservar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox NpvyICmTQS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btApagarComp")]
	private Button FFHy7M0hYL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgERROS")]
	private DataGridView nR6yqaK2Vs;

	private DeclaracoesFiacao.structurePontosBlocos[] zvryahUINQ;

	private DeclaracoesFiacao.structureRevisoes[] R6Ay8m9JZa;

	private DeclaracoesFiacao.structurePontosPotencial[] KBUyNJ5fIO;

	private List<int> wf4yF5DOZi;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return TW4yjhJDPX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TW4yjhJDPX = value;
		}
	}

	internal virtual TextBox tbRevisao
	{
		[CompilerGenerated]
		get
		{
			return LGRyLx9XXH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LGRyLx9XXH = value;
		}
	}

	internal virtual Button btAnalisar
	{
		[CompilerGenerated]
		get
		{
			return jMpyw1iVEE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bl8yJy8tUc;
			Button button = jMpyw1iVEE;
			if (button != null)
			{
				button.Click -= value2;
			}
			jMpyw1iVEE = value;
			button = jMpyw1iVEE;
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
			return UcRyxV4TXh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qvnyhCtTC8;
			Button button = UcRyxV4TXh;
			if (button != null)
			{
				button.Click -= value2;
			}
			UcRyxV4TXh = value;
			button = UcRyxV4TXh;
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
			return N1AybeVnYd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dN4yoGlNc0;
			Button button = N1AybeVnYd;
			if (button != null)
			{
				button.Click -= value2;
			}
			N1AybeVnYd = value;
			button = N1AybeVnYd;
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
			return MmByMrCcI8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MmByMrCcI8 = value;
		}
	}

	internal virtual CheckBox cbPreservar
	{
		[CompilerGenerated]
		get
		{
			return NpvyICmTQS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NpvyICmTQS = value;
		}
	}

	internal virtual Button btApagarComp
	{
		[CompilerGenerated]
		get
		{
			return FFHy7M0hYL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mGryD9CKtI;
			Button button = FFHy7M0hYL;
			if (button != null)
			{
				button.Click -= value2;
			}
			FFHy7M0hYL = value;
			button = FFHy7M0hYL;
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
			return nR6yqaK2Vs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = n9nyvLfJG7;
			MouseEventHandler value3 = PrOy6Q3V3M;
			DataGridView dataGridView = nR6yqaK2Vs;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.MouseUp -= value3;
			}
			nR6yqaK2Vs = value;
			dataGridView = nR6yqaK2Vs;
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
			if (disposing && Gdxyt17KNr != null)
			{
				Gdxyt17KNr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ywCyTjXUkK()
	{
		Gdxyt17KNr = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		tbRevisao = new TextBox();
		btAnalisar = new Button();
		btSalvar = new Button();
		btApagar = new Button();
		Label2 = new Label();
		FDqpBiUmZij(new ToolTip(Gdxyt17KNr));
		cbPreservar = new CheckBox();
		btApagarComp = new Button();
		dgERROS = new DataGridView();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgERROS).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
		dgRevisao.Location = new Point(12, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(277, 218);
		dgRevisao.TabIndex = 3;
		tbRevisao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbRevisao.Location = new Point(120, 279);
		tbRevisao.MaxLength = 5;
		tbRevisao.Name = "tbRevisao";
		tbRevisao.Size = new Size(42, 20);
		tbRevisao.TabIndex = 6;
		btAnalisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAnalisar.FlatStyle = FlatStyle.Flat;
		btAnalisar.ForeColor = SystemColors.Control;
		btAnalisar.Image = Resources.Programacao_32;
		btAnalisar.Location = new Point(12, 267);
		btAnalisar.Name = "btAnalisar";
		btAnalisar.Size = new Size(40, 42);
		btAnalisar.TabIndex = 14;
		btAnalisar.UseVisualStyleBackColor = true;
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(178, 266);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 15;
		btSalvar.UseVisualStyleBackColor = true;
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(253, 270);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(36, 36);
		btApagar.TabIndex = 17;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label2.AutoSize = true;
		Label2.Location = new Point(68, 282);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 18;
		Label2.Text = "Label2";
		cbPreservar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbPreservar.AutoSize = true;
		cbPreservar.Location = new Point(12, 236);
		cbPreservar.Name = "cbPreservar";
		cbPreservar.Size = new Size(81, 17);
		cbPreservar.TabIndex = 19;
		cbPreservar.Text = "CheckBox1";
		cbPreservar.UseVisualStyleBackColor = true;
		btApagarComp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarComp.FlatStyle = FlatStyle.Flat;
		btApagarComp.ForeColor = SystemColors.Control;
		btApagarComp.Image = Resources.ApagarComp_32;
		btApagarComp.Location = new Point(318, 266);
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
		dgERROS.Location = new Point(297, 12);
		dgERROS.Name = "dgERROS";
		dgERROS.ReadOnly = true;
		dgERROS.RowHeadersVisible = false;
		dgERROS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgERROS.Size = new Size(65, 241);
		dgERROS.TabIndex = 25;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(374, 321);
		Controls.Add(dgERROS);
		Controls.Add(btApagarComp);
		Controls.Add(cbPreservar);
		Controls.Add(Label2);
		Controls.Add(btApagar);
		Controls.Add(btSalvar);
		Controls.Add(btAnalisar);
		Controls.Add(tbRevisao);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(390, 1000);
		MinimumSize = new Size(390, 360);
		Name = "frmCompilarJumperExt";
		ShowInTaskbar = false;
		Text = "Jumper Externo";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgERROS).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return jR5yO5jgYo;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		jR5yO5jgYo = WithEventsValue;
	}

	public frmCompilarJumperExt()
	{
		zvryahUINQ = new DeclaracoesFiacao.structurePontosBlocos[1];
		R6Ay8m9JZa = new DeclaracoesFiacao.structureRevisoes[1];
		KBUyNJ5fIO = new DeclaracoesFiacao.structurePontosPotencial[1];
		wf4yF5DOZi = new List<int>();
		try
		{
			if (Geral.ExisteForm("frmCompilarJumperExt") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				ywCyTjXUkK();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1404]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]);
				cbPreservar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 765]);
				cbPreservar.Checked = true;
				w8dpBZ0kvSD().SetToolTip(btAnalisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1406]));
				w8dpBZ0kvSD().SetToolTip(btApagar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 757]));
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1407]));
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

	private void bl8yJy8tUc(object P_0, EventArgs P_1)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected Obj, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected Obj, but got Unknown
		//IL_1714: Unknown result type (might be due to invalid IL or missing references)
		//IL_1719: Unknown result type (might be due to invalid IL or missing references)
		//IL_1723: Unknown result type (might be due to invalid IL or missing references)
		//IL_172a: Expected Obj, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1778: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17de: Unknown result type (might be due to invalid IL or missing references)
		//IL_180a: Unknown result type (might be due to invalid IL or missing references)
		//IL_180f: Unknown result type (might be due to invalid IL or missing references)
		//IL_183b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1840: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Expected Obj, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_18af: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18be: Expected Obj, but got Unknown
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_086e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1101: Unknown result type (might be due to invalid IL or missing references)
		//IL_1125: Unknown result type (might be due to invalid IL or missing references)
		//IL_112a: Unknown result type (might be due to invalid IL or missing references)
		//IL_114f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1154: Unknown result type (might be due to invalid IL or missing references)
		//IL_1171: Unknown result type (might be due to invalid IL or missing references)
		//IL_1176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ede: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_147b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1480: Unknown result type (might be due to invalid IL or missing references)
		//IL_14af: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1198: Unknown result type (might be due to invalid IL or missing references)
		//IL_119d: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_120d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ada: Unknown result type (might be due to invalid IL or missing references)
		//IL_152a: Unknown result type (might be due to invalid IL or missing references)
		//IL_152f: Unknown result type (might be due to invalid IL or missing references)
		//IL_155e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1563: Unknown result type (might be due to invalid IL or missing references)
		//IL_1234: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Unknown result type (might be due to invalid IL or missing references)
		//IL_1255: Unknown result type (might be due to invalid IL or missing references)
		//IL_125a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1277: Unknown result type (might be due to invalid IL or missing references)
		//IL_127c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c52: Unknown result type (might be due to invalid IL or missing references)
		//IL_100e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1013: Unknown result type (might be due to invalid IL or missing references)
		//IL_103a: Unknown result type (might be due to invalid IL or missing references)
		//IL_103f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1960: Unknown result type (might be due to invalid IL or missing references)
		//IL_1965: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15de: Unknown result type (might be due to invalid IL or missing references)
		//IL_1605: Unknown result type (might be due to invalid IL or missing references)
		//IL_160a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1313: Unknown result type (might be due to invalid IL or missing references)
		//IL_1318: Unknown result type (might be due to invalid IL or missing references)
		//IL_133d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1342: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e74: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db0: Expected Obj, but got Unknown
		//IL_1de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ded: Expected Obj, but got Unknown
		//IL_0927: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0943: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Unknown result type (might be due to invalid IL or missing references)
		//IL_095a: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0974: Unknown result type (might be due to invalid IL or missing references)
		//IL_0979: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Unknown result type (might be due to invalid IL or missing references)
		//IL_0998: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef5: Expected Obj, but got Unknown
		//IL_1f8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2015: Unknown result type (might be due to invalid IL or missing references)
		//IL_201a: Unknown result type (might be due to invalid IL or missing references)
		//IL_201e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2023: Unknown result type (might be due to invalid IL or missing references)
		//IL_2059: Unknown result type (might be due to invalid IL or missing references)
		//IL_205e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2062: Unknown result type (might be due to invalid IL or missing references)
		//IL_2067: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0814: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b6: Unknown result type (might be due to invalid IL or missing references)
		ApagaBlocoErroFiacao();
		if (!clsInterligacao.ExisteJumperExternosNoDesenho())
		{
			return;
		}
		formataDGErros(berros: false);
		btAnalisar.Enabled = false;
		btSalvar.Enabled = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		zvryahUINQ = new DeclaracoesFiacao.structurePontosBlocos[1];
		KBUyNJ5fIO = new DeclaracoesFiacao.structurePontosPotencial[1];
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
					ApagaBlocoErroFiacao();
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
								if (Operators.CompareString(left, "", TextCompare: true) == 0 || Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "I", TextCompare: true) == 0 || Operators.CompareString(left, "M", TextCompare: true) == 0)
								{
									continue;
								}
								if (Operators.CompareString(left, "B", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "E", TextCompare: true) == 0 && clsConexao.possuiTerminalRB(ref val6))
									{
										if (!list.Contains(val6.Name.ToString()))
										{
											list.Add(val6.Name.ToString());
										}
										list2.Add(((DBObject)val6).ObjectId);
									}
								}
								else
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
										if (vPryGARi5x(point2dAt2.X, num, 1.0) | vPryGARi5x(point2dAt2.X, num2, 1.0) | vPryGARi5x(point2dAt2.Y, num3, 1.0) | vPryGARi5x(point2dAt2.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference = ref zvryahUINQ;
											reference = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											zvryahUINQ[Information.UBound(zvryahUINQ)].X = point2dAt2.X;
											zvryahUINQ[Information.UBound(zvryahUINQ)].Y = point2dAt2.Y;
										}
										Point2d point2dAt3 = val15.GetPoint2dAt(val15.NumberOfVertices - 1);
										if (vPryGARi5x(point2dAt3.X, num, 1.0) | vPryGARi5x(point2dAt3.X, num2, 1.0) | vPryGARi5x(point2dAt3.Y, num3, 1.0) | vPryGARi5x(point2dAt3.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference2 = ref zvryahUINQ;
											reference2 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference2, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											zvryahUINQ[Information.UBound(zvryahUINQ)].X = point2dAt3.X;
											zvryahUINQ[Information.UBound(zvryahUINQ)].Y = point2dAt3.Y;
										}
									}
									Line val16 = (Line)(object)((val14 is Line) ? val14 : null);
									if (val16 != null)
									{
										val11 = val16.StartPoint;
										bool flag = vPryGARi5x(val11.X, num, 1.0);
										val11 = val16.StartPoint;
										bool num6 = flag | vPryGARi5x(val11.X, num2, 1.0);
										val11 = val16.StartPoint;
										bool num7 = num6 | vPryGARi5x(val11.Y, num3, 1.0);
										val11 = val16.StartPoint;
										if (num7 | vPryGARi5x(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference3 = ref zvryahUINQ;
											reference3 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference3, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference4 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val16.StartPoint;
											reference4.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference5 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val16.StartPoint;
											reference5.Y = val11.Y;
										}
										val11 = val16.EndPoint;
										bool flag2 = vPryGARi5x(val11.X, num, 1.0);
										val11 = val16.EndPoint;
										bool num8 = flag2 | vPryGARi5x(val11.X, num2, 1.0);
										val11 = val16.EndPoint;
										bool num9 = num8 | vPryGARi5x(val11.Y, num3, 1.0);
										val11 = val16.EndPoint;
										if (num9 | vPryGARi5x(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference6 = ref zvryahUINQ;
											reference6 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference6, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference7 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val16.EndPoint;
											reference7.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference8 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val16.EndPoint;
											reference8.Y = val11.Y;
										}
									}
									Circle val17 = (Circle)(object)((val14 is Circle) ? val14 : null);
									if (val17 != null)
									{
										val11 = val17.Center;
										bool flag3 = vPryGARi5x(val11.X + val17.Radius, num, 1.0);
										val11 = val17.Center;
										bool num10 = flag3 | vPryGARi5x(val11.X + val17.Radius, num2, 1.0);
										val11 = val17.Center;
										bool num11 = num10 | vPryGARi5x(val11.Y, num3, 1.0);
										val11 = val17.Center;
										if (num11 | vPryGARi5x(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference9 = ref zvryahUINQ;
											reference9 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference9, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference10 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference10.X = val11.X + val17.Radius;
											ref DeclaracoesFiacao.structurePontosBlocos reference11 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference11.Y = val11.Y;
										}
										val11 = val17.Center;
										bool flag4 = vPryGARi5x(val11.X - val17.Radius, num, 1.0);
										val11 = val17.Center;
										bool num12 = flag4 | vPryGARi5x(val11.X - val17.Radius, num2, 1.0);
										val11 = val17.Center;
										bool num13 = num12 | vPryGARi5x(val11.Y, num3, 1.0);
										val11 = val17.Center;
										if (num13 | vPryGARi5x(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference12 = ref zvryahUINQ;
											reference12 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference12, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference13 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference13.X = val11.X - val17.Radius;
											ref DeclaracoesFiacao.structurePontosBlocos reference14 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference14.Y = val11.Y;
										}
										val11 = val17.Center;
										bool flag5 = vPryGARi5x(val11.X, num, 1.0);
										val11 = val17.Center;
										bool num14 = flag5 | vPryGARi5x(val11.X, num2, 1.0);
										val11 = val17.Center;
										bool num15 = num14 | vPryGARi5x(val11.Y - val17.Radius, num3, 1.0);
										val11 = val17.Center;
										if (num15 | vPryGARi5x(val11.Y - val17.Radius, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference15 = ref zvryahUINQ;
											reference15 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference15, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference16 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference16.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference17 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference17.Y = val11.Y - val17.Radius;
										}
										val11 = val17.Center;
										bool flag6 = vPryGARi5x(val11.X, num, 1.0);
										val11 = val17.Center;
										bool num16 = flag6 | vPryGARi5x(val11.X, num2, 1.0);
										val11 = val17.Center;
										bool num17 = num16 | vPryGARi5x(val11.Y + val17.Radius, num3, 1.0);
										val11 = val17.Center;
										if (num17 | vPryGARi5x(val11.Y + val17.Radius, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference18 = ref zvryahUINQ;
											reference18 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference18, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference19 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference19.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference20 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val17.Center;
											reference20.Y = val11.Y + val17.Radius;
										}
									}
									DBPoint val18 = (DBPoint)(object)((val14 is DBPoint) ? val14 : null);
									if (val18 != null)
									{
										val11 = val18.Position;
										bool flag7 = vPryGARi5x(val11.X, num, 1.0);
										val11 = val18.Position;
										bool num18 = flag7 | vPryGARi5x(val11.X, num2, 1.0);
										val11 = val18.Position;
										bool num19 = num18 | vPryGARi5x(val11.Y, num3, 1.0);
										val11 = val18.Position;
										if (num19 | vPryGARi5x(val11.Y, num4, 1.0))
										{
											ref DeclaracoesFiacao.structurePontosBlocos[] reference21 = ref zvryahUINQ;
											reference21 = (DeclaracoesFiacao.structurePontosBlocos[])Utils.CopyArray(reference21, new DeclaracoesFiacao.structurePontosBlocos[Information.UBound(zvryahUINQ) + 1 + 1]);
											zvryahUINQ[Information.UBound(zvryahUINQ)].nome = item;
											ref DeclaracoesFiacao.structurePontosBlocos reference22 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
											val11 = val18.Position;
											reference22.X = val11.X;
											ref DeclaracoesFiacao.structurePontosBlocos reference23 = ref zvryahUINQ[Information.UBound(zvryahUINQ)];
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
								DeclaracoesEntidades.StructureConexao conex = default;
								if (XDataConexao.lerXDataConexao(ref pl, ref conex))
								{
									if (!wf4yF5DOZi.Contains(conex.Painel))
									{
										wf4yF5DOZi.Add(conex.Painel);
									}
									if ((conex.Tipo == 4) & conex.Disp1)
									{
										Point2d point2dAt4 = pl.GetPoint2dAt(0);
										ref DeclaracoesFiacao.structurePontosPotencial[] kBUyNJ5fIO = ref KBUyNJ5fIO;
										kBUyNJ5fIO = (DeclaracoesFiacao.structurePontosPotencial[])Utils.CopyArray(kBUyNJ5fIO, new DeclaracoesFiacao.structurePontosPotencial[Information.UBound(KBUyNJ5fIO) + 1 + 1]);
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].X = point2dAt4.X;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].Y = point2dAt4.Y;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].potencial = conex.Potencial;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].painel = conex.Painel;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].secao = conex.Secao;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].cor = conex.Cor;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].layer = ((Entity)pl).Layer.ToString();
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].bJumper = true;
									}
									if (((conex.Tipo == 3) & (Operators.CompareString(conex.Jumper.ToUpper(), "JUMPER", TextCompare: true) == 0)) | ((conex.Tipo == 4) & conex.Disp2))
									{
										Point2d point2dAt5 = pl.GetPoint2dAt(pl.NumberOfVertices - 1);
										ref DeclaracoesFiacao.structurePontosPotencial[] kBUyNJ5fIO2 = ref KBUyNJ5fIO;
										kBUyNJ5fIO2 = (DeclaracoesFiacao.structurePontosPotencial[])Utils.CopyArray(kBUyNJ5fIO2, new DeclaracoesFiacao.structurePontosPotencial[Information.UBound(KBUyNJ5fIO) + 1 + 1]);
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].X = point2dAt5.X;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].Y = point2dAt5.Y;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].potencial = conex.Potencial;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].painel = conex.Painel;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].secao = conex.Secao;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].cor = conex.Cor;
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].layer = ((Entity)pl).Layer.ToString();
										KBUyNJ5fIO[Information.UBound(KBUyNJ5fIO)].bJumper = true;
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator6)?.Dispose();
						}
						DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(KBUyNJ5fIO);
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num20 = Information.UBound(KBUyNJ5fIO);
						for (int k = 1; k <= num20; k++)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							string text4 = "";
							text4 = "Layer='" + KBUyNJ5fIO[k].layer.ToString() + "' AND " + KBUyNJ5fIO[k].X.ToString("F", CultureInfo.InvariantCulture) + ">= XMin AND " + KBUyNJ5fIO[k].X.ToString("F", CultureInfo.InvariantCulture) + "<= XMax AND " + KBUyNJ5fIO[k].Y.ToString("F", CultureInfo.InvariantCulture) + ">= YMin AND " + KBUyNJ5fIO[k].Y.ToString("F", CultureInfo.InvariantCulture) + "<= YMax";
							DataRow[] array2 = dataTable2.Select(text4);
							int upperBound2 = array2.GetUpperBound(0);
							int num21 = 0;
							while (true)
							{
								if (num21 <= upperBound2)
								{
									object obj = array2[num21][0];
									ObjectId val21 = ((obj == null) ? default(ObjectId) : ((ObjectId)obj));
									BlockReference val22 = (BlockReference)val21.GetObject((OpenMode)0);
									string sRegua = "";
									string text5 = "";
									string sAlternativo = "";
									short num22 = 0;
									short tipoBorne = 0;
									short indexModelo = 0;
									Entity ent = (Entity)(object)val22;
									string text = "";
									string tipoImportado = XDataDispositivo.verificaTipoDispositivo(ref ent, ref text);
									val22 = (BlockReference)ent;
									string text6 = tipoImportado;
									string left2 = text6;
									if (Operators.CompareString(left2, "", TextCompare: true) != 0 && Operators.CompareString(left2, "P", TextCompare: true) != 0 && Operators.CompareString(left2, "A", TextCompare: true) != 0 && Operators.CompareString(left2, "I", TextCompare: true) != 0 && Operators.CompareString(left2, "M", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left2, "E", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left2, "B", TextCompare: true) == 0)
											{
												object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val22);
												DeclaracoesEntidades.StructureBorne structureBorne = ((obj2 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj2));
												indexModelo = (short)structureBorne.IndiceRegua;
												int iRegua = indexModelo;
												int num23 = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref iRegua, ref sRegua, ref sAlternativo);
												indexModelo = (short)iRegua;
												num22 = (short)num23;
												text5 = "";
												tipoBorne = (short)structureBorne.tipo;
											}
										}
										else
										{
											object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val22);
											DeclaracoesEntidades.StructurePortas structurePortas = ((obj3 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj3));
											sRegua = structurePortas.Nome1;
											text5 = structurePortas.Nome2;
											sAlternativo = structurePortas.Alternativo;
											ent = (Entity)(object)val22;
											short num24 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
											val22 = (BlockReference)ent;
											num22 = num24;
											tipoBorne = -1;
											indexModelo = (short)structurePortas.indiceDoModelo;
										}
										if ((KBUyNJ5fIO[k].painel == num22) & (num22 > 0))
										{
											double num25 = KBUyNJ5fIO[k].X;
											Extents3d value = ((Drawable)val22).Bounds.Value;
											val11 = value.MinPoint;
											bool flag8 = num25 >= val11.X - 0.25;
											double num26 = KBUyNJ5fIO[k].X;
											value = ((Drawable)val22).Bounds.Value;
											val11 = value.MaxPoint;
											bool num27 = flag8 & (num26 <= val11.X + 0.25);
											double num28 = KBUyNJ5fIO[k].Y;
											value = ((Drawable)val22).Bounds.Value;
											val11 = value.MinPoint;
											bool num29 = num27 & (num28 >= val11.Y - 0.25);
											double num30 = KBUyNJ5fIO[k].Y;
											value = ((Drawable)val22).Bounds.Value;
											val11 = value.MaxPoint;
											if (num29 & (num30 <= val11.Y + 0.25))
											{
												string terminal = "";
												double terminalNum = 0.0;
												string nRegua = "";
												if (DhsyHnu5Pu(k, ref val22, text6, 0.5, ref terminal, ref terminalNum, ref nRegua))
												{
													KBUyNJ5fIO[k].tag = sRegua;
													if (Operators.CompareString(text5, "", TextCompare: true) != 0)
													{
														ref string tag = ref KBUyNJ5fIO[k].tag;
														tag = tag + "/" + text5;
													}
													KBUyNJ5fIO[k].nRegua = nRegua;
													KBUyNJ5fIO[k].alternativo = sAlternativo;
													KBUyNJ5fIO[k].terminal = terminal;
													KBUyNJ5fIO[k].terminalNum = terminalNum;
													KBUyNJ5fIO[k].tipo = text6;
													if (Operators.CompareString(text6, "B", TextCompare: true) != 0)
													{
														KBUyNJ5fIO[k].PosicaoNum = 0;
														KBUyNJ5fIO[k].dOrdem = -1.0;
													}
													else
													{
														KBUyNJ5fIO[k].PosicaoNum = 1;
														KBUyNJ5fIO[k].dOrdem = DicionarioReguas.BuscaIndiceDeUmaRegua(sRegua, num22);
													}
													KBUyNJ5fIO[k].tipoBorne = tipoBorne;
													KBUyNJ5fIO[k].handle = ((object)((DBObject)val22).Handle/*cast due to constrained. prefix*/).ToString();
													KBUyNJ5fIO[k].indexModelo = indexModelo;
													KBUyNJ5fIO[k].bLink = false;
													break;
												}
											}
										}
									}
									num21++;
									continue;
								}
								InsereBlocoErroFiacao(KBUyNJ5fIO[k].layer, KBUyNJ5fIO[k].X, KBUyNJ5fIO[k].Y);
								if (!list3.Contains(KBUyNJ5fIO[k].layer.ToString()))
								{
									list3.Add(KBUyNJ5fIO[k].layer.ToString());
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

	private void qvnyhCtTC8(object P_0, EventArgs P_1)
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
					DeclaracoesGeral.bAnularEventos = true;
					try
					{
						DeclaracoesFiacao.structurePosicaoDisp[] mPosicao = new DeclaracoesFiacao.structurePosicaoDisp[1];
						foreach (int item2 in wf4yF5DOZi)
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
						int num = Information.UBound(KBUyNJ5fIO);
						for (int i = 1; i <= num; i++)
						{
							DataRow dataRow = dataTable.NewRow();
							dataRow["Painel"] = KBUyNJ5fIO[i].painel;
							dataRow["Potencial"] = KBUyNJ5fIO[i].potencial;
							dataRow["Pagina"] = KBUyNJ5fIO[i].layer;
							dataRow["Tag"] = KBUyNJ5fIO[i].tag;
							dataRow["Alternativo"] = KBUyNJ5fIO[i].alternativo;
							dataRow["Terminal"] = KBUyNJ5fIO[i].terminal;
							dataRow["TerminalNum"] = KBUyNJ5fIO[i].terminalNum;
							dataRow["Tipo"] = KBUyNJ5fIO[i].tipo;
							dataRow["Secao"] = KBUyNJ5fIO[i].secao;
							dataRow["Cor"] = KBUyNJ5fIO[i].cor;
							dataRow["TipoBorne"] = KBUyNJ5fIO[i].tipoBorne;
							dataRow["BJumper"] = KBUyNJ5fIO[i].bJumper;
							dataRow["BLink"] = KBUyNJ5fIO[i].bLink;
							dataRow["Handle"] = KBUyNJ5fIO[i].handle;
							dataRow["IndexModelo"] = KBUyNJ5fIO[i].indexModelo;
							dataRow["NRegua"] = KBUyNJ5fIO[i].nRegua;
							if (Operators.CompareString(KBUyNJ5fIO[i].tipo, "B", TextCompare: true) != 0)
							{
								dataRow["PosicaoNum"] = 0;
								dataRow["Ordem"] = 0;
								int num2 = Information.UBound(mPosicao);
								for (int j = 1; j <= num2; j++)
								{
									if ((mPosicao[j].painel == KBUyNJ5fIO[i].painel) & (Operators.CompareString(mPosicao[j].tag, KBUyNJ5fIO[i].tag, TextCompare: true) == 0))
									{
										dataRow["PosicaoNum"] = mPosicao[j].posicaoNum;
										dataRow["Ordem"] = mPosicao[j].ordem;
										break;
									}
								}
							}
							else
							{
								dataRow["PosicaoNum"] = KBUyNJ5fIO[i].PosicaoNum;
								dataRow["Ordem"] = KBUyNJ5fIO[i].dOrdem;
							}
							dataTable.Rows.Add(dataRow);
						}
						cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
						cDadosAccessInterligacao3.RemoveRevisaoTabelaParaDWG("Jumper4", DeclaracoesGeral.arqAtivo.Indice, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1460]));
						cDadosAccessInterligacao3.fechaConexao();
						int num3 = dgRevisao.Rows.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							if (Operators.ConditionalCompareObjectEqual(dgRevisao.Rows[k].Cells[0].Value, DeclaracoesGeral.mMensagem[1, 1460], TextCompare: true))
							{
								dgRevisao.Rows.RemoveAt(k);
								break;
							}
						}
						string filterExpression = "Potencial > 0";
						string sort = "Potencial ASC, PosicaoNum DESC, Ordem, TerminalNum, Terminal";
						DataRow[] array = dataTable.Select(filterExpression, sort);
						int num4 = 0;
						int num5 = 0;
						DeclaracoesGeral._uscPagina.Quantidade = array.GetUpperBound(0);
						DeclaracoesGeral._uscPagina.pbIniciar();
						DateTime now = DateTime.Now;
						cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
						int upperBound = array.GetUpperBound(0);
						for (int l = 0; l <= upperBound; l++)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							DeclaracoesFiacao.structurePontosPotencial pot = new DeclaracoesFiacao.structurePontosPotencial
							{
								painel = Conversions.ToShort(array[l][0]),
								potencial = Conversions.ToInteger(array[l][1]),
								dOrdem = Conversions.ToDouble(array[l][2])
							};
							if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
							{
								if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
								{
									if (DeclaracoesGeral.Conf.incluirColuna == 6)
									{
										pot.layer = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", array[l][3]), ")"));
										string text2 = Pagina.BuscaAlternativo(Conversions.ToString(array[l][3]), bretornaVazio: true);
										if (Operators.CompareString(text2, "", TextCompare: true) != 0)
										{
											ref string layer = ref pot.layer;
											layer = layer + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
										}
									}
								}
								else
								{
									pot.layer = Pagina.BuscaAlternativo(Conversions.ToString(array[l][3]), bretornaVazio: false);
								}
							}
							else
							{
								pot.layer = Conversions.ToString(array[l][3]);
							}
							pot.tag = Conversions.ToString(array[l][4]);
							pot.alternativo = Conversions.ToString(array[l][5]);
							pot.terminal = Conversions.ToString(array[l][6]);
							pot.terminalNum = Conversions.ToDouble(array[l][7]);
							pot.tipo = Conversions.ToString(array[l][8]);
							pot.secao = Conversions.ToString(array[l][9]);
							pot.cor = Conversions.ToString(array[l][10]);
							pot.PosicaoNum = Conversions.ToInteger(array[l][11]);
							pot.tipoBorne = Conversions.ToShort(array[l][12]);
							pot.bJumper = Conversions.ToBoolean(array[l][13]);
							pot.bLink = Conversions.ToBoolean(array[l][14]);
							pot.handle = Conversions.ToString(array[l][15]);
							pot.indexModelo = Conversions.ToShort(array[l][16]);
							pot.nRegua = Conversions.ToString(array[l][17]);
							if (pot.potencial != num4)
							{
								num4 = pot.potencial;
								num5 = 0;
							}
							num5 = (pot.Ordem = num5 + 1);
							pot.revisao = text;
							pot.dwg = DeclaracoesGeral.arqAtivo.Indice;
							pot.criador = Environment.UserName;
							pot.data = now;
							cDadosAccessJumper2.AdicionaItemPotencial(pot);
						}
						if (cbPreservar.Checked && dgRevisao.RowCount != 0)
						{
							DeclaracoesFiacao.structurePnRev[] array2 = new DeclaracoesFiacao.structurePnRev[1];
							array2 = new DeclaracoesFiacao.structurePnRev[1];
							foreach (int item3 in wf4yF5DOZi)
							{
								array2 = (DeclaracoesFiacao.structurePnRev[])Utils.CopyArray(array2, new DeclaracoesFiacao.structurePnRev[Information.UBound(array2) + 1 + 1]);
								array2[Information.UBound(array2)].painel = item3;
								array2[Information.UBound(array2)].revisao = Conversions.ToString(dgRevisao.Rows[dgRevisao.RowCount - 1].Cells[0].Value);
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
								cDadosAccessJumper2.CarregaPotenciais(DeclaracoesGeral.arqAtivo.Indice, array2[m].revisao, array2[m].painel, ref mPot);
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
								cDadosAccessJumper2.AtualizaPotenciais(DeclaracoesGeral.arqAtivo.Indice, text, ref varTableFiacaoH);
								cDadosAccessJumper2.ReordenaOrdemPotenciais(DeclaracoesGeral.arqAtivo.Indice, text);
							}
						}
						text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1460]);
						filterExpression = "Potencial > 0";
						sort = "Potencial ASC, PosicaoNum DESC, Ordem, TerminalNum, Terminal";
						array = dataTable.Select(filterExpression, sort);
						num4 = 0;
						num5 = 0;
						DeclaracoesGeral._uscPagina.Quantidade = array.GetUpperBound(0);
						DeclaracoesGeral._uscPagina.pbIniciar();
						now = DateTime.Now;
						int upperBound2 = array.GetUpperBound(0);
						for (int num8 = 0; num8 <= upperBound2; num8++)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
							DeclaracoesFiacao.structurePontosPotencial pot2 = new DeclaracoesFiacao.structurePontosPotencial
							{
								painel = Conversions.ToShort(array[num8][0]),
								potencial = Conversions.ToInteger(array[num8][1]),
								dOrdem = Conversions.ToDouble(array[num8][2])
							};
							if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
							{
								if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
								{
									if (DeclaracoesGeral.Conf.incluirColuna == 6)
									{
										pot2.layer = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", array[num8][3]), ")"));
										string text3 = Pagina.BuscaAlternativo(Conversions.ToString(array[num8][3]), bretornaVazio: true);
										if (Operators.CompareString(text3, "", TextCompare: true) != 0)
										{
											ref string layer2 = ref pot2.layer;
											layer2 = layer2 + DeclaracoesGeral.Conf.SeparadorCruzamento + text3;
										}
									}
								}
								else
								{
									pot2.layer = Pagina.BuscaAlternativo(Conversions.ToString(array[num8][3]), bretornaVazio: false);
								}
							}
							else
							{
								pot2.layer = Conversions.ToString(array[num8][3]);
							}
							pot2.tag = Conversions.ToString(array[num8][4]);
							pot2.alternativo = Conversions.ToString(array[num8][5]);
							pot2.terminal = Conversions.ToString(array[num8][6]);
							pot2.terminalNum = Conversions.ToDouble(array[num8][7]);
							pot2.tipo = Conversions.ToString(array[num8][8]);
							pot2.secao = Conversions.ToString(array[num8][9]);
							pot2.cor = Conversions.ToString(array[num8][10]);
							pot2.PosicaoNum = Conversions.ToInteger(array[num8][11]);
							pot2.tipoBorne = Conversions.ToShort(array[num8][12]);
							pot2.bJumper = Conversions.ToBoolean(array[num8][13]);
							pot2.bLink = Conversions.ToBoolean(array[num8][14]);
							pot2.handle = Conversions.ToString(array[num8][15]);
							pot2.indexModelo = Conversions.ToShort(array[num8][16]);
							pot2.nRegua = Conversions.ToString(array[num8][17]);
							if (pot2.potencial != num4)
							{
								num4 = pot2.potencial;
								num5 = 0;
							}
							num5 = (pot2.Ordem = num5 + 1);
							pot2.revisao = text;
							pot2.dwg = DeclaracoesGeral.arqAtivo.Indice;
							pot2.criador = Environment.UserName;
							pot2.data = now;
							cDadosAccessJumper2.AdicionaItemPotencial(pot2);
						}
						if (cbPreservar.Checked && dgRevisao.RowCount != 0)
						{
							DeclaracoesFiacao.structurePnRev[] array3 = new DeclaracoesFiacao.structurePnRev[1];
							array3 = new DeclaracoesFiacao.structurePnRev[1];
							foreach (int item4 in wf4yF5DOZi)
							{
								array3 = (DeclaracoesFiacao.structurePnRev[])Utils.CopyArray(array3, new DeclaracoesFiacao.structurePnRev[Information.UBound(array3) + 1 + 1]);
								array3[Information.UBound(array3)].painel = item4;
								array3[Information.UBound(array3)].revisao = Conversions.ToString(dgRevisao.Rows[dgRevisao.RowCount - 1].Cells[0].Value);
							}
							DataTable varTableFiacaoH2 = new DataTable();
							varTableFiacaoH2.Columns.Add("Potencial", typeof(int));
							varTableFiacaoH2.Columns.Add("Handle", typeof(string));
							varTableFiacaoH2.Columns.Add("Terminal", typeof(string));
							varTableFiacaoH2.Columns.Add("Ordem", typeof(double));
							varTableFiacaoH2.Columns.Add("BLink", typeof(bool));
							DeclaracoesFiacao.structurePontosPotencial[] mPot2 = new DeclaracoesFiacao.structurePontosPotencial[1];
							int num9 = Information.UBound(array3);
							for (int num10 = 1; num10 <= num9; num10++)
							{
								cDadosAccessJumper2.CarregaPotenciais(DeclaracoesGeral.arqAtivo.Indice, array3[num10].revisao, array3[num10].painel, ref mPot2);
							}
							int num11 = Information.UBound(mPot2);
							for (int num12 = 1; num12 <= num11; num12++)
							{
								DataRow dataRow3 = varTableFiacaoH2.NewRow();
								dataRow3["Potencial"] = mPot2[num12].potencial;
								dataRow3["Handle"] = mPot2[num12].handle;
								dataRow3["Terminal"] = mPot2[num12].terminal;
								dataRow3["Ordem"] = mPot2[num12].Ordem;
								dataRow3["BLink"] = mPot2[num12].bLink;
								varTableFiacaoH2.Rows.Add(dataRow3);
							}
							if (varTableFiacaoH2.Rows.Count > 0)
							{
								cDadosAccessJumper2.AtualizaPotenciais(DeclaracoesGeral.arqAtivo.Indice, text, ref varTableFiacaoH2);
								cDadosAccessJumper2.ReordenaOrdemPotenciais(DeclaracoesGeral.arqAtivo.Indice, text);
							}
						}
						DeclaracoesGeral._uscPagina.pbFim();
						cDadosAccessJumper2.fechaConexao();
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

	private void dN4yoGlNc0(object P_0, EventArgs P_1)
	{
		if (dgRevisao.SelectedRows.Count != 0)
		{
			string revisao = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 760]), MsgBoxStyle.YesNo);
			if (msgBoxResult != MsgBoxResult.No)
			{
				cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
				cDadosAccessInterligacao3.RemoveRevisaoTabelaParaDWG("Jumper4", DeclaracoesGeral.arqAtivo.Indice, revisao);
				cDadosAccessInterligacao3.fechaConexao();
				formataDGRevisao();
				CarregaDGRevisao();
			}
		}
	}

	private bool vPryGARi5x(double P_0, double P_1, double P_2)
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

	private bool DhsyHnu5Pu(int P_0, ref BlockReference P_1, string P_2, double P_3, ref string P_4, ref double P_5, ref string P_6)
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
			double num = KBUyNJ5fIO[P_0].X;
			double num2 = KBUyNJ5fIO[P_0].Y;
			double num3 = 0.0;
			double num4 = 0.0;
			bool flag = false;
			int num5 = Information.UBound(zvryahUINQ);
			for (int i = 1; i <= num5; i = checked(i + 1))
			{
				if (Operators.CompareString(zvryahUINQ[i].nome, P_1.Name, TextCompare: true) != 0)
				{
					if (flag)
					{
						break;
					}
					continue;
				}
				flag = true;
				Point3d position = P_1.Position;
				num3 = position.X + zvryahUINQ[i].X;
				position = P_1.Position;
				num4 = position.Y + zvryahUINQ[i].Y;
				double num6 = Math.Sqrt(Math.Pow(num3 - num, 2.0) + Math.Pow(num4 - num2, 2.0));
				if (!(num6 <= P_3))
				{
					continue;
				}
				if (Operators.CompareString(P_2, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(P_2, "E", TextCompare: true) == 0)
					{
						int num7 = 1;
						int num8 = 0;
						b6uydFF7DS(ref P_1, num, num2, ref P_4, ref num7, ref num8);
						if (num7 != 2)
						{
							P_6 = "";
						}
						else
						{
							UZLyfClbkN(ref P_1, num, num2, ref P_6, num8);
						}
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

	private void po4ykM1cZf(ref BlockReference P_0, double P_1, double P_2, ref string P_3)
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

	private void b6uydFF7DS(ref BlockReference P_0, double P_1, double P_2, ref string P_3, ref int P_4, ref int P_5)
	{
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Invalid comparison between Unknown and I4
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
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

	private void UZLyfClbkN(ref BlockReference P_0, double P_1, double P_2, ref string P_3, int P_4)
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

	private void mGryD9CKtI(object P_0, EventArgs P_1)
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
				int num2 = dgRevisao.Columns.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					dgRevisao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
		R6Ay8m9JZa = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			cDadosAccessJumper2.CarregaRevisoesDwgJumperCorrente(DeclaracoesGeral.arqAtivo.Indice, ref R6Ay8m9JZa);
			int num = Information.UBound(R6Ay8m9JZa);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgRevisao.Rows.Add(R6Ay8m9JZa[i].revisao, R6Ay8m9JZa[i].criador, R6Ay8m9JZa[i].data);
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
			cDadosAccessJumper2.fechaConexao();
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

	private void n9nyvLfJG7(object P_0, MouseEventArgs P_1)
	{
		mostraPagina();
	}

	private void PrOy6Q3V3M(object P_0, MouseEventArgs P_1)
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
