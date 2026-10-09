#!/usr/bin/env python3
"""Compara as contagens do relatorio do VERIF com a linha de base do repositorio.

Uso:
    python scripts/cad-verif-baseline.py <relatorio.txt> [--atualizar]

O relatorio e o que o `ELETREL` escreve (texto puro, cabecalho `# ...` e linhas
`area;tipo;tabela;identificador;detalhe`). O script conta os problemas **por tipo** e
compara com `scripts/verif-baseline.txt` — a fotografia esperada para o desenho real
(`Funcional.dwg`, DWG 63). Divergencia nao e erro por si: e o sinal de que uma regra
mudou (ou de que o desenho mudou). Use `--atualizar` para regravar a linha de base
depois de conferir a diferenca.

O que **nao** se compara: a ordem das linhas e o detalhe de cada problema, so as
contagens por tipo — e por isso o arquivo de base e estavel entre rodadas."""

import collections
import pathlib
import sys


def conta_relatorio(caminho: str):
    tipos = collections.Counter()
    total = None
    cabecalho = []
    for linha in pathlib.Path(caminho).read_text(encoding='utf-8', errors='replace').splitlines():
        linha = linha.strip()
        if not linha:
            continue
        if linha.startswith('#'):
            cabecalho.append(linha)
            if linha.startswith('# problemas='):
                total = int(linha.split('=', 1)[1])
            continue
        campos = linha.split(';')
        if len(campos) >= 2:
            tipos[campos[1]] += 1
    return cabecalho, total if total is not None else sum(tipos.values()), tipos


def le_base(caminho: str):
    base = {}
    for linha in pathlib.Path(caminho).read_text(encoding='utf-8').splitlines():
        linha = linha.strip()
        if not linha or linha.startswith('#'):
            continue
        if '=' in linha:
            chave, valor = linha.split('=', 1)
            base[chave.strip()] = int(valor)
    return base


def escreve_base(caminho: str, cabecalho, total: int, tipos) -> None:
    linhas = ['# Linha de base do VERIF — desenho real (Funcional.dwg, DWG 63, R0).',
              '# Gerado por scripts/cad-verif-baseline.py --atualizar; confira a diferenca antes.',
              '#']
    linhas.extend('#' + c.lstrip('#') for c in cabecalho if c.startswith('# banco='))
    linhas.append(f'total={total}')
    for tipo in sorted(tipos):
        linhas.append(f'{tipo}={tipos[tipo]}')
    pathlib.Path(caminho).write_text('\n'.join(linhas) + '\n', encoding='utf-8')


def principal() -> int:
    if len(sys.argv) < 2:
        print(__doc__)
        return 2
    relatorio = sys.argv[1]
    base_caminho = str(pathlib.Path(__file__).with_name('verif-baseline.txt'))
    cabecalho, total, tipos = conta_relatorio(relatorio)

    if '--atualizar' in sys.argv:
        escreve_base(base_caminho, cabecalho, total, tipos)
        print(f'linha de base regravada: {base_caminho}')
        for tipo in sorted(tipos):
            print(f'  {tipo}={tipos[tipo]}')
        print(f'  total={total}')
        return 0

    base = le_base(base_caminho) if pathlib.Path(base_caminho).exists() else {}
    print(f'relatorio: {relatorio}')
    print(f'  total de problemas: {total}' + (f" (base: {base.get('total')})" if 'total' in base else ''))
    print('  tipo                       agora   base')
    divergencias = 0
    for tipo in sorted(set(tipos) | {k for k in base if k != 'total'}):
        agora = tipos.get(tipo, 0)
        esperado = base.get(tipo)
        marca = '' if esperado == agora else ('  <-- DIFERE' if esperado is not None else '  <-- NOVO')
        if esperado != agora:
            divergencias += 1
        print(f'  {tipo:<24} {agora:>6}  {esperado if esperado is not None else "-":>5}{marca}')

    if not base:
        print('sem linha de base gravada: rode com --atualizar depois de conferir')
        return 0
    if divergencias:
        print(f'{divergencias} tipo(s) fora da linha de base')
        return 1
    print('linha de base confere')
    return 0


if __name__ == '__main__':
    raise SystemExit(principal())
