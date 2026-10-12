param(
  [string]$AutoCadDir = "$env:ProgramFiles\Autodesk\AutoCAD 2020"
)

$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$destination = Join-Path $repoRoot "cad-plugin\lib\AutoCAD\2020"
$assemblies = @("accoremgd.dll", "acmgd.dll", "acdbmgd.dll")

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
