import { useEffect, useState, type FormEvent } from "react";
import type { useProjeto } from "@/hooks/useProjeto";
import { getLastPath } from "@/lib/bridge";

type Projeto = ReturnType<typeof useProjeto>;

export function ProjetoPanel({ projeto }: { projeto: Projeto }) {
  const [caminho, setCaminho] = useState("");

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
    if (alvo) void projeto.abrir(alvo);
  };

  return (
    <section className="panel">
      <h2>Projeto</h2>

      <form className="open-row" onSubmit={onSubmit}>
        <input
          value={caminho}
          onChange={(e) => setCaminho(e.target.value)}
          placeholder="C:\caminho\para\projeto.db"
          aria-label="Caminho do banco do projeto"
          spellCheck={false}
        />
        <button type="submit" disabled={projeto.carregando || caminho.trim() === ""}>
          {projeto.carregando ? "abrindo…" : "abrir"}
        </button>
      </form>

      {projeto.erro && <p className="error">{projeto.erro}</p>}

      {projeto.caminho && (
        <p className="muted">
          {projeto.caminho} · {projeto.tabelas.length} tabelas · {projeto.paineis.length} painéis
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
