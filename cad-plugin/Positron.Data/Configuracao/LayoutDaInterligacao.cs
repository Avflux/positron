namespace Positron.Data.Configuracao
{
    /// <summary>
    /// O <c>switch</c> do <c>RECRIACABOS</c> (frente 7 do §7.6): qual dos dois rótulos de cabo
    /// recriar, pelo <c>Conf.InterligacaoLayout</c>.
    ///
    /// O reverso escolhe <c>clsEletrosul.RecriaTextosCaboEletrosul()</c> **só** no caso <c>1</c>;
    /// nos casos <c>0</c>, <c>2</c> e <c>3</c> chama <c>clsEletron.RecriaTextosCabo()</c>.
    /// </summary>
    public static class LayoutDaInterligacao
    {
        public const int Eletrosul = 1;

        /// <summary>O layout usa o rótulo do Eletrosul (caso <c>1</c>)?</summary>
        public static bool EhEletrosul(int interligacaoLayout)
        {
            return interligacaoLayout == Eletrosul;
        }
    }
}
