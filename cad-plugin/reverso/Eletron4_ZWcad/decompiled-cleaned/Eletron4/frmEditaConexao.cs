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
using ZwSoft.ZwCAD.EditorInput;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmEditaConexao : Form
{
	private IContainer lTbZ9uDA1B;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEditar")]
	private Button qSpZzHAi6s;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	[CompilerGenerated]
	private DataGridView Dv1iWrLH83;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip RJ9ipTnYLn;

	internal virtual Button btEditar
	{
		[CompilerGenerated]
		get
		{
			return qSpZzHAi6s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = j2HZCSevKW;
			Button button = qSpZzHAi6s;
			if (button != null)
			{
				button.Click -= value2;
			}
			qSpZzHAi6s = value;
			button = qSpZzHAi6s;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return Dv1iWrLH83;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Dv1iWrLH83 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && lTbZ9uDA1B != null)
			{
				lTbZ9uDA1B.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void qX8Z4YKcsF()
	{
		lTbZ9uDA1B = new Container();
		btEditar = new Button();
		dg = new DataGridView();
		FDqpBiUmZij(new ToolTip(lTbZ9uDA1B));
		((ISupportInitialize)dg).BeginInit();
		SuspendLayout();
		btEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btEditar.FlatStyle = FlatStyle.Flat;
		btEditar.ForeColor = SystemColors.Control;
		btEditar.Image = Resources.OK_32;
		btEditar.Location = new Point(32, 308);
		btEditar.Name = "btEditar";
		btEditar.Size = new Size(40, 42);
		btEditar.TabIndex = 16;
		btEditar.UseVisualStyleBackColor = true;
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = Color.White;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(6, 12);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(91, 290);
		dg.TabIndex = 18;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(104, 362);
		Controls.Add(dg);
		Controls.Add(btEditar);
		MaximizeBox = false;
		MaximumSize = new Size(120, 800);
		MinimizeBox = false;
		MinimumSize = new Size(120, 400);
		Name = "frmEditaConexao";
		ShowInTaskbar = false;
		Text = "Editar Conexão";
		((ISupportInitialize)dg).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return RJ9ipTnYLn;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		RJ9ipTnYLn = WithEventsValue;
	}

	public frmEditaConexao()
	{
		try
		{
			if (!Geral.ExisteForm("frmEditaConexao"))
			{
				qX8Z4YKcsF();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 719]);
				w8dpBZ0kvSD().SetToolTip(btEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 719]));
				QNjZraIE9k();
				FpkZYb3mMU();
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

	private void j2HZCSevKW(object P_0, EventArgs P_1)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		List<string> list = new List<string>();
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dg.Rows[i].Selected)
				{
					list.Add(Conversions.ToString(dg.Rows[i].Cells[0].Value));
				}
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			clsConexao clsConexao2 = new clsConexao();
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptKeywordOptions val = new PromptKeywordOptions("");
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 715]));
			((PromptOptions)val).Keywords.Add("S");
			((PromptOptions)val).Keywords.Add("C");
			((PromptOptions)val).Keywords.Add("A");
			val.AllowNone = false;
			val.AllowArbitraryInput = false;
			((PromptOptions)val).Keywords.Default = "A";
			PromptResult keywords = editor.GetKeywords(val);
			if (Operators.CompareString(keywords.StringResult, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(keywords.StringResult, "C", TextCompare: true) != 0)
				{
					if (Operators.CompareString(keywords.StringResult, "A", TextCompare: true) == 0)
					{
						clsConexao2.editarSecaoCorPaginas(3, list);
					}
				}
				else
				{
					clsConexao2.editarSecaoCorPaginas(2, list);
				}
			}
			else
			{
				clsConexao2.editarSecaoCorPaginas(1, list);
			}
		}
	}

	private void FpkZYb3mMU()
	{
		try
		{
			dg.Columns[0].ReadOnly = false;
			dg.MultiSelect = true;
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dg.Rows.Add(DeclaracoesGeral.mPaginas[0, i]);
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

	private void QNjZraIE9k()
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
}
