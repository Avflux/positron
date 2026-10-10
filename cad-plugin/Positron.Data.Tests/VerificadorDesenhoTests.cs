using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// As regras do verificador que olham o **desenho** (régua do borne e cabo
    /// fora do catálogo) — o que o <c>frmVerificadorProjeto*</c> acrescenta às
    /// tabelas gravadas.
    /// </summary>
    public class VerificadorDesenhoTests
    {
        [Fact]
        public void Aponta_cabo_referenciado_fora_do_catalogo()
        {
            List<string> usados = new List<string> { "CABO1", "CABO2", "cabo2", null, " " };
            List<string> catalogo = new List<string> { "CABO1", "CABO3" };

            List<Problema> problemas = VerificadorProjeto.VerificarCabosSemCatalogo(usados, catalogo);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.CaboSemCatalogo, problema.Tipo);
            Assert.Equal("CABO2", problema.Identificador);
        }

        [Fact]
        public void Catalogo_completo_nao_aponta_nada()
        {
            List<Problema> problemas = VerificadorProjeto.VerificarCabosSemCatalogo(
                new List<string> { "CABO1" },
                new List<string> { "cabo1" });

            Assert.Empty(problemas);
        }

        [Fact]
        public void Aponta_borne_sem_regua_no_dicionario()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5 },
                new PontoBorne { Handle = "H9", IndiceRegua = 9 },
                new PontoBorne { Handle = "", IndiceRegua = 9 },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarBornesSemRegua(bornes, reguas);

            Assert.Equal(2, problemas.Count);
            Assert.Equal(TipoProblema.BorneSemRegua, problemas[0].Tipo);
            Assert.Equal("H9", problemas[0].Identificador);
            Assert.Equal("régua #9", problemas[1].Identificador);
        }

        [Fact]
        public void Aponta_painel_fora_do_cadastro()
        {
            // O `lPnAoagado` do original: `Dicionario.BuscaNomeDoPainel` responde
            // "???" quando o painel nao esta no dicionario (a tabela `Paineis`).
            List<Problema> problemas = VerificadorProjeto.VerificarPaineisSemCadastro(
                new List<int> { 503, 509, 0, 509 },
                new List<int> { 503 });

            Problema problema = Assert.Single(problemas);
            Assert.Equal(TipoProblema.PainelSemCadastro, problema.Tipo);
            Assert.Equal("painel 509", problema.Identificador);
        }

        [Fact]
        public void Painel_no_cadastro_nao_aponta()
        {
            Assert.Empty(VerificadorProjeto.VerificarPaineisSemCadastro(
                new List<int> { 503, 509 },
                new List<int> { 503, 509, 510 }));
        }

        [Fact]
        public void Aponta_conexao_sem_sobreposicao()
        {
            // O laço A do `carregaOrfao`: `HandleSup` vazio = Tipo 3 sem o Handle do
            // XData, ou seja, uma conexão sem par.
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>
            {
                new ConexaoFiacao { Tipo = 3, Potencial = 10, Painel = 503, Handle = "H1", HandleSuperposto = "", Pagina = "8" },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarOrfaos(conexoes);

            Assert.Contains(problemas, p => p.Tipo == TipoProblema.ConexaoOrfa && p.Identificador == "H1");
        }

        [Fact]
        public void Aponta_potencial_sem_conexao_tipo_1_ou_2()
        {
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>
            {
                // Tipo 3 com sobreposição "OK"? impossível: só o Tipo 1/2 recebem OK.
                new ConexaoFiacao { Tipo = 3, Potencial = 77, Painel = 503, Handle = "H1", HandleSuperposto = "OK", Pagina = "8" },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarOrfaos(conexoes);

            Assert.Contains(problemas, p => p.Tipo == TipoProblema.ConexaoOrfa && p.Detalhe.Contains("77"));
        }

        [Fact]
        public void Aponta_sobreposicao_que_nao_resolve()
        {
            // Tipo 2 existe no potencial 5 (logo o potencial não é isolado), mas o
            // Tipo 3 aponta para um handle que não é conexão nenhuma.
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>
            {
                new ConexaoFiacao { Tipo = 2, Potencial = 5, Painel = 503, Handle = "H1", HandleSuperposto = "OK", Pagina = "8" },
                new ConexaoFiacao { Tipo = 3, Potencial = 5, Painel = 503, Handle = "H2", HandleSuperposto = "NAOEXISTE", Pagina = "8" },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarOrfaos(conexoes);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(TipoProblema.SobreposicaoAusente, problema.Tipo);
            Assert.Equal("H2", problema.Identificador);
        }

        [Fact]
        public void Conexao_de_jumper_e_descartada()
        {
            // O original ignora as conexões com `Jumper == "JUMPER"` ao montar o
            // conjunto (`ClsVerificadorProjetoFiacao:791`).
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>
            {
                new ConexaoFiacao { Tipo = 4, Potencial = 99, Painel = 503, Handle = "H1", HandleSuperposto = "", Pagina = "8", Jumper = "JUMPER" },
            };

            Assert.Empty(VerificadorProjeto.VerificarOrfaos(conexoes));
        }

        [Fact]
        public void Conexao_com_par_nao_aponta()
        {
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>
            {
                new ConexaoFiacao { Tipo = 2, Potencial = 5, Painel = 503, Handle = "H1", HandleSuperposto = "OK", Pagina = "8" },
                new ConexaoFiacao { Tipo = 3, Potencial = 5, Painel = 503, Handle = "H2", HandleSuperposto = "H1", Pagina = "8" },
            };

            Assert.Empty(VerificadorProjeto.VerificarOrfaos(conexoes));
        }

        [Fact]
        public void Aponta_borne_sem_LM()
        {
            // O `GijcRTCGe3` do reverso: todo borne do desenho com `lm == 0`.
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5, Painel = 503, Numero = "11", Lm = 0 },
                new PontoBorne { Handle = "H2", IndiceRegua = 5, Painel = 503, Numero = "12", Lm = 476 },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarBornesSemLm(bornes);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.BorneSemLm, problema.Tipo);
            Assert.Equal("H1", problema.Identificador);
            Assert.Contains("painel 503", problema.Detalhe);
            Assert.Contains("11", problema.Detalhe);
        }

        [Fact]
        public void Borne_com_LM_nao_aponta()
        {
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", Lm = 1 },
                new PontoBorne { Handle = "H2", Lm = 476 },
            };

            Assert.Empty(VerificadorProjeto.VerificarBornesSemLm(bornes));
        }

        [Fact]
        public void Aponta_borne_com_numero_visivel_diferente_da_regua()
        {
            // O `bt9Discrepantes` (QU5c0lgjBd): o atributo `T1` do bloco é o número
            // visível; quando difere do número da régua/XData o borne foi editado à mão.
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5, Painel = 3, Numero = "11", Terminal = "11", NumeroVisivel = "12" },
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarBornesEditados(bornes));
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.BorneEditado, problema.Tipo);
            Assert.Equal("Bornes", problema.Tabela);
            Assert.Equal("H1", problema.Identificador);
            Assert.Contains("12", problema.Detalhe);
            Assert.Contains("11", problema.Detalhe);
        }

        [Fact]
        public void Borne_com_numero_visivel_igual_ao_da_regua_nao_aponta()
        {
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5, Numero = "11", Terminal = "11", NumeroVisivel = "11" },
            };

            Assert.Empty(VerificadorProjeto.VerificarBornesEditados(bornes));
        }

        [Fact]
        public void Borne_sem_atributo_T1_nao_aponta()
        {
            // O `TiraNothing`: sem atributo (ou vazio) não há edição a apontar.
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5, Numero = "11", Terminal = "11", NumeroVisivel = null },
                new PontoBorne { Handle = "H2", IndiceRegua = 5, Numero = "12", Terminal = "12", NumeroVisivel = "" },
            };

            Assert.Empty(VerificadorProjeto.VerificarBornesEditados(bornes));
        }

        [Fact]
        public void Numero_visivel_do_borne_ignora_maiusculas()
        {
            // O `TextCompare` do original: o complemento colado entra no número e a
            // comparação não diferencia maiúsculas de minúsculas.
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5, Numero = "11", Terminal = "11A", NumeroVisivel = "11a" },
            };

            Assert.Empty(VerificadorProjeto.VerificarBornesEditados(bornes));
        }

        [Fact]
        public void Aponta_regua_do_dicionario_sem_borne()
        {
            // O `buscaReguasVazias` do reverso: para cada régua do dicionário, se o
            // par (painel, régua) não está entre as usadas pelos bornes, ela está vazia.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());

            // Sem nenhum borne no desenho, a única régua do dicionário (painel 3,
            // régua 5) está vazia.
            List<Problema> problemas = VerificadorProjeto.VerificarReguasVazias(reguas, new List<PontoBorne>());

            Problema problema = Assert.Single(problemas);
            Assert.Equal(TipoProblema.ReguaVazia, problema.Tipo);
            Assert.Equal("painel 3, régua #5", problema.Identificador);
            Assert.Contains("R1", problema.Detalhe);
        }

        [Fact]
        public void Regua_usada_nao_e_apontada()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>();
            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                bornes.Add(new PontoBorne { Handle = "H" + regua.Indice, IndiceRegua = regua.Indice, Painel = regua.Painel });
            }

            Assert.Empty(VerificadorProjeto.VerificarReguasVazias(reguas, bornes));
        }

        [Fact]
        public void Borne_de_outro_painel_nao_usa_a_regua()
        {
            // A chave é o par (painel, régua), como o `"painel,régua"` do original:
            // um borne de outro painel com o mesmo índice não usa esta régua.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            int indice = reguas.Ordenadas[0].Indice;
            int painel = reguas.Ordenadas[0].Painel;
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = indice, Painel = (short)(painel + 1) },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarReguasVazias(reguas, bornes);

            Assert.Contains(problemas, p => p.Identificador == "painel " + painel + ", régua #" + indice);
        }

        [Fact]
        public void Borne_com_regua_resolvida_nao_aponta()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne> { new PontoBorne { Handle = "H1", IndiceRegua = 5 } };

            Assert.Empty(VerificadorProjeto.VerificarBornesSemRegua(bornes, reguas));
        }

        [Fact]
        public void Aponta_buraco_na_sequencia_de_bornes_da_regua()
        {
            // O `bt8intervalos` (nXnc5R08lF): a régua 5 tem os bornes 1, 2 e 4 — falta
            // o 3, então a sequência 2 → 4 é um intervalo inválido.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "1", 1),
                Borne("H2", "2", 2),
                Borne("H4", "4", 3),
            };

            List<Problema> problemas = VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, null);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.IntervaloBorneInvalido, problema.Tipo);
            Assert.Equal("painel 3, régua #5", problema.Identificador);
            Assert.Contains("2 a 4", problema.Detalhe);
        }

        [Fact]
        public void Aponta_numero_de_borne_repetido()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "1", 1),
                Borne("H2", "2", 2),
                Borne("H3", "2", 3),
            };

            List<Problema> problemas = VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, null);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(TipoProblema.BorneNumeroRepetido, problema.Tipo);
            Assert.Contains("borne 2 repetido", problema.Detalhe);
        }

        [Fact]
        public void Aponta_numero_de_borne_indefinido()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "?", 1),
                Borne("H2", "2", 2),
            };

            List<Problema> problemas = VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, null);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(TipoProblema.BorneNumeroIndefinido, problema.Tipo);
        }

        [Fact]
        public void Sequencia_continua_nao_aponta()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "10", 1),
                Borne("H2", "11", 2),
                Borne("H3", "12", 3),
            };

            Assert.Empty(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, null));
        }

        [Fact]
        public void Numero_nao_numerico_e_ignorado()
        {
            // Só os números numéricos entram no teste de intervalo (o
            // `Versioned.IsNumeric` do original); "A1"/"A2" passam batido.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "A1", 1),
                Borne("H2", "A2", 2),
            };

            Assert.Empty(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, null));
        }

        [Fact]
        public void Reserva_preenche_o_buraco_da_sequencia()
        {
            // O `LeDicBornesReserva` acrescenta as reservas da régua à sequência:
            // com a reserva "2" no meio, 1 → 2 → 3 volta a ser contíguo.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "1", 1),
                Borne("H3", "3", 3),
            };
            Dictionary<int, IReadOnlyList<BorneReserva>> reservas =
                new Dictionary<int, IReadOnlyList<BorneReserva>>
                {
                    { 5, new List<BorneReserva> { new BorneReserva { Numero = "2", Ordem = 2 } } },
                };

            Assert.Empty(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, reservas));
        }

        [Fact]
        public void Regua_de_painel_fora_de_uso_e_ignorada()
        {
            // O filtro `lPn` do `buscaDadosDeFiacaoDWG`: só as réguas de painel em uso
            // entram na checagem.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "1", 1),
                Borne("H4", "4", 2),
            };

            Assert.Empty(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 9 }, null));
        }

        [Fact]
        public void Complemento_do_borne_entra_no_numero()
        {
            // O original cola o `NumeroComplem` no `Numero` antes de comparar (o
            // borne 11 com complemento "A" vira "11A"). Como "11A" não é numérico,
            // ele fica fora do teste de intervalo — o buraco 10 → 12 fica escondido.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H10", "10", 1),
                Borne("H11", "11", 2, "A"),
                Borne("H12", "12", 3),
            };

            Assert.Empty(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, null));
        }

        [Fact]
        public void Numero_zero_do_desenho_e_indefinido()
        {
            // O desenho grava "sem número" como "0" e o original troca por
            // `CaracterTerminalIndefinido` ("?") ao montar a lista de bornes.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("H1", "0", 1),
                Borne("H2", "1", 2),
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, null));
            Assert.Equal(TipoProblema.BorneNumeroIndefinido, problema.Tipo);
        }

        [Fact]
        public void Reserva_com_numero_zero_nao_vira_indefinido()
        {
            // O mapeamento "0" → "?" é feito **só** nos bornes do desenho; o
            // `LeDicBornesReserva` acrescenta as reservas cruas do dicionário, então
            // a reserva "0" continua numérica e entra no teste de intervalo como
            // qualquer outro número (aqui, 1 → 0).
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne> { Borne("H1", "1", 1) };
            Dictionary<int, IReadOnlyList<BorneReserva>> reservas =
                new Dictionary<int, IReadOnlyList<BorneReserva>>
                {
                    { 5, new List<BorneReserva> { new BorneReserva { Numero = "0", Ordem = 2 } } },
                };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornes, new List<int> { 3 }, reservas));
            Assert.Equal(TipoProblema.IntervaloBorneInvalido, problema.Tipo);
            Assert.Contains("1 a 0", problema.Detalhe);
        }

        [Fact]
        public void Aponta_regua_da_mascara_com_separador_inconsistente()
        {
            // O `bt13ReguaMascara` (AC1cAJLSDI): a porta tem duas réguas ("R1;R2")
            // para um só borne — o separador não fecha com a contagem de bornes.
            ModeloMascara modelo = ModeloMascara(3, "MOD");
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>
                {
                    { 3, new List<ModeloPorta> { ModeloPorta("R1;R2", "B1") } },
                };

            Problema problema = Assert.Single(
                VerificadorProjeto.VerificarReguasMascara(new[] { modelo }, portas));

            Assert.Equal(AreaVerificacao.Modelos, problema.Area);
            Assert.Equal(TipoProblema.ReguaMascara, problema.Tipo);
            Assert.Equal("Mascaras", problema.Tabela);
            Assert.Equal("MOD #3", problema.Identificador);
            Assert.Contains("R1;R2", problema.Detalhe);
            Assert.Contains("2 × 1", problema.Detalhe);
        }

        [Fact]
        public void Reguas_e_bornes_em_mesma_conta_nao_apontam()
        {
            // Duas réguas para dois bornes é o multi-régua legítimo (uma por borne).
            ModeloMascara modelo = ModeloMascara(3, "MOD");
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>
                {
                    { 3, new List<ModeloPorta> { ModeloPorta("R1;R2", "B1;B2") } },
                };

            Assert.Empty(VerificadorProjeto.VerificarReguasMascara(new[] { modelo }, portas));
        }

        [Fact]
        public void Regua_unica_para_varios_bornes_nao_aponta()
        {
            // Uma régua para N bornes é o outro caso legítimo do original.
            ModeloMascara modelo = ModeloMascara(3, "MOD");
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>
                {
                    { 3, new List<ModeloPorta> { ModeloPorta("R1", "B1;B2;B3") } },
                };

            Assert.Empty(VerificadorProjeto.VerificarReguasMascara(new[] { modelo }, portas));
        }

        [Fact]
        public void Regua_com_separador_e_sem_bornes_aponta()
        {
            // Sem bornes (o campo vazio também conta 1 item) a conta 2 × 1 não fecha.
            ModeloMascara modelo = ModeloMascara(3, "MOD");
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>
                {
                    { 3, new List<ModeloPorta> { ModeloPorta("R1;R2", null) } },
                };

            Assert.Single(VerificadorProjeto.VerificarReguasMascara(new[] { modelo }, portas));
        }

        [Fact]
        public void Regua_repetida_no_modelo_aponta_uma_vez_e_por_modelo()
        {
            // O `list` do original é por MODELO: a mesma régua só sai uma vez dentro
            // do modelo, mas cada modelo inconsistente vira uma linha própria.
            List<ModeloMascara> modelos = new List<ModeloMascara>
            {
                ModeloMascara(3, "MOD3"),
                ModeloMascara(4, "MOD4"),
            };
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>
                {
                    { 3, new List<ModeloPorta> { ModeloPorta("R1;R2", "B1"), ModeloPorta("R1;R2", "B1") } },
                    { 4, new List<ModeloPorta> { ModeloPorta("R3;R4", "B1") } },
                };

            List<Problema> problemas = VerificadorProjeto.VerificarReguasMascara(modelos, portas);

            Assert.Equal(2, problemas.Count);
            Assert.Equal("MOD3 #3", problemas[0].Identificador);
            Assert.Equal("MOD4 #4", problemas[1].Identificador);
        }

        [Fact]
        public void Regua_sem_separador_nao_aponta()
        {
            // Sem `;` no campo Régua o original nunca aponta (o `sRegua != right`).
            ModeloMascara modelo = ModeloMascara(3, "MOD");
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>
                {
                    { 3, new List<ModeloPorta> { ModeloPorta("R2", "B1;B2;B3") } },
                };

            Assert.Empty(VerificadorProjeto.VerificarReguasMascara(new[] { modelo }, portas));
        }

        [Fact]
        public void Aponta_terminal_da_porta_diferente_do_modelo()
        {
            // O `bt14PortasDiscrepantes`: o bloco `E` traz T1=9 e o modelo 1/porta 1
            // define o terminal "1".
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "1;3") };
            List<PortaNoDesenho> blocos = new List<PortaNoDesenho> { BlocoDePorta(1, 1, "H1", "T1=9") };

            Problema problema = Assert.Single(
                VerificadorProjeto.VerificarPortasDiscrepantes(modelo, blocos));

            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.PortaDiscrepante, problema.Tipo);
            Assert.Equal("Portas", problema.Tabela);
            Assert.Equal("H1", problema.Identificador);
            Assert.Contains("T1", problema.Detalhe);
            Assert.Contains("9", problema.Detalhe);
        }

        [Fact]
        public void Porta_igual_ao_modelo_nao_aponta()
        {
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "1;3") };
            List<PortaNoDesenho> blocos = new List<PortaNoDesenho> { BlocoDePorta(1, 1, "H1", "T1=1", "T2=3") };

            Assert.Empty(VerificadorProjeto.VerificarPortasDiscrepantes(modelo, blocos));
        }

        [Fact]
        public void Terminal_fora_do_modelo_aponta()
        {
            // O modelo só define um terminal; o bloco tem T2.
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "1") };
            List<PortaNoDesenho> blocos = new List<PortaNoDesenho> { BlocoDePorta(1, 1, "H1", "T2=5") };

            Problema problema = Assert.Single(
                VerificadorProjeto.VerificarPortasDiscrepantes(modelo, blocos));
            Assert.Contains("fora do modelo", problema.Detalhe);
        }

        [Fact]
        public void Aponta_borne_da_porta_diferente_do_modelo()
        {
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "", "2;4") };
            List<PortaNoDesenho> blocos = new List<PortaNoDesenho> { BlocoDePorta(1, 1, "H1", "B1=2", "B2=9") };

            Problema problema = Assert.Single(
                VerificadorProjeto.VerificarPortasDiscrepantes(modelo, blocos));
            Assert.Contains("B2", problema.Detalhe);
        }

        [Fact]
        public void Asterisco_do_modelo_e_removido_no_borne()
        {
            // O `*` do modelo marca "repete" e é removido antes de comparar.
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "", "2*") };
            List<PortaNoDesenho> blocos = new List<PortaNoDesenho> { BlocoDePorta(1, 1, "H1", "B1=2") };

            Assert.Empty(VerificadorProjeto.VerificarPortasDiscrepantes(modelo, blocos));
        }

        [Fact]
        public void Aponta_regua_da_porta_diferente_do_modelo()
        {
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "", "", "R1") };
            List<PortaNoDesenho> blocos = new List<PortaNoDesenho> { BlocoDePorta(1, 1, "H1", "R1=R2") };

            Problema problema = Assert.Single(
                VerificadorProjeto.VerificarPortasDiscrepantes(modelo, blocos));
            Assert.Contains("R1", problema.Detalhe);
        }

        [Fact]
        public void Regua_invisivel_no_borne_repetido_aponta_mesmo_igual()
        {
            // O ramo do `list`/visibilidade do original: borne marcado com `*` cuja
            // régua correspondente está invisível — aponta ainda que o texto seja igual.
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "", "1*", "") };
            PortaNoDesenho bloco = BlocoDePorta(1, 1, "H1", "B1=1", "R1=");
            foreach (AtributoPorta atributo in bloco.Atributos)
            {
                if (atributo.Tag == "R1")
                {
                    atributo.Visivel = false;
                }
            }

            Problema problema = Assert.Single(
                VerificadorProjeto.VerificarPortasDiscrepantes(modelo, new[] { bloco }));
            Assert.Contains("invisível", problema.Detalhe);
        }

        [Fact]
        public void Porta_sem_modelo_ou_sem_indice_e_ignorada()
        {
            List<ModeloPorta> modelo = new List<ModeloPorta> { PortaDoModelo(1, 1, "1") };
            List<PortaNoDesenho> blocos = new List<PortaNoDesenho>
            {
                BlocoDePorta(1, 1, "H1", "T1=9"),   // casa
                BlocoDePorta(9, 1, "H9", "T1=9"),   // modelo inexistente
                BlocoDePorta(1, 0, "H0", "T1=9"),   // indiceDaPorta 0
            };

            Assert.Single(VerificadorProjeto.VerificarPortasDiscrepantes(modelo, blocos));
        }

        [Fact]
        public void Principal_sem_lm_e_apontado()
        {
            List<Problema> problemas = VerificadorProjeto.VerificarDispositivosPrincipais(
                new[] { Principal("H1", "K1", 0, 0, "T1=1", "T2=2") });

            Problema problema = Assert.Single(problemas);
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.PrincipalIncompleto, problema.Tipo);
            Assert.Equal("Dispositivos", problema.Tabela);
            Assert.Equal("H1", problema.Identificador);
            Assert.Contains("sem LM", problema.Detalhe);
        }

        [Fact]
        public void Principal_com_terminal_indefinido_e_apontado()
        {
            // O `"0"` do atributo vira `CaracterTerminalIndefinido` (`"?"`) no texto.
            Problema problema = Assert.Single(VerificadorProjeto.VerificarDispositivosPrincipais(
                new[] { Principal("H1", "K1", 3, 7, "T1=1", "T2=0", "T3=3") }));

            Assert.Contains("terminal indefinido", problema.Detalhe);
            Assert.DoesNotContain("sem LM", problema.Detalhe);
            Assert.Contains("\"1, ?, 3\"", problema.Detalhe);
        }

        [Fact]
        public void Principal_com_LM_zero_so_no_primeiro_nao_e_apontado()
        {
            // A conjunção do original: a lista de handles exige `LM1 == 0 && LM2 == 0`.
            Assert.Empty(VerificadorProjeto.VerificarDispositivosPrincipais(
                new[] { Principal("H1", "K1", 0, 5, "T1=1") }));
            Assert.Empty(VerificadorProjeto.VerificarDispositivosPrincipais(
                new[] { Principal("H1", "K1", 5, 0, "T1=1") }));
        }

        [Fact]
        public void Principal_completo_nao_aponta()
        {
            Assert.Empty(VerificadorProjeto.VerificarDispositivosPrincipais(
                new[] { Principal("H1", "K1", 3, 7, "T1=1", "T2=2") }));
        }

        [Fact]
        public void Terminais_do_principal_saem_ordenados_por_tag_e_sem_os_B()
        {
            // Ordinal pela tag (`T1` < `T2`), o `B1` fica de fora e o vazio vira `"?"`.
            Problema problema = Assert.Single(VerificadorProjeto.VerificarDispositivosPrincipais(
                new[] { Principal("H1", "K1", 0, 0, "T2=B", "T1=A", "B1=X", "T3=") }));

            Assert.Contains("\"A, B, ?\"", problema.Detalhe);
        }

        [Fact]
        public void Principal_repetido_aponta_uma_vez()
        {
            Assert.Single(VerificadorProjeto.VerificarDispositivosPrincipais(new[]
            {
                Principal("H1", "K1", 0, 0, "T1=1"),
                Principal("H1", "K1", 0, 0, "T1=2"),
            }));
        }

        [Fact]
        public void Auxiliar_NA_com_terminal_divergente_aponta()
        {
            List<Problema> problemas = VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "NA", 1, "T1=9", "T2=2") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "")));

            Problema problema = Assert.Single(problemas);
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.AuxiliarDivergente, problema.Tipo);
            Assert.Equal("Auxiliares", problema.Tabela);
            Assert.Equal("H2", problema.Identificador);
            Assert.Contains("T1 \"9\" ≠ modelo \"1\"", problema.Detalhe);
            Assert.DoesNotContain("T2", problema.Detalhe);
        }

        [Fact]
        public void Auxiliar_com_terminais_iguais_ao_contato_nao_aponta()
        {
            // Terminais diferentes do modelo o põem na lista do original, mas o ramo
            // `NA`/`NA` compara o `T3` do bloco com **vazio** — e ele está vazio.
            Assert.Empty(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "NA", 1, "T1=1", "T2=2") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "3"))));
        }

        [Fact]
        public void Auxiliar_RV_com_bloco_RV_compara_os_tres_terminais()
        {
            Problema problema = Assert.Single(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "RV", 3, "T1=1", "T2=2", "T3=3") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "4"))));

            Assert.Contains("T3 \"3\" ≠ modelo \"4\"", problema.Detalhe);
        }

        [Fact]
        public void Auxiliar_RV_com_bloco_NF_compara_so_T1_e_T2()
        {
            // `RV` do contato contra `NF` do bloco: o `T3` divergente não é olhado.
            Assert.Empty(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "NF", 3, "T1=1", "T2=2", "T3=9") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "7"))));
        }

        [Fact]
        public void Auxiliar_RV_com_bloco_NA_compara_T2_com_o_T3_do_modelo()
        {
            // O ramo `NA` do bloco: `T1` contra o primeiro e `T2` contra o **terceiro**
            // terminal do modelo (o `text4 × text8` do original).
            Problema problema = Assert.Single(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "NA", 3, "T1=1", "T2=2") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "9"))));

            Assert.Contains("T2 \"2\" ≠ modelo \"9\"", problema.Detalhe);
        }

        [Fact]
        public void Auxiliar_tipo_de_bloco_desconhecido_nao_aponta()
        {
            Assert.Empty(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "XX", 3, "T1=1", "T2=9") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "3"))));
        }

        [Fact]
        public void Auxiliar_NF_com_bloco_NA_nao_aponta()
        {
            Assert.Empty(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "NA", 2, "T1=1", "T2=9") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "3"))));
        }

        [Fact]
        public void Auxiliar_sem_principal_conhecido_nao_aponta()
        {
            Assert.Empty(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H9", "NA", 1, "T1=1", "T2=9") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "3"))));
        }

        [Fact]
        public void Auxiliar_ignora_maiusculas_no_tipo()
        {
            Problema problema = Assert.Single(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "na", 3, "T1=1", "T2=9") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", "3"))));

            Assert.Contains("T2", problema.Detalhe);
        }

        [Fact]
        public void Auxiliar_NA_reclama_do_T3_do_bloco_que_deveria_estar_vazio()
        {
            // No ramo `NA`/`NA` o `T3` do bloco é comparado com **vazio**.
            Problema problema = Assert.Single(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "NA", 1, "T1=1", "T2=2", "T3=3") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(1, "1", "2", ""))));

            Assert.Contains("T3 \"3\" ≠ modelo \"\"", problema.Detalhe);
        }

        [Fact]
        public void Auxiliar_sem_contato_no_dicionario_compara_com_vazio()
        {
            Problema problema = Assert.Single(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                new[] { Auxiliar("H2", "H1", "NA", 1, "T1=1") },
                new[] { Principal("H1", "K1", 3, 7, "T1=1") },
                Contatos(1, Contato(7, "1", "2", "3"))));

            Assert.Contains("≠ modelo \"\"", problema.Detalhe);
        }

        [Fact]
        public void Aponta_mascara_duplicada()
        {
            // O `bt12AMao` ("Copy made by hand"): dois blocos `M` com a mesma
            // identidade (painel/nome/alt), no mesmo painel em uso.
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Mascara("M1", 3, "R1"),
                Mascara("M2", 3, "R1"),
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.BlocoDuplicado, problema.Tipo);
            Assert.Equal("Blocos", problema.Tabela);
            Assert.Equal("M2", problema.Identificador);
            Assert.Contains("Mask", problema.Detalhe);
        }

        [Fact]
        public void Mascara_complementar_nao_aponta()
        {
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Mascara("M1", 3, "R1"),
                Mascara("M2", 3, "R1"),
            };
            blocos[1].Complementar = true;

            Assert.Empty(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
        }

        [Fact]
        public void Bloco_duplicado_de_painel_fora_de_uso_nao_aponta()
        {
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Mascara("M1", 3, "R1"),
                Mascara("M2", 3, "R1"),
            };

            Assert.Empty(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 9 }));
        }

        [Fact]
        public void Aponta_dispositivo_duplicado()
        {
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Bloco("P", "P1", 3, "K1"),
                Bloco("P", "P2", 3, "K1"),
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
            Assert.Contains("Main Device", problema.Detalhe);
        }

        [Fact]
        public void Aponta_porta_duplicada_da_mesma_mascara()
        {
            // A chave do `E` é a identidade da **máscara** + o índice da porta.
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Porta("E1", 3, "M1", 2),
                Porta("E2", 3, "M1", 2),
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
            Assert.Contains("Door", problema.Detalhe);
        }

        [Fact]
        public void Porta_sem_indice_nao_aponta()
        {
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Porta("E1", 3, "M1", 0),
                Porta("E2", 3, "M1", 0),
            };

            Assert.Empty(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
        }

        [Fact]
        public void Aponta_borne_duplicado()
        {
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Terminal("B1", 3, 5, "11"),
                Terminal("B2", 3, 5, "11"),
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
            Assert.Contains("Terminal", problema.Detalhe);
        }

        [Fact]
        public void Borne_sem_numero_duplicado_nao_aponta()
        {
            // O desenho grava "sem número" como "?"/"0"; o original não aponta esses.
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Terminal("B1", 3, 5, "0"),
                Terminal("B2", 3, 5, "0"),
            };

            Assert.Empty(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
        }

        [Fact]
        public void Aponta_auxiliar_duplicado()
        {
            // O filtro do auxiliar usa o painel do último borne: sem um borne antes,
            // o painel seria 0 e nada apareceria (o bug do original).
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Terminal("B1", 3, 5, "1"),
                Auxiliar("A1", 3, "K1", 7),
                Auxiliar("A2", 3, "K1", 7),
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
            Assert.Contains("Auxiliary Contacts", problema.Detalhe);
        }

        [Fact]
        public void Auxiliar_usa_o_painel_do_ultimo_borne_no_filtro()
        {
            // O bug do original, reproduzido: o filtro do auxiliar usa o `indexPainel`
            // do último borne processado — não o painel do bob (3).
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Terminal("B1", 9, 5, "1"),
                Auxiliar("A1", 3, "K1", 7),
                Auxiliar("A2", 3, "K1", 7),
            };

            Assert.Single(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 9 }));
            Assert.Empty(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
        }

        [Fact]
        public void Aponta_definicao_duplicada()
        {
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Definicao("T1", 3, "4D642", 53, 2),
                Definicao("T2", 3, "4D642", 53, 2),
            };

            Problema problema = Assert.Single(VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 }));
            Assert.Contains("Definition", problema.Detalhe);
        }

        [Fact]
        public void Tres_copias_apontam_as_duas_ultimas()
        {
            // O original aponta toda cópia a partir da segunda (a chave fica no `list`).
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>
            {
                Mascara("M1", 3, "R1"),
                Mascara("M2", 3, "R1"),
                Mascara("M3", 3, "R1"),
            };

            List<Problema> problemas = VerificadorProjeto.VerificarBlocosDuplicados(blocos, new[] { 3 });
            Assert.Equal(2, problemas.Count);
            Assert.Equal("M2", problemas[0].Identificador);
            Assert.Equal("M3", problemas[1].Identificador);
        }

        private static BlocoDuplicavel Bloco(string tipo, string handle, short painel, string nome1, string nome2 = null, string alternativo = null)
        {
            return new BlocoDuplicavel
            {
                Tipo = tipo,
                Handle = handle,
                Pagina = "8",
                Painel = painel,
                Nome1 = nome1,
                Nome2 = nome2,
                Alternativo = alternativo,
            };
        }

        private static BlocoDuplicavel Mascara(string handle, short painel, string nome1)
        {
            return Bloco("M", handle, painel, nome1);
        }

        private static BlocoDuplicavel Porta(string handle, short painel, string nome1, int indiceDaPorta)
        {
            BlocoDuplicavel bloco = Bloco("E", handle, painel, nome1);
            bloco.IndiceDaPorta = indiceDaPorta;
            return bloco;
        }

        private static BlocoDuplicavel Terminal(string handle, short painel, int indiceRegua, string numero)
        {
            BlocoDuplicavel bloco = Bloco("B", handle, painel, null);
            bloco.IndiceRegua = indiceRegua;
            bloco.Numero = numero;
            return bloco;
        }

        private static BlocoDuplicavel Auxiliar(string handle, short painel, string nome1, int indexContato)
        {
            BlocoDuplicavel bloco = Bloco("A", handle, painel, nome1);
            bloco.IndexContato = indexContato;
            return bloco;
        }

        private static BlocoDuplicavel Definicao(string handle, short painel, string handleMascara, int indiceModelo, int indiceDaPorta)
        {
            BlocoDuplicavel bloco = Bloco("D", handle, painel, null);
            bloco.HandleMascara = handleMascara;
            bloco.IndiceModelo = indiceModelo;
            bloco.IndiceDaPorta = indiceDaPorta;
            return bloco;
        }

        /// <summary>Um dispositivo `P` do desenho, com os terminais em <c>T#=valor</c>.</summary>
        private static DispositivoFiacao Principal(string handle, string nome, int lm1, int lm2, params string[] terminais)
        {
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "P",
                Handle = handle,
                Nome1 = nome,
                Painel = 3,
                Lm1 = lm1,
                Lm2 = lm2,
            };

            AcrescentarTerminais(dispositivo, terminais);
            return dispositivo;
        }

        /// <summary>
        /// Um bloco auxiliar `A` do desenho: o <c>bob</c> (dispositivo cujo contato ele
        /// representa), o tipo do contato do XData e o nome do bloco — de cujo 5º
        /// caractere sai o <c>TipoBlocoUsado</c> (<c>Mid(nome, 5, 2)</c>).
        /// </summary>
        private static DispositivoFiacao Auxiliar(
            string handle, string bob, string tipoDoBloco, short tipoDoContato, params string[] terminais)
        {
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "A",
                Handle = handle,
                HandleBob = bob,
                Nome1 = "A1",
                Painel = 3,
                IndexModelo = 1,
                IndiceDaPorta = 1,
                NomeBloco = "ELET" + tipoDoBloco + "0",
                TipoDoContato = tipoDoContato,
            };

            AcrescentarTerminais(dispositivo, terminais);
            return dispositivo;
        }

        private static void AcrescentarTerminais(DispositivoFiacao dispositivo, string[] terminais)
        {
            foreach (string item in terminais)
            {
                int separador = item.IndexOf('=');
                dispositivo.Terminais.Add(new TerminalDispositivo
                {
                    Atributo = item.Substring(0, separador),
                    Texto = item.Substring(separador + 1),
                });
            }
        }

        private static Dictionary<int, IReadOnlyList<ContatoAuxiliar>> Contatos(int indiceModelo, params ContatoAuxiliar[] contatos)
        {
            return new Dictionary<int, IReadOnlyList<ContatoAuxiliar>>
            {
                { indiceModelo, new List<ContatoAuxiliar>(contatos) },
            };
        }

        private static ContatoAuxiliar Contato(int indice, string t1, string t2, string t3)
        {
            return new ContatoAuxiliar { Indice = indice, T1 = t1, T2 = t2, T3 = t3 };
        }

        private static ModeloPorta PortaDoModelo(int modelo, int porta, string terminais, string bornes = "", string regua = "")
        {
            return new ModeloPorta
            {
                IndiceModelo = modelo,
                IndiceDaPorta = porta,
                NomeModelo = "MOD" + modelo,
                Terminais = terminais,
                Bornes = bornes,
                Regua = regua,
            };
        }

        private static PortaNoDesenho BlocoDePorta(int modelo, int porta, string handle, params string[] atributos)
        {
            PortaNoDesenho bloco = new PortaNoDesenho
            {
                Handle = handle,
                IndiceModelo = modelo,
                IndiceDaPorta = porta,
            };

            foreach (string item in atributos)
            {
                int separador = item.IndexOf('=');
                bloco.Atributos.Add(new AtributoPorta
                {
                    Tag = item.Substring(0, separador),
                    Texto = item.Substring(separador + 1),
                    Visivel = true,
                });
            }

            return bloco;
        }

        private static ModeloMascara ModeloMascara(int indice, string nome)
        {
            return new ModeloMascara { Indice = indice, Nome = nome };
        }

        private static ModeloPorta ModeloPorta(string regua, string bornes)
        {
            return new ModeloPorta
            {
                IndiceDaPorta = 1,
                IndiceModelo = 3,
                NomeModelo = "MOD",
                Regua = regua,
                Bornes = bornes,
            };
        }

        /// <summary>
        /// Um borne do desenho como o <see cref="PontoBorne.DeBorne"/> monta: o
        /// <c>Terminal</c> já é o número com o complemento colado.
        /// </summary>
        private static PontoBorne Borne(string handle, string numero, double ordem, string complemento = null)
        {
            return new PontoBorne
            {
                Handle = handle,
                IndiceRegua = 5,
                Numero = numero,
                Terminal = string.IsNullOrEmpty(complemento) ? numero : numero + complemento,
                Ordem = ordem,
            };
        }

        private static List<TypedXData> RegistrosRegua()
        {
            List<TypedXData> valores = new List<TypedXData>();
            // Índice 0 é o cabeçalho (maior indexRegua) — como o produto grava.
            valores.Add(new TypedXData(90, 5));
            valores.Add(new TypedXData(1071, 5));
            valores.Add(new TypedXData(1000, "R1"));
            valores.Add(new TypedXData(1000, "ALT1"));
            valores.Add(new TypedXData(1071, 3));
            for (int i = 0; i < 6; i++)
            {
                valores.Add(new TypedXData(1071, 0));
            }

            return valores;
        }
    }
}
