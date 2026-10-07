import { useState } from "react";
import type { PingResult } from "@protocol";
import { useBackendStatus } from "@/hooks/useBackend";

export function HealthPanel() {
  const { status, error, ping, transport } = useBackendStatus();
  const [last, setLast] = useState<PingResult | null>(null);
  const [busy, setBusy] = useState(false);

  const onPing = async () => {
    setBusy(true);
    setLast(await ping());
    setBusy(false);
  };

  return (
    <section className="panel">
      <h2>Backend</h2>
      <dl>
        <dt>Transporte</dt>
        <dd>{transport}</dd>
        <dt>Sidecar</dt>
        <dd>{status ? status.state : "—"}</dd>
      </dl>

      <button onClick={onPing} disabled={busy}>
        {busy ? "ping…" : "ping"}
      </button>

      {error && <p className="error">{error}</p>}
      {last && (
        <p className="ok">
          ok · {last.service} v{last.version} · {last.ts}
        </p>
      )}
    </section>
  );
}
