<#
.SYNOPSIS
  Smoke test do plugin Positron dentro do ZWCAD 2026 (execucao por script).

.DESCRIPTION
  1. confere ZWCAD instalado, DLL compilada e schema.sql;
  2. recusa rodar com o ZWCAD aberto (instancia unica: a instancia existente
     nao herda as variaveis POSITRON_*);
  3. cria o .db do projeto a partir do schema.sql, se ele nao existir;
  4. escreve o passo.scr (FILEDIA, SECURELOAD, NETLOAD, comandos, QUIT);
  5. exporta POSITRON_* e roda "ZWCAD.exe /nologo /b passo.scr";
  6. imprime o POSITRON_LOG e sai 0 somente se o plugin disse que carregou.

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Comandos ELET,FIA,VERIF -Revisao R1
#>
[CmdletBinding()]
param(
    [string]   $ZWCadDir = "C:\Program Files\ZWSOFT\ZWCAD 2026",
    [string]   $Db,
    [int]      $Dwg = 1,
    [string]   $Revisao = "R0",
    [string]   $Local = "LOCAL-A",
    [string[]] $Comandos = @("ELET"),
    [int]      $TimeoutSegundos = 240
)

$ErrorActionPreference = "Stop"

$raiz   = Split-Path -Parent $PSScriptRoot
$exe    = Join-Path $ZWCadDir "ZWCAD.exe"
$dll    = Join-Path $raiz "cad-plugin\Positron.Plugin\bin\Debug\ZWCAD\net472\Positron.Plugin.ZWCAD.dll"
$schema = Join-Path $raiz "services\sidecar\src\sidecar\db\schema.sql"
$python = Join-Path $raiz "services\sidecar\.venv\Scripts\python.exe"

if (-not (Test-Path $exe)) { throw "ZWCAD nao encontrado em '$ZWCadDir'. Passe -ZWCadDir." }
if (-not (Test-Path $dll)) { throw "DLL nao compilada: rode 'npm run plugin:build' antes." }
if (-not (Test-Path $schema)) { throw "schema.sql nao encontrado em '$schema'." }

$aberto = Get-Process ZWCAD -ErrorAction SilentlyContinue
if ($aberto) {
    throw ("ZWCAD ja esta aberto (PID " + ($aberto.Id -join ", ") + "). Feche-o: o ZWCAD e instancia unica " +
           "e a instancia existente nao herda POSITRON_*.")
}

if ([string]::IsNullOrWhiteSpace($Db)) {
    $Db = Join-Path $env:TEMP ("positron-zwcad-" + (Get-Date -Format "yyyyMMdd-HHmmss") + ".db")
}
$Db = [System.IO.Path]::GetFullPath($Db)

if (-not (Test-Path $Db)) {
    if (-not (Test-Path $python)) { throw "venv do sidecar nao encontrado; rode 'npm run sidecar:sync'." }
    $src = Join-Path $raiz "services\sidecar\src"
    & $python -c "import sys; sys.path.insert(0, r'$src'); from sidecar.db.project import ProjectDatabase; ProjectDatabase(r'$Db').create_from_schema()"
    if ($LASTEXITCODE -ne 0) { throw "falha ao criar o banco a partir do schema.sql." }
    Write-Host "banco criado: $Db"
} else {
    Write-Host "banco existente: $Db"
}

$carimbo = Get-Date -Format "yyyyMMdd-HHmmss"
$log = Join-Path $env:TEMP ("positron-log-" + $carimbo + ".txt")
$scr = Join-Path $env:TEMP ("positron-passo-" + $carimbo + ".scr")

$linhas = @(
    '(setvar "FILEDIA" 0)',
    '(setvar "SECURELOAD" 0)',
    '(vl-cmdf "_.NETLOAD" "' + ($dll -replace '\\', '/') + '")'
)
$linhas += $Comandos
$linhas += "QUIT"
Set-Content -Path $scr -Value $linhas -Encoding ASCII

$env:POSITRON_DB_PATH  = $Db
$env:POSITRON_DWG      = "$Dwg"
$env:POSITRON_REVISAO  = $Revisao
$env:POSITRON_LOCAL    = $Local
$env:POSITRON_LOG      = $log

Write-Host "rodando: $exe /nologo /b $scr"
$processo = Start-Process -FilePath $exe -ArgumentList @("/nologo", "/b", $scr) -PassThru

$limite = [DateTime]::UtcNow.AddSeconds($TimeoutSegundos)
while ([DateTime]::UtcNow -lt $limite) {
    if (Test-Path $log) {
        $texto = Get-Content $log -Raw
        if ($texto -match "Positron carregado") { break }
    }
    if ($processo.HasExited -and (Test-Path $log)) { break }
    Start-Sleep -Milliseconds 500
}

if (-not $processo.HasExited) {
    Write-Warning "ZWCAD ainda rodando; encerrando o processo que este script abriu (PID $($processo.Id))."
    try { $processo.Kill() } catch { }
}

if (-not (Test-Path $log)) {
    throw "o plugin nao escreveu no POSITRON_LOG. NETLOAD falhou? Confira o caminho da DLL, FILEDIA e SECURELOAD."
}

Write-Host "----- POSITRON_LOG ($log) -----"
Get-Content $log | ForEach-Object { Write-Host $_ }
Write-Host "-------------------------------"

$conteudo = Get-Content $log -Raw
if ($conteudo -notmatch "Positron carregado") {
    Write-Error "o log nao tem 'Positron carregado' - o plugin nao inicializou."
    exit 1
}

Write-Host "OK: plugin carregado no ZWCAD 2026 (banco: $Db)."
exit 0
