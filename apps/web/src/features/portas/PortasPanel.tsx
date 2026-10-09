import { useState } from "react";
import type { Portas4F, Portas4I } from "@protocol";
import { request } from "@/lib/bridge";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Portas do diagrama (`Portas4F`) — o que o `FIA` grava das máscaras: linha `T`
 * (terminal da máscara) e linha `B` (borne declarado). Clicar no modelo abre o
 * **drill-down** com as portas da interligação (`portas4i_por_modelo`), que é o que
 * o `INT` grava para o mesmo `IndexModelo`.
 */
export function PortasPanel({ portas }: { portas: Portas4F[] }) {
  const [modelo, setModelo] = useState<number | null>(null);
  const [detalhe, setDetalhe] = useState<Portas4I[] | null>(null);
  const [erro, setErro] = useState<string | null>(null);

  const abrir = async (indexModelo: number | null) => {
    if (indexModelo === null) return;
    if (modelo === indexModelo) {
      setModelo(null);
      setDetalhe(null);
      return;
    }

    setModelo(indexModelo);
    setErro(null);
    try {
      const resposta = await request("portas4i_por_modelo", { index_modelo: indexModelo });
      setDetalhe(resposta.portas);
    } catch (e) {
      setDetalhe(null);
      setErro(e instanceof Error ? e.message : String(e));
    }
  };

  return (
    <div className="subsection">
      <h3>
        Portas <span className="muted">({portas.length})</span>
      </h3>
      {portas.length === 0 ? (
        <p className="muted">sem portas gravadas nesta revisão</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Modelo</th>
              <th>Tipo</th>
              <th>Terminal</th>
              <th>Borne</th>
              <th>Régua</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {portas.map((porta) => (
              <tr key={porta.Indice}>
                <td>
                  {ouTraco(porta.NomeModelo)} <span className="muted">#{ouTraco(porta.IndexModelo)}</span>
                </td>
                <td>{ouTraco(porta.Tipo)}</td>
                <td>{ouTraco(porta.Terminal)}</td>
                <td>{ouTraco(porta.Borne)}</td>
                <td>{ouTraco(porta.Regua)}</td>
                <td>
                  <button
                    type="button"
                    onClick={() => void abrir(porta.IndexModelo)}
                    disabled={porta.IndexModelo === null}
                  >
                    {modelo === porta.IndexModelo ? "fechar" : "4I"}
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
      {erro && <p className="error">{erro}</p>}
      {modelo !== null && detalhe && (
        <div className="drill">
          <h4>
            Portas 4I do modelo #{modelo} <span className="muted">({detalhe.length})</span>
          </h4>
          {detalhe.length === 0 ? (
            <p className="muted">o INT não gravou portas para este modelo</p>
          ) : (
            <table className="data">
              <thead>
                <tr>
                  <th>Modelo</th>
                  <th>Régua</th>
                  <th>Borne</th>
                  <th>Terminal</th>
                  <th>Tipo</th>
                </tr>
              </thead>
              <tbody>
                {detalhe.map((linha) => (
                  <tr key={linha.Indice}>
                    <td>{ouTraco(linha.NomeModelo)}</td>
                    <td>{ouTraco(linha.Regua)}</td>
                    <td>{ouTraco(linha.Borne)}</td>
                    <td>{ouTraco(linha.Terminal)}</td>
                    <td>{ouTraco(linha.Tipo)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      )}
    </div>
  );
}
