import { useState } from "react";
import type { Bornes4F, Bornes4I } from "@protocol";
import { request } from "@/lib/bridge";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Bornes do diagrama (`Bornes4F`) — o que o `FIA` grava das réguas (borne do
 * desenho + reservas), com o drill-down `bornes4i_por_regua`, que é o que o `INT`
 * grava para a mesma régua.
 */
export function BornesPanel({ bornes }: { bornes: Bornes4F[] }) {
  const [regua, setRegua] = useState<number | null>(null);
  const [detalhe, setDetalhe] = useState<Bornes4I[] | null>(null);
  const [erro, setErro] = useState<string | null>(null);

  const abrir = async (indexRegua: number | null) => {
    if (indexRegua === null) return;
    if (regua === indexRegua) {
      setRegua(null);
      setDetalhe(null);
      return;
    }

    setRegua(indexRegua);
    setErro(null);
    try {
      const resposta = await request("bornes4i_por_regua", { index_regua: indexRegua });
      setDetalhe(resposta.bornes);
    } catch (e) {
      setDetalhe(null);
      setErro(e instanceof Error ? e.message : String(e));
    }
  };

  return (
    <div className="subsection">
      <h3>
        Bornes <span className="muted">({bornes.length})</span>
      </h3>
      {bornes.length === 0 ? (
        <p className="muted">sem bornes gravados nesta revisão</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Régua</th>
              <th>Borne</th>
              <th>Ordem</th>
              <th>Pág.</th>
              <th>Reserva</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {bornes.map((borne) => (
              <tr key={borne.Indice}>
                <td>
                  {ouTraco(borne.Regua)} <span className="muted">#{ouTraco(borne.IndexRegua)}</span>
                </td>
                <td>{ouTraco(borne.Borne)}</td>
                <td>{ouTraco(borne.Ordem)}</td>
                <td>{ouTraco(borne.Pagina)}</td>
                <td>{borne.bReserva ? "sim" : "não"}</td>
                <td>
                  <button
                    type="button"
                    onClick={() => void abrir(borne.IndexRegua)}
                    disabled={borne.IndexRegua === null}
                  >
                    {regua === borne.IndexRegua ? "fechar" : "4I"}
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
      {erro && <p className="error">{erro}</p>}
      {regua !== null && detalhe && (
        <div className="drill">
          <h4>
            Bornes 4I da régua #{regua} <span className="muted">({detalhe.length})</span>
          </h4>
          {detalhe.length === 0 ? (
            <p className="muted">o INT não gravou bornes para esta régua</p>
          ) : (
            <table className="data">
              <thead>
                <tr>
                  <th>Régua</th>
                  <th>Borne</th>
                  <th>Ordem</th>
                  <th>Pág.</th>
                  <th>Reserva</th>
                </tr>
              </thead>
              <tbody>
                {detalhe.map((linha) => (
                  <tr key={linha.Indice}>
                    <td>{ouTraco(linha.Regua)}</td>
                    <td>{ouTraco(linha.Borne)}</td>
                    <td>{ouTraco(linha.Ordem)}</td>
                    <td>{ouTraco(linha.Pagina)}</td>
                    <td>{linha.bReserva ? "sim" : "não"}</td>
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
