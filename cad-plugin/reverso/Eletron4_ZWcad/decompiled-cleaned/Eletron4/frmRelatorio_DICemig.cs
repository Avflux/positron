using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
public class frmRelatorio_DICemig : Form
{
	private IContainer cpPjITHWTr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView q64j7448AH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView IN3jqsOAON;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionarRegua")]
	private Button x4GjaR6shh;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip QE5j8Fi72Q;

	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox f59jN0ypBT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCadastro")]
	private RadioButton hBmjFN8Kra;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCrescente")]
	private RadioButton EpjjQEAnoF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgRegua")]
	private DataGridView sepjPIbcUI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox JD1jcovJuw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb2")]
	private RadioButton Yb2jKd72IG;

	[AccessedThroughProperty("rb1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton FXAjeGJhiA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagaRegua")]
	private Button ieZj2oSrNO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btJumper")]
	private Button cknj3nhR3g;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarJumper")]
	private Button Ds6jnfOgMM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarCabos")]
	private Button oQUj1HwhwA;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox FmpjlpAF30;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox RFdj5qF5R6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	private GroupBox nfZj0rfEPs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCabos")]
	private Button XjSjR5gbAN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox wsijmWKKDb;

	[AccessedThroughProperty("btApagarVeias")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button stMjXikqvH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btVeias")]
	private Button Y2ljU3ULB8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSincroniza")]
	private Button cwRjyAWtmj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb4")]
	private RadioButton PD3jgc9rLO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb3")]
	private RadioButton eX9jAh29yi;

	[AccessedThroughProperty("ProgressBar1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ProgressBar UCIjsZiosh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPesquisa")]
	private TextBox TU9jB1bJJq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSeleciona")]
	private Button Dn3jV3FZBh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbC")]
	private RadioButton z8QjuU2iyO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btMirrorJumperDown")]
	private Button LupjEiRP1F;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEsquerda")]
	[CompilerGenerated]
	private Button BqNjZhTRSN;

	[CompilerGenerated]
	[AccessedThroughProperty("dgEsquerda")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView O42jiIWbr1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label xKSjSGC9YK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btVerificar")]
	private Button oElj4MXAJG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarCruzamentos")]
	private Button gdbjCokiic;

	private DeclaracoesFiacao.structurePnRev[] zuZjYVsDP7;

	private DeclaracoesFiacao.structureRevisoes[] LnFjrULJce;

	private DeclaracoesInterligacao.structureRI[] XNlj9mcaVA;

	private DeclaracoesInterligacao.structureBornesInseridos[] em2jzQ3JUO;

	private string LfiLWCpBu5;

	private int K1DLpQ0OWN;

	private bool zuVLTrngIJ;

	private bool MbQLJbiRX8;

	private DeclaracoesInterligacao.ConfigDInterlig eMmLhB0KQG;

	private int Hu2LowX0Zg;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return q64j7448AH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tRyt9ievha;
			DataGridView dataGridView = q64j7448AH;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			q64j7448AH = value;
			dataGridView = q64j7448AH;
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
			return IN3jqsOAON;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Xt9jTCO4oq;
			DataGridView dataGridView = IN3jqsOAON;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			IN3jqsOAON = value;
			dataGridView = IN3jqsOAON;
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
			return x4GjaR6shh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = e3tjkcLwkF;
			Button button = x4GjaR6shh;
			if (button != null)
			{
				button.Click -= value2;
			}
			x4GjaR6shh = value;
			button = x4GjaR6shh;
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
			return f59jN0ypBT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			f59jN0ypBT = value;
		}
	}

	internal virtual RadioButton rbCadastro
	{
		[CompilerGenerated]
		get
		{
			return hBmjFN8Kra;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = T7Ajp94A9Z;
			RadioButton radioButton = hBmjFN8Kra;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			hBmjFN8Kra = value;
			radioButton = hBmjFN8Kra;
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
			return EpjjQEAnoF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EpjjQEAnoF = value;
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return sepjPIbcUI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sepjPIbcUI = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return JD1jcovJuw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JD1jcovJuw = value;
		}
	}

	internal virtual RadioButton rb2
	{
		[CompilerGenerated]
		get
		{
			return Yb2jKd72IG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Yb2jKd72IG = value;
		}
	}

	internal virtual RadioButton rb1
	{
		[CompilerGenerated]
		get
		{
			return FXAjeGJhiA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FXAjeGJhiA = value;
		}
	}

	internal virtual Button btApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return ieZj2oSrNO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fDFjd8aiem;
			Button button = ieZj2oSrNO;
			if (button != null)
			{
				button.Click -= value2;
			}
			ieZj2oSrNO = value;
			button = ieZj2oSrNO;
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
			return cknj3nhR3g;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DPZjDrLPc4;
			Button button = cknj3nhR3g;
			if (button != null)
			{
				button.Click -= value2;
			}
			cknj3nhR3g = value;
			button = cknj3nhR3g;
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
			return Ds6jnfOgMM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rOyjviuxI1;
			Button button = Ds6jnfOgMM;
			if (button != null)
			{
				button.Click -= value2;
			}
			Ds6jnfOgMM = value;
			button = Ds6jnfOgMM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarCabos
	{
		[CompilerGenerated]
		get
		{
			return oQUj1HwhwA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iIqjLvg1rh;
			Button button = oQUj1HwhwA;
			if (button != null)
			{
				button.Click -= value2;
			}
			oQUj1HwhwA = value;
			button = oQUj1HwhwA;
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
			return FmpjlpAF30;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FmpjlpAF30 = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return RFdj5qF5R6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RFdj5qF5R6 = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return nfZj0rfEPs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nfZj0rfEPs = value;
		}
	}

