import type { Dispositivos4F } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Dispositivos do painel (`Dispositivos4F`) — um por bloco `P`/`M` do desenho,
 * projetado pelo `FIA`. Ver `docs/POSITRON.md`.
 */
export function DispositivosPanel({ dispositivos }: { dispositivos: Dispositivos4F[] }) {
  return (
    <div className="subsection">
      <h3>
        Dispositivos <span className="muted">({dispositivos.length})</span>
      </h3>
      {dispositivos.length === 0 ? (
        <p className="muted">sem dispositivos neste painel</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Tag</th>
              <th>Tipo</th>
              <th>Alternativo</th>
              <th>Pág.</th>
              <th>Posição</th>
            </tr>
          </thead>
          <tbody>
            {dispositivos.map((dispositivo) => (
              <tr key={dispositivo.Indice}>
                <td>{ouTraco(dispositivo.Tag)}</td>
                <td>{ouTraco(dispositivo.Tipo)}</td>
                <td>{ouTraco(dispositivo.Alternativo)}</td>
                <td>{ouTraco(dispositivo.Pagina)}</td>
                <td>{ouTraco(dispositivo.PosicaoNum)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
