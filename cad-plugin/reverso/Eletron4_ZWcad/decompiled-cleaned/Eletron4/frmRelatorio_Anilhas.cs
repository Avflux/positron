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

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Anilhas : Form
{
	private IContainer v0c6Mo0PI0;

	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView uOV6OtM6f1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView zcF6I9bLfT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgFiacao")]
	[CompilerGenerated]
	private DataGridView CMG67h1qCQ;

	[AccessedThroughProperty("btPesquisar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button A346qgybPy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWG")]
	[CompilerGenerated]
	private DataGridView XQS6aXN3LP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCEL")]
	private Button OZj681dUgJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip M5L6NSgfJQ;

	[AccessedThroughProperty("cbAlternativo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox Vmc6FuGlQd;

	[AccessedThroughProperty("cbSecaoCor")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox WNu6QNICPo;

	[AccessedThroughProperty("cbJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox SMX6PdbSWZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbLayout")]
	private CheckBox TVE6cnKFsr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox hp46KgRgHO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDelimitadorTT2")]
	private TextBox LTN6eebsbB;

	[AccessedThroughProperty("tbDelimitadorTT")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox AkZ629D7Q4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbSufixoCruzado")]
	private TextBox m7r63Dvcon;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPrefixoCruzado")]
	[CompilerGenerated]
	private TextBox iqS6nW3XWQ;

	[CompilerGenerated]
	[AccessedThroughProperty("tbDelimitadorD")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox KNl61hmKba;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPrefixoPonto")]
	private TextBox o3J6lqVvCB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSufixoPonto")]
	private TextBox ayX656CRvD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox5")]
	private PictureBox wW160mVnYr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox jr46R7DCQE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb7")]
	[CompilerGenerated]
	private RadioButton XxL6mOOJZm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb1")]
	private RadioButton pVi6XPdxvB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb6")]
	private RadioButton FRm6UHEf90;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb2")]
	private RadioButton zXc6yolqGs;

	[AccessedThroughProperty("rb4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton wKg6gB7Fsj;

	[AccessedThroughProperty("rb3")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton rei6A5uInb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb5")]
	private RadioButton Dcg6sS12Gu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox3")]
	private PictureBox tq66BQCPBE;

	[AccessedThroughProperty("rb0")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton cMR6VIl9LK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbV")]
	private RadioButton TtY6unVUoT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbN")]
	private RadioButton GD76EeBW8Y;

	[AccessedThroughProperty("rbS")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton aGd6ZqeuC9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox jmG6iMLuXN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb8")]
	private RadioButton qF16SYB3RH;

	private DeclaracoesFiacao.structurePnRev[] V1164p9ZH9;

	private DeclaracoesFiacao.structureRevisoes[] hEP6CFGGyO;

	private int Haf6Y4024R;

	private string vqX6rxLsTG;

	private int DKs69YoLNc;

	private bool FSp6zTK4OT;

	private bool H0htWPuMdj;

	public DeclaracoesFiacao.structureRelPotencial[] mRelPotencial;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return uOV6OtM6f1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TJV6vH4upo;
			DataGridView dataGridView = uOV6OtM6f1;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			uOV6OtM6f1 = value;
			dataGridView = uOV6OtM6f1;
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
			return zcF6I9bLfT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zcF6I9bLfT = value;
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return CMG67h1qCQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CMG67h1qCQ = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return A346qgybPy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Epx6jOKMsG;
			Button button = A346qgybPy;
			if (button != null)
			{
				button.Click -= value2;
			}
			A346qgybPy = value;
			button = A346qgybPy;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return XQS6aXN3LP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = z4J6fR0ykW;
			DataGridView dataGridView = XQS6aXN3LP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			XQS6aXN3LP = value;
			dataGridView = XQS6aXN3LP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btExportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return OZj681dUgJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IV46tqqKfH;
			Button button = OZj681dUgJ;
			if (button != null)
			{
				button.Click -= value2;
			}
			OZj681dUgJ = value;
			button = OZj681dUgJ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return Vmc6FuGlQd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Vmc6FuGlQd = value;
		}
	}

	internal virtual CheckBox cbSecaoCor
	{
		[CompilerGenerated]
		get
		{
			return WNu6QNICPo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WNu6QNICPo = value;
		}
	}

	internal virtual CheckBox cbJumper
	{
		[CompilerGenerated]
		get
		{
			return SMX6PdbSWZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SMX6PdbSWZ = value;
		}
	}

	internal virtual CheckBox cbLayout
	{
		[CompilerGenerated]
		get
		{
			return TVE6cnKFsr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TVE6cnKFsr = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return hp46KgRgHO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hp46KgRgHO = value;
		}
	}

	internal virtual TextBox tbDelimitadorTT2
	{
		[CompilerGenerated]
		get
		{
			return LTN6eebsbB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LTN6eebsbB = value;
		}
	}

	internal virtual TextBox tbDelimitadorTT
	{
		[CompilerGenerated]
		get
		{
			return AkZ629D7Q4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = o5v6wdKsRw;
			TextBox textBox = AkZ629D7Q4;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			AkZ629D7Q4 = value;
			textBox = AkZ629D7Q4;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	internal virtual TextBox tbSufixoCruzado
	{
		[CompilerGenerated]
		get
		{
			return m7r63Dvcon;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m7r63Dvcon = value;
		}
	}

	internal virtual TextBox tbPrefixoCruzado
	{
		[CompilerGenerated]
		get
		{
			return iqS6nW3XWQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iqS6nW3XWQ = value;
		}
	}

	internal virtual TextBox tbDelimitadorD
	{
		[CompilerGenerated]
		get
		{
			return KNl61hmKba;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KNl61hmKba = value;
		}
	}

	internal virtual TextBox tbPrefixoPonto
	{
		[CompilerGenerated]
		get
		{
			return o3J6lqVvCB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o3J6lqVvCB = value;
		}
	}

	internal virtual TextBox tbSufixoPonto
	{
		[CompilerGenerated]
		get
		{
			return ayX656CRvD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ayX656CRvD = value;
		}
	}

	internal virtual PictureBox PictureBox5
	{
		[CompilerGenerated]
		get
		{
			return wW160mVnYr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wW160mVnYr = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return jr46R7DCQE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jr46R7DCQE = value;
		}
	}

	internal virtual RadioButton rb7
	{
		[CompilerGenerated]
		get
		{
			return XxL6mOOJZm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XxL6mOOJZm = value;
		}
	}

	internal virtual RadioButton rb1
	{
		[CompilerGenerated]
		get
		{
			return pVi6XPdxvB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pVi6XPdxvB = value;
		}
	}

	internal virtual RadioButton rb6
	{
		[CompilerGenerated]
		get
		{
			return FRm6UHEf90;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FRm6UHEf90 = value;
		}
	}

	internal virtual RadioButton rb2
	{
		[CompilerGenerated]
		get
		{
			return zXc6yolqGs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zXc6yolqGs = value;
		}
	}

	internal virtual RadioButton rb4
	{
		[CompilerGenerated]
		get
		{
			return wKg6gB7Fsj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wKg6gB7Fsj = value;
		}
	}

	internal virtual RadioButton rb3
	{
		[CompilerGenerated]
		get
		{
			return rei6A5uInb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rei6A5uInb = value;
		}
	}

	internal virtual RadioButton rb5
	{
		[CompilerGenerated]
		get
		{
			return Dcg6sS12Gu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Dcg6sS12Gu = value;
		}
	}

	internal virtual PictureBox PictureBox3
	{
		[CompilerGenerated]
		get
		{
			return tq66BQCPBE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tq66BQCPBE = value;
		}
	}

	internal virtual RadioButton rb0
	{
		[CompilerGenerated]
		get
		{
			return cMR6VIl9LK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cMR6VIl9LK = value;
		}
	}

	internal virtual RadioButton rbV
	{
		[CompilerGenerated]
		get
		{
			return TtY6unVUoT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TtY6unVUoT = value;
		}
	}

	internal virtual RadioButton rbN
	{
		[CompilerGenerated]
		get
		{
			return GD76EeBW8Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GD76EeBW8Y = value;
		}
	}

	internal virtual RadioButton rbS
	{
		[CompilerGenerated]
		get
		{
			return aGd6ZqeuC9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aGd6ZqeuC9 = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return jmG6iMLuXN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jmG6iMLuXN = value;
		}
	}

	internal virtual RadioButton rb8
	{
		[CompilerGenerated]
		get
		{
			return qF16SYB3RH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qF16SYB3RH = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && v0c6Mo0PI0 != null)
			{
				v0c6Mo0PI0.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void H0U6dSewtv()
	{
		v0c6Mo0PI0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgFiacao = new DataGridView();
		btPesquisar = new Button();
		dgDWG = new DataGridView();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(v0c6Mo0PI0));
		cbAlternativo = new CheckBox();
		cbSecaoCor = new CheckBox();
		cbJumper = new CheckBox();
		cbLayout = new CheckBox();
		GroupBox3 = new GroupBox();
		tbDelimitadorTT2 = new TextBox();
		tbDelimitadorTT = new TextBox();
		tbSufixoCruzado = new TextBox();
		tbPrefixoCruzado = new TextBox();
		tbDelimitadorD = new TextBox();
		tbPrefixoPonto = new TextBox();
		tbSufixoPonto = new TextBox();
		PictureBox5 = new PictureBox();
		GroupBox2 = new GroupBox();
		rb0 = new RadioButton();
		rb7 = new RadioButton();
		rb1 = new RadioButton();
		rb6 = new RadioButton();
		rb2 = new RadioButton();
		rb4 = new RadioButton();
		rb3 = new RadioButton();
		rb5 = new RadioButton();
		PictureBox3 = new PictureBox();
		rbV = new RadioButton();
		rbN = new RadioButton();
		rbS = new RadioButton();
		GroupBox1 = new GroupBox();
		rb8 = new RadioButton();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgFiacao).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		GroupBox3.SuspendLayout();
		((ISupportInitialize)PictureBox5).BeginInit();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)PictureBox3).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
		dgRevisao.Location = new Point(12, 129);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(90, 105);
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
		dgEquip.Location = new Point(108, 129);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(135, 105);
		dgEquip.TabIndex = 8;
		dgFiacao.AllowUserToAddRows = false;
		dgFiacao.AllowUserToDeleteRows = false;
		dgFiacao.AllowUserToResizeRows = false;
		dgFiacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgFiacao.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgFiacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgFiacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgFiacao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgFiacao.Location = new Point(249, 12);
		dgFiacao.MultiSelect = false;
		dgFiacao.Name = "dgFiacao";
		dgFiacao.ReadOnly = true;
		dgFiacao.RowHeadersVisible = false;
		dgFiacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgFiacao.Size = new Size(573, 617);
		dgFiacao.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(131, 587);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDWG.Location = new Point(12, 12);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(231, 111);
		dgDWG.TabIndex = 17;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(186, 578);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 51);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		cbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAlternativo.AutoSize = true;
		cbAlternativo.Location = new Point(10, 530);
		cbAlternativo.Name = "cbAlternativo";
		cbAlternativo.Size = new Size(76, 17);
		cbAlternativo.TabIndex = 42;
		cbAlternativo.Text = "Alternativo";
		cbAlternativo.UseVisualStyleBackColor = true;
		cbSecaoCor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbSecaoCor.AutoSize = true;
		cbSecaoCor.Location = new Point(10, 596);
		cbSecaoCor.Name = "cbSecaoCor";
		cbSecaoCor.Size = new Size(85, 17);
		cbSecaoCor.TabIndex = 46;
		cbSecaoCor.Text = "Seção e Cor";
		cbSecaoCor.UseVisualStyleBackColor = true;
		cbJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbJumper.AutoSize = true;
		cbJumper.Location = new Point(10, 552);
		cbJumper.Name = "cbJumper";
		cbJumper.Size = new Size(60, 17);
		cbJumper.TabIndex = 47;
		cbJumper.Text = "Jumper";
		cbJumper.UseVisualStyleBackColor = true;
		cbLayout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbLayout.AutoSize = true;
		cbLayout.Location = new Point(10, 574);
		cbLayout.Name = "cbLayout";
		cbLayout.Size = new Size(92, 17);
		cbLayout.TabIndex = 48;
		cbLayout.Text = "Ordem Layout";
		cbLayout.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(tbDelimitadorTT2);
		GroupBox3.Controls.Add(tbDelimitadorTT);
		GroupBox3.Controls.Add(tbSufixoCruzado);
		GroupBox3.Controls.Add(tbPrefixoCruzado);
		GroupBox3.Controls.Add(tbDelimitadorD);
		GroupBox3.Controls.Add(tbPrefixoPonto);
		GroupBox3.Controls.Add(tbSufixoPonto);
		GroupBox3.Controls.Add(PictureBox5);
		GroupBox3.Location = new Point(12, 467);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(231, 57);
		GroupBox3.TabIndex = 50;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Delimitadores";
		tbDelimitadorTT2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbDelimitadorTT2.Location = new Point(160, 23);
		tbDelimitadorTT2.Name = "tbDelimitadorTT2";
		tbDelimitadorTT2.ReadOnly = true;
		tbDelimitadorTT2.Size = new Size(16, 22);
		tbDelimitadorTT2.TabIndex = 212;
		tbDelimitadorTT2.TextAlign = HorizontalAlignment.Center;
		tbDelimitadorTT.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbDelimitadorTT.Location = new Point(42, 23);
		tbDelimitadorTT.Name = "tbDelimitadorTT";
		tbDelimitadorTT.Size = new Size(16, 22);
		tbDelimitadorTT.TabIndex = 9;
		tbDelimitadorTT.TextAlign = HorizontalAlignment.Center;
		tbSufixoCruzado.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbSufixoCruzado.Location = new Point(193, 23);
		tbSufixoCruzado.Name = "tbSufixoCruzado";
		tbSufixoCruzado.Size = new Size(16, 22);
		tbSufixoCruzado.TabIndex = 13;
		tbSufixoCruzado.TextAlign = HorizontalAlignment.Center;
		tbPrefixoCruzado.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbPrefixoCruzado.Location = new Point(119, 23);
		tbPrefixoCruzado.Name = "tbPrefixoCruzado";
		tbPrefixoCruzado.Size = new Size(16, 22);
		tbPrefixoCruzado.TabIndex = 12;
		tbPrefixoCruzado.TextAlign = HorizontalAlignment.Center;
		tbDelimitadorD.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbDelimitadorD.Location = new Point(100, 23);
		tbDelimitadorD.Name = "tbDelimitadorD";
		tbDelimitadorD.Size = new Size(16, 22);
		tbDelimitadorD.TabIndex = 11;
		tbDelimitadorD.TextAlign = HorizontalAlignment.Center;
		tbPrefixoPonto.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbPrefixoPonto.Location = new Point(12, 23);
		tbPrefixoPonto.Name = "tbPrefixoPonto";
		tbPrefixoPonto.Size = new Size(16, 22);
		tbPrefixoPonto.TabIndex = 8;
		tbPrefixoPonto.TextAlign = HorizontalAlignment.Center;
		tbSufixoPonto.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbSufixoPonto.Location = new Point(82, 23);
		tbSufixoPonto.Name = "tbSufixoPonto";
		tbSufixoPonto.Size = new Size(16, 22);
		tbSufixoPonto.TabIndex = 10;
		tbSufixoPonto.TextAlign = HorizontalAlignment.Center;
		PictureBox5.Anchor = AnchorStyles.Left;
		PictureBox5.Image = Resources.FormatoAnilhas;
		PictureBox5.Location = new Point(28, 20);
		PictureBox5.Name = "PictureBox5";
		PictureBox5.Size = new Size(186, 30);
		PictureBox5.TabIndex = 211;
		PictureBox5.TabStop = false;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rb8);
		GroupBox2.Controls.Add(rb0);
		GroupBox2.Controls.Add(rb7);
		GroupBox2.Controls.Add(rb1);
		GroupBox2.Controls.Add(rb6);
		GroupBox2.Controls.Add(rb2);
		GroupBox2.Controls.Add(rb4);
		GroupBox2.Controls.Add(rb3);
		GroupBox2.Controls.Add(rb5);
		GroupBox2.Controls.Add(PictureBox3);
		GroupBox2.Location = new Point(13, 240);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(230, 221);
		GroupBox2.TabIndex = 49;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Tipo de Cruzamento";
		rb0.AutoSize = true;
		rb0.Location = new Point(199, 53);
		rb0.Name = "rb0";
		rb0.Size = new Size(14, 13);
		rb0.TabIndex = 66;
		rb0.TabStop = true;
		rb0.UseVisualStyleBackColor = true;
		rb7.AutoSize = true;
		rb7.Location = new Point(199, 190);
		rb7.Name = "rb7";
		rb7.Size = new Size(14, 13);
		rb7.TabIndex = 7;
		rb7.TabStop = true;
		rb7.UseVisualStyleBackColor = true;
		rb1.AutoSize = true;
		rb1.Location = new Point(199, 72);
		rb1.Name = "rb1";
		rb1.Size = new Size(14, 13);
		rb1.TabIndex = 1;
		rb1.TabStop = true;
		rb1.UseVisualStyleBackColor = true;
		rb6.AutoSize = true;
		rb6.Location = new Point(199, 170);
		rb6.Name = "rb6";
		rb6.Size = new Size(14, 13);
		rb6.TabIndex = 6;
		rb6.TabStop = true;
		rb6.UseVisualStyleBackColor = true;
		rb2.AutoSize = true;
		rb2.Location = new Point(199, 91);
		rb2.Name = "rb2";
		rb2.Size = new Size(14, 13);
		rb2.TabIndex = 2;
		rb2.TabStop = true;
		rb2.UseVisualStyleBackColor = true;
		rb4.AutoSize = true;
		rb4.Location = new Point(199, 131);
		rb4.Name = "rb4";
		rb4.Size = new Size(14, 13);
		rb4.TabIndex = 4;
		rb4.TabStop = true;
		rb4.UseVisualStyleBackColor = true;
		rb3.AutoSize = true;
		rb3.Location = new Point(199, 111);
		rb3.Name = "rb3";
		rb3.Size = new Size(14, 13);
		rb3.TabIndex = 3;
		rb3.TabStop = true;
		rb3.UseVisualStyleBackColor = true;
		rb5.AutoSize = true;
		rb5.Location = new Point(199, 150);
		rb5.Name = "rb5";
		rb5.Size = new Size(14, 13);
		rb5.TabIndex = 5;
		rb5.TabStop = true;
		rb5.UseVisualStyleBackColor = true;
		PictureBox3.Image = Resources.PadraoAnilhas;
		PictureBox3.Location = new Point(4, 12);
		PictureBox3.Name = "PictureBox3";
		PictureBox3.Size = new Size(197, 203);
		PictureBox3.TabIndex = 65;
		PictureBox3.TabStop = false;
		rbV.AutoSize = true;
		rbV.Location = new Point(6, 19);
		rbV.Name = "rbV";
		rbV.Size = new Size(41, 17);
		rbV.TabIndex = 51;
		rbV.TabStop = true;
		rbV.Text = "rbV";
		rbV.UseVisualStyleBackColor = true;
		rbN.AutoSize = true;
		rbN.Location = new Point(62, 19);
		rbN.Name = "rbN";
		rbN.Size = new Size(42, 17);
		rbN.TabIndex = 52;
		rbN.TabStop = true;
		rbN.Text = "rbN";
		rbN.UseVisualStyleBackColor = true;
		rbS.AutoSize = true;
		rbS.Location = new Point(103, 19);
		rbS.Name = "rbS";
		rbS.Size = new Size(41, 17);
		rbS.TabIndex = 53;
		rbS.TabStop = true;
		rbS.Text = "rbS";
		rbS.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbV);
		GroupBox1.Controls.Add(rbS);
		GroupBox1.Controls.Add(rbN);
		GroupBox1.Location = new Point(99, 530);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(144, 48);
		GroupBox1.TabIndex = 54;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		rb8.AutoSize = true;
		rb8.Location = new Point(199, 35);
		rb8.Name = "rb8";
		rb8.Size = new Size(14, 13);
		rb8.TabIndex = 67;
		rb8.TabStop = true;
		rb8.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(834, 641);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(cbLayout);
		Controls.Add(cbJumper);
		Controls.Add(cbSecaoCor);
		Controls.Add(cbAlternativo);
		Controls.Add(btExportaEXCEL);
		Controls.Add(dgDWG);
		Controls.Add(btPesquisar);
		Controls.Add(dgFiacao);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(850, 680);
		Name = "frmRelatorio_Anilhas";
		ShowInTaskbar = false;
		Text = "Relatório de Anilhas";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgFiacao).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		((ISupportInitialize)PictureBox5).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)PictureBox3).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return M5L6NSgfJQ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		M5L6NSgfJQ = WithEventsValue;
	}

	public frmRelatorio_Anilhas()
	{
		Resize += NSf6xvTWyV;
		V1164p9ZH9 = new DeclaracoesFiacao.structurePnRev[1];
		hEP6CFGGyO = new DeclaracoesFiacao.structureRevisoes[1];
		Haf6Y4024R = 0;
		vqX6rxLsTG = "";
		DKs69YoLNc = 0;
		FSp6zTK4OT = false;
		H0htWPuMdj = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Anilhas"))
			{
				H0U6dSewtv();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1509]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]);
				cbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 795]);
				cbJumper.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1444]);
				cbSecaoCor.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1518]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1840]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 825]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 831]);
				rbV.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1841]);
				rbN.Text = "N";
				rbS.Text = "S";
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao();
				formataDGEquip();
				formataDGFiacao();
				CarregaDGDWG();
				cbAlternativo.Checked = false;
				cbJumper.Checked = true;
				cbSecaoCor.Checked = true;
				cbLayout.Checked = true;
				rbV.Checked = true;
				tbDelimitadorD.Text = "/";
				tbDelimitadorTT.Text = ":";
				tbPrefixoCruzado.Text = "";
				tbSufixoCruzado.Text = "";
				tbPrefixoPonto.Text = "";
				tbSufixoPonto.Text = "";
				rb0.Checked = true;
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

	private void z4J6fR0ykW(object P_0, EventArgs P_1)
	{
		FSp6zTK4OT = true;
		dgRevisao.Rows.Clear();
		FSp6zTK4OT = false;
		H0htWPuMdj = true;
		dgEquip.Rows.Clear();
		H0htWPuMdj = false;
		dYL6DMApDE();
	}

	private void dYL6DMApDE()
	{
		Haf6Y4024R = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		hEP6CFGGyO = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(Haf6Y4024R, ref hEP6CFGGyO);
			FSp6zTK4OT = true;
			dgRevisao.Rows.Clear();
			FSp6zTK4OT = false;
			int num = Information.UBound(hEP6CFGGyO);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(hEP6CFGGyO[i].revisao);
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

	private void TJV6vH4upo(object P_0, EventArgs P_1)
	{
		H0htWPuMdj = true;
		dgEquip.Rows.Clear();
		H0htWPuMdj = false;
		if (!FSp6zTK4OT)
		{
			sdL66V9PO1();
		}
	}

	private void sdL66V9PO1()
	{
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			vqX6rxLsTG = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			H0htWPuMdj = true;
			dgEquip.Rows.Clear();
			H0htWPuMdj = false;
			int num = Information.UBound(V1164p9ZH9);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(V1164p9ZH9[i].revisao, vqX6rxLsTG, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(V1164p9ZH9[i].painel, Dicionario.BuscaNomeDoPainel(V1164p9ZH9[i].painel));
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

	public void CarregaPnRev()
	{
		V1164p9ZH9 = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(hEP6CFGGyO) > 0)
			{
				int num = Information.UBound(hEP6CFGGyO);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(Haf6Y4024R, hEP6CFGGyO[i].revisao, ref V1164p9ZH9);
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

	private void IV46tqqKfH(object P_0, EventArgs P_1)
	{
		if (dgFiacao.RowCount <= 0)
		{
			return;
		}
		btExportaEXCEL.Enabled = false;
		int num = 0;
		Relatorios_AnilhaEXCEL.RelatorioAnilhas[] array = new Relatorios_AnilhaEXCEL.RelatorioAnilhas[1];
		array[0].Origem = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1510]);
		array[0].Destino = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1511]);
		array[0].AnilhaOrigem = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1512]);
		array[0].AnilhaDestino = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1513]);
		array[0].Cor_Secao = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1518]);
		string sEquip = Conversions.ToString(dgEquip.SelectedRows[0].Cells[1].Value);
		checked
		{
			int num2 = dgFiacao.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (!(dgFiacao.Rows[i].Cells[1].Style.BackColor == Color.LightGray))
				{
					num++;
					array = (Relatorios_AnilhaEXCEL.RelatorioAnilhas[])Utils.CopyArray(array, new Relatorios_AnilhaEXCEL.RelatorioAnilhas[num + 1]);
					array[num].bDispositivo = false;
					array[num].Origem = Conversions.ToString(dgFiacao.Rows[i].Cells[0].Value);
					array[num].Destino = Conversions.ToString(dgFiacao.Rows[i].Cells[2].Value);
					array[num].AnilhaOrigem = Conversions.ToString(dgFiacao.Rows[i].Cells[4].Value);
					array[num].AnilhaDestino = Conversions.ToString(dgFiacao.Rows[i].Cells[5].Value);
					array[num].Cor_Secao = Conversions.ToString(dgFiacao.Rows[i].Cells[6].Value);
				}
				else
				{
					num++;
					array = (Relatorios_AnilhaEXCEL.RelatorioAnilhas[])Utils.CopyArray(array, new Relatorios_AnilhaEXCEL.RelatorioAnilhas[num + 1]);
					array[num].bDispositivo = true;
					array[num].Origem = Conversions.ToString(dgFiacao.Rows[i].Cells[0].Value);
				}
			}
			Relatorios_AnilhaEXCEL.CriaRelatorioAnilhasEXCEL(array, sEquip, cbSecaoCor.Checked);
			btExportaEXCEL.Enabled = true;
		}
	}

	private void Epx6jOKMsG(object P_0, EventArgs P_1)
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		formataDGFiacao();
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		DKs69YoLNc = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		checked
		{
			try
			{
				DeclaracoesFiacao.structurePotencial[] mPotencial = new DeclaracoesFiacao.structurePotencial[1];
				DeclaracoesFiacao.structureAnilhas[] array = new DeclaracoesFiacao.structureAnilhas[1];
				DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
				cDadosAccessFiacao2.CarregaDispTipoIndexModelo(Haf6Y4024R, vqX6rxLsTG, DKs69YoLNc, ref mDisp);
				cDadosAccessFiacao2.CarregaPotenciaisPainel3(Haf6Y4024R, vqX6rxLsTG, DKs69YoLNc, ref mPotencial);
				if (Information.UBound(mPotencial) < 2)
				{
					return;
				}
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add("Tag1", typeof(string));
				dataTable.Columns.Add("Alternativo1", typeof(string));
				dataTable.Columns.Add("Term1", typeof(string));
				dataTable.Columns.Add("TermNum1", typeof(double));
				dataTable.Columns.Add("Tag2", typeof(string));
				dataTable.Columns.Add("Alternativo2", typeof(string));
				dataTable.Columns.Add("Term2", typeof(string));
				dataTable.Columns.Add("Ordem", typeof(int));
				dataTable.Columns.Add("Secao", typeof(string));
				dataTable.Columns.Add("Cor", typeof(string));
				dataTable.Columns.Add("bTemLink", typeof(bool));
				dataTable.Columns.Add("Orient1", typeof(string));
				dataTable.Columns.Add("Orient2", typeof(string));
				int num = 0;
				int num2 = Information.UBound(mPotencial);
				for (int i = 1; i <= num2; i++)
				{
					int potencial = mPotencial[i].Potencial;
					if (num == potencial)
					{
						int num3 = 0;
						string tag = mPotencial[i - 1].Tag;
						string text = mPotencial[i - 1].Alternativo;
						if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
						{
							text = tag;
						}
						string text2 = mPotencial[i - 1].Orientacao;
						if (Operators.CompareString(text2.Trim(), "", TextCompare: true) == 0)
						{
							if (!rbN.Checked)
							{
								if (rbS.Checked)
								{
									text2 = "S";
								}
							}
							else
							{
								text2 = "N";
							}
						}
						string text3 = "";
						text3 = ((Operators.CompareString(mPotencial[i - 1].NRegua, "", TextCompare: true) == 0) ? mPotencial[i - 1].Terminal : (mPotencial[i - 1].NRegua + ":" + mPotencial[i - 1].Terminal));
						int num4 = Information.UBound(mDisp);
						for (int j = 1; j <= num4; j++)
						{
							if (Operators.CompareString(tag, mDisp[j].Tag, TextCompare: true) == 0)
							{
								num3 = mDisp[j].PosOrdem;
								if (num3 == 3)
								{
									num3 = 3000;
								}
								break;
							}
						}
						string tag2 = mPotencial[i].Tag;
						string text4 = mPotencial[i].Alternativo;
						if (Operators.CompareString(text4.Trim(), "", TextCompare: true) == 0)
						{
							text4 = tag2;
						}
						string text5 = mPotencial[i].Orientacao;
						if (Operators.CompareString(text5.Trim(), "", TextCompare: true) == 0)
						{
							if (!rbN.Checked)
							{
								if (rbS.Checked)
								{
									text5 = "S";
								}
							}
							else
							{
								text5 = "N";
							}
						}
						string text6 = "";
						text6 = ((Operators.CompareString(mPotencial[i].NRegua, "", TextCompare: true) == 0) ? mPotencial[i].Terminal : (mPotencial[i].NRegua + ":" + mPotencial[i].Terminal));
						bool flag = false;
						if ((mPotencial[i - 1].bLink & mPotencial[i].bLink) && mPotencial[i - 1].indexModelo == mPotencial[i].indexModelo && cDadosAccessFiacao2.BornesVizinhos(Haf6Y4024R, vqX6rxLsTG, DKs69YoLNc, mPotencial[i].indexModelo, mPotencial[i - 1].Terminal, mPotencial[i].Terminal))
						{
							flag = true;
						}
						DataRow dataRow = dataTable.NewRow();
						dataRow["Tag1"] = tag;
						dataRow["Alternativo1"] = text;
						dataRow["Term1"] = text3;
						dataRow["TermNum1"] = mPotencial[i - 1].TerminalNum;
						dataRow["Tag2"] = tag2;
						dataRow["Alternativo2"] = text4;
						dataRow["Term2"] = text6;
						dataRow["Ordem"] = num3;
						dataRow["Secao"] = mPotencial[i - 1].Secao;
						dataRow["Cor"] = mPotencial[i - 1].Cor;
						dataRow["bTemLink"] = flag;
						dataRow["Orient1"] = text2;
						dataRow["Orient2"] = text5;
						dataTable.Rows.Add(dataRow);
					}
					else
					{
						num = potencial;
					}
				}
				string text7 = "";
				string text8 = "";
				text7 = "";
				if (cbLayout.Checked)
				{
					text8 = "Ordem ASC, Tag1 ASC, TermNum1 ASC, Term1 ASC";
				}
				else
				{
					text8 = ((!cbAlternativo.Checked) ? "Tag1 ASC, TermNum1 ASC, Term1 ASC" : "Alternativo1 ASC, TermNum1 ASC, Term1 ASC");
				}
				DataRow[] array2 = dataTable.Select(text7, text8);
				string text9 = tbPrefixoPonto.Text;
				string text10 = tbSufixoPonto.Text;
				string text11 = tbPrefixoCruzado.Text;
				string text12 = tbSufixoCruzado.Text;
				string text13 = tbDelimitadorTT.Text;
				string text14 = tbDelimitadorD.Text;
				int upperBound = array2.GetUpperBound(0);
				for (int k = 0; k <= upperBound; k++)
				{
					array = (DeclaracoesFiacao.structureAnilhas[])Utils.CopyArray(array, new DeclaracoesFiacao.structureAnilhas[Information.UBound(array) + 1 + 1]);
					string text15 = Conversions.ToString(array2[k][0]);
					if (cbAlternativo.Checked)
					{
						text15 = Conversions.ToString(array2[k][1]);
					}
					array[Information.UBound(array)].Tag1 = text15;
					array[Information.UBound(array)].Terminal1 = Conversions.ToString(array2[k][2]);
					string text16 = Conversions.ToString(array2[k][2]);
					string text17 = Conversions.ToString(array2[k][4]);
					if (cbAlternativo.Checked)
					{
						text17 = Conversions.ToString(array2[k][5]);
					}
					array[Information.UBound(array)].Tag2 = text17;
					array[Information.UBound(array)].Terminal2 = Conversions.ToString(array2[k][6]);
					string text18 = Conversions.ToString(array2[k][6]);
					array[Information.UBound(array)].Secao = Conversions.ToString(array2[k][8]);
					array[Information.UBound(array)].Cor = Conversions.ToString(array2[k][9]);
					array[Information.UBound(array)].bTemLink = Conversions.ToBoolean(array2[k][10]);
					array[Information.UBound(array)].Orientacao1 = Conversions.ToString(array2[k][11]);
					array[Information.UBound(array)].Orientacao2 = Conversions.ToString(array2[k][12]);
					if (!rb8.Checked)
					{
						if (!rb0.Checked)
						{
							if (!rb1.Checked)
							{
								if (!rb2.Checked)
								{
									if (!rb3.Checked)
									{
										if (!rb4.Checked)
										{
											if (!rb5.Checked)
											{
												if (!rb6.Checked)
												{
													if (!rb7.Checked)
													{
														continue;
													}
													if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "N", TextCompare: true) != 0)
													{
														if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "S", TextCompare: true) == 0)
														{
															array[Information.UBound(array)].Anilha1 = text11 + text17 + text13 + text18 + text12 + text14 + text9 + text15 + text13 + text16 + text10;
														}
													}
													else
													{
														array[Information.UBound(array)].Anilha1 = text9 + text16 + text13 + text15 + text10 + text14 + text11 + text17 + text13 + text18 + text12;
													}
													if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "N", TextCompare: true) != 0)
													{
														if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "S", TextCompare: true) == 0)
														{
															array[Information.UBound(array)].Anilha2 = text11 + text15 + text13 + text16 + text12 + text14 + text9 + text17 + text13 + text18 + text10;
														}
													}
													else
													{
														array[Information.UBound(array)].Anilha2 = text9 + text18 + text13 + text17 + text10 + text14 + text11 + text15 + text13 + text16 + text12;
													}
													continue;
												}
												if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "N", TextCompare: true) != 0)
												{
													if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "S", TextCompare: true) == 0)
													{
														array[Information.UBound(array)].Anilha1 = text11 + text17 + text13 + text18 + text12 + text14 + text9 + text15 + text13 + text16 + text10;
													}
												}
												else
												{
													array[Information.UBound(array)].Anilha1 = text9 + text15 + text13 + text16 + text10 + text14 + text11 + text17 + text13 + text18 + text12;
												}
												if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "N", TextCompare: true) != 0)
												{
													if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "S", TextCompare: true) == 0)
													{
														array[Information.UBound(array)].Anilha2 = text11 + text15 + text13 + text16 + text12 + text14 + text9 + text17 + text13 + text18 + text10;
													}
												}
												else
												{
													array[Information.UBound(array)].Anilha2 = text9 + text17 + text13 + text18 + text10 + text14 + text11 + text15 + text13 + text16 + text12;
												}
												continue;
											}
											if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "N", TextCompare: true) != 0)
											{
												if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "S", TextCompare: true) == 0)
												{
													array[Information.UBound(array)].Anilha1 = text11 + text18 + text13 + text17 + text12 + text14 + text9 + text15 + text13 + text16 + text10;
												}
											}
											else
											{
												array[Information.UBound(array)].Anilha1 = text9 + text16 + text13 + text15 + text10 + text14 + text11 + text17 + text13 + text18 + text12;
											}
											if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "N", TextCompare: true) != 0)
											{
												if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "S", TextCompare: true) == 0)
												{
													array[Information.UBound(array)].Anilha2 = text11 + text16 + text13 + text15 + text12 + text14 + text9 + text17 + text13 + text18 + text10;
												}
											}
											else
											{
												array[Information.UBound(array)].Anilha2 = text9 + text18 + text13 + text17 + text10 + text14 + text11 + text15 + text13 + text16 + text12;
											}
											continue;
										}
										if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "N", TextCompare: true) != 0)
										{
											if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "S", TextCompare: true) == 0)
											{
												array[Information.UBound(array)].Anilha1 = text11 + text18 + text13 + text17 + text12 + text14 + text9 + text16 + text10;
											}
										}
										else
										{
											array[Information.UBound(array)].Anilha1 = text9 + text16 + text10 + text14 + text11 + text17 + text13 + text18 + text12;
										}
										if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "N", TextCompare: true) != 0)
										{
											if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "S", TextCompare: true) == 0)
											{
												array[Information.UBound(array)].Anilha2 = text11 + text16 + text13 + text15 + text12 + text14 + text9 + text18 + text10;
											}
										}
										else
										{
											array[Information.UBound(array)].Anilha2 = text9 + text18 + text10 + text14 + text11 + text15 + text13 + text16 + text12;
										}
										continue;
									}
									if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "N", TextCompare: true) != 0)
									{
										if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "S", TextCompare: true) == 0)
										{
											array[Information.UBound(array)].Anilha1 = text11 + text17 + text13 + text18 + text12 + text14 + text9 + text16 + text10;
										}
									}
									else
									{
										array[Information.UBound(array)].Anilha1 = text9 + text16 + text10 + text14 + text11 + text17 + text13 + text18 + text12;
									}
									if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "N", TextCompare: true) != 0)
									{
										if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "S", TextCompare: true) == 0)
										{
											array[Information.UBound(array)].Anilha2 = text11 + text15 + text13 + text16 + text12 + text14 + text9 + text18 + text10;
										}
									}
									else
									{
										array[Information.UBound(array)].Anilha2 = text9 + text18 + text10 + text14 + text11 + text15 + text13 + text16 + text12;
									}
								}
								else
								{
									array[Information.UBound(array)].Anilha1 = text11 + text17 + text13 + text18 + text12;
									array[Information.UBound(array)].Anilha2 = text11 + text15 + text13 + text16 + text12;
								}
							}
							else
							{
								array[Information.UBound(array)].Anilha1 = text9 + text15 + text13 + text16 + text10;
								array[Information.UBound(array)].Anilha2 = text9 + text17 + text13 + text18 + text10;
							}
							continue;
						}
						if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "N", TextCompare: true) != 0)
						{
							if (Operators.CompareString(array[Information.UBound(array)].Orientacao1, "S", TextCompare: true) == 0)
							{
								array[Information.UBound(array)].Anilha1 = text9 + text15 + text13 + text16 + text10;
							}
						}
						else
						{
							array[Information.UBound(array)].Anilha1 = text9 + text16 + text13 + text15 + text10;
						}
						if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "N", TextCompare: true) != 0)
						{
							if (Operators.CompareString(array[Information.UBound(array)].Orientacao2, "S", TextCompare: true) == 0)
							{
								array[Information.UBound(array)].Anilha2 = text9 + text17 + text13 + text18 + text10;
							}
						}
						else
						{
							array[Information.UBound(array)].Anilha2 = text9 + text18 + text13 + text17 + text10;
						}
					}
					else
					{
						array[Information.UBound(array)].Anilha1 = text9 + text16 + text10;
						array[Information.UBound(array)].Anilha2 = text9 + text18 + text10;
					}
				}
				string left = "";
				int num5 = Information.UBound(array);
				for (int l = 1; l <= num5; l++)
				{
					if (Operators.CompareString(left, array[l].Tag1, TextCompare: true) != 0)
					{
						left = array[l].Tag1;
						dgFiacao.Rows.Add(array[l].Tag1);
						dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
						int num6 = dgFiacao.ColumnCount - 1;
						for (int m = 1; m <= num6; m++)
						{
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[m].Style.BackColor = Color.LightGray;
						}
					}
					string text19 = array[l].Secao;
					if (Operators.CompareString(array[l].Cor, "", TextCompare: true) != 0)
					{
						text19 = text19 + tbDelimitadorTT.Text + array[l].Cor;
					}
					if (cbJumper.Checked & array[l].bTemLink)
					{
						dgFiacao.Rows.Add(array[l].Terminal1, array[l].Orientacao1, array[l].Tag2 + tbDelimitadorTT.Text + array[l].Terminal2, array[l].Orientacao2, "JUMPER", "", "");
						dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[4].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
						dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[4].Style.ForeColor = Color.DarkRed;
					}
					if (!array[l].bTemLink)
					{
						dgFiacao.Rows.Add(array[l].Terminal1, array[l].Orientacao1, array[l].Tag2 + tbDelimitadorTT.Text + array[l].Terminal2, array[l].Orientacao2, array[l].Anilha1, array[l].Anilha2, text19);
						if ((Operators.CompareString(array[l].Orientacao1, "", TextCompare: true) == 0) & !rb1.Checked & !rb2.Checked & !rb8.Checked)
						{
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[1].Style.BackColor = Color.Yellow;
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[4].Style.BackColor = Color.Yellow;
						}
						if ((Operators.CompareString(array[l].Orientacao2, "", TextCompare: true) == 0) & !rb1.Checked & !rb2.Checked & !rb8.Checked)
						{
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightYellow;
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[5].Style.BackColor = Color.Yellow;
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
			finally
			{
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	private string k8I6LTogtw(string P_0, string P_1)
	{
		string text = "";
		text = ((Operators.CompareString(P_0.Trim(), "", TextCompare: true) == 0) ? P_1 : (P_0 + ":" + P_1));
		return text.Trim();
	}

	public void formataDGDWG()
	{
		checked
		{
			try
			{
				dgDWG.Rows.Clear();
				dgDWG.Columns.Clear();
				dgDWG.Columns.Add("", "DWG");
				dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 786]));
				float num = dgDWG.Width - 22;
				dgDWG.Columns[0].Width = (int)Math.Round(num / 5f);
				dgDWG.Columns[1].Width = (int)Math.Round(num * 4f / 5f);
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

	public void CarregaDGDWG()
	{
		DeclaracoesGeral.arqLogico[] mDWG = new DeclaracoesGeral.arqLogico[1];
		cDadosAccess.carregaDadosTodosDWG(ref mDWG);
		checked
		{
			try
			{
				int num = Information.UBound(mDWG);
				for (int i = 1; i <= num; i++)
				{
					dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (DeclaracoesGeral.arqAtivo.Indice == mDWG[i].Indice)
					{
						dgDWG.Rows[dgDWG.Rows.Count - 1].Selected = true;
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
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num);
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
				H0htWPuMdj = true;
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
				H0htWPuMdj = false;
			}
		}
	}

	public void formataDGFiacao()
	{
		checked
		{
			try
			{
				dgFiacao.Rows.Clear();
				dgFiacao.Columns.Clear();
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1510]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1839]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1511]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1839]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1512]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1513]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1518]));
				int num = dgFiacao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgFiacao.Width - 20;
				if (!cbSecaoCor.Checked)
				{
					dgFiacao.Columns[0].Width = (int)Math.Round(3f * num2 / 14f);
					dgFiacao.Columns[1].Width = (int)Math.Round(num2 / 14f);
					dgFiacao.Columns[2].Width = (int)Math.Round(3f * num2 / 14f);
					dgFiacao.Columns[3].Width = (int)Math.Round(num2 / 14f);
					dgFiacao.Columns[4].Width = (int)Math.Round(3f * num2 / 14f);
					dgFiacao.Columns[5].Width = (int)Math.Round(3f * num2 / 14f);
					dgFiacao.Columns[6].Width = 0;
					dgFiacao.Columns[6].Visible = false;
				}
				else
				{
					dgFiacao.Columns[0].Width = (int)Math.Round(3f * num2 / 17f);
					dgFiacao.Columns[1].Width = (int)Math.Round(num2 / 17f);
					dgFiacao.Columns[2].Width = (int)Math.Round(3f * num2 / 17f);
					dgFiacao.Columns[3].Width = (int)Math.Round(num2 / 17f);
					dgFiacao.Columns[4].Width = (int)Math.Round(3f * num2 / 17f);
					dgFiacao.Columns[5].Width = (int)Math.Round(3f * num2 / 17f);
					dgFiacao.Columns[6].Width = (int)Math.Round(3f * num2 / 17f);
					dgFiacao.Columns[6].Visible = true;
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

	private void o5v6wdKsRw(object P_0, EventArgs P_1)
	{
		tbDelimitadorTT2.Text = tbDelimitadorTT.Text;
	}

	private void NSf6xvTWyV(object P_0, EventArgs P_1)
	{
		KGJ6bB82tC();
	}

	private void KGJ6bB82tC()
	{
		checked
		{
			if (dgFiacao.Columns.Count == 7)
			{
				float num = dgFiacao.Width - 20;
				if (!cbSecaoCor.Checked)
				{
					dgFiacao.Columns[0].Width = (int)Math.Round(3f * num / 14f);
					dgFiacao.Columns[1].Width = (int)Math.Round(num / 14f);
					dgFiacao.Columns[2].Width = (int)Math.Round(3f * num / 14f);
					dgFiacao.Columns[3].Width = (int)Math.Round(num / 14f);
					dgFiacao.Columns[4].Width = (int)Math.Round(3f * num / 14f);
					dgFiacao.Columns[5].Width = (int)Math.Round(3f * num / 14f);
					dgFiacao.Columns[6].Width = 0;
					dgFiacao.Columns[6].Visible = false;
				}
				else
				{
					dgFiacao.Columns[0].Width = (int)Math.Round(3f * num / 17f);
					dgFiacao.Columns[1].Width = (int)Math.Round(num / 17f);
					dgFiacao.Columns[2].Width = (int)Math.Round(3f * num / 17f);
					dgFiacao.Columns[3].Width = (int)Math.Round(num / 17f);
					dgFiacao.Columns[4].Width = (int)Math.Round(3f * num / 17f);
					dgFiacao.Columns[5].Width = (int)Math.Round(3f * num / 17f);
					dgFiacao.Columns[6].Width = (int)Math.Round(3f * num / 17f);
					dgFiacao.Columns[6].Visible = true;
				}
			}
		}
	}
}
