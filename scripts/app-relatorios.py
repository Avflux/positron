#!/usr/bin/env python3
"""Gera os relatorios tabulares de um banco de projeto, como o app faz.

Uso:
    python scripts/app-relatorios.py <banco.db> [--painel 503] [--revisao R0]

Chama os **handlers do sidecar** (o mesmo caminho da UI, sem ZMQ e sem CAD): lista o
catalogo de relatorios e gera cada um para o painel, imprimindo as colunas, o total de
linhas e as primeiras linhas. Serve para conferir um `.db` recem-projetado: o conteudo
tem de casar com as tabelas que o plugin gravou (`ListaMateriais`, `Cabos4`, `Veias4`,
`Interligacao4`)."""

import argparse
import asyncio
import pathlib
import sys

RAIZ = pathlib.Path(__file__).resolve().parent.parent
sys.path.insert(0, str(RAIZ / 'services' / 'sidecar' / 'src'))

from sidecar.handlers import Handlers  # noqa: E402
from sidecar.protocol import BadParams  # noqa: E402

AMOSTRA = 4


async def principal() -> int:
    parser = argparse.ArgumentParser(description='Gera os relatorios tabulares do app')
    parser.add_argument('banco')
    parser.add_argument('--painel', type=int, default=503)
    parser.add_argument('--revisao', default='R0')
    parser.add_argument('--amostra', type=int, default=AMOSTRA)
    args = parser.parse_args()

    handlers = Handlers(args.banco)
    catalogo = await handlers.dispatch('relatorio_listar')
    print(f'banco: {args.banco}')
    print(f'painel: {args.painel} | revisao: {args.revisao}')
    print(f'relatorios: {", ".join(r["id"] for r in catalogo["relatorios"])}')
    print()

    for info in catalogo['relatorios']:
        params = {'relatorio': info['id'], 'painel': args.painel}
        if 'revisao' in info['parametros']:
            params['revisao'] = args.revisao
        try:
            gerado = await handlers.dispatch('relatorio_gerar', params)
        except BadParams as erro:
            print(f'== {info["id"]} == indisponivel: {erro.message}')
            continue

        print(f'== {info["id"]} == {gerado["titulo"]} ({gerado["total"]} linha(s))')
        print('   ' + ' | '.join(gerado['colunas']))
        for linha in gerado['linhas'][: args.amostra]:
            print('   ' + ' | '.join(celula if celula else '-' for celula in linha))
        if gerado['total'] > args.amostra:
            print(f'   ... mais {gerado["total"] - args.amostra} linha(s)')
        print()
    return 0


if __name__ == '__main__':
    raise SystemExit(asyncio.run(principal()))
