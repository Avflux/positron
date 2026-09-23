import type { ListaMateriais } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Lista de material do painel (`ListaMateriais`) — o que o comando `COMPLM`
 * projeta do desenho (`clsLM.CompilaListaDeMateriais` do original): uma linha por
 * LM da máscara/dispositivo e uma **agregada** por borne `(régua, tipo, lm)`.
 *
 * `Ordem` é a ordem do **diagrama** (1..N por painel) e `OrdemLay` a posição do
 * equipamento no layout `CENG_LAYOUT` — **10000** quando ele não está no layout,
 * o valor que o original grava. `Avulso` marca o item lançado à mão no app: a
 * projeção o preserva e não o recalcula.
 *
 * A tabela **não tem revisão**: a chave é o `DWG`. Ver `docs/RUNBOOK.md`, rodada 62.
 */
export function ListaMateriaisPanel({ materiais }: { materiais: ListaMateriais[] }) {
  return (
    <div className="subsection">
      <h3>
        Lista de material <span className="muted">({materiais.length})</span>
      </h3>
      {materiais.length === 0 ? (
        <p className="muted">sem lista de material neste painel — rode o COMPLM no desenho</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Ordem</th>
              <th>Tag</th>
              <th>Material</th>
              <th>Qtd.</th>
              <th>Alternativo</th>
              <th>Handle</th>
              <th>OrdemLay</th>
            </tr>
          </thead>
          <tbody>
            {materiais.map((material) => (
              <tr key={material.Indice}>
                <td>{ouTraco(material.Ordem)}</td>
                <td>
                  {ouTraco(material.Tag)}
                  {material.Avulso && <span className="muted"> (avulso)</span>}
                </td>
                <td>{ouTraco(material.IndiceMaterial)}</td>
                <td>{ouTraco(material.Quantidade)}</td>
                <td>{ouTraco(material.Alternativo)}</td>
                <td>{ouTraco(material.Handle)}</td>
                <td>{ouTraco(material.OrdemLay)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
