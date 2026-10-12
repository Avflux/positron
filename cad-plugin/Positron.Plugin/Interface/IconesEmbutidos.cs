using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// Os **icones do produto original**, embutidos no plugin (o `..\lib\Icons\*.png`, extraidos
    /// do DLL pelo `scripts/extrair-icones-do-reverso.ps1`).
    ///
    /// A conversao e a do `Ribbon.getBitmap` do reverso: o `Bitmap` vai para um `MemoryStream`
    /// em PNG e vira `BitmapImage` para o ribbon. O original usa o icone generico `Item` nos
    /// botoes sem icone proprio — aqui o fallback e o mesmo.
    /// </summary>
    internal static class IconesEmbutidos
    {
        internal const string Generico = "Item";

        private static readonly Dictionary<string, Bitmap> Cache = new Dictionary<string, Bitmap>();

        /// <summary>O Bitmap do icone (ou o generico quando o nome nao existe).</summary>
        internal static Bitmap BitmapDe(string nome)
        {
            string chave = string.IsNullOrEmpty(nome) ? Generico : nome;
            Bitmap guardado;
            if (Cache.TryGetValue(chave, out guardado))
            {
                return guardado;
            }

            Assembly assembly = typeof(IconesEmbutidos).Assembly;
            using (Stream fluxo = assembly.GetManifestResourceStream("Positron.Icons." + chave + ".png"))
            {
                if (fluxo == null)
                {
                    // Sem o icone pedido, cai no generico (e, sem ele, nulo).
                    return chave == Generico ? null : BitmapDe(Generico);
                }

                Bitmap imagem = new Bitmap(fluxo);
                Cache[chave] = imagem;
                return imagem;
            }
        }

        private static readonly Dictionary<string, BitmapImage> CacheRibbon =
            new Dictionary<string, BitmapImage>();

        /// <summary>O icone pronto para o ribbon (o `getBitmap` do reverso).</summary>
        internal static BitmapImage Imagem(string nome)
        {
            string chave = string.IsNullOrEmpty(nome) ? Generico : nome;
            BitmapImage guardada;
            if (CacheRibbon.TryGetValue(chave, out guardada))
            {
                return guardada;
            }

            Bitmap bitmap = BitmapDe(chave);
            if (bitmap == null)
            {
                return null;
            }

            using (MemoryStream memoria = new MemoryStream())
            {
                bitmap.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage imagem = new BitmapImage();
                imagem.BeginInit();
                imagem.StreamSource = memoria;
                imagem.CacheOption = BitmapCacheOption.OnLoad;
                imagem.EndInit();
                imagem.Freeze();

                CacheRibbon[chave] = imagem;
                return imagem;
            }
        }
    }
}
