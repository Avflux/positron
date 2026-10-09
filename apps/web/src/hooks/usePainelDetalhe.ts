import { useEffect, useState } from "react";
import type {
  Aplicacao4F,
  Bornes4F,
  Cabos4,
  Circuitos4F,
  Dispositivos4F,
  Fiacao,
  Interligacao4,
  Jumper4,
  Materiais,
  ModelosCabos,
  Paineis,
  Portas4F,
  Veias4,
} from "@protocol";
import { request } from "@/lib/bridge";

export interface PainelDetalhe {
  fios: Fiacao[];
  trechos: Interligacao4[];
  circuitos: Circuitos4F[];
  dispositivos: Dispositivos4F[];
  jumpers: Jumper4[];
  aplicacoes: Aplicacao4F[];
  cabos: Cabos4[];
  veias: Veias4[];
  materiais: Materiais[];
  modelosCabo: ModelosCabos[];
  portas: Portas4F[];
  bornes: Bornes4F[];
  carregando: boolean;
  erro: string | null;
}

const VAZIO: PainelDetalhe = {
  fios: [],
  trechos: [],
  circuitos: [],
  dispositivos: [],
  jumpers: [],
  aplicacoes: [],
  cabos: [],
  veias: [],
  materiais: [],
  modelosCabo: [],
  portas: [],
  bornes: [],
  carregando: false,
  erro: null,
};

/**
 * Fiação, interligação, circuitos, dispositivos do painel e as listas da revisão
 * (jumpers, aplicações, catálogo de cabos e veias).
 *
 * As consultas são independentes, então vão em paralelo. A flag `vivo`
 * evita aplicar o resultado de um painel que já não está selecionado (trocar de
 * painel rápido deixaria a resposta antiga sobrescrever a nova).
 *
 * As quatro últimas são **por revisão** (`jumpers` por painel); como o app não tem
 * seletor de revisão, elas vão sem filtro — o contrato devolve todas as linhas.
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
        const [
          fiacao,
          interligacao,
          circuitos,
          dispositivos,
          jumpers,
          aplicacoes,
          cabos,
          veias,
          materiais,
          modelos,
          portas,
          bornes,
        ] = await Promise.all([
            request("fiacao_por_painel", { painel: painel.Indice }),
            request("interligacao_por_painel", { painel: painel.Indice }),
            request("circuitos_por_painel", { painel: painel.Indice }),
            request("dispositivos_por_painel", { painel: painel.Indice }),
            request("jumper_por_painel", { painel: painel.Indice }),
            request("aplicacoes_por_revisao", {}),
            request("cabos4_por_revisao", {}),
            request("veias4_por_revisao", {}),
            request("catalogo_listar_materiais", {}),
            request("catalogo_listar_modelos_cabo", {}),
            request("portas4f_por_revisao", {}),
            request("bornes4f_por_revisao", {}),
          ]);
        if (vivo) {
          setState({
            fios: fiacao.fios,
            trechos: interligacao.trechos,
            circuitos: circuitos.circuitos,
            dispositivos: dispositivos.dispositivos,
            jumpers: jumpers.jumpers,
            aplicacoes: aplicacoes.aplicacoes,
            cabos: cabos.cabos,
            veias: veias.veias,
            materiais: materiais.materiais,
            modelosCabo: modelos.modelos,
            portas: portas.portas,
            bornes: bornes.bornes,
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
