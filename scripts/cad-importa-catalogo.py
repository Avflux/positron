#!/usr/bin/env python3
"""Carrega um CSV exportado do Access numa tabela do banco do projeto (SQLite).

Uso (normalmente chamado por `scripts/cad-importa-catalogo.ps1`):
    python scripts/cad-importa-catalogo.py <banco.db> <tabela> <csv>

Regras:
* casa as colunas **por nome**, ignorando maiusculas/minusculas, e insere so as que
  existem nos dois lados (o Access e a fonte; o SQLite pode ter colunas a mais, como
  as chaves `Indice`/`Chave`, que sao INTEGER PRIMARY KEY e se auto-numeram);
* colunas `BOOL` recebem 0/1 (o Access exporta `True`/`False`);
* quando a chave primaria aparece no CSV, a carga e `INSERT OR REPLACE`; quando nao
  aparece (caso de `Veias`, cuja `Chave` so existe no SQLite), a tabela e **limpa**
  antes — catalogo e recarga total, nunca acumula."""

import csv
import sqlite3
import sys


def colunas(con: sqlite3.Connection, tabela: str):
    return [r[1] for r in con.execute(f'PRAGMA table_info({tabela})')]


def principais(con: sqlite3.Connection, tabela: str):
    return [r[1] for r in con.execute(f'PRAGMA table_info({tabela})') if r[5]]


def booleana(con: sqlite3.Connection, tabela: str, coluna: str) -> bool:
    for r in con.execute(f'PRAGMA table_info({tabela})'):
        if r[1].lower() == coluna.lower():
            return 'BOOL' in (r[2] or '').upper()
    return False


def principal(banco: str, tabela: str, caminho_csv: str) -> None:
    con = sqlite3.connect(banco)
    try:
        existentes = colunas(con, tabela)
        if not existentes:
            raise SystemExit(f'a tabela {tabela} nao existe em {banco}')
        por_nome = {c.lower(): c for c in existentes}

        with open(caminho_csv, encoding='utf-8-sig', newline='') as f:
            leitor = csv.DictReader(f)
            cabecalho = leitor.fieldnames or []
            usadas = [c for c in cabecalho if c.lower() in por_nome]
            alvo = [por_nome[c.lower()] for c in usadas]
            if not alvo:
                raise SystemExit(f'nenhuma coluna em comum entre {tabela} e o CSV')

            booleanas = {c for c in alvo if booleana(con, tabela, c)}
            chaves = principais(con, tabela)
            recarga_total = not (chaves and all(k in alvo for k in chaves))
            conflito = '' if recarga_total else ' OR REPLACE'
            if recarga_total:
                con.execute(f'DELETE FROM {tabela}')
                con.commit()
            sql = (
                f'INSERT{conflito} INTO {tabela} ('
                + ', '.join(alvo)
                + ') VALUES ('
                + ', '.join('?' for _ in alvo)
                + ')'
            )

            linhas = []
            for registro in leitor:
                valores = []
                for coluna_csv, coluna in zip(usadas, alvo):
                    valor = registro.get(coluna_csv)
                    if valor == '':
                        valores.append(None)
                    elif coluna in booleanas:
                        valores.append(1 if str(valor).strip().lower() in ('true', '1', '-1') else 0)
                    else:
                        valores.append(valor)
                linhas.append(valores)

            con.executemany(sql, linhas)
            con.commit()
            total = con.execute(f'SELECT COUNT(*) FROM {tabela}').fetchone()[0]
            print(f'  {tabela}: {len(linhas)} linha(s) carregada(s), tabela agora com {total}')
    finally:
        con.close()


if __name__ == '__main__':
    if len(sys.argv) != 4:
        raise SystemExit(__doc__)
    principal(sys.argv[1], sys.argv[2], sys.argv[3])
