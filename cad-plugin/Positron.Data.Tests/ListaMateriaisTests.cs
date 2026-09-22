using System.Collections.Generic;
using System.Linq;
using Positron.Contract;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Positron.Data.Materiais;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A lista de materiais (<c>clsLM.CompilaListaDeMateriais</c>): o que cada tipo de
    /// bloco emite, como as reservas se agregam e — o que mais importa — a
    /// **ordenação/renumeração** do original, que tem dois detalhes capazes de mudar
    /// o resultado (a bolha de três comparações independentes e a bolha "torta" da
    /// segunda passada).
    /// </summary>
    public class ListaMateriaisTests
    {
        /// <summary>Uma régua do dicionário, para montar o XRecord do teste.</summary>
        private sealed class Regua
        {
            public int Indice { get; set; }

            public string Nome { get; set; }

            public string Alternativo { get; set; }

            public int Painel { get; set; }
        }

        private static ReguasModelo Reguas(params Regua[] reguas)
        {
            // O XRecord `MODELOS2` das réguas: o índice 0 é o cabeçalho e cada régua
            // ocupa 10 valores (+0 índice, +1 nome, +2 alternativo, +3 painel).
            List<TypedXData> valores = new List<TypedXData> { new TypedXData(1000, reguas.Length) };
            foreach (Regua regua in reguas)
            {
                valores.Add(new TypedXData(1000, regua.Indice));
                valores.Add(new TypedXData(1000, regua.Nome));
                valores.Add(new TypedXData(1000, regua.Alternativo));
                valores.Add(new TypedXData(1000, regua.Painel));
                for (int i = 0; i < 6; i++)
                {
                    valores.Add(new TypedXData(1000, 0));
                }
            }

            return ReguasModelo.Ler(valores);
        }

        private static LayoutPosicoes Layout(params PosicaoLayout[] posicoes)
        {
            return LayoutPosicoes.Ler(posicoes);
        }

        private static List<LinhaListaMaterial> Gerar(
            IEnumerable<DispositivoFiacao> dispositivos,
            Dictionary<int, ModeloMascara> mascaras,
            Dictionary<int, ModeloContato> contatos,
            IEnumerable<PontoBorne> bornes,
            ReguasModelo reguas,
            Dictionary<int, IReadOnlyList<BorneReserva>> reservas,
            LayoutPosicoes layout,
            IReadOnlyList<LinhaListaMaterial> avulsos = null,
            IReadOnlyList<LinhaListaMaterial> ordem = null,
            bool ordemDoBanco = false)
        {
            return ListaMateriaisGerador.Gerar(
                63, dispositivos, mascaras, contatos, bornes, reguas, reservas, layout, avulsos, ordem, ordemDoBanco);
        }

        [Fact]
        public void Mascara_gera_uma_linha_por_lm_do_modelo()
        {
            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "M", Nome1 = "M1", Painel = 503, IndexModelo = 7 },
                new DispositivoFiacao { Tipo = "M", Nome1 = "M2", Nome2 = "B", Painel = 503, IndexModelo = 8 },
            };

            Dictionary<int, ModeloMascara> mascaras = new Dictionary<int, ModeloMascara>
            {
                { 7, new ModeloMascara { Indice = 7, Nome = "M1", Lm1 = 515 } },
                { 8, new ModeloMascara { Indice = 8, Nome = "M2", Lm1 = 519, Lm2 = 520 } },
            };

            List<LinhaListaMaterial> linhas = Gerar(dispositivos, mascaras, null, null, null, null, null);

            Assert.Equal(3, linhas.Count);
            Assert.Equal(new[] { 515, 519, 520 }, linhas.Select(l => l.IndiceMaterial));
            Assert.Equal("M2/B", linhas[2].Tag);
            // A máscara nunca leva handle na linha.
            Assert.All(linhas, linha => Assert.True(string.IsNullOrEmpty(linha.Handle)));
            Assert.All(linhas, linha => Assert.Equal(503, linha.Painel));
        }

        [Fact]
        public void Complementar_e_portas_nao_entram_na_lista()
        {
            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "M", Nome1 = "COMPL", Painel = 1, IndexModelo = 1, Complementar = true },
                new DispositivoFiacao { Tipo = "E", Nome1 = "PORTA", Painel = 1, IndexModelo = 1 },
                new DispositivoFiacao { Tipo = "A", Nome1 = "AUX", Painel = 1, IndexModelo = 1 },
                new DispositivoFiacao { Tipo = "I", Nome1 = "IMP", Painel = 1 },
                new DispositivoFiacao { Tipo = "M", Nome1 = "OK", Painel = 1, IndexModelo = 1 },
            };

            Dictionary<int, ModeloMascara> mascaras = new Dictionary<int, ModeloMascara>
            {
                { 1, new ModeloMascara { Indice = 1, Lm1 = 10 } },
            };

            LinhaListaMaterial linha = Assert.Single(Gerar(dispositivos, mascaras, null, null, null, null, null));
            Assert.Equal("OK", linha.Tag);
        }

        [Fact]
        public void Dispositivo_sem_modelo_usa_o_lm_do_xdata_e_guarda_o_handle()
        {
            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                // indexModelo 0: os LM são os do XData e o handle do bloco é gravado.
                new DispositivoFiacao { Tipo = "P", Nome1 = "hA2", Painel = 503, IndexModelo = 0, Lm1 = 458, Handle = "4AEAC" },
                // Com modelo: os LM vêm do dicionário e a linha sai sem handle.
                new DispositivoFiacao { Tipo = "P", Nome1 = "hA1", Painel = 503, IndexModelo = 5, Lm1 = 1, Handle = "4AEB2" },
            };

            Dictionary<int, ModeloContato> contatos = new Dictionary<int, ModeloContato>
            {
                { 5, new ModeloContato { Indice = 5, Lm1 = 459 } },
            };

            List<LinhaListaMaterial> linhas = Gerar(dispositivos, null, contatos, null, null, null, null);

            Assert.Equal(2, linhas.Count);
            Assert.Equal("hA2", linhas[0].Tag);
            Assert.Equal(458, linhas[0].IndiceMaterial);
            Assert.Equal("4AEAC", linhas[0].Handle);
            Assert.Equal("hA1", linhas[1].Tag);
            Assert.Equal(459, linhas[1].IndiceMaterial);
            Assert.True(string.IsNullOrEmpty(linhas[1].Handle));
        }

        [Fact]
        public void Bornes_agregam_por_painel_regua_tipo_e_lm()
        {
            ReguasModelo reguas = Reguas(new Regua { Indice = 37, Nome = "R6", Painel = 9 });

            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { IndiceRegua = 37, NomeRegua = "R6", Painel = 9, Tipo = 0, Lm = 476 },
                new PontoBorne { IndiceRegua = 37, NomeRegua = "R6", Painel = 9, Tipo = 0, Lm = 476 },
                new PontoBorne { IndiceRegua = 37, NomeRegua = "R6", Painel = 9, Tipo = 0, Lm = 476 },
                // Mesmo painel e régua, outro lm: é outra linha de material.
                new PontoBorne { IndiceRegua = 37, NomeRegua = "R6", Painel = 9, Tipo = 0, Lm = 477 },
                // Régua fora do dicionário (painel 0): não entra.
                new PontoBorne { IndiceRegua = 99, NomeRegua = "R9", Painel = 0, Tipo = 0, Lm = 1 },
            };

            List<LinhaListaMaterial> linhas = Gerar(null, null, null, bornes, reguas, null, null);

            Assert.Equal(2, linhas.Count);
            LinhaListaMaterial doBorne = linhas.Single(l => l.IndiceMaterial == 476);
            Assert.Equal(3, doBorne.Quantidade);
            Assert.Equal("R6", doBorne.Tag);
            Assert.Equal("BORNE", doBorne.Handle);
            Assert.Equal(1, linhas.Single(l => l.IndiceMaterial == 477).Quantidade);
        }

        [Fact]
        public void Reserva_que_casa_com_borne_so_soma_e_a_sem_par_vira_linha()
        {
            ReguasModelo reguas = Reguas(
                new Regua { Indice = 37, Nome = "R6", Painel = 9 },
                new Regua { Indice = 480, Nome = "RES", Painel = 9 });

            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { IndiceRegua = 37, NomeRegua = "R6", Painel = 9, Tipo = 0, Lm = 476 },
            };

            Dictionary<int, IReadOnlyList<BorneReserva>> reservas =
                new Dictionary<int, IReadOnlyList<BorneReserva>>
                {
                    // A reserva da régua 37 repete (tipo, lm) do borne: só soma.
                    { 37, new List<BorneReserva> { new BorneReserva { Tipo = 0, Lm = 476 }, new BorneReserva { Tipo = 0, Lm = 476 } } },
                    // A reserva da régua 480 não tem borne equivalente: vira linha, e
                    // duas reservas iguais agregam na mesma linha.
                    { 480, new List<BorneReserva> { new BorneReserva { Tipo = 1, Lm = 300 }, new BorneReserva { Tipo = 1, Lm = 300 } } },
                };

            List<LinhaListaMaterial> linhas = Gerar(null, null, null, bornes, reguas, reservas, null);

            Assert.Equal(2, linhas.Count);
            Assert.Equal(3, linhas.Single(l => l.IndiceMaterial == 476).Quantidade);

            LinhaListaMaterial daReserva = linhas.Single(l => l.IndiceMaterial == 300);
            Assert.Equal(2, daReserva.Quantidade);
            Assert.Equal("RES", daReserva.Tag);
            // A reserva entra sem handle e com OrdemLay 0 (como no original).
            Assert.True(string.IsNullOrEmpty(daReserva.Handle));
            Assert.Equal(0, daReserva.OrdemLay);
        }

        [Fact]
        public void OrdemLay_vem_do_layout_e_10000_quando_ausente()
        {
            LayoutPosicoes layout = Layout(
                new PosicaoLayout { Painel = 503, Tag = "D1", PosicaoNum = 3, Ordem = 1 },
                new PosicaoLayout { Painel = 503, Tag = "hA2", PosicaoNum = 3, Ordem = 2 });

            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                // "hA2" é a **segunda** tag do layout → índice 1.
                new DispositivoFiacao { Tipo = "P", Nome1 = "hA2", Painel = 503, Lm1 = 1, Handle = "A" },
                // Fora do layout → 10000.
                new DispositivoFiacao { Tipo = "P", Nome1 = "FU1", Painel = 503, Lm1 = 2, Handle = "B" },
                // Outro painel, sem layout nenhum → 10000.
                new DispositivoFiacao { Tipo = "P", Nome1 = "D1", Painel = 9, Lm1 = 3, Handle = "C" },
            };

            List<LinhaListaMaterial> linhas = Gerar(dispositivos, null, null, null, null, null, layout);

            Assert.Equal(1, linhas.Single(l => l.Tag == "hA2").OrdemLay);
            Assert.Equal(LayoutPosicoes.OrdemEquipamentoAusente, linhas.Single(l => l.Tag == "FU1").OrdemLay);
            Assert.Equal(LayoutPosicoes.OrdemEquipamentoAusente, linhas.Single(l => l.Tag == "D1").OrdemLay);
        }

        [Fact]
        public void Ordem_final_e_renumerada_1_a_N_por_painel()
        {
            ReguasModelo reguas = Reguas(new Regua { Indice = 1, Nome = "R1", Painel = 9 });

            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { IndiceRegua = 1, NomeRegua = "R1", Painel = 9, Tipo = 0, Lm = 10 },
                new PontoBorne { IndiceRegua = 1, NomeRegua = "R1", Painel = 9, Tipo = 0, Lm = 11 },
                new PontoBorne { IndiceRegua = 1, NomeRegua = "R1", Painel = 9, Tipo = 0, Lm = 12 },
            };

            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "P", Nome1 = "D1", Painel = 503, Lm1 = 1, Handle = "A" },
                new DispositivoFiacao { Tipo = "P", Nome1 = "D2", Painel = 503, Lm1 = 2, Handle = "B" },
            };

            List<LinhaListaMaterial> linhas = Gerar(dispositivos, null, null, bornes, reguas, null, null);

            // Cada painel é renumerado 1..N **na sua própria sequência**.
            Assert.Equal(new[] { 1, 2, 3 }, linhas.Where(l => l.Painel == 9).Select(l => l.Ordem));
            Assert.Equal(new[] { 1, 2 }, linhas.Where(l => l.Painel == 503).Select(l => l.Ordem));
        }

        [Fact]
        public void Uma_linha_so_fica_com_a_ordem_do_contador_interno()
        {
            // Com **uma** linha o original não renumera (`UBound >= 2`): a Ordem fica
            // no valor do contador interno, que começa em 10000 e já avançou uma vez
            // na varredura (o próprio dispositivo).
            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "P", Nome1 = "D1", Painel = 503, Lm1 = 1, Handle = "A" },
            };

            LinhaListaMaterial linha = Assert.Single(Gerar(dispositivos, null, null, null, null, null, null));
            Assert.Equal(10001, linha.Ordem);
        }

        [Fact]
        public void Avulsos_entram_na_lista_e_sobrevivem()
        {
            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "P", Nome1 = "D1", Painel = 503, Lm1 = 458, Handle = "A" },
                new DispositivoFiacao { Tipo = "P", Nome1 = "D2", Painel = 503, Lm1 = 459, Handle = "B" },
                new DispositivoFiacao { Tipo = "P", Nome1 = "D3", Painel = 503, Lm1 = 460, Handle = "C" },
            };

            // O avulso guarda a Ordem que a projeção anterior lhe deu; ela é a chave
            // da ordenação final, então o item fica onde estava — e, no empate com a
            // linha calculada, a bolha (estável) mantém a calculada antes.
            List<LinhaListaMaterial> avulsos = new List<LinhaListaMaterial>
            {
                new LinhaListaMaterial { DWG = 63, Painel = 503, Tag = "MF", IndiceMaterial = 518, Quantidade = 1, Ordem = 2, Avulso = true },
            };

            List<LinhaListaMaterial> linhas = Gerar(dispositivos, null, null, null, null, null, null, avulsos);

            Assert.Equal(4, linhas.Count);
            Assert.Equal(new[] { "D1", "D2", "MF", "D3" }, linhas.Select(l => l.Tag));
            Assert.Equal(new[] { 1, 2, 3, 4 }, linhas.Select(l => l.Ordem));
            Assert.True(linhas.Single(l => l.Tag == "MF").Avulso);
        }

        [Fact]
        public void Ordem_do_banco_sobrepoe_a_ordem_calculada_quando_pedida()
        {
            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "P", Nome1 = "D1", Painel = 503, Lm1 = 458, Handle = "A" },
                new DispositivoFiacao { Tipo = "P", Nome1 = "D2", Painel = 503, Lm1 = 459, Handle = "B" },
                new DispositivoFiacao { Tipo = "P", Nome1 = "X1", Painel = 9, Lm1 = 460, Handle = "C" },
            };

            List<LinhaListaMaterial> anterior = new List<LinhaListaMaterial>
            {
                new LinhaListaMaterial { Painel = 503, Tag = "D2", IndiceMaterial = 459, Ordem = 1 },
                new LinhaListaMaterial { Painel = 503, Tag = "D1", IndiceMaterial = 458, Ordem = 2 },
                new LinhaListaMaterial { Painel = 9, Tag = "X1", IndiceMaterial = 460, Ordem = 1 },
            };

            List<LinhaListaMaterial> semBanco = Gerar(dispositivos, null, null, null, null, null, null);
            List<LinhaListaMaterial> comBanco = Gerar(
                dispositivos, null, null, null, null, null, null, null, anterior, true);

            // Sem a ordem do banco, o desenho manda: painel 9 primeiro, depois o 503.
            Assert.Equal(new[] { "X1", "D1", "D2" }, semBanco.Select(l => l.Tag));

            // Com a ordem do banco, a chave da ordenação é a Ordem **anterior** (que é
            // 1..N por painel): a lista sai agrupada por essa Ordem, não por painel —
            // é exatamente o rastro que o produto deixou em `ListaMateriais` (as linhas
            // do DWG 63 foram inseridas com Indice crescente por Ordem: todas as
            // "ordem = 1" antes das "ordem = 2").
            Assert.Equal(new[] { "X1", "D2", "D1" }, comBanco.Select(l => l.Tag));

            // E a Ordem gravada volta a ser 1..N **por painel** — o que faz a ordem
            // sobreviver à projeção seguinte (o "Sim" é auto-consistente).
            Assert.Equal(1, comBanco.Single(l => l.Tag == "X1").Ordem);
            Assert.Equal(new[] { 1, 2 }, comBanco.Where(l => l.Painel == 503).Select(l => l.Ordem));
        }

        [Fact]
        public void Bornes_de_paineis_com_a_mesma_chave_saem_em_ordem_alfabetica()
        {
            // A ordenação dos bornes é por `(IndiceMaterial, Painel, TagRégua)`; com uma
            // chave só, o resultado é alfabético.
            //
            // **A bolha da segunda passada depende da lista inteira**, não só do painel:
            // ela compara `mMateriais[o]` (o índice de fora) contra `mMateriais[j + 1]`,
            // então o mesmo conjunto de bornes sai em ordem diferente conforme o resto
            // da lista. É por isso que no desenho real — com a lista inteira — o painel
            // 155 sai `R1, SAÍDA, R3, R2` (não alfabético) e aqui, com só quatro linhas,
            // sai alfabético. O A/B do RUNBOOK confere o caso real contra o produto.
            ReguasModelo reguas = Reguas(
                new Regua { Indice = 1, Nome = "R1", Painel = 155 },
                new Regua { Indice = 2, Nome = "SAÍDA", Painel = 155 },
                new Regua { Indice = 3, Nome = "R3", Painel = 155 },
                new Regua { Indice = 4, Nome = "R2", Painel = 155 });

            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { IndiceRegua = 1, NomeRegua = "R1", Painel = 155, Tipo = 0, Lm = 0 },
                new PontoBorne { IndiceRegua = 2, NomeRegua = "SAÍDA", Painel = 155, Tipo = 0, Lm = 0 },
                new PontoBorne { IndiceRegua = 3, NomeRegua = "R3", Painel = 155, Tipo = 0, Lm = 0 },
                new PontoBorne { IndiceRegua = 4, NomeRegua = "R2", Painel = 155, Tipo = 0, Lm = 0 },
            };

            List<LinhaListaMaterial> linhas = Gerar(null, null, null, bornes, reguas, null, null);

            Assert.Equal(new[] { "R1", "R2", "R3", "SAÍDA" }, linhas.Select(l => l.Tag));
            Assert.Equal(new[] { 1, 2, 3, 4 }, linhas.Select(l => l.Ordem));
        }

        [Fact]
        public void Um_dispositivo_em_outro_painel_muda_a_ordem_dos_bornes()
        {
            // A prova da sensibilidade: as MESMAS quatro linhas de borne do teste
            // anterior, com um dispositivo num painel mais alto, saem em outra ordem —
            // a bolha "torta" reordena pela lista inteira. Um `sort` limpo daria
            // alfabético nos dois casos.
            ReguasModelo reguas = Reguas(
                new Regua { Indice = 1, Nome = "R1", Painel = 155 },
                new Regua { Indice = 2, Nome = "SAÍDA", Painel = 155 },
                new Regua { Indice = 3, Nome = "R3", Painel = 155 },
                new Regua { Indice = 4, Nome = "R2", Painel = 155 });

            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { IndiceRegua = 1, NomeRegua = "R1", Painel = 155, Tipo = 0, Lm = 0 },
                new PontoBorne { IndiceRegua = 2, NomeRegua = "SAÍDA", Painel = 155, Tipo = 0, Lm = 0 },
                new PontoBorne { IndiceRegua = 3, NomeRegua = "R3", Painel = 155, Tipo = 0, Lm = 0 },
                new PontoBorne { IndiceRegua = 4, NomeRegua = "R2", Painel = 155, Tipo = 0, Lm = 0 },
            };

            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "P", Nome1 = "D1", Painel = 503, Lm1 = 458, Handle = "A" },
                new DispositivoFiacao { Tipo = "P", Nome1 = "D2", Painel = 503, Lm1 = 459, Handle = "B" },
            };

            List<LinhaListaMaterial> comDispositivo = Gerar(dispositivos, null, null, bornes, reguas, null, null);
            List<string> bornesNaOrdem = comDispositivo.Where(l => l.Handle == "BORNE").Select(l => l.Tag).ToList();
            List<string> bornesSozinhos = Gerar(null, null, null, bornes, reguas, null, null).Select(l => l.Tag).ToList();

            Assert.Equal(new[] { "R1", "R2", "R3", "SAÍDA" }, bornesSozinhos);
            Assert.NotEqual(bornesSozinhos, bornesNaOrdem);
        }

        [Fact]
        public void Grava_e_le_de_volta_sem_duplicar()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<LinhaListaMaterial> linhas = new List<LinhaListaMaterial>
                {
                    new LinhaListaMaterial { DWG = 63, Painel = 503, Tag = "D1", IndiceMaterial = 458, Quantidade = 1, Ordem = 1, Handle = "A", OrdemLay = 12 },
                    new LinhaListaMaterial { DWG = 63, Painel = 503, Tag = "R6", IndiceMaterial = 476, Quantidade = 63, Ordem = 2, Handle = "BORNE", OrdemLay = 10000 },
                };

                Assert.Equal(2, store.InserirListaMateriais(linhas, 63));
                Assert.Equal(2, store.InserirListaMateriais(linhas, 63));

                List<LinhaListaMaterial> lidas = store.LerListaMateriais(63);
                Assert.Equal(2, lidas.Count);
                Assert.Equal("D1", lidas[0].Tag);
                Assert.Equal(12, lidas[0].OrdemLay);
                Assert.Equal(63, lidas[1].Quantidade);
                Assert.Equal(10000, lidas[1].OrdemLay);
                Assert.Equal(0, lidas[0].IndiceLM);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Avulso_sobrevive_a_projecao_e_guarda_o_indice_lm()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);

                // Uma linha manual do app, com IndiceLM já atribuído por outro fluxo.
                store.InserirListaMateriais(new List<LinhaListaMaterial>
                {
                    new LinhaListaMaterial { DWG = 63, Painel = 503, Tag = "MF", IndiceMaterial = 518, Quantidade = 1, Ordem = 1, Avulso = true, IndiceLM = 44 },
                    new LinhaListaMaterial { DWG = 63, Painel = 503, Tag = "D1", IndiceMaterial = 458, Quantidade = 1, Ordem = 2 },
                }, 63);

                // O `RemoveMateriaisLista` apaga só os não-avulsos...
                Assert.Equal(1, store.RemoverListaMateriaisNaoAvulsos(63));
                Assert.Single(store.LerListaMateriaisAvulsos(63));

                // ...e o `RemoveItemMaterial` preserva o IndiceLM de quem tem o mesmo
                // (Painel, Tag).
                store.InserirListaMateriais(
                    new List<LinhaListaMaterial>
                    {
                        new LinhaListaMaterial { DWG = 63, Painel = 503, Tag = "MF", IndiceMaterial = 518, Quantidade = 1, Ordem = 1, Avulso = true },
                        new LinhaListaMaterial { DWG = 63, Painel = 503, Tag = "D2", IndiceMaterial = 459, Quantidade = 1, Ordem = 2 },
                    },
                    63);

                List<LinhaListaMaterial> lidas = store.LerListaMateriais(63);
                Assert.Equal(2, lidas.Count);
                Assert.Equal(44, lidas.Single(l => l.Tag == "MF").IndiceLM);
                Assert.Equal(0, lidas.Single(l => l.Tag == "D2").IndiceLM);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Limpeza_de_desenhos_fora_do_cadastro_e_pulada_sem_cadastro()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                store.InserirListaMateriais(new List<LinhaListaMaterial>
                {
                    new LinhaListaMaterial { DWG = 9, Painel = 1, Tag = "X", IndiceMaterial = 1, Quantidade = 1, Ordem = 1 },
                }, 9);
                store.InserirListaMateriais(new List<LinhaListaMaterial>
                {
                    new LinhaListaMaterial { DWG = 63, Painel = 1, Tag = "Y", IndiceMaterial = 2, Quantidade = 1, Ordem = 1 },
                }, 63);

                // Sem nenhum desenho no cadastro (`DWG`), a limpeza não conclui nada:
                // apagar as listas seria inventar dado. Desvio documentado.
                Assert.Equal(0, store.RemoverListaMateriaisDeDwgsForaDoCadastro());
                Assert.Single(store.LerListaMateriais(9));
                Assert.Single(store.LerListaMateriais(63));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}
