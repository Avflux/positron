using System;
using Positron.Data.Bornes;
using Positron.Data.Layout;

namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Um ponto de fiação — equivalente ao <c>structurePontosPotencial</c> do
    /// original, com os campos que viram colunas de <c>Fiacao</c>.
    ///
    /// **O que vem do borne.** O original monta estes pontos varrendo também os
    /// **bornes/terminais** do desenho (colunas que não existem no XData de
    /// <c>CONEXAO</c>). <see cref="AplicarBorne"/> preenche <see cref="Tag"/>,
    /// <see cref="Alternativo"/>, <see cref="Terminal"/>, <see cref="TerminalNum"/>,
    /// <see cref="Tipo"/>, <see cref="PosicaoNum"/>, <see cref="TipoBorne"/>,
    /// <see cref="IndexModelo"/>, <see cref="NRegua"/>, <see cref="Handle"/> e
    /// <see cref="BLink"/>. Ver docs/POSITRON.md (fases 5 e 7).
    /// </summary>
    public sealed class PontoFiacao
    {
        public short Painel { get; set; }

        public int Potencial { get; set; }

        /// <summary>Posição do ponto no desenho — usada para casar com o borne.</summary>
        public double X { get; set; }

        public double Y { get; set; }

        public string Layer { get; set; }

        public string Tag { get; set; }

        public string Alternativo { get; set; }

        public string Terminal { get; set; }

        public double TerminalNum { get; set; }

        public string Tipo { get; set; }

        public string Secao { get; set; }

        public string Cor { get; set; }

        public int PosicaoNum { get; set; }

        public short TipoBorne { get; set; }

        public short IndexModelo { get; set; }

        public bool BJumper { get; set; }

        public bool BLink { get; set; }

        public string Handle { get; set; }

        public string NRegua { get; set; }

        public int Aplicacao { get; set; }

        /// <summary>
        /// Chave de ordenação do original (<c>dOrdem</c>): no borne é o índice da
        /// régua; no não-borne com posição de layout, a ordem da posição. Usada
        /// só para ordenar (não vai para o banco).
        /// </summary>
        public int OrdemChave { get; set; }

        /// <summary>Sequência dentro do potencial; calculada pelo projetor.</summary>
        public int Ordem { get; set; }

        public string Revisao { get; set; }

        public int Dwg { get; set; }

        public string Criador { get; set; }

        public DateTime Data { get; set; }

        /// <summary>
        /// Projeta o que o XData <c>CONEXAO</c> fornece com segurança.
        ///
        /// Mapeamento deliberadamente conservador: só o que é inequívoco. Campos
        /// que dependem da varredura de bornes (ou de outro XData) ficam no
        /// default em <see cref="PontoFiacao"/> — inventar aqui encheria o banco
        /// de dado errado, que é pior que dado ausente.
        /// </summary>
        public static PontoFiacao DeConexao(ConexaoXData conexao)
        {
            if (conexao == null)
            {
                throw new ArgumentNullException("conexao");
            }

            return new PontoFiacao
            {
                Painel = conexao.Painel,
                Potencial = conexao.Potencial,
                Secao = conexao.Secao,
                Cor = conexao.Cor,
                Aplicacao = conexao.Aplicacao,
                BJumper = !string.IsNullOrWhiteSpace(conexao.Jumper),
                Criador = string.IsNullOrWhiteSpace(conexao.Usuario) ? null : conexao.Usuario,
            };
        }

        /// <summary>
        /// Completa o ponto com o borne casado — as colunas que a varredura de
        /// bornes preenche (ver <see cref="CasamentoBorne"/>). Equivale ao trecho
        /// de <c>frmCompilarFiacao</c> que roda após achar o bloco na vizinhança
        /// do ponto.
        ///
        /// <c>Tag</c> recebe o nome da régua (com "/alternativo" quando há), e o
        /// painel do borne passa a valer sobre o painel do XData: o original usa
        /// o painel resolvido pelo dicionário.
        /// </summary>
        public void AplicarBorne(PontoBorne borne)
        {
            if (borne == null)
            {
                throw new ArgumentNullException("borne");
            }

            Tag = string.IsNullOrEmpty(borne.Alternativo) ? borne.NomeRegua : borne.NomeRegua + "/" + borne.Alternativo;
            Alternativo = borne.Alternativo;
            Terminal = borne.Terminal;
            TerminalNum = borne.Ordem;
            Tipo = BorneXData.TipoBorne;
            TipoBorne = (short)borne.Tipo;
            IndexModelo = (short)borne.IndiceRegua;
            NRegua = borne.NomeRegua;
            Handle = borne.Handle;
            PosicaoNum = 1;
            OrdemChave = borne.IndiceRegua;
            BLink = false;
        }

        /// <summary>
        /// Completa um ponto **não-borne** com a posição do layout
        /// (<see cref="LayoutPosicoes"/>) casada por <c>(painel, tag)</c> — o
        /// <c>mPosicao</c> do <c>frmCompilarFiacao</c>. Dá o <c>PosicaoNum</c> e a
        /// ordem na reordenação.
        /// </summary>
        public void AplicarPosicao(PosicaoLayout posicao)
        {
            if (posicao == null)
            {
                throw new ArgumentNullException("posicao");
            }

            PosicaoNum = posicao.PosicaoNum;
            OrdemChave = posicao.Ordem;
        }
    }

    /// <summary>Contexto do desenho que completa a linha (não vem do XData).</summary>
    public sealed class ContextoProjecao
    {
        public int Dwg { get; set; }

        public string Revisao { get; set; }

        public string Criador { get; set; }

        public DateTime Data { get; set; }
    }
}
