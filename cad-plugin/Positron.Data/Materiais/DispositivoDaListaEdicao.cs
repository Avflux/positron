using System.Collections.Generic;

namespace Positron.Data.Materiais
{
    /// <summary>
    /// O **ramo do desenho** do <b>Edita Material Selecionado</b> do <c>ATINDEP</c> — o
    /// <c>clsDispositivo.EditaLMDoDispositivo</c> do reverso (<c>clsDispositivo.cs:3088</c>), que o
    /// <c>eK4ppmS0dUi</c> chama para cada linha da grade **com handle** (a linha que veio do desenho,
    /// não o item avulso).
    ///
    /// O original monta um <c>object(3, 1)</c> por linha e o entrega ao
    /// <c>EditaLMDoDispositivo</c>, que faz **duas** coisas com **um** dispositivo:
    ///
    /// | # | o que | de onde sai o valor |
    /// |---|---|---|
    /// | 1 | o **<c>iLM1</c>** no XData <c>Dispositivo</c> do bloco (o índice 21 do array — o <c>1071</c> do <c>GravarXDataDispPrincipal</c>) | o <c>mLM[1, i]</c>, a célula 4 da grade (o material digitado) |
    /// | 2 | os atributos <c>MODELO</c> (vazio), <c>PAINEL</c> e <c>FABRICANTE</c> | o painel e o LM **relidos do desenho** depois da gravação |
    ///
    /// **A ordem e os guardas do original, como estão:**
    ///
    /// - o bloco é achado pelo **handle** (o <c>mLM[2, i]</c>) e só entra se
    ///   <c>verificaTipoDispositivo</c> responder <c>"P"</c> (o tipo do XData <c>Dispositivo</c>) —
    ///   handle inexistente e bloco de outro tipo são **pulados**, não erro;
    /// - o XData é regravado **só quando o <c>iLM1</c> do desenho difere** do material escolhido
    ///   (o <c>&lt;&gt;</c> do original);
    /// - os **três atributos são gravados sempre**, mesmo quando o <c>iLM1</c> já era o escolhido —
    ///   é o que atualiza o painel e o fabricante de quem não mudou de material;
    /// - o fabricante sai do **LM já gravado** (o original relê o XData depois de gravar e busca o
    ///   <c>Fabricante</c> da <c>Materiais</c> por <c>CodigoInterno</c>); o <c>MODELO</c> vai
    ///   **vazio**: o original **limpa** o modelo do desenho em vez de escrever o novo (o mesmo que o
    ///   <c>clsDispositivo.cs:4082</c> faz quando o contato muda), e é o que se reproduz.
    ///
    /// O que é **de banco** aqui é só o **cadastro**: o nome do painel (a tabela <c>Paineis</c>, o
    /// <c>Dicionario.BuscaNomeDoPainel</c>, que responde <c>"???"</c> para um painel fora do cadastro)
    /// e o fabricante (a tabela <c>Materiais</c>) — o <c>IndiceMaterial</c> da linha já foi gravado
    /// pela escrita da lista (<see cref="ListaMateriaisEdicao"/>).
    /// </summary>
    public static class DispositivoDaListaEdicao
    {
        /// <summary>
        /// O <c>iLM1</c> no array do XData <c>Dispositivo</c> — o <c>array[21]</c> do
        /// <c>GravarXDataDispPrincipal</c> do reverso (um <c>1071</c>, entre o <c>dAlturaModelo</c>
        /// do 20 e o <c>0</c> do 22). O índice é **depois do app name** (o nosso leitor conta o 1001
        /// como 0), o mesmo critério do <c>ATT</c> do `cad-dump-xdata.lsp`.
        /// </summary>
        public const int IndiceDoLmNoXData = 21;

        /// <summary>O painel no array do XData <c>Dispositivo</c> — o <c>array[8]</c> (<c>1070</c>).</summary>
        public const int IndiceDoPainelNoXData = 8;

        /// <summary>O tag do modelo do dispositivo, que a edição da lista **limpa** (o <c>""</c> do original).</summary>
        public const string TagDoModelo = "MODELO";

        /// <summary>O tag do painel do dispositivo, que recebe o nome do cadastro.</summary>
        public const string TagDoPainel = "PAINEL";

        /// <summary>O tag do fabricante do dispositivo, que recebe o fabricante do material.</summary>
        public const string TagDoFabricante = "FABRICANTE";

        /// <summary>
        /// O que o <c>Dicionario.BuscaNomeDoPainel</c> responde para um painel que **não está** no
        /// cadastro (o `lPnAoagado` do original): <c>"???"</c>. Não é o índice nem vazio — é o
        /// literal, e é ele que vai para o atributo <c>PAINEL</c> e para a coluna da grade.
        /// </summary>
        public const string PainelSemCadastro = "???";

        /// <summary>
        /// O texto que o original grava no atributo <c>MODELO</c>: vazio — a edição do material
        /// **limpa** o modelo do dispositivo (o modelo novo é assunto de outro caminho).
        /// </summary>
        public const string ModeloLimpo = "";

