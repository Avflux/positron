import { useEffect, useState } from "react";
import type { Fiacao, Interligacao4, Paineis } from "@protocol";
import { request } from "@/lib/bridge";

export interface PainelDetalhe {
  fios: Fiacao[];
  trechos: Interligacao4[];
  carregando: boolean;
  erro: string | null;
}

const VAZIO: PainelDetalhe = { fios: [], trechos: [], carregando: false, erro: null };

/**
 * Fiação + interligação de um painel.
 *
 * As duas consultas são independentes, então vão em paralelo. A flag `vivo`
 * evita aplicar o resultado de um painel que já não está selecionado (trocar de
 * painel rápido deixaria a resposta antiga sobrescrever a nova).
 */
export function usePainelDetalhe(painel: Paineis | null): PainelDetalhe {
  const [state, setState] = useState<PainelDetalhe>(VAZIO);

  useEffect(() => {
    if (!painel) {
      setState(VAZIO);
      return;
    }

    let vivo = true;
    setState({ fios: [], trechos: [], carregando: true, erro: null });

    void (async () => {
      try {
        const [fiacao, interligacao] = await Promise.all([
          request("fiacao_por_painel", { painel: painel.Indice }),
          request("interligacao_por_painel", { painel: painel.Indice }),
        ]);
        if (vivo) {
          setState({ fios: fiacao.fios, trechos: interligacao.trechos, carregando: false, erro: null });
        }
      } catch (e) {
        if (vivo) {
          setState({ fios: [], trechos: [], carregando: false, erro: e instanceof Error ? e.message : String(e) });
        }
      }
    })();

    return () => {
      vivo = false;
    };
  }, [painel]);

  return state;
}
