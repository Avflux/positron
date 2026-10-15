using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmGerenciadorMateriais</c> (o comando <c>GERLM</c>): a grade
    /// <c>DGMateriais</c> com o **catálogo de materiais** (<c>Materiais</c>), na ordem do original
    /// (<c>order by CodigoInterno</c>), o <c>MostraSelecionado</c> e — desde a rodada 149 — a
    /// **escrita**: os quatro botões que trabalham na tela.
    ///
    /// O que cada botão faz (o corpo do original, na ordem em que ele o executa):
    ///
    /// - **Adiciona Material** (<c>OYXpWrD09De</c>): as seis caixas vazias não fazem nada; um código
    ///   que já está na grade só seleciona a linha; senão o código sai do
    ///   <see cref="CatalogoDeMateriais.ProximoCodigo"/> (o digitado, quando é número; senão o maior
    ///   da grade mais um), a linha entra no fim com a marca **`A`** e as seis primeiras células
    ///   ficam verdes;
    /// - **Edita Material Selecionado** (<c>KcbpW9CNreY</c>): a linha selecionada recebe das caixas
    ///   **só os campos que mudaram** (comparação sem caixa, como o `TextCompare` do VB), cada um
    ///   pintado de amarelo, e a linha passa a **`E`**;
    /// - **Apaga Material Selecionado** (<c>LNDpWzth4ys</c>): a linha sai da grade e o código interno
    ///   entra na lista de apagados;
    /// - **Salvar Alterações** (<c>iaGppGHMjAT</c>): o
    ///   <see cref="CatalogoDeMateriais.PlanoDeGravacao"/> da grade (apagados, `A` = remover +
    ///   adicionar, `E` = editar) vai para o banco **na ordem do original**, a grade é recarregada e
    ///   as caixas são limpas.
    ///
    /// **Duas diferenças deliberadas** (as duas registradas no RUNBOOK, rodada 149): o original
    /// pergunta "Salvar Alterações?" num `MsgBox` **ao fechar** a janela (e o `sim` chama o mesmo
    /// `iaGppGHMjAT`) — o recoder **não salva ao fechar**, só avisa na linha de comando; e a linha
    /// recém-acrescentada tem `0` na coluna do índice original, que o original joga na lista de
    /// apagados ao ser removida da tela (`RemoveMaterial(0)`) — aqui o `0` **não** entra na lista,
    /// porque apagar um material de código 0 seria apagar outro material.
    ///
    /// **Importar/Exportar do Excel** continuam **desabilitados com o motivo na dica** (interop).
    ///
    /// **Como a tela é medida num script:** não há clique, então <c>POSITRON_LM_MATERIAL</c> (os seis
    /// campos, separados por `;`), <c>POSITRON_LM_ACAO</c> (`adicionar`, `editar` ou `apagar`) e
    /// <c>POSITRON_LM_SALVAR</c> (=1) rodam, ao abrir, a **mesma** ação do clique — o gancho do
    /// harness, como o <c>POSITRON_ANALISAR</c> das telas de compilação. A receita está no RUNBOOK.
    /// </summary>
    internal sealed class LigacaoDoFrmGerenciadorMateriais : LigacaoDeMateriais
    {
        /// <summary>O estado de edição da janela — o `QH3pp205How` (apagados) e o `xXlppeqw8lg` (alterado) do original.</summary>
        private sealed class EstadoDaGrade
        {
            internal readonly List<int> Apagados = new List<int>();

            internal bool Alterado;
        }

        public override string NomeDaTela
        {
            get { return "frmGerenciadorMateriais"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "DGMateriais");
            Button salvar = ControlesDaTela.Achar<Button>(janela, "btSalvar");

            TextosDoOriginal(janela);

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            List<MaterialDoCatalogo> materiais = Catalogo(config);
            PreencherGrade(grade, materiais);

            EstadoDaGrade estado = new EstadoDaGrade();

            Ligar(ControlesDaTela.Achar<Button>(janela, "BTAdicionaMaterial"),
                (origem, evento) => Plugin.Escrever(Adicionar(janela, grade, estado, salvar)));
            Ligar(ControlesDaTela.Achar<Button>(janela, "BTEditaMaterial"),
                (origem, evento) => Plugin.Escrever(Editar(janela, grade, estado, salvar)));
            Ligar(ControlesDaTela.Achar<Button>(janela, "BTApagaMaterial"),
                (origem, evento) => Plugin.Escrever(Apagar(janela, grade, estado, salvar)));
            Ligar(salvar,
                (origem, evento) => Plugin.Escrever(Gravar(janela, grade, estado, salvar, config)));

            if (grade != null)
            {
                grade.SelectionChanged += (origem, evento) => MostraSelecionado(janela, grade);

                // Num script a tela não é *mostrada*, então a seleção programática não dispara o
                // evento: a primeira linha é mostrada explicitamente, como o original faz ao clicar.
                if (grade.Rows.Count > 0)
                {
                    grade.Rows[0].Selected = true;
                }

                MostraSelecionado(janela, grade);
            }

            // O original pergunta ao fechar (o `MsgBox` do finalizador); o recoder não salva sozinho.
            if (janela != null)
            {
                janela.FormClosing += (origem, evento) => AvisarAoFechar(estado);
            }

            Motivos(janela);

            Plugin.Escrever("GERLM: " + materiais.Count + " material(is) no catálogo"
                + (materiais.Count > 0 ? " (\"" + materiais[0].DescricaoResumida + "\" no código "
                    + materiais[0].CodigoInterno + ")" : " — a tabela Materiais está vazia")
                + "; grade com " + (grade == null ? 0 : grade.Columns.Count) + " coluna(s); "
                + "Adiciona/Edita/Apaga/Salvar ligados, o Excel desabilitado.");

            GanchoDoHarness(janela, grade, estado, salvar, config);
        }

        /// <summary>Os textos que o construtor do original aplica por cima dos do designer.</summary>
        private static void TextosDoOriginal(Form janela)
        {
            Texto(janela, "GroupBoxMateriais", "Materiais");
            Texto(janela, "GroupBoxAdiciona", string.Empty);
            Texto(janela, "LBDescResumida", "Descrição Resumida");
            Texto(janela, "LBDescCompleta", "Descrição Completa");
            Texto(janela, "LBCodInterno", "Código Interno");
            Texto(janela, "LBCodCliente", "Código do Cliente");
            Texto(janela, "LBModelo", "Modelo");
            Texto(janela, "LBFabricante", "Fabricante");

            Dica(janela, "BTAdicionaMaterial", "Adiciona Material");
            Dica(janela, "BTEditaMaterial", "Edita Material Selecionado");
            Dica(janela, "BTApagaMaterial", "Apaga Material Selecionado");
            Dica(janela, "BTImportaEX", "Importa do Excel");
            Dica(janela, "BTExportaEX", "Exporta para o Excel");
        }

        /// <summary>
        /// As nove colunas do <c>formataDG</c> do original e as linhas do catálogo no **mesmo formato**
        /// do <c>CarregaListaMateriaisDoDG</c>: `#` e `IndiceOriginal` com o código interno, `IndiceEL`
        /// com a chave da tabela, e `Ação` vazia (a marca `A`/`E` é da edição desta rodada).
        /// </summary>
        private static void PreencherGrade(DataGridView grade, List<MaterialDoCatalogo> materiais)
        {
            if (grade == null)
            {
                return;
            }

            grade.Columns.Clear();
            grade.Columns.Add("CodigoInterno", "#");
            grade.Columns.Add("CodigoCliente", "Cod.Cliente");
            grade.Columns.Add("Modelo", "Modelo");
            grade.Columns.Add("Fabricante", "Fabricante");
            grade.Columns.Add("DescricaoResumida", "DescricaoResumida");
            grade.Columns.Add("DescricaoCompleta", "DescricaoCompleta");
            grade.Columns.Add("IndiceOriginal", "IndiceOriginal");
            grade.Columns.Add("Ação", "Ação");
            grade.Columns.Add("IndiceEL", "IndiceEL");
            grade.ColumnHeadersVisible = true;

            grade.Rows.Clear();
            foreach (MaterialDoCatalogo material in materiais)
            {
                grade.Rows.Add(
                    material.CodigoInterno,
                    material.CodigoCliente,
                    material.Modelo,
                    material.Fabricante,
                    material.DescricaoResumida,
                    material.DescricaoCompleta,
                    material.CodigoInterno,
                    string.Empty,
                    material.Indice);
            }
        }

        // ------------------------------------------------------------------ as quatro acoes da tela

        /// <summary>O clique do <c>BTAdicionaMaterial</c> — o <c>OYXpWrD09De</c>.</summary>
        private static string Adicionar(Form janela, DataGridView grade, EstadoDaGrade estado, Button salvar)
        {
            if (grade == null)
            {
                return "GERLM: a grade não está na tela.";
            }

            string digitado = LerCaixa(janela, "TBCodInterno");
            string cliente = LerCaixa(janela, "TBCodCliente");
            string modelo = LerCaixa(janela, "TBModelo");
            string fabricante = LerCaixa(janela, "TBFabricante");
            string resumida = LerCaixa(janela, "TBDescResumida");
            string completa = LerCaixa(janela, "TBDescCompleta");

            if (string.IsNullOrEmpty(digitado) && string.IsNullOrEmpty(cliente) && string.IsNullOrEmpty(modelo)
                && string.IsNullOrEmpty(fabricante) && string.IsNullOrEmpty(resumida) && string.IsNullOrEmpty(completa))
            {
                return "GERLM: nada a adicionar — as seis caixas estão vazias.";
            }

            // Um código que já está na grade só seleciona a linha (o laço com o `ConditionalCompareObjectEqual`).
            int informado;
            bool temNumero = int.TryParse(digitado.Trim(), out informado);
            if (digitado.Trim().Length > 0)
            {
                foreach (DataGridViewRow linha in grade.Rows)
                {
                    if ((temNumero && CodigoDaLinha(linha, 0) == informado)
                        || (!temNumero && string.Equals(Celula(linha, 0), digitado.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        linha.Selected = true;
                        return "GERLM: o código " + digitado.Trim() + " já está na grade — linha selecionada.";
                    }
                }
            }

            int novo = CatalogoDeMateriais.ProximoCodigo(CodigosDaGrade(grade), digitado);
            TextoDaCaixa(janela, "TBCodInterno", novo.ToString(CultureInfo.InvariantCulture));

            int indice = grade.Rows.Add(novo, cliente, modelo, fabricante, resumida, completa, 0, "A", 0);
            for (int coluna = 0; coluna <= 5; coluna++)
            {
                grade.Rows[indice].Cells[coluna].Style.BackColor = Color.LightGreen;
            }

            grade.Rows[indice].Selected = true;
            MostraSelecionado(janela, grade);
            MarcarAlterado(salvar, estado);

            return "GERLM: material " + novo + " \"" + resumida + "\" marcado para acrescentar (A).";
        }

        /// <summary>O clique do <c>BTEditaMaterial</c> — o <c>KcbpW9CNreY</c>.</summary>
        private static string Editar(Form janela, DataGridView grade, EstadoDaGrade estado, Button salvar)
        {
            if (grade == null || grade.SelectedRows.Count == 0)
            {
                return "GERLM: escolha a linha a editar na grade.";
            }

            DataGridViewRow linha = grade.SelectedRows[0];
            string[] dasCaixas = CaixasDoMaterial(janela);
            List<string> mudadas = new List<string>();

            // As colunas 1..5 são, na ordem, os cinco campos editáveis.
            for (int i = 0; i < dasCaixas.Length; i++)
            {
                int coluna = i + 1;
                if (coluna >= linha.Cells.Count)
                {
                    break;
                }

                string atual = Celula(linha, coluna);
                if (string.Equals(atual, dasCaixas[i], StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                linha.Cells[coluna].Value = dasCaixas[i];
                linha.Cells[7].Value = "E";
                linha.Cells[coluna].Style.BackColor = Color.Yellow;
                mudadas.Add(NomeDoCampo(i));
            }

            MarcarAlterado(salvar, estado);

            return mudadas.Count == 0
                ? "GERLM: a linha " + CodigoDaLinha(linha, 0) + " não mudou (nada a editar)."
                : "GERLM: linha " + CodigoDaLinha(linha, 0) + " marcada para editar (E) — "
                    + string.Join(", ", mudadas.ToArray()) + ".";
        }

        /// <summary>O clique do <c>BTApagaMaterial</c> — o <c>LNDpWzth4ys</c>.</summary>
        private static string Apagar(Form janela, DataGridView grade, EstadoDaGrade estado, Button salvar)
        {
            if (grade == null || grade.SelectedRows.Count == 0)
            {
                return "GERLM: escolha a linha a apagar na grade.";
            }

            DataGridViewRow linha = grade.SelectedRows[0];
            int codigo = CodigoDaLinha(linha, 6);
            int posicao = linha.Index;
            grade.Rows.RemoveAt(posicao);

            // O original empurra o `Cells[6]` (o código interno) para a lista de apagados em qualquer
            // linha; aqui o `0` da linha recém-acrescentada **não** entra (apagar o material de
            // código 0 seria apagar outro material) — desvio registrado no RUNBOOK.
            if (codigo != 0)
            {
                estado.Apagados.Add(codigo);
            }

            MarcarAlterado(salvar, estado);

            return "GERLM: linha " + codigo + " tirada da grade"
                + (codigo == 0 ? " (ainda não gravada — nada a apagar no banco)" : " (entra na lista de apagados)") + ".";
        }

        /// <summary>O clique do <c>btSalvar</c> — o <c>iaGppGHMjAT</c>.</summary>
        private static string Gravar(
            Form janela,
            DataGridView grade,
            EstadoDaGrade estado,
            Button salvar,
            ConfiguracaoPositron config)
        {
            if (grade == null)
            {
                return "GERLM: a grade não está na tela.";
            }

            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return "GERLM: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).";
            }

            List<OperacaoNoCatalogo> plano =
                CatalogoDeMateriais.PlanoDeGravacao(LinhasDaGrade(grade), estado.Apagados);
            if (plano.Count == 0)
            {
                return "GERLM: não há alteração para salvar.";
            }

            int removidos = 0;
            int acrescentados = 0;
            int editados = 0;
            try
            {
                ProjectStore store = new ProjectStore(config.Banco);
                foreach (OperacaoNoCatalogo operacao in plano)
                {
                    switch (operacao.Tipo)
                    {
                        case TipoDeOperacaoNoCatalogo.Remover:
                            removidos += store.RemoverMaterial(operacao.Material.CodigoInterno);
                            break;
                        case TipoDeOperacaoNoCatalogo.Adicionar:
                            store.AdicionarMaterial(operacao.Material);
                            acrescentados++;
                            break;
                        default:
                            store.EditarMaterial(operacao.Material);
                            editados++;
                            break;
                    }
                }
            }
            catch (Exception erro)
            {
                return "GERLM: falhou ao gravar o catálogo — " + erro.Message;
            }

            PreencherGrade(grade, Catalogo(config));
            if (grade.Rows.Count > 0)
            {
                grade.Rows[0].Selected = true;
            }

            LimparCaixas(janela);
            estado.Apagados.Clear();
            estado.Alterado = false;
            if (salvar != null)
            {
                salvar.Enabled = false;
            }

            return "GERLM: catálogo gravado — " + removidos + " removida(s), " + acrescentados
                + " acrescentada(s), " + editados + " editada(s); a grade foi recarregada.";
        }

        /// <summary>O aviso do fechamento — o `MsgBox` "Salvar Alterações?" do finalizador do original.</summary>
        private static void AvisarAoFechar(EstadoDaGrade estado)
        {
            if (estado == null || !estado.Alterado)
            {
                return;
            }

            Plugin.Escrever("GERLM: há alteração(ões) não salva(s) na grade — o original pergunta num "
                + "MsgBox ao fechar; o recoder não salva sozinho (use Salvar).");
        }

        // ------------------------------------------------------------------ o gancho do harness

        /// <summary>
        /// O gancho do harness (um script não clica nos botões): <c>POSITRON_LM_MATERIAL</c> seleciona
        /// a linha do código e preenche as seis caixas (nesta ordem — a seleção escreveria por cima
        /// do digitado), <c>POSITRON_LM_ACAO</c> roda a mesma ação do
        /// clique (`adicionar` é o padrão quando só o material vem) e <c>POSITRON_LM_SALVAR</c>=1
        /// grava. Sem nenhuma variável, nada acontece.
        /// </summary>
        private static void GanchoDoHarness(
            Form janela,
            DataGridView grade,
            EstadoDaGrade estado,
            Button salvar,
            ConfiguracaoPositron config)
        {
            string material = Environment.GetEnvironmentVariable("POSITRON_LM_MATERIAL");
            string acao = Environment.GetEnvironmentVariable("POSITRON_LM_ACAO");
            bool gravar = Ligado("POSITRON_LM_SALVAR");

            if (string.IsNullOrEmpty(material) && string.IsNullOrEmpty(acao) && !gravar)
            {
                return;
            }

            if (!string.IsNullOrEmpty(material))
            {
                string[] campos = material.Split(';');

                // A seleção vem **antes** das caixas: o `MostraSelecionado` da seleção sobrescreve
                // os seis campos com a linha, e num script é o material digitado que tem de
                // sobreviver — senão um `editar` nunca acharia diferença (o original digita depois
                // de clicar).
                int codigo;
                if (grade != null && int.TryParse(Campo(campos, 0), out codigo))
                {
                    foreach (DataGridViewRow linha in grade.Rows)
                    {
                        if (CodigoDaLinha(linha, 0) == codigo)
                        {
                            linha.Selected = true;
                            MostraSelecionado(janela, grade);
                            break;
                        }
                    }
                }

                TextoDaCaixa(janela, "TBCodInterno", Campo(campos, 0));
                TextoDaCaixa(janela, "TBCodCliente", Campo(campos, 1));
                TextoDaCaixa(janela, "TBModelo", Campo(campos, 2));
                TextoDaCaixa(janela, "TBFabricante", Campo(campos, 3));
                TextoDaCaixa(janela, "TBDescResumida", Campo(campos, 4));
                TextoDaCaixa(janela, "TBDescCompleta", Campo(campos, 5));
            }

            if (string.IsNullOrEmpty(acao))
            {
                acao = string.IsNullOrEmpty(material) ? string.Empty : "adicionar";
            }

            if (string.Equals(acao, "editar", StringComparison.OrdinalIgnoreCase))
            {
                Plugin.Escrever(Editar(janela, grade, estado, salvar));
            }
            else if (string.Equals(acao, "apagar", StringComparison.OrdinalIgnoreCase))
            {
                Plugin.Escrever(Apagar(janela, grade, estado, salvar));
            }
            else if (string.Equals(acao, "adicionar", StringComparison.OrdinalIgnoreCase))
            {
                Plugin.Escrever(Adicionar(janela, grade, estado, salvar));
            }

            if (gravar)
            {
                Plugin.Escrever(Gravar(janela, grade, estado, salvar, config));
            }
        }

        // ------------------------------------------------------------------ os ajudantes

        private static void Ligar(Button botao, EventHandler acao)
        {
            if (botao != null)
            {
                botao.Click += acao;
            }
        }

        private static void MarcarAlterado(Button salvar, EstadoDaGrade estado)
        {
            estado.Alterado = true;
            if (salvar != null)
            {
                salvar.Enabled = true;
            }
        }

        private static void LimparCaixas(Form janela)
        {
            TextoDaCaixa(janela, "TBCodInterno", string.Empty);
            TextoDaCaixa(janela, "TBCodCliente", string.Empty);
            TextoDaCaixa(janela, "TBModelo", string.Empty);
            TextoDaCaixa(janela, "TBFabricante", string.Empty);
            TextoDaCaixa(janela, "TBDescResumida", string.Empty);
            TextoDaCaixa(janela, "TBDescCompleta", string.Empty);
        }

        /// <summary>Os cinco campos editáveis na ordem das colunas 1..5 (código do cliente, modelo, fabricante, descrição resumida e completa).</summary>
        private static string[] CaixasDoMaterial(Form janela)
        {
            return new[]
            {
                LerCaixa(janela, "TBCodCliente"),
                LerCaixa(janela, "TBModelo"),
                LerCaixa(janela, "TBFabricante"),
                LerCaixa(janela, "TBDescResumida"),
                LerCaixa(janela, "TBDescCompleta"),
            };
        }

        private static string NomeDoCampo(int indice)
        {
            switch (indice)
            {
                case 0: return "código do cliente";
                case 1: return "modelo";
                case 2: return "fabricante";
                case 3: return "descrição resumida";
                default: return "descrição completa";
            }
        }

        private static List<int> CodigosDaGrade(DataGridView grade)
        {
            List<int> codigos = new List<int>();
            if (grade == null)
            {
                return codigos;
            }

            foreach (DataGridViewRow linha in grade.Rows)
            {
                codigos.Add(CodigoDaLinha(linha, 0));
            }

            return codigos;
        }

        /// <summary>A grade no estado em que o plano de gravação a lê (os seis campos + a marca da coluna 7).</summary>
        private static List<LinhaDoCatalogoNaGrade> LinhasDaGrade(DataGridView grade)
        {
            List<LinhaDoCatalogoNaGrade> linhas = new List<LinhaDoCatalogoNaGrade>();
            if (grade == null)
            {
                return linhas;
            }

            foreach (DataGridViewRow linha in grade.Rows)
            {
                linhas.Add(new LinhaDoCatalogoNaGrade
                {
                    CodigoInterno = CodigoDaLinha(linha, 0),
                    CodigoCliente = Celula(linha, 1),
                    Modelo = Celula(linha, 2),
                    Fabricante = Celula(linha, 3),
                    DescricaoResumida = Celula(linha, 4),
                    DescricaoCompleta = Celula(linha, 5),
                    Marca = Celula(linha, 7),
                });
            }

            return linhas;
        }

        private static int CodigoDaLinha(DataGridViewRow linha, int coluna)
        {
            int codigo;
            return int.TryParse(Celula(linha, coluna), out codigo) ? codigo : 0;
        }

        /// <summary>O <c>MostraSelecionado</c> do original: as seis caixas do material recebem a linha selecionada.</summary>
        private static void MostraSelecionado(Form janela, DataGridView grade)
        {
            if (grade == null || grade.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow linha = grade.SelectedRows[0];
            TextoDaCaixa(janela, "TBCodInterno", Celula(linha, 0));
            TextoDaCaixa(janela, "TBCodCliente", Celula(linha, 1));
            TextoDaCaixa(janela, "TBModelo", Celula(linha, 2));
            TextoDaCaixa(janela, "TBFabricante", Celula(linha, 3));
            TextoDaCaixa(janela, "TBDescResumida", Celula(linha, 4));
            TextoDaCaixa(janela, "TBDescCompleta", Celula(linha, 5));
        }

        private static string Campo(string[] campos, int indice)
        {
            return indice < campos.Length ? (campos[indice] ?? string.Empty) : string.Empty;
        }

        private static bool Ligado(string variavel)
        {
            string valor = Environment.GetEnvironmentVariable(variavel);
            return !string.IsNullOrEmpty(valor) && valor != "0";
        }

        /// <summary>O que continua sem regra na tela: a importação/exportação do Excel (interop).</summary>
        private static void Motivos(Form janela)
        {
            Desabilitar(janela, "BTImportaEX", "Importa do Excel: usa o Excel (interop)");
            Desabilitar(janela, "BTExportaEX", "Exporta para o Excel: usa o Excel (interop)");
        }
    }
}
