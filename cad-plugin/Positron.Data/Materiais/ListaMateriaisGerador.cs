using System;
using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Positron.Data.Modelos;

namespace Positron.Data.Materiais
{
    /// <summary>Uma linha de <c>ListaMateriais</c> (o <c>clsLM.LMateriais</c> do original).</summary>
    public sealed class LinhaListaMaterial
    {
        public int DWG { get; set; }

        public int Painel { get; set; }

        public string Tag { get; set; }

        public int IndiceMaterial { get; set; }

        public int Quantidade { get; set; }

        /// <summary>
        /// A coluna <c>Ordem</c> — o <c>lOrdem</c> do original. Ela é **renumerada
        /// por painel, 1..N, no fim do fluxo**.
        /// </summary>
        public int Ordem { get; set; }

        public bool Avulso { get; set; }

        public string Destino { get; set; }

        public string DescDestino { get; set; }

        public string Alternativo { get; set; }

        public string Handle { get; set; }

        /// <summary>
        /// A coluna <c>IndiceLM</c> (o <c>indexLM</c>). **Não sai desta geração:** o
        /// original a preenche em <c>RemoveItemMaterial</c>, a partir das linhas que já
        /// estavam no banco (<c>AtualizaIndiceLM</c> é outro fluxo) — quem grava decide.
        /// </summary>
        public int IndiceLM { get; set; }

        /// <summary>
        /// A coluna <c>OrdemLay</c>: a posição do equipamento no layout do painel
        /// (<c>BuscaOrdemEquipamento</c>, o dicionário <c>CENG_LAYOUT</c> do próprio
        /// desenho) — <see cref="LayoutPosicoes.OrdemEquipamentoAusente"/> (10000)
        /// quando o equipamento não está no layout e <c>0</c> nas reservas e nos
        /// itens avulsos, como no original.
        /// </summary>
        public int OrdemLay { get; set; }
    }

