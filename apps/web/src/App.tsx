import { useState } from "react";
import { PainelView } from "@/features/painel/PainelView";
import { ProjetoPanel } from "@/features/projeto/ProjetoPanel";
import { useProjeto } from "@/hooks/useProjeto";
import { Sidebar } from "@/components/Sidebar";
import { SettingsModal } from "@/components/SettingsModal";
import { SearchDialog } from "@/components/SearchDialog";
import { WindowControls } from "@/components/WindowControls";

export default function App() {
  const projeto = useProjeto();
  const [showSettings, setShowSettings] = useState(false);
  const [showSearch, setShowSearch] = useState(false);

  return (
    <div className="layout">
      <WindowControls />
      <Sidebar 
        onOpenSettings={() => setShowSettings(true)} 
        onOpenSearch={() => setShowSearch(true)}
      />
      
      <main className="app-content">
        <header className="page-header" data-tauri-drag-region>
          <h1 data-tauri-drag-region>Pósitron</h1>
          <p className="muted" data-tauri-drag-region>Fiação e interligação do diagrama funcional</p>
        </header>

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

      {showSearch && (
        <SearchDialog onClose={() => setShowSearch(false)} />
      )}
    </div>
  );
}
