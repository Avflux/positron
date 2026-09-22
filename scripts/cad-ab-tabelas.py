#!/usr/bin/env python3
"""Compara o conteudo das tabelas do diagrama entre o recoder e o produto (A/B).

Uso:
    python scripts/cad-ab-tabelas.py <banco.db> <pasta-do-produto> [--nosso-dwg 63 --nosso-revisao R0]

A pasta vem do `scripts/cad-ab-tabelas.ps1` (um CSV por tabela, colunas cruas). Aqui os
dois lados passam pela **mesma normalizacao**, senao a comparacao mente:

* `None`/vazio -> string vazia;
* `True`/`False` (Access) -> `1`/`0` (SQLite);
* numeros -> 4 casas (`Ordem 1.0` do Access contra `1` do SQLite);
* texto do Access -> desfaz a dupla codificacao do driver ODBC
  (bytes UTF-8 lidos como CP1252);
* espacos das pontas.

Compara as colunas de negocio escolhidas em `COLUNAS` (a chave `Indice`/`Criador`/`Data`
fica de fora: autoincremento e carimbo mudam sem significar diferenca de conteudo)."""

import argparse
import csv
import hashlib
import pathlib
import sqlite3
import sys

# Colunas comparadas por tabela — as que o produto e o recoder devem ter iguais.
COLUNAS = {
    'Fiacao': ['Painel', 'Potencial', 'Ordem', 'Pagina', 'Tag', 'NRegua', 'Terminal',
               'Tipo', 'Secao', 'Cor', 'PosicaoNum', 'TipoBorne', 'Handle'],
    'Portas4F': ['IndexModelo', 'NomeModelo', 'Regua', 'Borne', 'Terminal', 'Tipo', 'Orientacao'],
    'Bornes4F': ['Painel', 'IndexRegua', 'Regua', 'Borne', 'Ordem', 'Tipo', 'Pagina',
                 'bReserva', 'LM', 'BlocoLayout', 'Handle'],
    'Contatos4F': ['IndexModelo', 'NomeModelo', 'Terminal', 'Orientacao'],
    'Dispositivos4F': ['Painel', 'Tag', 'Alternativo', 'Tipo', 'Pagina', 'BlocoTopografico',
                       'BlocoLayout', 'PosicaoNum', 'Handle'],
    'Circuitos4F': ['Painel', 'Circuito', 'Potencial'],
    'Aplicacao4F': ['Numero', 'Nome', 'Secao', 'Cor', 'TipoCabo', 'Isolacao'],
    # `ListaMateriais` e a unica do recorte **sem revisao**: a chave e o `DWG`.
    # `IndiceLM` fica de fora como `Indice`/`Criador`/`Data`: quem o atribui e outro
    # fluxo (`AtualizaIndiceLM`), nao a projecao. `Ordem` entra: e o que a projecao
    # calcula — e onde a ordem preservada pelo "Sim" do produto aparece.
    'ListaMateriais': ['Painel', 'Tag', 'IndiceMaterial', 'Quantidade', 'Ordem', 'Avulso',
                       'Alternativo', 'Handle', 'OrdemLay'],
}

# Tabelas cujo filtro e so o `DWG` (nao tem coluna `Revisao`).
SEM_REVISAO = {'ListaMateriais'}

# Chave de casamento explicita, quando o `Handle` nao serve. Em `ListaMateriais` o
# `Handle` e `"BORNE"` em todas as linhas de borne (e vazio nas de dispositivo),
# entao a chave e o proprio item.
CHAVE = {
    'ListaMateriais': ['Painel', 'Tag', 'IndiceMaterial'],
}


def desfaz_codificacao(texto: str) -> str:
    try:
        return texto.encode('cp1252').decode('utf-8')
    except (UnicodeEncodeError, UnicodeDecodeError):
        return texto


def norm(valor) -> str:
    if valor is None:
        return ''
    texto = str(valor)
    # Bool primeiro **e continua**: o SQLite devolve 0/1 e o Access True/False, mas os
    # dois tem de sair no mesmo formato do resto dos numeros — senao `0` e `0.0000`
    # viram diferenca em toda linha (foi um falso positivo da primeira versao).
    if texto == 'True':
        texto = '1'
    elif texto == 'False':
        texto = '0'
    try:
        return f'{float(texto):.4f}'
    except ValueError:
        return desfaz_codificacao(texto).strip()


def linhas_do_recoder(con, tabela, colunas, dwg, revisao):
    if tabela in SEM_REVISAO:
        sql = f"SELECT {', '.join(colunas)} FROM {tabela} WHERE DWG = ?"
        return ['|'.join(norm(v) for v in linha) for linha in con.execute(sql, (dwg,))]
    sql = f"SELECT {', '.join(colunas)} FROM {tabela} WHERE DWG = ? AND Revisao = ?"
    return ['|'.join(norm(v) for v in linha) for linha in con.execute(sql, (dwg, revisao))]


def linhas_do_produto(pasta, tabela, colunas):
    caminho = pathlib.Path(pasta) / f'{tabela}.csv'
    if not caminho.exists():
        return None
    with open(caminho, encoding='utf-8', newline='') as f:
        leitor = csv.DictReader(f)
        return ['|'.join(norm(registro.get(coluna)) for coluna in colunas) for registro in leitor]