    /// <summary>
    /// Gera a <c>ListaMateriais</c> do desenho — o
    /// <c>clsLM.CompilaListaDeMateriais()</c> do original (o comando <c>COMPLM</c>,
    /// botão de listagem de materiais).
    ///
    /// Uma **passada única** pelo ModelSpace classifica cada bloco (o mesmo
    /// <c>verificaTipoDispositivo</c> do <c>bt12</c>) e emite linhas:
    ///
    /// | bloco | insumo | linhas |
    /// |---|---|---|
    /// | <c>M</c> (máscara) | <c>iLM1</c>/<c>iLM2</c> do **modelo de máscara** por <c>indexModelo</c> (sem modelo, os do XData) | até 2 (uma por LM) |
    /// | <c>P</c> (dispositivo) | <c>iLM1</c>/<c>iLM2</c> do **modelo de contato** por <c>indexModelo</c> (sem modelo, os do XData) | até 2 |
    /// | <c>B</c> (borne) | régua, <c>tipo</c> e <c>lm</c> | 1 **agregada** por <c>(Painel, TagRégua, tipo, lm)</c> |
    ///
    /// O <c>E</c> e o <c>A</c> **não** entram: o <c>switch</c> do original só trata
    /// <c>B</c>/<c>P</c>/<c>M</c> (o resto cai no <c>continue</c>), e o <c>Complementar</c>
    /// é pulado.
    ///
    /// Depois vêm, na ordem do original: as **reservas** de todas as réguas
    /// (agregadas às linhas de borne equivalentes), a **ordenação** e a
    /// **renumeração** — inclusive os dois detalhes que mudam o resultado e por isso
    /// foram reproduzidos: a bolha de três comparações independentes e a bolha
    /// "torta" da segunda passada, cuja primeira comparação usa o índice **de fora**
    /// (<c>mMateriais[num42]</c> contra <c>mMateriais[num45 + 1]</c>). Sem a segunda, a
    /// ordem de painéis como o 155 não sai igual à do produto.
    ///
    /// A lista **não tem revisão**: a chave é o <c>DWG</c> e o fluxo apaga e regrava
    /// por desenho — o <c>RemoveMateriaisLista</c>/<c>RemoveItemMaterial</c>.
    /// </summary>
    public static class ListaMateriaisGerador
    {
        /// <summary>
        /// Gera as linhas do desenho.
        /// </summary>
        /// <param name="dwg">O <c>DWG</c> ativo (o <c>DeclaracoesGeral.arqAtivo.Indice</c>).</param>
        /// <param name="dispositivos">Os blocos de dispositivo do desenho; só <c>M</c> e <c>P</c> entram.</param>
        /// <param name="modelosMascara">Modelos de máscara por índice (de onde saem os LM do <c>M</c>).</param>
        /// <param name="modelosContato">Modelos de contato por índice (de onde saem os LM do <c>P</c>).</param>
        /// <param name="bornes">Os bornes do desenho (<c>PontoBorne</c>), em ordem de ModelSpace.</param>
        /// <param name="reguas">O dicionário de réguas do desenho.</param>
        /// <param name="reservasPorRegua">As reservas de cada régua (<c>CENG_BORNES</c>).</param>
        /// <param name="layout">O layout do desenho (<c>CENG_LAYOUT</c>) — fonte do <c>OrdemLay</c>.</param>
        /// <param name="avulsos">As linhas <c>Avulso = true</c> que já estavam no banco (o <c>CapturaMateriaisAvulso</c>).</param>
        /// <param name="ordemDoBanco">A ordem anterior do desenho, quando <paramref name="usarOrdemDoBanco"/>.</param>
        /// <param name="usarOrdemDoBanco">
        /// O <c>Sim</c> do diálogo do original ("a ordem vem da lista do banco?").
        /// <c>false</c> = a ordem é a do desenho (o <c>Não</c>), que é o padrão do recoder.
        /// </param>
        public static List<LinhaListaMaterial> Gerar(
            int dwg,
            IEnumerable<DispositivoFiacao> dispositivos,
            IReadOnlyDictionary<int, ModeloMascara> modelosMascara,
            IReadOnlyDictionary<int, ModeloContato> modelosContato,
            IEnumerable<PontoBorne> bornes,
            ReguasModelo reguas,
            IReadOnlyDictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua,
            LayoutPosicoes layout,
            IReadOnlyList<LinhaListaMaterial> avulsos,
            IReadOnlyList<LinhaListaMaterial> ordemDoBanco,
            bool usarOrdemDoBanco)
        {
            List<MaterialDeDispositivo> dispositivosDoDesenho = new List<MaterialDeDispositivo>();
            List<MaterialDeDispositivo> mascaras = new List<MaterialDeDispositivo>();
            List<MaterialDeBorne> array = new List<MaterialDeBorne>();

            ClassificarDispositivos(
                dispositivos,
                modelosMascara,
                modelosContato,
                layout,
                dispositivosDoDesenho,
                mascaras);

            ClassificarBornes(bornes, layout, array);

            // O contador `num` do original começa em 10000 e avança na varredura, uma
            // vez por linha lançada (as duas do `M`/`P` e os bornes **novos** — as
            // reservas entram depois e não o incrementam). Ele é a Ordem inicial das
            // linhas e só sobrevive quando o fluxo **não** renumera, isto é, com uma
            // única linha na lista (o `UBound >= 2` do original).
            int num = 10000 + dispositivosDoDesenho.Count + mascaras.Count + array.Count;

            List<ReservaDeRegua> reservas = AchatReservas(reguas, reservasPorRegua);
            AplicarReservas(reservas, reguas, array);
            OrdenarBornes(array);

            List<LinhaListaMaterial> materiais = new List<LinhaListaMaterial>();
            foreach (MaterialDeDispositivo modelo in dispositivosDoDesenho)
            {
                materiais.Add(DaLinhaDeDispositivo(dwg, modelo, false, num));
                num++;
            }

            foreach (MaterialDeDispositivo mascara in mascaras)
            {
                materiais.Add(DaLinhaDeDispositivo(dwg, mascara, true, num));
                num++;
            }

            OrdenarPorPainelMaterialTag(materiais);

            foreach (MaterialDeBorne borne in array)
            {
                materiais.Add(new LinhaListaMaterial
                {
                    DWG = dwg,
                    Painel = borne.Painel,
                    Tag = borne.TagRegua,
                    Alternativo = borne.TagAlternativo,
                    IndiceMaterial = borne.IndiceMaterial,
                    Quantidade = borne.Quantidade,
                    OrdemLay = borne.OrdemLay,
                    Handle = borne.Handle,
                    Avulso = false,
                });
            }

            Renumerar(materiais);
            OrdenarPorPainelMaterialTagAlternativo(materiais);
            Renumerar(materiais);

            if (usarOrdemDoBanco)
            {
                AplicarOrdemDoBanco(materiais, ordemDoBanco);
            }

            if (avulsos != null)
            {
                foreach (LinhaListaMaterial avulso in avulsos)
                {
                    if (avulso != null)
                    {
                        materiais.Add(avulso);
                    }
                }
            }

            OrdenarPorOrdem(materiais);
            RenumerarPorPainel(materiais);

            return materiais;
        }

