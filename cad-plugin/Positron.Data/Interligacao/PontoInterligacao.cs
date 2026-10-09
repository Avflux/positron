using System;
using Positron.Data.Bornes;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// Um ponto bruto de interligação — uma <c>LWPOLYLINE</c> com XData
    /// <c>INTERLIGACAO</c>, já traduzida para tipos neutros (sem ZWCAD).
    ///
    /// Corresponde à leitura de <c>XDataInterligacao.lerXDataInterligacao</c>
    /// mais o layer e a geometria da entidade. A mesclagem em linhas de
    /// <c>Interligacao4</c> (o <c>ssqypmV1FI</c> do original) é feita por
    /// <see cref="InterligacaoProjetor"/>.
    ///
    /// **Geometria das pontas** (recuperada de <c>frmCompilarInterligacao</c>):
    ///
    /// - <c>Tipo == 1</c>: a polyline traz as duas pontas — início (vértice 0) e
    ///   fim (último vértice).
    /// - <c>Tipo == 2</c>: cada polyline traz **uma** ponta — <c>Painel1 &gt; 0</c>
    ///   usa o vértice 0 (ponta 1); caso contrário, o último vértice (ponta 2).
    /// - <c>Tipo == 3</c>: só a ponta 2 (último vértice); a ponta 1 fica vazia.
    ///
    /// A posição de cada ponta é o que casa com o borne (<see cref="CasamentoBorne"/>).
    /// </summary>
    public sealed class PontoInterligacao
    {
        /// <summary>Tipo do XData (1 = ponta única; 2 = trecho mesclado por cabo/veia; 3 = destino).</summary>
        public short Tipo { get; set; }

        public string Tag_Cabo { get; set; }

        public int NumVeia { get; set; }

        public string NomeVeia { get; set; }

        public short Painel1 { get; set; }

        public short Painel2 { get; set; }

        /// <summary>Handle da entidade da ponta (campo 9 do XData).</summary>
        public string Handle { get; set; }

        /// <summary>Layer da entidade — vira a página da ponta.</summary>
        public string Pagina { get; set; }

        /// <summary>Esta polyline fornece a ponta 1 (vértice 0).</summary>
        public bool TemPonta1 { get; set; }

        /// <summary>Esta polyline fornece a ponta 2 (último vértice).</summary>
        public bool TemPonta2 { get; set; }

        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        /// <summary>
        /// Projeta o que o XData <c>INTERLIGACAO</c> fornece com segurança. O
        /// <paramref name="layer"/> da entidade vira a página da ponta.
        ///
        /// A geometria das pontas (<see cref="X1"/>/<see cref="Y1"/> e
        /// <see cref="X2"/>/<see cref="Y2"/>) e as bandeiras
        /// <see cref="TemPonta1"/>/<see cref="TemPonta2"/> são preenchidas por
        /// quem lê a entidade (o adapter do CAD), que enxerga os vértices.
        ///
        /// Mapeamento deliberadamente conservador: só o que é inequívoco. Campos
        /// que dependem da varredura de bornes (tag, terminal, nRegua, posicao,
        /// indexModelo, handle da ponta) ficam no default — inventar aqui
        /// encheria o banco de dado errado, que é pior que dado ausente.
        /// </summary>
        public static PontoInterligacao DeInterligacao(InterligacaoXData ilig, string layer)
        {
            if (ilig == null)
            {
                throw new ArgumentNullException("ilig");
            }

            return new PontoInterligacao
            {
                Tipo = ilig.Tipo,
                Tag_Cabo = ilig.Tag_Cabo,
                NumVeia = ilig.NumVeia,
                NomeVeia = ilig.NomeVeia,
                Painel1 = ilig.Painel1,
                Painel2 = ilig.Painel2,
                Handle = ilig.Handle,
                Pagina = layer,
            };
        }
    }

    /// <summary>Contexto do desenho que completa a linha (não vem do XData).</summary>
    public sealed class ContextoInterligacao
    {
        public int Dwg { get; set; }

        public string Revisao { get; set; }

        public string Criador { get; set; }

        public DateTime Data { get; set; }
    }

    /// <summary>
    /// Uma linha de <c>Interligacao4</c> já mesclada. Espelha as colunas do
    /// INSERT canônico (<c>cDadosAccessInterligacao2.AdicionaItemInterligacao</c>).
    ///
    /// As colunas que a varredura de bornes preenche (tag, alternativo, nRegua,
    /// terminal, terminalNum, tipoBorne, handle, indexModelo) são o que se aplica
    /// por ponta. As que **não** vêm do XData nem do borne — <c>Documento</c>,
    /// <c>Posicao</c> e <c>DWG1</c>/<c>DWG2</c> — não são expostas: saem nulas de
    /// propósito (config e por-ponta, não projetadas).
    /// </summary>
    public sealed class TrechoInterligacao
    {
        public string Tag_Cabo { get; set; }

        public int NumVeia { get; set; }

        public string NomeVeia { get; set; }

        public short Painel1 { get; set; }

        public string Pagina1 { get; set; }

        public short Painel2 { get; set; }

        public string Pagina2 { get; set; }

        public string Revisao { get; set; }

        public int Dwg { get; set; }

        public string Criador { get; set; }

        public DateTime Data { get; set; }

        // ── geometria das pontas (para casar com o borne) ──────────────────────

        public bool TemPonta1 { get; set; }

        public double X1 { get; set; }

        public double Y1 { get; set; }

        public bool TemPonta2 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        // ── colunas da ponta 1 preenchidas pela varredura de bornes ────────────

        public string Tag1 { get; set; }

        public string Alternativo1 { get; set; }

        public string NRegua1 { get; set; }

        public string Terminal1 { get; set; }

        public double? TerminalNum1 { get; set; }

        public int? TipoBorne1 { get; set; }

        public string Handle1 { get; set; }

        public int? IndexModelo1 { get; set; }

        // ── colunas da ponta 2 preenchidas pela varredura de bornes ────────────

        public string Tag2 { get; set; }

        public string Alternativo2 { get; set; }

        public string NRegua2 { get; set; }

        public string Terminal2 { get; set; }

        public double? TerminalNum2 { get; set; }

        public int? TipoBorne2 { get; set; }

        public string Handle2 { get; set; }

        public int? IndexModelo2 { get; set; }

        /// <summary>
        /// Completa a ponta 1 com o borne casado — as mesmas colunas que a fase 7
        /// preenche na <c>Fiacao</c> (ver <c>PontoFiacao.AplicarBorne</c>).
        /// <c>Tag</c> recebe o nome da régua (com "/alternativo" quando há).
        /// </summary>
        public void AplicarBornePonta1(PontoBorne borne)
        {
            Tag1 = MontarTag(borne);
            Alternativo1 = borne.Alternativo;
            NRegua1 = borne.NomeRegua;
            Terminal1 = borne.Terminal;
            TerminalNum1 = borne.Ordem;
            TipoBorne1 = borne.Tipo;
            IndexModelo1 = borne.IndiceRegua;
            Handle1 = borne.Handle;
        }

        /// <summary>Completa a ponta 2 com o borne casado (espelho da ponta 1).</summary>
        public void AplicarBornePonta2(PontoBorne borne)
        {
            Tag2 = MontarTag(borne);
            Alternativo2 = borne.Alternativo;
            NRegua2 = borne.NomeRegua;
            Terminal2 = borne.Terminal;
            TerminalNum2 = borne.Ordem;
            TipoBorne2 = borne.Tipo;
            IndexModelo2 = borne.IndiceRegua;
            Handle2 = borne.Handle;
        }

        private static string MontarTag(PontoBorne borne)
        {
            if (borne == null)
            {
                throw new ArgumentNullException("borne");
            }

            return string.IsNullOrEmpty(borne.Alternativo)
                ? borne.NomeRegua
                : borne.NomeRegua + "/" + borne.Alternativo;
        }
    }
}
