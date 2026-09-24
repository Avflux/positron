using System;
using System.ComponentModel;
using System.Data;
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
public class frmGerenciadorDWG : Form
{
	private IContainer grhz65iTZV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionar")]
	private Button JISzt7qTwB;

	[CompilerGenerated]
	[AccessedThroughProperty("btAtualizar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button pTBzjC8evu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btApagar")]
	private Button AlPzLnK1q9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSubstituir")]
	private Button x6Kzwo5AfY;

	[AccessedThroughProperty("LabelQuantidade")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label s4VzxlKVjt;

	[CompilerGenerated]
	[AccessedThroughProperty("BTExcluido")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button KZ5zbqo4PT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgDWG")]
	private DataGridView ltPzMXX9fG;

	private string HjVzO7YkYs;

	private string iHmzI1PYeD;

	private DateTime Qg7z7WQKR8;

	private bool S7Xzq2jtlB;

	private string CyuzakKNKn;

	private string ioez8Sq0UD;

	internal virtual Button btAdicionar
	{
		[CompilerGenerated]
		get
		{
			return JISzt7qTwB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = r9lzo89kwT;
			Button button = JISzt7qTwB;
			if (button != null)
			{
				button.Click -= value2;
			}
			JISzt7qTwB = value;
			button = JISzt7qTwB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btAtualizar
	{
		[CompilerGenerated]
		get
		{
			return pTBzjC8evu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XcCzGoSIQ7;
			Button button = pTBzjC8evu;
			if (button != null)
			{
				button.Click -= value2;
			}
			pTBzjC8evu = value;
			button = pTBzjC8evu;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagar
	{
		[CompilerGenerated]
		get
		{
			return AlPzLnK1q9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = q78zHkEDkp;
			Button button = AlPzLnK1q9;
			if (button != null)
			{
				button.Click -= value2;
			}
			AlPzLnK1q9 = value;
			button = AlPzLnK1q9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSubstituir
	{
		[CompilerGenerated]
		get
		{
			return x6Kzwo5AfY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LdszkSnntB;
			Button button = x6Kzwo5AfY;
			if (button != null)
			{
				button.Click -= value2;
			}
			x6Kzwo5AfY = value;
			button = x6Kzwo5AfY;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelQuantidade
	{
		[CompilerGenerated]
		get
		{
			return s4VzxlKVjt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s4VzxlKVjt = value;
		}
	}

	internal virtual Button BTExcluido
	{
		[CompilerGenerated]
		get
		{
			return KZ5zbqo4PT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KZ5zbqo4PT = value;
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return ltPzMXX9fG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ltPzMXX9fG = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && grhz65iTZV != null)
			{
				grhz65iTZV.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void NVtzJXmTv9()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmGerenciadorDWG));
		btSubstituir = new Button();
		btApagar = new Button();
		btAtualizar = new Button();
		btAdicionar = new Button();
		LabelQuantidade = new Label();
		BTExcluido = new Button();
		dgDWG = new DataGridView();
		((ISupportInitialize)dgDWG).BeginInit();
		SuspendLayout();
		btSubstituir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btSubstituir.FlatStyle = FlatStyle.Flat;
		btSubstituir.ForeColor = SystemColors.Control;
		btSubstituir.Image = Resources.SubstituirDWG_32;
		btSubstituir.Location = new Point(932, 216);
		btSubstituir.Name = "btSubstituir";
		btSubstituir.Size = new Size(36, 36);
		btSubstituir.TabIndex = 5;
		btSubstituir.UseVisualStyleBackColor = true;
		btApagar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(932, 158);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(36, 36);
		btApagar.TabIndex = 4;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btAtualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btAtualizar.FlatStyle = FlatStyle.Flat;
		btAtualizar.ForeColor = SystemColors.Control;
		btAtualizar.Image = Resources.Update_32;
		btAtualizar.Location = new Point(932, 108);
		btAtualizar.Name = "btAtualizar";
		btAtualizar.Size = new Size(36, 36);
		btAtualizar.TabIndex = 3;
		btAtualizar.UseVisualStyleBackColor = true;
		btAdicionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btAdicionar.FlatStyle = FlatStyle.Flat;
		btAdicionar.ForeColor = SystemColors.Control;
		btAdicionar.Image = (Image)componentResourceManager.GetObject("btAdicionar.Image");
		btAdicionar.Location = new Point(932, 51);
		btAdicionar.Name = "btAdicionar";
		btAdicionar.Size = new Size(36, 36);
		btAdicionar.TabIndex = 2;
		btAdicionar.UseVisualStyleBackColor = true;
		LabelQuantidade.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LabelQuantidade.BorderStyle = BorderStyle.Fixed3D;
		LabelQuantidade.Location = new Point(932, 12);
		LabelQuantidade.Name = "LabelQuantidade";
		LabelQuantidade.Size = new Size(37, 24);
		LabelQuantidade.TabIndex = 9;
		LabelQuantidade.Text = "Label1";
		LabelQuantidade.TextAlign = ContentAlignment.MiddleCenter;
		BTExcluido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTExcluido.BackColor = Color.Red;
		BTExcluido.FlatStyle = FlatStyle.Flat;
		BTExcluido.ForeColor = SystemColors.Control;
		BTExcluido.Location = new Point(959, 51);
		BTExcluido.Name = "BTExcluido";
		BTExcluido.Size = new Size(10, 8);
		BTExcluido.TabIndex = 8;
		BTExcluido.UseVisualStyleBackColor = false;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgDWG.BorderStyle = BorderStyle.Fixed3D;
		dgDWG.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.Location = new Point(17, 12);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(909, 289);
		dgDWG.TabIndex = 1;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(979, 314);
		Controls.Add(BTExcluido);
		Controls.Add(LabelQuantidade);
		Controls.Add(dgDWG);
		Controls.Add(btSubstituir);
		Controls.Add(btApagar);
		Controls.Add(btAtualizar);
		Controls.Add(btAdicionar);
		MinimumSize = new Size(650, 309);
		Name = "frmGerenciadorDWG";
		ShowInTaskbar = false;
		Text = "GER DWG";
		((ISupportInitialize)dgDWG).EndInit();
		ResumeLayout(performLayout: false);
	}

	public frmGerenciadorDWG()
	{
		Resize += wdYzvSPyO3;
		S7Xzq2jtlB = false;
		CyuzakKNKn = "DWG";
		ioez8Sq0UD = "DWGH";
		if (Geral.ExisteForm("frmGerenciadorDWG"))
		{
			return;
		}
		NVtzJXmTv9();
		if (clsAuxiliar.BancoValido())
		{
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 318]);
			ToolTip toolTip = new ToolTip();
			toolTip.AutoPopDelay = 5000;
			toolTip.InitialDelay = 1000;
			toolTip.ReshowDelay = 500;
			toolTip.ShowAlways = true;
			toolTip.SetToolTip(btAdicionar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 319]));
			toolTip.SetToolTip(btAtualizar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 320]));
			toolTip.SetToolTip(btApagar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 321]));
			toolTip.SetToolTip(btSubstituir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 322]));
			HjVzO7YkYs = Environment.UserName;
			iHmzI1PYeD = Environment.UserName;
			Qg7z7WQKR8 = Conversions.ToDate(DateTime.Now.ToString());
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			rkJzhDwcXc();
			S7Xzq2jtlB = true;
		}
	}

	private void rkJzhDwcXc()
	{
		checked
		{
			try
			{
				cDadosAccess.carregaDadosDWG();
				XLhzft67pY("ASC");
				if (dgDWG.Rows.Count > 0 && DeclaracoesGeral.arqAtivo.Indice > 0)
				{
					int num = dgDWG.RowCount - 1;
					for (int i = 0; i <= num; i++)
					{
						if (Conversions.ToInteger(dgDWG.Rows[i].Cells[0].Value) != DeclaracoesGeral.arqAtivo.Indice)
						{
							btAdicionar.Enabled = true;
							dgDWG.Rows[i].Selected = false;
							continue;
						}
						dgDWG.Rows[i].Selected = true;
						btAdicionar.Enabled = false;
						break;
					}
				}
				VerificaArquivoExcluido();
				Vg6zDtum2o();
				LabelQuantidade.Text = Conversions.ToString(dgDWG.Rows.Count);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message.ToString(), MsgBoxStyle.Critical, "Eletron");
				ProjectData.ClearProjectError();
			}
		}
	}

	private void r9lzo89kwT(object P_0, EventArgs P_1)
	{
		Qg7z7WQKR8 = Conversions.ToDate(DateTime.Now.ToString());
		bool flag = false;
		cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
		bool flag2 = false;
		try
		{
			if (DeclaracoesGeral.arqAtivo.Nome.Length <= 50)
			{
				int num = cDadosAccessDWG2.BuscaIndiceArquivo("DWGH", DeclaracoesGeral.arqAtivo.Nome);
				flag2 = cDadosAccessDWG2.BuscaIndice("DWG", Conversions.ToString(num));
				if (!(!cDadosAccessDWG2.ExisteArquivo(ioez8Sq0UD, DeclaracoesGeral.arqAtivo.Nome) | flag2))
				{
					cDadosAccessDWG2.RecuperaDWG(CyuzakKNKn, ioez8Sq0UD, DeclaracoesGeral.arqAtivo.Nome);
					cDadosAccessDWG2.AtualizaDWG(CyuzakKNKn, iHmzI1PYeD, Qg7z7WQKR8, DeclaracoesGeral.arqAtivo.Nome);
					cDadosAccessDWG2.RemoveDWG(ioez8Sq0UD, DeclaracoesGeral.arqAtivo.Nome);
					cDadosAccessDWG2.fechaConexao();
					cDadosAccess.carregaDadosDWG();
					flag = false;
				}
				else
				{
					int indice = cDadosAccessDWG2.ProximoIndice(CyuzakKNKn);
					cDadosAccessDWG2.AdicionaCaderno(CyuzakKNKn, indice, HjVzO7YkYs, iHmzI1PYeD, Qg7z7WQKR8);
					if (flag2)
					{
						cDadosAccessDWG2.RemoveDWG(ioez8Sq0UD, DeclaracoesGeral.arqAtivo.Nome);
					}
					cDadosAccessDWG2.fechaConexao();
					btAdicionar.Enabled = false;
					cDadosAccess.carregaDadosDWG();
					flag = true;
				}
				Vg6zDtum2o();
				LabelQuantidade.Text = Conversions.ToString(dgDWG.Rows.Count);
				BTExcluido.Visible = false;
				btAdicionar.Enabled = false;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1922]), MsgBoxStyle.Information, "Eletron");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
		if (!flag)
		{
			rkJzhDwcXc();
			XLhzft67pY("ASC");
			VerificaArquivoExcluido();
		}
		else
		{
			rkJzhDwcXc();
			XLhzft67pY("DESC");
		}
	}

	private void XcCzGoSIQ7(object P_0, EventArgs P_1)
	{
		Qg7z7WQKR8 = Conversions.ToDate(DateTime.Now.ToString());
		try
		{
			if (DeclaracoesGeral.arqAtivo.Indice <= 0)
			{
				if (DeclaracoesGeral.arqAtivo.Indice == 0)
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 323]), MsgBoxStyle.Information, "Eletron");
				}
				return;
			}
			cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
			cDadosAccessDWG2.AtualizaValores(CyuzakKNKn, iHmzI1PYeD, Qg7z7WQKR8);
			cDadosAccessDWG2.fechaConexao();
			cDadosAccess.carregaDadosDWG();
			XLhzft67pY("ASC");
			cDadosAccess.carregaDWGDicionario();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	private void q78zHkEDkp(object P_0, EventArgs P_1)
	{
		if (dgDWG.SelectedRows.Count == 0)
		{
			return;
		}
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 489]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		Qg7z7WQKR8 = Conversions.ToDate(DateTime.Now.ToString());
		Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		string text = Conversions.ToString(dgDWG.SelectedRows[0].Cells[3].Value);
		dgDWG.Rows.RemoveAt(dgDWG.SelectedRows[0].Index);
		if (Operators.CompareString(text, "", TextCompare: true) == 0)
		{
			return;
		}
		try
		{
			cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
			cDadosAccessDWG2.RecuperaDWG(ioez8Sq0UD, CyuzakKNKn, text);
			cDadosAccessDWG2.AtualizaDWG(ioez8Sq0UD, iHmzI1PYeD, Qg7z7WQKR8, text);
			cDadosAccessDWG2.RemoveDWG(CyuzakKNKn, text);
			cDadosAccessDWG2.fechaConexao();
			LabelQuantidade.Text = Conversions.ToString(dgDWG.Rows.Count);
			VerificaArquivoExcluido();
			btAdicionar.Enabled = true;
			Vg6zDtum2o();
			cDadosAccess.carregaDWGDicionario();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	private void LdszkSnntB(object P_0, EventArgs P_1)
	{
		if (DeclaracoesGeral.arqAtivo.Nome.Length <= 50)
		{
			Qg7z7WQKR8 = Conversions.ToDate(DateTime.Now.ToString());
			int num = Pjwzdnx1I4();
			if (num <= 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 327]), MsgBoxStyle.Information, "Eletron");
				return;
			}
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 324]), MsgBoxStyle.YesNo);
			if (msgBoxResult == MsgBoxResult.No)
			{
				return;
			}
			try
			{
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 326]), MsgBoxStyle.Information, "Eletron");
					return;
				}
				cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
				if (cDadosAccessDWG2.ExisteArquivo(CyuzakKNKn, DeclaracoesGeral.arqAtivo.Nome))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 325]), MsgBoxStyle.Information, "Eletron");
				}
				else
				{
					cDadosAccessDWG2.AtualizaCaderno(CyuzakKNKn, iHmzI1PYeD, Qg7z7WQKR8, num);
					DeclaracoesGeral.arqAtivo.Indice = num;
					btAdicionar.Enabled = false;
				}
				cDadosAccessDWG2.RemoveDWG(ioez8Sq0UD, DeclaracoesGeral.arqAtivo.Nome);
				cDadosAccessDWG2.fechaConexao();
				cDadosAccess.carregaDadosDWG();
				XLhzft67pY("ASC");
				VerificaArquivoExcluido();
				cDadosAccess.carregaDWGDicionario();
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
				ProjectData.ClearProjectError();
				return;
			}
			finally
			{
			}
		}
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 485]), MsgBoxStyle.Information, "Eletron");
	}

	private int Pjwzdnx1I4()
	{
		int result = 0;
		checked
		{
			int num = dgDWG.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgDWG.Rows[i].Selected)
				{
					result = Conversions.ToInteger(dgDWG.Rows[i].Cells[0].Value);
					break;
				}
			}
			return result;
		}
	}

	private void XLhzft67pY(string P_0)
	{
		cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
		DataTable dataTable = cDadosAccessDWG2.atualizaDG(P_0);
		dgDWG.DataSource = dataTable.DefaultView;
		checked
		{
			if (dgDWG.Rows.Count <= 0)
			{
				btAdicionar.Enabled = true;
			}
			else
			{
				int num = dgDWG.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDWG.Rows[i].Selected = false;
				}
				btAdicionar.Enabled = true;
				int num2 = dgDWG.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (Conversions.ToInteger(dgDWG.Rows[j].Cells[0].Value) == DeclaracoesGeral.arqAtivo.Indice)
					{
						dgDWG.Rows[j].Selected = true;
						btAdicionar.Enabled = false;
						break;
					}
				}
			}
			cDadosAccessDWG2.fechaConexao();
		}
	}

	public void VerificaArquivoExcluido()
	{
		cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
		BTExcluido.Visible = cDadosAccessDWG2.verificaArquivoExcluido(ioez8Sq0UD, DeclaracoesGeral.arqAtivo.Nome);
		cDadosAccessDWG2.fechaConexao();
	}

	private void Vg6zDtum2o()
	{
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDWG)) ? ((double)(dgDWG.Width - 5 - 40 - 35 - 90 - 90 - 110)) : ((double)(dgDWG.Width - 22 - 40 - 35 - 90 - 90 - 110)));
			dgDWG.Columns[0].Width = 40;
			dgDWG.Columns[1].Width = 35;
			dgDWG.Columns[2].Width = (int)Math.Round(num * 0.7);
			dgDWG.Columns[3].Width = (int)Math.Round(num * 0.3);
			dgDWG.Columns[4].Width = 90;
			dgDWG.Columns[5].Width = 90;
			dgDWG.Columns[6].Width = 110;
			int num2 = 0;
			do
			{
				dgDWG.Columns[num2].Visible = true;
				dgDWG.Columns[num2].ReadOnly = false;
				num2++;
			}
			while (num2 <= 6);
			dgDWG.MultiSelect = true;
		}
	}

	private void wdYzvSPyO3(object P_0, EventArgs P_1)
	{
		if (S7Xzq2jtlB)
		{
			Vg6zDtum2o();
		}
	}
}
