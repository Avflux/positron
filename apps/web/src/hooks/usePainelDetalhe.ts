import { useEffect, useState } from "react";
import type {
  Aplicacao4F,
  Bornes4F,
  Cabos4,
  Contatos4F,
  Circuitos4F,
  Dispositivos4F,
  Fiacao,
  Interligacao4,
  Jumper4,
  ListaMateriais,
  Materiais,
  ModelosCabos,
  Paineis,
  Plaquetas4,
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
  contatos: Contatos4F[];
  plaquetas: Plaquetas4[];
  listaMateriais: ListaMateriais[];
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
  contatos: [],
  plaquetas: [],
  listaMateriais: [],
  carregando: false,
  erro: null,
};

/**
 * Fiação, interligação, circuitos, dispositivos do painel e as listas do projeto
 * (jumpers, aplicações, catálogo de cabos/veias/materiais, portas/bornes/contatos,
 * plaquetas e lista de material do painel).
 *
 * As consultas são independentes, então vão em paralelo. A flag `vivo`
 * evita aplicar o resultado de um painel que já não está selecionado (trocar de
 * painel rápido deixaria a resposta antiga sobrescrever a nova).
 *
 * As consultas **por revisão** (`jumpers` é por painel) vão sem filtro, porque o app
 * não tem seletor de revisão — o contrato devolve todas as linhas. As de `Plaquetas4`
 * e `ListaMateriais` são **por painel e sem revisão**: a chave dessas tabelas é o `DWG`
 * (quem as grava é o `EPLQ`/`COMPLM` do plugin).
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
          contatos,
          plaquetas,
          listaMateriais,
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
            request("contatos4f_por_revisao", {}),
            request("plaquetas_por_painel", { painel: painel.Indice }),
            request("lista_materiais_por_painel", { painel: painel.Indice }),
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
            contatos: contatos.contatos,
            plaquetas: plaquetas.plaquetas,
            listaMateriais: listaMateriais.materiais,
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
