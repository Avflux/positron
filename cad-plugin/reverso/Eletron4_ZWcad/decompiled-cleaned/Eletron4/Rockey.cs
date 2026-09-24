using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace Eletron4;

public class Rockey
{
	public class Rockey432
	{
		private ushort WVop58ewnqJ;

		private ushort QQYp5NXUJmT;

		private ushort rCgp5FCSn1P;

		private ushort LFSp5Q1aTnn;

		private ushort W6mp5Piqwg9;

		private uint JnLp5cCPH2f;

		private uint ktCp5KScdVl;

		[DllImport("RYDLL32.dll", EntryPoint = "Rockey")]
		private static extern short wlgp5a4KmJc(short P_0, ref ushort P_1, ref uint P_2, ref uint P_3, ref ushort P_4, ref ushort P_5, ref ushort P_6, ref ushort P_7, ref byte P_8);

		public void AbreModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			QQYp5NXUJmT = Convert.ToUInt16(15891);
			rCgp5FCSn1P = Convert.ToUInt16(61950);
			LFSp5Q1aTnn = Convert.ToUInt16(0);
			W6mp5Piqwg9 = Convert.ToUInt16(0);
			short num = wlgp5a4KmJc(1, ref WVop58ewnqJ, ref JnLp5cCPH2f, ref ktCp5KScdVl, ref QQYp5NXUJmT, ref rCgp5FCSn1P, ref LFSp5Q1aTnn, ref W6mp5Piqwg9, ref array[0]);
			if (!((num != 0) | ((long)JnLp5cCPH2f == 0L)))
			{
				hl.ID = JnLp5cCPH2f;
				QQYp5NXUJmT = Convert.ToUInt16(15891);
				rCgp5FCSn1P = Convert.ToUInt16(61950);
				LFSp5Q1aTnn = Convert.ToUInt16(0);
				W6mp5Piqwg9 = Convert.ToUInt16(0);
				if (wlgp5a4KmJc(3, ref WVop58ewnqJ, ref JnLp5cCPH2f, ref ktCp5KScdVl, ref QQYp5NXUJmT, ref rCgp5FCSn1P, ref LFSp5Q1aTnn, ref W6mp5Piqwg9, ref array[0]) == 0)
				{
					hl.handle = WVop58ewnqJ;
					if ((long)ktCp5KScdVl != 6L)
					{
						QQYp5NXUJmT = 3;
						if (wlgp5a4KmJc(12, ref WVop58ewnqJ, ref JnLp5cCPH2f, ref ktCp5KScdVl, ref QQYp5NXUJmT, ref rCgp5FCSn1P, ref LFSp5Q1aTnn, ref W6mp5Piqwg9, ref array[0]) == 0)
						{
							if (rCgp5FCSn1P != 1)
							{
								hl.erro = 2;
								hl.existe = false;
								return;
							}
							hl.company = "?";
							if (wlgp5a4KmJc(10, ref WVop58ewnqJ, ref JnLp5cCPH2f, ref ktCp5KScdVl, ref QQYp5NXUJmT, ref rCgp5FCSn1P, ref LFSp5Q1aTnn, ref W6mp5Piqwg9, ref array[0]) == 0)
							{
								int indice = checked((int)JnLp5cCPH2f);
								hl.company = Geral.leCompany(indice);
								hl.tipo = 1;
								hl.existe = true;
							}
							else
							{
								hl.erro = 1;
								hl.existe = false;
							}
						}
						else
						{
							hl.erro = 1;
							hl.existe = false;
						}
					}
					else
					{
						hl.erro = 1;
						hl.existe = false;
					}
				}
				else
				{
					hl.erro = 1;
					hl.existe = false;
				}
			}
			else
			{
				hl.erro = 1;
				hl.existe = false;
			}
		}

