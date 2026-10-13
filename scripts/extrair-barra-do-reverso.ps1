# Extrai a BARRA DE FERRAMENTAS do reverso (o Ribbon.cs) na estrutura de verdade: a aba, os
# paineis na ordem em que o original os cria (CreateRibbon + CreateRibbon2) e, dentro de cada
# painel, a ARVORE de itens como o original a monta - as linhas (RibbonRowPanel) com as quebras,
# a area recolhivel (o que vem depois do RibbonPanelBreak), os separadores, os menus suspensos
# (RibbonMenuButton com os RibbonMenuItem), a lista de secao (RibbonCombo), o campo da cor
# (RibbonTextBox), o botao liga/desliga (RibbonToggleButton) e o botao do canto (DialogLauncher).
#
# Por que um interprete: o corpo de cada painel e uma sequencia regular de instrucoes - cria a
# variavel (`RibbonButton item3 = new RibbonButton()`), configura (por um dos ajudantes ou por
# propriedade) e ADICIONA a um conteiner (`val13.Items.Add(item3)`). Ler so os ajudantes (a versao
# das rodadas 129-146) achava os 121 botoes, mas perdia onde cada um mora, os 5 menus com 39 itens,
# a lista, o campo e o liga/desliga - e a barra montada saia achatada numa fileira so.
#
# Os ajudantes do original (o nome ficou ofuscado; o corpo, nao) dizem o GRAU do item:
#   Nowp1LGUQxQ(ref b, texto, "CMD ", icone, dica)  -> Grande: icone grande com texto embaixo
#   IsVp1wK9F5x(ref b, texto, "CMD ", icone, dica)  -> IconeGrande: icone grande sem texto
#   PVGp1btLkXV(ref b, "CMD ", icone, dica, texto)  -> IconeTexto: icone 16 com texto ao lado
#   UCHp1xnMtMs(ref b, "CMD ", icone, dica)         -> Icone: so o icone 16x16
#   hlxp1M9O0Oq(ref m, icone, dica)                 -> Menu: o botao do menu suspenso
#   dQ7p1OIrNSK(ref i, "CMD ", icone, dica, texto)  -> ItemDeMenu
# O icone vem do par `if (num == 0) image = X_Dark; if (num == 1) image = X;` (o COLORTHEME do
# CAD): o mapa guarda os dois.
#
# Coberto: se o recoder tem aquele comando ([CommandMethod] em qualquer .cs do plugin, inclusive
# os gerados).
#
# Uso: powershell -File scripts/extrair-barra-do-reverso.ps1
[CmdletBinding()]
param(
  # o reverso vive dentro do repo desde a rodada 134 (cad-plugin/reverso); os caminhos sao
  # relativos a raiz do repo, como os outros parametros destes extratores.
  [string] $Ribbon    = "cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4\Ribbon.cs",
  [string] $Mensagens = "cad-plugin\Positron.Data\Interface\Mapas\mensagens-pt.txt",
  [string] $Plugins   = "cad-plugin\Positron.Plugin",
  [string] $Mapa      = "docs\reverso-barra-do-original.txt",
  [string] $Dados     = "cad-plugin\Positron.Data\Interface\Mapas\BarraDoReverso.Dados.cs",
  # O mapa dos comandos (do extrair-comandos-do-reverso.ps1): diz quais botoes da barra abrem
  # janela. A barra e o mapa de telas se cruzam por aqui, sem ninguem ler o outro por acaso.
  [string] $Comandos  = "cad-plugin\Positron.Data\Interface\Mapas\ComandosDoReverso.Dados.cs"
)

if (-not (Test-Path $Ribbon)) { throw "Ribbon.cs nao encontrado: $Ribbon" }
if (-not (Test-Path $Mensagens)) { throw "mensagens nao encontradas: $Mensagens" }

# ---------------------------------------------------------------- a mMensagem (indice -> texto)
$mm = @{}
foreach ($m in [regex]::Matches([System.IO.File]::ReadAllText($Mensagens), '\{(\d+)=([^}]*)\}')) {
  $mm[[int]$m.Groups[1].Value] = $m.Groups[2].Value
}

function TextoMensagem([int] $indice) {
  if ($mm.ContainsKey($indice)) { return $mm[$indice] }
  return ""
}

