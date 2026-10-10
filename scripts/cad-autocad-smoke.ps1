<#
.SYNOPSIS
  Smoke test do plugin Positron dentro do AutoCAD 2020 (accoreconsole, headless).

.DESCRIPTION
  Equivalente ao `cad-zwcad-smoke.ps1`, mas para o `accoreconsole.exe`. Roda o
  ciclo inteiro sem interface:

  1. confere AutoCAD instalado, DLL compilada e schema.sql;
  2. cria o .db do projeto a partir do schema.sql, se ele nao existir (o
     `ProjectStore` NAO aplica o schema — quem cria e o sidecar ou este harness);
  3. escreve o passo.scr (FILEDIA, SECURELOAD, [fixture], NETLOAD, comandos, QUIT);
  4. exporta POSITRON_* e roda
     `accoreconsole.exe [/i <desenho>] /s <passo.scr>`;
  5. imprime o POSITRON_LOG e sai 0 somente se o plugin disse que carregou.

  Diferencas em relacao ao ZWCAD (todas medidas nesta maquina):

  * o `accoreconsole` e um processo separado — nao ha a armadilha de instancia
    unica nem a necessidade de fechar o CAD antes;
  * o script vai com o caminho COMPLETO e a extensao `.scr` (o ZWCAD e que exige
    o caminho SEM a extensao no `/b`);
  * o desenho entra por `/i <copia>` — o original nunca e tocado;
  * a saida do `accoreconsole` e UTF-16LE e ele redireciona o proprio stdout para
    um arquivo, entao o `POSITRON_LOG` continua sendo a evidencia primaria.

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 -Comandos ELET,FIA,VERIF -Revisao R1

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 `
      -Desenho "..\Elet\RCD\Funcional.dwg" -Dwg 63 -Comandos ELET,FIA,INT,SYNCD,VERIF
#>
[CmdletBinding()]
param(
    [string]   $AutoCadDir = "C:\Program Files\Autodesk\AutoCAD 2020",
    # Nome `Banco` (e nao `Db`) de proposito: `-Db` colide com o alias do
    # parametro comum `-Debug` e o binding falha antes de rodar qualquer coisa.
    [string]   $Banco,
    [int]      $Dwg = 1,
    [string]   $Revisao = "R0",
    [string]   $Local = "LOCAL-A",
    [string[]] $Comandos = @("ELET"),
    [int]      $TimeoutSegundos = 240,
    # Script LISP carregado antes do NETLOAD: monta o desenho do teste
    # (`scripts/cad-fixture.lsp`). Sem ele o desenho aberto fica vazio.
    [string]   $Fixture,
    # Desenho de verdade para abrir no CAD (E2E com dados reais). O script copia
    # para o TEMP e abre a COPIA: o original nunca e tocado.
    [string]   $Desenho
)

$ErrorActionPreference = "Stop"

# O plugin grava o log em UTF-8; sem isso o console exibe os acentos quebrados.
try { [Console]::OutputEncoding = [System.Text.Encoding]::UTF8 } catch { }

# `-Comandos ELET,FIA` chega como UMA string quando vem pelo npm (o `-File` nao
# reparte a lista); normaliza para uma lista de comandos.
$Comandos = @($Comandos -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_.Length -gt 0 })

$raiz   = Split-Path -Parent $PSScriptRoot
$exe    = Join-Path $AutoCadDir "accoreconsole.exe"
$dll    = Join-Path $raiz "cad-plugin\Positron.Plugin\bin\Debug\AutoCAD\net472\Positron.Plugin.AutoCAD.dll"
$schema = Join-Path $raiz "services\sidecar\src\sidecar\db\schema.sql"
$python = Join-Path $raiz "services\sidecar\.venv\Scripts\python.exe"

if (-not (Test-Path $exe)) { throw "accoreconsole nao encontrado em '$AutoCadDir'. Passe -AutoCadDir." }
if (-not (Test-Path $dll)) { throw "DLL do AutoCAD nao compilada: rode 'npm run plugin:build:autocad' antes." }
if (-not (Test-Path $schema)) { throw "schema.sql nao encontrado em '$schema'." }

if ([string]::IsNullOrWhiteSpace($Banco)) {
    $Banco = Join-Path $env:TEMP ("positron-autocad-" + (Get-Date -Format "yyyyMMdd-HHmmss") + ".db")
}
$Banco = [System.IO.Path]::GetFullPath($Banco)

if (-not (Test-Path $Banco)) {
    if (-not (Test-Path $python)) { throw "venv do sidecar nao encontrado; rode 'npm run sidecar:sync'." }
    $src = Join-Path $raiz "services\sidecar\src"
    & $python -c "import sys; sys.path.insert(0, r'$src'); from sidecar.db.project import ProjectDatabase; ProjectDatabase(r'$Banco').create_from_schema()"
    if ($LASTEXITCODE -ne 0) { throw "falha ao criar o banco a partir do schema.sql." }
    Write-Host "banco criado: $Banco"
} else {
    Write-Host "banco existente: $Banco"
}

$carimbo = Get-Date -Format "yyyyMMdd-HHmmss"
$log = Join-Path $env:TEMP ("positron-log-" + $carimbo + ".txt")
$scr = Join-Path $env:TEMP ("positron-passo-" + $carimbo + ".scr")

# O caminho da DLL vai com barras normais: o LISP aceita as duas, e assim a
# string do script nao depende de escape de barra invertida.
$dllFwd = $dll -replace '\\', '/'
$linhas = @(
    '(setvar "FILEDIA" 0)',
    '(setvar "SECURELOAD" 0)'
)
if (-not [string]::IsNullOrWhiteSpace($Fixture)) {
    $fixtureFwd = [System.IO.Path]::GetFullPath($Fixture) -replace '\\', '/'
    $linhas += ('(load "' + $fixtureFwd + '")')
}
$linhas += ('(vl-cmdf "_.NETLOAD" "' + $dllFwd + '")')
$linhas += $Comandos
$linhas += "QUIT"
Set-Content -Path $scr -Value $linhas -Encoding ASCII

$env:POSITRON_DB_PATH  = $Banco
$env:POSITRON_DWG      = "$Dwg"
$env:POSITRON_REVISAO  = $Revisao
$env:POSITRON_LOCAL    = $Local
$env:POSITRON_LOG      = $log

# `/i` (desenho) e `/s` (script). O accoreconsole aceita os dois caminhos
# completos, com extensao.
$argumentos = @()
if (-not [string]::IsNullOrWhiteSpace($Desenho)) {
    if (-not (Test-Path $Desenho)) { throw "desenho nao encontrado: $Desenho" }
    $copia = Join-Path $env:TEMP ("positron-desenho-" + $carimbo + ".dwg")
    Copy-Item $Desenho $copia -Force
    Write-Host "desenho (copia): $copia"
    $argumentos += @("/i", $copia)
}
$argumentos += @("/s", $scr)

Write-Host "rodando: $exe $($argumentos -join ' ')"
# -WorkingDirectory no TEMP: sem isso o accoreconsole pode gravar arquivos de
# trabalho no diretorio de onde foi chamado (a raiz do repo).
$processo = Start-Process -FilePath $exe -ArgumentList $argumentos -WorkingDirectory $env:TEMP -PassThru

if (-not $processo.WaitForExit($TimeoutSegundos * 1000)) {
    Write-Warning "accoreconsole nao terminou em $TimeoutSegundos s; encerrando (PID $($processo.Id))."
    try { Stop-Process -Id $processo.Id -Force } catch { }
}

if (-not (Test-Path $log)) {
    throw "o plugin nao escreveu no POSITRON_LOG. NETLOAD falhou? Confira o caminho da DLL."
}

Write-Host "----- POSITRON_LOG ($log) -----"
# UTF8 explicito: o plugin grava UTF-8 e o Get-Content sem -Encoding le como
# ANSI, o que reintroduz mojibake so na exibicao (o arquivo esta certo).
Get-Content $log -Encoding UTF8 | ForEach-Object { Write-Host $_ }
Write-Host "-------------------------------"

$conteudo = Get-Content $log -Raw -Encoding UTF8
if ($conteudo -notmatch "Positron carregado") {
    Write-Error "o log nao tem 'Positron carregado' - o plugin nao inicializou."
    exit 1
}

Write-Host "OK: plugin carregado no AutoCAD 2020 (banco: $Banco)."
exit 0
