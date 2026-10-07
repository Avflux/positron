#Requires -Version 5.1
<#
.SYNOPSIS
    Empacota o sidecar Python num único .exe para o Tauri distribuir.

.DESCRIPTION
    Gera apps/desktop/src-tauri/binaries/sidecar-<target-triple>.exe. O Tauri copia
    esse arquivo para o lado do executável principal SEM o sufixo do triple, com o
    nome `sidecar.exe` — que é exatamente o nome que
    apps/desktop/src-tauri/src/sidecar.rs procura em runtime.

    O sufixo do triple não é enfeite: o `externalBin` do Tauri exige esse formato
    no arquivo de origem e falha com "binary not found" se ele faltar.

    No fim roda o executável gerado e confere se ele emitiu o handshake
    SIDECAR_READY. É o teste que pega o erro mais comum do PyInstaller: módulo
    importado dinamicamente que não entrou no bundle.

.PARAMETER Triple
    Target triple a usar no nome. Padrão: o host reportado por `rustc -vV`.

.PARAMETER SkipSync
    Não roda `uv sync` antes (útil em CI, onde as deps já foram instaladas).

.NOTES
    Salve este arquivo como UTF-8 **com BOM**. O PowerShell 5.1 lê arquivos sem
    BOM como ANSI, o que transforma os acentos em lixo e quebra o parser.

.EXAMPLE
    pwsh -File scripts/build-sidecar.ps1
    pwsh -File scripts/build-sidecar.ps1 -Triple x86_64-pc-windows-msvc -SkipSync

.EXAMPLE
    npm run sidecar:build
#>
[CmdletBinding()]
param(
    [string] $Triple = "",
    [switch] $SkipSync
)

# O console legado do Windows (CP850/CP437) não tem 'é' nem 'í', então a saída
# viraria mojibake. Em terminal moderno (UTF-8) isto é inofensivo.
try { [Console]::OutputEncoding = [System.Text.Encoding]::UTF8 } catch { }

# Sem `$ErrorActionPreference = 'Stop'`: no PowerShell 5.1 isso converte o stderr de
# comandos nativos em erro terminante, e `uv` e `pyinstaller` escrevem a barra de
# progresso em stderr. O sinal confiável é o código de saída.

function Invoke-Native {
    <#
        Roda um comando nativo, mostra a saída no console e devolve o código de
        saída. Out-Host (e não Out-Null) porque ver o progresso do PyInstaller
        durante um build de minutos é a diferença entre esperar e achar que travou.
    #>
    param(
        [Parameter(Mandatory = $true)][string] $Program,
        [Parameter()][string[]] $Arguments = @()
    )

    Write-Verbose "$Program $($Arguments -join ' ')"
    & $Program @Arguments | Out-Host

    $code = $LASTEXITCODE
    # Comando não encontrado: o PowerShell nem define LASTEXITCODE.
    if ($null -eq $code) { return 1 }
    return $code
}

function Get-HostTriple {
    if (-not (Get-Command rustc -ErrorAction SilentlyContinue)) { return $null }
    $match = & rustc -vV | Select-String -Pattern '^host:\s*(.+)$'
    if (-not $match -or $match.Matches.Count -eq 0) { return $null }
    return $match.Matches[0].Groups[1].Value.Trim()
}

$repoRoot = Split-Path -Parent $PSScriptRoot
$sidecar  = Join-Path $repoRoot "services\sidecar"
$binDir   = Join-Path $repoRoot "apps\desktop\src-tauri\binaries"
$workDir  = Join-Path $env:TEMP "sidecar-pyinstaller"

if (-not (Test-Path -LiteralPath (Join-Path $sidecar "pyproject.toml"))) {
    throw "não encontrei services/sidecar/pyproject.toml a partir de $repoRoot"
}

if ([string]::IsNullOrWhiteSpace($Triple)) {
    $detected = Get-HostTriple
    if ($detected) {
        $Triple = $detected
    }
    else {
        $Triple = "x86_64-pc-windows-msvc"
        Write-Warning "rustc não está no PATH; assumindo '$Triple'."
    }
}

New-Item -ItemType Directory -Force -Path $binDir  | Out-Null
New-Item -ItemType Directory -Force -Path $workDir | Out-Null

$exeName = "sidecar-$Triple.exe"
$exePath = Join-Path $binDir $exeName

Write-Host "==> Triple : $Triple"
Write-Host "==> Destino: $exePath"

if (-not $SkipSync) {
    Write-Host "==> uv sync"
    Push-Location $sidecar
    try {
        if ((Invoke-Native -Program "uv" -Arguments @("sync", "--group", "dev")) -ne 0) {
            throw "uv sync falhou"
        }
    }
    finally { Pop-Location }
}

Write-Host "==> PyInstaller"
Push-Location $sidecar
try {
    $arguments = @(
        "run", "--no-progress", "--with", "pyinstaller", "pyinstaller",
        "--noconfirm",
        "--clean",
        "--onefile",
        # --paths src: deixa o PyInstaller achar o pacote `sidecar`
        "--paths", "src",
        # --name com o triple: exigência do externalBin do Tauri (ver acima)
        "--name", "sidecar-$Triple",
        "--distpath", $binDir,
        "--workpath", (Join-Path $workDir "build"),
        "--specpath", $workDir,
        # uvicorn e fastapi importam módulos por nome em runtime; a análise
        # estática não enxerga isso e o executável quebraria só na execução.
        "--collect-submodules", "uvicorn",
        "--collect-submodules", "fastapi",
        "tools/entrypoint.py"
    )

    if ((Invoke-Native -Program "uv" -Arguments $arguments) -ne 0) {
        throw "PyInstaller falhou"
    }
}
finally { Pop-Location }

if (-not (Test-Path -LiteralPath $exePath)) {
    throw "esperava encontrar $exePath depois do build"
}

$sizeMb = [math]::Round((Get-Item -LiteralPath $exePath).Length / 1MB, 1)
Write-Host "OK: $exePath ($sizeMb MB)" -ForegroundColor Green

Write-Host "==> Smoke test do executável (handshake em stdout)"
$log = Join-Path $env:TEMP "sidecar-smoke.log"
Remove-Item -LiteralPath $log -Force -ErrorAction SilentlyContinue

$proc = Start-Process -FilePath $exePath `
    -ArgumentList @("--no-http", "--log-level", "WARNING") `
    -RedirectStandardOutput $log `
    -NoNewWindow -PassThru

try {
    $deadline = (Get-Date).AddSeconds(60)
    $line = $null
    while (-not $line -and (Get-Date) -lt $deadline -and -not $proc.HasExited) {
        Start-Sleep -Milliseconds 250
        if (Test-Path -LiteralPath $log) {
            $line = Get-Content -LiteralPath $log -TotalCount 1 -ErrorAction SilentlyContinue
        }
    }

    if ($line -like "SIDECAR_READY *") {
        Write-Host "OK: handshake -> $line" -ForegroundColor Green
    }
    else {
        Write-Warning "o executável não emitiu SIDECAR_READY depois de 60s."
        Write-Warning "Saída capturada em $log"
        throw "smoke test do executável falhou"
    }
}
finally {
    if (-not $proc.HasExited) { Stop-Process -Id $proc.Id -Force }
}
