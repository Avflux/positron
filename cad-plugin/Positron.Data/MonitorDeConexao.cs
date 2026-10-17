using System;

namespace Positron.Data
{
    /// <summary>
    /// O <c>DeclaracoesGeral.monitorConexao</c> do original (<c>DeclaracoesGeral.cs:566</c>, zerado no
    /// construtor estático, <c>:610</c>): o **contador de conexões abertas** que decide o ícone do
    /// banco na paleta de páginas.
    ///
    /// O par do original é abrir/fechar, em cada acesso a dados: no <c>Open()</c> o
    /// <c>monitorConexao++</c> seguido do <c>statusBanco(monitorConexao)</c> (<c>AcessoSQLite.cs:99-104</c>,
    /// <c>AcessoAccess.cs:136-137</c>, <c>AcessoSQLServer.cs:110-111</c>) e no <c>fechaConexao()</c> o
    /// <c>monitorConexao--</c> seguido do mesmo aviso (<c>AcessoSQLite.cs:33-43</c>). O incremento só
    /// acontece quando a conexão estava fechada — o contador conta conexões, não chamadas.
    ///
    /// Quem consome é o <c>uscPaginas.statusBanco</c> (<c>uscPaginas.cs:2606-2617</c>):
    /// <c>Conversions.ToDouble(valor) &gt; 0</c> decide entre <c>DB_CONNECTED</c> e
    /// <c>DB_DISCONNECTED</c> — <see cref="ConectadoCom"/>/<see cref="Conectado"/>. A carga da paleta
    /// <b>não</b> mexe no ícone no original: só o contador (e o <c>monitorConexao = 0</c> do
    /// <c>IniciarDWG</c>, <c>Iniciar.cs:178-179</c>) o faz.
    ///
    /// O monitor da sessão é o <see cref="Atual"/> (o estático do original); a instância existe para a
    /// regra poder ser medida isolada, sem o contador global da suíte.
    /// </summary>
    public sealed class MonitorDeConexao
    {
        /// <summary>O monitor da sessão — o <c>DeclaracoesGeral.monitorConexao</c> de todo mundo.</summary>
        public static readonly MonitorDeConexao Atual = new MonitorDeConexao();

        private int _abertas;

        /// <summary>Quantas conexões estão abertas agora (o <c>monitorConexao</c>).</summary>
        public int Abertas
        {
            get { return _abertas; }
        }

        /// <summary>O <c>statusBanco</c> com o contador de agora.</summary>
        public bool Conectado
        {
            get { return ConectadoCom(_abertas); }
        }

        /// <summary>
        /// O <c>statusBanco</c> do reverso sobre um valor do contador: o ícone é o de conectado a partir
        /// de **uma** conexão aberta (o original testa <c>&gt; 0</c> sobre o número, não sobre o arquivo).
        /// </summary>
        public static bool ConectadoCom(int abertas)
        {
            return abertas > 0;
        }

        /// <summary>
        /// O aviso do <c>statusBanco</c> (as três famílias de acesso o chamam a cada mudança do
        /// contador). Quem escuta é a paleta, que troca a imagem do <c>PictureBox2</c>.
        /// </summary>
        public event EventHandler Mudou;

        /// <summary>O <c>monitorConexao++</c> + o <c>statusBanco</c> do original.</summary>
        public void Incrementar()
        {
            _abertas++;
            Avisar();
        }

        /// <summary>O <c>monitorConexao--</c> + o <c>statusBanco</c> do <c>fechaConexao</c>.</summary>
        public void Decrementar()
        {
            _abertas--;
            Avisar();
        }

        /// <summary>
        /// O <c>monitorConexao = 0</c> seguido do <c>statusBanco("0")</c> do <c>IniciarDWG</c>
        /// (<c>Iniciar.cs:178-179</c>): o original avisa o ícone mesmo já estando em zero — por isso
        /// o aviso sai **sempre**, e não só quando o valor muda.
        /// </summary>
        public void Reiniciar()
        {
            _abertas = 0;
            Avisar();
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
