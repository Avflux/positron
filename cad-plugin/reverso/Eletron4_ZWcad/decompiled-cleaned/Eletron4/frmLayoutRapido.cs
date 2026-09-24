using System;
using System.Collections.Generic;
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
using ZwSoft.ZwCAD.ApplicationServices.Core;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmLayoutRapido : Form
{
	private IContainer Qp9pk4ZNsLU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGEquip")]
	private DataGridView BTwpkCdRITD;

	[AccessedThroughProperty("DGDisp")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView N77pkYysvRf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGPorta")]
	private DataGridView Fwupkrw81XV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGChassi")]
	private DataGridView hO5pk9RDlS8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTSalvar")]
	private Button IbFpkzh5ytb;

	[AccessedThroughProperty("CBMultiselecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox FGvpdWgZt8a;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTMoveChassi")]
	private Button EV3pdpY7Xhk;

	[CompilerGenerated]
	[AccessedThroughProperty("BTMovePorta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button OKnpdTHqhEi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btUltimoPorta")]
	private Button VSIpdJxqPZx;

	[AccessedThroughProperty("btPrimeiroPorta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button HpcpdhcTHfp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBaixoPorta")]
	private Button MVlpdowxLF3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCimaPorta")]
	private Button XbApdGQccvp;

	[AccessedThroughProperty("btUltimoChassi")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button e75pdHjklcY;

	[CompilerGenerated]
	[AccessedThroughProperty("btPrimeiroChassi")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button be0pdkY2tB9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBaixoChassi")]
	private Button hqjpddVYBhm;

	[AccessedThroughProperty("btCimaChassi")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button s3qpdfSlqab;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lP")]
	private Label BebpdDNpDih;

	[AccessedThroughProperty("lC")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label hIWpdvhCHkD;

	private int Fggpd68Q9TU;

	private bool jnqpdtyoW1W;

	private DataTable Tb1pdjbwAoG;

	private int QCapdLtXd2A;

	private int WC5pdws9Ot2;

	private bool PxUpdxNIgq1;

	private bool w8UpdbvHEub;

	internal virtual DataGridView DGEquip
	{
		[CompilerGenerated]
		get
		{
			return BTwpkCdRITD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Q7LpkwkWswy;
			DataGridView dataGridView = BTwpkCdRITD;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			BTwpkCdRITD = value;
			dataGridView = BTwpkCdRITD;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView DGDisp
	{
		[CompilerGenerated]
		get
		{
			return N77pkYysvRf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = GTMpkaowr2b;
			DragEventHandler value3 = LiwpkFawkQb;
			DragEventHandler value4 = ABgpkQCikGC;
			KeyEventHandler value5 = nUFpk18TVsd;
			DataGridView dataGridView = N77pkYysvRf;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
				dataGridView.DragDrop -= value3;
				dataGridView.DragEnter -= value4;
				dataGridView.KeyDown -= value5;
			}
			N77pkYysvRf = value;
			dataGridView = N77pkYysvRf;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
				dataGridView.DragDrop += value3;
				dataGridView.DragEnter += value4;
				dataGridView.KeyDown += value5;
			}
		}
	}

	internal virtual DataGridView DGPorta
	{
		[CompilerGenerated]
		get
		{
			return Fwupkrw81XV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = chnpk87rCku;
			DragEventHandler value3 = kYQpkPxnnVq;
			DragEventHandler value4 = Q5ppkcsGrYg;
			KeyEventHandler value5 = XlWpk2gtESt;
			DataGridView dataGridView = Fwupkrw81XV;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
				dataGridView.DragDrop -= value3;
				dataGridView.DragEnter -= value4;
				dataGridView.KeyDown -= value5;
			}
			Fwupkrw81XV = value;
			dataGridView = Fwupkrw81XV;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
				dataGridView.DragDrop += value3;
				dataGridView.DragEnter += value4;
				dataGridView.KeyDown += value5;
			}
		}
	}

	internal virtual DataGridView DGChassi
	{
		[CompilerGenerated]
		get
		{
			return hO5pk9RDlS8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = SIcpkNhnjJp;
			DragEventHandler value3 = f9opkKBP1MT;
			DragEventHandler value4 = ibtpke9OBHN;
			KeyEventHandler value5 = pXLpk3f3YTT;
			DataGridView dataGridView = hO5pk9RDlS8;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
				dataGridView.DragDrop -= value3;
				dataGridView.DragEnter -= value4;
				dataGridView.KeyDown -= value5;
			}
			hO5pk9RDlS8 = value;
			dataGridView = hO5pk9RDlS8;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
				dataGridView.DragDrop += value3;
				dataGridView.DragEnter += value4;
				dataGridView.KeyDown += value5;
			}
		}
	}

	internal virtual Button BTSalvar
	{
		[CompilerGenerated]
		get
		{
			return IbFpkzh5ytb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QnppkbrFQok;
			Button button = IbFpkzh5ytb;
			if (button != null)
			{
				button.Click -= value2;
			}
			IbFpkzh5ytb = value;
			button = IbFpkzh5ytb;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CBMultiselecao
	{
		[CompilerGenerated]
		get
		{
			return FGvpdWgZt8a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CFopknbSHp6;
			CheckBox checkBox = FGvpdWgZt8a;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			FGvpdWgZt8a = value;
			checkBox = FGvpdWgZt8a;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button BTMoveChassi
	{
		[CompilerGenerated]
		get
		{
			return EV3pdpY7Xhk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kWLpk5NJWwK;
			Button button = EV3pdpY7Xhk;
			if (button != null)
			{
				button.Click -= value2;
			}
			EV3pdpY7Xhk = value;
			button = EV3pdpY7Xhk;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTMovePorta
	{
		[CompilerGenerated]
		get
		{
			return OKnpdTHqhEi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ybTpk0Q5Ul5;
			Button button = OKnpdTHqhEi;
			if (button != null)
			{
				button.Click -= value2;
			}
			OKnpdTHqhEi = value;
			button = OKnpdTHqhEi;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btUltimoPorta
	{
		[CompilerGenerated]
		get
		{
			return VSIpdJxqPZx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aV3pksvGiCc;
			Button button = VSIpdJxqPZx;
			if (button != null)
			{
				button.Click -= value2;
			}
			VSIpdJxqPZx = value;
			button = VSIpdJxqPZx;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPrimeiroPorta
	{
		[CompilerGenerated]
		get
		{
			return HpcpdhcTHfp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lCWpkyKgDTw;
			Button button = HpcpdhcTHfp;
			if (button != null)
			{
				button.Click -= value2;
			}
			HpcpdhcTHfp = value;
			button = HpcpdhcTHfp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btBaixoPorta
	{
		[CompilerGenerated]
		get
		{
			return MVlpdowxLF3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WSMpkAi2hxo;
			Button button = MVlpdowxLF3;
			if (button != null)
			{
				button.Click -= value2;
			}
			MVlpdowxLF3 = value;
			button = MVlpdowxLF3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCimaPorta
	{
		[CompilerGenerated]
		get
		{
			return XbApdGQccvp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NPRpkg3nSE0;
			Button button = XbApdGQccvp;
			if (button != null)
			{
				button.Click -= value2;
			}
			XbApdGQccvp = value;
			button = XbApdGQccvp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btUltimoChassi
	{
		[CompilerGenerated]
		get
		{
			return e75pdHjklcY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FIbpkENL3Aq;
			Button button = e75pdHjklcY;
			if (button != null)
			{
				button.Click -= value2;
			}
			e75pdHjklcY = value;
			button = e75pdHjklcY;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPrimeiroChassi
	{
		[CompilerGenerated]
		get
		{
			return be0pdkY2tB9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RN3pkB3Nvjj;
			Button button = be0pdkY2tB9;
			if (button != null)
			{
				button.Click -= value2;
			}
			be0pdkY2tB9 = value;
			button = be0pdkY2tB9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btBaixoChassi
	{
		[CompilerGenerated]
		get
		{
			return hqjpddVYBhm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mG7pkuGbVg9;
			Button button = hqjpddVYBhm;
			if (button != null)
			{
				button.Click -= value2;
			}
			hqjpddVYBhm = value;
			button = hqjpddVYBhm;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCimaChassi
	{
		[CompilerGenerated]
		get
		{
			return s3qpdfSlqab;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UwPpkV4D8PO;
			Button button = s3qpdfSlqab;
			if (button != null)
			{
				button.Click -= value2;
			}
			s3qpdfSlqab = value;
			button = s3qpdfSlqab;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lP
	{
		[CompilerGenerated]
		get
		{
			return BebpdDNpDih;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BebpdDNpDih = value;
		}
	}

	internal virtual Label lC
	{
		[CompilerGenerated]
		get
		{
			return hIWpdvhCHkD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hIWpdvhCHkD = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && Qp9pk4ZNsLU != null)
			{
				Qp9pk4ZNsLU.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void T4NpkjU2BcS()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DGEquip = new DataGridView();
		DGDisp = new DataGridView();
		DGPorta = new DataGridView();
		DGChassi = new DataGridView();
		BTSalvar = new Button();
		CBMultiselecao = new CheckBox();
		BTMoveChassi = new Button();
		BTMovePorta = new Button();
		btUltimoPorta = new Button();
		btPrimeiroPorta = new Button();
		btBaixoPorta = new Button();
		btCimaPorta = new Button();
		btUltimoChassi = new Button();
		btPrimeiroChassi = new Button();
		btBaixoChassi = new Button();
		btCimaChassi = new Button();
		lP = new Label();
		lC = new Label();
		((ISupportInitialize)DGEquip).BeginInit();
		((ISupportInitialize)DGDisp).BeginInit();
		((ISupportInitialize)DGPorta).BeginInit();
		((ISupportInitialize)DGChassi).BeginInit();
		SuspendLayout();
		DGEquip.AllowUserToAddRows = false;
		DGEquip.AllowUserToDeleteRows = false;
		DGEquip.AllowUserToOrderColumns = true;
		DGEquip.AllowUserToResizeRows = false;
		DGEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGEquip.Location = new Point(15, 12);
		DGEquip.MultiSelect = false;
		DGEquip.Name = "DGEquip";
		DGEquip.ReadOnly = true;
		DGEquip.RowHeadersVisible = false;
		DGEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGEquip.Size = new Size(160, 537);
		DGEquip.TabIndex = 0;
		DGDisp.AllowDrop = true;
		DGDisp.AllowUserToAddRows = false;
		DGDisp.AllowUserToDeleteRows = false;
		DGDisp.AllowUserToOrderColumns = true;
		DGDisp.AllowUserToResizeRows = false;
		DGDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		DGDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		DGDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGDisp.Location = new Point(195, 12);
		DGDisp.MultiSelect = false;
		DGDisp.Name = "DGDisp";
		DGDisp.ReadOnly = true;
		DGDisp.RowHeadersVisible = false;
		DGDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGDisp.Size = new Size(160, 537);
		DGDisp.TabIndex = 1;
		DGPorta.AllowDrop = true;
		DGPorta.AllowUserToAddRows = false;
		DGPorta.AllowUserToDeleteRows = false;
		DGPorta.AllowUserToOrderColumns = true;
		DGPorta.AllowUserToResizeRows = false;
		DGPorta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGPorta.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		DGPorta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		DGPorta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGPorta.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGPorta.Location = new Point(376, 12);
		DGPorta.MultiSelect = false;
		DGPorta.Name = "DGPorta";
		DGPorta.ReadOnly = true;
		DGPorta.RowHeadersVisible = false;
		DGPorta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGPorta.Size = new Size(160, 537);
		DGPorta.TabIndex = 2;
		DGChassi.AllowDrop = true;
		DGChassi.AllowUserToAddRows = false;
		DGChassi.AllowUserToDeleteRows = false;
		DGChassi.AllowUserToOrderColumns = true;
		DGChassi.AllowUserToResizeRows = false;
		DGChassi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGChassi.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		DGChassi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		DGChassi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGChassi.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGChassi.Location = new Point(584, 12);
		DGChassi.MultiSelect = false;
		DGChassi.Name = "DGChassi";
		DGChassi.ReadOnly = true;
		DGChassi.RowHeadersVisible = false;
		DGChassi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGChassi.Size = new Size(160, 486);
		DGChassi.TabIndex = 3;
		BTSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTSalvar.FlatStyle = FlatStyle.Flat;
		BTSalvar.ForeColor = SystemColors.Control;
		BTSalvar.Image = Resources.Salvar_32;
		BTSalvar.Location = new Point(699, 504);
		BTSalvar.Name = "BTSalvar";
		BTSalvar.Size = new Size(45, 45);
		BTSalvar.TabIndex = 26;
		BTSalvar.UseVisualStyleBackColor = true;
		CBMultiselecao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CBMultiselecao.AutoSize = true;
		CBMultiselecao.Location = new Point(584, 519);
		CBMultiselecao.Name = "CBMultiselecao";
		CBMultiselecao.Size = new Size(85, 17);
		CBMultiselecao.TabIndex = 27;
		CBMultiselecao.Text = "Multiseleção";
		CBMultiselecao.UseVisualStyleBackColor = true;
		BTMoveChassi.FlatStyle = FlatStyle.Flat;
		BTMoveChassi.ForeColor = SystemColors.Control;
		BTMoveChassi.Image = Resources.Direita_32;
		BTMoveChassi.Location = new Point(542, 310);
		BTMoveChassi.Name = "BTMoveChassi";
		BTMoveChassi.Size = new Size(36, 36);
		BTMoveChassi.TabIndex = 189;
		BTMoveChassi.UseVisualStyleBackColor = true;
		BTMovePorta.FlatStyle = FlatStyle.Flat;
		BTMovePorta.ForeColor = SystemColors.Control;
		BTMovePorta.Image = Resources.Esquerda_32;
		BTMovePorta.Location = new Point(542, 272);
		BTMovePorta.Name = "BTMovePorta";
		BTMovePorta.Size = new Size(36, 36);
		BTMovePorta.TabIndex = 188;
		BTMovePorta.UseVisualStyleBackColor = true;
		btUltimoPorta.Image = Resources.Ultimo_16;
		btUltimoPorta.Location = new Point(546, 177);
		btUltimoPorta.Name = "btUltimoPorta";
		btUltimoPorta.Size = new Size(23, 23);
		btUltimoPorta.TabIndex = 193;
		btUltimoPorta.UseVisualStyleBackColor = true;
		btPrimeiroPorta.Image = Resources.Primeiro_16;
		btPrimeiroPorta.Location = new Point(546, 90);
		btPrimeiroPorta.Name = "btPrimeiroPorta";
		btPrimeiroPorta.Size = new Size(23, 23);
		btPrimeiroPorta.TabIndex = 192;
		btPrimeiroPorta.UseVisualStyleBackColor = true;
		btBaixoPorta.Image = Resources.Baixo_16;
		btBaixoPorta.Location = new Point(546, 148);
		btBaixoPorta.Name = "btBaixoPorta";
		btBaixoPorta.Size = new Size(23, 23);
		btBaixoPorta.TabIndex = 191;
		btBaixoPorta.UseVisualStyleBackColor = true;
		btCimaPorta.Image = Resources.Cima_16;
		btCimaPorta.Location = new Point(546, 119);
		btCimaPorta.Name = "btCimaPorta";
		btCimaPorta.Size = new Size(23, 23);
		btCimaPorta.TabIndex = 190;
		btCimaPorta.UseVisualStyleBackColor = true;
		btUltimoChassi.Image = Resources.Ultimo_16;
		btUltimoChassi.Location = new Point(753, 177);
		btUltimoChassi.Name = "btUltimoChassi";
		btUltimoChassi.Size = new Size(23, 23);
		btUltimoChassi.TabIndex = 197;
		btUltimoChassi.UseVisualStyleBackColor = true;
		btPrimeiroChassi.Image = Resources.Primeiro_16;
		btPrimeiroChassi.Location = new Point(753, 90);
		btPrimeiroChassi.Name = "btPrimeiroChassi";
		btPrimeiroChassi.Size = new Size(23, 23);
		btPrimeiroChassi.TabIndex = 196;
		btPrimeiroChassi.UseVisualStyleBackColor = true;
		btBaixoChassi.Image = Resources.Baixo_16;
		btBaixoChassi.Location = new Point(753, 148);
		btBaixoChassi.Name = "btBaixoChassi";
		btBaixoChassi.Size = new Size(23, 23);
		btBaixoChassi.TabIndex = 195;
		btBaixoChassi.UseVisualStyleBackColor = true;
		btCimaChassi.Image = Resources.Cima_16;
		btCimaChassi.Location = new Point(753, 119);
		btCimaChassi.Name = "btCimaChassi";
		btCimaChassi.Size = new Size(23, 23);
		btCimaChassi.TabIndex = 194;
		btCimaChassi.UseVisualStyleBackColor = true;
		lP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		lP.AutoSize = true;
		lP.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lP.ForeColor = Color.Red;
		lP.Location = new Point(541, 12);
		lP.Name = "lP";
		lP.Size = new Size(35, 33);
		lP.TabIndex = 198;
		lP.Text = "P";
		lC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		lC.AutoSize = true;
		lC.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lC.ForeColor = Color.Red;
		lC.Location = new Point(748, 12);
		lC.Name = "lC";
		lC.Size = new Size(37, 33);
		lC.TabIndex = 199;
		lC.Text = "C";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(784, 561);
		Controls.Add(lC);
		Controls.Add(lP);
		Controls.Add(btUltimoChassi);
		Controls.Add(btPrimeiroChassi);
		Controls.Add(btBaixoChassi);
		Controls.Add(btCimaChassi);
		Controls.Add(btUltimoPorta);
		Controls.Add(btPrimeiroPorta);
		Controls.Add(btBaixoPorta);
		Controls.Add(btCimaPorta);
		Controls.Add(BTMoveChassi);
		Controls.Add(BTMovePorta);
		Controls.Add(CBMultiselecao);
		Controls.Add(BTSalvar);
		Controls.Add(DGChassi);
		Controls.Add(DGPorta);
		Controls.Add(DGDisp);
		Controls.Add(DGEquip);
		MaximumSize = new Size(800, 1000);
		MinimumSize = new Size(800, 600);
		Name = "frmLayoutRapido";
		ShowInTaskbar = false;
		Text = "frmLayoutRapido";
		((ISupportInitialize)DGEquip).EndInit();
		((ISupportInitialize)DGDisp).EndInit();
		((ISupportInitialize)DGPorta).EndInit();
		((ISupportInitialize)DGChassi).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmLayoutRapido()
	{
		Resize += gsjpkiU6joL;
		Fggpd68Q9TU = 0;
		jnqpdtyoW1W = false;
		Tb1pdjbwAoG = new DataTable();
		QCapdLtXd2A = 0;
		WC5pdws9Ot2 = 0;
		PxUpdxNIgq1 = false;
		w8UpdbvHEub = false;
		try
		{
			if (Geral.ExisteForm("frmLayoutRapido") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				T4NpkjU2BcS();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 747]);
				CBMultiselecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 14]);
				cDadosAccess.carregaPainelDicionario();
				FormataDGEquip();
				CarregaDGEquip();
				FormataDGPorta();
				FormataDGChassi();
				clsDispositivoTacito.carregaTodosDispositivosLayout(ref Tb1pdjbwAoG, ref jnqpdtyoW1W);
				BTSalvar.Enabled = false;
				JLLpkLy9Yk2();
				CBMultiselecao.Checked = false;
				DGDisp.MultiSelect = false;
				lP.Visible = CBMultiselecao.Checked;
				lC.Visible = CBMultiselecao.Checked;
				Application.ShowModelessDialog((Form)this);
				K09pkRZT0mF();
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

	private void JLLpkLy9Yk2()
	{
		if (DGEquip.Rows.Count == 0 || DicionarioLayout.ExisteDicLayout())
		{
			return;
		}
		checked
		{
			int num = DGEquip.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				Fggpd68Q9TU = Conversions.ToInteger(DGEquip.Rows[i].Cells[0].Value);
				string filterExpression = "Painel=" + Fggpd68Q9TU;
				string sort = "Tag ASC";
				DataRow[] array = Tb1pdjbwAoG.Select(filterExpression, sort);
				int upperBound = array.GetUpperBound(0);
				for (int j = 0; j <= upperBound; j++)
				{
					string item = Conversions.ToString(array[j][1]);
					Conversions.ToString(array[j][1]);
					list5.Add(item);
					if (!(list.Contains(item) | list3.Contains(item)))
					{
						list6.Add(item);
					}
				}
				foreach (string item2 in list)
				{
					if (Operators.CompareString(item2, "---", TextCompare: true) == 0)
					{
						list2.Add("---------------");
					}
					if (list5.Contains(item2))
					{
						list2.Add(item2);
					}
				}
				foreach (string item3 in list3)
				{
					if (Operators.CompareString(item3, "---", TextCompare: true) == 0)
					{
						list4.Add("---------------");
					}
					if (list5.Contains(item3))
					{
						list4.Add(item3);
					}
				}
				NMwpkOwxwe1(Fggpd68Q9TU, ref list6, ref list2, ref list4);
			}
		}
	}

	private void Q7LpkwkWswy(object P_0, EventArgs P_1)
	{
		if (BTSalvar.Enabled && BTSalvar.Enabled)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1089], "?"), MsgBoxStyle.YesNo, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				A2ZpkMr3sNP();
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
		SUlpkxBDcON();
	}

	private void SUlpkxBDcON()
	{
		FormataDGDisp();
		FormataDGPorta();
		FormataDGChassi();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		if (DGEquip.SelectedRows.Count <= 0)
		{
			return;
		}
		Fggpd68Q9TU = Conversions.ToInteger(DGEquip.SelectedRows[0].Cells[0].Value);
		checked
		{
			if (!DicionarioLayout.ExisteDicLayoutPainel(Fggpd68Q9TU.ToString()))
			{
				string filterExpression = "Painel=" + Fggpd68Q9TU;
				string sort = "Tag ASC";
				DataRow[] array = Tb1pdjbwAoG.Select(filterExpression, sort);
				int upperBound = array.GetUpperBound(0);
				for (int i = 0; i <= upperBound; i++)
				{
					string text = Conversions.ToString(array[i][1]);
					string text2 = Conversions.ToString(array[i][2]);
					list3.Add(text + "|" + text2);
				}
				foreach (string item in list3)
				{
					string[] array2 = item.Split('|');
					if (DGDisp.RowCount == 0)
					{
						FormataDGDisp();
					}
					DGDisp.Rows.Add(array2[0], array2[1], 0);
				}
			}
			else
			{
				string filterExpression2 = "Painel=" + Fggpd68Q9TU;
				string sort2 = "Tag ASC";
				DataRow[] array3 = Tb1pdjbwAoG.Select(filterExpression2, sort2);
				int upperBound2 = array3.GetUpperBound(0);
				for (int j = 0; j <= upperBound2; j++)
				{
					string text3 = Conversions.ToString(array3[j][1]);
					string text4 = Conversions.ToString(array3[j][2]);
					list3.Add(text3 + "|" + text4);
				}
				DeclaracoesEntidades.StructureLayout[] mTags = new DeclaracoesEntidades.StructureLayout[1];
				if (DicionarioLayout.LeDicLayout("P" + Fggpd68Q9TU, ref mTags))
				{
					int num = 0;
					int num2 = 0;
					float num3 = 1000f;
					DeclaracoesEntidades.StructureLayout[] array4 = mTags;
					for (int k = 0; k < array4.Length; k++)
					{
						DeclaracoesEntidades.StructureLayout structureLayout = array4[k];
						num2 = (int)Math.Round(((double)num3 - structureLayout.Y) / 10.0);
						int num4 = num2;
						for (num = 1; num <= num4; num++)
						{
							if (DGPorta.RowCount == 0)
							{
								FormataDGPorta();
							}
							DGPorta.Rows.Add("---------------", "", 0);
						}
						if (list3.Contains(structureLayout.Tag + "|" + structureLayout.Alternativo))
						{
							if (DGPorta.RowCount == 0)
							{
								FormataDGPorta();
							}
							DGPorta.Rows.Add(TiraTal(structureLayout.Tag), TiraTal(structureLayout.Alternativo), 0);
							list.Add(structureLayout.Tag + "|" + structureLayout.Alternativo);
						}
						num3 = (float)structureLayout.Y;
					}
				}
				DeclaracoesEntidades.StructureLayout[] mTags2 = new DeclaracoesEntidades.StructureLayout[1];
				if (DicionarioLayout.LeDicLayout("C" + Fggpd68Q9TU, ref mTags2))
				{
					int num5 = 0;
					int num6 = 0;
					float num7 = 1000f;
					DeclaracoesEntidades.StructureLayout[] array5 = mTags2;
					for (int l = 0; l < array5.Length; l++)
					{
						DeclaracoesEntidades.StructureLayout structureLayout2 = array5[l];
						num6 = (int)Math.Round(((double)num7 - structureLayout2.Y) / 10.0);
						int num8 = num6;
						for (num5 = 1; num5 <= num8; num5++)
						{
							if (DGChassi.RowCount == 0)
							{
								FormataDGChassi();
							}
							DGChassi.Rows.Add("---------------", "", 0);
						}
						if (list3.Contains(structureLayout2.Tag + "|" + structureLayout2.Alternativo))
						{
							if (DGChassi.RowCount == 0)
							{
								FormataDGChassi();
							}
							DGChassi.Rows.Add(TiraTal(structureLayout2.Tag), TiraTal(structureLayout2.Alternativo), 0);
							list2.Add(structureLayout2.Tag + "|" + structureLayout2.Alternativo);
						}
						num7 = (float)structureLayout2.Y;
					}
				}
				foreach (string item2 in list3)
				{
					if (!(list.Contains(item2) | list2.Contains(item2)))
					{
						if (DGDisp.RowCount == 0)
						{
							FormataDGDisp();
						}
						string[] array6 = item2.Split('|');
						DGDisp.Rows.Add(array6[0], array6[1], 0);
					}
				}
			}
			if (DGDisp.Rows.Count != 0)
			{
				BTSalvar.Enabled = false;
			}
			else if (!((DGPorta.Rows.Count == 0) & (DGChassi.Rows.Count == 0)))
			{
				BTSalvar.Enabled = false;
			}
			else
			{
				BTSalvar.Enabled = false;
			}
			r22pkmwcumj();
			fmypkX2FHth();
			vbopkUSvGGG();
		}
	}

	public string TiraTal(string s)
	{
		return s.Replace("|", "");
	}

	private void QnppkbrFQok(object P_0, EventArgs P_1)
	{
		A2ZpkMr3sNP();
	}

	private void A2ZpkMr3sNP()
	{
		checked
		{
			if (Fggpd68Q9TU > 0)
			{
				int num = 0;
				int num2 = 0;
				float num3 = 0f;
				float num4 = 1000f;
				num = tYNpk7x0r9u("P");
				if (num <= 0)
				{
					DicionarioLayout.ApagaDicLayoutPainel("P", Fggpd68Q9TU.ToString());
				}
				else
				{
					DeclaracoesEntidades.StructureLayout[] array = new DeclaracoesEntidades.StructureLayout[1];
					array = new DeclaracoesEntidades.StructureLayout[num - 1 + 1];
					num2 = 0;
					int num5 = DGPorta.Rows.Count - 1;
					for (int i = 0; i <= num5; i++)
					{
						string text = Conversions.ToString(DGPorta.Rows[i].Cells[0].Value);
						string alternativo = "";
						if (jnqpdtyoW1W)
						{
							alternativo = Conversions.ToString(DGPorta.Rows[i].Cells[1].Value);
						}
						if (!text.Contains("------"))
						{
							num3 += 10f;
							array[num2].Tag = text;
							array[num2].Alternativo = alternativo;
							array[num2].X = num3;
							array[num2].Y = num4;
							num2++;
						}
						else
						{
							num4 -= 10f;
							num3 = 0f;
						}
					}
					DicionarioLayout.gravaDicLayout("P" + Fggpd68Q9TU, ref array);
				}
				num = tYNpk7x0r9u("C");
				num3 = 0f;
				num4 = 1000f;
				if (num <= 0)
				{
					DicionarioLayout.ApagaDicLayoutPainel("C", Fggpd68Q9TU.ToString());
				}
				else
				{
					DeclaracoesEntidades.StructureLayout[] array2 = new DeclaracoesEntidades.StructureLayout[1];
					array2 = new DeclaracoesEntidades.StructureLayout[num - 1 + 1];
					num2 = 0;
					int num6 = DGChassi.Rows.Count - 1;
					for (int j = 0; j <= num6; j++)
					{
						string text2 = Conversions.ToString(DGChassi.Rows[j].Cells[0].Value);
						string alternativo2 = "";
						if (jnqpdtyoW1W)
						{
							alternativo2 = Conversions.ToString(DGChassi.Rows[j].Cells[1].Value);
						}
						if (!text2.Contains("------"))
						{
							num3 += 10f;
							array2[num2].Tag = text2;
							array2[num2].Alternativo = alternativo2;
							array2[num2].X = num3;
							array2[num2].Y = num4;
							num2++;
						}
						else
						{
							num4 -= 10f;
							num3 = 0f;
						}
					}
					DicionarioLayout.gravaDicLayout("C" + Fggpd68Q9TU, ref array2);
				}
			}
			if (DGDisp.Rows.Count != 0)
			{
				BTSalvar.Enabled = true;
			}
			else
			{
				BTSalvar.Enabled = false;
			}
		}
	}

	private void NMwpkOwxwe1(int P_0, ref List<string> P_1, ref List<string> P_2, ref List<string> P_3)
	{
		int num = 0;
		int num2 = 0;
		float num3 = 0f;
		float num4 = 1000f;
		num = U2GpkqeU7lH(ref P_2);
		checked
		{
			if (num <= 0)
			{
				DicionarioLayout.ApagaDicLayoutPainel("P", P_0.ToString());
			}
			else
			{
				DeclaracoesEntidades.StructureLayout[] array = new DeclaracoesEntidades.StructureLayout[1];
				array = new DeclaracoesEntidades.StructureLayout[num - 1 + 1];
				num2 = 0;
				foreach (string item in P_2)
				{
					if (!item.Contains("------"))
					{
						num3 += 10f;
						array[num2].Tag = item;
						array[num2].Alternativo = qy0pkIHvXPs(P_0, item);
						array[num2].X = num3;
						array[num2].Y = num4;
						num2++;
					}
					else
					{
						num4 -= 10f;
						num3 = 0f;
					}
				}
				DicionarioLayout.gravaDicLayout("P" + P_0, ref array);
			}
			num = U2GpkqeU7lH(ref P_3);
			num3 = 0f;
			num4 = 1000f;
			if (num <= 0)
			{
				DicionarioLayout.ApagaDicLayoutPainel("C", P_0.ToString());
				return;
			}
			DeclaracoesEntidades.StructureLayout[] array2 = new DeclaracoesEntidades.StructureLayout[1];
			array2 = new DeclaracoesEntidades.StructureLayout[num - 1 + 1];
			num2 = 0;
			foreach (string item2 in P_3)
			{
				if (!item2.Contains("------"))
				{
					num3 += 10f;
					array2[num2].Tag = item2;
					array2[num2].Alternativo = qy0pkIHvXPs(P_0, item2);
					array2[num2].X = num3;
					array2[num2].Y = num4;
					num2++;
				}
				else
				{
					num4 -= 10f;
					num3 = 0f;
				}
			}
			DicionarioLayout.gravaDicLayout("C" + P_0, ref array2);
		}
	}

	private string qy0pkIHvXPs(int P_0, string P_1)
	{
		string text = "";
		string filterExpression = "Painel=" + P_0 + " AND Tag='" + P_1 + "'";
		DataRow[] array = Tb1pdjbwAoG.Select(filterExpression);
		return Conversions.ToString(array[0][2]);
	}

	private int tYNpk7x0r9u(string P_0)
	{
		int num = 0;
		checked
		{
			if (Operators.CompareString(P_0, "P", TextCompare: true) != 0)
			{
				if (Operators.CompareString(P_0, "C", TextCompare: true) == 0)
				{
					int num2 = DGChassi.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						string text = Conversions.ToString(DGChassi.Rows[i].Cells[0].Value);
						if (!text.Contains("------"))
						{
							num++;
						}
					}
				}
			}
			else
			{
				int num3 = DGPorta.Rows.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					string text2 = Conversions.ToString(DGPorta.Rows[j].Cells[0].Value);
					if (!text2.Contains("------"))
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	private int U2GpkqeU7lH(ref List<string> P_0)
	{
		int num = 0;
		foreach (string item in P_0)
		{
			if (!item.Contains("------"))
			{
				num = checked(num + 1);
			}
		}
		return num;
	}

	private void GTMpkaowr2b(object P_0, MouseEventArgs P_1)
	{
		if (!DGDisp.MultiSelect)
		{
			DataGridView.HitTestInfo hitTestInfo = DGDisp.HitTest(P_1.X, P_1.Y);
			if (hitTestInfo.RowIndex >= 0)
			{
				DataGridViewRow data = DGDisp.Rows[hitTestInfo.RowIndex];
				QCapdLtXd2A = 1;
				WC5pdws9Ot2 = hitTestInfo.RowIndex;
				DGDisp.Rows[WC5pdws9Ot2].Selected = true;
				DGDisp.DoDragDrop(data, DragDropEffects.All);
			}
			P9ypkSqp7lR();
		}
	}

	private void chnpk87rCku(object P_0, MouseEventArgs P_1)
	{
		if (!DGDisp.MultiSelect)
		{
			DataGridView.HitTestInfo hitTestInfo = DGPorta.HitTest(P_1.X, P_1.Y);
			if (hitTestInfo.RowIndex >= 0)
			{
				DataGridViewRow data = DGPorta.Rows[hitTestInfo.RowIndex];
				QCapdLtXd2A = 2;
				WC5pdws9Ot2 = hitTestInfo.RowIndex;
				DGPorta.Rows[WC5pdws9Ot2].Selected = true;
				DGPorta.DoDragDrop(data, DragDropEffects.All);
			}
			P9ypkSqp7lR();
		}
	}

	private void SIcpkNhnjJp(object P_0, MouseEventArgs P_1)
	{
		if (!DGDisp.MultiSelect)
		{
			DataGridView.HitTestInfo hitTestInfo = DGChassi.HitTest(P_1.X, P_1.Y);
			if (hitTestInfo.RowIndex >= 0)
			{
				DataGridViewRow data = DGChassi.Rows[hitTestInfo.RowIndex];
				QCapdLtXd2A = 3;
				WC5pdws9Ot2 = hitTestInfo.RowIndex;
				DGChassi.Rows[WC5pdws9Ot2].Selected = true;
				DGChassi.DoDragDrop(data, DragDropEffects.All);
			}
			P9ypkSqp7lR();
		}
	}

	private void LiwpkFawkQb(object P_0, DragEventArgs P_1)
	{
		Point point = DGDisp.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = DGDisp.HitTest(point.X, point.Y);
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		string text = Conversions.ToString(dataGridViewRow.Cells[0].Value);
		if (text.Contains("------"))
		{
			if (QCapdLtXd2A != 3)
			{
				if (QCapdLtXd2A == 2)
				{
					DGPorta.Rows.RemoveAt(WC5pdws9Ot2);
				}
			}
			else
			{
				DGChassi.Rows.RemoveAt(WC5pdws9Ot2);
			}
		}
		else if (hitTestInfo.RowIndex == -1)
		{
			if (QCapdLtXd2A != 3)
			{
				if (QCapdLtXd2A == 2)
				{
					if (DGDisp.RowCount == 0)
					{
						FormataDGDisp();
					}
					DGDisp.Rows.Add(dataGridViewRow2);
					DGPorta.Rows.RemoveAt(WC5pdws9Ot2);
					if (DGPorta.RowCount == 0)
					{
						FormataDGPorta();
					}
				}
			}
			else
			{
				if (DGDisp.RowCount == 0)
				{
					FormataDGDisp();
				}
				DGDisp.Rows.Add(dataGridViewRow2);
				DGChassi.Rows.RemoveAt(WC5pdws9Ot2);
				if (DGChassi.RowCount == 0)
				{
					FormataDGChassi();
				}
			}
		}
		else if (QCapdLtXd2A != 3)
		{
			if (QCapdLtXd2A == 2)
			{
				if (DGDisp.RowCount == 0)
				{
					FormataDGDisp();
				}
				DGDisp.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
				DGPorta.Rows.RemoveAt(WC5pdws9Ot2);
				if (DGPorta.RowCount == 0)
				{
					FormataDGPorta();
				}
			}
		}
		else
		{
			if (DGDisp.RowCount == 0)
			{
				FormataDGDisp();
			}
			DGDisp.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
			DGChassi.Rows.RemoveAt(WC5pdws9Ot2);
			if (DGChassi.RowCount == 0)
			{
				FormataDGChassi();
			}
		}
		if (DGDisp.Rows.Count != 0)
		{
			BTSalvar.Enabled = false;
		}
		else if (!((DGPorta.Rows.Count == 0) & (DGChassi.Rows.Count == 0)))
		{
			BTSalvar.Enabled = true;
		}
		else
		{
			BTSalvar.Enabled = false;
		}
	}

	private void ABgpkQCikGC(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}

	private void kYQpkPxnnVq(object P_0, DragEventArgs P_1)
	{
		Point point = DGPorta.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = DGPorta.HitTest(point.X, point.Y);
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		dataGridViewRow2.Cells[2].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[2].Value);
		checked
		{
			if (hitTestInfo.RowIndex == -1)
			{
				if (QCapdLtXd2A != 1)
				{
					if (QCapdLtXd2A != 3)
					{
						if (QCapdLtXd2A == 2)
						{
							DGPorta.Rows.Add(dataGridViewRow2);
							DGPorta.Rows.RemoveAt(WC5pdws9Ot2);
						}
					}
					else
					{
						if (DGPorta.RowCount == 0)
						{
							FormataDGPorta();
						}
						DGPorta.Rows.Add(dataGridViewRow2);
						DGChassi.Rows.RemoveAt(WC5pdws9Ot2);
						if (DGChassi.RowCount == 0)
						{
							FormataDGChassi();
						}
					}
				}
				else
				{
					if (DGPorta.RowCount == 0)
					{
						FormataDGPorta();
					}
					DGPorta.Rows.Add(dataGridViewRow2);
					DGDisp.Rows.RemoveAt(WC5pdws9Ot2);
					if (DGDisp.RowCount == 0)
					{
						FormataDGDisp();
					}
				}
			}
			else if (QCapdLtXd2A != 1)
			{
				if (QCapdLtXd2A != 3)
				{
					if ((QCapdLtXd2A == 2) & (WC5pdws9Ot2 != hitTestInfo.RowIndex))
					{
						DGPorta.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
						if (WC5pdws9Ot2 > hitTestInfo.RowIndex)
						{
							WC5pdws9Ot2++;
						}
						DGPorta.Rows.RemoveAt(WC5pdws9Ot2);
					}
				}
				else
				{
					if (DGPorta.RowCount == 0)
					{
						FormataDGPorta();
					}
					DGPorta.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
					DGChassi.Rows.RemoveAt(WC5pdws9Ot2);
					if (DGChassi.RowCount == 0)
					{
						FormataDGChassi();
					}
				}
			}
			else
			{
				if (DGPorta.RowCount == 0)
				{
					FormataDGPorta();
				}
				DGPorta.Rows.Add(dataGridViewRow2);
				DGDisp.Rows.RemoveAt(WC5pdws9Ot2);
				if (DGDisp.RowCount == 0)
				{
					FormataDGDisp();
				}
			}
			if (DGDisp.Rows.Count != 0)
			{
				BTSalvar.Enabled = false;
			}
			else if (!((DGPorta.Rows.Count == 0) & (DGChassi.Rows.Count == 0)))
			{
				BTSalvar.Enabled = true;
			}
			else
			{
				BTSalvar.Enabled = false;
			}
		}
	}

	private void Q5ppkcsGrYg(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}

	private void f9opkKBP1MT(object P_0, DragEventArgs P_1)
	{
		Point point = DGChassi.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = DGChassi.HitTest(point.X, point.Y);
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		if (jnqpdtyoW1W)
		{
			dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		}
		checked
		{
			if (hitTestInfo.RowIndex == -1)
			{
				if (QCapdLtXd2A != 1)
				{
					if (QCapdLtXd2A != 2)
					{
						if (QCapdLtXd2A == 3)
						{
							DGChassi.Rows.Add(dataGridViewRow2);
							DGChassi.Rows.RemoveAt(WC5pdws9Ot2);
						}
					}
					else
					{
						if (DGChassi.RowCount == 0)
						{
							FormataDGChassi();
						}
						DGChassi.Rows.Add(dataGridViewRow2);
						DGPorta.Rows.RemoveAt(WC5pdws9Ot2);
						if (DGPorta.RowCount == 0)
						{
							FormataDGPorta();
						}
					}
				}
				else
				{
					if (DGChassi.RowCount == 0)
					{
						FormataDGChassi();
					}
					DGChassi.Rows.Add(dataGridViewRow2);
					DGDisp.Rows.RemoveAt(WC5pdws9Ot2);
					if (DGDisp.RowCount == 0)
					{
						FormataDGDisp();
					}
				}
			}
			else if (QCapdLtXd2A != 1)
			{
				if (QCapdLtXd2A != 2)
				{
					if ((QCapdLtXd2A == 3) & (WC5pdws9Ot2 != hitTestInfo.RowIndex))
					{
						DGChassi.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
						if (WC5pdws9Ot2 > hitTestInfo.RowIndex)
						{
							WC5pdws9Ot2++;
						}
						DGChassi.Rows.RemoveAt(WC5pdws9Ot2);
					}
				}
				else
				{
					if (DGChassi.RowCount == 0)
					{
						FormataDGChassi();
					}
					DGChassi.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
					DGPorta.Rows.RemoveAt(WC5pdws9Ot2);
					if (DGPorta.RowCount == 0)
					{
						FormataDGPorta();
					}
				}
			}
			else
			{
				if (DGChassi.RowCount == 0)
				{
					FormataDGChassi();
				}
				DGChassi.Rows.Add(dataGridViewRow2);
				DGDisp.Rows.RemoveAt(WC5pdws9Ot2);
				if (DGDisp.RowCount == 0)
				{
					FormataDGDisp();
				}
			}
			if (DGDisp.Rows.Count != 0)
			{
				BTSalvar.Enabled = false;
			}
			else if (!((DGPorta.Rows.Count == 0) & (DGChassi.Rows.Count == 0)))
			{
				BTSalvar.Enabled = true;
			}
			else
			{
				BTSalvar.Enabled = false;
			}
		}
	}

	private void ibtpke9OBHN(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}

	private void XlWpk2gtESt(object P_0, KeyEventArgs P_1)
	{
		if (DGPorta.SelectedRows.Count == 0)
		{
			return;
		}
		checked
		{
			try
			{
				if (CBMultiselecao.Checked)
				{
					if (P_1.KeyCode != Keys.Home)
					{
						if (P_1.KeyCode == Keys.End)
						{
							DataGridViewRow[] array = new DataGridViewRow[1];
							List<int> list = new List<int>();
							int num = DGPorta.Rows.Count - 1;
							for (int i = num; i >= 0; i += -1)
							{
								if (DGPorta.Rows[i].Selected)
								{
									array = (DataGridViewRow[])Utils.CopyArray(array, new DataGridViewRow[Information.UBound(array) + 1 + 1]);
									array[Information.UBound(array)] = DGPorta.Rows[i];
									list.Add(i);
								}
							}
							foreach (int item in list)
							{
								DGPorta.Rows.RemoveAt(item);
							}
							int num2 = Information.UBound(array);
							for (int j = num2; j >= 1; j += -1)
							{
								if (DGPorta.RowCount == 0)
								{
									FormataDGPorta();
								}
								DGPorta.Rows.Add(array[j]);
							}
						}
					}
					else
					{
						DataGridViewRow[] array2 = new DataGridViewRow[1];
						List<int> list2 = new List<int>();
						int num3 = DGPorta.Rows.Count - 1;
						for (int k = num3; k >= 0; k += -1)
						{
							if (DGPorta.Rows[k].Selected)
							{
								array2 = (DataGridViewRow[])Utils.CopyArray(array2, new DataGridViewRow[Information.UBound(array2) + 1 + 1]);
								array2[Information.UBound(array2)] = DGPorta.Rows[k];
								list2.Add(k);
							}
						}
						foreach (int item2 in list2)
						{
							DGPorta.Rows.RemoveAt(item2);
						}
						int num4 = Information.UBound(array2);
						for (int l = 1; l <= num4; l++)
						{
							DGPorta.Rows.Insert(0, array2[l]);
						}
					}
				}
				else if (P_1.KeyCode != Keys.Insert)
				{
					if (P_1.KeyCode != Keys.Home)
					{
						if (P_1.KeyCode != Keys.End)
						{
							if (P_1.KeyCode == Keys.Delete)
							{
								string text = Conversions.ToString(DGPorta.SelectedRows[0].Cells[0].Value);
								string text2 = Conversions.ToString(DGPorta.SelectedRows[0].Cells[1].Value);
								if (!text.Contains("------"))
								{
									if (DGDisp.RowCount == 0)
									{
										FormataDGDisp();
									}
									DGDisp.Rows.Add(text, text2, 0);
								}
								DGPorta.Rows.RemoveAt(DGPorta.SelectedRows[0].Index);
								if (DGPorta.RowCount == 0)
								{
									FormataDGPorta();
								}
							}
						}
						else
						{
							string text3 = Conversions.ToString(DGPorta.SelectedRows[0].Cells[0].Value);
							DGPorta.Rows.RemoveAt(DGPorta.SelectedRows[0].Index);
							DGPorta.Rows.Add(text3);
							DGPorta.Rows[DGPorta.Rows.Count - 1].Selected = true;
							DGPorta.CurrentCell = DGPorta.Rows[DGPorta.Rows.Count - 1].Cells[0];
						}
					}
					else
					{
						string text4 = Conversions.ToString(DGPorta.SelectedRows[0].Cells[0].Value);
						DGPorta.Rows.RemoveAt(DGPorta.SelectedRows[0].Index);
						DGPorta.Rows.Insert(0, text4);
						DGPorta.Rows[0].Selected = true;
						DGPorta.CurrentCell = DGPorta.Rows[0].Cells[0];
					}
				}
				else
				{
					DGPorta.Rows.Insert(DGPorta.SelectedRows[0].Index, "---------------");
				}
				if (DGDisp.Rows.Count != 0)
				{
					BTSalvar.Enabled = false;
				}
				else if (!((DGPorta.Rows.Count == 0) & (DGChassi.Rows.Count == 0)))
				{
					BTSalvar.Enabled = true;
				}
				else
				{
					BTSalvar.Enabled = false;
				}
				r22pkmwcumj();
				fmypkX2FHth();
				vbopkUSvGGG();
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

	private void pXLpk3f3YTT(object P_0, KeyEventArgs P_1)
	{
		if (DGChassi.SelectedRows.Count == 0)
		{
			return;
		}
		checked
		{
			try
			{
				if (CBMultiselecao.Checked)
				{
					if (P_1.KeyCode != Keys.Home)
					{
						if (P_1.KeyCode == Keys.End)
						{
							DataGridViewRow[] array = new DataGridViewRow[1];
							List<int> list = new List<int>();
							int num = DGChassi.Rows.Count - 1;
							for (int i = num; i >= 0; i += -1)
							{
								if (DGChassi.Rows[i].Selected)
								{
									array = (DataGridViewRow[])Utils.CopyArray(array, new DataGridViewRow[Information.UBound(array) + 1 + 1]);
									array[Information.UBound(array)] = DGChassi.Rows[i];
									list.Add(i);
								}
							}
							foreach (int item in list)
							{
								DGChassi.Rows.RemoveAt(item);
							}
							int num2 = Information.UBound(array);
							for (int j = num2; j >= 1; j += -1)
							{
								DGChassi.Rows.Add(array[j]);
							}
						}
					}
					else
					{
						DataGridViewRow[] array2 = new DataGridViewRow[1];
						List<int> list2 = new List<int>();
						int num3 = DGChassi.Rows.Count - 1;
						for (int k = num3; k >= 0; k += -1)
						{
							if (DGChassi.Rows[k].Selected)
							{
								array2 = (DataGridViewRow[])Utils.CopyArray(array2, new DataGridViewRow[Information.UBound(array2) + 1 + 1]);
								array2[Information.UBound(array2)] = DGChassi.Rows[k];
								list2.Add(k);
							}
						}
						foreach (int item2 in list2)
						{
							DGChassi.Rows.RemoveAt(item2);
						}
						int num4 = Information.UBound(array2);
						for (int l = 1; l <= num4; l++)
						{
							DGChassi.Rows.Insert(0, array2[l]);
						}
					}
				}
				else if (P_1.KeyCode != Keys.Insert)
				{
					if (P_1.KeyCode != Keys.Home)
					{
						if (P_1.KeyCode != Keys.End)
						{
							if (P_1.KeyCode == Keys.Delete)
							{
								string text = Conversions.ToString(DGChassi.SelectedRows[0].Cells[0].Value);
								string text2 = Conversions.ToString(DGChassi.SelectedRows[0].Cells[1].Value);
								if (!text.Contains("------"))
								{
									if (DGDisp.RowCount == 0)
									{
										FormataDGDisp();
									}
									DGDisp.Rows.Add(text, text2, 0);
								}
								DGChassi.Rows.RemoveAt(DGChassi.SelectedRows[0].Index);
								if (DGChassi.RowCount == 0)
								{
									FormataDGChassi();
								}
							}
						}
						else
						{
							string text3 = Conversions.ToString(DGChassi.SelectedRows[0].Cells[0].Value);
							DGChassi.Rows.RemoveAt(DGChassi.SelectedRows[0].Index);
							DGChassi.Rows.Add(text3);
							DGChassi.Rows[DGChassi.Rows.Count - 1].Selected = true;
							DGChassi.CurrentCell = DGChassi.Rows[DGChassi.Rows.Count - 1].Cells[0];
						}
					}
					else
					{
						string text4 = Conversions.ToString(DGChassi.SelectedRows[0].Cells[0].Value);
						DGChassi.Rows.RemoveAt(DGChassi.SelectedRows[0].Index);
						DGChassi.Rows.Insert(0, text4);
						DGChassi.Rows[0].Selected = true;
						DGChassi.CurrentCell = DGChassi.Rows[0].Cells[0];
					}
				}
				else
				{
					DGChassi.Rows.Insert(DGChassi.SelectedRows[0].Index, "---------------");
				}
				if (DGDisp.Rows.Count != 0)
				{
					BTSalvar.Enabled = false;
				}
				else if (!((DGPorta.Rows.Count == 0) & (DGChassi.Rows.Count == 0)))
				{
					BTSalvar.Enabled = true;
				}
				else
				{
					BTSalvar.Enabled = false;
				}
				r22pkmwcumj();
				fmypkX2FHth();
				vbopkUSvGGG();
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

	private void CFopknbSHp6(object P_0, EventArgs P_1)
	{
		if (!CBMultiselecao.Checked)
		{
			DGDisp.MultiSelect = false;
			DGPorta.MultiSelect = false;
			DGChassi.MultiSelect = false;
			DGDisp.AllowDrop = true;
			DGPorta.AllowDrop = true;
			DGChassi.AllowDrop = true;
		}
		else
		{
			DGDisp.MultiSelect = true;
			DGPorta.MultiSelect = true;
			DGChassi.MultiSelect = true;
			DGDisp.AllowDrop = false;
			DGPorta.AllowDrop = false;
			DGChassi.AllowDrop = false;
		}
		lP.Visible = CBMultiselecao.Checked;
		lC.Visible = CBMultiselecao.Checked;
	}

	private void nUFpk18TVsd(object P_0, KeyEventArgs P_1)
	{
		try
		{
			if ((P_1.KeyCode == Keys.P) | (P_1.KeyCode == Keys.D))
			{
				foreach (DataGridViewRow selectedRow in DGDisp.SelectedRows)
				{
					DataGridViewRow dataGridViewRow2 = (DataGridViewRow)selectedRow.Clone();
					dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(selectedRow.Cells[0].Value);
					dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(selectedRow.Cells[1].Value);
					dataGridViewRow2.Cells[2].Value = RuntimeHelpers.GetObjectValue(selectedRow.Cells[2].Value);
					if (DGPorta.RowCount == 0)
					{
						FormataDGPorta();
					}
					DGPorta.Rows.Add(dataGridViewRow2);
					DGDisp.Rows.RemoveAt(selectedRow.Index);
					if (DGDisp.RowCount == 0)
					{
						FormataDGDisp();
					}
				}
			}
			else if ((P_1.KeyCode == Keys.C) | (P_1.KeyCode == Keys.I))
			{
				foreach (DataGridViewRow selectedRow2 in DGDisp.SelectedRows)
				{
					DataGridViewRow dataGridViewRow4 = (DataGridViewRow)selectedRow2.Clone();
					dataGridViewRow4.Cells[0].Value = RuntimeHelpers.GetObjectValue(selectedRow2.Cells[0].Value);
					dataGridViewRow4.Cells[1].Value = RuntimeHelpers.GetObjectValue(selectedRow2.Cells[1].Value);
					dataGridViewRow4.Cells[2].Value = RuntimeHelpers.GetObjectValue(selectedRow2.Cells[2].Value);
					if (DGChassi.RowCount == 0)
					{
						FormataDGChassi();
					}
					DGChassi.Rows.Add(dataGridViewRow4);
					DGDisp.Rows.RemoveAt(selectedRow2.Index);
					if (DGDisp.RowCount == 0)
					{
						FormataDGDisp();
					}
				}
			}
			if (DGDisp.Rows.Count != 0)
			{
				BTSalvar.Enabled = false;
			}
			else if (!((DGPorta.Rows.Count == 0) & (DGChassi.Rows.Count == 0)))
			{
				BTSalvar.Enabled = true;
			}
			else
			{
				BTSalvar.Enabled = false;
			}
			r22pkmwcumj();
			fmypkX2FHth();
			vbopkUSvGGG();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaDGEquip()
	{
		try
		{
			List<int> lEquip = new List<int>();
			clsConexao.carregaEquipComFiacao(ref lEquip);
			foreach (int key in DeclaracoesGeral.dicPainel.Keys)
			{
				if (lEquip.Contains(key))
				{
					DGEquip.Rows.Add(key, DeclaracoesGeral.dicPainel[key]);
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

	public void CarregaDGDisp()
	{
		try
		{
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void PtypkleVt8c(object P_0, EventArgs P_1)
	{
		SUlpkxBDcON();
	}

	private void kWLpk5NJWwK(object P_0, EventArgs P_1)
	{
		List<int> list = new List<int>();
		checked
		{
			int num = DGPorta.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGPorta.Rows[i].Selected)
				{
					list.Add(i);
					if (DGChassi.RowCount == 0)
					{
						FormataDGChassi();
					}
					DGChassi.Rows.Add(DGPorta.Rows[i].Cells[0].Value, DGPorta.Rows[i].Cells[1].Value, DGPorta.Rows[i].Cells[2].Value);
				}
			}
			list.Reverse();
			foreach (int item in list)
			{
				DGPorta.Rows.RemoveAt(item);
			}
			if (DGPorta.RowCount == 0)
			{
				FormataDGPorta();
			}
			fmypkX2FHth();
			vbopkUSvGGG();
			BTSalvar.Enabled = true;
		}
	}

	private void ybTpk0Q5Ul5(object P_0, EventArgs P_1)
	{
		List<int> list = new List<int>();
		checked
		{
			int num = DGChassi.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGChassi.Rows[i].Selected)
				{
					list.Add(i);
					if (DGPorta.RowCount == 0)
					{
						FormataDGPorta();
					}
					DGPorta.Rows.Add(DGChassi.Rows[i].Cells[0].Value, DGChassi.Rows[i].Cells[1].Value, DGChassi.Rows[i].Cells[2].Value);
				}
			}
			list.Reverse();
			foreach (int item in list)
			{
				DGChassi.Rows.RemoveAt(item);
			}
			if (DGChassi.RowCount == 0)
			{
				FormataDGChassi();
			}
			fmypkX2FHth();
			vbopkUSvGGG();
			BTSalvar.Enabled = true;
		}
	}

	public void FormataDGEquip()
	{
		checked
		{
			try
			{
				DGEquip.Rows.Clear();
				DGEquip.Columns.Clear();
				DGEquip.Columns.Add("", "Indice");
				DGEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				K09pkRZT0mF();
				int num = DGEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DGEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void FormataDGDisp()
	{
		checked
		{
			try
			{
				DGDisp.Rows.Clear();
				DGDisp.Columns.Clear();
				DGDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 749]));
				DGDisp.Columns.Add("", Strings.Mid(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]), 1, 5));
				DGDisp.Columns.Add("", "");
				int num = DGDisp.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DGDisp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void FormataDGPorta()
	{
		checked
		{
			try
			{
				DGPorta.Rows.Clear();
				DGPorta.Columns.Clear();
				DGPorta.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 750]));
				DGPorta.Columns.Add("", Strings.Mid(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]), 1, 5));
				DGPorta.Columns.Add("", "#");
				int num = DGPorta.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DGPorta.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void FormataDGChassi()
	{
		checked
		{
			try
			{
				DGChassi.Rows.Clear();
				DGChassi.Columns.Clear();
				DGChassi.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 751]));
				DGChassi.Columns.Add("", Strings.Mid(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]), 1, 5));
				DGChassi.Columns.Add("", "#");
				int num = DGChassi.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DGChassi.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	private void K09pkRZT0mF()
	{
		checked
		{
			if (DGEquip.RowCount != 0)
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGEquip)) ? ((float)(DGEquip.Width - 4)) : ((float)(DGEquip.Width - 22)));
				DGEquip.Columns[0].Width = 0;
				DGEquip.Columns[0].Visible = false;
				DGEquip.Columns[1].Width = (int)Math.Round(num);
				DGEquip.Columns[1].Visible = true;
			}
		}
	}

	private void r22pkmwcumj()
	{
		checked
		{
			if (DGDisp.RowCount != 0)
			{
				float num = DGDisp.Width - 4;
				if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGDisp))
				{
					num = DGDisp.Width - 22;
				}
				if (jnqpdtyoW1W)
				{
					DGDisp.Columns[0].Width = (int)Math.Round((double)num * 0.7);
					DGDisp.Columns[1].Width = (int)Math.Round((double)num * 0.3);
					DGDisp.Columns[2].Width = 0;
					DGDisp.Columns[2].Visible = false;
				}
				else
				{
					DGDisp.Columns[0].Width = (int)Math.Round(num);
					DGDisp.Columns[1].Width = 0;
					DGDisp.Columns[1].Visible = false;
					DGDisp.Columns[2].Width = 0;
					DGDisp.Columns[2].Visible = false;
				}
			}
			else
			{
				DGDisp.Columns.Clear();
			}
		}
	}

	private void fmypkX2FHth()
	{
		checked
		{
			if (DGPorta.RowCount != 0)
			{
				float num = 0f;
				num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGPorta)) ? ((float)(DGPorta.Width - 4)) : ((float)(DGPorta.Width - 22)));
				if (jnqpdtyoW1W)
				{
					DGPorta.Columns[0].Width = (int)Math.Round((double)num * 0.7);
					DGPorta.Columns[1].Width = (int)Math.Round((double)num * 0.3);
					DGPorta.Columns[2].Width = 0;
					DGPorta.Columns[2].Visible = false;
				}
				else
				{
					DGPorta.Columns[0].Width = (int)Math.Round(num);
					DGPorta.Columns[1].Width = 0;
					DGPorta.Columns[1].Visible = false;
					DGPorta.Columns[2].Width = 0;
					DGPorta.Columns[2].Visible = false;
				}
			}
			else
			{
				DGPorta.Columns.Clear();
			}
		}
	}

	private void vbopkUSvGGG()
	{
		checked
		{
			if (DGChassi.RowCount != 0)
			{
				float num = 0f;
				num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGChassi)) ? ((float)(DGChassi.Width - 4)) : ((float)(DGChassi.Width - 22)));
				if (jnqpdtyoW1W)
				{
					DGChassi.Columns[0].Width = (int)Math.Round((double)num * 0.7);
					DGChassi.Columns[1].Width = (int)Math.Round((double)num * 0.3);
					DGChassi.Columns[2].Width = 0;
					DGChassi.Columns[2].Visible = false;
				}
				else
				{
					DGChassi.Columns[0].Width = (int)Math.Round(num);
					DGChassi.Columns[1].Width = 0;
					DGChassi.Columns[1].Visible = false;
					DGChassi.Columns[2].Width = 0;
					DGChassi.Columns[2].Visible = false;
				}
			}
			else
			{
				DGChassi.Columns.Clear();
			}
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
					if (Conversions.ToDouble(dg.Rows[j].Cells[2].Value) > Conversions.ToDouble(dg.Rows[j + 1].Cells[2].Value))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[num3].Value);
							dg.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(dg.Rows[j + 1].Cells[num3].Value);
							dg.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 2);
					}
				}
			}
		}
	}

	private void lCWpkyKgDTw(object P_0, EventArgs P_1)
	{
		if (DGPorta.Rows.Count == 0 || PxUpdxNIgq1)
		{
			return;
		}
		DataGridView withEventsValue = DGPorta;
		di9pkZj7Ho2(ref withEventsValue);
		DGPorta = withEventsValue;
		PxUpdxNIgq1 = true;
		int num = -1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGPorta.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (DGPorta.Rows[i].Selected)
				{
					DGPorta.Rows[i].Cells[2].Value = num;
					list.Add(Conversions.ToString(DGPorta.Rows[i].Cells[0].Value));
					num++;
					DGPorta.Rows[i].Selected = false;
				}
			}
			withEventsValue = DGPorta;
			ordenar(ref withEventsValue);
			DGPorta = withEventsValue;
			num = 1;
			int num3 = DGPorta.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				DGPorta.Rows[j].Cells[2].Value = num;
				if (list.Contains(Conversions.ToString(DGPorta.Rows[j].Cells[0].Value)))
				{
					DGPorta.Rows[j].Selected = true;
					DGPorta.FirstDisplayedScrollingRowIndex = 0;
				}
				num++;
			}
			PxUpdxNIgq1 = false;
			BTSalvar.Enabled = true;
		}
	}

	private void NPRpkg3nSE0(object P_0, EventArgs P_1)
	{
		if (DGPorta.Rows.Count == 0 || PxUpdxNIgq1)
		{
			return;
		}
		PxUpdxNIgq1 = true;
		DataGridView withEventsValue = DGPorta;
		di9pkZj7Ho2(ref withEventsValue);
		DGPorta = withEventsValue;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGPorta.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (DGPorta.Rows[num3].Selected)
					{
						if (num3 == 0)
						{
							break;
						}
						list.Add(Conversions.ToString(DGPorta.Rows[num3].Cells[0].Value));
					}
					num3++;
					continue;
				}
				int num4 = DGPorta.Rows.Count - 1;
				for (int i = 0; i <= num4 && !DGPorta.Rows[i].Selected; i++)
				{
					num = i;
				}
				int num5 = -1000;
				if (num > 0)
				{
					int num6 = num - 1;
					for (int j = 0; j <= num6; j++)
					{
						DGPorta.Rows[j].Cells[2].Value = num5;
					}
				}
				int num7 = DGPorta.Rows.Count - 1;
				for (int k = 0; k <= num7; k++)
				{
					DGPorta.Rows[k].Selected = false;
				}
				num5 = 1000;
				int num8 = num;
				int num9 = DGPorta.Rows.Count - 1;
				for (int l = num8; l <= num9; l++)
				{
					if (!list.Contains(Conversions.ToString(DGPorta.Rows[l].Cells[0].Value)))
					{
						DGPorta.Rows[l].Cells[2].Value = num5;
						num5++;
					}
				}
				withEventsValue = DGPorta;
				ordenar(ref withEventsValue);
				DGPorta = withEventsValue;
				num5 = 1;
				int num10 = DGPorta.Rows.Count - 1;
				for (int m = 0; m <= num10; m++)
				{
					DGPorta.Rows[m].Cells[2].Value = num5;
					if (list.Contains(Conversions.ToString(DGPorta.Rows[m].Cells[0].Value)))
					{
						DGPorta.Rows[m].Selected = true;
						if (flag)
						{
							flag = false;
							DGPorta.FirstDisplayedScrollingRowIndex = m;
						}
					}
					num5++;
				}
				break;
			}
			PxUpdxNIgq1 = false;
			BTSalvar.Enabled = true;
		}
	}

	private void WSMpkAi2hxo(object P_0, EventArgs P_1)
	{
		if (DGPorta.Rows.Count == 0 || PxUpdxNIgq1)
		{
			return;
		}
		PxUpdxNIgq1 = true;
		DataGridView withEventsValue = DGPorta;
		di9pkZj7Ho2(ref withEventsValue);
		DGPorta = withEventsValue;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGPorta.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (DGPorta.Rows[i].Selected)
				{
					num = i;
					list.Add(Conversions.ToString(DGPorta.Rows[i].Cells[0].Value));
				}
			}
			if (num < DGPorta.Rows.Count - 1)
			{
				num++;
				int num3 = -1000;
				int num4 = DGPorta.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (j > num)
					{
						num3 = 1000;
						num = 1000;
					}
					if (!list.Contains(Conversions.ToString(DGPorta.Rows[j].Cells[0].Value)))
					{
						DGPorta.Rows[j].Cells[2].Value = num3;
						num3++;
					}
				}
				int num5 = DGPorta.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					DGPorta.Rows[k].Selected = false;
				}
				withEventsValue = DGPorta;
				ordenar(ref withEventsValue);
				DGPorta = withEventsValue;
				num3 = 1;
				int num6 = DGPorta.Rows.Count - 1;
				for (int l = 0; l <= num6; l++)
				{
					DGPorta.Rows[l].Cells[2].Value = num3;
					if (list.Contains(Conversions.ToString(DGPorta.Rows[l].Cells[0].Value)))
					{
						DGPorta.Rows[l].Selected = true;
						if (flag)
						{
							flag = false;
							DGPorta.FirstDisplayedScrollingRowIndex = l;
						}
					}
					num3++;
				}
			}
			PxUpdxNIgq1 = false;
			BTSalvar.Enabled = true;
		}
	}

	private void aV3pksvGiCc(object P_0, EventArgs P_1)
	{
		if (DGPorta.Rows.Count == 0 || PxUpdxNIgq1)
		{
			return;
		}
		PxUpdxNIgq1 = true;
		DataGridView withEventsValue = DGPorta;
		di9pkZj7Ho2(ref withEventsValue);
		DGPorta = withEventsValue;
		int num = 1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGPorta.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (DGPorta.Rows[i].Selected)
				{
					DGPorta.Rows[i].Cells[2].Value = num;
					list.Add(Conversions.ToString(DGPorta.Rows[i].Cells[0].Value));
					num++;
					DGPorta.Rows[i].Selected = false;
				}
			}
			withEventsValue = DGPorta;
			ordenar(ref withEventsValue);
			DGPorta = withEventsValue;
			num = 1;
			int num3 = DGPorta.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				DGPorta.Rows[j].Cells[2].Value = num;
				if (list.Contains(Conversions.ToString(DGPorta.Rows[j].Cells[0].Value)))
				{
					DGPorta.Rows[j].Selected = true;
					DGPorta.FirstDisplayedScrollingRowIndex = j;
				}
				num++;
			}
			PxUpdxNIgq1 = false;
			BTSalvar.Enabled = true;
		}
	}

	private void RN3pkB3Nvjj(object P_0, EventArgs P_1)
	{
		if (DGChassi.Rows.Count == 0 || w8UpdbvHEub)
		{
			return;
		}
		w8UpdbvHEub = true;
		DataGridView withEventsValue = DGChassi;
		di9pkZj7Ho2(ref withEventsValue);
		DGChassi = withEventsValue;
		int num = -1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGChassi.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (DGChassi.Rows[i].Selected)
				{
					DGChassi.Rows[i].Cells[2].Value = num;
					list.Add(Conversions.ToString(DGChassi.Rows[i].Cells[0].Value));
					num++;
					DGChassi.Rows[i].Selected = false;
				}
			}
			withEventsValue = DGChassi;
			ordenar(ref withEventsValue);
			DGChassi = withEventsValue;
			num = 1;
			int num3 = DGChassi.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				DGChassi.Rows[j].Cells[2].Value = num;
				if (list.Contains(Conversions.ToString(DGChassi.Rows[j].Cells[0].Value)))
				{
					DGChassi.Rows[j].Selected = true;
					DGChassi.FirstDisplayedScrollingRowIndex = 0;
				}
				num++;
			}
			w8UpdbvHEub = false;
			BTSalvar.Enabled = true;
		}
	}

	private void UwPpkV4D8PO(object P_0, EventArgs P_1)
	{
		if (DGChassi.Rows.Count == 0 || w8UpdbvHEub)
		{
			return;
		}
		w8UpdbvHEub = true;
		DataGridView withEventsValue = DGChassi;
		di9pkZj7Ho2(ref withEventsValue);
		DGChassi = withEventsValue;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGChassi.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (DGChassi.Rows[num3].Selected)
					{
						if (num3 == 0)
						{
							break;
						}
						list.Add(Conversions.ToString(DGChassi.Rows[num3].Cells[0].Value));
					}
					num3++;
					continue;
				}
				int num4 = DGChassi.Rows.Count - 1;
				for (int i = 0; i <= num4 && !DGChassi.Rows[i].Selected; i++)
				{
					num = i;
				}
				int num5 = -1000;
				if (num > 0)
				{
					int num6 = num - 1;
					for (int j = 0; j <= num6; j++)
					{
						DGChassi.Rows[j].Cells[2].Value = num5;
					}
				}
				int num7 = DGChassi.Rows.Count - 1;
				for (int k = 0; k <= num7; k++)
				{
					DGChassi.Rows[k].Selected = false;
				}
				num5 = 1000;
				int num8 = num;
				int num9 = DGChassi.Rows.Count - 1;
				for (int l = num8; l <= num9; l++)
				{
					if (!list.Contains(Conversions.ToString(DGChassi.Rows[l].Cells[0].Value)))
					{
						DGChassi.Rows[l].Cells[2].Value = num5;
						num5++;
					}
				}
				withEventsValue = DGChassi;
				ordenar(ref withEventsValue);
				DGChassi = withEventsValue;
				num5 = 1;
				int num10 = DGChassi.Rows.Count - 1;
				for (int m = 0; m <= num10; m++)
				{
					DGChassi.Rows[m].Cells[2].Value = num5;
					if (list.Contains(Conversions.ToString(DGChassi.Rows[m].Cells[0].Value)))
					{
						DGChassi.Rows[m].Selected = true;
						if (flag)
						{
							flag = false;
							DGChassi.FirstDisplayedScrollingRowIndex = m;
						}
					}
					num5++;
				}
				break;
			}
			w8UpdbvHEub = false;
			BTSalvar.Enabled = true;
		}
	}

	private void mG7pkuGbVg9(object P_0, EventArgs P_1)
	{
		if (DGChassi.Rows.Count == 0 || w8UpdbvHEub)
		{
			return;
		}
		w8UpdbvHEub = true;
		DataGridView withEventsValue = DGChassi;
		di9pkZj7Ho2(ref withEventsValue);
		DGChassi = withEventsValue;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGChassi.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (DGChassi.Rows[i].Selected)
				{
					num = i;
					list.Add(Conversions.ToString(DGChassi.Rows[i].Cells[0].Value));
				}
			}
			if (num < DGChassi.Rows.Count - 1)
			{
				num++;
				int num3 = -1000;
				int num4 = DGChassi.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (j > num)
					{
						num3 = 1000;
						num = 1000;
					}
					if (!list.Contains(Conversions.ToString(DGChassi.Rows[j].Cells[0].Value)))
					{
						DGChassi.Rows[j].Cells[2].Value = num3;
						num3++;
					}
				}
				int num5 = DGChassi.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					DGChassi.Rows[k].Selected = false;
				}
				withEventsValue = DGChassi;
				ordenar(ref withEventsValue);
				DGChassi = withEventsValue;
				num3 = 1;
				int num6 = DGChassi.Rows.Count - 1;
				for (int l = 0; l <= num6; l++)
				{
					DGChassi.Rows[l].Cells[2].Value = num3;
					if (list.Contains(Conversions.ToString(DGChassi.Rows[l].Cells[0].Value)))
					{
						DGChassi.Rows[l].Selected = true;
						if (flag)
						{
							flag = false;
							DGChassi.FirstDisplayedScrollingRowIndex = l;
						}
					}
					num3++;
				}
			}
			w8UpdbvHEub = false;
			BTSalvar.Enabled = true;
		}
	}

	private void FIbpkENL3Aq(object P_0, EventArgs P_1)
	{
		if (DGChassi.Rows.Count == 0 || w8UpdbvHEub)
		{
			return;
		}
		w8UpdbvHEub = true;
		DataGridView withEventsValue = DGChassi;
		di9pkZj7Ho2(ref withEventsValue);
		DGChassi = withEventsValue;
		int num = 1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = DGChassi.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (DGChassi.Rows[i].Selected)
				{
					DGChassi.Rows[i].Cells[2].Value = num;
					list.Add(Conversions.ToString(DGChassi.Rows[i].Cells[0].Value));
					num++;
					DGChassi.Rows[i].Selected = false;
				}
			}
			withEventsValue = DGChassi;
			ordenar(ref withEventsValue);
			DGChassi = withEventsValue;
			num = 1;
			int num3 = DGChassi.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				DGChassi.Rows[j].Cells[2].Value = num;
				if (list.Contains(Conversions.ToString(DGChassi.Rows[j].Cells[0].Value)))
				{
					DGChassi.Rows[j].Selected = true;
					DGChassi.FirstDisplayedScrollingRowIndex = j;
				}
				num++;
			}
			w8UpdbvHEub = false;
			BTSalvar.Enabled = true;
		}
	}

	private void di9pkZj7Ho2(ref DataGridView P_0)
	{
		int num = 1;
		checked
		{
			int num2 = P_0.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				P_0.Rows[i].Cells[2].Value = num;
				num++;
			}
		}
	}

	private void gsjpkiU6joL(object P_0, EventArgs P_1)
	{
		P9ypkSqp7lR();
	}

	private void P9ypkSqp7lR()
	{
		K09pkRZT0mF();
		r22pkmwcumj();
		fmypkX2FHth();
		vbopkUSvGGG();
	}
}
