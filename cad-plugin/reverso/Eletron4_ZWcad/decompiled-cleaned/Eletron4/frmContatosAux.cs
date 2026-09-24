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
using YhamV21aratNE3b4GFK;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmContatosAux : Form
{
	public struct BlocosAuxiliares
	{
		public string NomeDWG;

		public string CaminhoCompleto;

		public string Tipo;

		public string Comportamento;

		public int Quantidadede;
	}

	private IContainer hDXBOY0iw1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip nXxBIYcb17;

	[CompilerGenerated]
	[AccessedThroughProperty("CKAlternativo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox rynB7DnET8;

	[AccessedThroughProperty("CKNomeVisivel")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox jphBqDywLE;

	[AccessedThroughProperty("dgBlocos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView gfOBawgkHa;

	[AccessedThroughProperty("btSeleciona")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button UMaB8N7Yd2;

	[CompilerGenerated]
	[AccessedThroughProperty("btInserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button ND4BNJGnY2;

	[AccessedThroughProperty("iDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private PictureBox NHjBFDW1h9;

	[AccessedThroughProperty("dgContatos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView GAPBQbPBj8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPainel")]
	[CompilerGenerated]
	private ComboBox zljBPRIypL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDisp")]
	private DataGridView TIXBc6qxW8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private Label FQTBKSevML;

	private BlocosAuxiliares[] deQBeePXwm;

	private string gdSB2LF22b;

	private string hXrB39bQXl;

	private string NILBnvPxdp;

	private string F5nB1pgpRD;

	private bool PeXBlmxeev;

	private string SKwB5qCt4X;

	private string eUNB0Bv9yC;

	private string idxBR4fwbM;

	internal virtual CheckBox CKAlternativo
	{
		[CompilerGenerated]
		get
		{
			return rynB7DnET8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rynB7DnET8 = value;
		}
	}

	internal virtual CheckBox CKNomeVisivel
	{
		[CompilerGenerated]
		get
		{
			return jphBqDywLE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jphBqDywLE = value;
		}
	}

	internal virtual DataGridView dgBlocos
	{
		[CompilerGenerated]
		get
		{
			return gfOBawgkHa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = F30BDU14vk;
			KeyEventHandler value3 = YvuBv4eq19;
			KeyEventHandler value4 = kO9B6laXfG;
			DataGridView dataGridView = gfOBawgkHa;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
			}
			gfOBawgkHa = value;
			dataGridView = gfOBawgkHa;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
			}
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return UMaB8N7Yd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bNwBLkBh8e;
			Button button = UMaB8N7Yd2;
			if (button != null)
			{
				button.Click -= value2;
			}
			UMaB8N7Yd2 = value;
			button = UMaB8N7Yd2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return ND4BNJGnY2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dhEBw2sZ98;
			Button button = ND4BNJGnY2;
			if (button != null)
			{
				button.Click -= value2;
			}
			ND4BNJGnY2 = value;
			button = ND4BNJGnY2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual PictureBox iDWG
	{
		[CompilerGenerated]
		get
		{
			return NHjBFDW1h9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NHjBFDW1h9 = value;
		}
	}

	internal virtual DataGridView dgContatos
	{
		[CompilerGenerated]
		get
		{
			return GAPBQbPBj8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = QZXBHNQ2vx;
			KeyEventHandler value3 = WefBkLZKnL;
			KeyEventHandler value4 = AAQBdM7eAR;
			DataGridViewCellEventHandler value5 = BELBM8LqsN;
			DataGridView dataGridView = GAPBQbPBj8;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
				dataGridView.CellContentDoubleClick -= value5;
			}
			GAPBQbPBj8 = value;
			dataGridView = GAPBQbPBj8;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
				dataGridView.CellContentDoubleClick += value5;
			}
		}
	}

	internal virtual ComboBox cbPainel
	{
		[CompilerGenerated]
		get
		{
			return zljBPRIypL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NaiBpPfgkA;
			EventHandler value3 = AvABxbw6B9;
			ComboBox comboBox = zljBPRIypL;
			if (comboBox != null)
			{
				comboBox.TextChanged -= value2;
				comboBox.SelectedIndexChanged -= value3;
			}
			zljBPRIypL = value;
			comboBox = zljBPRIypL;
			if (comboBox != null)
			{
				comboBox.TextChanged += value2;
				comboBox.SelectedIndexChanged += value3;
			}
		}
	}

	internal virtual DataGridView dgDisp
	{
		[CompilerGenerated]
		get
		{
			return TIXBc6qxW8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qFEBJ9myU9;
			MouseEventHandler value3 = VioBhSmeNq;
			KeyEventHandler value4 = YoYBoW51uC;
			KeyEventHandler value5 = qvWBGgluKF;
			DataGridView dataGridView = TIXBc6qxW8;
			if (dataGridView != null)
			{
				dataGridView.SizeChanged -= value2;
				dataGridView.MouseClick -= value3;
				dataGridView.KeyUp -= value4;
				dataGridView.KeyDown -= value5;
			}
			TIXBc6qxW8 = value;
			dataGridView = TIXBc6qxW8;
			if (dataGridView != null)
			{
				dataGridView.SizeChanged += value2;
				dataGridView.MouseClick += value3;
				dataGridView.KeyUp += value4;
				dataGridView.KeyDown += value5;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return FQTBKSevML;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FQTBKSevML = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && hDXBOY0iw1 != null)
			{
				hDXBOY0iw1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void v3NBWRVSYj()
	{
		hDXBOY0iw1 = new Container();
		FDqpBiUmZij(new ToolTip(hDXBOY0iw1));
		CKAlternativo = new CheckBox();
		CKNomeVisivel = new CheckBox();
		dgBlocos = new DataGridView();
		btSeleciona = new Button();
		btInserir = new Button();
		iDWG = new PictureBox();
		dgContatos = new DataGridView();
		cbPainel = new ComboBox();
		dgDisp = new DataGridView();
		Label1 = new Label();
		((ISupportInitialize)dgBlocos).BeginInit();
		((ISupportInitialize)iDWG).BeginInit();
		((ISupportInitialize)dgContatos).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		SuspendLayout();
		CKAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKAlternativo.AutoSize = true;
		CKAlternativo.Checked = true;
		CKAlternativo.CheckState = CheckState.Checked;
		CKAlternativo.Location = new Point(16, 497);
		CKAlternativo.Name = "CKAlternativo";
		CKAlternativo.Size = new Size(90, 17);
		CKAlternativo.TabIndex = 58;
		CKAlternativo.Text = "CKAlternativo";
		CKAlternativo.UseVisualStyleBackColor = true;
		CKNomeVisivel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKNomeVisivel.AutoSize = true;
		CKNomeVisivel.Checked = true;
		CKNomeVisivel.CheckState = CheckState.Checked;
		CKNomeVisivel.Location = new Point(16, 474);
		CKNomeVisivel.Name = "CKNomeVisivel";
		CKNomeVisivel.Size = new Size(100, 17);
		CKNomeVisivel.TabIndex = 57;
		CKNomeVisivel.Text = "CKNomeVisível";
		CKNomeVisivel.UseVisualStyleBackColor = true;
		dgBlocos.AllowUserToAddRows = false;
		dgBlocos.AllowUserToDeleteRows = false;
		dgBlocos.AllowUserToOrderColumns = true;
		dgBlocos.AllowUserToResizeRows = false;
		dgBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		dgBlocos.BorderStyle = BorderStyle.Fixed3D;
		dgBlocos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgBlocos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBlocos.Location = new Point(228, 133);
		dgBlocos.MultiSelect = false;
		dgBlocos.Name = "dgBlocos";
		dgBlocos.ReadOnly = true;
		dgBlocos.RowHeadersVisible = false;
		dgBlocos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBlocos.Size = new Size(248, 167);
		dgBlocos.TabIndex = 56;
		btSeleciona.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_32;
		btSeleciona.Location = new Point(317, 474);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(40, 40);
		btSeleciona.TabIndex = 50;
		btSeleciona.Tag = "";
		btSeleciona.UseVisualStyleBackColor = true;
		btInserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.OK_32;
		btInserir.Location = new Point(388, 474);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 40);
		btInserir.TabIndex = 49;
		btInserir.UseVisualStyleBackColor = true;
		iDWG.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		iDWG.BackColor = SystemColors.Desktop;
		iDWG.Location = new Point(228, 12);
		iDWG.Name = "iDWG";
		iDWG.Size = new Size(248, 115);
		iDWG.SizeMode = PictureBoxSizeMode.Zoom;
		iDWG.TabIndex = 47;
		iDWG.TabStop = false;
		dgContatos.AllowUserToAddRows = false;
		dgContatos.AllowUserToDeleteRows = false;
		dgContatos.AllowUserToOrderColumns = true;
		dgContatos.AllowUserToResizeRows = false;
		dgContatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgContatos.BorderStyle = BorderStyle.Fixed3D;
		dgContatos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgContatos.Location = new Point(228, 306);
		dgContatos.MultiSelect = false;
		dgContatos.Name = "dgContatos";
		dgContatos.ReadOnly = true;
		dgContatos.RowHeadersVisible = false;
		dgContatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgContatos.Size = new Size(248, 152);
		dgContatos.TabIndex = 62;
		cbPainel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		cbPainel.FormattingEnabled = true;
		cbPainel.Location = new Point(13, 25);
		cbPainel.Name = "cbPainel";
		cbPainel.Size = new Size(209, 21);
		cbPainel.TabIndex = 59;
		dgDisp.AllowUserToAddRows = false;
		dgDisp.AllowUserToDeleteRows = false;
		dgDisp.AllowUserToOrderColumns = true;
		dgDisp.AllowUserToResizeRows = false;
		dgDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgDisp.BorderStyle = BorderStyle.Fixed3D;
		dgDisp.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDisp.Location = new Point(12, 52);
		dgDisp.MultiSelect = false;
		dgDisp.Name = "dgDisp";
		dgDisp.ReadOnly = true;
		dgDisp.RowHeadersVisible = false;
		dgDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDisp.Size = new Size(210, 406);
		dgDisp.TabIndex = 61;
		Label1.AutoSize = true;
		Label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label1.Location = new Point(13, 9);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 60;
		Label1.Text = "Label1";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(488, 524);
		Controls.Add(dgContatos);
		Controls.Add(cbPainel);
		Controls.Add(dgDisp);
		Controls.Add(Label1);
		Controls.Add(CKAlternativo);
		Controls.Add(CKNomeVisivel);
		Controls.Add(dgBlocos);
		Controls.Add(btSeleciona);
		Controls.Add(btInserir);
		Controls.Add(iDWG);
		MaximizeBox = false;
		MinimizeBox = false;
		MinimumSize = new Size(504, 562);
		Name = "frmContatosAux";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Contatos Auxilaires";
		((ISupportInitialize)dgBlocos).EndInit();
		((ISupportInitialize)iDWG).EndInit();
		((ISupportInitialize)dgContatos).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return nXxBIYcb17;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		nXxBIYcb17 = WithEventsValue;
	}

	public frmContatosAux()
	{
		Resize += x39Bb10DV6;
		gdSB2LF22b = "";
		hXrB39bQXl = "";
		NILBnvPxdp = "";
		F5nB1pgpRD = "";
		PeXBlmxeev = true;
		SKwB5qCt4X = "";
		eUNB0Bv9yC = "";
		idxBR4fwbM = "";
		checked
		{
			try
			{
				if (!clsAuxiliar.BancoValido())
				{
					return;
				}
				cDadosAccess.carregaDadosDWG();
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					v3NBWRVSYj();
					bool bCaminhoSimb = true;
					if (Geral.ExisteForm("frmContatosAux"))
					{
						return;
					}
					Application.ShowModelessDialog((Form)this);
					F5nB1pgpRD = "1";
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 500]);
					Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 902]);
					w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 906]));
					w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 907]));
					CKNomeVisivel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 910]);
					CKAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 911]);
					List<string> list = new List<string>();
					list = clsDispositivoAuxiliares.carregaNomeContatosAux(ref deQBeePXwm, ref bCaminhoSimb);
					if (bCaminhoSimb)
					{
						cDadosAccess.carregaPainelDicionario();
						ComboBox combo = cbPainel;
						clsDispositivoAuxiliares.CarregaOsPaineisEmUsoPelosContatos(ref combo);
						cbPainel = combo;
						YBYBTcwKKi();
						CKAlternativo.Checked = false;
						CKAlternativo.Enabled = false;
						gdSB2LF22b = cbPainel.Text;
						PeXBlmxeev = false;
						if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
						{
							Left = 0;
						}
						if (list.Count > 0)
						{
							string text = "IEC";
							if (DeclaracoesGeral.Conf.Norma == 1)
							{
								text = "ANSI";
							}
							string right = DeclaracoesGeral.Conf.DirSimbologiaEletrica + "Contatos\\" + text;
							string text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1371], list.Count), DeclaracoesGeral.mMensagem[1, 1372]), right));
							if (list.Count > 1)
							{
								text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1371], list.Count), DeclaracoesGeral.mMensagem[1, 1373]), right));
							}
							text2 += "\r\n\r\n";
							int num = list.Count - 1;
							for (int i = 0; i <= num; i++)
							{
								if (i > 0)
								{
									text2 += ", \r\n";
								}
								text2 += list[i];
							}
							Interaction.MsgBox(text2, MsgBoxStyle.Information);
						}
					}
					if (!bCaminhoSimb)
					{
						Close();
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
	}

	private void NaiBpPfgkA(object P_0, EventArgs P_1)
	{
		YBYBTcwKKi();
	}

	private void YBYBTcwKKi()
	{
		DeclaracoesGeral.ativo.Painel = Dicionario.BuscaIndiceDoPainel(cbPainel.Text);
		gdSB2LF22b = cbPainel.Text;
		checked
		{
			DataGridView DgContatos;
			if (Operators.CompareString(gdSB2LF22b, "", TextCompare: true) != 0)
			{
				DataGridView dg = dgDisp;
				clsDispositivoAuxiliares.CarregaContatosAuxiliaresInseridos(ref dg, gdSB2LF22b);
				dgDisp = dg;
				CKAlternativo.Checked = false;
				CKAlternativo.Enabled = false;
				int num = dgDisp.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgDisp.Rows[i].Selected)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[i].Cells[3].Value, "", TextCompare: true))
						{
							F5nB1pgpRD = "2";
						}
						if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[i].Cells[4].Value, "", TextCompare: true))
						{
							CKAlternativo.Enabled = true;
						}
						break;
					}
				}
				if (dgDisp.Rows.Count > 0)
				{
					DataGridView dataGridView = dgDisp;
					dg = dgContatos;
					clsDispositivoAuxiliares.CarregaOsContatosAuxiliares(dataGridView, ref dg, gdSB2LF22b);
					dgContatos = dg;
					if (dgContatos.Rows.Count > 0)
					{
						dg = dgBlocos;
						DgContatos = dgContatos;
						frmContatosAux Paleta = this;
						string text = clsDispositivoAuxiliares.carregaDGContatosAuxiliares(ref dg, ref DgContatos, ref Paleta, ref deQBeePXwm, Conversions.ToInteger(F5nB1pgpRD));
						dgContatos = DgContatos;
						dgBlocos = dg;
						hXrB39bQXl = text;
						if (Operators.CompareString(hXrB39bQXl, "", TextCompare: true) != 0)
						{
							iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(hXrB39bQXl);
						}
					}
				}
			}
			DgContatos = dgDisp;
			AtualizaColunasDGContatosDisp(ref DgContatos);
			dgDisp = DgContatos;
			AtualizadgDisp();
		}
	}

	private void qFEBJ9myU9(object P_0, EventArgs P_1)
	{
		AtualizadgDisp();
	}

	private void VioBhSmeNq(object P_0, MouseEventArgs P_1)
	{
		AtualizadgDisp();
	}

	private void YoYBoW51uC(object P_0, KeyEventArgs P_1)
	{
		AtualizadgDisp();
	}

	private void qvWBGgluKF(object P_0, KeyEventArgs P_1)
	{
		AtualizadgDisp();
	}

	public void AtualizadgDisp()
	{
		CKAlternativo.Checked = false;
		CKAlternativo.Enabled = false;
		F5nB1pgpRD = "1";
		checked
		{
			int num = dgDisp.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgDisp.Rows[i].Selected)
				{
					SKwB5qCt4X = Conversions.ToString(dgDisp.Rows[i].Cells[1].Value);
					if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[i].Cells[3].Value, "", TextCompare: true))
					{
						F5nB1pgpRD = "2";
					}
					if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[i].Cells[4].Value, "", TextCompare: true))
					{
						CKAlternativo.Enabled = true;
					}
					break;
				}
			}
			if (dgDisp.Rows.Count > 0)
			{
				hXrB39bQXl = "";
				DataGridView dataGridView = dgDisp;
				DataGridView withEventsValue = dgContatos;
				clsDispositivoAuxiliares.CarregaOsContatosAuxiliares(dataGridView, ref withEventsValue, gdSB2LF22b);
				dgContatos = withEventsValue;
				if (dgContatos.Rows.Count > 0)
				{
					withEventsValue = dgBlocos;
					DataGridView DgContatos = dgContatos;
					frmContatosAux Paleta = this;
					string text = clsDispositivoAuxiliares.carregaDGContatosAuxiliares(ref withEventsValue, ref DgContatos, ref Paleta, ref deQBeePXwm, Conversions.ToInteger(F5nB1pgpRD));
					dgContatos = DgContatos;
					dgBlocos = withEventsValue;
					hXrB39bQXl = text;
					if (Operators.CompareString(hXrB39bQXl, "", TextCompare: true) != 0)
					{
						iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(hXrB39bQXl);
					}
				}
			}
			int num2 = dgContatos.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (dgContatos.Rows[j].Cells[0].Style.BackColor != Color.LightCoral)
				{
					if (j >= 3)
					{
						dgContatos.FirstDisplayedScrollingRowIndex = j - 2;
					}
					dgContatos.Rows[j].Selected = true;
					break;
				}
			}
			WgwBfRJXDc();
			if (Operators.CompareString(NILBnvPxdp, "", TextCompare: true) != 0)
			{
				int num3 = dgBlocos.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgBlocos.Rows[k].Cells[0].Value, NILBnvPxdp, TextCompare: true))
					{
						dgBlocos.Rows[k].Selected = true;
						if (k >= 3)
						{
							dgBlocos.FirstDisplayedScrollingRowIndex = k - 2;
						}
					}
				}
			}
			o0EBjdhdGN();
		}
	}

	private void QZXBHNQ2vx(object P_0, MouseEventArgs P_1)
	{
		WgwBfRJXDc();
	}

	private void WefBkLZKnL(object P_0, KeyEventArgs P_1)
	{
		WgwBfRJXDc();
	}

	private void AAQBdM7eAR(object P_0, KeyEventArgs P_1)
	{
		WgwBfRJXDc();
	}

	private void WgwBfRJXDc()
	{
		checked
		{
			int num = dgContatos.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (!dgContatos.Rows[num2].Selected)
					{
						num2++;
						continue;
					}
					if (!(dgContatos.Rows[num2].Cells[0].Style.BackColor == Color.LightCoral))
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(eUNB0Bv9yC, dgContatos.Rows[num2].Cells[5].Value, TextCompare: true), Operators.CompareObjectEqual(idxBR4fwbM, dgContatos.Rows[num2].Cells[6].Value, TextCompare: true))))
						{
							break;
						}
						eUNB0Bv9yC = Conversions.ToString(dgContatos.Rows[num2].Cells[5].Value);
						idxBR4fwbM = Conversions.ToString(dgContatos.Rows[num2].Cells[6].Value);
					}
					else
					{
						eUNB0Bv9yC = "";
						idxBR4fwbM = "";
					}
				}
				if (dgContatos.Rows.Count > 0)
				{
					hXrB39bQXl = "";
					DataGridView Dg = dgBlocos;
					DataGridView DgContatos = dgContatos;
					frmContatosAux Paleta = this;
					string text = clsDispositivoAuxiliares.carregaDGContatosAuxiliares(ref Dg, ref DgContatos, ref Paleta, ref deQBeePXwm, Conversions.ToInteger(F5nB1pgpRD));
					dgContatos = DgContatos;
					dgBlocos = Dg;
					hXrB39bQXl = text;
					iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(hXrB39bQXl);
				}
				bool flag = false;
				if (Operators.CompareString(NILBnvPxdp, "", TextCompare: true) != 0)
				{
					int num3 = dgBlocos.RowCount - 1;
					for (int i = 0; i <= num3; i++)
					{
						if (Operators.ConditionalCompareObjectEqual(NILBnvPxdp, dgBlocos.Rows[i].Cells[0].Value, TextCompare: true))
						{
							dgBlocos.Rows[i].Selected = true;
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					o0EBjdhdGN();
				}
				break;
			}
		}
	}

	private void F30BDU14vk(object P_0, MouseEventArgs P_1)
	{
		brEBtNWy6q();
	}

	private void YvuBv4eq19(object P_0, KeyEventArgs P_1)
	{
		brEBtNWy6q();
	}

	private void kO9B6laXfG(object P_0, KeyEventArgs P_1)
	{
		brEBtNWy6q();
	}

	private void brEBtNWy6q()
	{
		if (dgBlocos.SelectedRows.Count > 0)
		{
			NILBnvPxdp = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[0].Value);
		}
		o0EBjdhdGN();
	}

	private void o0EBjdhdGN()
	{
		checked
		{
			int num = dgBlocos.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgBlocos.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(dgBlocos.Rows[num2].Cells[1].Value));
		}
	}

	private void bNwBLkBh8e(object P_0, EventArgs P_1)
	{
		Declaracoes2.StructureContatoAuxBobina myBL = default;
		clsDispositivoAuxiliares.selecionaContatoAuxiliarInserido(ref myBL);
		if (!myBL.bOK)
		{
			return;
		}
		cbPainel.Text = myBL.sPainel;
		bool flag = false;
		if (Operators.CompareString(myBL.sPainel, "", TextCompare: true) == 0)
		{
			return;
		}
		DataGridView dg = dgDisp;
		clsDispositivoAuxiliares.CarregaContatosAuxiliaresInseridos(ref dg, gdSB2LF22b);
		dgDisp = dg;
		checked
		{
			int num = dgDisp.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				string right = myBL.sNome1;
				if (Operators.CompareString(myBL.sNome2, "", TextCompare: true) != 0)
				{
					right = myBL.sNome1 + "/" + myBL.sNome2;
				}
				if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[i].Cells[1].Value, right, TextCompare: true))
				{
					dgDisp.Rows[i].Selected = true;
					dgDisp.CurrentCell = dgDisp.Rows[i].Cells[1];
					flag = true;
					break;
				}
			}
			dgContatos.Rows.Clear();
			dgBlocos.Rows.Clear();
			if (!flag)
			{
				return;
			}
			flag = false;
			if (dgDisp.Rows.Count <= 0)
			{
				return;
			}
			DataGridView dataGridView = dgDisp;
			dg = dgContatos;
			clsDispositivoAuxiliares.CarregaOsContatosAuxiliares(dataGridView, ref dg, gdSB2LF22b);
			dgContatos = dg;
			if (dgContatos.Rows.Count > 0)
			{
				dg = dgBlocos;
				DataGridView DgContatos = dgContatos;
				frmContatosAux Paleta = this;
				string text = clsDispositivoAuxiliares.carregaDGContatosAuxiliares(ref dg, ref DgContatos, ref Paleta, ref deQBeePXwm, Conversions.ToInteger(F5nB1pgpRD));
				dgContatos = DgContatos;
				dgBlocos = dg;
				hXrB39bQXl = text;
				if (Operators.CompareString(hXrB39bQXl, "", TextCompare: true) != 0)
				{
					iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(hXrB39bQXl);
				}
			}
		}
	}

	private void dhEBw2sZ98(object P_0, EventArgs P_1)
	{
		if ((dgDisp.SelectedRows.Count == 0) | (dgBlocos.RowCount == 0) | (dgBlocos.SelectedRows.Count == 0) | (dgContatos.SelectedRows.Count == 0))
		{
			return;
		}
		Hide();
		bool flag = false;
		checked
		{
			int num = cbPainel.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(cbPainel.Items[i].ToString().Trim(), cbPainel.Text.ToString().Trim(), TextCompare: true) == 0)
				{
					flag = true;
				}
			}
			if (flag)
			{
				Declaracoes2.StructureContatoAuxBobina cont = default;
				cont.sPainel = cbPainel.Text;
				cont.iPainel = Dicionario.BuscaIndiceDoPainel(cont.sPainel);
				if (dgDisp.SelectedRows.Count <= 0)
				{
					flag = false;
				}
				else
				{
					cont.iIndiceModelo = Conversions.ToInteger(dgDisp.SelectedRows[0].Cells[0].Value);
					cont.sNomeDisp = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
					cont.sNome1 = Conversions.ToString(dgDisp.SelectedRows[0].Cells[2].Value);
					cont.sNome2 = Conversions.ToString(dgDisp.SelectedRows[0].Cells[3].Value);
					cont.sAlternativo = Conversions.ToString(dgDisp.SelectedRows[0].Cells[4].Value);
					cont.sHandleBobina = Conversions.ToString(dgDisp.SelectedRows[0].Cells[5].Value);
				}
				if (dgContatos.SelectedRows.Count <= 0)
				{
					flag = false;
				}
				else
				{
					cont.iIndiceContato = Conversions.ToInteger(dgContatos.SelectedRows[0].Cells[0].Value);
					cont.sT1 = Conversions.ToString(dgContatos.SelectedRows[0].Cells[1].Value);
					cont.sT2 = Conversions.ToString(dgContatos.SelectedRows[0].Cells[2].Value);
					cont.sT3 = Conversions.ToString(dgContatos.SelectedRows[0].Cells[3].Value);
					cont.sTipo = Conversions.ToString(dgContatos.SelectedRows[0].Cells[5].Value);
					string sTipo = cont.sTipo;
					if (Operators.CompareString(sTipo, "NA", TextCompare: true) != 0)
					{
						if (Operators.CompareString(sTipo, "NF", TextCompare: true) != 0)
						{
							if (Operators.CompareString(sTipo, "RV", TextCompare: true) == 0)
							{
								cont.iTipo = 3;
							}
						}
						else
						{
							cont.iTipo = 2;
						}
					}
					else
					{
						cont.iTipo = 1;
					}
					cont.sComportamento = Conversions.ToString(dgContatos.SelectedRows[0].Cells[6].Value);
					string sComportamento = cont.sComportamento;
					if (Operators.CompareString(sComportamento, "ST", TextCompare: true) != 0)
					{
						if (Operators.CompareString(sComportamento, "TE", TextCompare: true) != 0)
						{
							if (Operators.CompareString(sComportamento, "TD", TextCompare: true) != 0)
							{
								if (Operators.CompareString(sComportamento, "BI", TextCompare: true) != 0)
								{
									if (Operators.CompareString(sComportamento, "AM", TextCompare: true) == 0)
									{
										cont.iComportamento = 4;
									}
								}
								else
								{
									cont.iComportamento = 3;
								}
							}
							else
							{
								cont.iComportamento = 2;
							}
						}
						else
						{
							cont.iComportamento = 1;
						}
					}
					else
					{
						cont.iComportamento = 0;
					}
				}
				if (dgBlocos.SelectedRows.Count <= 0)
				{
					flag = false;
				}
				else
				{
					cont.sNomeDoBloco = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[0].Value);
					NILBnvPxdp = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[0].Value);
					cont.sCaminhoBloco = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[1].Value);
					cont.sTipoBlocoContato = Strings.Mid(cont.sNomeDoBloco, 5, 2);
				}
				if (flag && clsDispositivoAuxiliares.InserirContatoAux(ref cont, CKNomeVisivel.Checked, CKAlternativo.Checked))
				{
					MarcaContatoAuxiliarUsado(dgContatos);
					clsDispositivoAuxiliares.criaInsercaoTabela(ref cont);
					WgwBfRJXDc();
				}
				Show();
				PointMonitorToolTips.StartMonitor();
				DeclaracoesGeral.bSuspenderEvento = false;
				DeclaracoesGeral.bAnularEventos = false;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1044]), MsgBoxStyle.Information);
			}
		}
	}

	public static void MarcaContatoAuxiliarUsado(DataGridView dgContatos)
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		checked
		{
			if (dgContatos.SelectedRows.Count > 0)
			{
				int num = 0;
				do
				{
					dgContatos.SelectedRows[0].Cells[num].Style = dataGridViewCellStyle;
					num++;
				}
				while (num <= 7);
				dgContatos.SelectedRows[0].Cells[7].Value = DeclaracoesGeral.ativo.Pagina;
				dgContatos.SelectedRows[0].Selected = false;
			}
			int num2 = dgContatos.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgContatos.Rows[num3].Cells[0].Style.BackColor != Color.LightCoral)
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			dgContatos.Rows[num3].Selected = true;
			if (num3 >= 3)
			{
				dgContatos.FirstDisplayedScrollingRowIndex = num3 - 2;
			}
		}
	}

	private void AvABxbw6B9(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.ativo.Painel = Dicionario.BuscaIndiceDoPainel(cbPainel.Text);
	}

	public static void AtualizaColunasDGContatosDisp(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Visible = false;
				dg.Columns[1].Visible = true;
				dg.Columns[0].Width = 0;
				dg.Columns[1].Width = (int)Math.Round(a);
			}
		}
	}

	public static void AtualizaColunasDGBlocosAuxiliares(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				dg.ColumnHeadersVisible = true;
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.ColumnHeadersVisible = false;
				dg.Columns[0].Width = (int)Math.Round(a);
				dg.Columns[1].Width = 0;
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.MultiSelect = false;
			}
		}
	}

	private void x39Bb10DV6(object P_0, EventArgs P_1)
	{
		DataGridView dg = dgDisp;
		AtualizaColunasDGContatosDisp(ref dg);
		dgDisp = dg;
		dg = dgBlocos;
		AtualizaColunasDGBlocosAuxiliares(ref dg);
		dgBlocos = dg;
		dg = dgContatos;
		clsDispositivoAuxiliares.AtualizaColunasDGContatosAuxiliares(ref dg);
		dgContatos = dg;
	}

	private void BELBM8LqsN(object P_0, DataGridViewCellEventArgs P_1)
	{
		string text = Conversions.ToString(dgContatos.SelectedRows[0].Cells[9].Value);
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			clsBlocos.MostraBloco(text);
		}
	}
}
