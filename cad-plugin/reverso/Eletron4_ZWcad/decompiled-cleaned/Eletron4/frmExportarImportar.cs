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
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmExportarImportar : Form
{
	private IContainer d2hY1sW2JB;

	[AccessedThroughProperty("btExportar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button WutYlvJSYx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btImportar")]
	private Button GWhY5QpjmC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox xhOY0cGRr7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label zTxYR3ogDF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label hUPYmvdfZk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDy")]
	[CompilerGenerated]
	private TextBox J5TYXvDRZd;

	[AccessedThroughProperty("tbDx")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox UOJYUg0dby;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip xS4YyUZgoH;

	[CompilerGenerated]
	[AccessedThroughProperty("btApagarTodos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button PB4YggjkuS;

	[AccessedThroughProperty("btApagarSelecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button zvfYAyOEeh;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox W9xYsOqeBs;

	[AccessedThroughProperty("btCarimbo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button mofYBt0WDA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSincronizaExpImp")]
	private Button gLEYVvyEop;

	[AccessedThroughProperty("btOcultarImportados")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button agtYuTyZGN;

	[AccessedThroughProperty("btLigarImportados")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button Hf9YEMFPV2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	[CompilerGenerated]
	private Button rLdYZ2EjIX;

	[CompilerGenerated]
	[AccessedThroughProperty("tv1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TreeView p0gYiGLbC8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btApagarComp")]
	private Button trBYSQSNc5;

	[AccessedThroughProperty("cbApagarImp")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox hH6Y4UgA7b;

	[AccessedThroughProperty("Label3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label prSYCoORvV;

	private ObjectIdCollection BSZYYRPUAl;

	private Document SZsYrvtK7t;

	private Document cXSY9syRhL;

	private ObjectIdCollection anPYzdd1I9;

	private string GOdrWFHpwl;

	private double XPLrpXq430;

	private double ii3rTUCgwV;

	private int svXrJ0eYtE;

	private int UiCrhuZcXp;

	internal virtual Button btExportar
	{
		[CompilerGenerated]
		get
		{
			return WutYlvJSYx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HCfY7Vtyac;
			Button button = WutYlvJSYx;
			if (button != null)
			{
				button.Click -= value2;
			}
			WutYlvJSYx = value;
			button = WutYlvJSYx;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btImportar
	{
		[CompilerGenerated]
		get
		{
			return GWhY5QpjmC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = guoYQJLsb8;
			Button button = GWhY5QpjmC;
			if (button != null)
			{
				button.Click -= value2;
			}
			GWhY5QpjmC = value;
			button = GWhY5QpjmC;
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
			return xhOY0cGRr7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xhOY0cGRr7 = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return zTxYR3ogDF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zTxYR3ogDF = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return hUPYmvdfZk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hUPYmvdfZk = value;
		}
	}

	internal virtual TextBox tbDy
	{
		[CompilerGenerated]
		get
		{
			return J5TYXvDRZd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = jIVYnNjTDe;
			TextBox textBox = J5TYXvDRZd;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			J5TYXvDRZd = value;
			textBox = J5TYXvDRZd;
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
			return UOJYUg0dby;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = PoJY3pFk3s;
			TextBox textBox = UOJYUg0dby;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			UOJYUg0dby = value;
			textBox = UOJYUg0dby;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button btApagarTodos
	{
		[CompilerGenerated]
		get
		{
			return PB4YggjkuS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = t3KYq9yNMn;
			Button button = PB4YggjkuS;
			if (button != null)
			{
				button.Click -= value2;
			}
			PB4YggjkuS = value;
			button = PB4YggjkuS;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarSelecao
	{
		[CompilerGenerated]
		get
		{
			return zvfYAyOEeh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vQ4YaKcKLk;
			Button button = zvfYAyOEeh;
			if (button != null)
			{
				button.Click -= value2;
			}
			zvfYAyOEeh = value;
			button = zvfYAyOEeh;
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
			return W9xYsOqeBs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			W9xYsOqeBs = value;
		}
	}

	internal virtual Button btCarimbo
	{
		[CompilerGenerated]
		get
		{
			return mofYBt0WDA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ld4Y8vngqH;
			Button button = mofYBt0WDA;
			if (button != null)
			{
				button.Click -= value2;
			}
			mofYBt0WDA = value;
			button = mofYBt0WDA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSincronizaExpImp
	{
		[CompilerGenerated]
		get
		{
			return gLEYVvyEop;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zTrYP092L6;
			Button button = gLEYVvyEop;
			if (button != null)
			{
				button.Click -= value2;
			}
			gLEYVvyEop = value;
			button = gLEYVvyEop;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btOcultarImportados
	{
		[CompilerGenerated]
		get
		{
			return agtYuTyZGN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = c5lYNbTmno;
			Button button = agtYuTyZGN;
			if (button != null)
			{
				button.Click -= value2;
			}
			agtYuTyZGN = value;
			button = agtYuTyZGN;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btLigarImportados
	{
		[CompilerGenerated]
		get
		{
			return Hf9YEMFPV2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zvuYFcWl9A;
			Button button = Hf9YEMFPV2;
			if (button != null)
			{
				button.Click -= value2;
			}
			Hf9YEMFPV2 = value;
			button = Hf9YEMFPV2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return rLdYZ2EjIX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mNeYePZIVi;
			Button button = rLdYZ2EjIX;
			if (button != null)
			{
				button.Click -= value2;
			}
			rLdYZ2EjIX = value;
			button = rLdYZ2EjIX;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TreeView tv1
	{
		[CompilerGenerated]
		get
		{
			return p0gYiGLbC8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			p0gYiGLbC8 = value;
		}
	}

	internal virtual Button btApagarComp
	{
		[CompilerGenerated]
		get
		{
			return trBYSQSNc5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GJTY2s4cfm;
			Button button = trBYSQSNc5;
			if (button != null)
			{
				button.Click -= value2;
			}
			trBYSQSNc5 = value;
			button = trBYSQSNc5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbApagarImp
	{
		[CompilerGenerated]
		get
		{
			return hH6Y4UgA7b;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hH6Y4UgA7b = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return prSYCoORvV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			prSYCoORvV = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && d2hY1sW2JB != null)
			{
				d2hY1sW2JB.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m1fYIUiYVp()
	{
		d2hY1sW2JB = new Container();
		btExportar = new Button();
		btImportar = new Button();
		GroupBox1 = new GroupBox();
		Label2 = new Label();
		Label1 = new Label();
		tbDy = new TextBox();
		tbDx = new TextBox();
		FDqpBiUmZij(new ToolTip(d2hY1sW2JB));
		btApagarTodos = new Button();
		btApagarSelecao = new Button();
		GroupBox2 = new GroupBox();
		btCarimbo = new Button();
		btSincronizaExpImp = new Button();
		btOcultarImportados = new Button();
		btLigarImportados = new Button();
		btPesquisar = new Button();
		tv1 = new TreeView();
		btApagarComp = new Button();
		cbApagarImp = new CheckBox();
		Label3 = new Label();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		btExportar.FlatStyle = FlatStyle.Flat;
		btExportar.ForeColor = SystemColors.Control;
		btExportar.Image = Resources.Export_32;
		btExportar.Location = new Point(6, 10);
		btExportar.Name = "btExportar";
		btExportar.Size = new Size(40, 40);
		btExportar.TabIndex = 7;
		btExportar.UseVisualStyleBackColor = true;
		btImportar.Anchor = AnchorStyles.Top;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.Import_32;
		btImportar.Location = new Point(113, 84);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(40, 40);
		btImportar.TabIndex = 12;
		btImportar.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Top;
		GroupBox1.Controls.Add(Label2);
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(tbDy);
		GroupBox1.Controls.Add(tbDx);
		GroupBox1.Location = new Point(13, 65);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(93, 73);
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
		btApagarTodos.FlatStyle = FlatStyle.Flat;
		btApagarTodos.ForeColor = SystemColors.Control;
		btApagarTodos.Image = Resources.Delete_32;
		btApagarTodos.Location = new Point(100, 11);
		btApagarTodos.Name = "btApagarTodos";
		btApagarTodos.Size = new Size(40, 40);
		btApagarTodos.TabIndex = 15;
		btApagarTodos.UseVisualStyleBackColor = true;
		btApagarSelecao.FlatStyle = FlatStyle.Flat;
		btApagarSelecao.ForeColor = SystemColors.Control;
		btApagarSelecao.Image = Resources.Select_32;
		btApagarSelecao.Location = new Point(147, 11);
		btApagarSelecao.Name = "btApagarSelecao";
		btApagarSelecao.Size = new Size(40, 40);
		btApagarSelecao.TabIndex = 16;
		btApagarSelecao.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Top;
		GroupBox2.Controls.Add(btCarimbo);
		GroupBox2.Controls.Add(btExportar);
		GroupBox2.Controls.Add(btApagarTodos);
		GroupBox2.Controls.Add(btApagarSelecao);
		GroupBox2.Location = new Point(13, 6);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(194, 56);
		GroupBox2.TabIndex = 17;
		GroupBox2.TabStop = false;
		btCarimbo.FlatStyle = FlatStyle.Flat;
		btCarimbo.ForeColor = SystemColors.Control;
		btCarimbo.Image = Resources.Carimbo_32;
		btCarimbo.Location = new Point(53, 11);
		btCarimbo.Name = "btCarimbo";
		btCarimbo.Size = new Size(40, 40);
		btCarimbo.TabIndex = 17;
		btCarimbo.UseVisualStyleBackColor = true;
		btSincronizaExpImp.Anchor = AnchorStyles.Top;
		btSincronizaExpImp.FlatStyle = FlatStyle.Flat;
		btSincronizaExpImp.ForeColor = SystemColors.Control;
		btSincronizaExpImp.Image = Resources.Restaura_32;
		btSincronizaExpImp.Location = new Point(259, 84);
		btSincronizaExpImp.Name = "btSincronizaExpImp";
		btSincronizaExpImp.Size = new Size(40, 40);
		btSincronizaExpImp.TabIndex = 18;
		btSincronizaExpImp.UseVisualStyleBackColor = true;
		btOcultarImportados.Anchor = AnchorStyles.Top;
		btOcultarImportados.FlatStyle = FlatStyle.Flat;
		btOcultarImportados.ForeColor = SystemColors.Control;
		btOcultarImportados.Image = Resources.Desliga_32;
		btOcultarImportados.Location = new Point(213, 17);
		btOcultarImportados.Name = "btOcultarImportados";
		btOcultarImportados.Size = new Size(40, 40);
		btOcultarImportados.TabIndex = 18;
		btOcultarImportados.UseVisualStyleBackColor = true;
		btLigarImportados.Anchor = AnchorStyles.Top;
		btLigarImportados.FlatStyle = FlatStyle.Flat;
		btLigarImportados.ForeColor = SystemColors.Control;
		btLigarImportados.Image = Resources.Liga_32;
		btLigarImportados.Location = new Point(259, 17);
		btLigarImportados.Name = "btLigarImportados";
		btLigarImportados.Size = new Size(40, 40);
		btLigarImportados.TabIndex = 19;
		btLigarImportados.UseVisualStyleBackColor = true;
		btPesquisar.Anchor = AnchorStyles.Top;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(305, 17);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 40);
		btPesquisar.TabIndex = 20;
		btPesquisar.UseVisualStyleBackColor = true;
		tv1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tv1.Font = new Font("Arial", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tv1.Location = new Point(12, 144);
		tv1.Name = "tv1";
		tv1.Size = new Size(340, 185);
		tv1.TabIndex = 22;
		btApagarComp.Anchor = AnchorStyles.Top;
		btApagarComp.FlatStyle = FlatStyle.Flat;
		btApagarComp.ForeColor = SystemColors.Control;
		btApagarComp.Image = Resources.ApagarComp_32;
		btApagarComp.Location = new Point(305, 83);
		btApagarComp.Name = "btApagarComp";
		btApagarComp.Size = new Size(40, 42);
		btApagarComp.TabIndex = 23;
		btApagarComp.UseVisualStyleBackColor = true;
		cbApagarImp.Anchor = AnchorStyles.Top;
		cbApagarImp.AutoSize = true;
		cbApagarImp.Location = new Point(167, 98);
		cbApagarImp.Name = "cbApagarImp";
		cbApagarImp.Size = new Size(15, 14);
		cbApagarImp.TabIndex = 24;
		cbApagarImp.UseVisualStyleBackColor = true;
		Label3.Anchor = AnchorStyles.Top;
		Label3.Location = new Point(181, 72);
		Label3.Name = "Label3";
		Label3.Size = new Size(72, 66);
		Label3.TabIndex = 25;
		Label3.Text = "Apagar Importados Inválidos ao Sincronizar";
		Label3.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(364, 341);
		Controls.Add(Label3);
		Controls.Add(cbApagarImp);
		Controls.Add(btApagarComp);
		Controls.Add(tv1);
		Controls.Add(btPesquisar);
		Controls.Add(btLigarImportados);
		Controls.Add(btOcultarImportados);
		Controls.Add(btSincronizaExpImp);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(btImportar);
		MaximizeBox = false;
		MaximumSize = new Size(380, 1000);
		MinimizeBox = false;
		MinimumSize = new Size(380, 380);
		Name = "frmExportarImportar";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Exportar/Importar";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return xS4YyUZgoH;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		xS4YyUZgoH = WithEventsValue;
	}

	public frmExportarImportar()
	{
		GOdrWFHpwl = "";
		XPLrpXq430 = 0.0;
		ii3rTUCgwV = 0.0;
		svXrJ0eYtE = 0;
		UiCrhuZcXp = 0;
		try
		{
			if (!Geral.ExisteForm("frmExportarImportar"))
			{
				m1fYIUiYVp();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 868]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 419]);
				w8dpBZ0kvSD().SetToolTip(btExportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 869]));
				w8dpBZ0kvSD().SetToolTip(btImportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 870]));
				w8dpBZ0kvSD().SetToolTip(btApagarTodos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 874]));
				w8dpBZ0kvSD().SetToolTip(btApagarSelecao, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 875]));
				w8dpBZ0kvSD().SetToolTip(btCarimbo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 879]));
				w8dpBZ0kvSD().SetToolTip(btSincronizaExpImp, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 597]));
				w8dpBZ0kvSD().SetToolTip(btOcultarImportados, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1496]));
				w8dpBZ0kvSD().SetToolTip(btLigarImportados, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1497]));
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1498]));
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1873]);
				tbDx.Text = "0";
				tbDy.Text = "0";
				btImportar.Enabled = false;
				cbApagarImp.Checked = false;
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

	private void HCfY7Vtyac(object P_0, EventArgs P_1)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Obj, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Invalid comparison between Unknown and I4
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected Obj, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected Obj, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected Obj, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected Obj, but got Unknown
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Expected Obj, but got Unknown
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected Obj, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b83: Expected Obj, but got Unknown
		//IL_0b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0c: Expected Obj, but got Unknown
		//IL_0d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Unknown result type (might be due to invalid IL or missing references)
		//IL_082f: Expected Obj, but got Unknown
		//IL_096a: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Expected Obj, but got Unknown
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected Obj, but got Unknown
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b5: Expected Obj, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Expected Obj, but got Unknown
		//IL_0919: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Expected Obj, but got Unknown
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Expected Obj, but got Unknown
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a92: Expected Obj, but got Unknown
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected Obj, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Expected Obj, but got Unknown
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		PointMonitorToolTips.StopMonitor();
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		int num = 0;
		cDadosAccess.carregaDadosDWG();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				cDadosAccessExpImp cDadosAccessExpImp2 = new cDadosAccessExpImp();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					TypedValue[] array = new TypedValue[3];
					array.SetValue((object)new TypedValue(-4, (object)"<NOT"), 0);
					array.SetValue((object)new TypedValue(1001, (object)"EXPORTADO"), 1);
					array.SetValue((object)new TypedValue(-4, (object)"NOT>"), 2);
					SelectionFilter val4 = new SelectionFilter(array);
					PromptSelectionOptions val5 = new PromptSelectionOptions();
					val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 871]);
					PromptSelectionResult selection = editor.GetSelection(val5, val4);
					if ((int)selection.Status == 5100)
					{
						svXrJ0eYtE = DeclaracoesGeral.arqAtivo.Indice;
						GOdrWFHpwl = DeclaracoesGeral.ativo.Pagina;
						SZsYrvtK7t = Application.DocumentManager.MdiActiveDocument;
						SelectionSet value = selection.Value;
						anPYzdd1I9 = new ObjectIdCollection(value.GetObjectIds());
						BSZYYRPUAl = new ObjectIdCollection();
						checked
						{
							if (anPYzdd1I9.Count != 0)
							{
								DeclaracoesEntidades.StructureExportar exp = new DeclaracoesEntidades.StructureExportar
								{
									Codigo = XDataExpImp.codigoExportacao(),
									DWG = DeclaracoesGeral.arqAtivo.Indice,
									Caderno = DeclaracoesGeral.Conf.Local
								};
								if (!((Operators.CompareString(DeclaracoesGeral.ativo.Alternativo, "", TextCompare: true) != 0) & ((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5))))
								{
									exp.Pagina = DeclaracoesGeral.ativo.Pagina;
								}
								else
								{
									exp.Pagina = DeclaracoesGeral.ativo.Alternativo;
								}
								exp.Atualizado = true;
								exp.DWGDest = 0;
								exp.CadernoDest = "";
								exp.PaginaDest = "";
								exp.PosicaoDest = "";
								num = 0;
								short tipo = default;
								foreach (object item in anPYzdd1I9)
								{
									ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									Entity ent = (Entity)val6.GetObject((OpenMode)0);
									ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("EXPORTADO");
									if (xDataForApplication != null)
									{
										continue;
									}
									BlockReference val7 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
									short painel;
									if (val7 != null)
									{
										Entity ent2 = (Entity)(object)val7;
										string text = Pagina.calculaLinhaColuna(ref ent2, ref RH, ref RH2, flag, flag2);
										val7 = (BlockReference)ent2;
										string text2 = text;
										if (Operators.CompareString(text2, "", TextCompare: true) != 0)
										{
											if (DeclaracoesGeral.Conf.incluirColuna != 2)
											{
												exp.posicao = exp.Pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
											}
											else
											{
												exp.posicao = text2 + DeclaracoesGeral.Conf.SeparadorCruzamento + exp.Pagina;
											}
										}
										else
										{
											exp.posicao = exp.Pagina;
										}
										ent2 = (Entity)(object)val7;
										text = "";
										string text3 = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref text);
										val7 = (BlockReference)ent2;
										string text4 = text3;
										string left = text4;
										if (Operators.CompareString(left, "P", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "A", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "E", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "B", TextCompare: true) == 0)
													{
														object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val7);
														DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
														exp.Tipo = text4;
														exp.Handle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
														ref int indiceRegua = ref structureBorne.IndiceRegua;
														text3 = "";
														text = "";
														exp.Painel = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref indiceRegua, ref text3, ref text);
														exp.Texto = "";
														exp.NomeRegua = "";
														exp.indexModelo = 0;
														exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
														cDadosAccessExpImp2.ApagaAtributosHandle(exp.DWG, exp.Handle);
														foreach (object item2 in val7.AttributeCollection)
														{
															ObjectId val8 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
															AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)0);
															cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val9.Tag.ToUpper(), ((DBText)val9).TextString);
														}
														((DBObject)val7).UpgradeOpen();
														ent2 = (Entity)(object)val7;
														XDataExpImp.GravarXDataExportado(ref ent2, ref exp);
														val7 = (BlockReference)ent2;
														BSZYYRPUAl.Add(val6);
														num++;
													}
												}
												else
												{
													object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val7);
													DeclaracoesEntidades.StructurePortas structurePortas = ((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2));
													exp.Tipo = text4;
													exp.Handle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
													ent2 = (Entity)(object)val7;
													painel = XDataDispositivo.BuscaPainelDispositivo(ref ent2);
													val7 = (BlockReference)ent2;
													exp.Painel = painel;
													exp.Texto = "";
													exp.NomeRegua = "";
													exp.indexModelo = structurePortas.indiceDoModelo;
													exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
													cDadosAccessExpImp2.ApagaAtributosHandle(exp.DWG, exp.Handle);
													foreach (object item3 in val7.AttributeCollection)
													{
														ObjectId val10 = ((item3 == null) ? default(ObjectId) : ((ObjectId)item3));
														AttributeReference val11 = (AttributeReference)val10.GetObject((OpenMode)0);
														cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val11.Tag.ToUpper(), ((DBText)val11).TextString);
													}
													((DBObject)val7).UpgradeOpen();
													ent2 = (Entity)(object)val7;
													XDataExpImp.GravarXDataExportado(ref ent2, ref exp);
													val7 = (BlockReference)ent2;
													BSZYYRPUAl.Add(val6);
													num++;
												}
											}
											else
											{
												object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val7);
												if (obj3 == null)
												{
													_ = default(DeclaracoesEntidades.StructureAuxiliar);
												}
												else
													_ = (DeclaracoesEntidades.StructureAuxiliar)obj3;
												exp.Tipo = text4;
												exp.Handle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
												ent2 = (Entity)(object)val7;
												painel = XDataDispositivo.BuscaPainelDispositivo(ref ent2);
												val7 = (BlockReference)ent2;
												exp.Painel = painel;
												exp.Texto = "";
												exp.NomeRegua = "";
												exp.indexModelo = 0;
												exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
												cDadosAccessExpImp2.ApagaAtributosHandle(exp.DWG, exp.Handle);
												foreach (object item4 in val7.AttributeCollection)
												{
													ObjectId val12 = ((item4 == null) ? default(ObjectId) : ((ObjectId)item4));
													AttributeReference val13 = (AttributeReference)val12.GetObject((OpenMode)0);
													cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val13.Tag.ToUpper(), ((DBText)val13).TextString);
												}
												((DBObject)val7).UpgradeOpen();
												ent2 = (Entity)(object)val7;
												XDataExpImp.GravarXDataExportado(ref ent2, ref exp);
												val7 = (BlockReference)ent2;
												BSZYYRPUAl.Add(val6);
												num++;
											}
										}
										else
										{
											object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val7);
											DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj4 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj4));
											exp.Tipo = text4;
											exp.Handle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
											exp.Painel = structureDispositivo.Painel;
											exp.Texto = "";
											exp.NomeRegua = "";
											exp.indexModelo = 0;
											exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
											cDadosAccessExpImp2.ApagaAtributosHandle(exp.DWG, exp.Handle);
											foreach (object item5 in val7.AttributeCollection)
											{
												ObjectId val14 = ((item5 == null) ? default(ObjectId) : ((ObjectId)item5));
												AttributeReference val15 = (AttributeReference)val14.GetObject((OpenMode)0);
												cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val15.Tag.ToUpper(), ((DBText)val15).TextString);
											}
											((DBObject)val7).UpgradeOpen();
											ent2 = (Entity)(object)val7;
											XDataExpImp.GravarXDataExportado(ref ent2, ref exp);
											val7 = (BlockReference)ent2;
											BSZYYRPUAl.Add(val6);
											num++;
										}
									}
									Polyline pl = (Polyline)(object)((ent is Polyline) ? ent : null);
									DeclaracoesEntidades.StructureConexao conex = default;
									if (pl != null && XDataConexao.lerXDataConexao(ref pl, ref conex) && ((conex.Tipo == 2) | (conex.Tipo == 3)))
									{
										exp.Tipo = "C";
										exp.Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										exp.posicao = "";
										exp.Painel = conex.Painel;
										exp.Texto = "";
										exp.NomeRegua = "";
										exp.indexModelo = 0;
										exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
										((DBObject)pl).UpgradeOpen();
										Entity ent2 = (Entity)(object)pl;
										XDataExpImp.GravarXDataExportado(ref ent2, ref exp);
										pl = (Polyline)ent2;
										BSZYYRPUAl.Add(val6);
										num++;
									}
									int num2 = 0;
									painel = 0;
									bool flag3 = XDataConexao.lerXDataHatchLinha(ref ent, ref painel);
									num2 = painel;
									if (flag3 && num2 == 1)
									{
										exp.Tipo = "D";
										exp.Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
										exp.posicao = "";
										exp.Painel = -1;
										exp.Texto = "";
										exp.NomeRegua = "";
										exp.indexModelo = 0;
										exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
										((DBObject)ent).UpgradeOpen();
										XDataExpImp.GravarXDataExportado(ref ent, ref exp);
										BSZYYRPUAl.Add(val6);
										num++;
									}
									DBText val16 = (DBText)(object)((ent is DBText) ? ent : null);
									if (val16 != null)
									{
										string handle = "";
										string THandle = "";
										Entity ent2 = (Entity)(object)val16;
										string text = "";
										flag3 = XDataInterligacao.lerXDataAuxInterligacao(ref ent2, ref handle, ref tipo, ref THandle, ref text);
										val16 = (DBText)ent2;
										if (flag3 && tipo == 1)
										{
											exp.Tipo = "T";
											exp.Handle = ((object)((DBObject)val16).Handle/*cast due to constrained. prefix*/).ToString();
											exp.posicao = "";
											exp.Painel = -1;
											exp.Texto = val16.TextString;
											exp.NomeRegua = "";
											exp.indexModelo = 0;
											exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
											((DBObject)val16).UpgradeOpen();
											ent2 = (Entity)(object)val16;
											XDataExpImp.GravarXDataExportado(ref ent2, ref exp);
											val16 = (DBText)ent2;
											BSZYYRPUAl.Add(val6);
											num++;
										}
									}
									if (((DBObject)ent).XData == (ResultBuffer)null)
									{
										exp.Tipo = "K";
										exp.Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
										exp.posicao = "";
										exp.Painel = -1;
										exp.Texto = "";
										exp.NomeRegua = "";
										exp.indexModelo = 0;
										exp.indice = cDadosAccessExpImp2.gravaDispExportado(ref exp);
										((DBObject)ent).UpgradeOpen();
										XDataExpImp.GravarXDataExportado(ref ent, ref exp);
										BSZYYRPUAl.Add(val6);
										num++;
									}
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
					cDadosAccessExpImp2.fechaConexao();
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
		DeclaracoesGeral.bAnularEventos = true;
		if (num > 0)
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.SendStringToExecute("_QSAVE ", true, false, false);
			btImportar.Enabled = true;
		}
		PointMonitorToolTips.StartMonitor();
		DeclaracoesGeral.bAnularEventos = false;
	}

	private void t3KYq9yNMn(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 872]), MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			clsExportImport.removeTodosCodigosExportacao();
		}
	}

	private void vQ4YaKcKLk(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 873]), MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			clsExportImport.removeCodigosSelecionadosExportacao();
		}
	}

	private void Ld4Y8vngqH(object P_0, EventArgs P_1)
	{
		clsExportImport.Carimbo();
	}

	private void c5lYNbTmno(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1463]), MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			clsExportImport.ocultarImportadosSelecionados();
		}
	}

	private void zvuYFcWl9A(object P_0, EventArgs P_1)
	{
		clsExportImport.ligarImportadosPagina(DeclaracoesGeral.ativo.Pagina);
	}

	private void guoYQJLsb8(object P_0, EventArgs P_1)
	{
		try
		{
			DeclaracoesGeral.bSuspenderEventoExpImpClonar = true;
			cDadosAccess.carregaDadosDWG();
			UiCrhuZcXp = DeclaracoesGeral.arqAtivo.Indice;
			if (svXrJ0eYtE != UiCrhuZcXp)
			{
				btImportar.Enabled = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				V2tYcSWivI();
				bool bApagarImp = cbApagarImp.Checked;
				bool bExisteErro = false;
				clsExportImport.SincronizaImportados(bApagarImp, ref bExisteErro);
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 878]), MsgBoxStyle.Information);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
		finally
		{
			DeclaracoesGeral.bSuspenderEventoExpImpClonar = false;
		}
	}

	private void zTrYP092L6(object P_0, EventArgs P_1)
	{
		bool bExisteErro = false;
		clsExportImport.SincronizaExportados();
		clsExportImport.SincronizaImportados(cbApagarImp.Checked, ref bExisteErro);
		if (cbApagarImp.Checked)
		{
			clsExportImport.ApagaXDataImportadosAuxiliaresOrfaos();
		}
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		if (bExisteErro)
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1874]), MsgBoxStyle.Critical);
		}
	}

	private void V2tYcSWivI()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected Obj, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected Obj, but got Unknown
		DeclaracoesGeral.bAnularEventos = true;
		cXSY9syRhL = Application.DocumentManager.MdiActiveDocument;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					XPLrpXq430 = Conversions.ToDouble(tbDx.Text);
					ii3rTUCgwV = Conversions.ToDouble(tbDy.Text);
					Point3d val3 = new Point3d(0.0, 0.0, 0.0);
					Vector3d vectorTo = val3.GetVectorTo(new Point3d(XPLrpXq430, ii3rTUCgwV, 0.0));
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					IdMapping val6 = new IdMapping();
					SZsYrvtK7t.Database.WblockCloneObjects(BSZYYRPUAl, ((DBObject)val5).ObjectId, val6, (DuplicateRecordCloning)1, false);
					foreach (object item in val6)
					{
						IdPair val7 = ((item == null) ? default(IdPair) : ((IdPair)item));
						ObjectId key = val7.Key;
						ObjectId value = val7.Value;
						if (BSZYYRPUAl.Contains(key))
						{
							Entity val8 = (Entity)val2.GetObject(value, (OpenMode)1);
							val8.Layer = DeclaracoesGeral.ativo.Pagina;
							val8.TransformBy(Matrix3d.Displacement(vectorTo));
						}
					}
					foreach (object item2 in val6)
					{
						IdPair val9 = ((item2 == null) ? default(IdPair) : ((IdPair)item2));
						ObjectId key2 = val9.Key;
						ObjectId value2 = val9.Value;
						if (!BSZYYRPUAl.Contains(key2))
						{
							continue;
						}
						Entity ent = (Entity)val2.GetObject(value2, (OpenMode)1);
						DeclaracoesEntidades.StructureExportar exp = default;
						if (!XDataExpImp.LerXDataExportado(ref ent, ref exp))
						{
							continue;
						}
						string tipo = exp.Tipo;
						if (Operators.CompareString(tipo, "P", TextCompare: true) != 0 && Operators.CompareString(tipo, "A", TextCompare: true) != 0 && Operators.CompareString(tipo, "E", TextCompare: true) != 0 && Operators.CompareString(tipo, "B", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tipo, "C", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tipo, "D", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tipo, "T", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tipo, "K", TextCompare: true) != 0)
										{
										}
									}
									else
									{
										j6IYKTMYIT(ref ent, "AUXINTERLIG");
									}
								}
								else
								{
									j6IYKTMYIT(ref ent, "AUXDERIVACAO");
								}
							}
							else
							{
								j6IYKTMYIT(ref ent, "CONEXAO");
							}
						}
						else
						{
							j6IYKTMYIT(ref ent, "Dispositivo");
						}
						DeclaracoesEntidades.StructureExportar exp2 = new DeclaracoesEntidades.StructureExportar
						{
							DWG = exp.DWG,
							Codigo = exp.Codigo,
							indice = exp.indice,
							Handle = exp.Handle,
							Tipo = exp.Tipo,
							DWGDest = UiCrhuZcXp,
							Painel = exp.Painel
						};
						XDataExpImp.ApagarXDataExportado(ref ent);
						XDataExpImp.GravarXDataImportado(ref ent, ref exp2);
					}
					bool flag = true;
					int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, i], GOdrWFHpwl, TextCompare: true))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						Pagina.RemoveLayer(GOdrWFHpwl, bAtivaPag: true);
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

	private void j6IYKTMYIT(ref Entity P_0, string P_1)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			_ = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			TypedValue[] array = new TypedValue[1]
			{
				new TypedValue(1001, (object)P_1)
			};
			((DBObject)P_0).XData = new ResultBuffer(array);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	private void mNeYePZIVi(object P_0, EventArgs P_1)
	{
		tv1.Nodes.Clear();
		DeclaracoesEntidades.StructureExportar[] mExp = new DeclaracoesEntidades.StructureExportar[1];
		clsExportImport.CapturaExportados(ref mExp);
		List<string> list = new List<string>();
		int num = Information.UBound(mExp);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (!list.Contains(mExp[i].nomePainel))
				{
					list.Add(mExp[i].nomePainel);
				}
			}
			list.Sort();
			foreach (string item in list)
			{
				TreeNode treeNode = tv1.Nodes.Add(item);
				treeNode.Name = item;
				treeNode.NodeFont = new Font("Arial", 11f, FontStyle.Bold);
				treeNode.ForeColor = Color.Blue;
				List<string> list2 = new List<string>();
				int num2 = Information.UBound(mExp);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.CompareString(mExp[j].nomePainel, item, TextCompare: true) == 0 && !list2.Contains(mExp[j].Pagina))
					{
						list2.Add(mExp[j].Pagina);
					}
				}
				list2.Sort();
				foreach (string item2 in list2)
				{
					TreeNode treeNode2 = treeNode.Nodes.Add(item2);
					treeNode2.Name = item2;
					treeNode2.NodeFont = new Font("Arial", 10f, FontStyle.Bold);
					treeNode2.ForeColor = Color.Black;
				}
			}
			int num3 = Information.UBound(mExp);
			for (int k = 1; k <= num3; k++)
			{
				string text = "";
				if (Operators.CompareString(mExp[k].tag, "", TextCompare: true) != 0)
				{
					text = mExp[k].tag;
				}
				if (Operators.CompareString(mExp[k].efc, "", TextCompare: true) != 0)
				{
					text = text + " - " + mExp[k].efc;
				}
				if ((Operators.CompareString(text, "", TextCompare: true) != 0) & (Operators.CompareString(mExp[k].NomeRegua, "", TextCompare: true) != 0))
				{
					text += " - ";
				}
				if (Operators.CompareString(mExp[k].NomeRegua, "", TextCompare: true) != 0)
				{
					text = text + mExp[k].NomeRegua + ":" + mExp[k].numero;
				}
				TreeNode treeNode3 = tv1.Nodes[mExp[k].nomePainel].Nodes[mExp[k].Pagina].Nodes.Add(text);
				treeNode3.NodeFont = new Font("Arial", 9f);
				treeNode3.ForeColor = Color.Black;
				if (!((Operators.CompareString(mExp[k].CadernoDest, "", TextCompare: true) != 0) & (Operators.CompareString(mExp[k].CadernoDest, "INVALIDO", TextCompare: true) != 0)))
				{
					if (Operators.CompareString(mExp[k].CadernoDest, "INVALIDO", TextCompare: true) != 0)
					{
						treeNode3.Text += " » ?";
						treeNode3.BackColor = Color.Yellow;
					}
					else
					{
						TreeNode treeNode4;
						(treeNode4 = treeNode3).Text = Conversions.ToString(Operators.AddObject(treeNode4.Text, Operators.AddObject(" » ", DeclaracoesGeral.mMensagem[1, 1872])));
						treeNode3.BackColor = Color.LightCoral;
					}
				}
				else
				{
					TreeNode treeNode4;
					(treeNode4 = treeNode3).Text = treeNode4.Text + " » " + mExp[k].CadernoDest + " - " + mExp[k].PaginaDest;
				}
			}
			tv1.Sort();
			tv1.ExpandAll();
		}
	}

	private void GJTY2s4cfm(object P_0, EventArgs P_1)
	{
		clsExportImport.ApagaBlocoErro();
	}

	private void PoJY3pFk3s(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void jIVYnNjTDe(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}
}
