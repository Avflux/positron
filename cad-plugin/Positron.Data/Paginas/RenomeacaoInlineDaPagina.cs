using System;
using System.Collections.Generic;
using Positron.Data.Interface;

namespace Positron.Data.Paginas
{
    /// <summary>O que o fim da edição da célula **Página** decide fazer (o ramo `ColumnIndex == 0`).</summary>
    public enum AcaoDaRenomeacaoInline
    {
        /// <summary>Escreve de volta o nome original da linha (o `Cells[3]`) e não renomeia.</summary>
        Reverter,

        /// <summary>
        /// Célula esvaziada: o original escreve ali a **página ativa** (o
        /// `DeclaracoesGeral.ativo.Pagina`) e retorna sem renomear.
        /// </summary>
        EscreverAtiva,

        /// <summary>O nome normalizado é igual ao original — só reescreve a célula, sem renomear.</summary>
        Escrever,

        /// <summary>Renomeia o layer da página para <see cref="PlanoDaRenomeacaoInline.Nome"/>.</summary>
        Renomear,

        /// <summary>O nome já é uma página do caderno: avisa (mMensagem 28) e escreve o original.</summary>
        JaExiste,
    }

    /// <summary>O que a célula Página faz ao terminar a edição — a decisão pura do `j9Sp1mKZkcD`.</summary>
    public sealed class PlanoDaRenomeacaoInline
    {
        /// <summary>O ramo que o original tomou.</summary>
        public AcaoDaRenomeacaoInline Acao { get; set; }

        /// <summary>O nome que a célula passa a exibir (e o novo layer, quando <see cref="AcaoDaRenomeacaoInline.Renomear"/>).</summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>A mensagem do `MsgBox` de informação (mMensagem 28); `null` quando não há aviso.</summary>
        public string Aviso { get; set; }

        /// <summary>
        /// Se a família de sincronizações do original roda depois desta edição. O original a roda em
        /// **todo** ramo que chega ao fim do `case 0` — inclusive quando o `LayerValido` recusa — mas
        /// não quando ele sai antes (célula vazia, capa, um caractere não numérico, prefixo inválido,
        /// nome inalterado).
        /// </summary>
        public bool RodarSincronizacoes { get; set; }
    }

