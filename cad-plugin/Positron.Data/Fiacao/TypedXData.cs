namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Um valor de XData (par código DXF / valor) numa forma **neutra**, sem o
    /// tipo <c>TypedValue</c> do ZWCAD.
    ///
    /// Existe para que o parser da fiação seja puro e testável: o adapter do
    /// ZWCAD (<c>Positron.Plugin</c>) traduz o <c>ResultBuffer</c> para esta
    /// lista, e o resto do código não precisa do ZWCAD para rodar.
    /// </summary>
    public struct TypedXData
    {
        public TypedXData(short codigo, object valor)
        {
            Codigo = codigo;
            Valor = valor;
        }

        /// <summary>Código de grupo DXF (1001 = app name, 1000 = texto, 1070/1071 = inteiro, 1040 = real).</summary>
        public short Codigo;

        public object Valor;
    }
}
