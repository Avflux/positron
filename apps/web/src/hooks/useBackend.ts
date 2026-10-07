import { useCallback, useEffect, useState } from "react";
import { isTauri, request, onEvent, type SidecarStatus } from "@/lib/bridge";

export function useBackendStatus() {
  const [status, setStatus] = useState<SidecarStatus | null>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    let off: (() => void) | undefined;
    let cancelled = false;
    onEvent<SidecarStatus>("sidecar", (s) => setStatus(s)).then((fn) => {
      if (cancelled) fn();
      else off = fn;
    });
    return () => {
      cancelled = true;
      off?.();
    };
  }, []);

  const ping = useCallback(async () => {
    setError(null);
    try {
      return await request("ping", {});
    } catch (e) {
      setError(e instanceof Error ? e.message : String(e));
      return null;
    }
  }, []);

  return { status, error, ping, transport: isTauri() ? "tauri" : "http" } as const;
}
