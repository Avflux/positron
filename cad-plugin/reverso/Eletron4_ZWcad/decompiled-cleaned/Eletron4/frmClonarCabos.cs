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
using ZwSoft.ZwCAD.ApplicationServices.Core;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmClonarCabos : Form
{
	private IContainer HiVXU3bcAu;

	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog ePQXyRm8lV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip Ex8XglfyrW;

	[AccessedThroughProperty("dgCabos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView MGuXAKkjHq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTrocar")]
	[CompilerGenerated]
	private Label Sb6XsgvwHW;

	[AccessedThroughProperty("tbDE")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox NyrXB9Hff4;

	[AccessedThroughProperty("lbPara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label MnFXVF0Xll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPara")]
	private TextBox gPvXuNV9f2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEditaNome")]
	[CompilerGenerated]
	private Button M2eXEUN2KL;

	[CompilerGenerated]
	[AccessedThroughProperty("BtIndefineVeias")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button TILXZuA0TF;

	private List<string> q1jXioMbtp;

	private structureCadernoMigra[] J89XSKOy0L;

	internal virtual DataGridView dgCabos
	{
		[CompilerGenerated]
		get
		{
			return MGuXAKkjHq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MGuXAKkjHq = value;
		}
	}

	internal virtual Label lbTrocar
	{
		[CompilerGenerated]
		get
		{
			return Sb6XsgvwHW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Sb6XsgvwHW = value;
		}
	}

	internal virtual TextBox tbDE
	{
		[CompilerGenerated]
		get
		{
			return NyrXB9Hff4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = NYFXmUMGMG;
			TextBox textBox = NyrXB9Hff4;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			NyrXB9Hff4 = value;
			textBox = NyrXB9Hff4;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbPara
	{
		[CompilerGenerated]
		get
		{
			return MnFXVF0Xll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MnFXVF0Xll = value;
		}
	}

	internal virtual TextBox tbPara
	{
		[CompilerGenerated]
		get
		{
			return gPvXuNV9f2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = OihXRZnN3P;
			TextBox textBox = gPvXuNV9f2;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			gPvXuNV9f2 = value;
			textBox = gPvXuNV9f2;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btEditaNome
	{
		[CompilerGenerated]
		get
		{
			return M2eXEUN2KL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QTCX00NHL6;
			Button button = M2eXEUN2KL;
			if (button != null)
			{
				button.Click -= value2;
			}
			M2eXEUN2KL = value;
			button = M2eXEUN2KL;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BtIndefineVeias
	{
		[CompilerGenerated]
		get
		{
			return TILXZuA0TF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tFEXXFkUFv;
			Button button = TILXZuA0TF;
			if (button != null)
			{
				button.Click -= value2;
			}
			TILXZuA0TF = value;
			button = TILXZuA0TF;
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
			if (disposing && HiVXU3bcAu != null)
			{
				HiVXU3bcAu.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void uhKXlFLAxY()
	{
		HiVXU3bcAu = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(HiVXU3bcAu));
		dgCabos = new DataGridView();
		lbTrocar = new Label();
		tbDE = new TextBox();
		lbPara = new Label();
		tbPara = new TextBox();
		btEditaNome = new Button();
		BtIndefineVeias = new Button();
		((ISupportInitialize)dgCabos).BeginInit();
		SuspendLayout();
		dgCabos.AllowUserToAddRows = false;
		dgCabos.AllowUserToDeleteRows = false;
		dgCabos.AllowUserToOrderColumns = true;
		dgCabos.AllowUserToResizeRows = false;
		dgCabos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
		dgCabos.Location = new Point(8, 12);
		dgCabos.MultiSelect = false;
		dgCabos.Name = "dgCabos";
		dgCabos.ReadOnly = true;
		dgCabos.RowHeadersVisible = false;
		dgCabos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgCabos.Size = new Size(317, 405);
		dgCabos.TabIndex = 9;
		lbTrocar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbTrocar.BorderStyle = BorderStyle.Fixed3D;
		lbTrocar.Location = new Point(8, 424);
		lbTrocar.Name = "lbTrocar";
		lbTrocar.Size = new Size(101, 20);
		lbTrocar.TabIndex = 167;
		lbTrocar.Text = "lbTrocar";
		lbTrocar.TextAlign = ContentAlignment.MiddleCenter;
		tbDE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbDE.Location = new Point(8, 447);
		tbDE.Name = "tbDE";
		tbDE.Size = new Size(101, 20);
		tbDE.TabIndex = 166;
		tbDE.TextAlign = HorizontalAlignment.Center;
		lbPara.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbPara.BorderStyle = BorderStyle.Fixed3D;
		lbPara.Location = new Point(119, 424);
		lbPara.Name = "lbPara";
		lbPara.Size = new Size(101, 20);
		lbPara.TabIndex = 169;
		lbPara.Text = "lbPara";
		lbPara.TextAlign = ContentAlignment.MiddleCenter;
		tbPara.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbPara.Location = new Point(119, 447);
		tbPara.Name = "tbPara";
		tbPara.Size = new Size(101, 20);
		tbPara.TabIndex = 168;
		tbPara.TextAlign = HorizontalAlignment.Center;
		btEditaNome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btEditaNome.FlatStyle = FlatStyle.Flat;
		btEditaNome.ForeColor = SystemColors.Control;
		btEditaNome.Image = Resources.Editar;
		btEditaNome.Location = new Point(282, 422);
		btEditaNome.Name = "btEditaNome";
		btEditaNome.Size = new Size(40, 40);
		btEditaNome.TabIndex = 174;
		btEditaNome.UseVisualStyleBackColor = true;
		BtIndefineVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BtIndefineVeias.FlatStyle = FlatStyle.Flat;
		BtIndefineVeias.ForeColor = SystemColors.Control;
		BtIndefineVeias.Image = Resources.Indefinir_32;
		BtIndefineVeias.Location = new Point(236, 422);
		BtIndefineVeias.Name = "BtIndefineVeias";
		BtIndefineVeias.Size = new Size(40, 40);
		BtIndefineVeias.TabIndex = 175;
		BtIndefineVeias.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(334, 474);
		Controls.Add(BtIndefineVeias);
		Controls.Add(btEditaNome);
		Controls.Add(lbPara);
		Controls.Add(tbPara);
		Controls.Add(lbTrocar);
		Controls.Add(tbDE);
		Controls.Add(dgCabos);
		MaximumSize = new Size(350, 1440);
		MinimumSize = new Size(350, 440);
		Name = "frmClonarCabos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frm Clonar Cabos";
		((ISupportInitialize)dgCabos).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return ePQXyRm8lV;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		ePQXyRm8lV = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return Ex8XglfyrW;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		Ex8XglfyrW = WithEventsValue;
	}

	public frmClonarCabos()
	{
		Resize += VabX5x5heX;
		q1jXioMbtp = new List<string>();
		if (Geral.ExisteForm("frmClonarCabos") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			uhKXlFLAxY();
			DeclaracoesGeral._uscPagina.Quantidade = 5;
			DeclaracoesGeral._uscPagina.pbIniciar();
			J89XSKOy0L = new structureCadernoMigra[1];
			DeclaracoesGeral._uscPagina.pbPasso();
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			cDadosAccessInterligacao3.LeCabosTodosOsCabos(ref q1jXioMbtp);
			DeclaracoesGeral._uscPagina.pbPasso();
			cDadosAccessInterligacao3.FechaConexao();
			clsEditarInterligacao.PesquisaCabosFaltantes(ref J89XSKOy0L);
			DeclaracoesGeral._uscPagina.pbPasso();
			if (Information.UBound(J89XSKOy0L) != 0)
			{
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 577]);
				lbTrocar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]);
				lbPara.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]);
				w8dpBZ0kvSD().SetToolTip(BtIndefineVeias, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1380]));
				w8dpBZ0kvSD().SetToolTip(btEditaNome, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1381]));
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				DataGridView dg = dgCabos;
				CarregaTodasCabosDoCadernoNoDG(ref dg, J89XSKOy0L, "", "");
				dgCabos = dg;
				DeclaracoesGeral._uscPagina.pbPasso();
				pesquisatroca();
				DeclaracoesGeral._uscPagina.pbFim();
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1289]), MsgBoxStyle.Information);
				DeclaracoesGeral._uscPagina.pbFim();
				Close();
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	public void CarregaTodasCabosDoCadernoNoDG(ref DataGridView dg, structureCadernoMigra[] VeiasCaderno, string sNome, string sFormacao)
	{
		formataDGCabos();
		int num = Information.UBound(VeiasCaderno);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				dg.Rows.Add(VeiasCaderno[i].sTag0, "", "", VeiasCaderno[i].iPn1, VeiasCaderno[i].iPn2);
			}
			AtualizaDGCabos();
			int count = dgCabos.Rows.Count;
			for (int j = 0; j <= count; j++)
			{
				dgCabos.Rows[0].Selected = false;
			}
		}
	}

	public void formataDGCabos()
	{
		try
		{
			dgCabos.Rows.Clear();
			dgCabos.Columns.Clear();
			dgCabos.Columns.Add("Cabo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]));
			dgCabos.Columns.Add("Cabo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]));
			dgCabos.Columns.Add("OK", "OK");
			dgCabos.Columns.Add("PN1", "PN1");
			dgCabos.Columns.Add("PN2", "PN2");
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
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(num * 0.5);
				dgCabos.Columns[0].Visible = true;
				dgCabos.Columns[1].Width = (int)Math.Round(num * 0.5);
				dgCabos.Columns[1].Visible = true;
				dgCabos.Columns[2].Width = 30;
				dgCabos.Columns[2].Visible = false;
				dgCabos.Columns[3].Width = 30;
				dgCabos.Columns[3].Visible = false;
				dgCabos.Columns[4].Width = 30;
				dgCabos.Columns[4].Visible = false;
				dgCabos.MultiSelect = true;
			}
		}
	}

	private void VabX5x5heX(object P_0, EventArgs P_1)
	{
		AtualizaDGCabos();
	}

	private void QTCX00NHL6(object P_0, EventArgs P_1)
	{
		CDadosAccessInterligacao CDadosAccessInterligacao = new CDadosAccessInterligacao();
		checked
		{
			int num = dgCabos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!Operators.ConditionalCompareObjectEqual(dgCabos.Rows[i].Cells[2].Value, "OK", TextCompare: true))
				{
					continue;
				}
				string text = Conversions.ToString(dgCabos.Rows[i].Cells[0].Value);
				string text2 = Conversions.ToString(dgCabos.Rows[i].Cells[1].Value);
				ClsCabos.StructureCabo Cabo = default;
				ClsCabos.StructureVeia[] Veias = null;
				CDadosAccessInterligacao.LeDadosDeUmCabo(text, ref Cabo);
				Cabo.sTag = text2;
				Cabo.sTagAntigo = text;
				Cabo.iPn1 = Conversions.ToInteger(dgCabos.Rows[i].Cells[3].Value);
				Cabo.iPn2 = Conversions.ToInteger(dgCabos.Rows[i].Cells[4].Value);
				if (CDadosAccessInterligacao.LancaUmCaboNoBanco(Cabo))
				{
					CDadosAccessInterligacao.leDadosDaVeia(text, ref Veias);
					int num2 = Information.UBound(Veias);
					for (int j = 1; j <= num2; j++)
					{
						CDadosAccessInterligacao.AddParteDeUmaVeia(text2, Veias[j].iIndice, Veias[j].sNome, Veias[j].sFuncao);
					}
				}
			}
			DataGridView dg = dgCabos;
			clsEditarInterligacao.EditaNomeDoCaboNoDesenho(ref dg);
			dgCabos = dg;
			J89XSKOy0L = new structureCadernoMigra[1];
			if (dgCabos.Rows.Count >= 0)
			{
				int num3 = dgCabos.Rows.Count - 1;
				for (int k = num3; k >= 0; k += -1)
				{
					if (Operators.ConditionalCompareObjectEqual(dgCabos.Rows[k].Cells[2].Value, "OK", TextCompare: true))
					{
						dgCabos.Rows.RemoveAt(k);
					}
				}
			}
			if (dgCabos.Rows.Count == 0)
			{
				clsEditarInterligacao.SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao);
				clsEditarInterligacao.AtualizaNomesDosCabos();
				clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
			}
			CDadosAccessInterligacao.FechaConexao();
			if (dgCabos.Rows.Count == 0)
			{
				clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
			}
		}
	}

	private void OihXRZnN3P(object P_0, KeyEventArgs P_1)
	{
		pesquisatroca();
	}

	private void NYFXmUMGMG(object P_0, KeyEventArgs P_1)
	{
		pesquisatroca();
	}

	public void pesquisatroca()
	{
		int num = 0;
		int num2 = 0;
		tbDE.Text = tbDE.Text.Replace(" ", "");
		tbPara.Text = tbPara.Text.Replace(" ", "");
		string text = tbDE.Text;
		string text2 = tbPara.Text;
		checked
		{
			int num3 = dgCabos.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				dgCabos.Rows[i].Cells[1].Value = "";
			}
			if (!((Operators.CompareString(text, "", TextCompare: true) != 0) & (Operators.CompareString(text2, "", TextCompare: true) != 0)))
			{
				int num4 = dgCabos.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgCabos.Rows[j].Cells[1].Value, "", TextCompare: true))
					{
						int num5 = 0;
						do
						{
							dgCabos.Rows[j].Cells[num5].Style.BackColor = Color.White;
							dgCabos.Rows[j].Cells[num5].Style.ForeColor = Color.Black;
							dgCabos[1, j].ErrorText = "";
							num5++;
						}
						while (num5 <= 1);
						dgCabos.Rows[j].Cells[2].Value = "";
					}
				}
			}
			else
			{
				int num6 = dgCabos.Rows.Count - 1;
				for (int k = 0; k <= num6; k++)
				{
					string text3 = Conversions.ToString(dgCabos.Rows[k].Cells[0].Value);
					string text4 = "";
					text4 = text3.Replace(text, text2);
					if (Operators.CompareString(text3.ToUpper(), text4.ToUpper(), TextCompare: true) == 0)
					{
						dgCabos.Rows[k].Cells[1].Value = "";
					}
					else
					{
						dgCabos.Rows[k].Cells[1].Value = text4;
					}
				}
				if (dgCabos.Rows.Count >= 2)
				{
					int num7 = dgCabos.Rows.Count - 2;
					for (int l = num7; l >= 0; l += -1)
					{
						int num8 = l;
						for (int m = 0; m <= num8; m++)
						{
							if (Operators.ConditionalCompareObjectEqual(dgCabos[1, m].Value, "", TextCompare: true))
							{
								int num9 = 0;
								do
								{
									object objectValue = RuntimeHelpers.GetObjectValue(dgCabos[num9, m + 1].Value);
									dgCabos[num9, m + 1].Value = RuntimeHelpers.GetObjectValue(dgCabos[num9, m].Value);
									dgCabos[num9, m].Value = RuntimeHelpers.GetObjectValue(objectValue);
									num9++;
								}
								while (num9 <= 4);
							}
						}
					}
				}
				int num10 = dgCabos.Rows.Count - 1;
				for (int n = 0; n <= num10; n++)
				{
					if (!Operators.ConditionalCompareObjectEqual(dgCabos.Rows[n].Cells[1].Value, "", TextCompare: true))
					{
						if (!q1jXioMbtp.Contains(Conversions.ToString(dgCabos.Rows[n].Cells[1].Value)))
						{
							int num11 = 0;
							do
							{
								dgCabos.Rows[n].Cells[num11].Style.BackColor = Color.LightGreen;
								dgCabos.Rows[n].Cells[num11].Style.ForeColor = Color.Black;
								dgCabos[1, n].ErrorText = "";
								num11++;
							}
							while (num11 <= 1);
							dgCabos.Rows[n].Cells[2].Value = "OK";
							num++;
						}
						else
						{
							int num12 = 0;
							do
							{
								dgCabos.Rows[n].Cells[num12].Style.BackColor = Color.LightCoral;
								dgCabos.Rows[n].Cells[num12].Style.ForeColor = Color.White;
								dgCabos[1, n].ErrorText = Conversions.ToString(Operators.ConcatenateObject("   ", DeclaracoesGeral.mMensagem[1, 1258]));
								num12++;
							}
							while (num12 <= 1);
							dgCabos.Rows[n].Cells[2].Value = "";
							num2++;
						}
					}
					else
					{
						int num13 = 0;
						do
						{
							dgCabos.Rows[n].Cells[num13].Style.BackColor = Color.White;
							dgCabos.Rows[n].Cells[num13].Style.ForeColor = Color.Black;
							dgCabos[1, n].ErrorText = "";
							num13++;
						}
						while (num13 <= 1);
						dgCabos.Rows[n].Cells[2].Value = "";
					}
				}
			}
			int num14 = dgCabos.Rows.Count - 1;
			for (int num15 = num14; num15 >= 0; num15 += -1)
			{
				dgCabos.Rows[0].Selected = false;
				if (Operators.ConditionalCompareObjectEqual(dgCabos.Rows[num15].Cells[2].Value, "OK", TextCompare: true))
				{
					dgCabos.FirstDisplayedScrollingRowIndex = num15;
				}
			}
		}
	}

	private void tFEXXFkUFv(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		list.Clear();
		checked
		{
			int num = dgCabos.Rows.Count - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (dgCabos.Rows[i].Selected)
				{
					list.Add(Conversions.ToString(dgCabos.Rows[i].Cells[0].Value));
				}
			}
			if (list.Count > 0)
			{
				MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1290]), MsgBoxStyle.YesNo, "Elétron");
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					clsInterligacao.IndefineUmCabo(list);
					int num2 = dgCabos.Rows.Count - 1;
					for (int j = num2; j >= 0; j += -1)
					{
						if (dgCabos.Rows[j].Selected)
						{
							dgCabos.Rows.RemoveAt(j);
						}
					}
				}
			}
			if (dgCabos.Rows.Count == 0)
			{
				CDadosAccessInterligacao CDadosAccessInterligacao = new CDadosAccessInterligacao();
				clsEditarInterligacao.SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao);
				CDadosAccessInterligacao.FechaConexao();
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
			}
		}
	}

	~frmClonarCabos()
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		mdiActiveDocument.SendStringToExecute("_.AtualizaOpcionaisDoCabo \n", true, false, true);
		base.Finalize();
	}
}
