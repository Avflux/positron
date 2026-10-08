import type { Fiacao } from "@protocol";

/** `null` do banco vira travessão — evita "null" cru na tela. */
export const ouTraco = (valor: string | number | boolean | null): string =>
  valor === null ? "—" : String(valor);

export function FiacaoPanel({ fios }: { fios: Fiacao[] }) {
  return (
    <div className="subsection">
      <h3>
        Fiação <span className="muted">({fios.length})</span>
      </h3>
      {fios.length === 0 ? (
        <p className="muted">sem fios neste painel</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Tag</th>
              <th>Terminal</th>
              <th>Seção</th>
              <th>Cor</th>
              <th>Potencial</th>
              <th>Pág.</th>
            </tr>
          </thead>
          <tbody>
            {fios.map((fio) => (
              <tr key={fio.Indice}>
                <td>{ouTraco(fio.Tag)}</td>
                <td>{ouTraco(fio.Terminal)}</td>
                <td>{ouTraco(fio.Secao)}</td>
                <td>{ouTraco(fio.Cor)}</td>
                <td>{ouTraco(fio.Potencial)}</td>
                <td>{ouTraco(fio.Pagina)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
