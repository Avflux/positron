import { useEffect, useState } from "react";
import type { Circuitos4F, Dispositivos4F, Fiacao, Interligacao4, Paineis } from "@protocol";
import { request } from "@/lib/bridge";

export interface PainelDetalhe {
  fios: Fiacao[];
  trechos: Interligacao4[];
  circuitos: Circuitos4F[];
  dispositivos: Dispositivos4F[];
  carregando: boolean;
  erro: string | null;
}

const VAZIO: PainelDetalhe = {
  fios: [],
  trechos: [],
  circuitos: [],
  dispositivos: [],
  carregando: false,
  erro: null,
};

/**
 * Fiação, interligação, circuitos e dispositivos de um painel.
 *
 * As consultas são independentes, então vão em paralelo. A flag `vivo`
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
    setState({ ...VAZIO, carregando: true });

    void (async () => {
      try {
        const [fiacao, interligacao, circuitos, dispositivos] = await Promise.all([
          request("fiacao_por_painel", { painel: painel.Indice }),
          request("interligacao_por_painel", { painel: painel.Indice }),
          request("circuitos_por_painel", { painel: painel.Indice }),
          request("dispositivos_por_painel", { painel: painel.Indice }),
        ]);
        if (vivo) {
          setState({
            fios: fiacao.fios,
            trechos: interligacao.trechos,
            circuitos: circuitos.circuitos,
            dispositivos: dispositivos.dispositivos,
            carregando: false,
            erro: null,
          });
        }
      } catch (e) {
        if (vivo) {
          setState({
            ...VAZIO,
            erro: e instanceof Error ? e.message : String(e),
          });
        }
      }
    })();

    return () => {
      vivo = false;
    };
  }, [painel]);

  return state;
}
