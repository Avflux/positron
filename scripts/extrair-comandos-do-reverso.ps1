# Extrai o mapa COMANDO -> JANELA do reverso: cada [CommandMethod] do original e qual `frm*`
# ele abre. No Eletron4Z o comando e fino de proposito: o corpo monta a janela
# (`new frmGerenciadorDWG();`) e a propria janela abre dentro do CAD
# (`Application.ShowModelessDialog(this)` no construtor do `frm*`). A lista de comandos diz,
# portanto, QUAIS nomes abrem QUAIS das telas decodificadas pelo extrair-formularios-do-reverso.ps1.
#
# Duas marcas decidem o destino de cada comando:
#   * SO ABRE A JANELA - o corpo nao tem outro trabalho (nenhuma chamada alem do `new frm*`).
#     Um comando que tambem faz regra (o SYNCD, por exemplo) fica de fora.
#   * SEM VARIANTE - a construcao e `new frmX()`. No original varios comandos abrem a MESMA tela
#     com um argumento que troca a variante (`new frmRelatorio_DICemig(3)`); esses nao podem ser
#     registrados como se fossem a tela padrao, porque nao sao.
# Os que passam nas duas viram comando no plugin (o `ComandosDoOriginal.Gerado.cs`), com o nome
# do original - e so o nome, que a tela vem do mapa `Positron.Data.Interface.Mapas.ComandosDoReverso`.
#
# Uso: powershell -File scripts/extrair-comandos-do-reverso.ps1 [-Amostra]
[CmdletBinding()]
param(
  [string] $Reverso = "C:\Users\Administrator\Downloads\Elet\Eletron4_ZWcad\decompiled-cleaned",
  [string] $Plugins = "cad-plugin\Positron.Plugin",
  [string] $Mapa    = "docs\reverso-comandos.txt",
  [string] $Dados   = "cad-plugin\Positron.Data\Interface\Mapas\ComandosDoReverso.Dados.cs",
  [string] $Gerado  = "cad-plugin\Positron.Plugin\ComandosDoOriginal.Gerado.cs",
  [switch] $Amostra
)

if (-not (Test-Path $Reverso)) { throw "reverso nao encontrado: $Reverso" }

# ---------------------------------------------------------------- o que o plugin ja implementa
$jaNoPlugin = @{}
if (Test-Path $Plugins) {
  # `.Gerado.cs` fica de fora: o registro que este mesmo script gera nao e implementacao do
  # recoder - se ele entrasse na conta, todo comando sairia como "ja no plugin" e o gerador
  # se esvaziaria na segunda rodada.
  foreach ($arquivo in (Get-ChildItem -Path $Plugins -Recurse -Filter *.cs | Where-Object { $_.Name -notlike '*.Gerado.cs' })) {
    $texto = [System.IO.File]::ReadAllText($arquivo.FullName)
    foreach ($m in [regex]::Matches($texto, '\[CommandMethod\("([^"]+)"\)\]')) {
      $jaNoPlugin[$m.Groups[1].Value] = $arquivo.Name
    }
  }
}

# ---------------------------------------------------------------- chaves, strings e o "resto"
# A contagem de chaves tem de ignorar o que esta dentro de literal de string (`"{"`, por exemplo).
function SemTexto([string] $linha) {
  return [regex]::Replace($linha, '"(\\.|[^"\\])*"', '""')
}

