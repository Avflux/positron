using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;

namespace Positron.Data.Correcoes
{
    /// <summary>Um contato cujo índice no dicionário não é o da sua posição.</summary>
    public sealed class AjusteDeContato
    {
        public int IndiceModelo { get; set; }

        /// <summary>O índice que o contato tinha (o que está no XData dos blocos).</summary>
        public int IndiceContato { get; set; }

        /// <summary>O índice da posição (1, 2, 3...) — o que o bloco deve passar a ter.</summary>
        public int IndiceContatoNovo { get; set; }
    }

    /// <summary>
    /// O <c>CorrigeModelosDeContatos</c> do <c>Correcao.cs</c> — o par do
    /// <c>CorrigeBlocosContatosAux</c> da rodada 85: aquele reescreve os **terminais**
    /// dos blocos auxiliares; este acerta o **índice do contato**.
    ///
    /// A correção nasce de uma inconsistência do dicionário <c>CONTATOS</c>: quando o
    /// <c>Indice</c> de um contato não é o da sua **posição** na lista do modelo, o
    /// original renumera o dicionário (1, 2, 3...) e grava no desenho o índice novo —
    /// no XData <c>Dispositivo</c> (blocos auxiliares, tipo <c>A</c>) e no XData
    /// <c>Modelo</c>.
    ///
    /// **Nota de escopo:** a renumeração do **dicionário** fica fora deste recorte — o
    /// leitor do recoder já **recalcula a orientação** ao ler (<c>OrientacaoContato</c>,
    /// desvio documentado de uma rodada anterior), então gravar de volta o que se leu
    /// persistiria a orientação recalculada em vez da original; a varredura do
    /// **desenho**, que é a parte com efeito medível, entra inteira.
    /// </summary>
    public static class CorrecaoModeloDeContato
    {
        /// <summary>
        /// Os ajustes de um modelo: um por contato cujo <c>Indice</c> não é o da
        /// posição (<paramref name="contatos"/> na ordem do dicionário).
        /// </summary>
        public static IReadOnlyList<AjusteDeContato> Planejar(
            int indiceModelo,
            IReadOnlyList<ContatoAuxiliar> contatos)
        {
            List<AjusteDeContato> ajustes = new List<AjusteDeContato>();
            if (contatos == null)
            {
                return ajustes;
            }

            for (int i = 0; i < contatos.Count; i++)
            {
                ContatoAuxiliar contato = contatos[i];
                if (contato == null)
                {
                    continue;
                }

                int novo = i + 1;
                if (contato.Indice == novo)
                {
                    continue;
                }

                ajustes.Add(new AjusteDeContato
                {
                    IndiceModelo = indiceModelo,
                    IndiceContato = contato.Indice,
                    IndiceContatoNovo = novo,
                });
            }

            return ajustes;
        }

        /// <summary>
        /// Renumera os contatos **crus** pela posição (1, 2, 3...) — é a gravação do
        /// <c>GravaOsContatosAuxiliarDoModeloDoDicionario</c> — preservando todo o resto do
        /// registro (inclusive a orientação, que o leitor tipado recalcularia).
        /// </summary>
        public static IReadOnlyList<ModelosContato.ContatoBruto> Renumerar(
            IReadOnlyList<ModelosContato.ContatoBruto> contatos,
            out bool mudou)
        {
            mudou = false;
            List<ModelosContato.ContatoBruto> saida = new List<ModelosContato.ContatoBruto>();
            if (contatos == null)
            {
                return saida;
            }

            for (int i = 0; i < contatos.Count; i++)
            {
                ModelosContato.ContatoBruto contato = contatos[i];
                int novo = i + 1;
                if (contato == null || contato.Valores == null || contato.Valores.Count == 0)
                {
                    saida.Add(contato);
                    continue;
                }

                IReadOnlyList<TypedXData> valores = contato.Valores;
                int atual = XDataNumero.Inteiro(valores[0].Valor);
                if (atual == novo)
                {
                    saida.Add(contato);
                    continue;
                }

                List<TypedXData> renumerado = new List<TypedXData>
                {
                    new TypedXData(valores[0].Codigo, novo),
                };
                for (int k = 1; k < valores.Count; k++)
                {
                    renumerado.Add(valores[k]);
                }

                mudou = true;
                saida.Add(new ModelosContato.ContatoBruto { Valores = renumerado });
            }

            return saida;
        }

        /// <summary>
        /// O índice novo do par (modelo, contato) — ou <c>-1</c> quando não há ajuste
        /// (o original compara o par e desiste quando o contato já é o da posição).
        /// </summary>
        public static int ContatoNovo(
            IReadOnlyList<AjusteDeContato> ajustes,
            int indiceModelo,
            int indiceContato)
        {
            if (ajustes == null)
            {
                return -1;
            }

            foreach (AjusteDeContato ajuste in ajustes)
            {
                if (ajuste != null &&
                    ajuste.IndiceModelo == indiceModelo &&
                    ajuste.IndiceContato == indiceContato &&
                    ajuste.IndiceContato != ajuste.IndiceContatoNovo)
                {
                    return ajuste.IndiceContatoNovo;
                }
            }

            return -1;
        }
    }
}
