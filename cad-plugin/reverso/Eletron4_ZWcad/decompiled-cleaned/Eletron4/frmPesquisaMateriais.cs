using System;
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
public class frmPesquisaMateriais : Form
{
	private IContainer SdfvjSyW9L;

	[CompilerGenerated]
	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog M5EvLyIyLS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip qpRvw6fb7U;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxMateriais")]
	private GroupBox jJMvxkpxL3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("DGMateriais")]
	private DataGridView uccvbVRbEB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbFiltro")]
	[CompilerGenerated]
	private Label IL0vMBBxjR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBPesquisa")]
	private TextBox bc5vOorVOP;

	[AccessedThroughProperty("LBDescCompleta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label vVVvIRrkOs;

	[AccessedThroughProperty("TBDescCompleta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox kO6v7LC6cJ;

	[CompilerGenerated]
	[AccessedThroughProperty("btSeleciona")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button hPYvqXdFs8;

	[AccessedThroughProperty("LBFabricante")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label Ax7va4D7uA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBFabricante")]
	private TextBox gqEv8jsTG6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBModelo")]
	private Label CwlvNkjoJu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBModelo")]
	private TextBox nkuvFDNx2x;

	[AccessedThroughProperty("BTPesquisa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button suVvQ1UlHw;

	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label hqxvP3GXwC;

	private bool NiivcEWQHi;

	private DeclaracoesClonar.structureMaterial[] dDfvKQ2HAe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int z5Rve66SFD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string fmUv2tvxeE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string Md0v3AuviF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string tbvvn1WjH4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string XUgv16dWY1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string YJovlPf20l;

	internal virtual GroupBox GroupBoxMateriais
	{
		[CompilerGenerated]
		get
		{
			return jJMvxkpxL3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jJMvxkpxL3 = value;
		}
	}

	internal virtual DataGridView DGMateriais
	{
		[CompilerGenerated]
		get
		{
			return uccvbVRbEB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TlIvdKWLMY;
			DataGridView dataGridView = uccvbVRbEB;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			uccvbVRbEB = value;
			dataGridView = uccvbVRbEB;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return IL0vMBBxjR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IL0vMBBxjR = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return bc5vOorVOP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bc5vOorVOP = value;
		}
	}

	internal virtual Label LBDescCompleta
	{
		[CompilerGenerated]
		get
		{
			return vVVvIRrkOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vVVvIRrkOs = value;
		}
	}

	internal virtual TextBox TBDescCompleta
	{
		[CompilerGenerated]
		get
		{
			return kO6v7LC6cJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kO6v7LC6cJ = value;
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return hPYvqXdFs8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ug9vfouHs8;
			Button button = hPYvqXdFs8;
			if (button != null)
			{
				button.Click -= value2;
			}
			hPYvqXdFs8 = value;
			button = hPYvqXdFs8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LBFabricante
	{
		[CompilerGenerated]
		get
		{
			return Ax7va4D7uA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ax7va4D7uA = value;
		}
	}

	internal virtual TextBox TBFabricante
	{
		[CompilerGenerated]
		get
		{
			return gqEv8jsTG6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gqEv8jsTG6 = value;
		}
	}

	internal virtual Label LBModelo
	{
		[CompilerGenerated]
		get
		{
			return CwlvNkjoJu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CwlvNkjoJu = value;
		}
	}

	internal virtual TextBox TBModelo
	{
		[CompilerGenerated]
		get
		{
			return nkuvFDNx2x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nkuvFDNx2x = value;
		}
	}

	internal virtual Button BTPesquisa
	{
		[CompilerGenerated]
		get
		{
			return suVvQ1UlHw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = y8DvvE7015;
			Button button = suVvQ1UlHw;
			if (button != null)
			{
				button.Click -= value2;
			}
			suVvQ1UlHw = value;
			button = suVvQ1UlHw;
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
			return hqxvP3GXwC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hqxvP3GXwC = value;
		}
	}

	public int codigoInterno
	{
		[CompilerGenerated]
		get
		{
			return z5Rve66SFD;
		}
		[CompilerGenerated]
		set
		{
			z5Rve66SFD = value;
		}
	}

	public string codigoCliente
	{
		[CompilerGenerated]
		get
		{
			return fmUv2tvxeE;
		}
		[CompilerGenerated]
		set
		{
			fmUv2tvxeE = value;
		}
	}

	public string modelo
	{
		[CompilerGenerated]
		get
		{
			return Md0v3AuviF;
		}
		[CompilerGenerated]
		set
		{
			Md0v3AuviF = value;
		}
	}

	public string fabricante
	{
		[CompilerGenerated]
		get
		{
			return tbvvn1WjH4;
		}
		[CompilerGenerated]
		set
		{
			tbvvn1WjH4 = value;
		}
	}

	public string descricaoResumida
	{
		[CompilerGenerated]
		get
		{
			return XUgv16dWY1;
		}
		[CompilerGenerated]
		set
		{
			XUgv16dWY1 = value;
		}
	}

	public string descricaoCompleta
	{
		[CompilerGenerated]
		get
		{
			return YJovlPf20l;
		}
		[CompilerGenerated]
		set
		{
			YJovlPf20l = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && SdfvjSyW9L != null)
			{
				SdfvjSyW9L.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void iXdvHvhieF()
	{
		SdfvjSyW9L = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(SdfvjSyW9L));
		GroupBoxMateriais = new GroupBox();
		BTPesquisa = new Button();
		Label2 = new Label();
		TBPesquisa = new TextBox();
		LbFiltro = new Label();
		LBFabricante = new Label();
		TBFabricante = new TextBox();
		LBModelo = new Label();
		TBModelo = new TextBox();
		LBDescCompleta = new Label();
		btSeleciona = new Button();
		DGMateriais = new DataGridView();
		TBDescCompleta = new TextBox();
		GroupBoxMateriais.SuspendLayout();
		((ISupportInitialize)DGMateriais).BeginInit();
		SuspendLayout();
		GroupBoxMateriais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBoxMateriais.Controls.Add(BTPesquisa);
		GroupBoxMateriais.Controls.Add(Label2);
		GroupBoxMateriais.Controls.Add(TBPesquisa);
		GroupBoxMateriais.Controls.Add(LbFiltro);
		GroupBoxMateriais.Controls.Add(LBFabricante);
		GroupBoxMateriais.Controls.Add(TBFabricante);
		GroupBoxMateriais.Controls.Add(LBModelo);
		GroupBoxMateriais.Controls.Add(TBModelo);
		GroupBoxMateriais.Controls.Add(LBDescCompleta);
		GroupBoxMateriais.Controls.Add(btSeleciona);
		GroupBoxMateriais.Controls.Add(DGMateriais);
		GroupBoxMateriais.Controls.Add(TBDescCompleta);
		GroupBoxMateriais.Location = new Point(6, 12);
		GroupBoxMateriais.Name = "GroupBoxMateriais";
		GroupBoxMateriais.Size = new Size(638, 441);
		GroupBoxMateriais.TabIndex = 143;
		GroupBoxMateriais.TabStop = false;
		GroupBoxMateriais.Text = "GroupBoxMateriais";
		BTPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTPesquisa.FlatStyle = FlatStyle.Flat;
		BTPesquisa.ForeColor = SystemColors.Control;
		BTPesquisa.Image = Resources.Pesquisar_32;
		BTPesquisa.Location = new Point(516, 395);
		BTPesquisa.Name = "BTPesquisa";
		BTPesquisa.Size = new Size(40, 40);
		BTPesquisa.TabIndex = 173;
		BTPesquisa.UseVisualStyleBackColor = true;
		Label2.AutoSize = true;
		Label2.BorderStyle = BorderStyle.Fixed3D;
		Label2.Location = new Point(6, 20);
		Label2.Name = "Label2";
		Label2.Size = new Size(41, 15);
		Label2.TabIndex = 174;
		Label2.Text = "Label2";
		TBPesquisa.Location = new Point(384, 406);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(126, 20);
		TBPesquisa.TabIndex = 168;
		LbFiltro.ImageAlign = ContentAlignment.TopCenter;
		LbFiltro.Location = new Point(384, 383);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(78, 20);
		LbFiltro.TabIndex = 169;
		LbFiltro.Text = "Filtro";
		LbFiltro.TextAlign = ContentAlignment.MiddleLeft;
		LBFabricante.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LBFabricante.Location = new Point(384, 68);
		LBFabricante.Name = "LBFabricante";
		LBFabricante.Size = new Size(175, 17);
		LBFabricante.TabIndex = 173;
		LBFabricante.Text = "LBFabricante";
		LBFabricante.TextAlign = ContentAlignment.BottomLeft;
		TBFabricante.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBFabricante.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBFabricante.Location = new Point(384, 89);
		TBFabricante.MaxLength = 250;
		TBFabricante.Name = "TBFabricante";
		TBFabricante.ReadOnly = true;
		TBFabricante.Size = new Size(247, 20);
		TBFabricante.TabIndex = 172;
		LBModelo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LBModelo.Location = new Point(381, 21);
		LBModelo.Name = "LBModelo";
		LBModelo.Size = new Size(175, 17);
		LBModelo.TabIndex = 171;
		LBModelo.Text = "LBModelo";
		LBModelo.TextAlign = ContentAlignment.BottomLeft;
		TBModelo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBModelo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBModelo.Location = new Point(384, 43);
		TBModelo.MaxLength = 250;
		TBModelo.Name = "TBModelo";
		TBModelo.ReadOnly = true;
		TBModelo.Size = new Size(247, 20);
		TBModelo.TabIndex = 170;
		LBDescCompleta.Location = new Point(384, 114);
		LBDescCompleta.Name = "LBDescCompleta";
		LBDescCompleta.Size = new Size(241, 17);
		LBDescCompleta.TabIndex = 144;
		LBDescCompleta.Text = "LBDescCompleta";
		LBDescCompleta.TextAlign = ContentAlignment.BottomLeft;
		btSeleciona.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.OK_32;
		btSeleciona.Location = new Point(585, 395);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(40, 40);
		btSeleciona.TabIndex = 145;
		btSeleciona.UseVisualStyleBackColor = true;
		DGMateriais.AllowUserToAddRows = false;
		DGMateriais.AllowUserToDeleteRows = false;
		DGMateriais.AllowUserToResizeColumns = false;
		DGMateriais.AllowUserToResizeRows = false;
		DGMateriais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGMateriais.BackgroundColor = SystemColors.ButtonHighlight;
		DGMateriais.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGMateriais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGMateriais.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGMateriais.Location = new Point(6, 43);
		DGMateriais.MultiSelect = false;
		DGMateriais.Name = "DGMateriais";
		DGMateriais.ReadOnly = true;
		DGMateriais.RowHeadersVisible = false;
		DGMateriais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGMateriais.Size = new Size(364, 392);
		DGMateriais.TabIndex = 118;
		TBDescCompleta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TBDescCompleta.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDescCompleta.Location = new Point(384, 134);
		TBDescCompleta.Multiline = true;
		TBDescCompleta.Name = "TBDescCompleta";
		TBDescCompleta.ReadOnly = true;
		TBDescCompleta.Size = new Size(247, 246);
		TBDescCompleta.TabIndex = 140;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(654, 461);
		Controls.Add(GroupBoxMateriais);
		MaximizeBox = false;
		MaximumSize = new Size(670, 500);
		MinimizeBox = false;
		MinimumSize = new Size(670, 500);
		Name = "frmPesquisaMateriais";
		ShowIcon = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Pesquisar Materiais";
		GroupBoxMateriais.ResumeLayout(performLayout: false);
		GroupBoxMateriais.PerformLayout();
		((ISupportInitialize)DGMateriais).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return M5EvLyIyLS;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		M5EvLyIyLS = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return qpRvw6fb7U;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		qpRvw6fb7U = WithEventsValue;
	}

	public frmPesquisaMateriais(int CodIntSel)
	{
		Resize += vwkvtSnv7U;
		NiivcEWQHi = false;
		if (Geral.ExisteForm("frmPesquisaMateriais"))
		{
			return;
		}
		iXdvHvhieF();
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		checked
		{
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1211]);
				GroupBoxMateriais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]);
				LBModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
				LBFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]);
				LBDescCompleta.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 247]);
				LbFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
				TBDescCompleta.Multiline = true;
				TBDescCompleta.AcceptsTab = true;
				cDadosLM cDadosLM2 = new cDadosLM();
				dDfvKQ2HAe = cDadosLM2.CarregaDadosLMMatriz();
				cDadosLM2.fechaConexao();
				DataGridView dg = DGMateriais;
				formataDG(ref dg);
				DGMateriais = dg;
				xK1vkMMZhe();
				Label2.Text = DGMateriais.RowCount.ToString();
				NiivcEWQHi = true;
				dg = DGMateriais;
				AtualizaColunasDGMateriais(ref dg);
				DGMateriais = dg;
				int num = DGMateriais.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.ConditionalCompareObjectEqual(DGMateriais.Rows[i].Cells[0].Value, CodIntSel, TextCompare: true))
					{
						DGMateriais.CurrentCell = DGMateriais[0, i];
						DGMateriais.Rows[i].Selected = true;
						DGMateriais.FirstDisplayedScrollingRowIndex = i;
						iGlvD9qymL();
						break;
					}
				}
				Application.ShowModalDialog((Form)this);
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
	}

	private void xK1vkMMZhe(string P_0 = "")
	{
		TBModelo.Text = "";
		TBFabricante.Text = "";
		TBDescCompleta.Text = "";
		int num = Information.UBound(dDfvKQ2HAe);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_0, "", TextCompare: true) != 0)
			{
				if (dDfvKQ2HAe[i].CodigoCliente.Contains(P_0) | dDfvKQ2HAe[i].Modelo.ToUpper().Contains(P_0) | dDfvKQ2HAe[i].Fabricante.ToUpper().Contains(P_0) | dDfvKQ2HAe[i].DescricaoResumida.ToUpper().Contains(P_0) | dDfvKQ2HAe[i].DescricaoCompleta.ToUpper().Contains(P_0))
				{
					DGMateriais.Rows.Add(dDfvKQ2HAe[i].CodigoInterno, dDfvKQ2HAe[i].CodigoCliente, dDfvKQ2HAe[i].Modelo, dDfvKQ2HAe[i].Fabricante, dDfvKQ2HAe[i].DescricaoResumida, dDfvKQ2HAe[i].DescricaoCompleta);
				}
			}
			else
			{
				DGMateriais.Rows.Add(dDfvKQ2HAe[i].CodigoInterno, dDfvKQ2HAe[i].CodigoCliente, dDfvKQ2HAe[i].Modelo, dDfvKQ2HAe[i].Fabricante, dDfvKQ2HAe[i].DescricaoResumida, dDfvKQ2HAe[i].DescricaoCompleta);
			}
		}
	}

	private void TlIvdKWLMY(object P_0, EventArgs P_1)
	{
		if (DGMateriais.SelectedRows.Count > 0)
		{
			MostraSelecionado();
		}
	}

	public void MostraSelecionado()
	{
		if (DGMateriais.SelectedRows.Count > 0 && NiivcEWQHi)
		{
			TBModelo.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[2].Value);
			TBFabricante.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[3].Value);
			TBDescCompleta.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[5].Value);
		}
	}

	private void Ug9vfouHs8(object P_0, EventArgs P_1)
	{
		iGlvD9qymL();
		Close();
	}

	private void iGlvD9qymL()
	{
		if (DGMateriais.SelectedRows.Count == 1)
		{
			codigoInterno = Conversions.ToInteger(DGMateriais.SelectedRows[0].Cells[0].Value);
			codigoCliente = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[1].Value);
			modelo = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[2].Value);
			fabricante = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[3].Value);
			descricaoResumida = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[4].Value);
			descricaoCompleta = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[5].Value);
		}
	}

	private void y8DvvE7015(object P_0, EventArgs P_1)
	{
		mdfv6TqulV();
	}

	private void mdfv6TqulV()
	{
		DataGridView dg = DGMateriais;
		formataDG(ref dg);
		DGMateriais = dg;
		xK1vkMMZhe(TBPesquisa.Text.ToUpper().Trim());
		Label2.Text = DGMateriais.RowCount.ToString();
		dg = DGMateriais;
		AtualizaColunasDGMateriais(ref dg);
		DGMateriais = dg;
	}

	public void formataDG(ref DataGridView dg)
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("CodigoInterno", "#");
		dg.Columns.Add("CodigoCliente", "CodigoCliente");
		dg.Columns.Add("Modelo", "Modelo");
		dg.Columns.Add("Fabricante", "Fabricante");
		dg.Columns.Add("DescricaoResumida", "DescricaoResumida");
		dg.Columns.Add("DescricaoCompleta", "DescricaoCompleta");
		dg.ColumnHeadersVisible = true;
	}

	public static void AtualizaColunasDGMateriais(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				dg.ColumnHeadersVisible = true;
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = (int)Math.Round(num * 0.2);
				dg.Columns[1].Width = 0;
				dg.Columns[2].Width = 0;
				dg.Columns[3].Width = 0;
				dg.Columns[4].Width = (int)Math.Round(num * 0.8);
				dg.Columns[5].Width = 0;
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[2].Visible = false;
				dg.Columns[3].Visible = false;
				dg.Columns[4].Visible = true;
				dg.Columns[5].Visible = false;
			}
			else
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
			}
		}
	}

	private void vwkvtSnv7U(object P_0, EventArgs P_1)
	{
		if (NiivcEWQHi)
		{
			DataGridView dg = DGMateriais;
			AtualizaColunasDGMateriais(ref dg);
			DGMateriais = dg;
		}
	}
}