def chave_da_linha(tabela: str, linha: str, colunas) -> str:
    """Chave de casamento da linha.

    A `CHAVE` declarada da tabela manda — em `ListaMateriais` o `Handle` é `"BORNE"`
    em todas as linhas de borne (e vazio nas de dispositivo), então não identifica
    nada. Sem ela, vale o `Handle` quando existe (as reservas não têm) e, por fim, a
    própria linha: reserva só casa se for idêntica."""
    partes = linha.split('|')
    declarada = CHAVE.get(tabela)
    if declarada:
        return '|'.join(partes[colunas.index(coluna)] for coluna in declarada)

    if 'Handle' in colunas:
        handle = partes[colunas.index('Handle')]
        if handle and handle != '0.0000':
            return handle

    return linha


def detalhe(tabela: str, colunas, nosso, produto) -> None:
    """Para cada coluna, quantas linhas casadas divergem — o que o resumo não diz."""
    def por_chave(linhas):
        mapa = {}
        for linha in linhas:
            mapa.setdefault(chave_da_linha(tabela, linha, colunas), linha)
        return mapa

    mapa_nosso, mapa_produto = por_chave(nosso), por_chave(produto)
    comuns = set(mapa_nosso) & set(mapa_produto)
    contagem = {coluna: 0 for coluna in colunas}
    exemplo = {}
    for chave in comuns:
        a = mapa_nosso[chave].split('|')
        b = mapa_produto[chave].split('|')
        for i, coluna in enumerate(colunas):
            if i < len(a) and i < len(b) and a[i] != b[i]:
                contagem[coluna] += 1
                exemplo.setdefault(coluna, (chave, a[i], b[i]))
    divergentes = {c: n for c, n in contagem.items() if n}
    print(f'  {tabela}: {len(nosso)} x {len(produto)} linhas, {len(comuns)} chave(s) em comum')
    print(f'    so no recoder: {len(mapa_nosso) - len(comuns)} | so no produto: {len(mapa_produto) - len(comuns)}')
    if not divergentes:
        print('    colunas iguais nas chaves em comum')
        return
    for coluna, n in sorted(divergentes.items(), key=lambda par: -par[1]):
        chave, a, b = exemplo[coluna]
        print(f'    {coluna:<16} {n:>5}  ex. {chave}: recoder={a!r} produto={b!r}')


def marca(linhas):
    linhas = sorted(linhas)
    return len(linhas), hashlib.sha256('\n'.join(linhas).encode('utf-8')).hexdigest()[:16], set(linhas)


def principal() -> int:
    parser = argparse.ArgumentParser(description='A/B de conteudo das tabelas do diagrama')
    parser.add_argument('banco')
    parser.add_argument('pasta_produto')
    parser.add_argument('--nosso-dwg', type=int, default=63)
    parser.add_argument('--nosso-revisao', default='R0')
    parser.add_argument('--detalhe', action='store_true',
                        help='mostra, por coluna, quantas linhas casadas divergem')
    args = parser.parse_args()

    con = sqlite3.connect(args.banco)
    print(f'recoder: {args.banco} (DWG {args.nosso_dwg}, revisao {args.nosso_revisao})')
    print(f'produto: {args.pasta_produto}')
    print()
    print(f'{"tabela":<16} {"recoder":>8} {"produto":>8} {"diferem":>8}  situacao')
    iguais = 0
    divergentes = []
    for tabela, colunas in COLUNAS.items():
        nosso = linhas_do_recoder(con, tabela, colunas, args.nosso_dwg, args.nosso_revisao)
        produto = linhas_do_produto(args.pasta_produto, tabela, colunas)
        if produto is None:
            print(f'{tabela:<16} {len(nosso):>8} {"-":>8} {"-":>8}  sem CSV')
            continue
        n_a, h_a, s_a = marca(nosso)
        n_b, h_b, s_b = marca(produto)
        diferem = len(s_a - s_b) + len(s_b - s_a)
        if diferem == 0:
            situacao = f'IDENTICO ({h_a})'
            iguais += 1
        else:
            situacao = f'DIFERE (so no recoder {len(s_a - s_b)}, so no produto {len(s_b - s_a)})'
            divergentes.append((tabela, sorted(s_a - s_b), sorted(s_b - s_a)))
        print(f'{tabela:<16} {n_a:>8} {n_b:>8} {diferem:>8}  {situacao}')

    for tabela, so_a, so_b in divergentes:
        print()
        print(f'== {tabela} ==')
        for linha in so_a[:4]:
            print('  recoder:', linha)
        for linha in so_b[:4]:
            print('  produto:', linha)

    if args.detalhe:
        print()
        print('== detalhe por coluna (linhas casadas pela chave da tabela) ==')
        for tabela in COLUNAS:
            colunas = COLUNAS[tabela]
            nosso = linhas_do_recoder(con, tabela, colunas, args.nosso_dwg, args.nosso_revisao)
            produto = linhas_do_produto(args.pasta_produto, tabela, colunas)
            if produto is None:
                continue
            detalhe(tabela, colunas, nosso, produto)

    print()
    print(f'{iguais} de {len(COLUNAS)} tabela(s) identicas')
    return 0 if iguais == len(COLUNAS) else 1


if __name__ == '__main__':
    raise SystemExit(principal())
