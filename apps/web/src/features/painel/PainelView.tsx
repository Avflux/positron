import type { Paineis } from "@protocol";
import { usePainelDetalhe } from "@/hooks/usePainelDetalhe";
import { AplicacoesPanel } from "@/features/aplicacoes/AplicacoesPanel";
import { BornesPanel } from "@/features/bornes/BornesPanel";
import { CatalogoPanel } from "@/features/catalogo/CatalogoPanel";
import { CircuitosPanel } from "@/features/circuitos/CircuitosPanel";
import { ContatosPanel } from "@/features/contatos/ContatosPanel";
import { DispositivosPanel } from "@/features/dispositivos/DispositivosPanel";
import { FiacaoPanel } from "@/features/fiacao/FiacaoPanel";
import { InterligacaoPanel } from "@/features/interligacao/InterligacaoPanel";
import { JumpersPanel } from "@/features/jumpers/JumpersPanel";
import { ListaMateriaisPanel } from "@/features/materiais/ListaMateriaisPanel";
import { PlaquetasPanel } from "@/features/plaquetas/PlaquetasPanel";
import { PortasPanel } from "@/features/portas/PortasPanel";

export function PainelView({ painel }: { painel: Paineis }) {
  const {
    fios,
    trechos,
    circuitos,
    dispositivos,
    jumpers,
    aplicacoes,
    cabos,
    veias,
    materiais,
    modelosCabo,
    portas,
    bornes,
    contatos,
    plaquetas,
    listaMateriais,
    carregando,
    erro,
  } = usePainelDetalhe(painel);

  return (
    <section className="panel">
      <h2>Painel {painel.Nome ?? `#${painel.Indice}`}</h2>
      {carregando && <p className="muted">carregando…</p>}
      {erro && <p className="error">{erro}</p>}
      {!carregando && !erro && (
        <>
          <FiacaoPanel fios={fios} />
          <InterligacaoPanel trechos={trechos} />
          <CircuitosPanel circuitos={circuitos} />
          <DispositivosPanel dispositivos={dispositivos} />
          <JumpersPanel jumpers={jumpers} />
          <PortasPanel portas={portas} />
          <BornesPanel bornes={bornes} />
          <ContatosPanel contatos={contatos} />
          <AplicacoesPanel aplicacoes={aplicacoes} />
          <ListaMateriaisPanel materiais={listaMateriais} />
          <PlaquetasPanel plaquetas={plaquetas} />
          <CatalogoPanel
            cabos={cabos}
            veias={veias}
            materiais={materiais}
            modelosCabo={modelosCabo}
          />
        </>
      )}
    </section>
  );
}
