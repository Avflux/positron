import { useCallback, useState } from "react";
import type { Paineis } from "@protocol";
import { request } from "@/lib/bridge";

/**
 * Estado do projeto aberto no sidecar (ver docs/POSITRON.md).
 *
 * Abrir é *stateful* no backend: `projeto_abrir` guarda o caminho e os demais
 * métodos passam a ler dali. Aqui só espelhamos esse estado para a UI.
 */
export function useProjeto() {
  const [caminho, setCaminho] = useState<string | null>(null);
  const [tabelas, setTabelas] = useState<string[]>([]);
  const [paineis, setPaineis] = useState<Paineis[]>([]);
  const [selecionado, setSelecionado] = useState<Paineis | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);

  const abrir = useCallback(async (alvo: string) => {
    setCarregando(true);
    setErro(null);
    try {
      const aberto = await request("projeto_abrir", { caminho: alvo });
      const lista = await request("projeto_listar_paineis", {});
      setCaminho(aberto.caminho);
      setTabelas(aberto.tabelas);
      setPaineis(lista.paineis);
      setSelecionado(lista.paineis[0] ?? null);
    } catch (e) {
      // Falhou: não deixa um projeto meio-aberto na tela.
      setCaminho(null);
      setTabelas([]);
      setPaineis([]);
      setSelecionado(null);
      setErro(e instanceof Error ? e.message : String(e));
    } finally {
      setCarregando(false);
    }
  }, []);

  return { caminho, tabelas, paineis, selecionado, selecionar: setSelecionado, abrir, carregando, erro } as const;
}
