using System;
using System.Collections.Generic;
using Positron.Data.TrocaDeBlocos;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.TrocaDeBlocos
{
    /// <summary>
    /// O I/O da **troca de blocos**: ler os atributos do ModelSpace (o <c>LeAtributos</c>/
    /// <c>LeTodosAtributos</c> do <c>clsTrocaEditaBlocos.cs</c>) e gravar de volta pelo handle do
    /// bloco + tag (o <c>EditaUmAtributoDeUmBloco</c> do <c>clsBlocos.cs</c>). A regra é pura
    /// (<see cref="AtributosDosBlocos"/>); aqui só se fala com o desenho.
    ///
    /// O **buffer é estático**, como no original (<c>clsTrocaEditaBlocosMat.mAtributos</c>): lá os
    /// comandos são disparados por <c>SendStringToExecute</c> e não recebem nada — quem lê
    /// (<c>LeAtributos</c>) deixa no estático o que quem grava (<c>CorrigeAtributos</c>) aplica.
    /// </summary>
    internal static class AtributosDoDesenho
    {
        /// <summary>O buffer do original: o que a última leitura encontrou (só os invisíveis).</summary>
        internal static IReadOnlyList<AtributoDoBloco> Buffer = new List<AtributoDoBloco>();

        /// <summary>Os nomes dos blocos que a última leitura reconheceu (maiúscula, sem repetição).</summary>
        internal static IReadOnlyList<string> NomesExistentes = new List<string>();

        /// <summary>
        /// A lista dos blocos que **não** existem, montada pela tela
        /// (<c>frmTrocaEditaBlocos.cs:718-724</c>) — o recoder não tem a grade, então ela fica
        /// como a tela a deixaria: vazia, salvo se o comando a preencher.
        /// </summary>
        internal static string BlocosNaoExistentes = string.Empty;

        internal sealed class ResultadoDaLeitura
        {
            /// <summary>Blocos (<c>BlockReference</c>) varridos no ModelSpace.</summary>
            internal int BlocosLidos { get; set; }

            /// <summary>Blocos com pelo menos um atributo (só esses entram em <see cref="NomesExistentes"/>).</summary>
            internal int BlocosComAtributo { get; set; }

            /// <summary>Atributos lidos, visíveis e invisíveis.</summary>
            internal int AtributosLidos { get; set; }

            /// <summary>Entradas no buffer (só os atributos **invisíveis**).</summary>
            internal int EntradasNoBuffer { get; set; }
        }

        /// <summary>
        /// O <c>LeAtributos</c> (com <paramref name="nomesDeBloco"/>) e o <c>LeTodosAtributos</c>
        /// (sem filtro): varre o ModelSpace, deixa no buffer estático os atributos invisíveis e
        /// devolve as contagens. Nunca lança — o comando trata a exceção.
        /// </summary>
        internal static ResultadoDaLeitura Ler(IReadOnlyCollection<string> nomesDeBloco)
        {
            ResultadoDaLeitura resultado = new ResultadoDaLeitura();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = BornesDaCorrecao.EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                List<AtributoDoBloco> lidos = new List<AtributoDoBloco>();

                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    resultado.BlocosLidos++;

                    // O `Name` do bloco pode lançar (bloco anônimo/xref) — o original também
                    // envolve a leitura num `try`.
                    string nome;
                    try
                    {
                        nome = bloco.Name;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (!NomePermitido(nome, nomesDeBloco))
                    {
                        continue;
                    }

                    string handleDoBloco = bloco.Handle.ToString();
                    bool temAtributo = false;
                    foreach (ObjectId idAtributo in bloco.AttributeCollection)
                    {
                        AttributeReference atributo =
                            transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                        if (atributo == null)
                        {
                            continue;
                        }

                        temAtributo = true;
                        resultado.AtributosLidos++;
                        lidos.Add(new AtributoDoBloco
                        {
                            HandleDoBloco = handleDoBloco,
                            NomeDoBloco = nome,
                            Tag = atributo.Tag,
                            Valor = atributo.TextString,
                            Visivel = !atributo.Invisible,
                        });
                    }

                    if (temAtributo)
                    {
                        resultado.BlocosComAtributo++;
                    }
                }

                transacao.Commit();

                // O buffer são só os invisíveis; os nomes saem da leitura inteira (o original
                // registra o bloco assim que ele tem **algum** atributo, visível ou não).
                Buffer = AtributosDosBlocos.Invisiveis(lidos, nomesDeBloco);
                resultado.EntradasNoBuffer = Buffer.Count;
                NomesExistentes = AtributosDosBlocos.NomesDosBlocos(lidos);
            }

            return resultado;
        }

        internal sealed class ResultadoDaAplicacao
        {
            /// <summary>Entradas do buffer varridas.</summary>
            internal int Entradas { get; set; }

            /// <summary>Blocos abertos pelo handle com a tag encontrada.</summary>
            internal int BlocosCasados { get; set; }

            /// <summary>Atributos cujo texto realmente mudou (o original só grava quando difere).</summary>
            internal int AtributosAplicados { get; set; }

            /// <summary>Atributos cuja visibilidade mudou.</summary>
            internal int VisibilidadesAplicadas { get; set; }

            /// <summary>Blocos do buffer que não estão mais no desenho.</summary>
            internal int BlocosNaoAchados { get; set; }

            /// <summary>Blocos achados sem a tag do buffer.</summary>
            internal int TagsNaoAchadas { get; set; }
        }

        /// <summary>
        /// O <c>EditaUmAtributoDeUmBloco</c> do original, para todo o buffer: casa o bloco pelo
        /// handle e o atributo pela tag (sem caixa), grava o texto (só quando difere) e a
        /// visibilidade. Nunca lança.
        /// </summary>
        /// <remarks>
        /// Duas diferenças de forma em relação ao original, as duas sem efeito no dado: ele abre o
        /// atributo **ForWrite** na marra e chama <c>UpgradeOpen</c>/<c>AdjustAlignment</c>/<c>Draw</c>
        /// (o último só força o redesenho da tela); aqui o atributo abre <b>ForRead</b> e sobe para
        /// <c>UpgradeOpen</c> **quando muda** — o mesmo que os outros adaptadores de correção fazem —,
        /// e o redesenho fica com o CAD.
        ///
        /// **A diferença que importa é a visibilidade** (medida na rodada 135): o original lê e grava
        /// <c>Entity.Visible</c>, mas no ZWCAD esse membro **sempre devolve verdadeiro** — na fixture,
        /// os dois atributos invisíveis da fixture leem <c>Visible = 0</c> e <c>Invisible = 2</c> ao
        /// mesmo tempo, com o <c>70</c> do DXF em <c>1</c> —, e com ele o buffer sairia **vazio** em
        /// todo desenho. Aqui a invisibilidade vem de <see cref="AttributeReference.Invisible"/>
        /// (o mesmo flag <c>70</c> bit 1, e a propriedade que o leitor de portas do recoder já usa).
        /// </remarks>
        internal static ResultadoDaAplicacao Aplicar()
        {
            ResultadoDaAplicacao resultado = new ResultadoDaAplicacao();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                foreach (AtributoDoBloco entrada in Buffer)
                {
                    resultado.Entradas++;

                    BlockReference bloco = BornesDaCorrecao.AbrirPorHandle(transacao, banco, entrada.HandleDoBloco);
                    if (bloco == null)
                    {
                        resultado.BlocosNaoAchados++;
                        continue;
                    }

                    bool casou = false;
                    foreach (ObjectId idAtributo in bloco.AttributeCollection)
                    {
                        AttributeReference atributo =
                            transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                        if (atributo == null ||
                            !string.Equals(atributo.Tag ?? string.Empty, entrada.Tag ?? string.Empty,
                                StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        string valor = entrada.Valor ?? string.Empty;
                        if (!string.Equals(atributo.TextString ?? string.Empty, valor, StringComparison.Ordinal))
                        {
                            atributo.UpgradeOpen();
                            atributo.TextString = valor;
                            resultado.AtributosAplicados++;
                        }

                        if ((!atributo.Invisible) != entrada.Visivel)
                        {
                            atributo.UpgradeOpen();
                            atributo.Invisible = !entrada.Visivel;
                            resultado.VisibilidadesAplicadas++;
                        }

                        casou = true;
                        break;
                    }

                    if (casou)
                    {
                        resultado.BlocosCasados++;
                    }
                    else
                    {
                        resultado.TagsNaoAchadas++;
                    }
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static bool NomePermitido(string nome, IReadOnlyCollection<string> nomesDeBloco)
        {
            if (nomesDeBloco == null || nomesDeBloco.Count == 0)
            {
                return true;
            }

            string procurado = (nome ?? string.Empty).ToUpperInvariant();
            foreach (string permitido in nomesDeBloco)
            {
                if (string.Equals(procurado, (permitido ?? string.Empty).ToUpperInvariant(), StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
