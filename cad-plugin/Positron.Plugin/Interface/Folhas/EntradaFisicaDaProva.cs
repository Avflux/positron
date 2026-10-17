using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// O **mouse e o teclado de verdade** da prova da rodada 222: o clique sai por
    /// <c>mouse_event</c> na posição de tela do controle e a digitação por <c>keybd_event</c> —
    /// é o caminho do usuário (o ponteiro e as teclas do Windows), não a chamada do handler.
    /// Só o harness usa, pelos modos <c>POSITRON_FOLHA_ACAO=clique-…</c>.
    /// </summary>
    internal static class EntradaFisicaDaProva
    {
        private const uint RatoEsquerdoAbaixo = 0x0002;
        private const uint RatoEsquerdoAcima = 0x0004;
        private const uint TeclaLiberada = 0x0002;
        private const byte TeclaShift = 0x10;
        private const byte TeclaEnter = 0x0D;
        private const uint Raiz = 2;

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint bandeiras, uint dx, uint dy, uint dados, UIntPtr extra);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte tecla, byte varredura, uint bandeiras, UIntPtr extra);

        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr janela, uint bandeiras);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr janela);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr janela, StringBuilder texto, int maximo);

        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char caractere);

        /// <summary>O título da janela em foco — o que o clique físico vai acordar (para o log).</summary>
        internal static string Foco()
        {
            StringBuilder texto = new StringBuilder(256);
            GetWindowText(GetForegroundWindow(), texto, 256);
            return texto.ToString();
        }

        /// <summary>Ativa a janela do controle, põe o cursor no centro dele e clica (1 ou 2 vezes).</summary>
        internal static Point Clicar(Control alvo, int vezes)
        {
            return ClicarEm(alvo.PointToScreen(new Point(alvo.Width / 2, alvo.Height / 2)), vezes, alvo);
        }

        /// <summary>O clique num ponto de tela; <paramref name="alvo"/> é só para ativar a janela antes.</summary>
        internal static Point ClicarEm(Point ponto, int vezes, Control alvo)
        {
            if (alvo != null)
            {
                IntPtr topo = GetAncestor(alvo.Handle, Raiz);
                if (topo != IntPtr.Zero)
                {
                    SetForegroundWindow(topo);
                }
            }

            System.Threading.Thread.Sleep(250);
            SetCursorPos(ponto.X, ponto.Y);
            System.Threading.Thread.Sleep(150);
            if (alvo != null && GetForegroundWindow() != GetAncestor(alvo.Handle, Raiz))
            {
                // Sem o foco, o primeiro clique só acorda a janela (e o Windows o engole): um
                // clique de aquecimento antes do clique que vale. Medido na rodada 222 — sem ele
                // o lb1 às vezes não navegava (o clique sumia na ativação da janela).
                mouse_event(RatoEsquerdoAbaixo, 0, 0, 0, UIntPtr.Zero);
                System.Threading.Thread.Sleep(40);
                mouse_event(RatoEsquerdoAcima, 0, 0, 0, UIntPtr.Zero);
                System.Threading.Thread.Sleep(400);
            }

            for (int i = 0; i < vezes; i++)
            {
                mouse_event(RatoEsquerdoAbaixo, 0, 0, 0, UIntPtr.Zero);
                System.Threading.Thread.Sleep(40);
                mouse_event(RatoEsquerdoAcima, 0, 0, 0, UIntPtr.Zero);
                System.Threading.Thread.Sleep(90);
            }

            return ponto;
        }

        /// <summary>
        /// Digita o texto como o usuário (Shift quando o caractere pede) e, quando
        /// <paramref name="enter"/>, confirma com Enter. As mensagens vão para a fila do Windows:
        /// o controle as processa quando este tick devolver o thread ao laço da interface.
        /// </summary>
        internal static string Digitar(string texto, bool enter)
        {
            foreach (char caractere in texto)
            {
                short mapa = VkKeyScan(caractere);
                if (mapa == -1)
                {
                    return "caractere sem tecla: '" + caractere + "'";
                }

                byte tecla = (byte)(mapa & 0xFF);
                bool shift = (mapa & 0x100) != 0;
                if (shift)
                {
                    keybd_event(TeclaShift, 0, 0, UIntPtr.Zero);
                }

                keybd_event(tecla, 0, 0, UIntPtr.Zero);
                keybd_event(tecla, 0, TeclaLiberada, UIntPtr.Zero);
                if (shift)
                {
                    keybd_event(TeclaShift, 0, TeclaLiberada, UIntPtr.Zero);
                }

                System.Threading.Thread.Sleep(40);
            }

            if (enter)
            {
                keybd_event(TeclaEnter, 0, 0, UIntPtr.Zero);
                keybd_event(TeclaEnter, 0, TeclaLiberada, UIntPtr.Zero);
            }

            return null;
        }
    }
}
