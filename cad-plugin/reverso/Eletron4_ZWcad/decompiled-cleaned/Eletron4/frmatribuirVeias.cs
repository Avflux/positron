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
using aFa9DPlwTjweDtcq368;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmatribuirVeias : Form
{
	private IContainer RVm1CZiaLK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog Cut1Ysmut2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGCabos")]
	private DataGridView n8F1rIukt4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip qIB19TOlaW;

	[CompilerGenerated]
	[AccessedThroughProperty("BTAtribuiVeia")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button RUr1zEQJOo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTSelecionarVeias")]
	private Button uRelWI0bZh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGVeiasIndefinidas")]
	private DataGridView N8Mlp6XnYv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKNomeVisivel")]
	private CheckBox qmwlT7rsyB;

	[AccessedThroughProperty("CKOrdemSelecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox zdXlJ6YxgP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LBFuncao")]
	private Label vmxlh4xlje;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GBFuncao")]
	private GroupBox pfiloNJlTe;

	[AccessedThroughProperty("BTAdicionarCabo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button F5XlGDgpDl;

	private string x3alHE4NsZ;

	private structureVeiasCaderno[] qtylkGsM6a;

	private bool AUyldnBK6M;

	private DataGridViewCellStyle qhglft9LYa;

	private DataGridViewCellStyle MG0lDqSbrw;

	private FB2GIolLuVhdHYsC16b[] Ti5lv7jpUO;

	private clsTextos.structureTextoCaderno[] mM1l6lqFnp;

	private string upAltWwJvF;

	private string VLpljaIa7w;

	internal virtual DataGridView DGCabos
	{
		[CompilerGenerated]
		get
		{
			return n8F1rIukt4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = xFH1BYqJGn;
			MouseEventHandler value3 = XpG1V9CEWC;
			DataGridView dataGridView = n8F1rIukt4;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			n8F1rIukt4 = value;
			dataGridView = n8F1rIukt4;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual Button BTAtribuiVeia
	{
		[CompilerGenerated]
		get
		{
			return RUr1zEQJOo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aty1UlvDXb;
			Button button = RUr1zEQJOo;
			if (button != null)
			{
				button.Click -= value2;
			}
			RUr1zEQJOo = value;
			button = RUr1zEQJOo;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTSelecionarVeias
	{
		[CompilerGenerated]
		get
		{
			return uRelWI0bZh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gsx1yGR67Y;
			Button button = uRelWI0bZh;
			if (button != null)
			{
				button.Click -= value2;
			}
			uRelWI0bZh = value;
			button = uRelWI0bZh;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView DGVeiasIndefinidas
	{
		[CompilerGenerated]
		get
		{
			return N8Mlp6XnYv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = PJy1EWCDur;
			MouseEventHandler value3 = oF81ZwiqCF;
			DataGridView dataGridView = N8Mlp6XnYv;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			N8Mlp6XnYv = value;
			dataGridView = N8Mlp6XnYv;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual CheckBox CKNomeVisivel
	{
		[CompilerGenerated]
		get
		{
			return qmwlT7rsyB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qmwlT7rsyB = value;
		}
	}

	internal virtual CheckBox CKOrdemSelecao
	{
		[CompilerGenerated]
		get
		{
			return zdXlJ6YxgP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zdXlJ6YxgP = value;
		}
	}

	internal virtual Label LBFuncao
	{
		[CompilerGenerated]
		get
		{
			return vmxlh4xlje;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vmxlh4xlje = value;
		}
	}

	internal virtual GroupBox GBFuncao
	{
		[CompilerGenerated]
		get
		{
			return pfiloNJlTe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pfiloNJlTe = value;
		}
	}

	internal virtual Button BTAdicionarCabo
	{
		[CompilerGenerated]
		get
		{
			return F5XlGDgpDl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = m5i14CrPvt;
			Button button = F5XlGDgpDl;
			if (button != null)
			{
				button.Click -= value2;
			}
			F5XlGDgpDl = value;
			button = F5XlGDgpDl;
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
			if (disposing && RVm1CZiaLK != null)
			{
				RVm1CZiaLK.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void HZG1XpVUhc()
	{
		RVm1CZiaLK = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmatribuirVeias));
		aHypBEW66iS(new FolderBrowserDialog());
		DGCabos = new DataGridView();
		FDqpBiUmZij(new ToolTip(RVm1CZiaLK));
		BTAtribuiVeia = new Button();
		BTSelecionarVeias = new Button();
		DGVeiasIndefinidas = new DataGridView();
		CKNomeVisivel = new CheckBox();
		CKOrdemSelecao = new CheckBox();
		LBFuncao = new Label();
		GBFuncao = new GroupBox();
		BTAdicionarCabo = new Button();
		((ISupportInitialize)DGCabos).BeginInit();
		((ISupportInitialize)DGVeiasIndefinidas).BeginInit();
		GBFuncao.SuspendLayout();
		SuspendLayout();
		DGCabos.AllowUserToAddRows = false;
		DGCabos.AllowUserToDeleteRows = false;
		DGCabos.AllowUserToOrderColumns = true;
		DGCabos.AllowUserToResizeRows = false;
		DGCabos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGCabos.BackgroundColor = SystemColors.ButtonHighlight;
		DGCabos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGCabos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGCabos.Location = new Point(12, 12);
		DGCabos.Name = "DGCabos";
		DGCabos.ReadOnly = true;
		DGCabos.RowHeadersVisible = false;
		DGCabos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGCabos.Size = new Size(223, 153);
		DGCabos.TabIndex = 117;
		BTAtribuiVeia.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTAtribuiVeia.FlatStyle = FlatStyle.Flat;
		BTAtribuiVeia.ForeColor = SystemColors.Control;
		BTAtribuiVeia.Image = Resources.OK_32;
		BTAtribuiVeia.Location = new Point(429, 217);
		BTAtribuiVeia.Name = "BTAtribuiVeia";
		BTAtribuiVeia.Size = new Size(40, 40);
		BTAtribuiVeia.TabIndex = 143;
		BTAtribuiVeia.UseVisualStyleBackColor = true;
		BTSelecionarVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTSelecionarVeias.FlatStyle = FlatStyle.Flat;
		BTSelecionarVeias.ForeColor = SystemColors.Control;
		BTSelecionarVeias.Image = (Image)componentResourceManager.GetObject("BTSelecionarVeias.Image");
		BTSelecionarVeias.Location = new Point(384, 217);
		BTSelecionarVeias.Name = "BTSelecionarVeias";
		BTSelecionarVeias.Size = new Size(40, 40);
		BTSelecionarVeias.TabIndex = 170;
		BTSelecionarVeias.Tag = "";
		BTSelecionarVeias.UseVisualStyleBackColor = true;
		DGVeiasIndefinidas.AllowUserToAddRows = false;
		DGVeiasIndefinidas.AllowUserToDeleteRows = false;
		DGVeiasIndefinidas.AllowUserToOrderColumns = true;
		DGVeiasIndefinidas.AllowUserToResizeRows = false;
		DGVeiasIndefinidas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGVeiasIndefinidas.BackgroundColor = SystemColors.ButtonHighlight;
		DGVeiasIndefinidas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGVeiasIndefinidas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGVeiasIndefinidas.Location = new Point(241, 12);
		DGVeiasIndefinidas.Name = "DGVeiasIndefinidas";
		DGVeiasIndefinidas.ReadOnly = true;
		DGVeiasIndefinidas.RowHeadersVisible = false;
		DGVeiasIndefinidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGVeiasIndefinidas.Size = new Size(231, 153);
		DGVeiasIndefinidas.TabIndex = 171;
		CKNomeVisivel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKNomeVisivel.AutoSize = true;
		CKNomeVisivel.Checked = true;
		CKNomeVisivel.CheckState = CheckState.Checked;
		CKNomeVisivel.Location = new Point(15, 214);
		CKNomeVisivel.Name = "CKNomeVisivel";
		CKNomeVisivel.Size = new Size(96, 17);
		CKNomeVisivel.TabIndex = 172;
		CKNomeVisivel.Text = "ckNomeVisivel";
		CKNomeVisivel.UseVisualStyleBackColor = true;
		CKOrdemSelecao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKOrdemSelecao.AutoSize = true;
		CKOrdemSelecao.Checked = true;
		CKOrdemSelecao.CheckState = CheckState.Checked;
		CKOrdemSelecao.Location = new Point(15, 236);
		CKOrdemSelecao.Name = "CKOrdemSelecao";
		CKOrdemSelecao.Size = new Size(127, 17);
		CKOrdemSelecao.TabIndex = 173;
		CKOrdemSelecao.Text = "CkOrdem de Seleção";
		CKOrdemSelecao.UseVisualStyleBackColor = true;
		LBFuncao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LBFuncao.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		LBFuncao.Location = new Point(3, 16);
		LBFuncao.Name = "LBFuncao";
		LBFuncao.Size = new Size(455, 18);
		LBFuncao.TabIndex = 175;
		LBFuncao.Text = "função";
		GBFuncao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GBFuncao.Controls.Add(LBFuncao);
		GBFuncao.Location = new Point(12, 170);
		GBFuncao.Name = "GBFuncao";
		GBFuncao.Size = new Size(460, 38);
		GBFuncao.TabIndex = 176;
		GBFuncao.TabStop = false;
		GBFuncao.Text = "GBFunção";
		BTAdicionarCabo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTAdicionarCabo.FlatStyle = FlatStyle.Flat;
		BTAdicionarCabo.ForeColor = SystemColors.Control;
		BTAdicionarCabo.Image = Resources.Adiciona_32;
		BTAdicionarCabo.Location = new Point(338, 217);
		BTAdicionarCabo.Name = "BTAdicionarCabo";
		BTAdicionarCabo.Size = new Size(40, 40);
		BTAdicionarCabo.TabIndex = 143;
		BTAdicionarCabo.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(484, 261);
		Controls.Add(GBFuncao);
		Controls.Add(CKOrdemSelecao);
		Controls.Add(CKNomeVisivel);
		Controls.Add(DGVeiasIndefinidas);
		Controls.Add(BTSelecionarVeias);
		Controls.Add(BTAdicionarCabo);
		Controls.Add(BTAtribuiVeia);
		Controls.Add(DGCabos);
		ImeMode = ImeMode.On;
		MaximumSize = new Size(500, 1000);
		MinimumSize = new Size(500, 300);
		Name = "frmatribuirVeias";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Atribuir Veias";
		((ISupportInitialize)DGCabos).EndInit();
		((ISupportInitialize)DGVeiasIndefinidas).EndInit();
		GBFuncao.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return Cut1Ysmut2;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		Cut1Ysmut2 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return qIB19TOlaW;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		qIB19TOlaW = WithEventsValue;
	}

	public frmatribuirVeias()
	{
		Resize += RrG1SF5irc;
		x3alHE4NsZ = Conversions.ToString(1);
		AUyldnBK6M = false;
		qhglft9LYa = new DataGridViewCellStyle();
		MG0lDqSbrw = new DataGridViewCellStyle();
		upAltWwJvF = "";
		VLpljaIa7w = "";
		if (Geral.ExisteForm("frmatribuirVeias") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			HZG1XpVUhc();
			qhglft9LYa.BackColor = Color.LightCoral;
			MG0lDqSbrw.BackColor = Color.LightGreen;
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1276]);
			CKNomeVisivel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 910]);
			CKOrdemSelecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1347]);
			GBFuncao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1270]);
			LBFuncao.Text = "";
			w8dpBZ0kvSD().SetToolTip(BTAtribuiVeia, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 564]));
			w8dpBZ0kvSD().SetToolTip(BTSelecionarVeias, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1277]));
			mM1l6lqFnp = new clsTextos.structureTextoCaderno[1];
			clsInterligacao.buscaTextosdosCabos(ref mM1l6lqFnp);
			DGCabos.Enabled = false;
			DGVeiasIndefinidas.Enabled = false;
			Application.ShowModelessDialog((Form)this);
			CKOrdemSelecao.Checked = false;
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

	private void aty1UlvDXb(object P_0, EventArgs P_1)
	{
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		string text = "";
		string text2 = "";
		string text3 = "";
		int num = 0;
		int num2 = 0;
		checked
		{
			if (DGCabos.SelectedRows.Count > 0)
			{
				text = Conversions.ToString(DGCabos.SelectedRows[0].Cells[0].Value);
				text2 = Conversions.ToString(DGCabos.SelectedRows[0].Cells[1].Value);
				num = Conversions.ToInteger(DGCabos.SelectedRows[0].Cells[3].Value);
				num2 = Conversions.ToInteger(DGCabos.SelectedRows[0].Cells[4].Value);
				int num3 = Information.UBound(qtylkGsM6a);
				for (int i = 1; i <= num3; i++)
				{
					if (!((qtylkGsM6a[i].iPn1 == num) | (qtylkGsM6a[i].iPn2 == num2) | ((qtylkGsM6a[i].iPn1 == num2) | (qtylkGsM6a[i].iPn2 == num))))
					{
						continue;
					}
					int num4 = 0;
					string text4 = "";
					int num5 = -1000;
					string text5 = "";
					int num6 = DGVeiasIndefinidas.Rows.Count - 1;
					for (int j = 0; j <= num6; j++)
					{
						if (DGVeiasIndefinidas.Rows[j].Selected)
						{
							num4 = Conversions.ToInteger(DGVeiasIndefinidas.Rows[j].Cells[0].Value);
							text4 = Conversions.ToString(DGVeiasIndefinidas.Rows[j].Cells[1].Value);
							num5 = Conversions.ToInteger(DGVeiasIndefinidas.Rows[j].Cells[2].Value);
							text5 = Conversions.ToString(DGVeiasIndefinidas.Rows[j].Cells[3].Value);
							DGVeiasIndefinidas.Rows[j].Cells[5].Value = DeclaracoesGeral.mMensagem[1, 1113].ToString().ToUpper();
							DGVeiasIndefinidas.Rows[j].Selected = false;
							break;
						}
					}
					int num7 = 0;
					num7 = Conversions.ToInteger(clsInterligacao.LeOModeloVeias());
					if (num4 == 0)
					{
						continue;
					}
					text3 = text5;
					qtylkGsM6a[i].sTag = text4;
					qtylkGsM6a[i].iIndice = num5;
					qtylkGsM6a[i].sNomeVeia = text3;
					if (num7 != 3 && Operators.CompareString(qtylkGsM6a[i].sHandleCabo1, "", TextCompare: true) != 0 && Operators.CompareString(qtylkGsM6a[i].sHandleTag1, "", TextCompare: true) == 0)
					{
						qtylkGsM6a[i].sHandleTag1 = clsEditarInterligacao.reinsereAuxInterlig(qtylkGsM6a[i].sHandleCabo1);
					}
					if (num7 != 3 && Operators.CompareString(qtylkGsM6a[i].sHandleCabo2, "", TextCompare: true) != 0 && Operators.CompareString(qtylkGsM6a[i].sHandleTag2, "", TextCompare: true) == 0)
					{
						qtylkGsM6a[i].sHandleTag2 = clsEditarInterligacao.reinsereAuxInterlig(qtylkGsM6a[i].sHandleCabo2);
					}
					string text6 = "";
					if (DeclaracoesGeral.Conf.InterligacaoLayout != 3)
					{
						if (Operators.CompareString(text3.Trim(), "", TextCompare: true) == 0)
						{
							text6 = num5.ToString();
							if (CKNomeVisivel.Checked)
							{
								text6 = text4 + DeclaracoesGeral.Conf.SeparadorCaboVeia + text6;
							}
							if (Operators.CompareString(text2, "1X", TextCompare: true) == 0)
							{
								text6 = text4;
							}
						}
						else
						{
							text6 = "(" + text3 + ")";
							if (CKNomeVisivel.Checked)
							{
								text6 = text4 + " " + text6;
							}
						}
					}
					else
					{
						text6 = text3;
						if (Operators.CompareString(text6, "", TextCompare: true) == 0)
						{
							text6 = num5.ToString();
						}
					}
					if (DeclaracoesGeral.Conf.InterligacaoLayout == 3)
					{
						clsENEL.ReinsereAuxInterligaENEL_SP(qtylkGsM6a[i].sHandleCabo1);
					}
					if (DeclaracoesGeral.Conf.InterligacaoLayout == 3 && Operators.CompareString(qtylkGsM6a[i].sHandleCabo2, "", TextCompare: true) != 0)
					{
						clsENEL.ReinsereAuxInterligaENEL_SP(qtylkGsM6a[i].sHandleCabo2);
					}
					cDadosAccessInterligacao3.AtribuiVeiaNoBanco(num4, qtylkGsM6a[i].sHandleCabo1, DeclaracoesGeral.arqAtivo.Indice, qtylkGsM6a[i].sPagina);
					if (Operators.CompareString(qtylkGsM6a[i].sHandleCabo1, "", TextCompare: true) != 0)
					{
						clsInterligacao.AtribuiUmaVeia(qtylkGsM6a[i].sHandleCabo1, text4, num5, text5, CKNomeVisivel.Checked);
					}
					if (Operators.CompareString(qtylkGsM6a[i].sHandleCabo2, "", TextCompare: true) != 0)
					{
						clsInterligacao.AtribuiUmaVeia(qtylkGsM6a[i].sHandleCabo2, text4, num5, text5, CKNomeVisivel.Checked);
					}
					if (Operators.CompareString(qtylkGsM6a[i].sHandleTag1, "", TextCompare: true) != 0)
					{
						clsTextos.AtualizaUmTexto(qtylkGsM6a[i].sHandleTag1, text6);
					}
					if (Operators.CompareString(qtylkGsM6a[i].sHandleTag2, "", TextCompare: true) != 0)
					{
						clsTextos.AtualizaUmTexto(qtylkGsM6a[i].sHandleTag2, text6);
					}
				}
				cDadosAccessInterligacao3.FechaConexao();
				structureVeiasCaderno[] array = new structureVeiasCaderno[1];
				int num8 = Information.UBound(qtylkGsM6a);
				for (int k = 1; k <= num8; k++)
				{
					if (Operators.CompareString(qtylkGsM6a[k].sTag, "", TextCompare: true) == 0)
					{
						int num9 = Information.UBound(array) + 1;
						array = (structureVeiasCaderno[])Utils.CopyArray(array, new structureVeiasCaderno[num9 + 1]);
						array[num9] = qtylkGsM6a[k];
					}
				}
				qtylkGsM6a = new structureVeiasCaderno[1];
				int num10 = Information.UBound(array);
				for (int l = 1; l <= num10; l++)
				{
					int num11 = Information.UBound(qtylkGsM6a) + 1;
					ref structureVeiasCaderno[] reference = ref qtylkGsM6a;
					reference = (structureVeiasCaderno[])Utils.CopyArray(reference, new structureVeiasCaderno[num11 + 1]);
					qtylkGsM6a[num11] = array[l];
				}
				rwS1sO1NnL();
				int num12 = DGCabos.Rows.Count - 1;
				for (int m = 0; m <= num12; m++)
				{
					if (Operators.ConditionalCompareObjectEqual(DGCabos.Rows[m].Cells[0].Value, text, TextCompare: true))
					{
						DGCabos.Rows[m].Selected = true;
						e5Z1uH0Wae();
						break;
					}
				}
				AtualizaDGVeiasIndefinidas();
				Form form = Application.OpenForms["frmPesquisaVeiasIndefinidas"];
				if (!Information.IsNothing(form))
				{
					frmPesquisaVeiasIndefinidas frmPesquisaVeiasIndefinidas2 = (frmPesquisaVeiasIndefinidas)form;
					frmPesquisaVeiasIndefinidas2.CarregaNovamenteAsVeias();
				}
			}
			clsBlocos.Unhighlight();
			PintaCabosUso();
			LBFuncao.Text = "";
			clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
		}
	}

	public void CarregaTodasAsVeiasDoCadernoNoDG(structureVeiasCaderno[] VeiasCaderno, string sPagina)
	{
		Ti5lv7jpUO = new FB2GIolLuVhdHYsC16b[1];
		int num = Information.UBound(VeiasCaderno);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (Operators.CompareString(VeiasCaderno[i].sPagina.ToString(), sPagina.ToString(), TextCompare: true) == 0)
				{
					string fRDlMY62yd = DeclaracoesGeral.mMensagem[1, 1105].ToString().ToLowerInvariant();
					if (VeiasCaderno[i].iTipo == 3)
					{
						fRDlMY62yd = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 565]);
					}
					if ((double)VeiasCaderno[i].iIndice != Conversions.ToDouble("-1000"))
					{
						fRDlMY62yd = VeiasCaderno[i].iIndice.ToString();
					}
					if (Operators.CompareString(VeiasCaderno[i].sNomeVeia.Trim(), "", TextCompare: true) != 0)
					{
						fRDlMY62yd = VeiasCaderno[i].sNomeVeia;
					}
					int num2 = VeiasCaderno[i].iPn1;
					int num3 = VeiasCaderno[i].iPn2;
					if (num2 > num3)
					{
						num2 = VeiasCaderno[i].iPn2;
						num3 = VeiasCaderno[i].iPn1;
					}
					int num4 = Information.UBound(Ti5lv7jpUO) + 1;
					ref FB2GIolLuVhdHYsC16b[] ti5lv7jpUO = ref Ti5lv7jpUO;
					ti5lv7jpUO = (FB2GIolLuVhdHYsC16b[])Utils.CopyArray(ti5lv7jpUO, new FB2GIolLuVhdHYsC16b[num4 + 1]);
					Ti5lv7jpUO[num4].wEilbwmCGl = VeiasCaderno[i].iIndice;
					Ti5lv7jpUO[num4].FRDlMY62yd = fRDlMY62yd;
					Ti5lv7jpUO[num4].dc3lOPPB2t = num2;
					Ti5lv7jpUO[num4].IerlI0eZqc = num3;
					Ti5lv7jpUO[num4].xYZl7jomay = VeiasCaderno[i].sHandleCabo1;
					Ti5lv7jpUO[num4].rvylaDhtyO = VeiasCaderno[i].sHandleTag1;
					Ti5lv7jpUO[num4].FSAlqdhVVh = VeiasCaderno[i].sHandleCabo2;
					Ti5lv7jpUO[num4].kOxl8xb0WL = VeiasCaderno[i].sHandleTag2;
					Ti5lv7jpUO[num4].XnjlNsAyWa = VeiasCaderno[i].sPagina;
					Ti5lv7jpUO[num4].iWllF8xV3C = VeiasCaderno[i].sPagina2;
				}
			}
		}
	}

	public void MostraAsVeiasDoDWG()
	{
		if (AUyldnBK6M && Operators.CompareString(DeclaracoesGeral.ativo.Pagina, x3alHE4NsZ, TextCompare: true) != 0)
		{
			x3alHE4NsZ = DeclaracoesGeral.ativo.Pagina;
			Ti5lv7jpUO = new FB2GIolLuVhdHYsC16b[1];
			DGCabos.Rows.Clear();
			DGCabos.Columns.Clear();
			DGVeiasIndefinidas.Rows.Clear();
			DGVeiasIndefinidas.Columns.Clear();
		}
	}

	private void gsx1yGR67Y(object P_0, EventArgs P_1)
	{
		DGCabos.Rows.Clear();
		DGCabos.Columns.Clear();
		DGVeiasIndefinidas.Rows.Clear();
		DGVeiasIndefinidas.Columns.Clear();
		DGCabos.Enabled = false;
		MostraAsVeiasDoDWG();
		clsBlocos.Unhighlight();
		Hide();
		string left = clsInterligacao.SelecionaAsVeiasDaPagina(ref qtylkGsM6a, mM1l6lqFnp, CKOrdemSelecao.Checked);
		Show();
		if (Operators.CompareString(left, "", TextCompare: true) != 0)
		{
			if (Information.UBound(qtylkGsM6a) >= 1)
			{
				rwS1sO1NnL();
				DGCabos.Enabled = true;
			}
			PintaCabosUso();
		}
	}

	private void mlv1gnVBqR(object P_0, KeyEventArgs P_1)
	{
		rwS1sO1NnL();
	}

	private void FEv1AZFyQ4(object P_0, MouseEventArgs P_1)
	{
		rwS1sO1NnL();
	}

	private void rwS1sO1NnL()
	{
		List<string> list = new List<string>();
		list.Clear();
		DGCabos.Rows.Clear();
		DGCabos.Columns.Clear();
		DGVeiasIndefinidas.Rows.Clear();
		DGVeiasIndefinidas.Columns.Clear();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		clsInterligacao.AtivaHighlight(list);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		formataDGCabos();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		int num = 0;
		int num2 = 0;
		checked
		{
			if (Information.UBound(qtylkGsM6a) > 0)
			{
				if (qtylkGsM6a[1].iTipo == 3)
				{
					int num3 = Information.UBound(qtylkGsM6a);
					for (int i = 1; i <= num3; i++)
					{
						if (qtylkGsM6a[i].iPn1 != qtylkGsM6a[i].iPn2)
						{
							num = qtylkGsM6a[i].iPn1;
							num2 = qtylkGsM6a[i].iPn2;
							break;
						}
					}
					if (num == 0)
					{
						num = num2;
					}
					DataGridView dg = DGCabos;
					cDadosAccessInterligacao3.LeBlindagensDoPainel(ref dg, num);
					DGCabos = dg;
				}
				else
				{
					int num4 = Information.UBound(qtylkGsM6a);
					for (int j = 1; j <= num4; j++)
					{
						if (qtylkGsM6a[j].iPn1 != qtylkGsM6a[j].iPn2)
						{
							num = qtylkGsM6a[j].iPn1;
							num2 = qtylkGsM6a[j].iPn2;
							DataGridView dg = DGCabos;
							cDadosAccessInterligacao3.LeCabosDosPaineis(ref dg, qtylkGsM6a[j].iPn1, qtylkGsM6a[j].iPn2);
							DGCabos = dg;
							break;
						}
					}
				}
			}
			AtualizaDGCabos();
			if (DGCabos.Rows.Count > 0)
			{
				DGCabos.Rows[0].Selected = false;
			}
			if (DGCabos.Rows.Count == 0)
			{
				int num5 = DGCabos.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					DGCabos.Rows[k].Selected = false;
				}
			}
			cDadosAccessInterligacao3.FechaConexao();
		}
	}

	private void xFH1BYqJGn(object P_0, KeyEventArgs P_1)
	{
		e5Z1uH0Wae();
	}

	private void XpG1V9CEWC(object P_0, MouseEventArgs P_1)
	{
		e5Z1uH0Wae();
	}

	private void e5Z1uH0Wae()
	{
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		DGVeiasIndefinidas.Rows.Clear();
		DGVeiasIndefinidas.Columns.Clear();
		if (DGCabos.SelectedRows.Count > 0)
		{
			DGVeiasIndefinidas.Enabled = true;
			string sCabo = Conversions.ToString(DGCabos.SelectedRows[0].Cells[0].Value);
			LBFuncao.Text = Conversions.ToString(DGCabos.SelectedRows[0].Cells[2].Value);
			formataDGVeiasIndefinidas();
			if (qtylkGsM6a[1].iTipo != 3)
			{
				DataGridView dg = DGVeiasIndefinidas;
				cDadosAccessInterligacao3.LeAsVeiasDoCaboSel(ref dg, sCabo);
				DGVeiasIndefinidas = dg;
			}
			else
			{
				DataGridView dg = DGVeiasIndefinidas;
				cDadosAccessInterligacao3.LeAsBlindagensDoCaboSel(ref dg, sCabo);
				DGVeiasIndefinidas = dg;
			}
			AtualizaDGVeiasIndefinidas();
		}
		checked
		{
			if (DGVeiasIndefinidas.Rows.Count - 1 >= 0)
			{
				int num = DGVeiasIndefinidas.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.CompareString(DGVeiasIndefinidas.Rows[i].Cells[5].Value.ToString().ToUpper(), DeclaracoesGeral.mMensagem[1, 1105].ToString().ToUpper(), TextCompare: true) != 0)
					{
						int num2 = 0;
						do
						{
							DGVeiasIndefinidas.Rows[i].Cells[num2].Style = qhglft9LYa;
							num2++;
						}
						while (num2 <= 6);
					}
					else
					{
						int num3 = 0;
						do
						{
							DGVeiasIndefinidas.Rows[i].Cells[num3].Style = MG0lDqSbrw;
							num3++;
						}
						while (num3 <= 6);
					}
				}
			}
			int num4 = 0;
			int num5 = DGVeiasIndefinidas.Rows.Count - 1;
			for (int j = 0; j <= num5; j++)
			{
				DGVeiasIndefinidas.Rows[j].Selected = false;
			}
			int num6 = 0;
			int num7 = 0;
			int num8 = Information.UBound(qtylkGsM6a);
			for (int k = 1; k <= num8; k++)
			{
				if (qtylkGsM6a[k].iPn1 != qtylkGsM6a[k].iPn2)
				{
					num6 = qtylkGsM6a[k].iPn1;
					num7 = qtylkGsM6a[k].iPn2;
					break;
				}
			}
			int num9 = 0;
			int num10 = Information.UBound(qtylkGsM6a);
			for (int l = 1; l <= num10; l++)
			{
				if (((num6 == qtylkGsM6a[l].iPn1) & (num7 == qtylkGsM6a[l].iPn2)) | ((num6 == qtylkGsM6a[l].iPn2) & (num7 == qtylkGsM6a[l].iPn1)))
				{
					num9++;
				}
			}
			int num11 = DGVeiasIndefinidas.Rows.Count - 1;
			for (int m = 0; m <= num11; m++)
			{
				if (Operators.CompareString(DGVeiasIndefinidas.Rows[m].Cells[5].Value.ToString().ToUpper(), DeclaracoesGeral.mMensagem[1, 1105].ToString().ToUpper(), TextCompare: true) == 0)
				{
					num4++;
					num9--;
					DGVeiasIndefinidas.Rows[m].Selected = true;
					if ((Information.UBound(qtylkGsM6a) == num4) | (num9 == 0))
					{
						break;
					}
				}
			}
			cDadosAccessInterligacao3.FechaConexao();
		}
	}

	private void PJy1EWCDur(object P_0, KeyEventArgs P_1)
	{
		zpQ1i79rPG();
	}

	private void oF81ZwiqCF(object P_0, MouseEventArgs P_1)
	{
		zpQ1i79rPG();
	}

	private void zpQ1i79rPG()
	{
		int num = 0;
		checked
		{
			if (DGVeiasIndefinidas.Rows.Count - 1 >= 0)
			{
				int num2 = DGVeiasIndefinidas.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.CompareString(DGVeiasIndefinidas.Rows[i].Cells[5].Value.ToString().ToUpper(), DeclaracoesGeral.mMensagem[1, 1105].ToString().ToUpper(), TextCompare: true) != 0)
					{
						DGVeiasIndefinidas.Rows[i].Selected = false;
					}
					else
					{
						num++;
					}
				}
			}
			if (Information.UBound(qtylkGsM6a) > num)
			{
				return;
			}
			num = Information.UBound(qtylkGsM6a);
			int num3 = DGVeiasIndefinidas.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if (DGVeiasIndefinidas.Rows[j].Selected)
				{
					if (num <= 0)
					{
						DGVeiasIndefinidas.Rows[j].Selected = false;
					}
					num--;
				}
			}
		}
	}

	public void formataDGCabos()
	{
		try
		{
			DGCabos.Rows.Clear();
			DGCabos.Columns.Clear();
			DGCabos.Columns.Add("Cabos", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]));
			DGCabos.Columns.Add("Formacao", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
			DGCabos.Columns.Add("Funcao", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1430]));
			DGCabos.Columns.Add("PN1", "PN1");
			DGCabos.Columns.Add("PN2", "PN2");
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
			if (DGCabos.Columns.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGCabos)) ? ((double)(DGCabos.Width - 4)) : ((double)(DGCabos.Width - 21)));
				DGCabos.Columns[0].Width = (int)Math.Round(num * 0.6);
				DGCabos.Columns[0].Visible = true;
				DGCabos.Columns[1].Width = (int)Math.Round(num * 0.4);
				DGCabos.Columns[1].Visible = true;
				DGCabos.Columns[2].Width = 0;
				DGCabos.Columns[2].Visible = false;
				DGCabos.Columns[3].Width = 0;
				DGCabos.Columns[3].Visible = false;
				DGCabos.Columns[4].Width = 0;
				DGCabos.Columns[4].Visible = false;
				DGCabos.MultiSelect = false;
			}
		}
	}

	public void PintaCabosUso()
	{
		if (DGCabos.Columns.Count == 0)
		{
			return;
		}
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightGreen;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.LightYellow;
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dataGridViewCellStyle3.BackColor = Color.LightCoral;
		checked
		{
			int num = DGCabos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string sCabo = Conversions.ToString(DGCabos.Rows[i].Cells[0].Value);
				DGCabos.Rows[i].Cells[0].Style = dataGridViewCellStyle;
				DGCabos.Rows[i].Cells[1].Style = dataGridViewCellStyle;
				string text = "L";
				text = ((qtylkGsM6a[1].iTipo == 3) ? cDadosAccessInterligacao3.TemBlindagemLivresNoCaboSel(sCabo) : cDadosAccessInterligacao3.TemVeiasLivresNoCaboSel(sCabo));
				if (Operators.CompareString(text, "L", TextCompare: true) != 0)
				{
					if (Operators.CompareString(text, "U", TextCompare: true) != 0)
					{
						if (Operators.CompareString(text, "D", TextCompare: true) == 0)
						{
							DGCabos.Rows[i].Cells[0].Style = dataGridViewCellStyle2;
							DGCabos.Rows[i].Cells[1].Style = dataGridViewCellStyle2;
						}
					}
					else
					{
						DGCabos.Rows[i].Cells[0].Style = dataGridViewCellStyle3;
						DGCabos.Rows[i].Cells[1].Style = dataGridViewCellStyle3;
					}
				}
				else
				{
					DGCabos.Rows[i].Cells[0].Style = dataGridViewCellStyle;
					DGCabos.Rows[i].Cells[1].Style = dataGridViewCellStyle;
				}
			}
			cDadosAccessInterligacao3.FechaConexao();
		}
	}

	public void formataDGVeiasIndefinidas()
	{
		try
		{
			DGVeiasIndefinidas.Rows.Clear();
			DGVeiasIndefinidas.Columns.Clear();
			DGVeiasIndefinidas.Columns.Add("Chave", "0Chave");
			DGVeiasIndefinidas.Columns.Add("Tag", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]));
			DGVeiasIndefinidas.Columns.Add("Indice", "2Indice");
			DGVeiasIndefinidas.Columns.Add("Nome", "3Nome");
			DGVeiasIndefinidas.Columns.Add("NomeIndice", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
			DGVeiasIndefinidas.Columns.Add("Uso", "5Uso");
			DGVeiasIndefinidas.Columns.Add("funcaoVeias", "funcaoVeias");
			AtualizaDGVeiasIndefinidas();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGVeiasIndefinidas()
	{
		checked
		{
			if (DGVeiasIndefinidas.Columns.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGVeiasIndefinidas)) ? ((double)(DGVeiasIndefinidas.Width - 4)) : ((double)(DGVeiasIndefinidas.Width - 21)));
				DGVeiasIndefinidas.Columns[0].Width = 0;
				DGVeiasIndefinidas.Columns[0].Visible = false;
				DGVeiasIndefinidas.Columns[1].Width = (int)Math.Round(num * 0.7);
				DGVeiasIndefinidas.Columns[1].Visible = true;
				DGVeiasIndefinidas.Columns[2].Width = 0;
				DGVeiasIndefinidas.Columns[2].Visible = false;
				DGVeiasIndefinidas.Columns[3].Width = 0;
				DGVeiasIndefinidas.Columns[3].Visible = false;
				DGVeiasIndefinidas.Columns[4].Width = (int)Math.Round(num * 0.3);
				DGVeiasIndefinidas.Columns[4].Visible = true;
				DGVeiasIndefinidas.Columns[5].Width = 0;
				DGVeiasIndefinidas.Columns[5].Visible = false;
				DGVeiasIndefinidas.Columns[6].Width = 0;
				DGVeiasIndefinidas.Columns[6].Visible = false;
			}
		}
	}

	private void RrG1SF5irc(object P_0, EventArgs P_1)
	{
		AtualizaDGCabos();
		AtualizaDGVeiasIndefinidas();
	}

	private void m5i14CrPvt(object P_0, EventArgs P_1)
	{
		formataDGCabos();
		formataDGVeiasIndefinidas();
		upAltWwJvF = "";
		VLpljaIa7w = "";
		if (!Information.IsNothing(qtylkGsM6a) && Information.UBound(qtylkGsM6a) >= 1)
		{
			upAltWwJvF = Dicionario.BuscaNomeDoPainel(qtylkGsM6a[1].iPn1);
			VLpljaIa7w = Dicionario.BuscaNomeDoPainel(qtylkGsM6a[1].iPn2);
		}
		Hide();
		new frmAdicionaUmCabo(bFecha: false, upAltWwJvF, VLpljaIa7w);
		Show();
		if (!Information.IsNothing(qtylkGsM6a) && Information.UBound(qtylkGsM6a) >= 1)
		{
			rwS1sO1NnL();
			DGCabos.Enabled = true;
		}
		PintaCabosUso();
	}
}
