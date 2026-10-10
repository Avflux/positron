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
