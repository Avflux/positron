import { useEffect, useState, type FormEvent } from "react";
import type { useProjeto } from "@/hooks/useProjeto";
import { getLastPath } from "@/lib/bridge";

type Projeto = ReturnType<typeof useProjeto>;

interface SettingsModalProps {
  onClose: () => void;
  projeto: Projeto;
}

export function SettingsModal({ onClose, projeto }: SettingsModalProps) {
  const [caminho, setCaminho] = useState("");
  const [theme, setTheme] = useState(() => document.documentElement.getAttribute("data-theme") || "dark");

  useEffect(() => {
    void getLastPath().then((ultimo) => {
      if (ultimo) {
        setCaminho((atual) => (atual === "" ? ultimo : atual));
      }
    });
  }, []);

  const onSubmit = (event: FormEvent) => {
    event.preventDefault();
    const alvo = caminho.trim();
    if (alvo) {
      void projeto.abrir(alvo);
      onClose(); // Close modal after opening
    }
  };

  const toggleTheme = () => {
    const newTheme = theme === "dark" ? "light" : "dark";
    setTheme(newTheme);
    document.documentElement.setAttribute("data-theme", newTheme);
  };

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal" onClick={(e) => e.stopPropagation()}>
        <div className="modal-header">
          <h2>Configurações</h2>
          <button className="icon-btn close-btn" onClick={onClose}>✖</button>
        </div>

        <div className="settings-section">
          <h3>Aparência</h3>
          <button onClick={toggleTheme} className="btn-primary">
            Tema atual: {theme === "dark" ? "Escuro 🌙" : "Claro ☀️"}
          </button>
        </div>

        <div className="settings-section">
          <h3>Carregamento do Banco</h3>
          <form className="open-row" onSubmit={onSubmit}>
            <input
              value={caminho}
              onChange={(e) => setCaminho(e.target.value)}
              placeholder="C:\caminho\para\projeto.db"
              aria-label="Caminho do banco do projeto"
              spellCheck={false}
            />
            <button type="submit" className="btn-primary" disabled={projeto.carregando || caminho.trim() === ""}>
              {projeto.carregando ? "Abrindo..." : "Abrir"}
            </button>
          </form>
          {projeto.erro && <p className="error">{projeto.erro}</p>}
        </div>
      </div>
    </div>
  );
}
