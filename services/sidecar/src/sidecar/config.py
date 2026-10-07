"""Configuração por ambiente (prefixo SIDECAR_)."""

from __future__ import annotations

from pydantic_settings import BaseSettings, SettingsConfigDict


class Settings(BaseSettings):
    model_config = SettingsConfigDict(env_prefix="SIDECAR_", env_file=".env", extra="ignore")

    #: Interface de bind do ROUTER e do PUB (sempre loopback por padrão).
    zmq_host: str = "127.0.0.1"
    #: Porta do ROUTER. 0 = deixa o SO escolher (o Rust prefere isto e lê o READY).
    zmq_port: int = 0

    #: FastAPI. `http_enabled=False` desliga completamente.
    http_enabled: bool = True
    http_host: str = "127.0.0.1"
    http_port: int = 8765

    log_level: str = "INFO"
    #: Intervalo do evento `heartbeat` em segundos (0 desliga).
    heartbeat_seconds: float = 15.0

    @property
    def pub_port_offset(self) -> int:
        """O PUB mora em PORT+1 para o Rust conseguir prever o endereço."""
        return 1
