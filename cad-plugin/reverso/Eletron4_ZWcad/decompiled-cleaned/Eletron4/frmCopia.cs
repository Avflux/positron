using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmCopia : Form
{
	private IContainer wqZoqwKS5h;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip Nsgoav98fL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dg")]
	private DataGridView AGRo8c1Zxq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSeleciona")]
	private Button hZ2oNdyTn6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btColar")]
	private Button oCOoF1dvG7;

	[CompilerGenerated]
	[AccessedThroughProperty("BTConstroiLink")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button w9goQgCxpW;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return AGRo8c1Zxq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AGRo8c1Zxq = value;
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return hZ2oNdyTn6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mBIoOHhe3s;
			Button button = hZ2oNdyTn6;
			if (button != null)
			{
				button.Click -= value2;
			}
			hZ2oNdyTn6 = value;
			button = hZ2oNdyTn6;
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
			return oCOoF1dvG7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = e56oIK3CwO;
			Button button = oCOoF1dvG7;
			if (button != null)
			{
				button.Click -= value2;
			}
			oCOoF1dvG7 = value;
			button = oCOoF1dvG7;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTConstroiLink
	{
		[CompilerGenerated]
		get
		{
			return w9goQgCxpW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FZjo7Ud0hu;
			Button button = w9goQgCxpW;
			if (button != null)
			{
				button.Click -= value2;
			}
			w9goQgCxpW = value;
			button = w9goQgCxpW;
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
			if (disposing && wqZoqwKS5h != null)
			{
				wqZoqwKS5h.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void bW8obg74uv()
	{
		wqZoqwKS5h = new Container();
		FDqpBiUmZij(new ToolTip(wqZoqwKS5h));
		dg = new DataGridView();
		btSeleciona = new Button();
		btColar = new Button();
		BTConstroiLink = new Button();
		((ISupportInitialize)dg).BeginInit();
		SuspendLayout();
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToOrderColumns = true;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = SystemColors.ButtonHighlight;
		dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(7, 12);
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(289, 296);
		dg.TabIndex = 45;
		btSeleciona.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_32;
		btSeleciona.Location = new Point(7, 314);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(40, 40);
		btSeleciona.TabIndex = 172;
		btSeleciona.Tag = "";
		btSeleciona.UseVisualStyleBackColor = true;
		btColar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btColar.FlatStyle = FlatStyle.Flat;
		btColar.ForeColor = SystemColors.Control;
		btColar.Image = Resources.Paste_32;
		btColar.Location = new Point(256, 314);
		btColar.Name = "btColar";
		btColar.Size = new Size(40, 40);
		btColar.TabIndex = 197;
		btColar.UseVisualStyleBackColor = true;
		BTConstroiLink.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTConstroiLink.FlatStyle = FlatStyle.Flat;
		BTConstroiLink.ForeColor = SystemColors.Control;
		BTConstroiLink.Image = Resources.Restaura_32;
		BTConstroiLink.Location = new Point(132, 314);
		BTConstroiLink.Name = "BTConstroiLink";
		BTConstroiLink.Size = new Size(40, 40);
		BTConstroiLink.TabIndex = 198;
		BTConstroiLink.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(304, 361);
		Controls.Add(BTConstroiLink);
		Controls.Add(dg);
		Controls.Add(btColar);
		Controls.Add(btSeleciona);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(320, 1400);
		MinimizeBox = false;
		MinimumSize = new Size(320, 400);
		Name = "frmCopia";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frm Cópia sem Função Elétrica";
		((ISupportInitialize)dg).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return Nsgoav98fL;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		Nsgoav98fL = WithEventsValue;
	}

	public frmCopia()
	{
		try
		{
			if (!Geral.ExisteForm("frmCopia"))
			{
				bW8obg74uv();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1726]);
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

	public void FormataDG()
	{
		try
		{
			dg.Rows.Clear();
			dg.Columns.Clear();
			dg.Columns.Add("", "Handle");
			dg.Columns.Add("", "Tipo");
			dg.Columns.Add("", "Nome");
			dg.Columns.Add("", "NomeBloco");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void Lv3oMMiaVe(clsCopia.structureCopia[] P_0)
	{
		try
		{
			FormataDG();
			int num = Information.UBound(P_0);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dg.Rows.Add(P_0[i].sHandle, P_0[i].sTipo, P_0[i].sNome, P_0[i].sNomeBloco);
			}
			AtualizaDG();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDG()
	{
		checked
		{
			if (dg.Columns.Count > 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = 0;
				dg.Columns[1].Width = (int)Math.Round(num * 0.2);
				dg.Columns[2].Width = (int)Math.Round(num * 0.4);
				dg.Columns[3].Width = (int)Math.Round(num * 0.4);
				dg.Columns[0].Visible = false;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = true;
				dg.Columns[3].Visible = true;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
			}
		}
	}

	private void mBIoOHhe3s(object P_0, EventArgs P_1)
	{
		PointMonitorToolTips.StopMonitor();
		new List<string>();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Hide();
			clsCopia.structureCopia[] mListaDisp = null;
			clsCopia.SelecionaBornesParaEdicao(ref mListaDisp);
			if (mListaDisp.Count() > 0)
			{
				Lv3oMMiaVe(mListaDisp);
			}
			Show();
			AtualizaDG();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		PointMonitorToolTips.StartMonitor();
	}

	private void e56oIK3CwO(object P_0, EventArgs P_1)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected Obj, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected Obj, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Invalid comparison between Unknown and I4
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Invalid comparison between Unknown and I4
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected Obj, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected Obj, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected Obj, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected Obj, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected Obj, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cadgraph\\Eletron4\\";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string sHandle = Conversions.ToString(dg.SelectedRows[0].Cells[0].Value);
					string text2 = Conversions.ToString(dg.SelectedRows[0].Cells[3].Value);
					text = DeclaracoesGeral.Conf.DirSimbologiaEletrica + text2 + ".dwg";
					clsCopia.structureATTBloco[] Att = null;
					clsCopia.LeTodosOsAtributosDoBloco(ref sHandle, ref Att);
					if (!((SymbolTable)val4).Has(text2))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text2, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text2], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					BlockReference val8 = new BlockReference(Point3d.Origin, val3);
					((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
					BlockTableRecord val9 = null;
					Jig jig = new Jig((Entity)(object)val8);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val10 = editor.Drag((Jig)(object)jig);
					if (!(((int)val10.Status == -5002) | ((int)val10.Status == -5001)))
					{
						((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
						val5.AppendEntity((Entity)(object)val8);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
						((Entity)val8).Draw();
						val9 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val9.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val11 = (Entity)val2.GetObject(current, (OpenMode)0);
								if (!(val11 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val12 = (AttributeDefinition)val11;
								AttributeReference val13 = new AttributeReference();
								val13.SetAttributeFromBlock(val12, val8.BlockTransform);
								int num = Information.UBound(Att);
								for (int i = 0; i <= num; i = checked(i + 1))
								{
									if (Operators.CompareString(val12.Tag, Att[i].Tag, TextCompare: true) == 0)
									{
										((DBText)val13).TextString = Att[i].sValor;
										((Entity)val13).Visible = Att[i].bVisivel;
										break;
									}
								}
								((DBText)val13).AdjustAlignment(database);
								val8.AttributeCollection.AppendAttribute(val13);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
								((Entity)val13).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						Entity ent = (Entity)(object)val8;
						XDataGeral.gravarXDataCopiaSemFuncaoEletrica(ref ent, sHandle);
						val8 = (BlockReference)ent;
					}
					else
					{
						val8 = null;
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

	private void FZjo7Ud0hu(object P_0, EventArgs P_1)
	{
		clsCopia.AtualizaBlocosCopia();
	}
}