# ---------------------------------------------------------------- o que o plugin ja tem
$cobertos = @{}
foreach ($arquivo in Get-ChildItem -Path $Plugins -Recurse -Filter *.cs) {
  $texto = [System.IO.File]::ReadAllText($arquivo.FullName)
  foreach ($m in [regex]::Matches($texto, '\[CommandMethod\("([^"]+)"\)\]')) {
    $cobertos[$m.Groups[1].Value] = $arquivo.Name
  }
}

# ---------------------------------------------------------------- quem abre janela (o mapa 128)
$abremJanela = @{}
if (Test-Path $Comandos) {
  $textoDosComandos = [System.IO.File]::ReadAllText($Comandos)
  # O `new Janela[] { ... }` (com a chave) e o comando que abre; o `new Janela[]` seco e o que nao
  # abre nenhuma. Procurar so o prefixo contava os dois como vazios e o cruzamento dava zero.
  foreach ($m in [regex]::Matches($textoDosComandos, 'new Comando\("([^"]+)", "[^"]*", \d+, (?:true|false), (?:true|false), (?:true|false), new Janela\[\](\s*\{)?')) {
    if (-not $m.Groups[2].Success) { continue }
    $abremJanela[$m.Groups[1].Value] = $true
  }
}

$linhas = [System.IO.File]::ReadAllLines($Ribbon)

# ---------------------------------------------------------------- chaves (o corpo de um metodo)
function FimDoCorpo([string[]] $texto, [int] $inicio) {
  $nivel = 0
  for ($i = $inicio; $i -lt $texto.Count; $i++) {
    $limpa = [regex]::Replace($texto[$i], '"(\\.|[^"\\])*"', '""')
    $nivel += ([regex]::Matches($limpa, '\{')).Count
    $nivel -= ([regex]::Matches($limpa, '\}')).Count
    if ($nivel -le 0 -and $i -gt $inicio -or ($nivel -le 0 -and ([regex]::Matches($limpa, '\{')).Count -gt 0)) {
      return $i
    }
  }
  return $texto.Count - 1
}

