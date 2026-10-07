import { useEffect, useRef } from "react";
import { onEvent } from "@/lib/bridge";

/**
 * Assina um tópico publicado pelo sidecar.
 * O handler vive numa ref para não reassinar a cada render.
 */
export function useZmqEvent<T = unknown>(topic: string, handler: (payload: T) => void): void {
  const ref = useRef(handler);
  ref.current = handler;

  useEffect(() => {
    let dispose: (() => void) | undefined;
    let cancelled = false;

    onEvent<T>(topic, (payload) => ref.current(payload)).then((off) => {
      if (cancelled) off();
      else dispose = off;
    });

    return () => {
      cancelled = true;
      dispose?.();
    };
  }, [topic]);
}
