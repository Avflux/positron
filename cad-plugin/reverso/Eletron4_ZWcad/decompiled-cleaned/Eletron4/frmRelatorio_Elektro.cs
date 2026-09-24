using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Elektro : Form
{
	private IContainer OupxC1pmlw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button QI5xYFUmo7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaDWG")]
	private Button ONnxrYWBl0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip RLlx9N1Fo2;

	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView DIDxzTqZXD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDisp")]
	private DataGridView re0bWqBsic;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBTipo")]
	private ComboBox iT9bpc4iUa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbTipo")]
	private Label KDSbT0I17o;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRelatorio")]
	private DataGridView ixHbJaAoQS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBEntradaSaida")]
	private TextBox waUbhQyjNn;

	[AccessedThroughProperty("tbBornes")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox qsxbo21epq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricao")]
	[CompilerGenerated]
	private TextBox viKbGLtmb9;

	[CompilerGenerated]
	[AccessedThroughProperty("tbPagina")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox zYjbH3fPIt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbOBS")]
	private TextBox Cjgbk5UDLa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbModelo")]
	private TextBox eUBbdw72lZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagaRelatorio")]
	[CompilerGenerated]
	private Button VLkbfMX7P6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBCompleta")]
	[CompilerGenerated]
	private RadioButton nEKbDoo9e1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBResumida")]
	private RadioButton KBLbvge4t2;

	private int InWb6at2rS;

	private Declaracoes2.MModeloDePortas[] LYwbtZXxgf;

	private clsRelatorio_Elektro.mRelatElektro[] fXJbjoN9b7;

	private clsRelatorio_Elektro.mRelatElektro[] iE4bLZWD3y;

	private int zYcbw0hOqQ;

	private int FWYbxSxW6T;

	private string r14bbx1R50;

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return QI5xYFUmo7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ex3xAu1v8Y;
			Button button = QI5xYFUmo7;
			if (button != null)
			{
				button.Click -= value2;
			}
			QI5xYFUmo7 = value;
			button = QI5xYFUmo7;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportaDWG
	{
		[CompilerGenerated]
		get
		{
			return ONnxrYWBl0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KjqxB6PXRT;
			Button button = ONnxrYWBl0;
			if (button != null)
			{
				button.Click -= value2;
			}
			ONnxrYWBl0 = value;
			button = ONnxrYWBl0;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return DIDxzTqZXD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FRjxuLDi7U;
			DataGridView dataGridView = DIDxzTqZXD;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			DIDxzTqZXD = value;
			dataGridView = DIDxzTqZXD;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDisp
	{
		[CompilerGenerated]
		get
		{
			return re0bWqBsic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jACxZDi6Rf;
			DataGridView dataGridView = re0bWqBsic;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			re0bWqBsic = value;
			dataGridView = re0bWqBsic;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual ComboBox CBTipo
	{
		[CompilerGenerated]
		get
		{
			return iT9bpc4iUa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iT9bpc4iUa = value;
		}
	}

	internal virtual Label LbTipo
	{
		[CompilerGenerated]
		get
		{
			return KDSbT0I17o;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KDSbT0I17o = value;
		}
	}

	internal virtual DataGridView dgRelatorio
	{
		[CompilerGenerated]
		get
		{
			return ixHbJaAoQS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ixHbJaAoQS = value;
		}
	}

	internal virtual TextBox TBEntradaSaida
	{
		[CompilerGenerated]
		get
		{
			return waUbhQyjNn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			waUbhQyjNn = value;
		}
	}

	internal virtual TextBox tbBornes
	{
		[CompilerGenerated]
		get
		{
			return qsxbo21epq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qsxbo21epq = value;
		}
	}

	internal virtual TextBox tbDescricao
	{
		[CompilerGenerated]
		get
		{
			return viKbGLtmb9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			viKbGLtmb9 = value;
		}
	}

	internal virtual TextBox tbPagina
	{
		[CompilerGenerated]
		get
		{
			return zYjbH3fPIt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zYjbH3fPIt = value;
		}
	}

	internal virtual TextBox tbOBS
	{
		[CompilerGenerated]
		get
		{
			return Cjgbk5UDLa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Cjgbk5UDLa = value;
		}
	}

	internal virtual TextBox tbModelo
	{
		[CompilerGenerated]
		get
		{
			return eUBbdw72lZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eUBbdw72lZ = value;
		}
	}

	internal virtual Button btApagaRelatorio
	{
		[CompilerGenerated]
		get
		{
			return VLkbfMX7P6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TOOx44DWIZ;
			Button button = VLkbfMX7P6;
			if (button != null)
			{
				button.Click -= value2;
			}
			VLkbfMX7P6 = value;
			button = VLkbfMX7P6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton RBCompleta
	{
		[CompilerGenerated]
		get
		{
			return nEKbDoo9e1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nEKbDoo9e1 = value;
		}
	}

	internal virtual RadioButton RBResumida
	{
		[CompilerGenerated]
		get
		{
			return KBLbvge4t2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KBLbvge4t2 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && OupxC1pmlw != null)
			{
				OupxC1pmlw.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void hqsxgbwbGq()
	{
		OupxC1pmlw = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Elektro));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		btPesquisar = new Button();
		btExportaDWG = new Button();
		FDqpBiUmZij(new ToolTip(OupxC1pmlw));
		dgEquip = new DataGridView();
		dgDisp = new DataGridView();
		CBTipo = new ComboBox();
		LbTipo = new Label();
		dgRelatorio = new DataGridView();
		TBEntradaSaida = new TextBox();
		tbBornes = new TextBox();
		tbDescricao = new TextBox();
		tbPagina = new TextBox();
		tbOBS = new TextBox();
		tbModelo = new TextBox();
		btApagaRelatorio = new Button();
		RBCompleta = new RadioButton();
		RBResumida = new RadioButton();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		((ISupportInitialize)dgRelatorio).BeginInit();
		SuspendLayout();
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(538, 357);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExportaDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportaDWG.FlatStyle = FlatStyle.Flat;
		btExportaDWG.ForeColor = SystemColors.Control;
		btExportaDWG.Image = (Image)componentResourceManager.GetObject("btExportaDWG.Image");
		btExportaDWG.Location = new Point(632, 357);
		btExportaDWG.Name = "btExportaDWG";
		btExportaDWG.Size = new Size(40, 42);
		btExportaDWG.TabIndex = 40;
		btExportaDWG.UseVisualStyleBackColor = true;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 12);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(166, 122);
		dgEquip.TabIndex = 42;
		dgDisp.AllowUserToAddRows = false;
		dgDisp.AllowUserToDeleteRows = false;
		dgDisp.AllowUserToOrderColumns = true;
		dgDisp.AllowUserToResizeRows = false;
		dgDisp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		dgDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDisp.Location = new Point(12, 144);
		dgDisp.MultiSelect = false;
		dgDisp.Name = "dgDisp";
		dgDisp.ReadOnly = true;
		dgDisp.RowHeadersVisible = false;
		dgDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDisp.Size = new Size(166, 202);
		dgDisp.TabIndex = 43;
		CBTipo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CBTipo.FormattingEnabled = true;
		CBTipo.Location = new Point(12, 370);
		CBTipo.Name = "CBTipo";
		CBTipo.Size = new Size(80, 21);
		CBTipo.TabIndex = 178;
		LbTipo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbTipo.Location = new Point(12, 357);
		LbTipo.Name = "LbTipo";
		LbTipo.Size = new Size(64, 16);
		LbTipo.TabIndex = 177;
		LbTipo.Text = "lbTipo";
		dgRelatorio.AllowUserToAddRows = false;
		dgRelatorio.AllowUserToDeleteRows = false;
		dgRelatorio.AllowUserToOrderColumns = true;
		dgRelatorio.AllowUserToResizeRows = false;
		dgRelatorio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgRelatorio.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgRelatorio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgRelatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRelatorio.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRelatorio.Location = new Point(184, 64);
		dgRelatorio.MultiSelect = false;
		dgRelatorio.Name = "dgRelatorio";
		dgRelatorio.ReadOnly = true;
		dgRelatorio.RowHeadersVisible = false;
		dgRelatorio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRelatorio.Size = new Size(488, 282);
		dgRelatorio.TabIndex = 181;
		TBEntradaSaida.Location = new Point(184, 38);
		TBEntradaSaida.Name = "TBEntradaSaida";
		TBEntradaSaida.Size = new Size(71, 20);
		TBEntradaSaida.TabIndex = 203;
		tbBornes.Location = new Point(258, 38);
		tbBornes.Name = "tbBornes";
		tbBornes.Size = new Size(95, 20);
		tbBornes.TabIndex = 204;
		tbDescricao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tbDescricao.Location = new Point(356, 38);
		tbDescricao.Name = "tbDescricao";
		tbDescricao.Size = new Size(156, 20);
		tbDescricao.TabIndex = 205;
		tbPagina.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		tbPagina.Location = new Point(514, 38);
		tbPagina.Name = "tbPagina";
		tbPagina.Size = new Size(68, 20);
		tbPagina.TabIndex = 206;
		tbOBS.AcceptsReturn = true;
		tbOBS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		tbOBS.Location = new Point(584, 38);
		tbOBS.Name = "tbOBS";
		tbOBS.Size = new Size(88, 20);
		tbOBS.TabIndex = 207;
		tbModelo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tbModelo.Location = new Point(184, 12);
		tbModelo.Name = "tbModelo";
		tbModelo.Size = new Size(488, 20);
		tbModelo.TabIndex = 208;
		tbModelo.TextAlign = HorizontalAlignment.Center;
		btApagaRelatorio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btApagaRelatorio.FlatStyle = FlatStyle.Flat;
		btApagaRelatorio.ForeColor = SystemColors.Control;
		btApagaRelatorio.Image = Resources.Delete_32;
		btApagaRelatorio.Location = new Point(584, 357);
		btApagaRelatorio.Name = "btApagaRelatorio";
		btApagaRelatorio.Size = new Size(40, 42);
		btApagaRelatorio.TabIndex = 209;
		btApagaRelatorio.UseVisualStyleBackColor = true;
		RBCompleta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		RBCompleta.AutoSize = true;
		RBCompleta.Location = new Point(115, 377);
		RBCompleta.Name = "RBCompleta";
		RBCompleta.Size = new Size(97, 17);
		RBCompleta.TabIndex = 211;
		RBCompleta.TabStop = true;
		RBCompleta.Text = "Desc Completa";
		RBCompleta.UseVisualStyleBackColor = true;
		RBResumida.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		RBResumida.AutoSize = true;
		RBResumida.Location = new Point(115, 357);
		RBResumida.Name = "RBResumida";
		RBResumida.Size = new Size(100, 17);
		RBResumida.TabIndex = 210;
		RBResumida.TabStop = true;
		RBResumida.Text = "Desc Resumida";
		RBResumida.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(684, 411);
		Controls.Add(RBCompleta);
		Controls.Add(RBResumida);
		Controls.Add(btApagaRelatorio);
		Controls.Add(tbModelo);
		Controls.Add(tbOBS);
		Controls.Add(tbPagina);
		Controls.Add(tbDescricao);
		Controls.Add(tbBornes);
		Controls.Add(TBEntradaSaida);
		Controls.Add(dgRelatorio);
		Controls.Add(CBTipo);
		Controls.Add(LbTipo);
		Controls.Add(dgDisp);
		Controls.Add(dgEquip);
		Controls.Add(btExportaDWG);
		Controls.Add(btPesquisar);
		MinimumSize = new Size(700, 450);
		Name = "frmRelatorio_Elektro";
		ShowIcon = false;
		ShowInTaskbar = false;
		Text = "Relátório Elektro";
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		((ISupportInitialize)dgRelatorio).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return RLlx9N1Fo2;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		RLlx9N1Fo2 = WithEventsValue;
	}

	public frmRelatorio_Elektro()
	{
		Resize += pgUxSu8LwL;
		InWb6at2rS = 0;
		zYcbw0hOqQ = 0;
		FWYbxSxW6T = 0;
		r14bbx1R50 = "";
		try
		{
			if (Geral.ExisteForm("frmRelatorio_Elektro"))
			{
				return;
			}
			hqsxgbwbGq();
			if (!clsAuxiliar.BancoValido())
			{
				return;
			}
			RBCompleta.Enabled = true;
			RBResumida.Enabled = true;
			if (Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoCompleta, "", TextCompare: true) == 0)
			{
				RBCompleta.Enabled = false;
			}
			else
			{
				RBCompleta.Checked = true;
			}
			if (Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoResumida, "", TextCompare: true) == 0)
			{
				RBResumida.Enabled = false;
			}
			else
			{
				RBResumida.Checked = true;
			}
			if (!XDataGeral.LerXDataConfiguracaoListaDePontos())
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 281]), MsgBoxStyle.Information);
				return;
			}
			if (Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0)
			{
				if (!File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 282]), MsgBoxStyle.Information);
					return;
				}
				if (Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
					return;
				}
				XDataGeral.LerXDataConfiguracaoListaDePontos();
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				clsRelatorio_Elektro.PesquisaTodasAsPortasEDefinicoesUsadas(ref fXJbjoN9b7);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1674]);
				tbBornes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]);
				TBEntradaSaida.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 273]);
				tbDescricao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 64]);
				tbPagina.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 427]);
				tbOBS.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1670]);
				LbTipo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 262]);
				RBResumida.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
				RBCompleta.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 247]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
				Application.ShowModelessDialog((Form)this);
				BnlxVEfVZC();
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void Ex3xAu1v8Y(object P_0, EventArgs P_1)
	{
		GZYxsAl5qa();
	}

	private void GZYxsAl5qa()
	{
		string left = CBTipo.Text;
		if (Operators.CompareString(left, "EA", TextCompare: true) != 0 && Operators.CompareString(left, "ED", TextCompare: true) != 0 && Operators.CompareString(left, "DI", TextCompare: true) != 0 && Operators.CompareString(left, "AI", TextCompare: true) != 0)
		{
			if (Operators.CompareString(left, "SD", TextCompare: true) == 0 || Operators.CompareString(left, "SA", TextCompare: true) == 0 || Operators.CompareString(left, "DO", TextCompare: true) == 0 || Operators.CompareString(left, "AO", TextCompare: true) == 0)
			{
				TBEntradaSaida.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 210]);
			}
		}
		else
		{
			TBEntradaSaida.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 209]);
		}
		string right = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
		int num = 0;
		iE4bLZWD3y = new clsRelatorio_Elektro.mRelatElektro[1];
		string left2 = CBTipo.Text;
		formataDGRelatorio();
		clsRelatorio_Elektro.mRelatElektro[] array = fXJbjoN9b7;
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				clsRelatorio_Elektro.mRelatElektro mRelatElektro = array[i];
				if (Conversions.ToDouble(mRelatElektro.iPN) == (double)zYcbw0hOqQ && mRelatElektro.iIndexModelo == FWYbxSxW6T && Operators.CompareString(mRelatElektro.sNomeModelo, right, TextCompare: true) == 0 && (Operators.CompareString(left2, "", TextCompare: true) == 0 || Operators.CompareString(left2, mRelatElektro.sTipo, TextCompare: true) == 0))
				{
					string bornes = mRelatElektro.sTerminais;
					if (Operators.CompareString(mRelatElektro.sBornes, "", TextCompare: true) != 0)
					{
						bornes = mRelatElektro.sBornes;
					}
					if (Operators.CompareString(bornes, "", TextCompare: true) != 0)
					{
						CalculaTerminais(ref bornes);
					}
					num++;
					ref clsRelatorio_Elektro.mRelatElektro[] reference = ref iE4bLZWD3y;
					reference = (clsRelatorio_Elektro.mRelatElektro[])Utils.CopyArray(reference, new clsRelatorio_Elektro.mRelatElektro[num + 1]);
					iE4bLZWD3y[num] = mRelatElektro;
					if ((Operators.CompareString(mRelatElektro.sRegua, "", TextCompare: true) != 0) & (Operators.CompareString(mRelatElektro.sBornes, "", TextCompare: true) != 0))
					{
						bornes = mRelatElektro.sRegua + ":" + bornes;
					}
					iE4bLZWD3y[num].sBornes = bornes;
					if (!RBCompleta.Checked)
					{
						dgRelatorio.Rows.Add(mRelatElektro.sEFC, bornes, mRelatElektro.DescricaoR, mRelatElektro.sPaginaPorta, "");
					}
					else
					{
						dgRelatorio.Rows.Add(mRelatElektro.sEFC, bornes, mRelatElektro.DescricaoC, mRelatElektro.sPaginaPorta, "");
					}
				}
			}
			tbModelo.Text = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
			AtualizaDGRelatorio();
		}
	}

	private void KjqxB6PXRT(object P_0, EventArgs P_1)
	{
		if (Information.IsNothing(iE4bLZWD3y))
		{
			return;
		}
		string[] array = new string[1];
		array = (string[])Relatorios_GeralDWG.CapturaOsTextStyle();
		string sfonte = "";
		if (Information.UBound(array) > 0)
		{
			sfonte = array[1];
		}
		int num = Information.UBound(array);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(array[i].ToString().ToUpper(), "ROMANS", TextCompare: true) == 0)
			{
				sfonte = array[i];
			}
		}
		iE4bLZWD3y[0].sBornes = tbBornes.Text;
		iE4bLZWD3y[0].DescricaoC = tbDescricao.Text;
		iE4bLZWD3y[0].DescricaoR = tbDescricao.Text;
		iE4bLZWD3y[0].sEFC = TBEntradaSaida.Text;
		iE4bLZWD3y[0].sPaginaPorta = tbPagina.Text;
		iE4bLZWD3y[0].sHandlePorta = tbOBS.Text;
		clsRelatorio_Elektro.ConfElektro rel = default;
		rel.iColuna = 0;
		rel.iIndiceUnico = 0;
		rel.sDisp = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
		rel.iPainel = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		rel.sTipo = CBTipo.Text;
		rel.sUnidade = "";
		string text = clsRelatorio_Elektro.EncontraPotenciaisDWGElektro(rel);
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(rel.sDisp + " ", DeclaracoesGeral.mMensagem[1, 1837]), text), MsgBoxStyle.Information, "Elétron");
		}
		else
		{
			clsRelatorio_Elektro.CriaMatrizDePotenciaisDWG_OK(iE4bLZWD3y, sfonte, tbModelo.Text, ref rel, RBCompleta.Checked);
		}
	}

	public void CalculaTerminais(ref string bornes)
	{
		bornes = bornes.Replace("*", "");
		string[] array = bornes.Split(';');
		string text = "";
		int num = Information.UBound(array);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(text, "", TextCompare: true) != 0)
			{
				if (Operators.CompareString(array[i].ToString(), "", TextCompare: true) != 0)
				{
					text = text + "/" + array[i].ToString();
				}
			}
			else
			{
				text = array[i].ToString();
			}
		}
		bornes = text;
	}

	private void BnlxVEfVZC()
	{
		formataDGEquip();
		List<int> list = new List<int>();
		dgEquip.Rows.Clear();
		int num = Information.UBound(fXJbjoN9b7);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!list.Contains(Conversions.ToInteger(fXJbjoN9b7[i].iPN)))
			{
				try
				{
					dgEquip.Rows.Add(fXJbjoN9b7[i].iPN, fXJbjoN9b7[i].sPN);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				list.Add(Conversions.ToInteger(fXJbjoN9b7[i].iPN));
			}
			if ((i == Information.UBound(fXJbjoN9b7)) & (i > 1))
			{
				dgEquip.Rows[0].Selected = true;
				E4YxEir9BD();
			}
		}
		AtualizaDGEquip();
	}

	private void FRjxuLDi7U(object P_0, EventArgs P_1)
	{
		if (dgEquip.SelectedRows.Count > 0)
		{
			E4YxEir9BD();
		}
	}

	private void E4YxEir9BD()
	{
		formataDGDisp();
		List<string> list = new List<string>();
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		zYcbw0hOqQ = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		dgDisp.Rows.Clear();
		try
		{
			int num = Information.UBound(fXJbjoN9b7);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Conversions.ToDouble(fXJbjoN9b7[i].iPN) == (double)zYcbw0hOqQ && !list.Contains(fXJbjoN9b7[i].sNomeModelo))
				{
					dgDisp.Rows.Add(fXJbjoN9b7[i].iIndexModelo, fXJbjoN9b7[i].sNomeModelo);
					list.Add(fXJbjoN9b7[i].sNomeModelo);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		AtualizaDGEquip();
		if (dgDisp.Rows.Count > 0)
		{
			hcuxiO0DKp();
		}
	}

	private void jACxZDi6Rf(object P_0, EventArgs P_1)
	{
		if (dgDisp.Rows.Count > 0)
		{
			hcuxiO0DKp();
		}
		GZYxsAl5qa();
	}

	private void hcuxiO0DKp()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		if (dgDisp.SelectedRows.Count == 0)
		{
			return;
		}
		zYcbw0hOqQ = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		FWYbxSxW6T = Conversions.ToInteger(dgDisp.SelectedRows[0].Cells[0].Value);
		r14bbx1R50 = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
		try
		{
			int num = Information.UBound(fXJbjoN9b7);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if ((Conversions.ToDouble(fXJbjoN9b7[i].iPN) == (double)zYcbw0hOqQ) & (fXJbjoN9b7[i].iIndexModelo == FWYbxSxW6T) & (Operators.CompareString(fXJbjoN9b7[i].sNomeModelo, r14bbx1R50, TextCompare: true) == 0))
				{
					fXJbjoN9b7[i].sTipo = clsTextos.TiraNothing(fXJbjoN9b7[i].sTipo);
					if (!list.Contains(fXJbjoN9b7[i].sTipo))
					{
						list.Add(fXJbjoN9b7[i].sTipo);
					}
					fXJbjoN9b7[i].sUnidade = clsTextos.TiraNothing(fXJbjoN9b7[i].sUnidade);
					if (!list2.Contains(fXJbjoN9b7[i].sUnidade))
					{
						list2.Add(fXJbjoN9b7[i].sUnidade);
					}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		CBTipo.Text = "";
		list.Sort();
		CBTipo.Items.Clear();
		foreach (string item in list)
		{
			CBTipo.Items.Add(item);
			if (Operators.CompareString(item, "", TextCompare: true) == 0)
			{
				CBTipo.Text = item;
			}
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
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			AtualizaDGEquip();
		}
	}

	public void AtualizaDGEquip()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip)) ? ((double)(dgEquip.Width - 4)) : ((double)(dgEquip.Width - 21)));
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(a);
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
	}

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				dgDisp.Rows.Clear();
				dgDisp.Columns.Clear();
				dgDisp.Columns.Add("", "Indice");
				dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 804]));
				int num = dgDisp.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDisp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			AtualizaDGDisp();
		}
	}

	public void AtualizaDGDisp()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDisp)) ? ((double)(dgDisp.Width - 4)) : ((double)(dgDisp.Width - 21)));
				dgDisp.Columns[0].Width = 0;
				dgDisp.Columns[0].Visible = false;
				dgDisp.Columns[1].Width = (int)Math.Round(a);
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
	}

	public void formataDGRelatorio()
	{
		checked
		{
			try
			{
				dgRelatorio.Rows.Clear();
				dgRelatorio.Columns.Clear();
				dgRelatorio.Columns.Add("", TBEntradaSaida.Text);
				dgRelatorio.Columns.Add("", tbBornes.Text);
				dgRelatorio.Columns.Add("", tbDescricao.Text);
				dgRelatorio.Columns.Add("", tbPagina.Text);
				dgRelatorio.Columns.Add("", tbOBS.Text);
				int num = dgRelatorio.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgRelatorio.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				dgRelatorio.ColumnHeadersVisible = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			AtualizaDGRelatorio();
		}
	}

	public void AtualizaDGRelatorio()
	{
		checked
		{
			try
			{
				if (dgRelatorio.Columns.Count != 0)
				{
					double num = dgRelatorio.Width - 21;
					int num2 = 0;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRelatorio))
					{
						num2 = 17;
					}
					if (!(num > 310.0))
					{
						dgRelatorio.Columns[0].Width = (int)Math.Round(num * 0.1);
						dgRelatorio.Columns[1].Width = (int)Math.Round(num * 0.15);
						dgRelatorio.Columns[2].Width = (int)Math.Round(num * 0.55);
						dgRelatorio.Columns[3].Width = (int)Math.Round(num * 0.1);
						dgRelatorio.Columns[4].Width = (int)Math.Round((double)num2 + num * 0.1);
					}
					else
					{
						num -= 310.0;
						dgRelatorio.Columns[0].Width = 70;
						dgRelatorio.Columns[1].Width = 100;
						dgRelatorio.Columns[2].Width = (int)Math.Round(num);
						dgRelatorio.Columns[3].Width = 70;
						dgRelatorio.Columns[4].Width = 70 + num2;
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
			}
		}
	}

	private void pgUxSu8LwL(object P_0, EventArgs P_1)
	{
		AtualizaDGRelatorio();
	}

	private void TOOx44DWIZ(object P_0, EventArgs P_1)
	{
		clsRelatorio_Elektro.ConfElektro relDEL = default;
		relDEL.iColuna = 0;
		relDEL.iIndiceUnico = 0;
		relDEL.sDisp = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
		relDEL.iPainel = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		relDEL.sTipo = CBTipo.Text;
		relDEL.sUnidade = "";
		string pag = clsRelatorio_Elektro.ApagaPotenciaisDWGElektro(relDEL);
		if (Operators.CompareString(pag, "", TextCompare: true) != 0)
		{
			Pagina.AtivaPagina(pag);
			DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
		}
	}
}
