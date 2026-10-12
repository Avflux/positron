param(
  [string]$AutoCadDir = "$env:ProgramFiles\Autodesk\AutoCAD 2020"
)

$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$destination = Join-Path $repoRoot "cad-plugin\lib\AutoCAD\2020"
# AdWindows traz a API de interface do AutoCAD (Autodesk.Windows: o RibbonControl e os itens);
# e a irma da `ZdWindows` do ZWCAD; sem ela o build AutoCAD nao compila a barra.
$assemblies = @("accoremgd.dll", "acmgd.dll", "acdbmgd.dll", "AdWindows.dll")

foreach ($assembly in $assemblies) {
  $source = Join-Path $AutoCadDir $assembly
  if (-not (Test-Path -LiteralPath $source -PathType Leaf)) {
    throw "Assembly do AutoCAD não encontrada: $source"
  }
}

New-Item -ItemType Directory -Path $destination -Force | Out-Null
foreach ($assembly in $assemblies) {
  Copy-Item -LiteralPath (Join-Path $AutoCadDir $assembly) -Destination $destination -Force
  Write-Output "Copiado: $assembly"
}

Write-Output "API local do AutoCAD preparada em: $destination"
