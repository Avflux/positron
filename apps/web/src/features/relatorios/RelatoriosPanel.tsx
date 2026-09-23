import { useEffect, useState } from "react";
import type { RelatorioGerado, RelatorioInfo } from "@protocol";
import { request } from "@/lib/bridge";

/**
 * Área de **relatórios tabulares** do painel: o catálogo vem do sidecar
 * (`relatorio_listar`), a revisão — quando o relatório exige — sai dos cabos do
 * projeto (`cabos4_por_revisao`, sem filtro, porque o app não tem seletor de revisão)
 * e o relatório é gerado por `relatorio_gerar` com o painel selecionado.
 *
 * O render é a grade; exportar para Excel/PDF (o que as telas do original faziam) fica
 * para a fase seguinte — ver `docs/PLANO.md` §7.3.
 */
export function RelatoriosPanel({ painel }: { painel: number }) {
  const [catalogo, setCatalogo] = useState<RelatorioInfo[]>([]);
  const [revisoes, setRevisoes] = useState<string[]>([]);
  const [escolhido, setEscolhido] = useState("");
  const [revisao, setRevisao] = useState("");
  const [gerado, setGerado] = useState<RelatorioGerado | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);

  // O catálogo dos relatórios e as revisões do projeto (uma vez).
  useEffect(() => {
    let vivo = true;
    void (async () => {
      try {
        const [lista, cabos] = await Promise.all([
          request("relatorio_listar", {}),
          request("cabos4_por_revisao", {}),
        ]);
        if (!vivo) return;
        setCatalogo(lista.relatorios);
        setEscolhido((atual) => atual || (lista.relatorios[0]?.id ?? ""));
        const distintas = [...new Set(cabos.cabos.map((cabo) => cabo.Revisao ?? ""))].filter(
          (valor) => valor !== "",
        );
        setRevisoes(distintas.sort());
        setRevisao((atual) => atual || (distintas.length === 1 ? distintas[0] : ""));
      } catch (e) {
        if (vivo) setErro(e instanceof Error ? e.message : String(e));
      }
    })();
    return () => {
      vivo = false;
    };
  }, []);

  const info = catalogo.find((item) => item.id === escolhido);
  const precisaRevisao = info?.parametros.includes("revisao") ?? false;

  // Gera o relatório escolhido para o painel (e revisão, quando exigida).
  useEffect(() => {
    if (!info || (precisaRevisao && !revisao)) {
      setGerado(null);
      return;
    }

    let vivo = true;
    setCarregando(true);
    void (async () => {
      try {
        const resultado = await request("relatorio_gerar", {
          relatorio: info.id,
          painel,
          revisao: precisaRevisao ? revisao : null,
        });
        if (vivo) {
          setGerado(resultado);
          setErro(null);
        }
      } catch (e) {
        if (vivo) {
          setGerado(null);
          setErro(e instanceof Error ? e.message : String(e));
        }
      } finally {
        if (vivo) setCarregando(false);
      }
    })();
    return () => {
      vivo = false;
    };
  }, [info, painel, precisaRevisao, revisao]);

  return (
    <div className="subsection">
      <h3>
        Relatórios <span className="muted">({catalogo.length})</span>
      </h3>
      <div className="relatorio-controles">
        <label>
          Relatório{" "}
          <select value={escolhido} onChange={(evento) => setEscolhido(evento.target.value)}>
            {catalogo.map((item) => (
              <option key={item.id} value={item.id}>
                {item.titulo}
              </option>
            ))}
          </select>
        </label>
        {precisaRevisao && (
          <label>
            Revisão{" "}
            <select value={revisao} onChange={(evento) => setRevisao(evento.target.value)}>
              {revisoes.length === 0 && <option value="">(sem cabos no projeto)</option>}
              {revisoes.map((valor) => (
                <option key={valor} value={valor}>
                  {valor}
                </option>
              ))}
            </select>
          </label>
        )}
      </div>

      {info && <p className="muted">{info.descricao}</p>}
      {carregando && <p className="muted">gerando…</p>}
      {erro && <p className="error">{erro}</p>}

      {!carregando && !erro && gerado && (
        <>
          <p className="muted">
            {gerado.titulo}: {gerado.total} linha(s)
          </p>
          {gerado.total === 0 ? (
            <p className="muted">sem linhas para este painel</p>
          ) : (
            <table className="data">
              <thead>
                <tr>
                  {gerado.colunas.map((coluna) => (
                    <th key={coluna}>{coluna}</th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {gerado.linhas.map((linha, indice) => (
                  <tr key={indice}>
                    {linha.map((celula, coluna) => (
                      <td key={coluna}>{celula}</td>
                    ))}
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
