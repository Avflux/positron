using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmEditarNomesFuncoesVeias : Form
{
	public struct structureVeiasEditadas
	{
		public string sTag;

		public int iIndice;

		public string sNomeVeia;

		public string sFuncaoVeia;

		public string sHandleTag1;

		public string sHandleCabo1;

		public string sHandleTag2;

		public string sHandleCabo2;
	}

	private IContainer tqqHcWGUXT;

	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog XAiHKfJEIg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip bjuHeRvESt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgCabos")]
	private DataGridView AOBH2lIfTS;

	[AccessedThroughProperty("dgVeias")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView BcgH31rdKm;

	[CompilerGenerated]
	[AccessedThroughProperty("tbCabos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox v1hHnjkm7R;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFormacao")]
	private TextBox gNTH1FHVje;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCaderno")]
	private RadioButton BkqHl54INo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbNaoUsados")]
	private RadioButton SKnH52gCl4;

	[AccessedThroughProperty("lbCabos")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label UvAH0lKra2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbFormacao")]
	private Label TivHRL4Ghp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportar")]
	private Button WrAHmv8iTW;

	[AccessedThroughProperty("btImportar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button VHHHXcTQgS;

	private structureVeiasCaderno[] z0sHUZYifH;

	private structureVeiasCaderno[] psiHyZlsf3;

	private structureVeiasEditadas[] CstHgrlyVl;

	private clsTextos.structureTextoCaderno[] c1sHAl4tFB;

	internal virtual DataGridView dgCabos
	{
		[CompilerGenerated]
		get
		{
			return AOBH2lIfTS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = roCHI1SdrF;
			MouseEventHandler value3 = PhKH76ZFwG;
			DataGridView dataGridView = AOBH2lIfTS;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			AOBH2lIfTS = value;
			dataGridView = AOBH2lIfTS;
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
			return BcgH31rdKm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BcgH31rdKm = value;
		}
	}

	internal virtual TextBox tbCabos
	{
		[CompilerGenerated]
		get
		{
			return v1hHnjkm7R;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = ujkHMpNiRn;
			TextBox textBox = v1hHnjkm7R;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			v1hHnjkm7R = value;
			textBox = v1hHnjkm7R;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbFormacao
	{
		[CompilerGenerated]
		get
		{
			return gNTH1FHVje;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = T7CHOAsYxK;
			TextBox textBox = gNTH1FHVje;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			gNTH1FHVje = value;
			textBox = gNTH1FHVje;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual RadioButton rbCaderno
	{
		[CompilerGenerated]
		get
		{
			return BkqHl54INo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jWTH8kRDrx;
			RadioButton radioButton = BkqHl54INo;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			BkqHl54INo = value;
			radioButton = BkqHl54INo;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbNaoUsados
	{
		[CompilerGenerated]
		get
		{
			return SKnH52gCl4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = r7OHN0qYyQ;
			RadioButton radioButton = SKnH52gCl4;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			SKnH52gCl4 = value;
			radioButton = SKnH52gCl4;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label lbCabos
	{
		[CompilerGenerated]
		get
		{
			return UvAH0lKra2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UvAH0lKra2 = value;
		}
	}

	internal virtual Label lbFormacao
	{
		[CompilerGenerated]
		get
		{
			return TivHRL4Ghp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TivHRL4Ghp = value;
		}
	}

	internal virtual Button btExportar
	{
		[CompilerGenerated]
		get
		{
			return WrAHmv8iTW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = h6YHQZsSjw;
			Button button = WrAHmv8iTW;
			if (button != null)
			{
				button.Click -= value2;
			}
			WrAHmv8iTW = value;
			button = WrAHmv8iTW;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btImportar
	{
		[CompilerGenerated]
		get
		{
			return VHHHXcTQgS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ekpHPIwhYV;
			Button button = VHHHXcTQgS;
			if (button != null)
			{
				button.Click -= value2;
			}
			VHHHXcTQgS = value;
			button = VHHHXcTQgS;
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
			if (disposing && tqqHcWGUXT != null)
			{
				tqqHcWGUXT.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void bC7HbRSicr()
	{
		tqqHcWGUXT = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(tqqHcWGUXT));
		dgCabos = new DataGridView();
		dgVeias = new DataGridView();
		tbCabos = new TextBox();
		tbFormacao = new TextBox();
		rbCaderno = new RadioButton();
		rbNaoUsados = new RadioButton();
		lbCabos = new Label();
		lbFormacao = new Label();
		btExportar = new Button();
		btImportar = new Button();
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
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgCabos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgCabos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgCabos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgCabos.Location = new Point(5, 58);
		dgCabos.MultiSelect = false;
		dgCabos.Name = "dgCabos";
		dgCabos.ReadOnly = true;
		dgCabos.RowHeadersVisible = false;
		dgCabos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgCabos.Size = new Size(188, 426);
		dgCabos.TabIndex = 9;
		dgVeias.AllowUserToAddRows = false;
		dgVeias.AllowUserToDeleteRows = false;
		dgVeias.AllowUserToOrderColumns = true;
		dgVeias.AllowUserToResizeRows = false;
		dgVeias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgVeias.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgVeias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgVeias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgVeias.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgVeias.Location = new Point(199, 58);
		dgVeias.MultiSelect = false;
		dgVeias.Name = "dgVeias";
		dgVeias.ReadOnly = true;
		dgVeias.RowHeadersVisible = false;
		dgVeias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgVeias.Size = new Size(217, 375);
		dgVeias.TabIndex = 10;
		tbCabos.CharacterCasing = CharacterCasing.Upper;
		tbCabos.Location = new Point(5, 25);
		tbCabos.Name = "tbCabos";
		tbCabos.Size = new Size(125, 20);
		tbCabos.TabIndex = 166;
		tbCabos.TextAlign = HorizontalAlignment.Center;
		tbFormacao.CharacterCasing = CharacterCasing.Upper;
		tbFormacao.Location = new Point(136, 25);
		tbFormacao.Name = "tbFormacao";
		tbFormacao.Size = new Size(132, 20);
		tbFormacao.TabIndex = 168;
		tbFormacao.TextAlign = HorizontalAlignment.Center;
		rbCaderno.AutoSize = true;
		rbCaderno.Location = new Point(283, 12);
		rbCaderno.Name = "rbCaderno";
		rbCaderno.Size = new Size(74, 17);
		rbCaderno.TabIndex = 170;
		rbCaderno.TabStop = true;
		rbCaderno.Text = "rbCaderno";
		rbCaderno.UseVisualStyleBackColor = true;
		rbNaoUsados.AutoSize = true;
		rbNaoUsados.Location = new Point(283, 30);
		rbNaoUsados.Name = "rbNaoUsados";
		rbNaoUsados.Size = new Size(93, 17);
		rbNaoUsados.TabIndex = 171;
		rbNaoUsados.TabStop = true;
		rbNaoUsados.Text = "tbNão Usados";
		rbNaoUsados.UseVisualStyleBackColor = true;
		lbCabos.AutoSize = true;
		lbCabos.Location = new Point(2, 9);
		lbCabos.Name = "lbCabos";
		lbCabos.Size = new Size(45, 13);
		lbCabos.TabIndex = 180;
		lbCabos.Text = "lbCabos";
		lbFormacao.AutoSize = true;
		lbFormacao.Location = new Point(133, 9);
		lbFormacao.Name = "lbFormacao";
		lbFormacao.Size = new Size(62, 13);
		lbFormacao.TabIndex = 181;
		lbFormacao.Text = "lbFormação";
		btExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportar.FlatStyle = FlatStyle.Flat;
		btExportar.ForeColor = SystemColors.Control;
		btExportar.Image = Resources.ExportaExcel_20;
		btExportar.Location = new Point(264, 439);
		btExportar.Name = "btExportar";
		btExportar.Size = new Size(40, 42);
		btExportar.TabIndex = 190;
		btExportar.UseVisualStyleBackColor = true;
		btImportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.ImportaExcel_20;
		btImportar.Location = new Point(328, 439);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(40, 42);
		btImportar.TabIndex = 189;
		btImportar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(424, 493);
		Controls.Add(btExportar);
		Controls.Add(btImportar);
		Controls.Add(rbNaoUsados);
		Controls.Add(rbCaderno);
		Controls.Add(tbFormacao);
		Controls.Add(tbCabos);
		Controls.Add(dgVeias);
		Controls.Add(dgCabos);
		Controls.Add(lbCabos);
		Controls.Add(lbFormacao);
		MaximumSize = new Size(500, 1000);
		MinimumSize = new Size(440, 440);
		Name = "frmEditarNomesFuncoesVeias";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frm Edita Nome de Veias";
		((ISupportInitialize)dgCabos).EndInit();
		((ISupportInitialize)dgVeias).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return XAiHKfJEIg;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		XAiHKfJEIg = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return bjuHeRvESt;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		bjuHeRvESt = WithEventsValue;
	}

	public frmEditarNomesFuncoesVeias()
	{
		Resize += WqgHaXA2PG;
		if (Geral.ExisteForm("frmEditaFuncaoVeias") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			bC7HbRSicr();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1658]);
			lbCabos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
			lbFormacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]);
			rbCaderno.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1278]);
			rbNaoUsados.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1280]);
			List<string> lCabos = new List<string>();
			z0sHUZYifH = new structureVeiasCaderno[1];
			psiHyZlsf3 = new structureVeiasCaderno[1];
			c1sHAl4tFB = new clsTextos.structureTextoCaderno[1];
			clsInterligacao.buscaTextosdosCabos(ref c1sHAl4tFB);
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			cDadosAccessInterligacao3.LeCabosVeiasUsadasCaderno(ref z0sHUZYifH, ref lCabos, bFormacao: true);
			cDadosAccessInterligacao3.LeCabosVeiasNaoUsadasCaderno(ref psiHyZlsf3, bFormacao: true);
			cDadosAccessInterligacao3.FechaConexao();
			Application.ShowModelessDialog((Form)this);
			rbCaderno.Checked = true;
			DataGridView dg = dgCabos;
			CarregaTodasCabosDoCadernoNoDG(ref dg, z0sHUZYifH, tbCabos.Text, tbFormacao.Text);
			dgCabos = dg;
			if (dgCabos.Rows.Count > 0)
			{
				dgCabos.Rows[0].Selected = false;
			}
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			if (Information.UBound(z0sHUZYifH) == 0)
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

	private void ujkHMpNiRn(object P_0, KeyEventArgs P_1)
	{
		if (!rbCaderno.Checked)
		{
			DataGridView dg = dgCabos;
			CarregaTodasCabosDoCadernoNoDG(ref dg, psiHyZlsf3, tbCabos.Text, tbFormacao.Text);
			dgCabos = dg;
		}
		else
		{
			DataGridView dg = dgCabos;
			CarregaTodasCabosDoCadernoNoDG(ref dg, z0sHUZYifH, tbCabos.Text, tbFormacao.Text);
			dgCabos = dg;
		}
	}

	private void T7CHOAsYxK(object P_0, KeyEventArgs P_1)
	{
		if (!rbCaderno.Checked)
		{
			DataGridView dg = dgCabos;
			CarregaTodasCabosDoCadernoNoDG(ref dg, psiHyZlsf3, tbCabos.Text, tbFormacao.Text);
			dgCabos = dg;
		}
		else
		{
			DataGridView dg = dgCabos;
			CarregaTodasCabosDoCadernoNoDG(ref dg, z0sHUZYifH, tbCabos.Text, tbFormacao.Text);
			dgCabos = dg;
		}
	}

	public void CarregaTodasCabosDoCadernoNoDG(ref DataGridView dg, structureVeiasCaderno[] VeiasCaderno, string sNome, string sFormacao)
	{
		formataDGCabos();
		List<string> list = new List<string>();
		list.Clear();
		int num = Information.UBound(VeiasCaderno);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (!list.Contains(VeiasCaderno[i].sTag))
				{
					list.Add(VeiasCaderno[i].sTag);
					if (LikeOperator.LikeString(VeiasCaderno[i].sTag.ToString().ToUpper(), "*" + sNome.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(VeiasCaderno[i].sFormacao.ToUpper(), "*" + sFormacao.ToUpper() + "*", CompareMethod.Text))
					{
						dg.Rows.Add(VeiasCaderno[i].sTag, VeiasCaderno[i].sFormacao);
					}
				}
			}
			AtualizaDGCabos();
			int num2 = dgCabos.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				dgCabos.Rows[0].Selected = false;
			}
			Xy8HqYWUXD();
		}
	}

	private void roCHI1SdrF(object P_0, KeyEventArgs P_1)
	{
		Xy8HqYWUXD();
	}

	private void PhKH76ZFwG(object P_0, MouseEventArgs P_1)
	{
		Xy8HqYWUXD();
	}

	private void Xy8HqYWUXD()
	{
		formataDGVeias();
		string text = "";
		checked
		{
			int num = dgCabos.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgCabos.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			text = Conversions.ToString(dgCabos.Rows[num2].Cells[0].Value);
			if (!rbCaderno.Checked)
			{
				DataGridView dg = dgVeias;
				CarregaTodasAsVeiasDoCadernoNoDG(ref dg, text, psiHyZlsf3);
				dgVeias = dg;
			}
			else
			{
				DataGridView dg = dgVeias;
				CarregaTodasAsVeiasDoCadernoNoDG(ref dg, text, z0sHUZYifH);
				dgVeias = dg;
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
			dgCabos.Columns.Add("Formacao", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
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
				dgCabos.MultiSelect = false;
			}
		}
	}

	public void CarregaTodasAsVeiasDoCadernoNoDG(ref DataGridView dg, string sCabo, structureVeiasCaderno[] VeiasCaderno)
	{
		formataDGVeias();
		int num = Information.UBound(VeiasCaderno);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(VeiasCaderno[i].sTag, sCabo, TextCompare: true) != 0)
			{
				continue;
			}
			string text = Conversions.ToString(VeiasCaderno[i].iIndice);
			if (VeiasCaderno[i].iIndice < 1)
			{
				text = VeiasCaderno[i].sNomeVeia;
			}
			if (VeiasCaderno[i].iIndice <= -50)
			{
				continue;
			}
			double num2 = VeiasCaderno[i].iIndice;
			if (VeiasCaderno[i].iIndice < 0)
			{
				if (!VeiasCaderno[i].sFormacao.Contains("P"))
				{
					if (VeiasCaderno[i].sFormacao.Contains("T"))
					{
						num2 *= -3.0;
						num2 += 0.1;
					}
				}
				else
				{
					num2 *= -2.0;
					num2 += 0.1;
				}
			}
			dg.Rows.Add(VeiasCaderno[i].iIndice, text, VeiasCaderno[i].sNomeVeia, VeiasCaderno[i].sFuncaoVeia, VeiasCaderno[i].sPagina, VeiasCaderno[i].sHandleCabo1, num2);
		}
		ClsCabos.OrdenaVeias(ref dg, 6);
		AtualizaDGVeias();
		if (dgVeias.Rows.Count > 0)
		{
			dgVeias.Rows[0].Selected = false;
		}
	}

	public void formataDGVeias()
	{
		try
		{
			dgVeias.Rows.Clear();
			dgVeias.Columns.Clear();
			dgVeias.Columns.Add("Indi", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 915]));
			dgVeias.Columns.Add("Indice", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 915]));
			dgVeias.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
			dgVeias.Columns.Add("Func", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
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
				dgVeias.Columns[1].Width = (int)Math.Round(num * 0.2);
				dgVeias.Columns[1].Visible = true;
				dgVeias.Columns[2].Width = (int)Math.Round(num * 0.2);
				dgVeias.Columns[2].Visible = true;
				dgVeias.Columns[3].Width = (int)Math.Round(num * 0.3);
				dgVeias.Columns[3].Visible = true;
				dgVeias.Columns[4].Width = (int)Math.Round(num * 0.3);
				dgVeias.Columns[4].Visible = true;
				dgVeias.Columns[5].Width = 0;
				dgVeias.Columns[5].Visible = false;
				dgVeias.Columns[6].Width = 0;
				dgVeias.Columns[6].Visible = false;
			}
		}
	}

	private void WqgHaXA2PG(object P_0, EventArgs P_1)
	{
		AtualizaDGCabos();
		AtualizaDGVeias();
	}

	private void jWTH8kRDrx(object P_0, EventArgs P_1)
	{
		tbCabos.Text = "";
		tbFormacao.Text = "";
		DataGridView dg = dgCabos;
		CarregaTodasCabosDoCadernoNoDG(ref dg, z0sHUZYifH, tbCabos.Text, tbFormacao.Text);
		dgCabos = dg;
	}

	private void r7OHN0qYyQ(object P_0, EventArgs P_1)
	{
		tbCabos.Text = "";
		tbFormacao.Text = "";
		DataGridView dg = dgCabos;
		CarregaTodasCabosDoCadernoNoDG(ref dg, psiHyZlsf3, tbCabos.Text, tbFormacao.Text);
		dgCabos = dg;
	}

	private void pu4HFniFqA()
	{
		List<string> lCabos = new List<string>();
		z0sHUZYifH = new structureVeiasCaderno[1];
		psiHyZlsf3 = new structureVeiasCaderno[1];
		c1sHAl4tFB = new clsTextos.structureTextoCaderno[1];
		clsInterligacao.buscaTextosdosCabos(ref c1sHAl4tFB);
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.LeCabosVeiasUsadasCaderno(ref z0sHUZYifH, ref lCabos, bFormacao: true);
		clsEditarInterligacao.AtualizaXdatadosCabosVeiasUsadasCaderno(ref z0sHUZYifH);
		clsEditarInterligacao.AtualizaNomesDosCabos();
		cDadosAccessInterligacao3.LeCabosVeiasNaoUsadasCaderno(ref psiHyZlsf3, bFormacao: true);
		cDadosAccessInterligacao3.FechaConexao();
		Application.ShowModelessDialog((Form)this);
		rbCaderno.Checked = true;
		DataGridView dg = dgCabos;
		CarregaTodasCabosDoCadernoNoDG(ref dg, z0sHUZYifH, tbCabos.Text, tbFormacao.Text);
		dgCabos = dg;
	}

	private void h6YHQZsSjw(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
		{
			if (!rbCaderno.Checked)
			{
				DataGridView dg = dgCabos;
				clsVeias.ExportaNomeFuncaoVeiaParaOExcel(ref oSheet, ref dg, psiHyZlsf3);
				dgCabos = dg;
			}
			else
			{
				DataGridView dg = dgCabos;
				clsVeias.ExportaNomeFuncaoVeiaParaOExcel(ref oSheet, ref dg, z0sHUZYifH);
				dgCabos = dg;
			}
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
	}

	private void ekpHPIwhYV(object P_0, EventArgs P_1)
	{
		structureVeiasCaderno[] SincVeias = null;
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
		{
			clsVeias.ImportaNomeFuncaoVeiaDoExcel(ref oSheet, ref SincVeias);
		}
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		DeclaracoesGeral._uscPagina.pbIniciar();
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(SincVeias);
		int num = Information.UBound(SincVeias);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			cDadosAccessInterligacao3.EditaNomeFuncaoVeiaDeUmCabo(SincVeias[i].sNomeVeia, SincVeias[i].sFuncaoVeia, SincVeias[i].sTag, SincVeias[i].iIndice);
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		cDadosAccessInterligacao3.FechaConexao();
		pu4HFniFqA();
		DeclaracoesGeral._uscPagina.pbFim();
	}

	~frmEditarNomesFuncoesVeias()
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		mdiActiveDocument.SendStringToExecute("_.AtualizaOpcionaisDoCabo \n", true, false, true);
		base.Finalize();
	}
}
