import type { useProjeto } from "@/hooks/useProjeto";
import { open, save } from "@tauri-apps/plugin-dialog";

type Projeto = ReturnType<typeof useProjeto>;

export function ProjetoPanel({ projeto, onOpenSettings }: { projeto: Projeto, onOpenSettings: () => void }) {
  const handleOpenProject = async () => {
    try {
      const selected = await open({
        multiple: false,
        directory: false,
        filters: [{ name: "Banco de Dados SQLite", extensions: ["db", "sqlite", "sqlite3"] }]
      });
      if (selected && typeof selected === "string") {
        projeto.abrir(selected);
      }
    } catch (e) {
      console.error(e);
      onOpenSettings();
    }
  };

  const handleNewProject = async () => {
    try {
      const selected = await save({
        filters: [{ name: "Banco de Dados SQLite", extensions: ["db"] }]
      });
      if (selected && typeof selected === "string") {
        projeto.abrir(selected);
      }
    } catch (e) {
      console.error(e);
      onOpenSettings();
    }
  };

  if (!projeto.caminho && !projeto.erro) {
    return (
      <div className="panel" style={{ textAlign: "center", padding: "40px 20px" }}>
        <h2 style={{ marginBottom: "8px" }}>Nenhum projeto carregado</h2>
        <p className="muted" style={{ margin: "0 0 24px" }}>Vá em Configurações ou crie um novo para começar.</p>
        
        <div style={{ display: "flex", gap: "12px", justifyContent: "center" }}>
          <button className="btn-primary" onClick={handleOpenProject} title="Carregar Projeto">
            <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
              <path d="M4 20h16a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.93a2 2 0 0 1-1.66-.9l-.82-1.2A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13c0 1.1.9 2 2 2Z"></path>
            </svg>
            Carregar Projeto
          </button>

          <button className="btn-primary" onClick={handleNewProject} title="Novo Projeto">
            <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
              <path d="M14.5 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7.5L14.5 2z"></path>
              <polyline points="14 2 14 8 20 8"></polyline>
              <line x1="12" y1="18" x2="12" y2="12"></line>
              <line x1="9" y1="15" x2="15" y2="15"></line>
            </svg>
            Novo Projeto
          </button>
        </div>
      </div>
    );
  }

  return (
    <section className="panel">
      <h2>Painéis do Projeto</h2>

      {projeto.caminho && (
        <p className="muted">
          {projeto.caminho} • {projeto.tabelas.length} tabelas • {projeto.paineis.length} painéis
        </p>
      )}

      {projeto.paineis.length > 0 && (
        <ul className="chips">
          {projeto.paineis.map((painel) => {
            const ativo = painel.Indice === projeto.selecionado?.Indice;
            return (
              <li key={painel.Indice}>
                <button
                  type="button"
                  className={ativo ? "active" : ""}
                  aria-pressed={ativo}
                  onClick={() => projeto.selecionar(painel)}
                >
                  {painel.Nome ?? `#${painel.Indice}`}
                </button>
              </li>
            );
          })}
        </ul>
      )}
    </section>
  );
}
