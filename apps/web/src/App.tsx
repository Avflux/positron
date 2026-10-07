import { HealthPanel } from "@/features/health/HealthPanel";

export default function App() {
  return (
    <main className="app">
      <header>
        <div className="app-brand">
          <img src="/icon.svg" alt="" />
          <h1>ZMQ Starter</h1>
        </div>
        <p className="muted">Tauri + React + Python (FastAPI/pyzmq)</p>
      </header>
      <HealthPanel />
    </main>
  );
}
