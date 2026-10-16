using System;

namespace Positron.Data.Paginas
{
    /// <summary>frmEditaTitulos: edição local da grade, aplicada ao DWG só por Editar.</summary>
    public static class EdicaoDaGradeDeTitulos
    {
        public static string Colar(int coluna, string atual, string copiado)
        {
            return coluna <= 0 ? atual : Limitar(coluna, copiado);
        }

        public static string Limpar(int coluna, string atual)
        {
            return coluna <= 0 ? atual : string.Empty;
        }

        public static string Substituir(int coluna, string atual, string de, string para)
        {
            if (coluna <= 0 || string.IsNullOrEmpty(de) || !(atual ?? "").Contains(de)) return atual;
            return Limitar(coluna, atual.Replace(de, para ?? "").Trim());
        }

        public static string Limitar(int coluna, string valor)
        {
            valor = valor ?? string.Empty;
            return coluna == 6 && valor.Length > 20 ? valor.Substring(0, 20) : valor;
        }
    }
}
