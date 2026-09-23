import type { Plaquetas4 } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Plaquetas de identificação do painel (`Plaquetas4`) — o que o comando `EPLQ`
 * projeta do dicionário `CENG_PLAQUETA` do **próprio desenho**
 * (`clsDispositivoTacito.exportaPlaquetas` do original). O nome (`Tag`) é
 * resolvido pelo tipo da plaqueta: painel, dispositivo, texto livre ou régua.
 *
 * A tabela **não tem revisão**: a chave é o `DWG`. Ver `docs/RUNBOOK.md`, rodada 61.
 */
export function PlaquetasPanel({ plaquetas }: { plaquetas: Plaquetas4[] }) {
  return (
    <div className="subsection">
      <h3>
        Plaquetas <span className="muted">({plaquetas.length})</span>
      </h3>
      {plaquetas.length === 0 ? (
        <p className="muted">sem plaquetas neste painel — rode o EPLQ no desenho</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Tag</th>
              <th>Modelo</th>
              <th>Descrição 1</th>
              <th>Descrição 2</th>
              <th>Descrição 3</th>
            </tr>
          </thead>
          <tbody>
            {plaquetas.map((plaqueta) => (
              <tr key={plaqueta.Indice}>
                <td>{ouTraco(plaqueta.Tag)}</td>
                <td>{ouTraco(plaqueta.Modelo)}</td>
                <td>{ouTraco(plaqueta.Desc1)}</td>
                <td>{ouTraco(plaqueta.Desc2)}</td>
                <td>{ouTraco(plaqueta.Desc3)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
