# Extrai os icones da interface do DLL original (via de4dot + ResourceManager).
#
# Pre-requisito: o Eletron4Z-cleaned.dll gerado pelo de4dot a partir do Eletron4Z.dll:
#   de4dot.exe Eletron4Z.dll          (o obfuscador detectado e o .NET Reactor)
#
# Uso: powershell -File scripts/extrair-icones-do-reverso.ps1 [-Dll <cleaned>] [-Saida <pasta>]
[CmdletBinding()]
param(
  # a DLL ja desobfuscada e o resto do reverso vivem dentro do repo desde a rodada 134
  # (cad-plugin/reverso), entao a extracao nao depende mais do de4dot rodar de novo.
  [string] $Dll   = "cad-plugin\reverso\Eletron4_ZWcad\cleaned\Eletron4Z-cleaned.dll",
  [string] $Saida = "cad-plugin\lib\Icons",
  [string] $Acessores = "cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4.My.Resources\Resources.cs",
  [string] $ZWCAD = "C:\Program Files\ZWSOFT\ZWCAD 2026",
  [string] $Origem = "cad-plugin\reverso\Eletron4_ZWcad\DLL"
)

if (-not (Test-Path $Dll)) { throw "DLL limpa nao encontrada: $Dll (rode o de4dot primeiro)" }
if (-not (Test-Path $Acessores)) { throw "Resources.cs nao encontrado: $Acessores" }

# 1) os nomes dos icones saem dos acessores do proprio produto
$nomes = [regex]::Matches([System.IO.File]::ReadAllText($Acessores), "internal static Bitmap (\w+)") |
  ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
"icones no produto: " + $nomes.Count

# 2) resolve as dependencias do assembly limpo (ZwManaged, ZwDatabaseMgd, ...)
$handler = [System.ResolveEventHandler]{ param($s,$e) $n = ($e.Name -split ",")[0] + ".dll"; foreach ($p in @($Origem, $ZWCAD, (Split-Path $Dll))) { $c = Join-Path $p $n; if (Test-Path $c) { return [System.Reflection.Assembly]::LoadFrom($c) } }; return $null }
[System.AppDomain]::CurrentDomain.add_AssemblyResolve($handler)

$asm = [System.Reflection.Assembly]::LoadFrom($Dll)
$rm = New-Object System.Resources.ResourceManager("Eletron4.Resources", $asm)

# 3) extrai cada Bitmap para PNG
New-Item -ItemType Directory -Force -Path $Saida | Out-Null
$ok = 0; $falhas = New-Object System.Collections.Generic.List[string]
foreach ($nome in $nomes) {
  try {
    $obj = $rm.GetObject($nome)
    if ($obj -is [System.Drawing.Bitmap]) {
      $obj.Save((Join-Path $Saida ($nome + ".png")), [System.Drawing.Imaging.ImageFormat]::Png)
      $ok++
      $obj.Dispose()
    } else { $falhas.Add($nome + " (nao e Bitmap)") }
  } catch { $falhas.Add($nome + " :: " + $_.Exception.Message) }
}

"extraidos: " + $ok + " de " + $nomes.Count
if ($falhas.Count -gt 0) { "falhas (" + $falhas.Count + "):"; $falhas | Select-Object -First 8 }
"pasta: " + (Join-Path (Get-Location) $Saida)
