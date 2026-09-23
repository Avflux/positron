namespace Positron.Data.Correcoes
{
    /// <summary>
    /// <c>CorrigeBornes</c> (o <c>CorrecaoBornesVisiveis</c> do <c>Correcao.cs</c>):
    /// o borne cujo campo <c>Visivel</c> está em <c>-1</c> volta para <c>0</c>.
    ///
    /// É uma correção de **um campo**: o original varre os blocos <c>B</c> e, quando
    /// acha um com <c>Visivel == -1</c>, regrava o XData pelo mesmo
    /// <c>GravarXDataDispBorne</c> (que ainda resolve o <c>lm</c> — o
    /// <c>ReguasModelo.BuscarLm</c> que a correção de ordem já usa). Quem varre o
    /// desenho é o adapter do plugin.
    /// </summary>
    public static class CorrecaoVisibilidadeBorne
    {
        /// <summary>O valor que o original substitui.</summary>
        public const int VisivelInvalido = -1;

        /// <summary>O valor que entra no lugar.</summary>
        public const int VisivelCorrigido = 0;

        /// <summary>O borne precisa da correção de visibilidade.</summary>
        public static bool PrecisaCorrigir(int visivel)
        {
            return visivel == VisivelInvalido;
        }
    }

    /// <summary>
    /// <c>CorrigeDisp</c> (o <c>CorrecaoDisp</c> do <c>Correcao.cs</c>): renomeia o
    /// app name **legado** <c>"DISPOSITIVO"</c> para <c>"Dispositivo"</c> na tabela
    /// <c>APPID</c> do desenho.
    ///
    /// É a migração do nome antigo, que sobrevive em desenhos mais velhos: os
    /// leitores do recoder aceitam os dois (o original também), mas os
    /// **gravadores** usam só <c>"Dispositivo"</c> — então um desenho com o nome
    /// legado fica com dois app names para a mesma coisa até esta migração.
    /// </summary>
    public static class CorrecaoAppNameDispositivo
    {
        public const string Legado = "DISPOSITIVO";

        public const string Atual = "Dispositivo";

        /// <summary>Os nomes são os mesmos que os leitores de XData do recoder aceitam.</summary>
        public static bool BateComOsLeitores()
        {
            return string.Equals(Legado, Bornes.BorneXData.AppNameLegado, System.StringComparison.Ordinal)
                && string.Equals(Atual, Bornes.BorneXData.AppName, System.StringComparison.Ordinal);
        }
    }
}
