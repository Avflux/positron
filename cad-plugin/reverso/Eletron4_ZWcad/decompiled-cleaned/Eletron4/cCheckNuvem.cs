using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Eletron4.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class cCheckNuvem
{
	private int wKizwmZkK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool IrDpW5EQgq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool NwYppfQsAs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool w8mpTPW8sp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string jXipJ64lke;

	public bool bApp
	{
		[CompilerGenerated]
		get
		{
			return IrDpW5EQgq;
		}
		[CompilerGenerated]
		set
		{
			IrDpW5EQgq = value;
		}
	}

	public bool bTrial
	{
		[CompilerGenerated]
		get
		{
			return NwYppfQsAs;
		}
		[CompilerGenerated]
		set
		{
			NwYppfQsAs = value;
		}
	}

	public bool bAbreRegistro
	{
		[CompilerGenerated]
		get
		{
			return w8mpTPW8sp;
		}
		[CompilerGenerated]
		set
		{
			w8mpTPW8sp = value;
		}
	}

	public string msg
	{
		[CompilerGenerated]
		get
		{
			return jXipJ64lke;
		}
		[CompilerGenerated]
		set
		{
			jXipJ64lke = value;
		}
	}

	public cCheckNuvem()
	{
		wKizwmZkK = 2;
		bApp = false;
		bTrial = false;
		bAbreRegistro = false;
		msg = "";
	}

	public void verificaLic()
	{
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Expected Obj, but got Unknown
		//IL_06f7: Expected Obj, but got Unknown
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.structureLic lic = default;
		DeclaracoesGeral.structureUser user = default;
		cDadosSQLServerLicenca cDadosSQLServerLicenca2 = new cDadosSQLServerLicenca();
		checked
		{
			try
			{
				DeclaracoesGeral.structureUserPC structureUserPC = default;
				double num = 26.03;
				string versaoCAD = Geral.CADVersion();
				if (HPKCuHb17(ref structureUserPC))
				{
					if (Operators.CompareString(structureUserPC.CPUID, CbU9DG8Fi(), TextCompare: true) == 0)
					{
						if (cDadosSQLServerLicenca2.testaConexao())
						{
							lic.Licenca = structureUserPC.Licenca;
							if (cDadosSQLServerLicenca2.carregaLicenca(ref lic))
							{
								user.ChaveLic = lic.ChaveLic;
								user.Email = structureUserPC.Email;
								user.IDUnico = structureUserPC.IDUnico;
								if (lic.Habilitada)
								{
									int num2 = (int)Math.Round(DateAndTime.DateValue(Conversions.ToString(DateAndTime.Now.Date)).ToOADate());
									if (!((lic.DataExpira > 0) & (num2 >= lic.DataExpira)))
									{
										if (lic.Software == wKizwmZkK)
										{
											if (cDadosSQLServerLicenca2.carregaUser(ref user))
											{
												structureUserPC.UltLogin = num2;
												structureUserPC.DiasTrial = lic.DiasTrial;
												structureUserPC.UsoTrial = 0;
												structureUserPC.NomeCliente = lic.NomeCliente;
												structureUserPC.CodigoCliente = lic.CodigoCliente;
												structureUserPC.Versao = lic.Versao;
												structureUserPC.DiaInicialTrial = 0;
												y0PYeBw4b("CL4", Conversions.ToString(structureUserPC.UltLogin));
												y0PYeBw4b("CL6", Conversions.ToString(structureUserPC.DiasTrial));
												y0PYeBw4b("CL7", Conversions.ToString(structureUserPC.UsoTrial));
												y0PYeBw4b("CL9", structureUserPC.NomeCliente);
												y0PYeBw4b("CL10", Conversions.ToString(structureUserPC.CodigoCliente));
												y0PYeBw4b("CL11", Conversions.ToString(structureUserPC.Versao));
												y0PYeBw4b("CL12", Conversions.ToString(structureUserPC.DiaInicialTrial));
												cDadosSQLServerLicenca2.AtualizaUltimoLogin(structureUserPC.UltLogin, user.ChaveUser, versaoCAD, num);
												if (!((structureUserPC.Versao == 0.0) | (num <= structureUserPC.Versao)))
												{
													bApp = false;
													bTrial = false;
													msg = "Esta licença não possui Contrato de Suporte ativo para usar esta versão!";
												}
												else
												{
													bApp = true;
													bTrial = false;
													msg = "Licença carregada!";
													DeclaracoesGeral.companyHardlock = structureUserPC.NomeCliente;
												}
											}
											else
											{
												F4wr8yg9m();
												bApp = false;
												bTrial = false;
												msg = "A licença deste usuário não existe mais no servidor!";
											}
										}
										else
										{
											bApp = false;
											bTrial = false;
											msg = "Esta licença não é deste software!";
										}
									}
									else
									{
										y0PYeBw4b("CL6", Conversions.ToString(0));
										bApp = false;
										bTrial = false;
										msg = "Esta licença já expirou!";
									}
								}
								else
								{
									y0PYeBw4b("CL6", Conversions.ToString(0));
									bApp = false;
									bTrial = false;
									msg = "Esta licença está desabilitada no servidor!";
								}
							}
							else
							{
								F4wr8yg9m();
								bApp = false;
								bTrial = false;
								msg = "Esta licença não existe mais no servidor!";
							}
							return;
						}
						Interaction.MsgBox("Sem conexão com o servidor na nuvem!");
						if (structureUserPC.UltLogin >= structureUserPC.DataCriacao)
						{
							if (structureUserPC.DiasTrial != 0)
							{
								int num3 = (int)Math.Round(DateAndTime.DateValue(Conversions.ToString(DateAndTime.Now.Date)).ToOADate());
								if (structureUserPC.DiaInicialTrial != 0)
								{
									int num4 = num3 - structureUserPC.DiaInicialTrial;
									if (num4 >= 0)
									{
										if (num3 < structureUserPC.UltLogin)
										{
											structureUserPC.DiasTrial = 0;
											y0PYeBw4b("CL6", Conversions.ToString(structureUserPC.DiasTrial));
											bApp = false;
											bTrial = false;
											msg = "A data do computador foi adulterada";
											return;
										}
										if (num4 >= structureUserPC.DiasTrial)
										{
											structureUserPC.UltLogin = num3;
											structureUserPC.DiasTrial = 0;
											y0PYeBw4b("CL4", Conversions.ToString(structureUserPC.UltLogin));
											y0PYeBw4b("CL6", Conversions.ToString(structureUserPC.DiasTrial));
											bApp = false;
											bTrial = false;
											msg = "Trial expirou!";
											return;
										}
										structureUserPC.UltLogin = num3;
										y0PYeBw4b("CL4", Conversions.ToString(structureUserPC.UltLogin));
										if (!((structureUserPC.Versao == 0.0) | (num <= structureUserPC.Versao)))
										{
											bApp = false;
											bTrial = false;
											msg = "Esta licença não possui Contrato de Suporte ativo para usar esta versão!";
										}
										else
										{
											bApp = false;
											bTrial = true;
											msg = "Licença Trial Ativada!";
											DeclaracoesGeral.companyHardlock = "Trial dia " + (num4 + 1) + "/" + structureUserPC.DiasTrial;
										}
									}
									else
									{
										structureUserPC.DiasTrial = 0;
										y0PYeBw4b("CL6", Conversions.ToString(structureUserPC.DiasTrial));
										bApp = false;
										bTrial = false;
										msg = "A data do computador foi adulterada para antes da data inicial do Trial!";
									}
								}
								else
								{
									structureUserPC.UltLogin = num3;
									structureUserPC.DiaInicialTrial = num3;
									y0PYeBw4b("CL4", Conversions.ToString(structureUserPC.UltLogin));
									y0PYeBw4b("CL12", Conversions.ToString(structureUserPC.DiaInicialTrial));
									MySettingsProperty.Settings.Codigo = "";
									MySettingsProperty.Settings.DCode = "";
									MySettingsProperty.Settings.HCode = "";
									MySettingsProperty.Settings.Cont = -1;
									MySettingsProperty.Settings.Save();
									if (!((structureUserPC.Versao == 0.0) | (num <= structureUserPC.Versao)))
									{
										bApp = false;
										bTrial = false;
										msg = "Esta licença não possui Contrato de Suporte ativo para usar esta versão!";
									}
									else
									{
										bApp = false;
										bTrial = true;
										msg = "Licença Trial Ativada!";
										DeclaracoesGeral.companyHardlock = "Trial dia 1/" + structureUserPC.DiasTrial;
									}
								}
							}
							else
							{
								bApp = false;
								bTrial = false;
								msg = "Trial não disponível!";
							}
						}
						else
						{
							structureUserPC.DiasTrial = 0;
							y0PYeBw4b("CL6", Conversions.ToString(structureUserPC.DiasTrial));
							bApp = false;
							bTrial = false;
							msg = "A data do computador foi adulterada!";
						}
					}
					else
					{
						F4wr8yg9m();
						bApp = false;
						bTrial = false;
						msg = "Esta licença não pertence a este computador!";
					}
				}
				else
				{
					bApp = false;
					bTrial = false;
					bAbreRegistro = true;
					msg = "Não existe licença instalada neste computador";
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				Exception ex2 = ex;
				throw new Exception((ErrorStatus)Conversions.ToInteger(((Exception)(object)ex2).Message));
			}
			finally
			{
				cDadosSQLServerLicenca2.fechaConexao();
			}
		}
	}

	public bool RegistraNuvem(string licenca, string email)
	{
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected Obj, but got Unknown
		//IL_0499: Expected Obj, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		int millisecond = DateAndTime.Now.Millisecond;
		DeclaracoesGeral.structureLic lic = new DeclaracoesGeral.structureLic
		{
			Licenca = licenca
		};
		DeclaracoesGeral.structureUser user = default;
		cDadosSQLServerLicenca cDadosSQLServerLicenca2 = new cDadosSQLServerLicenca();
		string left = BuscaChaveLicReg("CL3");
		double num = 26.03;
		string versaoCAD = Geral.CADVersion();
		try
		{
			if (!((Operators.CompareString(left, lic.Licenca, TextCompare: true) == 0) & (Operators.CompareString(lic.Licenca, "", TextCompare: true) != 0)))
			{
				if (!((Operators.CompareString(left, "", TextCompare: true) == 0) & (Operators.CompareString(lic.Licenca, "", TextCompare: true) != 0)))
				{
					if (Operators.CompareString(left, "", TextCompare: true) != 0)
					{
						Interaction.MsgBox("Desinstale a licença atual antes de instalar a nova licença.", MsgBoxStyle.Information);
					}
				}
				else
				{
					MsgBoxResult msgBoxResult = Interaction.MsgBox("Deseja instalar esta licença neste computador?", MsgBoxStyle.YesNo);
					if (msgBoxResult == MsgBoxResult.Yes)
					{
						if (cDadosSQLServerLicenca2.carregaLicenca(ref lic))
						{
							if (lic.Habilitada)
							{
								int num2 = checked((int)Math.Round(DateAndTime.DateValue(Conversions.ToString(DateAndTime.Now.Date)).ToOADate()));
								if (!((lic.DataExpira > 0) & (lic.DataExpira < num2)))
								{
									if (lic.Software == wKizwmZkK)
									{
										if (cDadosSQLServerLicenca2.buscaQuantidadeUsers(lic.ChaveLic) < lic.Quantidade)
										{
											user.ChaveLic = lic.ChaveLic;
											user.Email = email;
											user.versaoCAD = versaoCAD;
											user.versaoSW = num;
											user.IDUnico = millisecond;
											if (!cDadosSQLServerLicenca2.carregaUser(ref user))
											{
												user.UltLogin = num2;
												cDadosSQLServerLicenca2.AdicionaUser(user);
												DeclaracoesGeral.structureUserPC structureUserPC = new DeclaracoesGeral.structureUserPC
												{
													Software = lic.Software,
													Email = user.Email,
													Licenca = lic.Licenca,
													UltLogin = num2,
													DataCriacao = num2,
													DiasTrial = lic.DiasTrial,
													UsoTrial = 0,
													IDUnico = user.IDUnico,
													NomeCliente = lic.NomeCliente,
													CodigoCliente = lic.CodigoCliente,
													Versao = lic.Versao,
													DiaInicialTrial = 0,
													CPUID = CbU9DG8Fi()
												};
												y0PYeBw4b("CL1", Conversions.ToString(structureUserPC.Software));
												y0PYeBw4b("CL2", structureUserPC.Email);
												y0PYeBw4b("CL3", structureUserPC.Licenca);
												y0PYeBw4b("CL4", Conversions.ToString(structureUserPC.UltLogin));
												y0PYeBw4b("CL5", Conversions.ToString(structureUserPC.DataCriacao));
												y0PYeBw4b("CL6", Conversions.ToString(structureUserPC.DiasTrial));
												y0PYeBw4b("CL7", Conversions.ToString(structureUserPC.UsoTrial));
												y0PYeBw4b("CL8", Conversions.ToString(structureUserPC.IDUnico));
												y0PYeBw4b("CL9", structureUserPC.NomeCliente);
												y0PYeBw4b("CL10", Conversions.ToString(structureUserPC.CodigoCliente));
												y0PYeBw4b("CL11", Conversions.ToString(structureUserPC.Versao));
												y0PYeBw4b("CL12", Conversions.ToString(structureUserPC.DiaInicialTrial));
												y0PYeBw4b("CL13", structureUserPC.CPUID);
												MySettingsProperty.Settings.Codigo = "";
												MySettingsProperty.Settings.DCode = "";
												MySettingsProperty.Settings.HCode = "";
												MySettingsProperty.Settings.Cont = -1;
												MySettingsProperty.Settings.Save();
												if (!((structureUserPC.Versao == 0.0) | (num <= structureUserPC.Versao)))
												{
													Interaction.MsgBox("Esta licença foi instalada com sucesso, mas você não possui Contrato de Suporte para usar esta versão!", MsgBoxStyle.Information);
													DeclaracoesGeral.companyHardlock = structureUserPC.NomeCliente;
													result = false;
												}
												else
												{
													Interaction.MsgBox("Esta licença foi instalada com sucesso!", MsgBoxStyle.Information);
													DeclaracoesGeral.companyHardlock = structureUserPC.NomeCliente;
													result = true;
												}
											}
											else
											{
												Interaction.MsgBox("Este email já foi cadastrado e vinculado a uma licença!", MsgBoxStyle.Critical);
											}
										}
										else
										{
											Interaction.MsgBox("Não existe licença disponível!", MsgBoxStyle.Critical);
										}
									}
									else
									{
										Interaction.MsgBox("Esta licença não é deste software!", MsgBoxStyle.Critical);
									}
								}
								else
								{
									Interaction.MsgBox("Esta licença já expirou!", MsgBoxStyle.Critical);
								}
							}
							else
							{
								Interaction.MsgBox("Esta licença está desabilitada!", MsgBoxStyle.Critical);
							}
						}
						else
						{
							Interaction.MsgBox("Esta licença não existe!", MsgBoxStyle.Critical);
						}
					}
				}
			}
			else
			{
				Interaction.MsgBox("Esta licença já foi instalada neste computador!", MsgBoxStyle.Information);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			Exception ex2 = ex;
			throw new Exception((ErrorStatus)Conversions.ToInteger(((Exception)(object)ex2).Message));
		}
		finally
		{
			cDadosSQLServerLicenca2.fechaConexao();
		}
		return result;
	}

	public bool DesregistraNuvem()
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected Obj, but got Unknown
		//IL_0149: Expected Obj, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		DeclaracoesGeral.structureLic lic = default;
		DeclaracoesGeral.structureUser user = default;
		cDadosSQLServerLicenca cDadosSQLServerLicenca2 = new cDadosSQLServerLicenca();
		try
		{
			DeclaracoesGeral.structureUserPC structureUserPC = default;
			string licenca = BuscaChaveLicReg("CL3");
			structureUserPC.Licenca = licenca;
			if (Operators.CompareString(structureUserPC.Licenca.Trim(), "", TextCompare: true) != 0)
			{
				MsgBoxResult msgBoxResult = Interaction.MsgBox("Deseja desinstalar esta licença?", MsgBoxStyle.YesNo);
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					new cProtectNuvem();
					if (Operators.CompareString(structureUserPC.Licenca, "", TextCompare: true) == 0)
					{
						Interaction.MsgBox("Não existe licença instalada neste computador!", MsgBoxStyle.Critical);
					}
					else
					{
						HPKCuHb17(ref structureUserPC);
						lic.Licenca = structureUserPC.Licenca;
						if (cDadosSQLServerLicenca2.carregaLicenca(ref lic))
						{
							user.ChaveLic = lic.ChaveLic;
							user.Email = structureUserPC.Email;
							user.IDUnico = structureUserPC.IDUnico;
							if (cDadosSQLServerLicenca2.carregaUser(ref user) && cDadosSQLServerLicenca2.ApagaUser(user.ChaveUser))
							{
								F4wr8yg9m();
								Interaction.MsgBox("Esta licença foi desinstalada com sucesso!", MsgBoxStyle.Information);
								result = true;
							}
						}
						else
						{
							Interaction.MsgBox("Esta licença não existe!", MsgBoxStyle.Critical);
							F4wr8yg9m();
						}
					}
				}
			}
			else
			{
				Interaction.MsgBox("Não existe licença instalada neste computador", MsgBoxStyle.Information);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			Exception ex2 = ex;
			throw new Exception((ErrorStatus)Conversions.ToInteger(((Exception)(object)ex2).Message));
		}
		finally
		{
			cDadosSQLServerLicenca2.fechaConexao();
		}
		return result;
	}

	public bool DesregistraNuvemAut()
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_00f2: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		DeclaracoesGeral.structureLic lic = default;
		DeclaracoesGeral.structureUser user = default;
		cDadosSQLServerLicenca cDadosSQLServerLicenca2 = new cDadosSQLServerLicenca();
		try
		{
			DeclaracoesGeral.structureUserPC structureUserPC = default;
			string licenca = BuscaChaveLicReg("CL3");
			structureUserPC.Licenca = licenca;
			if (Operators.CompareString(structureUserPC.Licenca.Trim(), "", TextCompare: true) != 0)
			{
				new cProtectNuvem();
				if (Operators.CompareString(structureUserPC.Licenca, "", TextCompare: true) != 0)
				{
					HPKCuHb17(ref structureUserPC);
					lic.Licenca = structureUserPC.Licenca;
					if (cDadosSQLServerLicenca2.carregaLicenca(ref lic))
					{
						user.ChaveLic = lic.ChaveLic;
						user.Email = structureUserPC.Email;
						user.IDUnico = structureUserPC.IDUnico;
						if (cDadosSQLServerLicenca2.carregaUser(ref user) && cDadosSQLServerLicenca2.ApagaUser(user.ChaveUser))
						{
							F4wr8yg9m();
							result = true;
						}
					}
					else
					{
						F4wr8yg9m();
						result = true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			Exception ex2 = ex;
			throw new Exception((ErrorStatus)Conversions.ToInteger(((Exception)(object)ex2).Message));
		}
		finally
		{
			cDadosSQLServerLicenca2.fechaConexao();
		}
		return result;
	}

	private bool HPKCuHb17(ref DeclaracoesGeral.structureUserPC P_0)
	{
		bool result = false;
		cProtectNuvem cProtectNuvem2 = new cProtectNuvem();
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\\\W64c\\\\Elk", writable: false);
		if (registryKey != null)
		{
			P_0.Software = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL1", ""))));
			P_0.Email = cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL2", "")));
			P_0.Licenca = Conversions.ToString(registryKey.GetValue("CL3", ""));
			P_0.UltLogin = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL4", ""))));
			P_0.DataCriacao = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL5", ""))));
			P_0.DiasTrial = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL6", ""))));
			P_0.UsoTrial = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL7", ""))));
			P_0.IDUnico = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL8", ""))));
			P_0.NomeCliente = cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL9", "")));
			P_0.CodigoCliente = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL10", ""))));
			P_0.Versao = Conversions.ToDouble(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL11", ""))));
			P_0.DiaInicialTrial = Conversions.ToInteger(cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL12", ""))));
			P_0.CPUID = cProtectNuvem2.DescriptografarDH(Conversions.ToString(registryKey.GetValue("CL13", "")));
			if (Operators.CompareString(P_0.Licenca.Trim(), "", TextCompare: true) != 0)
			{
				result = true;
			}
			registryKey.Close();
		}
		return result;
	}

	private void y0PYeBw4b(string P_0, string P_1)
	{
		cProtectNuvem cProtectNuvem2 = new cProtectNuvem();
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\\\W64c\\\\Elk", writable: true);
		if (registryKey == null)
		{
			registryKey = Registry.CurrentUser.CreateSubKey("Software\\\\W64c\\\\Elk");
		}
		if (registryKey != null)
		{
			if (Operators.CompareString(P_0, "CL3", TextCompare: true) != 0)
			{
				registryKey.SetValue(P_0, cProtectNuvem2.CriptografarDH(P_1));
			}
			else
			{
				registryKey.SetValue("CL3", P_1);
			}
			registryKey.Close();
		}
	}

	public static string BuscaChaveLicReg(string chave)
	{
		string text = "";
		cProtectNuvem cProtectNuvem2 = new cProtectNuvem();
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\\\W64c\\\\Elk", writable: false);
		if (registryKey != null)
		{
			text = Conversions.ToString(registryKey.GetValue(chave, ""));
			if (Operators.CompareString(chave, "CL3", TextCompare: true) != 0)
			{
				text = cProtectNuvem2.DescriptografarDH(text);
			}
			registryKey.Close();
		}
		return text;
	}

	private void F4wr8yg9m()
	{
		Registry.CurrentUser.DeleteSubKey("Software\\\\W64c\\\\Elk", throwOnMissingSubKey: false);
	}

	private string CbU9DG8Fi()
	{
		string text = ".";
		object objectValue = RuntimeHelpers.GetObjectValue(Interaction.GetObject("winmgmts:{impersonationLevel=impersonate}!\\\\" + text + "\\root\\cimv2"));
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "ExecQuery", new object[1] { "Select * from Win32_Processor" }, null, null, null));
		string result = "";
		IEnumerator enumerator = ((IEnumerable)objectValue2).GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(enumerator.Current);
				result = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "ProcessorId", new object[0], null, null, null));
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return result;
	}
}