# Tira os `new frmX(...)` do corpo (com os parenteses balanceados) para sobrar o que mais ele faz.
function TirarJanelas([string] $texto) {
  $saida = New-Object System.Text.StringBuilder
  $i = 0
  while ($i -lt $texto.Length) {
    $m = [regex]::Match($texto.Substring($i), '^new\s+(frm|Frm)[A-Za-z_0-9]*\s*\(')
    if (-not $m.Success) {
      [void]$saida.Append($texto[$i])
      $i++
      continue
    }

    $j = $i + $m.Length
    $nivel = 1
    $dentroDeTexto = $false
    while ($j -lt $texto.Length -and $nivel -gt 0) {
      $c = $texto[$j]
      if ($c -eq '"' -and $texto[$j - 1] -ne '\') { $dentroDeTexto = -not $dentroDeTexto }
      if (-not $dentroDeTexto) {
        if ($c -eq '(') { $nivel++ }
        if ($c -eq ')') { $nivel-- }
      }
      $j++
    }

    [void]$saida.Append('AbriuJanela')
    $i = $j
  }

  return $saida.ToString()
}

# A construcao inteira de cada `new frmX(...)` - a evidencia da variante.
function Construcoes([string] $texto) {
  $achadas = New-Object System.Collections.ArrayList
  foreach ($m in [regex]::Matches($texto, 'new\s+((frm|Frm)[A-Za-z_0-9]*)\s*\(')) {
    $j = $m.Index + $m.Length
    $nivel = 1
    $dentroDeTexto = $false
    while ($j -lt $texto.Length -and $nivel -gt 0) {
      $c = $texto[$j]
      if ($c -eq '"' -and $texto[$j - 1] -ne '\') { $dentroDeTexto = -not $dentroDeTexto }
      if (-not $dentroDeTexto) {
        if ($c -eq '(') { $nivel++ }
        if ($c -eq ')') { $nivel-- }
      }
      $j++
    }

    [void]$achadas.Add([pscustomobject]@{
      Tela       = $m.Groups[1].Value
      Construcao = ([regex]::Replace($texto.Substring($m.Index, $j - $m.Index), '\s+', ' '))
      ComArg     = (($j - $m.Index) -gt ($m.Length + 1))
    })
  }

  return $achadas
}

# ---------------------------------------------------------------- a varredura dos comandos
$comandos = New-Object System.Collections.ArrayList
foreach ($arquivo in (Get-ChildItem -Path $Reverso -Recurse -Filter *.cs | Sort-Object FullName)) {
  $linhas = [System.IO.File]::ReadAllLines($arquivo.FullName)
  for ($i = 0; $i -lt $linhas.Count; $i++) {
    $atributo = [regex]::Match($linhas[$i], '^\s*\[CommandMethod\("([^"]+)"\)\]\s*$')
    if (-not $atributo.Success) { continue }

    $nome = $atributo.Groups[1].Value
    $linhaDoAtributo = $i + 1

    # o corpo: da abertura de chaves ate ela fechar; se um novo atributo aparecer antes, desiste
    $i = $i + 1
    $achouChave = $false
    while ($i -lt $linhas.Count -and -not $achouChave) {
      if ($linhas[$i] -match '\[CommandMethod\(') { break }
      # NAO avanca depois de achar a chave: a contagem do nivel comeca nela. Avancar aqui
      # deixava o corpo comecar ja dentro do bloco, e ai um corpo que abre com guarda
      # (`if (clsRegua.VerificaRegua())` - o DEF, o EDBORN) fechava na primeira linha e
      # perdia o `new frmX()` que estava dentro.
      if ((SemTexto $linhas[$i]) -match '\{') { $achouChave = $true; break }
      $i++
    }

    if (-not $achouChave) { continue }

    $corpo = New-Object System.Collections.ArrayList
    $nivel = 0
    while ($i -lt $linhas.Count) {
      $limpa = SemTexto $linhas[$i]
      $nivel += ([regex]::Matches($limpa, '\{')).Count
      $nivel -= ([regex]::Matches($limpa, '\}')).Count
      [void]$corpo.Add($linhas[$i])
      $i++
      if ($nivel -le 0) { break }
    }

    $texto = ($corpo -join "`n")
    # @() de proposito: comando com uma janela so devolve um objeto, e ai o `.Count` do
    # PowerShell 5.1 nao vale 1 - o if viraria falso e todo comando caira como "faz mais".
    $janelas = @(Construcoes $texto)

    # o "resto": o corpo sem os `new frm*`, sem as condicoes, sem as guardas e sem os rotulos
    $resto = TirarJanelas $texto
    $resto = [regex]::Replace($resto, '"(?:\\.|[^"\\])*"', '""')
    $guardas = New-Object System.Collections.ArrayList
    foreach ($g in [regex]::Matches($resto, 'if\s*\(([^;{}]*)\)')) {
      $condicao = ([regex]::Replace($g.Groups[1].Value, '\s+', ' ')).Trim()
      if ($condicao.Length -gt 0) { [void]$guardas.Add($condicao) }
    }

    $resto = [regex]::Replace($resto, '(?m)^\s*(if|else|try|catch|finally|return|break|continue|checked|unchecked|using)\b.*$', '')

    # Nomes benignos: o que so existe por causa da guarda ou do relato de erro do original.
    # Tudo o que sobrar depois deles e trabalho de verdade - e entao o comando nao entra como
    # "so abre a janela" (e o SYNCD, que roda a sincronizacao inteira e nao abre nada).
    $resto = [regex]::Replace($resto, 'AbriuJanela', ' ')
    $benignos = 'ProjectData|Interaction|MsgBoxStyle|Operators|Conversions|Information|RuntimeHelpers|Strings|Geral|clsRegua|DeclaracoesGeral|Exception'
    $resto = [regex]::Replace($resto, '\b(' + $benignos + ')\b', '')
    $resto = [regex]::Replace($resto, '[^A-Za-z_0-9]', ' ')
    $sobrou = ([regex]::Replace($resto, '\s+', ' ')).Trim()

    [void]$comandos.Add([pscustomobject]@{
      Nome          = $nome
      Arquivo       = $arquivo.Name
      Linha         = $linhaDoAtributo
      Janelas       = @($janelas)
      Telas         = @($janelas | ForEach-Object { $_.Tela })
      SomenteJanela = ($janelas.Count -gt 0 -and $sobrou.Length -eq 0)
      ComVariante   = (@($janelas | Where-Object { $_.ComArg }).Count -gt 0)
      Guardas       = @($guardas)
      JaNoPlugin    = $jaNoPlugin.ContainsKey($nome)
      Sobrou        = $sobrou
    })
  }
}

# Comando repetido (o original declara o mesmo nome em duas classes): fica o primeiro.
$unicos = New-Object System.Collections.ArrayList
$vistos = @{}
foreach ($c in ($comandos | Sort-Object Nome, Arquivo, Linha)) {
  if ($vistos.ContainsKey($c.Nome)) { continue }
  $vistos[$c.Nome] = $true
  [void]$unicos.Add($c)
}

$reservadas = @('abstract', 'as', 'base', 'bool', 'break', 'byte', 'case', 'catch', 'char', 'checked', 'class',
  'const', 'continue', 'decimal', 'default', 'delegate', 'do', 'double', 'else', 'enum', 'event', 'explicit',
  'extern', 'false', 'finally', 'fixed', 'float', 'for', 'foreach', 'goto', 'if', 'implicit', 'in', 'int',
  'interface', 'internal', 'is', 'lock', 'long', 'namespace', 'new', 'null', 'object', 'operator', 'out',
  'override', 'params', 'private', 'protected', 'public', 'readonly', 'ref', 'return', 'sbyte', 'sealed',
  'short', 'sizeof', 'stackalloc', 'static', 'string', 'struct', 'switch', 'this', 'throw', 'true', 'try',
  'typeof', 'uint', 'ulong', 'unchecked', 'unsafe', 'ushort', 'using', 'virtual', 'void', 'volatile', 'while')

$comTelas = @($unicos | Where-Object { $_.Telas.Count -gt 0 })
$soJanela = @($unicos | Where-Object { $_.SomenteJanela })
$variante = @($soJanela | Where-Object { $_.ComVariante })
$ligaveis = @($soJanela | Where-Object { (-not $_.ComVariante) -and (-not $_.JaNoPlugin) -and ($_.Nome -match '^[A-Za-z_][A-Za-z_0-9]*$') -and ($reservadas -notcontains $_.Nome) })

if ($Amostra) {
  Write-Output "--- SO ABRE A JANELA, SEM VARIANTE (primeiros 30) ---"
  foreach ($c in ($soJanela | Where-Object { -not $_.ComVariante } | Select-Object -First 30)) {
    $construcoes = (($c.Janelas | ForEach-Object { $_.Construcao }) -join ' ')
    Write-Output ($c.Nome.PadRight(24) + ' ' + $construcoes.PadRight(44) + ' ' + $c.Arquivo)
  }
  Write-Output "--- SO ABRE A JANELA, MAS ABRE UMA VARIANTE (todos) ---"
  foreach ($c in $variante) {
    $construcoes = (($c.Janelas | ForEach-Object { $_.Construcao }) -join ' ')
    Write-Output ($c.Nome.PadRight(24) + ' ' + $construcoes.PadRight(44) + ' ' + $c.Arquivo)
  }
  Write-Output "--- ABRE A JANELA E FAZ MAIS (todos) ---"
  foreach ($c in @($comTelas | Where-Object { -not $_.SomenteJanela })) {
    Write-Output ("{0,-24} {1,-30} sobra: {2}" -f $c.Nome, ($c.Telas -join ','), $c.Sobrou)
  }
  Write-Output "--- TOTAIS ---"
  Write-Output ("comandos: {0}; abrem janela: {1}; so abrem: {2}; com variante: {3}; ligaveis: {4}" -f $unicos.Count, $comTelas.Count, $soJanela.Count, $variante.Count, $ligaveis.Count)
  return
}

# ---------------------------------------------------------------- o mapa legivel
$doc = New-Object System.Collections.ArrayList
[void]$doc.Add('# O mapa dos comandos do reverso (comando -> janela)')
[void]$doc.Add('')
[void]$doc.Add('Gerado por `scripts/extrair-comandos-do-reverso.ps1` a partir do descompilado')
[void]$doc.Add('(`..\Elet\Eletron4_ZWcad\decompiled-cleaned`). Cada `[CommandMethod]` do original e a janela')
[void]$doc.Add('que o corpo dele abre: no original o comando e fino, quem trabalha e a janela - e ela abre')
[void]$doc.Add('**dentro do CAD** (`Application.ShowModelessDialog(this)` no construtor do `frm*`).')
[void]$doc.Add('')
[void]$doc.Add('`so abre` = o corpo nao faz outra regra alem de montar a janela. `variante` = a construcao')
[void]$doc.Add('passa argumento (`new frmRelatorio_DICemig(3)`), entao aquele comando e uma variante da tela.')
[void]$doc.Add('')
[void]$doc.Add('| comando | janela(s) | construcao | so abre | variante | ja no recoder | guarda | origem |')
[void]$doc.Add('|---|---|---|---|---|---|---|---|')
foreach ($c in $unicos) {
  $construcao = (($c.Janelas | ForEach-Object { $_.Construcao }) -join ' ')
  if ($construcao.Length -eq 0) { $construcao = '-' } else { $construcao = '`' + $construcao + '`' }
  [void]$doc.Add('| `' + $c.Nome + '` | ' + (($c.Telas | ForEach-Object { '`' + $_ + '`' }) -join ' ') + ' | ' + $construcao + ' | ' + $(if ($c.SomenteJanela) { 'sim' } else { 'nao' }) + ' | ' + $(if ($c.ComVariante) { 'sim' } else { 'nao' }) + ' | ' + $(if ($c.JaNoPlugin) { 'sim' } else { 'nao' }) + ' | ' + (($c.Guardas | ForEach-Object { '`' + $_ + '`' }) -join ' ') + ' | `' + $c.Arquivo + ':' + $c.Linha + '` |')
}
[void]$doc.Add('')
[void]$doc.Add('## Por janela')
[void]$doc.Add('')
[void]$doc.Add('As telas do mapa do layout (`docs/reverso-formularios.txt`) com os comandos do original que as')
[void]$doc.Add('abrem. Quando a construcao tem argumento, ela aparece ao lado do comando.')
[void]$doc.Add('')
[void]$doc.Add('| janela | comando(s) |')
[void]$doc.Add('|---|---|')
$porTela = @{}
foreach ($c in $comTelas) {
  foreach ($j in $c.Janelas) {
    if (-not $porTela.ContainsKey($j.Tela)) { $porTela[$j.Tela] = New-Object System.Collections.ArrayList }
    $rotulo = '`' + $c.Nome + '`'
    if ($j.ComArg) { $rotulo += ' (' + $j.Construcao + ')' }
    [void]$porTela[$j.Tela].Add($rotulo)
  }
}
foreach ($t in ($porTela.Keys | Sort-Object)) {
  [void]$doc.Add('| `' + $t + '` | ' + (($porTela[$t] | Sort-Object) -join ' ') + ' |')
}
[void]$doc.Add('')
[void]$doc.Add('## Contagens')
[void]$doc.Add('')
[void]$doc.Add('- `[CommandMethod]`: **' + $unicos.Count + '** nomes distintos no reverso.')
[void]$doc.Add('- Abrem alguma janela: **' + $comTelas.Count + '**.')
[void]$doc.Add('- **So** abrem a janela (sem outra regra no corpo): **' + $soJanela.Count + '**.')
[void]$doc.Add('- Dessas, abrem uma **variante** (construcao com argumento): **' + $variante.Count + '**.')
[void]$doc.Add('- Ja tem par no recoder: **' + @($soJanela | Where-Object { $_.JaNoPlugin }).Count + '**.')
[void]$doc.Add('- Viram comando do plugin (sem par e sem variante): **' + $ligaveis.Count + '**.')
[void]$doc.Add('')

[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Mapa), $doc)

# ---------------------------------------------------------------- a tabela compilada
$cs = New-Object System.Collections.ArrayList
[void]$cs.Add('// <auto-generated>')
[void]$cs.Add('//     Gerado por scripts/extrair-comandos-do-reverso.ps1 - nao edite a mao.')
[void]$cs.Add('//     O mapa legivel e a evidencia ficam em docs/reverso-comandos.txt.')
[void]$cs.Add('// </auto-generated>')
[void]$cs.Add('')
[void]$cs.Add('namespace Positron.Data.Interface.Mapas')
[void]$cs.Add('{')
[void]$cs.Add('    public static partial class ComandosDoReverso')
[void]$cs.Add('    {')
[void]$cs.Add('        private static Comando[] MontarOsComandos()')
[void]$cs.Add('        {')
[void]$cs.Add('            return new Comando[]')
[void]$cs.Add('            {')
foreach ($c in $unicos) {
  $janelas = 'new Janela[0]'
  if ($c.Janelas.Count -gt 0) {
    $janelas = 'new Janela[] { ' + (($c.Janelas | ForEach-Object { 'new Janela("' + $_.Tela + '", "' + $_.Construcao + '")' }) -join ', ') + ' }'
  }
  [void]$cs.Add('                new Comando("' + $c.Nome + '", "' + $c.Arquivo + '", ' + $c.Linha + ', ' +
    $(if ($c.SomenteJanela) { 'true' } else { 'false' }) + ', ' +
    $(if ($c.ComVariante) { 'true' } else { 'false' }) + ', ' +
    $(if ($c.JaNoPlugin) { 'true' } else { 'false' }) + ', ' + $janelas + '),')
}
[void]$cs.Add('            };')
[void]$cs.Add('        }')
[void]$cs.Add('    }')
[void]$cs.Add('}')
[void]$cs.Add('')

[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Dados), $cs)

