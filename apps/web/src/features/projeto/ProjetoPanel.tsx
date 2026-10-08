import type { useProjeto } from "@/hooks/useProjeto";

type Projeto = ReturnType<typeof useProjeto>;

export function ProjetoPanel({ projeto }: { projeto: Projeto }) {
  if (!projeto.caminho && !projeto.erro) {
    return (
      <div className="panel" style={{ textAlign: "center", padding: "40px 20px" }}>
        <h2 style={{ marginBottom: "8px" }}>Nenhum projeto carregado</h2>
        <p className="muted" style={{ margin: 0 }}>Vá em Configurações para carregar o banco de dados.</p>
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