        /// <summary>
        /// A passada de blocos: <c>M</c> e <c>P</c> viram até duas linhas cada.
        /// O <c>Complementar</c> é pulado e o resto dos tipos (<c>B</c>/<c>E</c>/<c>A</c>/<c>I</c>)
        /// também — como no <c>switch</c> do original.
        /// </summary>
        private static void ClassificarDispositivos(
            IEnumerable<DispositivoFiacao> dispositivos,
            IReadOnlyDictionary<int, ModeloMascara> modelosMascara,
            IReadOnlyDictionary<int, ModeloContato> modelosContato,
            LayoutPosicoes layout,
            List<MaterialDeDispositivo> dispositivosDoDesenho,
            List<MaterialDeDispositivo> mascaras)
        {
            if (dispositivos == null)
            {
                return;
            }

            foreach (DispositivoFiacao dispositivo in dispositivos)
            {
                if (dispositivo == null || dispositivo.Complementar)
                {
                    continue;
                }

                bool ehMascara = string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoMascara, StringComparison.OrdinalIgnoreCase);
                bool ehDispositivo = string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoDispositivo, StringComparison.OrdinalIgnoreCase);
                if (!ehMascara && !ehDispositivo)
                {
                    continue;
                }

                string tag = TagDe(dispositivo);
                int lm1 = dispositivo.Lm1;
                int lm2 = dispositivo.Lm2;

                if (ehMascara)
                {
                    ModeloMascara modelo;
                    if (modelosMascara != null && modelosMascara.TryGetValue(dispositivo.IndexModelo, out modelo) && modelo != null)
                    {
                        lm1 = modelo.Lm1;
                        lm2 = modelo.Lm2;
                    }
                }
                else if (dispositivo.IndexModelo > 0)
                {
                    ModeloContato modelo;
                    if (modelosContato != null && modelosContato.TryGetValue(dispositivo.IndexModelo, out modelo) && modelo != null)
                    {
                        lm1 = modelo.Lm1;
                        lm2 = modelo.Lm2;
                    }
                }

                int ordemLay = layout == null
                    ? LayoutPosicoes.OrdemEquipamentoAusente
                    : layout.OrdemEquipamento(dispositivo.Painel, tag);

                // No `M` o handle da linha sai sempre vazio; no `P` ele é o handle do
                // bloco e só é gravado quando o dispositivo **não** tem modelo
                // (`indexModelo == 0`) — a decisão é do `RemoveItemMaterial`, no
                // fim do fluxo, e por isso fica marcada aqui.
                string handle = ehMascara ? string.Empty : (dispositivo.Handle ?? string.Empty);

