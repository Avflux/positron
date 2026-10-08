import type { Interligacao4 } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

export function InterligacaoPanel({ trechos }: { trechos: Interligacao4[] }) {
  return (
    <div className="subsection">
      <h3>
        Interligação <span className="muted">({trechos.length})</span>
      </h3>
      {trechos.length === 0 ? (
        <p className="muted">sem interligações neste painel</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Cabo</th>
              <th>Veia</th>
              <th>Origem</th>
              <th>Destino</th>
            </tr>
          </thead>
          <tbody>
            {trechos.map((trecho) => (
              <tr key={trecho.Indice}>
                <td>{ouTraco(trecho.Tag_Cabo)}</td>
                <td>
                  {ouTraco(trecho.Num_Veia)}
                  {trecho.Nome_Veia ? <span className="muted"> · {trecho.Nome_Veia}</span> : null}
                </td>
                <td>
                  {ouTraco(trecho.Tag1)} <span className="muted">{ouTraco(trecho.Terminal1)}</span>
                </td>
                <td>
                  {ouTraco(trecho.Tag2)} <span className="muted">{ouTraco(trecho.Terminal2)}</span>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