		public bool checaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			QQYp5NXUJmT = Convert.ToUInt16(15891);
			rCgp5FCSn1P = Convert.ToUInt16(61950);
			LFSp5Q1aTnn = Convert.ToUInt16(0);
			W6mp5Piqwg9 = Convert.ToUInt16(0);
			wlgp5a4KmJc(1, ref WVop58ewnqJ, ref JnLp5cCPH2f, ref ktCp5KScdVl, ref QQYp5NXUJmT, ref rCgp5FCSn1P, ref LFSp5Q1aTnn, ref W6mp5Piqwg9, ref array[0]);
			if (!((JnLp5cCPH2f == hl.ID) & ((long)JnLp5cCPH2f > 0L)))
			{
				return false;
			}
			return true;
		}

		public void fechaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			WVop58ewnqJ = hl.handle;
			short num = wlgp5a4KmJc(4, ref WVop58ewnqJ, ref JnLp5cCPH2f, ref ktCp5KScdVl, ref QQYp5NXUJmT, ref rCgp5FCSn1P, ref LFSp5Q1aTnn, ref W6mp5Piqwg9, ref array[0]);
			if (num != 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 54]), MsgBoxStyle.Information);
			}
		}
	}

	public class Rockey4ND32
	{
		private ushort NjCp52weHPD;

		private ushort pcep53JMNAp;

		private ushort Fxqp5nMs7De;

		private ushort p4cp51Co4nL;

		private ushort oINp5lIIy0d;

		private uint CxHp55ui7w1;

		private uint C6ep50XKa0T;

		[DllImport("Rockey4ND.dll", EntryPoint = "Rockey")]
		private static extern short Sd3p5eR4nBw(short P_0, ref ushort P_1, ref uint P_2, ref uint P_3, ref ushort P_4, ref ushort P_5, ref ushort P_6, ref ushort P_7, ref byte P_8);

		public void AbreModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			pcep53JMNAp = Convert.ToUInt16(15891);
			Fxqp5nMs7De = Convert.ToUInt16(61950);
			p4cp51Co4nL = Convert.ToUInt16(0);
			oINp5lIIy0d = Convert.ToUInt16(0);
			short num = Sd3p5eR4nBw(1, ref NjCp52weHPD, ref CxHp55ui7w1, ref C6ep50XKa0T, ref pcep53JMNAp, ref Fxqp5nMs7De, ref p4cp51Co4nL, ref oINp5lIIy0d, ref array[0]);
			if (!((num != 0) | ((long)CxHp55ui7w1 == 0L)))
			{
				hl.ID = CxHp55ui7w1;
				pcep53JMNAp = Convert.ToUInt16(15891);
				Fxqp5nMs7De = Convert.ToUInt16(61950);
				p4cp51Co4nL = Convert.ToUInt16(0);
				oINp5lIIy0d = Convert.ToUInt16(0);
				if (Sd3p5eR4nBw(3, ref NjCp52weHPD, ref CxHp55ui7w1, ref C6ep50XKa0T, ref pcep53JMNAp, ref Fxqp5nMs7De, ref p4cp51Co4nL, ref oINp5lIIy0d, ref array[0]) == 0)
				{
					hl.handle = NjCp52weHPD;
					if ((long)C6ep50XKa0T != 10L)
					{
						pcep53JMNAp = 3;
						if (Sd3p5eR4nBw(12, ref NjCp52weHPD, ref CxHp55ui7w1, ref C6ep50XKa0T, ref pcep53JMNAp, ref Fxqp5nMs7De, ref p4cp51Co4nL, ref oINp5lIIy0d, ref array[0]) == 0)
						{
							if (Fxqp5nMs7De != 1)
							{
								hl.erro = 2;
								hl.existe = false;
								return;
							}
							hl.company = "?";
							if (Sd3p5eR4nBw(10, ref NjCp52weHPD, ref CxHp55ui7w1, ref C6ep50XKa0T, ref pcep53JMNAp, ref Fxqp5nMs7De, ref p4cp51Co4nL, ref oINp5lIIy0d, ref array[0]) == 0)
							{
								int indice = checked((int)CxHp55ui7w1);
								hl.company = Geral.leCompany(indice);
								hl.tipo = 5;
								hl.existe = true;
							}
							else
							{
								hl.erro = 1;
								hl.existe = false;
							}
						}
						else
						{
							hl.erro = 1;
							hl.existe = false;
						}
					}
					else
					{
						hl.erro = 1;
						hl.existe = false;
					}
				}
				else
				{
					hl.erro = 1;
					hl.existe = false;
				}
			}
			else
			{
				hl.erro = 1;
				hl.existe = false;
			}
		}

		public bool checaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			pcep53JMNAp = Convert.ToUInt16(15891);
			Fxqp5nMs7De = Convert.ToUInt16(61950);
			p4cp51Co4nL = Convert.ToUInt16(0);
			oINp5lIIy0d = Convert.ToUInt16(0);
			Sd3p5eR4nBw(1, ref NjCp52weHPD, ref CxHp55ui7w1, ref C6ep50XKa0T, ref pcep53JMNAp, ref Fxqp5nMs7De, ref p4cp51Co4nL, ref oINp5lIIy0d, ref array[0]);
			if (!((CxHp55ui7w1 == hl.ID) & ((long)CxHp55ui7w1 > 0L)))
			{
				return false;
			}
			return true;
		}

		public void fechaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
		}
	}

	public class Rockey464
	{
		private ushort lBBp5mnCCKg;

		private ushort Je2p5X3OH9L;

		private ushort BZgp5U6yEAv;

		private ushort tErp5yRpcQq;

		private ushort bJ5p5g1Le3U;

		private uint QNAp5AiloJl;

		private uint oEtp5sB0MAG;

		[DllImport("RYDLL64.dll", EntryPoint = "Rockey")]
		private static extern short O7Np5Re3cjl(short P_0, ref ushort P_1, ref uint P_2, ref uint P_3, ref ushort P_4, ref ushort P_5, ref ushort P_6, ref ushort P_7, ref byte P_8);

		public void AbreModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			Je2p5X3OH9L = Convert.ToUInt16(15891);
			BZgp5U6yEAv = Convert.ToUInt16(61950);
			tErp5yRpcQq = Convert.ToUInt16(0);
			bJ5p5g1Le3U = Convert.ToUInt16(0);
			short num = O7Np5Re3cjl(1, ref lBBp5mnCCKg, ref QNAp5AiloJl, ref oEtp5sB0MAG, ref Je2p5X3OH9L, ref BZgp5U6yEAv, ref tErp5yRpcQq, ref bJ5p5g1Le3U, ref array[0]);
			if (!((num != 0) | ((long)QNAp5AiloJl == 0L)))
			{
				hl.ID = QNAp5AiloJl;
				Je2p5X3OH9L = Convert.ToUInt16(15891);
				BZgp5U6yEAv = Convert.ToUInt16(61950);
				tErp5yRpcQq = Convert.ToUInt16(0);
				bJ5p5g1Le3U = Convert.ToUInt16(0);
				if (O7Np5Re3cjl(3, ref lBBp5mnCCKg, ref QNAp5AiloJl, ref oEtp5sB0MAG, ref Je2p5X3OH9L, ref BZgp5U6yEAv, ref tErp5yRpcQq, ref bJ5p5g1Le3U, ref array[0]) == 0)
				{
					hl.handle = lBBp5mnCCKg;
					if ((long)oEtp5sB0MAG != 6L)
					{
						Je2p5X3OH9L = 3;
						if (O7Np5Re3cjl(12, ref lBBp5mnCCKg, ref QNAp5AiloJl, ref oEtp5sB0MAG, ref Je2p5X3OH9L, ref BZgp5U6yEAv, ref tErp5yRpcQq, ref bJ5p5g1Le3U, ref array[0]) == 0)
						{
							if (BZgp5U6yEAv != 1)
							{
								hl.erro = 2;
								hl.existe = false;
								return;
							}
							hl.company = "?";
							if (O7Np5Re3cjl(10, ref lBBp5mnCCKg, ref QNAp5AiloJl, ref oEtp5sB0MAG, ref Je2p5X3OH9L, ref BZgp5U6yEAv, ref tErp5yRpcQq, ref bJ5p5g1Le3U, ref array[0]) == 0)
							{
								int indice = checked((int)QNAp5AiloJl);
								hl.company = Geral.leCompany(indice);
								hl.tipo = 2;
								hl.existe = true;
							}
							else
							{
								hl.erro = 1;
								hl.existe = false;
							}
						}
						else
						{
							hl.erro = 1;
							hl.existe = false;
						}
					}
					else
					{
						hl.erro = 1;
						hl.existe = false;
					}
				}
				else
				{
					hl.erro = 1;
					hl.existe = false;
				}
			}
			else
			{
				hl.erro = 1;
				hl.existe = false;
			}
		}

		public bool checaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			Je2p5X3OH9L = Convert.ToUInt16(15891);
			BZgp5U6yEAv = Convert.ToUInt16(61950);
			tErp5yRpcQq = Convert.ToUInt16(0);
			bJ5p5g1Le3U = Convert.ToUInt16(0);
			O7Np5Re3cjl(1, ref lBBp5mnCCKg, ref QNAp5AiloJl, ref oEtp5sB0MAG, ref Je2p5X3OH9L, ref BZgp5U6yEAv, ref tErp5yRpcQq, ref bJ5p5g1Le3U, ref array[0]);
			if (!((QNAp5AiloJl == hl.ID) & ((long)QNAp5AiloJl > 0L)))
			{
				return false;
			}
			return true;
		}

		public void fechaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			lBBp5mnCCKg = hl.handle;
			short num = O7Np5Re3cjl(4, ref lBBp5mnCCKg, ref QNAp5AiloJl, ref oEtp5sB0MAG, ref Je2p5X3OH9L, ref BZgp5U6yEAv, ref tErp5yRpcQq, ref bJ5p5g1Le3U, ref array[0]);
			if (num != 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 54]), MsgBoxStyle.Information);
			}
		}
	}

	public class Rockey4ND64
	{
		private ushort Yfgp5VhwOqJ;

		private ushort mq4p5uBK4fS;

		private ushort R5Pp5EqTUu9;

		private ushort feJp5ZpM12X;

		private ushort A1Fp5iSkbhb;

		private uint b0Dp5SfbsJZ;

		private uint cYcp540a3uv;

		[DllImport("Rockey4ND_X64.dll", EntryPoint = "Rockey")]
		private static extern short IFvp5BNArDI(short P_0, ref ushort P_1, ref uint P_2, ref uint P_3, ref ushort P_4, ref ushort P_5, ref ushort P_6, ref ushort P_7, ref byte P_8);

		public void AbreModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			mq4p5uBK4fS = Convert.ToUInt16(15891);
			R5Pp5EqTUu9 = Convert.ToUInt16(61950);
			feJp5ZpM12X = Convert.ToUInt16(0);
			A1Fp5iSkbhb = Convert.ToUInt16(0);
			short num = IFvp5BNArDI(1, ref Yfgp5VhwOqJ, ref b0Dp5SfbsJZ, ref cYcp540a3uv, ref mq4p5uBK4fS, ref R5Pp5EqTUu9, ref feJp5ZpM12X, ref A1Fp5iSkbhb, ref array[0]);
			if (!((num != 0) | ((long)b0Dp5SfbsJZ == 0L)))
			{
				hl.ID = b0Dp5SfbsJZ;
				mq4p5uBK4fS = Convert.ToUInt16(15891);
				R5Pp5EqTUu9 = Convert.ToUInt16(61950);
				feJp5ZpM12X = Convert.ToUInt16(0);
				A1Fp5iSkbhb = Convert.ToUInt16(0);
				if (IFvp5BNArDI(3, ref Yfgp5VhwOqJ, ref b0Dp5SfbsJZ, ref cYcp540a3uv, ref mq4p5uBK4fS, ref R5Pp5EqTUu9, ref feJp5ZpM12X, ref A1Fp5iSkbhb, ref array[0]) == 0)
				{
					hl.handle = Yfgp5VhwOqJ;
					if ((long)cYcp540a3uv != 10L)
					{
						mq4p5uBK4fS = 3;
						if (IFvp5BNArDI(12, ref Yfgp5VhwOqJ, ref b0Dp5SfbsJZ, ref cYcp540a3uv, ref mq4p5uBK4fS, ref R5Pp5EqTUu9, ref feJp5ZpM12X, ref A1Fp5iSkbhb, ref array[0]) == 0)
						{
							if (R5Pp5EqTUu9 != 1)
							{
								hl.erro = 2;
								hl.existe = false;
								return;
							}
							hl.company = "?";
							if (IFvp5BNArDI(10, ref Yfgp5VhwOqJ, ref b0Dp5SfbsJZ, ref cYcp540a3uv, ref mq4p5uBK4fS, ref R5Pp5EqTUu9, ref feJp5ZpM12X, ref A1Fp5iSkbhb, ref array[0]) == 0)
							{
								int indice = checked((int)b0Dp5SfbsJZ);
								hl.company = Geral.leCompany(indice);
								hl.tipo = 6;
								hl.existe = true;
							}
							else
							{
								hl.erro = 1;
								hl.existe = false;
							}
						}
						else
						{
							hl.erro = 1;
							hl.existe = false;
						}
					}
					else
					{
						hl.erro = 1;
						hl.existe = false;
					}
				}
				else
				{
					hl.erro = 1;
					hl.existe = false;
				}
			}
			else
			{
				hl.erro = 1;
				hl.existe = false;
			}
		}

		public bool checaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			mq4p5uBK4fS = Convert.ToUInt16(15891);
			R5Pp5EqTUu9 = Convert.ToUInt16(61950);
			feJp5ZpM12X = Convert.ToUInt16(0);
			A1Fp5iSkbhb = Convert.ToUInt16(0);
			IFvp5BNArDI(1, ref Yfgp5VhwOqJ, ref b0Dp5SfbsJZ, ref cYcp540a3uv, ref mq4p5uBK4fS, ref R5Pp5EqTUu9, ref feJp5ZpM12X, ref A1Fp5iSkbhb, ref array[0]);
			if (!((b0Dp5SfbsJZ == hl.ID) & ((long)b0Dp5SfbsJZ > 0L)))
			{
				return false;
			}
			return true;
		}

		public void fechaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
		}
	}

	public class NetRockey432
	{
		private ushort FFsp5rJWrhR;

		private ushort GdYp59K4ZBW;

		private ushort b7lp5zYJJYx;

		private ushort v2Fp0WfJg3y;

		private ushort B9Zp0pSCLyD;

		private uint leqp0TK7EaF;

		private uint GhAp0J5X0lu;

		[DllImport("NrClient.dll", EntryPoint = "NetRockey")]
		private static extern short URgp5C7cJsB(short P_0, ref ushort P_1, ref uint P_2, ref uint P_3, ref ushort P_4, ref ushort P_5, ref ushort P_6, ref ushort P_7, ref byte P_8);

		[DllImport("NrClient.dll", EntryPoint = "SetIniPathName")]
		private static extern long iPLp5YYZDgB(string P_0);

		public void AbreModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
			folderPath += "\\clicfg.ini";
			iPLp5YYZDgB(folderPath);
			byte[] array = new byte[1025];
			GdYp59K4ZBW = Convert.ToUInt16(15891);
			b7lp5zYJJYx = Convert.ToUInt16(61950);
			v2Fp0WfJg3y = Convert.ToUInt16(0);
			B9Zp0pSCLyD = Convert.ToUInt16(0);
			short num = URgp5C7cJsB(1, ref FFsp5rJWrhR, ref leqp0TK7EaF, ref GhAp0J5X0lu, ref GdYp59K4ZBW, ref b7lp5zYJJYx, ref v2Fp0WfJg3y, ref B9Zp0pSCLyD, ref array[0]);
			if (!((num != 0) | ((long)leqp0TK7EaF == 0L)))
			{
				hl.ID = leqp0TK7EaF;
				GdYp59K4ZBW = Convert.ToUInt16(15891);
				b7lp5zYJJYx = Convert.ToUInt16(61950);
				v2Fp0WfJg3y = Convert.ToUInt16(0);
				B9Zp0pSCLyD = Convert.ToUInt16(0);
				GhAp0J5X0lu = Convert.ToUInt32(65539);
				if (URgp5C7cJsB(3, ref FFsp5rJWrhR, ref leqp0TK7EaF, ref GhAp0J5X0lu, ref GdYp59K4ZBW, ref b7lp5zYJJYx, ref v2Fp0WfJg3y, ref B9Zp0pSCLyD, ref array[0]) == 0)
				{
					hl.handle = FFsp5rJWrhR;
					hl.company = "?";
					if (URgp5C7cJsB(10, ref FFsp5rJWrhR, ref leqp0TK7EaF, ref GhAp0J5X0lu, ref GdYp59K4ZBW, ref b7lp5zYJJYx, ref v2Fp0WfJg3y, ref B9Zp0pSCLyD, ref array[0]) == 0)
					{
						int indice = checked((int)leqp0TK7EaF);
						hl.company = Geral.leCompany(indice);
						hl.tipo = 3;
						hl.existe = true;
					}
					else
					{
						hl.erro = 1;
						hl.existe = false;
					}
				}
				else
				{
					hl.erro = 2;
					hl.existe = false;
				}
			}
			else
			{
				hl.erro = 1;
				hl.existe = false;
			}
		}

		public void fechaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			FFsp5rJWrhR = hl.handle;
			short num = URgp5C7cJsB(4, ref FFsp5rJWrhR, ref leqp0TK7EaF, ref GhAp0J5X0lu, ref GdYp59K4ZBW, ref b7lp5zYJJYx, ref v2Fp0WfJg3y, ref B9Zp0pSCLyD, ref array[0]);
			if (num != 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 54]), MsgBoxStyle.Information);
			}
		}

		public bool checaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
			folderPath += "\\clicfg.ini";
			iPLp5YYZDgB(folderPath);
			byte[] array = new byte[1025];
			GdYp59K4ZBW = Convert.ToUInt16(15891);
			b7lp5zYJJYx = Convert.ToUInt16(61950);
			v2Fp0WfJg3y = Convert.ToUInt16(0);
			B9Zp0pSCLyD = Convert.ToUInt16(0);
			URgp5C7cJsB(1, ref FFsp5rJWrhR, ref leqp0TK7EaF, ref GhAp0J5X0lu, ref GdYp59K4ZBW, ref b7lp5zYJJYx, ref v2Fp0WfJg3y, ref B9Zp0pSCLyD, ref array[0]);
			if (!((leqp0TK7EaF == hl.ID) & ((long)leqp0TK7EaF > 0L)))
			{
				return false;
			}
			return true;
		}
	}

	public class NetRockey464
	{
		private ushort HWvp0G9QYLw;

		private ushort W3jp0Hry08t;

		private ushort H7Op0kFTsnw;

		private ushort H5fp0dhDdBa;

		private ushort sR5p0fHReig;

		private uint xljp0DepbEt;

		private uint S8vp0vMu7o7;

		[DllImport("NrClient_X64.dll", EntryPoint = "NetRockey")]
		private static extern short WYHp0hIGceD(short P_0, ref ushort P_1, ref uint P_2, ref uint P_3, ref ushort P_4, ref ushort P_5, ref ushort P_6, ref ushort P_7, ref byte P_8);

		[DllImport("NrClient_X64.dll", EntryPoint = "SetIniPathName")]
		private static extern long adxp0oZr4Tr(string P_0);

		public void AbreModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
			folderPath += "\\clicfg.ini";
			adxp0oZr4Tr(folderPath);
			byte[] array = new byte[1025];
			W3jp0Hry08t = Convert.ToUInt16(15891);
			H7Op0kFTsnw = Convert.ToUInt16(61950);
			H5fp0dhDdBa = Convert.ToUInt16(0);
			sR5p0fHReig = Convert.ToUInt16(0);
			short num = WYHp0hIGceD(1, ref HWvp0G9QYLw, ref xljp0DepbEt, ref S8vp0vMu7o7, ref W3jp0Hry08t, ref H7Op0kFTsnw, ref H5fp0dhDdBa, ref sR5p0fHReig, ref array[0]);
			if (!((num != 0) | ((long)xljp0DepbEt == 0L)))
			{
				hl.ID = xljp0DepbEt;
				W3jp0Hry08t = Convert.ToUInt16(15891);
				H7Op0kFTsnw = Convert.ToUInt16(61950);
				H5fp0dhDdBa = Convert.ToUInt16(0);
				sR5p0fHReig = Convert.ToUInt16(0);
				S8vp0vMu7o7 = Convert.ToUInt32(65539);
				if (WYHp0hIGceD(3, ref HWvp0G9QYLw, ref xljp0DepbEt, ref S8vp0vMu7o7, ref W3jp0Hry08t, ref H7Op0kFTsnw, ref H5fp0dhDdBa, ref sR5p0fHReig, ref array[0]) == 0)
				{
					hl.handle = HWvp0G9QYLw;
					hl.company = "?";
					if (WYHp0hIGceD(10, ref HWvp0G9QYLw, ref xljp0DepbEt, ref S8vp0vMu7o7, ref W3jp0Hry08t, ref H7Op0kFTsnw, ref H5fp0dhDdBa, ref sR5p0fHReig, ref array[0]) == 0)
					{
						int indice = checked((int)xljp0DepbEt);
						hl.company = Geral.leCompany(indice);
						hl.tipo = 4;
						hl.existe = true;
					}
					else
					{
						hl.erro = 1;
						hl.existe = false;
					}
				}
				else
				{
					hl.erro = 2;
					hl.existe = false;
				}
			}
			else
			{
				hl.erro = 1;
				hl.existe = false;
			}
		}

		public void fechaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			byte[] array = new byte[1025];
			HWvp0G9QYLw = hl.handle;
			short num = WYHp0hIGceD(4, ref HWvp0G9QYLw, ref xljp0DepbEt, ref S8vp0vMu7o7, ref W3jp0Hry08t, ref H7Op0kFTsnw, ref H5fp0dhDdBa, ref sR5p0fHReig, ref array[0]);
			if (num != 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 54]), MsgBoxStyle.Information);
			}
		}

		public bool checaModulo3(ref DeclaracoesGeral.Hardlock hl)
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
			folderPath += "\\clicfg.ini";
			adxp0oZr4Tr(folderPath);
			byte[] array = new byte[1025];
			W3jp0Hry08t = Convert.ToUInt16(15891);
			H7Op0kFTsnw = Convert.ToUInt16(61950);
			H5fp0dhDdBa = Convert.ToUInt16(0);
			sR5p0fHReig = Convert.ToUInt16(0);
			WYHp0hIGceD(1, ref HWvp0G9QYLw, ref xljp0DepbEt, ref S8vp0vMu7o7, ref W3jp0Hry08t, ref H7Op0kFTsnw, ref H5fp0dhDdBa, ref sR5p0fHReig, ref array[0]);
			if (!((xljp0DepbEt == hl.ID) & ((long)xljp0DepbEt > 0L)))
			{
				return false;
			}
			return true;
		}
	}
}