    /// <summary>
    /// A **edição inline da célula Página** da paleta das folhas — o ramo `ColumnIndex == 0` do
    /// <c>dg.CellEndEdit</c> do reverso (`uscPaginas.cs:1733-1846`, o <c>j9Sp1mKZkcD</c>): o que o
    /// original faz quando o usuário termina de digitar um nome novo na coluna Página.
    ///
    /// O nome digitado passa pelo <c>Trim</c>/<c>ToUpper</c>, pela validação de dígitos (só o
    /// **último** caractere pode ser letra) e pelo <see cref="PaginasDoCaderno.MontaNumeroPagina"/>
    /// (a largura fixa do caderno); depois o <see cref="PaginasDoCaderno.LayerValido"/> recusa o que
    /// não é página. Quando o nome vale, o original chama o <c>Pagina.renumerarPagina</c>
    /// (`Pagina.cs:1841`), que **avisa e não renomeia** se o nome já for uma página do caderno
    /// (mMensagem 28).
    ///
    /// A **primeira linha** da grade (a capa) é protegida pelo próprio handler: qualquer edição nela
    /// volta ao nome original (não é `ReadOnly`). A célula esvaziada não é renomeada: o original
    /// escreve ali a **página ativa** (um quirk mantido), e isso vale também para a linha 0, porque o
    /// teste do vazio vem **antes** do teste da capa.
    /// </summary>
    public static class RenomeacaoInlineDaPagina
    {
        /// <summary>
        /// O plano do fim da edição: <paramref name="digitado"/> é o texto que ficou na célula,
        /// <paramref name="nomeOriginal"/> o nome carregado (a coluna `Pg`, o `Cells[3]`),
        /// <paramref name="paginaAtiva"/> o `DeclaracoesGeral.ativo.Pagina`,
        /// <paramref name="existentes"/> as páginas do caderno (o <c>mPaginas</c> que o
        /// `renumerarPagina` percorre) e <paramref name="primeiraLinha"/> se a linha é a 0 (a capa).
        /// </summary>
        public static PlanoDaRenomeacaoInline Planejar(string digitado, string nomeOriginal,
            string paginaAtiva, int larguraFixaPaginas, IReadOnlyList<string> existentes, bool primeiraLinha)
        {
            string texto = (digitado ?? string.Empty).Trim();
            if (texto.Length > 0)
            {
                texto = texto.ToUpperInvariant();
            }

            // Célula vazia: escreve a página ativa e retorna — sem renomear (antes do teste da capa).
            if (texto.Length == 0)
            {
                return new PlanoDaRenomeacaoInline
                {
                    Acao = AcaoDaRenomeacaoInline.EscreverAtiva,
                    Nome = paginaAtiva ?? string.Empty,
                };
            }

            // Linha 0 (a capa): volta ao nome carregado.
            if (primeiraLinha)
            {
                return new PlanoDaRenomeacaoInline
                {
                    Acao = AcaoDaRenomeacaoInline.Reverter,
                    Nome = nomeOriginal ?? string.Empty,
                };
            }

            // A validação do original: com um caractere só, ele tem de ser numérico; com mais, todo
            // caractere **menos o último** (a letra do alfanumérico) tem de ser dígito.
            if (!PaginaNumerada.EhNumerico(texto))
            {
                if (texto.Length == 1)
                {
                    return Reverter(nomeOriginal, false);
                }

                for (int i = 0; i < texto.Length - 1; i++)
                {
                    if (!PaginaNumerada.EhNumerico(texto.Substring(i, 1)))
                    {
                        return Reverter(nomeOriginal, false);
                    }
                }
            }

            string novo = PaginasDoCaderno.MontaNumeroPagina(texto, larguraFixaPaginas);
            if (!PaginasDoCaderno.LayerValido(novo))
            {
                // Inválido: volta ao original, mas o original ainda roda as sincronizações.
                return Reverter(nomeOriginal, true);
            }

            if (Mesma(nomeOriginal, novo))
            {
                // Igual ao carregado: só a célula normalizada, sem renomear e sem sincronizar.
                return new PlanoDaRenomeacaoInline
                {
                    Acao = AcaoDaRenomeacaoInline.Escrever,
                    Nome = novo,
                };
            }

            if (Existe(novo, existentes))
            {
                // O `renumerarPagina`: avisa (mMensagem 28) e devolve false — a célula volta ao original.
                return new PlanoDaRenomeacaoInline
                {
                    Acao = AcaoDaRenomeacaoInline.JaExiste,
                    Nome = nomeOriginal ?? string.Empty,
                    Aviso = MensagensDoReverso.EstaPaginaJaExiste,
                    RodarSincronizacoes = true,
                };
            }

            return new PlanoDaRenomeacaoInline
            {
                Acao = AcaoDaRenomeacaoInline.Renomear,
                Nome = novo,
                RodarSincronizacoes = true,
            };
        }

        private static PlanoDaRenomeacaoInline Reverter(string nomeOriginal, bool sincronizar)
        {
            return new PlanoDaRenomeacaoInline
            {
                Acao = AcaoDaRenomeacaoInline.Reverter,
                Nome = nomeOriginal ?? string.Empty,
                RodarSincronizacoes = sincronizar,
            };
        }

        private static bool Mesma(string pagina, string outra)
        {
            return string.Equals(pagina ?? string.Empty, outra ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        private static bool Existe(string pagina, IReadOnlyList<string> existentes)
        {
            if (existentes == null)
            {
                return false;
            }

            foreach (string outra in existentes)
            {
                if (Mesma(pagina, outra))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
