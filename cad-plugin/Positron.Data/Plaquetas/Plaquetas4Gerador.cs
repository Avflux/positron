using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Bornes;

namespace Positron.Data.Plaquetas
{
    /// <summary>
    /// Gera <c>Plaquetas4</c> — o <c>clsDispositivoTacito.exportaPlaquetas()</c> do
    /// original (comando <c>EPLQ</c>).
    ///
    /// A tabela é a **plaqueta de identificação** de cada painel: o desenho guarda
    /// na sua própria biblioteca (<c>CENG_PLAQUETA</c>) quais plaquetas existem,
    /// com tipo e descrição; este gerador resolve o **nome** de cada uma e grava o
    /// que tem destino.
    ///
    /// Regras fiéis ao original:
    ///
    /// - Só entram painéis **com fiação** no desenho (o
    ///   <c>clsConexao.carregaEquipComFiacao</c>: os painéis citados pelas
    ///   <c>CONEXAO</c>) **e** com registro no dicionário (<c>CENG_PLAQUETA</c>).
    /// - O **nome** (que vira <c>Tag</c>) depende do tipo:
    ///   <c>"P"</c> = nome do painel (cadastro <c>Paineis</c>);
    ///   <c>"D"</c> = <c>Nome1[/Nome2]</c> do bloco <c>M</c>/<c>P</c> do painel, pelo
    ///   handle (<c>carregaNomeDispositivosPM</c>);
    ///   <c>"X"</c> = a primeira descrição não-vazia;
    ///   <c>"R"</c> = nome da régua pelo <c>IndiceRegua</c> (dicionário
    ///   <c>REGUAS/MODELOS2</c>, o mesmo <see cref="ReguasModelo"/> do <c>FIA</c>).
    /// - Só grava quando há **nome** e **alguma descrição** (as plaquetas sem texto
    ///   não têm o que imprimir).
    ///
    /// **O que não é portado:** o original, no ramo <c>"X"</c>, calcula
    /// <c>Ordem = CInt(Handle.Replace("#", ""))</c> — e **não** grava essa ordem em
    /// lugar nenhum (o <c>Insert into Plaquetas4</c> não tem coluna de ordem, e a
    /// tabela também não). Reproduzir o cálculo só traria o risco de
    /// <c>FormatException</c> com um handle não-numérico; ele fica de fora e o
    /// motivo fica registrado aqui.
    /// </summary>
    public static class Plaquetas4Gerador
    {
        public static List<Plaquetas4Row> Gerar(
            int dwg,
            IReadOnlyDictionary<int, IReadOnlyList<PlaquetaDefinicao>> plaquetasPorPainel,
            IReadOnlyDictionary<int, string> nomesDePaineis,
            ReguasModelo reguas,
            ICollection<int> paineisComFiacao,
            IReadOnlyDictionary<int, IReadOnlyDictionary<string, string>> nomesDeDispositivosPorPainel)
        {
            List<Plaquetas4Row> linhas = new List<Plaquetas4Row>();
            if (plaquetasPorPainel == null || nomesDePaineis == null)
            {
                return linhas;
            }

            foreach (KeyValuePair<int, string> painel in nomesDePaineis)
            {
                int indicePainel = painel.Key;

                // `if (!lEquip.Contains(key)) continue;`
                if (paineisComFiacao == null || !paineisComFiacao.Contains(indicePainel))
                {
                    continue;
                }

                // `if (!DicionarioPlaqueta.ExisteDicPlaquetaPainel(...)) continue;`
                IReadOnlyList<PlaquetaDefinicao> plaquetas;
                if (!plaquetasPorPainel.TryGetValue(indicePainel, out plaquetas) || plaquetas == null)
                {
                    continue;
                }

                IReadOnlyDictionary<string, string> nomesDeDispositivos;
                nomesDeDispositivosPorPainel.TryGetValue(indicePainel, out nomesDeDispositivos);

                foreach (PlaquetaDefinicao plaqueta in plaquetas)
                {
                    string nome = ResolverNome(plaqueta, painel.Value, reguas, nomesDeDispositivos);

                    if (string.IsNullOrEmpty(nome))
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(plaqueta.Desc1)
                        && string.IsNullOrEmpty(plaqueta.Desc2)
                        && string.IsNullOrEmpty(plaqueta.Desc3))
                    {
                        continue;
                    }

                    // `AdicionaItemPlaqueta`: DWG, Painel, Tag(=Nome), Desc1, Desc2,
                    // Desc3, Modelo. `Quantidade` fica ausente (NULL) — o original
                    // não a informa neste INSERT.
                    linhas.Add(new Plaquetas4Row
                    {
                        DWG = dwg,
                        Painel = indicePainel,
                        Tag = nome,
                        Desc1 = plaqueta.Desc1,
                        Desc2 = plaqueta.Desc2,
                        Desc3 = plaqueta.Desc3,
                        Modelo = plaqueta.Modelo,
                    });
                }
            }

            return linhas;
        }

        private static string ResolverNome(
            PlaquetaDefinicao plaqueta,
            string nomeDoPainel,
            ReguasModelo reguas,
            IReadOnlyDictionary<string, string> nomesDeDispositivos)
        {
            string tipo = plaqueta.Tipo ?? string.Empty;

            if (string.Equals(tipo, "P", StringComparison.OrdinalIgnoreCase))
            {
                return nomeDoPainel ?? string.Empty;
            }

            if (string.Equals(tipo, "D", StringComparison.OrdinalIgnoreCase))
            {
                string nome;
                if (nomesDeDispositivos != null
                    && plaqueta.Handle != null
                    && nomesDeDispositivos.TryGetValue(plaqueta.Handle, out nome))
                {
                    return nome;
                }

                return string.Empty;
            }

            if (string.Equals(tipo, "X", StringComparison.OrdinalIgnoreCase))
            {
                // Primeira descrição não-vazia (o original compara com `Trim`).
                if (!string.IsNullOrEmpty(plaqueta.Desc1) && plaqueta.Desc1.Trim().Length > 0)
                {
                    return plaqueta.Desc1;
                }

                if (!string.IsNullOrEmpty(plaqueta.Desc2) && plaqueta.Desc2.Trim().Length > 0)
                {
                    return plaqueta.Desc2;
                }

                return plaqueta.Desc3 ?? string.Empty;
            }

            if (string.Equals(tipo, "R", StringComparison.OrdinalIgnoreCase))
            {
                return NomeDaRegua(reguas, plaqueta.IndiceRegua);
            }

            return string.Empty;
        }

        private static string NomeDaRegua(ReguasModelo reguas, int indiceRegua)
        {
            if (reguas == null)
            {
                return string.Empty;
            }

            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                if (regua != null && regua.Indice == indiceRegua)
                {
                    return regua.Nome ?? string.Empty;
                }
            }

            return string.Empty;
        }
    }
}