        /// <summary>
        /// As linhas **do desenho** do plano do <c>eK4ppmS0dUi</c>, na ordem do original: cada
        /// <see cref="TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo"/> vira um item com o handle
        /// (o <c>mLM[2, i]</c>), o material escolhido (o <c>mLM[1, i]</c>, que é o
        /// <c>IndiceMaterial</c> da ação) e o <c>Indice</c> da linha (o <c>mLM[0, i]</c>, que a
        /// escrita no desenho **não** usa — está aqui porque é o que o array do original carrega).
        /// </summary>
        public static List<ItemDoDispositivo> ItensParaODesenho(IEnumerable<AcaoNoItemDaLM> plano)
        {
            List<ItemDoDispositivo> itens = new List<ItemDoDispositivo>();
            if (plano == null)
            {
                return itens;
            }

            foreach (AcaoNoItemDaLM acao in plano)
            {
                if (acao == null || acao.Tipo != TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(acao.Handle))
                {
                    continue;
                }

                itens.Add(new ItemDoDispositivo
                {
                    Indice = acao.Indice,
                    Lm = acao.IndiceMaterial,
                    Handle = acao.Handle,
                });
            }

            return itens;
        }

        /// <summary>
        /// O guarda do XData: grava o <c>iLM1</c> só quando o **do desenho** difere do escolhido (o
        /// <c>disp.iLM1 &lt;&gt; Conversions.ToInteger(mLM[1, i])</c>).
        /// </summary>
        public static bool PrecisaGravarLm(int lmNoDesenho, int lmNovo)
        {
            return lmNoDesenho != lmNovo;
        }

        /// <summary>
        /// O nome do painel no cadastro — o <c>Dicionario.BuscaNomeDoPainel</c>: o valor da tabela
        /// <c>Paineis</c> quando o índice está lá (mesmo vazio) e <see cref="PainelSemCadastro"/>
        /// quando não está.
        /// </summary>
        public static string NomeDoPainel(IReadOnlyDictionary<int, string> nomesDePaineis, int painel)
        {
            string nome;
            if (nomesDePaineis == null || !nomesDePaineis.TryGetValue(painel, out nome))
            {
                return PainelSemCadastro;
            }

            return nome ?? string.Empty;
        }

        /// <summary>
        /// O fabricante do material escolhido — o <c>cDadosLM.BuscaFabricanteDoMaterial</c>: o
        /// <c>Fabricante</c> da <c>Materiais</c> pelo <c>CodigoInterno</c>, com o <c>TiraNothing</c>
        /// por cima. Material fora do catálogo responde **vazio** (o <c>Rows.Count = 0</c> do
        /// original), não "???".
        /// </summary>
        public static string FabricanteDoMaterial(MaterialDoCatalogo material)
        {
            return material == null ? string.Empty : (material.Fabricante ?? string.Empty);
        }

        /// <summary>
        /// Os três atributos que a edição grava no dispositivo, **na ordem do original** (o
        /// <c>AtualizaValorDeUmAtributo</c> de cada um): o <c>MODELO</c> vazio, o <c>PAINEL</c> com o
        /// nome do painel **do dispositivo** e o <c>FABRICANTE</c> do material escolhido.
        /// </summary>
        public static List<AtributoDoDispositivo> AtributosDoDispositivo(string nomeDoPainel, string fabricante)
        {
            return new List<AtributoDoDispositivo>
            {
                new AtributoDoDispositivo { Tag = TagDoModelo, Valor = ModeloLimpo },
                new AtributoDoDispositivo { Tag = TagDoPainel, Valor = nomeDoPainel ?? string.Empty },
                new AtributoDoDispositivo { Tag = TagDoFabricante, Valor = fabricante ?? string.Empty },
            };
        }
    }

    /// <summary>
    /// Uma linha do array que o <c>eK4ppmS0dUi</c> monta para o <c>EditaLMDoDispositivo</c>
    /// (<c>object(3, 1)</c>): o <c>mLM[0, i]</c> (o <c>Indice</c> da linha), o <c>mLM[1, i]</c> (o
    /// material escolhido, que vira o <c>iLM1</c>) e o <c>mLM[2, i]</c> (o handle do bloco).
    /// </summary>
    public sealed class ItemDoDispositivo
    {
        /// <summary>A chave da linha na <c>ListaMateriais</c> — o <c>mLM[0, i]</c> (não entra na escrita).</summary>
        public int Indice { get; set; }

        /// <summary>O material escolhido (o <c>IndiceMaterial</c>) — o <c>mLM[1, i]</c>, que vai para o <c>iLM1</c>.</summary>
        public int Lm { get; set; }

        /// <summary>O handle do bloco do dispositivo — o <c>mLM[2, i]</c>.</summary>
        public string Handle { get; set; }
    }

    /// <summary>Um atributo do dispositivo a gravar: o tag e o texto (o par do <c>AtualizaValorDeUmAtributo</c>).</summary>
    public sealed class AtributoDoDispositivo
    {
        public string Tag { get; set; }

        public string Valor { get; set; }
    }
}
