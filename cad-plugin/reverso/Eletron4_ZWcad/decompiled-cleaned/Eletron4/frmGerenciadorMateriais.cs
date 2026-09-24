using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmGerenciadorMateriais : Form
{
	private IContainer sPKppk6kIHD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBCodCliente")]
	private Label hIpppdDc2iZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog R19ppfdV3HH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBCodInterno")]
	private Label EKjppDJe3ut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDescCompleta")]
	private Label ijfppvaWsv3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip pdmpp6Ju3W9;

	[AccessedThroughProperty("TBCodCliente")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox HvXpptC6QUU;

	[AccessedThroughProperty("TBDescCompleta")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox VZeppjyUxjq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDescResumida")]
	private Label cImppLUhbUq;

	[AccessedThroughProperty("TBDescResumida")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox oVGppwcKpaP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTEditaMaterial")]
	private Button WhHppxnsqaG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAdicionaMaterial")]
	private Button V4oppbbLVlh;

	[CompilerGenerated]
	[AccessedThroughProperty("BTApagaMaterial")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button qrTppMKIuut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTExportaEX")]
	private Button DVoppOuliEA;

	[AccessedThroughProperty("BTImportaEX")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button AqeppIouWoY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxMateriais")]
	private GroupBox Gpppp7lNnsa;

	[AccessedThroughProperty("GroupBoxAdiciona")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox I6yppq5bc7f;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBFabricante")]
	private Label qF8ppaip6IM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBFabricante")]
	private TextBox pIupp8ji2Te;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBModelo")]
	private Label a2GppN6MshV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBModelo")]
	private TextBox bytppFpZxL0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGMateriais")]
	private DataGridView TsjppQVhiQJ;

	[AccessedThroughProperty("TBCodInterno")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox uFVppPKlevs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	[CompilerGenerated]
	private Button SVWppcqnFCK;

	private bool MduppKvixhe;

	private bool xXlppeqw8lg;

	private List<int> QH3pp205How;

	private bool fnKpp3WA1NG;

	internal virtual Label LBCodCliente
	{
		[CompilerGenerated]
		get
		{
			return hIpppdDc2iZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hIpppdDc2iZ = value;
		}
	}

	internal virtual Label LBCodInterno
	{
		[CompilerGenerated]
		get
		{
			return EKjppDJe3ut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EKjppDJe3ut = value;
		}
	}

	internal virtual Label LBDescCompleta
	{
		[CompilerGenerated]
		get
		{
			return ijfppvaWsv3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ijfppvaWsv3 = value;
		}
	}

	internal virtual TextBox TBCodCliente
	{
		[CompilerGenerated]
		get
		{
			return HvXpptC6QUU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HvXpptC6QUU = value;
		}
	}

	internal virtual TextBox TBDescCompleta
	{
		[CompilerGenerated]
		get
		{
			return VZeppjyUxjq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VZeppjyUxjq = value;
		}
	}

	internal virtual Label LBDescResumida
	{
		[CompilerGenerated]
		get
		{
			return cImppLUhbUq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cImppLUhbUq = value;
		}
	}

	internal virtual TextBox TBDescResumida
	{
		[CompilerGenerated]
		get
		{
			return oVGppwcKpaP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oVGppwcKpaP = value;
		}
	}

	internal virtual Button BTEditaMaterial
	{
		[CompilerGenerated]
		get
		{
			return WhHppxnsqaG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KcbpW9CNreY;
			Button button = WhHppxnsqaG;
			if (button != null)
			{
				button.Click -= value2;
			}
			WhHppxnsqaG = value;
			button = WhHppxnsqaG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAdicionaMaterial
	{
		[CompilerGenerated]
		get
		{
			return V4oppbbLVlh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OYXpWrD09De;
			Button button = V4oppbbLVlh;
			if (button != null)
			{
				button.Click -= value2;
			}
			V4oppbbLVlh = value;
			button = V4oppbbLVlh;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTApagaMaterial
	{
		[CompilerGenerated]
		get
		{
			return qrTppMKIuut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LNDpWzth4ys;
			Button button = qrTppMKIuut;
			if (button != null)
			{
				button.Click -= value2;
			}
			qrTppMKIuut = value;
			button = qrTppMKIuut;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTExportaEX
	{
		[CompilerGenerated]
		get
		{
			return DVoppOuliEA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wM7pppyLNsc;
			Button button = DVoppOuliEA;
			if (button != null)
			{
				button.Click -= value2;
			}
			DVoppOuliEA = value;
			button = DVoppOuliEA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTImportaEX
	{
		[CompilerGenerated]
		get
		{
			return AqeppIouWoY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = O7JppWsA7YJ;
			Button button = AqeppIouWoY;
			if (button != null)
			{
				button.Click -= value2;
			}
			AqeppIouWoY = value;
			button = AqeppIouWoY;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBoxMateriais
	{
		[CompilerGenerated]
		get
		{
			return Gpppp7lNnsa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Gpppp7lNnsa = value;
		}
	}

	internal virtual GroupBox GroupBoxAdiciona
	{
		[CompilerGenerated]
		get
		{
			return I6yppq5bc7f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			I6yppq5bc7f = value;
		}
	}

	internal virtual Label LBFabricante
	{
		[CompilerGenerated]
		get
		{
			return qF8ppaip6IM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qF8ppaip6IM = value;
		}
	}

	internal virtual TextBox TBFabricante
	{
		[CompilerGenerated]
		get
		{
			return pIupp8ji2Te;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pIupp8ji2Te = value;
		}
	}

	internal virtual Label LBModelo
	{
		[CompilerGenerated]
		get
		{
			return a2GppN6MshV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a2GppN6MshV = value;
		}
	}

	internal virtual TextBox TBModelo
	{
		[CompilerGenerated]
		get
		{
			return bytppFpZxL0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bytppFpZxL0 = value;
		}
	}

	internal virtual DataGridView DGMateriais
	{
		[CompilerGenerated]
		get
		{
			return TsjppQVhiQJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = TdSppTTAWll;
			MouseEventHandler value3 = AFTppJYrcGh;
			DataGridView dataGridView = TsjppQVhiQJ;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			TsjppQVhiQJ = value;
			dataGridView = TsjppQVhiQJ;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual TextBox TBCodInterno
	{
		[CompilerGenerated]
		get
		{
			return uFVppPKlevs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = VfvppHjN9gf;
			TextBox textBox = uFVppPKlevs;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			uFVppPKlevs = value;
			textBox = uFVppPKlevs;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return SVWppcqnFCK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QDqppoIrIDt;
			Button button = SVWppcqnFCK;
			if (button != null)
			{
				button.Click -= value2;
			}
			SVWppcqnFCK = value;
			button = SVWppcqnFCK;
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
			if (disposing && sPKppk6kIHD != null)
			{
				sPKppk6kIHD.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void jRIpWYgkTon()
	{
		sPKppk6kIHD = new Container();
		LBCodCliente = new Label();
		aHypBEW66iS(new FolderBrowserDialog());
		LBCodInterno = new Label();
		LBDescCompleta = new Label();
		FDqpBiUmZij(new ToolTip(sPKppk6kIHD));
		TBCodCliente = new TextBox();
		TBDescCompleta = new TextBox();
		LBDescResumida = new Label();
		TBDescResumida = new TextBox();
		BTEditaMaterial = new Button();
		BTAdicionaMaterial = new Button();
		BTApagaMaterial = new Button();
		BTExportaEX = new Button();
		BTImportaEX = new Button();
		GroupBoxMateriais = new GroupBox();
		DGMateriais = new DataGridView();
		GroupBoxAdiciona = new GroupBox();
		btSalvar = new Button();
		LBFabricante = new Label();
		TBFabricante = new TextBox();
		LBModelo = new Label();
		TBModelo = new TextBox();
		TBCodInterno = new TextBox();
		GroupBoxMateriais.SuspendLayout();
		((ISupportInitialize)DGMateriais).BeginInit();
		GroupBoxAdiciona.SuspendLayout();
		SuspendLayout();
		LBCodCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LBCodCliente.Location = new Point(191, 102);
		LBCodCliente.Name = "LBCodCliente";
		LBCodCliente.Size = new Size(175, 17);
		LBCodCliente.TabIndex = 146;
		LBCodCliente.Text = "LBCodCliente";
		LBCodCliente.TextAlign = ContentAlignment.BottomLeft;
		LBCodInterno.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LBCodInterno.Location = new Point(191, 59);
		LBCodInterno.Name = "LBCodInterno";
		LBCodInterno.Size = new Size(175, 17);
		LBCodInterno.TabIndex = 145;
		LBCodInterno.Text = "LBCodInterno";
		LBCodInterno.TextAlign = ContentAlignment.BottomLeft;
		LBDescCompleta.Location = new Point(6, 59);
		LBDescCompleta.Name = "LBDescCompleta";
		LBDescCompleta.Size = new Size(200, 17);
		LBDescCompleta.TabIndex = 144;
		LBDescCompleta.Text = "LBDescCompleta";
		LBDescCompleta.TextAlign = ContentAlignment.BottomLeft;
		TBCodCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBCodCliente.Location = new Point(191, 122);
		TBCodCliente.MaxLength = 250;
		TBCodCliente.Name = "TBCodCliente";
		TBCodCliente.Size = new Size(175, 20);
		TBCodCliente.TabIndex = 143;
		TBDescCompleta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TBDescCompleta.Font = new System.Drawing.Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDescCompleta.Location = new Point(6, 79);
		TBDescCompleta.Multiline = true;
		TBDescCompleta.Name = "TBDescCompleta";
		TBDescCompleta.Size = new Size(179, 328);
		TBDescCompleta.TabIndex = 140;
		LBDescResumida.Location = new Point(6, 16);
		LBDescResumida.Name = "LBDescResumida";
		LBDescResumida.Size = new Size(200, 17);
		LBDescResumida.TabIndex = 139;
		LBDescResumida.Text = "LBDescResumida";
		LBDescResumida.TextAlign = ContentAlignment.BottomLeft;
		TBDescResumida.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TBDescResumida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDescResumida.Location = new Point(6, 36);
		TBDescResumida.MaxLength = 250;
		TBDescResumida.Name = "TBDescResumida";
		TBDescResumida.Size = new Size(360, 20);
		TBDescResumida.TabIndex = 138;
		BTEditaMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTEditaMaterial.FlatStyle = FlatStyle.Flat;
		BTEditaMaterial.ForeColor = SystemColors.Control;
		BTEditaMaterial.Image = Resources.Editar;
		BTEditaMaterial.Location = new Point(258, 254);
		BTEditaMaterial.Name = "BTEditaMaterial";
		BTEditaMaterial.Size = new Size(40, 40);
		BTEditaMaterial.TabIndex = 137;
		BTEditaMaterial.UseVisualStyleBackColor = true;
		BTAdicionaMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTAdicionaMaterial.FlatStyle = FlatStyle.Flat;
		BTAdicionaMaterial.ForeColor = SystemColors.Control;
		BTAdicionaMaterial.Image = Resources.Adiciona_32;
		BTAdicionaMaterial.Location = new Point(212, 254);
		BTAdicionaMaterial.Name = "BTAdicionaMaterial";
		BTAdicionaMaterial.Size = new Size(40, 40);
		BTAdicionaMaterial.TabIndex = 136;
		BTAdicionaMaterial.UseVisualStyleBackColor = true;
		BTApagaMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTApagaMaterial.FlatStyle = FlatStyle.Flat;
		BTApagaMaterial.ForeColor = SystemColors.Control;
		BTApagaMaterial.Image = Resources.Delete_32;
		BTApagaMaterial.Location = new Point(304, 254);
		BTApagaMaterial.Name = "BTApagaMaterial";
		BTApagaMaterial.Size = new Size(40, 40);
		BTApagaMaterial.TabIndex = 135;
		BTApagaMaterial.Tag = "";
		BTApagaMaterial.UseVisualStyleBackColor = true;
		BTExportaEX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTExportaEX.FlatStyle = FlatStyle.Flat;
		BTExportaEX.ForeColor = SystemColors.Control;
		BTExportaEX.Image = Resources.ExportaExcel_20;
		BTExportaEX.Location = new Point(262, 309);
		BTExportaEX.Name = "BTExportaEX";
		BTExportaEX.Size = new Size(30, 42);
		BTExportaEX.TabIndex = 144;
		BTExportaEX.UseVisualStyleBackColor = true;
		BTImportaEX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTImportaEX.FlatStyle = FlatStyle.Flat;
		BTImportaEX.ForeColor = SystemColors.Control;
		BTImportaEX.Image = Resources.ImportaExcel_20;
		BTImportaEX.Location = new Point(310, 309);
		BTImportaEX.Name = "BTImportaEX";
		BTImportaEX.Size = new Size(30, 42);
		BTImportaEX.TabIndex = 143;
		BTImportaEX.UseVisualStyleBackColor = true;
		GroupBoxMateriais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBoxMateriais.Controls.Add(DGMateriais);
		GroupBoxMateriais.Location = new Point(6, 6);
		GroupBoxMateriais.Name = "GroupBoxMateriais";
		GroupBoxMateriais.Size = new Size(413, 413);
		GroupBoxMateriais.TabIndex = 143;
		GroupBoxMateriais.TabStop = false;
		GroupBoxMateriais.Text = "GroupBoxMateriais";
		DGMateriais.AllowUserToAddRows = false;
		DGMateriais.AllowUserToDeleteRows = false;
		DGMateriais.AllowUserToOrderColumns = true;
		DGMateriais.AllowUserToResizeRows = false;
		DGMateriais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGMateriais.BackgroundColor = SystemColors.ButtonHighlight;
		DGMateriais.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGMateriais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGMateriais.Location = new Point(6, 19);
		DGMateriais.MultiSelect = false;
		DGMateriais.Name = "DGMateriais";
		DGMateriais.ReadOnly = true;
		DGMateriais.RowHeadersVisible = false;
		DGMateriais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGMateriais.Size = new Size(401, 388);
		DGMateriais.TabIndex = 118;
		GroupBoxAdiciona.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBoxAdiciona.Controls.Add(btSalvar);
		GroupBoxAdiciona.Controls.Add(LBFabricante);
		GroupBoxAdiciona.Controls.Add(TBFabricante);
		GroupBoxAdiciona.Controls.Add(LBModelo);
		GroupBoxAdiciona.Controls.Add(TBModelo);
		GroupBoxAdiciona.Controls.Add(LBCodCliente);
		GroupBoxAdiciona.Controls.Add(LBCodInterno);
		GroupBoxAdiciona.Controls.Add(LBDescCompleta);
		GroupBoxAdiciona.Controls.Add(TBCodInterno);
		GroupBoxAdiciona.Controls.Add(TBCodCliente);
		GroupBoxAdiciona.Controls.Add(TBDescCompleta);
		GroupBoxAdiciona.Controls.Add(BTExportaEX);
		GroupBoxAdiciona.Controls.Add(LBDescResumida);
		GroupBoxAdiciona.Controls.Add(BTImportaEX);
		GroupBoxAdiciona.Controls.Add(TBDescResumida);
		GroupBoxAdiciona.Controls.Add(BTEditaMaterial);
		GroupBoxAdiciona.Controls.Add(BTAdicionaMaterial);
		GroupBoxAdiciona.Controls.Add(BTApagaMaterial);
		GroupBoxAdiciona.Location = new Point(425, 6);
		GroupBoxAdiciona.Name = "GroupBoxAdiciona";
		GroupBoxAdiciona.Size = new Size(372, 413);
		GroupBoxAdiciona.TabIndex = 144;
		GroupBoxAdiciona.TabStop = false;
		GroupBoxAdiciona.Text = "GroupBox";
		btSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(304, 364);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 179;
		btSalvar.UseVisualStyleBackColor = true;
		LBFabricante.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LBFabricante.Location = new Point(191, 188);
		LBFabricante.Name = "LBFabricante";
		LBFabricante.Size = new Size(175, 17);
		LBFabricante.TabIndex = 150;
		LBFabricante.Text = "LBFabricante";
		LBFabricante.TextAlign = ContentAlignment.BottomLeft;
		TBFabricante.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBFabricante.Location = new Point(191, 208);
		TBFabricante.MaxLength = 250;
		TBFabricante.Name = "TBFabricante";
		TBFabricante.Size = new Size(175, 20);
		TBFabricante.TabIndex = 149;
		LBModelo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LBModelo.Location = new Point(191, 145);
		LBModelo.Name = "LBModelo";
		LBModelo.Size = new Size(175, 17);
		LBModelo.TabIndex = 148;
		LBModelo.Text = "LBModelo";
		LBModelo.TextAlign = ContentAlignment.BottomLeft;
		TBModelo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBModelo.Location = new Point(191, 165);
		TBModelo.MaxLength = 250;
		TBModelo.Name = "TBModelo";
		TBModelo.Size = new Size(175, 20);
		TBModelo.TabIndex = 147;
		TBCodInterno.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBCodInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBCodInterno.Location = new Point(191, 79);
		TBCodInterno.MaxLength = 250;
		TBCodInterno.Name = "TBCodInterno";
		TBCodInterno.Size = new Size(175, 20);
		TBCodInterno.TabIndex = 143;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(804, 426);
		Controls.Add(GroupBoxMateriais);
		Controls.Add(GroupBoxAdiciona);
		MinimumSize = new Size(820, 465);
		Name = "frmGerenciadorMateriais";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "meGerenciador de Materiais";
		GroupBoxMateriais.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGMateriais).EndInit();
		GroupBoxAdiciona.ResumeLayout(performLayout: false);
		GroupBoxAdiciona.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return R19ppfdV3HH;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		R19ppfdV3HH = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return pdmpp6Ju3W9;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		pdmpp6Ju3W9 = WithEventsValue;
	}

	public frmGerenciadorMateriais()
	{
		Resize += gifpphd88VY;
		FormClosed += [SpecialName] [DebuggerHidden] (object a0, FormClosedEventArgs a1) =>
		{
			Finalize();
		};
		MduppKvixhe = false;
		xXlppeqw8lg = false;
		QH3pp205How = new List<int>();
		fnKpp3WA1NG = true;
		if (Geral.ExisteForm("frmGerenciadorMateriais") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			jRIpWYgkTon();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 585]);
			GroupBoxMateriais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]);
			GroupBoxAdiciona.Text = "";
			LBDescResumida.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
			LBDescCompleta.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 247]);
			LBCodInterno.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1162]);
			LBCodCliente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1163]);
			LBModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
			LBFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]);
			w8dpBZ0kvSD().SetToolTip(BTAdicionaMaterial, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1164]));
			w8dpBZ0kvSD().SetToolTip(BTEditaMaterial, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1165]));
			w8dpBZ0kvSD().SetToolTip(BTApagaMaterial, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1166]));
			w8dpBZ0kvSD().SetToolTip(BTImportaEX, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1167]));
			w8dpBZ0kvSD().SetToolTip(BTExportaEX, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1168]));
			w8dpBZ0kvSD().SetToolTip(TBDescCompleta, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1884]));
			Application.ShowModelessDialog((Form)this);
			TBDescCompleta.Multiline = true;
			TBDescCompleta.AcceptsTab = true;
			cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
			DataGridView dg = DGMateriais;
			formataDG(ref dg);
			DGMateriais = dg;
			cDadosAccessMateriais2.CarregaListaMateriaisDoDG(DGMateriais);
			cDadosAccessMateriais2.fechaConexao();
			dg = DGMateriais;
			AtualizaColunasDGMateriais(ref dg, 1);
			DGMateriais = dg;
			MduppKvixhe = true;
			MostraSelecionado();
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

	private void OYXpWrD09De(object P_0, EventArgs P_1)
	{
		int num = 0;
		if ((Operators.CompareString(TBCodInterno.Text, "", TextCompare: true) == 0) & (Operators.CompareString(TBCodCliente.Text, "", TextCompare: true) == 0) & (Operators.CompareString(TBModelo.Text, "", TextCompare: true) == 0) & (Operators.CompareString(TBFabricante.Text, "", TextCompare: true) == 0) & (Operators.CompareString(TBDescResumida.Text, "", TextCompare: true) == 0) & (Operators.CompareString(TBDescCompleta.Text, "", TextCompare: true) == 0))
		{
			return;
		}
		checked
		{
			if (Operators.CompareString(TBCodInterno.Text, "", TextCompare: true) != 0)
			{
				int num2 = DGMateriais.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.ConditionalCompareObjectEqual(DGMateriais.Rows[i].Cells[0].Value, TBCodInterno.Text, TextCompare: true))
					{
						DGMateriais.FirstDisplayedScrollingRowIndex = i;
						return;
					}
				}
			}
			DataGridView dg;
			if (Versioned.IsNumeric(TBCodInterno.Text))
			{
				num = Conversions.ToInteger(TBCodInterno.Text);
			}
			else if (DGMateriais.RowCount == 0)
			{
				num = 1;
				dg = DGMateriais;
				formataDG(ref dg);
				DGMateriais = dg;
			}
			else
			{
				num = 1;
				int num3 = DGMateriais.Rows.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					if (Operators.ConditionalCompareObjectLess(num, DGMateriais.Rows[j].Cells[0].Value, TextCompare: true))
					{
						num = Conversions.ToInteger(Operators.AddObject(DGMateriais.Rows[j].Cells[0].Value, 1));
					}
				}
				TBCodInterno.Text = Conversions.ToString(num);
			}
			DGMateriais.Rows.Add(num, TBCodCliente.Text, TBModelo.Text, TBFabricante.Text, TBDescResumida.Text, TBDescCompleta.Text, 0, "A", 0);
			Color lightGreen = Color.LightGreen;
			int num4 = 0;
			do
			{
				DGMateriais.Rows[DGMateriais.Rows.Count - 1].Cells[num4].Style.BackColor = lightGreen;
				num4++;
			}
			while (num4 <= 5);
			dg = DGMateriais;
			AtualizaColunasDGMateriais(ref dg, num);
			DGMateriais = dg;
			MostraSelecionado();
			btSalvar.Enabled = true;
			xXlppeqw8lg = true;
		}
	}

	private void KcbpW9CNreY(object P_0, EventArgs P_1)
	{
		Conversions.ToInteger(TBCodInterno.Text);
		checked
		{
			int num = DGMateriais.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGMateriais.Rows[i].Selected)
				{
					if (Operators.ConditionalCompareObjectNotEqual(DGMateriais.Rows[i].Cells[1].Value, TBCodCliente.Text, TextCompare: true))
					{
						DGMateriais.Rows[i].Cells[1].Value = TBCodCliente.Text;
						DGMateriais.Rows[i].Cells[7].Value = "E";
						Color yellow = Color.Yellow;
						DGMateriais.Rows[i].Cells[1].Style.BackColor = yellow;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGMateriais.Rows[i].Cells[2].Value, TBModelo.Text, TextCompare: true))
					{
						DGMateriais.Rows[i].Cells[2].Value = TBModelo.Text;
						DGMateriais.Rows[i].Cells[7].Value = "E";
						Color yellow = Color.Yellow;
						DGMateriais.Rows[i].Cells[2].Style.BackColor = yellow;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGMateriais.Rows[i].Cells[3].Value, TBFabricante.Text, TextCompare: true))
					{
						DGMateriais.Rows[i].Cells[3].Value = TBFabricante.Text;
						DGMateriais.Rows[i].Cells[7].Value = "E";
						Color yellow = Color.Yellow;
						DGMateriais.Rows[i].Cells[3].Style.BackColor = yellow;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGMateriais.Rows[i].Cells[4].Value, TBDescResumida.Text, TextCompare: true))
					{
						DGMateriais.Rows[i].Cells[4].Value = TBDescResumida.Text;
						DGMateriais.Rows[i].Cells[7].Value = "E";
						Color yellow = Color.Yellow;
						DGMateriais.Rows[i].Cells[4].Style.BackColor = yellow;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGMateriais.Rows[i].Cells[5].Value, TBDescCompleta.Text, TextCompare: true))
					{
						DGMateriais.Rows[i].Cells[5].Value = TBDescCompleta.Text;
						DGMateriais.Rows[i].Cells[7].Value = "E";
						Color yellow = Color.Yellow;
						DGMateriais.Rows[i].Cells[5].Style.BackColor = yellow;
					}
					break;
				}
			}
			btSalvar.Enabled = true;
			xXlppeqw8lg = true;
		}
	}

	private void LNDpWzth4ys(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = DGMateriais.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGMateriais.Rows[i].Selected)
				{
					QH3pp205How.Add(Conversions.ToInteger(DGMateriais.Rows[i].Cells[6].Value));
					DGMateriais.Rows.RemoveAt(i);
					break;
				}
			}
			btSalvar.Enabled = true;
			xXlppeqw8lg = true;
		}
	}

	private void O7JppWsA7YJ(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		oSheet.Cells.ClearComments();
		DataGridView dg = DGMateriais;
		excMateriais.ImportaMateriais(ref oSheet, ref dg);
		DGMateriais = dg;
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		checked
		{
			int num = DGMateriais.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(DGMateriais.Rows[i].Cells[7].Value, "", TextCompare: true))
				{
					btSalvar.Enabled = true;
					break;
				}
			}
			cDadosAccessMateriais2.fechaConexao();
			xXlppeqw8lg = true;
		}
	}

	private void wM7pppyLNsc(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		DataGridView dg = DGMateriais;
		excMateriais.ExportaMateriais(ref oSheet, ref dg);
		DGMateriais = dg;
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		xXlppeqw8lg = false;
	}

	public void formataDG(ref DataGridView dg)
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("CodigoInterno", "#");
		dg.Columns.Add("CodigoCliente", "CodigoCliente");
		dg.Columns.Add("Modelo", "Modelo");
		dg.Columns.Add("Fabricante", "Fabricante");
		dg.Columns.Add("DescricaoResumida", "DescricaoResumida");
		dg.Columns.Add("DescricaoCompleta", "DescricaoCompleta");
		dg.Columns.Add("IndiceOriginal", "IndiceOriginal");
		dg.Columns.Add("Ação", "Ação");
		dg.Columns.Add("IndiceEL", "IndiceEL");
		dg.ColumnHeadersVisible = true;
	}

	public static void AtualizaColunasDGMateriais(ref DataGridView dg, int Index)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		dg.ColumnHeadersVisible = true;
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			dg.Columns[0].Width = (int)Math.Round(num * 0.1);
			dg.Columns[1].Width = (int)Math.Round(num * 0.2);
			dg.Columns[2].Width = (int)Math.Round(num * 0.35);
			dg.Columns[3].Width = (int)Math.Round(num * 0.35);
			dg.Columns[4].Width = 0;
			dg.Columns[5].Width = 0;
			dg.Columns[6].Width = 0;
			dg.Columns[7].Width = 0;
			dg.Columns[8].Width = 0;
			dg.Columns[0].Visible = true;
			dg.Columns[1].Visible = true;
			dg.Columns[2].Visible = true;
			dg.Columns[3].Visible = true;
			dg.Columns[4].Visible = false;
			dg.Columns[5].Visible = false;
			dg.Columns[6].Visible = false;
			dg.Columns[7].Visible = false;
			dg.Columns[8].Visible = false;
			dg.Columns[0].ReadOnly = false;
			dg.Columns[1].ReadOnly = false;
			dg.Columns[2].ReadOnly = false;
			dg.Columns[3].ReadOnly = false;
			dg.Columns[4].ReadOnly = false;
			dg.Columns[5].ReadOnly = false;
			dg.Columns[6].ReadOnly = false;
			dg.Columns[8].ReadOnly = false;
			dg.MultiSelect = false;
			if (Index == -1)
			{
				return;
			}
			int num2 = dg.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (Index == Conversions.ToInteger(dg.Rows[num3].Cells[0].Value))
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			dg.FirstDisplayedScrollingRowIndex = num3;
			dg.Rows[num3].Selected = true;
		}
	}

	private void TdSppTTAWll(object P_0, KeyEventArgs P_1)
	{
		MostraSelecionado();
	}

	private void AFTppJYrcGh(object P_0, MouseEventArgs P_1)
	{
		MostraSelecionado();
	}

	public void MostraSelecionado()
	{
		if (DGMateriais.SelectedRows.Count > 0 && MduppKvixhe)
		{
			TBCodInterno.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[0].Value);
			TBCodCliente.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[1].Value);
			TBModelo.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[2].Value);
			TBFabricante.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[3].Value);
			TBDescResumida.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[4].Value);
			TBDescCompleta.Text = Conversions.ToString(DGMateriais.SelectedRows[0].Cells[5].Value);
			BTEditaMaterial.Enabled = true;
			BTApagaMaterial.Enabled = true;
		}
		TBCodInterno.BackColor = Color.White;
		TBCodInterno.ForeColor = Color.Black;
	}

	private void gifpphd88VY(object P_0, EventArgs P_1)
	{
		if (MduppKvixhe)
		{
			DataGridView dg = DGMateriais;
			AtualizaColunasDGMateriais(ref dg, -1);
			DGMateriais = dg;
		}
	}

	private void QDqppoIrIDt(object P_0, EventArgs P_1)
	{
		iaGppGHMjAT();
		xXlppeqw8lg = false;
	}

	private void iaGppGHMjAT()
	{
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		checked
		{
			int num = QH3pp205How.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				cDadosAccessMateriais2.RemoveMaterial(QH3pp205How[i]);
			}
			int num2 = DGMateriais.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (Operators.ConditionalCompareObjectEqual(DGMateriais.Rows[j].Cells[7].Value, "A", TextCompare: true))
				{
					cDadosAccessMateriais2.RemoveMaterial(Conversions.ToInteger(DGMateriais.Rows[j].Cells[0].Value));
					cDadosAccessMateriais2.AdicionaItemMaterial(Conversions.ToInteger(DGMateriais.Rows[j].Cells[0].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[1].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[2].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[3].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[4].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[5].Value));
				}
				if (Operators.ConditionalCompareObjectEqual(DGMateriais.Rows[j].Cells[7].Value, "E", TextCompare: true))
				{
					cDadosAccessMateriais2.EditaItemMaterial(Conversions.ToInteger(DGMateriais.Rows[j].Cells[0].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[1].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[2].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[3].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[4].Value), Conversions.ToString(DGMateriais.Rows[j].Cells[5].Value));
				}
			}
			DataGridView dg = DGMateriais;
			formataDG(ref dg);
			DGMateriais = dg;
			cDadosAccessMateriais2.CarregaListaMateriaisDoDG(DGMateriais);
			cDadosAccessMateriais2.fechaConexao();
			dg = DGMateriais;
			AtualizaColunasDGMateriais(ref dg, 1);
			DGMateriais = dg;
			TBCodInterno.Text = "";
			TBCodCliente.Text = "";
			TBDescCompleta.Text = "";
			TBDescResumida.Text = "";
			TBFabricante.Text = "";
			TBModelo.Text = "";
			btSalvar.Enabled = false;
		}
	}

	private void VfvppHjN9gf(object P_0, KeyEventArgs P_1)
	{
		BTEditaMaterial.Enabled = false;
		BTApagaMaterial.Enabled = false;
		BTAdicionaMaterial.Enabled = true;
		fnKpp3WA1NG = true;
		TBCodInterno.BackColor = Color.White;
		TBCodInterno.ForeColor = Color.Black;
		checked
		{
			if (Versioned.IsNumeric(TBCodInterno.Text))
			{
				int num = DGMateriais.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Conversions.ToInteger(DGMateriais.Rows[i].Cells[0].Value) == Conversions.ToInteger(TBCodInterno.Text))
					{
						TBCodInterno.BackColor = Color.Red;
						TBCodInterno.ForeColor = Color.White;
						BTAdicionaMaterial.Enabled = false;
						fnKpp3WA1NG = false;
					}
				}
			}
			else if (Operators.CompareString(TBCodInterno.Text.Trim(), "", TextCompare: true) != 0)
			{
				TBCodInterno.BackColor = Color.Red;
				TBCodInterno.ForeColor = Color.White;
			}
			else
			{
				TBCodInterno.Text = "";
			}
		}
	}

	~frmGerenciadorMateriais()
	{
		if (xXlppeqw8lg)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1089], "?"), MsgBoxStyle.YesNo, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				iaGppGHMjAT();
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}
}
