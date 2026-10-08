import { useState } from "react";
import { PainelView } from "@/features/painel/PainelView";
import { ProjetoPanel } from "@/features/projeto/ProjetoPanel";
import { useProjeto } from "@/hooks/useProjeto";
import { Sidebar } from "@/components/Sidebar";
import { SettingsModal } from "@/components/SettingsModal";
import { WindowControls } from "@/components/WindowControls";

export default function App() {
  const projeto = useProjeto();
  const [showSettings, setShowSettings] = useState(false);

  return (
    <div className="app-wrapper">
      <WindowControls />
      <div className="layout">
        <Sidebar
          onOpenSettings={() => setShowSettings(true)}
        />

        <main className="app-content">
        <header className="page-header" data-tauri-drag-region></header>

        <div className="stack">
          <ProjetoPanel projeto={projeto} />
          {projeto.selecionado && <PainelView painel={projeto.selecionado} />}
        </div>
      </main>

      {showSettings && (
        <SettingsModal
          projeto={projeto}
          onClose={() => setShowSettings(false)}
        />
      )}
      </div>
    </div>
  );
}
