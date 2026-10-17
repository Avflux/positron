<#
.SYNOPSIS
  Prepara a API local do Excel (a PIA Microsoft.Office.Interop.Excel) em cad-plugin\lib\Excel.

.DESCRIPTION
  O Excel ATIVO da tela frmEditaTitulos (o `clsTextos.ExportaPaginas`/`ImportaTitulos` do reverso)
  fala com a instancia aberta do Excel pela PIA `Microsoft.Office.Interop.Excel` — a mesma que o
  original usa. A copia fica versionada no repo, no padrao das outras APIs vendorizadas
  (`lib\AutoCAD\2020`, `lib\ZWCAD\2026`), para o BUILD nao depender da instalacao do Office.

  Onde a PIA mora (medido em 2026-10-16, Office 16.0 nesta maquina): nao ha
  `Microsoft.Office.Interop.Excel.dll` na pasta do Office — a PIA instalada pelo Office fica no
  **GAC** (`C:\Windows\assembly\GAC_MSIL\Microsoft.Office.Interop.Excel\15.0.0.0__71e9bce111e9429c\`).
  O script procura nessa ordem: o GAC, a pasta do Office/Office16 e uma pasta de PIAs passada em
  -OfficePiaDir.

  Em tempo de execucao nada disso e preciso copiar para junto do plugin: a PIA do Office esta no GAC
  da maquina que tem Excel instalado (e o `<EmbedInteropTypes>` do csproj embute os tipos usados).

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/prepare-excel-api.ps1
#>
param(
  [string]$OfficePiaDir
)

$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$destination = Join-Path $repoRoot "cad-plugin\lib\Excel"
$candidatos = @(
  (Join-Path $env:WINDIR "assembly\GAC_MSIL\Microsoft.Office.Interop.Excel\15.0.0.0__71e9bce111e9429c\Microsoft.Office.Interop.Excel.dll"),
  (Join-Path $env:ProgramFiles "Microsoft Office\root\Office16\Microsoft.Office.Interop.Excel.dll"),
  (Join-Path ${env:ProgramFiles(x86)} "Microsoft Office\root\Office16\Microsoft.Office.Interop.Excel.dll"),
  (Join-Path $env:ProgramFiles "Common Files\Microsoft Shared\VSTO\10.0\Microsoft.Office.Interop.Excel.dll")
)
if (-not [string]::IsNullOrWhiteSpace($OfficePiaDir)) {
  $candidatos = @((Join-Path $OfficePiaDir "Microsoft.Office.Interop.Excel.dll")) + $candidatos
}

$origem = $candidatos | Where-Object { Test-Path -LiteralPath $_ -PathType Leaf } | Select-Object -First 1
if (-not $origem) {
  throw "PIA do Excel nao encontrada (medir antes de afirmar ausencia). Procurei em: $($candidatos -join '; ')"
}

New-Item -ItemType Directory -Path $destination -Force | Out-Null
Copy-Item -LiteralPath $origem -Destination $destination -Force
Write-Output "Copiada: $origem"
Write-Output "API local do Excel preparada em: $destination"
