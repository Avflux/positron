using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmGerenciadorMascaras : Form
{
	private IContainer RH9zz6SEuM;

	[CompilerGenerated]
	[AccessedThroughProperty("LBBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label LfRpWW1Gdi4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog ikCpWpa5cqw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBRegua")]
	private Label MqvpWTge7rc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBTerminais")]
	private Label anlpWJhd49Y;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip tKPpWhk0CcZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBBornes")]
	private TextBox lXIpWoDGxvA;

	[CompilerGenerated]
	[AccessedThroughProperty("TBRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox VZWpWGX3USB;

	[AccessedThroughProperty("TBTerminais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox SnDpWHTIVMm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBEF")]
	[CompilerGenerated]
	private Label wdtpWk4YJZw;

	[AccessedThroughProperty("TBEFC")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox fAppWd6aGcM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGPortasInseridas")]
	private DataGridView Sq8pWfBSu19;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTEditaPorta")]
	private Button FIgpWDsacpB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAdicionaPorta")]
	private Button vwXpWv0c0fa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTApagaPorta")]
	private Button fb6pW6TOmTT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTExportaEX")]
	private Button vtvpWtQ9Vfw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTImportaEX")]
	private Button sAapWj5ddiH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBModelo")]
	private TextBox eGUpWLBiwha;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbModelo")]
	private Label YJYpWwcvpqM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTEditaMascara")]
	private Button yGrpWxBH1rv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxMascara")]
	private GroupBox kJwpWb83Pqu;

	[AccessedThroughProperty("BTAdicionaMascara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button uUspWM8V3ev;

	[AccessedThroughProperty("BTApagaMascara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button TIlpWO74WIp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGMascaras")]
	private DataGridView xPrpWIXL1cB;

	[AccessedThroughProperty("GroupBoxPorta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox vsvpW7bSab0;

	[AccessedThroughProperty("DGPortas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView B6xpWqlySZp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btVerifica")]
	[CompilerGenerated]
	private Button PLNpWajwuM3;

	[CompilerGenerated]
	[AccessedThroughProperty("lbOrientacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label MhvpW8Ke2pN;

	[AccessedThroughProperty("TBOrientacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox wnjpWNPGtPd;

	[AccessedThroughProperty("btApagaModelosSemUso")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button G3MpWFL1Z7C;

	[CompilerGenerated]
	[AccessedThroughProperty("btPesquisaLM2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button b3ipWQlxRWT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisaLM1")]
	private Button qJTpWP2abTU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	private GroupBox DJqpWcGPXKO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox OH4pWKvyrU1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbTopografico")]
	private Label etlpWeXtMQQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbLayout")]
	private Label bdApW2mS3s6;

	[AccessedThroughProperty("btSelecionaBlocoTopo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button P3KpW3awEEE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBlocoLayout")]
	private TextBox SRvpWnJmC5V;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBlocoTopografico")]
	private TextBox RZspW1ABET1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecionaBlocoLayout")]
	private Button I1TpWlAtTIF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox AO3pW5HHfy7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbFabricante")]
	private Label wj1pW0KWpQF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label kFGpWRGbxBn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbDesc")]
	private Label hr8pWmmQQJi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbCodigo")]
	[CompilerGenerated]
	private Label wbFpWXJr80f;

	[CompilerGenerated]
	[AccessedThroughProperty("tbFabricante2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox zkbpWUCEoHT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFabricante1")]
	private TextBox w3FpWyDJ1NY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbModelo2")]
	[CompilerGenerated]
	private TextBox tmkpWgg5RJk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbModelo1")]
	private TextBox W36pWA05l2H;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricaoResum2")]
	private TextBox YF9pWsBYL2s;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDescricaoResum1")]
	private TextBox m63pWBPR26B;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCodigo2")]
	private TextBox VBVpWVQnss8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCodigo1")]
	private TextBox sOVpWuhLYf5;

	private DeclaracoesClonar.structureMaterial[] kigpWElRigI;

	private int L0FpWZgIhYI;

	private int B6qpWimJUPB;

	private Declaracoes2.MModeloDeMascara[] WMgpWSL2vjs;

	private Declaracoes2.MModeloDePortas[] UMrpW4fhjTY;

	private List<int> Nj5pWCKSi8n;

	internal virtual Label LBBornes
	{
		[CompilerGenerated]
		get
		{
			return LfRpWW1Gdi4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LfRpWW1Gdi4 = value;
		}
	}

	internal virtual Label LBRegua
	{
		[CompilerGenerated]
		get
		{
			return MqvpWTge7rc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MqvpWTge7rc = value;
		}
	}

	internal virtual Label LBTerminais
	{
		[CompilerGenerated]
		get
		{
			return anlpWJhd49Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			anlpWJhd49Y = value;
		}
	}

	internal virtual TextBox TBBornes
	{
		[CompilerGenerated]
		get
		{
			return lXIpWoDGxvA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = ntBzCD5ekH;
			TextBox textBox = lXIpWoDGxvA;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			lXIpWoDGxvA = value;
			textBox = lXIpWoDGxvA;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox TBRegua
	{
		[CompilerGenerated]
		get
		{
			return VZWpWGX3USB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = uCZz4vJgWO;
			TextBox textBox = VZWpWGX3USB;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			VZWpWGX3USB = value;
			textBox = VZWpWGX3USB;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox TBTerminais
	{
		[CompilerGenerated]
		get
		{
			return SnDpWHTIVMm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = smAziwxFyb;
			TextBox textBox = SnDpWHTIVMm;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			SnDpWHTIVMm = value;
			textBox = SnDpWHTIVMm;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LBEF
	{
		[CompilerGenerated]
		get
		{
			return wdtpWk4YJZw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wdtpWk4YJZw = value;
		}
	}

	internal virtual TextBox TBEFC
	{
		[CompilerGenerated]
		get
		{
			return fAppWd6aGcM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = nHazEVh24a;
			TextBox textBox = fAppWd6aGcM;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			fAppWd6aGcM = value;
			textBox = fAppWd6aGcM;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual DataGridView DGPortasInseridas
	{
		[CompilerGenerated]
		get
		{
			return Sq8pWfBSu19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = aCPzXlXRqO;
			KeyEventHandler value3 = w9QzUsrj70;
			KeyEventHandler value4 = fG1zyQ7rIO;
			DataGridView dataGridView = Sq8pWfBSu19;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyDown -= value3;
				dataGridView.KeyUp -= value4;
			}
			Sq8pWfBSu19 = value;
			dataGridView = Sq8pWfBSu19;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyDown += value3;
				dataGridView.KeyUp += value4;
			}
		}
	}

	internal virtual Button BTEditaPorta
	{
		[CompilerGenerated]
		get
		{
			return FIgpWDsacpB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = A4LzRhDe7G;
			Button button = FIgpWDsacpB;
			if (button != null)
			{
				button.Click -= value2;
			}
			FIgpWDsacpB = value;
			button = FIgpWDsacpB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAdicionaPorta
	{
		[CompilerGenerated]
		get
		{
			return vwXpWv0c0fa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VkAz0p6s2W;
			Button button = vwXpWv0c0fa;
			if (button != null)
			{
				button.Click -= value2;
			}
			vwXpWv0c0fa = value;
			button = vwXpWv0c0fa;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTApagaPorta
	{
		[CompilerGenerated]
		get
		{
			return fb6pW6TOmTT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bPwzmxwd1x;
			Button button = fb6pW6TOmTT;
			if (button != null)
			{
				button.Click -= value2;
			}
			fb6pW6TOmTT = value;
			button = fb6pW6TOmTT;
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
			return vtvpWtQ9Vfw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LkyzsPiIli;
			Button button = vtvpWtQ9Vfw;
			if (button != null)
			{
				button.Click -= value2;
			}
			vtvpWtQ9Vfw = value;
			button = vtvpWtQ9Vfw;
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
			return sAapWj5ddiH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ax3zAK8iX1;
			Button button = sAapWj5ddiH;
			if (button != null)
			{
				button.Click -= value2;
			}
			sAapWj5ddiH = value;
			button = sAapWj5ddiH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBModelo
	{
		[CompilerGenerated]
		get
		{
			return eGUpWLBiwha;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = GfjzB369Bt;
			TextBox textBox = eGUpWLBiwha;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			eGUpWLBiwha = value;
			textBox = eGUpWLBiwha;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LbModelo
	{
		[CompilerGenerated]
		get
		{
			return YJYpWwcvpqM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YJYpWwcvpqM = value;
		}
	}

	internal virtual Button BTEditaMascara
	{
		[CompilerGenerated]
		get
		{
			return yGrpWxBH1rv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RKnzeljMvI;
			Button button = yGrpWxBH1rv;
			if (button != null)
			{
				button.Click -= value2;
			}
			yGrpWxBH1rv = value;
			button = yGrpWxBH1rv;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBoxMascara
	{
		[CompilerGenerated]
		get
		{
			return kJwpWb83Pqu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kJwpWb83Pqu = value;
		}
	}

	internal virtual Button BTAdicionaMascara
	{
		[CompilerGenerated]
		get
		{
			return uUspWM8V3ev;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xLJzK0LgWn;
			Button button = uUspWM8V3ev;
			if (button != null)
			{
				button.Click -= value2;
			}
			uUspWM8V3ev = value;
			button = uUspWM8V3ev;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTApagaMascara
	{
		[CompilerGenerated]
		get
		{
			return TIlpWO74WIp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nWYz3oZQ0v;
			Button button = TIlpWO74WIp;
			if (button != null)
			{
				button.Click -= value2;
			}
			TIlpWO74WIp = value;
			button = TIlpWO74WIp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView DGMascaras
	{
		[CompilerGenerated]
		get
		{
			return xPrpWIXL1cB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = koDzFDQaDc;
			KeyEventHandler value3 = QKHzQROvrD;
			KeyEventHandler value4 = DH1zP5wfDT;
			DataGridView dataGridView = xPrpWIXL1cB;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyDown -= value3;
				dataGridView.KeyUp -= value4;
			}
			xPrpWIXL1cB = value;
			dataGridView = xPrpWIXL1cB;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyDown += value3;
				dataGridView.KeyUp += value4;
			}
		}
	}

	internal virtual GroupBox GroupBoxPorta
	{
		[CompilerGenerated]
		get
		{
			return vsvpW7bSab0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vsvpW7bSab0 = value;
		}
	}

	internal virtual DataGridView DGPortas
	{
		[CompilerGenerated]
		get
		{
			return B6xpWqlySZp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = y3rz1HDBB4;
			KeyEventHandler value3 = UKpzldmBqO;
			KeyEventHandler value4 = lqNz5kU0HM;
			DataGridView dataGridView = B6xpWqlySZp;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
			}
			B6xpWqlySZp = value;
			dataGridView = B6xpWqlySZp;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
			}
		}
	}

	internal virtual Button btVerifica
	{
		[CompilerGenerated]
		get
		{
			return PLNpWajwuM3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IEEzZjnYnA;
			Button button = PLNpWajwuM3;
			if (button != null)
			{
				button.Click -= value2;
			}
			PLNpWajwuM3 = value;
			button = PLNpWajwuM3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbOrientacao
	{
		[CompilerGenerated]
		get
		{
			return MhvpW8Ke2pN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MhvpW8Ke2pN = value;
		}
	}

	internal virtual TextBox TBOrientacao
	{
		[CompilerGenerated]
		get
		{
			return wnjpWNPGtPd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = CPOzSSyGXW;
			TextBox textBox = wnjpWNPGtPd;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			wnjpWNPGtPd = value;
			textBox = wnjpWNPGtPd;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btApagaModelosSemUso
	{
		[CompilerGenerated]
		get
		{
			return G3MpWFL1Z7C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UYOznVCLYc;
			Button button = G3MpWFL1Z7C;
			if (button != null)
			{
				button.Click -= value2;
			}
			G3MpWFL1Z7C = value;
			button = G3MpWFL1Z7C;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPesquisaLM2
	{
		[CompilerGenerated]
		get
		{
			return b3ipWQlxRWT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hjQzrovvlH;
			Button button = b3ipWQlxRWT;
			if (button != null)
			{
				button.Click -= value2;
			}
			b3ipWQlxRWT = value;
			button = b3ipWQlxRWT;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPesquisaLM1
	{
		[CompilerGenerated]
		get
		{
			return qJTpWP2abTU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DSLzYitgUH;
			Button button = qJTpWP2abTU;
			if (button != null)
			{
				button.Click -= value2;
			}
			qJTpWP2abTU = value;
			button = qJTpWP2abTU;
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
			return DJqpWcGPXKO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DJqpWcGPXKO = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return OH4pWKvyrU1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OH4pWKvyrU1 = value;
		}
	}

	internal virtual Label lbTopografico
	{
		[CompilerGenerated]
		get
		{
			return etlpWeXtMQQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			etlpWeXtMQQ = value;
		}
	}

	internal virtual Label lbLayout
	{
		[CompilerGenerated]
		get
		{
			return bdApW2mS3s6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bdApW2mS3s6 = value;
		}
	}

	internal virtual Button btSelecionaBlocoTopo
	{
		[CompilerGenerated]
		get
		{
			return P3KpW3awEEE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sfizVUeQSq;
			Button button = P3KpW3awEEE;
			if (button != null)
			{
				button.Click -= value2;
			}
			P3KpW3awEEE = value;
			button = P3KpW3awEEE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return SRvpWnJmC5V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SRvpWnJmC5V = value;
		}
	}

	internal virtual TextBox tbBlocoTopografico
	{
		[CompilerGenerated]
		get
		{
			return RZspW1ABET1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RZspW1ABET1 = value;
		}
	}

	internal virtual Button btSelecionaBlocoLayout
	{
		[CompilerGenerated]
		get
		{
			return I1TpWlAtTIF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EGtzu0v9LJ;
			Button button = I1TpWlAtTIF;
			if (button != null)
			{
				button.Click -= value2;
			}
			I1TpWlAtTIF = value;
			button = I1TpWlAtTIF;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return AO3pW5HHfy7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AO3pW5HHfy7 = value;
		}
	}

	internal virtual Label lbFabricante
	{
		[CompilerGenerated]
		get
		{
			return wj1pW0KWpQF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wj1pW0KWpQF = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return kFGpWRGbxBn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kFGpWRGbxBn = value;
		}
	}

	internal virtual Label lbDesc
	{
		[CompilerGenerated]
		get
		{
			return hr8pWmmQQJi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hr8pWmmQQJi = value;
		}
	}

	internal virtual Label lbCodigo
	{
		[CompilerGenerated]
		get
		{
			return wbFpWXJr80f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wbFpWXJr80f = value;
		}
	}

	internal virtual TextBox tbFabricante2
	{
		[CompilerGenerated]
		get
		{
			return zkbpWUCEoHT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zkbpWUCEoHT = value;
		}
	}

	internal virtual TextBox tbFabricante1
	{
		[CompilerGenerated]
		get
		{
			return w3FpWyDJ1NY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			w3FpWyDJ1NY = value;
		}
	}

	internal virtual TextBox tbModelo2
	{
		[CompilerGenerated]
		get
		{
			return tmkpWgg5RJk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tmkpWgg5RJk = value;
		}
	}

	internal virtual TextBox tbModelo1
	{
		[CompilerGenerated]
		get
		{
			return W36pWA05l2H;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			W36pWA05l2H = value;
		}
	}

	internal virtual TextBox tbDescricaoResum2
	{
		[CompilerGenerated]
		get
		{
			return YF9pWsBYL2s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YF9pWsBYL2s = value;
		}
	}

	internal virtual TextBox tbDescricaoResum1
	{
		[CompilerGenerated]
		get
		{
			return m63pWBPR26B;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m63pWBPR26B = value;
		}
	}

	internal virtual TextBox tbCodigo2
	{
		[CompilerGenerated]
		get
		{
			return VBVpWVQnss8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VBVpWVQnss8 = value;
		}
	}

	internal virtual TextBox tbCodigo1
	{
		[CompilerGenerated]
		get
		{
			return sOVpWuhLYf5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sOVpWuhLYf5 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && RH9zz6SEuM != null)
			{
				RH9zz6SEuM.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void JEZzNina6E()
	{
		RH9zz6SEuM = new Container();
		LBBornes = new Label();
		aHypBEW66iS(new FolderBrowserDialog());
		LBRegua = new Label();
		LBTerminais = new Label();
		FDqpBiUmZij(new ToolTip(RH9zz6SEuM));
		TBBornes = new TextBox();
		TBRegua = new TextBox();
		TBTerminais = new TextBox();
		LBEF = new Label();
		TBEFC = new TextBox();
		DGPortasInseridas = new DataGridView();
		BTEditaPorta = new Button();
		BTAdicionaPorta = new Button();
		BTApagaPorta = new Button();
		BTExportaEX = new Button();
		BTImportaEX = new Button();
		TBModelo = new TextBox();
		LbModelo = new Label();
		BTEditaMascara = new Button();
		GroupBoxMascara = new GroupBox();
		DGMascaras = new DataGridView();
		btPesquisaLM2 = new Button();
		btPesquisaLM1 = new Button();
		btApagaModelosSemUso = new Button();
		BTAdicionaMascara = new Button();
		BTApagaMascara = new Button();
		GroupBoxPorta = new GroupBox();
		btVerifica = new Button();
		lbOrientacao = new Label();
		TBOrientacao = new TextBox();
		DGPortas = new DataGridView();
		GroupBox2 = new GroupBox();
		GroupBox3 = new GroupBox();
		lbTopografico = new Label();
		lbLayout = new Label();
		btSelecionaBlocoTopo = new Button();
		tbBlocoLayout = new TextBox();
		tbBlocoTopografico = new TextBox();
		btSelecionaBlocoLayout = new Button();
		GroupBox4 = new GroupBox();
		lbFabricante = new Label();
		Label1 = new Label();
		lbDesc = new Label();
		lbCodigo = new Label();
		tbFabricante2 = new TextBox();
		tbFabricante1 = new TextBox();
		tbModelo2 = new TextBox();
		tbModelo1 = new TextBox();
		tbDescricaoResum2 = new TextBox();
		tbDescricaoResum1 = new TextBox();
		tbCodigo2 = new TextBox();
		tbCodigo1 = new TextBox();
		((ISupportInitialize)DGPortasInseridas).BeginInit();
		GroupBoxMascara.SuspendLayout();
		((ISupportInitialize)DGMascaras).BeginInit();
		GroupBoxPorta.SuspendLayout();
		((ISupportInitialize)DGPortas).BeginInit();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		SuspendLayout();
		LBBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LBBornes.Location = new Point(431, 351);
		LBBornes.Name = "LBBornes";
		LBBornes.Size = new Size(81, 17);
		LBBornes.TabIndex = 146;
		LBBornes.Text = "lbBornes";
		LBBornes.TextAlign = ContentAlignment.BottomLeft;
		LBRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LBRegua.Location = new Point(295, 353);
		LBRegua.Name = "LBRegua";
		LBRegua.Size = new Size(81, 17);
		LBRegua.TabIndex = 145;
		LBRegua.Text = "lbRegua";
		LBRegua.TextAlign = ContentAlignment.BottomLeft;
		LBTerminais.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LBTerminais.Location = new Point(104, 354);
		LBTerminais.Name = "LBTerminais";
		LBTerminais.Size = new Size(78, 17);
		LBTerminais.TabIndex = 144;
		LBTerminais.Text = "lbTerminais";
		LBTerminais.TextAlign = ContentAlignment.BottomLeft;
		TBBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBBornes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBBornes.Location = new Point(431, 371);
		TBBornes.Name = "TBBornes";
		TBBornes.Size = new Size(130, 20);
		TBBornes.TabIndex = 18;
		TBRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBRegua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBRegua.Location = new Point(295, 373);
		TBRegua.Name = "TBRegua";
		TBRegua.Size = new Size(130, 20);
		TBRegua.TabIndex = 17;
		TBTerminais.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBTerminais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTerminais.Location = new Point(104, 374);
		TBTerminais.Name = "TBTerminais";
		TBTerminais.Size = new Size(110, 20);
		TBTerminais.TabIndex = 15;
		LBEF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LBEF.Location = new Point(8, 353);
		LBEF.Name = "LBEF";
		LBEF.Size = new Size(81, 17);
		LBEF.TabIndex = 139;
		LBEF.Text = "LBEf";
		LBEF.TextAlign = ContentAlignment.BottomLeft;
		TBEFC.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBEFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBEFC.Location = new Point(8, 373);
		TBEFC.Name = "TBEFC";
		TBEFC.Size = new Size(90, 20);
		TBEFC.TabIndex = 14;
		DGPortasInseridas.AllowUserToAddRows = false;
		DGPortasInseridas.AllowUserToDeleteRows = false;
		DGPortasInseridas.AllowUserToOrderColumns = true;
		DGPortasInseridas.AllowUserToResizeRows = false;
		DGPortasInseridas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		DGPortasInseridas.BackgroundColor = SystemColors.ButtonHighlight;
		DGPortasInseridas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGPortasInseridas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGPortasInseridas.Location = new Point(605, 15);
		DGPortasInseridas.MultiSelect = false;
		DGPortasInseridas.Name = "DGPortasInseridas";
		DGPortasInseridas.ReadOnly = true;
		DGPortasInseridas.RowHeadersVisible = false;
		DGPortasInseridas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGPortasInseridas.Size = new Size(140, 330);
		DGPortasInseridas.TabIndex = 201;
		BTEditaPorta.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTEditaPorta.FlatStyle = FlatStyle.Flat;
		BTEditaPorta.ForeColor = SystemColors.Control;
		BTEditaPorta.Image = Resources.Editar;
		BTEditaPorta.Location = new Point(620, 352);
		BTEditaPorta.Name = "BTEditaPorta";
		BTEditaPorta.Size = new Size(40, 40);
		BTEditaPorta.TabIndex = 20;
		BTEditaPorta.UseVisualStyleBackColor = true;
		BTAdicionaPorta.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTAdicionaPorta.FlatStyle = FlatStyle.Flat;
		BTAdicionaPorta.ForeColor = SystemColors.Control;
		BTAdicionaPorta.Image = Resources.Adiciona_32;
		BTAdicionaPorta.Location = new Point(577, 352);
		BTAdicionaPorta.Name = "BTAdicionaPorta";
		BTAdicionaPorta.Size = new Size(40, 40);
		BTAdicionaPorta.TabIndex = 19;
		BTAdicionaPorta.UseVisualStyleBackColor = true;
		BTApagaPorta.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTApagaPorta.FlatStyle = FlatStyle.Flat;
		BTApagaPorta.ForeColor = SystemColors.Control;
		BTApagaPorta.Image = Resources.Delete_32;
		BTApagaPorta.Location = new Point(663, 352);
		BTApagaPorta.Name = "BTApagaPorta";
		BTApagaPorta.Size = new Size(40, 40);
		BTApagaPorta.TabIndex = 21;
		BTApagaPorta.Tag = "";
		BTApagaPorta.UseVisualStyleBackColor = true;
		BTExportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTExportaEX.FlatStyle = FlatStyle.Flat;
		BTExportaEX.ForeColor = SystemColors.Control;
		BTExportaEX.Image = Resources.ExportaExcel_20;
		BTExportaEX.Location = new Point(465, 171);
		BTExportaEX.Name = "BTExportaEX";
		BTExportaEX.Size = new Size(22, 42);
		BTExportaEX.TabIndex = 11;
		BTExportaEX.UseVisualStyleBackColor = true;
		BTImportaEX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTImportaEX.FlatStyle = FlatStyle.Flat;
		BTImportaEX.ForeColor = SystemColors.Control;
		BTImportaEX.Image = Resources.ImportaExcel_20;
		BTImportaEX.Location = new Point(504, 171);
		BTImportaEX.Name = "BTImportaEX";
		BTImportaEX.Size = new Size(22, 42);
		BTImportaEX.TabIndex = 12;
		BTImportaEX.UseVisualStyleBackColor = true;
		TBModelo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBModelo.Location = new Point(6, 31);
		TBModelo.Name = "TBModelo";
		TBModelo.Size = new Size(124, 20);
		TBModelo.TabIndex = 1;
		LbModelo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbModelo.Location = new Point(6, 13);
		LbModelo.Name = "LbModelo";
		LbModelo.Size = new Size(124, 17);
		LbModelo.TabIndex = 140;
		LbModelo.Text = "lbMODELO";
		BTEditaMascara.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTEditaMascara.FlatStyle = FlatStyle.Flat;
		BTEditaMascara.ForeColor = SystemColors.Control;
		BTEditaMascara.Image = Resources.Editar;
		BTEditaMascara.Location = new Point(179, 13);
		BTEditaMascara.Name = "BTEditaMascara";
		BTEditaMascara.Size = new Size(40, 40);
		BTEditaMascara.TabIndex = 3;
		BTEditaMascara.UseVisualStyleBackColor = true;
		GroupBoxMascara.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBoxMascara.Controls.Add(DGMascaras);
		GroupBoxMascara.Location = new Point(6, 6);
		GroupBoxMascara.Name = "GroupBoxMascara";
		GroupBoxMascara.Size = new Size(543, 156);
		GroupBoxMascara.TabIndex = 143;
		GroupBoxMascara.TabStop = false;
		GroupBoxMascara.Text = "GroupBoxMascara";
		DGMascaras.AllowUserToAddRows = false;
		DGMascaras.AllowUserToDeleteRows = false;
		DGMascaras.AllowUserToOrderColumns = true;
		DGMascaras.AllowUserToResizeRows = false;
		DGMascaras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGMascaras.BackgroundColor = SystemColors.ButtonHighlight;
		DGMascaras.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGMascaras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGMascaras.Location = new Point(5, 15);
		DGMascaras.MultiSelect = false;
		DGMascaras.Name = "DGMascaras";
		DGMascaras.ReadOnly = true;
		DGMascaras.RowHeadersVisible = false;
		DGMascaras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGMascaras.Size = new Size(526, 135);
		DGMascaras.TabIndex = 0;
		DGMascaras.TabStop = false;
		btPesquisaLM2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM2.FlatStyle = FlatStyle.Flat;
		btPesquisaLM2.ForeColor = SystemColors.Control;
		btPesquisaLM2.Image = Resources.Pesquisar_16;
		btPesquisaLM2.Location = new Point(515, 59);
		btPesquisaLM2.Name = "btPesquisaLM2";
		btPesquisaLM2.Size = new Size(22, 22);
		btPesquisaLM2.TabIndex = 193;
		btPesquisaLM2.UseVisualStyleBackColor = true;
		btPesquisaLM1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisaLM1.FlatStyle = FlatStyle.Flat;
		btPesquisaLM1.ForeColor = SystemColors.Control;
		btPesquisaLM1.Image = Resources.Pesquisar_16;
		btPesquisaLM1.Location = new Point(513, 36);
		btPesquisaLM1.Name = "btPesquisaLM1";
		btPesquisaLM1.Size = new Size(22, 22);
		btPesquisaLM1.TabIndex = 192;
		btPesquisaLM1.UseVisualStyleBackColor = true;
		btApagaModelosSemUso.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagaModelosSemUso.FlatStyle = FlatStyle.Flat;
		btApagaModelosSemUso.ForeColor = SystemColors.Control;
		btApagaModelosSemUso.Image = Resources.Apagador_32;
		btApagaModelosSemUso.Location = new Point(265, 13);
		btApagaModelosSemUso.Name = "btApagaModelosSemUso";
		btApagaModelosSemUso.Size = new Size(40, 40);
		btApagaModelosSemUso.TabIndex = 180;
		btApagaModelosSemUso.Tag = "";
		btApagaModelosSemUso.UseVisualStyleBackColor = true;
		BTAdicionaMascara.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTAdicionaMascara.FlatStyle = FlatStyle.Flat;
		BTAdicionaMascara.ForeColor = SystemColors.Control;
		BTAdicionaMascara.Image = Resources.Adiciona_32;
		BTAdicionaMascara.Location = new Point(136, 13);
		BTAdicionaMascara.Name = "BTAdicionaMascara";
		BTAdicionaMascara.Size = new Size(40, 40);
		BTAdicionaMascara.TabIndex = 2;
		BTAdicionaMascara.UseVisualStyleBackColor = true;
		BTApagaMascara.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTApagaMascara.FlatStyle = FlatStyle.Flat;
		BTApagaMascara.ForeColor = SystemColors.Control;
		BTApagaMascara.Image = Resources.Delete_32;
		BTApagaMascara.Location = new Point(222, 13);
		BTApagaMascara.Name = "BTApagaMascara";
		BTApagaMascara.Size = new Size(40, 40);
		BTApagaMascara.TabIndex = 4;
		BTApagaMascara.Tag = "";
		BTApagaMascara.UseVisualStyleBackColor = true;
		GroupBoxPorta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBoxPorta.Controls.Add(btVerifica);
		GroupBoxPorta.Controls.Add(DGPortasInseridas);
		GroupBoxPorta.Controls.Add(LBBornes);
		GroupBoxPorta.Controls.Add(LBRegua);
		GroupBoxPorta.Controls.Add(lbOrientacao);
		GroupBoxPorta.Controls.Add(LBTerminais);
		GroupBoxPorta.Controls.Add(TBBornes);
		GroupBoxPorta.Controls.Add(TBRegua);
		GroupBoxPorta.Controls.Add(TBOrientacao);
		GroupBoxPorta.Controls.Add(TBTerminais);
		GroupBoxPorta.Controls.Add(LBEF);
		GroupBoxPorta.Controls.Add(TBEFC);
		GroupBoxPorta.Controls.Add(BTEditaPorta);
		GroupBoxPorta.Controls.Add(BTAdicionaPorta);
		GroupBoxPorta.Controls.Add(BTApagaPorta);
		GroupBoxPorta.Controls.Add(DGPortas);
		GroupBoxPorta.Location = new Point(555, 6);
		GroupBoxPorta.Name = "GroupBoxPorta";
		GroupBoxPorta.Size = new Size(754, 399);
		GroupBoxPorta.TabIndex = 144;
		GroupBoxPorta.TabStop = false;
		GroupBoxPorta.Text = "GroupBoxPorta";
		btVerifica.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btVerifica.FlatStyle = FlatStyle.Flat;
		btVerifica.ForeColor = SystemColors.Control;
		btVerifica.Image = Resources.Verifica_Duplo_32;
		btVerifica.Location = new Point(706, 352);
		btVerifica.Name = "btVerifica";
		btVerifica.Size = new Size(40, 40);
		btVerifica.TabIndex = 22;
		btVerifica.Tag = "";
		btVerifica.UseVisualStyleBackColor = true;
		lbOrientacao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbOrientacao.Location = new Point(220, 354);
		lbOrientacao.Name = "lbOrientacao";
		lbOrientacao.Size = new Size(78, 17);
		lbOrientacao.TabIndex = 144;
		lbOrientacao.Text = "lbOrientação";
		lbOrientacao.TextAlign = ContentAlignment.BottomLeft;
		TBOrientacao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBOrientacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBOrientacao.Location = new Point(220, 374);
		TBOrientacao.Name = "TBOrientacao";
		TBOrientacao.Size = new Size(69, 20);
		TBOrientacao.TabIndex = 16;
		DGPortas.AllowUserToAddRows = false;
		DGPortas.AllowUserToDeleteRows = false;
		DGPortas.AllowUserToOrderColumns = true;
		DGPortas.AllowUserToResizeRows = false;
		DGPortas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGPortas.BackgroundColor = SystemColors.ButtonHighlight;
		DGPortas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGPortas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGPortas.Location = new Point(8, 15);
		DGPortas.MultiSelect = false;
		DGPortas.Name = "DGPortas";
		DGPortas.ReadOnly = true;
		DGPortas.RowHeadersVisible = false;
		DGPortas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGPortas.Size = new Size(596, 330);
		DGPortas.TabIndex = 200;
		DGPortas.TabStop = false;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(LbModelo);
		GroupBox2.Controls.Add(BTApagaMascara);
		GroupBox2.Controls.Add(BTAdicionaMascara);
		GroupBox2.Controls.Add(BTEditaMascara);
		GroupBox2.Controls.Add(btApagaModelosSemUso);
		GroupBox2.Controls.Add(TBModelo);
		GroupBox2.Location = new Point(6, 162);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(316, 65);
		GroupBox2.TabIndex = 145;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(lbTopografico);
		GroupBox3.Controls.Add(lbLayout);
		GroupBox3.Controls.Add(btSelecionaBlocoTopo);
		GroupBox3.Controls.Add(tbBlocoLayout);
		GroupBox3.Controls.Add(tbBlocoTopografico);
		GroupBox3.Controls.Add(btSelecionaBlocoLayout);
		GroupBox3.Location = new Point(5, 231);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(544, 71);
		GroupBox3.TabIndex = 169;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "GroupBox3";
		lbTopografico.Location = new Point(13, 20);
		lbTopografico.Name = "lbTopografico";
		lbTopografico.Size = new Size(112, 16);
		lbTopografico.TabIndex = 156;
		lbTopografico.Text = "lbTOPOGRAFICO";
		lbLayout.Location = new Point(271, 20);
		lbLayout.Name = "lbLayout";
		lbLayout.Size = new Size(112, 16);
		lbLayout.TabIndex = 158;
		lbLayout.Text = "lbLAYOUT";
		btSelecionaBlocoTopo.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoTopo.ForeColor = SystemColors.Control;
		btSelecionaBlocoTopo.Image = Resources.Pesquisar_16;
		btSelecionaBlocoTopo.Location = new Point(233, 37);
		btSelecionaBlocoTopo.Name = "btSelecionaBlocoTopo";
		btSelecionaBlocoTopo.Size = new Size(22, 22);
		btSelecionaBlocoTopo.TabIndex = 10;
		btSelecionaBlocoTopo.UseVisualStyleBackColor = true;
		tbBlocoLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoLayout.Location = new Point(274, 39);
		tbBlocoLayout.Name = "tbBlocoLayout";
		tbBlocoLayout.Size = new Size(234, 20);
		tbBlocoLayout.TabIndex = 11;
		tbBlocoTopografico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoTopografico.Location = new Point(7, 39);
		tbBlocoTopografico.Name = "tbBlocoTopografico";
		tbBlocoTopografico.Size = new Size(220, 20);
		tbBlocoTopografico.TabIndex = 9;
		btSelecionaBlocoLayout.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoLayout.ForeColor = SystemColors.Control;
		btSelecionaBlocoLayout.Image = Resources.Pesquisar_16;
		btSelecionaBlocoLayout.Location = new Point(514, 37);
		btSelecionaBlocoLayout.Name = "btSelecionaBlocoLayout";
		btSelecionaBlocoLayout.Size = new Size(22, 22);
		btSelecionaBlocoLayout.TabIndex = 12;
		btSelecionaBlocoLayout.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(btPesquisaLM2);
		GroupBox4.Controls.Add(lbFabricante);
		GroupBox4.Controls.Add(Label1);
		GroupBox4.Controls.Add(btPesquisaLM1);
		GroupBox4.Controls.Add(lbDesc);
		GroupBox4.Controls.Add(lbCodigo);
		GroupBox4.Controls.Add(tbFabricante2);
		GroupBox4.Controls.Add(tbFabricante1);
		GroupBox4.Controls.Add(tbModelo2);
		GroupBox4.Controls.Add(tbModelo1);
		GroupBox4.Controls.Add(tbDescricaoResum2);
		GroupBox4.Controls.Add(tbDescricaoResum1);
		GroupBox4.Controls.Add(tbCodigo2);
		GroupBox4.Controls.Add(tbCodigo1);
		GroupBox4.Location = new Point(6, 316);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(543, 89);
		GroupBox4.TabIndex = 170;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "GroupBox4";
		lbFabricante.Location = new Point(393, 17);
		lbFabricante.Name = "lbFabricante";
		lbFabricante.Size = new Size(111, 16);
		lbFabricante.TabIndex = 207;
		lbFabricante.Text = "Fabricante";
		Label1.Location = new Point(276, 16);
		Label1.Name = "Label1";
		Label1.Size = new Size(111, 16);
		Label1.TabIndex = 206;
		Label1.Text = "Modelo";
		lbDesc.Location = new Point(87, 16);
		lbDesc.Name = "lbDesc";
		lbDesc.Size = new Size(197, 16);
		lbDesc.TabIndex = 205;
		lbDesc.Text = "Descrição Resumida";
		lbCodigo.Location = new Point(6, 16);
		lbCodigo.Name = "lbCodigo";
		lbCodigo.Size = new Size(75, 16);
		lbCodigo.TabIndex = 204;
		lbCodigo.Text = "Codigo";
		tbFabricante2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante2.Location = new Point(393, 61);
		tbFabricante2.Name = "tbFabricante2";
		tbFabricante2.ReadOnly = true;
		tbFabricante2.Size = new Size(111, 20);
		tbFabricante2.TabIndex = 203;
		tbFabricante1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFabricante1.Location = new Point(393, 36);
		tbFabricante1.Name = "tbFabricante1";
		tbFabricante1.ReadOnly = true;
		tbFabricante1.Size = new Size(111, 20);
		tbFabricante1.TabIndex = 202;
		tbModelo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo2.Location = new Point(276, 61);
		tbModelo2.Name = "tbModelo2";
		tbModelo2.ReadOnly = true;
		tbModelo2.Size = new Size(111, 20);
		tbModelo2.TabIndex = 201;
		tbModelo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbModelo1.Location = new Point(276, 36);
		tbModelo1.Name = "tbModelo1";
		tbModelo1.ReadOnly = true;
		tbModelo1.Size = new Size(111, 20);
		tbModelo1.TabIndex = 200;
		tbDescricaoResum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum2.Location = new Point(87, 61);
		tbDescricaoResum2.Name = "tbDescricaoResum2";
		tbDescricaoResum2.ReadOnly = true;
		tbDescricaoResum2.Size = new Size(184, 20);
		tbDescricaoResum2.TabIndex = 199;
		tbDescricaoResum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDescricaoResum1.Location = new Point(87, 36);
		tbDescricaoResum1.Name = "tbDescricaoResum1";
		tbDescricaoResum1.ReadOnly = true;
		tbDescricaoResum1.Size = new Size(184, 20);
		tbDescricaoResum1.TabIndex = 198;
		tbCodigo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo2.Location = new Point(8, 61);
		tbCodigo2.Name = "tbCodigo2";
		tbCodigo2.ReadOnly = true;
		tbCodigo2.Size = new Size(73, 20);
		tbCodigo2.TabIndex = 197;
		tbCodigo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCodigo1.Location = new Point(8, 36);
		tbCodigo1.Name = "tbCodigo1";
		tbCodigo1.ReadOnly = true;
		tbCodigo1.Size = new Size(73, 20);
		tbCodigo1.TabIndex = 196;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1314, 412);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBoxMascara);
		Controls.Add(GroupBoxPorta);
		Controls.Add(BTExportaEX);
		Controls.Add(BTImportaEX);
		MinimumSize = new Size(1330, 450);
		Name = "frmGerenciadorMascaras";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Gerenciador de Mascaras";
		((ISupportInitialize)DGPortasInseridas).EndInit();
		GroupBoxMascara.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGMascaras).EndInit();
		GroupBoxPorta.ResumeLayout(performLayout: false);
		GroupBoxPorta.PerformLayout();
		((ISupportInitialize)DGPortas).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return ikCpWpa5cqw;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		ikCpWpa5cqw = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return tKPpWhk0CcZ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		tKPpWhk0CcZ = WithEventsValue;
	}

	public frmGerenciadorMascaras()
	{
		Resize += WXCz919CZj;
		L0FpWZgIhYI = -1;
		B6qpWimJUPB = -1;
		Nj5pWCKSi8n = new List<int>();
		if (Geral.ExisteForm("frmGerenciadorMascaras") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			JEZzNina6E();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 920]);
			GroupBoxMascara.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 652]);
			GroupBoxPorta.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 921]);
			LbModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
			LBEF.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 922]);
			LBTerminais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 923]);
			lbOrientacao.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1846], ";"));
			LBRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]);
			LBBornes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 925]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
			GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 192]);
			GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]);
			lbCodigo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1245]);
			lbDesc.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
			LbModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]);
			lbFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]);
			lbTopografico.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 657]);
			lbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 658]);
			w8dpBZ0kvSD().SetToolTip(BTAdicionaMascara, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 661]));
			w8dpBZ0kvSD().SetToolTip(BTEditaMascara, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 662]));
			w8dpBZ0kvSD().SetToolTip(BTApagaMascara, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 663]));
			w8dpBZ0kvSD().SetToolTip(BTAdicionaPorta, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1126]));
			w8dpBZ0kvSD().SetToolTip(BTEditaPorta, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1127]));
			w8dpBZ0kvSD().SetToolTip(BTApagaPorta, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1128]));
			w8dpBZ0kvSD().SetToolTip(TBEFC, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 668]));
			w8dpBZ0kvSD().SetToolTip(TBTerminais, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 669]));
			w8dpBZ0kvSD().SetToolTip(TBRegua, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 670]));
			w8dpBZ0kvSD().SetToolTip(DGPortasInseridas, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 673]));
			w8dpBZ0kvSD().SetToolTip(BTImportaEX, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1124]));
			w8dpBZ0kvSD().SetToolTip(BTExportaEX, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1125]));
			w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoTopo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
			w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoLayout, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
			w8dpBZ0kvSD().SetToolTip(btVerifica, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1481]));
			w8dpBZ0kvSD().SetToolTip(btApagaModelosSemUso, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1843]));
			DicionarioMascaras.LeOsModelosDeMascaras(ref WMgpWSL2vjs, bComplementarModelo: true);
			DataGridView dg = DGMascaras;
			clsMascara.carregaModelosDeMascaraNoDG(ref dg, WMgpWSL2vjs);
			DGMascaras = dg;
			clsMascara.EncontraModelosUsados(ref Nj5pWCKSi8n);
			cDadosLM cDadosLM2 = new cDadosLM();
			kigpWElRigI = cDadosLM2.CarregaDadosLMMatriz();
			cDadosLM2.fechaConexao();
			tbBlocoTopografico.Enabled = false;
			tbBlocoLayout.Enabled = false;
			if (DGMascaras.Rows.Count > 0)
			{
				DGMascaras.Rows[0].Selected = true;
			}
			mostraModeloMascara();
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			dg = DGMascaras;
			clsMascara.AtualizaColunasDGModelos(ref dg);
			DGMascaras = dg;
			dg = DGPortas;
			AtualizaColunasDGPortasMascara(ref dg);
			DGPortas = dg;
			marcaUdoDosModelos(Nj5pWCKSi8n);
			if (DGPortas.RowCount > 0)
			{
				DGPortas.Rows[0].Selected = false;
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	private void koDzFDQaDc(object P_0, DataGridViewCellEventArgs P_1)
	{
		mostraModeloMascara();
	}

	private void QKHzQROvrD(object P_0, KeyEventArgs P_1)
	{
		mostraModeloMascara();
	}

	private void DH1zP5wfDT(object P_0, KeyEventArgs P_1)
	{
		mostraModeloMascara();
	}

	public void mostraModeloMascara()
	{
		DGPortasInseridas.Rows.Clear();
		DGPortasInseridas.Columns.Clear();
		checked
		{
			int num = DGMascaras.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGMascaras.Rows[i].Selected)
				{
					L0FpWZgIhYI = Conversions.ToInteger(DGMascaras.Rows[i].Cells[0].Value);
					TBModelo.Text = Conversions.ToString(DGMascaras.Rows[i].Cells[1].Value);
					yuSzcqjrTY(Conversions.ToInteger(DGMascaras.Rows[i].Cells[2].Value), 1);
					yuSzcqjrTY(Conversions.ToInteger(DGMascaras.Rows[i].Cells[3].Value), 2);
					tbBlocoTopografico.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico))
					{
						tbBlocoTopografico.BackColor = Color.White;
					}
					tbBlocoTopografico.Text = DGMascaras.Rows[i].Cells[4].Value.ToString().ToUpper().Trim();
					tbBlocoLayout.BackColor = Color.Silver;
					if ((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout))
					{
						tbBlocoLayout.BackColor = Color.White;
					}
					tbBlocoLayout.Text = DGMascaras.Rows[i].Cells[5].Value.ToString().ToUpper().Trim();
					int iIndiceSelecionado = Conversions.ToInteger(DGMascaras.Rows[i].Cells[0].Value);
					string sNomeModelo = Conversions.ToString(DGMascaras.Rows[i].Cells[0].Value);
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado, sNomeModelo, ref UMrpW4fhjTY);
					DataGridView dg = DGPortas;
					clsDispositivoMascaras.carregaContatosNoDGMascara(ref dg, ref UMrpW4fhjTY, bPintaDG: false);
					DGPortas = dg;
					dg = DGPortas;
					AtualizaColunasDGPortasMascara(ref dg);
					DGPortas = dg;
					TBEFC.Text = "";
					TBTerminais.Text = "";
					TBOrientacao.Text = "";
					TBRegua.Text = "";
					TBBornes.Text = "";
					break;
				}
			}
			if (DGPortas.RowCount > 0)
			{
				DGPortas.Rows[0].Selected = false;
			}
		}
	}

	private void yuSzcqjrTY(int P_0, int P_1)
	{
		if (P_1 == 1)
		{
			tbCodigo1.Text = Conversions.ToString(0);
			tbDescricaoResum1.Text = "";
			tbModelo1.Text = "";
			tbFabricante1.Text = "";
		}
		else if (P_1 == 2)
		{
			tbCodigo2.Text = Conversions.ToString(0);
			tbDescricaoResum2.Text = "";
			tbModelo2.Text = "";
			tbFabricante2.Text = "";
		}
		int num = Information.UBound(kigpWElRigI);
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (kigpWElRigI[num2].CodigoInterno == P_0)
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return;
		}
		switch (P_1)
		{
		case 1:
			tbCodigo1.Text = Conversions.ToString(P_0);
			tbDescricaoResum1.Text = kigpWElRigI[num2].DescricaoResumida;
			tbModelo1.Text = kigpWElRigI[num2].Modelo;
			tbFabricante1.Text = kigpWElRigI[num2].Fabricante;
			break;
		case 2:
			tbCodigo2.Text = Conversions.ToString(P_0);
			tbDescricaoResum2.Text = kigpWElRigI[num2].DescricaoResumida;
			tbModelo2.Text = kigpWElRigI[num2].Modelo;
			tbFabricante2.Text = kigpWElRigI[num2].Fabricante;
			break;
		}
	}

	private void xLJzK0LgWn(object P_0, EventArgs P_1)
	{
		ModelosBotoesVisiveis(bOpcao: false);
		DGPortas.Rows.Clear();
		DGPortasInseridas.Rows.Clear();
		DGPortasInseridas.Columns.Clear();
		int num = 0;
		int num2 = 0;
		if (Operators.CompareString(tbCodigo1.Text.Trim(), "", TextCompare: true) != 0)
		{
			num = Conversions.ToInteger(tbCodigo1.Text);
		}
		if (Operators.CompareString(tbCodigo2.Text.Trim(), "", TextCompare: true) != 0)
		{
			num2 = Conversions.ToInteger(tbCodigo2.Text);
		}
		TBModelo.Text = TBModelo.Text.ToString().Trim();
		checked
		{
			int num3 = Information.UBound(WMgpWSL2vjs) - 1;
			int num4 = 0;
			while (true)
			{
				if (num4 <= num3)
				{
					TBModelo.BackColor = Color.White;
					TBModelo.ForeColor = Color.Black;
					if (!Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(DGMascaras.Rows[num4].Cells[1].Value, TBModelo.Text.ToString(), TextCompare: true), Operators.CompareString(TBModelo.Text.ToString().Trim(), "", TextCompare: true) == 0)))
					{
						num4++;
						continue;
					}
					TBModelo.BackColor = Color.Red;
					TBModelo.ForeColor = Color.White;
					break;
				}
				UMrpW4fhjTY = new Declaracoes2.MModeloDePortas[1];
				int num5 = 1;
				int num6 = Information.UBound(WMgpWSL2vjs);
				for (int i = 0; i <= num6; i++)
				{
					if (num5 <= WMgpWSL2vjs[i].iIndiceModelo)
					{
						num5 = WMgpWSL2vjs[i].iIndiceModelo + 1;
					}
				}
				DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(num5, ref UMrpW4fhjTY);
				int num7 = 0;
				num7 = Information.UBound(WMgpWSL2vjs) + 1;
				ref Declaracoes2.MModeloDeMascara[] wMgpWSL2vjs = ref WMgpWSL2vjs;
				wMgpWSL2vjs = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(wMgpWSL2vjs, new Declaracoes2.MModeloDeMascara[num7 + 1]);
				WMgpWSL2vjs[num7].iIndiceModelo = num5;
				WMgpWSL2vjs[num7].sNomeModelo = TBModelo.Text.ToString();
				WMgpWSL2vjs[num7].iLM1 = num;
				WMgpWSL2vjs[num7].iLM2 = num2;
				WMgpWSL2vjs[num7].sBlocoTopografico = tbBlocoTopografico.Text.ToString();
				WMgpWSL2vjs[num7].sBlocoLayout = tbBlocoLayout.Text.ToString();
				DicionarioMascaras.GravaOsModelosDeMascara(WMgpWSL2vjs);
				DicionarioMascaras.LeOsModelosDeMascaras(ref WMgpWSL2vjs, bComplementarModelo: true);
				DataGridView dg = DGMascaras;
				clsMascara.carregaModelosDeMascaraNoDG(ref dg, WMgpWSL2vjs);
				DGMascaras = dg;
				if (DGMascaras.Rows.Count > 0)
				{
					DGMascaras.Rows[DGMascaras.Rows.Count - 1].Selected = true;
				}
				if (DGMascaras.Rows.Count > 0)
				{
					int num8 = DGMascaras.Rows.Count - 1;
					DGMascaras.Rows[num8].Selected = true;
					DGMascaras.FirstDisplayedScrollingRowIndex = num8;
				}
				mostraModeloMascara();
				break;
			}
			ModelosBotoesVisiveis(bOpcao: true);
			marcaUdoDosModelos(Nj5pWCKSi8n);
		}
	}

	private void RKnzeljMvI(object P_0, EventArgs P_1)
	{
		XcPz2XLTyp();
		marcaUdoDosModelos(Nj5pWCKSi8n);
	}

	private void XcPz2XLTyp()
	{
		if (DGMascaras.Rows.Count == 0)
		{
			return;
		}
		clsTrocaEditaBlocos.LeTodosAtributos();
		ModelosBotoesVisiveis(bOpcao: false);
		int num = 0;
		int indiceMascara = -1;
		TBModelo.Text = TBModelo.Text.ToString().Trim();
		checked
		{
			int num2 = Information.UBound(WMgpWSL2vjs) - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					TBModelo.BackColor = Color.White;
					TBModelo.ForeColor = Color.Black;
					if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(DGMascaras.Rows[num3].Cells[1].Value, TBModelo.Text.ToString(), TextCompare: true), !DGMascaras.Rows[num3].Selected)))
					{
						num3++;
						continue;
					}
					TBModelo.BackColor = Color.Red;
					TBModelo.ForeColor = Color.White;
					break;
				}
				int num4 = DGMascaras.Rows.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					if (DGMascaras.Rows[i].Selected)
					{
						num = i;
						indiceMascara = Conversions.ToInteger(DGMascaras.Rows[i].Cells[0].Value);
						if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(DGMascaras.Rows[i].Cells[1].Value, TBModelo.Text, TextCompare: true), Operators.CompareString(DGMascaras.Rows[i].Cells[2].Value.ToString(), tbCodigo1.Text.ToString(), TextCompare: true) != 0), Operators.CompareString(DGMascaras.Rows[i].Cells[3].Value.ToString(), tbCodigo2.Text.ToString(), TextCompare: true) != 0), Operators.CompareString(DGMascaras.Rows[i].Cells[4].Value.ToString(), tbBlocoTopografico.Text, TextCompare: true) != 0), Operators.CompareString(DGMascaras.Rows[i].Cells[5].Value.ToString(), tbBlocoLayout.Text, TextCompare: true) != 0)))
						{
							DGMascaras.Rows[i].Cells[1].Value = TBModelo.Text;
							DGMascaras.Rows[i].Cells[2].Value = tbCodigo1.Text.ToString();
							DGMascaras.Rows[i].Cells[3].Value = tbCodigo2.Text.ToString();
							DGMascaras.Rows[i].Cells[4].Value = tbBlocoTopografico.Text;
							DGMascaras.Rows[i].Cells[5].Value = tbBlocoLayout.Text;
							_ = TBModelo.Text;
							break;
						}
					}
				}
				WMgpWSL2vjs = new Declaracoes2.MModeloDeMascara[1];
				int num5 = DGMascaras.Rows.Count - 1;
				for (int j = 0; j <= num5; j++)
				{
					int num6 = Information.UBound(WMgpWSL2vjs) + 1;
					ref Declaracoes2.MModeloDeMascara[] wMgpWSL2vjs = ref WMgpWSL2vjs;
					wMgpWSL2vjs = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(wMgpWSL2vjs, new Declaracoes2.MModeloDeMascara[num6 + 1]);
					if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(DGMascaras.Rows[j].Cells[2].Value)))
					{
						Conversions.ToInteger(DGMascaras.Rows[j].Cells[2].Value);
					}
					if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(DGMascaras.Rows[j].Cells[3].Value)))
					{
						Conversions.ToInteger(DGMascaras.Rows[j].Cells[3].Value);
					}
					WMgpWSL2vjs[num6].iIndiceModelo = Conversions.ToInteger(DGMascaras.Rows[j].Cells[0].Value);
					WMgpWSL2vjs[num6].sNomeModelo = Conversions.ToString(DGMascaras.Rows[j].Cells[1].Value);
					if (Operators.CompareString(DGMascaras.Rows[j].Cells[2].Value.ToString(), "0", TextCompare: true) != 0)
					{
						WMgpWSL2vjs[num6].iLM1 = Conversions.ToInteger(DGMascaras.Rows[j].Cells[2].Value);
					}
					if (Operators.CompareString(DGMascaras.Rows[j].Cells[3].Value.ToString(), "0", TextCompare: true) != 0)
					{
						WMgpWSL2vjs[num6].iLM2 = Conversions.ToInteger(DGMascaras.Rows[j].Cells[3].Value);
					}
					WMgpWSL2vjs[num6].sBlocoTopografico = Conversions.ToString(DGMascaras.Rows[j].Cells[4].Value);
					WMgpWSL2vjs[num6].sBlocoLayout = Conversions.ToString(DGMascaras.Rows[j].Cells[5].Value);
				}
				DicionarioMascaras.GravaOsModelosDeMascara(WMgpWSL2vjs);
				DicionarioMascaras.LeOsModelosDeMascaras(ref WMgpWSL2vjs, bComplementarModelo: true);
				DataGridView dg = DGMascaras;
				clsMascara.carregaModelosDeMascaraNoDG(ref dg, WMgpWSL2vjs);
				DGMascaras = dg;
				clsDispositivoMascaras.EditaMascarasDoModelo(indiceMascara, ref WMgpWSL2vjs, Conversions.ToString(Conversions.ToInteger(tbCodigo1.Text)), Conversions.ToString(Conversions.ToInteger(tbCodigo2.Text)), tbBlocoTopografico.Text, tbBlocoLayout.Text);
				clsUtilitarios.EditaPortasPainelModeloFabricante();
				if (DGMascaras.Rows.Count > 0)
				{
					DGMascaras.Rows[DGMascaras.Rows.Count - 1].Selected = true;
				}
				DGMascaras.Rows[num].Selected = true;
				DGMascaras.FirstDisplayedScrollingRowIndex = num;
				clsUtilitarios.EditaPortasPainelModeloFabricante();
				break;
			}
			ModelosBotoesVisiveis(bOpcao: true);
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.SendStringToExecute("CorrigeAtributosSemMsg\n", true, false, true);
		}
	}

	private void nWYz3oZQ0v(object P_0, EventArgs P_1)
	{
		if (DGMascaras.Rows.Count == 0)
		{
			return;
		}
		ModelosBotoesVisiveis(bOpcao: false);
		MsgBoxResult msgBoxResult = MsgBoxResult.No;
		int num = -1;
		int iIndiceDel = 0;
		checked
		{
			int num2 = DGMascaras.Rows.Count - 1;
			for (int i = num2; i >= 0; i += -1)
			{
				if (DGMascaras.Rows[i].Selected)
				{
					num = i;
					iIndiceDel = Conversions.ToInteger(DGMascaras.Rows[i].Cells[0].Value);
					break;
				}
			}
			string prompt = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1140], "\r\n"), "\r\n"), DeclaracoesGeral.mMensagem[1, 1141]));
			msgBoxResult = Interaction.MsgBox(prompt, MsgBoxStyle.YesNo, "Elétron");
			if (msgBoxResult != MsgBoxResult.No)
			{
				DGPortasInseridas.Rows.Clear();
				DGPortasInseridas.Columns.Clear();
				DeclaracoesGeral._uscPagina.Quantidade = 6;
				DeclaracoesGeral._uscPagina.pbIniciar();
				DeclaracoesGeral._uscPagina.pbPasso();
				UMrpW4fhjTY = new Declaracoes2.MModeloDePortas[1];
				DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(L0FpWZgIhYI, ref UMrpW4fhjTY);
				DeclaracoesGeral._uscPagina.pbPasso();
				if (num != -1)
				{
					DGMascaras.Rows.RemoveAt(num);
					WMgpWSL2vjs = new Declaracoes2.MModeloDeMascara[1];
					int num3 = DGMascaras.Rows.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						int num4 = Information.UBound(WMgpWSL2vjs) + 1;
						ref Declaracoes2.MModeloDeMascara[] wMgpWSL2vjs = ref WMgpWSL2vjs;
						wMgpWSL2vjs = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(wMgpWSL2vjs, new Declaracoes2.MModeloDeMascara[num4 + 1]);
						WMgpWSL2vjs[num4].iIndiceModelo = Conversions.ToInteger(DGMascaras.Rows[j].Cells[0].Value);
						WMgpWSL2vjs[num4].sNomeModelo = Conversions.ToString(DGMascaras.Rows[j].Cells[1].Value);
						WMgpWSL2vjs[num4].iLM1 = Conversions.ToInteger(DGMascaras.Rows[j].Cells[2].Value);
						WMgpWSL2vjs[num4].iLM2 = Conversions.ToInteger(DGMascaras.Rows[j].Cells[3].Value);
						WMgpWSL2vjs[num4].sBlocoTopografico = Conversions.ToString(DGMascaras.Rows[j].Cells[4].Value);
						WMgpWSL2vjs[num4].sBlocoLayout = Conversions.ToString(DGMascaras.Rows[j].Cells[5].Value);
					}
					DicionarioMascaras.GravaOsModelosDeMascara(WMgpWSL2vjs);
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				string[] mPortas = new string[1];
				DeclaracoesGeral._uscPagina.pbPasso();
				clsMascara.IndefineModeloDaMmascara(iIndiceDel, ref mPortas);
				DeclaracoesGeral._uscPagina.pbPasso();
				clsPortas.IndefinePortasModelo(mPortas);
				DeclaracoesGeral._uscPagina.pbPasso();
				mostraModeloMascara();
				DeclaracoesGeral._uscPagina.pbFim();
				DataGridView dg = DGMascaras;
				clsMascara.AtualizaColunasDGModelos(ref dg);
				DGMascaras = dg;
				clsPortas.SincronizaPortas();
			}
			ModelosBotoesVisiveis(bOpcao: true);
			marcaUdoDosModelos(Nj5pWCKSi8n);
		}
	}

	private void UYOznVCLYc(object P_0, EventArgs P_1)
	{
		ModelosBotoesVisiveis(bOpcao: false);
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1842]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		checked
		{
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1283]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
				if (msgBoxResult != MsgBoxResult.No)
				{
					List<int> list = new List<int>();
					int num = DGMascaras.Rows.Count - 1;
					for (int i = num; i >= 0; i += -1)
					{
						if (DGMascaras.Rows[i].Cells[0].Style.BackColor == Color.LightGreen)
						{
							list.Add(Conversions.ToInteger(DGMascaras.Rows[i].Cells[0].Value));
						}
					}
					DGPortas.Rows.Clear();
					DGPortas.Columns.Clear();
					DGPortasInseridas.Rows.Clear();
					DGPortasInseridas.Columns.Clear();
					DeclaracoesGeral._uscPagina.Quantidade = DGMascaras.Rows.Count - 1;
					DeclaracoesGeral._uscPagina.pbIniciar();
					WMgpWSL2vjs = new Declaracoes2.MModeloDeMascara[1];
					foreach (int item in list)
					{
						UMrpW4fhjTY = new Declaracoes2.MModeloDePortas[1];
						DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(item, ref UMrpW4fhjTY);
						int num2 = DGMascaras.Rows.Count - 1;
						for (int j = num2; j >= 0; j += -1)
						{
							if (Operators.ConditionalCompareObjectEqual(DGMascaras.Rows[j].Cells[0].Value, item, TextCompare: true))
							{
								DGMascaras.Rows.RemoveAt(j);
								DeclaracoesGeral._uscPagina.pbPasso();
								break;
							}
						}
					}
					int num3 = DGMascaras.Rows.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						int num4 = Information.UBound(WMgpWSL2vjs) + 1;
						ref Declaracoes2.MModeloDeMascara[] wMgpWSL2vjs = ref WMgpWSL2vjs;
						wMgpWSL2vjs = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(wMgpWSL2vjs, new Declaracoes2.MModeloDeMascara[num4 + 1]);
						WMgpWSL2vjs[num4].iIndiceModelo = Conversions.ToInteger(DGMascaras.Rows[k].Cells[0].Value);
						WMgpWSL2vjs[num4].sNomeModelo = Conversions.ToString(DGMascaras.Rows[k].Cells[1].Value);
						WMgpWSL2vjs[num4].iLM1 = Conversions.ToInteger(DGMascaras.Rows[k].Cells[2].Value);
						WMgpWSL2vjs[num4].iLM2 = Conversions.ToInteger(DGMascaras.Rows[k].Cells[3].Value);
						WMgpWSL2vjs[num4].sBlocoTopografico = Conversions.ToString(DGMascaras.Rows[k].Cells[4].Value);
						WMgpWSL2vjs[num4].sBlocoLayout = Conversions.ToString(DGMascaras.Rows[k].Cells[5].Value);
					}
					DicionarioMascaras.GravaOsModelosDeMascara(WMgpWSL2vjs);
					mostraModeloMascara();
					DeclaracoesGeral._uscPagina.pbFim();
					DataGridView dg = DGMascaras;
					clsMascara.AtualizaColunasDGModelos(ref dg);
					DGMascaras = dg;
					clsPortas.SincronizaPortas();
				}
			}
			ModelosBotoesVisiveis(bOpcao: true);
			marcaUdoDosModelos(Nj5pWCKSi8n);
		}
	}

	private void y3rz1HDBB4(object P_0, DataGridViewCellEventArgs P_1)
	{
		TBEFC.BackColor = Color.White;
		TBEFC.ForeColor = Color.Black;
		mostraPortas();
	}

	private void UKpzldmBqO(object P_0, KeyEventArgs P_1)
	{
		TBEFC.BackColor = Color.White;
		TBEFC.ForeColor = Color.Black;
		mostraPortas();
	}

	private void lqNz5kU0HM(object P_0, KeyEventArgs P_1)
	{
		TBEFC.BackColor = Color.White;
		TBEFC.ForeColor = Color.Black;
		mostraPortas();
	}

	public void mostraPortas()
	{
		checked
		{
			if (clsRegua.VerificaRegua())
			{
				bool flag = false;
				int num = DGPortas.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (DGPortas.Rows[i].Selected)
					{
						flag = true;
					}
				}
				if (!flag & (DGPortas.Rows.Count > 0))
				{
					DGPortas.Rows[0].Selected = true;
				}
				int num2 = DGPortas.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (DGPortas.Rows[j].Selected)
					{
						B6qpWimJUPB = Conversions.ToInteger(DGPortas.Rows[j].Cells[0].Value);
						TBEFC.Text = Conversions.ToString(DGPortas.Rows[j].Cells[2].Value);
						TBTerminais.Text = Conversions.ToString(DGPortas.Rows[j].Cells[3].Value);
						TBOrientacao.Text = Conversions.ToString(DGPortas.Rows[j].Cells[4].Value);
						TBRegua.Text = Conversions.ToString(DGPortas.Rows[j].Cells[5].Value);
						TBBornes.Text = Conversions.ToString(DGPortas.Rows[j].Cells[6].Value);
						DeclaracoesEntidades.StructurePortas[] mPORTAS = new DeclaracoesEntidades.StructurePortas[1];
						clsDispositivoMascaras.PesquisaPortasUsadasDosModelos(L0FpWZgIhYI, B6qpWimJUPB, ref mPORTAS);
						DataGridView dg = DGPortasInseridas;
						clsDispositivoMascaras.carregaPortasUsadasDosModelos(ref dg, ref mPORTAS);
						DGPortasInseridas = dg;
						dg = DGPortasInseridas;
						AtualizaColunasDGPortasUsadasDosModelos(ref dg);
						DGPortasInseridas = dg;
						break;
					}
				}
			}
			VerificaEntradaDeDados();
		}
	}

	private void VkAz0p6s2W(object P_0, EventArgs P_1)
	{
		PortasBotoesVisiveis(bOpcao: false);
		bool flag = false;
		checked
		{
			int num = DGMascaras.Rows.Count - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (DGMascaras.Rows[i].Selected)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				TBEFC.BackColor = Color.White;
				TBEFC.ForeColor = Color.Black;
				int indiceDaPorta = UMrpW4fhjTY[Information.UBound(UMrpW4fhjTY)].IndiceDaPorta + 1;
				int num2 = Information.UBound(UMrpW4fhjTY) + 1;
				ref Declaracoes2.MModeloDePortas[] uMrpW4fhjTY = ref UMrpW4fhjTY;
				uMrpW4fhjTY = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(uMrpW4fhjTY, new Declaracoes2.MModeloDePortas[num2 + 1]);
				UMrpW4fhjTY[0].MaxIndice = num2;
				UMrpW4fhjTY[num2].IndiceDaPorta = indiceDaPorta;
				UMrpW4fhjTY[num2].NomeModelo = Conversions.ToString(DGMascaras.SelectedRows[0].Cells[0].Value);
				UMrpW4fhjTY[num2].sEFC = TBEFC.Text;
				UMrpW4fhjTY[num2].sTerminais = TBTerminais.Text;
				UMrpW4fhjTY[num2].sOrientacao = TBOrientacao.Text;
				UMrpW4fhjTY[num2].sBornes = TBBornes.Text;
				UMrpW4fhjTY[num2].sRegua = TBRegua.Text;
				DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(L0FpWZgIhYI, ref UMrpW4fhjTY);
				mostraModeloMascara();
				if (DGPortas.Rows.Count > 0)
				{
					int num3 = DGPortas.Rows.Count - 1;
					DGPortas.Rows[num3].Selected = true;
					DGPortas.FirstDisplayedScrollingRowIndex = num3;
				}
			}
			PortasBotoesVisiveis(bOpcao: true);
		}
	}

	private void A4LzRhDe7G(object P_0, EventArgs P_1)
	{
		if (DGPortas.Rows.Count == 0)
		{
			return;
		}
		PortasBotoesVisiveis(bOpcao: false);
		bool flag = false;
		string text = TBEFC.Text;
		string sTerminais = TBTerminais.Text;
		_ = TBOrientacao.Text;
		string sRegua = TBRegua.Text;
		string sBornes = TBBornes.Text;
		int indexPorta = 0;
		checked
		{
			int num = DGPortas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGPortas.Rows[i].Selected)
				{
					if (Operators.ConditionalCompareObjectNotEqual(DGPortas.Rows[i].Cells[2].Value, TBEFC.Text, TextCompare: true))
					{
						DGPortas.Rows[i].Cells[2].Value = TBEFC.Text;
						flag = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGPortas.Rows[i].Cells[3].Value, TBTerminais.Text, TextCompare: true))
					{
						DGPortas.Rows[i].Cells[3].Value = TBTerminais.Text;
						flag = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGPortas.Rows[i].Cells[4].Value, TBOrientacao.Text, TextCompare: true))
					{
						DGPortas.Rows[i].Cells[4].Value = TBOrientacao.Text;
						flag = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGPortas.Rows[i].Cells[5].Value, TBRegua.Text, TextCompare: true))
					{
						DGPortas.Rows[i].Cells[5].Value = TBRegua.Text;
						flag = true;
					}
					if (Operators.ConditionalCompareObjectNotEqual(DGPortas.Rows[i].Cells[6].Value, TBBornes.Text, TextCompare: true))
					{
						DGPortas.Rows[i].Cells[6].Value = TBBornes.Text;
						flag = true;
					}
					DGPortas.FirstDisplayedScrollingRowIndex = i;
					indexPorta = Conversions.ToInteger(DGPortas.Rows[i].Cells[0].Value);
					break;
				}
			}
			if (flag)
			{
				clsDispositivoMascaras.carregaMatrizPortas(DGPortas, ref UMrpW4fhjTY);
				DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(L0FpWZgIhYI, ref UMrpW4fhjTY);
				mostraModeloMascara();
				clsPortas.EditaUmaPorta(L0FpWZgIhYI, indexPorta, text, sTerminais, sRegua, sBornes);
			}
			try
			{
				if (Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					int num2 = DGPortas.Rows.Count - 1;
					for (int j = 1; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectEqual(DGPortas.Rows[j].Cells[2].Value, text, TextCompare: true))
						{
							DGPortas.Rows[j].Selected = true;
							DGPortas.FirstDisplayedScrollingRowIndex = j;
							break;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			PortasBotoesVisiveis(bOpcao: true);
		}
	}

	private void bPwzmxwd1x(object P_0, EventArgs P_1)
	{
		if (DGPortas.Rows.Count == 0)
		{
			return;
		}
		PortasBotoesVisiveis(bOpcao: false);
		int num = -1;
		checked
		{
			int num2 = DGPortas.Rows.Count - 1;
			int b6qpWimJUPB = default;
			for (int i = num2; i >= 0; i += -1)
			{
				if (DGPortas.Rows[i].Selected)
				{
					B6qpWimJUPB = Conversions.ToInteger(DGPortas.Rows[i].Cells[0].Value);
					b6qpWimJUPB = B6qpWimJUPB;
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				DGPortas.Rows.RemoveAt(num);
				clsDispositivoMascaras.carregaMatrizPortas(DGPortas, ref UMrpW4fhjTY);
				DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(L0FpWZgIhYI, ref UMrpW4fhjTY);
				mostraModeloMascara();
			}
			clsPortas.IndefinePortasApagadas(L0FpWZgIhYI, b6qpWimJUPB);
			PortasBotoesVisiveis(bOpcao: true);
		}
	}

	private void aCPzXlXRqO(object P_0, DataGridViewCellEventArgs P_1)
	{
		EPfzgj6kYX();
	}

	private void w9QzUsrj70(object P_0, KeyEventArgs P_1)
	{
		EPfzgj6kYX();
	}

	private void fG1zyQ7rIO(object P_0, KeyEventArgs P_1)
	{
		EPfzgj6kYX();
	}

	private void EPfzgj6kYX()
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		if (!Caderno.ExisteFormato())
		{
		}
		if (DGPortasInseridas.Rows.Count == 0)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					int num = DGPortasInseridas.Rows.Count - 1;
					for (int i = num; i >= 0; i += -1)
					{
						if (!DGPortasInseridas.Rows[i].Selected)
						{
							continue;
						}
						string text = DGPortasInseridas.Rows[i].Cells[2].Value.ToString();
						if (Operators.CompareString(text, "", TextCompare: true) == 0)
						{
							break;
						}
						ObjectId val3 = clsBlocos.RetornaID_Bloco(text);
						if (val3.IsValid)
						{
							BlockReference val4 = (BlockReference)val2.GetObject(val3, (OpenMode)0);
							try
							{
								Pagina.AtivaPagina(((Entity)val4).Layer);
								uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
								string pag = ((Entity)val4).Layer.ToString();
								uscPagina.ativaPaginaAtalho(ref pag);
								Caderno.ZEntity(((DBObject)val4).ObjectId);
							}
							finally
							{
								((IDisposable)val4)?.Dispose();
							}
						}
						break;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	private void Ax3zAK8iX1(object P_0, EventArgs P_1)
	{
		bool flag = true;
		if (DGPortas.Rows.Count == 0)
		{
			flag = false;
		}
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		DGPortasInseridas.Rows.Clear();
		DGPortasInseridas.Columns.Clear();
		bool flag2 = false;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false);
		if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.ToUpper()
			.Trim(), DeclaracoesGeral.mMensagem[1, 1846].ToString().ToUpper().Trim(), TextCompare: true) == 0)
		{
			flag2 = true;
		}
		string text = "";
		text = (flag2 ? clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)"J2", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))) : clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)"I2", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))));
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		MsgBoxResult msgBoxResult = MsgBoxResult.No;
		string text2 = "";
		text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1703], TBModelo.Text), ", "), DeclaracoesGeral.mMensagem[1, 1704]), text), "?"));
		msgBoxResult = Interaction.MsgBox(text2, MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		clsTrocaEditaBlocos.LeTodosAtributos();
		checked
		{
			int num = DGMascaras.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(DGMascaras.Rows[i].Cells[1].Value, text, TextCompare: true) && !DGMascaras.Rows[i].Selected)
				{
					text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1705], text.ToString()), "."), "\r\n"), DeclaracoesGeral.mMensagem[1, 1706]), DGMascaras.Rows[i].Cells[0].Value.ToString()));
					Interaction.MsgBox(text2, MsgBoxStyle.SystemModal, "Elétron");
					ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false);
					if (!flag2)
					{
						((_Worksheet)oSheet).get_Range((object)"I2", RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
					}
					else
					{
						((_Worksheet)oSheet).get_Range((object)"J2", RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
					}
					return;
				}
			}
			GroupBoxMascara.Enabled = false;
			GroupBoxPorta.Enabled = false;
			int num2 = -1;
			if (DGMascaras.Rows.Count - 1 != 0)
			{
			}
			int num3 = DGMascaras.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if (DGMascaras.Rows[j].Selected)
				{
					num2 = Conversions.ToInteger(DGMascaras.Rows[j].Cells[0].Value);
					break;
				}
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int num4 = DGPortas.Rows.Count - 1;
			for (int k = 0; k <= num4; k++)
			{
				list.Add(Conversions.ToInteger(DGPortas.Rows[k].Cells[0].Value));
			}
			if (num2 != -1)
			{
				bool flag3 = false;
				if (!(flag2 ? excPortas.ExisteIndicesIguaisNasMascarasNovas(ref oSheet) : excPortas.ExisteIndicesIguaisNasMascarasAntigas(ref oSheet)))
				{
					bool bComplemento = false;
					string sMOdelo = "";
					string sLm = "";
					string sLm2 = "";
					string sTopo = "";
					string sLay = "";
					if (!flag2)
					{
						excPortas.ImportaPortasMascaraAntiga(ref oSheet, ref UMrpW4fhjTY, ref bComplemento, ref sMOdelo, ref sLm, ref sLm2, ref sTopo, ref sLay);
					}
					else
					{
						excPortas.ImportaPortasMascaraNova(ref oSheet, ref UMrpW4fhjTY, ref bComplemento, ref sMOdelo, ref sLm, ref sLm2, ref sTopo, ref sLay);
					}
					DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(L0FpWZgIhYI, ref UMrpW4fhjTY);
					DataGridView dg = DGPortas;
					clsDispositivoMascaras.carregaContatosNoDGMascara(ref dg, ref UMrpW4fhjTY, bPintaDG: false);
					DGPortas = dg;
					dg = DGPortas;
					AtualizaColunasDGPortasMascara(ref dg);
					DGPortas = dg;
					TBEFC.Text = "";
					TBTerminais.Text = "";
					TBRegua.Text = "";
					TBBornes.Text = "";
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(UMrpW4fhjTY);
					DeclaracoesGeral._uscPagina.pbIniciar();
					if (flag)
					{
						int num5 = Information.UBound(UMrpW4fhjTY);
						for (int l = 1; l <= num5; l++)
						{
							clsPortas.EditaUmaPorta(L0FpWZgIhYI, UMrpW4fhjTY[l].IndiceDaPorta, UMrpW4fhjTY[l].sEFC, UMrpW4fhjTY[l].sTerminais, UMrpW4fhjTY[l].sRegua, UMrpW4fhjTY[l].sBornes);
							DeclaracoesGeral._uscPagina.pbPasso();
						}
					}
					int num6 = DGPortas.Rows.Count - 1;
					for (int m = 0; m <= num6; m++)
					{
						list2.Add(Conversions.ToInteger(DGPortas.Rows[m].Cells[0].Value));
					}
					if (list.Count - 1 > 0)
					{
						clsPortas.AtualizaPortasImportadasDoExcel(L0FpWZgIhYI, list, list2);
					}
					if (bComplemento)
					{
						if (Operators.CompareString(sMOdelo.Trim(), "", TextCompare: true) != 0)
						{
							TBModelo.Text = sMOdelo;
						}
						yuSzcqjrTY(Conversions.ToInteger(sLm), 1);
						yuSzcqjrTY(Conversions.ToInteger(sLm2), 2);
						if (Operators.CompareString(sTopo, tbBlocoTopografico.Text, TextCompare: true) != 0)
						{
							tbBlocoTopografico.Text = sTopo;
						}
						if (Operators.CompareString(sLay, tbBlocoLayout.Text, TextCompare: true) != 0)
						{
							tbBlocoLayout.Text = sLay;
						}
					}
					DeclaracoesGeral._uscPagina.pbFim();
				}
				else
				{
					Interaction.MsgBox(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1192], TBModelo.Text), MsgBoxStyle.SystemModal, "Elétron");
				}
			}
			XcPz2XLTyp();
			GroupBoxMascara.Enabled = true;
			GroupBoxPorta.Enabled = true;
			marcaUdoDosModelos(Nj5pWCKSi8n);
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.SendStringToExecute("CorrigeAtributosSemMsg\n", true, false, true);
		}
	}

	private void LkyzsPiIli(object P_0, EventArgs P_1)
	{
		int iIndiceSelecionado = -1;
		checked
		{
			int num = DGMascaras.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGMascaras.Rows[i].Selected)
				{
					iIndiceSelecionado = Conversions.ToInteger(DGMascaras.Rows[i].Cells[0].Value);
					break;
				}
			}
			if (iIndiceSelecionado != -1)
			{
				BTExportaEX.Enabled = false;
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string sNomeModelo = Conversions.ToString(DGMascaras.SelectedRows[0].Cells[0].Value);
				DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado, sNomeModelo, ref UMrpW4fhjTY);
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, TBModelo.Text);
				if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
				{
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				}
				excPortas.ExportaPortas(ref oSheet, ref UMrpW4fhjTY, TBModelo.Text, tbCodigo1.Text, tbCodigo2.Text, tbBlocoTopografico.Text, tbBlocoLayout.Text);
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				BTExportaEX.Enabled = true;
			}
			marcaUdoDosModelos(Nj5pWCKSi8n);
		}
	}

	private void GfjzB369Bt(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = TBModelo;
		clsTextos.NomeValido(ref tbNome);
		TBModelo = tbNome;
		TBModelo.BackColor = Color.White;
		TBModelo.ForeColor = Color.Black;
	}

	private void sfizVUeQSq(object P_0, EventArgs P_1)
	{
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaTopografico, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaTopografico)))
		{
			tbBlocoTopografico.BackColor = Color.Silver;
			return;
		}
		tbBlocoTopografico.BackColor = Color.White;
		DeclaracoesGeral.gsCaminhoBloco = DeclaracoesGeral.Conf.dirSimbologiaTopografico;
		frmVisualizarBloco frmVisualizarBloco2 = new frmVisualizarBloco();
		Application.ShowModalDialog((Form)frmVisualizarBloco2);
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoTopografico.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	private void EGtzu0v9LJ(object P_0, EventArgs P_1)
	{
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout)))
		{
			tbBlocoLayout.BackColor = Color.Silver;
			return;
		}
		tbBlocoLayout.BackColor = Color.White;
		DeclaracoesGeral.gsCaminhoBloco = DeclaracoesGeral.Conf.dirSimbologiaLayout;
		frmVisualizarBloco frmVisualizarBloco2 = new frmVisualizarBloco();
		Application.ShowModalDialog((Form)frmVisualizarBloco2);
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoLayout.Text = DeclaracoesGeral.gsCaminhoBloco;
		}
	}

	public static void AtualizaColunasDGPortasMascara(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				num -= 115.0;
				dg.Columns[0].Width = 50;
				dg.Columns[1].Width = 0;
				dg.Columns[2].Width = (int)Math.Round(num * 0.2);
				dg.Columns[3].Width = (int)Math.Round(num * 0.3);
				dg.Columns[4].Width = 65;
				dg.Columns[5].Width = (int)Math.Round(num * 0.3);
				dg.Columns[6].Width = (int)Math.Round(num * 0.2);
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[2].Visible = true;
				dg.Columns[3].Visible = true;
				dg.Columns[4].Visible = true;
				dg.Columns[5].Visible = true;
				dg.Columns[6].Visible = true;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
				dg.Columns[4].ReadOnly = false;
				dg.Columns[5].ReadOnly = false;
				dg.Columns[6].ReadOnly = false;
				dg.MultiSelect = false;
			}
		}
	}

	public static void AtualizaColunasDGPortasUsadasDosModelos(ref DataGridView dg)
	{
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			if (dg.RowCount != 0)
			{
				dg.ColumnHeadersVisible = true;
				dg.Columns[0].Width = (int)Math.Round(num * 0.5);
				dg.Columns[1].Width = (int)Math.Round(num * 0.5);
				dg.Columns[2].Width = 0;
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.MultiSelect = true;
				int num2 = dg.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					dg.Rows[i].Selected = false;
				}
			}
		}
	}

	public void ModelosBotoesVisiveis(bool bOpcao)
	{
		GroupBoxMascara.Enabled = bOpcao;
		GroupBoxPorta.Enabled = bOpcao;
	}

	public void PortasBotoesVisiveis(bool bOpcao)
	{
		BTAdicionaPorta.Enabled = bOpcao;
		BTEditaPorta.Enabled = bOpcao;
		BTApagaPorta.Enabled = bOpcao;
	}

	private void nHazEVh24a(object P_0, KeyEventArgs P_1)
	{
		bool flag = true;
		int count = DGPortas.Rows.Count;
		for (int i = 1; i <= count; i = checked(i + 1))
		{
			TBEFC.BackColor = Color.White;
			TBEFC.ForeColor = Color.Black;
			if (Operators.CompareString(TBEFC.Text.Trim(), "", TextCompare: true) == 0)
			{
				break;
			}
			if (Operators.CompareString(UMrpW4fhjTY[i].sEFC.ToUpper(), TBEFC.Text.ToUpper(), TextCompare: true) == 0)
			{
				TBEFC.BackColor = Color.Red;
				TBEFC.ForeColor = Color.White;
				flag = false;
			}
		}
		if (flag)
		{
			VerificaEntradaDeDados();
		}
	}

	private void IEEzZjnYnA(object P_0, EventArgs P_1)
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.White;
		checked
		{
			int num = DGPortas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				DGPortas.Rows[i].Cells[3].Style = dataGridViewCellStyle2;
				DGPortas.Rows[i].Cells[5].Style = dataGridViewCellStyle2;
				DGPortas.Rows[i].Cells[6].Style = dataGridViewCellStyle2;
				DGPortas[3, i].ErrorText = "";
				DGPortas[5, i].ErrorText = "";
			}
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			bool flag = false;
			int num2 = DGPortas.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				List<string> lTerminais = new List<string>();
				Geral.DivideTerminais(ref lTerminais, Conversions.ToString(DGPortas.Rows[j].Cells[3].Value), bRepete: true);
				foreach (string item in lTerminais)
				{
					if (Operators.CompareString(item.Trim(), "", TextCompare: true) != 0)
					{
						if (list.Contains(item))
						{
							list3.Add(item);
						}
						else
						{
							list.Add(item);
						}
					}
				}
				List<string> lTerminais2 = new List<string>();
				Geral.DivideTerminais(ref lTerminais2, Conversions.ToString(DGPortas.Rows[j].Cells[5].Value), bRepete: true);
				List<string> lTerminais3 = new List<string>();
				Geral.DivideTerminais(ref lTerminais3, Conversions.ToString(DGPortas.Rows[j].Cells[6].Value), bRepete: true);
				if (lTerminais2.Count != lTerminais3.Count)
				{
					if (!((lTerminais2.Count == 1) & (lTerminais3.Count > 1)))
					{
						continue;
					}
					int num3 = lTerminais3.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						string text = lTerminais2[0] + ":" + lTerminais3[k];
						text = text.Replace("*", "");
						text = text.ToUpper();
						if (list2.Contains(text))
						{
							list4.Add(text);
						}
						else
						{
							list2.Add(text);
						}
					}
					continue;
				}
				int num4 = lTerminais2.Count - 1;
				for (int l = 0; l <= num4; l++)
				{
					string text2 = lTerminais2[l] + ":" + lTerminais3[l];
					text2 = text2.ToUpper();
					if (list2.Contains(text2))
					{
						list4.Add(text2);
					}
					else
					{
						list2.Add(text2);
					}
				}
			}
			int num5 = DGPortas.Rows.Count - 1;
			for (int m = 0; m <= num5; m++)
			{
				List<string> lTerminais4 = new List<string>();
				Geral.DivideTerminais(ref lTerminais4, Conversions.ToString(DGPortas.Rows[m].Cells[3].Value), bRepete: true);
				foreach (string item2 in lTerminais4)
				{
					if (Operators.CompareString(item2.Trim(), "", TextCompare: true) != 0 && list3.Contains(item2))
					{
						if (Operators.CompareString(DGPortas[3, m].ErrorText, "", TextCompare: true) != 0)
						{
							DGPortas[3, m].ErrorText = DGPortas[3, m].ErrorText + item2 + "; ";
						}
						else
						{
							DGPortas[3, m].ErrorText = item2 + "; ";
						}
						DGPortas.Rows[m].Cells[3].Style = dataGridViewCellStyle;
						if (!flag & (m > 18))
						{
							DGPortas.FirstDisplayedScrollingRowIndex = m - 4;
							flag = true;
						}
					}
				}
				List<string> lTerminais5 = new List<string>();
				Geral.DivideTerminais(ref lTerminais5, Conversions.ToString(DGPortas.Rows[m].Cells[5].Value), bRepete: true);
				List<string> lTerminais6 = new List<string>();
				Geral.DivideTerminais(ref lTerminais6, Conversions.ToString(DGPortas.Rows[m].Cells[6].Value), bRepete: true);
				if (lTerminais5.Count != lTerminais6.Count)
				{
					if (!((lTerminais5.Count == 1) & (lTerminais6.Count > 1)))
					{
						continue;
					}
					int num6 = lTerminais6.Count - 1;
					for (int n = 0; n <= num6; n++)
					{
						string text3 = lTerminais5[0] + ":" + lTerminais6[n];
						text3 = text3.Replace("*", "");
						text3 = text3.ToUpper();
						if (list4.Contains(text3) & (Operators.CompareString(text3, ":", TextCompare: true) != 0))
						{
							if (Operators.CompareString(DGPortas[5, m].ErrorText, "", TextCompare: true) != 0)
							{
								DGPortas[5, m].ErrorText = DGPortas[5, m].ErrorText + text3 + "; ";
							}
							else
							{
								DGPortas[5, m].ErrorText = text3 + "; ";
							}
							DGPortas.Rows[m].Cells[5].Style = dataGridViewCellStyle;
							DGPortas.Rows[m].Cells[6].Style = dataGridViewCellStyle;
							if (!flag & (m > 18))
							{
								DGPortas.FirstDisplayedScrollingRowIndex = m - 4;
								flag = true;
							}
						}
					}
					continue;
				}
				int num7 = lTerminais5.Count - 1;
				for (int num8 = 0; num8 <= num7; num8++)
				{
					string text4 = lTerminais5[num8] + ":" + lTerminais6[num8];
					text4 = text4.ToUpper();
					if (list4.Contains(text4) & (Operators.CompareString(text4, ":", TextCompare: true) != 0))
					{
						if (Operators.CompareString(DGPortas[5, m].ErrorText, "", TextCompare: true) != 0)
						{
							DGPortas[5, m].ErrorText = DGPortas[5, m].ErrorText + text4 + "; ";
						}
						else
						{
							DGPortas[5, m].ErrorText = text4 + "; ";
						}
						DGPortas.Rows[m].Cells[5].Style = dataGridViewCellStyle;
						DGPortas.Rows[m].Cells[6].Style = dataGridViewCellStyle;
						if (!flag & (m > 18))
						{
							DGPortas.FirstDisplayedScrollingRowIndex = m - 4;
							flag = true;
						}
					}
				}
			}
		}
	}

	private void smAziwxFyb(object P_0, KeyEventArgs P_1)
	{
		VerificaEntradaDeDados();
	}

	private void CPOzSSyGXW(object P_0, KeyEventArgs P_1)
	{
		VerificaEntradaDeDados();
	}

	private void uCZz4vJgWO(object P_0, KeyEventArgs P_1)
	{
		VerificaEntradaDeDados();
	}

	private void ntBzCD5ekH(object P_0, KeyEventArgs P_1)
	{
		VerificaEntradaDeDados();
	}

	public void VerificaEntradaDeDados()
	{
		BTAdicionaPorta.Enabled = true;
		BTEditaPorta.Enabled = true;
		TBEFC.BackColor = Color.White;
		TBEFC.ForeColor = Color.Black;
		TBTerminais.BackColor = Color.White;
		TBTerminais.ForeColor = Color.Black;
		TBOrientacao.BackColor = Color.White;
		TBOrientacao.ForeColor = Color.Black;
		TBRegua.BackColor = Color.White;
		TBRegua.ForeColor = Color.Black;
		TBBornes.BackColor = Color.White;
		TBBornes.ForeColor = Color.Black;
		if (Operators.CompareString(TBEFC.Text, TBEFC.Text.Replace("'", "`"), TextCompare: true) != 0)
		{
			TBEFC.BackColor = Color.Red;
			TBEFC.ForeColor = Color.White;
			BTAdicionaPorta.Enabled = false;
			BTEditaPorta.Enabled = false;
		}
		if (Operators.CompareString(TBTerminais.Text, TBTerminais.Text.Replace("'", "`"), TextCompare: true) != 0)
		{
			TBTerminais.BackColor = Color.Red;
			TBTerminais.ForeColor = Color.White;
			BTAdicionaPorta.Enabled = false;
			BTEditaPorta.Enabled = false;
		}
		checked
		{
			if (Operators.CompareString(TBOrientacao.Text, "", TextCompare: true) != 0)
			{
				int num = 0;
				string text = TBTerminais.Text + ";";
				string[] array = text.Split(';');
				int num2 = Information.UBound(array);
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.CompareString(array[i].ToString().Trim(), "", TextCompare: true) != 0)
					{
						num++;
					}
				}
				TBOrientacao.Text = TBOrientacao.Text.ToUpper();
				string text2 = TBOrientacao.Text.Trim();
				text2 = text2.Replace("NN", "N");
				text2 = text2.Replace("SS", "S");
				text2 = text2.Replace("NS", "N");
				text2 = text2.Replace("SN", "S");
				string text3 = "";
				int num3 = 0;
				int num4 = Strings.Len(text2);
				for (int j = 1; j <= num4; j++)
				{
					string text4 = Strings.Mid(text2, j, 1);
					if ((Operators.CompareString(text4, "N", TextCompare: true) == 0) | (Operators.CompareString(text4, "S", TextCompare: true) == 0) | (Operators.CompareString(text4, ";", TextCompare: true) == 0))
					{
						if ((Operators.CompareString(text4, "N", TextCompare: true) == 0) | (Operators.CompareString(text4, "S", TextCompare: true) == 0))
						{
							num3++;
						}
						if (num3 <= num)
						{
							text3 += text4;
						}
					}
				}
				text3 = text3.Replace(";;", ";");
				if (Operators.CompareString(text3, ";", TextCompare: true) == 0)
				{
					text3 = "";
				}
				TBOrientacao.Text = text3;
				if (Operators.ConditionalCompareObjectNotEqual(text3, DGPortas.SelectedRows[0].Cells[4].Value, TextCompare: true))
				{
					BTAdicionaPorta.Enabled = false;
					BTEditaPorta.Enabled = true;
				}
				TBOrientacao.SelectionStart = TBOrientacao.Text.Length;
			}
			int num5 = DivideValores(TBRegua.Text);
			int num6 = DivideValores(TBBornes.Text.Replace("*", ""));
			if (!((num5 == 1) & (num6 > 0)) && num5 != num6)
			{
				TBRegua.ForeColor = Color.White;
				TBRegua.BackColor = Color.Red;
				TBBornes.ForeColor = Color.White;
				TBBornes.BackColor = Color.Red;
				BTAdicionaPorta.Enabled = false;
				BTEditaPorta.Enabled = false;
			}
			if (Operators.CompareString(TBRegua.Text, TBRegua.Text.Replace("'", "`"), TextCompare: true) != 0)
			{
				TBRegua.BackColor = Color.Red;
				TBRegua.ForeColor = Color.White;
				BTAdicionaPorta.Enabled = false;
				BTEditaPorta.Enabled = false;
			}
			if (Operators.CompareString(TBBornes.Text, TBBornes.Text.Replace("'", "`"), TextCompare: true) != 0)
			{
				TBBornes.BackColor = Color.Red;
				TBBornes.ForeColor = Color.White;
				BTAdicionaPorta.Enabled = false;
				BTEditaPorta.Enabled = false;
			}
			if (Operators.CompareString(TBRegua.Text, TBRegua.Text.Replace("*", ""), TextCompare: true) != 0)
			{
				TBRegua.Text = TBRegua.Text.Replace("*", "");
			}
		}
	}

	public static int DivideValores(string sValor)
	{
		int num = 0;
		List<string> lTerminais = new List<string>();
		Geral.DivideTerminais(ref lTerminais, sValor, bRepete: true);
		foreach (string item in lTerminais)
		{
			if (Operators.CompareString(item.Trim(), "", TextCompare: true) != 0)
			{
				num = checked(num + 1);
			}
		}
		return num;
	}

	public string BuscaNumeroDoMaterial(string sNum)
	{
		string text = "";
		if (Operators.CompareString(sNum.Trim(), "", TextCompare: true) != 0)
		{
			sNum = sNum.ToString().Trim();
			int num = Strings.Len(sNum);
			for (int i = 1; i <= num && Versioned.IsNumeric(Strings.Mid(sNum, i, 1)); i = checked(i + 1))
			{
				text += Strings.Mid(sNum, i, 1);
			}
		}
		return text;
	}

	public void marcaUdoDosModelos(List<int> lModelosUsados)
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.LightGreen;
		int num = -1;
		checked
		{
			int num2 = DGMascaras.Rows.Count - 1;
			for (int i = num2; i >= 0; i += -1)
			{
				if (DGMascaras.Rows[i].Selected)
				{
					num = Conversions.ToInteger(DGMascaras.Rows[i].Cells[0].Value);
				}
			}
			int num3 = DGMascaras.Rows.Count - 1;
			for (int j = num3; j >= 0; j += -1)
			{
				if (!lModelosUsados.Contains(Conversions.ToInteger(DGMascaras.Rows[j].Cells[0].Value)))
				{
					DGMascaras.Rows[j].Cells[0].Style = dataGridViewCellStyle2;
				}
				else
				{
					DGMascaras.Rows[j].Cells[0].Style = dataGridViewCellStyle;
				}
			}
			int num4 = DGMascaras.Rows.Count - 1;
			int num5 = num4;
			while (true)
			{
				if (num5 >= 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.CompareObjectEqual(num, DGMascaras.Rows[num5].Cells[0].Value, TextCompare: true), true, TextCompare: true))
					{
						break;
					}
					num5 += -1;
					continue;
				}
				return;
			}
			DGMascaras.Rows[num5].Selected = true;
		}
	}

	private void DSLzYitgUH(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo1.Text));
		tbCodigo1.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum1.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo1.Text = frmPesquisaMateriais2.modelo;
		tbFabricante1.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}

	private void hjQzrovvlH(object P_0, EventArgs P_1)
	{
		frmPesquisaMateriais frmPesquisaMateriais2 = new frmPesquisaMateriais(Conversions.ToInteger(tbCodigo2.Text));
		tbCodigo2.Text = Conversions.ToString(frmPesquisaMateriais2.codigoInterno);
		tbDescricaoResum2.Text = frmPesquisaMateriais2.descricaoResumida;
		tbModelo2.Text = frmPesquisaMateriais2.modelo;
		tbFabricante2.Text = frmPesquisaMateriais2.fabricante;
		frmPesquisaMateriais2.Dispose();
	}

	private void WXCz919CZj(object P_0, EventArgs P_1)
	{
		DataGridView dg = DGMascaras;
		clsMascara.AtualizaColunasDGModelos(ref dg);
		DGMascaras = dg;
		dg = DGPortas;
		AtualizaColunasDGPortasMascara(ref dg);
		DGPortas = dg;
	}
}
