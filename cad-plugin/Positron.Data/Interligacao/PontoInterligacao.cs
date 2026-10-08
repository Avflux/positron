using System;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// Um ponto bruto de interligação — uma <c>LWPOLYLINE</c> com XData
    /// <c>INTERLIGACAO</c>, já traduzida para tipos neutros (sem ZWCAD).
    ///
    /// Corresponde à leitura de <c>XDataInterligacao.lerXDataInterligacao</c>
    /// mais o layer da entidade. A mesclagem em linhas de <c>Interligacao4</c>
    /// (o <c>ssqypmV1FI</c> do original) é feita por
    /// <see cref="InterligacaoProjetor"/>.
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

        /// <summary>
        /// Projeta o que o XData <c>INTERLIGACAO</c> fornece com segurança. O
        /// <paramref name="layer"/> da entidade vira a página da ponta.
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
    }
}
