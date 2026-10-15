# Conhecimento do reverso — índice

Fatos do Eletron4Z **descobertos e confirmados**, por tema, para nenhuma rodada redescobrir o que
outra já leu. Um arquivo por tema (`xdata.md`, `dicionarios.md`, `banco.md`, `paginas.md`,
`ofuscados.md`…), criado quando o primeiro fato do tema aparecer.

Regras: cada fato cita `arquivo:linha` do decompilado (relativo a
`cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`) e a rodada que o confirmou;
fato que se mostrou errado é corrigido aqui, não empilhado.

## Fontes que já existem (consulte antes)

| fonte | o que tem |
|---|---|
| `cad-plugin/reverso/Eletron4_ZWcad/ARQUITETURA.md` | camadas, classes principais, dependências do original |
| `docs/POSITRON.md` | domínio, tabelas, XData e dicionários usados pelo recoder |
| `docs/reverso-comandos.txt` | os 216 comandos → classe/método/tela |
| `docs/reverso-formularios.txt` · `reverso-capturas.txt` | as 127 telas e as capturas conferidas |
| `docs/RUNBOOK.md` → *Troubleshooting* | quirks do CAD medidos (XData, `entget`, `Xrecord`…) |
| `docs/PLANO.md` §7 | triagem do que está fora do recorte e por quê |

## Temas

| tema | arquivo |
|---|---|
| `CONEXAO`/`AUXCONEXAO`, edição de seção e cor, `SetFocus` | `conexao.md` |
| `INTERLIGACAO`: as duas cargas de veias indefinidas, a tela `PESQC` | `interligacao.md` |
| Páginas: títulos (`TituloPagina`, `buscaTitulosExistentes`), o `LerXDataVazio`, a troca do `TROCTT` | `paginas.md` |
