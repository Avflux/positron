using System;
using System.Collections.Generic;
using System.Threading;
using Positron.Data;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// <see cref="MonitorDeConexao"/> — o <c>DeclaracoesGeral.monitorConexao</c> e o
    /// <c>statusBanco</c> do reverso: o contador de conexões abertas que decide o ícone do banco na
    /// paleta de páginas (rodada 219).
    /// </summary>
    public class MonitorDeConexaoTests
    {
        [Fact]
        public void O_status_so_liga_a_partir_de_uma_conexao()
        {
            // O `Conversions.ToDouble(valor) > 0` do `statusBanco` (`uscPaginas.cs:2606-2617`).
            Assert.False(MonitorDeConexao.ConectadoCom(0));
            Assert.True(MonitorDeConexao.ConectadoCom(1));
            Assert.True(MonitorDeConexao.ConectadoCom(3));
        }

        [Fact]
        public void Abrir_e_fechar_movem_o_contador_e_o_status()
        {
            MonitorDeConexao monitor = new MonitorDeConexao();
            List<int> avisos = new List<int>();
            monitor.Mudou += (origem, evento) => avisos.Add(monitor.Abertas);

            Assert.False(monitor.Conectado);

            monitor.Incrementar();
            Assert.Equal(1, monitor.Abertas);
            Assert.True(monitor.Conectado);

            monitor.Incrementar();
            Assert.Equal(2, monitor.Abertas);

            monitor.Decrementar();
            Assert.Equal(1, monitor.Abertas);
            Assert.True(monitor.Conectado);

            monitor.Decrementar();
            Assert.Equal(0, monitor.Abertas);
            Assert.False(monitor.Conectado);

            // O `statusBanco` avisa a cada passo do contador.
            Assert.Equal(new[] { 1, 2, 1, 0 }, avisos);
        }

        [Fact]
        public void Reiniciar_zera_o_contador_e_avisa_mesmo_em_zero()
        {
            MonitorDeConexao monitor = new MonitorDeConexao();
            int avisos = 0;
            monitor.Mudou += (origem, evento) => avisos++;

            monitor.Incrementar();
            monitor.Incrementar();
            monitor.Reiniciar();
            Assert.Equal(0, monitor.Abertas);
            Assert.Equal(3, avisos);

            // O `monitorConexao = 0` + `statusBanco("0")` do `IniciarDWG` (`Iniciar.cs:178-179`) chama o
            // aviso mesmo com o contador já em zero.
            monitor.Reiniciar();
            Assert.Equal(4, avisos);
        }

        [Fact]
        public void Cada_leitura_do_ProjectStore_abre_e_fecha_uma_conexao()
        {
            string caminho = BancoDeTeste.Criar();
            int thread = Thread.CurrentThread.ManagedThreadId;
            List<bool> vistos = new List<bool>();
            EventHandler observador = (origem, evento) =>
            {
                // O monitor da sessão é único: só o que **esta** thread provocou interessa aqui (a
                // suíte roda classes em paralelo, e o contador é global).
                if (Thread.CurrentThread.ManagedThreadId == thread)
                {
                    vistos.Add(MonitorDeConexao.Atual.Conectado);
                }
            };

            MonitorDeConexao.Atual.Mudou += observador;
            try
            {
                new ProjectStore(caminho).LerNomesDeDwgs();
            }
            finally
            {
                MonitorDeConexao.Atual.Mudou -= observador;
                BancoDeTeste.Limpar(caminho);
            }

            // Os dois avisos do par do `Abrir()`: o `monitorConexao++` na abertura e o
            // `monitorConexao--` do `fechaConexao` (aqui, o `Disposed`). Os **valores** do contador não
            // entram na comparação porque outra classe pode abrir/fechar no meio — o que é desta
            // thread é a contagem (dois avisos) e o estado na abertura.
            Assert.Equal(2, vistos.Count);
            Assert.True(vistos[0]);
        }
    }
}
