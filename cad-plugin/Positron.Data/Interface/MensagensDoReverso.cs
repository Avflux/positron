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
    /// 3. o recorte `[PT]` fica em `Positron.Data/Interface/mensagens-pt.txt`.
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

        /// <summary>Rótulos de botões da barra do original que caem em comandos que temos (Ribbon.cs).</summary>
        public const string BotaoGerDwg = "GER DWG";

        public const string BotaoCbd = "CBD";

        public const string BotaoRestProj = "RESTPROJ";
    }
}
