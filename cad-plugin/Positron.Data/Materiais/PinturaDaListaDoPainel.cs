using System;
using System.Collections.Generic;

namespace Positron.Data.Materiais
{
    /// <summary>As cores que o <c>MesclaDGDisp</c> usa (os <c>Color.*</c> do original, pelo nome).</summary>
    public enum CorDaCelula
    {
        /// <summary><c>Color.LightGray</c> — a linha sem marca (nem do desenho, nem avulsa).</summary>
        CinzaClaro,

        /// <summary><c>Color.LemonChiffon</c> — a linha que veio do desenho (tem handle).</summary>
        Limao,

        /// <summary><c>Color.LightCyan</c> — o item avulso.</summary>
        Ciano,

        /// <summary><c>Color.LightCoral</c> (texto branco) — o material fora do catálogo, só na célula 4.</summary>
        Coral,
    }

    /// <summary>Como uma linha da grade <c>dgDisp</c> sai pintada.</summary>
    public sealed class PinturaDaLinha
    {
        /// <summary>O fundo das células 3 a 5 (tag, material, quantidade); o texto é preto.</summary>
        public CorDaCelula Fundo { get; set; }

        /// <summary>
        /// O fundo da célula 4 quando ela difere das outras (o <see cref="CorDaCelula.Coral"/>, texto
        /// branco), ou <c>null</c> quando segue o <see cref="Fundo"/>.
        /// </summary>
        public CorDaCelula? FundoDoMaterial { get; set; }

        /// <summary>A dica das células 3 a 5 (vazia quando o original não põe nenhuma).</summary>
        public string Dica { get; set; }

        /// <summary>O <c>ErrorText</c> da célula 4 (vazio = sem erro).</summary>
        public string Erro { get; set; }
    }

    /// <summary>
    /// A **pintura** da grade do <c>ATINDEP</c> — o <c>MesclaDGDisp</c> do reverso
    /// (<c>frmGerenciadorMatIndep.cs:926</c>), que o original chama depois de cada carga da grade.
    /// Lê três células da linha: a 4 (o material), a 7 (<c>Avulso</c>) e a 11 (<c>Handle</c>), e o
    /// catálogo do <c>CarregaDadosLMMatriz</c> (o mesmo que preenche as caixas da seleção).
    ///
    /// **As regras, na ordem do original** (a que vem depois sobrescreve):
    ///
    /// | quando | o que |
    /// |---|---|
    /// | sempre | células 3–5 cinza-claro |
    /// | tem handle (veio do desenho) | células 3–5 limão |
    /// | avulso | células 3–5 ciano, dica "Dispositivo Avulso" (1200) |
    /// | tem handle e não é avulso | dica "Dispositivo Independente" (1201) |
    /// | sem handle e material 0 | erro 1203 + 1202 |
    /// | com handle e material 0 | erro 1201 + 1202 (1200 + 1202 se avulso) |
    /// | material ≠ 0 fora do catálogo | célula 4 coral/branco, erro 1204 + 1205 |
    ///
    /// O handle vazio e o nulo são o mesmo (o <c>Nothing = ""</c> do VB). As mensagens são as da
    /// <c>mMensagem</c> em português, juntadas por <c>"\r\n"</c> como lá.
    /// </summary>
    public static class PinturaDaListaDoPainel
    {
        /// <summary><c>mMensagem[1, 1200]</c>.</summary>
        public const string DispositivoAvulso = "Dispositivo Avulso";

        /// <summary><c>mMensagem[1, 1201]</c>.</summary>
        public const string DispositivoIndependente = "Dispositivo Independente";

        /// <summary><c>mMensagem[1, 1202]</c>.</summary>
        public const string MaterialZeroForaDoRelatorio = "Dispositivo com Material '0' não será inserido no relatório";

        /// <summary><c>mMensagem[1, 1203]</c>.</summary>
        public const string AtribuirNoModelo = "Esse Material deve ser atribuido no modelo do Dispositivo";

        /// <summary><c>mMensagem[1, 1204]</c>.</summary>
        public const string MaterialNaoCadastrado = "Material não cadastrado no Gerenciador de Materiais";

        /// <summary><c>mMensagem[1, 1205]</c>.</summary>
        public const string SemMaterialForaDoRelatorio = "Dispositivos sem material não serão inseridos no relatório";

        /// <summary>A pintura de uma linha da grade, com o catálogo indexado por <c>CodigoInterno</c>.</summary>
        public static PinturaDaLinha Pintar(LinhaDoItemNaGrade linha, IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            if (linha == null)
            {
                throw new ArgumentNullException("linha");
            }

            bool doDesenho = !string.IsNullOrEmpty(linha.Handle);
            bool materialZero = linha.IndiceMaterial == 0;

            PinturaDaLinha pintura = new PinturaDaLinha
            {
                Fundo = CorDaCelula.CinzaClaro,
                Dica = string.Empty,
                Erro = string.Empty,
            };

            if (doDesenho)
            {
                pintura.Fundo = CorDaCelula.Limao;
            }

            if (linha.Avulso)
            {
                pintura.Fundo = CorDaCelula.Ciano;
                pintura.Dica = DispositivoAvulso;
            }
            else if (doDesenho)
            {
                pintura.Dica = DispositivoIndependente;
            }

            if (materialZero)
            {
                string primeira = !doDesenho ? AtribuirNoModelo
                    : linha.Avulso ? DispositivoAvulso : DispositivoIndependente;
                pintura.Erro = primeira + "\r\n" + MaterialZeroForaDoRelatorio;
            }
            else if (catalogo == null || !catalogo.ContainsKey(linha.IndiceMaterial))
            {
                pintura.FundoDoMaterial = CorDaCelula.Coral;
                pintura.Erro = MaterialNaoCadastrado + "\r\n" + SemMaterialForaDoRelatorio;
            }

            return pintura;
        }
    }
}
