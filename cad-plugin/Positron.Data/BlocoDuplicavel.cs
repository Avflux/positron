namespace Positron.Data
{
    /// <summary>
    /// Um bloco do desenho já em campos neutros, para a checagem de **duplicados**
    /// (o <c>bt12AMao</c>, "Copy made by hand", alimentado pelo
    /// <c>clsBlocos.VerificaDuplicados</c> do original).
    ///
    /// O original identifica cada bloco por um tipo de uma letra (o
    /// <c>verificaTipoDispositivo</c>) e monta uma **chave de identidade** conforme
    /// o tipo. A porta (<c>E</c>) usa a identidade da **máscara** que ela aponta
    /// (<see cref="Nome1"/>/<see cref="Nome2"/>/<see cref="Alternativo"/>/
    /// <see cref="Painel"/> preenchidos a partir da máscara), e o auxiliar (<c>A</c>)
    /// usa a identidade do **bob**; o campo próprio de cada um entra na chave como
    /// <see cref="IndiceDaPorta"/> (porta) e <see cref="IndexContato"/> (auxiliar).
    ///
    /// <see cref="Tipo"/> usa as letras do original (<c>M</c>/<c>P</c>/<c>E</c>/
    /// <c>B</c>/<c>A</c>) e <c>D</c> para o texto de **definição** (o <c>DBText</c>
    /// com XData <c>Definicao</c>).
    /// </summary>
    public sealed class BlocoDuplicavel
    {
        /// <summary>Tipo do bloco: <c>M</c> (máscara), <c>P</c> (dispositivo), <c>E</c> (porta), <c>B</c> (borne), <c>A</c> (auxiliar) ou <c>D</c> (definição).</summary>
        public string Tipo { get; set; }

        /// <summary>Nome 1 da identidade usada na chave (própria em <c>M</c>/<c>P</c>; da máscara em <c>E</c>; do bob em <c>A</c>).</summary>
        public string Nome1 { get; set; }

        /// <summary>Nome 2 da identidade usada na chave.</summary>
        public string Nome2 { get; set; }

        /// <summary>Alternativo da identidade usada na chave.</summary>
        public string Alternativo { get; set; }

        /// <summary>Painel da identidade (próprio em <c>M</c>/<c>P</c>/<c>B</c>; da máscara em <c>E</c>; do bob em <c>A</c>; da máscara em <c>D</c>).</summary>
        public short Painel { get; set; }

        /// <summary>Máscara/dispositivo complementar — não entra na checagem (só <c>M</c>/<c>P</c>).</summary>
        public bool Complementar { get; set; }

        /// <summary>Índice da porta do modelo (chave do <c>E</c>).</summary>
        public int IndiceDaPorta { get; set; }

        /// <summary>Índice da régua (chave do <c>B</c>).</summary>
        public int IndiceRegua { get; set; }

        /// <summary>Número do borne **cru** do XData (chave e guarda do <c>B</c>).</summary>
        public string Numero { get; set; }

        /// <summary>Índice do contato (chave do <c>A</c>).</summary>
        public int IndexContato { get; set; }

        /// <summary>Handle da máscara (chave do <c>D</c>).</summary>
        public string HandleMascara { get; set; }

        /// <summary>Índice do modelo (chave do <c>D</c>).</summary>
        public int IndiceModelo { get; set; }

        /// <summary>Layer do bloco no desenho — a "página" que a grade do original mostra.</summary>
        public string Pagina { get; set; }

        /// <summary>Handle do bloco (ou do texto de definição) no desenho.</summary>
        public string Handle { get; set; }
    }
}
