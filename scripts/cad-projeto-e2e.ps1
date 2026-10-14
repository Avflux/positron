<#
.SYNOPSIS
  Roda o ciclo completo sobre o projeto real: projeta, importa o cadastro e confere o app.

.DESCRIPTION
  Passos (qualquer falha interrompe):

  1. checa que nao ha ZWCAD aberto e apaga o banco alvo;
  2. projeta o desenho no banco novo (`cad:smoke` com `ELET,FIA,INT`);
  3. importa catalogo e cadastro de paineis do Access (`-Mdb`) para o banco;
  4. **projeta o `INT` de novo**, agora com o catalogo carregado — e o `INT` que
     carimba `Cabos4`/`Veias4` como snapshot do catalogo, entao sem esta segunda
     passada o app mostraria zero cabo; roda tambem `COMPLM,VERIF,ELETREL`, para a
     lista de materiais sair junto e o relatorio sair com o catalogo carregado (a
     regra `CaboSemCatalogo` so roda assim);
  5. roda as consultas do app (`scripts/app-consultas.py`);
  6. confere o relatorio do VERIF contra `scripts/verif-baseline.txt`;
  7. com `-Idempotencia`, projeta de novo, gera dois dumps e compara (`--ignorar Data`).

  E o "prove que a coisa toda funciona junto" numa linha so. Cada passo ja existia
  isolado; aqui eles viram um comando reproduzivel, com o desenho e o banco do produto
  como entrada padrao.

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-projeto-e2e.ps1 -Idempotencia

.EXAMPLE
  # host AutoCAD 2020 (accoreconsole) em vez do ZWCAD
  powershell -ExecutionPolicy Bypass -File scripts/cad-projeto-e2e.ps1 -Cad AutoCAD -Idempotencia
#>
[CmdletBinding()]
param(
    # Host CAD que roda os comandos. `ZWCAD` e o alvo do produto; `AutoCAD` usa o
    # `accoreconsole` do AutoCAD 2020 (harness `cad-autocad-smoke.ps1`).
    [ValidateSet('ZWCAD', 'AutoCAD')]
    [string] $Cad = 'ZWCAD',
    # Vazio = o projeto real que mora DENTRO do repo (`cad-plugin/reverso/Teste_projeto_real`,
    # desde a rodada 134). Resolvido contra a raiz do repo, e nao contra o diretorio de chamada.
    [string] $Desenho,
    [string] $Mdb,
    [string] $Banco = "$env:TEMP\positron-projeto.db",
    [int]    $Dwg = 63,
    [string] $Revisao = "R0",
    [int]    $Painel = 503,
    [switch] $Idempotencia,
    [switch] $ExigirBaseline
)

# Script do harness conforme o host. O ZWCAD continua o padrao.
# Invocamos o .ps1 DIRETO (nao por `npm run`): o shim `npm.ps1` do PowerShell
# mastiga os argumentos depois do `--` (npm 11 le `-Revisao`/`-Comandos` como
# cli config) e o harness recebe os parametros errados.
$smokeScript = Join-Path $PSScriptRoot $(if ($Cad -eq 'AutoCAD') { 'cad-autocad-smoke.ps1' } else { 'cad-zwcad-smoke.ps1' })

$ErrorActionPreference = "Stop"
$raiz = Split-Path -Parent $PSScriptRoot
$python = Join-Path $raiz 'services\sidecar\.venv\Scripts\python.exe'

# O relatorio e os dumps da idempotencia saem **ao lado do banco**, e nao no TEMP do sistema:
# (1) e onde o proprio ELETREL grava quando `POSITRON_RELATORIO` nao esta definido (o
# `CaminhoDoRelatorio` do plugin); (2) medido nesta maquina (rodada 151), o python do venv do sidecar
# **nao tem permissao de escrita no `%TEMP%`** — o dump da idempotencia morria com `PermissionError` e
# o passo 6 passava lendo um relatorio velho de outra rodada. Com o `-Banco` dentro do repo (a receita
# desta maquina) os dois funcionam; com o banco no default, a pasta e a mesma de antes.
$pastaSaida = Split-Path -Parent ([System.IO.Path]::GetFullPath($Banco))
$relatorio = Join-Path $pastaSaida 'positron-relatorio.txt'

# O projeto real (desenho + banco de referencia do produto) mora DENTRO do repo desde a rodada 134
# (cad-plugin/reverso/Teste_projeto_real); os defaults saem da RAIZ DO REPO, e nao do diretorio de
# chamada — era '..\Elet\...', de quando o material estava fora do repo.
if ([string]::IsNullOrWhiteSpace($Desenho)) {
    $Desenho = Join-Path $raiz 'cad-plugin\reverso\Teste_projeto_real\Funcional.dwg'
}
if ([string]::IsNullOrWhiteSpace($Mdb)) {
    $Mdb = Join-Path $raiz 'cad-plugin\reverso\Teste_projeto_real\RCD.mdb'
}

if (-not (Test-Path $Desenho)) { throw "nao encontrei o desenho em '$Desenho'" }
if (-not (Test-Path $Mdb)) { throw "nao encontrei o .mdb em '$Mdb'" }
if (-not (Test-Path $python)) { throw "nao encontrei o python do sidecar em '$python'" }

