using Positron.Data.Layout;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Perfil de XData do desenho — o que faz o comando explicar por que não achou
    /// nada. Casos reais: `Funcional.dwg` (CONEXAO/INTERLIGACAO), `Interligação.dwg`
    /// (DINTERLIG) e `Fiação.dwg` (só Eletron/DiagLog/LAYOUT).
    /// </summary>
    public class PerfilDoDesenhoTests
    {
        [Fact]
        public void Sem_xdata_e_desconhecido()
        {
            Assert.Equal(TipoDeDesenho.Desconhecido, new PerfilDoDesenho().Veredito());
            Assert.Contains("sem XData", new PerfilDoDesenho().Explicacao());
        }

        [Fact]
        public void Conexao_ou_interligacao_e_diagrama_funcional()
        {
            PerfilDoDesenho perfil = new PerfilDoDesenho();
            perfil.Registrar("CONEXAO");
            perfil.Registrar("CONEXAO");
            perfil.Registrar("AUXINTERLIG");

            Assert.Equal(TipoDeDesenho.DiagramaFuncional, perfil.Veredito());
            Assert.Equal(2, perfil.Quantos("CONEXAO"));

            PerfilDoDesenho outro = new PerfilDoDesenho();
            outro.Registrar("INTERLIGACAO");
            Assert.Equal(TipoDeDesenho.DiagramaFuncional, outro.Veredito());
        }

        [Fact]
        public void Dinterlig_e_documento_de_interligacao()
        {
            PerfilDoDesenho perfil = new PerfilDoDesenho();
            perfil.Registrar("DINTERLIG");
            perfil.Registrar("Eletron");
            perfil.Registrar("DiagLog");

            Assert.Equal(TipoDeDesenho.DocumentoInterligacao, perfil.Veredito());
            Assert.Contains("ArqNet", perfil.Explicacao());
        }

        [Fact]
        public void So_eletron_e_documento_do_produto()
        {
            PerfilDoDesenho perfil = new PerfilDoDesenho();
            perfil.Registrar("Eletron");
            perfil.Registrar("LAYOUT");
            perfil.Registrar("TOPOGRAFICO");

            Assert.Equal(TipoDeDesenho.Documento, perfil.Veredito());
            Assert.Contains("Eletron=1", perfil.Explicacao());
            Assert.Contains("sem os XData do diagrama", perfil.Explicacao());
        }

        [Fact]
        public void App_name_em_branco_ou_nulo_e_ignorado()
        {
            PerfilDoDesenho perfil = new PerfilDoDesenho();
            perfil.Registrar(null);
            perfil.Registrar("   ");

            Assert.Empty(perfil.PorApp);
            Assert.Equal(TipoDeDesenho.Desconhecido, perfil.Veredito());
        }
    }
}
