import { useState } from "react";
import type { Interligacao4 } from "@protocol";
import { request } from "@/lib/bridge";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Interligação do painel (`Interligacao4`) e **busca por cabo**.
 *
 * A lista vem do painel selecionado; a busca usa `interligacao_por_cabo`, que
 * varre a revisão inteira pela `Tag_Cabo` — é o `dgdInterlig`/consulta do
 * original, útil para achar um trecho que está em outro painel.
 */
export function InterligacaoPanel({ trechos }: { trechos: Interligacao4[] }) {
  const [tag, setTag] = useState("");
  const [buscados, setBuscados] = useState<Interligacao4[] | null>(null);
  const [erro, setErro] = useState<string | null>(null);
  const [buscando, setBuscando] = useState(false);

  const buscar = async () => {
    const alvo = tag.trim();
    if (alvo.length === 0) {
      setBuscados(null);
      setErro(null);
      return;
    }

    setBuscando(true);
    try {
      const resposta = await request("interligacao_por_cabo", { tag_cabo: alvo });
      setBuscados(resposta.trechos);
      setErro(null);
    } catch (e) {
      setBuscados(null);
      setErro(e instanceof Error ? e.message : String(e));
    } finally {
      setBuscando(false);
    }
  };

  return (
    <div className="subsection">
      <h3>
        Interligação <span className="muted">({trechos.length})</span>
      </h3>
      <form
        className="busca"
        onSubmit={(evento) => {
          evento.preventDefault();
          void buscar();
        }}
      >
        <input
          type="text"
          placeholder="buscar por cabo (Tag_Cabo)"
          value={tag}
          onChange={(evento) => setTag(evento.target.value)}
          aria-label="Buscar cabo"
        />
        <button type="submit" disabled={buscando}>
          {buscando ? "buscando…" : "Buscar"}
        </button>
        {buscados !== null && (
          <button
            type="button"
            onClick={() => {
              setBuscados(null);
              setTag("");
            }}
          >
            Limpar
          </button>
        )}
      </form>
      {erro && <p className="error">{erro}</p>}

      {buscados !== null ? (
        <Tabela
          titulo={`Trechos do cabo ${tag.trim()} (${buscados.length})`}
          vazio="nenhum trecho com esse cabo"
          trechos={buscados}
        />
      ) : (
        <Tabela
          titulo={null}
          vazio="sem interligações neste painel"
          trechos={trechos}
        />
      )}
    </div>
  );
}

function Tabela({
  titulo,
  vazio,
  trechos,
}: {
  titulo: string | null;
  vazio: string;
  trechos: Interligacao4[];
}) {
  if (trechos.length === 0) {
    return <p className="muted">{vazio}</p>;
  }

  return (
    <>
      {titulo && <h4>{titulo}</h4>}
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
    </>
  );
}
