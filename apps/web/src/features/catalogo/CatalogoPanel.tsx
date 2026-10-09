import type { Cabos4, Veias4 } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Catálogo da revisão: `Cabos4` e `Veias4` — o snapshot que o `INT` carimba com a
 * revisão (`RUIU5Sbjhj`/`v1TU0cEjWd` do original). Sem catálogo carregado, as
 * listas saem vazias (o `VERIF` não aponta cabo por causa disso).
 */
export function CatalogoPanel({ cabos, veias }: { cabos: Cabos4[]; veias: Veias4[] }) {
  return (
    <div className="subsection">
      <h3>
        Catálogo <span className="muted">({cabos.length} cabo(s), {veias.length} veia(s))</span>
      </h3>
      {cabos.length === 0 && veias.length === 0 ? (
        <p className="muted">sem catálogo carregado nesta revisão</p>
      ) : (
        <>
          {cabos.length > 0 && (
            <table className="data">
              <thead>
                <tr>
                  <th>Cabo</th>
                  <th>Formação</th>
                  <th>Blindagem</th>
                  <th>Pn1</th>
                  <th>Pn2</th>
                  <th>Função</th>
                </tr>
              </thead>
              <tbody>
                {cabos.map((cabo) => (
                  <tr key={cabo.Indice}>
                    <td>{ouTraco(cabo.Tag)}</td>
                    <td>{ouTraco(cabo.Formacao)}</td>
                    <td>{cabo.Blindagem ? "sim" : "não"}</td>
                    <td>{ouTraco(cabo.Pn1)}</td>
                    <td>{ouTraco(cabo.Pn2)}</td>
                    <td>{ouTraco(cabo.Funcao)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
          {veias.length > 0 && (
            <table className="data">
              <thead>
                <tr>
                  <th>Veia</th>
                  <th>Número</th>
                  <th>Nome</th>
                  <th>Função</th>
                </tr>
              </thead>
              <tbody>
                {veias.map((veia) => (
                  <tr key={veia.Indice}>
                    <td>{ouTraco(veia.Tag)}</td>
                    <td>{ouTraco(veia.Num_Veia)}</td>
                    <td>{ouTraco(veia.Nome_Veia)}</td>
                    <td>{ouTraco(veia.Funcao)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </>
      )}
    </div>
  );
}
