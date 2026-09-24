# Extrai as imagens que ficam no .resx de CADA formulario - as que o designer pega por
# `componentResourceManager.GetObject("btAdicionar.Image")` e que NAO estao no
# `Eletron4.Resources` global (aquelas saem pelo scripts/extrair-icones-do-reverso.ps1).
#
# O valor no .resx e um Bitmap serializado pelo BinaryFormatter
# (`mimetype="application/x-microsoft.net.object.binary.base64"`): decodifica o base64 e
# desserializa - e o mesmo caminho que o ResourceReader do .NET faz.
#
# O nome do arquivo e a chave sem o sufixo da propriedade (`btAdicionar.Image` -> `btAdicionar`),
# que e o nome que o scripts/extrair-formularios-do-reverso.ps1 grava no mapa.
#
# Uso: powershell -File scripts/extrair-imagens-dos-formularios.ps1
[CmdletBinding()]
param(
  [string] $Reverso = "C:\Users\Administrator\Downloads\Elet\Eletron4_ZWcad\decompiled-cleaned",
  [string] $Saida   = "cad-plugin\lib\Icons"
)

if (-not (Test-Path $Reverso)) { throw "reverso nao encontrado: $Reverso" }

New-Item -ItemType Directory -Force -Path $Saida | Out-Null
$bin = New-Object System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

$ok = 0
$falhas = New-Object System.Collections.Generic.List[string]
foreach ($arquivo in (Get-ChildItem -Path $Reverso -Filter 'Eletron4.*.resx')) {
  $doc = New-Object System.Xml.XmlDocument
  $doc.Load($arquivo.FullName)

  foreach ($dado in $doc.SelectNodes('/root/data')) {
    $chave = $dado.GetAttribute('name')
    if ($chave -notmatch '\.(Image|BackgroundImage)$') { continue }

    $nome = $chave -replace '\.(Image|BackgroundImage)$', ''
    try {
      $texto = $dado.SelectSingleNode('value').InnerText -replace '\s', ''
      $bytes = [Convert]::FromBase64String($texto)
      $ms = New-Object System.IO.MemoryStream(, $bytes)
      $obj = $bin.Deserialize($ms)
      if ($obj -is [System.Drawing.Bitmap]) {
        $obj.Save((Join-Path $Saida ($nome + '.png')), [System.Drawing.Imaging.ImageFormat]::Png)
        $obj.Dispose()
        $ok++
      } else {
        $falhas.Add($arquivo.Name + ' :: ' + $chave + ' (nao e Bitmap: ' + $obj.GetType().Name + ')')
      }
    } catch {
      $falhas.Add($arquivo.Name + ' :: ' + $chave + ' :: ' + $_.Exception.Message)
    }
  }
}

"imagens extraidas: " + $ok
if ($falhas.Count -gt 0) { "falhas (" + $falhas.Count + "):"; $falhas | Select-Object -First 8 }
"pasta: " + (Join-Path (Get-Location) $Saida)
