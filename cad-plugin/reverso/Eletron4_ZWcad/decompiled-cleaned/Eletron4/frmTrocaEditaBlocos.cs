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

namespace Eletron4;

[DesignerGenerated]
public class frmTrocaEditaBlocos : Form
{
	private IContainer YTLp37TZtwQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDesenho")]
	private TextBox SG0p3qHHNC6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btTrocaosPaineis")]
	[CompilerGenerated]
	private Button D1vp3atPsq6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbTrocar")]
	private RadioButton RKvp38UNYkR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbSubstituir")]
	private RadioButton biEp3N8BSr7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecionaSimbologia")]
	private Button Ja5p3FTCDpl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecionaDWG")]
	private Button qEpp3QWhDWH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckSelecionado")]
	private CheckBox fxXp3PvEPJ6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckTodos")]
	private CheckBox y8sp3c96q66;

	[AccessedThroughProperty("dgBlocos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView QhUp3KysTxV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBloco")]
	private TextBox W4ep3ey4Gxs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip ARXp32LDRBj;

	private List<string> vY4p33YnXUi;

	private List<string> klSp3ndwstI;

	private structureAtributosSub[] mgWp31IkDKK;

	private string jo3p3lm8aLn;

	private string Ul5p35pHeGj;

	private object[,] lc8p30eKZep;

	private string Npcp3RYBLBx;

	internal virtual TextBox tbDesenho
	{
		[CompilerGenerated]
		get
		{
			return SG0p3qHHNC6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SG0p3qHHNC6 = value;
		}
	}

