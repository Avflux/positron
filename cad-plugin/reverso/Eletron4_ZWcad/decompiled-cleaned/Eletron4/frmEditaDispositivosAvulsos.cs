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
public class frmEditaDispositivosAvulsos : Form
{
	private IContainer LZAGcWdNwY;

	[AccessedThroughProperty("dgDispositivos")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView WI8GKW0wFq;

	[AccessedThroughProperty("btEdita")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button n1BGelB2kU;

	[CompilerGenerated]
	[AccessedThroughProperty("tbTerminais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox sbOG2s8vn6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBLM1")]
	private ComboBox h2LG37LmPt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTerminais")]
	private Label XynGn69Xpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox nj2G1CjSvj;

	private clsDispositivo.mBlocosPrincipal[] DIZGleUcgg;

	private bool s2NG53Gg3o;

	private int vdQG032j7K;

	private int eenGRnq8Lg;

	private bool dGYGmInWni;

	internal virtual DataGridView dgDispositivos
	{
		[CompilerGenerated]
		get
		{
			return WI8GKW0wFq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = OEUG7Tal0a;
			MouseEventHandler value3 = QZOGqnifyu;
			DataGridViewCellEventHandler value4 = JWxGaMtj3q;
			DataGridView dataGridView = WI8GKW0wFq;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
				dataGridView.CellContentDoubleClick -= value4;
			}
			WI8GKW0wFq = value;
			dataGridView = WI8GKW0wFq;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
				dataGridView.CellContentDoubleClick += value4;
			}
		}
	}

