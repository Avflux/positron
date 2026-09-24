using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_InterligacaoEletroSul_Excel : Form
{
	public struct ConfRelelatorioExcel
	{
		public string Desc1;

		public string Desc_2;

		public string NumDesenho;

		public string sRev;

		public double LinhasPorPagina;

		public bool bPagina;

		public string Prefixo;

		public string Sufixo;

		public string sCaminhoDesenho;

		public string sNomeSheet;
	}

	private IContainer Udw741c0hm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbLinhasPorPaginaSul")]
	private TextBox GHa7ChKFQS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDesc1")]
	[CompilerGenerated]
	private Label gMR7YaInak;

	[CompilerGenerated]
	[AccessedThroughProperty("btExportaEXCELELETROSUL")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button SZZ7rltfQp;

	[AccessedThroughProperty("tbDesc1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox NS979TP163;

	[CompilerGenerated]
	[AccessedThroughProperty("lbLinhas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label gSA7zdemSL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNumDesenho")]
	private TextBox CCCqWnsjoG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbNumDesenho")]
	private Label cDIqp6SgJa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPaginaInicio")]
	[CompilerGenerated]
	private TextBox zx6qTmtNxg;

	[CompilerGenerated]
	[AccessedThroughProperty("lbPaginas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label tmOqJEKDlX;

	[CompilerGenerated]
	[AccessedThroughProperty("tbRev")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox meCqhSIvuP;

	[AccessedThroughProperty("lbRev")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label LuLqoEA0Ye;

	[AccessedThroughProperty("tbCaminho")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox pf6qG7LPLT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbImagem")]
	private Label MFGqHubYLp;

	[CompilerGenerated]
	[AccessedThroughProperty("btSelecionaImagem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button fJNqkDKCAo;

	[AccessedThroughProperty("btModeloExcel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button geJqdvtKf6;

	[CompilerGenerated]
	[AccessedThroughProperty("btParar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button AAmqfdHJTQ;

	private ConfRelelatorioExcel wSyqDB6DsN;

	private Relatorios_InterligacaoExcelEletroSul.structureRelInterligacao[] x1lqvGiWCv;

	private string jvwq6VZ4WU;

	private ColorDialog HjNqtiUBPL;

	private Declaracoes2.StructureIndiceRelatEletroSul[] hsCqjvxXYU;

	private int CboqL8s8pK;

	private string Da7qwViee3;

	private bool gRxqxyceyy;

	private bool A9JqbDKs57;

	private bool MnUqMQKD3h;

	private bool kuhqO5RVL5;

	private bool XplqI0CwQa;

	private string zw1q7lFkGZ;

	private bool tHlqqEvufv;

	private DeclaracoesInterligacao.reservaRI[] awNqaFdk0A;

	private DeclaracoesInterligacao.reservaRI[] WqSq8RvZA9;

	private List<string> ctBqN94HQD;

	internal virtual TextBox tbLinhasPorPaginaSul
	{
		[CompilerGenerated]
		get
		{
			return GHa7ChKFQS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = toA7ujuBub;
			TextBox textBox = GHa7ChKFQS;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			GHa7ChKFQS = value;
			textBox = GHa7ChKFQS;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label lbDesc1
	{
		[CompilerGenerated]
		get
		{
			return gMR7YaInak;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gMR7YaInak = value;
		}
	}

	internal virtual Button btExportaEXCELELETROSUL
	{
		[CompilerGenerated]
		get
		{
			return SZZ7rltfQp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VNj7S39YJl;
			Button button = SZZ7rltfQp;
			if (button != null)
			{
				button.Click -= value2;
			}
			SZZ7rltfQp = value;
			button = SZZ7rltfQp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbDesc1
	{
		[CompilerGenerated]
		get
		{
			return NS979TP163;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NS979TP163 = value;
		}
	}

	internal virtual Label lbLinhas
	{
		[CompilerGenerated]
		get
		{
			return gSA7zdemSL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gSA7zdemSL = value;
		}
	}

	internal virtual TextBox tbNumDesenho
	{
		[CompilerGenerated]
		get
		{
			return CCCqWnsjoG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CCCqWnsjoG = value;
		}
	}

	internal virtual Label lbNumDesenho
	{
		[CompilerGenerated]
		get
		{
			return cDIqp6SgJa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cDIqp6SgJa = value;
		}
	}

	internal virtual TextBox tbPaginaInicio
	{
		[CompilerGenerated]
		get
		{
			return zx6qTmtNxg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zx6qTmtNxg = value;
		}
	}

	internal virtual Label lbPaginas
	{
		[CompilerGenerated]
		get
		{
			return tmOqJEKDlX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tmOqJEKDlX = value;
		}
	}

	internal virtual TextBox tbRev
	{
		[CompilerGenerated]
		get
		{
			return meCqhSIvuP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			meCqhSIvuP = value;
		}
	}

	internal virtual Label lbRev
	{
		[CompilerGenerated]
		get
		{
			return LuLqoEA0Ye;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LuLqoEA0Ye = value;
		}
	}

	internal virtual TextBox tbCaminho
	{
		[CompilerGenerated]
		get
		{
			return pf6qG7LPLT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pf6qG7LPLT = value;
		}
	}

	internal virtual Label lbImagem
	{
		[CompilerGenerated]
		get
		{
			return MFGqHubYLp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MFGqHubYLp = value;
		}
	}

	internal virtual Button btSelecionaImagem
	{
		[CompilerGenerated]
		get
		{
			return fJNqkDKCAo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VEV7EJIeKa;
			Button button = fJNqkDKCAo;
			if (button != null)
			{
				button.Click -= value2;
			}
			fJNqkDKCAo = value;
			button = fJNqkDKCAo;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btModeloExcel
	{
		[CompilerGenerated]
		get
		{
			return geJqdvtKf6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gjf7ZdjX92;
			Button button = geJqdvtKf6;
			if (button != null)
			{
				button.Click -= value2;
			}
			geJqdvtKf6 = value;
			button = geJqdvtKf6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btParar
	{
		[CompilerGenerated]
		get
		{
			return AAmqfdHJTQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = m7F7iepykr;
			Button button = AAmqfdHJTQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			AAmqfdHJTQ = value;
			button = AAmqfdHJTQ;
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
			if (disposing && Udw741c0hm != null)
			{
				Udw741c0hm.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void TG27BEFCQg()
	{
		tbLinhasPorPaginaSul = new TextBox();
		lbDesc1 = new Label();
		btParar = new Button();
		btModeloExcel = new Button();
		lbLinhas = new Label();
		btSelecionaImagem = new Button();
		tbCaminho = new TextBox();
		lbImagem = new Label();
		tbRev = new TextBox();
		lbRev = new Label();
		tbPaginaInicio = new TextBox();
		lbPaginas = new Label();
		btExportaEXCELELETROSUL = new Button();
		tbDesc1 = new TextBox();
		lbNumDesenho = new Label();
		tbNumDesenho = new TextBox();
		SuspendLayout();
		tbLinhasPorPaginaSul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbLinhasPorPaginaSul.Location = new Point(102, 88);
		tbLinhasPorPaginaSul.Name = "tbLinhasPorPaginaSul";
		tbLinhasPorPaginaSul.Size = new Size(80, 20);
		tbLinhasPorPaginaSul.TabIndex = 69;
		tbLinhasPorPaginaSul.TextAlign = HorizontalAlignment.Center;
		lbDesc1.Location = new Point(12, 18);
		lbDesc1.Name = "lbDesc1";
		lbDesc1.Size = new Size(64, 25);
		lbDesc1.TabIndex = 70;
		lbDesc1.Text = "Descição 1";
		lbDesc1.TextAlign = ContentAlignment.MiddleLeft;
		btParar.FlatStyle = FlatStyle.Flat;
		btParar.ForeColor = SystemColors.Control;
		btParar.Image = Resources.Stop_32;
		btParar.Location = new Point(121, 189);
		btParar.Name = "btParar";
		btParar.Size = new Size(40, 42);
		btParar.TabIndex = 105;
		btParar.UseVisualStyleBackColor = true;
		btModeloExcel.FlatStyle = FlatStyle.Flat;
		btModeloExcel.ForeColor = SystemColors.Control;
		btModeloExcel.Image = Resources.ModeloExcel_32;
		btModeloExcel.Location = new Point(34, 188);
		btModeloExcel.Name = "btModeloExcel";
		btModeloExcel.Size = new Size(40, 42);
		btModeloExcel.TabIndex = 115;
		btModeloExcel.UseVisualStyleBackColor = true;
		lbLinhas.Location = new Point(82, 68);
		lbLinhas.Name = "lbLinhas";
		lbLinhas.Size = new Size(117, 17);
		lbLinhas.TabIndex = 102;
		lbLinhas.Text = "Linhas por Página";
		lbLinhas.TextAlign = ContentAlignment.MiddleCenter;
		btSelecionaImagem.FlatStyle = FlatStyle.Flat;
		btSelecionaImagem.ForeColor = SystemColors.Control;
		btSelecionaImagem.Image = Resources.Pesquisar_16;
		btSelecionaImagem.Location = new Point(249, 144);
		btSelecionaImagem.Name = "btSelecionaImagem";
		btSelecionaImagem.Size = new Size(23, 23);
		btSelecionaImagem.TabIndex = 114;
		btSelecionaImagem.UseVisualStyleBackColor = true;
		tbCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCaminho.Location = new Point(15, 129);
		tbCaminho.Multiline = true;
		tbCaminho.Name = "tbCaminho";
		tbCaminho.Size = new Size(228, 51);
		tbCaminho.TabIndex = 111;
		lbImagem.Location = new Point(15, 111);
		lbImagem.Name = "lbImagem";
		lbImagem.Size = new Size(231, 15);
		lbImagem.TabIndex = 112;
		lbImagem.Text = "Imagem";
		lbImagem.TextAlign = ContentAlignment.MiddleLeft;
		tbRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbRev.Location = new Point(16, 88);
		tbRev.Name = "tbRev";
		tbRev.Size = new Size(80, 20);
		tbRev.TabIndex = 109;
		tbRev.TextAlign = HorizontalAlignment.Center;
		lbRev.Location = new Point(31, 70);
		lbRev.Name = "lbRev";
		lbRev.Size = new Size(54, 15);
		lbRev.TabIndex = 110;
		lbRev.Text = "sRev";
		lbRev.TextAlign = ContentAlignment.MiddleCenter;
		tbPaginaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPaginaInicio.Location = new Point(188, 88);
		tbPaginaInicio.Name = "tbPaginaInicio";
		tbPaginaInicio.Size = new Size(80, 20);
		tbPaginaInicio.TabIndex = 105;
		tbPaginaInicio.TextAlign = HorizontalAlignment.Center;
		lbPaginas.Location = new Point(205, 70);
		lbPaginas.Name = "lbPaginas";
		lbPaginas.Size = new Size(52, 15);
		lbPaginas.TabIndex = 106;
		lbPaginas.Text = "Páginas";
		lbPaginas.TextAlign = ContentAlignment.MiddleCenter;
		btExportaEXCELELETROSUL.FlatStyle = FlatStyle.Flat;
		btExportaEXCELELETROSUL.ForeColor = SystemColors.Control;
		btExportaEXCELELETROSUL.Image = Resources.ExportaExcel_20;
		btExportaEXCELELETROSUL.Location = new Point(217, 189);
		btExportaEXCELELETROSUL.Name = "btExportaEXCELELETROSUL";
		btExportaEXCELELETROSUL.Size = new Size(40, 43);
		btExportaEXCELELETROSUL.TabIndex = 100;
		btExportaEXCELELETROSUL.UseVisualStyleBackColor = true;
		tbDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDesc1.Location = new Point(76, 18);
		tbDesc1.Name = "tbDesc1";
		tbDesc1.Size = new Size(196, 20);
		tbDesc1.TabIndex = 101;
		tbDesc1.TextAlign = HorizontalAlignment.Center;
		lbNumDesenho.Location = new Point(12, 45);
		lbNumDesenho.Name = "lbNumDesenho";
		lbNumDesenho.Size = new Size(64, 25);
		lbNumDesenho.TabIndex = 99;
		lbNumDesenho.Text = "Desenho";
		lbNumDesenho.TextAlign = ContentAlignment.MiddleLeft;
		tbNumDesenho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNumDesenho.Location = new Point(76, 45);
		tbNumDesenho.Name = "tbNumDesenho";
		tbNumDesenho.Size = new Size(196, 20);
		tbNumDesenho.TabIndex = 98;
		tbNumDesenho.TextAlign = HorizontalAlignment.Center;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(290, 246);
		Controls.Add(btParar);
		Controls.Add(btModeloExcel);
		Controls.Add(lbLinhas);
		Controls.Add(lbDesc1);
		Controls.Add(btSelecionaImagem);
		Controls.Add(tbNumDesenho);
		Controls.Add(tbCaminho);
		Controls.Add(lbNumDesenho);
		Controls.Add(lbImagem);
		Controls.Add(tbLinhasPorPaginaSul);
		Controls.Add(tbRev);
		Controls.Add(tbDesc1);
		Controls.Add(lbRev);
		Controls.Add(btExportaEXCELELETROSUL);
		Controls.Add(lbPaginas);
		Controls.Add(tbPaginaInicio);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmRelatorio_InterligacaoEletroSul_Excel";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Relatório de Inteligação EletroSul EXCEL";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmRelatorio_InterligacaoEletroSul_Excel(string revisaoSel, Relatorios_InterligacaoExcelEletroSul.structureRelInterligacao[] mInterligacao, int iPnSel, string sQuantLinhas, bool bformacao, bool bFuncao, bool bDocumento, string sOpcional, bool bOpcional, bool bTrajeto, bool bReserva, DeclaracoesInterligacao.reservaRI[] mAterrados, DeclaracoesInterligacao.reservaRI[] mNaoAterrados)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		jvwq6VZ4WU = "";
		HjNqtiUBPL = new ColorDialog();
		hsCqjvxXYU = null;
		CboqL8s8pK = 1;
		ctBqN94HQD = new List<string>();
		TG27BEFCQg();
		x1lqvGiWCv = mInterligacao;
		Da7qwViee3 = Dicionario.BuscaNomeDoPainel(iPnSel);
		gRxqxyceyy = bformacao;
		A9JqbDKs57 = bFuncao;
		kuhqO5RVL5 = bDocumento;
		MnUqMQKD3h = bTrajeto;
		XplqI0CwQa = bReserva;
		zw1q7lFkGZ = sOpcional;
		tHlqqEvufv = bOpcional;
		awNqaFdk0A = mAterrados;
		WqSq8RvZA9 = mNaoAterrados;
		tbLinhasPorPaginaSul.Text = sQuantLinhas;
		tbNumDesenho.Text = DeclaracoesGeral.Conf.Local;
		tbRev.Text = revisaoSel;
		lbDesc1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 805]);
		lbNumDesenho.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1158]);
		lbRev.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]);
		lbLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1151]);
		lbPaginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]);
		lbImagem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1159]);
		Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1416]);
		tbDesc1.Text = Da7qwViee3;
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		string text = "CAPA";
		int num = 1;
		int num2 = 0;
		checked
		{
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, text))
			{
				ref Declaracoes2.StructureIndiceRelatEletroSul[] reference = ref hsCqjvxXYU;
				reference = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(reference, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
				hsCqjvxXYU[num2].sFolha = num.ToString();
				hsCqjvxXYU[num2].sDescricao = text;
				num2++;
				num++;
			}
			text = "INDICE";
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, text))
			{
				ref Declaracoes2.StructureIndiceRelatEletroSul[] reference2 = ref hsCqjvxXYU;
				reference2 = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(reference2, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
				hsCqjvxXYU[num2].sFolha = num.ToString();
				hsCqjvxXYU[num2].sDescricao = text;
			}
			tbPaginaInicio.Text = "1";
			if (num2 > 1)
			{
				tbPaginaInicio.Text = Conversions.ToString(Conversions.ToInteger(hsCqjvxXYU[num2].sFolha) + 1);
			}
			tbCaminho.Text = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "EletrosulRelatorio.png";
			tbCaminho.BackColor = Color.White;
			if (Operators.CompareString(tbCaminho.Text, "", TextCompare: true) != 0 && !File.Exists(tbCaminho.Text))
			{
				tbCaminho.BackColor = Color.LightCoral;
			}
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	private short zny7VZA3uJ()
	{
		DialogResult dialogResult = HjNqtiUBPL.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return HjNqtiUBPL.Color.ColorIndex;
	}

	private void toA7ujuBub(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void VEV7EJIeKa(object P_0, EventArgs P_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptOpenFileOptions val = new PromptOpenFileOptions(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1160]));
		((PromptFileOptions)val).InitialDirectory = "C:\\";
		((PromptFileOptions)val).Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*";
		PromptFileNameResult fileNameForOpen = editor.GetFileNameForOpen(val);
		PromptStatus status = ((PromptResult)fileNameForOpen).Status;
		if ((int)status != -5002 && (int)status == 5100)
		{
			tbCaminho.Text = ((PromptResult)fileNameForOpen).StringResult;
			tbCaminho.BackColor = Color.White;
			if (Operators.CompareString(tbCaminho.Text, "", TextCompare: true) != 0 && !File.Exists(tbCaminho.Text))
			{
				tbCaminho.BackColor = Color.LightCoral;
			}
		}
	}

	private void gjf7ZdjX92(object P_0, EventArgs P_1)
	{
		string sCaminho = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Eletron4\\Modelos\\Modelo Interligação.xls";
		ExcFuncoesExcel.FechaExcelOculto();
		ExcFuncoesExcel.AbreExcelExterno(sCaminho);
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		string text = "CAPA";
		int num = 1;
		int num2 = 0;
		checked
		{
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, text))
			{
				ref Declaracoes2.StructureIndiceRelatEletroSul[] reference = ref hsCqjvxXYU;
				reference = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(reference, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
				hsCqjvxXYU[num2].sFolha = num.ToString();
				hsCqjvxXYU[num2].sDescricao = text;
				num2++;
				num++;
			}
			text = "INDICE";
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, text))
			{
				num2++;
				num++;
				ref Declaracoes2.StructureIndiceRelatEletroSul[] reference2 = ref hsCqjvxXYU;
				reference2 = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(reference2, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
				hsCqjvxXYU[num2].sFolha = num.ToString();
				hsCqjvxXYU[num2].sDescricao = text;
			}
			tbPaginaInicio.Text = "1";
			if (num2 > 1)
			{
				tbPaginaInicio.Text = Conversions.ToString(Conversions.ToInteger(hsCqjvxXYU[num2].sFolha) + 1);
			}
		}
	}

	private void m7F7iepykr(object P_0, EventArgs P_1)
	{
		btExportaEXCELELETROSUL.Enabled = true;
		DeclaracoesGeral.bPararRelatorio = true;
		System.Windows.Forms.Application.DoEvents();
	}

	private void VNj7S39YJl(object P_0, EventArgs P_1)
	{
		ctBqN94HQD.Clear();
		DeclaracoesGeral.bPararRelatorio = false;
		btExportaEXCELELETROSUL.Enabled = false;
		int num = 9;
		checked
		{
			if (gRxqxyceyy)
			{
				num++;
			}
			if (A9JqbDKs57)
			{
				num++;
			}
			if (kuhqO5RVL5)
			{
				num++;
			}
			if (Operators.ConditionalCompareObjectNotEqual(zw1q7lFkGZ, "", TextCompare: true))
			{
				num++;
			}
			if (MnUqMQKD3h)
			{
				num++;
			}
			string sMaxColuna = ExcFuncoesExcel.mudaNumeroAsc(num);
			string sMaxQuebra = ExcFuncoesExcel.mudaNumeroAsc(num + 1);
			int num2 = 0;
			hsCqjvxXYU = new Declaracoes2.StructureIndiceRelatEletroSul[1];
			num2 = 1;
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Worksheet oSheet = null;
			string text = "CAPA";
			int num3 = 1;
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, text))
			{
				ref Declaracoes2.StructureIndiceRelatEletroSul[] reference = ref hsCqjvxXYU;
				reference = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(reference, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
				hsCqjvxXYU[num2].sFolha = num3.ToString();
				hsCqjvxXYU[num2].sDescricao = text;
				num2++;
				num3++;
			}
			text = "INDICE";
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, text))
			{
				ref Declaracoes2.StructureIndiceRelatEletroSul[] reference2 = ref hsCqjvxXYU;
				reference2 = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(reference2, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
				hsCqjvxXYU[num2].sFolha = num3.ToString();
				hsCqjvxXYU[num2].sDescricao = text;
			}
			tbPaginaInicio.Text = "1";
			if (num2 > 1)
			{
				tbPaginaInicio.Text = Conversions.ToString(Conversions.ToInteger(hsCqjvxXYU[num2].sFolha) + 1);
			}
			wSyqDB6DsN.Desc1 = tbDesc1.Text;
			wSyqDB6DsN.NumDesenho = tbNumDesenho.Text;
			wSyqDB6DsN.sRev = tbRev.Text;
			wSyqDB6DsN.LinhasPorPagina = Conversions.ToInteger(tbLinhasPorPaginaSul.Text);
			wSyqDB6DsN.Prefixo = tbPaginaInicio.Text;
			wSyqDB6DsN.sCaminhoDesenho = tbCaminho.Text;
			Relatorios_InterligacaoExcelEletroSul.CriaMatrizInterligacaoExcel(ref ctBqN94HQD, x1lqvGiWCv, Da7qwViee3, (int)Math.Round(wSyqDB6DsN.LinhasPorPagina), gRxqxyceyy, A9JqbDKs57, kuhqO5RVL5, XplqI0CwQa, Conversions.ToString(zw1q7lFkGZ), tHlqqEvufv, MnUqMQKD3h, awNqaFdk0A, WqSq8RvZA9, sMaxColuna, sMaxQuebra, ref hsCqjvxXYU, bRodape: true, wSyqDB6DsN);
			Relatorios_ExcelComum_EletroSul.preencheIndiceInterligacaoExcel(ref hsCqjvxXYU, jvwq6VZ4WU, wSyqDB6DsN.sRev, "", Conversions.ToString(Value: false), ref CboqL8s8pK);
			Relatorios_ExcelComum_EletroSul.preencheIndiceComumExcel("INDICE", Da7qwViee3, tbDesc1.Text, "", "", wSyqDB6DsN.sRev, "Num. Des. " + tbNumDesenho.Text, hsCqjvxXYU[Information.UBound(hsCqjvxXYU)].sFolha, 50, 65);
			Relatorios_ExcelComum_EletroSul.preencheIndiceComumExcel("CAPA", Da7qwViee3, tbDesc1.Text, "", "", wSyqDB6DsN.sRev, tbNumDesenho.Text, "'1/" + hsCqjvxXYU[Information.UBound(hsCqjvxXYU)].sFolha, 55, 65);
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
			btExportaEXCELELETROSUL.Enabled = true;
		}
	}
}
