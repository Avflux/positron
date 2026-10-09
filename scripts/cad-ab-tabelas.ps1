<#
.SYNOPSIS
  Exporta as tabelas do diagrama do banco do produto (Access) para CSV, por desenho e revisao.

.DESCRIPTION
  Par do `scripts/cad-ab-tabelas.py`: aquele compara estes CSVs com o banco do recoder.
  Le a COPIA do `.mdb` (o original nunca e tocado) e grava um CSV por tabela, em UTF-8,
  com todas as colunas — a normalizacao (BOOL, NULL, acentos) fica no lado Python, para
  os dois lados passarem pela mesma regra.

  Atencao ao **ciclo de revisao**: a fiacao usa `1..4`; interligacao e cabos usam
  `00A-n`/`CORR`. Comparar com a revisao errada faz a tabela parecer vazia.

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/cad-ab-tabelas.ps1 -Dwg 63 -Revisao 3 -SaidaDir "$env:TEMP\ab"
#>
[CmdletBinding()]
param(
    [string] $Mdb = "..\Elet\RCD\RCD.mdb",
    [int]    $Dwg = 63,
    [string] $Revisao = "3",
    [string] $SaidaDir = "$env:TEMP\positron-ab",
    [string[]] $Tabelas = @('Fiacao', 'Portas4F', 'Bornes4F', 'Contatos4F', 'Dispositivos4F', 'Circuitos4F', 'Aplicacao4F')
)

$ErrorActionPreference = "Stop"
if (-not (Test-Path $Mdb)) { throw "nao encontrei o .mdb em '$Mdb'" }
New-Item -ItemType Directory -Force -Path $SaidaDir | Out-Null

$pasta = Join-Path $SaidaDir ('mdb-' + (Get-Date -Format 'yyyyMMdd-HHmmss'))
New-Item -ItemType Directory -Force -Path $pasta | Out-Null
$copia = Join-Path $pasta 'RCD.mdb'
Copy-Item $Mdb $copia -Force

$conn = New-Object System.Data.Odbc.OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=$copia;ReadOnly=1;")
$conn.Open()
try {
    $cmd = $conn.CreateCommand()
    foreach ($tabela in $Tabelas) {
        $cmd.CommandText = "SELECT * FROM [$tabela] WHERE DWG=$Dwg AND Revisao='$Revisao'"
        $dt = New-Object System.Data.DataTable
        $dt.Load($cmd.ExecuteReader())
        $destino = Join-Path $pasta ($tabela + '.csv')
        # UTF-8 **sem BOM** e as colunas cruas: quem normaliza e o comparador Python.
        $linhas = @()
        $linhas += (($dt.Columns | ForEach-Object { $_.ColumnName }) -join ',')
        foreach ($row in $dt.Rows) {
            $celulas = @()
            foreach ($valor in $row.ItemArray) {
                if ($null -eq $valor) { $celulas += '' }
                else {
                    $texto = [string]$valor
                    if ($texto -match '[,"\r\n]') { $celulas += '"' + ($texto -replace '"', '""') + '"' }
                    else { $celulas += $texto }
                }
            }
            $linhas += ($celulas -join ',')
        }
        [System.IO.File]::WriteAllLines($destino, $linhas, (New-Object Text.UTF8Encoding($false)))
        Write-Host ("  {0,-16} {1,6} linha(s) -> {2}" -f $tabela, $dt.Rows.Count, $destino)
    }
    Write-Host "pasta do produto: $pasta"
} finally {
    $conn.Close()
}