# ---------------------------------------------------------------- os argumentos de uma chamada
# Devolve os argumentos de nivel 1 da chamada `NOME(` que estiver na linha (ou $null).
function Argumentos([string] $linha, [string] $nome) {
  $achado = [regex]::Match($linha, [regex]::Escape($nome) + '\s*\(')
  if (-not $achado.Success) { return $null }

  $i = $achado.Index + $achado.Length
  $nivel = 1
  $texto = $false
  $atual = New-Object System.Text.StringBuilder
  $saida = New-Object System.Collections.ArrayList
  while ($i -lt $linha.Length) {
    $c = $linha[$i]
    if ($c -eq '"' -and ($i -eq 0 -or $linha[$i - 1] -ne '\')) { $texto = -not $texto }
    if (-not $texto) {
      if ($c -eq '(') { $nivel++ }
      if ($c -eq ')') {
        $nivel--
        if ($nivel -eq 0) { break }
      }
      if ($c -eq ',' -and $nivel -eq 1) {
        [void]$saida.Add($atual.ToString().Trim())
        [void]$atual.Clear()
        $i++
        continue
      }
    }

    [void]$atual.Append($c)
    $i++
  }

  [void]$saida.Add($atual.ToString().Trim())
  return $saida
}

# O texto de um argumento: literal entre aspas, ou a mMensagem por indice (o `Conversions.ToString`).
function TextoDoArgumento([string] $arg) {
  if ([string]::IsNullOrEmpty($arg)) { return "" }
  $literal = [regex]::Match($arg, '^\s*"((\\.|[^"\\])*)"\s*$')
  if ($literal.Success) {
    return [regex]::Replace($literal.Groups[1].Value, '\\r\\n', ' ').Trim()
  }

  $indice = [regex]::Match($arg, 'mMensagem\[1,\s*(\d+)\]')
  if ($indice.Success) {
    return (TextoMensagem ([int]$indice.Groups[1].Value)).Trim()
  }

  return ""
}

# Escapa o que o literal do C# nao aceita cru (a barra invertida e a aspa do rotulo do original).
function EscC([string] $texto) {
  if ($null -eq $texto) { return "" }
  return $texto.Replace('\', '\\').Replace('"', '\"')
}


# O icone de um argumento `getBitmap(...)`: `Resources.X` direto, ou o `image` do par claro/escuro.
function IconesDoArgumento([string] $arg, [string] $claro, [string] $escuro) {
  $direto = [regex]::Match($arg, 'Resources\.([A-Za-z0-9_]+)')
  if ($direto.Success) { return @($direto.Groups[1].Value, "") }
  if ($arg -match '\bimage\b') { return @($claro, $(if ($escuro -ne $claro) { $escuro } else { "" })) }
  return @("", "")
}

# Tira os casts do descompilado (`((RibbonItem)val3).Size = (RibbonItemSize)1` -> `val3.Size = 1`).
function SemCasts([string] $s) {
  return [regex]::Replace($s, '\((?:Collection<\w+>|object|Ribbon\w+|Orientation)\)', '')
}

# As instrucoes de um trecho: separa por `;` fora de texto, joga fora chaves e comentarios e guarda
# a linha (1-based) em que cada instrucao comeca.
function Instrucoes([string[]] $texto, [int] $de, [int] $ate) {
  $saida = New-Object System.Collections.ArrayList
  $atual = New-Object System.Text.StringBuilder
  $linhaDoInicio = -1
  $emTexto = $false
  for ($i = $de; $i -le $ate; $i++) {
    $linha = $texto[$i]
    if ($linha -match '^\s*//') { continue }
    for ($k = 0; $k -lt $linha.Length; $k++) {
      $c = $linha[$k]
      if ($c -eq '"' -and ($k -eq 0 -or $linha[$k - 1] -ne '\')) { $emTexto = -not $emTexto }
      if (-not $emTexto -and ($c -eq '{' -or $c -eq '}')) { [void]$atual.Append(' '); continue }
      if (-not $emTexto -and $c -eq ';') {
        $pronta = ([regex]::Replace($atual.ToString(), '\s+', ' ')).Trim()
        if ($pronta.Length -gt 0) { [void]$saida.Add([pscustomobject]@{ Texto = $pronta; Linha = $linhaDoInicio + 1 }) }
        [void]$atual.Clear()
        $linhaDoInicio = -1
        continue
      }
      if ($linhaDoInicio -lt 0 -and -not [char]::IsWhiteSpace($c)) { $linhaDoInicio = $i }
      [void]$atual.Append($c)
    }
    [void]$atual.Append(' ')
  }
  return $saida
}

$tiposPorClasse = @{
  'RibbonButton' = 'Botao'; 'RibbonMenuButton' = 'Menu'; 'RibbonMenuItem' = 'ItemDeMenu';
  'RibbonRowPanel' = 'Linha'; 'RibbonCombo' = 'ListaDeSecao'; 'RibbonTextBox' = 'CampoDeCor';
  'RibbonSeparator' = 'Separador'; 'RibbonToggleButton' = 'Alternar'
}

$ajudantes = @{
  'Nowp1LGUQxQ' = @{ Grau = 'Grande';      Rotulo = 1;  Comando = 2;  Icone = 3; Dica = 4; Texto = -1 }
  'IsVp1wK9F5x' = @{ Grau = 'IconeGrande'; Rotulo = 1;  Comando = 2;  Icone = 3; Dica = 4; Texto = -1 }
  'PVGp1btLkXV' = @{ Grau = 'IconeTexto';  Rotulo = -1; Comando = 1;  Icone = 2; Dica = 3; Texto = 4 }
  'UCHp1xnMtMs' = @{ Grau = 'Icone';       Rotulo = -1; Comando = 1;  Icone = 2; Dica = 3; Texto = -1 }
  'hlxp1M9O0Oq' = @{ Grau = 'Menu';        Rotulo = -1; Comando = -1; Icone = 1; Dica = 2; Texto = -1 }
  'dQ7p1OIrNSK' = @{ Grau = 'ItemDeMenu';  Rotulo = -1; Comando = 1;  Icone = 2; Dica = 3; Texto = 4 }
}

function NovoItem([string] $tipo, [int] $linha) {
  return [pscustomobject]@{
    Tipo = $tipo; Grau = ""; Rotulo = ""; Comando = ""; Icone = ""; IconeEscuro = ""; Dica = "";
    Largura = 0.0; Desativado = $false; Linha = $linha; Coberto = $false; AbreJanela = $false;
    Filhos = (New-Object System.Collections.ArrayList); Colocado = $false
  }
}

function Marcar($item) {
  $cmd = $item.Comando.Trim()
  $item.Comando = $cmd
  $item.Coberto = ($cmd.Length -gt 0 -and $cobertos.ContainsKey($cmd))
  $item.AbreJanela = ($cmd.Length -gt 0 -and $abremJanela.ContainsKey($cmd))
}

function Somar([string] $tipo) {
  if ($criadosPorTipo.ContainsKey($tipo)) { $criadosPorTipo[$tipo]++ } else { $criadosPorTipo[$tipo] = 1 }
}

# ---------------------------------------------------------------- a ordem dos paineis
# O CreateRibbon adiciona dois e o CreateRibbon2 mais sete; a ordem das chamadas e a ordem deles.
$ordem = New-Object System.Collections.ArrayList
$dentro = $false
foreach ($linha in $linhas) {
  if ($linha -match 'public void CreateRibbon') { $dentro = $true; continue }
  if (-not $dentro) { continue }
  if ($linha -match 'PointMonitorToolTips\.StartMonitor') { break }
  $chamada = [regex]::Match($linha, '^\s*([A-Za-z0-9_]+)\(val\);')
  if ($chamada.Success) { [void]$ordem.Add($chamada.Groups[1].Value) }
}

# ---------------------------------------------------------------- cada painel (o interprete)
$paineis = New-Object System.Collections.ArrayList
$criadosPorTipo = @{}
$soltos = New-Object System.Collections.ArrayList
$ordemDoPainel = 0
foreach ($metodo in $ordem) {
  # `private void NOME(RibbonTab P_0)` OU `private RibbonPanelSource NOME(RibbonTab P_0)`.
  $declaracao = -1
  for ($i = 0; $i -lt $linhas.Count; $i++) {
    if ($linhas[$i] -match ('\b' + [regex]::Escape($metodo) + '\s*\(RibbonTab')) { $declaracao = $i; break }
  }
  if ($declaracao -lt 0) { continue }
  $fim = FimDoCorpo $linhas $declaracao
  $ordemDoPainel++

  $variaveis = @{}
  $fonte = ""
  $indiceTitulo = -1
  $tituloLiteral = ""
  $claro = ""
  $escuro = ""
  $raiz = New-Object System.Collections.ArrayList
  $lancador = $null

  foreach ($instrucao in (Instrucoes $linhas ($declaracao + 1) $fim)) {
    $t = $instrucao.Texto

    # o par do tema: `if (num == 0) image = Resources.X_Dark` / `if (num == 1) image = Resources.X`
    $tema = [regex]::Match($t, '^if \(num == ([01])\) image = Resources\.([A-Za-z0-9_]+)$')
    if ($tema.Success) {
      if ($tema.Groups[1].Value -eq '0') { $escuro = $tema.Groups[2].Value } else { $claro = $tema.Groups[2].Value }
      continue
    }

    # a criacao: `RibbonButton item3 = new RibbonButton()`
    $criacao = [regex]::Match($t, '^(Ribbon\w+) (\w+) = new (Ribbon\w+)\(\)$')
    if ($criacao.Success) {
      $classe = $criacao.Groups[3].Value
      if ($classe -eq 'RibbonPanelSource') { $fonte = $criacao.Groups[2].Value; continue }
      if (-not $tiposPorClasse.ContainsKey($classe)) { continue }
      $item = NovoItem $tiposPorClasse[$classe] $instrucao.Linha
      $variaveis[$criacao.Groups[2].Value] = $item
      Somar $item.Tipo
      continue
    }

    # o ajudante: `IsVp1wK9F5x(ref item3, ...)`
    $chamada = [regex]::Match($t, '^(\w+)\(ref (\w+),')
    if ($chamada.Success -and $ajudantes.ContainsKey($chamada.Groups[1].Value) -and $variaveis.ContainsKey($chamada.Groups[2].Value)) {
      $a = $ajudantes[$chamada.Groups[1].Value]
      $item = $variaveis[$chamada.Groups[2].Value]
      $argumentos = Argumentos $t $chamada.Groups[1].Value
      $item.Grau = $a.Grau
      if ($a.Comando -ge 0) { $item.Comando = TextoDoArgumento $argumentos[$a.Comando] }
      $rotulo = $(if ($a.Rotulo -ge 0) { TextoDoArgumento $argumentos[$a.Rotulo] } else { "" })
      $texto = $(if ($a.Texto -ge 0 -and $argumentos.Count -gt $a.Texto) { TextoDoArgumento $argumentos[$a.Texto] } else { "" })
      $dica = $(if ($argumentos.Count -gt $a.Dica) { TextoDoArgumento $argumentos[$a.Dica] } else { "" })
      $icones = IconesDoArgumento $argumentos[$a.Icone] $claro $escuro
      $item.Icone = $icones[0]
      $item.IconeEscuro = $icones[1]
      $item.Rotulo = $(if ($texto.Length -gt 0) { $texto } else { $rotulo })
      $item.Dica = $(if ($dica.Length -gt 0) { $dica } else { $item.Rotulo })
      if ($a.Grau -eq 'Menu') { $item.Largura = 40.0 }
      Marcar $item
      continue
    }

    $limpa = SemCasts $t

    # a adicao: `val13.Items.Add(item3)` / `.Add(new RibbonRowBreak())`
    $adicao = [regex]::Match($limpa, '^\(*(\w+)\)*\.Items\)*\.Add\(+\s*(?:new (Ribbon\w+)\(\)|(\w+))')
    if ($adicao.Success) {
      $conteiner = $adicao.Groups[1].Value
      $filho = $null
      if ($adicao.Groups[2].Success) {
        switch ($adicao.Groups[2].Value) {
          'RibbonRowBreak'   { $filho = NovoItem 'QuebraDeLinha' $instrucao.Linha }
          'RibbonPanelBreak' { $filho = NovoItem 'Recolhe' $instrucao.Linha }
          'RibbonSeparator'  { $filho = NovoItem 'Separador' $instrucao.Linha; Somar 'Separador' }
        }
      } elseif ($variaveis.ContainsKey($adicao.Groups[3].Value)) {
        $filho = $variaveis[$adicao.Groups[3].Value]
        $filho.Colocado = $true
      }
      if ($null -eq $filho) { continue }
      if ($conteiner -eq $fonte) { [void]$raiz.Add($filho) }
      elseif ($variaveis.ContainsKey($conteiner) -and $variaveis[$conteiner].Tipo -ne 'ListaDeSecao') { [void]$variaveis[$conteiner].Filhos.Add($filho) }
      continue
    }

    # a propriedade: `val3.Size = 1`, `val.Title = ...`, `val.DialogLauncher = val4`
    $prop = [regex]::Match($limpa, '^\(*(\w+)\)*\.(\w+) = (.+)$')
    if (-not $prop.Success) { continue }
    $alvo = $prop.Groups[1].Value
    $nome = $prop.Groups[2].Value
    $valor = $prop.Groups[3].Value.Trim()

    if ($alvo -eq $fonte -and $nome -eq 'Title') {
      $m = [regex]::Match($valor, 'mMensagem\[1,\s*(\d+)\]')
      if ($m.Success) { $indiceTitulo = [int]$m.Groups[1].Value }
      else { $tituloLiteral = (TextoDoArgumento $valor) }
      continue
    }
    if ($alvo -eq $fonte -and $nome -eq 'DialogLauncher' -and $variaveis.ContainsKey($valor)) {
      $lancador = $variaveis[$valor]
      $lancador.Colocado = $true
      $lancador.Grau = 'Dialogo'
      continue
    }
    if (-not $variaveis.ContainsKey($alvo)) { continue }
    $item = $variaveis[$alvo]
    switch ($nome) {
      'CommandParameter' { $item.Comando = TextoDoArgumento $valor; Marcar $item }
      'Text'             { if ($item.Tipo -ne 'ListaDeSecao') { $item.Rotulo = TextoDoArgumento $valor } }
      'ToolTip'          { $item.Dica = TextoDoArgumento $valor }
      'IsActive'         { if ($valor -eq 'false') { $item.Desativado = $true } }
      'Width'            { $item.Largura = [double]::Parse($valor, [Globalization.CultureInfo]::InvariantCulture) }
      'Size'             { if ($valor -eq '1' -and $item.Grau -eq '') { $item.Grau = 'IconeGrande' } }
      'LargeImage'       { $ic = IconesDoArgumento $valor $claro $escuro; $item.Icone = $ic[0]; $item.IconeEscuro = $ic[1] }
      'Image'            { $ic = IconesDoArgumento $valor $claro $escuro; $item.Icone = $ic[0]; $item.IconeEscuro = $ic[1] }
    }
  }

  # O que foi criado e nunca entrou num conteiner (o original monta e nao usa) - vai para a conferencia.
  foreach ($chave in $variaveis.Keys) {
    $v = $variaveis[$chave]
    if (-not $v.Colocado -and $v.Tipo -ne 'Linha') {
      [void]$soltos.Add(('{0} `{1}` do painel {2} (linha {3}, comando `{4}`)' -f $v.Tipo, $chave, $ordemDoPainel, $v.Linha, $v.Comando))
    }
  }

  [void]$paineis.Add([pscustomobject]@{
    Ordem    = $ordemDoPainel
    Metodo   = $metodo
    Materia  = $indiceTitulo
    Titulo   = $(if ($indiceTitulo -ge 0) { TextoMensagem $indiceTitulo } else { $tituloLiteral })
    Linha    = $declaracao + 1
    Itens    = $raiz
    Lancador = $lancador
  })
}

# ---------------------------------------------------------------- contas
function Achatar($itens) {
  foreach ($i in $itens) { $i; if ($i.Filhos.Count -gt 0) { Achatar $i.Filhos } }
}
function DoPainel($p) {
  $lista = @(Achatar $p.Itens)
  if ($p.Lancador) { $lista += $p.Lancador }
  return $lista
}
$todosOsItens = @($paineis | ForEach-Object { DoPainel $_ })
function Contar([string] $tipo) { return @($todosOsItens | Where-Object { $_.Tipo -eq $tipo }).Count }
$acionaveis = @($todosOsItens | Where-Object { $_.Tipo -in @('Botao', 'ItemDeMenu', 'Alternar') })
$cobertosNaBarra = @($acionaveis | Where-Object { $_.Coberto })
$chamamJanela = @($acionaveis | Where-Object { $_.Coberto -and $_.AbreJanela })

$textoInteiro = $linhas -join "`n"
function NoArquivo([string] $classe) { return ([regex]::Matches($textoInteiro, 'new ' + $classe + '\(\)')).Count }
function NoMapa([string] $tipo) {
  if ($tipo -eq 'Separador') { if ($criadosPorTipo.ContainsKey('Separador')) { return $criadosPorTipo['Separador'] } else { return 0 } }
  return (Contar $tipo)
}
$conferencia = @(
  @('Botao', 'RibbonButton'), @('Menu', 'RibbonMenuButton'), @('ItemDeMenu', 'RibbonMenuItem'),
  @('Linha', 'RibbonRowPanel'), @('QuebraDeLinha', 'RibbonRowBreak'), @('Recolhe', 'RibbonPanelBreak'),
  @('ListaDeSecao', 'RibbonCombo'), @('CampoDeCor', 'RibbonTextBox'), @('Alternar', 'RibbonToggleButton'),
  @('Separador', 'RibbonSeparator')
)

$abaId = ([regex]::Match($textoInteiro, 'val\.Id = "([^"]+)"')).Groups[1].Value
$abaTitulo = ([regex]::Match($textoInteiro, 'val\.Title = "([^"]+)"')).Groups[1].Value

# ---------------------------------------------------------------- o mapa legivel
function Descrever($item) {
  switch ($item.Tipo) {
    'QuebraDeLinha' { return '(quebra de linha)' }
    'Recolhe'       { return '--- daqui para baixo, a area recolhivel (RibbonPanelBreak) ---' }
    'Separador'     { return '(separador' + $(if ($item.Largura -gt 0) { ', largura ' + $item.Largura } else { '' }) + ')' }
    'Linha'         { return 'linha' }
    'ListaDeSecao'  { return 'lista de secao (RibbonCombo, largura ' + $item.Largura + '; a BitolaCollection, grava a Secao ativa)' }
    'CampoDeCor'    { return 'campo da cor (RibbonTextBox, largura ' + $item.Largura + '; grava a Cor ativa)' }
  }
  $partes = @($item.Tipo + '/' + $item.Grau)
  if ($item.Rotulo) { $partes += '"' + $item.Rotulo + '"' }
  if ($item.Comando) { $partes += '`' + $item.Comando + '`' }
  if ($item.Icone) { $partes += 'icone ' + $item.Icone + $(if ($item.IconeEscuro) { '/' + $item.IconeEscuro } else { '' }) }
  if ($item.Desativado) { $partes += 'DESATIVADO' }
  if ($item.Comando) { $partes += $(if ($item.Coberto) { 'coberto' } else { 'nao coberto' }) + $(if ($item.AbreJanela) { ', abre janela' } else { '' }) }
  if ($item.Dica -and $item.Dica -ne $item.Rotulo) { $partes += '- ' + $item.Dica }
  return ($partes -join ' ') + ' (linha ' + $item.Linha + ')'
}

function Arvore($itens, [string] $recuo, $saida) {
  foreach ($i in $itens) {
    [void]$saida.Add($recuo + '- ' + (Descrever $i))
    if ($i.Filhos.Count -gt 0) { Arvore $i.Filhos ($recuo + '  ') $saida }
  }
}

$doc = New-Object System.Collections.ArrayList
[void]$doc.Add('# A barra de ferramentas do reverso (o `Ribbon.cs`)')
[void]$doc.Add('')
[void]$doc.Add('Gerado por `scripts/extrair-barra-do-reverso.ps1` a partir do descompilado')
[void]$doc.Add('(`cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4\Ribbon.cs`), lendo o corpo de')
[void]$doc.Add('cada painel **instrucao por instrucao** (cria, configura, adiciona ao conteiner).')
[void]$doc.Add('')
[void]$doc.Add('A aba do original e `' + $abaId + '` (**' + $abaTitulo + '**); os paineis saem na ordem em que o')
[void]$doc.Add('`CreateRibbon()` (dois) e o `CreateRibbon2()` (sete) os criam. `coberto` = o recoder responde a')
[void]$doc.Add('esse comando hoje (qualquer `[CommandMethod]` do plugin, inclusive os gerados).')
[void]$doc.Add('')
[void]$doc.Add('Graus: **Grande** (icone grande, texto embaixo), **IconeGrande** (icone grande, sem texto),')
[void]$doc.Add('**IconeTexto** (icone 16 com texto), **Icone** (so o icone 16), **Menu** (o botao do menu suspenso),')
[void]$doc.Add('**ItemDeMenu**, **Dialogo** (o botao do canto do painel).')
[void]$doc.Add('')
[void]$doc.Add('## Conferencia: o que o arquivo cria x o que o mapa leu')
[void]$doc.Add('')
[void]$doc.Add('| tipo | `new` no Ribbon.cs | no mapa |')
[void]$doc.Add('|---|---|---|')
foreach ($par in $conferencia) {
  [void]$doc.Add('| ' + $par[0] + ' | ' + (NoArquivo $par[1]) + ' | ' + (NoMapa $par[0]) + ' |')
}
[void]$doc.Add('')
[void]$doc.Add('Os separadores do mapa contam as **declaracoes** (o original reusa a mesma variavel: o `val6` do')
[void]$doc.Add('painel Fiacao entra seis vezes); na arvore, cada uso aparece. Criados e **nunca colocados** num')
[void]$doc.Add('conteiner: ' + $(if ($soltos.Count -eq 0) { 'nenhum.' } else { ($soltos -join '; ') + '.' }))
[void]$doc.Add('')
[void]$doc.Add('## Os paineis')
[void]$doc.Add('')
[void]$doc.Add('| # | painel | mMensagem | botoes | itens de menu | cobertos | metodo | linha |')
[void]$doc.Add('|---|---|---|---|---|---|---|---|')
foreach ($p in $paineis) {
  $doPainel = DoPainel $p
  [void]$doc.Add('| ' + $p.Ordem + ' | ' + $p.Titulo + ' | ' + $p.Materia + ' | ' + @($doPainel | Where-Object { $_.Tipo -eq 'Botao' }).Count + ' | ' + @($doPainel | Where-Object { $_.Tipo -eq 'ItemDeMenu' }).Count + ' | ' + @($doPainel | Where-Object { $_.Coberto }).Count + ' | `' + $p.Metodo + '` | ' + $p.Linha + ' |')
}
[void]$doc.Add('')
[void]$doc.Add('## A arvore de cada painel, na ordem do original')
foreach ($p in $paineis) {
  [void]$doc.Add('')
  [void]$doc.Add('### ' + $p.Ordem + '. ' + $p.Titulo + ' (`' + $p.Metodo + '`, linha ' + $p.Linha + ')')
  [void]$doc.Add('')
  if ($p.Lancador) { [void]$doc.Add('- canto do painel: ' + (Descrever $p.Lancador)) }
  Arvore $p.Itens '' $doc
}
[void]$doc.Add('')
[void]$doc.Add('## Contagens')
[void]$doc.Add('')
[void]$doc.Add('- Paineis: **' + $paineis.Count + '**.')
[void]$doc.Add('- Botoes: **' + (Contar 'Botao') + '**; menus: **' + (Contar 'Menu') + '** com **' + (Contar 'ItemDeMenu') + '** itens; liga/desliga: **' + (Contar 'Alternar') + '**.')
[void]$doc.Add('- Acionaveis (botao, item de menu, liga/desliga): **' + $acionaveis.Count + '** - o recoder responde a **' + $cobertosNaBarra.Count + '**, dos quais **' + $chamamJanela.Count + '** abrem janela.')
[void]$doc.Add('')
[System.IO.File]::WriteAllText((Join-Path (Get-Location) $Mapa), (($doc -join "`n") + "`n"))

# ---------------------------------------------------------------- a tabela compilada
function Bool([bool] $b) { if ($b) { return 'true' } else { return 'false' } }
function Num([double] $n) { return $n.ToString([Globalization.CultureInfo]::InvariantCulture) }

function EmitirItem($item, [string] $recuo, $saida, [string] $fim) {
  $cabeca = $recuo + 'new ItemDaBarra(TipoDoItemDaBarra.' + $item.Tipo + ', "' + (EscC $item.Grau) + '", "' + (EscC $item.Rotulo) + '", "' + (EscC $item.Comando) + '", "' + (EscC $item.Icone) + '", "' + (EscC $item.IconeEscuro) + '", "' + (EscC $item.Dica) + '", ' + (Num $item.Largura) + ', ' + (Bool $item.Desativado) + ', ' + $item.Linha + ', ' + (Bool $item.Coberto) + ', ' + (Bool $item.AbreJanela)
  if ($item.Filhos.Count -eq 0) { [void]$saida.Add($cabeca + ')' + $fim); return }
  [void]$saida.Add($cabeca + ',')
  for ($k = 0; $k -lt $item.Filhos.Count; $k++) {
    $depois = $(if ($k -lt $item.Filhos.Count - 1) { ',' } else { ')' + $fim })
    EmitirItem $item.Filhos[$k] ($recuo + '    ') $saida $depois
  }
}

$cs = New-Object System.Collections.ArrayList
[void]$cs.Add('// <auto-generated>')
[void]$cs.Add('//     Gerado por scripts/extrair-barra-do-reverso.ps1 - nao edite a mao.')
[void]$cs.Add('//     O mapa legivel e a evidencia ficam em docs/reverso-barra-do-original.txt.')
[void]$cs.Add('// </auto-generated>')
[void]$cs.Add('')
[void]$cs.Add('namespace Positron.Data.Interface.Mapas')
[void]$cs.Add('{')
[void]$cs.Add('    public static partial class BarraDoReverso')
[void]$cs.Add('    {')
[void]$cs.Add('        private const string IdDaAba = "' + (EscC $abaId) + '";')
[void]$cs.Add('')
[void]$cs.Add('        private const string TituloDaAba = "' + (EscC $abaTitulo) + '";')
[void]$cs.Add('')
[void]$cs.Add('        private static PainelDaBarra[] MontarOsPaineis()')
[void]$cs.Add('        {')
[void]$cs.Add('            return new PainelDaBarra[]')
[void]$cs.Add('            {')
foreach ($p in $paineis) {
  [void]$cs.Add('                new PainelDaBarra(' + $p.Ordem + ', "' + (EscC $p.Titulo) + '", ' + $p.Materia + ', "' + (EscC $p.Metodo) + '", ' + $p.Linha + ',')
  if ($p.Lancador) { EmitirItem $p.Lancador '                    ' $cs ',' } else { [void]$cs.Add('                    null,') }
  [void]$cs.Add('                    new ItemDaBarra[]')
  [void]$cs.Add('                    {')
  foreach ($i in $p.Itens) { EmitirItem $i '                        ' $cs ',' }
  [void]$cs.Add('                    }),')
}
[void]$cs.Add('            };')
[void]$cs.Add('        }')
[void]$cs.Add('    }')
[void]$cs.Add('}')
[System.IO.File]::WriteAllText((Join-Path (Get-Location) $Dados), (($cs -join "`n") + "`n"))

Write-Output ("aba: " + $abaId + " (" + $abaTitulo + ")")
Write-Output ("paineis: " + $paineis.Count)
foreach ($par in $conferencia) {
  Write-Output ("{0}: arquivo {1}, mapa {2}" -f $par[0], (NoArquivo $par[1]), (NoMapa $par[0]))
}
Write-Output ("acionaveis: " + $acionaveis.Count + " (cobertos " + $cobertosNaBarra.Count + ", abrem janela " + $chamamJanela.Count + ")")
Write-Output ("soltos: " + $soltos.Count + $(if ($soltos.Count -gt 0) { ' - ' + ($soltos -join '; ') } else { '' }))