	internal virtual Button btTrocaosPaineis
	{
		[CompilerGenerated]
		get
		{
			return D1vp3atPsq6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = D27p3IIAwtp;
			Button button = D1vp3atPsq6;
			if (button != null)
			{
				button.Click -= value2;
			}
			D1vp3atPsq6 = value;
			button = D1vp3atPsq6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbTrocar
	{
		[CompilerGenerated]
		get
		{
			return RKvp38UNYkR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qN6p3Lslj0i;
			RadioButton radioButton = RKvp38UNYkR;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			RKvp38UNYkR = value;
			radioButton = RKvp38UNYkR;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbSubstituir
	{
		[CompilerGenerated]
		get
		{
			return biEp3N8BSr7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = J0Zp3wHRmcp;
			RadioButton radioButton = biEp3N8BSr7;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			biEp3N8BSr7 = value;
			radioButton = biEp3N8BSr7;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btSelecionaSimbologia
	{
		[CompilerGenerated]
		get
		{
			return Ja5p3FTCDpl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Q6Hp3bnHAIQ;
			Button button = Ja5p3FTCDpl;
			if (button != null)
			{
				button.Click -= value2;
			}
			Ja5p3FTCDpl = value;
			button = Ja5p3FTCDpl;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSelecionaDWG
	{
		[CompilerGenerated]
		get
		{
			return qEpp3QWhDWH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rYTp3xvav5j;
			Button button = qEpp3QWhDWH;
			if (button != null)
			{
				button.Click -= value2;
			}
			qEpp3QWhDWH = value;
			button = qEpp3QWhDWH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox ckSelecionado
	{
		[CompilerGenerated]
		get
		{
			return fxXp3PvEPJ6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zEup3Mj6Q12;
			CheckBox checkBox = fxXp3PvEPJ6;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			fxXp3PvEPJ6 = value;
			checkBox = fxXp3PvEPJ6;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox ckTodos
	{
		[CompilerGenerated]
		get
		{
			return y8sp3c96q66;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = M9np3Ov7dFb;
			CheckBox checkBox = y8sp3c96q66;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			y8sp3c96q66 = value;
			checkBox = y8sp3c96q66;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgBlocos
	{
		[CompilerGenerated]
		get
		{
			return QhUp3KysTxV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QhUp3KysTxV = value;
		}
	}

	internal virtual TextBox tbBloco
	{
		[CompilerGenerated]
		get
		{
			return W4ep3ey4Gxs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			W4ep3ey4Gxs = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && YTLp37TZtwQ != null)
			{
				YTLp37TZtwQ.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void HaRp3js4Nlq()
	{
		YTLp37TZtwQ = new Container();
		tbDesenho = new TextBox();
		btTrocaosPaineis = new Button();
		rbTrocar = new RadioButton();
		rbSubstituir = new RadioButton();
		btSelecionaSimbologia = new Button();
		btSelecionaDWG = new Button();
		ckSelecionado = new CheckBox();
		ckTodos = new CheckBox();
		dgBlocos = new DataGridView();
		tbBloco = new TextBox();
		FDqpBiUmZij(new ToolTip(YTLp37TZtwQ));
		((ISupportInitialize)dgBlocos).BeginInit();
		SuspendLayout();
		tbDesenho.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tbDesenho.Location = new Point(12, 35);
		tbDesenho.Name = "tbDesenho";
		tbDesenho.Size = new Size(288, 20);
		tbDesenho.TabIndex = 168;
		btTrocaosPaineis.Anchor = AnchorStyles.Bottom;
		btTrocaosPaineis.FlatStyle = FlatStyle.Flat;
		btTrocaosPaineis.ForeColor = SystemColors.Control;
		btTrocaosPaineis.Image = Resources.Update_32;
		btTrocaosPaineis.Location = new Point(157, 165);
		btTrocaosPaineis.Name = "btTrocaosPaineis";
		btTrocaosPaineis.Size = new Size(40, 40);
		btTrocaosPaineis.TabIndex = 170;
		btTrocaosPaineis.UseVisualStyleBackColor = true;
		rbTrocar.AutoSize = true;
		rbTrocar.Location = new Point(12, 12);
		rbTrocar.Name = "rbTrocar";
		rbTrocar.Size = new Size(100, 17);
		rbTrocar.TabIndex = 171;
		rbTrocar.TabStop = true;
		rbTrocar.Text = "rbTrocar Blocos";
		rbTrocar.UseVisualStyleBackColor = true;
		rbSubstituir.AutoSize = true;
		rbSubstituir.Location = new Point(188, 12);
		rbSubstituir.Name = "rbSubstituir";
		rbSubstituir.Size = new Size(112, 17);
		rbSubstituir.TabIndex = 172;
		rbSubstituir.TabStop = true;
		rbSubstituir.Text = "rbSubstituir Blocos";
		rbSubstituir.UseVisualStyleBackColor = true;
		btSelecionaSimbologia.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSelecionaSimbologia.FlatStyle = FlatStyle.Flat;
		btSelecionaSimbologia.ForeColor = SystemColors.Control;
		btSelecionaSimbologia.Image = Resources.DWG;
		btSelecionaSimbologia.Location = new Point(306, 119);
		btSelecionaSimbologia.Name = "btSelecionaSimbologia";
		btSelecionaSimbologia.Size = new Size(40, 40);
		btSelecionaSimbologia.TabIndex = 173;
		btSelecionaSimbologia.UseVisualStyleBackColor = true;
		btSelecionaDWG.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btSelecionaDWG.FlatStyle = FlatStyle.Flat;
		btSelecionaDWG.ForeColor = SystemColors.Control;
		btSelecionaDWG.Image = Resources.Select_32;
		btSelecionaDWG.Location = new Point(306, 24);
		btSelecionaDWG.Name = "btSelecionaDWG";
		btSelecionaDWG.Size = new Size(40, 40);
		btSelecionaDWG.TabIndex = 174;
		btSelecionaDWG.UseVisualStyleBackColor = true;
		ckSelecionado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ckSelecionado.AutoSize = true;
		ckSelecionado.Location = new Point(15, 60);
		ckSelecionado.Name = "ckSelecionado";
		ckSelecionado.Size = new Size(97, 17);
		ckSelecionado.TabIndex = 175;
		ckSelecionado.Text = "ckSelecionado";
		ckSelecionado.UseVisualStyleBackColor = true;
		ckTodos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ckTodos.AutoSize = true;
		ckTodos.Location = new Point(188, 60);
		ckTodos.Name = "ckTodos";
		ckTodos.Size = new Size(68, 17);
		ckTodos.TabIndex = 176;
		ckTodos.Text = "ckTodos";
		ckTodos.UseVisualStyleBackColor = true;
		dgBlocos.AllowUserToAddRows = false;
		dgBlocos.AllowUserToDeleteRows = false;
		dgBlocos.AllowUserToResizeRows = false;
		dgBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgBlocos.BackgroundColor = Color.White;
		dgBlocos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBlocos.Location = new Point(12, 35);
		dgBlocos.MultiSelect = false;
		dgBlocos.Name = "dgBlocos";
		dgBlocos.ReadOnly = true;
		dgBlocos.RowHeadersVisible = false;
		dgBlocos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBlocos.Size = new Size(288, 124);
		dgBlocos.TabIndex = 177;
		tbBloco.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tbBloco.Location = new Point(12, 94);
		tbBloco.Multiline = true;
		tbBloco.Name = "tbBloco";
		tbBloco.Size = new Size(288, 65);
		tbBloco.TabIndex = 178;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(354, 217);
		Controls.Add(tbBloco);
		Controls.Add(ckTodos);
		Controls.Add(ckSelecionado);
		Controls.Add(btSelecionaDWG);
		Controls.Add(btSelecionaSimbologia);
		Controls.Add(rbSubstituir);
		Controls.Add(rbTrocar);
		Controls.Add(btTrocaosPaineis);
		Controls.Add(tbDesenho);
		Controls.Add(dgBlocos);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmTrocaEditaBlocos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Trocar Blocos";
		((ISupportInitialize)dgBlocos).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return ARXp32LDRBj;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		ARXp32LDRBj = WithEventsValue;
	}

	public frmTrocaEditaBlocos()
	{
		vY4p33YnXUi = new List<string>();
		klSp3ndwstI = new List<string>();
		jo3p3lm8aLn = "";
		Ul5p35pHeGj = "";
		Npcp3RYBLBx = "";
		try
		{
			if (!Geral.ExisteForm("frmTrocaEditaBlocos"))
			{
				HaRp3js4Nlq();
				mgWp31IkDKK = new structureAtributosSub[1];
				Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 595], " - "), DeclaracoesGeral.mMensagem[1, 596]));
				ckTodos.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1291], DeclaracoesGeral.mMensagem[1, 1292]));
				ckSelecionado.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1294]);
				rbTrocar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 595]);
				rbSubstituir.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 596]);
				rbTrocar.Checked = true;
				ckSelecionado.Checked = true;
				Application.ShowModelessDialog((Form)this);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void qN6p3Lslj0i(object P_0, EventArgs P_1)
	{
		vY4p33YnXUi.Clear();
		btSelecionaDWG.Visible = false;
		tbDesenho.Visible = false;
		ckSelecionado.Visible = false;
		ckTodos.Visible = false;
		tbBloco.Visible = false;
		dgBlocos.Visible = true;
		btSelecionaSimbologia.Enabled = true;
	}

	private void J0Zp3wHRmcp(object P_0, EventArgs P_1)
	{
		btSelecionaDWG.Visible = true;
		tbDesenho.Visible = true;
		ckSelecionado.Visible = true;
		ckTodos.Visible = true;
		tbBloco.Visible = true;
		dgBlocos.Visible = false;
		if (Information.UBound(mgWp31IkDKK) == 0)
		{
			btSelecionaSimbologia.Enabled = false;
		}
	}

	private void rYTp3xvav5j(object P_0, EventArgs P_1)
	{
		string sNomeDoBloco = "";
		clsBlocos.Unhighlight();
		Npcp3RYBLBx = Conversions.ToString(clsTrocaEditaBlocos.selecionaBlocosParaTrocar(ref mgWp31IkDKK, ref sNomeDoBloco, ref jo3p3lm8aLn));
		int num = clsTrocaEditaBlocos.BuscaNumeroDeBlocosParaTrocar(sNomeDoBloco);
		tbDesenho.Text = sNomeDoBloco;
		btSelecionaSimbologia.Enabled = true;
		ckSelecionado.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1294]);
		ckTodos.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1291], DeclaracoesGeral.mMensagem[1, 1292]));
		if (num > 0)
		{
			ckTodos.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1291], num), " "), DeclaracoesGeral.mMensagem[1, 1292]));
		}
		if (Information.UBound(mgWp31IkDKK) == 1)
		{
			ckSelecionado.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(Information.UBound(mgWp31IkDKK)) + " ", DeclaracoesGeral.mMensagem[1, 1293]));
		}
		if (Information.UBound(mgWp31IkDKK) > 1)
		{
			ckSelecionado.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(Information.UBound(mgWp31IkDKK)) + " ", DeclaracoesGeral.mMensagem[1, 1294]));
		}
		if (Information.UBound(mgWp31IkDKK) == 0)
		{
			btSelecionaSimbologia.Enabled = false;
		}
	}

	private void Q6Hp3bnHAIQ(object P_0, EventArgs P_1)
	{
		Ul5p35pHeGj = "";
		if (!rbTrocar.Checked)
		{
			tbBloco.Text = clsBlocos.selecionaUmBlocoDaSimbologia(jo3p3lm8aLn);
			Ul5p35pHeGj = clsBlocos.BuscaNomeDoBloco(tbBloco.Text);
			return;
		}
		formataDGBlocos();
		List<string> lNomeBlocosSel = klSp3ndwstI;
		DataGridView dg = dgBlocos;
		clsBlocos.selecionaVariosBlocos("", lNomeBlocosSel, ref dg);
		dgBlocos = dg;
		AtualizaDGBlocos();
	}

	public void formataDGBlocos()
	{
		try
		{
			dgBlocos.Rows.Clear();
			dgBlocos.Columns.Clear();
			dgBlocos.ColumnHeadersVisible = false;
			dgBlocos.Columns.Add("Caminho", "");
			dgBlocos.Columns.Add("Nome", "");
			dgBlocos.Columns.Add("Handle", "");
			AtualizaDGBlocos();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGBlocos()
	{
		checked
		{
			if (dgBlocos.Columns.Count != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBlocos)) ? ((double)(dgBlocos.Width - 4)) : ((double)(dgBlocos.Width - 21)));
				dgBlocos.Columns[0].Width = 0;
				dgBlocos.Columns[0].Visible = false;
				dgBlocos.Columns[1].Width = (int)Math.Round(a);
				dgBlocos.Columns[1].Visible = true;
				dgBlocos.Columns[2].Width = 0;
				dgBlocos.Columns[2].Visible = false;
			}
		}
	}

	private void zEup3Mj6Q12(object P_0, EventArgs P_1)
	{
		if (ckSelecionado.Checked)
		{
			ckTodos.Checked = false;
		}
	}

	private void M9np3Ov7dFb(object P_0, EventArgs P_1)
	{
		if (ckTodos.Checked)
		{
			ckSelecionado.Checked = false;
		}
	}

	private void D27p3IIAwtp(object P_0, EventArgs P_1)
	{
		clsTrocaEditaBlocosMat.lBlocosExistentesTrocados.Clear();
		btTrocaosPaineis.Enabled = false;
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		checked
		{
			if (!rbTrocar.Checked)
			{
				if ((Operators.CompareString(tbDesenho.Text, "", TextCompare: true) == 0) | (Operators.CompareString(tbBloco.Text, "", TextCompare: true) == 0))
				{
					return;
				}
				if (ckTodos.Checked)
				{
					mgWp31IkDKK = new structureAtributosSub[1];
					clsTrocaEditaBlocos.BuscaBlocosIguaisAoSelecionado(ref mgWp31IkDKK, tbDesenho.Text);
				}
				if (Operators.CompareString(tbDesenho.Text, Ul5p35pHeGj, TextCompare: true) == 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1296], " "), Ul5p35pHeGj), "\r\n"), DeclaracoesGeral.mMensagem[1, 1297]), DeclaracoesGeral.mMensagem[1, 595]), MsgBoxStyle.Information, "Elétron");
					return;
				}
				clsTrocaEditaBlocos.BuscaAtributosDeTodosOsBlocosIguaisAoSelecionado(Ul5p35pHeGj, tbDesenho.Text);
				clsTrocaEditaBlocos.insereUmBlocoParaSubstituir(ref mgWp31IkDKK, tbDesenho.Text, Ul5p35pHeGj, tbBloco.Text, bSelecionados: true);
				clsTrocaEditaBlocos.ApagaOsBlocosAntigos();
				clsTrocaEditaBlocos.corrigeOsHandlesDosBlocos(ref mgWp31IkDKK);
				mdiActiveDocument.SendStringToExecute("_.attsync Name " + Ul5p35pHeGj + "\n", true, false, true);
				mdiActiveDocument.SendStringToExecute("CorrigeAtributos\n", true, false, true);
				if (Ul5p35pHeGj.Contains("_E_"))
				{
					clsPortas.AtualizaAsPortasTrocadas(mgWp31IkDKK);
				}
				if (Ul5p35pHeGj.Contains("_A_"))
				{
					Correcao.CorrigeContatosAux();
					Correcao.CorrigeBlocosContatosAux();
				}
				if (Ul5p35pHeGj.Contains("_B_"))
				{
					mdiActiveDocument.SendStringToExecute("CorrigePainelET1DosBornes\n", true, false, true);
				}
				if (Operators.CompareString(jo3p3lm8aLn, "M", TextCompare: true) == 0 && Operators.CompareString(jo3p3lm8aLn, "M", TextCompare: true) == 0)
				{
					clsPortas.AtualizaChavePrimariaPortasDefinicao(ref mgWp31IkDKK);
				}
			}
			else
			{
				if (dgBlocos.RowCount == 0)
				{
					return;
				}
				if (Conversions.ToBoolean(clsTrocaEditaBlocos.LeAtributos(klSp3ndwstI, ref vY4p33YnXUi, ref clsTrocaEditaBlocosMat.lBlocosExistentesTrocados)))
				{
					DataGridView dg = dgBlocos;
					clsBlocos.InsereOsBlocos(ref dg);
					dgBlocos = dg;
					dg = dgBlocos;
					clsBlocos.ExecutaATTSYNC(ref dg);
					dgBlocos = dg;
					dg = dgBlocos;
					clsBlocos.removeOsBlocos(ref dg);
					dgBlocos = dg;
					mdiActiveDocument.SendStringToExecute("CorrigeAtributos\n", true, false, true);
				}
				clsTrocaEditaBlocosMat.sBlocosNaoExistentes = "";
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				int num = dgBlocos.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (clsTrocaEditaBlocosMat.lBlocosExistentesTrocados.Contains(Conversions.ToString(dgBlocos.Rows[i].Cells[1].Value)))
					{
						if (dgBlocos.Rows[i].Cells[1].Value.ToString().Contains("_A_"))
						{
							flag = true;
						}
						if (dgBlocos.Rows[i].Cells[1].Value.ToString().Contains("_B_"))
						{
							flag2 = true;
						}
						if (dgBlocos.Rows[i].Cells[1].Value.ToString().Contains("_E_"))
						{
							flag3 = true;
						}
					}
					else
					{
						if (Operators.CompareString(clsTrocaEditaBlocosMat.sBlocosNaoExistentes, "", TextCompare: true) != 0)
						{
							clsTrocaEditaBlocosMat.sBlocosNaoExistentes = clsTrocaEditaBlocosMat.sBlocosNaoExistentes + ";\r\n" + dgBlocos.Rows[i].Cells[1].Value.ToString().ToUpper();
						}
						if (Operators.CompareString(clsTrocaEditaBlocosMat.sBlocosNaoExistentes, "", TextCompare: true) == 0)
						{
							clsTrocaEditaBlocosMat.sBlocosNaoExistentes = Conversions.ToString(Operators.ConcatenateObject("\r\n", dgBlocos.Rows[i].Cells[1].Value));
						}
					}
				}
				if (flag)
				{
					Correcao.CorrigeBlocosContatosAux();
				}
				if (flag2)
				{
					mdiActiveDocument.SendStringToExecute("CorrigePainelET1DosBornes\n", true, false, true);
				}
				if (flag | flag3)
				{
					mdiActiveDocument.SendStringToExecute("PreencheNovosAtributos\n", true, false, true);
				}
			}
			btTrocaosPaineis.Enabled = true;
		}
	}
}
