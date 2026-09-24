# Extrai o mapa da barra de ferramentas do reverso (Ribbon.cs) para um arquivo de texto.
# Uso: powershell -File scripts/extrair-barra-do-reverso.ps1
[CmdletBinding()]
param(
  [string] $Ribbon = "C:\Users\Administrator\Downloads\Elet\Eletron4_ZWcad\decompiled-cleaned\Eletron4\Ribbon.cs",
  [string] $Saida  = "docs\reverso-barra-do-original.txt"
)

if (-not (Test-Path $Ribbon)) { throw "Ribbon.cs nao encontrado: $Ribbon" }

$texto = [System.IO.File]::ReadAllText($Ribbon)
$padrao = '"([^"]{1,60})"[ ]*,[ ]*"([A-Za-z0-9_]+)[ ]+"'
$linhas = New-Object System.Collections.Generic.List[string]
foreach ($m in [regex]::Matches($texto, $padrao)) {
  $linhas.Add(($m.Groups[2].Value + " = " + $m.Groups[1].Value))
}

[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Saida), $linhas)
"pares extraidos: " + $linhas.Count
"salvo em " + $Saida
