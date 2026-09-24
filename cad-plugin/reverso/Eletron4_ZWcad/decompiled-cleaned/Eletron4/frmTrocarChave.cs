using System;
using System.Collections.Specialized;
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

namespace Eletron4;

[DesignerGenerated]
public class frmTrocarChave : Form
{
	private IContainer SsapnGTlluG;

	[AccessedThroughProperty("tbPara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox ziqpnH62rij;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDe")]
	private TextBox oVXpnkKjI1H;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	private DataGridView V7tpndQPAeK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserir")]
	private Button IEspnf8FZ5n;

	private bool T8xpnDvgura;

	internal virtual TextBox tbPara
	{
		[CompilerGenerated]
		get
		{
			return ziqpnH62rij;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ziqpnH62rij = value;
		}
	}

	internal virtual TextBox tbDe
	{
		[CompilerGenerated]
		get
		{
			return oVXpnkKjI1H;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oVXpnkKjI1H = value;
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return V7tpndQPAeK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			V7tpndQPAeK = value;
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return IEspnf8FZ5n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bHspnobPRqG;
			Button button = IEspnf8FZ5n;
			if (button != null)
			{
				button.Click -= value2;
			}
			IEspnf8FZ5n = value;
			button = IEspnf8FZ5n;
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
			if (disposing && SsapnGTlluG != null)
			{
				SsapnGTlluG.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void hmppnhDiDLw()
	{
		tbPara = new TextBox();
		tbDe = new TextBox();
		dg = new DataGridView();
		btInserir = new Button();
		((ISupportInitialize)dg).BeginInit();
		SuspendLayout();
		tbPara.Location = new Point(12, 404);
		tbPara.Name = "tbPara";
		tbPara.Size = new Size(86, 20);
		tbPara.TabIndex = 17;
		tbDe.Location = new Point(12, 378);
		tbDe.Name = "tbDe";
		tbDe.Size = new Size(86, 20);
		tbDe.TabIndex = 16;
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dg.BackgroundColor = Color.White;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(12, 12);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(86, 347);
		dg.TabIndex = 15;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.Key;
		btInserir.Location = new Point(31, 430);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 40);
		btInserir.TabIndex = 18;
		btInserir.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(124, 481);
		Controls.Add(btInserir);
		Controls.Add(tbPara);
		Controls.Add(tbDe);
		Controls.Add(dg);
		MaximumSize = new Size(132, 520);
		MinimumSize = new Size(132, 520);
		Name = "frmTrocarChave";
		ShowIcon = false;
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmEditaTitulos";
		((ISupportInitialize)dg).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmTrocarChave()
	{
		T8xpnDvgura = false;
		hmppnhDiDLw();
		Text = "Troca Chave Primária";
		formataDG();
		CarregaDG();
		Application.ShowModelessDialog((Form)this);
	}

	private void bHspnobPRqG(object P_0, EventArgs P_1)
	{
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected Obj, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected Obj, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected Obj, but got Unknown
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 297]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		StringCollection stringCollection = new StringCollection();
		string text = tbDe.Text.Trim();
		string text2 = tbPara.Text.Trim();
		if (!((Operators.CompareString(text, "", TextCompare: true) == 0) | (Operators.CompareString(text2, "", TextCompare: true) == 0)))
		{
			int num = 0;
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
						foreach (DataGridViewRow selectedRow in dg.SelectedRows)
						{
							string value = Conversions.ToString(selectedRow.Cells[0].Value);
							stringCollection.Add(value);
						}
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val4.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current = enumerator2.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								if (!stringCollection.Contains(val5.Layer.ToString()))
								{
									continue;
								}
								MText val6 = (MText)(object)((val5 is MText) ? val5 : null);
								if (val6 != null)
								{
									Entity Ent = (Entity)(object)val6;
									string text3 = XDataDispositivosMaster.LerXDataTextoLP(ref Ent);
									val6 = (MText)Ent;
									string text4 = text3;
									if (Operators.CompareString(text4, "", TextCompare: true) != 0 && text4.Contains(text))
									{
										text4 = text4.Replace(text, text2);
										num = checked(num + 1);
										((DBObject)val6).UpgradeOpen();
										Ent = (Entity)(object)val6;
										XDataDispositivosMaster.GravarXDataTextoLP(ref Ent, text4);
										val6 = (MText)Ent;
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						Application.UpdateScreen();
						if (num > 0)
						{
							T8xpnDvgura = true;
							Interaction.MsgBox(Operators.AddObject(num.ToString(), DeclaracoesGeral.mMensagem[1, 300]), MsgBoxStyle.Information, "Elétron");
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						return;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val2.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Elétron");
						ProjectData.ClearProjectError();
						return;
					}
					finally
					{
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
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 298]), MsgBoxStyle.Information, "Elétron");
	}

	public void formataDG()
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
			dg.ReadOnly = true;
			dg.AllowUserToAddRows = false;
			dg.MultiSelect = true;
		}
	}

	public void CarregaDG()
	{
		try
		{
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dg.Rows.Add(Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}
}
