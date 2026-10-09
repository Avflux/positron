<#
.SYNOPSIS
  Importa o catalogo do banco do produto (Access) para o banco do projeto (SQLite).

.DESCRIPTION
  O produto guarda no Access o catalogo (Cabos/Veias/Materiais/ModelosCabos) e o
  cadastro de paineis (Paineis); o positron guarda no SQLite do projeto. Este script
  le a COPIA do .mdb (o original nunca e tocado), exporta as tabelas pedidas para CSV
  e chama o carregador Python (`-Tabelas` muda a lista).

  Serve para verificar o caminho do catalogo de ponta a ponta: com o catalogo
  carregado, o INT carimba Cabos4/Veias4 (snapshot por revisao) e o app deixa de
  mostrar o catalogo vazio.

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-importa-catalogo.ps1 `
      -Banco "$env:TEMP\positron-idem.db"
#>
[CmdletBinding()]
param(
    [string] $Mdb = "..\Elet\RCD\RCD.mdb",
    [string] $Banco,
    [string] $Pasta,
    # Tabelas do projeto que vivem no Access e sao carregadas para o SQLite. As
    # quatro primeiras sao o catalogo; `Paineis` e o cadastro de paineis (o app
    # lista os paineis por ele: `projeto_listar_paineis`).
    [string[]] $Tabelas = @('Cabos', 'Veias', 'Materiais', 'ModelosCabos', 'Paineis')
)

$ErrorActionPreference = "Stop"

if (-not (Test-Path $Mdb)) { throw "nao encontrei o .mdb em '$Mdb'" }
if (-not $Banco) { throw "informe -Banco (o .db do projeto)" }
if (-not (Test-Path (Split-Path -Parent $Banco))) { throw "a pasta do banco nao existe: $Banco" }
if (-not $Pasta) { $Pasta = Join-Path $env:TEMP ('positron-catalogo-' + (Get-Date -Format 'yyyyMMdd-HHmmss')) }
New-Item -ItemType Directory -Force -Path $Pasta | Out-Null

$raiz   = Split-Path -Parent $PSScriptRoot
$python = Join-Path $raiz 'services\sidecar\.venv\Scripts\python.exe'
$loader = Join-Path $PSScriptRoot 'cad-importa-catalogo.py'
if (-not (Test-Path $python)) { throw "nao encontrei o python do sidecar em '$python'" }

$copia = Join-Path $Pasta 'RCD.mdb'
Copy-Item $Mdb $copia -Force

$conn = New-Object System.Data.Odbc.OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=$copia;ReadOnly=1;")
$conn.Open()
try {
    $cmd = $conn.CreateCommand()
    foreach ($tabela in $Tabelas) {
        $cmd.CommandText = "SELECT * FROM [$tabela]"
        $dt = New-Object System.Data.DataTable
        $dt.Load($cmd.ExecuteReader())
        $csv = Join-Path $Pasta ($tabela + '.csv')
        $dt | Export-Csv -Path $csv -NoTypeInformation -Encoding UTF8
        Write-Host ("{0,-14} {1,6} linha(s) -> {2}" -f $tabela, $dt.Rows.Count, $csv)
        if ($dt.Rows.Count -eq 0) {
            Write-Host ("  {0}: vazia no Access, nada a carregar" -f $tabela)
            continue
        }

        & $python $loader $Banco $tabela $csv
        if ($LASTEXITCODE -ne 0) { throw "o carregador falhou em $tabela" }
    }
} finally {
    $conn.Close()
}

