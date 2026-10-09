import type { Paineis } from "@protocol";
import { usePainelDetalhe } from "@/hooks/usePainelDetalhe";
import { AplicacoesPanel } from "@/features/aplicacoes/AplicacoesPanel";
import { CatalogoPanel } from "@/features/catalogo/CatalogoPanel";
import { CircuitosPanel } from "@/features/circuitos/CircuitosPanel";
import { DispositivosPanel } from "@/features/dispositivos/DispositivosPanel";
import { FiacaoPanel } from "@/features/fiacao/FiacaoPanel";
import { InterligacaoPanel } from "@/features/interligacao/InterligacaoPanel";
import { JumpersPanel } from "@/features/jumpers/JumpersPanel";

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
          <AplicacoesPanel aplicacoes={aplicacoes} />
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
