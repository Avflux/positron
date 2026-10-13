using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>A exclusão de página: as guardas de <see cref="ExclusaoDePagina.Recusa"/>.</summary>
    public class ExclusaoDePaginaTests
    {
        private static List<string> Paginas()
        {
            return new List<string> { "1", "2", "3" };
        }

        [Fact]
        public void Apagar_uma_pagina_do_caderno_e_permitido()
        {
            Assert.Null(ExclusaoDePagina.Recusa("2", Paginas()));
            Assert.Null(ExclusaoDePagina.Recusa(" 2 ", Paginas()));
        }

        [Fact]
        public void Nome_vazio_e_recusado()
        {
            Assert.NotNull(ExclusaoDePagina.Recusa("", Paginas()));
            Assert.NotNull(ExclusaoDePagina.Recusa(null, Paginas()));
        }

        [Fact]
        public void Layer_que_nao_e_pagina_e_recusado()
        {
            Assert.NotNull(ExclusaoDePagina.Recusa("-1", Paginas()));
            Assert.NotNull(ExclusaoDePagina.Recusa("Defpoints", Paginas()));
        }

        [Fact]
        public void Pagina_fora_da_lista_e_recusada()
        {
            Assert.NotNull(ExclusaoDePagina.Recusa("9", Paginas()));
        }

        [Fact]
        public void Sem_lista_o_crivo_e_so_o_LayerValido()
        {
            Assert.Null(ExclusaoDePagina.Recusa("7", null));
            Assert.NotNull(ExclusaoDePagina.Recusa("-1", null));
        }
    }
}