# ---------------------------------------------------------------- os comandos do plugin
$ger = New-Object System.Collections.ArrayList
[void]$ger.Add('// <auto-generated>')
[void]$ger.Add('//     Gerado por scripts/extrair-comandos-do-reverso.ps1 - nao edite a mao.')
[void]$ger.Add('//     Um comando por nome do original que SO abre a janela e nao abre variante')
[void]$ger.Add('//     (o mapa completo, com as variantes e as guardas: docs/reverso-comandos.txt).')
[void]$ger.Add('// </auto-generated>')
[void]$ger.Add('')
[void]$ger.Add('#if AUTOCAD')
[void]$ger.Add('using Autodesk.AutoCAD.Runtime;')
[void]$ger.Add('#else')
[void]$ger.Add('using ZwSoft.ZwCAD.Runtime;')
[void]$ger.Add('#endif')
[void]$ger.Add('')
[void]$ger.Add('namespace Positron.Plugin')
[void]$ger.Add('{')
[void]$ger.Add('    /// <summary>')
[void]$ger.Add('    /// Os comandos do original que **so abrem a janela** (' + $ligaveis.Count + ' dos ' + $soJanela.Count + '):')
[void]$ger.Add('    /// no reverso o corpo deles monta o `frm*` e mais nada - quem trabalha e a propria janela.')
[void]$ger.Add('    /// Registrar com o nome do original e o que faz o produto responder como ele:')
[void]$ger.Add('    /// `GERDWG` abre a `frmGerenciadorDWG`, `DEF` a `frmDefinicao`, `BORN` a `frmBornes`.')
[void]$ger.Add('    ///')
[void]$ger.Add('    /// O corpo aqui e so o nome: quem sabe qual tela abrir e o mapa do reverso')
[void]$ger.Add('    /// (`Positron.Data.Interface.Mapas.ComandosDoReverso`) - uma fonte so para o mapa e o comando.')
[void]$ger.Add('    ///</summary>')
[void]$ger.Add('    public sealed class ComandosDoOriginal')
[void]$ger.Add('    {')
foreach ($c in $ligaveis) {
  [void]$ger.Add('        /// <summary>`' + $c.Nome + '` do reverso (`' + $c.Arquivo + ':' + $c.Linha + '`) - abre ' + (($c.Telas | ForEach-Object { '`' + $_ + '`' }) -join ' ') + '.</summary>')
  [void]$ger.Add('        [CommandMethod("' + $c.Nome + '")]')
  [void]$ger.Add('        public void ' + $c.Nome + '()')
  [void]$ger.Add('        {')
  [void]$ger.Add('            Plugin.Escrever(Interface.Telas.JanelasDoOriginal.Abrir("' + $c.Nome + '"));')
  [void]$ger.Add('        }')
  [void]$ger.Add('')
}
[void]$ger.Add('    }')
[void]$ger.Add('}')
[void]$ger.Add('')

[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Gerado), $ger)

Write-Output ("comandos: " + $unicos.Count)
Write-Output ("abrem janela: " + $comTelas.Count)
Write-Output ("so abrem a janela: " + $soJanela.Count)
Write-Output ("com variante: " + $variante.Count)
Write-Output ("comandos novos no plugin: " + $ligaveis.Count)
Write-Output ("mapa: " + (Join-Path (Get-Location) $Mapa))
Write-Output ("dados: " + (Join-Path (Get-Location) $Dados))
Write-Output ("comandos do plugin: " + (Join-Path (Get-Location) $Gerado))
