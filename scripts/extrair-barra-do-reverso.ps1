# Extrai o mapa da barra de ferramentas do reverso (Ribbon.cs): comando, rotulo e icone.
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
  # o icone e atribuido numa variavel poucas linhas antes da chamada
  $antes = $texto.Substring([Math]::Max(0, $m.Index - 500), [Math]::Min(500, $m.Index))
  $icones = [regex]::Matches($antes, "\w+ = Resources\.(\w+)")
  $icone = if ($icones.Count -gt 0) { $icones[$icones.Count - 1].Groups[1].Value } else { "" }
  $linhas.Add(($m.Groups[2].Value + " = " + $m.Groups[1].Value + " | " + $icone))
}

[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Saida), $linhas)
"pares extraidos: " + $linhas.Count
"salvo em " + $Saida