import { HealthPanel } from "@/features/health/HealthPanel";

export default function App() {
  return (
    <main className="app">
      <header>
        <h1>ZMQ Starter</h1>
        <p className="muted">Tauri + React + Python (FastAPI/pyzmq)</p>
      </header>
      <HealthPanel />
    </main>
  );
}