if ($Cad -eq 'ZWCAD') {
    # O host do produto e o ZWCAD, mas nem toda maquina tem os dois: sem o ZWCAD instalado o default
    # falharia dentro do harness com 'ZWCAD nao encontrado'; aqui a mensagem ja diz o host que existe.
    $zwcadDir = @('C:\Program Files\ZWSOFT\ZWCAD 2026', 'C:\Program Files\ZWSOFT\ZWCAD 2025') |
        Where-Object { Test-Path $_ } | Select-Object -First 1
    if (-not $zwcadDir) {
        throw ("ZWCAD nao esta instalado (procurei em 'C:\Program Files\ZWSOFT\ZWCAD 2026' e 2025). " +
               "Nesta maquina o host verificado e o AutoCAD 2020: rode com '-Cad AutoCAD'.")
    }
    if (Get-Process ZWCAD -ErrorAction SilentlyContinue) {
        throw "ZWCAD esta aberto; feche-o (instancia unica e nao herda POSITRON_*)"
    }
}

Write-Host "=== 1/6 banco novo ===" -ForegroundColor Cyan
Remove-Item $Banco -ErrorAction SilentlyContinue
Write-Host "  banco: $Banco"

Write-Host "=== 2/7 projecao ($Desenho / DWG $Dwg / $Revisao) ===" -ForegroundColor Cyan
& powershell -NoProfile -ExecutionPolicy Bypass -File $smokeScript -Dwg $Dwg -Revisao $Revisao -Comandos ELET,FIA,INT `
    -Desenho $Desenho -Banco $Banco 2>&1 | Select-String -Pattern "FIA:|INT:" | ForEach-Object { "  " + $_.Line }
if ($LASTEXITCODE -ne 0) { throw "cad:smoke falhou (exit $LASTEXITCODE)" }

Write-Host "=== 3/7 catalogo e cadastro de paineis ===" -ForegroundColor Cyan
powershell -ExecutionPolicy Bypass -File (Join-Path $PSScriptRoot 'cad-importa-catalogo.ps1') `
    -Banco $Banco -Mdb $Mdb | ForEach-Object { "  " + $_ }
if ($LASTEXITCODE -ne 0) { throw "a importacao falhou (exit $LASTEXITCODE)" }

Write-Host "=== 4/7 INT de novo, com o catalogo carregado (+ COMPLM/VERIF/ELETREL) ===" -ForegroundColor Cyan
& powershell -NoProfile -ExecutionPolicy Bypass -File $smokeScript -Dwg $Dwg -Revisao $Revisao -Comandos INT,COMPLM,VERIF,ELETREL `
    -Desenho $Desenho -Banco $Banco 2>&1 | Select-String -Pattern "INT:|COMPLM:|VERIF:|ELETREL:" | ForEach-Object { "  " + $_.Line }
if ($LASTEXITCODE -ne 0) { throw "a segunda passada de INT falhou (exit $LASTEXITCODE)" }

Write-Host "=== 5/7 consultas do app ===" -ForegroundColor Cyan
& $python (Join-Path $PSScriptRoot 'app-consultas.py') $Banco --painel $Painel | ForEach-Object { "  $_" }
if ($LASTEXITCODE -ne 0) { throw "as consultas do app falharam (exit $LASTEXITCODE)" }

Write-Host "=== 5b/7 relatorios tabulares do app ===" -ForegroundColor Cyan
& $python (Join-Path $PSScriptRoot 'app-relatorios.py') $Banco --painel $Painel --revisao $Revisao --amostra 2 |
    Select-String -Pattern "^== |^   \.\.\. mais" | ForEach-Object { "  " + $_.Line }
if ($LASTEXITCODE -ne 0) { throw "os relatorios do app falharam (exit $LASTEXITCODE)" }

Write-Host "=== 6/7 relatorio do VERIF contra a linha de base ===" -ForegroundColor Cyan
if (-not (Test-Path $relatorio)) { throw "o ELETREL nao escreveu o relatorio em $relatorio" }
& $python (Join-Path $PSScriptRoot 'cad-verif-baseline.py') $relatorio | ForEach-Object { "  $_" }
$baselineOk = ($LASTEXITCODE -eq 0)
if (-not $baselineOk -and $ExigirBaseline) { throw 'o relatorio saiu da linha de base (e -ExigirBaseline foi pedido)' }

if ($Idempotencia) {
    Write-Host "=== 7/7 idempotencia (3a passada e comparacao de conteudo) ===" -ForegroundColor Cyan
    & powershell -NoProfile -ExecutionPolicy Bypass -File $smokeScript -Dwg $Dwg -Revisao $Revisao -Comandos FIA,INT -Desenho $Desenho -Banco $Banco 2>&1 |
        Select-String -Pattern "FIA:|INT:" | ForEach-Object { "  " + $_.Line }
    $dumpA = Join-Path $pastaSaida 'positron-e2e-a.txt'
    $dumpB = Join-Path $pastaSaida 'positron-e2e-b.txt'
    & $python (Join-Path $PSScriptRoot 'cad-dump-tabelas.py') dump $Banco $Dwg $dumpA | ForEach-Object { "  $_" }
    & powershell -NoProfile -ExecutionPolicy Bypass -File $smokeScript -Dwg $Dwg -Revisao $Revisao -Comandos FIA,INT -Desenho $Desenho -Banco $Banco 2>&1 | Out-Null
    & $python (Join-Path $PSScriptRoot 'cad-dump-tabelas.py') dump $Banco $Dwg $dumpB | ForEach-Object { "  $_" }
    & $python (Join-Path $PSScriptRoot 'cad-dump-tabelas.py') comparar $dumpA $dumpB --ignorar Data | ForEach-Object { "  $_" }
    if ($LASTEXITCODE -ne 0) { throw 'a projecao nao foi idempotente' }
}

Write-Host "=== OK: ciclo completo no banco $Banco ===" -ForegroundColor Green
if (-not $baselineOk) { Write-Host '  (atencao: relatorio fora da linha de base)' -ForegroundColor Yellow }

