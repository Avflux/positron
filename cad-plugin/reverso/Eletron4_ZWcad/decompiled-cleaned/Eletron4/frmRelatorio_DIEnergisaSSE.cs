using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_DIEnergisaSSE : Form
{
	private IContainer lAwxbSuBWj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView nRuxMkQpL0;

	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView qNZxOyRyVo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionarRegua")]
	private Button RJ8xIgtQqu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip xdBx7KTssp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox XXixqIsKVv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCadastro")]
	private RadioButton MqnxaZPVRn;

	[AccessedThroughProperty("rbCrescente")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton H7ux8Xy99P;

	[AccessedThroughProperty("dgRegua")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView pfaxNZJnE4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox sPSxFMGchD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb1")]
	private RadioButton YKKxQKI4Gd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagaRegua")]
	private Button SUFxP2QaAp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btJumper")]
	private Button xljxc30Ajg;

	[AccessedThroughProperty("btApagarJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button C42xKuIxnd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox n4LxebRjh1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox WMex2pWFl8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb3")]
	private RadioButton vfbx32pkMI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar lhdxncXFtc;

	[AccessedThroughProperty("tbPesquisa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox EmCx1Ysq0V;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSeleciona")]
	private Button xMAxlMmWhj;

	private DeclaracoesFiacao.structurePnRev[] btcx5TgEMk;

	private DeclaracoesFiacao.structureRevisoes[] Csux08FVTh;

	private DeclaracoesInterligacao.structureRI[] UT7xRkYMgr;

	private string TS2xmGqO3F;

	private int SG7xXwJM7c;

	private bool rGWxUnfjE2;

	private bool yfoxyrqTKG;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return nRuxMkQpL0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bk2xGg8hTm;
			DataGridView dataGridView = nRuxMkQpL0;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			nRuxMkQpL0 = value;
			dataGridView = nRuxMkQpL0;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return qNZxOyRyVo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OVqxfZsP49;
			DataGridView dataGridView = qNZxOyRyVo;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			qNZxOyRyVo = value;
			dataGridView = qNZxOyRyVo;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btAdicionarRegua
	{
		[CompilerGenerated]
		get
		{
			return RJ8xIgtQqu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = COFxtLy2Ha;
			Button button = RJ8xIgtQqu;
			if (button != null)
			{
				button.Click -= value2;
			}
			RJ8xIgtQqu = value;
			button = RJ8xIgtQqu;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return XXixqIsKVv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XXixqIsKVv = value;
		}
	}

	internal virtual RadioButton rbCadastro
	{
		[CompilerGenerated]
		get
		{
			return MqnxaZPVRn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = b78xd8Kw26;
			RadioButton radioButton = MqnxaZPVRn;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			MqnxaZPVRn = value;
			radioButton = MqnxaZPVRn;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbCrescente
	{
		[CompilerGenerated]
		get
		{
			return H7ux8Xy99P;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			H7ux8Xy99P = value;
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return pfaxNZJnE4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pfaxNZJnE4 = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return sPSxFMGchD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sPSxFMGchD = value;
		}
	}

	internal virtual RadioButton rb1
	{
		[CompilerGenerated]
		get
		{
			return YKKxQKI4Gd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YKKxQKI4Gd = value;
		}
	}

	internal virtual Button btApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return SUFxP2QaAp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rDHxjZD9bA;
			Button button = SUFxP2QaAp;
			if (button != null)
			{
				button.Click -= value2;
			}
			SUFxP2QaAp = value;
			button = SUFxP2QaAp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btJumper
	{
		[CompilerGenerated]
		get
		{
			return xljxc30Ajg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = B2kxwplrdD;
			Button button = xljxc30Ajg;
			if (button != null)
			{
				button.Click -= value2;
			}
			xljxc30Ajg = value;
			button = xljxc30Ajg;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarJumper
	{
		[CompilerGenerated]
		get
		{
			return C42xKuIxnd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nJtxxk5Wy9;
			Button button = C42xKuIxnd;
			if (button != null)
			{
				button.Click -= value2;
			}
			C42xKuIxnd = value;
			button = C42xKuIxnd;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return n4LxebRjh1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			n4LxebRjh1 = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return WMex2pWFl8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WMex2pWFl8 = value;
		}
	}

	internal virtual RadioButton rb3
	{
		[CompilerGenerated]
		get
		{
			return vfbx32pkMI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vfbx32pkMI = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return lhdxncXFtc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lhdxncXFtc = value;
		}
	}

	internal virtual TextBox tbPesquisa
	{
		[CompilerGenerated]
		get
		{
			return EmCx1Ysq0V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = fB4xHCYwl7;
			TextBox textBox = EmCx1Ysq0V;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			EmCx1Ysq0V = value;
			textBox = EmCx1Ysq0V;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return xMAxlMmWhj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lfsxLXtfyw;
			Button button = xMAxlMmWhj;
			if (button != null)
			{
				button.Click -= value2;
			}
			xMAxlMmWhj = value;
			button = xMAxlMmWhj;
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
			if (disposing && lAwxbSuBWj != null)
			{
				lAwxbSuBWj.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void YCfxJNt53T()
	{
		lAwxbSuBWj = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		btAdicionarRegua = new Button();
		FDqpBiUmZij(new ToolTip(lAwxbSuBWj));
		GroupBox2 = new GroupBox();
		rbCadastro = new RadioButton();
		rbCrescente = new RadioButton();
		dgRegua = new DataGridView();
		GroupBox1 = new GroupBox();
		rb3 = new RadioButton();
		rb1 = new RadioButton();
		btApagaRegua = new Button();
		btJumper = new Button();
		btApagarJumper = new Button();
		GroupBox3 = new GroupBox();
		GroupBox4 = new GroupBox();
		ProgressBar1 = new ProgressBar();
		tbPesquisa = new TextBox();
		btSeleciona = new Button();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgRegua).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao.Location = new Point(12, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(385, 133);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(13, 177);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(137, 205);
		dgEquip.TabIndex = 8;
		btAdicionarRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAdicionarRegua.FlatStyle = FlatStyle.Flat;
		btAdicionarRegua.ForeColor = SystemColors.Control;
		btAdicionarRegua.Image = Resources.BorneAranha_32;
		btAdicionarRegua.Location = new Point(15, 20);
		btAdicionarRegua.Name = "btAdicionarRegua";
		btAdicionarRegua.Size = new Size(40, 42);
		btAdicionarRegua.TabIndex = 15;
		btAdicionarRegua.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rbCadastro);
		GroupBox2.Controls.Add(rbCrescente);
		GroupBox2.Location = new Point(7, 389);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(142, 69);
		GroupBox2.TabIndex = 47;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordem Bornes Máscara";
		rbCadastro.AutoSize = true;
		rbCadastro.Location = new Point(6, 42);
		rbCadastro.Name = "rbCadastro";
		rbCadastro.Size = new Size(76, 17);
		rbCadastro.TabIndex = 1;
		rbCadastro.TabStop = true;
		rbCadastro.Text = "rbCadastro";
		rbCadastro.UseVisualStyleBackColor = true;
		rbCrescente.AutoSize = true;
		rbCrescente.Location = new Point(6, 19);
		rbCrescente.Name = "rbCrescente";
		rbCrescente.Size = new Size(82, 17);
		rbCrescente.TabIndex = 0;
		rbCrescente.TabStop = true;
		rbCrescente.Text = "rbCrescente";
		rbCrescente.UseVisualStyleBackColor = true;
		dgRegua.AllowUserToAddRows = false;
		dgRegua.AllowUserToDeleteRows = false;
		dgRegua.AllowUserToOrderColumns = true;
		dgRegua.AllowUserToResizeRows = false;
		dgRegua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgRegua.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgRegua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgRegua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRegua.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRegua.Location = new Point(155, 151);
		dgRegua.MultiSelect = false;
		dgRegua.Name = "dgRegua";
		dgRegua.ReadOnly = true;
		dgRegua.RowHeadersVisible = false;
		dgRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRegua.Size = new Size(242, 162);
		dgRegua.TabIndex = 48;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rb3);
		GroupBox1.Controls.Add(rb1);
		GroupBox1.Location = new Point(155, 336);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(242, 49);
		GroupBox1.TabIndex = 49;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Posição";
		rb3.AutoSize = true;
		rb3.Location = new Point(129, 20);
		rb3.Name = "rb3";
		rb3.Size = new Size(40, 17);
		rb3.TabIndex = 52;
		rb3.TabStop = true;
		rb3.Text = "rb3";
		rb3.UseVisualStyleBackColor = true;
		rb1.AutoSize = true;
		rb1.Location = new Point(17, 19);
		rb1.Name = "rb1";
		rb1.Size = new Size(40, 17);
		rb1.TabIndex = 50;
		rb1.TabStop = true;
		rb1.Text = "rb1";
		rb1.UseVisualStyleBackColor = true;
		btApagaRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagaRegua.FlatStyle = FlatStyle.Flat;
		btApagaRegua.ForeColor = SystemColors.Control;
		btApagaRegua.Image = Resources.Delete_32;
		btApagaRegua.Location = new Point(69, 20);
		btApagaRegua.Name = "btApagaRegua";
		btApagaRegua.Size = new Size(40, 42);
		btApagaRegua.TabIndex = 50;
		btApagaRegua.UseVisualStyleBackColor = true;
		btJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btJumper.FlatStyle = FlatStyle.Flat;
		btJumper.ForeColor = SystemColors.Control;
		btJumper.Image = Resources.JumperAranha_32;
		btJumper.Location = new Point(7, 19);
		btJumper.Name = "btJumper";
		btJumper.Size = new Size(40, 42);
		btJumper.TabIndex = 51;
		btJumper.UseVisualStyleBackColor = true;
		btApagarJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarJumper.FlatStyle = FlatStyle.Flat;
		btApagarJumper.ForeColor = SystemColors.Control;
		btApagarJumper.Image = Resources.Delete_32;
		btApagarJumper.Location = new Point(52, 20);
		btApagarJumper.Name = "btApagarJumper";
		btApagarJumper.Size = new Size(40, 42);
		btApagarJumper.TabIndex = 52;
		btApagarJumper.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(btAdicionarRegua);
		GroupBox3.Controls.Add(btApagaRegua);
		GroupBox3.Location = new Point(155, 389);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(115, 70);
		GroupBox3.TabIndex = 56;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Bornes e Cabos";
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(btApagarJumper);
		GroupBox4.Controls.Add(btJumper);
		GroupBox4.Location = new Point(282, 389);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(115, 70);
		GroupBox4.TabIndex = 57;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Jumpers";
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(155, 319);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(242, 11);
		ProgressBar1.TabIndex = 61;
		tbPesquisa.Location = new Point(12, 151);
		tbPesquisa.Name = "tbPesquisa";
		tbPesquisa.Size = new Size(116, 20);
		tbPesquisa.TabIndex = 62;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_16;
		btSeleciona.Location = new Point(132, 151);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(16, 20);
		btSeleciona.TabIndex = 67;
		btSeleciona.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(404, 461);
		Controls.Add(btSeleciona);
		Controls.Add(tbPesquisa);
		Controls.Add(ProgressBar1);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(dgRegua);
		Controls.Add(GroupBox2);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(420, 1200);
		MinimumSize = new Size(420, 500);
		Name = "frmRelatorio_DIEnergisaSSE";
		ShowInTaskbar = false;
		Text = "Diagrama de Interligação Energisa Sul Sudeste";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dgRegua).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox4.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return xdBx7KTssp;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		xdBx7KTssp = WithEventsValue;
	}

	public frmRelatorio_DIEnergisaSSE()
	{
		btcx5TgEMk = new DeclaracoesFiacao.structurePnRev[1];
		Csux08FVTh = new DeclaracoesFiacao.structureRevisoes[1];
		TS2xmGqO3F = "";
		SG7xXwJM7c = 0;
		rGWxUnfjE2 = false;
		yfoxyrqTKG = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_DIEnergisaSSE"))
			{
				YCfxJNt53T();
				KfoxhiNcLG(_0020: false);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1775]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1439]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1419]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1777]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1444]);
				rbCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1420]);
				rbCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1421]);
				rb1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 384]);
				rb3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 386]);
				w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1900]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				UT7xRkYMgr = new DeclaracoesInterligacao.structureRI[1];
				UT7xRkYMgr[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				formataDGRevisao();
				formataDGEquip();
				rbCrescente.Checked = true;
				rb1.Checked = true;
				tbTxo2vOpD();
				KfoxhiNcLG(_0020: true);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void KfoxhiNcLG(bool P_0)
	{
		GroupBox1.Enabled = P_0;
		GroupBox2.Enabled = P_0;
		GroupBox3.Enabled = P_0;
		GroupBox4.Enabled = P_0;
		btSeleciona.Enabled = P_0;
	}

	private void tbTxo2vOpD()
	{
		Csux08FVTh = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref Csux08FVTh);
			rGWxUnfjE2 = true;
			dgRevisao.Rows.Clear();
			rGWxUnfjE2 = false;
			int num = Information.UBound(Csux08FVTh);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(Csux08FVTh[i].revisao, Csux08FVTh[i].criador, Csux08FVTh[i].data);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	private void bk2xGg8hTm(object P_0, EventArgs P_1)
	{
		yfoxyrqTKG = true;
		dgEquip.Rows.Clear();
		yfoxyrqTKG = false;
		if (!rGWxUnfjE2)
		{
			OLxxkVj4LZ(_0020: false);
		}
	}

	private void fB4xHCYwl7(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(tbPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !rGWxUnfjE2)
		{
			OLxxkVj4LZ(_0020: true);
		}
	}

	private void OLxxkVj4LZ(bool P_0)
	{
		if (!P_0)
		{
			tbPesquisa.Text = "";
		}
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			TS2xmGqO3F = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			yfoxyrqTKG = true;
			dgEquip.Rows.Clear();
			yfoxyrqTKG = false;
			int num = Information.UBound(btcx5TgEMk);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(btcx5TgEMk[i].revisao, TS2xmGqO3F, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(btcx5TgEMk[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(btcx5TgEMk[i].painel, text);
					}
					else if (text.ToUpper().Contains(tbPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(btcx5TgEMk[i].painel, text);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaPnRev()
	{
		btcx5TgEMk = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(Csux08FVTh) > 0)
			{
				int num = Information.UBound(Csux08FVTh);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(Csux08FVTh[i].revisao, ref btcx5TgEMk);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	private void b78xd8Kw26(object P_0, EventArgs P_1)
	{
		DegxDwasK5();
	}

	private void OVqxfZsP49(object P_0, EventArgs P_1)
	{
		DegxDwasK5();
	}

	private void DegxDwasK5()
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				KfoxhiNcLG(_0020: false);
				SG7xXwJM7c = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				formataDGRegua();
				UT7xRkYMgr = new DeclaracoesInterligacao.structureRI[1];
				UT7xRkYMgr[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cDadosAccessInterligacao3.CarregaReguas(TS2xmGqO3F, SG7xXwJM7c, ref UT7xRkYMgr);
				cDadosAccessInterligacao3.CarregaReguasPortas(TS2xmGqO3F, SG7xXwJM7c, ref UT7xRkYMgr);
				cDadosAccessInterligacao3.CarregaBornesReguas(TS2xmGqO3F, SG7xXwJM7c, ref UT7xRkYMgr, rbCadastro.Checked);
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = checked(TUUxvNCouI() * 2);
				ProgressBar1.Value = 0;
				ProgressBar1.Step = 1;
				string tS2xmGqO3F = TS2xmGqO3F;
				int sG7xXwJM7c = SG7xXwJM7c;
				ref DeclaracoesInterligacao.structureRI[] uT7xRkYMgr = ref UT7xRkYMgr;
				ProgressBar ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaCabosNosBornesRI(tS2xmGqO3F, sG7xXwJM7c, ref uT7xRkYMgr, ref ProgressBar, -1);
				ProgressBar1 = ProgressBar;
				string tS2xmGqO3F2 = TS2xmGqO3F;
				int sG7xXwJM7c2 = SG7xXwJM7c;
				ref DeclaracoesInterligacao.structureRI[] uT7xRkYMgr2 = ref UT7xRkYMgr;
				ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaJumpersNosBornesRI(tS2xmGqO3F2, sG7xXwJM7c2, ref uT7xRkYMgr2, ref ProgressBar);
				ProgressBar1 = ProgressBar;
				v18x6Um4nr();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessInterligacao3.fechaConexao();
			ProgressBar1.Value = 0;
			KfoxhiNcLG(_0020: true);
		}
	}

	private int TUUxvNCouI()
	{
		int num = 0;
		int num2 = Information.UBound(UT7xRkYMgr);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!Information.IsNothing(UT7xRkYMgr[i].Bornes))
				{
					num += UT7xRkYMgr[i].Bornes.Length - 1;
				}
			}
			return num;
		}
	}

	private void v18x6Um4nr()
	{
		if (Information.UBound(UT7xRkYMgr) == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		try
		{
			int num = Information.UBound(UT7xRkYMgr);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Information.IsNothing(UT7xRkYMgr[i].Bornes))
				{
					if (!list.Contains(UT7xRkYMgr[i].DWG))
					{
						list.Add(UT7xRkYMgr[i].DWG);
					}
					continue;
				}
				int num2 = Information.UBound(UT7xRkYMgr[i].Bornes);
				dgRegua.Rows.Add(UT7xRkYMgr[i].Tipo, UT7xRkYMgr[i].Tag, UT7xRkYMgr[i].NRegua, num2);
			}
			string text = "";
			if (list.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicDWG)
			{
				if (list.Contains(item.Key))
				{
					text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? item.Value : ("," + item.Value));
				}
			}
			if (list.Count != 1)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1981], "\r\n"), " "), text), MsgBoxStyle.Information);
			}
			else
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1980], "\r\n"), " "), text), MsgBoxStyle.Information);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void COFxtLy2Ha(object P_0, EventArgs P_1)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				List<string> lPaginasColunas = new List<string>();
				clsDIEnergisaSSE.buscaPaginasColuna(ref lPaginasColunas);
				DeclaracoesInterligacao.structureRI structureRI = default;
				if (dgEquip.SelectedRows.Count == 0 || dgRegua.SelectedRows.Count == 0)
				{
					return;
				}
				DeclaracoesGeral.Reguas RH = default;
				if (XDataGeral.LeXDataReguaH(ref RH))
				{
					Point3d ptCol = new Point3d(RH.Pti.X + 10.0, 282.0, 0.0);
					Point3d ptCol2 = new Point3d(RH.Pti.X + (RH.LarguraBase - RH.Pti.X) - 189.0, 282.0, 0.0);
					string text = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
					string text2 = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
					int num = Information.UBound(UT7xRkYMgr);
					for (int i = 1; i <= num; i++)
					{
						if ((Operators.CompareString(UT7xRkYMgr[i].Tag, text, TextCompare: true) == 0) & (Operators.CompareString(UT7xRkYMgr[i].NRegua, text2, TextCompare: true) == 0))
						{
							structureRI = UT7xRkYMgr[i];
							break;
						}
					}
					if (Information.UBound(structureRI.Bornes) == 0)
					{
						return;
					}
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					Point3d val = new Point3d(RH.Pti.X + 10.0, 259.0, 0.0);
					Point3d val2 = new Point3d(RH.Pti.X + (RH.LarguraBase - RH.Pti.X) - 189.0, 259.0, 0.0);
					Point3d ptIns = default;
					if (!rb1.Checked)
					{
						if (rb3.Checked)
						{
							ptIns = val2;
							num4 = 3;
						}
					}
					else
					{
						ptIns = val;
						num4 = 1;
					}
					if (!clsDIEnergisaSSE.reguaExiste(SG7xXwJM7c, text, text2))
					{
						double deltaY = 0.0;
						Point3d pt = default;
						if (clsDIEnergisaSSE.outraReguaExiste(DeclaracoesGeral.ativo.Pagina, ref pt, num4, ref deltaY))
						{
							ptIns = new Point3d(pt.X, pt.Y - deltaY, 0.0);
							num2 = (int)Math.Round((259.0 - ptIns.Y) / 5.0);
							if (num2 >= 44)
							{
								return;
							}
						}
						string nomePainel = Dicionario.BuscaNomeDoPainel(SG7xXwJM7c);
						string left = "";
						double deltaY2 = 0.0;
						int num5 = Information.UBound(structureRI.Bornes);
						for (int j = 1; j <= num5; j++)
						{
							int num6 = structureRI.Bornes[j].cabos.Count() - 1;
							if (num2 != 0)
							{
								if (num2 > 0)
								{
									double num7 = 0.0;
									switch (num6)
									{
									case 4:
										num7 = num2 + 4;
										break;
									case 0:
									case 1:
										num7 = num2 + 1;
										break;
									case 2:
										num7 = num2 + 2;
										break;
									case 3:
										num7 = num2 + 3;
										break;
									}
									if (!((num7 > 0.0) & (num7 <= 44.0)))
									{
										if (num7 > 44.0)
										{
											left = "";
											num2 = 0;
											num4 += 2;
											if (num4 == 5)
											{
												num4 = 1;
												string text3 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
												if (Operators.CompareString(text3, "", TextCompare: true) != 0)
												{
													Pagina.AtivaPagina(text3);
												}
												else if (!Pagina.criarUmaNovaPagina())
												{
													break;
												}
												clsDIEnergisaSSE.insereColunasSePrecisar(ref lPaginasColunas, ptCol, ptCol2, nomePainel);
											}
											if (num4 == 1)
											{
												ptIns = val;
											}
											else if (num4 == 3)
											{
												ptIns = val2;
											}
										}
									}
									else
									{
										ptIns = new Point3d(ptIns.X, ptIns.Y - (double)num3, 0.0);
									}
								}
							}
							else
							{
								clsDIEnergisaSSE.insereColunasSePrecisar(ref lPaginasColunas, ptCol, ptCol2, nomePainel);
							}
							DeclaracoesInterligacao.borneAranha bn = new DeclaracoesInterligacao.borneAranha
							{
								Revisao = TS2xmGqO3F,
								Painel = SG7xXwJM7c,
								Tag = text,
								NRegua = text2,
								Borne = structureRI.Bornes[j].Borne,
								TipoBorne = num6,
								Ordem = structureRI.Bornes[j].Ordem,
								Posicao = num4
							};
							string text4 = "";
							switch (num6)
							{
							case 4:
								text4 = "Borne4.DWG";
								break;
							case 0:
							case 1:
								text4 = "Borne1.DWG";
								break;
							case 2:
								text4 = "Borne2.DWG";
								break;
							case 3:
								text4 = "Borne3.DWG";
								break;
							}
							if (File.Exists(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaSSE\\" + text4))
							{
								clsDIEnergisaSSE.InserirBorneAranha(text4, bn, ptIns);
								string regua = bn.Tag;
								if (Operators.CompareString(bn.NRegua, "", TextCompare: true) != 0)
								{
									regua = bn.NRegua;
								}
								int num8 = num6;
								for (int k = 1; k <= num8; k++)
								{
									Point3d ptIns2 = new Point3d(ptIns.X + 25.0, ptIns.Y + 2.5 - (double)(5 * k), 0.0);
									int num9 = 1;
									string tag_Cabo = structureRI.Bornes[j].cabos[k].Tag_Cabo;
									if (Operators.CompareString(left, tag_Cabo, TextCompare: true) == 0)
									{
										num9 = 2;
									}
									else
									{
										left = tag_Cabo;
										deltaY2 = ptIns2.Y;
										num9 = 1;
									}
									clsDIEnergisaSSE.InserirVeia(TS2xmGqO3F, SG7xXwJM7c, regua, structureRI.Bornes[j], ptIns2, k, num9, deltaY2);
								}
								switch (num6)
								{
								case 4:
									num2 += 4;
									num3 = 20;
									break;
								case 0:
									num2++;
									num3 = 5;
									break;
								case 1:
									num2++;
									num3 = 5;
									break;
								case 2:
									num2 += 2;
									num3 = 10;
									break;
								case 3:
									num2 += 3;
									num3 = 15;
									break;
								}
								continue;
							}
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
							return;
						}
						DeclaracoesGeral._uscPagina.CarregaPG();
					}
					int num10 = dgRegua.Rows.Count - 1;
					int num11 = 0;
					while (true)
					{
						if (num11 <= num10)
						{
							if (dgRegua.Rows[num11].Selected && num11 < dgRegua.Rows.Count - 1)
							{
								break;
							}
							num11++;
							continue;
						}
						return;
					}
					dgRegua.Rows[num11 + 1].Selected = true;
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				Application.UpdateScreen();
			}
		}
	}

	private void rDHxjZD9bA(object P_0, EventArgs P_1)
	{
		string tag = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
		string nRegua = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
		clsDIEnergisaSSE.ApagaRegua(TS2xmGqO3F, SG7xXwJM7c, tag, nRegua);
		Application.UpdateScreen();
	}

	private void lfsxLXtfyw(object P_0, EventArgs P_1)
	{
		string rev = "";
		int painel = 0;
		checked
		{
			if (clsDIEnergisaSSE.SelecionaBorne(ref rev, ref painel))
			{
				int num = dgRevisao.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!Operators.ConditionalCompareObjectEqual(dgRevisao[0, i].Value, rev, TextCompare: true))
					{
						continue;
					}
					dgRevisao.Rows[i].Selected = true;
					dgRevisao.FirstDisplayedScrollingRowIndex = i;
					int num2 = dgEquip.RowCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectEqual(dgEquip[0, j].Value, painel, TextCompare: true))
						{
							dgEquip.Rows[j].Selected = true;
							dgEquip.FirstDisplayedScrollingRowIndex = j;
							break;
						}
					}
					break;
				}
			}
			Application.UpdateScreen();
		}
	}

	private void B2kxwplrdD(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.jumper[] mJumpers = new DeclaracoesInterligacao.jumper[1];
		if (!clsDIEnergisaSSE.carregaBornesJ(TS2xmGqO3F, SG7xXwJM7c, ref mBornesJ))
		{
			return;
		}
		clsDIEnergisaSSE.buscaJumpers(ref mBornesJ, ref mJumpers, ref UT7xRkYMgr);
		clsDIEnergisaSSE.ApagaJumper(TS2xmGqO3F, SG7xXwJM7c);
		if (Information.UBound(mJumpers) <= 0)
		{
			return;
		}
		int num = Information.UBound(mJumpers);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!mJumpers[i].bMesmaPaginaColuna)
			{
				if (!mJumpers[i].bMesmaPaginaColuna)
				{
					clsDIEnergisaSSE.desenhaJumper2(TS2xmGqO3F, SG7xXwJM7c, ref mBornesJ, ref mJumpers, i);
				}
			}
			else
			{
				clsDIEnergisaSSE.desenhaJumper1(TS2xmGqO3F, SG7xXwJM7c, ref mBornesJ, ref mJumpers, i);
			}
		}
		Application.UpdateScreen();
	}

	private void nJtxxk5Wy9(object P_0, EventArgs P_1)
	{
		clsDIEnergisaSSE.ApagaJumper(TS2xmGqO3F, SG7xXwJM7c);
		Application.UpdateScreen();
	}

	public void formataDGRevisao()
	{
		checked
		{
			try
			{
				dgRevisao.Rows.Clear();
				dgRevisao.Columns.Clear();
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 753]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 754]));
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num / 3f);
				dgRevisao.Columns[1].Width = (int)Math.Round(num / 3f);
				dgRevisao.Columns[2].Width = (int)Math.Round(num / 3f);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				yfoxyrqTKG = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				float num = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				yfoxyrqTKG = false;
			}
		}
	}

	public void formataDGRegua()
	{
		checked
		{
			try
			{
				dgRegua.Rows.Clear();
				dgRegua.Columns.Clear();
				dgRegua.Columns.Add("", "Tipo");
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 110]));
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]));
				dgRegua.Columns.Add("", "#");
				float num = dgRegua.Width - 22;
				dgRegua.Columns[0].Width = 0;
				dgRegua.Columns[0].Visible = false;
				dgRegua.Columns[1].Width = (int)Math.Round(num * 2f / 4f);
				dgRegua.Columns[2].Width = (int)Math.Round((double)num * 1.2 / 4.0);
				dgRegua.Columns[3].Width = (int)Math.Round((double)num * 0.8 / 4.0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}
}
