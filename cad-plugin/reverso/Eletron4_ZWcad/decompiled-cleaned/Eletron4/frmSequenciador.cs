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
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmSequenciador : Form
{
	private IContainer XRRpcGDR0yv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView j8WpcHtTaye;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip ur7pckcf21U;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView kDXpcdpcoow;

	[AccessedThroughProperty("dgDisp")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView oJ9pcfCtANn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgPot")]
	private DataGridView bJspcDm7WkP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgSeq")]
	private DataGridView hNIpcv8a1qS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblSecao")]
	private Label ctmpc63eIdY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCor")]
	private Label rsxpctnceT0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	private Button XbspcjwI2W5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbNumConexoes")]
	[CompilerGenerated]
	private CheckBox jrbpcL6S4wA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btUltimo")]
	private Button xmcpcwd1YTT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPrimeiro")]
	[CompilerGenerated]
	private Button E6spcximo1s;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBaixo")]
	private Button lfppcbs8cKs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCima")]
	private Button QdSpcM421hG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKMulti")]
	private CheckBox sBQpcOutZ17;

	private DeclaracoesFiacao.structurePnRev[] AtIpcITOQgr;

	private DeclaracoesFiacao.structureRevisoes[] JKYpc7D3arw;

	private Dictionary<int, int> I9WpcqTq3o9;

	private string CNupcattuhc;

	private int xqGpc8vrFEI;

	private string jCHpcNc0rPm;

	private int Iy0pcFREFeq;

	private bool vFPpcQutQ6d;

	private bool QudpcPLMeoJ;

	private bool Evwpccq0Xdf;

	private int TL1pcKulWJM;

	private bool Bg9pceAM907;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return j8WpcHtTaye;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OPSpPByFlDG;
			DataGridView dataGridView = j8WpcHtTaye;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			j8WpcHtTaye = value;
			dataGridView = j8WpcHtTaye;
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
			return kDXpcdpcoow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = o2MpPuElVp7;
			DataGridView dataGridView = kDXpcdpcoow;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			kDXpcdpcoow = value;
			dataGridView = kDXpcdpcoow;
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
			return oJ9pcfCtANn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qn9pPiiTCW3;
			DataGridView dataGridView = oJ9pcfCtANn;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			oJ9pcfCtANn = value;
			dataGridView = oJ9pcfCtANn;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgPot
	{
		[CompilerGenerated]
		get
		{
			return bJspcDm7WkP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Y0tpP45Zxiy;
			DataGridView dataGridView = bJspcDm7WkP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			bJspcDm7WkP = value;
			dataGridView = bJspcDm7WkP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgSeq
	{
		[CompilerGenerated]
		get
		{
			return hNIpcv8a1qS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = sywpPYfKfqH;
			MouseEventHandler value3 = ae3pcTSkjGI;
			DragEventHandler value4 = mJ9pcJTVppN;
			DragEventHandler value5 = Mlppchbeeay;
			DataGridView dataGridView = hNIpcv8a1qS;
			if (dataGridView != null)
			{
				dataGridView.KeyDown -= value2;
				dataGridView.MouseDown -= value3;
				dataGridView.DragDrop -= value4;
				dataGridView.DragEnter -= value5;
			}
			hNIpcv8a1qS = value;
			dataGridView = hNIpcv8a1qS;
			if (dataGridView != null)
			{
				dataGridView.KeyDown += value2;
				dataGridView.MouseDown += value3;
				dataGridView.DragDrop += value4;
				dataGridView.DragEnter += value5;
			}
		}
	}

	internal virtual Label lblSecao
	{
		[CompilerGenerated]
		get
		{
			return ctmpc63eIdY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ctmpc63eIdY = value;
		}
	}

	internal virtual Label lblCor
	{
		[CompilerGenerated]
		get
		{
			return rsxpctnceT0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rsxpctnceT0 = value;
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return XbspcjwI2W5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = V7IpPsKgSGB;
			Button button = XbspcjwI2W5;
			if (button != null)
			{
				button.Click -= value2;
			}
			XbspcjwI2W5 = value;
			button = XbspcjwI2W5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbNumConexoes
	{
		[CompilerGenerated]
		get
		{
			return jrbpcL6S4wA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PG9pPZPf5Zp;
			CheckBox checkBox = jrbpcL6S4wA;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			jrbpcL6S4wA = value;
			checkBox = jrbpcL6S4wA;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btUltimo
	{
		[CompilerGenerated]
		get
		{
			return xmcpcwd1YTT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XAWpcWEfGsJ;
			Button button = xmcpcwd1YTT;
			if (button != null)
			{
				button.Click -= value2;
			}
			xmcpcwd1YTT = value;
			button = xmcpcwd1YTT;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPrimeiro
	{
		[CompilerGenerated]
		get
		{
			return E6spcximo1s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CBipPrsQaMh;
			Button button = E6spcximo1s;
			if (button != null)
			{
				button.Click -= value2;
			}
			E6spcximo1s = value;
			button = E6spcximo1s;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btBaixo
	{
		[CompilerGenerated]
		get
		{
			return lfppcbs8cKs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vRspPzoNQID;
			Button button = lfppcbs8cKs;
			if (button != null)
			{
				button.Click -= value2;
			}
			lfppcbs8cKs = value;
			button = lfppcbs8cKs;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCima
	{
		[CompilerGenerated]
		get
		{
			return QdSpcM421hG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = D7upP91jeQZ;
			Button button = QdSpcM421hG;
			if (button != null)
			{
				button.Click -= value2;
			}
			QdSpcM421hG = value;
			button = QdSpcM421hG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CKMulti
	{
		[CompilerGenerated]
		get
		{
			return sBQpcOutZ17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HWapcp7mwNm;
			CheckBox checkBox = sBQpcOutZ17;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			sBQpcOutZ17 = value;
			checkBox = sBQpcOutZ17;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && XRRpcGDR0yv != null)
			{
				XRRpcGDR0yv.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void M2LpPANXep0()
	{
		XRRpcGDR0yv = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		FDqpBiUmZij(new ToolTip(XRRpcGDR0yv));
		dgEquip = new DataGridView();
		dgDisp = new DataGridView();
		dgPot = new DataGridView();
		dgSeq = new DataGridView();
		lblSecao = new Label();
		lblCor = new Label();
		btSalvar = new Button();
		cbNumConexoes = new CheckBox();
		btUltimo = new Button();
		btPrimeiro = new Button();
		btBaixo = new Button();
		btCima = new Button();
		CKMulti = new CheckBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		((ISupportInitialize)dgPot).BeginInit();
		((ISupportInitialize)dgSeq).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
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
		dgRevisao.Size = new Size(355, 175);
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
		dgEquip.Location = new Point(12, 193);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(155, 378);
		dgEquip.TabIndex = 8;
		dgDisp.AllowUserToAddRows = false;
		dgDisp.AllowUserToDeleteRows = false;
		dgDisp.AllowUserToOrderColumns = true;
		dgDisp.AllowUserToResizeRows = false;
		dgDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDisp.Location = new Point(173, 193);
		dgDisp.MultiSelect = false;
		dgDisp.Name = "dgDisp";
		dgDisp.ReadOnly = true;
		dgDisp.RowHeadersVisible = false;
		dgDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDisp.Size = new Size(194, 347);
		dgDisp.TabIndex = 9;
		dgPot.AllowUserToAddRows = false;
		dgPot.AllowUserToDeleteRows = false;
		dgPot.AllowUserToOrderColumns = true;
		dgPot.AllowUserToResizeRows = false;
		dgPot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPot.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgPot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgPot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPot.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPot.Location = new Point(373, 12);
		dgPot.MultiSelect = false;
		dgPot.Name = "dgPot";
		dgPot.ReadOnly = true;
		dgPot.RowHeadersVisible = false;
		dgPot.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPot.Size = new Size(101, 559);
		dgPot.TabIndex = 10;
		dgSeq.AllowDrop = true;
		dgSeq.AllowUserToAddRows = false;
		dgSeq.AllowUserToDeleteRows = false;
		dgSeq.AllowUserToResizeRows = false;
		dgSeq.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgSeq.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgSeq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgSeq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgSeq.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgSeq.Location = new Point(480, 12);
		dgSeq.MultiSelect = false;
		dgSeq.Name = "dgSeq";
		dgSeq.ReadOnly = true;
		dgSeq.RowHeadersVisible = false;
		dgSeq.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgSeq.Size = new Size(314, 500);
		dgSeq.TabIndex = 11;
		lblSecao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lblSecao.AutoSize = true;
		lblSecao.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblSecao.Location = new Point(495, 537);
		lblSecao.Name = "lblSecao";
		lblSecao.Size = new Size(65, 18);
		lblSecao.TabIndex = 14;
		lblSecao.Text = "lblSecao";
		lblCor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lblCor.AutoSize = true;
		lblCor.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblCor.Location = new Point(495, 555);
		lblCor.Name = "lblCor";
		lblCor.Size = new Size(47, 18);
		lblCor.TabIndex = 15;
		lblCor.Text = "lblCor";
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(777, 526);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 16;
		btSalvar.UseVisualStyleBackColor = true;
		cbNumConexoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbNumConexoes.AutoSize = true;
		cbNumConexoes.Location = new Point(188, 554);
		cbNumConexoes.Name = "cbNumConexoes";
		cbNumConexoes.Size = new Size(81, 17);
		cbNumConexoes.TabIndex = 17;
		cbNumConexoes.Text = "CheckBox1";
		cbNumConexoes.TextAlign = ContentAlignment.BottomLeft;
		cbNumConexoes.UseVisualStyleBackColor = true;
		btUltimo.Anchor = AnchorStyles.Right;
		btUltimo.Image = Resources.Ultimo_16;
		btUltimo.Location = new Point(801, 289);
		btUltimo.Name = "btUltimo";
		btUltimo.Size = new Size(23, 23);
		btUltimo.TabIndex = 193;
		btUltimo.UseVisualStyleBackColor = true;
		btPrimeiro.Anchor = AnchorStyles.Right;
		btPrimeiro.Image = Resources.Primeiro_16;
		btPrimeiro.Location = new Point(801, 202);
		btPrimeiro.Name = "btPrimeiro";
		btPrimeiro.Size = new Size(23, 23);
		btPrimeiro.TabIndex = 192;
		btPrimeiro.UseVisualStyleBackColor = true;
		btBaixo.Anchor = AnchorStyles.Right;
		btBaixo.Image = Resources.Baixo_16;
		btBaixo.Location = new Point(800, 260);
		btBaixo.Name = "btBaixo";
		btBaixo.Size = new Size(23, 23);
		btBaixo.TabIndex = 191;
		btBaixo.UseVisualStyleBackColor = true;
		btCima.Anchor = AnchorStyles.Right;
		btCima.Image = Resources.Cima_16;
		btCima.Location = new Point(800, 231);
		btCima.Name = "btCima";
		btCima.Size = new Size(23, 23);
		btCima.TabIndex = 190;
		btCima.UseVisualStyleBackColor = true;
		CKMulti.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKMulti.AutoSize = true;
		CKMulti.Location = new Point(480, 517);
		CKMulti.Name = "CKMulti";
		CKMulti.Size = new Size(81, 17);
		CKMulti.TabIndex = 194;
		CKMulti.Text = "CheckBox1";
		CKMulti.TextAlign = ContentAlignment.BottomLeft;
		CKMulti.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(834, 583);
		Controls.Add(CKMulti);
		Controls.Add(btUltimo);
		Controls.Add(btPrimeiro);
		Controls.Add(btBaixo);
		Controls.Add(btCima);
		Controls.Add(cbNumConexoes);
		Controls.Add(btSalvar);
		Controls.Add(lblCor);
		Controls.Add(lblSecao);
		Controls.Add(dgSeq);
		Controls.Add(dgPot);
		Controls.Add(dgDisp);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(950, 800);
		MinimumSize = new Size(850, 600);
		Name = "frmSequenciador";
		ShowInTaskbar = false;
		Text = "Sequenciador de Conexões";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		((ISupportInitialize)dgPot).EndInit();
		((ISupportInitialize)dgSeq).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return ur7pckcf21U;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		ur7pckcf21U = WithEventsValue;
	}

	public frmSequenciador()
	{
		Resize += eHNpcowxkIt;
		AtIpcITOQgr = new DeclaracoesFiacao.structurePnRev[1];
		JKYpc7D3arw = new DeclaracoesFiacao.structureRevisoes[1];
		CNupcattuhc = "";
		xqGpc8vrFEI = 0;
		jCHpcNc0rPm = "";
		Iy0pcFREFeq = 0;
		vFPpcQutQ6d = false;
		QudpcPLMeoJ = false;
		Evwpccq0Xdf = false;
		TL1pcKulWJM = 0;
		Bg9pceAM907 = false;
		try
		{
			if (Geral.ExisteForm("frmSequenciador") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				M2LpPANXep0();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 766]);
				cbNumConexoes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 773]);
				CKMulti.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 14]);
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 774]));
				Application.ShowModelessDialog((Form)this);
				formataDGRevisao();
				formataDGEquip();
				formataDGDisp();
				formataDGPot();
				formataDGSeq();
				CarregaDGRevisao();
				CarregaPnRev();
				AevpPVFnk1c();
				btSalvar.Enabled = false;
				cbNumConexoes.Checked = true;
				dgSeq.MultiSelect = false;
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

	private void V7IpPsKgSGB(object P_0, EventArgs P_1)
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			int num = 0;
			foreach (DataGridViewRow item in (IEnumerable)dgSeq.Rows)
			{
				num = checked(num + 1);
				int indice = Conversions.ToInteger(item.Cells[0].Value);
				cDadosAccessFiacao2.AtualizaOrdemTerminal(indice, num);
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
			cDadosAccessFiacao2.fechaConexao();
			btSalvar.Enabled = false;
		}
	}

	private void OPSpPByFlDG(object P_0, EventArgs P_1)
	{
		AevpPVFnk1c();
		btSalvar.Enabled = false;
	}

	private void AevpPVFnk1c()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			CNupcattuhc = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			I9WpcqTq3o9 = new Dictionary<int, int>();
			cDadosAccessFiacao2.CarregaDicPotenciais(DeclaracoesGeral.arqAtivo.Indice, CNupcattuhc, ref I9WpcqTq3o9);
			vFPpcQutQ6d = true;
			dgEquip.Rows.Clear();
			vFPpcQutQ6d = false;
			int num = Information.UBound(AtIpcITOQgr);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(AtIpcITOQgr[i].revisao, CNupcattuhc, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(AtIpcITOQgr[i].painel, Dicionario.BuscaNomeDoPainel(AtIpcITOQgr[i].painel));
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void o2MpPuElVp7(object P_0, EventArgs P_1)
	{
		if (!vFPpcQutQ6d)
		{
			Ub1pPEjV9gC();
		}
		btSalvar.Enabled = false;
	}

	private void Ub1pPEjV9gC()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgEquip.SelectedRows.Count != 1)
			{
				return;
			}
			xqGpc8vrFEI = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			List<string> list = cDadosAccessFiacao2.CarregaDispositivos(DeclaracoesGeral.arqAtivo.Indice, CNupcattuhc, xqGpc8vrFEI);
			QudpcPLMeoJ = true;
			dgDisp.Rows.Clear();
			QudpcPLMeoJ = false;
			dgDisp.Rows.Add(DeclaracoesGeral.mMensagem[1, 768]);
			foreach (string item in list)
			{
				dgDisp.Rows.Add(item);
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void PG9pPZPf5Zp(object P_0, EventArgs P_1)
	{
		KpSpPSfW6y7();
		btSalvar.Enabled = false;
	}

	private void qn9pPiiTCW3(object P_0, EventArgs P_1)
	{
		if (!QudpcPLMeoJ)
		{
			KpSpPSfW6y7();
		}
		btSalvar.Enabled = false;
	}

	private void KpSpPSfW6y7()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgDisp.SelectedRows.Count != 1)
			{
				return;
			}
			jCHpcNc0rPm = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
			List<int> list = (dgDisp.Rows[0].Selected ? cDadosAccessFiacao2.CarregaTodosPotenciais(DeclaracoesGeral.arqAtivo.Indice, CNupcattuhc, xqGpc8vrFEI, "", cbNumConexoes.Checked, ref I9WpcqTq3o9) : cDadosAccessFiacao2.CarregaTodosPotenciais(DeclaracoesGeral.arqAtivo.Indice, CNupcattuhc, xqGpc8vrFEI, jCHpcNc0rPm, cbNumConexoes.Checked, ref I9WpcqTq3o9));
			Evwpccq0Xdf = true;
			dgPot.Rows.Clear();
			Evwpccq0Xdf = false;
			dgSeq.Rows.Clear();
			foreach (int item in list)
			{
				dgPot.Rows.Add(item.ToString());
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void Y0tpP45Zxiy(object P_0, EventArgs P_1)
	{
		if (!Evwpccq0Xdf)
		{
			M2FpPCbo8rt();
		}
		btSalvar.Enabled = false;
	}

	private void M2FpPCbo8rt()
	{
		if (dgPot.RowCount == 0)
		{
			return;
		}
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			formataDGSeq();
			if (dgDisp.SelectedRows.Count == 1)
			{
				Iy0pcFREFeq = Conversions.ToInteger(dgPot.SelectedRows[0].Cells[0].Value);
				int indice = DeclaracoesGeral.arqAtivo.Indice;
				string cNupcattuhc = CNupcattuhc;
				int painel = xqGpc8vrFEI;
				int iy0pcFREFeq = Iy0pcFREFeq;
				DataGridView withEventsValue = dgSeq;
				Label withEventsValue2 = lblSecao;
				Label withEventsValue3 = lblCor;
				cDadosAccessFiacao2.CarregaSequenciamento(indice, cNupcattuhc, painel, iy0pcFREFeq, ref withEventsValue, ref withEventsValue2, ref withEventsValue3);
				lblCor = withEventsValue3;
				lblSecao = withEventsValue2;
				dgSeq = withEventsValue;
			}
			AtualizaDGSeq();
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void sywpPYfKfqH(object P_0, KeyEventArgs P_1)
	{
		checked
		{
			try
			{
				if (P_1.KeyCode != Keys.Home)
				{
					if (P_1.KeyCode == Keys.End)
					{
						DataGridViewRow dataGridViewRow = dgSeq.SelectedRows[0];
						dgSeq.Rows.RemoveAt(dgSeq.SelectedRows[0].Index);
						dgSeq.Rows.Add(dataGridViewRow);
						dgSeq.Rows[dgSeq.Rows.Count - 1].Selected = true;
						dgSeq.CurrentCell = dgSeq.Rows[dgSeq.Rows.Count - 1].Cells[1];
						btSalvar.Enabled = true;
					}
				}
				else
				{
					DataGridViewRow dataGridViewRow2 = dgSeq.SelectedRows[0];
					dgSeq.Rows.RemoveAt(dgSeq.SelectedRows[0].Index);
					dgSeq.Rows.Insert(0, dataGridViewRow2);
					dgSeq.Rows[0].Selected = true;
					dgSeq.CurrentCell = dgSeq.Rows[0].Cells[1];
					btSalvar.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
		}
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
				dgRevisao.Columns[0].Width = (int)Math.Round(num * 2f / 8f);
				dgRevisao.Columns[1].Width = (int)Math.Round(num * 2f / 8f);
				dgRevisao.Columns[2].Width = (int)Math.Round(num * 4f / 8f);
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

	public void CarregaDGRevisao()
	{
		JKYpc7D3arw = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(DeclaracoesGeral.arqAtivo.Indice, ref JKYpc7D3arw);
			int num = Information.UBound(JKYpc7D3arw);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(JKYpc7D3arw[i].revisao, JKYpc7D3arw[i].criador, JKYpc7D3arw[i].data);
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				vFPpcQutQ6d = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num2);
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
				vFPpcQutQ6d = false;
			}
		}
	}

	public void CarregaPnRev()
	{
		AtIpcITOQgr = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(JKYpc7D3arw) > 0)
			{
				int num = Information.UBound(JKYpc7D3arw);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(DeclaracoesGeral.arqAtivo.Indice, JKYpc7D3arw[i].revisao, ref AtIpcITOQgr);
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
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				QudpcPLMeoJ = true;
				dgDisp.Rows.Clear();
				dgDisp.Columns.Clear();
				dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 767]));
				int num = dgDisp.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDisp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgDisp.Width - 22;
				dgDisp.Columns[0].Width = (int)Math.Round(num2);
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
				QudpcPLMeoJ = false;
			}
		}
	}

	public void formataDGPot()
	{
		checked
		{
			try
			{
				Evwpccq0Xdf = true;
				dgPot.Rows.Clear();
				dgPot.Columns.Clear();
				dgPot.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 769]));
				int num = dgPot.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgPot.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgPot.Width - 22;
				dgPot.Columns[0].Width = (int)Math.Round(num2);
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
				Evwpccq0Xdf = false;
			}
		}
	}

	public void formataDGSeq()
	{
		checked
		{
			try
			{
				dgSeq.Rows.Clear();
				dgSeq.Columns.Clear();
				dgSeq.Columns.Add("", "Indice");
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 770]));
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1923]));
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 771]));
				dgSeq.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 772]));
				dgSeq.Columns.Add("", "Ordem");
				int num = dgSeq.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgSeq.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				AtualizaDGSeq();
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

	public void AtualizaDGSeq()
	{
		checked
		{
			try
			{
				if (dgSeq.Rows.Count == 0)
				{
					return;
				}
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgSeq)) ? ((float)(dgSeq.Width - 4)) : ((float)(dgSeq.Width - 21)));
				bool flag = false;
				int num2 = dgSeq.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(dgSeq.Rows[i].Cells[2].Value, "", TextCompare: true))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					dgSeq.Columns[0].Width = 0;
					dgSeq.Columns[0].Visible = false;
					dgSeq.Columns[1].Width = (int)Math.Round((double)num * 0.3);
					dgSeq.Columns[2].Width = (int)Math.Round((double)num * 0.3);
					dgSeq.Columns[2].Visible = true;
					dgSeq.Columns[3].Width = (int)Math.Round((double)num * 0.25);
					dgSeq.Columns[4].Width = (int)Math.Round((double)num * 0.15);
					dgSeq.Columns[5].Width = 0;
					dgSeq.Columns[5].Visible = false;
				}
				else
				{
					dgSeq.Columns[0].Width = 0;
					dgSeq.Columns[0].Visible = false;
					dgSeq.Columns[1].Width = (int)Math.Round((double)num * 0.5);
					dgSeq.Columns[2].Width = 0;
					dgSeq.Columns[2].Visible = false;
					dgSeq.Columns[3].Width = (int)Math.Round((double)num * 0.25);
					dgSeq.Columns[4].Width = (int)Math.Round((double)num * 0.25);
					dgSeq.Columns[5].Width = 0;
					dgSeq.Columns[5].Visible = false;
				}
				dgSeq.MultiSelect = true;
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

	private void CBipPrsQaMh(object P_0, EventArgs P_1)
	{
		if (dgSeq.Rows.Count == 0 || Bg9pceAM907)
		{
			return;
		}
		Bg9pceAM907 = true;
		int num = -1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgSeq.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgSeq.Rows[i].Selected)
				{
					dgSeq.Rows[i].Cells[5].Value = num;
					list.Add(Conversions.ToString(dgSeq.Rows[i].Cells[0].Value));
					num++;
					dgSeq.Rows[i].Selected = false;
				}
			}
			DataGridView dg = dgSeq;
			ordenar(ref dg);
			dgSeq = dg;
			num = 1;
			int num3 = dgSeq.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgSeq.Rows[j].Cells[5].Value = num;
				if (list.Contains(Conversions.ToString(dgSeq.Rows[j].Cells[0].Value)))
				{
					dgSeq.Rows[j].Selected = true;
					dgSeq.FirstDisplayedScrollingRowIndex = 0;
				}
				num++;
			}
			Bg9pceAM907 = false;
			btSalvar.Enabled = true;
		}
	}

	private void D7upP91jeQZ(object P_0, EventArgs P_1)
	{
		if (dgSeq.Rows.Count == 0 || Bg9pceAM907)
		{
			return;
		}
		Bg9pceAM907 = true;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgSeq.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgSeq.Rows[num3].Selected)
					{
						if (num3 == 0)
						{
							break;
						}
						list.Add(Conversions.ToString(dgSeq.Rows[num3].Cells[0].Value));
					}
					num3++;
					continue;
				}
				int num4 = dgSeq.Rows.Count - 1;
				for (int i = 0; i <= num4 && !dgSeq.Rows[i].Selected; i++)
				{
					num = i;
				}
				int num5 = -1000;
				if (num > 0)
				{
					int num6 = num - 1;
					for (int j = 0; j <= num6; j++)
					{
						dgSeq.Rows[j].Cells[5].Value = num5;
					}
				}
				int num7 = dgSeq.Rows.Count - 1;
				for (int k = 0; k <= num7; k++)
				{
					dgSeq.Rows[k].Selected = false;
				}
				num5 = 1000;
				int num8 = num;
				int num9 = dgSeq.Rows.Count - 1;
				for (int l = num8; l <= num9; l++)
				{
					if (!list.Contains(Conversions.ToString(dgSeq.Rows[l].Cells[0].Value)))
					{
						dgSeq.Rows[l].Cells[5].Value = num5;
						num5++;
					}
				}
				DataGridView dg = dgSeq;
				ordenar(ref dg);
				dgSeq = dg;
				num5 = 1;
				int num10 = dgSeq.Rows.Count - 1;
				for (int m = 0; m <= num10; m++)
				{
					dgSeq.Rows[m].Cells[5].Value = num5;
					if (list.Contains(Conversions.ToString(dgSeq.Rows[m].Cells[0].Value)))
					{
						dgSeq.Rows[m].Selected = true;
						if (flag)
						{
							flag = false;
							dgSeq.FirstDisplayedScrollingRowIndex = m;
						}
					}
					num5++;
				}
				break;
			}
			Bg9pceAM907 = false;
			btSalvar.Enabled = true;
		}
	}

	private void vRspPzoNQID(object P_0, EventArgs P_1)
	{
		if (dgSeq.Rows.Count == 0 || Bg9pceAM907)
		{
			return;
		}
		Bg9pceAM907 = true;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgSeq.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgSeq.Rows[i].Selected)
				{
					num = i;
					list.Add(Conversions.ToString(dgSeq.Rows[i].Cells[0].Value));
				}
			}
			if (num < dgSeq.Rows.Count - 1)
			{
				num++;
				int num3 = -1000;
				int num4 = dgSeq.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (j > num)
					{
						num3 = 1000;
						num = 1000;
					}
					if (!list.Contains(Conversions.ToString(dgSeq.Rows[j].Cells[0].Value)))
					{
						dgSeq.Rows[j].Cells[5].Value = num3;
						num3++;
					}
				}
				int num5 = dgSeq.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					dgSeq.Rows[k].Selected = false;
				}
				DataGridView dg = dgSeq;
				ordenar(ref dg);
				dgSeq = dg;
				num3 = 1;
				int num6 = dgSeq.Rows.Count - 1;
				for (int l = 0; l <= num6; l++)
				{
					dgSeq.Rows[l].Cells[5].Value = num3;
					if (list.Contains(Conversions.ToString(dgSeq.Rows[l].Cells[0].Value)))
					{
						dgSeq.Rows[l].Selected = true;
						if (flag)
						{
							flag = false;
							dgSeq.FirstDisplayedScrollingRowIndex = l;
						}
					}
					num3++;
				}
			}
			Bg9pceAM907 = false;
			btSalvar.Enabled = true;
		}
	}

	public static void ordenar(ref DataGridView dg)
	{
		checked
		{
			if (dg.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = dg.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = dg.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					if (Conversions.ToDouble(dg.Rows[j].Cells[5].Value) > Conversions.ToDouble(dg.Rows[j + 1].Cells[5].Value))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[num3].Value);
							dg.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(dg.Rows[j + 1].Cells[num3].Value);
							dg.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 5);
					}
				}
			}
		}
	}

	private void XAWpcWEfGsJ(object P_0, EventArgs P_1)
	{
		if (dgSeq.Rows.Count == 0 || Bg9pceAM907)
		{
			return;
		}
		Bg9pceAM907 = true;
		int num = 1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgSeq.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgSeq.Rows[i].Selected)
				{
					dgSeq.Rows[i].Cells[5].Value = num;
					list.Add(Conversions.ToString(dgSeq.Rows[i].Cells[0].Value));
					num++;
					dgSeq.Rows[i].Selected = false;
				}
			}
			DataGridView dg = dgSeq;
			ordenar(ref dg);
			dgSeq = dg;
			num = 1;
			int num3 = dgSeq.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgSeq.Rows[j].Cells[5].Value = num;
				if (list.Contains(Conversions.ToString(dgSeq.Rows[j].Cells[0].Value)))
				{
					dgSeq.Rows[j].Selected = true;
					dgSeq.FirstDisplayedScrollingRowIndex = j;
				}
				num++;
			}
			Bg9pceAM907 = false;
			btSalvar.Enabled = true;
		}
	}

	private void HWapcp7mwNm(object P_0, EventArgs P_1)
	{
		if (!CKMulti.Checked)
		{
			if (!CKMulti.Checked)
			{
				dgSeq.MultiSelect = false;
			}
		}
		else
		{
			dgSeq.MultiSelect = true;
		}
	}

	private void ae3pcTSkjGI(object P_0, MouseEventArgs P_1)
	{
		if (!dgSeq.MultiSelect)
		{
			DataGridView.HitTestInfo hitTestInfo = dgSeq.HitTest(P_1.X, P_1.Y);
			if (hitTestInfo.RowIndex >= 0)
			{
				DataGridViewRow data = dgSeq.Rows[hitTestInfo.RowIndex];
				TL1pcKulWJM = hitTestInfo.RowIndex;
				dgSeq.Rows[TL1pcKulWJM].Selected = true;
				dgSeq.DoDragDrop(data, DragDropEffects.All);
			}
		}
	}

	private void mJ9pcJTVppN(object P_0, DragEventArgs P_1)
	{
		if (dgSeq.MultiSelect)
		{
			return;
		}
		Point point = dgSeq.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgSeq.HitTest(point.X, point.Y);
		if (TL1pcKulWJM == hitTestInfo.RowIndex)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		dataGridViewRow2.Cells[2].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[2].Value);
		dataGridViewRow2.Cells[3].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[3].Value);
		checked
		{
			if (hitTestInfo.RowIndex == -1)
			{
				dgSeq.Rows.Add(dataGridViewRow2);
				dgSeq.Rows.RemoveAt(TL1pcKulWJM);
			}
			else
			{
				dgSeq.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
				if (TL1pcKulWJM > hitTestInfo.RowIndex)
				{
					TL1pcKulWJM++;
				}
				dgSeq.Rows.RemoveAt(TL1pcKulWJM);
			}
			btSalvar.Enabled = true;
		}
	}

	private void Mlppchbeeay(object P_0, DragEventArgs P_1)
	{
		if (!dgSeq.MultiSelect)
		{
			P_1.Effect = DragDropEffects.Copy;
		}
	}

	private void eHNpcowxkIt(object P_0, EventArgs P_1)
	{
		AtualizaDGSeq();
	}
}
