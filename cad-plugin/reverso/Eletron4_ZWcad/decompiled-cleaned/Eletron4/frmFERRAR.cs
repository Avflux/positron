using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

[DesignerGenerated]
public class frmFERRAR : Form
{
	private IContainer qYhkKt1NDr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button eHZkeT0WyD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TextBox1")]
	private TextBox kgWk2d9w1l;

	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label KmIk30mK07;

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return eHZkeT0WyD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SHOkc5XM87;
			Button button = eHZkeT0WyD;
			if (button != null)
			{
				button.Click -= value2;
			}
			eHZkeT0WyD = value;
			button = eHZkeT0WyD;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return kgWk2d9w1l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kgWk2d9w1l = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return KmIk30mK07;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KmIk30mK07 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && qYhkKt1NDr != null)
			{
				qYhkKt1NDr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void w5JkPUMKep()
	{
		Button1 = new Button();
		TextBox1 = new TextBox();
		Label1 = new Label();
		SuspendLayout();
		Button1.Location = new Point(74, 25);
		Button1.Name = "Button1";
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 0;
		Button1.Text = "FERRAR";
		Button1.UseVisualStyleBackColor = true;
		TextBox1.Location = new Point(63, 68);
		TextBox1.Name = "TextBox1";
		TextBox1.Size = new Size(100, 20);
		TextBox1.TabIndex = 1;
		Label1.AutoSize = true;
		Label1.Location = new Point(95, 110);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 2;
		Label1.Text = "Label1";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(227, 147);
		Controls.Add(Label1);
		Controls.Add(TextBox1);
		Controls.Add(Button1);
		Name = "frmFERRAR";
		Text = "frmFERRAR";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmFERRAR()
	{
		try
		{
			if (!Geral.ExisteForm("frmFERRAR"))
			{
				cDadosAccess.carregaDadosDWG();
				w5JkPUMKep();
				Application.ShowModelessDialog((Form)this);
				TextBox1.Text = Conversions.ToString(100);
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

	private void SHOkc5XM87(object P_0, EventArgs P_1)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Obj, but got Unknown
		int num = Conversions.ToInteger(TextBox1.Text);
		BlockTableRecordEnumerator enumerator = default;
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			Label1.Text = i.ToString();
			Application.DoEvents();
			PointMonitorToolTips.StopMonitor();
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					try
					{
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)current.GetObject((OpenMode)0);
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 != null)
								{
									Entity ent = (Entity)(object)val6;
									string tipoImportado = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									val6 = (BlockReference)ent;
									string text2 = text;
									string left = text2;
									if (Operators.CompareString(left, "", TextCompare: true) != 0 && Operators.CompareString(left, "I", TextCompare: true) != 0 && Operators.CompareString(left, "M", TextCompare: true) != 0 && (Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "E", TextCompare: true) == 0 || Operators.CompareString(left, "B", TextCompare: true) == 0))
									{
										Funcao1(ref val6, i);
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
	}

	public static string Funcao1(ref BlockReference blockRef, int cont)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			AttributeCollection attributeCollection = blockRef.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val2 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val3 = (AttributeReference)val.GetObject(val2, (OpenMode)0);
				_ = val3.Tag;
				((DBObject)val3).UpgradeOpen();
				((DBText)val3).TextString = cont.ToString();
				((Entity)val3).Draw();
			}
			Funcao2(ref blockRef, cont);
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
		return result;
	}

	public static string Funcao2(ref BlockReference blockRef, int cont)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			((DBObject)blockRef).UpgradeOpen();
			Point3d val2 = new Point3d(0.0, 0.0, 0.0);
			Vector3d vectorTo = val2.GetVectorTo(new Point3d(0.0, 0.0, (double)cont));
			((Entity)blockRef).TransformBy(Matrix3d.Displacement(vectorTo));
			((Entity)blockRef).Visible = true;
			((Entity)blockRef).Highlight();
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
		return result;
	}
}
