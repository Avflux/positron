namespace Positron.Data.Interface
{
    /// <summary>
    /// Os textos da interface **extraídos do produto original** (a tabela `mMensagem` do
    /// `Mensagem.cs`, que lê o recurso `Resources.Mensagens`).
    ///
    /// Como foram obtidos (a receita fica em `scripts/extrair-barra-do-reverso.ps1` e no
    /// RUNBOOK, rodada 123):
    ///
    /// 1. `de4dot.exe` no `Eletron4Z.dll` → `Eletron4Z-cleaned.dll` (o obfuscador é o .NET Reactor);
    /// 2. `ResourceManager` no assembly limpo, com um `AssemblyResolve` apontando para as DLLs do
    ///    ZWCAD → `GetString("Mensagens")` devolve a tabela inteira (60.680 chars, 1982 entradas);
    /// 3. o recorte `[PT]` fica em `Positron.Data/Interface/Mapas/mensagens-pt.txt`.
    ///
    /// Os índices são os do `mMensagem[1, N]` do reverso.
    /// </summary>
    public static class MensagensDoReverso
    {
        /// <summary>Páginas — o título da paleta (o `_pspag` do reverso).</summary>
        public const string Paginas = "Páginas";

        public const string Pagina = "Página";

        public const string Alternativo = "Alternativo";

        public const string Unidade = "Unidade";

        /// <summary>Os títulos dos painéis da barra do original (mMensagem 109..112, 540, 559, 560, 1549).</summary>
        public const string PainelCaderno = "Caderno";

        public const string PainelDispositivos = "Dispositivos";

        public const string PainelConfiguracao = "Configuração";

        public const string PainelUtilitarios = "Utilitários";

        public const string PainelBornes = "Bornes";

        public const string PainelFiacao = "Fiação";

        public const string PainelCabosEVeias = "Cabos e Veias";

        public const string PainelConstrutivo = "Construtivo";

        public const string PainelHelp = "Help";

        /// <summary>
        /// O menu de contexto do `uscPaginas` (as folhas). Todo item que no designer tem um texto
        /// literal sai daqui: o designer põe um valor e o construtor o **sobrescreve** pela
        /// `mMensagem`, então o que o usuário lê é o desta tabela. Os índices são os do reverso
        /// (`uscPaginas.cs:1300-1306`).
        /// </summary>
        /// <remarks>
        /// O `Renumerar Páginas` é o caso que mais engana: o nome do campo no designer é
        /// `RenomearPáginasToolStripMenuItem`, mas o texto que o usuário vê é a mMensagem 22 —
        /// "Renumerar". A regra por trás é a do `RENPAGA` (renumerar o caderno), que é o que o
        /// `PaginasDoCaderno` faz: o rótulo antigo do recoder ("Renomear Páginas") estava errado.
        /// </remarks>
        public const string RenumerarPaginas = "Renumerar Páginas";

        public const string EditarUnidade = "Editar Unidade";

        public const string EditarAlternativo = "Editar Alternativo";

        public const string EditarTitulos = "Editar Títulos";

        public const string EditarRevisoes = "Editar Revisões";

        public const string RevisaoSimplificada = "Simplificada";

        public const string RevisaoCompleta = "Completa";

        /// <summary>Os formatos de folha do combo `Folha` do menu (literais do designer).</summary>
        public static readonly string[] FormatosDeFolha = { "12", "012", "0012", "00012", "000012", "0000012" };

        /// <summary>Rótulos de botões da barra do original que caem em comandos que temos (Ribbon.cs).</summary>
        public const string BotaoGerDwg = "GER DWG";

        public const string BotaoCbd = "CBD";

        public const string BotaoRestProj = "RESTPROJ";

        /// <summary>
        /// O resumo da **troca de blocos** (o <c>MsgBox</c> do <c>CorrigeAtributos</c>, a família
        /// <c>clsTrocaEditaBlocos.cs</c>): os índices são do <c>mMensagem</c>, e o título muda com a
        /// contagem — <c>1298</c> no singular, <c>1302</c> com mais de um, e o <c>1349</c>
        /// (&quot;Blocos Trocados&quot;) entra no lugar do título quando algum handle mudou na troca.
        /// </summary>
        public const string TipoDeBlocoTrocado = "Tipo de Bloco Trocado";

        public const string TiposDeBlocosTrocados = "Tipos de Blocos Trocados";

        public const string BlocosTrocados = "Blocos Trocados";

        public const string NaoExisteEsseBloco = "Não existe esse bloco";

        public const string NaoExistemEssesBlocos = "Não existem esses blocos";

        public const string NoDesenho = "no Desenho";
    }
}
