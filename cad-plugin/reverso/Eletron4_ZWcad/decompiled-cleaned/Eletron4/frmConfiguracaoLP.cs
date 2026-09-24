using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmConfiguracaoLP : Form
{
	private IContainer jJKsa1qrJT;

	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private FolderBrowserDialog pHOs8VUaMn;

	[AccessedThroughProperty("GroupBox4")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox FHxsNjwBre;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbListaDePontos")]
	private TextBox Hy2sFvOkIk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SelLP")]
	private Button BMVsQKm24q;

	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label C69sPEo1gk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private GroupBox VYusc69oee;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label5")]
	private Label cK0sK9RBtn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label6")]
	private Label dnkseJUbus;

	[AccessedThroughProperty("Label7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label csZs2Mc2pZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label4")]
	private Label LrBs3VJuYx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private Label oCFsn0wl8f;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label gpEs11Jpvy;

	[AccessedThroughProperty("Label10")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label gBpslg9YGI;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox rhys5D6X0i;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label14")]
	private Label Rqxs0NqdmT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label15")]
	private Label lWcsRXoaDU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label16")]
	private Label HaRsm6t8p5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label17")]
	private Label dlFsXvr7j7;

	[AccessedThroughProperty("Label18")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label HC6sUwsB24;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvar")]
	private Button cTBsyLkP8c;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbDescricaoResumida")]
	private ComboBox yYWsgPwBRP;

	[AccessedThroughProperty("cbTipoDeSinal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox cxmsAf6cS6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTag")]
	private ComboBox M3csscJ9O5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbUnidade")]
	private ComboBox FkusB1wCtt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("cbChavePrimaria")]
	private ComboBox EHNsViegHO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbEFC")]
	private ComboBox FECsu0JERZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbDescricaoCompleta")]
	private ComboBox UVisEMTh3P;

	[AccessedThroughProperty("cbPosicaoLogico")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox YLRsZv1Vif;

	[CompilerGenerated]
	[AccessedThroughProperty("cbDocumentoLogico")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox Ob7siv4KLr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPosicaoFuncional")]
	[CompilerGenerated]
	private ComboBox hj7sSOHcHd;

	[AccessedThroughProperty("cbDocumentoFuncional")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox N6Hs49jpfC;

	[CompilerGenerated]
	[AccessedThroughProperty("btAtualizar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button fHAsCFu4Op;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbWorkSheet")]
	[CompilerGenerated]
	private ComboBox UAUsYIHuFB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbFuncaoPorta")]
	private ComboBox u4Lsru8rTO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelFuncao")]
	private Label emOs9WRsEZ;

	private string[] Q3WszdY8Wg;

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return FHxsNjwBre;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FHxsNjwBre = value;
		}
	}

	internal virtual TextBox tbListaDePontos
	{
		[CompilerGenerated]
		get
		{
			return Hy2sFvOkIk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Hy2sFvOkIk = value;
		}
	}

	internal virtual Button SelLP
	{
		[CompilerGenerated]
		get
		{
			return BMVsQKm24q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XZRsIZvumB;
			Button button = BMVsQKm24q;
			if (button != null)
			{
				button.Click -= value2;
			}
			BMVsQKm24q = value;
			button = BMVsQKm24q;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return C69sPEo1gk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			C69sPEo1gk = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return VYusc69oee;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VYusc69oee = value;
		}
	}

	internal virtual Label Label5
	{
		[CompilerGenerated]
		get
		{
			return cK0sK9RBtn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cK0sK9RBtn = value;
		}
	}

	internal virtual Label Label6
	{
		[CompilerGenerated]
		get
		{
			return dnkseJUbus;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dnkseJUbus = value;
		}
	}

	internal virtual Label Label7
	{
		[CompilerGenerated]
		get
		{
			return csZs2Mc2pZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			csZs2Mc2pZ = value;
		}
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return LrBs3VJuYx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LrBs3VJuYx = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return oCFsn0wl8f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oCFsn0wl8f = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return gpEs11Jpvy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gpEs11Jpvy = value;
		}
	}

	internal virtual Label Label10
	{
		[CompilerGenerated]
		get
		{
			return gBpslg9YGI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gBpslg9YGI = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return rhys5D6X0i;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rhys5D6X0i = value;
		}
	}

	internal virtual Label Label14
	{
		[CompilerGenerated]
		get
		{
			return Rqxs0NqdmT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Rqxs0NqdmT = value;
		}
	}

	internal virtual Label Label15
	{
		[CompilerGenerated]
		get
		{
			return lWcsRXoaDU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lWcsRXoaDU = value;
		}
	}

	internal virtual Label Label16
	{
		[CompilerGenerated]
		get
		{
			return HaRsm6t8p5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HaRsm6t8p5 = value;
		}
	}

	internal virtual Label Label17
	{
		[CompilerGenerated]
		get
		{
			return dlFsXvr7j7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dlFsXvr7j7 = value;
		}
	}

	internal virtual Label Label18
	{
		[CompilerGenerated]
		get
		{
			return HC6sUwsB24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HC6sUwsB24 = value;
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return cTBsyLkP8c;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sbusOY3uXJ;
			Button button = cTBsyLkP8c;
			if (button != null)
			{
				button.Click -= value2;
			}
			cTBsyLkP8c = value;
			button = cTBsyLkP8c;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox cbDescricaoResumida
	{
		[CompilerGenerated]
		get
		{
			return yYWsgPwBRP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yYWsgPwBRP = value;
		}
	}

	internal virtual ComboBox cbTipoDeSinal
	{
		[CompilerGenerated]
		get
		{
			return cxmsAf6cS6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cxmsAf6cS6 = value;
		}
	}

	internal virtual ComboBox cbTag
	{
		[CompilerGenerated]
		get
		{
			return M3csscJ9O5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			M3csscJ9O5 = value;
		}
	}

	internal virtual ComboBox cbUnidade
	{
		[CompilerGenerated]
		get
		{
			return FkusB1wCtt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FkusB1wCtt = value;
		}
	}

	internal virtual ComboBox cbChavePrimaria
	{
		[CompilerGenerated]
		get
		{
			return EHNsViegHO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EHNsViegHO = value;
		}
	}

	internal virtual ComboBox cbEFC
	{
		[CompilerGenerated]
		get
		{
			return FECsu0JERZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FECsu0JERZ = value;
		}
	}

	internal virtual ComboBox cbDescricaoCompleta
	{
		[CompilerGenerated]
		get
		{
			return UVisEMTh3P;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UVisEMTh3P = value;
		}
	}

	internal virtual ComboBox cbPosicaoLogico
	{
		[CompilerGenerated]
		get
		{
			return YLRsZv1Vif;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YLRsZv1Vif = value;
		}
	}

	internal virtual ComboBox cbDocumentoLogico
	{
		[CompilerGenerated]
		get
		{
			return Ob7siv4KLr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ob7siv4KLr = value;
		}
	}

	internal virtual ComboBox cbPosicaoFuncional
	{
		[CompilerGenerated]
		get
		{
			return hj7sSOHcHd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hj7sSOHcHd = value;
		}
	}

	internal virtual ComboBox cbDocumentoFuncional
	{
		[CompilerGenerated]
		get
		{
			return N6Hs49jpfC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			N6Hs49jpfC = value;
		}
	}

	internal virtual Button btAtualizar
	{
		[CompilerGenerated]
		get
		{
			return fHAsCFu4Op;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = riNs7QN0Pw;
			Button button = fHAsCFu4Op;
			if (button != null)
			{
				button.Click -= value2;
			}
			fHAsCFu4Op = value;
			button = fHAsCFu4Op;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox cbWorkSheet
	{
		[CompilerGenerated]
		get
		{
			return UAUsYIHuFB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UAUsYIHuFB = value;
		}
	}

	internal virtual ComboBox cbFuncaoPorta
	{
		[CompilerGenerated]
		get
		{
			return u4Lsru8rTO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			u4Lsru8rTO = value;
		}
	}

	internal virtual Label LabelFuncao
	{
		[CompilerGenerated]
		get
		{
			return emOs9WRsEZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			emOs9WRsEZ = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && jJKsa1qrJT != null)
			{
				jJKsa1qrJT.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void jSOsLOWgJd()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmConfiguracaoLP));
		aHypBEW66iS(new FolderBrowserDialog());
		GroupBox4 = new GroupBox();
		cbWorkSheet = new ComboBox();
		btAtualizar = new Button();
		Label1 = new Label();
		tbListaDePontos = new TextBox();
		SelLP = new Button();
		GroupBox1 = new GroupBox();
		cbDescricaoCompleta = new ComboBox();
		cbEFC = new ComboBox();
		cbDescricaoResumida = new ComboBox();
		cbTipoDeSinal = new ComboBox();
		cbTag = new ComboBox();
		Label10 = new Label();
		cbUnidade = new ComboBox();
		cbChavePrimaria = new ComboBox();
		Label5 = new Label();
		Label6 = new Label();
		Label7 = new Label();
		Label4 = new Label();
		Label3 = new Label();
		Label2 = new Label();
		GroupBox2 = new GroupBox();
		Label16 = new Label();
		Label14 = new Label();
		Label17 = new Label();
		cbPosicaoLogico = new ComboBox();
		Label15 = new Label();
		cbDocumentoFuncional = new ComboBox();
		cbPosicaoFuncional = new ComboBox();
		cbDocumentoLogico = new ComboBox();
		Label18 = new Label();
		btSalvar = new Button();
		cbFuncaoPorta = new ComboBox();
		LabelFuncao = new Label();
		GroupBox4.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		GroupBox4.Controls.Add(cbWorkSheet);
		GroupBox4.Controls.Add(btAtualizar);
		GroupBox4.Controls.Add(Label1);
		GroupBox4.Controls.Add(tbListaDePontos);
		GroupBox4.Controls.Add(SelLP);
		GroupBox4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GroupBox4.Location = new Point(12, 12);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(332, 112);
		GroupBox4.TabIndex = 17;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Lista de Pontos";
		cbWorkSheet.FormattingEnabled = true;
		cbWorkSheet.Location = new Point(139, 76);
		cbWorkSheet.Name = "cbWorkSheet";
		cbWorkSheet.Size = new Size(140, 21);
		cbWorkSheet.TabIndex = 37;
		btAtualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btAtualizar.FlatStyle = FlatStyle.Flat;
		btAtualizar.ForeColor = SystemColors.Control;
		btAtualizar.Image = Resources.Update_32;
		btAtualizar.Location = new Point(285, 63);
		btAtualizar.Name = "btAtualizar";
		btAtualizar.Size = new Size(36, 36);
		btAtualizar.TabIndex = 36;
		btAtualizar.UseVisualStyleBackColor = true;
		Label1.Location = new Point(6, 76);
		Label1.Name = "Label1";
		Label1.Size = new Size(127, 23);
		Label1.TabIndex = 23;
		Label1.Text = "Worksheet: ";
		Label1.TextAlign = ContentAlignment.MiddleRight;
		tbListaDePontos.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbListaDePontos.Location = new Point(6, 19);
		tbListaDePontos.Multiline = true;
		tbListaDePontos.Name = "tbListaDePontos";
		tbListaDePontos.Size = new Size(273, 45);
		tbListaDePontos.TabIndex = 1;
		SelLP.FlatStyle = FlatStyle.Flat;
		SelLP.ForeColor = SystemColors.Control;
		SelLP.Image = (Image)componentResourceManager.GetObject("SelLP.Image");
		SelLP.Location = new Point(285, 19);
		SelLP.Name = "SelLP";
		SelLP.Size = new Size(36, 36);
		SelLP.TabIndex = 35;
		SelLP.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(cbFuncaoPorta);
		GroupBox1.Controls.Add(LabelFuncao);
		GroupBox1.Controls.Add(cbDescricaoCompleta);
		GroupBox1.Controls.Add(cbEFC);
		GroupBox1.Controls.Add(cbDescricaoResumida);
		GroupBox1.Controls.Add(cbTipoDeSinal);
		GroupBox1.Controls.Add(cbTag);
		GroupBox1.Controls.Add(Label10);
		GroupBox1.Controls.Add(cbUnidade);
		GroupBox1.Controls.Add(cbChavePrimaria);
		GroupBox1.Controls.Add(Label5);
		GroupBox1.Controls.Add(Label6);
		GroupBox1.Controls.Add(Label7);
		GroupBox1.Controls.Add(Label4);
		GroupBox1.Controls.Add(Label3);
		GroupBox1.Controls.Add(Label2);
		GroupBox1.Location = new Point(12, 153);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(332, 180);
		GroupBox1.TabIndex = 18;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		cbDescricaoCompleta.FormattingEnabled = true;
		cbDescricaoCompleta.Location = new Point(221, 99);
		cbDescricaoCompleta.Name = "cbDescricaoCompleta";
		cbDescricaoCompleta.Size = new Size(100, 21);
		cbDescricaoCompleta.TabIndex = 33;
		cbEFC.BackColor = Color.PaleTurquoise;
		cbEFC.FormattingEnabled = true;
		cbEFC.Location = new Point(221, 45);
		cbEFC.Name = "cbEFC";
		cbEFC.Size = new Size(100, 21);
		cbEFC.TabIndex = 32;
		cbDescricaoResumida.BackColor = Color.PaleTurquoise;
		cbDescricaoResumida.FormattingEnabled = true;
		cbDescricaoResumida.Location = new Point(115, 99);
		cbDescricaoResumida.Name = "cbDescricaoResumida";
		cbDescricaoResumida.Size = new Size(100, 21);
		cbDescricaoResumida.TabIndex = 30;
		cbTipoDeSinal.FormattingEnabled = true;
		cbTipoDeSinal.Location = new Point(9, 153);
		cbTipoDeSinal.Name = "cbTipoDeSinal";
		cbTipoDeSinal.Size = new Size(100, 21);
		cbTipoDeSinal.TabIndex = 31;
		cbTag.FormattingEnabled = true;
		cbTag.Location = new Point(115, 45);
		cbTag.Name = "cbTag";
		cbTag.Size = new Size(100, 21);
		cbTag.TabIndex = 28;
		Label10.Location = new Point(6, 120);
		Label10.Name = "Label10";
		Label10.Size = new Size(100, 30);
		Label10.TabIndex = 36;
		Label10.Text = "Tipo de Sinal";
		Label10.TextAlign = ContentAlignment.BottomLeft;
		cbUnidade.BackColor = Color.PaleTurquoise;
		cbUnidade.FormattingEnabled = true;
		cbUnidade.Location = new Point(9, 99);
		cbUnidade.Name = "cbUnidade";
		cbUnidade.Size = new Size(100, 21);
		cbUnidade.TabIndex = 29;
		cbChavePrimaria.BackColor = Color.PaleTurquoise;
		cbChavePrimaria.FormattingEnabled = true;
		cbChavePrimaria.Location = new Point(9, 45);
		cbChavePrimaria.Name = "cbChavePrimaria";
		cbChavePrimaria.Size = new Size(100, 21);
		cbChavePrimaria.TabIndex = 27;
		Label5.Location = new Point(218, 66);
		Label5.Name = "Label5";
		Label5.Size = new Size(100, 30);
		Label5.TabIndex = 34;
		Label5.Text = "Descrição Completa";
		Label5.TextAlign = ContentAlignment.BottomLeft;
		Label6.Location = new Point(115, 66);
		Label6.Name = "Label6";
		Label6.Size = new Size(100, 30);
		Label6.TabIndex = 32;
		Label6.Text = "Descrição Resumida";
		Label6.TextAlign = ContentAlignment.BottomLeft;
		Label7.Location = new Point(6, 66);
		Label7.Name = "Label7";
		Label7.Size = new Size(100, 30);
		Label7.TabIndex = 30;
		Label7.Text = "Unidade";
		Label7.TextAlign = ContentAlignment.BottomLeft;
		Label4.Location = new Point(221, 12);
		Label4.Name = "Label4";
		Label4.Size = new Size(100, 30);
		Label4.TabIndex = 28;
		Label4.Text = "Endereço Físico";
		Label4.TextAlign = ContentAlignment.BottomLeft;
		Label3.Location = new Point(112, 12);
		Label3.Name = "Label3";
		Label3.Size = new Size(100, 30);
		Label3.TabIndex = 26;
		Label3.Text = "Tag";
		Label3.TextAlign = ContentAlignment.BottomLeft;
		Label2.Location = new Point(6, 12);
		Label2.Name = "Label2";
		Label2.Size = new Size(100, 30);
		Label2.TabIndex = 24;
		Label2.Text = "Chave Primária";
		Label2.TextAlign = ContentAlignment.BottomLeft;
		GroupBox2.Controls.Add(Label16);
		GroupBox2.Controls.Add(Label14);
		GroupBox2.Controls.Add(Label17);
		GroupBox2.Controls.Add(cbPosicaoLogico);
		GroupBox2.Controls.Add(Label15);
		GroupBox2.Controls.Add(cbDocumentoFuncional);
		GroupBox2.Controls.Add(cbPosicaoFuncional);
		GroupBox2.Controls.Add(cbDocumentoLogico);
		GroupBox2.Location = new Point(12, 340);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(334, 129);
		GroupBox2.TabIndex = 19;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		Label16.Location = new Point(165, 66);
		Label16.Name = "Label16";
		Label16.Size = new Size(150, 28);
		Label16.TabIndex = 34;
		Label16.Text = "Posição Lógico";
		Label16.TextAlign = ContentAlignment.BottomLeft;
		Label14.Location = new Point(6, 66);
		Label14.Name = "Label14";
		Label14.Size = new Size(150, 28);
		Label14.TabIndex = 30;
		Label14.Text = "Posição Funcional";
		Label14.TextAlign = ContentAlignment.BottomLeft;
		Label17.Location = new Point(169, 12);
		Label17.Name = "Label17";
		Label17.Size = new Size(150, 28);
		Label17.TabIndex = 32;
		Label17.Text = "Documento Lógico";
		Label17.TextAlign = ContentAlignment.BottomLeft;
		cbPosicaoLogico.BackColor = Color.PaleTurquoise;
		cbPosicaoLogico.FormattingEnabled = true;
		cbPosicaoLogico.Location = new Point(165, 97);
		cbPosicaoLogico.Name = "cbPosicaoLogico";
		cbPosicaoLogico.Size = new Size(150, 21);
		cbPosicaoLogico.TabIndex = 45;
		Label15.Location = new Point(6, 12);
		Label15.Name = "Label15";
		Label15.Size = new Size(150, 28);
		Label15.TabIndex = 28;
		Label15.Text = "Documento Funcional";
		Label15.TextAlign = ContentAlignment.BottomLeft;
		cbDocumentoFuncional.BackColor = Color.PaleTurquoise;
		cbDocumentoFuncional.FormattingEnabled = true;
		cbDocumentoFuncional.Location = new Point(9, 45);
		cbDocumentoFuncional.Name = "cbDocumentoFuncional";
		cbDocumentoFuncional.Size = new Size(150, 21);
		cbDocumentoFuncional.TabIndex = 42;
		cbPosicaoFuncional.BackColor = Color.PaleTurquoise;
		cbPosicaoFuncional.FormattingEnabled = true;
		cbPosicaoFuncional.Location = new Point(9, 99);
		cbPosicaoFuncional.Name = "cbPosicaoFuncional";
		cbPosicaoFuncional.Size = new Size(150, 21);
		cbPosicaoFuncional.TabIndex = 43;
		cbDocumentoLogico.BackColor = Color.PaleTurquoise;
		cbDocumentoLogico.FormattingEnabled = true;
		cbDocumentoLogico.Location = new Point(165, 45);
		cbDocumentoLogico.Name = "cbDocumentoLogico";
		cbDocumentoLogico.Size = new Size(150, 21);
		cbDocumentoLogico.TabIndex = 44;
		Label18.BackColor = Color.PaleTurquoise;
		Label18.BorderStyle = BorderStyle.FixedSingle;
		Label18.Location = new Point(211, 127);
		Label18.Name = "Label18";
		Label18.Size = new Size(127, 23);
		Label18.TabIndex = 24;
		Label18.Text = "Campos Obrigatórios";
		Label18.TextAlign = ContentAlignment.MiddleCenter;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = (Image)componentResourceManager.GetObject("btSalvar.Image");
		btSalvar.Location = new Point(151, 475);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 25;
		btSalvar.UseVisualStyleBackColor = true;
		cbFuncaoPorta.FormattingEnabled = true;
		cbFuncaoPorta.Location = new Point(115, 153);
		cbFuncaoPorta.Name = "cbFuncaoPorta";
		cbFuncaoPorta.Size = new Size(100, 21);
		cbFuncaoPorta.TabIndex = 37;
		LabelFuncao.Location = new Point(112, 120);
		LabelFuncao.Name = "LabelFuncao";
		LabelFuncao.Size = new Size(100, 30);
		LabelFuncao.TabIndex = 38;
		LabelFuncao.Text = "lbFunção da Porta";
		LabelFuncao.TextAlign = ContentAlignment.BottomLeft;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(359, 521);
		Controls.Add(btSalvar);
		Controls.Add(Label18);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox4);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(375, 560);
		MinimizeBox = false;
		MinimumSize = new Size(375, 560);
		Name = "frmConfiguracaoLP";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Configuração Lista de Pontos";
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return pHOs8VUaMn;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		pHOs8VUaMn = WithEventsValue;
	}

	public frmConfiguracaoLP()
	{
		jSOsLOWgJd();
		Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 238]);
		GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 239]);
		GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 240]);
		GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 242]);
		Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 243]);
		Label4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 244]);
		Label7.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 245]);
		Label6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
		Label5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 247]);
		Label10.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 248]);
		Label15.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 253]);
		Label14.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 254]);
		Label17.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 255]);
		Label16.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 256]);
		Label18.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 257]);
		LabelFuncao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1702]);
		SelLP.Image = Resources.Excel_32;
		if (XDataGeral.LerXDataConfiguracaoListaDePontos())
		{
			if (Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0 && File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
			{
				if (Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
					return;
				}
				aFisq0fwYk();
				if (Operators.CompareString(DeclaracoesGeral.ConfLP.worksheet, "", TextCompare: true) != 0)
				{
					FhEsxrrnIO();
				}
			}
			wJwsw7f6OD();
		}
		tbListaDePontos.BackColor = Color.White;
		if (Operators.CompareString(tbListaDePontos.Text, "", TextCompare: true) != 0 && !File.Exists(tbListaDePontos.Text))
		{
			tbListaDePontos.BackColor = Color.LightCoral;
		}
		Application.ShowModelessDialog((Form)this);
		if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
		{
			Left = 0;
		}
	}

	private bool wJwsw7f6OD()
	{
		bool result;
		try
		{
			DKFsbI95dx();
			tbListaDePontos.Text = DeclaracoesGeral.ConfLP.listaDePontos;
			cbWorkSheet.Text = DeclaracoesGeral.ConfLP.worksheet;
			cbChavePrimaria.Text = DeclaracoesGeral.ConfLP.chavePrimaria;
			cbTag.Text = DeclaracoesGeral.ConfLP.tag;
			cbDescricaoResumida.Text = DeclaracoesGeral.ConfLP.descricaoResumida;
			cbDescricaoCompleta.Text = DeclaracoesGeral.ConfLP.descricaoCompleta;
			cbTipoDeSinal.Text = DeclaracoesGeral.ConfLP.tipoDeSinal;
			cbUnidade.Text = DeclaracoesGeral.ConfLP.unidade;
			cbEFC.Text = DeclaracoesGeral.ConfLP.enderecoFisico;
			cbPosicaoLogico.Text = DeclaracoesGeral.ConfLP.posicaoLogico;
			cbPosicaoFuncional.Text = DeclaracoesGeral.ConfLP.posicaoFuncional;
			cbDocumentoFuncional.Text = DeclaracoesGeral.ConfLP.documentoFuncional;
			cbDocumentoLogico.Text = DeclaracoesGeral.ConfLP.documentoLogico;
			cbFuncaoPorta.Text = DeclaracoesGeral.ConfLP.funcaoPorta;
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void FhEsxrrnIO()
	{
		try
		{
			DKFsbI95dx();
			Q3WszdY8Wg = new string[1];
			Q3WszdY8Wg[0] = "";
			if (!XDataGeral.LerXDataConfiguracaoListaDePontos())
			{
				return;
			}
			if (Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0)
			{
				tbListaDePontos.BackColor = Color.White;
				if (File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					cDadosExcel cDadosExcel2 = new cDadosExcel();
					cDadosExcel2.CarregaColunasDaWS(ref Q3WszdY8Wg, cbWorkSheet.Text);
					cDadosExcel2.fechaConexao();
					int num = Information.UBound(Q3WszdY8Wg);
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						cbChavePrimaria.Items.Add(Q3WszdY8Wg[i]);
						cbTag.Items.Add(Q3WszdY8Wg[i]);
						cbDescricaoResumida.Items.Add(Q3WszdY8Wg[i]);
						cbDescricaoCompleta.Items.Add(Q3WszdY8Wg[i]);
						cbTipoDeSinal.Items.Add(Q3WszdY8Wg[i]);
						cbUnidade.Items.Add(Q3WszdY8Wg[i]);
						cbEFC.Items.Add(Q3WszdY8Wg[i]);
						cbPosicaoLogico.Items.Add(Q3WszdY8Wg[i]);
						cbPosicaoFuncional.Items.Add(Q3WszdY8Wg[i]);
						cbDocumentoFuncional.Items.Add(Q3WszdY8Wg[i]);
						cbDocumentoLogico.Items.Add(Q3WszdY8Wg[i]);
						cbFuncaoPorta.Items.Add(Q3WszdY8Wg[i]);
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.chavePrimaria))
					{
						cbChavePrimaria.Text = "";
					}
					else
					{
						cbChavePrimaria.Text = DeclaracoesGeral.ConfLP.chavePrimaria;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.tag))
					{
						cbTag.Text = "";
					}
					else
					{
						cbTag.Text = DeclaracoesGeral.ConfLP.tag;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.descricaoResumida))
					{
						cbDescricaoResumida.Text = "";
					}
					else
					{
						cbDescricaoResumida.Text = DeclaracoesGeral.ConfLP.descricaoResumida;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.descricaoCompleta))
					{
						cbDescricaoCompleta.Text = "";
					}
					else
					{
						cbDescricaoCompleta.Text = DeclaracoesGeral.ConfLP.descricaoCompleta;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.tipoDeSinal))
					{
						cbTipoDeSinal.Text = "";
					}
					else
					{
						cbTipoDeSinal.Text = DeclaracoesGeral.ConfLP.tipoDeSinal;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.unidade))
					{
						cbUnidade.Text = "";
					}
					else
					{
						cbUnidade.Text = DeclaracoesGeral.ConfLP.unidade;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.enderecoFisico))
					{
						cbEFC.Text = "";
					}
					else
					{
						cbEFC.Text = DeclaracoesGeral.ConfLP.enderecoFisico;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.posicaoLogico))
					{
						cbPosicaoLogico.Text = "";
					}
					else
					{
						cbPosicaoLogico.Text = DeclaracoesGeral.ConfLP.posicaoLogico;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.posicaoFuncional))
					{
						cbPosicaoFuncional.Text = "";
					}
					else
					{
						cbPosicaoFuncional.Text = DeclaracoesGeral.ConfLP.posicaoFuncional;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.documentoFuncional))
					{
						cbDocumentoFuncional.Text = "";
					}
					else
					{
						cbDocumentoFuncional.Text = DeclaracoesGeral.ConfLP.documentoFuncional;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.documentoLogico))
					{
						cbDocumentoLogico.Text = "";
					}
					else
					{
						cbDocumentoLogico.Text = DeclaracoesGeral.ConfLP.documentoLogico;
					}
					if (!QI0sMDBnjQ(DeclaracoesGeral.ConfLP.funcaoPorta))
					{
						cbFuncaoPorta.Text = "";
					}
					else
					{
						cbFuncaoPorta.Text = DeclaracoesGeral.ConfLP.funcaoPorta;
					}
				}
				else
				{
					tbListaDePontos.BackColor = Color.LightCoral;
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 282]), MsgBoxStyle.Information);
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 281]), MsgBoxStyle.Information);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void DKFsbI95dx()
	{
		cbChavePrimaria.Items.Clear();
		cbTag.Items.Clear();
		cbDescricaoResumida.Items.Clear();
		cbDescricaoCompleta.Items.Clear();
		cbTipoDeSinal.Items.Clear();
		cbUnidade.Items.Clear();
		cbEFC.Items.Clear();
		cbPosicaoLogico.Items.Clear();
		cbPosicaoFuncional.Items.Clear();
		cbDocumentoFuncional.Items.Clear();
		cbDocumentoLogico.Items.Clear();
	}

	private bool QI0sMDBnjQ(string P_0)
	{
		bool result = false;
		int num = Information.UBound(Q3WszdY8Wg);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_0.ToString().Trim().ToUpper(), Q3WszdY8Wg[i].ToString().Trim().ToUpper(), TextCompare: true) == 0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void sbusOY3uXJ(object P_0, EventArgs P_1)
	{
		bool flag = true;
		tbListaDePontos.BackColor = Color.White;
		if (Operators.CompareString(tbListaDePontos.Text.Trim(), "", TextCompare: true) == 0)
		{
			tbListaDePontos.Text = "";
			cbWorkSheet.Text = "";
			cbChavePrimaria.Text = "";
			cbTag.Text = "";
			cbDescricaoResumida.Text = "";
			cbDescricaoCompleta.Text = "";
			cbTipoDeSinal.Text = "";
			cbUnidade.Text = "";
			cbEFC.Text = "";
			cbPosicaoLogico.Text = "";
			cbPosicaoFuncional.Text = "";
			cbDocumentoFuncional.Text = "";
			cbDocumentoLogico.Text = "";
			salvaconfiguracao();
			Close();
		}
		else
		{
			if (!File.Exists(tbListaDePontos.Text))
			{
				tbListaDePontos.BackColor = Color.LightCoral;
			}
			if (flag & (Operators.CompareString(tbListaDePontos.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(cbWorkSheet.Text.Trim(), "", TextCompare: true) != 0))
			{
				salvaconfiguracao();
				Close();
			}
		}
	}

	public void salvaconfiguracao()
	{
		try
		{
			DeclaracoesGeral.ConfLP.listaDePontos = tbListaDePontos.Text.Trim();
			DeclaracoesGeral.ConfLP.worksheet = cbWorkSheet.Text.Trim();
			DeclaracoesGeral.ConfLP.chavePrimaria = cbChavePrimaria.Text.Trim();
			DeclaracoesGeral.ConfLP.tag = cbTag.Text.Trim();
			DeclaracoesGeral.ConfLP.descricaoResumida = cbDescricaoResumida.Text.Trim();
			DeclaracoesGeral.ConfLP.descricaoCompleta = cbDescricaoCompleta.Text.Trim();
			DeclaracoesGeral.ConfLP.tipoDeSinal = cbTipoDeSinal.Text.Trim();
			DeclaracoesGeral.ConfLP.unidade = cbUnidade.Text.Trim();
			DeclaracoesGeral.ConfLP.enderecoFisico = cbEFC.Text.Trim();
			DeclaracoesGeral.ConfLP.posicaoLogico = cbPosicaoLogico.Text.Trim();
			DeclaracoesGeral.ConfLP.posicaoFuncional = cbPosicaoFuncional.Text.Trim();
			DeclaracoesGeral.ConfLP.documentoFuncional = cbDocumentoFuncional.Text.Trim();
			DeclaracoesGeral.ConfLP.documentoLogico = cbDocumentoLogico.Text.Trim();
			DeclaracoesGeral.ConfLP.funcaoPorta = cbFuncaoPorta.Text.Trim();
			XDataGeral.GravarXDataConfiguracaoListaDePontos();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 100]), MsgBoxStyle.Critical, "Elétron");
			ProjectData.ClearProjectError();
		}
	}

	private void XZRsIZvumB(object P_0, EventArgs P_1)
	{
		try
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 258]);
			openFileDialog.Filter = "Excel (*.xls; *.xlsx)|*.xls;*.xlsx";
			openFileDialog.DefaultExt = ".xls";
			openFileDialog.FileName = "";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ValidateNames = true;
			if (!openFileDialog.ShowDialog().Value)
			{
				return;
			}
			tbListaDePontos.Text = openFileDialog.FileName;
			bool flag = true;
			tbListaDePontos.BackColor = Color.White;
			if (Operators.CompareString(tbListaDePontos.Text, "", TextCompare: true) != 0 && !File.Exists(tbListaDePontos.Text))
			{
				tbListaDePontos.BackColor = Color.LightCoral;
				flag = false;
			}
			if (flag)
			{
				XDataGeral.LerXDataConfiguracaoListaDePontos();
				DeclaracoesGeral.ConfLP.listaDePontos = tbListaDePontos.Text;
				if (!Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					DKFsbI95dx();
					aFisq0fwYk();
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
					DeclaracoesGeral.ConfLP.listaDePontos = "";
					tbListaDePontos.Text = "";
				}
				btSalvar.Enabled = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	private void riNs7QN0Pw(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.ConfLP.worksheet = cbWorkSheet.Text;
		if ((Operators.CompareString(tbListaDePontos.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(cbWorkSheet.Text.Trim(), "", TextCompare: true) != 0))
		{
			salvaconfiguracao();
			FhEsxrrnIO();
			btSalvar.Enabled = true;
		}
	}

	private void aFisq0fwYk()
	{
		string[] mWS = new string[1];
		cDadosExcel cDadosExcel2 = new cDadosExcel();
		cDadosExcel2.leWorkSheets(ref mWS);
		cDadosExcel2.fechaConexao();
		cbWorkSheet.Items.Clear();
		cbWorkSheet.Text = "";
		int num = Information.UBound(mWS);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			cbWorkSheet.Items.Add(mWS[i]);
		}
	}
}
