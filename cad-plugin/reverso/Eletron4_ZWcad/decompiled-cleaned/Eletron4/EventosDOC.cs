using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

public class EventosDOC
{
	public static void WillLockCommand(object sender, DocumentLockModeWillChangeEventArgs e)
	{
		string globalCommandName = e.GlobalCommandName;
		if (Operators.CompareString(globalCommandName, "U", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "UNDO", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "PURGE", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "-VBARUN", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "ZOOM", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "QUIT", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "GRIP_EDIT", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "GRIP_STRETCH", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "PREVIEW_END", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "CLOSE", TextCompare: true) != 0)
		{
			if (Operators.CompareString(globalCommandName, "QSAVE", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "SAVE", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "SAVEAS", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "AUTO_SAVE", TextCompare: true) != 0)
			{
				if (Operators.CompareString(globalCommandName, "#U", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#UNDO", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#PURGE", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#-VBARUN", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#ZOOM", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#QUIT", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#GRIP_EDIT", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#GRIP_STRETCH", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#PREVIEW_END", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#CLOSE", TextCompare: true) != 0)
				{
					if (Operators.CompareString(globalCommandName, "#QSAVE", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#SAVE", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#SAVEAS", TextCompare: true) != 0 && Operators.CompareString(globalCommandName, "#AUTO_SAVE", TextCompare: true) != 0)
					{
						if (Operators.CompareString(globalCommandName, "MIRROR", TextCompare: true) != 0)
						{
							if (Operators.CompareString(globalCommandName, "#MIRROR", TextCompare: true) != 0)
							{
								if (Operators.CompareString(globalCommandName, "ROTATE", TextCompare: true) != 0)
								{
									if (Operators.CompareString(globalCommandName, "#ROTATE", TextCompare: true) != 0)
									{
										if (Operators.CompareString(globalCommandName, "SCALE", TextCompare: true) != 0)
										{
											if (Operators.CompareString(globalCommandName, "#SCALE", TextCompare: true) != 0)
											{
												if (Operators.CompareString(globalCommandName, "COPYCLIP", TextCompare: true) == 0 || Operators.CompareString(globalCommandName, "COPY", TextCompare: true) == 0 || Operators.CompareString(globalCommandName, "COPYBASE", TextCompare: true) == 0)
												{
													Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
													DeclaracoesGeral.sDocumentoclip = mdiActiveDocument.Name;
												}
												return;
											}
											if (Declaracoes2.bScaleAtivo && Declaracoes2.bCancelaScale)
											{
												Application.DocumentManager.MdiActiveDocument.SendStringToExecute("_u ", true, false, false);
											}
											Declaracoes2.bScaleAtivo = false;
											Declaracoes2.bCancelaScale = false;
										}
										else
										{
											Declaracoes2.bScaleAtivo = true;
										}
									}
									else
									{
										if (Declaracoes2.bRotateAtivo && Declaracoes2.bCanselaRotate)
										{
											Application.DocumentManager.MdiActiveDocument.SendStringToExecute("_u ", true, false, false);
										}
										Declaracoes2.bRotateAtivo = false;
										Declaracoes2.bCanselaRotate = false;
									}
								}
								else
								{
									Declaracoes2.bRotateAtivo = true;
								}
								return;
							}
							if (Declaracoes2.bMirrorAtivo)
							{
								if (Declaracoes2.bCancelaMirror)
								{
									Application.DocumentManager.MdiActiveDocument.SendStringToExecute("_u ", true, false, false);
								}
								Document mdiActiveDocument2 = Application.DocumentManager.MdiActiveDocument;
								mdiActiveDocument2.SendStringToExecute("_.ApagaBlocosMirror \n", true, false, true);
							}
							Declaracoes2.bMirrorAtivo = false;
							Declaracoes2.bCancelaMirror = false;
						}
						else
						{
							Declaracoes2.bMirrorAtivo = true;
						}
					}
					else
					{
						DeclaracoesGeral.bAnularEventos = false;
						DeclaracoesGeral.bSuspenderEvento = false;
					}
				}
				else
				{
					DeclaracoesGeral.bAnularEventos = false;
					DeclaracoesGeral.bSuspenderEvento = false;
				}
			}
			else
			{
				DeclaracoesGeral.bAnularEventos = true;
				DeclaracoesGeral.bSuspenderEvento = true;
			}
		}
		else
		{
			DeclaracoesGeral.bAnularEventos = true;
			DeclaracoesGeral.bSuspenderEvento = true;
		}
	}

	public static void criaDocumento()
	{
		if (DeclaracoesGeral.bAnularEventos | DeclaracoesGeral.bCancelarEventoTrocaDocumento)
		{
		}
	}

	public static void AtivaDocumento()
	{
		if (DeclaracoesGeral.bCancelarEventoTrocaDocumento)
		{
			return;
		}
		checked
		{
			try
			{
				int count = Application.OpenForms.Count;
				int num = count - 1;
				for (int i = num; i >= 0; i += -1)
				{
					Form form = Application.OpenForms[i];
					string name = form.Name;
					if (Operators.CompareString(name, "frmExportarImportar", TextCompare: true) != 0 && Operators.CompareString(name, "frmClonar", TextCompare: true) != 0 && Operators.CompareString(name, "frmRelatorio_Aranha", TextCompare: true) != 0 && Operators.CompareString(name, "frmRelatorio_DInterlig", TextCompare: true) != 0 && Operators.CompareString(name, "frmRelatorio_DIEnergisaMS", TextCompare: true) != 0 && Operators.CompareString(name, "frmRelatorio_DIEnergisaMT", TextCompare: true) != 0 && Operators.CompareString(name, "frmRelatorio_DICemig", TextCompare: true) != 0 && Operators.CompareString(name, "frmMisturador", TextCompare: true) != 0 && Operators.CompareString(name, "frmClonarEstruturaRegua", TextCompare: true) != 0 && Operators.CompareString(name, "frmCopiarObjetos", TextCompare: true) != 0)
					{
						form.Close();
					}
				}
				Iniciar.IniciarDWG();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void fechaDocumento()
	{
		int num = 1;
		try
		{
			if (Application.DocumentManager.Count == num && DeclaracoesGeral._pspag != null)
			{
				DeclaracoesGeral._pspag.Visible = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void trocaColorSchema(object senderObj, SystemVariableChangedEventArgs sysVarChEvtArgs)
	{
		try
		{
			Version version = Application.Version;
			if (version.Major >= 20 && Operators.CompareString(sysVarChEvtArgs.Name, "COLORTHEME", TextCompare: true) == 0)
			{
				Ribbon ribbon = new Ribbon();
				ribbon.RemoveRibbon();
				ribbon.CreateRibbon();
				ribbon.CreateRibbon2();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
