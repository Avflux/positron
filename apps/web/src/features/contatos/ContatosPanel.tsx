import type { Contatos4F } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Contatos do diagrama (`Contatos4F`) — um por terminal declarado pelo modelo de
 * contato (`sT1`/`sT2`/`sT3` do `frmCompilarFiacao`), gravado pelo `FIA`.
 */
export function ContatosPanel({ contatos }: { contatos: Contatos4F[] }) {
  return (
    <div className="subsection">
      <h3>
        Contatos <span className="muted">({contatos.length})</span>
      </h3>
      {contatos.length === 0 ? (
        <p className="muted">sem contatos gravados nesta revisão</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Modelo</th>
              <th>Terminal</th>
              <th>Orientação</th>
            </tr>
          </thead>
          <tbody>
            {contatos.map((contato) => (
              <tr key={contato.Indice}>
                <td>
                  {ouTraco(contato.NomeModelo)} <span className="muted">#{ouTraco(contato.IndexModelo)}</span>
                </td>
                <td>{ouTraco(contato.Terminal)}</td>
                <td>{ouTraco(contato.Orientacao)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
