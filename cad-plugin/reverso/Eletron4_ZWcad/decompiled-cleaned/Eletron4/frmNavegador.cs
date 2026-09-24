using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmNavegador : Form
{
	private IContainer xQBpvPJlOGv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBlocos")]
	private DataGridView eRbpvcfCghu;

	[CompilerGenerated]
	[AccessedThroughProperty("lbNome1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label V70pvK6YkjY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNome1")]
	[CompilerGenerated]
	private TextBox c3VpvexJkKY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbNome2")]
	private Label KFFpv2xQkbt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNome2")]
	private TextBox Uampv3mof8F;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisa")]
	private Button lGopvnV4Nuk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbAlternativo")]
	[CompilerGenerated]
	private Label RInpv13lIVA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbAlternativo")]
	private TextBox TmLpvltenlP;

	[CompilerGenerated]
	[AccessedThroughProperty("CKPrincipal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox Cdfpv5osSJ3;

	[AccessedThroughProperty("CKAuxiliar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox icLpv0YpjYj;

	[AccessedThroughProperty("CKMascaras")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox EvfpvRR4SkR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKPortas")]
	private CheckBox QpdpvmVYAts;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("CKCabos")]
	private CheckBox v28pvXBBIvQ;

	[CompilerGenerated]
	[AccessedThroughProperty("CKConexao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox cVvpvUW0NOW;

	[AccessedThroughProperty("CKJumpers")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox xh0pvy03ZKZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKBornes")]
	private CheckBox Vx4pvghEpgi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelTotal")]
	private Label bNIpvArIL3B;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtApaga")]
	private Button gccpvsrHxis;

	private bool lU0pvBpvMgM;

	private bool j14pvVOnEi6;

	internal virtual DataGridView dgBlocos
	{
		[CompilerGenerated]
		get
		{
			return eRbpvcfCghu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = CQypv8GFGkM;
			MouseEventHandler value3 = XhEpvN8dKnv;
			DataGridView dataGridView = eRbpvcfCghu;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			eRbpvcfCghu = value;
			dataGridView = eRbpvcfCghu;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual Label lbNome1
	{
		[CompilerGenerated]
		get
		{
			return V70pvK6YkjY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			V70pvK6YkjY = value;
		}
	}

	internal virtual TextBox tbNome1
	{
		[CompilerGenerated]
		get
		{
			return c3VpvexJkKY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			c3VpvexJkKY = value;
		}
	}

	internal virtual Label lbNome2
	{
		[CompilerGenerated]
		get
		{
			return KFFpv2xQkbt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KFFpv2xQkbt = value;
		}
	}

	internal virtual TextBox tbNome2
	{
		[CompilerGenerated]
		get
		{
			return Uampv3mof8F;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Uampv3mof8F = value;
		}
	}

	internal virtual Button btPesquisa
	{
		[CompilerGenerated]
		get
		{
			return lGopvnV4Nuk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ae0pvFeb9IO;
			Button button = lGopvnV4Nuk;
			if (button != null)
			{
				button.Click -= value2;
			}
			lGopvnV4Nuk = value;
			button = lGopvnV4Nuk;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return RInpv13lIVA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RInpv13lIVA = value;
		}
	}

	internal virtual TextBox tbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return TmLpvltenlP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TmLpvltenlP = value;
		}
	}

	internal virtual CheckBox CKPrincipal
	{
		[CompilerGenerated]
		get
		{
			return Cdfpv5osSJ3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Cdfpv5osSJ3 = value;
		}
	}

	internal virtual CheckBox CKAuxiliar
	{
		[CompilerGenerated]
		get
		{
			return icLpv0YpjYj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			icLpv0YpjYj = value;
		}
	}

	internal virtual CheckBox CKMascaras
	{
		[CompilerGenerated]
		get
		{
			return EvfpvRR4SkR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EvfpvRR4SkR = value;
		}
	}

	internal virtual CheckBox CKPortas
	{
		[CompilerGenerated]
		get
		{
			return QpdpvmVYAts;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QpdpvmVYAts = value;
		}
	}

	internal virtual CheckBox CKCabos
	{
		[CompilerGenerated]
		get
		{
			return v28pvXBBIvQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v28pvXBBIvQ = value;
		}
	}

	internal virtual CheckBox CKConexao
	{
		[CompilerGenerated]
		get
		{
			return cVvpvUW0NOW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cVvpvUW0NOW = value;
		}
	}

	internal virtual CheckBox CKJumpers
	{
		[CompilerGenerated]
		get
		{
			return xh0pvy03ZKZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xh0pvy03ZKZ = value;
		}
	}

	internal virtual CheckBox CKBornes
	{
		[CompilerGenerated]
		get
		{
			return Vx4pvghEpgi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Vx4pvghEpgi = value;
		}
	}

	internal virtual Label LabelTotal
	{
		[CompilerGenerated]
		get
		{
			return bNIpvArIL3B;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bNIpvArIL3B = value;
		}
	}

	internal virtual Button BtApaga
	{
		[CompilerGenerated]
		get
		{
			return gccpvsrHxis;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Cb3pvQ4lXsr;
			Button button = gccpvsrHxis;
			if (button != null)
			{
				button.Click -= value2;
			}
			gccpvsrHxis = value;
			button = gccpvsrHxis;
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
			if (disposing && xQBpvPJlOGv != null)
			{
				xQBpvPJlOGv.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void Y0tpvqlUqMx()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dgBlocos = new DataGridView();
		lbNome1 = new Label();
		tbNome1 = new TextBox();
		lbNome2 = new Label();
		tbNome2 = new TextBox();
		btPesquisa = new Button();
		lbAlternativo = new Label();
		tbAlternativo = new TextBox();
		CKPrincipal = new CheckBox();
		CKAuxiliar = new CheckBox();
		CKMascaras = new CheckBox();
		CKPortas = new CheckBox();
		CKCabos = new CheckBox();
		CKConexao = new CheckBox();
		CKJumpers = new CheckBox();
		CKBornes = new CheckBox();
		LabelTotal = new Label();
		BtApaga = new Button();
		((ISupportInitialize)dgBlocos).BeginInit();
		SuspendLayout();
		dgBlocos.AllowUserToAddRows = false;
		dgBlocos.AllowUserToDeleteRows = false;
		dgBlocos.AllowUserToOrderColumns = true;
		dgBlocos.AllowUserToResizeRows = false;
		dgBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgBlocos.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgBlocos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgBlocos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBlocos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgBlocos.Location = new Point(8, 12);
		dgBlocos.MultiSelect = false;
		dgBlocos.Name = "dgBlocos";
		dgBlocos.ReadOnly = true;
		dgBlocos.RowHeadersVisible = false;
		dgBlocos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBlocos.Size = new Size(694, 296);
		dgBlocos.TabIndex = 9;
		lbNome1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbNome1.BorderStyle = BorderStyle.Fixed3D;
		lbNome1.Location = new Point(382, 321);
		lbNome1.Name = "lbNome1";
		lbNome1.Size = new Size(80, 20);
		lbNome1.TabIndex = 167;
		lbNome1.Text = "Nome 1";
		lbNome1.TextAlign = ContentAlignment.MiddleCenter;
		tbNome1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbNome1.CharacterCasing = CharacterCasing.Upper;
		tbNome1.Location = new Point(468, 322);
		tbNome1.Name = "tbNome1";
		tbNome1.Size = new Size(129, 20);
		tbNome1.TabIndex = 166;
		tbNome1.TextAlign = HorizontalAlignment.Center;
		lbNome2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbNome2.BorderStyle = BorderStyle.Fixed3D;
		lbNome2.Location = new Point(382, 355);
		lbNome2.Name = "lbNome2";
		lbNome2.Size = new Size(80, 20);
		lbNome2.TabIndex = 169;
		lbNome2.Text = "Nome 2";
		lbNome2.TextAlign = ContentAlignment.MiddleCenter;
		tbNome2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbNome2.CharacterCasing = CharacterCasing.Upper;
		tbNome2.Location = new Point(468, 356);
		tbNome2.Name = "tbNome2";
		tbNome2.Size = new Size(129, 20);
		tbNome2.TabIndex = 168;
		tbNome2.TextAlign = HorizontalAlignment.Center;
		btPesquisa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btPesquisa.FlatStyle = FlatStyle.Flat;
		btPesquisa.ForeColor = SystemColors.Control;
		btPesquisa.Image = Resources.Pesquisar_32;
		btPesquisa.Location = new Point(637, 331);
		btPesquisa.Name = "btPesquisa";
		btPesquisa.Size = new Size(40, 40);
		btPesquisa.TabIndex = 174;
		btPesquisa.UseVisualStyleBackColor = true;
		lbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbAlternativo.BorderStyle = BorderStyle.Fixed3D;
		lbAlternativo.Location = new Point(382, 387);
		lbAlternativo.Name = "lbAlternativo";
		lbAlternativo.Size = new Size(80, 20);
		lbAlternativo.TabIndex = 176;
		lbAlternativo.Text = "Alternativo";
		lbAlternativo.TextAlign = ContentAlignment.MiddleCenter;
		tbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbAlternativo.CharacterCasing = CharacterCasing.Upper;
		tbAlternativo.Location = new Point(468, 388);
		tbAlternativo.Name = "tbAlternativo";
		tbAlternativo.Size = new Size(129, 20);
		tbAlternativo.TabIndex = 175;
		tbAlternativo.TextAlign = HorizontalAlignment.Center;
		CKPrincipal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKPrincipal.AutoSize = true;
		CKPrincipal.Location = new Point(12, 321);
		CKPrincipal.Name = "CKPrincipal";
		CKPrincipal.Size = new Size(66, 17);
		CKPrincipal.TabIndex = 177;
		CKPrincipal.Text = "Principal";
		CKPrincipal.UseVisualStyleBackColor = true;
		CKAuxiliar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKAuxiliar.AutoSize = true;
		CKAuxiliar.Location = new Point(160, 320);
		CKAuxiliar.Name = "CKAuxiliar";
		CKAuxiliar.Size = new Size(70, 17);
		CKAuxiliar.TabIndex = 178;
		CKAuxiliar.Text = "Auxiliares";
		CKAuxiliar.UseVisualStyleBackColor = true;
		CKMascaras.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKMascaras.AutoSize = true;
		CKMascaras.Location = new Point(12, 344);
		CKMascaras.Name = "CKMascaras";
		CKMascaras.Size = new Size(72, 17);
		CKMascaras.TabIndex = 179;
		CKMascaras.Text = "Mascaras";
		CKMascaras.UseVisualStyleBackColor = true;
		CKPortas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKPortas.AutoSize = true;
		CKPortas.Location = new Point(160, 343);
		CKPortas.Name = "CKPortas";
		CKPortas.Size = new Size(56, 17);
		CKPortas.TabIndex = 180;
		CKPortas.Text = "Portas";
		CKPortas.UseVisualStyleBackColor = true;
		CKCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKCabos.AutoSize = true;
		CKCabos.Location = new Point(12, 390);
		CKCabos.Name = "CKCabos";
		CKCabos.Size = new Size(70, 17);
		CKCabos.TabIndex = 182;
		CKCabos.Text = "CKCabos";
		CKCabos.UseVisualStyleBackColor = true;
		CKConexao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKConexao.AutoSize = true;
		CKConexao.Location = new Point(160, 367);
		CKConexao.Name = "CKConexao";
		CKConexao.Size = new Size(82, 17);
		CKConexao.TabIndex = 181;
		CKConexao.Text = "CKConexao";
		CKConexao.UseVisualStyleBackColor = true;
		CKJumpers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKJumpers.AutoSize = true;
		CKJumpers.Location = new Point(160, 390);
		CKJumpers.Name = "CKJumpers";
		CKJumpers.Size = new Size(79, 17);
		CKJumpers.TabIndex = 183;
		CKJumpers.Text = "CKJumpers";
		CKJumpers.UseVisualStyleBackColor = true;
		CKBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKBornes.AutoSize = true;
		CKBornes.Location = new Point(12, 367);
		CKBornes.Name = "CKBornes";
		CKBornes.Size = new Size(59, 17);
		CKBornes.TabIndex = 184;
		CKBornes.Text = "Bornes";
		CKBornes.UseVisualStyleBackColor = true;
		LabelTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		LabelTotal.BorderStyle = BorderStyle.Fixed3D;
		LabelTotal.Location = new Point(616, 388);
		LabelTotal.Name = "LabelTotal";
		LabelTotal.Size = new Size(86, 20);
		LabelTotal.TabIndex = 186;
		LabelTotal.Tag = "";
		LabelTotal.Text = "Total";
		LabelTotal.TextAlign = ContentAlignment.MiddleCenter;
		BtApaga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BtApaga.FlatStyle = FlatStyle.Flat;
		BtApaga.ForeColor = SystemColors.Control;
		BtApaga.Image = Resources.Delete_32;
		BtApaga.Location = new Point(336, 344);
		BtApaga.Name = "BtApaga";
		BtApaga.Size = new Size(40, 40);
		BtApaga.TabIndex = 187;
		BtApaga.Tag = "";
		BtApaga.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(714, 421);
		Controls.Add(BtApaga);
		Controls.Add(LabelTotal);
		Controls.Add(CKBornes);
		Controls.Add(CKJumpers);
		Controls.Add(CKCabos);
		Controls.Add(CKConexao);
		Controls.Add(CKPortas);
		Controls.Add(CKMascaras);
		Controls.Add(CKAuxiliar);
		Controls.Add(CKPrincipal);
		Controls.Add(lbAlternativo);
		Controls.Add(tbAlternativo);
		Controls.Add(btPesquisa);
		Controls.Add(lbNome2);
		Controls.Add(tbNome2);
		Controls.Add(lbNome1);
		Controls.Add(tbNome1);
		Controls.Add(dgBlocos);
		MaximumSize = new Size(1650, 1400);
		MinimumSize = new Size(730, 460);
		Name = "frmNavegador";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Pesquisa Elétron";
		((ISupportInitialize)dgBlocos).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmNavegador()
	{
		Resize += vjfpvacdndn;
		lU0pvBpvMgM = true;
		j14pvVOnEi6 = true;
		if (!Geral.ExisteForm("frmNavegador"))
		{
			Y0tpvqlUqMx();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1687]);
			CKPrincipal.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 625]);
			CKAuxiliar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 500]);
			CKBornes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]);
			CKMascaras.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 524]);
			CKPortas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 520]);
			CKConexao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 516]);
			CKCabos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
			CKJumpers.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 703]);
			lbNome1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 627]);
			lbNome2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 628]);
			lbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 629]);
			BtApaga.Visible = false;
			if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
			{
				BtApaga.Visible = true;
			}
			Application.ShowModelessDialog((Form)this);
			LabelTotal.Visible = false;
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	public void formataDGBlocos()
	{
		try
		{
			dgBlocos.Rows.Clear();
			dgBlocos.Columns.Clear();
			dgBlocos.Columns.Add("Nome1", "Nome1");
			dgBlocos.Columns.Add("Nome2", "Nome2");
			dgBlocos.Columns.Add("Alternativo", "Alternativo");
			dgBlocos.Columns.Add("Terminais", "Terminais");
			dgBlocos.Columns.Add("PN", "PN");
			dgBlocos.Columns.Add("Tipo", "Tipo");
			dgBlocos.Columns.Add("Handle", "Handle");
			dgBlocos.Columns.Add("Bloco", "Bloco");
			dgBlocos.Columns.Add("Página", "Página");
			dgBlocos.Columns.Add("Potencial", "Potencial");
			dgBlocos.Columns.Add("X", "X");
			dgBlocos.Columns.Add("Y", "Y");
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
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBlocos)) ? ((double)(dgBlocos.Width - 4)) : ((double)(dgBlocos.Width - 22)));
				double num2 = 7.0;
				if (lU0pvBpvMgM)
				{
					num2++;
				}
				if (j14pvVOnEi6)
				{
					num2++;
				}
				dgBlocos.Columns[0].Width = (int)Math.Round(num / num2 + num / num2 / 2.0);
				dgBlocos.Columns[0].Visible = true;
				if (!lU0pvBpvMgM)
				{
					dgBlocos.Columns[1].Width = 0;
					dgBlocos.Columns[1].Visible = false;
				}
				else
				{
					dgBlocos.Columns[1].Width = (int)Math.Round(num / num2);
					dgBlocos.Columns[1].Visible = true;
				}
				if (!j14pvVOnEi6)
				{
					dgBlocos.Columns[2].Width = 0;
					dgBlocos.Columns[2].Visible = false;
				}
				else
				{
					dgBlocos.Columns[2].Width = (int)Math.Round(num / num2);
					dgBlocos.Columns[2].Visible = true;
				}
				dgBlocos.Columns[3].Width = (int)Math.Round(num / num2);
				dgBlocos.Columns[3].Visible = true;
				dgBlocos.Columns[4].Width = (int)Math.Round(num / num2);
				dgBlocos.Columns[4].Visible = true;
				dgBlocos.Columns[5].Width = (int)Math.Round(num / num2 + num / num2 / 2.0);
				dgBlocos.Columns[5].Visible = true;
				dgBlocos.Columns[6].Width = 0;
				dgBlocos.Columns[6].Visible = false;
				dgBlocos.Columns[7].Width = (int)Math.Round(num / num2 + num / num2 / 2.0);
				dgBlocos.Columns[7].Visible = true;
				dgBlocos.Columns[8].Width = (int)Math.Round(num / num2 / 2.0);
				dgBlocos.Columns[8].Visible = true;
				dgBlocos.Columns[9].Width = 0;
				dgBlocos.Columns[9].Visible = false;
				dgBlocos.Columns[10].Width = 0;
				dgBlocos.Columns[10].Visible = false;
				dgBlocos.Columns[11].Width = 0;
				dgBlocos.Columns[11].Visible = false;
				dgBlocos.MultiSelect = true;
				tbNome2.Enabled = lU0pvBpvMgM;
				tbAlternativo.Enabled = j14pvVOnEi6;
			}
		}
	}

	private void vjfpvacdndn(object P_0, EventArgs P_1)
	{
		AtualizaDGBlocos();
	}

	private void CQypv8GFGkM(object P_0, KeyEventArgs P_1)
	{
		MostraBloco();
	}

	private void XhEpvN8dKnv(object P_0, MouseEventArgs P_1)
	{
		MostraBloco();
	}

	public void MostraBloco()
	{
		if (dgBlocos.Columns.Count != 0)
		{
			string sHandle = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[6].Value);
			clsPesquisaBlocos.mostraBloco(sHandle, Conversions.ToInteger(dgBlocos.SelectedRows[0].Cells[10].Value), Conversions.ToInteger(dgBlocos.SelectedRows[0].Cells[11].Value));
		}
	}

	private void Ae0pvFeb9IO(object P_0, EventArgs P_1)
	{
		formataDGBlocos();
		string sNome = tbNome1.Text;
		string sNome2 = tbNome2.Text;
		string sAlternativo = tbAlternativo.Text;
		bool p = CKPrincipal.Checked;
		bool a = CKAuxiliar.Checked;
		bool b = CKBornes.Checked;
		bool m = CKMascaras.Checked;
		bool e = CKPortas.Checked;
		bool bConexao = CKConexao.Checked;
		bool bCabo = CKCabos.Checked;
		bool bJumper = CKJumpers.Checked;
		DataGridView dg = dgBlocos;
		clsPesquisaBlocos.pesquisaElementosEletronNoDWG(sNome, sNome2, sAlternativo, p, a, b, m, e, bConexao, bCabo, bJumper, ref dg, ref lU0pvBpvMgM, ref j14pvVOnEi6);
		dgBlocos = dg;
		if (dgBlocos.RowCount <= 0)
		{
			LabelTotal.Visible = false;
		}
		else
		{
			LabelTotal.Visible = true;
			LabelTotal.Text = Conversions.ToString(dgBlocos.RowCount);
		}
		AtualizaDGBlocos();
	}

	private void Cb3pvQ4lXsr(object P_0, EventArgs P_1)
	{
		string sHandle = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[6].Value);
		clsPesquisaBlocos.ApagaBloco(ref sHandle);
	}
}
