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
using ZwSoft.ZwCAD.Geometry;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmMudaPN : Form
{
	private IContainer pwPpvTnPx5t;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btTrocar")]
	private Button QHFpvJGwmy4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip X4epvhKRk26;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPainel")]
	[CompilerGenerated]
	private TextBox nP4pvojrADB;

	[AccessedThroughProperty("lbDistLinha")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label Lq7pvGs89k0;

	[AccessedThroughProperty("lbPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label Aw9pvH7AmP8;

	[AccessedThroughProperty("BTSelecionaDisp")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button UsvpvkSEbGA;

	[CompilerGenerated]
	[AccessedThroughProperty("lbNome1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label jVOpvdpGxh2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox v9upvfBEwE5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPaineis")]
	private ComboBox M5DpvDymT1S;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox WNgpvv5uFwi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbAlternativo")]
	[CompilerGenerated]
	private Label FVXpv6mGFS0;

	[AccessedThroughProperty("lbNome2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label AlfpvtbyAhb;

	[AccessedThroughProperty("tbAlternativo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox GTTpvjfxFFY;

	[AccessedThroughProperty("tbNome2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox XnZpvLpb34D;

	[AccessedThroughProperty("tbNome1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox L48pvwGVBgp;

	private string fZEpvx3fH6R;

	private DeclaracoesEntidades.StructureDispositivo ut8pvbvGXRO;

	private DeclaracoesEntidades.StructureMascara WiApvMP0JZU;

	private int KHtpvOLiHmU;

	private int yvvpvIq6LLt;

	private bool i7jpv7htdLe;

	internal virtual Button btTrocar
	{
		[CompilerGenerated]
		get
		{
			return QHFpvJGwmy4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = N0tpvpNPHWO;
			Button button = QHFpvJGwmy4;
			if (button != null)
			{
				button.Click -= value2;
			}
			QHFpvJGwmy4 = value;
			button = QHFpvJGwmy4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbPainel
	{
		[CompilerGenerated]
		get
		{
			return nP4pvojrADB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nP4pvojrADB = value;
		}
	}

	internal virtual Label lbDistLinha
	{
		[CompilerGenerated]
		get
		{
			return Lq7pvGs89k0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Lq7pvGs89k0 = value;
		}
	}

	internal virtual Label lbPainel
	{
		[CompilerGenerated]
		get
		{
			return Aw9pvH7AmP8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Aw9pvH7AmP8 = value;
		}
	}

	internal virtual Button BTSelecionaDisp
	{
		[CompilerGenerated]
		get
		{
			return UsvpvkSEbGA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ra3pDzhQcpV;
			Button button = UsvpvkSEbGA;
			if (button != null)
			{
				button.Click -= value2;
			}
			UsvpvkSEbGA = value;
			button = UsvpvkSEbGA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbNome1
	{
		[CompilerGenerated]
		get
		{
			return jVOpvdpGxh2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jVOpvdpGxh2 = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return v9upvfBEwE5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v9upvfBEwE5 = value;
		}
	}

	internal virtual ComboBox cbPaineis
	{
		[CompilerGenerated]
		get
		{
			return M5DpvDymT1S;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = smEpvW5hyDv;
			ComboBox comboBox = M5DpvDymT1S;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			M5DpvDymT1S = value;
			comboBox = M5DpvDymT1S;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return WNgpvv5uFwi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WNgpvv5uFwi = value;
		}
	}

	internal virtual Label lbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return FVXpv6mGFS0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FVXpv6mGFS0 = value;
		}
	}

	internal virtual Label lbNome2
	{
		[CompilerGenerated]
		get
		{
			return AlfpvtbyAhb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AlfpvtbyAhb = value;
		}
	}

	internal virtual TextBox tbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return GTTpvjfxFFY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GTTpvjfxFFY = value;
		}
	}

	internal virtual TextBox tbNome2
	{
		[CompilerGenerated]
		get
		{
			return XnZpvLpb34D;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XnZpvLpb34D = value;
		}
	}

	internal virtual TextBox tbNome1
	{
		[CompilerGenerated]
		get
		{
			return L48pvwGVBgp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			L48pvwGVBgp = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && pwPpvTnPx5t != null)
			{
				pwPpvTnPx5t.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void v8vpD9QlIML()
	{
		pwPpvTnPx5t = new Container();
		btTrocar = new Button();
		FDqpBiUmZij(new ToolTip(pwPpvTnPx5t));
		tbPainel = new TextBox();
		lbDistLinha = new Label();
		lbPainel = new Label();
		BTSelecionaDisp = new Button();
		lbNome1 = new Label();
		GroupBox1 = new GroupBox();
		tbAlternativo = new TextBox();
		tbNome2 = new TextBox();
		tbNome1 = new TextBox();
		lbAlternativo = new Label();
		lbNome2 = new Label();
		cbPaineis = new ComboBox();
		GroupBox2 = new GroupBox();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		btTrocar.FlatStyle = FlatStyle.Flat;
		btTrocar.ForeColor = SystemColors.Control;
		btTrocar.Image = Resources.OK_32;
		btTrocar.Location = new Point(179, 8);
		btTrocar.Name = "btTrocar";
		btTrocar.Size = new Size(40, 40);
		btTrocar.TabIndex = 13;
		btTrocar.UseVisualStyleBackColor = true;
		tbPainel.BackColor = SystemColors.Window;
		tbPainel.Location = new Point(66, 103);
		tbPainel.Name = "tbPainel";
		tbPainel.ReadOnly = true;
		tbPainel.Size = new Size(116, 20);
		tbPainel.TabIndex = 20;
		lbDistLinha.AutoSize = true;
		lbDistLinha.Location = new Point(7, 110);
		lbDistLinha.Name = "lbDistLinha";
		lbDistLinha.Size = new Size(36, 13);
		lbDistLinha.TabIndex = 19;
		lbDistLinha.Text = "Painel";
		lbPainel.AutoSize = true;
		lbPainel.Location = new Point(7, 22);
		lbPainel.Name = "lbPainel";
		lbPainel.Size = new Size(36, 13);
		lbPainel.TabIndex = 21;
		lbPainel.Text = "Painel";
		BTSelecionaDisp.FlatStyle = FlatStyle.Flat;
		BTSelecionaDisp.ForeColor = SystemColors.Control;
		BTSelecionaDisp.Image = Resources.Select_32;
		BTSelecionaDisp.Location = new Point(186, 45);
		BTSelecionaDisp.Name = "BTSelecionaDisp";
		BTSelecionaDisp.Size = new Size(40, 40);
		BTSelecionaDisp.TabIndex = 27;
		BTSelecionaDisp.UseVisualStyleBackColor = true;
		lbNome1.AutoSize = true;
		lbNome1.Location = new Point(7, 20);
		lbNome1.Name = "lbNome1";
		lbNome1.Size = new Size(41, 13);
		lbNome1.TabIndex = 28;
		lbNome1.Text = "Nome1";
		GroupBox1.Controls.Add(tbAlternativo);
		GroupBox1.Controls.Add(tbNome2);
		GroupBox1.Controls.Add(tbNome1);
		GroupBox1.Controls.Add(lbAlternativo);
		GroupBox1.Controls.Add(lbNome2);
		GroupBox1.Controls.Add(lbNome1);
		GroupBox1.Controls.Add(lbDistLinha);
		GroupBox1.Controls.Add(tbPainel);
		GroupBox1.Controls.Add(BTSelecionaDisp);
		GroupBox1.Location = new Point(5, 12);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(226, 138);
		GroupBox1.TabIndex = 30;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "PN Uso";
		tbAlternativo.BackColor = SystemColors.ScrollBar;
		tbAlternativo.Location = new Point(66, 71);
		tbAlternativo.Name = "tbAlternativo";
		tbAlternativo.ReadOnly = true;
		tbAlternativo.Size = new Size(116, 20);
		tbAlternativo.TabIndex = 35;
		tbNome2.BackColor = SystemColors.ScrollBar;
		tbNome2.Location = new Point(66, 45);
		tbNome2.Name = "tbNome2";
		tbNome2.ReadOnly = true;
		tbNome2.Size = new Size(116, 20);
		tbNome2.TabIndex = 34;
		tbNome1.BackColor = SystemColors.ScrollBar;
		tbNome1.Location = new Point(66, 19);
		tbNome1.Name = "tbNome1";
		tbNome1.ReadOnly = true;
		tbNome1.Size = new Size(116, 20);
		tbNome1.TabIndex = 33;
		lbAlternativo.AutoSize = true;
		lbAlternativo.Location = new Point(7, 72);
		lbAlternativo.Name = "lbAlternativo";
		lbAlternativo.Size = new Size(57, 13);
		lbAlternativo.TabIndex = 32;
		lbAlternativo.Text = "Alternativo";
		lbNome2.AutoSize = true;
		lbNome2.Location = new Point(7, 46);
		lbNome2.Name = "lbNome2";
		lbNome2.Size = new Size(41, 13);
		lbNome2.TabIndex = 30;
		lbNome2.Text = "Nome2";
		cbPaineis.FormattingEnabled = true;
		cbPaineis.Location = new Point(48, 19);
		cbPaineis.Name = "cbPaineis";
		cbPaineis.Size = new Size(116, 21);
		cbPaineis.TabIndex = 31;
		GroupBox2.Controls.Add(cbPaineis);
		GroupBox2.Controls.Add(btTrocar);
		GroupBox2.Controls.Add(lbPainel);
		GroupBox2.Location = new Point(5, 156);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(226, 59);
		GroupBox2.TabIndex = 32;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Trocar para";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(245, 223);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		MinimumSize = new Size(251, 185);
		Name = "frmMudaPN";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Troca Painel";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return X4epvhKRk26;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		X4epvhKRk26 = WithEventsValue;
	}

	public frmMudaPN()
	{
		fZEpvx3fH6R = "";
		KHtpvOLiHmU = 0;
		yvvpvIq6LLt = 0;
		i7jpv7htdLe = true;
		try
		{
			if (Geral.ExisteForm("frmMudaPN") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				v8vpD9QlIML();
				XDataGeral.LerXDataConfiguracao();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1015]);
				lbNome1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 627]);
				lbNome2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 628]);
				lbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 629]);
				lbPainel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]);
				w8dpBZ0kvSD().SetToolTip(BTSelecionaDisp, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1016]));
				w8dpBZ0kvSD().SetToolTip(btTrocar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1015]));
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1017]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1018]);
				Application.ShowModelessDialog((Form)this);
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

	private void Ra3pDzhQcpV(object P_0, EventArgs P_1)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		PointMonitorToolTips.StopMonitor();
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Point3d ptInsert = default;
			ObjectId val2 = clsDispositivo.selDispositivoPrincipal(ref ptInsert, "Selecione um Dispositivo Principal");
			if (!val2.IsNull)
			{
				Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
				BlockReference val4 = (BlockReference)(object)((val3 is BlockReference) ? val3 : null);
				if (!Information.IsDBNull(val4))
				{
					if (Information.IsNothing(DeclaracoesGeral.dicPainel))
					{
						cDadosAccess.carregaPainelDicionario();
					}
					cbPaineis.Items.Clear();
					cbPaineis.Text = "";
					cbPaineis.BackColor = tbPainel.BackColor;
					cbPaineis.ForeColor = Color.Black;
					Entity ent = (Entity)(object)val4;
					string tipoImportado = "";
					string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					val4 = (BlockReference)ent;
					fZEpvx3fH6R = text;
					if (Operators.CompareString(fZEpvx3fH6R, "P", TextCompare: true) == 0)
					{
						BlockReference blockRef = (BlockReference)val3;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						val3 = (Entity)(object)blockRef;
						object obj2 = obj;
						ut8pvbvGXRO = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
						KHtpvOLiHmU = ut8pvbvGXRO.Painel;
						tbNome1.Text = ut8pvbvGXRO.Nome1;
						tbNome2.Text = ut8pvbvGXRO.Nome2;
						tbAlternativo.Text = ut8pvbvGXRO.Alternativo;
						tbPainel.Text = Dicionario.BuscaNomeDoPainel(ut8pvbvGXRO.Painel);
						foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
						{
							if (item.Key != ut8pvbvGXRO.Painel)
							{
								cbPaineis.Items.Add(item.Value);
							}
						}
					}
					if (Operators.CompareString(fZEpvx3fH6R, "M", TextCompare: true) == 0)
					{
						BlockReference blockRef = (BlockReference)val3;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						val3 = (Entity)(object)blockRef;
						object obj3 = obj;
						WiApvMP0JZU = ((obj3 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj3));
						KHtpvOLiHmU = WiApvMP0JZU.Painel;
						tbNome1.Text = WiApvMP0JZU.Nome1;
						tbNome2.Text = WiApvMP0JZU.Nome2;
						tbAlternativo.Text = WiApvMP0JZU.Alternativo;
						tbPainel.Text = Dicionario.BuscaNomeDoPainel(WiApvMP0JZU.Painel);
						foreach (KeyValuePair<int, string> item2 in DeclaracoesGeral.dicPainel)
						{
							if (item2.Key != WiApvMP0JZU.Painel)
							{
								cbPaineis.Items.Add(item2.Value);
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			else
			{
				fZEpvx3fH6R = "";
			}
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
		Application.DocumentManager.MdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
		PointMonitorToolTips.StartMonitor();
	}

	private void smEpvW5hyDv(object P_0, EventArgs P_1)
	{
		cbPaineis.BackColor = tbPainel.BackColor;
		cbPaineis.ForeColor = Color.Black;
		btTrocar.Enabled = true;
		yvvpvIq6LLt = Dicionario.BuscaIndiceDoPainel(cbPaineis.Text);
		string tipo = "";
		int num = 0;
		if (Operators.CompareString(fZEpvx3fH6R, "P", TextCompare: true) == 0)
		{
			int iPn = yvvpvIq6LLt;
			string nome = ut8pvbvGXRO.Nome1;
			string nome2 = ut8pvbvGXRO.Nome2;
			string alternativo = ut8pvbvGXRO.Alternativo;
			string handle = "";
			num = clsDispositivo.verificaExisteNomeDispositivo(iPn, nome, nome2, alternativo, ref handle, ref tipo);
		}
		if (Operators.CompareString(fZEpvx3fH6R, "M", TextCompare: true) == 0)
		{
			int iPn2 = yvvpvIq6LLt;
			string nome3 = WiApvMP0JZU.Nome1;
			string nome4 = WiApvMP0JZU.Nome2;
			string alternativo2 = WiApvMP0JZU.Alternativo;
			string handle = "";
			num = clsDispositivo.verificaExisteNomeDispositivo(iPn2, nome3, nome4, alternativo2, ref handle, ref tipo);
		}
		i7jpv7htdLe = false;
		if (num > 0)
		{
			btTrocar.Enabled = false;
			i7jpv7htdLe = true;
			cbPaineis.BackColor = Color.Red;
			cbPaineis.ForeColor = Color.White;
		}
	}

	private void N0tpvpNPHWO(object P_0, EventArgs P_1)
	{
		bool flag = false;
		checked
		{
			int num = cbPaineis.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(cbPaineis.Items[i].ToString().Trim(), cbPaineis.Text.ToString().Trim(), TextCompare: true) == 0)
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (!i7jpv7htdLe)
				{
					clsDispositivo.TrocaPainel(fZEpvx3fH6R, ut8pvbvGXRO, WiApvMP0JZU, KHtpvOLiHmU, yvvpvIq6LLt);
					clsUtilitarios.EditaPortaDipAuxPainelModeloFabricante();
				}
				else
				{
					Interaction.MsgBox(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1019], cbPaineis.Text), MsgBoxStyle.Critical, "Elétron");
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1044]), MsgBoxStyle.Information);
			}
		}
	}
}
