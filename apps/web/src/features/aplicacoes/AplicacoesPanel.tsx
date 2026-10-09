import type { Aplicacao4F } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Aplicações da revisão (`Aplicacao4F`) — os tipos do dicionário `APLICACAO/TIPOS`
 * do desenho, que o `FIA` copia (`FiRUTW6Q6W`). Lista da revisão, não do painel.
 */
export function AplicacoesPanel({ aplicacoes }: { aplicacoes: Aplicacao4F[] }) {
  return (
    <div className="subsection">
      <h3>
        Aplicações <span className="muted">({aplicacoes.length})</span>
      </h3>
      {aplicacoes.length === 0 ? (
        <p className="muted">sem aplicações na revisão</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Número</th>
              <th>Nome</th>
              <th>Seção</th>
              <th>Cor</th>
              <th>Tipo de cabo</th>
            </tr>
          </thead>
          <tbody>
            {aplicacoes.map((aplicacao) => (
              <tr key={aplicacao.Indice}>
                <td>{ouTraco(aplicacao.Numero)}</td>
                <td>{ouTraco(aplicacao.Nome)}</td>
                <td>{ouTraco(aplicacao.Secao)}</td>
                <td>{ouTraco(aplicacao.Cor)}</td>
                <td>{ouTraco(aplicacao.TipoCabo)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
