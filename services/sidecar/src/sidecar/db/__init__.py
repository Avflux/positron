"""Acesso ao banco do projeto (SQLite).

O schema é o contrato entre os dois frontends — ver `schema.sql` e
`docs/POSITRON.md`. Este pacote é o lado do frontend APP: o plugin ZWCAD fala
SQLite direto e não passa por aqui.
"""

from .project import ProjectDatabase

__all__ = ["ProjectDatabase"]
