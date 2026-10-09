#!/usr/bin/env python3
"""Smoke do app sobre um banco de projeto: imprime as contagens das consultas principais.

Uso:
    python scripts/app-consultas.py <banco.db> [--painel 503]

Chama os **handlers do sidecar** (o mesmo caminho do app), sem ZMQ e sem CAD, e mostra
o que cada painel do app mostraria. Serve para conferir um `.db` recem-projetado: e o
passo 3 do `scripts/cad-projeto-e2e.ps1`.

A lista de consultas e a ordem seguem os paineis de `apps/web` (fiacao, interligacao,
circuitos, dispositivos, jumpers, aplicacoes, catalogo, portas/bornes/contatos)."""

import argparse
import asyncio
import pathlib
import sys

RAIZ = pathlib.Path(__file__).resolve().parent.parent
sys.path.insert(0, str(RAIZ / 'services' / 'sidecar' / 'src'))

from sidecar.handlers import Handlers  # noqa: E402


def consultas(painel: int):
    return [
        ('projeto_listar_paineis', {}),
        ('fiacao_por_painel', {'painel': painel}),
        ('interligacao_por_painel', {'painel': painel}),
        ('circuitos_por_painel', {'painel': painel}),
        ('dispositivos_por_painel', {'painel': painel}),
        ('jumper_por_painel', {'painel': painel}),
        ('aplicacoes_por_revisao', {}),
        ('cabos4_por_revisao', {}),
        ('veias4_por_revisao', {}),
        ('catalogo_listar_materiais', {}),
        ('catalogo_listar_modelos_cabo', {}),
        ('portas4f_por_revisao', {}),
        ('bornes4f_por_revisao', {}),
        ('contatos4f_por_revisao', {}),
    ]


async def principal() -> int:
    parser = argparse.ArgumentParser(description='Smoke do app sobre um banco de projeto')
    parser.add_argument('banco')
    parser.add_argument('--painel', type=int, default=503,
                        help='painel usado nas consultas por painel (padrao: 503)')
    args = parser.parse_args()

    handlers = Handlers(args.banco)
    print(f'banco: {args.banco}')
    print(f'painel das consultas por painel: {args.painel}')
    total = 0
    for metodo, params in consultas(args.painel):
        resposta = await handlers.dispatch(metodo, params)
        chave = next(iter(resposta))
        linhas = resposta[chave]
        print(f'  {metodo:<28} {len(linhas):>6} linha(s)')
        total += len(linhas)
    print(f'  {"total":<28} {total:>6} linha(s)')
    return 0


if __name__ == '__main__':
    raise SystemExit(asyncio.run(principal()))
