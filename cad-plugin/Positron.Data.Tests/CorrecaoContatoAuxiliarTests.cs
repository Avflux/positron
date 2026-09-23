using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigeContatosAux</c> (frente 2 do §7.6): a regra que casa o bloco
    /// auxiliar (tipo <c>A</c>) ao bloco de modelo (<see cref="CorrecaoContatoAuxiliar"/>,
    /// o par de escrita do <c>bt4Auxiliar</c>) e o XData <c>Modelo</c>
    /// (<see cref="ModeloXData"/>).
    /// </summary>
    public class CorrecaoContatoAuxiliarTests
    {
        // ── A regra ───────────────────────────────────────────────────────────

        [Fact]
        public void Casa_pela_chave_e_preenche_o_handle()
        {
            List<ContatoAuxiliarNoDesenho> auxiliares = new List<ContatoAuxiliarNoDesenho>
            {
                Auxiliar("H1", 5, 2, "AAA"),
            };
            List<BlocoModelo> modelos = new List<BlocoModelo>
            {
                Modelo("H1", 5, 2, ""),
            };

            IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes =
                CorrecaoContatoAuxiliar.Planejar(auxiliares, modelos);

            Assert.Collection(
                ajustes,
                a =>
                {
                    Assert.Equal("AAA", a.HandleContatoAux);
                    Assert.True(a.Mudou);
                });
        }

        [Fact]
        public void O_HandleBob_ignora_a_caixa()
        {
            // O `TextCompare: true` do original: `h1` casa com `H1`.
            IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes = CorrecaoContatoAuxiliar.Planejar(
                new List<ContatoAuxiliarNoDesenho> { Auxiliar("h1", 5, 2, "AAA") },
                new List<BlocoModelo> { Modelo("H1", 5, 2, "") });

            Assert.Equal("AAA", ajustes[0].HandleContatoAux);
        }

        [Fact]
        public void Indice_diferente_nao_casa()
        {
            IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes = CorrecaoContatoAuxiliar.Planejar(
                new List<ContatoAuxiliarNoDesenho> { Auxiliar("H1", 5, 3, "AAA") },
                new List<BlocoModelo> { Modelo("H1", 5, 2, "") });

            Assert.Equal(string.Empty, ajustes[0].HandleContatoAux);
            Assert.False(ajustes[0].Mudou);
        }

        [Fact]
        public void O_primeiro_auxiliar_da_ordem_vence()
        {
            // A varredura do original é na ordem do ModelSpace e para no primeiro
            // que casa; a lista recebida já vem nessa ordem.
            IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes = CorrecaoContatoAuxiliar.Planejar(
                new List<ContatoAuxiliarNoDesenho>
                {
                    Auxiliar("H1", 5, 2, "PRIMEIRO"),
                    Auxiliar("H1", 5, 2, "SEGUNDO"),
                },
                new List<BlocoModelo> { Modelo("H1", 5, 2, "") });

            Assert.Equal("PRIMEIRO", ajustes[0].HandleContatoAux);
        }

        [Fact]
        public void Modelo_sem_contato_fica_vazio_e_marca_a_mudanca()
        {
            // O original grava o campo **vazio** quando nenhum auxiliar casa — e é
            // isso que o `bt4Auxiliar` enxerga como divergência.
            IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes = CorrecaoContatoAuxiliar.Planejar(
                new List<ContatoAuxiliarNoDesenho>(),
                new List<BlocoModelo> { Modelo("H1", 5, 2, "ANTIGO") });

            Assert.Equal(string.Empty, ajustes[0].HandleContatoAux);
            Assert.True(ajustes[0].Mudou);
        }

        [Fact]
        public void Quem_ja_esta_certo_nao_muda()
        {
            IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes = CorrecaoContatoAuxiliar.Planejar(
                new List<ContatoAuxiliarNoDesenho> { Auxiliar("H1", 5, 2, "AAA") },
                new List<BlocoModelo> { Modelo("H1", 5, 2, "AAA") });

            Assert.False(ajustes[0].Mudou);
        }

        [Fact]
        public void Sem_modelos_nao_ha_ajuste()
        {
            Assert.Empty(CorrecaoContatoAuxiliar.Planejar(null, null));
            Assert.Empty(CorrecaoContatoAuxiliar.Planejar(
                new List<ContatoAuxiliarNoDesenho> { Auxiliar("H1", 5, 2, "AAA") },
                new List<BlocoModelo>()));
        }

        [Fact]
        public void Sem_auxiliares_o_campo_vai_vazio()
        {
            IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes =
                CorrecaoContatoAuxiliar.Planejar(null, new List<BlocoModelo> { Modelo("H1", 5, 2, "") });

            Assert.Single(ajustes);
            Assert.Equal(string.Empty, ajustes[0].HandleContatoAux);
        }

        // ── O XData do modelo ─────────────────────────────────────────────────

        [Fact]
        public void Le_o_layout_do_Modelo()
        {
            BlocoModelo modelo;
            Assert.True(ModeloXData.Ler(Valores("Modelo", "H1", 5, 2, "AAA"), out modelo));
            Assert.Equal("H1", modelo.HandleBob);
            Assert.Equal(5, modelo.IndexModelo);
            Assert.Equal(2, modelo.IndexContato);
            Assert.Equal("AAA", modelo.HandleContatoAux);
        }

        [Fact]
        public void Aceita_o_app_name_legado()
        {
            // O original compara o valor em maiúsculas com `MODELO`, então a grafia
            // mista passa — a mesma tolerância dos leitores de dispositivo.
            BlocoModelo modelo;
            Assert.True(ModeloXData.Ler(Valores("MODELO", "H1", 5, 2, ""), out modelo));
            Assert.True(ModeloXData.Ler(Valores("modelo", "H1", 5, 2, ""), out modelo));
        }

        [Fact]
        public void Outro_app_name_nao_le()
        {
            BlocoModelo modelo;
            Assert.False(ModeloXData.Ler(Valores("MODELOS2", "H1", 5, 2, ""), out modelo));
            Assert.Null(modelo);
        }

        [Fact]
        public void Registro_truncado_nao_le_e_nao_estoura()
        {
            BlocoModelo modelo;
            Assert.False(ModeloXData.Ler(null, out modelo));
            Assert.False(ModeloXData.Ler(
                new List<TypedXData> { new TypedXData(1001, "Modelo") }, out modelo));
        }

        [Fact]
        public void O_que_o_escritor_grava_o_leitor_le_de_volta()
        {
            BlocoModelo modelo = Modelo("H1", 5, 2, "AAA");

            BlocoModelo lido;
            Assert.True(ModeloXData.Ler(ModeloXData.ParaValores(modelo), out lido));
            Assert.Equal("H1", lido.HandleBob);
            Assert.Equal(5, lido.IndexModelo);
            Assert.Equal(2, lido.IndexContato);
            Assert.Equal("AAA", lido.HandleContatoAux);
        }

        [Fact]
        public void O_escritor_usa_o_app_name_corrente_e_zera_o_que_vem_nulo()
        {
            IReadOnlyList<TypedXData> valores = ModeloXData.ParaValores(new BlocoModelo { IndexModelo = 3 });

            Assert.Equal(5, valores.Count);
            Assert.Equal(1001, valores[0].Codigo);
            Assert.Equal(ModeloXData.AppName, valores[0].Valor);
            Assert.Equal(string.Empty, valores[1].Valor);
            Assert.Equal(3, valores[2].Valor);
            Assert.Equal(0, valores[3].Valor);
            Assert.Equal(string.Empty, valores[4].Valor);
        }

        // ── Montagem ──────────────────────────────────────────────────────────

        private static ContatoAuxiliarNoDesenho Auxiliar(string bob, int indexModelo, int indexContato, string handle)
        {
            return new ContatoAuxiliarNoDesenho
            {
                Handle = handle,
                HandleBob = bob,
                IndexModelo = indexModelo,
                IndexContato = indexContato,
            };
        }

        private static BlocoModelo Modelo(string bob, int indexModelo, int indexContato, string handleContatoAux)
        {
            return new BlocoModelo
            {
                Handle = "BLOCO",
                HandleBob = bob,
                IndexModelo = indexModelo,
                IndexContato = indexContato,
                HandleContatoAux = handleContatoAux,
            };
        }

        private static List<TypedXData> Valores(string appName, string bob, int indexModelo, int indexContato, string handle)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, appName),
                new TypedXData(1000, bob),
                new TypedXData(1071, indexModelo),
                new TypedXData(1071, indexContato),
                new TypedXData(1000, handle),
            };
        }
    }
}
