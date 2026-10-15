# Recoder — estado e fila

> **Só estado e fila.** A narrativa de cada rodada fica em `rodadas/NNN-slug.md`; os fatos do
> reverso em `conhecimento/`. Fluxo completo: skill `recoder` (`.claude/skills/recoder/SKILL.md`).
> Histórico até a rodada 175: `../PLANO.md` §5 e as seções "Rodada N" do `../RUNBOOK.md`.

## Estado (2026-10-15, depois da rodada 178)

| | valor |
|---|---|
| última rodada | **178** |
| comandos no plugin | **77** escritos à mão (53 do reverso + 24 nossos) + **115** gerados (só abrem a tela) |
| comandos do reverso sem nada no plugin | **48** (todos regra pura; triagem em `../PLANO.md` §7.6) |
| telas `frm*` do reverso | **127**; **18** com a ligação à regra; 19 que nenhum comando abre |
| testes (`npm run plugin:test`) | **893** |
| builds ZWCAD / AutoCAD | 0 avisos |
| botões da barra cobertos | **126** de 161 acionáveis |
| host CAD medido | ZWCAD 2026 (AutoCAD 2020 não instalado nesta máquina em 2026-10-15) |

Números de cobertura: `powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1`.

## Frentes

| frente | situação |
|---|---|
| 1 — base e pipelines (`FIA`/`INT`/`JMP`/`VERIF`/`SYNCD`) | ✅ |
| 2 — correções e limpeza do CAD | ✅ 37 de 38 (o `CorrigeJanelas` é ambiente) |
| 3–9 — edição (réguas, dispositivos, fiação, cabos, materiais, exportação) | triadas (`PLANO.md` §7.6); portar comando a comando |
| 10 — páginas e caderno | ✅ (cadeia do `CAD` fechada na 175) |
| 11 — shell (arranque, paleta, barra, autoload) | ✅ |
| 12 — as 127 telas | todas abrem; 18 com regra ligada |
| relatórios (9b) · SQL Server (9c) · cadastro de DWGs | ⏳ decisão do dono |

## Fila (uma rodada por item, na ordem)

1. **Telas só-casca mais baratas** cuja regra cabe numa rodada (lista: `cobertura-do-reverso.ps1 -Listas`):
   `frmEditaTitulosTextos` (`TROCTT`), `frmEstatisticaDeCabos` (`ESTVCABOS`).
2. **Seção e cor ativas da barra** (`ListaDeSecao`/`CampoDeCor`, `Ribbon.cs:971,2264`): o padrão dos
   prompts do `EDCON`/`EDCONP` (hoje fixo em `1,5`/`PT`) e do `INSM`/`CON` — saiu da rodada 176.
3. **Comandos de regra pura sem nada no plugin** (48) — pegar os que a triagem do `PLANO.md` §7.6
   **não** marcou como fora do recorte/ambiente, começando pelos de edição das frentes 3–9.
4. **Contínuo:** os 42 rótulos/ícones da barra (`../reverso-barra-do-original.txt`) entram na rodada
   que portar o comando de cada um.

## Depende do dono (não começar sem decisão)

- Relatórios tabulares restantes (9b, `PLANO.md` §7.3).
- Banco multiusuário / SQL Server (9c).
- Cadastro de DWGs (`GERDWG`/`DUPCAD` gravando `DWG`/`DWGH`): hoje o índice vem do `POSITRON_DWG` e o
  `POSITRON.md` dá essas tabelas ao app; o original as grava no plugin.

## Últimas rodadas

| rodada | data | commit | resumo | arquivo |
|---|---|---|---|---|
| 178 | 2026-10-15 | *(este)* | `PESQCAB`: cabos do catálogo (deste DWG e de outros), veias com o `OrdenaVeias`, ir até a veia; `TCHAVE` fora (licença) | `rodadas/178-pesquisa-cabos.md` |
| 177 | 2026-10-15 | `e4f19340` | `PESQC`: veias indefinidas na grade, ir até a veia (página, zoom, realce) | `rodadas/177-pesquisa-veias-indefinidas.md` |
| 176 | 2026-10-15 | `054b001a` | `EDCON`/`EDCONP`: seção e cor das conexões por seleção e por página, tela ligada | `rodadas/176-edicao-secao-cor-conexoes.md` |
| 175 | 2026-10-15 | `5e067c41` | cadeia do `CAD` completa: `TrocaColunas`, `AtualizaRevSimplificada`, `attsync` | `RUNBOOK.md` (histórico) |
| 174 | 2026-10-15 | `9e5135f9` | inserir/excluir página com `AtualizaContTotFl` e ativação segura | `RUNBOOK.md` (histórico) |
