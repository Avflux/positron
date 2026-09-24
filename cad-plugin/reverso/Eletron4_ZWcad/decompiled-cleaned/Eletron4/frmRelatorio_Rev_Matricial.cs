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
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Rev_Matricial : Form
{
	private IContainer CHbQ7PbYtp;

	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private FolderBrowserDialog t9IQqLKGk0;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip HDkQat0Bir;

	[AccessedThroughProperty("btExporta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button rFTQ8BCKeb;

	[AccessedThroughProperty("btApagar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button eMJQNEgZqP;

	[CompilerGenerated]
	[AccessedThroughProperty("tbTitulo1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox nxDQFGkbbC;

	[AccessedThroughProperty("GroupBox4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox RHtQQibgTC;

	[AccessedThroughProperty("R15")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox T7KQP0sjDb;

	[AccessedThroughProperty("R14")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox QPgQcJqJum;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("R13")]
	private TextBox gD1QKC8crD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R12")]
	private TextBox rqBQe7HbrZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R11")]
	private TextBox FdMQ2ONgEW;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("R10")]
	private TextBox CYhQ364CFN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R9")]
	private TextBox zJnQnNRdZk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R8")]
	private TextBox iA2Q1yECd6;

	[AccessedThroughProperty("R7")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox HfVQlxGqcO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("R6")]
	private TextBox dlqQ5a4lrw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R5")]
	private TextBox L7DQ0t4aiF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R4")]
	private TextBox jQIQRiG50J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("R3")]
	private TextBox c76QmnC8w2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R2")]
	private TextBox miFQXXXZ9n;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R1")]
	private TextBox OAdQUH4Pab;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R0")]
	private TextBox WYDQy8kmJL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbTitulo2")]
	private TextBox L8gQgMaVHG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("R16")]
	[CompilerGenerated]
	private TextBox tM2QArLGNi;

	[AccessedThroughProperty("cbPreservar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox p2aQsEm8l5;

	[AccessedThroughProperty("BTY")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button qG1QB93O3y;

	[AccessedThroughProperty("tbOrdenadaY")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox Nm6QVPEPVT;

	[AccessedThroughProperty("lPTIni")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label fpgQu4FTa4;

	private Relatorios_Rev_Matricial.ConfigReV kbbQE4bchw;

	private double TG2QZtnH2j;

	private Relatorios_Rev_Matricial.RevisaoMatricial[] XGNQiaO9Ri;

	private Relatorios_Rev_Matricial.RevisaoMatricial[] PnbQScqMC8;

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return rFTQ8BCKeb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = twIQJbKKy1;
			Button button = rFTQ8BCKeb;
			if (button != null)
			{
				button.Click -= value2;
			}
			rFTQ8BCKeb = value;
			button = rFTQ8BCKeb;
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
			return eMJQNEgZqP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = i6yQhye9BV;
			Button button = eMJQNEgZqP;
			if (button != null)
			{
				button.Click -= value2;
			}
			eMJQNEgZqP = value;
			button = eMJQNEgZqP;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbTitulo1
	{
		[CompilerGenerated]
		get
		{
			return nxDQFGkbbC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nxDQFGkbbC = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return RHtQQibgTC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RHtQQibgTC = value;
		}
	}

	internal virtual TextBox R15
	{
		[CompilerGenerated]
		get
		{
			return T7KQP0sjDb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = G25QOO0tgV;
			TextBox textBox = T7KQP0sjDb;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			T7KQP0sjDb = value;
			textBox = T7KQP0sjDb;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R14
	{
		[CompilerGenerated]
		get
		{
			return QPgQcJqJum;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = W6bQMvdack;
			TextBox textBox = QPgQcJqJum;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			QPgQcJqJum = value;
			textBox = QPgQcJqJum;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R13
	{
		[CompilerGenerated]
		get
		{
			return gD1QKC8crD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = YqwQbArvJg;
			TextBox textBox = gD1QKC8crD;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			gD1QKC8crD = value;
			textBox = gD1QKC8crD;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R12
	{
		[CompilerGenerated]
		get
		{
			return rqBQe7HbrZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = IfWQxBjyYv;
			TextBox textBox = rqBQe7HbrZ;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			rqBQe7HbrZ = value;
			textBox = rqBQe7HbrZ;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R11
	{
		[CompilerGenerated]
		get
		{
			return FdMQ2ONgEW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = XmmQw12nuT;
			TextBox textBox = FdMQ2ONgEW;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			FdMQ2ONgEW = value;
			textBox = FdMQ2ONgEW;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R10
	{
		[CompilerGenerated]
		get
		{
			return CYhQ364CFN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = SNSQL59hJ1;
			TextBox textBox = CYhQ364CFN;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			CYhQ364CFN = value;
			textBox = CYhQ364CFN;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R9
	{
		[CompilerGenerated]
		get
		{
			return zJnQnNRdZk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = Vp5QjuUJ37;
			TextBox textBox = zJnQnNRdZk;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			zJnQnNRdZk = value;
			textBox = zJnQnNRdZk;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R8
	{
		[CompilerGenerated]
		get
		{
			return iA2Q1yECd6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = sNGQtnvvJO;
			TextBox textBox = iA2Q1yECd6;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			iA2Q1yECd6 = value;
			textBox = iA2Q1yECd6;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R7
	{
		[CompilerGenerated]
		get
		{
			return HfVQlxGqcO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = uyGQ6THKCG;
			TextBox textBox = HfVQlxGqcO;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			HfVQlxGqcO = value;
			textBox = HfVQlxGqcO;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R6
	{
		[CompilerGenerated]
		get
		{
			return dlqQ5a4lrw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = JtjQvhwdcS;
			TextBox textBox = dlqQ5a4lrw;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			dlqQ5a4lrw = value;
			textBox = dlqQ5a4lrw;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R5
	{
		[CompilerGenerated]
		get
		{
			return L7DQ0t4aiF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = OCaQDfIYon;
			TextBox textBox = L7DQ0t4aiF;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			L7DQ0t4aiF = value;
			textBox = L7DQ0t4aiF;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R4
	{
		[CompilerGenerated]
		get
		{
			return jQIQRiG50J;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = I6KQfPh60c;
			TextBox textBox = jQIQRiG50J;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			jQIQRiG50J = value;
			textBox = jQIQRiG50J;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R3
	{
		[CompilerGenerated]
		get
		{
			return c76QmnC8w2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = CBhQdA2Ht2;
			TextBox textBox = c76QmnC8w2;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			c76QmnC8w2 = value;
			textBox = c76QmnC8w2;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R2
	{
		[CompilerGenerated]
		get
		{
			return miFQXXXZ9n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = x0uQkw75YF;
			TextBox textBox = miFQXXXZ9n;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			miFQXXXZ9n = value;
			textBox = miFQXXXZ9n;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R1
	{
		[CompilerGenerated]
		get
		{
			return OAdQUH4Pab;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = xi9QHBoLAj;
			TextBox textBox = OAdQUH4Pab;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			OAdQUH4Pab = value;
			textBox = OAdQUH4Pab;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox R0
	{
		[CompilerGenerated]
		get
		{
			return WYDQy8kmJL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = FJFQGYEqCT;
			TextBox textBox = WYDQy8kmJL;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			WYDQy8kmJL = value;
			textBox = WYDQy8kmJL;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbTitulo2
	{
		[CompilerGenerated]
		get
		{
			return L8gQgMaVHG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			L8gQgMaVHG = value;
		}
	}

	internal virtual TextBox R16
	{
		[CompilerGenerated]
		get
		{
			return tM2QArLGNi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = oWWQIwf7Lm;
			TextBox textBox = tM2QArLGNi;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			tM2QArLGNi = value;
			textBox = tM2QArLGNi;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual CheckBox cbPreservar
	{
		[CompilerGenerated]
		get
		{
			return p2aQsEm8l5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			p2aQsEm8l5 = value;
		}
	}

	internal virtual Button BTY
	{
		[CompilerGenerated]
		get
		{
			return qG1QB93O3y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eajQoWPh9b;
			Button button = qG1QB93O3y;
			if (button != null)
			{
				button.Click -= value2;
			}
			qG1QB93O3y = value;
			button = qG1QB93O3y;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbOrdenadaY
	{
		[CompilerGenerated]
		get
		{
			return Nm6QVPEPVT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Nm6QVPEPVT = value;
		}
	}

	internal virtual Label lPTIni
	{
		[CompilerGenerated]
		get
		{
			return fpgQu4FTa4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fpgQu4FTa4 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && CHbQ7PbYtp != null)
			{
				CHbQ7PbYtp.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AQgQp6iW1B()
	{
		CHbQ7PbYtp = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Rev_Matricial));
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(CHbQ7PbYtp));
		btExporta = new Button();
		btApagar = new Button();
		tbTitulo1 = new TextBox();
		GroupBox4 = new GroupBox();
		R16 = new TextBox();
		BTY = new Button();
		cbPreservar = new CheckBox();
		R15 = new TextBox();
		R14 = new TextBox();
		R13 = new TextBox();
		tbOrdenadaY = new TextBox();
		lPTIni = new Label();
		R12 = new TextBox();
		R11 = new TextBox();
		R10 = new TextBox();
		R9 = new TextBox();
		R8 = new TextBox();
		R7 = new TextBox();
		R6 = new TextBox();
		R5 = new TextBox();
		R4 = new TextBox();
		R3 = new TextBox();
		R2 = new TextBox();
		R1 = new TextBox();
		R0 = new TextBox();
		tbTitulo2 = new TextBox();
		GroupBox4.SuspendLayout();
		SuspendLayout();
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(599, 46);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 118;
		btExporta.UseVisualStyleBackColor = true;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(553, 46);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 179;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		tbTitulo1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbTitulo1.Location = new Point(6, 15);
		tbTitulo1.Name = "tbTitulo1";
		tbTitulo1.Size = new Size(101, 22);
		tbTitulo1.TabIndex = 184;
		tbTitulo1.Text = "REV. DOC.";
		tbTitulo1.TextAlign = HorizontalAlignment.Center;
		GroupBox4.Controls.Add(btExporta);
		GroupBox4.Controls.Add(btApagar);
		GroupBox4.Controls.Add(R16);
		GroupBox4.Controls.Add(BTY);
		GroupBox4.Controls.Add(cbPreservar);
		GroupBox4.Controls.Add(R15);
		GroupBox4.Controls.Add(R14);
		GroupBox4.Controls.Add(R13);
		GroupBox4.Controls.Add(tbOrdenadaY);
		GroupBox4.Controls.Add(lPTIni);
		GroupBox4.Controls.Add(R12);
		GroupBox4.Controls.Add(R11);
		GroupBox4.Controls.Add(R10);
		GroupBox4.Controls.Add(R9);
		GroupBox4.Controls.Add(R8);
		GroupBox4.Controls.Add(R7);
		GroupBox4.Controls.Add(R6);
		GroupBox4.Controls.Add(R5);
		GroupBox4.Controls.Add(R4);
		GroupBox4.Controls.Add(R3);
		GroupBox4.Controls.Add(R2);
		GroupBox4.Controls.Add(R1);
		GroupBox4.Controls.Add(R0);
		GroupBox4.Controls.Add(tbTitulo2);
		GroupBox4.Controls.Add(tbTitulo1);
		GroupBox4.Location = new Point(6, 2);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(650, 101);
		GroupBox4.TabIndex = 185;
		GroupBox4.TabStop = false;
		R16.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R16.Location = new Point(609, 15);
		R16.Name = "R16";
		R16.Size = new Size(30, 22);
		R16.TabIndex = 203;
		R16.TextAlign = HorizontalAlignment.Center;
		BTY.FlatStyle = FlatStyle.Flat;
		BTY.ForeColor = SystemColors.Control;
		BTY.Image = Resources.Altura;
		BTY.Location = new Point(482, 48);
		BTY.Name = "BTY";
		BTY.Size = new Size(40, 40);
		BTY.TabIndex = 207;
		BTY.UseVisualStyleBackColor = true;
		cbPreservar.AutoSize = true;
		cbPreservar.Location = new Point(29, 71);
		cbPreservar.Name = "cbPreservar";
		cbPreservar.Size = new Size(89, 17);
		cbPreservar.TabIndex = 204;
		cbPreservar.Text = "_cbPreservar";
		cbPreservar.UseVisualStyleBackColor = true;
		R15.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R15.Location = new Point(578, 15);
		R15.Name = "R15";
		R15.Size = new Size(30, 22);
		R15.TabIndex = 202;
		R15.TextAlign = HorizontalAlignment.Center;
		R14.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R14.Location = new Point(547, 15);
		R14.Name = "R14";
		R14.Size = new Size(30, 22);
		R14.TabIndex = 201;
		R14.TextAlign = HorizontalAlignment.Center;
		R13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R13.Location = new Point(516, 15);
		R13.Name = "R13";
		R13.Size = new Size(30, 22);
		R13.TabIndex = 200;
		R13.TextAlign = HorizontalAlignment.Center;
		tbOrdenadaY.BackColor = SystemColors.ActiveBorder;
		tbOrdenadaY.Location = new Point(418, 69);
		tbOrdenadaY.Name = "tbOrdenadaY";
		tbOrdenadaY.ReadOnly = true;
		tbOrdenadaY.Size = new Size(61, 20);
		tbOrdenadaY.TabIndex = 206;
		lPTIni.AutoSize = true;
		lPTIni.ImageAlign = ContentAlignment.MiddleRight;
		lPTIni.Location = new Point(280, 71);
		lPTIni.Name = "lPTIni";
		lPTIni.Size = new Size(124, 13);
		lPTIni.TabIndex = 205;
		lPTIni.Text = "Ponto inicial do Relatório";
		lPTIni.TextAlign = ContentAlignment.MiddleRight;
		R12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R12.Location = new Point(485, 15);
		R12.Name = "R12";
		R12.Size = new Size(30, 22);
		R12.TabIndex = 199;
		R12.TextAlign = HorizontalAlignment.Center;
		R11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R11.Location = new Point(454, 15);
		R11.Name = "R11";
		R11.Size = new Size(30, 22);
		R11.TabIndex = 198;
		R11.TextAlign = HorizontalAlignment.Center;
		R10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R10.Location = new Point(423, 15);
		R10.Name = "R10";
		R10.Size = new Size(30, 22);
		R10.TabIndex = 197;
		R10.TextAlign = HorizontalAlignment.Center;
		R9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R9.Location = new Point(392, 15);
		R9.Name = "R9";
		R9.Size = new Size(30, 22);
		R9.TabIndex = 196;
		R9.TextAlign = HorizontalAlignment.Center;
		R8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R8.Location = new Point(361, 15);
		R8.Name = "R8";
		R8.Size = new Size(30, 22);
		R8.TabIndex = 195;
		R8.TextAlign = HorizontalAlignment.Center;
		R7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R7.Location = new Point(330, 15);
		R7.Name = "R7";
		R7.Size = new Size(30, 22);
		R7.TabIndex = 194;
		R7.TextAlign = HorizontalAlignment.Center;
		R6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R6.Location = new Point(299, 15);
		R6.Name = "R6";
		R6.Size = new Size(30, 22);
		R6.TabIndex = 193;
		R6.TextAlign = HorizontalAlignment.Center;
		R5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R5.Location = new Point(268, 15);
		R5.Name = "R5";
		R5.Size = new Size(30, 22);
		R5.TabIndex = 192;
		R5.TextAlign = HorizontalAlignment.Center;
		R4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R4.Location = new Point(237, 15);
		R4.Name = "R4";
		R4.Size = new Size(30, 22);
		R4.TabIndex = 191;
		R4.TextAlign = HorizontalAlignment.Center;
		R3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R3.Location = new Point(206, 15);
		R3.Name = "R3";
		R3.Size = new Size(30, 22);
		R3.TabIndex = 190;
		R3.TextAlign = HorizontalAlignment.Center;
		R2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R2.Location = new Point(175, 15);
		R2.Name = "R2";
		R2.Size = new Size(30, 22);
		R2.TabIndex = 189;
		R2.TextAlign = HorizontalAlignment.Center;
		R1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R1.Location = new Point(144, 15);
		R1.Name = "R1";
		R1.Size = new Size(30, 22);
		R1.TabIndex = 188;
		R1.TextAlign = HorizontalAlignment.Center;
		R0.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		R0.Location = new Point(113, 15);
		R0.Name = "R0";
		R0.Size = new Size(30, 22);
		R0.TabIndex = 187;
		R0.TextAlign = HorizontalAlignment.Center;
		tbTitulo2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbTitulo2.Location = new Point(6, 43);
		tbTitulo2.Name = "tbTitulo2";
		tbTitulo2.Size = new Size(101, 22);
		tbTitulo2.TabIndex = 186;
		tbTitulo2.Text = "FOLHA Nº";
		tbTitulo2.TextAlign = HorizontalAlignment.Center;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(664, 106);
		Controls.Add(GroupBox4);
		ImeMode = ImeMode.On;
		MaximumSize = new Size(680, 145);
		MinimumSize = new Size(680, 145);
		Name = "frmRelatorio_Rev_Matricial";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Estatistica";
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return t9IQqLKGk0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		t9IQqLKGk0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return HDkQat0Bir;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		HDkQat0Bir = WithEventsValue;
	}

	public frmRelatorio_Rev_Matricial()
	{
		if (Geral.ExisteForm("frmRelatorio_Rev_Matricial"))
		{
			return;
		}
		AQgQp6iW1B();
		DeclaracoesGeral.Reguas RH = default;
		if (XDataGeral.LeXDataReguaH(ref RH))
		{
			XGNQiaO9Ri = new Relatorios_Rev_Matricial.RevisaoMatricial[1];
			PnbQScqMC8 = new Relatorios_Rev_Matricial.RevisaoMatricial[1];
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1912]);
			cbPreservar.Checked = true;
			cbPreservar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1907]);
			lPTIni.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1908]);
			Relatorios_Rev_Matricial.BuscaRevisoesAntigasDWG(ref PnbQScqMC8);
			Application.ShowModelessDialog((Form)this);
			kbbQE4bchw.dOrdenadaY = Relatorios_Rev_Matricial.BuscaPosicaoInicialRelatorio();
			tbOrdenadaY.Text = Conversions.ToString(kbbQE4bchw.dOrdenadaY);
			TG2QZtnH2j = -1.0;
			List<string> lRevisoes = new List<string>();
			if (!Relatorios_Rev_Matricial.BuscaRevisaoMatricial(ref lRevisoes))
			{
				lRevisoes.Clear();
				WYyQT7YZ4D(ref lRevisoes);
				lRevisoes.Sort();
				if (lRevisoes.Count >= 1)
				{
					if (lRevisoes.Count > 0)
					{
						R0.Text = lRevisoes[0].Trim();
					}
					if (lRevisoes.Count > 1)
					{
						R1.Text = lRevisoes[1].Trim();
					}
					if (lRevisoes.Count > 2)
					{
						R2.Text = lRevisoes[2].Trim();
					}
					if (lRevisoes.Count > 3)
					{
						R3.Text = lRevisoes[3].Trim();
					}
					if (lRevisoes.Count > 4)
					{
						R4.Text = lRevisoes[4].Trim();
					}
					if (lRevisoes.Count > 5)
					{
						R5.Text = lRevisoes[5].Trim();
					}
					if (lRevisoes.Count > 6)
					{
						R6.Text = lRevisoes[6].Trim();
					}
					if (lRevisoes.Count > 7)
					{
						R7.Text = lRevisoes[7].Trim();
					}
					if (lRevisoes.Count > 8)
					{
						R8.Text = lRevisoes[8].Trim();
					}
					if (lRevisoes.Count > 9)
					{
						R9.Text = lRevisoes[9].Trim();
					}
					if (lRevisoes.Count > 10)
					{
						R10.Text = lRevisoes[10].Trim();
					}
					if (lRevisoes.Count > 11)
					{
						R11.Text = lRevisoes[11].Trim();
					}
					if (lRevisoes.Count > 12)
					{
						R12.Text = lRevisoes[12].Trim();
					}
					if (lRevisoes.Count > 13)
					{
						R13.Text = lRevisoes[13].Trim();
					}
					if (lRevisoes.Count > 14)
					{
						R14.Text = lRevisoes[14].Trim();
					}
					if (lRevisoes.Count > 15)
					{
						R15.Text = lRevisoes[15].Trim();
					}
					if (lRevisoes.Count > 16)
					{
						R16.Text = lRevisoes[16].Trim();
					}
				}
			}
			else if (lRevisoes.Count >= 1)
			{
				if (lRevisoes.Count > 0)
				{
					R0.Text = lRevisoes[0].Trim();
				}
				if (lRevisoes.Count > 1)
				{
					R1.Text = lRevisoes[1].Trim();
				}
				if (lRevisoes.Count > 2)
				{
					R2.Text = lRevisoes[2].Trim();
				}
				if (lRevisoes.Count > 3)
				{
					R3.Text = lRevisoes[3].Trim();
				}
				if (lRevisoes.Count > 4)
				{
					R4.Text = lRevisoes[4].Trim();
				}
				if (lRevisoes.Count > 5)
				{
					R5.Text = lRevisoes[5].Trim();
				}
				if (lRevisoes.Count > 6)
				{
					R6.Text = lRevisoes[6].Trim();
				}
				if (lRevisoes.Count > 7)
				{
					R7.Text = lRevisoes[7].Trim();
				}
				if (lRevisoes.Count > 8)
				{
					R8.Text = lRevisoes[8].Trim();
				}
				if (lRevisoes.Count > 9)
				{
					R9.Text = lRevisoes[9].Trim();
				}
				if (lRevisoes.Count > 10)
				{
					R10.Text = lRevisoes[10].Trim();
				}
				if (lRevisoes.Count > 11)
				{
					R11.Text = lRevisoes[11].Trim();
				}
				if (lRevisoes.Count > 12)
				{
					R12.Text = lRevisoes[12].Trim();
				}
				if (lRevisoes.Count > 13)
				{
					R13.Text = lRevisoes[13].Trim();
				}
				if (lRevisoes.Count > 14)
				{
					R14.Text = lRevisoes[14].Trim();
				}
				if (lRevisoes.Count > 15)
				{
					R15.Text = lRevisoes[15].Trim();
				}
				if (lRevisoes.Count > 16)
				{
					R16.Text = lRevisoes[16].Trim();
				}
			}
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
		}
	}

	private void WYyQT7YZ4D(ref List<string> P_0)
	{
		try
		{
			Revisao.capturaRevisoesSimplificadas();
			int num = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.ConditionalCompareObjectNotEqual(DeclaracoesGeral.mRevSimplificada[1, i], "", TextCompare: true) && !P_0.Contains(Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, i])) && Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(DeclaracoesGeral.mRevSimplificada[1, i], null, "TRIM", new object[0], null, null, null), "", TextCompare: true))
				{
					P_0.Add(Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, i]));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
		P_0.Sort();
	}

	private void twIQJbKKy1(object P_0, EventArgs P_1)
	{
		if (TG2QZtnH2j == 0.0)
		{
			return;
		}
		Pagina.CarregaPaginasOrdenadasNova();
		Revisao.capturaRevisoesSimplificadas();
		string text = "";
		XGNQiaO9Ri[0].R00 = clsTextos.TiraNothing(R0.Text.Trim());
		XGNQiaO9Ri[0].R01 = clsTextos.TiraNothing(R1.Text.Trim());
		XGNQiaO9Ri[0].R02 = clsTextos.TiraNothing(R2.Text.Trim());
		XGNQiaO9Ri[0].R03 = clsTextos.TiraNothing(R3.Text.Trim());
		XGNQiaO9Ri[0].R04 = clsTextos.TiraNothing(R4.Text.Trim());
		XGNQiaO9Ri[0].R05 = clsTextos.TiraNothing(R5.Text.Trim());
		XGNQiaO9Ri[0].R06 = clsTextos.TiraNothing(R6.Text.Trim());
		XGNQiaO9Ri[0].R07 = clsTextos.TiraNothing(R7.Text.Trim());
		XGNQiaO9Ri[0].R08 = clsTextos.TiraNothing(R8.Text.Trim());
		XGNQiaO9Ri[0].R09 = clsTextos.TiraNothing(R9.Text.Trim());
		XGNQiaO9Ri[0].R10 = clsTextos.TiraNothing(R10.Text.Trim());
		XGNQiaO9Ri[0].R11 = clsTextos.TiraNothing(R11.Text.Trim());
		XGNQiaO9Ri[0].R12 = clsTextos.TiraNothing(R12.Text.Trim());
		XGNQiaO9Ri[0].R13 = clsTextos.TiraNothing(R13.Text.Trim());
		XGNQiaO9Ri[0].R14 = clsTextos.TiraNothing(R14.Text.Trim());
		XGNQiaO9Ri[0].R15 = clsTextos.TiraNothing(R15.Text.Trim());
		XGNQiaO9Ri[0].R16 = clsTextos.TiraNothing(R16.Text.Trim());
		text += XGNQiaO9Ri[0].R00;
		text = text + "|" + XGNQiaO9Ri[0].R01;
		text = text + "|" + XGNQiaO9Ri[0].R02;
		text = text + "|" + XGNQiaO9Ri[0].R03;
		text = text + "|" + XGNQiaO9Ri[0].R04;
		text = text + "|" + XGNQiaO9Ri[0].R05;
		text = text + "|" + XGNQiaO9Ri[0].R06;
		text = text + "|" + XGNQiaO9Ri[0].R07;
		text = text + "|" + XGNQiaO9Ri[0].R08;
		text = text + "|" + XGNQiaO9Ri[0].R09;
		text = text + "|" + XGNQiaO9Ri[0].R10;
		text = text + "|" + XGNQiaO9Ri[0].R11;
		text = text + "|" + XGNQiaO9Ri[0].R12;
		text = text + "|" + XGNQiaO9Ri[0].R13;
		text = text + "|" + XGNQiaO9Ri[0].R14;
		text = text + "|" + XGNQiaO9Ri[0].R15;
		text = text + "|" + XGNQiaO9Ri[0].R16;
		int num = Information.UBound(DeclaracoesGeral.mPaginasNova);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				ref Relatorios_Rev_Matricial.RevisaoMatricial[] xGNQiaO9Ri = ref XGNQiaO9Ri;
				xGNQiaO9Ri = (Relatorios_Rev_Matricial.RevisaoMatricial[])Utils.CopyArray(xGNQiaO9Ri, new Relatorios_Rev_Matricial.RevisaoMatricial[i + 1]);
				XGNQiaO9Ri[i].sPagina = DeclaracoesGeral.mPaginasNova[i].Pagina;
				XGNQiaO9Ri[i].sAlternativa = DeclaracoesGeral.mPaginasNova[i].Alternativo;
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R00, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R00 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R00 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R00))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R00 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R01, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R01 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R01 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R01))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R01 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R02, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R02 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R02 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R02))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R02 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R03, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R03 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R03 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R03))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R03 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R04, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R04 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R04 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R04))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R04 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R05, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R05 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R05 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R05))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R05 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R06, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R06 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R06 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R06))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R06 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R07, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R07 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R07 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R07))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R07 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R08, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R08 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R08 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R08))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R08 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R09, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R09 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R09 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R09))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R09 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R10, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R10 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R10 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R10))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R10 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R11, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R11 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R11 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R11))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R11 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R12, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R12 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R12 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R12))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R12 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R13, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R13 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R13 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R13))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R13 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R14, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R14 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R14 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R14))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R14 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R15, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R15 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R15 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R15))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R15 + "|";
					}
				}
				if (!CaregaRevisaoSimplificadaDWG(DeclaracoesGeral.mPaginasNova[i].Pagina, XGNQiaO9Ri[0].R16, DeclaracoesGeral.mRevSimplificada))
				{
					XGNQiaO9Ri[i].R16 = "#B#";
				}
				else
				{
					XGNQiaO9Ri[i].R16 = "X";
					XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao).ToUpper();
					if (!XGNQiaO9Ri[i].sRevisao.Contains(XGNQiaO9Ri[0].R16))
					{
						XGNQiaO9Ri[i].sRevisao = XGNQiaO9Ri[0].R16 + "|";
					}
				}
				XGNQiaO9Ri[i].sRevisao = clsTextos.TiraNothing(XGNQiaO9Ri[i].sRevisao);
			}
			if (cbPreservar.Checked)
			{
				int num2 = Information.UBound(XGNQiaO9Ri);
				for (int j = 1; j <= num2; j++)
				{
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R00, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R00 + "|", "");
						ref string sRevisao = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao = sRevisao + XGNQiaO9Ri[0].R00 + "|";
						XGNQiaO9Ri[j].R00 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R01, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R01 + "|", "");
						ref string sRevisao2 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao2 = sRevisao2 + XGNQiaO9Ri[0].R01 + "|";
						XGNQiaO9Ri[j].R01 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R02, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R02 + "|", "");
						ref string sRevisao3 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao3 = sRevisao3 + XGNQiaO9Ri[0].R02 + "|";
						XGNQiaO9Ri[j].R02 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R03, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R03 + "|", "");
						ref string sRevisao4 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao4 = sRevisao4 + XGNQiaO9Ri[0].R03 + "|";
						XGNQiaO9Ri[j].R03 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R04, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R04 + "|", "");
						ref string sRevisao5 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao5 = sRevisao5 + XGNQiaO9Ri[0].R04 + "|";
						XGNQiaO9Ri[j].R04 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R05, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R05 + "|", "");
						ref string sRevisao6 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao6 = sRevisao6 + XGNQiaO9Ri[0].R05 + "|";
						XGNQiaO9Ri[j].R05 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R06, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R06 + "|", "");
						ref string sRevisao7 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao7 = sRevisao7 + XGNQiaO9Ri[0].R06 + "|";
						XGNQiaO9Ri[j].R06 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R07, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R07 + "|", "");
						ref string sRevisao8 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao8 = sRevisao8 + XGNQiaO9Ri[0].R07 + "|";
						XGNQiaO9Ri[j].R07 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R08, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R08 + "|", "");
						ref string sRevisao9 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao9 = sRevisao9 + XGNQiaO9Ri[0].R08 + "|";
						XGNQiaO9Ri[j].R08 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R09, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R09 + "|", "");
						ref string sRevisao10 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao10 = sRevisao10 + XGNQiaO9Ri[0].R09 + "|";
						XGNQiaO9Ri[j].R09 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R10, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R10 + "|", "");
						ref string sRevisao11 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao11 = sRevisao11 + XGNQiaO9Ri[0].R10 + "|";
						XGNQiaO9Ri[j].R10 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R11, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R11 + "|", "");
						ref string sRevisao12 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao12 = sRevisao12 + XGNQiaO9Ri[0].R11 + "|";
						XGNQiaO9Ri[j].R11 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R12, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R12 + "|", "");
						ref string sRevisao13 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao13 = sRevisao13 + XGNQiaO9Ri[0].R12 + "|";
						XGNQiaO9Ri[j].R12 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R13, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R13 + "|", "");
						ref string sRevisao14 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao14 = sRevisao14 + XGNQiaO9Ri[0].R13 + "|";
						XGNQiaO9Ri[j].R13 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R14, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R14 + "|", "");
						ref string sRevisao15 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao15 = sRevisao15 + XGNQiaO9Ri[0].R14 + "|";
						XGNQiaO9Ri[j].R14 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R15, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R15 + "|", "");
						ref string sRevisao16 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao16 = sRevisao16 + XGNQiaO9Ri[0].R15 + "|";
						XGNQiaO9Ri[j].R15 = "X";
					}
					if (Relatorios_Rev_Matricial.BuscaRevisoes(XGNQiaO9Ri[j].sPagina, XGNQiaO9Ri[0].R16, PnbQScqMC8))
					{
						XGNQiaO9Ri[j].sRevisao.Replace(XGNQiaO9Ri[0].R16 + "|", "");
						ref string sRevisao17 = ref XGNQiaO9Ri[j].sRevisao;
						sRevisao17 = sRevisao17 + XGNQiaO9Ri[0].R16 + "|";
						XGNQiaO9Ri[j].R16 = "X";
					}
				}
			}
			Relatorios_Rev_Matricial.ApagaRelatorioRevisaoMatricial();
			kbbQE4bchw.TamanhoFonte = 2.5;
			kbbQE4bchw.QuantColunas = 2;
			kbbQE4bchw.AlturaInicial = 25.0;
			kbbQE4bchw.dOrdenadaY = Conversions.ToDouble(tbOrdenadaY.Text);
			kbbQE4bchw.sFonte = "ROMANS";
			kbbQE4bchw.DistEntreColunas = 0.0;
			kbbQE4bchw.AlturaDoBloco = 6.0;
			kbbQE4bchw.sTitulo1 = tbTitulo1.Text;
			kbbQE4bchw.sTitulo2 = tbTitulo2.Text;
			kbbQE4bchw.sRevisoesProjeto = text;
			string pag = DeclaracoesGeral.ativo.Pagina;
			Relatorios_Rev_Matricial.CriaRelatorioREvisaoDWG(kbbQE4bchw, XGNQiaO9Ri);
			Pagina.AtivaPagina(pag);
			DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			Relatorios_Rev_Matricial.BuscaRevisoesAntigasDWG(ref PnbQScqMC8);
		}
	}

	public bool CaregaRevisaoSimplificadaDWG(string sPagina, string sRevisao, object[,] mRevSimplificada)
	{
		bool result = false;
		int num = Information.UBound(mRevSimplificada, 2);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.ConditionalCompareObjectEqual(sPagina, mRevSimplificada[0, i], TextCompare: true) && Operators.ConditionalCompareObjectNotEqual(mRevSimplificada[1, i], "", TextCompare: true) && Operators.CompareString(sRevisao, mRevSimplificada[1, i].ToString().ToUpper(), TextCompare: true) == 0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public void CarregaRevisoes(ref Relatorios_Rev_Matricial.RevisaoPosicaoMatricial mPosicoesrevisao)
	{
		mPosicoesrevisao.R0 = clsTextos.TiraNothing(R0.Text);
		mPosicoesrevisao.R1 = clsTextos.TiraNothing(R1.Text);
		mPosicoesrevisao.R2 = clsTextos.TiraNothing(R2.Text);
		mPosicoesrevisao.R3 = clsTextos.TiraNothing(R3.Text);
		mPosicoesrevisao.R4 = clsTextos.TiraNothing(R4.Text);
		mPosicoesrevisao.R5 = clsTextos.TiraNothing(R5.Text);
		mPosicoesrevisao.R6 = clsTextos.TiraNothing(R6.Text);
		mPosicoesrevisao.R7 = clsTextos.TiraNothing(R7.Text);
		mPosicoesrevisao.R8 = clsTextos.TiraNothing(R8.Text);
		mPosicoesrevisao.R9 = clsTextos.TiraNothing(R9.Text);
		mPosicoesrevisao.R10 = clsTextos.TiraNothing(R10.Text);
		mPosicoesrevisao.R11 = clsTextos.TiraNothing(R11.Text);
		mPosicoesrevisao.R12 = clsTextos.TiraNothing(R12.Text);
		mPosicoesrevisao.R13 = clsTextos.TiraNothing(R13.Text);
		mPosicoesrevisao.R14 = clsTextos.TiraNothing(R14.Text);
		mPosicoesrevisao.R15 = clsTextos.TiraNothing(R15.Text);
		mPosicoesrevisao.R16 = clsTextos.TiraNothing(R16.Text);
	}

	private void i6yQhye9BV(object P_0, EventArgs P_1)
	{
		Relatorios_Rev_Matricial.ApagaRelatorioRevisaoMatricial();
	}

	private void eajQoWPh9b(object P_0, EventArgs P_1)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Invalid comparison between Unknown and I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		TG2QZtnH2j = 0.0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			_ = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 688]) }, null, null, null);
			if ((int)((PromptResult)val2).Status != -5002)
			{
				TextBox textBox = tbOrdenadaY;
				Point3d value = val2.Value;
				textBox.Text = Math.Round(value.Y, 2).ToString();
				ref Relatorios_Rev_Matricial.ConfigReV reference = ref kbbQE4bchw;
				value = val2.Value;
				reference.dOrdenadaY = Math.Round(value.Y, 2);
				TG2QZtnH2j = -1.0;
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public object CarregaValores()
	{
		List<string> list = new List<string>();
		bool flag = false;
		list.Clear();
		if (Operators.CompareString(R0.Text, "", TextCompare: true) != 0)
		{
			list.Add(R0.Text);
		}
		if (Operators.CompareString(R1.Text, "", TextCompare: true) != 0)
		{
			list.Add(R1.Text);
		}
		if (Operators.CompareString(R2.Text, "", TextCompare: true) != 0)
		{
			list.Add(R2.Text);
		}
		if (Operators.CompareString(R3.Text, "", TextCompare: true) != 0)
		{
			list.Add(R3.Text);
		}
		if (Operators.CompareString(R4.Text, "", TextCompare: true) != 0)
		{
			list.Add(R4.Text);
		}
		if (Operators.CompareString(R5.Text, "", TextCompare: true) != 0)
		{
			list.Add(R5.Text);
		}
		if (Operators.CompareString(R6.Text, "", TextCompare: true) != 0)
		{
			list.Add(R6.Text);
		}
		if (Operators.CompareString(R7.Text, "", TextCompare: true) != 0)
		{
			list.Add(R7.Text);
		}
		if (Operators.CompareString(R8.Text, "", TextCompare: true) != 0)
		{
			list.Add(R8.Text);
		}
		if (Operators.CompareString(R9.Text, "", TextCompare: true) != 0)
		{
			list.Add(R9.Text);
		}
		if (Operators.CompareString(R10.Text, "", TextCompare: true) != 0)
		{
			list.Add(R10.Text);
		}
		if (Operators.CompareString(R11.Text, "", TextCompare: true) != 0)
		{
			list.Add(R11.Text);
		}
		if (Operators.CompareString(R12.Text, "", TextCompare: true) != 0)
		{
			list.Add(R12.Text);
		}
		if (Operators.CompareString(R13.Text, "", TextCompare: true) != 0)
		{
			list.Add(R13.Text);
		}
		if (Operators.CompareString(R14.Text, "", TextCompare: true) != 0)
		{
			list.Add(R14.Text);
		}
		if (Operators.CompareString(R15.Text, "", TextCompare: true) != 0)
		{
			list.Add(R15.Text);
		}
		if (Operators.CompareString(R16.Text, "", TextCompare: true) != 0)
		{
			list.Add(R16.Text);
		}
		checked
		{
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = list.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (i != j && Operators.CompareString(list[i], "", TextCompare: true) != 0 && Operators.CompareString(list[j], "", TextCompare: true) != 0 && Operators.CompareString(list[i], list[j], TextCompare: true) == 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			return flag;
		}
	}

	private void FJFQGYEqCT(object P_0, KeyEventArgs P_1)
	{
		R0.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R0.BackColor = Color.LightCoral;
		}
	}

	private void xi9QHBoLAj(object P_0, KeyEventArgs P_1)
	{
		R1.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R1.BackColor = Color.LightCoral;
		}
	}

	private void x0uQkw75YF(object P_0, KeyEventArgs P_1)
	{
		R2.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R2.BackColor = Color.LightCoral;
		}
	}

	private void CBhQdA2Ht2(object P_0, KeyEventArgs P_1)
	{
		R3.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R3.BackColor = Color.LightCoral;
		}
	}

	private void I6KQfPh60c(object P_0, KeyEventArgs P_1)
	{
		R4.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R4.BackColor = Color.LightCoral;
		}
	}

	private void OCaQDfIYon(object P_0, KeyEventArgs P_1)
	{
		R5.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R5.BackColor = Color.LightCoral;
		}
	}

	private void JtjQvhwdcS(object P_0, KeyEventArgs P_1)
	{
		R6.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R6.BackColor = Color.LightCoral;
		}
	}

	private void uyGQ6THKCG(object P_0, KeyEventArgs P_1)
	{
		R7.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R7.BackColor = Color.LightCoral;
		}
	}

	private void sNGQtnvvJO(object P_0, KeyEventArgs P_1)
	{
		R8.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R8.BackColor = Color.LightCoral;
		}
	}

	private void Vp5QjuUJ37(object P_0, KeyEventArgs P_1)
	{
		R9.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R9.BackColor = Color.LightCoral;
		}
	}

	private void SNSQL59hJ1(object P_0, KeyEventArgs P_1)
	{
		R10.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R10.BackColor = Color.LightCoral;
		}
	}

	private void XmmQw12nuT(object P_0, KeyEventArgs P_1)
	{
		R11.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R11.BackColor = Color.LightCoral;
		}
	}

	private void IfWQxBjyYv(object P_0, KeyEventArgs P_1)
	{
		R12.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R12.BackColor = Color.LightCoral;
		}
	}

	private void YqwQbArvJg(object P_0, KeyEventArgs P_1)
	{
		R13.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R13.BackColor = Color.LightCoral;
		}
	}

	private void W6bQMvdack(object P_0, KeyEventArgs P_1)
	{
		R14.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R14.BackColor = Color.LightCoral;
		}
	}

	private void G25QOO0tgV(object P_0, KeyEventArgs P_1)
	{
		R15.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R15.BackColor = Color.LightCoral;
		}
	}

	private void oWWQIwf7Lm(object P_0, KeyEventArgs P_1)
	{
		R16.BackColor = Color.White;
		if (Operators.ConditionalCompareObjectEqual(CarregaValores(), true, TextCompare: true))
		{
			R16.BackColor = Color.LightCoral;
		}
	}
}
