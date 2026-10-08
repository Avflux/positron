import { HealthPanel } from "@/features/health/HealthPanel";
import { PainelView } from "@/features/painel/PainelView";
import { ProjetoPanel } from "@/features/projeto/ProjetoPanel";
import { useProjeto } from "@/hooks/useProjeto";

export default function App() {
  const projeto = useProjeto();

  return (
    <main className="app">
      <header>
        <div className="app-brand">
          <img src="/icon.svg" alt="" />
          <h1>Positron</h1>
        </div>
        <p className="muted">Fiação e interligação do diagrama funcional</p>
      </header>

      <div className="stack">
        <ProjetoPanel projeto={projeto} />
        {projeto.selecionado && <PainelView painel={projeto.selecionado} />}
        <HealthPanel />
      </div>
    </main>
  );
}
