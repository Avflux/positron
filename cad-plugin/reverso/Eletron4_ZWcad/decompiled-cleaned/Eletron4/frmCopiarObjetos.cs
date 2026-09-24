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
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmCopiarObjetos : Form
{
	private IContainer IPqBiChfps;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCopiar")]
	private Button KSWBSCQQxa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btColar")]
	private Button WdeB48PaMM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox RVbBCRdDFp;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label sREBYn7wy4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label dAFBrWjGWY;

	[AccessedThroughProperty("tbDy")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox VfvB9tUBpY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDx")]
	[CompilerGenerated]
	private TextBox XTEBzN0Hyk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip xxbVWrW32D;

	[AccessedThroughProperty("lbTotal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label BgQVp72lLL;

	[AccessedThroughProperty("cbBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox N8sVTwl4QA;

	[AccessedThroughProperty("cbPortas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox QHnVJ6Msy6;

	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox Uo5VhvLuZo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	private DataGridView KgfVofcTrk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbRevisoes")]
	[CompilerGenerated]
	private CheckBox en1VGEf3Kx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAtualizarOrigem")]
	private Button ENPVHRUIV2;

	private string NqkVkBMWVj;

	private ObjectIdCollection YTCVdDSiFO;

	private Document PoiVftDSC1;

	private Document eqyVDuknPM;

	private ObjectIdCollection E4hVvUi4if;

	private string bPTV6aXuLk;

	private double vU1VtuL4mu;

	private double EmaVjYAVNe;

	private string[,] gYxVLmISmN;

	private string yAaVwioONs;

	private string YUiVxiu8Nm;

	private int UYFVbyU2Qg;

	private double Ec4VM2IqZu;

	internal virtual Button btCopiar
	{
		[CompilerGenerated]
		get
		{
			return KSWBSCQQxa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jJOBgaTtBx;
			Button button = KSWBSCQQxa;
			if (button != null)
			{
				button.Click -= value2;
			}
			KSWBSCQQxa = value;
			button = KSWBSCQQxa;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btColar
	{
		[CompilerGenerated]
		get
		{
			return WdeB48PaMM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ljFBA5oDKP;
			Button button = WdeB48PaMM;
			if (button != null)
			{
				button.Click -= value2;
			}
			WdeB48PaMM = value;
			button = WdeB48PaMM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return RVbBCRdDFp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RVbBCRdDFp = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return sREBYn7wy4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sREBYn7wy4 = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return dAFBrWjGWY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dAFBrWjGWY = value;
		}
	}

	internal virtual TextBox tbDy
	{
		[CompilerGenerated]
		get
		{
			return VfvB9tUBpY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = goaBumeNxo;
			TextBox textBox = VfvB9tUBpY;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			VfvB9tUBpY = value;
			textBox = VfvB9tUBpY;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbDx
	{
		[CompilerGenerated]
		get
		{
			return XTEBzN0Hyk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = uS0BVxowSr;
			TextBox textBox = XTEBzN0Hyk;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			XTEBzN0Hyk = value;
			textBox = XTEBzN0Hyk;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label lbTotal
	{
		[CompilerGenerated]
		get
		{
			return BgQVp72lLL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BgQVp72lLL = value;
		}
	}

	internal virtual CheckBox cbBornes
	{
		[CompilerGenerated]
		get
		{
			return N8sVTwl4QA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			N8sVTwl4QA = value;
		}
	}

	internal virtual CheckBox cbPortas
	{
		[CompilerGenerated]
		get
		{
			return QHnVJ6Msy6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QHnVJ6Msy6 = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return Uo5VhvLuZo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Uo5VhvLuZo = value;
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return KgfVofcTrk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KgfVofcTrk = value;
		}
	}

	internal virtual CheckBox cbRevisoes
	{
		[CompilerGenerated]
		get
		{
			return en1VGEf3Kx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			en1VGEf3Kx = value;
		}
	}

	internal virtual Button btAtualizarOrigem
	{
		[CompilerGenerated]
		get
		{
			return ENPVHRUIV2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = U07BEl1PAK;
			Button button = ENPVHRUIV2;
			if (button != null)
			{
				button.Click -= value2;
			}
			ENPVHRUIV2 = value;
			button = ENPVHRUIV2;
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
			if (disposing && IPqBiChfps != null)
			{
				IPqBiChfps.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void BvlBmJcvOt()
	{
		IPqBiChfps = new Container();
		btCopiar = new Button();
		btColar = new Button();
		GroupBox1 = new GroupBox();
		Label2 = new Label();
		Label1 = new Label();
		tbDy = new TextBox();
		tbDx = new TextBox();
		FDqpBiUmZij(new ToolTip(IPqBiChfps));
		lbTotal = new Label();
		cbBornes = new CheckBox();
		cbPortas = new CheckBox();
		GroupBox2 = new GroupBox();
		cbRevisoes = new CheckBox();
		dg = new DataGridView();
		btAtualizarOrigem = new Button();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dg).BeginInit();
		SuspendLayout();
		btCopiar.FlatStyle = FlatStyle.Flat;
		btCopiar.ForeColor = SystemColors.Control;
		btCopiar.Image = Resources.Copy_32;
		btCopiar.Location = new Point(11, 12);
		btCopiar.Name = "btCopiar";
		btCopiar.Size = new Size(40, 40);
		btCopiar.TabIndex = 7;
		btCopiar.UseVisualStyleBackColor = true;
		btColar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btColar.FlatStyle = FlatStyle.Flat;
		btColar.ForeColor = SystemColors.Control;
		btColar.Image = Resources.Paste_32;
		btColar.Location = new Point(118, 388);
		btColar.Name = "btColar";
		btColar.Size = new Size(40, 40);
		btColar.TabIndex = 12;
		btColar.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(Label2);
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(tbDy);
		GroupBox1.Controls.Add(tbDx);
		GroupBox1.Location = new Point(12, 366);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(91, 77);
		GroupBox1.TabIndex = 14;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Deslocamento";
		Label2.AutoSize = true;
		Label2.Location = new Point(6, 48);
		Label2.Name = "Label2";
		Label2.Size = new Size(14, 13);
		Label2.TabIndex = 3;
		Label2.Text = "Y";
		Label1.AutoSize = true;
		Label1.Location = new Point(6, 23);
		Label1.Name = "Label1";
		Label1.Size = new Size(14, 13);
		Label1.TabIndex = 2;
		Label1.Text = "X";
		tbDy.Location = new Point(26, 45);
		tbDy.Name = "tbDy";
		tbDy.Size = new Size(38, 20);
		tbDy.TabIndex = 1;
		tbDx.Location = new Point(26, 19);
		tbDx.Name = "tbDx";
		tbDx.Size = new Size(38, 20);
		tbDx.TabIndex = 0;
		lbTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbTotal.AutoSize = true;
		lbTotal.Location = new Point(9, 544);
		lbTotal.Name = "lbTotal";
		lbTotal.Size = new Size(77, 13);
		lbTotal.TabIndex = 4;
		lbTotal.Text = "Selecionados: ";
		lbTotal.TextAlign = ContentAlignment.MiddleCenter;
		cbBornes.AutoSize = true;
		cbBornes.Location = new Point(6, 24);
		cbBornes.Name = "cbBornes";
		cbBornes.Size = new Size(71, 17);
		cbBornes.TabIndex = 15;
		cbBornes.Text = "cbBornes";
		cbBornes.UseVisualStyleBackColor = true;
		cbPortas.AutoSize = true;
		cbPortas.Location = new Point(83, 24);
		cbPortas.Name = "cbPortas";
		cbPortas.Size = new Size(68, 17);
		cbPortas.TabIndex = 16;
		cbPortas.Text = "cbPortas";
		cbPortas.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(cbRevisoes);
		GroupBox2.Controls.Add(cbPortas);
		GroupBox2.Controls.Add(cbBornes);
		GroupBox2.Location = new Point(12, 457);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(154, 79);
		GroupBox2.TabIndex = 17;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		cbRevisoes.AutoSize = true;
		cbRevisoes.Location = new Point(6, 47);
		cbRevisoes.Name = "cbRevisoes";
		cbRevisoes.Size = new Size(82, 17);
		cbRevisoes.TabIndex = 17;
		cbRevisoes.Text = "cbRevisões";
		cbRevisoes.UseVisualStyleBackColor = true;
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = Color.White;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(11, 58);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(152, 301);
		dg.TabIndex = 19;
		btAtualizarOrigem.FlatStyle = FlatStyle.Flat;
		btAtualizarOrigem.ForeColor = SystemColors.Control;
		btAtualizarOrigem.Image = Resources.Update_32;
		btAtualizarOrigem.Location = new Point(126, 12);
		btAtualizarOrigem.Name = "btAtualizarOrigem";
		btAtualizarOrigem.Size = new Size(36, 36);
		btAtualizarOrigem.TabIndex = 192;
		btAtualizarOrigem.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(174, 567);
		Controls.Add(btAtualizarOrigem);
		Controls.Add(dg);
		Controls.Add(GroupBox2);
		Controls.Add(lbTotal);
		Controls.Add(btCopiar);
		Controls.Add(GroupBox1);
		Controls.Add(btColar);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(190, 1590);
		MinimizeBox = false;
		MinimumSize = new Size(190, 590);
		Name = "frmCopiarObjetos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Copiar objetos CAD";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dg).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return xxbVWrW32D;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		xxbVWrW32D = WithEventsValue;
	}

	public frmCopiarObjetos()
	{
		bPTV6aXuLk = "";
		vU1VtuL4mu = 0.0;
		EmaVjYAVNe = 0.0;
		yAaVwioONs = "";
		YUiVxiu8Nm = "";
		UYFVbyU2Qg = 0;
		Ec4VM2IqZu = 1.0;
		try
		{
			if (!Geral.ExisteForm("frmCopiarObjetos"))
			{
				BvlBmJcvOt();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 594]);
				w8dpBZ0kvSD().SetToolTip(btCopiar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 45]));
				w8dpBZ0kvSD().SetToolTip(btAtualizarOrigem, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1812]));
				w8dpBZ0kvSD().SetToolTip(btColar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 46]));
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 419]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1461]);
				cbBornes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]);
				cbPortas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 520]);
				cbRevisoes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 62]);
				lbTotal.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1462]);
				tbDx.Text = "0";
				tbDy.Text = "0";
				btColar.Enabled = false;
				cbBornes.Checked = true;
				cbPortas.Checked = true;
				cbRevisoes.Checked = true;
				Pagina.CarregaPaginas();
				Pagina.OrdenaMatrizPaginas();
				desbloqueia(b: false);
				Application.ShowModelessDialog((Form)this);
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

	private void BjiBXswNRN()
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			float num2 = dg.Width - 20;
			dg.Columns[0].Width = (int)Math.Round(num2);
		}
	}

	private void ejnBUcL5cI()
	{
		try
		{
			dg.Columns[0].ReadOnly = false;
			dg.MultiSelect = true;
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(DeclaracoesGeral.mPaginas[0, i].ToString().Trim(), "", TextCompare: true) != 0)
				{
					dg.Rows.Add(Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]));
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	private void GBGByWOZd2()
	{
		checked
		{
			try
			{
				int num = dg.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dg.Rows[i].Selected = false;
					if (Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[0].Value, DeclaracoesGeral.ativo.Pagina, TextCompare: true))
					{
						dg.Rows[i].Selected = true;
						dg.FirstDisplayedScrollingRowIndex = i;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	private void jJOBgaTtBx(object P_0, EventArgs P_1)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected Obj, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected Obj, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected Obj, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected Obj, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		clsBlocos.Unhighlight();
		PointMonitorToolTips.StopMonitor();
		List<string> list = new List<string>();
		list.Add("RELMATERIAIS");
		list.Add("FIACAO");
		list.Add("JUMPEREXT");
		list.Add("PLAQUETAS");
		list.Add("INDICE");
		list.Add("DISTRIBUICAODEPOTENCIAIS");
		list.Add("DISTRIBUICAODEPOTENCIAISLINHA");
		list.Add("FiacaoDWG");
		list.Add("FIACAODWG");
		list.Add("RevisaoAutomatica");
		list.Add("DEFINICAO");
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		yAaVwioONs = mdiActiveDocument.Name;
		NqkVkBMWVj = mdiActiveDocument.Name;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Ec4VM2IqZu = database.Ltscale;
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				TypedValue[] array = new TypedValue[3];
				array.SetValue((object)new TypedValue(-4, (object)"<NOT"), 0);
				array.SetValue((object)new TypedValue(1001, (object)""), 1);
				array.SetValue((object)new TypedValue(-4, (object)"NOT>"), 2);
				SelectionFilter val4 = new SelectionFilter(array);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = "Selecione os elementos Cad a serem copiados.";
				PromptSelectionResult selection = editor.GetSelection(val5, val4);
				if ((int)selection.Status == 5100)
				{
					bPTV6aXuLk = DeclaracoesGeral.ativo.Pagina;
					PoiVftDSC1 = Application.DocumentManager.MdiActiveDocument;
					SelectionSet value = selection.Value;
					E4hVvUi4if = new ObjectIdCollection(value.GetObjectIds());
					YTCVdDSiFO = new ObjectIdCollection();
					UYFVbyU2Qg = 0;
					checked
					{
						foreach (object item in E4hVvUi4if)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent = (Entity)val6.GetObject((OpenMode)0);
							string s = "";
							string s2 = "";
							if (!(((DBObject)ent).XData == (ResultBuffer)null))
							{
								XDataRelatorio.LeTodosOsXdatasDeRelatorio(ref ent, ref s, ref s2);
								bool flag = false;
								if (list.Contains(s))
								{
									flag = true;
								}
								if (list.Contains(s2))
								{
									flag = true;
								}
								if (!flag)
								{
									if (cbBornes.Checked)
									{
										string tipoImportado = "";
										if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
										{
											YTCVdDSiFO.Add(val6);
											ent.Highlight();
											UYFVbyU2Qg++;
											continue;
										}
									}
									if (cbPortas.Checked)
									{
										string tipoImportado = "";
										if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "E", TextCompare: true) == 0)
										{
											YTCVdDSiFO.Add(val6);
											ent.Highlight();
											UYFVbyU2Qg++;
											continue;
										}
									}
									if (cbPortas.Checked)
									{
										string tipoImportado = "";
										if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "M", TextCompare: true) == 0)
										{
											BlockReference blockRef = (BlockReference)ent;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											ent = (Entity)(object)blockRef;
											if (((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj)).Complementar)
											{
												YTCVdDSiFO.Add(val6);
												ent.Highlight();
												UYFVbyU2Qg++;
												continue;
											}
										}
									}
									if (cbRevisoes.Checked)
									{
										string tipoImportado = "";
										int iCor = 1;
										if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref tipoImportado, ref iCor))
										{
											YTCVdDSiFO.Add(val6);
											ent.Highlight();
											UYFVbyU2Qg++;
										}
									}
								}
								else
								{
									YTCVdDSiFO.Add(val6);
									ent.Highlight();
									UYFVbyU2Qg++;
								}
							}
							else
							{
								YTCVdDSiFO.Add(val6);
								ent.Highlight();
								UYFVbyU2Qg++;
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val2.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
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
		DeclaracoesGeral.bAnularEventos = true;
		if (UYFVbyU2Qg > 0)
		{
			btColar.Enabled = true;
		}
		PointMonitorToolTips.StartMonitor();
		btColar.Enabled = false;
		if (UYFVbyU2Qg > 0)
		{
			lbTotal.Text = Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1462], UYFVbyU2Qg.ToString()));
			btColar.Enabled = true;
		}
		EtTBZfcitQ();
		DeclaracoesGeral.bAnularEventos = false;
	}

	private void ljFBA5oDKP(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "E", TextCompare: true) != 0)
		{
			return;
		}
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		checked
		{
			if (Operators.CompareString(NqkVkBMWVj, mdiActiveDocument.Name, TextCompare: true) == 0)
			{
				int num = dg.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dg.Rows[i].Selected && Operators.ConditionalCompareObjectEqual(bPTV6aXuLk, dg.Rows[i].Cells[0].Value, TextCompare: true) && ((Operators.CompareString(tbDx.Text, "0", TextCompare: true) == 0) & (Operators.CompareString(tbDy.Text, "0", TextCompare: true) == 0)))
					{
						MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1931]), MsgBoxStyle.YesNo | MsgBoxStyle.Critical, "Elétron");
						if (msgBoxResult == MsgBoxResult.No)
						{
							return;
						}
					}
				}
				try
				{
					List<string> list = new List<string>();
					int num2 = dg.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (dg.Rows[j].Selected)
						{
							list.Add(Conversions.ToString(dg.Rows[j].Cells[0].Value));
						}
					}
					YUiVxiu8Nm = mdiActiveDocument.Name;
					if (Operators.CompareString(yAaVwioONs, YUiVxiu8Nm, TextCompare: true) != 0)
					{
						MhiBBHsFRw(list);
					}
					else
					{
						v3cBsIJ9Pc(list);
					}
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
					ProjectData.ClearProjectError();
				}
				clsBlocos.Unhighlight();
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1804]));
			}
		}
	}

	private void v3cBsIJ9Pc(List<string> P_0)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected Obj, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[DeclaracoesGeral.blockFormatoName], (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				vU1VtuL4mu = Conversions.ToDouble(tbDx.Text);
				EmaVjYAVNe = Conversions.ToDouble(tbDy.Text);
				Point3d val5 = new Point3d(0.0, 0.0, 0.0);
				Vector3d vectorTo = val5.GetVectorTo(new Point3d(vU1VtuL4mu, EmaVjYAVNe, 0.0));
				DeclaracoesGeral._uscPagina.Quantidade = checked(UYFVbyU2Qg * P_0.Count);
				DeclaracoesGeral._uscPagina.pbIniciar();
				foreach (string item in P_0)
				{
					foreach (object item2 in YTCVdDSiFO)
					{
						ObjectId val6 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
						Entity val7 = (Entity)val6.GetObject((OpenMode)0);
						Entity ent = (Entity)((RXObject)val7).Clone();
						ent.Layer = item;
						val4.AppendEntity(ent);
						if ((vU1VtuL4mu != 0.0) | (EmaVjYAVNe != 0.0))
						{
							ent.TransformBy(Matrix3d.Displacement(vectorTo));
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)ent, true);
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
						{
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "T1", DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
							clsBornes.indefineUmBorne(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString());
							Correcao.LimpaXData(ent, "EXPORTADO");
						}
						tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "E", TextCompare: true) == 0)
						{
							clsPortas.IndefineUmaPorta(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), bLimpaTudo: false);
							Correcao.LimpaXData(ent, "EXPORTADO");
						}
						DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
						if (XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def) && Operators.CompareString(Def.Nome.ToUpper(), "DEFINICAO", TextCompare: true) == 0)
						{
							clsPortas.IndefineUmaDefinicao(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString());
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
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
		DeclaracoesGeral.bAnularEventos = false;
	}

	private void MhiBBHsFRw(List<string> P_0)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Obj, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Obj, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected Obj, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected Obj, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		eqyVDuknPM = Application.DocumentManager.MdiActiveDocument;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					try
					{
						database.Ltscale = Ec4VM2IqZu;
						vU1VtuL4mu = Conversions.ToDouble(tbDx.Text);
						EmaVjYAVNe = Conversions.ToDouble(tbDy.Text);
						Point3d val3 = new Point3d(0.0, 0.0, 0.0);
						Vector3d vectorTo = val3.GetVectorTo(new Point3d(vU1VtuL4mu, EmaVjYAVNe, 0.0));
						BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)0);
						IdMapping val6 = new IdMapping();
						PoiVftDSC1.Database.WblockCloneObjects(YTCVdDSiFO, ((DBObject)val5).ObjectId, val6, (DuplicateRecordCloning)1, false);
						DeclaracoesGeral._uscPagina.Quantidade = UYFVbyU2Qg * P_0.Count;
						DeclaracoesGeral._uscPagina.pbIniciar();
						foreach (string item in P_0)
						{
							if (!Pagina.AtivaPagina(item))
							{
								int uYFVbyU2Qg = UYFVbyU2Qg;
								for (int i = 1; i <= uYFVbyU2Qg; i++)
								{
									DeclaracoesGeral._uscPagina.pbPasso();
								}
								continue;
							}
							foreach (object item2 in val6)
							{
								IdPair val7 = ((item2 == null) ? default(IdPair) : ((IdPair)item2));
								ObjectId key = val7.Key;
								ObjectId value = val7.Value;
								foreach (object item3 in YTCVdDSiFO)
								{
									if (Operators.CompareString(((object)((item3 == null) ? default(ObjectId) : ((ObjectId)item3))/*cast due to constrained. prefix*/).ToString(), ((object)key/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
									{
										Entity ent = (Entity)val2.GetObject(value, (OpenMode)1);
										ent.Layer = item;
										if ((vU1VtuL4mu != 0.0) | (EmaVjYAVNe != 0.0))
										{
											ent.TransformBy(Matrix3d.Displacement(vectorTo));
										}
										string tipoImportado = "";
										string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										if (Operators.CompareString(left, "B", TextCompare: true) == 0 || Operators.CompareString(left, "E", TextCompare: true) == 0 || Operators.CompareString(left, "M", TextCompare: true) == 0)
										{
											((DBObject)ent).Erase();
										}
									}
								}
								DeclaracoesGeral._uscPagina.pbPasso();
							}
						}
						bool flag = true;
						int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
						for (int j = 1; j <= num; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, j], bPTV6aXuLk, TextCompare: true))
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							Pagina.RemoveLayer(bPTV6aXuLk);
						}
						DeclaracoesGeral._uscPagina.pbFim();
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val2.Abort();
						throw;
					}
					finally
					{
						DeclaracoesGeral.bAnularEventos = false;
					}
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

	private void uS0BVxowSr(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void goaBumeNxo(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void U07BEl1PAK(object P_0, EventArgs P_1)
	{
		EtTBZfcitQ();
	}

	private void EtTBZfcitQ()
	{
		if (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "E", TextCompare: true) == 0 && UYFVbyU2Qg > 0)
		{
			desbloqueia(b: true);
			BjiBXswNRN();
			ejnBUcL5cI();
			GBGByWOZd2();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			NqkVkBMWVj = mdiActiveDocument.Name;
			if (Operators.CompareString(NqkVkBMWVj, yAaVwioONs, TextCompare: true) == 0)
			{
				cbBornes.Enabled = true;
				cbPortas.Enabled = true;
				cbBornes.Checked = true;
				cbPortas.Checked = true;
			}
			else
			{
				cbBornes.Checked = false;
				cbPortas.Checked = false;
				cbBornes.Enabled = false;
				cbPortas.Enabled = false;
			}
		}
	}

	public void desbloqueia(bool b)
	{
		dg.Enabled = b;
		GroupBox1.Enabled = b;
		GroupBox2.Enabled = b;
		btColar.Enabled = b;
	}
}