                List<MaterialDeDispositivo> destino = ehMascara ? mascaras : dispositivosDoDesenho;
                destino.Add(new MaterialDeDispositivo
                {
                    Painel = dispositivo.Painel,
                    Tag = tag,
                    Alternativo = dispositivo.Alternativo,
                    IndiceMaterial = lm1,
                    IndexModelo = dispositivo.IndexModelo,
                    OrdemLay = ordemLay,
                    Handle = handle,
                });

                if (lm2 > 0)
                {
                    destino.Add(new MaterialDeDispositivo
                    {
                        Painel = dispositivo.Painel,
                        Tag = tag,
                        Alternativo = dispositivo.Alternativo,
                        IndiceMaterial = lm2,
                        IndexModelo = dispositivo.IndexModelo,
                        OrdemLay = ordemLay,
                        Handle = handle,
                    });
                }
            }
        }

        /// <summary>
        /// Os bornes do desenho viram **uma linha agregada** por
        /// <c>(Painel, TagRégua, tipo, lm)</c> — o laço do original que procura o par
        /// já lançado e só incrementa a quantidade.
        /// </summary>
        private static void ClassificarBornes(
            IEnumerable<PontoBorne> bornes,
            LayoutPosicoes layout,
            List<MaterialDeBorne> array)
        {
            if (bornes == null)
            {
                return;
            }

            foreach (PontoBorne ponto in bornes)
            {
                if (ponto == null || ponto.Painel == 0)
                {
                    continue;
                }

                string tagRegua = ponto.NomeRegua ?? string.Empty;
                MaterialDeBorne existente = null;
                foreach (MaterialDeBorne item in array)
                {
                    if (item.Painel == ponto.Painel
                        && string.Equals(item.TagRegua ?? string.Empty, tagRegua, StringComparison.OrdinalIgnoreCase)
                        && item.Tipo == ponto.Tipo
                        && item.IndiceMaterial == ponto.Lm)
                    {
                        existente = item;
                        break;
                    }
                }

                if (existente != null)
                {
                    existente.Quantidade++;
                    continue;
                }

                array.Add(new MaterialDeBorne
                {
                    Painel = ponto.Painel,
                    TagRegua = tagRegua,
                    TagAlternativo = ponto.Alternativo ?? string.Empty,
                    IndiceRegua = ponto.IndiceRegua,
                    Tipo = ponto.Tipo,
                    IndiceMaterial = ponto.Lm,
                    Quantidade = 1,
                    OrdemLay = layout == null
                        ? LayoutPosicoes.OrdemEquipamentoAusente
                        : layout.OrdemEquipamento(ponto.Painel, tagRegua),
                    Handle = "BORNE",
                });
            }
        }

        /// <summary>
        /// As reservas de **todas** as réguas, na ordem das réguas do dicionário —
        /// vem do <c>LeDicBornesReservaTodos</c> chamado régua a régua no original.
        /// </summary>
        private static List<ReservaDeRegua> AchatReservas(
            ReguasModelo reguas,
            IReadOnlyDictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua)
        {
            List<ReservaDeRegua> reservas = new List<ReservaDeRegua>();
            if (reguas == null || reservasPorRegua == null)
            {
                return reservas;
            }

            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                IReadOnlyList<BorneReserva> lista;
                if (!reservasPorRegua.TryGetValue(regua.Indice, out lista) || lista == null)
                {
                    continue;
                }

                foreach (BorneReserva reserva in lista)
                {
                    if (reserva != null)
                    {
                        reservas.Add(new ReservaDeRegua { IndiceRegua = regua.Indice, Reserva = reserva });
                    }
                }
            }

            return reservas;
        }

        /// <summary>
        /// As reservas entram como linha nova só quando a régua **não** tem um borne
        /// do desenho com o mesmo <c>(régua, tipo, lm)</c>; a que entra é marcada com
        /// <c>IndiceRegua = 0</c> e, em seguida, toda reserva ainda com índice
        /// incrementa a quantidade da linha equivalente — o laço duplo do original.
        /// </summary>
        private static void AplicarReservas(
            List<ReservaDeRegua> reservas,
            ReguasModelo reguas,
            List<MaterialDeBorne> array)
        {
            foreach (ReservaDeRegua reserva in reservas)
            {
                bool nova = true;
                foreach (MaterialDeBorne item in array)
                {
                    if (item.IndiceRegua == reserva.IndiceRegua
                        && item.Tipo == reserva.Reserva.Tipo
                        && item.IndiceMaterial == reserva.Reserva.Lm)
                    {
                        nova = false;
                        break;
                    }
                }

                if (!(nova && reserva.IndiceRegua > 0))
                {
                    continue;
                }

                ReguaInfo regua = reguas == null ? null : reguas.Buscar(reserva.IndiceRegua);
                array.Add(new MaterialDeBorne
                {
                    TagRegua = regua == null ? string.Empty : regua.Nome,
                    Painel = regua == null ? (short)0 : regua.Painel,
                    IndiceRegua = reserva.IndiceRegua,
                    Tipo = reserva.Reserva.Tipo,
                    IndiceMaterial = reserva.Reserva.Lm,
                    Quantidade = 1,
                    OrdemLay = 0,
                    Handle = string.Empty,
                    TagAlternativo = string.Empty,
                });

                // A reserva consumida não conta de novo na quantidade (o original
                // zera o índice no próprio registro).
                reserva.IndiceRegua = 0;
            }

            foreach (MaterialDeBorne item in array)
            {
                foreach (ReservaDeRegua reserva in reservas)
                {
                    if (item.IndiceRegua == reserva.IndiceRegua
                        && item.Tipo == reserva.Reserva.Tipo
                        && item.IndiceMaterial == reserva.Reserva.Lm)
                    {
                        item.Quantidade++;
                    }
                }
            }
        }

        /// <summary>A ordenação dos bornes: <c>IndiceMaterial</c>, <c>Painel</c>, <c>TagRégua</c>.</summary>
        private static void OrdenarBornes(List<MaterialDeBorne> array)
        {
            int total = array.Count;
            for (int o = 0; o < total; o++)
            {
                for (int j = total - 2; j >= o; j--)
                {
                    if (array[j].IndiceMaterial > array[j + 1].IndiceMaterial)
                    {
                        Trocar(array, j, j + 1);
                    }

                    if (array[j].IndiceMaterial == array[j + 1].IndiceMaterial
                        && array[j].Painel > array[j + 1].Painel)
                    {
                        Trocar(array, j, j + 1);
                    }

                    if (array[j].IndiceMaterial == array[j + 1].IndiceMaterial
                        && array[j].Painel == array[j + 1].Painel
                        && Maior(array[j].TagRegua, array[j + 1].TagRegua))
                    {
                        Trocar(array, j, j + 1);
                    }
                }
            }
        }

        /// <summary>A primeira ordenação dos materiais: <c>Painel</c>, <c>IndiceMaterial</c>, <c>Tag</c>.</summary>
        private static void OrdenarPorPainelMaterialTag(List<LinhaListaMaterial> materiais)
        {
            int total = materiais.Count;
            for (int o = 0; o < total; o++)
            {
                for (int j = total - 2; j >= o; j--)
                {
                    if (materiais[j].Painel > materiais[j + 1].Painel)
                    {
                        Trocar(materiais, j, j + 1);
                    }

                    if (materiais[j].Painel == materiais[j + 1].Painel
                        && materiais[j].IndiceMaterial > materiais[j + 1].IndiceMaterial)
                    {
                        Trocar(materiais, j, j + 1);
                    }

                    if (materiais[j].Painel == materiais[j + 1].Painel
                        && materiais[j].IndiceMaterial == materiais[j + 1].IndiceMaterial
                        && Maior(materiais[j].Tag, materiais[j + 1].Tag))
                    {
                        Trocar(materiais, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// A segunda ordenação — **com o defeito do original**: a primeira comparação
        /// olha <c>mMateriais[num42]</c> (o índice **de fora**) contra
        /// <c>mMateriais[num45 + 1]</c> (o de dentro), enquanto as outras três olham o
        /// par de dentro. Reproduzido de propósito: é o que dá a ordem de painéis como
        /// o 155 no produto (R1, SAÍDA, R3, R2 — que não é a ordem alfabética).
        /// </summary>
        private static void OrdenarPorPainelMaterialTagAlternativo(List<LinhaListaMaterial> materiais)
        {
            int total = materiais.Count;
            for (int o = 0; o < total; o++)
            {
                for (int j = total - 2; j >= o; j--)
                {
                    if (materiais[o].Painel > materiais[j + 1].Painel)
                    {
                        Trocar(materiais, j, j + 1);
                    }

                    if (materiais[o].Painel == materiais[j + 1].Painel
                        && materiais[j].IndiceMaterial > materiais[j + 1].IndiceMaterial)
                    {
                        Trocar(materiais, j, j + 1);
                    }

                    if (materiais[o].Painel == materiais[j + 1].Painel
                        && materiais[j].IndiceMaterial == materiais[j + 1].IndiceMaterial
                        && Maior(materiais[j].Tag, materiais[j + 1].Tag))
                    {
                        Trocar(materiais, j, j + 1);
                    }

                    if (materiais[o].Painel == materiais[j + 1].Painel
                        && materiais[j].IndiceMaterial == materiais[j + 1].IndiceMaterial
                        && Iguais(materiais[j].Tag, materiais[j + 1].Tag)
                        && Maior(materiais[j].Alternativo, materiais[j + 1].Alternativo))
                    {
                        Trocar(materiais, j, j + 1);
                    }
                }
            }
        }

        /// <summary>Renumera <c>Ordem</c> 1..N — o <c>lOrdem = num35</c> do original.</summary>
        private static void Renumerar(List<LinhaListaMaterial> materiais)
        {
            if (materiais.Count < 2)
            {
                // O original só renumera com `UBound >= 2`: com **uma** linha a Ordem
                // fica no valor do contador interno (10000), e é isso que ele grava.
                return;
            }

            for (int i = 0; i < materiais.Count; i++)
            {
                materiais[i].Ordem = i + 1;
            }
        }

        /// <summary>
        /// A ordem que veio da lista do banco (o <c>Sim</c> do diálogo): todas as
        /// linhas vão para depois das manuais (o <c>+ 10000</c>) e depois cada uma que
        /// casa <c>(Painel, Tag, IndiceMaterial)</c> com uma linha do banco recebe a
        /// ordem antiga.
        /// </summary>
        private static void AplicarOrdemDoBanco(
            List<LinhaListaMaterial> materiais,
            IReadOnlyList<LinhaListaMaterial> ordemDoBanco)
        {
            foreach (LinhaListaMaterial linha in materiais)
            {
                linha.Ordem += 10000;
            }

            if (ordemDoBanco == null)
            {
                return;
            }

            bool[] usada = new bool[ordemDoBanco.Count];
            foreach (LinhaListaMaterial linha in materiais)
            {
                for (int i = 0; i < ordemDoBanco.Count; i++)
                {
                    LinhaListaMaterial antiga = ordemDoBanco[i];
                    if (antiga == null || usada[i])
                    {
                        continue;
                    }

                    if (linha.Painel == antiga.Painel
                        && Iguais(linha.Tag, antiga.Tag)
                        && linha.IndiceMaterial == antiga.IndiceMaterial)
                    {
                        linha.Ordem = antiga.Ordem;
                        usada[i] = true;
                    }
                }
            }
        }

        /// <summary>A ordenação final por <c>Ordem</c> — estável, como a bolha do original.</summary>
        private static void OrdenarPorOrdem(List<LinhaListaMaterial> materiais)
        {
            int total = materiais.Count;
            for (int o = 0; o < total; o++)
            {
                for (int j = total - 2; j >= o; j--)
                {
                    if (materiais[j].Ordem > materiais[j + 1].Ordem)
                    {
                        Trocar(materiais, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// A última passada: <c>Ordem</c> volta a ser 1..N **por painel**, na ordem em
        /// que os painéis aparecem na lista.
        /// </summary>
        private static void RenumerarPorPainel(List<LinhaListaMaterial> materiais)
        {
            if (materiais.Count < 2)
            {
                return;
            }

            List<int> paineis = new List<int>();
            foreach (LinhaListaMaterial linha in materiais)
            {
                if (!paineis.Contains(linha.Painel))
                {
                    paineis.Add(linha.Painel);
                }
            }

            foreach (int painel in paineis)
            {
                int ordem = 1;
                foreach (LinhaListaMaterial linha in materiais)
                {
                    if (linha.Painel == painel)
                    {
                        linha.Ordem = ordem;
                        ordem++;
                    }
                }
            }
        }

        private static LinhaListaMaterial DaLinhaDeDispositivo(int dwg, MaterialDeDispositivo modelo, bool mascara, int ordem)
        {
            return new LinhaListaMaterial
            {
                DWG = dwg,
                Painel = modelo.Painel,
                Tag = modelo.Tag,
                Alternativo = modelo.Alternativo,
                IndiceMaterial = modelo.IndiceMaterial,
                Quantidade = 1,
                Ordem = ordem,
                OrdemLay = modelo.OrdemLay,
                // O handle do `P` só é gravado quando o dispositivo não tem modelo.
                Handle = mascara || modelo.IndexModelo != 0 ? string.Empty : modelo.Handle,
                Avulso = false,
            };
        }

        private static string TagDe(DispositivoFiacao dispositivo)
        {
            if (string.IsNullOrEmpty(dispositivo.Nome2))
            {
                return dispositivo.Nome1;
            }

            return dispositivo.Nome1 + "/" + dispositivo.Nome2;
        }

        /// <summary>A comparação de texto do original (<c>TextCompare: true</c>, sem diferenciar maiúsculas).</summary>
        private static int Comparar(string esquerda, string direita)
        {
            return string.Compare(esquerda ?? string.Empty, direita ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        private static bool Maior(string esquerda, string direita)
        {
            return Comparar(esquerda, direita) > 0;
        }

        private static bool Iguais(string esquerda, string direita)
        {
            return Comparar(esquerda, direita) == 0;
        }

        private static void Trocar<T>(List<T> lista, int a, int b)
        {
            T guardado = lista[a];
            lista[a] = lista[b];
            lista[b] = guardado;
        }

        private sealed class MaterialDeDispositivo
        {
            public short Painel { get; set; }

            public string Tag { get; set; }

            public string Alternativo { get; set; }

            public int IndiceMaterial { get; set; }

            public int IndexModelo { get; set; }

            public int OrdemLay { get; set; }

            public string Handle { get; set; }
        }

        private sealed class MaterialDeBorne
        {
            public short Painel { get; set; }

            public string TagRegua { get; set; }

            public string TagAlternativo { get; set; }

            public int IndiceRegua { get; set; }

            public int Tipo { get; set; }

            public int IndiceMaterial { get; set; }

            public int Quantidade { get; set; }

            public int OrdemLay { get; set; }

            public string Handle { get; set; }
        }

        private sealed class ReservaDeRegua
        {
            public int IndiceRegua { get; set; }

            public BorneReserva Reserva { get; set; }
        }
    }
}
