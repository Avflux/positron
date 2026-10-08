import type { Paineis } from "@protocol";
import { usePainelDetalhe } from "@/hooks/usePainelDetalhe";
import { FiacaoPanel } from "@/features/fiacao/FiacaoPanel";
import { InterligacaoPanel } from "@/features/interligacao/InterligacaoPanel";

export function PainelView({ painel }: { painel: Paineis }) {
  const { fios, trechos, carregando, erro } = usePainelDetalhe(painel);

  return (
    <section className="panel">
      <h2>Painel {painel.Nome ?? `#${painel.Indice}`}</h2>
      {carregando && <p className="muted">carregando…</p>}
      {erro && <p className="error">{erro}</p>}
      {!carregando && !erro && (
        <>
          <FiacaoPanel fios={fios} />
          <InterligacaoPanel trechos={trechos} />
        </>
      )}
    </section>
  );
}
