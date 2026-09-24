using System;
using System.Collections;
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
public class frmMigraBornes : Form
{
	private IContainer OXJDwmt2QT;

	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog IdMDxdPkMt;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip n2ODb6csev;

	[AccessedThroughProperty("btSelecionarBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button P2CDMZXGWP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornesSelecionados")]
	[CompilerGenerated]
	private DataGridView xR9DOy6Dtt;

	[AccessedThroughProperty("LabelPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label sNcDIdGJ9e;

	[AccessedThroughProperty("dgNovaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView iAPD7JvPK2;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelPainel2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label MooDq4iR36;

	[AccessedThroughProperty("btMigrar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button dHCDa04oCl;

	private DeclaracoesEntidades.StructureBorne[] HLrD8LGM6D;

	private Declaracoes2.StructureModeloDeReguas[] zkdDNKAoLO;

	private DeclaracoesEntidades.StructureBorne[] KEXDF9qqlw;

	private List<string> uyBDQfIwAt;

	private double fwCDPGVBv1;

	private string DtFDcTOmTl;

	private int rYVDKtweBZ;

	private int bNqDeRiox8;

	internal virtual Button btSelecionarBornes
	{
		[CompilerGenerated]
		get
		{
			return P2CDMZXGWP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iX2DvPKHXD;
			Button button = P2CDMZXGWP;
			if (button != null)
			{
				button.Click -= value2;
			}
			P2CDMZXGWP = value;
			button = P2CDMZXGWP;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgBornesSelecionados
	{
		[CompilerGenerated]
		get
		{
			return xR9DOy6Dtt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FhVDLJJaJS;
			DataGridView dataGridView = xR9DOy6Dtt;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			xR9DOy6Dtt = value;
			dataGridView = xR9DOy6Dtt;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Label LabelPainel
	{
		[CompilerGenerated]
		get
		{
			return sNcDIdGJ9e;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sNcDIdGJ9e = value;
		}
	}

	internal virtual DataGridView dgNovaRegua
	{
		[CompilerGenerated]
		get
		{
			return iAPD7JvPK2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = VBlD6VxG4G;
			DataGridView dataGridView = iAPD7JvPK2;
			if (dataGridView != null)
			{
				dataGridView.CellMouseUp -= value2;
			}
			iAPD7JvPK2 = value;
			dataGridView = iAPD7JvPK2;
			if (dataGridView != null)
			{
				dataGridView.CellMouseUp += value2;
			}
		}
	}

	internal virtual Label LabelPainel2
	{
		[CompilerGenerated]
		get
		{
			return MooDq4iR36;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MooDq4iR36 = value;
		}
	}

	internal virtual Button btMigrar
	{
		[CompilerGenerated]
		get
		{
			return dHCDa04oCl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eClDtKxaTq;
			Button button = dHCDa04oCl;
			if (button != null)
			{
				button.Click -= value2;
			}
			dHCDa04oCl = value;
			button = dHCDa04oCl;
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
			if (disposing && OXJDwmt2QT != null)
			{
				OXJDwmt2QT.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void cufDDIKw6O()
	{
		OXJDwmt2QT = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(OXJDwmt2QT));
		btSelecionarBornes = new Button();
		dgBornesSelecionados = new DataGridView();
		LabelPainel = new Label();
		dgNovaRegua = new DataGridView();
		LabelPainel2 = new Label();
		btMigrar = new Button();
		((ISupportInitialize)dgBornesSelecionados).BeginInit();
		((ISupportInitialize)dgNovaRegua).BeginInit();
		SuspendLayout();
		btSelecionarBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSelecionarBornes.FlatStyle = FlatStyle.Flat;
		btSelecionarBornes.ForeColor = SystemColors.Control;
		btSelecionarBornes.Image = Resources.Select_32;
		btSelecionarBornes.Location = new Point(90, 413);
		btSelecionarBornes.Name = "btSelecionarBornes";
		btSelecionarBornes.Size = new Size(40, 40);
		btSelecionarBornes.TabIndex = 153;
		btSelecionarBornes.UseVisualStyleBackColor = true;
		dgBornesSelecionados.AllowDrop = true;
		dgBornesSelecionados.AllowUserToAddRows = false;
		dgBornesSelecionados.AllowUserToDeleteRows = false;
		dgBornesSelecionados.AllowUserToResizeRows = false;
		dgBornesSelecionados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgBornesSelecionados.BackgroundColor = Color.White;
		dgBornesSelecionados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornesSelecionados.Location = new Point(12, 29);
		dgBornesSelecionados.MultiSelect = false;
		dgBornesSelecionados.Name = "dgBornesSelecionados";
		dgBornesSelecionados.ReadOnly = true;
		dgBornesSelecionados.RowHeadersVisible = false;
		dgBornesSelecionados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornesSelecionados.Size = new Size(191, 378);
		dgBornesSelecionados.TabIndex = 179;
		LabelPainel.BorderStyle = BorderStyle.Fixed3D;
		LabelPainel.ImageAlign = ContentAlignment.MiddleLeft;
		LabelPainel.Location = new Point(12, 9);
		LabelPainel.Name = "LabelPainel";
		LabelPainel.Size = new Size(191, 17);
		LabelPainel.TabIndex = 180;
		LabelPainel.Text = "LabelPainel";
		LabelPainel.TextAlign = ContentAlignment.MiddleCenter;
		dgNovaRegua.AllowDrop = true;
		dgNovaRegua.AllowUserToAddRows = false;
		dgNovaRegua.AllowUserToDeleteRows = false;
		dgNovaRegua.AllowUserToOrderColumns = true;
		dgNovaRegua.AllowUserToResizeRows = false;
		dgNovaRegua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgNovaRegua.BackgroundColor = Color.White;
		dgNovaRegua.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgNovaRegua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgNovaRegua.Location = new Point(209, 29);
		dgNovaRegua.MultiSelect = false;
		dgNovaRegua.Name = "dgNovaRegua";
		dgNovaRegua.ReadOnly = true;
		dgNovaRegua.RowHeadersVisible = false;
		dgNovaRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgNovaRegua.Size = new Size(191, 378);
		dgNovaRegua.TabIndex = 186;
		LabelPainel2.BorderStyle = BorderStyle.Fixed3D;
		LabelPainel2.ImageAlign = ContentAlignment.MiddleLeft;
		LabelPainel2.Location = new Point(210, 9);
		LabelPainel2.Name = "LabelPainel2";
		LabelPainel2.Size = new Size(191, 17);
		LabelPainel2.TabIndex = 187;
		LabelPainel2.Text = "Label1";
		LabelPainel2.TextAlign = ContentAlignment.MiddleCenter;
		btMigrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btMigrar.FlatStyle = FlatStyle.Flat;
		btMigrar.ForeColor = SystemColors.Control;
		btMigrar.Image = Resources.BorneMigra;
		btMigrar.Location = new Point(255, 418);
		btMigrar.Name = "btMigrar";
		btMigrar.Size = new Size(65, 30);
		btMigrar.TabIndex = 188;
		btMigrar.Tag = "";
		btMigrar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(413, 465);
		Controls.Add(btMigrar);
		Controls.Add(LabelPainel2);
		Controls.Add(dgNovaRegua);
		Controls.Add(LabelPainel);
		Controls.Add(dgBornesSelecionados);
		Controls.Add(btSelecionarBornes);
		MaximizeBox = false;
		MaximumSize = new Size(429, 504);
		MinimizeBox = false;
		MinimumSize = new Size(429, 504);
		Name = "frmMigraBornes";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Editor de Bornes";
		((ISupportInitialize)dgBornesSelecionados).EndInit();
		((ISupportInitialize)dgNovaRegua).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return IdMDxdPkMt;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		IdMDxdPkMt = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return n2ODb6csev;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		n2ODb6csev = WithEventsValue;
	}

	public frmMigraBornes()
	{
		HLrD8LGM6D = null;
		KEXDF9qqlw = null;
		uyBDQfIwAt = new List<string>();
		fwCDPGVBv1 = 0.0;
		DtFDcTOmTl = "";
		bNqDeRiox8 = 0;
		if (Geral.ExisteForm("frmMigraBornes") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			cufDDIKw6O();
			LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], DeclaracoesGeral.Conf.SeparadorPainelRegua), DeclaracoesGeral.mMensagem[1, 984]));
			LabelPainel2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], DeclaracoesGeral.Conf.SeparadorPainelRegua), DeclaracoesGeral.mMensagem[1, 984]));
			zkdDNKAoLO = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref zkdDNKAoLO);
			DicionarioReguas.OrdenaOsModelosDeRegua(ref zkdDNKAoLO);
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1973]);
			w8dpBZ0kvSD().SetToolTip(btSelecionarBornes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1971]));
			w8dpBZ0kvSD().SetToolTip(btMigrar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1972]));
			btMigrar.Enabled = true;
			dgBornesSelecionados.ReadOnly = true;
			dgBornesSelecionados.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgBornesSelecionados.ClearSelection();
			Application.ShowModelessDialog((Form)this);
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

	public static void carregaOsBornesSelecionadosNoDG(ref DataGridView dg, clsBornes.ordemBornes[] mBornes, List<string> sHandleBornes)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mBornes == null || Information.UBound(mBornes) == 0)
				{
					return;
				}
				formataDgBornes(ref dg);
				dg.ColumnHeadersVisible = true;
				if (Information.UBound(mBornes) > 0)
				{
					int num = Information.UBound(mBornes);
					for (int i = 1; i <= num; i++)
					{
						dg.Rows.Add(mBornes[i].indexRegua, mBornes[i].Nome, mBornes[i].Alternativo, mBornes[i].sHandle, mBornes[i].dX, mBornes[i].dY, mBornes[i].Ordem, mBornes[i].Tipo, mBornes[i].Lm, mBornes[i].iOrdemSelecao, mBornes[i].Nome, mBornes[i].Layout, mBornes[i].Orientacao, DeclaracoesGeral.ativo.Pagina);
						sHandleBornes.Add(mBornes[i].sHandle);
					}
				}
				int num2 = dg.Rows.Count - 1;
				int num3 = 0;
				while (true)
				{
					if (num3 <= num2)
					{
						if (!dg.Rows[num3].Selected)
						{
							break;
						}
						num3++;
						continue;
					}
					return;
				}
				dg.FirstDisplayedScrollingRowIndex = num3;
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

	public static void carregaOsBornesReservaNoDG(ref DataGridView dg, DataGridView dgSel, DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		checked
		{
			try
			{
				if (mBornes == null || Information.UBound(mBornes) == 0)
				{
					return;
				}
				dg.ColumnHeadersVisible = true;
				if (Information.UBound(mBornes) > 0)
				{
					int num = Information.UBound(mBornes);
					for (int i = 1; i <= num; i++)
					{
						int num2 = dgSel.Rows.Count - 1;
						int num3 = 0;
						while (true)
						{
							if (num3 <= num2)
							{
								if (Operators.ConditionalCompareObjectEqual(mBornes[i].pagina, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectEqual(dgSel.Rows[num3].Cells[1].Value, mBornes[i].Numero, TextCompare: true))
								{
									break;
								}
								num3++;
								continue;
							}
							if (Operators.ConditionalCompareObjectEqual(mBornes[i].pagina, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
							{
								dg.Rows.Add(mBornes[i].IndiceRegua, mBornes[i].Numero, mBornes[i].Alternativo, "", 0, 0, mBornes[i].Ordem, mBornes[i].tipo, mBornes[i].lm, 0, mBornes[i].Numero, mBornes[i].BlocoLayout, mBornes[i].Orientacao, DeclaracoesGeral.mMensagem[1, 375]);
							}
							break;
						}
					}
				}
				int num4 = dg.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (!dg.Rows[j].Selected)
					{
						dg.FirstDisplayedScrollingRowIndex = j;
						break;
					}
				}
				AtualizaColunasDGBornes(ref dg);
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

	private void iX2DvPKHXD(object P_0, EventArgs P_1)
	{
		dgBornesSelecionados.Rows.Clear();
		dgBornesSelecionados.Columns.Clear();
		dgNovaRegua.Rows.Clear();
		dgNovaRegua.Columns.Clear();
		PointMonitorToolTips.StopMonitor();
		List<string> sHandleBornes = new List<string>();
		checked
		{
			try
			{
				LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], DeclaracoesGeral.Conf.SeparadorPainelRegua), DeclaracoesGeral.mMensagem[1, 984]));
				LabelPainel2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], DeclaracoesGeral.Conf.SeparadorPainelRegua), DeclaracoesGeral.mMensagem[1, 984]));
				dgBornesSelecionados.Rows.Clear();
				dgBornesSelecionados.Columns.Clear();
				HLrD8LGM6D = new DeclaracoesEntidades.StructureBorne[1];
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Hide();
				clsBornes.ordemBornes[] BornesSelecionadas = null;
				uyBDQfIwAt.Clear();
				DataGridView dg;
				if (clsBornes.SelecionaBornesECircuitosParaEdicao(ref BornesSelecionadas, ref uyBDQfIwAt, ref bNqDeRiox8, ref fwCDPGVBv1))
				{
					dg = dgBornesSelecionados;
					carregaOsBornesSelecionadosNoDG(ref dg, BornesSelecionadas, sHandleBornes);
					dgBornesSelecionados = dg;
					dg = dgBornesSelecionados;
					RV1DjLOiJW(ref dg, true, true, false);
					dgBornesSelecionados = dg;
					int num = dgBornesSelecionados.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (Operators.CompareString(dgBornesSelecionados.Rows[i].Cells[1].Value.ToString(), "?", TextCompare: true) == 0)
						{
							dgBornesSelecionados.Rows[i].Cells[1].Value = "0";
						}
					}
					dg = dgBornesSelecionados;
					AtualizaColunasDGBornes(ref dg);
					dgBornesSelecionados = dg;
					HLrD8LGM6D = new DeclaracoesEntidades.StructureBorne[1];
					int iMaiorOrdem = 0;
					clsBornes.capturaOutrosBornesDoDesenhoNaoSel(bNqDeRiox8, ref HLrD8LGM6D, sHandleBornes, ref iMaiorOrdem);
					int num2 = Information.UBound(HLrD8LGM6D);
					for (int j = 1; j <= num2; j++)
					{
						if (fwCDPGVBv1 < HLrD8LGM6D[j].Ordem)
						{
							fwCDPGVBv1 = HLrD8LGM6D[j].Ordem;
						}
					}
					ref int iRegua = ref bNqDeRiox8;
					ref string dtFDcTOmTl = ref DtFDcTOmTl;
					string sAlternativo = "";
					rYVDKtweBZ = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref iRegua, ref dtFDcTOmTl, ref sAlternativo);
					LabelPainel.Text = Dicionario.BuscaNomeDoPainel(rYVDKtweBZ) + DeclaracoesGeral.Conf.SeparadorPainelRegua + DtFDcTOmTl;
				}
				Show();
				dg = dgBornesSelecionados;
				AtualizaColunasDGBornes(ref dg);
				dgBornesSelecionados = dg;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (dgBornesSelecionados.Rows.Count - 1 >= 0)
			{
				DataGridView dg = dgBornesSelecionados;
				carregaOsBornesReservaNoDG(ref dg, dgBornesSelecionados, HLrD8LGM6D);
				dgBornesSelecionados = dg;
				dg = dgBornesSelecionados;
				AtualizaColunasDGBornes(ref dg);
				dgBornesSelecionados = dg;
				dg = dgBornesSelecionados;
				AtualizaColunasDGBornes(ref dg);
				dgBornesSelecionados = dg;
				dg = dgNovaRegua;
				CarregaPaineiseReguasNoDG(ref dg, zkdDNKAoLO, rYVDKtweBZ, bNqDeRiox8);
				dgNovaRegua = dg;
				dg = dgNovaRegua;
				AtualizaColunasDGReguas(ref dg);
				dgNovaRegua = dg;
				LabelPainel2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgNovaRegua.SelectedRows[0].Cells[1].Value, DeclaracoesGeral.Conf.SeparadorPainelRegua), dgNovaRegua.SelectedRows[0].Cells[3].Value));
				PointMonitorToolTips.StartMonitor();
			}
		}
	}

	public static void CarregaPaineiseReguasNoDG(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, int iPainelSel, int indiceDaReguaSel)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mMODELO == null || Information.UBound(mMODELO) <= 0)
				{
					return;
				}
				dg.Columns.Add("IndicePainel", "#");
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dg.Columns.Add("indiceRegua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1043]));
				dg.ColumnHeadersVisible = true;
				int num = Information.UBound(mMODELO);
				for (int i = 1; i <= num; i++)
				{
					if (!((mMODELO[i].indexPainel == iPainelSel) & (mMODELO[i].indexRegua == indiceDaReguaSel)))
					{
						string nomeRegua = mMODELO[i].nomeRegua;
						string text = Dicionario.BuscaNomeDoPainel(mMODELO[i].indexPainel);
						dg.Rows.Add(mMODELO[i].indexPainel, text, mMODELO[i].indexRegua, nomeRegua);
					}
				}
				int num2 = dg.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[num3].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[num3].Value)))
						{
							dg.Rows[j].Cells[num3].Value = "";
						}
						num3++;
					}
					while (num3 <= 3);
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

	private void VBlD6VxG4G(object P_0, DataGridViewCellMouseEventArgs P_1)
	{
		LabelPainel2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgNovaRegua.SelectedRows[0].Cells[1].Value, DeclaracoesGeral.Conf.SeparadorPainelRegua), dgNovaRegua.SelectedRows[0].Cells[3].Value));
	}

	private void eClDtKxaTq(object P_0, EventArgs P_1)
	{
		if (dgBornesSelecionados.Rows.Count == 0)
		{
			return;
		}
		int indiceRegua = Conversions.ToInteger(dgNovaRegua.SelectedRows[0].Cells[2].Value);
		string nomeRegua = Conversions.ToString(dgNovaRegua.SelectedRows[0].Cells[3].Value);
		string nomePainel = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dgNovaRegua.SelectedRows[0].Cells[0].Value));
		frmGerenciadorReguasBornes.StructureRegua structureRegua = default;
		structureRegua.iPainel = rYVDKtweBZ;
		structureRegua.sPainel = Dicionario.BuscaNomeDoPainel(rYVDKtweBZ);
		structureRegua.iRegua = bNqDeRiox8;
		structureRegua.sReguaA = DtFDcTOmTl;
		KEXDF9qqlw = new DeclaracoesEntidades.StructureBorne[1];
		checked
		{
			int num = dgBornesSelecionados.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string left = Conversions.ToString(dgBornesSelecionados.Rows[i].Cells[7].Value);
				if (Operators.CompareString(left, "", TextCompare: true) != 0)
				{
					int num2 = Information.UBound(KEXDF9qqlw) + 1;
					ref DeclaracoesEntidades.StructureBorne[] kEXDF9qqlw = ref KEXDF9qqlw;
					kEXDF9qqlw = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(kEXDF9qqlw, new DeclaracoesEntidades.StructureBorne[num2 + 1]);
					KEXDF9qqlw[num2].NomeRegua = nomeRegua;
					KEXDF9qqlw[num2].NomePainel = nomePainel;
					KEXDF9qqlw[num2].IndiceRegua = indiceRegua;
					KEXDF9qqlw[num2].Ordem = 0.0;
					KEXDF9qqlw[num2].Numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					KEXDF9qqlw[num2].Alternativo = "";
					KEXDF9qqlw[num2].tipo = Conversions.ToInteger(dgBornesSelecionados.Rows[i].Cells[7].Value);
					KEXDF9qqlw[num2].lm = Conversions.ToInteger(dgBornesSelecionados.Rows[i].Cells[8].Value);
					KEXDF9qqlw[num2].Handle = Conversions.ToString(dgBornesSelecionados.Rows[i].Cells[3].Value);
					KEXDF9qqlw[num2].Orientacao = Conversions.ToString(dgBornesSelecionados.Rows[i].Cells[12].Value);
					KEXDF9qqlw[num2].BlocoLayout = Conversions.ToString(dgBornesSelecionados.Rows[i].Cells[11].Value);
					KEXDF9qqlw[num2].reserva = false;
				}
			}
			clsBornes.EditarOsTodosOsBornesMigradosDasReguaSelecionada(KEXDF9qqlw, structureRegua.sReguaA);
			clsTrocaPainel.TrocaPainelCircuito(uyBDQfIwAt, Conversions.ToInteger(dgNovaRegua.SelectedRows[0].Cells[0].Value));
			clsUtilitarios.CorrigePainelET1DosBornes();
			dgBornesSelecionados.Rows.Clear();
			dgBornesSelecionados.Columns.Clear();
			dgNovaRegua.Rows.Clear();
			dgNovaRegua.Columns.Clear();
			Close();
			new frmEditaBornesSelecao();
		}
	}

	private static void RV1DjLOiJW(ref DataGridView P_0, bool P_1, bool P_2, bool P_3)
	{
		checked
		{
			if (P_1 && P_0.Rows.Count - 1 >= 1)
			{
				int num = P_0.Rows.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					int num2 = P_0.Rows.Count - 2;
					for (int j = num2; j >= 0; j += -1)
					{
						int num3 = Conversions.ToInteger(P_0.Rows[j].Cells[9].Value);
						int num4 = Conversions.ToInteger(P_0.Rows[j + 1].Cells[9].Value);
						if (num3 > num4)
						{
							int num5 = 0;
							do
							{
								object objectValue = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num5].Value);
								P_0.Rows[j].Cells[num5].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num5].Value);
								P_0.Rows[j + 1].Cells[num5].Value = RuntimeHelpers.GetObjectValue(objectValue);
								num5++;
							}
							while (num5 <= 12);
						}
					}
				}
			}
			if (P_3)
			{
				int num6 = P_0.Rows.Count - 2;
				for (int k = 0; k <= num6; k++)
				{
					int num7 = P_0.Rows.Count - 2;
					for (int l = num7; l >= 0; l += -1)
					{
						int num8 = Conversions.ToInteger(P_0.Rows[l].Cells[4].Value);
						int num9 = Conversions.ToInteger(P_0.Rows[l + 1].Cells[4].Value);
						int num10 = Conversions.ToInteger(P_0.Rows[l].Cells[5].Value);
						int num11 = Conversions.ToInteger(P_0.Rows[l + 1].Cells[5].Value);
						if (num8 > num9)
						{
							int num12 = 0;
							do
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(P_0.Rows[l].Cells[num12].Value);
								P_0.Rows[l].Cells[num12].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[l + 1].Cells[num12].Value);
								P_0.Rows[l + 1].Cells[num12].Value = RuntimeHelpers.GetObjectValue(objectValue2);
								num12++;
							}
							while (num12 <= 12);
						}
						if (num8 == num9 && num10 < num11)
						{
							int num13 = 0;
							do
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(P_0.Rows[l].Cells[num13].Value);
								P_0.Rows[l].Cells[num13].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[l + 1].Cells[num13].Value);
								P_0.Rows[l + 1].Cells[num13].Value = RuntimeHelpers.GetObjectValue(objectValue3);
								num13++;
							}
							while (num13 <= 12);
						}
					}
				}
			}
			if (!P_2)
			{
				return;
			}
			int num14 = P_0.Rows.Count - 2;
			for (int m = 0; m <= num14; m++)
			{
				int num15 = P_0.Rows.Count - 2;
				for (int n = num15; n >= 0; n += -1)
				{
					int num16 = Conversions.ToInteger(P_0.Rows[n].Cells[4].Value);
					int num17 = Conversions.ToInteger(P_0.Rows[n + 1].Cells[4].Value);
					int num18 = Conversions.ToInteger(P_0.Rows[n].Cells[5].Value);
					int num19 = Conversions.ToInteger(P_0.Rows[n + 1].Cells[5].Value);
					if (num18 < num19)
					{
						int num20 = 0;
						do
						{
							object objectValue4 = RuntimeHelpers.GetObjectValue(P_0.Rows[n].Cells[num20].Value);
							P_0.Rows[n].Cells[num20].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[n + 1].Cells[num20].Value);
							P_0.Rows[n + 1].Cells[num20].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							num20++;
						}
						while (num20 <= 12);
					}
					if (num18 == num19 && num16 > num17)
					{
						int num21 = 0;
						do
						{
							object objectValue5 = RuntimeHelpers.GetObjectValue(P_0.Rows[n].Cells[num21].Value);
							P_0.Rows[n].Cells[num21].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[n + 1].Cells[num21].Value);
							P_0.Rows[n + 1].Cells[num21].Value = RuntimeHelpers.GetObjectValue(objectValue5);
							num21++;
						}
						while (num21 <= 12);
					}
				}
			}
		}
	}

	public static void formataDgBornes(ref DataGridView dg)
	{
		dg.Columns.Add("IndiceRegua", "#");
		dg.Columns.Add("Numero", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1083]));
		dg.Columns.Add("Alternativo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]));
		dg.Columns.Add("sHandle", "sHandle");
		dg.Columns.Add("dX", "dX");
		dg.Columns.Add("dY", "dY");
		dg.Columns.Add("Ordem", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1082]));
		dg.Columns.Add("Tipo", "Tipo");
		dg.Columns.Add("Lm", "LM");
		dg.Columns.Add("Ordem", "Ordem");
		dg.Columns.Add("NumeroOri", "NumeroOri");
		dg.Columns.Add("BlocoLayout", "BlocoLayout");
		dg.Columns.Add("Orientação", "Orientação");
		dg.Columns.Add("Página", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
	}

	public static void AtualizaColunasDGBornes(ref DataGridView dg)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
		{
			dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			dg.Columns[0].Width = (int)Math.Round(num * 0.0);
			dg.Columns[1].Width = (int)Math.Round(num * 0.5);
			dg.Columns[2].Width = 0;
			dg.Columns[3].Width = 0;
			dg.Columns[4].Width = 0;
			dg.Columns[5].Width = 0;
			dg.Columns[6].Width = 0;
			dg.Columns[7].Width = 0;
			dg.Columns[8].Width = 0;
			dg.Columns[9].Width = 0;
			dg.Columns[10].Width = 0;
			dg.Columns[11].Width = 0;
			dg.Columns[12].Width = 0;
			dg.Columns[13].Width = (int)Math.Round(num * 0.5);
			dg.Columns[0].Visible = false;
			dg.Columns[1].Visible = true;
			dg.Columns[2].Visible = false;
			dg.Columns[3].Visible = false;
			dg.Columns[4].Visible = false;
			dg.Columns[5].Visible = false;
			dg.Columns[6].Visible = false;
			dg.Columns[7].Visible = false;
			dg.Columns[8].Visible = false;
			dg.Columns[9].Visible = false;
			dg.Columns[10].Visible = false;
			dg.Columns[11].Visible = false;
			dg.Columns[12].Visible = false;
			dg.Columns[13].Visible = true;
			int num2 = 0;
			do
			{
				dg.Columns[num2].ReadOnly = true;
				num2++;
			}
			while (num2 <= 13);
			dg.MultiSelect = true;
		}
	}

	public static void AtualizaColunasDGReguas(ref DataGridView dg)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
		{
			dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			dg.Columns[0].Width = 0;
			dg.Columns[1].Width = (int)Math.Round(num * 0.5);
			dg.Columns[2].Width = 0;
			dg.Columns[3].Width = (int)Math.Round(num * 0.5);
			dg.Columns[0].Visible = false;
			dg.Columns[1].Visible = true;
			dg.Columns[2].Visible = false;
			dg.Columns[3].Visible = true;
			int num2 = 0;
			do
			{
				dg.Columns[num2].ReadOnly = true;
				num2++;
			}
			while (num2 <= 3);
			dg.MultiSelect = false;
		}
	}

	private void FhVDLJJaJS(object P_0, EventArgs P_1)
	{
		dgBornesSelecionados.ClearSelection();
	}
}
