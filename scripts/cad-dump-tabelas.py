#!/usr/bin/env python3
"""Dump e comparacao de conteudo das tabelas do projeto (idempotencia).

Uso:
    python scripts/cad-dump-tabelas.py dump <banco.db> <dwg> <saida.txt>
    python scripts/cad-dump-tabelas.py comparar <a.txt> <b.txt> [--ignorar Data]

O `dump` imprime, por tabela, as linhas do desenho informado (`WHERE DWG = n`) em
formato estavel, **menos** a coluna `Indice` (autoincremento: muda a cada projecao
sem significar mudanca de conteudo).

O `comparar` canoniza os dois dumps (ordena as linhas dentro de cada tabela) e
responde se o conteudo e o mesmo, ignorando (por padrao) a coluna `Data`, que e
re-carimbada a cada projecao — e o **unico** campo que pode mudar legitimamente.

Receita no RUNBOOK: `## Idempotencia e isolamento por desenho`."""

import hashlib
import sqlite3
import sys


def dump(banco: str, dwg: str, saida: str) -> None:
    con = sqlite3.connect(banco)
    tabelas = [
        r[0]
        for r in con.execute(
            "SELECT name FROM sqlite_master WHERE type='table' "
            "AND name NOT LIKE 'sqlite_%' ORDER BY name"
        )
    ]
    total = 0
    resumo = []
    with open(saida, 'w', encoding='utf-8', newline='\n') as f:
        for tabela in tabelas:
            colunas = [r[1] for r in con.execute(f'PRAGMA table_info({tabela})')]
            if not colunas:
                continue
            filtro = f' WHERE DWG = {dwg}' if 'DWG' in colunas else ''
            linhas = list(con.execute(f'SELECT * FROM {tabela}{filtro}'))
            if not linhas:
                continue
            f.write(f'## {tabela} ({len(linhas)})\n')
            for linha in linhas:
                pares = [
                    f'{c}={v!r}' for c, v in zip(colunas, linha) if c != 'Indice'
                ]
                f.write('  ' + '|'.join(pares) + '\n')
            total += len(linhas)
            resumo.append(f'{tabela}={len(linhas)}')
        f.write(f'== total {total}\n')
    print('tabelas: ' + (', '.join(resumo) if resumo else '(nenhuma)'))
    print(f'total de linhas com DWG={dwg}: {total}')


def _blocos(caminho: str):
    """Le o dump em blocos (cabecalho, linhas), para canonizar por tabela."""
    atual = None
    for linha in open(caminho, encoding='utf-8'):
        linha = linha.rstrip('\n')
        if linha.startswith('## '):
            if atual:
                yield atual
            atual = (linha, [])
        elif linha.startswith('== '):
            if atual:
                yield atual
                atual = None
        elif atual is not None and linha.strip():
            atual[1].append(linha.strip())
    if atual:
        yield atual


def comparar(a: str, b: str, ignorar: list[str]) -> int:
    def canonico(caminho: str):
        partes = []
        for cabecalho, linhas in _blocos(caminho):
            normalizadas = []
            for linha in linhas:
                campos = []
                for par in linha.split('|'):
                    nome = par.split('=', 1)[0]
                    if nome not in ignorar:
                        campos.append(par)
                normalizadas.append('|'.join(campos))
            partes.append((cabecalho, sorted(normalizadas)))
        texto = '\n'.join(
            c + '\n' + '\n'.join(l) for c, l in partes
        ) + '\n'
        return hashlib.sha256(texto.encode('utf-8')).hexdigest(), partes

    ha, pa = canonico(a)
    hb, pb = canonico(b)
    rotulo = ' (ignorando ' + ', '.join(ignorar) + ')' if ignorar else ''
    print(f'hash A: {ha}')
    print(f'hash B: {hb}')
    if ha == hb:
        print(f'IDEMPOTENTE: mesmo conteudo{rotulo}')
        return 0

    print(f'DIFERE{rotulo}')
    for (ca, la), (cb, lb) in zip(pa, pb):
        so_a = set(la) - set(lb)
        so_b = set(lb) - set(la)
        if so_a or so_b or ca != cb or len(la) != len(lb):
            print(f'  {ca} -> {cb}: so em A={len(so_a)}, so em B={len(so_b)}')
            for linha in list(so_a)[:3]:
                print('    A:', linha[:160])
            for linha in list(so_b)[:3]:
                print('    B:', linha[:160])
    return 1


def principal() -> int:
    if len(sys.argv) < 2:
        print(__doc__)
        return 2
    modo = sys.argv[1]
    if modo == 'dump' and len(sys.argv) == 5:
        dump(sys.argv[2], sys.argv[3], sys.argv[4])
        return 0
    if modo == 'comparar' and len(sys.argv) >= 4:
        ignorar = []
        if '--ignorar' in sys.argv:
            ignorar = sys.argv[sys.argv.index('--ignorar') + 1].split(',')
        return comparar(sys.argv[2], sys.argv[3], ignorar)
    print(__doc__)
    return 2


if __name__ == '__main__':
    raise SystemExit(principal())
