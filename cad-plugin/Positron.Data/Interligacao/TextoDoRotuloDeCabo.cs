using System.Globalization;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// O **texto do rótulo de cabo** que o `RecriaTextosCabo` grava — o trecho do
    /// `clsEditarInterligacao.InsereTextosDeCabos` (caminho do **modelo padrão**, o
    /// `bPadraoEL = true` do comando; `InterligacaoLayout != 3`).
    ///
    /// | condição | texto |
    /// |---|---|
    /// | `NomeVeia` vazio, `NumVeia != -1000`, `ocultaTag == 0` | `Tag_Cabo` + separador + `NumVeia` |
    /// | ... e `NumVeia == 1` num cabo **singelo** (`Cabos.Formacao like '%1x%'`) | só `Tag_Cabo` |
    /// | `NomeVeia` vazio, `NumVeia == -1000`, `ocultaTag == 0` | o caracter de terminal indefinido (`?`) |
    /// | `NomeVeia` preenchido | `(NomeVeia)`, com `Tag_Cabo ` na frente quando `ocultaTag == 0` |
    /// | `ocultaTag != 0` | sem a tag |
    /// | `NumVeia == -1000` com tag oculta | **vazio** (nada a escrever) |
    ///
    /// O separador e o caracter vêm da configuração (`SeparadorCaboVeia`, padrão
    /// `/`, e `CaracterTerminalIndefinido`, padrão `?`); o "singelo" vem do catálogo
    /// (`SELECT Tag FROM Cabos WHERE Formacao like '%1x%'`), resolvido pelo adapter.
    /// </summary>
    public static class TextoDoRotuloDeCabo
    {
        public static string Calcular(
            InterligacaoXData ilig,
            string separadorCaboVeia,
            string caracterTerminalIndefinido,
            bool caboSingelo)
        {
            if (ilig == null)
            {
                return string.Empty;
            }

            string tag = ilig.Tag_Cabo ?? string.Empty;
            bool mostraTag = ilig.OcultaTag == 0;

            if ((ilig.NomeVeia ?? string.Empty).Trim().Length == 0)
            {
                if (ilig.NumVeia != InterligacaoXData.NumVeiaIndefinido)
                {
                    string texto = ilig.NumVeia.ToString(CultureInfo.InvariantCulture);
                    if (mostraTag)
                    {
                        texto = tag + (separadorCaboVeia ?? string.Empty) + texto;
                    }

                    if (ilig.NumVeia == 1 && caboSingelo)
                    {
                        texto = tag;
                    }

                    return texto;
                }

                return mostraTag ? (caracterTerminalIndefinido ?? string.Empty) : string.Empty;
            }

            string comNome = "(" + ilig.NomeVeia + ")";
            return mostraTag ? tag + " " + comNome : comNome;
        }
    }
}