	internal virtual Button btEdita
	{
		[CompilerGenerated]
		get
		{
			return n1BGelB2kU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = S4aGbmC5vB;
			Button button = n1BGelB2kU;
			if (button != null)
			{
				button.Click -= value2;
			}
			n1BGelB2kU = value;
			button = n1BGelB2kU;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbTerminais
	{
		[CompilerGenerated]
		get
		{
			return sbOG2s8vn6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Lf8G819XdW;
			TextBox textBox = sbOG2s8vn6;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			sbOG2s8vn6 = value;
			textBox = sbOG2s8vn6;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	internal virtual ComboBox CBLM1
	{
		[CompilerGenerated]
		get
		{
			return h2LG37LmPt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = QpCGNPxRis;
			EventHandler value3 = G4yGFuuNdh;
			ComboBox comboBox = h2LG37LmPt;
			if (comboBox != null)
			{
				comboBox.KeyUp -= value2;
				comboBox.SelectedIndexChanged -= value3;
			}
			h2LG37LmPt = value;
			comboBox = h2LG37LmPt;
			if (comboBox != null)
			{
				comboBox.KeyUp += value2;
				comboBox.SelectedIndexChanged += value3;
			}
		}
	}

	internal virtual Label lbTerminais
	{
		[CompilerGenerated]
		get
		{
			return XynGn69Xpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XynGn69Xpt = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return nj2G1CjSvj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nj2G1CjSvj = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && LZAGcWdNwY != null)
			{
				LZAGcWdNwY.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Hs8GjSNpYu()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dgDispositivos = new DataGridView();
		btEdita = new Button();
		tbTerminais = new TextBox();
		CBLM1 = new ComboBox();
		lbTerminais = new Label();
		GroupBox1 = new GroupBox();
		((ISupportInitialize)dgDispositivos).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		dgDispositivos.AllowUserToAddRows = false;
		dgDispositivos.AllowUserToDeleteRows = false;
		dgDispositivos.AllowUserToOrderColumns = true;
		dgDispositivos.AllowUserToResizeRows = false;
		dgDispositivos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgDispositivos.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgDispositivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgDispositivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDispositivos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDispositivos.Location = new Point(12, 81);
		dgDispositivos.MultiSelect = false;
		dgDispositivos.Name = "dgDispositivos";
		dgDispositivos.ReadOnly = true;
		dgDispositivos.RowHeadersVisible = false;
		dgDispositivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDispositivos.Size = new Size(326, 308);
		dgDispositivos.TabIndex = 9;
		btEdita.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btEdita.Enabled = false;
		btEdita.FlatStyle = FlatStyle.Flat;
		btEdita.ForeColor = SystemColors.Control;
		btEdita.Image = Resources.Editar_32;
		btEdita.Location = new Point(298, 407);
		btEdita.Name = "btEdita";
		btEdita.Size = new Size(40, 40);
		btEdita.TabIndex = 187;
		btEdita.UseVisualStyleBackColor = true;
		tbTerminais.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tbTerminais.Location = new Point(12, 419);
		tbTerminais.Name = "tbTerminais";
		tbTerminais.Size = new Size(280, 20);
		tbTerminais.TabIndex = 188;
		CBLM1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CBLM1.FormattingEnabled = true;
		CBLM1.Location = new Point(12, 26);
		CBLM1.Name = "CBLM1";
		CBLM1.Size = new Size(297, 21);
		CBLM1.TabIndex = 190;
		lbTerminais.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbTerminais.AutoSize = true;
		lbTerminais.Location = new Point(12, 402);
		lbTerminais.Name = "lbTerminais";
		lbTerminais.Size = new Size(60, 13);
		lbTerminais.TabIndex = 192;
		lbTerminais.Text = "lbTerminais";
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox1.Controls.Add(CBLM1);
		GroupBox1.Location = new Point(12, 12);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(326, 63);
		GroupBox1.TabIndex = 193;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(354, 461);
		Controls.Add(GroupBox1);
		Controls.Add(tbTerminais);
		Controls.Add(lbTerminais);
		Controls.Add(btEdita);
		Controls.Add(dgDispositivos);
		MinimumSize = new Size(370, 500);
		Name = "frmEditaDispositivosAvulsos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Editor Term Disp Avulsos";
		((ISupportInitialize)dgDispositivos).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmEditaDispositivosAvulsos()
	{
		Resize += PeaGPmiPnC;
		s2NG53Gg3o = false;
		vdQG032j7K = 0;
		eenGRnq8Lg = 0;
		dGYGmInWni = false;
		if (!Geral.ExisteForm("frmEditaDispositivosAvulsos"))
		{
			Hs8GjSNpYu();
			cDadosLM cDadosLM2 = new cDadosLM();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1688]);
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1538]);
			lbTerminais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]);
			List<int> lLM = new List<int>();
			iWdGLETeLM(ref lLM);
			ComboBox COMBO = CBLM1;
			cDadosLM2.CarregaDadosLMLista(ref COMBO, lLM);
			CBLM1 = COMBO;
			cDadosLM2.fechaConexao();
			s2NG53Gg3o = true;
			AtualizaDGBlocos();
			Application.ShowModelessDialog((Form)this);
			CarregaDispPaineis(-1);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	private void iWdGLETeLM(ref List<int> P_0)
	{
		clsDispositivo.pesquisaDispositivosTerminais(ref DIZGleUcgg, ref P_0);
		CarregaDispPaineis(eenGRnq8Lg);
	}

	public void formataDGBlocos()
	{
		try
		{
			dgDispositivos.Rows.Clear();
			dgDispositivos.Columns.Clear();
			dgDispositivos.Columns.Add("Nome_1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 627]));
			dgDispositivos.Columns.Add("TIPO", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 660]));
			dgDispositivos.Columns.Add("Terminais", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 659]));
			dgDispositivos.Columns.Add("PN", "PN");
			dgDispositivos.Columns.Add("Nome_1", "Nome_1");
			dgDispositivos.Columns.Add("Nome_2", "Nome_2");
			dgDispositivos.Columns.Add("Alternativo_", "Alternativo_");
			dgDispositivos.Columns.Add("Handle", "Handle");
			dgDispositivos.Columns.Add("BEDITADO", "BEDITADO");
			dgDispositivos.Columns.Add("#", "#");
			dgDispositivos.Columns.Add("INDICE", "INDICE");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGBlocos()
	{
		if (!s2NG53Gg3o)
		{
			return;
		}
		checked
		{
			if (dgDispositivos.Rows.Count != 0)
			{
				double num = dgDispositivos.Width - 21;
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDispositivos))
				{
					num = dgDispositivos.Width - 4;
				}
				num -= 30.0;
				dgDispositivos.Columns[0].Width = (int)Math.Round(num * 0.4);
				dgDispositivos.Columns[0].Visible = true;
				dgDispositivos.Columns[1].Width = 30;
				dgDispositivos.Columns[1].Visible = true;
				dgDispositivos.Columns[2].Width = (int)Math.Round(num * 0.6);
				dgDispositivos.Columns[2].Visible = true;
				dgDispositivos.Columns[3].Width = 0;
				dgDispositivos.Columns[3].Visible = false;
				dgDispositivos.Columns[4].Width = 0;
				dgDispositivos.Columns[4].Visible = false;
				dgDispositivos.Columns[5].Width = 0;
				dgDispositivos.Columns[5].Visible = false;
				dgDispositivos.Columns[6].Width = 0;
				dgDispositivos.Columns[6].Visible = false;
				dgDispositivos.Columns[7].Width = 0;
				dgDispositivos.Columns[7].Visible = false;
				dgDispositivos.Columns[8].Width = 0;
				dgDispositivos.Columns[8].Visible = false;
				dgDispositivos.Columns[9].Width = 0;
				dgDispositivos.Columns[9].Visible = false;
				dgDispositivos.Columns[10].Width = 0;
				dgDispositivos.Columns[10].Visible = false;
				dgDispositivos.MultiSelect = true;
			}
			else
			{
				dgDispositivos.Rows.Clear();
				dgDispositivos.Columns.Clear();
			}
		}
	}

	private void hxkGwDTTcZ(object P_0, KeyEventArgs P_1)
	{
		if (s2NG53Gg3o)
		{
			CarregaDispPaineis(eenGRnq8Lg);
		}
	}

	private void ofHGxIYFOh(object P_0, MouseEventArgs P_1)
	{
		if (s2NG53Gg3o)
		{
			CarregaDispPaineis(eenGRnq8Lg);
		}
	}

	public void CarregaDispPaineis(int iLM)
	{
		formataDGBlocos();
		bool flag = false;
		int num = Information.UBound(DIZGleUcgg);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if ((iLM == -1) | (iLM == DIZGleUcgg[i].iLM))
			{
				string sNome = DIZGleUcgg[i].sNome2;
				sNome = ((Operators.CompareString(clsTextos.TiraNothing(sNome), "", TextCompare: true) == 0) ? DIZGleUcgg[i].sNome1 : (DIZGleUcgg[i].sNome1 + "/" + DIZGleUcgg[i].sNome2));
				string text = "P";
				if (DIZGleUcgg[i].bComplementar)
				{
					text = "C";
				}
				string sTerminais = DIZGleUcgg[i].sTerminais;
				sTerminais = sTerminais.Replace(" ", "");
				dgDispositivos.Rows.Add(sNome, text, sTerminais, DIZGleUcgg[i].iPainel, DIZGleUcgg[i].sNome1, DIZGleUcgg[i].sNome2, DIZGleUcgg[i].sAlternativo, DIZGleUcgg[i].sHandle, flag, DIZGleUcgg[i].iQuantTerminais);
			}
		}
		DataGridView withEventsValue = dgDispositivos;
		DiCGOFYYbF(ref withEventsValue);
		dgDispositivos = withEventsValue;
		AtualizaDGBlocos();
		withEventsValue = dgDispositivos;
		ARoGIbnGUu(ref withEventsValue);
		dgDispositivos = withEventsValue;
	}

	private void S4aGbmC5vB(object P_0, EventArgs P_1)
	{
		clsDispositivo.mBlocosPrincipal[] array = new clsDispositivo.mBlocosPrincipal[1];
		checked
		{
			int num = dgDispositivos.RowCount - 1;
			int num3 = default;
			for (int i = 0; i <= num; i++)
			{
				if (!Operators.ConditionalCompareObjectEqual(dgDispositivos.Rows[i].Cells[8].Value, true, TextCompare: true))
				{
					continue;
				}
				int num2 = Information.UBound(DIZGleUcgg);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDispositivos.Rows[i].Cells[7].Value, DIZGleUcgg[j].sHandle, TextCompare: true))
					{
						num3++;
						array = (clsDispositivo.mBlocosPrincipal[])Utils.CopyArray(array, new clsDispositivo.mBlocosPrincipal[num3 + 1]);
						array[num3] = DIZGleUcgg[j];
						array[num3].sTerminais = Conversions.ToString(dgDispositivos.Rows[i].Cells[2].Value);
						break;
					}
				}
			}
			if (num3 > 0)
			{
				clsDispositivo.EditaTerminaisDispositivoSemModelo(array);
				int num4 = dgDispositivos.RowCount - 1;
				for (int k = 0; k <= num4; k++)
				{
					dgDispositivos.Rows[k].Cells[8].Value = false;
				}
				btEdita.Enabled = false;
			}
		}
	}

	private static void XblGMvhbMi(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = P_0.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = P_0.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					if (Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[1].Value, P_0.Rows[j + 1].Cells[1].Value, TextCompare: true))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num3].Value);
							P_0.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num3].Value);
							P_0.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 1);
					}
				}
			}
		}
	}

	private static void DiCGOFYYbF(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = P_0.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = P_0.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					if (Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[4].Value, P_0.Rows[j + 1].Cells[4].Value, TextCompare: true))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num3].Value);
							P_0.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num3].Value);
							P_0.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 10);
					}
					if (Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[4].Value, P_0.Rows[j + 1].Cells[4].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[5].Value, P_0.Rows[j + 1].Cells[5].Value, TextCompare: true))
					{
						int num4 = 0;
						do
						{
							object objectValue2 = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num4].Value);
							P_0.Rows[j].Cells[num4].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num4].Value);
							P_0.Rows[j + 1].Cells[num4].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							num4++;
						}
						while (num4 <= 10);
					}
					if (Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[4].Value, P_0.Rows[j + 1].Cells[4].Value, TextCompare: true) && Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[5].Value, P_0.Rows[j + 1].Cells[5].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(P_0.Rows[j].Cells[6].Value, P_0.Rows[j + 1].Cells[6].Value, TextCompare: true))
					{
						int num5 = 0;
						do
						{
							object objectValue3 = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num5].Value);
							P_0.Rows[j].Cells[num5].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num5].Value);
							P_0.Rows[j + 1].Cells[num5].Value = RuntimeHelpers.GetObjectValue(objectValue3);
							num5++;
						}
						while (num5 <= 10);
					}
					if (Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[4].Value, P_0.Rows[j + 1].Cells[4].Value, TextCompare: true) && Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[5].Value, P_0.Rows[j + 1].Cells[5].Value, TextCompare: true) && Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[6].Value, P_0.Rows[j + 1].Cells[6].Value, TextCompare: true) && Operators.ConditionalCompareObjectLess(P_0.Rows[j].Cells[1].Value, P_0.Rows[j + 1].Cells[1].Value, TextCompare: true))
					{
						int num6 = 0;
						do
						{
							object objectValue4 = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num6].Value);
							P_0.Rows[j].Cells[num6].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num6].Value);
							P_0.Rows[j + 1].Cells[num6].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							num6++;
						}
						while (num6 <= 10);
					}
				}
				P_0.Rows[i].Cells[10].Value = "";
			}
		}
	}

	private static void ARoGIbnGUu(ref DataGridView P_0)
	{
		string left = "";
		int num = 0;
		int num2 = 0;
		checked
		{
			int num3 = P_0.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				P_0.Rows[i].Cells[10].Value = "";
			}
			int num4 = P_0.Rows.Count - 1;
			for (int j = 0; j <= num4; j++)
			{
				if (num == 0)
				{
					num = Conversions.ToInteger(P_0.Rows[j].Cells[3].Value);
				}
				if (Operators.CompareString(left, "", TextCompare: true) == 0)
				{
					left = Conversions.ToString(P_0.Rows[j].Cells[0].Value);
				}
				if (!Operators.ConditionalCompareObjectNotEqual(left, P_0.Rows[j].Cells[0].Value, TextCompare: true))
				{
					if (Operators.ConditionalCompareObjectNotEqual(num, P_0.Rows[j].Cells[3].Value, TextCompare: true))
					{
						left = Conversions.ToString(P_0.Rows[j].Cells[0].Value);
						num2 = 0;
						num = Conversions.ToInteger(P_0.Rows[j].Cells[3].Value);
					}
					int num5 = Conversions.ToInteger(P_0.Rows[j].Cells[9].Value) - 1;
					for (int k = 0; k <= num5; k++)
					{
						if (!Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[10].Value, "", TextCompare: true))
						{
							DataGridViewCell dataGridViewCell;
							(dataGridViewCell = P_0.Rows[j].Cells[10]).Value = Operators.AddObject(dataGridViewCell.Value, ";" + num2);
						}
						else
						{
							P_0.Rows[j].Cells[10].Value = num2.ToString();
						}
						num2++;
					}
					continue;
				}
				left = Conversions.ToString(P_0.Rows[j].Cells[0].Value);
				num2 = 0;
				num = Conversions.ToInteger(P_0.Rows[j].Cells[3].Value);
				int num6 = Conversions.ToInteger(P_0.Rows[j].Cells[9].Value) - 1;
				for (int l = 0; l <= num6; l++)
				{
					if (!Operators.ConditionalCompareObjectEqual(P_0.Rows[j].Cells[10].Value, "", TextCompare: true))
					{
						DataGridViewCell dataGridViewCell;
						(dataGridViewCell = P_0.Rows[j].Cells[10]).Value = Operators.AddObject(dataGridViewCell.Value, ";" + num2);
					}
					else
					{
						P_0.Rows[j].Cells[10].Value = num2.ToString();
					}
					num2++;
				}
			}
		}
	}

	private void OEUG7Tal0a(object P_0, KeyEventArgs P_1)
	{
		SelecionaCOmplementares();
	}

	private void QZOGqnifyu(object P_0, MouseEventArgs P_1)
	{
		SelecionaCOmplementares();
	}

	public void SelecionaCOmplementares()
	{
		dGYGmInWni = true;
		tbTerminais.Text = "";
		string left = "";
		int num = 0;
		checked
		{
			int num2 = dgDispositivos.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (!dgDispositivos.Rows[i].Selected)
				{
					continue;
				}
				int num3 = dgDispositivos.Rows.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dgDispositivos.Rows[i].Cells[3].Value, dgDispositivos.Rows[j].Cells[3].Value, TextCompare: true), Operators.CompareObjectEqual(dgDispositivos.Rows[i].Cells[4].Value, dgDispositivos.Rows[j].Cells[4].Value, TextCompare: true)), Operators.CompareObjectEqual(dgDispositivos.Rows[i].Cells[5].Value, dgDispositivos.Rows[j].Cells[5].Value, TextCompare: true)), Operators.CompareObjectEqual(dgDispositivos.Rows[i].Cells[6].Value, dgDispositivos.Rows[j].Cells[6].Value, TextCompare: true))))
					{
						dgDispositivos.Rows[j].Selected = true;
						if (Operators.CompareString(left, "", TextCompare: true) == 0)
						{
							left = Conversions.ToString(dgDispositivos.Rows[i].Cells[0].Value);
							num = Conversions.ToInteger(dgDispositivos.Rows[i].Cells[3].Value);
						}
					}
				}
			}
			string text = "";
			int num4 = dgDispositivos.Rows.Count - 1;
			for (int k = 0; k <= num4; k++)
			{
				if (dgDispositivos.Rows[k].Selected && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(left, dgDispositivos.Rows[k].Cells[0].Value, TextCompare: true), Operators.CompareObjectEqual(num, dgDispositivos.Rows[k].Cells[3].Value, TextCompare: true))))
				{
					text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(text, dgDispositivos.Rows[k].Cells[2].Value), ";"));
				}
			}
			text = text.Replace(" ", "");
			tbTerminais.Text = text;
			dGYGmInWni = false;
		}
	}

	private void JWxGaMtj3q(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (dgDispositivos.Columns.Count != 0)
		{
			string sHandle = Conversions.ToString(dgDispositivos.SelectedRows[0].Cells[7].Value);
			Correcao.mostraBloco(sHandle);
		}
	}

	private void Lf8G819XdW(object P_0, EventArgs P_1)
	{
		if (dGYGmInWni)
		{
			return;
		}
		string text = tbTerminais.Text;
		text = text.Replace(" ", "");
		string[] array = text.Split(';');
		checked
		{
			int num = dgDispositivos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!dgDispositivos.Rows[i].Selected || !Operators.ConditionalCompareObjectNotEqual(dgDispositivos.Rows[i].Cells[10].Value, "", TextCompare: true))
				{
					continue;
				}
				string[] array2 = (string[])NewLateBinding.LateGet(dgDispositivos.Rows[i].Cells[10].Value, null, "Split", new object[1] { ";" }, null, null, null);
				dgDispositivos.Rows[i].Cells[2].Value = "";
				int num2 = Information.UBound(array2);
				for (int j = 0; j <= num2; j++)
				{
					if (!Operators.ConditionalCompareObjectEqual(dgDispositivos.Rows[i].Cells[2].Value, "", TextCompare: true))
					{
						if (Versioned.IsNumeric(array2[j]) && Versioned.IsNumeric(array2[j]) && (double)Information.UBound(array) >= Conversions.ToDouble(array2[j]))
						{
							DataGridViewCell dataGridViewCell;
							(dataGridViewCell = dgDispositivos.Rows[i].Cells[2]).Value = Operators.AddObject(dataGridViewCell.Value, ";" + array[Conversions.ToInteger(array2[j])].ToString());
							dgDispositivos.Rows[i].Cells[8].Value = true;
							btEdita.Enabled = true;
						}
					}
					else if (Versioned.IsNumeric(array2[j]) && (double)Information.UBound(array) >= Conversions.ToDouble(array2[j]))
					{
						dgDispositivos.Rows[i].Cells[2].Value = array[Conversions.ToInteger(array2[j])].ToString();
						dgDispositivos.Rows[i].Cells[8].Value = true;
						btEdita.Enabled = true;
					}
				}
			}
		}
	}

	private void QpCGNPxRis(object P_0, KeyEventArgs P_1)
	{
		ffUGQOi7e2();
	}

	private void G4yGFuuNdh(object P_0, EventArgs P_1)
	{
		ffUGQOi7e2();
	}

	private void ffUGQOi7e2()
	{
		if (Operators.CompareString(CBLM1.Text.Trim(), "", TextCompare: true) == 0)
		{
			eenGRnq8Lg = -1;
		}
		string text = "";
		text = CBLM1.Text;
		int num = -1;
		string text2 = "";
		int num2 = Strings.Len(text);
		checked
		{
			for (int i = 1; i <= num2 && Versioned.IsNumeric(Strings.Mid(text, i, 1)); i++)
			{
				text2 += Strings.Mid(text, i, 1);
				num = Conversions.ToInteger(text2);
			}
			if ((num != eenGRnq8Lg) | (eenGRnq8Lg == -1))
			{
				eenGRnq8Lg = num;
				CarregaDispPaineis(eenGRnq8Lg);
			}
			int num3 = dgDispositivos.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgDispositivos.Rows[j].Selected = false;
			}
			dGYGmInWni = true;
			tbTerminais.Text = "";
			dGYGmInWni = false;
		}
	}

	private void PeaGPmiPnC(object P_0, EventArgs P_1)
	{
		if (s2NG53Gg3o)
		{
			AtualizaDGBlocos();
		}
	}
}
