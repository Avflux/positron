using System;

namespace Positron.Data
{
    /// <summary>
    /// Os valores do <c>uscPaginas.ProgressBarColor</c> do original (<c>uscPaginas.cs:21-26</c>):
    /// <c>Green = 1</c>, <c>Red</c>, <c>Yellow</c>. O nome diz "cor", mas o que o original manda é a
    /// **mensagem 1040** — o <c>PBM_SETSTATE</c>, com os estados <c>PBST_NORMAL</c> (1),
    /// <c>PBST_ERROR</c> (2) e <c>PBST_PAUSED</c> (3). É por isso que a barra fica **vermelha**: o
    /// <c>pbIniciar</c> põe o estado de erro.
    /// </summary>
    public enum CorDaBarra
    {
        /// <summary><c>ProgressBarColor.Green</c> = <c>PBST_NORMAL</c>.</summary>
        Verde = 1,

        /// <summary><c>ProgressBarColor.Red</c> = <c>PBST_ERROR</c> — o estado que o <c>pbIniciar</c> põe.</summary>
        Vermelho = 2,

        /// <summary><c>ProgressBarColor.Yellow</c> = <c>PBST_PAUSED</c>.</summary>
        Amarelo = 3,
    }

    /// <summary>
    /// O <c>ProgressBar1</c> da paleta de páginas com o <c>pbIniciar</c>/<c>pbPasso</c>/<c>pbFim</c>
    /// do <c>uscPaginas</c> (<c>uscPaginas.cs:1242-1269</c>) — a barra **compartilhada** que as
    /// rotinas longas do produto dirigem por <c>DeclaracoesGeral._uscPagina</c>
    /// (<c>DeclaracoesGeral.cs:556</c>; ~92 arquivos chamam o par).
    ///
    /// O original não tem um tipo para isso: o estado *é* o do controle do WinForms. Aqui o estado é
    /// uma regra pura (medível sem CAD) e a paleta o **espelha** no <c>ProgressBar</c> que o usuário vê
    /// (o `FolhasControle` do plugin é o espelho; este projeto não enxerga o plugin).
    ///
    /// O que o original faz, linha a linha:
    /// <list type="bullet">
    /// <item><c>pbIniciar()</c> (<c>:1247-1257</c>): <c>Minimum = 0</c>; se <c>Quantidade &lt; 0</c>
    /// então <c>Quantidade = 0</c>; <c>Maximum = Quantidade</c>; <c>Step = 1</c>; e o
    /// <c>SendMessage(Handle, 1040, Red, 0)</c> (<c>:1242-1245</c>). **Não** zera o <c>Value</c>: o
    /// valor que sobrou da rodada anterior fica (quando o novo <c>Maximum</c> é menor, o controle o
    /// corta).</item>
    /// <item><c>pbPasso(int iPasso = 1)</c> (<c>:1259-1262</c>): <c>Increment(iPasso)</c> — o valor
    /// anda 1 (ou <paramref name="iPasso"/>) e para no <c>Maximum</c>.</item>
    /// <item><c>pbFim()</c> (<c>:1264-1269</c>): <c>Value = 0</c>, <c>Minimum = 0</c>,
    /// <c>Maximum = 0</c> — o <c>Step</c> e a cor ficam como estavam.</item>
    /// </list>
    /// O designer não muda os padrões do <c>ProgressBar</c> (<c>uscPaginas.cs:1203-1208</c>: só
    /// posição, tamanho, âncora e <c>ForeColor</c> transparente), então a barra **nasce** com os
    /// padrões do WinForms: 0..100, passo 10, valor 0 — e o <c>CorDaBarra.Verde</c> (o
    /// <c>PBST_NORMAL</c> de fábrica). Isso importa: um <c>pbPasso()</c> antes do primeiro
    /// <c>pbIniciar()</c> — o do <c>clsTextos.ExportaPaginas</c>, <c>clsTextos.cs:1064</c> — anda a
    /// barra no host em que ela ainda está em 0..100.
    /// </summary>
    public sealed class ProgressoCompartilhado
    {
        /// <summary>
        /// O aviso do original a cada chamada: quem escuta é a paleta, que leva o estado para o
        /// <c>ProgressBar</c> (e o harness, que lê os valores do controle).
        /// </summary>
        public event EventHandler Mudou;

        /// <summary>O <c>Quantidade</c> do original (<c>uscPaginas.cs:196</c>): quem chama a define **antes** do <c>pbIniciar</c>.</summary>
        public int Quantidade { get; set; }

        /// <summary>O <c>ProgressBar.Minimum</c> do controle.</summary>
        public int Minimo { get; private set; }

        /// <summary>O <c>ProgressBar.Maximum</c> do controle — nasce em 100, o padrão do WinForms.</summary>
        public int Maximo { get; private set; } = 100;

        /// <summary>O <c>ProgressBar.Step</c> do controle — nasce em 10, o padrão do WinForms.</summary>
        public int Incremento { get; private set; } = 10;

        /// <summary>O <c>ProgressBar.Value</c> do controle.</summary>
        public int Valor { get; private set; }

        /// <summary>O estado de pintura da barra (o <c>PBM_SETSTATE</c>): nasce <c>Verde</c>, como o controle.</summary>
        public CorDaBarra Cor { get; private set; } = CorDaBarra.Verde;

        /// <summary>A mensagem do <c>SendMessage</c> do original: <c>PBM_SETSTATE</c> (0x400 + 16).</summary>
        public const int MensagemDeEstado = 1040;

        /// <summary>
        /// O <c>pbIniciar</c>: fixa o tamanho da barra pela <see cref="Quantidade"/> e a pinta de
        /// vermelho. O valor corrente **não** é zerado (o original também não zera).
        /// </summary>
        public void Iniciar()
        {
            Minimo = 0;
            if (Quantidade < 0)
            {
                Quantidade = 0;
            }

            Maximo = Quantidade;
            Incremento = 1;
            Cor = CorDaBarra.Vermelho;
            Valor = Limitar(Valor);
            Avisar();
        }

        /// <summary>O <c>pbPasso(int iPasso = 1)</c>: o valor anda e para no <see cref="Maximo"/>.</summary>
        public void Passo(int iPasso = 1)
        {
            Valor = Limitar(Valor + iPasso);
            Avisar();
        }

        /// <summary>O <c>pbFim</c>: valor e faixa zerados (<c>Step</c> e cor ficam como estavam).</summary>
        public void Fim()
        {
            Valor = 0;
            Minimo = 0;
            Maximo = 0;
            Avisar();
        }

        private int Limitar(int valor)
        {
            if (valor < Minimo)
            {
                return Minimo;
            }

            return valor > Maximo ? Maximo : valor;
        }

        private void Avisar()
        {
            EventHandler aviso = Mudou;
            if (aviso != null)
            {
                aviso(null, EventArgs.Empty);
            }
        }
    }
}
