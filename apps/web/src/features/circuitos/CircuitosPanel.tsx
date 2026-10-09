import type { Circuitos4F } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Circuitos do painel (`Circuitos4F`) — o que o `FIA` projeta das conexões
 * (`Tipo == 1`, um por potencial). Ver `docs/POSITRON.md`.
 */
export function CircuitosPanel({ circuitos }: { circuitos: Circuitos4F[] }) {
  return (
    <div className="subsection">
      <h3>
        Circuitos <span className="muted">({circuitos.length})</span>
      </h3>
      {circuitos.length === 0 ? (
        <p className="muted">sem circuitos neste painel</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Circuito</th>
              <th>Potencial</th>
              <th>Revisão</th>
            </tr>
          </thead>
          <tbody>
            {circuitos.map((circuito) => (
              <tr key={circuito.Indice}>
                <td>{ouTraco(circuito.Circuito)}</td>
                <td>{ouTraco(circuito.Potencial)}</td>
                <td>{ouTraco(circuito.Revisao)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
