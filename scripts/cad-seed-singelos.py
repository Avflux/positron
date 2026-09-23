"""Semeia um banco de projeto com UM cabo singelo candidato (ver docs/RUNBOOK.md,
rodada 81): um `Cabos` com a coluna `Cabos = 1` e uma `Veias` do arquivo com o `#`
no nome — o que o `CorrigeCabosSingelos` deve limpar.

Uso: python scripts/cad-seed-singelos.py <banco.db> [arquivo] [tag]
"""
import os
import sqlite3
import sys


def main():
    if len(sys.argv) < 2:
        print(__doc__)
        return 1

    banco = os.path.abspath(sys.argv[1])
    arquivo = int(sys.argv[2]) if len(sys.argv) > 2 else 63
    tag = sys.argv[3] if len(sys.argv) > 3 else "CABO-SINGELO"

    if not os.path.exists(banco):
        sys.path.insert(0, os.path.join(os.path.dirname(__file__), "..", "services", "sidecar", "src"))
        from sidecar.db.project import ProjectDatabase
        ProjectDatabase(banco).create_from_schema()

    conexao = sqlite3.connect(banco)
    conexao.execute("DELETE FROM Cabos WHERE Tag = ?", (tag,))
    conexao.execute("DELETE FROM Veias WHERE Tag = ?", (tag,))
    conexao.execute(
        "INSERT INTO Cabos(Tag, Formacao, Blindagem, Cabos) VALUES(?, ?, 0, 1)",
        (tag, "1x"),
    )
    conexao.execute(
        "INSERT INTO Veias(Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Chave, Funcao) "
        "VALUES(?, 1, ?, 0, \"\", ?, \"\", 1, \"\")",
        (tag, "V#1", arquivo),
    )
    conexao.commit()
    conexao.close()
    print(f"banco semeado: {banco} (cabo {tag!r}, arquivo {arquivo})")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
