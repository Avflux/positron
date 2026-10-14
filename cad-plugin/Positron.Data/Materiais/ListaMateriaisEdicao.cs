using System;
using System.Collections.Generic;
using System.Globalization;

namespace Positron.Data.Materiais
{
    /// <summary>
    /// A **escrita da lista** pelo <c>frmGerenciadorMatIndep</c> (<c>ATINDEP</c>, "Dispositivos
    /// Independentes e Avulsos") — a regra dos três botões que gravam na <c>ListaMateriais</c>:
    /// o <c>AdicionaUmItemMaterialAvulso</c>, o <c>EditaUmItemMaterialAvulso</c> e o
    /// <c>RemoveMaterialAvulso</c> do <c>cDadosAccessMateriais</c>, com o corpo do formulário
    /// (<c>jnTppR04rG4</c>, <c>eK4ppmS0dUi</c> e <c>eUVppXAWerf</c>) decidindo o que cada clique faz.
    ///
    /// **O item avulso.** O <c>Adiciona Material</c> só age quando a caixa do código **não** é o
    /// <c>"0"</c> que o construtor deixa (a linha de um dispositivo sem material não entra) e a
    /// linha nova vai para o **fim** da lista por dois campos: a <c>Ordem</c> (o `rfCpTfmCm7Q` do
    /// construtor, que começa em <see cref="PrimeiraOrdemDoItemAvulso"/>) e o <c>Avulso</c> = 1, que
    /// é o que faz a projeção (<c>COMPLM</c>) **preservar** a linha. O <c>IndiceLM</c> fica
    /// **ausente**: o original grava nele o índice da **linha da grade** (o parâmetro `indice` do
    /// <c>AdicionaUmItemMaterialAvulso</c>), que não é o número do LM — esse é atribuído pelos
    /// relatórios (<c>AtualizaIndiceLM</c>) e inventá-lo aqui seria concluir dado que não existe.
    ///
    /// **A edição** (<c>eK4ppmS0dUi</c>) normaliza a quantidade antes do laço (vazio ou <c>"0"</c>
    /// vira <c>"1"</c>) e, para **cada linha selecionada**, faz duas coisas independentes:
    ///
    /// | linha | operação |
    /// |---|---|
    /// | `<c>Avulso</c> = 1` | **substitui**: o `RemoveMaterialAvulso` (pelo `Indice` da linha) e o `AdicionaUmItemMaterialAvulso` de novo, com a tag, a quantidade e o material digitados |
    /// | `<c>Handle</c>` preenchido | **o material do dispositivo do desenho**: o `EditaUmItemMaterialAvulso` (o `UPDATE ... SET IndiceMaterial`) e o `clsDispositivo.EditaLMDoDispositivo`, que regrava o XData do bloco e os atributos dele |
    ///
    /// **A exclusão** (<c>eUVppXAWerf</c>) só tira as linhas **avulsas** selecionadas (o
    /// `eUVppXAWerf` testa o `Cells[7]`): as linhas que vêm do desenho ficam — quem as escreve é a
    /// projeção.
    ///
    /// O que é **do desenho** (o ramo do <c>EditaLMDoDispositivo</c>) sai daqui como a ação
    /// <see cref="TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo"/>: a regra diz **o que** fazer e
    /// quem a aplica — a ligação da tela — recusa enquanto a escrita do XData do dispositivo não
    /// estiver portada (é item da fila do <c>PLANO.md</c>).
    /// </summary>
    public static class ListaMateriaisEdicao
    {
        /// <summary>
        /// A primeira <c>Ordem</c> de um item avulso — o `rfCpTfmCm7Q = 100000` que o construtor do
        /// formulário deixa depois da primeira carga. É o que joga a linha nova para o **fim** da
        /// lista (as linhas do desenho têm ordem de desenho).
        /// </summary>
        public const int PrimeiraOrdemDoItemAvulso = 100000;

        /// <summary>
        /// A <c>Ordem</c> do item avulso acrescentado nesta janela — o `rfCpTfmCm7Q` do
        /// <c>jnTppR04rG4</c>, que usa o valor e **soma 1** a cada item novo.
        /// </summary>
        /// <param name="jaAcrescentados">Quantos itens esta janela já acrescentou (começa em 0).</param>
        public static int OrdemDoItemAvulso(int jaAcrescentados)
        {
            return PrimeiraOrdemDoItemAvulso + (jaAcrescentados < 0 ? 0 : jaAcrescentados);
        }

        /// <summary>
        /// A quantidade do <c>eK4ppmS0dUi</c>: a caixa vazia ou no <c>"0"</c> vira <c>"1"</c> — o
        /// `TBQuantidade.Text = "1"` do original; o resto passa como foi digitado (é esse texto que
        /// vai para a célula da grade).
        /// </summary>
        public static string QuantidadeDoTexto(string texto)
        {
            string escrito = texto ?? string.Empty;
            string aparado = escrito.Trim();
            if (aparado.Length == 0 || string.Equals(aparado, "0", StringComparison.OrdinalIgnoreCase))
            {
                return "1";
            }

            return escrito;
        }

