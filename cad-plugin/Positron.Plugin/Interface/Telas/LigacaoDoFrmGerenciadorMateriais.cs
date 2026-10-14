using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmGerenciadorMateriais</c> (o comando <c>GERLM</c>): a grade
    /// <c>DGMateriais</c> com o **catálogo de materiais** (<c>Materiais</c>), na ordem do original
    /// (<c>order by CodigoInterno</c>), e o <c>MostraSelecionado</c> — a linha escolhida preenche as
    /// seis caixas do material, como no <c>TdSppTTAWll</c>/<c>AFTppJYrcGh</c>.
    ///
    /// As **colunas** desta grade não estão no designer: o original as cria no <c>formataDG</c>, e a
    /// ligação faz o mesmo (nomes e títulos do original, inclusive os três últimos — `IndiceOriginal`,
    /// `Ação` e `IndiceEL` —, que são o contrato do `iaGppGHMjAT` de gravação: `A` = acrescentar,
    /// `E` = editar).
    ///
    /// Os textos do título, dos rótulos e das dicas são os que o construtor do original aplica
    /// (`mMensagem` 584/585, 246/247, 1162/1163, 654, 1169 e 1164..1168).
    ///
    /// **Desabilitado com o motivo na dica:** os seis botões de escrita/Excel — o original grava o
    /// catálogo pelo próprio formulário (<c>AdicionaItemMaterial</c>/<c>EditaItemMaterial</c>/
    /// <c>RemoveMaterial</c>, com o botão Salvar e a confirmação no fechamento) e importa/exporta pelo
    /// Excel.
    /// </summary>
    internal sealed class LigacaoDoFrmGerenciadorMateriais : LigacaoDeMateriais
    {
        public override string NomeDaTela
        {
            get { return "frmGerenciadorMateriais"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "DGMateriais");

            TextosDoOriginal(janela);

            List<MaterialDoCatalogo> materiais = Catalogo(ConfiguracaoPositron.Carregar());
            PreencherGrade(grade, materiais);

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

            Motivos(janela);

            Plugin.Escrever("GERLM: " + materiais.Count + " material(is) no catálogo"
                + (materiais.Count > 0 ? " (\"" + materiais[0].DescricaoResumida + "\" no código "
                    + materiais[0].CodigoInterno + ")" : " — a tabela Materiais está vazia")
                + "; grade com " + (grade == null ? 0 : grade.Columns.Count) + " coluna(s); os botões que gravam estão desabilitados.");
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
        /// com a chave da tabela, e `Ação` vazia (a marca `A`/`E` é da edição, que o recoder não porta).
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

        /// <summary>
        /// O <c>MostraSelecionado</c> do original: as seis caixas do material recebem a linha
        /// selecionada. Os botões Edita/Apaga **não** são reabilitados aqui — eles são alvo da rodada
        /// que portar a escrita do catálogo.
        /// </summary>
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

        private static void Motivos(Form janela)
        {
            Desabilitar(janela, "BTAdicionaMaterial", "Adiciona Material: grava no catálogo (Materiais)");
            Desabilitar(janela, "BTEditaMaterial", "Edita Material Selecionado: grava no catálogo (Materiais)");
            Desabilitar(janela, "BTApagaMaterial", "Apaga Material Selecionado: destrutivo — apaga do catálogo (Materiais)");
            Desabilitar(janela, "btSalvar", "Salvar Alterações: a gravação do catálogo não está portada");
            Desabilitar(janela, "BTImportaEX", "Importa do Excel: usa o Excel (interop)");
            Desabilitar(janela, "BTExportaEX", "Exporta para o Excel: usa o Excel (interop)");
        }
    }
}
