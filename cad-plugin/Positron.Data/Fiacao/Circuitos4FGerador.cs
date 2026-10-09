using System.Collections.Generic;

namespace Positron.Data.Fiacao
{
    /// <summary>Uma linha de <c>Circuitos4F</c>.</summary>
    public sealed class Circuito4F
    {
        public short Painel { get; set; }

        public string Circuito { get; set; }

        public int Potencial { get; set; }
    }

    /// <summary>
    /// Gera <c>Circuitos4F</c> — o <c>t6yXrlfi5w</c> do <c>frmCompilarFiacao</c>:
    /// varre as conexões (<c>CONEXAO</c>) do desenho e grava **um circuito por
    /// potencial**.
    ///
    /// A varredura é das **conexões**, não dos pontos de fiação: uma `Tipo 1` sem
    /// `Disp1`/`Disp2` não gera ponto (`PontosDaConexao`), mas **gera circuito** se
    /// tiver nome — é o que o original faz (o laço dele percorre as polylines).
    ///
    /// Regras do original, na mesma ordem:
    ///
    /// 1. o painel da conexão tem que estar em uso (<c>enPUKxbphX</c>);
    /// 2. só o <c>Tipo == 1</c> (liga/fase) entra;
    /// 3. o <c>Nome</c> não pode ser vazio (comparado já com <c>Trim</c>);
    /// 4. dedup **por <c>Potencial</c>** — o primeiro que passa vence, e a
    ///    <c>Circuito</c> gravada é o <c>Nome</c> cru (o original passa
    ///    <c>conex.Nome</c> sem recortar).
    /// </summary>
    public static class Circuitos4FGerador
    {
        public static List<Circuito4F> Gerar(IEnumerable<ConexaoFiacao> conexoes, ICollection<int> paineisEmUso)
        {
            List<Circuito4F> circuitos = new List<Circuito4F>();
            if (conexoes == null)
            {
                return circuitos;
            }

            HashSet<int> potenciais = new HashSet<int>();
            foreach (ConexaoFiacao conexao in conexoes)
            {
                if (conexao == null)
                {
                    continue;
                }

                if (paineisEmUso != null && !paineisEmUso.Contains(conexao.Painel))
                {
                    continue;
                }

                if (conexao.Tipo != 1)
                {
                    continue;
                }

                string nome = conexao.Nome;
                if (string.IsNullOrEmpty(nome) || nome.Trim().Length == 0)
                {
                    continue;
                }

                // Só consome o potencial quando a linha entra (mesma ordem de
                // curto-circuito do original: o list.Contains é o último teste).
                if (!potenciais.Add(conexao.Potencial))
                {
                    continue;
                }

                circuitos.Add(new Circuito4F
                {
                    Painel = conexao.Painel,
                    Circuito = nome,
                    Potencial = conexao.Potencial,
                });
            }

            return circuitos;
        }
    }
}
