<#
.SYNOPSIS
  Smoke test do plugin Positron dentro do ZWCAD 2026 (execucao por script).

.DESCRIPTION
  1. confere ZWCAD instalado, DLL compilada e schema.sql;
  2. recusa rodar com o ZWCAD aberto (instancia unica: a instancia existente
     nao herda as variaveis POSITRON_*);
  3. cria o .db do projeto a partir do schema.sql, se ele nao existir;
  4. escreve o passo.scr (FILEDIA, SECURELOAD, NETLOAD, comandos, QUIT);
  5. exporta POSITRON_* e roda "ZWCAD.exe /nologo /b passo" — o /b do ZWCAD
     espera o caminho SEM a extensao .scr (com ela o script e ignorado em
     silencio: verificado);
  6. imprime o POSITRON_LOG e sai 0 somente se o plugin disse que carregou.

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Comandos ELET,FIA,VERIF -Revisao R1
#>
[CmdletBinding()]
param(
    [string]   $ZWCadDir = "C:\Program Files\ZWSOFT\ZWCAD 2026",
    # Nome `Banco` (e nao `Db`) de proposito: `-Db` colide com o alias do
    # parametro comum `-Debug` e o binding falha antes de rodar qualquer coisa.
    [string]   $Banco,
    [int]      $Dwg = 1,
    [string]   $Revisao = "R0",
    [string]   $Local = "LOCAL-A",
    [string[]] $Comandos = @("ELET"),
    [int]      $TimeoutSegundos = 240,
    # Depois que o plugin carrega, os comandos do script (ELET/FIA/...) ainda
    # estao rodando: espera essa folga antes de encerrar o ZWCAD.
    [int]      $EsperaSegundos = 15,
    # Script LISP carregado antes do NETLOAD: monta o desenho do teste
    # (`scripts/cad-fixture.lsp`). Sem ele o `Drawing1` fica vazio.
    [string]   $Fixture
)

$ErrorActionPreference = "Stop"

# `-Comandos ELET,FIA` chega como UMA string quando vem pelo npm (o `-File` nao
# reparte a lista); normaliza para uma lista de comandos.
$Comandos = @($Comandos -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_.Length -gt 0 })

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
           "e a instancia existente nao herda POSITRON_*")
}

if ([string]::IsNullOrWhiteSpace($Banco)) {
    $Banco = Join-Path $env:TEMP ("positron-zwcad-" + (Get-Date -Format "yyyyMMdd-HHmmss") + ".db")
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

$linhas = @(
    '(setvar "FILEDIA" 0)',
    '(vl-catch-all-apply (function (lambda () (setvar "SECURELOAD" 0))))',
    # Parenteses obrigatorios: dentro de @() a virgula tem precedencia maior que
    # o `+`; sem eles a concatenacao vira TRES elementos (uma linha cada) e o
    # caminho da DLL cai numa linha propria dentro da string do LISP.
    ('(vl-cmdf "_.NETLOAD" "' + ($dll -replace '\\', '/') + '")')
)
if (-not [string]::IsNullOrWhiteSpace($Fixture)) {
    $fixtureFwd = [System.IO.Path]::GetFullPath($Fixture) -replace '\\', '/'
    # Parenteses de novo: sem eles a virgula do @() quebra o `+` (ver acima).
    $linhas = @($linhas[0], $linhas[1], ('(load "' + $fixtureFwd + '")')) + $linhas[2..($linhas.Count - 1)]
}

$linhas += $Comandos
$linhas += "QUIT"
Set-Content -Path $scr -Value $linhas -Encoding ASCII

$env:POSITRON_DB_PATH  = $Banco
$env:POSITRON_DWG      = "$Dwg"
$env:POSITRON_REVISAO  = $Revisao
$env:POSITRON_LOCAL    = $Local
$env:POSITRON_LOG      = $log

# `/b` sem a extensao .scr: e assim que o ZWCAD acha o script.
# Sem `ChangeExtension(., $null)`: ele deixa um ponto no fim (".scr" -> ".").
$passo = $scr -replace '\.scr$', ''
Write-Host "rodando: $exe /nologo /b $passo"
# O Start-Process pode devolver um launcher que sai e deixa o ZWCAD real vivo;
# guardamos os PIDs de antes para encerrar exatamente o que este script abriu.
$antes = @(Get-Process ZWCAD -ErrorAction SilentlyContinue | Select-Object -ExpandProperty Id)
# -WorkingDirectory no TEMP: sem isso o ZWCAD salva o `Drawing1.dwg` de trabalho
# no diretorio de onde foi chamado (a raiz do repo).
$processo = Start-Process -FilePath $exe -ArgumentList @("/nologo", "/b", $passo) -WorkingDirectory $env:TEMP -PassThru

$limite = [DateTime]::UtcNow.AddSeconds($TimeoutSegundos)
while ([DateTime]::UtcNow -lt $limite) {
    if (Test-Path $log) {
        $texto = Get-Content $log -Raw
        if ($texto -match "Positron carregado") { break }
    }
    if ($processo.HasExited -and (Test-Path $log)) { break }
    Start-Sleep -Milliseconds 500
}

# O loop acima sai quando o plugin carrega — os comandos do .scr (ELET/FIA/...)
# ainda estao na fila. Esta folga deixa o script terminar antes do kill.
Start-Sleep -Seconds $EsperaSegundos

$novos = @(Get-Process ZWCAD -ErrorAction SilentlyContinue | Where-Object { $antes -notcontains $_.Id })
if ($novos.Count -gt 0) {
    Write-Warning ("encerrando o ZWCAD que este script abriu: PID " + (($novos | Select-Object -ExpandProperty Id) -join ", "))
    $novos | ForEach-Object { try { Stop-Process -Id $_.Id -Force } catch { } }
}

if (-not (Test-Path $log)) {
    throw "o plugin nao escreveu no POSITRON_LOG. NETLOAD falhou? Confira o caminho da DLL e o /b sem extensao."
}

Write-Host "----- POSITRON_LOG ($log) -----"
Get-Content $log | ForEach-Object { Write-Host $_ }
Write-Host "-------------------------------"

$conteudo = Get-Content $log -Raw
if ($conteudo -notmatch "Positron carregado") {
    Write-Error "o log nao tem 'Positron carregado' - o plugin nao inicializou."
    exit 1
}

Write-Host "OK: plugin carregado no ZWCAD 2026 (banco: $Banco)."
exit 0