	internal virtual Button btCabos
	{
		[CompilerGenerated]
		get
		{
			return XjSjR5gbAN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TjtjjCjlKn;
			Button button = XjSjR5gbAN;
			if (button != null)
			{
				button.Click -= value2;
			}
			XjSjR5gbAN = value;
			button = XjSjR5gbAN;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return wsijmWKKDb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wsijmWKKDb = value;
		}
	}

	internal virtual Button btApagarVeias
	{
		[CompilerGenerated]
		get
		{
			return stMjXikqvH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = miXjxZSpFP;
			Button button = stMjXikqvH;
			if (button != null)
			{
				button.Click -= value2;
			}
			stMjXikqvH = value;
			button = stMjXikqvH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btVeias
	{
		[CompilerGenerated]
		get
		{
			return Y2ljU3ULB8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iC0jwTZK8U;
			Button button = Y2ljU3ULB8;
			if (button != null)
			{
				button.Click -= value2;
			}
			Y2ljU3ULB8 = value;
			button = Y2ljU3ULB8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSincroniza
	{
		[CompilerGenerated]
		get
		{
			return cwRjyAWtmj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = g7BjMIf6bR;
			Button button = cwRjyAWtmj;
			if (button != null)
			{
				button.Click -= value2;
			}
			cwRjyAWtmj = value;
			button = cwRjyAWtmj;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rb4
	{
		[CompilerGenerated]
		get
		{
			return PD3jgc9rLO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PD3jgc9rLO = value;
		}
	}

	internal virtual RadioButton rb3
	{
		[CompilerGenerated]
		get
		{
			return eX9jAh29yi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eX9jAh29yi = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return UCIjsZiosh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UCIjsZiosh = value;
		}
	}

	internal virtual TextBox tbPesquisa
	{
		[CompilerGenerated]
		get
		{
			return TU9jB1bJJq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = FDCtzavAWy;
			TextBox textBox = TU9jB1bJJq;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			TU9jB1bJJq = value;
			textBox = TU9jB1bJJq;
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
			return Dn3jV3FZBh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rhkjf4xHdt;
			Button button = Dn3jV3FZBh;
			if (button != null)
			{
				button.Click -= value2;
			}
			Dn3jV3FZBh = value;
			button = Dn3jV3FZBh;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbC
	{
		[CompilerGenerated]
		get
		{
			return z8QjuU2iyO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dF0jbab1hm;
			RadioButton radioButton = z8QjuU2iyO;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			z8QjuU2iyO = value;
			radioButton = z8QjuU2iyO;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btMirrorJumperDown
	{
		[CompilerGenerated]
		get
		{
			return LupjEiRP1F;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DVNj6gLTMY;
			Button button = LupjEiRP1F;
			if (button != null)
			{
				button.Click -= value2;
			}
			LupjEiRP1F = value;
			button = LupjEiRP1F;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEsquerda
	{
		[CompilerGenerated]
		get
		{
			return BqNjZhTRSN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = l3ejt1KHhg;
			Button button = BqNjZhTRSN;
			if (button != null)
			{
				button.Click -= value2;
			}
			BqNjZhTRSN = value;
			button = BqNjZhTRSN;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgEsquerda
	{
		[CompilerGenerated]
		get
		{
			return O42jiIWbr1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			O42jiIWbr1 = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return xKSjSGC9YK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xKSjSGC9YK = value;
		}
	}

	internal virtual Button btVerificar
	{
		[CompilerGenerated]
		get
		{
			return oElj4MXAJG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oKBjotq5s3;
			Button button = oElj4MXAJG;
			if (button != null)
			{
				button.Click -= value2;
			}
			oElj4MXAJG = value;
			button = oElj4MXAJG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarCruzamentos
	{
		[CompilerGenerated]
		get
		{
			return gdbjCokiic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uIvjOIkcWF;
			Button button = gdbjCokiic;
			if (button != null)
			{
				button.Click -= value2;
			}
			gdbjCokiic = value;
			button = gdbjCokiic;
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
			if (disposing && cpPjITHWTr != null)
			{
				cpPjITHWTr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m8utCwCm4x()
	{
		cpPjITHWTr = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		btAdicionarRegua = new Button();
		FDqpBiUmZij(new ToolTip(cpPjITHWTr));
		GroupBox2 = new GroupBox();
		rbCadastro = new RadioButton();
		rbCrescente = new RadioButton();
		dgRegua = new DataGridView();
		GroupBox1 = new GroupBox();
		rbC = new RadioButton();
		rb4 = new RadioButton();
		rb3 = new RadioButton();
		rb2 = new RadioButton();
		rb1 = new RadioButton();
		btApagaRegua = new Button();
		btJumper = new Button();
		btApagarJumper = new Button();
		btApagarCabos = new Button();
		GroupBox3 = new GroupBox();
		btVerificar = new Button();
		GroupBox4 = new GroupBox();
		btMirrorJumperDown = new Button();
		GroupBox5 = new GroupBox();
		btEsquerda = new Button();
		btCabos = new Button();
		GroupBox6 = new GroupBox();
		btVeias = new Button();
		btApagarVeias = new Button();
		btSincroniza = new Button();
		ProgressBar1 = new ProgressBar();
		tbPesquisa = new TextBox();
		btSeleciona = new Button();
		dgEsquerda = new DataGridView();
		Label1 = new Label();
		btApagarCruzamentos = new Button();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgRegua).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox6.SuspendLayout();
		((ISupportInitialize)dgEsquerda).BeginInit();
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
		dgRevisao.Size = new Size(395, 133);
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
		dgEquip.Size = new Size(137, 250);
		dgEquip.TabIndex = 8;
		btAdicionarRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAdicionarRegua.FlatStyle = FlatStyle.Flat;
		btAdicionarRegua.ForeColor = SystemColors.Control;
		btAdicionarRegua.Image = Resources.BorneAranha_32;
		btAdicionarRegua.Location = new Point(47, 20);
		btAdicionarRegua.Name = "btAdicionarRegua";
		btAdicionarRegua.Size = new Size(40, 42);
		btAdicionarRegua.TabIndex = 15;
		btAdicionarRegua.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rbCadastro);
		GroupBox2.Controls.Add(rbCrescente);
		GroupBox2.Location = new Point(155, 351);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(169, 46);
		GroupBox2.TabIndex = 47;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordem Bornes Máscara";
		rbCadastro.AutoSize = true;
		rbCadastro.Location = new Point(94, 19);
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
		dgRegua.Size = new Size(252, 177);
		dgRegua.TabIndex = 48;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbC);
		GroupBox1.Controls.Add(rb4);
		GroupBox1.Controls.Add(rb3);
		GroupBox1.Controls.Add(rb2);
		GroupBox1.Controls.Add(rb1);
		GroupBox1.Location = new Point(157, 402);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(250, 49);
		GroupBox1.TabIndex = 49;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Posição";
		rbC.AutoSize = true;
		rbC.Location = new Point(102, 19);
		rbC.Name = "rbC";
		rbC.Size = new Size(41, 17);
		rbC.TabIndex = 54;
		rbC.TabStop = true;
		rbC.Text = "rbC";
		rbC.UseVisualStyleBackColor = true;
		rb4.AutoSize = true;
		rb4.Location = new Point(195, 19);
		rb4.Name = "rb4";
		rb4.Size = new Size(40, 17);
		rb4.TabIndex = 53;
		rb4.TabStop = true;
		rb4.Text = "rb4";
		rb4.UseVisualStyleBackColor = true;
		rb3.AutoSize = true;
		rb3.Location = new Point(149, 19);
		rb3.Name = "rb3";
		rb3.Size = new Size(40, 17);
		rb3.TabIndex = 52;
		rb3.TabStop = true;
		rb3.Text = "rb3";
		rb3.UseVisualStyleBackColor = true;
		rb2.AutoSize = true;
		rb2.Location = new Point(55, 19);
		rb2.Name = "rb2";
		rb2.Size = new Size(40, 17);
		rb2.TabIndex = 51;
		rb2.TabStop = true;
		rb2.Text = "rb2";
		rb2.UseVisualStyleBackColor = true;
		rb1.AutoSize = true;
		rb1.Location = new Point(10, 19);
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
		btApagaRegua.Location = new Point(85, 20);
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
		btJumper.Size = new Size(26, 42);
		btJumper.TabIndex = 51;
		btJumper.UseVisualStyleBackColor = true;
		btApagarJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarJumper.FlatStyle = FlatStyle.Flat;
		btApagarJumper.ForeColor = SystemColors.Control;
		btApagarJumper.Image = Resources.Delete_32;
		btApagarJumper.Location = new Point(37, 20);
		btApagarJumper.Name = "btApagarJumper";
		btApagarJumper.Size = new Size(40, 42);
		btApagarJumper.TabIndex = 52;
		btApagarJumper.UseVisualStyleBackColor = true;
		btApagarCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCabos.FlatStyle = FlatStyle.Flat;
		btApagarCabos.ForeColor = SystemColors.Control;
		btApagarCabos.Image = Resources.Delete_32;
		btApagarCabos.Location = new Point(85, 18);
		btApagarCabos.Name = "btApagarCabos";
		btApagarCabos.Size = new Size(40, 42);
		btApagarCabos.TabIndex = 54;
		btApagarCabos.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(btVerificar);
		GroupBox3.Controls.Add(btAdicionarRegua);
		GroupBox3.Controls.Add(btApagaRegua);
		GroupBox3.Location = new Point(155, 457);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(130, 70);
		GroupBox3.TabIndex = 56;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Réguas de Bornes";
		btVerificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVerificar.FlatStyle = FlatStyle.Flat;
		btVerificar.ForeColor = SystemColors.Control;
		btVerificar.Image = Resources.Check;
		btVerificar.Location = new Point(6, 20);
		btVerificar.Name = "btVerificar";
		btVerificar.Size = new Size(36, 42);
		btVerificar.TabIndex = 70;
		btVerificar.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(btMirrorJumperDown);
		GroupBox4.Controls.Add(btApagarJumper);
		GroupBox4.Controls.Add(btJumper);
		GroupBox4.Location = new Point(291, 457);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(116, 70);
		GroupBox4.TabIndex = 57;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Jumpers";
		btMirrorJumperDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btMirrorJumperDown.FlatStyle = FlatStyle.Flat;
		btMirrorJumperDown.ForeColor = SystemColors.Control;
		btMirrorJumperDown.Image = Resources.JumperRebatido2_32;
		btMirrorJumperDown.Location = new Point(81, 20);
		btMirrorJumperDown.Name = "btMirrorJumperDown";
		btMirrorJumperDown.Size = new Size(32, 42);
		btMirrorJumperDown.TabIndex = 67;
		btMirrorJumperDown.UseVisualStyleBackColor = true;
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(btEsquerda);
		GroupBox5.Controls.Add(btCabos);
		GroupBox5.Controls.Add(btApagarCabos);
		GroupBox5.Location = new Point(155, 532);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(130, 70);
		GroupBox5.TabIndex = 58;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Cabos";
		btEsquerda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btEsquerda.FlatStyle = FlatStyle.Flat;
		btEsquerda.ForeColor = SystemColors.Control;
		btEsquerda.Image = Resources.DI_Left;
		btEsquerda.Location = new Point(4, 18);
		btEsquerda.Name = "btEsquerda";
		btEsquerda.Size = new Size(40, 42);
		btEsquerda.TabIndex = 55;
		btEsquerda.UseVisualStyleBackColor = true;
		btCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCabos.FlatStyle = FlatStyle.Flat;
		btCabos.ForeColor = SystemColors.Control;
		btCabos.Image = Resources.CaboAranha_32;
		btCabos.Location = new Point(48, 18);
		btCabos.Name = "btCabos";
		btCabos.Size = new Size(40, 42);
		btCabos.TabIndex = 51;
		btCabos.UseVisualStyleBackColor = true;
		GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox6.Controls.Add(btVeias);
		GroupBox6.Controls.Add(btApagarVeias);
		GroupBox6.Location = new Point(291, 533);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(116, 70);
		GroupBox6.TabIndex = 59;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Veias";
		btVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVeias.FlatStyle = FlatStyle.Flat;
		btVeias.ForeColor = SystemColors.Control;
		btVeias.Image = Resources.Veias;
		btVeias.Location = new Point(13, 19);
		btVeias.Name = "btVeias";
		btVeias.Size = new Size(40, 42);
		btVeias.TabIndex = 55;
		btVeias.UseVisualStyleBackColor = true;
		btApagarVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarVeias.FlatStyle = FlatStyle.Flat;
		btApagarVeias.ForeColor = SystemColors.Control;
		btApagarVeias.Image = Resources.Delete_32;
		btApagarVeias.Location = new Point(62, 19);
		btApagarVeias.Name = "btApagarVeias";
		btApagarVeias.Size = new Size(40, 42);
		btApagarVeias.TabIndex = 52;
		btApagarVeias.UseVisualStyleBackColor = true;
		btSincroniza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSincroniza.FlatStyle = FlatStyle.Flat;
		btSincroniza.ForeColor = SystemColors.Control;
		btSincroniza.Image = Resources.Sincroniza_32;
		btSincroniza.Location = new Point(330, 357);
		btSincroniza.Name = "btSincroniza";
		btSincroniza.Size = new Size(36, 42);
		btSincroniza.TabIndex = 51;
		btSincroniza.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(155, 334);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(252, 11);
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
		btSeleciona.TabIndex = 66;
		btSeleciona.UseVisualStyleBackColor = true;
		dgEsquerda.AllowUserToAddRows = false;
		dgEsquerda.AllowUserToOrderColumns = true;
		dgEsquerda.AllowUserToResizeRows = false;
		dgEsquerda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		dgEsquerda.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgEsquerda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgEsquerda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEsquerda.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEsquerda.Location = new Point(12, 451);
		dgEsquerda.MultiSelect = false;
		dgEsquerda.Name = "dgEsquerda";
		dgEsquerda.ReadOnly = true;
		dgEsquerda.RowHeadersVisible = false;
		dgEsquerda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEsquerda.Size = new Size(137, 153);
		dgEsquerda.TabIndex = 67;
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label1.AutoSize = true;
		Label1.Location = new Point(12, 434);
		Label1.Name = "Label1";
		Label1.Size = new Size(85, 13);
		Label1.TabIndex = 68;
		Label1.Text = "Equip. Esquerda";
		btApagarCruzamentos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCruzamentos.FlatStyle = FlatStyle.Flat;
		btApagarCruzamentos.ForeColor = SystemColors.Control;
		btApagarCruzamentos.Image = Resources.Delete_32;
		btApagarCruzamentos.Location = new Point(371, 357);
		btApagarCruzamentos.Name = "btApagarCruzamentos";
		btApagarCruzamentos.Size = new Size(36, 42);
		btApagarCruzamentos.TabIndex = 69;
		btApagarCruzamentos.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(414, 611);
		Controls.Add(btApagarCruzamentos);
		Controls.Add(GroupBox2);
		Controls.Add(Label1);
		Controls.Add(dgEsquerda);
		Controls.Add(btSeleciona);
		Controls.Add(tbPesquisa);
		Controls.Add(ProgressBar1);
		Controls.Add(btSincroniza);
		Controls.Add(GroupBox6);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(dgRegua);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(430, 1200);
		MinimumSize = new Size(430, 650);
		Name = "frmRelatorio_DICemig";
		ShowInTaskbar = false;
		Text = "Diagrama de Interligação CEMIG";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dgRegua).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox6.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgEsquerda).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return QE5j8Fi72Q;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		QE5j8Fi72Q = WithEventsValue;
	}

	public frmRelatorio_DICemig(int value)
	{
		zuZjYVsDP7 = new DeclaracoesFiacao.structurePnRev[1];
		LnFjrULJce = new DeclaracoesFiacao.structureRevisoes[1];
		LfiLWCpBu5 = "";
		K1DLpQ0OWN = 0;
		zuVLTrngIJ = false;
		MbQLJbiRX8 = false;
		eMmLhB0KQG = default;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_DICemig"))
			{
				m8utCwCm4x();
				Pj5tYIStNe(_0020: false);
				Hu2LowX0Zg = value;
				switch (Hu2LowX0Zg)
				{
				case 3:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1898]);
					eMmLhB0KQG.bA1 = false;
					rb4.Enabled = false;
					eMmLhB0KQG.textStyle = "Arial";
					eMmLhB0KQG.diretorio = "Interligação\\Cemig-D\\";
					break;
				case 1:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1886]);
					eMmLhB0KQG.bA1 = true;
					rb4.Enabled = true;
					eMmLhB0KQG.textStyle = "INTL_ISO";
					eMmLhB0KQG.diretorio = "Interligação\\Cemig-GT-EQ\\";
					break;
				case 2:
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1896]);
					eMmLhB0KQG.bA1 = true;
					rb4.Enabled = true;
					eMmLhB0KQG.textStyle = "Arial";
					eMmLhB0KQG.diretorio = "Interligação\\Cemig-D\\";
					break;
				}
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1439]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1419]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1444]);
				GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
				GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1445]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1548]);
				rbCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1420]);
				rbCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1421]);
				rb1.Text = "1";
				rb2.Text = "2";
				rb3.Text = "3";
				rb4.Text = "4";
				rbC.Text = "C";
				w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1900]));
				w8dpBZ0kvSD().SetToolTip(btApagarCruzamentos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1901]));
				w8dpBZ0kvSD().SetToolTip(btVerificar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1902]));
				w8dpBZ0kvSD().SetToolTip(btEsquerda, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1903]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				XNlj9mcaVA = new DeclaracoesInterligacao.structureRI[1];
				XNlj9mcaVA[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				em2jzQ3JUO = new DeclaracoesInterligacao.structureBornesInseridos[1];
				formataDGRevisao();
				formataDGEquip();
				rbCrescente.Checked = true;
				rb1.Checked = true;
				U0utraESe5();
				Pj5tYIStNe(_0020: true);
				btEsquerda.Enabled = false;
				btMirrorJumperDown.Enabled = false;
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

	private void Pj5tYIStNe(bool P_0)
	{
		GroupBox1.Enabled = P_0;
		GroupBox2.Enabled = P_0;
		GroupBox3.Enabled = P_0;
		GroupBox4.Enabled = P_0;
		GroupBox5.Enabled = P_0;
		GroupBox6.Enabled = P_0;
		btSincroniza.Enabled = P_0;
		btSeleciona.Enabled = P_0;
	}

	private void U0utraESe5()
	{
		LnFjrULJce = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref LnFjrULJce);
			zuVLTrngIJ = true;
			dgRevisao.Rows.Clear();
			zuVLTrngIJ = false;
			int num = Information.UBound(LnFjrULJce);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(LnFjrULJce[i].revisao, LnFjrULJce[i].criador, LnFjrULJce[i].data);
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

	private void tRyt9ievha(object P_0, EventArgs P_1)
	{
		MbQLJbiRX8 = true;
		dgEquip.Rows.Clear();
		MbQLJbiRX8 = false;
		if (!zuVLTrngIJ)
		{
			mg6jWyNMrF(_0020: false);
		}
	}

	private void FDCtzavAWy(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(tbPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !zuVLTrngIJ)
		{
			mg6jWyNMrF(_0020: true);
		}
	}

	private void mg6jWyNMrF(bool P_0)
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
			LfiLWCpBu5 = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			MbQLJbiRX8 = true;
			dgEquip.Rows.Clear();
			MbQLJbiRX8 = false;
			int num = Information.UBound(zuZjYVsDP7);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(zuZjYVsDP7[i].revisao, LfiLWCpBu5, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(zuZjYVsDP7[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(zuZjYVsDP7[i].painel, text);
					}
					else if (text.ToUpper().Contains(tbPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(zuZjYVsDP7[i].painel, text);
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
		zuZjYVsDP7 = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(LnFjrULJce) > 0)
			{
				int num = Information.UBound(LnFjrULJce);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(LnFjrULJce[i].revisao, ref zuZjYVsDP7);
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

	private void T7Ajp94A9Z(object P_0, EventArgs P_1)
	{
		bXpjJyKmHv();
	}

	private void Xt9jTCO4oq(object P_0, EventArgs P_1)
	{
		bXpjJyKmHv();
		formataDGEsquerda();
	}

	private void bXpjJyKmHv()
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				Pj5tYIStNe(_0020: false);
				K1DLpQ0OWN = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				formataDGRegua();
				XNlj9mcaVA = new DeclaracoesInterligacao.structureRI[1];
				XNlj9mcaVA[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cDadosAccessInterligacao3.CarregaReguas(LfiLWCpBu5, K1DLpQ0OWN, ref XNlj9mcaVA);
				cDadosAccessInterligacao3.CarregaReguasPortas(LfiLWCpBu5, K1DLpQ0OWN, ref XNlj9mcaVA);
				cDadosAccessInterligacao3.CarregaBornesReguas(LfiLWCpBu5, K1DLpQ0OWN, ref XNlj9mcaVA, rbCadastro.Checked);
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = checked(ITTjh3PaXi() * 2);
				ProgressBar1.Value = 0;
				ProgressBar1.Step = 1;
				string lfiLWCpBu = LfiLWCpBu5;
				int k1DLpQ0OWN = K1DLpQ0OWN;
				ref DeclaracoesInterligacao.structureRI[] xNlj9mcaVA = ref XNlj9mcaVA;
				ProgressBar ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaCabosNosBornesRI(lfiLWCpBu, k1DLpQ0OWN, ref xNlj9mcaVA, ref ProgressBar, -1);
				ProgressBar1 = ProgressBar;
				string lfiLWCpBu2 = LfiLWCpBu5;
				int k1DLpQ0OWN2 = K1DLpQ0OWN;
				ref DeclaracoesInterligacao.structureRI[] xNlj9mcaVA2 = ref XNlj9mcaVA;
				ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaJumpersNosBornesRI(lfiLWCpBu2, k1DLpQ0OWN2, ref xNlj9mcaVA2, ref ProgressBar);
				ProgressBar1 = ProgressBar;
				d7SjHXYnIY();
				wh5jGT1csZ();
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
			Pj5tYIStNe(_0020: true);
		}
	}

	private int ITTjh3PaXi()
	{
		int num = 0;
		int num2 = Information.UBound(XNlj9mcaVA);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!Information.IsNothing(XNlj9mcaVA[i].Bornes))
				{
					num += XNlj9mcaVA[i].Bornes.Length - 1;
				}
			}
			return num;
		}
	}

	private void oKBjotq5s3(object P_0, EventArgs P_1)
	{
		wh5jGT1csZ();
	}

	private void wh5jGT1csZ()
	{
		em2jzQ3JUO = new DeclaracoesInterligacao.structureBornesInseridos[1];
		clsDICemig.ContaBornesReguas(K1DLpQ0OWN, ref em2jzQ3JUO);
		checked
		{
			int num = dgRegua.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string right = Conversions.ToString(dgRegua.Rows[i].Cells[1].Value);
				string right2 = Conversions.ToString(dgRegua.Rows[i].Cells[2].Value);
				int num2 = Conversions.ToInteger(dgRegua.Rows[i].Cells[3].Value);
				bool flag = false;
				int num3 = Information.UBound(em2jzQ3JUO);
				for (int j = 1; j <= num3; j++)
				{
					if (!((Operators.CompareString(em2jzQ3JUO[j].Tag, right, TextCompare: true) == 0) & (Operators.CompareString(em2jzQ3JUO[j].NRegua, right2, TextCompare: true) == 0)))
					{
						continue;
					}
					if (num2 != em2jzQ3JUO[j].Qtde)
					{
						if ((num2 > em2jzQ3JUO[j].Qtde) & (em2jzQ3JUO[j].Qtde > 0))
						{
							flag = true;
							dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightYellow;
						}
					}
					else
					{
						flag = true;
						dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightCoral;
					}
				}
				if (!flag)
				{
					dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
				}
			}
		}
	}

	private void d7SjHXYnIY()
	{
		if (Information.UBound(XNlj9mcaVA) == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		try
		{
			int num = Information.UBound(XNlj9mcaVA);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Information.IsNothing(XNlj9mcaVA[i].Bornes))
				{
					if (!list.Contains(XNlj9mcaVA[i].DWG))
					{
						list.Add(XNlj9mcaVA[i].DWG);
					}
					continue;
				}
				int num2 = Information.UBound(XNlj9mcaVA[i].Bornes);
				dgRegua.Rows.Add(XNlj9mcaVA[i].Tipo, XNlj9mcaVA[i].Tag, XNlj9mcaVA[i].NRegua, num2);
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

	private void e3tjkcLwkF(object P_0, EventArgs P_1)
	{
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_0785: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				DeclaracoesInterligacao.structureRI structureRI = default;
				if (dgEquip.SelectedRows.Count == 0 || dgRegua.SelectedRows.Count == 0)
				{
					return;
				}
				DeclaracoesGeral.Reguas RH = default;
				if (XDataGeral.LeXDataReguaH(ref RH))
				{
					string text = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
					string text2 = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
					int num = Information.UBound(XNlj9mcaVA);
					for (int i = 1; i <= num; i++)
					{
						if ((Operators.CompareString(XNlj9mcaVA[i].Tag, text, TextCompare: true) == 0) & (Operators.CompareString(XNlj9mcaVA[i].NRegua, text2, TextCompare: true) == 0))
						{
							structureRI = XNlj9mcaVA[i];
							break;
						}
					}
					if (Information.UBound(structureRI.Bornes) == 0)
					{
						return;
					}
					int num2 = 0;
					double num3 = 0.0;
					double num4 = 0.0;
					int num5 = 0;
					bool bInsereNomeRegua = false;
					int num6 = 0;
					if (!eMmLhB0KQG.bA1)
					{
						num6 = 3;
						num4 = 10.0;
					}
					else
					{
						num6 = 4;
						num4 = 30.0;
					}
					int num7 = (int)Math.Round((RH.Pti.Y - 20.0 - (RH.AltBase + 20.0)) / 8.0);
					double num8 = (RH.LarguraBase - RH.Pti.X) / (double)num6;
					double num9 = RH.Pti.Y - 20.0;
					Point3d val = new Point3d(RH.Pti.X + num8 * 0.0 + num4, num9, 0.0);
					Point3d val2 = new Point3d(RH.Pti.X + num8 * 1.0 + num4, num9, 0.0);
					Point3d val3 = new Point3d(RH.Pti.X + num8 * 2.0 + num4, num9, 0.0);
					Point3d val4 = new Point3d(RH.Pti.X + num8 * 3.0 + num4, num9, 0.0);
					Point3d val5 = ((num6 == 4) ? new Point3d(RH.Pti.X + num8 * 2.0 - 5.0, num9, 0.0) : new Point3d(RH.Pti.X + num8 * 1.5 - 5.0, num9, 0.0));
					Point3d ptIns = default;
					if (!rb1.Checked)
					{
						if (!rb2.Checked)
						{
							if (!rb3.Checked)
							{
								if (!rb4.Checked)
								{
									if (rbC.Checked)
									{
										ptIns = val5;
										num5 = 5;
									}
								}
								else
								{
									ptIns = val4;
									num5 = 4;
								}
							}
							else
							{
								ptIns = val3;
								num5 = 3;
							}
						}
						else
						{
							ptIns = val2;
							num5 = 2;
						}
					}
					else
					{
						ptIns = val;
						num5 = 1;
					}
					List<string> lBornes = new List<string>();
					Point3d pt = default;
					if (clsDICemig.ReguaExiste(K1DLpQ0OWN, text, text2))
					{
						DeclaracoesInterligacao.PosborneAranha ubn = default;
						if (!clsDICemig.BuscaUltimoBorne(K1DLpQ0OWN, text, text2, ref ubn, ref lBornes))
						{
							return;
						}
						Pagina.AtivaPagina(ubn.Pagina);
						num5 = ubn.Posicao;
						ptIns = ubn.PtIns;
						num2 = (int)Math.Round((num9 - ubn.PtIns.Y) / 8.0);
						if (structureRI.Bornes[1].TipoBorne != 0)
						{
							num2 += 2;
							num3 = 16.0;
						}
						else
						{
							num2++;
							num3 = 8.0;
						}
					}
					else if (clsDICemig.OutraReguaExiste(DeclaracoesGeral.ativo.Pagina, ref pt, num5))
					{
						ptIns = new Point3d(pt.X, pt.Y - 24.0, 0.0);
						num2 = (int)Math.Round((num9 - ptIns.Y) / 8.0);
						if (num2 >= num7)
						{
							return;
						}
						bInsereNomeRegua = true;
					}
					int num10 = Information.UBound(structureRI.Bornes);
					int num11 = 1;
					while (true)
					{
						if (num11 <= num10)
						{
							if (!lBornes.Contains(structureRI.Bornes[num11].Borne))
							{
								if (num2 != 0)
								{
									if (!((num2 > 0) & (num2 < num7)))
									{
										if (!((num2 >= num7) & (num5 <= num6)))
										{
											if ((num2 >= num7) & (num5 == 5))
											{
												num2 = 0;
												num5 = 5;
												string text3 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
												if (Operators.CompareString(text3, "", TextCompare: true) != 0)
												{
													Pagina.AtivaPagina(text3);
												}
												else if (!Pagina.criarUmaNovaPagina())
												{
													goto IL_0728;
												}
												ptIns = val5;
											}
										}
										else
										{
											num2 = 0;
											num5++;
											if (num5 == num6 + 1)
											{
												num5 = 1;
												string text4 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
												if (Operators.CompareString(text4, "", TextCompare: true) != 0)
												{
													Pagina.AtivaPagina(text4);
												}
												else if (!Pagina.criarUmaNovaPagina())
												{
													goto IL_0728;
												}
											}
											switch (num5)
											{
											case 4:
												ptIns = val4;
												break;
											case 1:
												ptIns = val;
												break;
											case 2:
												ptIns = val2;
												break;
											case 3:
												ptIns = val3;
												break;
											}
										}
									}
									else
									{
										ptIns = new Point3d(ptIns.X, ptIns.Y - num3, 0.0);
									}
								}
								DeclaracoesInterligacao.borneAranha bn = new DeclaracoesInterligacao.borneAranha
								{
									Revisao = LfiLWCpBu5,
									Painel = K1DLpQ0OWN,
									Tag = text,
									NRegua = text2,
									Borne = structureRI.Bornes[num11].Borne,
									TipoBorne = structureRI.Bornes[num11].TipoBorne,
									Ordem = structureRI.Bornes[num11].Ordem,
									Posicao = num5
								};
								string text5 = "";
								text5 = ((bn.TipoBorne == 0) ? "BorneSimples.DWG" : "BorneDuplo.DWG");
								if (!File.Exists(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + eMmLhB0KQG.diretorio + text5))
								{
									break;
								}
								if (num2 == 0)
								{
									bInsereNomeRegua = true;
								}
								clsDICemig.InserirBorneAranha(text5, bn, ptIns, bInsereNomeRegua, ref eMmLhB0KQG);
								bInsereNomeRegua = false;
								if (bn.TipoBorne != 0)
								{
									if (bn.TipoBorne == 1)
									{
										num2 += 2;
										num3 = 16.0;
									}
								}
								else
								{
									num2++;
									num3 = 8.0;
								}
							}
							num11++;
							continue;
						}
						goto IL_0728;
						IL_0728:
						DeclaracoesGeral._uscPagina.CarregaPG();
						return;
					}
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
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
				wh5jGT1csZ();
				Application.UpdateScreen();
			}
		}
	}

	private void fDFjd8aiem(object P_0, EventArgs P_1)
	{
		string tag = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
		string nRegua = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
		clsDICemig.ApagaRegua(LfiLWCpBu5, K1DLpQ0OWN, tag, nRegua);
		wh5jGT1csZ();
		Application.UpdateScreen();
	}

	private void rhkjf4xHdt(object P_0, EventArgs P_1)
	{
		string rev = "";
		int painel = 0;
		checked
		{
			if (clsDICemig.SelecionaBorne(ref rev, ref painel))
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

	private void DPZjDrLPc4(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.jumper[] mJumpers = new DeclaracoesInterligacao.jumper[1];
		if (!clsDICemig.CarregaBornesJ(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ))
		{
			return;
		}
		clsDICemig.BuscaJumpers(ref mBornesJ, ref mJumpers, ref XNlj9mcaVA);
		clsDICemig.ApagaJumper(LfiLWCpBu5, K1DLpQ0OWN);
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
					clsDICemig.DesenhaJumper2(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ, ref mJumpers, i, ref eMmLhB0KQG);
				}
			}
			else
			{
				clsDICemig.DesenhaJumper1(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ, ref mJumpers, i);
			}
		}
		Application.UpdateScreen();
	}

	private void rOyjviuxI1(object P_0, EventArgs P_1)
	{
		clsDICemig.ApagaJumper(LfiLWCpBu5, K1DLpQ0OWN);
		Application.UpdateScreen();
	}

	private void DVNj6gLTMY(object P_0, EventArgs P_1)
	{
		clsDICemig.EspelhaJumperLeft();
		Application.UpdateScreen();
	}

	private void l3ejt1KHhg(object P_0, EventArgs P_1)
	{
		formataDGEsquerda();
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		List<string> lPaineis = new List<string>();
		if (!clsDICemig.CarregaBornesJ(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ))
		{
			return;
		}
		clsDICemig.CarregaEquipamentos5(ref XNlj9mcaVA, ref mBornesJ, ref lPaineis);
		lPaineis.Sort();
		if (lPaineis.Count <= 0)
		{
			return;
		}
		foreach (string item in lPaineis)
		{
			dgEsquerda.Rows.Add(item);
		}
	}

	private void TjtjjCjlKn(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		List<string> list = new List<string>();
		if (!clsDICemig.CarregaBornesJ(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ))
		{
			return;
		}
		checked
		{
			if (dgEsquerda.Rows.Count > 0)
			{
				int num = dgEsquerda.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					list.Add(Conversions.ToString(dgEsquerda.Rows[i].Cells[0].Value));
				}
			}
			clsDICemig.CarregaCabosInseridos(LfiLWCpBu5, K1DLpQ0OWN, ref lCabosInseridos);
			clsDICemig.CarregaCabos(LfiLWCpBu5, ref XNlj9mcaVA, ref mBornesJ, ref mCabos, list);
			clsDICemig.InsereCabos(LfiLWCpBu5, K1DLpQ0OWN, ref mCabos, lCabosInseridos, ref eMmLhB0KQG);
			Application.UpdateScreen();
		}
	}

	private void iIqjLvg1rh(object P_0, EventArgs P_1)
	{
		clsDICemig.ApagaCabos(LfiLWCpBu5, K1DLpQ0OWN);
		clsDICemig.ApagaVeias(LfiLWCpBu5, K1DLpQ0OWN);
		Application.UpdateScreen();
	}

	private void iC0jwTZK8U(object P_0, EventArgs P_1)
	{
		btVeias.Enabled = false;
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias = new DeclaracoesInterligacao.cruzamentoCaboAranha[1];
		if (clsDICemig.CarregaBornesJ(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ))
		{
			clsDICemig.AtualizaBornesJ(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ);
			clsDICemig.CarregaCabosInseridosViaVeias(LfiLWCpBu5, K1DLpQ0OWN, ref lCabosInseridos);
			clsDICemig.CarregaCabosDWG(LfiLWCpBu5, K1DLpQ0OWN, ref mCabos);
			clsDICemig.RelacionaCabosBornes(K1DLpQ0OWN, ref XNlj9mcaVA, ref mBornesJ, ref mCabos);
			clsDICemig.VerificaErro(mCabos);
			clsDICemig.InsereVeias(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos, ref eMmLhB0KQG);
			clsDICemig.InsereVeias2(LfiLWCpBu5, K1DLpQ0OWN, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos, ref eMmLhB0KQG);
			Application.UpdateScreen();
		}
		btVeias.Enabled = true;
	}

	private void miXjxZSpFP(object P_0, EventArgs P_1)
	{
		clsDICemig.ApagaVeias(LfiLWCpBu5, K1DLpQ0OWN);
		Application.UpdateScreen();
	}

	private void dF0jbab1hm(object P_0, EventArgs P_1)
	{
		if (!rbC.Checked)
		{
			btEsquerda.Enabled = false;
			btMirrorJumperDown.Enabled = false;
		}
		else
		{
			btEsquerda.Enabled = true;
			btMirrorJumperDown.Enabled = true;
		}
	}

	private void g7BjMIf6bR(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.caboSync[] mCabosSync = new DeclaracoesInterligacao.caboSync[1];
		DeclaracoesInterligacao.caboSync[] mTodosCabosSync = new DeclaracoesInterligacao.caboSync[1];
		cDadosAccess.carregaDadosDWG();
		clsDICemig.CarregaTodosCabosDWG(LfiLWCpBu5, ref mCabosSync);
		List<int> lPn = new List<int>();
		int num = Information.UBound(mCabosSync);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!lPn.Contains(mCabosSync[i].Painel))
			{
				lPn.Add(mCabosSync[i].Painel);
			}
		}
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		cDadosAccessInterligacao3.ApagaCabosRevPn(LfiLWCpBu5, ref lPn);
		cDadosAccessInterligacao3.exportaCabos(LfiLWCpBu5, ref mCabosSync);
		cDadosAccessInterligacao3.leCabos(LfiLWCpBu5, ref mTodosCabosSync);
		clsDICemig.LimpaCruzamentoCabos();
		clsDICemig.SincronizaCabos(LfiLWCpBu5, mTodosCabosSync);
		cDadosAccessInterligacao3.fechaConexao();
		Application.UpdateScreen();
	}

	private void uIvjOIkcWF(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1899]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
			cDadosAtualizaBanco2.ApagaAranha4();
			cDadosAtualizaBanco2.fechaConexao();
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
				MbQLJbiRX8 = true;
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
				MbQLJbiRX8 = false;
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

	public void formataDGEsquerda()
	{
		checked
		{
			try
			{
				dgEsquerda.Rows.Clear();
				dgEsquerda.Columns.Clear();
				dgEsquerda.Columns.Add("", "Nome");
				float num = dgEsquerda.Width - 22;
				dgEsquerda.Columns[0].Width = (int)Math.Round(num);
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
