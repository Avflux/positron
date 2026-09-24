using System;
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
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Windows;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmMarcador : Form
{
	private IContainer Rk7pfTSl220;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbCor")]
	private CheckBox eILpfJUoQL4;

	[AccessedThroughProperty("btInserirTodos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button wO5pfhfdcQp;

	[AccessedThroughProperty("btApagarTodos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button DWRpfobGvlo;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip G8YpfGlkNwk;

	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label xlqpfHaommh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorTexto")]
	[CompilerGenerated]
	private Button DDUpfkOCXI5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFonte")]
	private TextBox an7pfdKFOU2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label KrbpffVEQXu;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox rOppfDVxLOh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbSecao")]
	private CheckBox VSNpfvk8VBx;

	[CompilerGenerated]
	[AccessedThroughProperty("btInserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button Ii3pf6FnZkG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPot")]
	private CheckBox d5Kpft5C1Nv;

	[CompilerGenerated]
	[AccessedThroughProperty("TBPot")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox MkEpfjiI7xJ;

	private ColorDialog zqopfLewoK5;

	private short iO2pfwUr0s5;

	internal virtual CheckBox cbCor
	{
		[CompilerGenerated]
		get
		{
			return eILpfJUoQL4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yNUpd9ZvuT0;
			CheckBox checkBox = eILpfJUoQL4;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			eILpfJUoQL4 = value;
			checkBox = eILpfJUoQL4;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btInserirTodos
	{
		[CompilerGenerated]
		get
		{
			return wO5pfhfdcQp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = n7gpd4XME1r;
			Button button = wO5pfhfdcQp;
			if (button != null)
			{
				button.Click -= value2;
			}
			wO5pfhfdcQp = value;
			button = wO5pfhfdcQp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarTodos
	{
		[CompilerGenerated]
		get
		{
			return DWRpfobGvlo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fFQpdCuvcNO;
			Button button = DWRpfobGvlo;
			if (button != null)
			{
				button.Click -= value2;
			}
			DWRpfobGvlo = value;
			button = DWRpfobGvlo;
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
			return xlqpfHaommh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xlqpfHaommh = value;
		}
	}

	internal virtual Button btCorTexto
	{
		[CompilerGenerated]
		get
		{
			return DDUpfkOCXI5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AhjpdrLyl2S;
			Button button = DDUpfkOCXI5;
			if (button != null)
			{
				button.Click -= value2;
			}
			DDUpfkOCXI5 = value;
			button = DDUpfkOCXI5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbFonte
	{
		[CompilerGenerated]
		get
		{
			return an7pfdKFOU2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = nWHpdYvA1ll;
			TextBox textBox = an7pfdKFOU2;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			an7pfdKFOU2 = value;
			textBox = an7pfdKFOU2;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return KrbpffVEQXu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KrbpffVEQXu = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return rOppfDVxLOh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rOppfDVxLOh = value;
		}
	}

	internal virtual CheckBox cbSecao
	{
		[CompilerGenerated]
		get
		{
			return VSNpfvk8VBx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VJspdzOv6uw;
			CheckBox checkBox = VSNpfvk8VBx;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			VSNpfvk8VBx = value;
			checkBox = VSNpfvk8VBx;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return Ii3pf6FnZkG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HqmpdS4lGyQ;
			Button button = Ii3pf6FnZkG;
			if (button != null)
			{
				button.Click -= value2;
			}
			Ii3pf6FnZkG = value;
			button = Ii3pf6FnZkG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbPot
	{
		[CompilerGenerated]
		get
		{
			return d5Kpft5C1Nv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VrupfW5xFwW;
			CheckBox checkBox = d5Kpft5C1Nv;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			d5Kpft5C1Nv = value;
			checkBox = d5Kpft5C1Nv;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual TextBox TBPot
	{
		[CompilerGenerated]
		get
		{
			return MkEpfjiI7xJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = K6ppfpUlWUo;
			TextBox textBox = MkEpfjiI7xJ;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			MkEpfjiI7xJ = value;
			textBox = MkEpfjiI7xJ;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && Rk7pfTSl220 != null)
			{
				Rk7pfTSl220.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DARpdiGBnTM()
	{
		Rk7pfTSl220 = new Container();
		cbCor = new CheckBox();
		btInserirTodos = new Button();
		btApagarTodos = new Button();
		FDqpBiUmZij(new ToolTip(Rk7pfTSl220));
		Label1 = new Label();
		btCorTexto = new Button();
		tbFonte = new TextBox();
		Label2 = new Label();
		GroupBox1 = new GroupBox();
		cbPot = new CheckBox();
		cbSecao = new CheckBox();
		TBPot = new TextBox();
		btInserir = new Button();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		cbCor.AutoSize = true;
		cbCor.CheckAlign = ContentAlignment.MiddleRight;
		cbCor.ImageAlign = ContentAlignment.MiddleRight;
		cbCor.Location = new Point(53, 95);
		cbCor.Name = "cbCor";
		cbCor.Size = new Size(42, 17);
		cbCor.TabIndex = 11;
		cbCor.Text = "Cor";
		cbCor.TextAlign = ContentAlignment.MiddleRight;
		cbCor.UseVisualStyleBackColor = true;
		btInserirTodos.FlatStyle = FlatStyle.Flat;
		btInserirTodos.ForeColor = SystemColors.Control;
		btInserirTodos.Image = Resources.OKmult_32;
		btInserirTodos.Location = new Point(63, 202);
		btInserirTodos.Name = "btInserirTodos";
		btInserirTodos.Size = new Size(40, 40);
		btInserirTodos.TabIndex = 13;
		btInserirTodos.UseVisualStyleBackColor = true;
		btApagarTodos.FlatStyle = FlatStyle.Flat;
		btApagarTodos.ForeColor = SystemColors.Control;
		btApagarTodos.Image = Resources.Delete_32;
		btApagarTodos.Location = new Point(114, 202);
		btApagarTodos.Name = "btApagarTodos";
		btApagarTodos.Size = new Size(40, 40);
		btApagarTodos.TabIndex = 15;
		btApagarTodos.UseVisualStyleBackColor = true;
		Label1.Location = new Point(34, 26);
		Label1.Name = "Label1";
		Label1.Size = new Size(37, 23);
		Label1.TabIndex = 40;
		Label1.Text = "Cor";
		Label1.TextAlign = ContentAlignment.TopRight;
		btCorTexto.BackColor = SystemColors.ActiveCaption;
		btCorTexto.Location = new Point(80, 21);
		btCorTexto.Name = "btCorTexto";
		btCorTexto.Size = new Size(35, 23);
		btCorTexto.TabIndex = 39;
		btCorTexto.UseVisualStyleBackColor = false;
		tbFonte.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonte.Location = new Point(80, 56);
		tbFonte.Name = "tbFonte";
		tbFonte.Size = new Size(35, 20);
		tbFonte.TabIndex = 41;
		tbFonte.TextAlign = HorizontalAlignment.Center;
		Label2.Location = new Point(0, 57);
		Label2.Name = "Label2";
		Label2.Size = new Size(72, 17);
		Label2.TabIndex = 42;
		Label2.Text = "Altura Texto";
		Label2.TextAlign = ContentAlignment.MiddleRight;
		GroupBox1.Controls.Add(cbPot);
		GroupBox1.Controls.Add(cbSecao);
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(TBPot);
		GroupBox1.Controls.Add(tbFonte);
		GroupBox1.Controls.Add(btCorTexto);
		GroupBox1.Controls.Add(Label2);
		GroupBox1.Controls.Add(cbCor);
		GroupBox1.Location = new Point(12, 12);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(142, 181);
		GroupBox1.TabIndex = 43;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Parâmetros";
		cbPot.AutoSize = true;
		cbPot.CheckAlign = ContentAlignment.MiddleRight;
		cbPot.ImageAlign = ContentAlignment.MiddleRight;
		cbPot.Location = new Point(24, 152);
		cbPot.Name = "cbPot";
		cbPot.Size = new Size(70, 17);
		cbPot.TabIndex = 45;
		cbPot.Text = "Potencial";
		cbPot.TextAlign = ContentAlignment.MiddleRight;
		cbPot.UseVisualStyleBackColor = true;
		cbSecao.AutoSize = true;
		cbSecao.CheckAlign = ContentAlignment.MiddleRight;
		cbSecao.ImageAlign = ContentAlignment.MiddleRight;
		cbSecao.Location = new Point(38, 118);
		cbSecao.Name = "cbSecao";
		cbSecao.Size = new Size(57, 17);
		cbSecao.TabIndex = 44;
		cbSecao.Text = "Seção";
		cbSecao.TextAlign = ContentAlignment.MiddleRight;
		cbSecao.UseVisualStyleBackColor = true;
		TBPot.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBPot.Location = new Point(99, 149);
		TBPot.Name = "TBPot";
		TBPot.Size = new Size(35, 20);
		TBPot.TabIndex = 41;
		TBPot.Text = "Pot:";
		TBPot.TextAlign = HorizontalAlignment.Center;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.OK_32;
		btInserir.Location = new Point(12, 203);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 40);
		btInserir.TabIndex = 44;
		btInserir.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(166, 246);
		Controls.Add(btInserir);
		Controls.Add(GroupBox1);
		Controls.Add(btApagarTodos);
		Controls.Add(btInserirTodos);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmMarcador";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Inserir Marcador";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return G8YpfGlkNwk;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		G8YpfGlkNwk = WithEventsValue;
	}

	public frmMarcador()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		zqopfLewoK5 = new ColorDialog();
		try
		{
			if (!Geral.ExisteForm("frmMarcador"))
			{
				DARpdiGBnTM();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 723]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 720]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 721]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1480]);
				cbCor.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 720]);
				cbSecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 722]);
				cbPot.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 428]);
				w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 724]));
				w8dpBZ0kvSD().SetToolTip(btInserirTodos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 725]));
				w8dpBZ0kvSD().SetToolTip(btApagarTodos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 726]));
				Color val = Color.FromColorIndex((ColorMethod)194, checked((short)DeclaracoesGeral.Conf.CorTextoCircuito));
				btCorTexto.BackColor = val.ColorValue;
				tbFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
				cbCor.Checked = true;
				cbSecao.Checked = false;
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

	private void HqmpdS4lGyQ(object P_0, EventArgs P_1)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Invalid comparison between Unknown and I4
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		if (!cbCor.Checked & !cbSecao.Checked)
		{
			return;
		}
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				try
				{
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptEntityOptions val4 = new PromptEntityOptions("");
					val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 727])));
					((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 728]));
					val4.AddAllowedClass(typeof(Polyline), true);
					PromptEntityResult entity = editor.GetEntity(val4);
					if ((int)((PromptResult)entity).Status != -5002)
					{
						Point3d pickedPoint = entity.PickedPoint;
						ObjectId objectId = entity.ObjectId;
						Polyline pl = (Polyline)objectId.GetObject((OpenMode)0);
						DeclaracoesEntidades.StructureConexao conex = default;
						if (XDataConexao.lerXDataConexao(ref pl, ref conex))
						{
							string handleSel = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
							Point3d closestPointTo = ((Curve)pl).GetClosestPointTo(pickedPoint, true);
							clsConexao clsConexao2 = new clsConexao();
							clsConexao2.CriarMarcador(iO2pfwUr0s5, closestPointTo, cbCor.Checked, cbSecao.Checked, cbPot.Checked, TBPot.Text, ((Entity)pl).Layer, Conversions.ToDouble(tbFonte.Text), conex, handleSel);
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					ProjectData.ClearProjectError();
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
		PointMonitorToolTips.StartMonitor();
	}

	private void n7gpd4XME1r(object P_0, EventArgs P_1)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		if (!cbCor.Checked & !cbSecao.Checked & !cbPot.Checked)
		{
			return;
		}
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 730]), MsgBoxStyle.YesNo, "Eletron");
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		apagaTodosMarcadores();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DeclaracoesEntidades.StructureConexao conex = default;
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl == null || !XDataConexao.lerXDataConexao(ref pl, ref conex))
						{
							continue;
						}
						string handleSel = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
						double num = 0.0;
						short num2 = 0;
						LineSegment3d lineSegmentAt;
						checked
						{
							int num3 = pl.NumberOfVertices - 2;
							for (int i = 0; i <= num3; i++)
							{
								lineSegmentAt = pl.GetLineSegmentAt(i);
								double length = lineSegmentAt.Length;
								if (length > num)
								{
									num = length;
									num2 = (short)i;
								}
							}
						}
						lineSegmentAt = pl.GetLineSegmentAt((int)num2);
						Point3d midPoint = lineSegmentAt.MidPoint;
						clsConexao clsConexao2 = new clsConexao();
						clsConexao2.CriarMarcador(iO2pfwUr0s5, midPoint, cbCor.Checked, cbSecao.Checked, cbPot.Checked, TBPot.Text, ((Entity)pl).Layer, Conversions.ToDouble(tbFonte.Text), conex, handleSel);
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void fFQpdCuvcNO(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 729]), MsgBoxStyle.YesNo, "Eletron");
		if (msgBoxResult != MsgBoxResult.No)
		{
			apagaTodosMarcadores();
		}
	}

	public void apagaTodosMarcadores()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					int potencial = default;
					int enderecamento = default;
					short tipo2 = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline val6 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (val6 != null)
						{
							short tipo = 0;
							Entity ent = (Entity)(object)val6;
							bool flag = XDataConexao.lerXDataHatchLinha(ref ent, ref tipo);
							val6 = (Polyline)ent;
							if (flag && tipo == 2)
							{
								((DBObject)val6).UpgradeOpen();
								((DBObject)val6).Erase();
							}
						}
						DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val7 != null)
						{
							string handle = "";
							if (XDataConexao.lerXDataAuxCircuito(ref val7, ref potencial, ref handle, ref enderecamento, ref tipo2) && ((tipo2 == 4) | (tipo2 == 5) | (tipo2 == 6)))
							{
								((DBObject)val7).UpgradeOpen();
								((DBObject)val7).Erase();
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void nWHpdYvA1ll(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void AhjpdrLyl2S(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = zqopfLewoK5.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			iO2pfwUr0s5 = zqopfLewoK5.Color.ColorIndex;
			btCorTexto.BackColor = zqopfLewoK5.Color.ColorValue;
		}
	}

	private void yNUpd9ZvuT0(object P_0, EventArgs P_1)
	{
		if (cbCor.Checked)
		{
			cbPot.Checked = false;
		}
		if (!cbPot.Checked & !cbCor.Checked & !cbSecao.Checked)
		{
			cbCor.Checked = true;
		}
	}

	private void VJspdzOv6uw(object P_0, EventArgs P_1)
	{
		if (cbSecao.Checked)
		{
			cbPot.Checked = false;
		}
		if (!cbPot.Checked & !cbCor.Checked & !cbSecao.Checked)
		{
			cbCor.Checked = true;
		}
	}

	private void VrupfW5xFwW(object P_0, EventArgs P_1)
	{
		if (cbPot.Checked)
		{
			cbCor.Checked = false;
			cbSecao.Checked = false;
		}
		if (!cbPot.Checked & !cbCor.Checked & !cbSecao.Checked)
		{
			cbCor.Checked = true;
		}
	}

	private void K6ppfpUlWUo(object P_0, EventArgs P_1)
	{
	}
}
