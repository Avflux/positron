import type { Cabos4, Materiais, ModelosCabos, Veias4 } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Catálogo: `Cabos4`/`Veias4` (o snapshot que o `INT` carimba com a revisão —
 * `RUIU5Sbjhj`/`v1TU0cEjWd`) e as tabelas de catálogo `Materiais` e `ModelosCabos`,
 * que vêm do banco do produto (no projeto real, do `RCD.mdb`).
 *
 * Sem catálogo carregado as listas saem vazias — é por isso que o `VERIF` não
 * aponta cabo (`CaboSemCatalogo` não roda com catálogo vazio).
 */
export function CatalogoPanel({
  cabos,
  veias,
  materiais,
  modelosCabo,
}: {
  cabos: Cabos4[];
  veias: Veias4[];
  materiais: Materiais[];
  modelosCabo: ModelosCabos[];
}) {
  const vazio =
    cabos.length === 0 && veias.length === 0 && materiais.length === 0 && modelosCabo.length === 0;
  return (
    <div className="subsection">
      <h3>
        Catálogo <span className="muted">
          ({cabos.length} cabo(s), {veias.length} veia(s), {materiais.length} material(is),
          {" "}{modelosCabo.length} modelo(s) de cabo)
        </span>
      </h3>
      {vazio ? (
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
          {materiais.length > 0 && (
            <table className="data">
              <thead>
                <tr>
                  <th>Código</th>
                  <th>Cliente</th>
                  <th>Descrição</th>
                  <th>Modelo</th>
                  <th>Fabricante</th>
                </tr>
              </thead>
              <tbody>
                {materiais.map((material) => (
                  <tr key={material.Indice}>
                    <td>{ouTraco(material.CodigoInterno)}</td>
                    <td>{ouTraco(material.CodigoCliente)}</td>
                    <td>{ouTraco(material.DescricaoResumida)}</td>
                    <td>{ouTraco(material.Modelo)}</td>
                    <td>{ouTraco(material.Fabricante)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
          {modelosCabo.length > 0 && (
            <table className="data">
              <thead>
                <tr>
                  <th>Modelo</th>
                  <th>Descrição</th>
                  <th>Prefixo</th>
                  <th>Conector 1</th>
                  <th>Conector 2</th>
                </tr>
              </thead>
              <tbody>
                {modelosCabo.map((modelo) => (
                  <tr key={modelo.Indice}>
                    <td>{ouTraco(modelo.CodigoCliente)}</td>
                    <td>{ouTraco(modelo.Descricao)}</td>
                    <td>{ouTraco(modelo.Prefixo)}</td>
                    <td>{ouTraco(modelo.Conector1)}</td>
                    <td>{ouTraco(modelo.Conector2)}</td>
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