        /// <summary>
        /// O guarda do <c>jnTppR04rG4</c>: só acrescenta quando o texto da caixa do código **não** é
        /// o <c>"0"</c> (o `CompareString(..., TextCompare: true) &lt;&gt; 0` do VB, sem aparar — com
        /// a caixa vazia o original acrescenta o material <c>0</c>, e é o que se reproduz).
        /// </summary>
        public static bool PodeAcrescentarItem(string codigo)
        {
            return !string.Equals(codigo ?? string.Empty, "0", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// O item avulso novo, como o `AdicionaUmItemMaterialAvulso` o grava: `Avulso` = 1,
        /// `Destino`/`DescDestino`/`Alternativo`/`Handle` vazios (é o `""` que o insert manda, não
        /// ausente) e o `IndiceLM` sem valor (ver o resumo da classe).
        /// </summary>
        public static LinhaListaMaterial ItemNovo(
            int dwg,
            int painel,
            string tag,
            string codigo,
            string quantidade,
            int ordem)
        {
            return new LinhaListaMaterial
            {
                DWG = dwg,
                Painel = painel,
                Tag = tag ?? string.Empty,
                IndiceMaterial = CodigoDoTexto(codigo),
                Quantidade = QuantidadeDeTexto(quantidade),
                Ordem = ordem,
                Avulso = true,
                Destino = string.Empty,
                DescDestino = string.Empty,
                Alternativo = string.Empty,
                Handle = string.Empty,
                IndiceLM = 0,
                OrdemLay = 0,
            };
        }

        /// <summary>
        /// O plano do <c>eK4ppmS0dUi</c> (o clique do <b>Edita Material Selecionado</b>), na ordem do
        /// original: para cada linha selecionada, a **substituição** quando ela é avulsa e o
        /// **material do dispositivo** quando ela tem `Handle` — as duas podem sair da mesma linha,
        /// como lá. As linhas que não são nem uma coisa nem outra não geram operação.
        /// </summary>
        /// <param name="linhas">As linhas **selecionadas** da grade (as doze células posicionais).</param>
        /// <param name="tag">O texto do `TBTag` no momento do clique.</param>
        /// <param name="quantidade">O texto do `TBQuantidade` (normalizado pela <see cref="QuantidadeDoTexto"/>).</param>
        /// <param name="codigo">O texto do `tbCodigo1` (o material escolhido).</param>
        public static List<AcaoNoItemDaLM> PlanoDoMaterialEscolhido(
            IEnumerable<LinhaDoItemNaGrade> linhas,
            string tag,
            string quantidade,
            string codigo)
        {
            List<AcaoNoItemDaLM> plano = new List<AcaoNoItemDaLM>();
            if (linhas == null)
            {
                return plano;
            }

            string quantidadeFinal = QuantidadeDoTexto(quantidade);
            foreach (LinhaDoItemNaGrade linha in linhas)
            {
                if (linha == null)
                {
                    continue;
                }

                if (linha.Avulso)
                {
                    LinhaListaMaterial item = ItemDaLinha(linha);
                    item.Tag = tag ?? string.Empty;
                    item.IndiceMaterial = CodigoDoTexto(codigo);
                    item.Quantidade = QuantidadeDeTexto(quantidadeFinal);

                    plano.Add(new AcaoNoItemDaLM
                    {
                        Tipo = TipoDeAcaoNoItemDaLM.Substituir,
                        Indice = linha.Indice,
                        Item = item,
                    });
                }

                if (!string.IsNullOrEmpty(linha.Handle))
                {
                    plano.Add(new AcaoNoItemDaLM
                    {
                        Tipo = TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo,
                        Indice = linha.Indice,
                        IndiceMaterial = CodigoDoTexto(codigo),
                        Handle = linha.Handle,
                    });
                }
            }

            return plano;
        }

        /// <summary>
        /// A linha da grade como o `AdicionaUmItemMaterialAvulso` a **relê** no ramo da substituição:
        /// as células 1..6 e 10/11 (`DWG`, `Painel`, `Tag`, `IndiceMaterial`, `Quantidade`, `Ordem`,
        /// `Alternativo`, `Handle`), com `Destino`/`DescDestino` vazios — o insert do original manda
        /// `""` nesses dois em qualquer caminho.
        /// </summary>
        private static LinhaListaMaterial ItemDaLinha(LinhaDoItemNaGrade linha)
        {
            return new LinhaListaMaterial
            {
                DWG = linha.DWG,
                Painel = linha.Painel,
                Tag = linha.Tag ?? string.Empty,
                IndiceMaterial = linha.IndiceMaterial,
                Quantidade = linha.Quantidade,
                Ordem = linha.Ordem,
                Avulso = true,
                Destino = string.Empty,
                DescDestino = string.Empty,
                Alternativo = linha.Alternativo ?? string.Empty,
                Handle = linha.Handle ?? string.Empty,
                IndiceLM = 0,
                OrdemLay = 0,
            };
        }

        /// <summary>
        /// O código interno lido do texto da caixa — o `Conversions.ToInteger(tbCodigo1.Text)` do
        /// original, tolerante ao que não é número (devolve <c>0</c> em vez de estourar: o original
        /// deixaria a exceção subir e o clique não gravaria nada).
        /// </summary>
        public static int CodigoDoTexto(string codigo)
        {
            int valor;
            if (int.TryParse((codigo ?? string.Empty).Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out valor))
            {
                return valor;
            }

            double quebrado;
            string aparado = (codigo ?? string.Empty).Trim();
            if (double.TryParse(aparado, NumberStyles.Float, CultureInfo.InvariantCulture, out quebrado)
                || double.TryParse(aparado.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out quebrado))
            {
                return (int)Math.Round(quebrado, MidpointRounding.AwayFromZero);
            }

            return 0;
        }

        /// <summary>A quantidade em inteiro — o `Conversions.ToInteger(dgDisp.Rows[i].Cells[5].Value)` do insert.</summary>
        public static int QuantidadeDeTexto(string quantidade)
        {
            return CodigoDoTexto(quantidade);
        }
    }

    /// <summary>
    /// Uma linha da <c>dgDisp</c> do <c>ATINDEP</c> nas **doze colunas posicionais** do
    /// <c>formataDGDisp</c> do original — é a ordem que as regras do formulário leem
    /// (<c>Cells[0]</c> a <c>Cells[11]</c>).
    /// </summary>
    public sealed class LinhaDoItemNaGrade
    {
        /// <summary>Célula 0: a chave da linha (<c>ListaMateriais.Indice</c>).</summary>
        public int Indice { get; set; }

        /// <summary>Célula 1: o <c>DWG</c>.</summary>
        public int DWG { get; set; }

        /// <summary>Célula 2: o <c>Painel</c>.</summary>
        public int Painel { get; set; }

        /// <summary>Célula 3: a <c>Tag</c> — o "Dispositivo" da tela.</summary>
        public string Tag { get; set; }

        /// <summary>Célula 4: o <c>IndiceMaterial</c> (o código interno do material).</summary>
        public int IndiceMaterial { get; set; }

        /// <summary>Célula 5: a <c>Quantidade</c>.</summary>
        public int Quantidade { get; set; }

        /// <summary>Célula 6: a <c>Ordem</c>.</summary>
        public int Ordem { get; set; }

        /// <summary>Célula 7: o <c>Avulso</c> — o que separa o item da tela da linha do desenho.</summary>
        public bool Avulso { get; set; }

        /// <summary>Célula 8: o <c>Destino</c>.</summary>
        public string Destino { get; set; }

        /// <summary>Célula 9: o <c>DescDestino</c>.</summary>
        public string DescDestino { get; set; }

        /// <summary>Célula 10: o <c>Alternativo</c>.</summary>
        public string Alternativo { get; set; }

        /// <summary>Célula 11: o <c>Handle</c> do dispositivo do desenho (vazio no item avulso).</summary>
        public string Handle { get; set; }
    }

    /// <summary>O que fazer com a linha escolhida na gravação (o <c>eK4ppmS0dUi</c> do original).</summary>
    public enum TipoDeAcaoNoItemDaLM
    {
        /// <summary>A linha avulsa: apagar a que está no banco e inserir de novo com os valores digitados.</summary>
        Substituir,

        /// <summary>A linha do desenho: o material do dispositivo (o XData do bloco e os atributos dele).</summary>
        AjustarMaterialDoDispositivo,
    }

    /// <summary>Uma operação do plano do <b>Edita Material Selecionado</b>, na ordem do original.</summary>
    public sealed class AcaoNoItemDaLM
    {
        public TipoDeAcaoNoItemDaLM Tipo { get; set; }

        /// <summary>A chave da linha (`Indice`): o `WHERE` da remoção e da edição.</summary>
        public int Indice { get; set; }

        /// <summary>O material escolhido (<c>IndiceMaterial</c>) — no ajuste do dispositivo e no item substituído.</summary>
        public int IndiceMaterial { get; set; }

        /// <summary>O handle do dispositivo do desenho (o ramo que o desenho atende), quando é o ajuste.</summary>
        public string Handle { get; set; }

        /// <summary>O item novo, no caso da substituição.</summary>
        public LinhaListaMaterial Item { get; set; }
    }
}
